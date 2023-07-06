// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="UploadFuel.aspx.cs" company="">
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

namespace DFleet.Users.Modules.Dash
{
    public partial class UploadFuel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;

            IContrattiBL servizioContratti = new ContrattiBL();

            if (!Page.IsPostBack)
            {
                if (Int32.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out int uid))
                {
                    IContratti data = servizioContratti.ReturnFileAuto(uid);
                    if (data != null)
                    {
                        hdFileVerbale.Value = data.Fileverbaleconsegna;
                        hdFileRelazione.Value = data.Filerelazioneperito;
                        hdFileDenunce.Value = data.Filedenunce;
                        hdFileRifiutoAuto.Value = data.Filerifiutoauto;
                        hdFileVerbaleAuto.Value = data.Fileverbaleauto;
                        hdFileLibrettoAuto.Value = data.Filelibrettoauto;
                        hdFuelCard.Value = data.Documentofuelcard;

                        if (!string.IsNullOrEmpty(data.Fileverbaleconsegna))
                        {
                            lblViewFileFileVerbale.Text = "<div class='preview mb-5'> <i class='icon-doc'></i> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Fileverbaleconsegna + "\" target='_blank'>Visualizza Verbale presa in consegna auto</a></div><br><br>";
                            fuFileVerbale.Visible = false;
                        }
                        if (!string.IsNullOrEmpty(data.Filerelazioneperito))
                        {
                            lblViewFileRelazione.Text = "<div class='preview mb-5'> <i class='icon-doc'></i> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Filerelazioneperito + "\" target='_blank'>Visualizza Relazione perito</a></div><br><br>";
                            fuFileRelazione.Visible = false;
                        }
                        if (!string.IsNullOrEmpty(data.Filedenunce))
                        {
                            lblViewFileDenunce.Text = "<div class='preview mb-5'> <i class='icon-doc'></i> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Filedenunce + "\" target='_blank'>Visualizza Denunce</a></div><br><br>";
                            fuFileDenunce.Visible = false;
                        }
                        if (!string.IsNullOrEmpty(data.Filerifiutoauto))
                        {
                            lblViewFileRifiutoAuto.Text = "<div class='preview mb-5'> <i class='icon-doc'></i> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Filerifiutoauto + "\" target='_blank'>Visualizza Verbale rifiuto auto</a></div><br><br>";
                            fuFileRifiutoAuto.Visible = false;
                        }
                        if (!string.IsNullOrEmpty(data.Fileverbaleauto))
                        {
                            lblViewFileVerbaleAuto.Text = "<div class='preview mb-5'> <i class='icon-doc'></i> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Fileverbaleauto + "\" target='_blank'>Visualizza Verbale di restituzione</a></div><br><br>";
                            fuFileVerbaleAuto.Visible = false;
                        }
                        if (!string.IsNullOrEmpty(data.Filelibrettoauto))
                        {
                            lblViewFileLibrettoAuto.Text = "<div class='preview mb-5'> <i class='icon-doc'></i> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Filelibrettoauto + "\" target='_blank'>Visualizza Libretto auto</a></div><br><br>";
                            fuFileLibrettoAuto.Visible = false;
                        }
                        if (!string.IsNullOrEmpty(data.Documentofuelcard))
                        {
                            lblViewFileFuelCard.Text = "<div class='preview mb-5'> <i class='icon-doc'></i> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Documentofuelcard + "\" target='_blank'>Visualizza richiesta fuel card</a></div><br><br>";
                            fuFuelCard.Visible = false;
                        }


                        hduid.Value = uid.ToString();
                    }
                }
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            int idassegnazione = SeoHelper.IntString(hduid.Value);

