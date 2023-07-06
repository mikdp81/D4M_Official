// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="Importa.aspx.cs" company="">
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
using System.IO;
using System.Linq;
using DFleet.Classes;
using ExcelDataReader;
using System.Data;
using System.Xml;
using Microsoft.VisualBasic.FileIO;
using System.Text;
using BusinessLogic.Services.blob;
using System.Collections.Generic;

namespace DFleet.Admin.Modules.Tracciati
{
    public partial class Importa : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(41)) //controllo se la pagina è autorizzata per l'utente 
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
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

            string operazioneok = "";
            string errorefile = "";
            string error = "";
            var supportedTypes = new[] { ".xls", ".xlsx", ".csv", ".txt", ".xml", ".XLS", ".XLSX", ".CSV", ".TXT", ".XML" };
            string extension;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/import/";


            if (ddlTipoFile.SelectedValue == "0")
            {
                ddlTipoFile.CssClass = "form-control is-invalid";
                error += "Selezionare un tipo file<br />";
            }
            else
            {
                ddlTipoFile.CssClass = "form-control";
            }

            if (Request.Files.Count == 0 || Request.Files[0].ContentLength == 0)
            {
                error += "Caricare almeno un file<br />";
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
                HttpFileCollection uploadedFiles = Request.Files;

                for (int i = 0; i < uploadedFiles.Count; i++)
                {
                    HttpPostedFile userPostedFile = uploadedFiles[i];

                    try
                    {
                        if (userPostedFile.ContentLength > 0)
                        {
                            extension = Path.GetExtension(userPostedFile.FileName);

                            //controllo l'estensione del file
                            if (!supportedTypes.Contains(extension))
                            {
                                errorefile += "Formato file non supportato: " + userPostedFile.FileName + "<br />";
                                operazioneok += "0";
                            }
                            else
                            {
                                // controllo la dimensione del file
                                if (userPostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                                {
                                    errorefile += "Il file " + userPostedFile.FileName + " non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile() + "<br />";
                                    operazioneok += "0";
                                }
                                else
                                {
                                    string filename = SeoHelper.OraAttuale() + "-" + userPostedFile.FileName;
                                    // salviamo il file nel percorso calcolato
                                    userPostedFile.SaveAs(filePath + filename);
                                    System.Threading.Thread.Sleep(1000);

                                    //controllo virus scanner
                                    var scanner = new AntiVirus.Scanner();
                                    var resultS = scanner.ScanAndClean(filePath + filename);

                                    if (resultS.ToString() != "VirusNotFound")
                                    {
                                        errorefile += "E' stato trovato un virus nel file " + userPostedFile.FileName + "<br />";
                                        operazioneok += "0";
                                    }
                                    else
                                    {
                                        string containerName = "import";
                                        string blobName = filename;
                                        string fileName = filename;
                                        string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/import/";
                                        string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/import/";
                                        string sas = Global.sas;

                                        AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                                        string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                                        Response.Write(resultBlob);


                                        //inserimento file in db
                                        IFileTracciati SaveFile = new FileTracciati
                                        {
                                            Idtipofile = SeoHelper.IntString(ddlTipoFile.SelectedValue),
                                            Nomefile = SeoHelper.EncodeString(filename),
                                            Periododal = SeoHelper.DataString(txtPeriododal.Text),
                                            Periodoal = SeoHelper.DataString(txtPeriodoal.Text),
                                            Idtelep = SeoHelper.IntString(ddlTemplate.SelectedValue),
                                            Uidtenant = SeoHelper.ReturnSessionTenant()
                                        };

                                        if (servizioFileTracciati.InsertStoricoImportazione(SaveFile) == 1)
                                        {
                                            operazioneok += "1";
                                        }
                                        else
                                        {
                                            operazioneok += "0";
                                            errorefile += "Errore importazione tracciato nel file " + userPostedFile.FileName + "<br />";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (IOException ex)
                    {
                        operazioneok += "0";
                        errorefile += "Operazione non andata a buon fine<br />" + ex.Message;
                    }
                }

                if (operazioneok.IndexOf("0") != -1)
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text = "Attenzione! <br /> " + errorefile;
                }
                else
                {
                    Response.Redirect("ViewImportazioni");
                }

            }
        }
    }
}
