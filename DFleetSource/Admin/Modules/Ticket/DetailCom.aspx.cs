// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DetailCom.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using System.Web;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Drawing;
using DFleet.Classes;
using System.Linq;
using BusinessLogic.Services.blob;

namespace DFleet.Admin.Modules.Ticket
{
    public partial class DetailCom : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(25)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IComunicazioni data = servizioComunicazioni.DetailComunicazioni(uid);
                    if (data != null)
                    {
                        BindData(data);
                    }
                    else
                    {
                        Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                    }
                }
            }
        }

        private void BindData(IComunicazioni data)
        {
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();

            ILogBL log = new LogBL();
            log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "View Comunicazione: " + SeoHelper.EncodeString(data.Oggetto));


            //aggiorna lettura
            servizioComunicazioni.UpdatStatoLettura(data.UidcomunicazionePadre, Uidtenant);

            //modifica status comunicazione in lavorazione (solo se status aperto = 0)
            if (data.Idstatuscomunicazione == 0)
            {
                servizioComunicazioni.UpdateStatoComunicazione(10, data.UidcomunicazionePadre, Uidtenant);
            }

            //dati
            lblOggetto.Text = data.Oggetto;
            hdidoggetto.Value = data.Idoggetto.ToString();
            lblNumTicket.Text = data.Idcomunicazione.ToString();
            lblDataIns.Text = SeoHelper.CheckDataString(data.Datainvio);

            hduidcomunicazione.Value = data.Uidcomunicazione.ToString();
            hduidcomunicazionepadre.Value = data.UidcomunicazionePadre.ToString();
            hdMittente.Value = data.UserIdMittente.ToString();
            hdpriorita.Value = data.Priorita.ToString();

            lblUtente.Text = data.Cognome;
            lblEmail.Text = data.Emailmittente;
            lblGrade.Text = data.Grade;
            lblSocieta.Text = data.Societa;
        }


        public string ReturnAllegati(string uidcomunicazione)
        {
            string retVal = string.Empty;

            IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();

            List<IComunicazioni> dataAllegati = servizioComunicazioni.SelectAllegati(new Guid(uidcomunicazione));

            if (dataAllegati != null && dataAllegati.Count > 0)
            {
                retVal += "<strong>Allegati</strong><br />";
                foreach (IComunicazioni resultAll in dataAllegati)
                {
                    retVal += "- <a href=\"../../../DownloadFile?type=comunicazioni&nomefile=" + resultAll.Allegato + "\" target='_blank'>" + resultAll.Allegato + "</a><br />";
                }
            }

            return retVal;
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
            IAccountBL servizioAccount = new AccountBL();
            IUtilitysBL servizioUtility = new UtilitysBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            string error = string.Empty;
            var supportedTypes = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
            string extension;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/comunicazioni/";


            Guid Uidcomunicazione;
            Guid UidcomunicazionePadre = new Guid(hduidcomunicazionepadre.Value);
            string testo = SeoHelper.EncodeString(txtText.Text);
            int priorita = SeoHelper.IntString(hdpriorita.Value); 
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();


            HttpFileCollection uploadedFiles2 = Request.Files;

            for (int i = 0; i < uploadedFiles2.Count; i++)
            {
                HttpPostedFile userPostedFile2 = uploadedFiles2[i];

                if (userPostedFile2.ContentLength > 0)
                {
                    extension = Path.GetExtension(userPostedFile2.FileName);

                    if (!supportedTypes.Contains(extension))
                    {
                        error += "<b>File non supportato</b><br />";
                    }
                    else
                    {
                        // controllo la dimensione del file
                        if (userPostedFile2.ContentLength > SeoHelper.MaxDimensionFile())
                        {
                            error += "Il file non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(testo))
            {
                txtText.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Messaggio<br />";
            }

            if (!string.IsNullOrEmpty(error))
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione! Si sono verificati i seguenti errori:";
                lblMessage.Text += "<br /><br /><b>" + error + "</b><br />";
            }
            else
            {
                string operazioneok = string.Empty;
                string errorefile = string.Empty;


                //inserimento comunicazione
                IComunicazioni MailNew = new Comunicazioni
                {
                    UserIdMittente = (Guid)Membership.GetUser().ProviderUserKey,
                    UseridDestinatario = new Guid(hdMittente.Value),
                    Idoggetto = SeoHelper.IntString(hdidoggetto.Value),
                    Testocomunicazione = testo,
                    Priorita = priorita,
                    UidcomunicazionePadre = UidcomunicazionePadre,
                    Uidtenant = Uidtenant
                };

                if (servizioComunicazioni.InsertComunicazione(MailNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Redatta Mail: " + SeoHelper.EncodeString(lblOggetto.Text));


                    //recupero uidcomunicazione appena inserito
                    IComunicazioni data = servizioComunicazioni.ReturnUidCom();
                    if (data != null)
                    {
                        Uidcomunicazione = data.UIDcomunicazione;

                        //controllo se partner ha uno o piu delegati e se sono abilitati a ricevere mail in copia
                        string emaildelegato1 = "";
                        string emaildelegato2 = "";
                        string emaildelegato3 = "";

                        List<IContratti> dataOpt = servizioContratti.SelectDeleghePartner(MailNew.UseridDestinatario);
                        if (dataOpt != null && dataOpt.Count > 0)
                        {
                            int count = 1;

                            foreach (IContratti resultOpt in dataOpt)
                            {
                                if (count == 1)
                                {
                                    if (resultOpt.Flgemailticket == 1)
                                    {
                                        emaildelegato1 = resultOpt.Email;
                                    }
                                }

                                if (count == 2)
                                {

                                    if (resultOpt.Flgemailticket == 1)
                                    {
                                        emaildelegato2 = resultOpt.Email;
                                    }
                                }

                                if (count == 3)
                                {
                                    if (resultOpt.Flgemailticket == 1)
                                    {
                                        emaildelegato3 = resultOpt.Email;
                                    }
                                }
                                count++;
                            }
                        }

                        //invio mail
                        IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(5);
                        if (dataTemplate != null)
                        {
                            Recuperadatiuser datiUtente = new Recuperadatiuser();
                            MailHelper.SendMail("", servizioAccount.DetailId(new Guid(hdMittente.Value)).Email, emaildelegato1, emaildelegato2, emaildelegato3, "", "Help Desk - Risposta Ticket", servizioUtility.InsComEmail((Guid)Membership.GetUser().ProviderUserKey, UidcomunicazionePadre, testo, dataTemplate.Corpo), "", datiUtente.ReturnObjectTenant());
                        }



                        HttpFileCollection uploadedFiles = Request.Files;

                        for (int i = 0; i < uploadedFiles.Count; i++)
                        {
                            HttpPostedFile userPostedFile = uploadedFiles[i];

                            try
                            {
                                if (userPostedFile.ContentLength > 0)
                                {
                                    //controllo estensione del file
                                    extension = Path.GetExtension(userPostedFile.FileName);

                                    if (!supportedTypes.Contains(extension))
                                    {
                                        operazioneok += "0";
                                        errorefile += "File non supportato: " + userPostedFile.FileName + "<br />";
                                    }
                                    else
                                    {
                                        // controllo la dimensione del file
                                        if (userPostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                                        {
                                            pnlMessage.CssClass = "alert alert-danger";
                                            pnlMessage.Visible = true;
                                            lblMessage.Text = "Il file " + userPostedFile.FileName + " non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                                            operazioneok += "0";
                                        }
                                        else
                                        {
                                            string allegato = SeoHelper.OraAttuale() + "-" + userPostedFile.FileName;
                                            userPostedFile.SaveAs(filePath + "\\" + Path.GetFileName(allegato));

                                            //controllo virus scanner
                                            var scanner = new AntiVirus.Scanner();
                                            var result = scanner.ScanAndClean(filePath + "\\" + Path.GetFileName(allegato));
                                            if (result.ToString() != "VirusNotFound")
                                            {
                                                pnlMessage.CssClass = "alert alert-danger";
                                                lblMessage.Text = "Attenzione! Si sono verificati i seguenti errori:";
                                                lblMessage.Text += "<br /><br /><b>E' stato trovato un virus nel file " + allegato + "</b><br />";
                                                operazioneok += "0";
                                            }
                                            else
                                            {
                                                string containerName = "comunicazioni";
                                                string blobName = allegato;
                                                string fileName = allegato;
                                                string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/comunicazioni/";
                                                string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/comunicazioni/";
                                                string sas = Global.sas;

                                                AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                                                string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                                                Response.Write(resultBlob);

                                                //inserisce allegato
                                                IComunicazioni AllNew = new Comunicazioni
                                                {
                                                    UIDcomunicazione = Uidcomunicazione,
                                                    Allegato = allegato,
                                                    Uidtenant = Uidtenant
                                                };
                                                if (servizioComunicazioni.InsertAllegato(AllNew) == 1)
                                                {
                                                    operazioneok += "1";
                                                }
                                                else
                                                {
                                                    errorefile += "Operazione non andata a buon fine per il file " + userPostedFile.FileName + "<br />";
                                                    operazioneok += "0";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (IOException)
                            {
                                errorefile += userPostedFile.FileName + "<br />";
                                operazioneok += "0";
                            }
                        }

                        if (operazioneok.IndexOf("0") != -1)
                        {
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-danger";
                            lblMessage.Text = "Attenzione! I seguenti allegati non sono stati elaborati: <br /> " + errorefile;
                        }
                        else
                        {
                            Response.Redirect("ViewComunicazioni");
                        }
                    }
                }
            }
        }
        public string ReturnDestinatario(string destinatario)
        {
            string retVal;

            if (string.IsNullOrEmpty(destinatario))
            {
                retVal = "D4M";
            }
            else
            {
                retVal = destinatario;
            }

            return retVal;
        }

        public string ReturnTesto(string testo)
        {
            string retVal = "";

            if (!string.IsNullOrEmpty(testo))
            {
                retVal = testo.Replace("\r\n", "<br />");
            }

            return retVal;
        }
    }
}
