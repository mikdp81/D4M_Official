// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Configura.aspx.cs" company="">
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

namespace DFleet.Partner.Modules.Dash
{
    public partial class Configura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            Guid Uidtenant = datiUtente.ReturnUidTenant();

            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            string error = string.Empty;
            var supportedTypes = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
            string extension;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/ordini/";

            IContratti ConfNew = new Contratti
            {
                Testo = SeoHelper.EncodeString(txtTesto.Text),
                Uidtenant = Uidtenant
            };


            if (string.IsNullOrEmpty(ConfNew.Testo))
            {
                txtTesto.CssClass = "form-control is-invalid";
                error += "inserire una testo<br />";
            }
            else
            {
                txtTesto.CssClass = "form-control";
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
                string listallegati = "";

                if (servizioContratti.InsertConfigurazionePartner(ConfNew) == 1)
                {

                    //recupero configurazione appena inserita
                    IContratti data = servizioContratti.ReturnIdConf();
                    if (data != null)
                    {

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
                                            listallegati += allegato + "*";


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
                                                string containerName = "ordini";
                                                string blobName = allegato;
                                                string fileName = allegato;
                                                string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                                                string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                                                string sas = Global.sas;

                                                AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                                                string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                                                Response.Write(resultBlob);


                                                //inserisce allegato
                                                IContratti AllNew = new Contratti
                                                {
                                                    Idconfigurazione = data.Idconfigurazione,
                                                    Allegato = allegato,
                                                    Uidtenant = SeoHelper.ReturnSessionTenant()
                                                };

                                                if (servizioContratti.InsertAllegato(AllNew) == 1)
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
                            lblMessage.Text = "Attenzione! I seguenti allegati non sono stati elaborati: <br /> " + errorefile;
                        }
                        else
                        {
                            //invio mail
                            if (MailHelper.SendMailConfigurazione("partnercarplan@deloitte.it", servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey).Email, "Nuova Richiesta Scelta Auto Partner", ConfNew.Testo, listallegati))
                            {
                                pnlMessage.Visible = true;
                                pnlMessage.CssClass = "alert alert-success";
                                lblMessage.Text = "Invio email avvenuto correttamente. La tua richiesta sar&agrave; evasa nel pi&ugrave; tempo possibile.";
                            }
                            else
                            {
                                pnlMessage.Visible = true;
                                pnlMessage.CssClass = "alert alert-danger";
                                lblMessage.Text = "Attenzione! Email non inviata. ";
                            }
                        }
                    }
                }

            }
        
        }
    }
}
