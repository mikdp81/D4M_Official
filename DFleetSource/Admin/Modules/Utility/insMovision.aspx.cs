// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="insMovision.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Utility
{
    public partial class insMovision : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(88)) //controllo se la pagina è autorizzata per l'utente 
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
            string error = string.Empty;
            bool controlTipoFile;
            var supportedTypes = new[] { "pdf", "docx", "doc", "xls", "xlsx", "csv" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";

            // controllo se fuFileDoc contiene un file da caricare
            if (fuFileDoc.HasFile == false)
            {
                controlTipoFile = false;
                fuFileDoc.CssClass = "form-control is-invalid";
                error += "inserire il file<br />";
            }
            else
            {
                fileExt = Path.GetExtension(fuFileDoc.FileName).Substring(1);

                // controllo la dimensione del file
                if (fuFileDoc.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    error += "Il file non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        controlTipoFile = false;
                        error += "Il file non può essere caricato perché non ha un'estensione valida";
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
                    string filename = fuFileDoc.FileName;
                    string filename2 = SeoHelper.OraAttuale() + "-" + fuFileDoc.FileName;

                    // salviamo il file nel percorso calcolato
                    fuFileDoc.SaveAs(filePath + filename);
                    fuFileDoc.SaveAs(filePath + filename2);

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
                        string containerName = "movesion";
                        string containerName2 = "movesionarchivio";
                        string blobName = filename;
                        string fileName = filename;
                        string blobName2 = filename2;
                        string fileName2 = filename2;
                        string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
                        string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
                        string sas = Global.sas;
                                                
                        AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                        string result = azureBlobManager.UploadBlob(fileName, blobName, true); // salva file nella cartella movesion

                        AzureBlobManager azureBlobManager2 = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName2);
                        string result2 = azureBlobManager2.UploadBlob(fileName2, blobName2, true); // salva file nella cartella movesion archivio

                        Response.Write(result);
                        Response.Write(result2);


                        Response.Redirect("ViewMovision");
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
