// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsCom.aspx.cs" company="">
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
    public partial class InsCom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (datiUtente.ReturnAutorizzatore() == 1)
            {
                blockuser.Visible = false; //nasconde filtro user
            }
            hdautorizz.Value = datiUtente.ReturnAutorizzatore().ToString();
            pnlMessage.Visible = false;
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

            Guid Uidcomunicazione = Guid.Empty;
            int oggetto = SeoHelper.IntString(ddlOggetto.SelectedValue);
            string oggettomail = "Help Desk - " + ddlOggetto.SelectedItem.Text;
            string testo = txtText.Text;
            string tpriorita = ddlPriorita.SelectedValue;
            Guid UserId = SeoHelper.GuidString(ddlUsers.SelectedValue);
            int priorita = 0; 
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            if (!string.IsNullOrEmpty(tpriorita))
            {
                priorita = Convert.ToInt32(tpriorita);
            }

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

            if (hdautorizz.Value == "0") //controllo utente destinatario solo se non è p&p
            {
                if (UserId == Guid.Empty)
                {
                    ddlUsers.CssClass = "form-control is-invalid";
                    error += "aggiungere un utente<br />";
                }
                else
                {
                    ddlUsers.CssClass = "form-control";
                }
            }

            if (string.IsNullOrEmpty(testo))
            {
                txtText.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Messaggio<br />";
            }
            else
            {
                txtText.CssClass = "form-control";
            }

            if (oggetto == 0)
            {
                ddlOggetto.CssClass = "form-control is-invalid";
                error += "inserire un Oggetto<br />";
            }
            else
            {
                ddlOggetto.CssClass = "form-control";
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


                if (hdautorizz.Value == "1") //controllo se p&p
                {

                    //inserimento comunicazione
                    IComunicazioni MailNew = new Comunicazioni
                    {
                        UserIdMittente = (Guid)Membership.GetUser().ProviderUserKey,
                        UseridDestinatario = Guid.Empty,
                        Idoggetto = oggetto,
                        Testocomunicazione = testo,
                        Priorita = priorita,
                        Uidtenant = Uidtenant
                    };

                    if (servizioComunicazioni.InsertComunicazione(MailNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Redatta Mail: " + oggetto);


                        //recupero uidcomunicazione appena inserito
                        IComunicazioni data = servizioComunicazioni.ReturnUidCom();
                        if (data != null)
                        {
                            Uidcomunicazione = data.UIDcomunicazione;


                            //aggiorna uidcomunicazione padre
                            IComunicazioni UpdMail = new Comunicazioni
                            {
                                UidcomunicazionePadre = data.UIDcomunicazione,
                                UIDcomunicazione = data.UIDcomunicazione,
                                Uidtenant = SeoHelper.ReturnSessionTenant()
                            };
                            servizioComunicazioni.UpdateUidComunicazionePadre(UpdMail);


                            //invio mail
                            IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(3);
                            if (dataTemplate != null)
                            {
                                Recuperadatiuser datiUtente = new Recuperadatiuser();
                                MailHelper.SendMail("", servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey).Email, "", "", "", "", oggettomail, servizioUtility.InsComEmail((Guid)Membership.GetUser().ProviderUserKey, Uidcomunicazione, testo, dataTemplate.Corpo), "", datiUtente.ReturnObjectTenant());
                            }


                            HttpFileCollection uploadedFiles = Request.Files;

                            for (int i = 0; i < uploadedFiles.Count; i++)
                            {
                                HttpPostedFile userPostedFile = uploadedFiles[i];

                                try
                                {
                                    if (userPostedFile.ContentLength > 0)
                                    {
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
                                                    lblMessage.Text += "<br /><br /><b>E' stato trovato un virus nel file " + userPostedFile.FileName + "</b><br />";
                                                    operazioneok += "0";
                                                }
                                                else
                                                {
                                                    string containerName = "comunicazioni";
                                                    string blobName = userPostedFile.FileName;
                                                    string fileName = userPostedFile.FileName;
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
                                                        operazioneok += "0";
                                                        errorefile += "Operazione non andata a buon fine per il file " + userPostedFile.FileName + "<br />";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (IOException)
                                {
                                    operazioneok += "0";
                                    errorefile += "Operazione non andata a buon fine<br />";
                                }
                            }


                            if (operazioneok.IndexOf("0") != -1)
                            {
                                pnlMessage.Visible = true;
                                pnlMessage.CssClass = "alert alert-danger";
                                lblMessage.Text = "Attenzione! Le seguenti pratiche non sono state elaborate: <br /> " + errorefile;
                            }
                            else
                            {
                                pnlMessage.Visible = true;
                                pnlMessage.CssClass = "alert alert-success";
                                lblMessage.Text = "Inserimento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Users/Modules/Dash/ViewComunicazioni") + "' style='color:#fff;'>Ritorna alla Lista Comunicazioni</a>";

                            }
                        }
                    }




                }
                else //se admin
                {


                    IAccount dataUt = servizioAccount.DetailId(UserId);
                    if (dataUt != null)
                    {
                        //inserimento comunicazione
                        IComunicazioni MailNew = new Comunicazioni
                        {
                            UserIdMittente = (Guid)Membership.GetUser().ProviderUserKey,
                            UseridDestinatario = UserId,
                            Idoggetto = oggetto,
                            Testocomunicazione = testo,
                            Priorita = priorita,
                            Uidtenant = Uidtenant
                        };

                        servizioComunicazioni.InsertComunicazione(MailNew);


                        //recupero uidcomunicazione appena inserito
                        IComunicazioni data = servizioComunicazioni.ReturnUidCom();
                        if (data != null)
                        {
                            Uidcomunicazione = data.UIDcomunicazione;

                            //aggiorna uidcomunicazione padre
                            IComunicazioni UpdMail = new Comunicazioni
                            {
                                UidcomunicazionePadre = data.UIDcomunicazione,
                                UIDcomunicazione = data.UIDcomunicazione
                            };
                            servizioComunicazioni.UpdateUidComunicazionePadre(UpdMail);
                        }


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
                        IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(3);
                        if (dataTemplate != null)
                        {
                            Recuperadatiuser datiUtente = new Recuperadatiuser();
                            MailHelper.SendMail("", dataUt.Email, emaildelegato1, emaildelegato2, emaildelegato3, "", oggettomail, servizioUtility.InsComEmail((Guid)Membership.GetUser().ProviderUserKey, Uidcomunicazione, testo, dataTemplate.Corpo), "", datiUtente.ReturnObjectTenant());
                        }

                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Redatta Mail: " + oggetto);




                        HttpFileCollection uploadedFiles = Request.Files;

                        for (int i = 0; i < uploadedFiles.Count; i++)
                        {
                            HttpPostedFile userPostedFile = uploadedFiles[i];

                            try
                            {
                                if (userPostedFile.ContentLength > 0)
                                {
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
                                                    operazioneok += "0";
                                                    errorefile += "Operazione non andata a buon fine per il file " + userPostedFile.FileName + "<br />";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (IOException)
                            {
                                operazioneok += "0";
                                errorefile += "Operazione non andata a buon fine<br />";
                            }
                        }


                        if (operazioneok.IndexOf("0") != -1)
                        {
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-danger";
                            lblMessage.Text = "Attenzione! Le seguenti pratiche non sono state elaborate: <br /> " + errorefile;
                        }
                        else
                        {
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Inserimento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Ticket/ViewComunicazioni") + "' style='color:#fff;'>Ritorna alla Lista Comunicazioni</a>";

                        }

                    }
                }
            }
        }
    }
}
