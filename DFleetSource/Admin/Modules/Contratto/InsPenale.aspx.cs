// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsPenale.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text.RegularExpressions;
using System.Web;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using DFleet.Classes;
using System.IO;
using System.Linq;
using BusinessLogic.Services.blob;
using System.Collections.Generic;

namespace DFleet.Admin.Modules.Contratto
{
    public partial class InsPenale : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(85)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {             
            pnlMessage.Visible = false;
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            InsertContratto("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertContratto("salvachiudi");
        }

        public void InsertContratto(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            IContrattiBL servizioContratti = new ContrattiBL();

            IContratti contrattoNew = new Contratti
            {
                UserId = SeoHelper.GuidString(ddlUsers.SelectedValue),
                Codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue),
                Numerofattura = SeoHelper.EncodeString(txtNumeroFattura.Text),
                Datafattura = SeoHelper.DataString(txtDataFattura.Text),
                Idtipopenaleauto = SeoHelper.IntString(ddltipopenaleauto.SelectedValue),
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Importo = SeoHelper.DecimalString(txtImporto.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;
            bool controlTipoFile = false;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/contratti/";


            if (contrattoNew.UserId == Guid.Empty)
            {
                ddlUsers.CssClass = "form-control select2 is-invalid";
                error += "inserire un valore valido per il campo Partner<br />";
            }
            else
            {
                ddlUsers.CssClass = "form-control select2";
            }

            if (string.IsNullOrEmpty(contrattoNew.Codfornitore))
            {
                ddlFornitore.CssClass = "form-control select2 is-invalid";
                error += "inserire un valore valido per il campo Codice fornitore<br />";
            }
            else
            {
                ddlFornitore.CssClass = "form-control select2";
            }

            if (contrattoNew.Idtipopenaleauto == 0)
            {
                ddltipopenaleauto.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Tipo penale<br />";
            }
            else
            {
                ddltipopenaleauto.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Targa))
            {
                txtTarga.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Targa<br />";
            }



            // controllo la dimensione del file
            if (fuFilePenale.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
            {
                controlTipoFile = false;
                error += "Il file non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
            }
            else
            {
                if (fuFilePenale.HasFile == true)
                {
                    fileExt = Path.GetExtension(fuFilePenale.FileName).Substring(1);
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        controlTipoFile = false;
                        error += "Il file non può essere caricato perché non ha un'estensione .pdf";
                    }
                    else
                    {
                        controlTipoFile = true;
                    }
                }
            }

            if (!string.IsNullOrEmpty(error))
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione. Il modulo non è stato compilato correttamente. Si sono verificati i seguenti errori:";
                lblMessage.Text += "<br /><br /><b>" + error + "</b><br />";
            }
            else
            {
                if (controlTipoFile) //se i controlli sono corretti carica il file sul server
                {
                    string filename = SeoHelper.OraAttuale() + "-" + fuFilePenale.FileName;
                    // salviamo il file nel percorso calcolato
                    filePath += filename;
                    fuFilePenale.SaveAs(filePath);
                    System.Threading.Thread.Sleep(1000);

                    //controllo virus scanner
                    var scanner = new AntiVirus.Scanner();
                    var resultS = scanner.ScanAndClean(filePath);

                    if (resultS.ToString() != "VirusNotFound")
                    {
                        pnlMessage.CssClass = "alert alert-danger";
                        lblMessage.Text = "Attenzione! Si sono verificati i seguenti errori:";
                        lblMessage.Text += "<br /><br /><b>E' stato trovato un virus nel file " + filename + "</b><br />";
                    }
                    else
                    {
                        string containerName = "contratti";
                        string blobName = filename;
                        string fileName = filename;
                        string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/contratti/";
                        string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/contratti/";
                        string sas = Global.sas;

                        AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                        string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                        Response.Write(resultBlob);

                        contrattoNew.Filepenale = filename;

                        if (servizioContratti.InsertPenale(contrattoNew) == 1)
                        {
                            ILogBL log = new LogBL();
                            log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + contrattoNew.Numerofattura);



                            //controllo se partner ha uno o piu delegati e se sono abilitati a ricevere mail in copia
                            string emaildelegato1 = "";
                            string emaildelegato2 = "";
                            string emaildelegato3 = "";

                            List<IContratti> dataOpt = servizioContratti.SelectDeleghePartner(contrattoNew.UserId);
                            if (dataOpt != null && dataOpt.Count > 0)
                            {
                                int count = 1;

                                foreach (IContratti resultOpt in dataOpt)
                                {
                                    if (count == 1)
                                    {
                                        if (resultOpt.Flgemailpenali == 1)
                                        {
                                            emaildelegato1 = resultOpt.Email;
                                        }
                                    }

                                    if (count == 2)
                                    {

                                        if (resultOpt.Flgemailpenali == 1)
                                        {
                                            emaildelegato2 = resultOpt.Email;
                                        }
                                    }

                                    if (count == 3)
                                    {
                                        if (resultOpt.Flgemailpenali == 1)
                                        {
                                            emaildelegato3 = resultOpt.Email;
                                        }
                                    }
                                    count++;
                                }
                            }



                            //invio mail
                            bool result = true;

                            IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(19);
                            if (dataTemplate != null)
                            {
                                Recuperadatiuser datiUtente = new Recuperadatiuser();
                                result = MailHelper.SendMail("", "partnercarplan@deloitte.it", emaildelegato1, emaildelegato2, emaildelegato3, "", "Notifica nuova penale", dataTemplate.Corpo, "", datiUtente.ReturnObjectTenant());
                            }

                            if (result) //se invio mail è andato a buon fine
                            {
                                if (opzione.ToUpper() == "SALVANUOVO")
                                {
                                    //reset campi
                                    ddlUsers.ClearSelection();
                                    ddlFornitore.ClearSelection();
                                    ddltipopenaleauto.ClearSelection();
                                    txtTarga.Text = "";
                                    txtDataFattura.Text = "";
                                    txtNumeroFattura.Text = "";
                                    txtImporto.Text = "";
                                    txtTarga.Text = "";

                                    ddlUsers.CssClass = "form-control select2";
                                    ddlFornitore.CssClass = "form-control select2";
                                    ddltipopenaleauto.CssClass = "form-control";
                                    txtTarga.CssClass = "form-control";

                                    //messaggio avvenuto inserimento
                                    pnlMessage.Visible = true;
                                    pnlMessage.CssClass = "alert alert-success";
                                    lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuova Penale o <a href='" + ResolveUrl("~/Admin/Modules/Contratto/ViewPenali") + "'>Ritorna alla Lista</a>";
                                }
                                else
                                {
                                    Response.Redirect("ViewPenali");
                                }
                            }
                            else
                            {
                                pnlMessage.Visible = true;
                                pnlMessage.CssClass = "alert alert-danger";
                                lblMessage.Text += "Invio email fallito";
                            }
                        }
                        else
                        {
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-danger";
                            lblMessage.Text += "Operazione fallita";
                        }
                    }
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Caricamento file non avvenuto. Ripetere l'operazione";
                }
            }
        }
    }
}
