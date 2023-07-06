// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModRevisioni.aspx.cs" company="">
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
using System.IO;
using System.Linq;
using BusinessLogic.Services.blob;

namespace DFleet.Partner.Modules.Dash
{
    public partial class ModRevisioni : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailRevisioniId(uid);
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
        private void BindData(IContratti data)
        {
            lblDatiRev.Text += "Targa<br /><h3>" + data.Targa + "</h3>" +
                           "Data Revisione <br /><h3>" + data.Mese + "/" + data.Anno + "</h3>";

            if (data.Idstatuscontratto == 1)
            {
                flgcheck.Checked = true;
                btnCheck.Visible = false;

                lblDatiRev.Text += "Revisione<br /><h3> EFFETTUATA ";
                if (data.Datacheck > DateTime.MinValue)
                {
                    lblDatiRev.Text += " IL " + data.Datacheck.ToString("dd/MM/yyyy");
                }
                lblDatiRev.Text += "</h3>";
            }
            else
            {
                flgcheck.Checked = false;
                btnCheck.Visible = true;
                lblDatiRev.Text += "Revisione<br /><h3> NON EFFETTUATA</h3> ";
            }
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);

            hdFileRev.Value = data.Filepdf;
            if (!string.IsNullOrEmpty(data.Filepdf))
            {
                lblViewFileRev.Text = "<a href='../../../DownloadFile?type=contratti&nomefile=" + data.Filepdf + "'>Apri File</a>";
            }
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            string filerev = "";
            string error = string.Empty;
            bool controlTipoFile = false;
            bool controlFileLoad;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "pdf", "doc", "docx" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/contratti/";


            // controllo se fuImmagine contiene un file da caricare
            string filename = SeoHelper.OraAttuale() + "-" + fuFileRev.FileName;
            if (fuFileRev.HasFile == false)
            {
                filerev = hdFileRev.Value;
                controlFileLoad = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileRev.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad = true;
                    error += "Il file non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad = true;
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        controlTipoFile = false;
                        error += "Il file non può essere caricato perché non ha un'estensione .pdf, .doc o . docx";
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
                if (controlFileLoad) //c'è un file da caricare
                {
                    if (controlTipoFile) //se i controlli sono corretti carica il file sul server
                    {
                        // salviamo il file nel percorso calcolato
                        filePath += filename;
                        fuFileRev.SaveAs(filePath);
                        System.Threading.Thread.Sleep(1000);

                        //controllo virus scanner
                        var scanner = new AntiVirus.Scanner();
                        var resultS = scanner.ScanAndClean(filePath);

                        if (resultS.ToString() != "VirusNotFound")
                        {
                            controlTrueFileLoad = false;
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

                            filerev = filename;
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

                    if (servizioContratti.UpdateCheckRevisione(SeoHelper.GuidString(hduid.Value), SeoHelper.EncodeString(filerev), SeoHelper.ReturnSessionTenant()) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Revisione Effettuata " + SeoHelper.EncodeString(hduid.Value));

                        Response.Redirect("ViewRevisioni");
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