            IContratti contrattoNew = new Contratti
            {
                Idassegnazione = idassegnazione,
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;
            string fileverbale = "";
            string filerelazione = "";
            string filedenuncia = "";
            string filerifiutoauto = "";
            string fileverbaleauto = "";
            string filelibrettoauto = "";
            string filefuelcard = "";
            bool controlTipoFile = false;
            bool controlFileLoad = false;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string fileExt2;
            string fileExt3;
            string fileExt4;
            string fileExt5;
            string fileExt6;
            string fileExt7;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/ordini/";


            string filename = SeoHelper.OraAttuale() + "-" + fuFileVerbale.FileName;
            string filename2 = SeoHelper.OraAttuale() + "-" + fuFileRelazione.FileName;
            string filename3 = SeoHelper.OraAttuale() + "-" + fuFileDenunce.FileName;
            string filename4 = SeoHelper.OraAttuale() + "-" + fuFileRifiutoAuto.FileName;
            string filename5 = SeoHelper.OraAttuale() + "-" + fuFileVerbaleAuto.FileName;
            string filename6 = SeoHelper.OraAttuale() + "-" + fuFileLibrettoAuto.FileName;
            string filename7 = SeoHelper.OraAttuale() + "-" + fuFuelCard.FileName;


            if (fuFileVerbale.HasFile == false)
            {
                
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileVerbale.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad = true;
                    error += "Il file verbale consegna non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad = true;
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        controlTipoFile = false;
                        error += "Il file verbale consegna non può essere caricato perché non ha un'estensione .pdf <br />";
                    }
                    else
                    {
                        controlTipoFile = true;
                    }
                }
            }


            if (fuFileRelazione.HasFile == false)
            {

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


            if (fuFileRifiutoAuto.HasFile == false)
            {

            }
            else
            {
                fileExt4 = Path.GetExtension(filename4).Substring(1);

                // controllo la dimensione del file
                if (fuFileRifiutoAuto.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad = true;
                    error += "Il file rifiuto auto non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad = true;
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt4))
                    {
                        controlTipoFile = false;
                        error += "Il file rifiuto auto non può essere caricato perché non ha un'estensione .pdf <br />";
                    }
                    else
                    {
                        controlTipoFile = true;
                    }
                }
            }

            if (fuFileVerbaleAuto.HasFile == false)
            {

            }
            else
            {
                fileExt5 = Path.GetExtension(filename5).Substring(1);

                // controllo la dimensione del file
                if (fuFileVerbaleAuto.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad = true;
                    error += "Il file verbale auto non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad = true;
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt5))
                    {
                        controlTipoFile = false;
                        error += "Il file verbale auto non può essere caricato perché non ha un'estensione .pdf <br />";
                    }
                    else
                    {
                        controlTipoFile = true;
                    }
                }
            }



            if (fuFileLibrettoAuto.HasFile == false)
            {

            }
            else
            {
                fileExt6 = Path.GetExtension(filename6).Substring(1);

                // controllo la dimensione del file
                if (fuFileLibrettoAuto.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad = true;
                    error += "Il file libretto auto non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad = true;
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt6))
                    {
                        controlTipoFile = false;
                        error += "Il file libretto auto non può essere caricato perché non ha un'estensione .pdf <br />";
                    }
                    else
                    {
                        controlTipoFile = true;
                    }
                }
            }

            if (fuFuelCard.HasFile == false)
            {

            }
            else
            {
                fileExt7 = Path.GetExtension(filename7).Substring(1);

                // controllo la dimensione del file
                if (fuFuelCard.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad = true;
                    error += "Il file ritiro fuel card non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad = true;
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt7))
                    {
                        controlTipoFile = false;
                        error += "Il file ritiro fuel card auto non può essere caricato perché non ha un'estensione .pdf <br />";
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
                        if (fuFileVerbale.HasFile == true)
                        {
                            fuFileVerbale.SaveAs(filePath + filename);
                        }
                        if (fuFileRelazione.HasFile == true)
                        {
                            fuFileRelazione.SaveAs(filePath + filename2);
                        }
                        if (fuFileDenunce.HasFile == true)
                        {
                            fuFileDenunce.SaveAs(filePath + filename3);
                        }
                        if (fuFileRifiutoAuto.HasFile == true)
                        {
                            fuFileRifiutoAuto.SaveAs(filePath + filename4);
                        }
                        if (fuFileVerbaleAuto.HasFile == true)
                        {
                            fuFileVerbaleAuto.SaveAs(filePath + filename5);
                        }
                        if (fuFileLibrettoAuto.HasFile == true)
                        {
                            fuFileLibrettoAuto.SaveAs(filePath + filename6);
                        }
                        if (fuFuelCard.HasFile == true)
                        {
                            fuFuelCard.SaveAs(filePath + filename7);
                        }

                        System.Threading.Thread.Sleep(1000);

                        //controllo virus scanner
                        var scanner = new AntiVirus.Scanner();
                        var resultS = scanner.ScanAndClean(filePath + filename);
                        var resultS2 = scanner.ScanAndClean(filePath + filename2);
                        var resultS3 = scanner.ScanAndClean(filePath + filename3);
                        var resultS4 = scanner.ScanAndClean(filePath + filename4);
                        var resultS5 = scanner.ScanAndClean(filePath + filename5);
                        var resultS6 = scanner.ScanAndClean(filePath + filename6);
                        var resultS7 = scanner.ScanAndClean(filePath + filename7);

                        if (resultS.ToString() != "VirusNotFound" && resultS2.ToString() != "VirusNotFound" && resultS3.ToString() != "VirusNotFound"
                            && resultS4.ToString() != "VirusNotFound" && resultS5.ToString() != "VirusNotFound" && resultS6.ToString() != "VirusNotFound" && resultS7.ToString() != "VirusNotFound")
                        {
                            controlTrueFileLoad = false;
                        }
                        else
                        {
                            if (fuFileVerbale.HasFile == true)
                            {
                                fileverbale = filename;
                            }
                            if (fuFileRelazione.HasFile == true)
                            {
                                filerelazione = filename2;
                            }
                            if (fuFileDenunce.HasFile == true)
                            {
                                filedenuncia = filename3;
                            }
                            if (fuFileRifiutoAuto.HasFile == true)
                            {
                                filerifiutoauto = filename4;
                            }
                            if (fuFileVerbaleAuto.HasFile == true)
                            {
                                fileverbaleauto = filename5;
                            }
                            if (fuFileLibrettoAuto.HasFile == true)
                            {
                                filelibrettoauto = filename6;
                            }
                            if (fuFuelCard.HasFile == true)
                            {
                                filefuelcard = filename7;
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
                    string containerName = "ordini";
                    string blobName = fileverbale;
                    string blobName2 = filerelazione;
                    string blobName3 = filedenuncia;
                    string blobName4 = filerifiutoauto;
                    string blobName5 = fileverbaleauto;
                    string blobName6 = filelibrettoauto;
                    string blobName7 = filefuelcard;
                    string fileName = fileverbale;
                    string fileName2 = filerelazione;
                    string fileName3 = filedenuncia;
                    string fileName4 = filerifiutoauto;
                    string fileName5 = fileverbaleauto;
                    string fileName6 = filelibrettoauto;
                    string fileName7 = filefuelcard;
                    string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                    string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                    string sas = Global.sas;

                    AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                    string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);
                    string resultBlob2 = azureBlobManager.UploadBlob(fileName2, blobName2, true);
                    string resultBlob3 = azureBlobManager.UploadBlob(fileName3, blobName3, true);
                    string resultBlob4 = azureBlobManager.UploadBlob(fileName4, blobName4, true);
                    string resultBlob5 = azureBlobManager.UploadBlob(fileName5, blobName5, true);
                    string resultBlob6 = azureBlobManager.UploadBlob(fileName6, blobName6, true);
                    string resultBlob7 = azureBlobManager.UploadBlob(fileName7, blobName7, true);

                    Response.Write(resultBlob);
                    Response.Write(resultBlob2);
                    Response.Write(resultBlob3);
                    Response.Write(resultBlob4);
                    Response.Write(resultBlob5);
                    Response.Write(resultBlob6);
                    Response.Write(resultBlob7);


                    contrattoNew.Fileverbaleconsegna = SeoHelper.EncodeString(fileverbale);
                    contrattoNew.Filerelazioneperito = SeoHelper.EncodeString(filerelazione);
                    contrattoNew.Filedenunce = SeoHelper.EncodeString(filedenuncia);
                    contrattoNew.Fileverbaleauto = SeoHelper.EncodeString(fileverbaleauto);
                    contrattoNew.Filerifiutoauto = SeoHelper.EncodeString(filerifiutoauto);
                    contrattoNew.Filelibrettoauto = SeoHelper.EncodeString(filelibrettoauto);
                    contrattoNew.Documentofuelcard = SeoHelper.EncodeString(filefuelcard);

                    if (servizioContratti.UpdateFileAuto(contrattoNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Caricamento Documenti Auto: " + idassegnazione);


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
