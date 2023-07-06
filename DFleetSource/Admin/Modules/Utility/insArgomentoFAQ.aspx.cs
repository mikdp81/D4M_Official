// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="insArgomentoFAQ.aspx.cs" company="">
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
    public partial class insArgomentoFAQ : System.Web.UI.Page
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
            pnlMessage.Visible = false;
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            InsertArg("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertArg("salvachiudi");
        }

        public void InsertArg(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys argNew = new Utilitys
            {
                Argomento = SeoHelper.EncodeString(txtArgomento.Text),
                Status = SeoHelper.EncodeString(ddlStatus.SelectedValue),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };
            
            
            string error = string.Empty;
            bool controlTipoFile;
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
            if (fuImmagine.HasFile == false)
            {
                controlTipoFile = false;
            }
            else
            {
                fileExt = Path.GetExtension(fuImmagine.FileName).Substring(1);

                // controllo la dimensione del file
                if (fuImmagine.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
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
                        error += "Il file non può essere caricato perché non ha un'estensione .jpg o .png";
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
                    string filename = SeoHelper.OraAttuale() + "-" + fuImmagine.FileName;
                    // salviamo il file nel percorso calcolato
                    filePath += filename;
                    fuImmagine.SaveAs(filePath);
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
                else
                {
                    argNew.Immagine = "";
                }



                if (servizioUtility.InsertArgomentoFAQ(argNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + argNew.Argomento);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        txtArgomento.Text = "";
                        ddlStatus.ClearSelection();
                        txtArgomento.CssClass = "form-control";
                        ddlStatus.CssClass = "form-control";

                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuovo Argomento o <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewArgomentiFAQ") + "'>Ritorna alla Lista</a>";
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
