// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="RichiestaAuto.aspx.cs" company="">
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

namespace DFleet.Partner.Modules.Dash
{
    public partial class RichiestaAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Int32.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out int uid))
                {
                    Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
                    IContratti data = servizioContratti.DetailVeicoloAttualeDriver(UserId);
                    if (data != null)
                    {
                        ltdati.Text += "Targa attuale <br /><h3>" + data.Targa + "</h3>" +
                                       "Veicolo <br /><h3>" + data.Modello + "</h3>" +
                                       "Fornitore <br /><h3> " + data.Fornitore + " </h3> ";

                        IContratti dataC = servizioContratti.DetailContrattiAssId(data.Idcontratto, UserId);
                        if (dataC != null)
                        {
                            ltdati2.Text += "Data consegna<br /><h3> " + dataC.Dataconsegna.ToString("dd/MM/yyyy") + "</h3>" +
                                           "Ora consegna<br /><h3> " + dataC.Oraconsegna + "</h3>" +
                                           "Luogo consegna<br /><h3> " + dataC.Luogoconsegna + "</h3>";
                        }
                    }

                    IContratti dataA = servizioContratti.DetailAssegnazioniContrattiXId(uid);
                    if (dataA != null)
                    {
                        hdidass.Value = dataA.Idassegnazione.ToString();

                        if (dataA.Flgaccettato.ToUpper() == "SI") //se già accettato
                        {
                            blockrifiuto.Visible = false;
                            hdFileLibretto.Value = dataA.Filelibrettoauto;
                            if (!string.IsNullOrEmpty(dataA.Filelibrettoauto))
                            {
                                lblViewFileLibretto.Text = "<a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataA.Filelibrettoauto + "\" target='_blank'>Apri File</a>";
                            }
                            hdFileVerbale.Value = dataA.Fileverbaleauto;
                            if (!string.IsNullOrEmpty(dataA.Fileverbaleauto))
                            {
                                lblViewFileVerbale.Text = "<a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataA.Fileverbaleauto + "\" target='_blank'>Apri File</a>";
                            }
                        }

                        if (dataA.Flgaccettato.ToUpper() == "NO") //se già rifiutato
                        {
                            blockaccetta.Visible = false;
                            hdFileRifiuto.Value = dataA.Filerifiutoauto;
                            txtMotivoRinuncia.Text = dataA.Motivorifiutoauto;
                            if (!string.IsNullOrEmpty(dataA.Filerifiutoauto))
                            {
                                lblViewFileRifiuto.Text = "<a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataA.Filerifiutoauto + "\" target='_blank'>Apri File</a>";
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                }
            }
        }       

        protected void btnRifiuta_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = new Guid(hduid.Value);

            string error = string.Empty;
            string filerinuncia = "";
            bool controlTipoFile = false;
            bool controlFileLoad;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/ordini/";


            if (string.IsNullOrEmpty(txtMotivoRinuncia.Text))
            {
                txtMotivoRinuncia.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Motivo Rinuncia<br />";
            }
            else
            {
                txtMotivoRinuncia.CssClass = "form-control";
            }

            string filename = SeoHelper.OraAttuale() + "-" + fuFileRifiuto.FileName;
            if (fuFileRifiuto.HasFile == false)
            {
                filerinuncia = hdFileRifiuto.Value;
                controlFileLoad = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileRifiuto.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
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
                        fuFileRifiuto.SaveAs(filePath);
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
                            string containerName = "ordini";
                            string blobName = filename;
                            string fileName = filename;
                            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                            string sas = Global.sas;

                            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                            string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                            Response.Write(resultBlob);

                            filerinuncia = filename;
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
                if (servizioContratti.UpdateRifiutaAuto(Uid, SeoHelper.ReturnSessionTenant()) == 1)
                {
                    if (servizioContratti.UpdateRifiutaAuto2(SeoHelper.IntString(hdidass.Value), SeoHelper.EncodeString(txtMotivoRinuncia.Text), SeoHelper.EncodeString(filerinuncia), SeoHelper.ReturnSessionTenant()) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Rifuto Auto Ordine: " + Uid);

                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Rifiuto Auto avvenuto correttamente <br />";
                    }
                    else
                    {
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-danger";
                        lblMessage.Text += "Operazione fallita";
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

        protected void btnAccetta_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = new Guid(hduid.Value);

            string error = string.Empty;
            string fileverbale = "";
            string filelibretto = "";
            bool controlTipoFile = false;
            bool controlFileLoad;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string fileExt2;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/ordini/";


            string filename = SeoHelper.OraAttuale() + "-" + fuFileVerbale.FileName;
            string filename2 = SeoHelper.OraAttuale() + "-" + fuFileLibretto.FileName;

            if (fuFileVerbale.HasFile == false)
            {
                fileverbale = hdFileVerbale.Value;
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                controlFileLoad = false;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
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
                        error += "Il file verbale non può essere caricato perché non ha un'estensione .pdf";
                    }
                    else
                    {
                        controlTipoFile = true;
                    }
                }
            }


            if (fuFileLibretto.HasFile == false)
            {
                filelibretto = hdFileLibretto.Value;
                controlFileLoad = false;
            }
            else
            {
                fileExt2 = Path.GetExtension(filename2).Substring(1);

                // controllo la dimensione del file
                if (fuFileLibretto.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad = true;
                    error += "Il file libretto non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad = true;
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt2))
                    {
                        controlTipoFile = false;
                        error += "Il file libretto non può essere caricato perché non ha un'estensione .pdf";
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
                        fuFileLibretto.SaveAs(filePath + filename2);
                        System.Threading.Thread.Sleep(1000);

                        //controllo virus scanner
                        var scanner = new AntiVirus.Scanner();
                        var resultS = scanner.ScanAndClean(filePath + filename);
                        var resultS2 = scanner.ScanAndClean(filePath + filename2);

                        if (resultS.ToString() != "VirusNotFound" && resultS2.ToString() != "VirusNotFound")
                        {
                            controlTrueFileLoad = false;
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


                            fileverbale = filename;
                            filelibretto = filename2;
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
                if (servizioContratti.UpdateAccettaAuto(Uid, SeoHelper.ReturnSessionTenant()) == 1)
                {
                    if (servizioContratti.UpdateAccettaAuto2(SeoHelper.IntString(hdidass.Value), SeoHelper.EncodeString(fileverbale), SeoHelper.EncodeString(filelibretto), SeoHelper.ReturnSessionTenant()) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Accettata Auto Ordine: " + Uid);


                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Auto Accettata correttamente <br />";
                    }
                    else
                    {
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-danger";
                        lblMessage.Text += "Operazione fallita";
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
