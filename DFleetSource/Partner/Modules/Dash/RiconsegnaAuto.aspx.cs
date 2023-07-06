// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="RiconsegnaAuto.aspx.cs" company="">
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
    public partial class RiconsegnaAuto : System.Web.UI.Page
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
                    ltdati.Text += "Targa attuale <br /><h3>" + data.Targa + "</h3>" +
                                   "Veicolo <br /><h3>" + data.Modello + "</h3>" +
                                   "Fornitore <br /><h3> " + data.Fornitore + " </h3> ";

                    IContratti dataA = servizioContratti.DetailContrattiAssId(data.Idcontratto, UserId);
                    if (dataA != null)
                    {
                        hdidass.Value = dataA.Idassegnazione.ToString();
                        ltdati2.Text += "Data Riconsegna<br /><h3> " + dataA.Datarestituzione.ToString("dd/MM/yyyy") + "</h3>" +
                                       "Ora Riconsegna<br /><h3> " + dataA.Orarestituzione + "</h3>" +
                                       "Luogo Riconsegna<br /><h3> " + dataA.Luogorestituzione + " " + dataA.Centrorestituzione + "</h3>";
                    }
                }
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            int idassegnazione = SeoHelper.IntString(hdidass.Value);

            IContratti contrattoNew = new Contratti
            {
                Tipogomme = SeoHelper.EncodeString(ddlTipoGomme.SelectedValue),
                Luogogomme = SeoHelper.EncodeString(txtLuogoGomme.Text),
                Datacambiogomme = SeoHelper.DataString(txtDataCambioGomme.Text),
                Kmrestituzione = SeoHelper.DecimalString(txtKmRestituzione.Text),
                Notedriver = SeoHelper.EncodeString(txtAnnotazionicontratto.Text),
                Idassegnazione = idassegnazione,
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;
            string fileverbale = "";
            string filerelazione = "";
            string filedenuncia = "";
            bool controlTipoFile = false;
            bool controlFileLoad;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string fileExt2;
            string fileExt3;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/ordini/";


            string filename = SeoHelper.OraAttuale() + "-" + fuFileVerbale.FileName;
            string filename2 = SeoHelper.OraAttuale() + "-" + fuFileRelazione.FileName;
            string filename3 = SeoHelper.OraAttuale() + "-" + fuFileDenunce.FileName;


            if (string.IsNullOrEmpty(contrattoNew.Tipogomme))
            {
                ddlTipoGomme.CssClass = "form-control is-invalid";
                error += "inserire il tipo gomme<br />";
            }
            else
            {
                ddlTipoGomme.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Luogogomme))
            {
                txtLuogoGomme.CssClass = "form-control is-invalid";
                error += "inserire il luogo gomme<br />";
            }
            else
            {
                txtLuogoGomme.CssClass = "form-control";
            }

            if (contrattoNew.Datacambiogomme == DateTime.MinValue)
            {
                txtDataCambioGomme.CssClass = "form-control is-invalid";
                error += "inserire una data cambio gomme valida<br />";
            }
            else
            {
                txtDataCambioGomme.CssClass = "form-control";
            }

            if (contrattoNew.Kmrestituzione == 0)
            {
                txtKmRestituzione.CssClass = "form-control is-invalid";
                error += "inserire i km restituzione<br />";
            }
            else
            {
                txtKmRestituzione.CssClass = "form-control";
            }


            if (fuFileVerbale.HasFile == false)
            {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                controlFileLoad = false;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
                error += "Carica il file verbale <br />";
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileVerbale.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                    controlFileLoad = true;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
                    error += "Il file verbale non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                    controlFileLoad = true;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
                               //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        controlTipoFile = false;
                        error += "Il file verbale non può essere caricato perché non ha un'estensione .pdf <br />";
                    }
                    else
                    {
                        controlTipoFile = true;
                    }
                }
            }


            if (fuFileRelazione.HasFile == false)
            {
                controlFileLoad = false;
                error += "Carica il file relazione <br />";
            }
            else
            {
                fileExt2 = Path.GetExtension(filename2).Substring(1);

                // controllo la dimensione del file
                if (fuFileRelazione.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad = true;
                    error += "Il file relazione non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad = true;
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt2))
                    {
                        controlTipoFile = false;
                        error += "Il file relazione non può essere caricato perché non ha un'estensione .pdf <br />";
                    }
                    else
                    {
                        controlTipoFile = true;
                    }
                }
            }


            if (fuFileDenunce.HasFile == false)
            {
                
            }
            else
            {
                fileExt3 = Path.GetExtension(filename3).Substring(1);

                // controllo la dimensione del file
                if (fuFileDenunce.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad = true;
                    error += "Il file denunce non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad = true;
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt3))
                    {
                        controlTipoFile = false;
                        error += "Il file denunce non può essere caricato perché non ha un'estensione .pdf <br />";
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
                        fuFileVerbale.SaveAs(filePath + filename);
                        fuFileRelazione.SaveAs(filePath + filename2);
                        if (fuFileDenunce.HasFile == true)
                        {
                            fuFileDenunce.SaveAs(filePath + filename3);
                        }

                        System.Threading.Thread.Sleep(1000);

                        //controllo virus scanner
                        var scanner = new AntiVirus.Scanner();
                        var resultS = scanner.ScanAndClean(filePath + filename);
                        var resultS2 = scanner.ScanAndClean(filePath + filename2);
                        var resultS3 = scanner.ScanAndClean(filePath + filename3);

                        if (resultS.ToString() != "VirusNotFound" && resultS2.ToString() != "VirusNotFound" && resultS3.ToString() != "VirusNotFound")
                        {
                            controlTrueFileLoad = false;
                        }
                        else
                        {
                            string containerName = "ordini";
                            string blobName = filename;
                            string blobName2 = filename2;
                            string blobName3 = filename3;
                            string fileName = filename;
                            string fileName2 = filename2;
                            string fileName3 = filename3;
                            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                            string sas = Global.sas;

                            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                            string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);
                            string resultBlob2 = azureBlobManager.UploadBlob(fileName2, blobName2, true);

                            Response.Write(resultBlob);
                            Response.Write(resultBlob2);



                            fileverbale = filename;
                            filerelazione = filename2;
                            if (fuFileDenunce.HasFile == true)
                            {
                                string resultBlob3 = azureBlobManager.UploadBlob(fileName3, blobName3, true);
                                Response.Write(resultBlob3);
                                filedenuncia = filename3;
                            }                            
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
                    contrattoNew.Fileverbaleconsegna = SeoHelper.EncodeString(fileverbale);
                    contrattoNew.Filerelazioneperito = SeoHelper.EncodeString(filerelazione);
                    contrattoNew.Filedenunce = SeoHelper.EncodeString(filedenuncia);

                    if (servizioContratti.UpdateContrattiAssDriver(contrattoNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "File Riconsegna Auto Caricati: " + idassegnazione);


                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "File Caricati Correttamente<br />";
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
