// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="EditConfOrdini.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Ordini
{
    public partial class EditConfOrdini : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(60)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
            IContrattiBL servizioContratti = new ContrattiBL();

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailUserCarPolicyId(uid);
                    if (data != null)
                    {
                        hduid.Value = uid.ToString();
                        lblSocieta.Text = data.Codsocieta;
                        lblGrade.Text = data.Grade;
                        lblDriver.Text = data.Denominazione + "<br />" + data.Matricola;
                        ddlCodCarPolicy.SelectedValue = data.Codcarpolicy;
                        txtDatadecorrenzadal.Text = SeoHelper.CheckDataString(data.Datadecorrenza);
                        txtDatadecorrenzaal.Text = SeoHelper.CheckDataString(data.Datafinedecorrenza);
                        hdFileCarPolicy.Value = data.Documentocarpolicy;
                        hdFilePatente.Value = data.Documentopatente;
                        if (!string.IsNullOrEmpty(data.Documentocarpolicy))
                        {
                            lblViewFileCarPolicy.Text = "<div class='preview mb-5'> <i class='icon-doc'></i> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Documentocarpolicy + "\" target='_blank'>Visualizza documento </a></div><br><br>";
                        }
                        if (!string.IsNullOrEmpty(data.Documentopatente))
                        {
                            lblViewFilePatente.Text = "<div class='preview mb-5'> <i class='icon-doc'></i> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Documentopatente + "\" target='_blank'>Visualizza documento </a></div><br><br>";
                        }
                    }
                }
                else
                {
                    Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                }
            }
        }
        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            //modifica carpolicy
            IContratti ordineNew = new Contratti
            {
                Codcarpolicy = SeoHelper.EncodeString(ddlCodCarPolicy.SelectedValue),
                Datadecorrenza = SeoHelper.DataString(txtDatadecorrenzadal.Text),
                Datafinedecorrenza = SeoHelper.DataString(txtDatadecorrenzaal.Text),
                Uid = SeoHelper.GuidString(hduid.Value),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };


            string error = string.Empty;

            bool controlTipoFile = false;
            bool controlFileLoad;
            bool controlFileLoad2;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/ordini/";

            string filename = SeoHelper.OraAttuale() + "-" + fuFileCarPolicy.FileName;
            if (fuFileCarPolicy.HasFile == false)
            {
                filename = hdFileCarPolicy.Value;
                controlFileLoad = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileCarPolicy.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad = true;
                    error += "Il file carpolicy non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad = true;
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        controlTipoFile = false;
                        error += "Il file carpolicy non può essere caricato perché non ha un'estensione .pdf";
                    }
                    else
                    {
                        controlTipoFile = true;
                    }
                }
            }

            string filename2 = SeoHelper.OraAttuale() + "-" + fuFilePatente.FileName;
            if (fuFilePatente.HasFile == false)
            {
                filename2 = hdFilePatente.Value;
                controlFileLoad2 = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename2).Substring(1);

                // controllo la dimensione del file
                if (fuFilePatente.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad2 = true;
                    error += "Il file patente non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad2 = true;
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        controlTipoFile = false;
                        error += "Il file patente non può essere caricato perché non ha un'estensione .pdf";
                    }
                    else
                    {
                        controlTipoFile = true;
                    }
                }
            }

            if (string.IsNullOrEmpty(ordineNew.Codcarpolicy))
            {
                ddlCodCarPolicy.CssClass = "form-control is-invalid select2";
                error += "inserire un valore valido per il campo CarPolicy<br />";
            }
            else
            {
                ddlCodCarPolicy.CssClass = "form-control select2";
            }

            if (ordineNew.Datadecorrenza == DateTime.MinValue)
            {
                txtDatadecorrenzadal.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Data decorrenza<br />";
            }
            else
            {
                txtDatadecorrenzadal.CssClass = "form-control";
            }

            if (ordineNew.Datafinedecorrenza == DateTime.MinValue)
            {
                txtDatadecorrenzaal.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Data fine decorrenza<br />";
            }
            else
            {
                txtDatadecorrenzaal.CssClass = "form-control";
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
                if (controlFileLoad || controlFileLoad2) //c'è un file da caricare
                {
                    if (controlTipoFile) //se i controlli sono corretti carica il file sul server
                    {
                        // salviamo il file nel percorso calcolato
                        if (fuFileCarPolicy.HasFile == true)
                        {
                            fuFileCarPolicy.SaveAs(filePath + filename);
                        }
                        if (fuFilePatente.HasFile == true)
                        {
                            fuFilePatente.SaveAs(filePath + filename2);
                        }

                        System.Threading.Thread.Sleep(1000);

                        //controllo virus scanner
                        var scanner = new AntiVirus.Scanner();
                        var resultS = scanner.ScanAndClean(filePath + filename);
                        var resultS2 = scanner.ScanAndClean(filePath + filename2);

                        if (resultS.ToString() != "VirusNotFound" && resultS2.ToString() != "VirusNotFound")
                        {
                            controlTrueFileLoad = false;
                        }
                    }
                }

                if (!controlTrueFileLoad)
                {
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text = "Attenzione! Si sono verificati i seguenti errori:";
                    lblMessage.Text += "<br /><br /><b>E' stato trovato un virus nei file</b><br />";
                }
                else
                {
                    string containerName = "ordini";
                    string blobName = filename;
                    string blobName2 = filename2;
                    string fileName = filename;
                    string fileName2 = filename2;
                    string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                    string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                    string sas = Global.sas;

                    AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                    string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);
                    string resultBlob2 = azureBlobManager.UploadBlob(fileName2, blobName2, true);

                    Response.Write(resultBlob);
                    Response.Write(resultBlob2);


                    if (fuFileCarPolicy.HasFile == false)
                    {
                        ordineNew.Documentocarpolicy = hdFileCarPolicy.Value;
                    }
                    else
                    {
                        ordineNew.Documentocarpolicy = SeoHelper.EncodeString(filename);
                    }

                    if (fuFilePatente.HasFile == false)
                    {
                        ordineNew.Documentopatente = hdFilePatente.Value;
                    }
                    else
                    {
                        ordineNew.Documentopatente = SeoHelper.EncodeString(filename2);
                    }



                    if (servizioContratti.UpdateCarPolicy(ordineNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica CarPolicy " + ordineNew.Uid);

                        Response.Redirect("ViewConfDriver");
                    }
                    else
                    {
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-danger";
                        lblMessage.Text = "Operazione fallita";
                    }
                }

            }
        }

    }
}
