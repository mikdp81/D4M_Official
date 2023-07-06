// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModDoc.aspx.cs" company="">
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
using System.IO;
using System.Linq;
using BusinessLogic.Services.blob;

namespace DFleet.Admin.Modules.Utility
{
    public partial class ModDoc : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(39)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IUtilitys data = servizioUtility.DetailDocumentoId(uid);
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
        private void BindData(IUtilitys data)
        {
            ddlCatDoc.SelectedValue = SeoHelper.CheckIntString(data.Idcatdoc);
            ddlCodSocieta.SelectedValue = data.Codsocieta;
            ddlCodGrade.SelectedValue = data.Codgrade;
            ddlCodCarPolicy.SelectedValue = data.Codcarpolicy;
            txtDescrizione.Text = data.Nomedocumento;
            txtVisibileDal.Text = SeoHelper.CheckDataString(data.Visibiledal);
            txtVisibileAl.Text = SeoHelper.CheckDataString(data.Visibileal);
            hdFileDoc.Value = data.Filedocumento;
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
            if (!string.IsNullOrEmpty(data.Filedocumento))
            {
                lblViewFileDoc.Text = "<a href=\"../../../DownloadFile?type=documenti&nomefile=" + data.Filedocumento + "\" target='_blank'>Apri File</a>";
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateDoc("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateDoc("salvachiudi");
        }


        public void UpdateDoc(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys docNew = new Utilitys
            {
                Idcatdoc = SeoHelper.IntString(ddlCatDoc.SelectedValue),
                Nomedocumento = SeoHelper.EncodeString(txtDescrizione.Text),
                Codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue),
                Codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue),
                Codcarpolicy = SeoHelper.EncodeString(ddlCodCarPolicy.SelectedValue),
                Visibiledal = SeoHelper.DataString(txtVisibileDal.Text),
                Visibileal = SeoHelper.DataString(txtVisibileAl.Text),
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;
            bool controlTipoFile = false;
            bool controlFileLoad;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/documenti/";


            if (docNew.Idcatdoc == 0)
            {
                ddlCatDoc.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Categoria<br />";
            }
            else
            {
                ddlCatDoc.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(docNew.Nomedocumento))
            {
                txtDescrizione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Documento<br />";
            }
            else
            {
                txtDescrizione.CssClass = "form-control";
            }
            // controllo se fuFileDoc contiene un file da caricare
            string filename = SeoHelper.OraAttuale() + "-" + fuFileDoc.FileName;
            if (fuFileDoc.HasFile == false)
            {
                docNew.Filedocumento = hdFileDoc.Value;
                controlFileLoad = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileDoc.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
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
                if (controlFileLoad) //c'è un file da caricare
                {
                    if (controlTipoFile) //se i controlli sono corretti carica il file sul server
                    {
                        // salviamo il file nel percorso calcolato
                        filePath += filename;
                        fuFileDoc.SaveAs(filePath);
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
                            string containerName = "documenti";
                            string blobName = filename;
                            string fileName = filename;
                            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/documenti/";
                            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/documenti/";
                            string sas = Global.sas;

                            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                            string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                            Response.Write(resultBlob);

                            docNew.Filedocumento = filename;
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
                    if (servizioUtility.UpdateDocumento(docNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + docNew.Uid);


                        if (opzione.ToUpper() == "SALVA")
                        {
                            //messaggio avvenuto inserimento
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewDocumenti") + "'>Ritorna alla Lista</a>";
                        }
                        else
                        {
                            Response.Redirect("ViewDocumenti");
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
        }
    }
}
