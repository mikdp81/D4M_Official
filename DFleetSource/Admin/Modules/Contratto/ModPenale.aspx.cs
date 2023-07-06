// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModPenale.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Contratto
{
    public partial class ModPenale : System.Web.UI.Page
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
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailIdPenale(uid);
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
            txtNumeroFattura.Text = data.Numerofattura;
            txtDataFattura.Text = SeoHelper.CheckDataString(data.Datafattura);
            txtImporto.Text = SeoHelper.CheckDecimalString(data.Importo);
            ddltipopenaleauto.SelectedValue = Convert.ToString(data.Idtipopenaleauto, CultureInfo.CurrentCulture);
            ddlUsers.SelectedValue = Convert.ToString(data.UserId, CultureInfo.CurrentCulture);
            ddlFornitore.SelectedValue = data.Codfornitore;
            txtTarga.Text = data.Targa;
            hdFilePenale.Value = data.Filepenale;
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);

            if (!string.IsNullOrEmpty(data.Filepenale))
            {
                lblViewFilePenale.Text = "<a href=\"../../../DownloadFile?type=contratti&nomefile=" + data.Filepenale + "\" target='_blank'>Apri File</a>";
            }

        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateContratti("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateContratti("salvachiudi");
        }


        public void UpdateContratti(string opzione)
        {
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
                Uid = SeoHelper.GuidString(hduid.Value),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;
            bool controlTipoFile = false;
            bool controlFileLoad;
            bool controlTrueFileLoad = true;
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

            // controllo se fuFileContratto contiene un file da caricare
            string filename = SeoHelper.OraAttuale() + "-" + fuFilePenale.FileName;
            if (fuFilePenale.HasFile == false)
            {
                contrattoNew.Filepenale = hdFilePenale.Value;
                controlFileLoad = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFilePenale.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
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
                        fuFilePenale.SaveAs(filePath);
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

                            contrattoNew.Filepenale = filename;
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
                    if (servizioContratti.UpdatePenale(contrattoNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + contrattoNew.Uid);


                        if (opzione.ToUpper() == "SALVA")
                        {
                            //messaggio avvenuto inserimento
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Contratto/ViewPenali") + "'>Ritorna alla Lista</a>";
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
                        lblMessage.Text += "Operazione fallita";
                    }
                }
            }
        }
    }
}
