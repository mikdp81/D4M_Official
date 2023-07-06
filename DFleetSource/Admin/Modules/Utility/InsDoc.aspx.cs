// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsDoc.aspx.cs" company="">
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
    public partial class InsDoc : System.Web.UI.Page
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
            pnlMessage.Visible = false;
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            InsertDoc("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertDoc("salvachiudi");
        }

        public void InsertDoc(string opzione)
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
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;
            bool controlTipoFile;
            var supportedTypes = new[] { "pdf", "docx", "doc" };
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
                if (controlTipoFile) //se i controlli sono corretti carica il file sul server
                {
                    string filename = SeoHelper.OraAttuale() + "-" + fuFileDoc.FileName;
                    // salviamo il file nel percorso calcolato
                    filePath += filename;
                    fuFileDoc.SaveAs(filePath);
                    System.Threading.Thread.Sleep(1000);

                    //controllo virus scanner
                    var scanner = new AntiVirus.Scanner();
                    var resultS = scanner.ScanAndClean(filePath);

                    if (resultS.ToString() != "VirusNotFound")
                    {
                        pnlMessage.CssClass = "alert alert-danger";
                        lblMessage.Text = "Attenzione! Si sono verificati i seguenti errori:";
                        lblMessage.Text += "<br /><br /><b>E' stato trovato un virus nel file " + filename + "</b><br />";
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
                        string result = azureBlobManager.UploadBlob(fileName, blobName, true);

                        Response.Write(result);

                        docNew.Filedocumento = filename;

                        if (servizioUtility.InsertDocumento(docNew) == 1)
                        {
                            ILogBL log = new LogBL();
                            log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + docNew.Nomedocumento);


                            if (opzione.ToUpper() == "SALVANUOVO")
                            {
                                //reset campi
                                ddlCatDoc.ClearSelection();
                                ddlCodSocieta.ClearSelection();
                                ddlCodGrade.ClearSelection();
                                ddlCodCarPolicy.ClearSelection();
                                txtDescrizione.Text = "";

                                txtDescrizione.CssClass = "form-control";
                                ddlCatDoc.CssClass = "form-control";

                                //messaggio avvenuto inserimento
                                pnlMessage.Visible = true;
                                pnlMessage.CssClass = "alert alert-success";
                                lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuovo Documento o <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewDocumenti") + "'>Ritorna alla Lista</a>";
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
