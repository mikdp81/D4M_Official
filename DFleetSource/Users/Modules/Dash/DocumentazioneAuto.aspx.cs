// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DocumentazioneAuto.aspx.cs" company="">
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

namespace DFleet.Users.Modules.Dash
{
    public partial class DocumentazioneAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;

            if (!Page.IsPostBack)
            {
                IContratti data = servizioContratti.DetailVeicoloAttualeDriver(UserId);
                if (data != null)
                {
                    ltdati.Text += "Targa attuale: <strong>" + data.Targa + "</strong><br />" +
                                   "Veicolo: <strong>" + data.Modello + "</strong><br />" +
                                   "Fornitore: <strong> " + data.Fornitore + " </strong><br /> " +
                                   "Fine contratto: <strong>" + data.Datafinecontratto.ToString("dd/MM/yyyy") + "</strong><br />" +
                                   "Tipo contratto: <strong>" + data.Tipocontratto + "</strong><br />" +
                                   "Mesi contrattuali: <strong>" + data.Duratamesi + "</strong><br />" +
                                   "Km contrattuali: <strong>" + data.Kmcontratto + "</strong><br /><br />";
                    hdtarga.Value = data.Targa;
                }
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            IContratti contrattoNew = new Contratti
            {
                Tipofile = SeoHelper.EncodeString("Tagliando Assicurativo"),
                Anno = SeoHelper.IntString(txtAnno.Text),
                Targa = SeoHelper.EncodeString(hdtarga.Value)
            };

            string error = string.Empty;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/contratti/";


            string filename = SeoHelper.OraAttuale() + "-" + fuFileAssicurazione.FileName;


            if (contrattoNew.Anno == 0)
            {
                txtAnno.CssClass = "form-control is-invalid";
                error += "inserire l'anno<br />";
            }
            else
            {
                txtAnno.CssClass = "form-control";
            }

            if (fuFileAssicurazione.HasFile == false)
            {
                error += "Carica il file assicurazione <br />";
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileAssicurazione.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    error += "Il file assicurazione non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        error += "Il file assicurazione non può essere caricato perché non ha un'estensione .pdf <br />";
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
                // salviamo il file nel percorso calcolato
                fuFileAssicurazione.SaveAs(filePath + filename);
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
                    string containerName = "contratti";
                    string blobName = filename;
                    string fileName = filename;
                    string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/contratti/";
                    string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/contratti/";
                    string sas = Global.sas;

                    AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                    string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                    Response.Write(resultBlob);

                    contrattoNew.Nomefile = SeoHelper.EncodeString(filename);

                    if (servizioContratti.InsertDocAuto(contrattoNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento Documento Assicurativo " + filename);


                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "File Caricato Correttamente<br />";
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
