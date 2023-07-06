// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Procedure.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using DFleet.Classes;
using System.Linq;
using System.IO;
using BusinessLogic.Services.blob;

namespace DFleet.Users.Modules.Dash
{
    public partial class Procedure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
            pnlMessage2.Visible = false;
            hdiduser.Value = Membership.GetUser().ProviderUserKey.ToString();



            /*IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
       
            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                IContratti dataC = servizioContratti.DetailVeicoloAttualeDriver(UserId);
                if (dataC != null)
                {
                    IContratti dataD = servizioContratti.DetailDocDelegaXId(UserId, dataC.Targa);
                    if (dataD != null)
                    {
                        if (!string.IsNullOrEmpty(dataD.Filepdf))
                        {
                            lblViewFilePdf.Text = "(<a href='../../../DownloadFile?type=deleghe&nomefile=" + dataD.Filepdf + "' target='_blank'>Apri File Documento</a>)";
                        }

                        if (dataD.Tipoutente.ToUpper() == "CONVIVENTE" && 
                            (dataD.Cittaresidenza == dataD.Cittaresidenzadelegato) &&
                            (dataD.Indirizzoresidenza == dataD.Indirizzoresidenzadelegato) && 
                            (dataD.Civicoresidenza == dataD.Civicoresidenzadelegato) )
                        {
                            lblViewFilePdfConv.Text = "(<a href='../../../Repository/documenti/Modulo-autocertificazione-di-convivenza.doc' target='_blank'>Scarica firma e invia il seguente modulo</a>)";
                        }

                    }
                    IContratti dataD2 = servizioContratti.DetailDocZTLXId(UserId, dataC.Targa);
                    if (dataD2 != null)
                    {
                        if (!string.IsNullOrEmpty(dataD2.Filepdf))
                        {
                            lblViewFilePdfZTL.Text = "(<a href='../../../DownloadFile?type=deleghe&nomefile=" + dataD2.Filepdf + "' target='_blank'>Apri File Documento</a>)";
                        }
                    }
                }
            
            }
            else
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }*/
        }

        public string ReturnCodCarPolicy(string codsocieta, string gradecode)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string retVal = string.Empty;

            IContratti dataCodPol = servizioContratti.ReturnCodCarPolicy(codsocieta, gradecode);
            if (dataCodPol != null)
            {
                retVal = dataCodPol.Codcarpolicy;
            }

            return retVal;
        }

        public string ReturnData(string data)
        {
            string retVal = string.Empty;

            if (string.IsNullOrEmpty(data) || data == "01/01/0001 00:00:00")
            {
                retVal = "";
            }
            else
            {
                string[] data1 = data.Split(' ');
                retVal += data1[0];
            }

            return retVal;
        }
        public string ReturnModuloFirmato(string modulofirmato, string note, string checkdoc, string tipomodulo, string cittaresidenza, string indirizzoresidenza, string civicoresidenza, 
            string cittaresidenzadelegato, string indirizzoresidenzadelegato, string civicoresidenzadelegato, string Uid, string moduloconvivenza)
        {
            string retVal = "";
            string tipofile = "";

            if (tipomodulo == "1")
            {
                tipofile = "Apri delega";
            }
            if (tipomodulo == "2")
            {
                tipofile = "Apri richiesta ZTL";
            }

            if (string.IsNullOrEmpty(checkdoc))
            {
                retVal = "IN ATTESA<br />";
            }
            else
            {
                if (checkdoc.ToUpper() == "SI")
                {
                    retVal = "APPROVATO<br />";
                }
                if (checkdoc.ToUpper() == "NO")
                {
                    retVal = "NON APPROVATO<br />";
                }

                if (!string.IsNullOrEmpty(modulofirmato))
                {
                    if (checkdoc.ToUpper() == "SI")
                    {
                        retVal += "<a href=\"../../../DownloadFile?type=deleghe&nomefile=" + modulofirmato + "\" target='_blank'>" + tipofile + "</a><br /> ";
                    }
                }
                if (!string.IsNullOrEmpty(note))
                {
                    retVal += note;
                }
            }

            string residenza = cittaresidenza + " " + indirizzoresidenza;
            string residenzadelegato = cittaresidenzadelegato + " " + indirizzoresidenzadelegato;

            if (!string.IsNullOrEmpty(residenza))
            {
                if (residenza.ToUpper() != residenzadelegato.ToUpper())
                {
                    if (string.IsNullOrEmpty(moduloconvivenza))
                    {
                        retVal += "<br /><a href='../../../Repository/documenti/Modulo-autocertificazione-di-convivenza.doc' target='_blank'>Scarica il modulo di autocertificazione</a><br />";
                        retVal += "<a href='ModuloConv-" + SeoHelper.EncodeString(Uid) + "' target='_blank'>Carica il modulo di autocertificazione compilato e firmato</a><br /> ";
                    }
                }
            }

            return retVal;
        }

        /*protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            string error = string.Empty;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/deleghe/";


            string filename = SeoHelper.OraAttuale() + "-" + fuFileDelega.FileName;
            if (fuFileDelega.HasFile == false)
            {
                error += "Il file delega non caricato ";
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileDelega.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    error += "Il file delega non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        error += "Il file delega non può essere caricato perché non ha un'estensione .pdf";
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

                // salviamo il file nel percorso calcolato
                fuFileDelega.SaveAs(filePath + filename);
                System.Threading.Thread.Sleep(1000);

                //controllo virus scanner
                var scanner = new AntiVirus.Scanner();
                var resultS = scanner.ScanAndClean(filePath + filename);

                if (resultS.ToString() != "VirusNotFound")                
                {
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text = "Attenzione! Si sono verificati i seguenti errori:";
                    lblMessage.Text += "<br /><br /><b>E' stato trovato un virus nel file " + filename + "</b><br />";
                }
                else
                {
                    string containerName = "deleghe";
                    string blobName = filename;
                    string fileName = filename;
                    string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/deleghe/";
                    string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/deleghe/";
                    string sas = Global.sas;

                    AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                    string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                    Response.Write(resultBlob);

                    IContratti delNew = new Contratti
                    {
                        Idtipomodulo = 1,
                        Modulodafirmare = SeoHelper.EncodeString(filename)
                    };

                    if (servizioContratti.InsertDelega(delNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Caricamento Nuova Delega");


                        Response.Redirect("Procedure");
                    }
                    else
                    {
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-danger";
                        lblMessage.Text += "Operazione fallita";
                    }
                }
            }
        }

        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            string error = string.Empty;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/deleghe/";


            string filename = SeoHelper.OraAttuale() + "-" + fuFileZTL.FileName;
            if (fuFileZTL.HasFile == false)
            {
                error += "Il file ztl non caricato ";
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileZTL.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    error += "Il file ztl non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        error += "Il file ztl non può essere caricato perché non ha un'estensione .pdf";
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

                // salviamo il file nel percorso calcolato
                fuFileZTL.SaveAs(filePath + filename);
                System.Threading.Thread.Sleep(1000);

                //controllo virus scanner
                var scanner = new AntiVirus.Scanner();
                var resultS = scanner.ScanAndClean(filePath + filename);

                if (resultS.ToString() != "VirusNotFound")
                {
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text = "Attenzione! Si sono verificati i seguenti errori:";
                    lblMessage.Text += "<br /><br /><b>E' stato trovato un virus nel file " + filename + "</b><br />";
                }
                else
                {
                    string containerName = "deleghe";
                    string blobName = filename;
                    string fileName = filename;
                    string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/deleghe/";
                    string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/deleghe/";
                    string sas = Global.sas;

                    AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                    string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                    Response.Write(resultBlob);

                    IContratti delNew = new Contratti
                    {
                        Idtipomodulo = 2,
                        Modulodafirmare = SeoHelper.EncodeString(filename)
                    };

                    if (servizioContratti.InsertDelega(delNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Caricamento Nuova Richiesta ZTL");


                        Response.Redirect("Procedure");
                    }
                    else
                    {
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-danger";
                        lblMessage.Text += "Operazione fallita";
                    }
                }
            }
        }*/
    }
}
