// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModuloConv.aspx.cs" company="">
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
using System.Linq;
using DFleet.Classes;
using System.IO;
using BusinessLogic.Services.blob;

namespace DFleet.Users.Modules.Dash
{
    public partial class ModuloConv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;

            IContrattiBL servizioContratti = new ContrattiBL();

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {

                    IContratti data = servizioContratti.ReturnModConv(uid);
                    if (data != null)
                    {
                        hdFileDocConv.Value = data.Moduloconvivenza;
                        if (!string.IsNullOrEmpty(data.Moduloconvivenza))
                        {
                            lblViewFileDocConv.Text = "<div class='preview mb-5'> <i class='icon-doc'></i> <a href=\"../../../DownloadFile?type=deleghe&nomefile=" + data.Moduloconvivenza + "\" target='_blank'>Visualizza il documento di autocertificazione di convivenza</a></div><br><br>";
                        }
                        hduid.Value = uid.ToString();
                    }
                }
            }                        
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = new Guid(hduid.Value);

            string error = string.Empty;
            bool controlTipoFile = false;
            bool controlFileLoad = false;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/deleghe/";


            string filename = SeoHelper.OraAttuale() + "-" + fuFileDocConv.FileName;
            if (fuFileDocConv.HasFile == false)
            {
                filename = hdFileDocConv.Value;
                controlFileLoad = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileDocConv.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
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
                        error += "Il file non può essere caricato perché non ha un'estensione .pdf";
                    }
                    else
                    {
                        controlFileLoad = true;
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
                if (controlFileLoad) //c'è un file da caricare
                {
                    if (controlTipoFile) //se i controlli sono corretti carica il file sul server
                    {
                        // salviamo il file nel percorso calcolato
                        if (fuFileDocConv.HasFile == true)
                        {
                            fuFileDocConv.SaveAs(filePath + filename);
                        }


                        System.Threading.Thread.Sleep(1000);

                        //controllo virus scanner
                        var scanner = new AntiVirus.Scanner(); 
                        var resultS = scanner.ScanAndClean(filePath + filename);

                        if (resultS.ToString() != "VirusNotFound")
                        {
                            controlTrueFileLoad = false;
                        }
                    }
                }


                if (!controlTrueFileLoad)
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


                    if (servizioContratti.UpdateModConv(Uid, filename, SeoHelper.ReturnSessionTenant()) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Caricamento Modulo di Convivenza  " + Uid);


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
    }
}
