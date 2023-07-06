// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModArgomentoFAQ.aspx.cs" company="">
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
    public partial class ModArgomentoFAQ : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(57)) //controllo se la pagina è autorizzata per l'utente 
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
                    IUtilitys data = servizioUtility.DetailArgomentoFAQId(uid);
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
            txtArgomento.Text = data.Argomento;
            ddlStatus.SelectedValue = data.Status;
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
            hdImmagine.Value = data.Immagine;
            if (!string.IsNullOrEmpty(data.Immagine))
            {
                lblViewImmagine.Text = "<img src='../../../DownloadFile?type=faq&nomefile=" + data.Immagine + "' width='150' alt='' border='0' />";
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateArg("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateArg("salvachiudi");
        }


        public void UpdateArg(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys argNew = new Utilitys
            {
                Argomento = SeoHelper.EncodeString(txtArgomento.Text),
                Status = SeoHelper.EncodeString(ddlStatus.SelectedValue),
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;
            bool controlTipoFile = false;
            bool controlFileLoad;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "jpg", "png" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/faq/";


            if (string.IsNullOrEmpty(argNew.Argomento))
            {
                txtArgomento.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Argomento<br />";
            }
            else
            {
                txtArgomento.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(argNew.Status))
            {
                ddlStatus.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Status<br />";
            }
            else
            {
                ddlStatus.CssClass = "form-control";
            }

            // controllo se fuImmagine contiene un file da caricare
            string filename = SeoHelper.OraAttuale() + "-" + fuImmagine.FileName;
            if (fuImmagine.HasFile == false)
            {
                argNew.Immagine = hdImmagine.Value;
                controlFileLoad = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuImmagine.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
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
                        fuImmagine.SaveAs(filePath);
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
                            string containerName = "faq";
                            string blobName = filename;
                            string fileName = filename;
                            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/faq/";
                            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/faq/";
                            string sas = Global.sas;

                            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                            string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                            Response.Write(resultBlob);

                            argNew.Immagine = filename;
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
                    if (servizioUtility.UpdateArgomentiFAQ(argNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + argNew.Uid);


                        if (opzione.ToUpper() == "SALVA")
                        {
                            //messaggio avvenuto inserimento
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewArgomentiFAQ") + "'>Ritorna alla Lista</a>";
                        }
                        else
                        {
                            Response.Redirect("ViewArgomentiFAQ");
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
