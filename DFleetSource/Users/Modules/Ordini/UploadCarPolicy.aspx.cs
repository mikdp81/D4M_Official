// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModScarta.aspx.cs" company="">
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

namespace DFleet.Users.Modules.Ordini
{
    public partial class UploadCarPolicy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;

            IContrattiBL servizioContratti = new ContrattiBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;

            IContratti data = servizioContratti.ReturnUidCarPolicy(UserId);
            if (data != null)
            {
                hdFileCarPolicy.Value = data.Documentocarpolicy;
                if (!string.IsNullOrEmpty(data.Documentocarpolicy))
                {
                    lblViewFileCarPolicy.Text = "<div class='preview mb-5'> <i class='icon-doc'></i> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Documentocarpolicy + "\" target='_blank'>Visualizza il documento caricato</a></div><br><br>";
                }
                hdFilePatente.Value = data.Documentopatente;
                if (!string.IsNullOrEmpty(data.Documentopatente))
                {
                    lblViewFilePatente.Text = "<div class='preview mb-5'> <i class='icon-doc'></i> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Documentopatente + "\" target='_blank'>Visualizza la patente caricata</a></div><br><br>";
                }
                hdFileFuelCard.Value = data.Documentofuelcard;
                if (!string.IsNullOrEmpty(data.Documentofuelcard))
                {
                    lblViewFileFuelCard.Text = "<div class='preview mb-5'> <i class='icon-doc'></i> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Documentofuelcard + "\" target='_blank'>Visualizza richiesta fuel card</a></div><br><br>";
                }
                hduid.Value = data.Uid.ToString();
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = new Guid(hduid.Value);

            string error = string.Empty;
            bool controlTipoFile = false;
            bool controlFileLoad = false;
            bool controlFileLoad2 = false;
            bool controlFileLoad3 = false;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string fileExt2;
            string fileExt3;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/ordini/";


            string filename = SeoHelper.OraAttuale() + "-" + fuFileCarPolicy.FileName;
            string filename2 = SeoHelper.OraAttuale() + "-" + fuFilePatente.FileName;
            string filename3 = SeoHelper.OraAttuale() + "-" + fuFileFuelCard.FileName;
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
                    error += "Il file carpolicy non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        controlTipoFile = false;
                        error += "Il file carpolicy non può essere caricato perché non ha un'estensione .pdf";
                    }
                    else
                    {
                        controlFileLoad = true;
                        controlTipoFile = true;
                    }
                }
            }

            if (fuFilePatente.HasFile == false)
            {
                filename2 = hdFilePatente.Value;
                controlFileLoad2 = false;
            }
            else
            {
                fileExt2 = Path.GetExtension(filename2).Substring(1);

                // controllo la dimensione del file
                if (fuFilePatente.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    error += "Il file patente non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt2))
                    {
                        controlTipoFile = false;
                        error += "Il file patente non può essere caricato perché non ha un'estensione .pdf";
                    }
                    else
                    {
                        controlFileLoad2 = true;
                        controlTipoFile = true;
                    }
                }
            }

            if (fuFileFuelCard.HasFile == false)
            {
                filename3 = hdFileFuelCard.Value;
                controlFileLoad3 = false;
            }
            else
            {
                fileExt3 = Path.GetExtension(filename3).Substring(1);

                // controllo la dimensione del file
                if (fuFileFuelCard.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad = true;
                    error += "Il file richiesta fuel card non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad = true;
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt3))
                    {
                        controlTipoFile = false;
                        error += "Il file richiesta fuel card non può essere caricato perché non ha un'estensione .pdf";
                    }
                    else
                    {
                        controlTipoFile = true;
                        controlFileLoad3 = true;
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
                if (controlFileLoad || controlFileLoad2 || controlFileLoad3) //c'è un file da caricare
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
                        if (fuFileFuelCard.HasFile == true)
                        {
                            fuFileFuelCard.SaveAs(filePath + filename3);
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
                    string resultBlob3 = azureBlobManager.UploadBlob(fileName3, blobName3, true);

                    Response.Write(resultBlob);
                    Response.Write(resultBlob2);
                    Response.Write(resultBlob3);


                    if (servizioContratti.UpdateDocCarPolicy(Uid, filename, filename2, filename3, SeoHelper.ReturnSessionTenant()) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Caricamento CarPolicy  " + Uid);


                        Response.Redirect("ConfiguraAuto");
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
