// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModMulteDaPagare.aspx.cs" company="">
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
using DFleet.Classes;
using BusinessLogic.Services.blob;

namespace DFleet.Admin.Modules.Multa
{
    public partial class ModMulteDaPagare : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(20) && !datiUtente.ReturnExistPage(22)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IMulteBL servizioMulte = new MulteBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IMulte data = servizioMulte.DetailMulteId(uid);
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
        private void BindData(IMulte data)
        {
            lblDescrizioneMulta.Text += "Numero Verbale: " + data.Numeroverbale + " del " + SeoHelper.CheckDataString(data.Datainfrazione) + "<br />";
            lblDescrizioneMulta.Text += "Driver: " + data.Denominazione + "<br />";
            lblDescrizioneMulta.Text += "Societ&agrave;: " + data.Societa + "<br />";

            if (data.Datapreseuntedimissioni > DateTime.MinValue)
            {
                lblDescrizioneMulta.Text += "Presutente Dimissioni: " + data.Datapreseuntedimissioni.ToString("dd/MM/yyyy") + "<br />";
            }

            if (data.Datadimissioni > DateTime.MinValue)
            {
                lblDescrizioneMulta.Text += "Dimissioni: " + data.Datadimissioni.ToString("dd/MM/yyyy") + "<br />";
            }

            lblDescrizioneMulta.Text += "<br /> <a href=\"../../../DownloadFile?type=multe&nomefile=" + data.Fileverbale + "\" target='_blank'>Apri File Verbale</a> ";
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
            hdidmulta.Value = Convert.ToString(data.Idmulta, CultureInfo.CurrentCulture);
            hduserid.Value = Convert.ToString(data.UserId, CultureInfo.CurrentCulture);
            txtDataPagamento.Text = SeoHelper.CheckDataString(data.Datapagamento);
            ddlCodPagamento.SelectedValue = data.Codpagamento;
            ddlTitolarePag.SelectedValue = data.Idtitolarepagamento.ToString();
            ddlContoPagamento.SelectedValue = data.Idcontopagamento.ToString();
            if (data.Spesepagamento > 0)
            {
                txtSpesePagamento.Text = SeoHelper.CheckDecimalString(data.Spesepagamento).Replace(".", ",");
            }
            else
            {
                txtSpesePagamento.Text = "0,80";
            }
            if (data.Importomultapagato > 0)
            {
                ddlImportoPagamento.SelectedValue = SeoHelper.CheckDecimalString(data.Importomultapagato).Replace(".", ",");
            }
            if (!string.IsNullOrEmpty(data.Filericevutapagamento))
            {
                lblViewFilePagamento.Text = "<a href=\"../../../DownloadFile?type=multe&nomefile=" + data.Filericevutapagamento + "\" target='_blank'>Apri File Ricevuta Pagamento</a>";
            }

            if (data.Idstatuspagamento > 100) //se multa e gia stata pagata disabilita tasti modifica
            {
                btnModifica.Visible = false;
                btnModifica2.Visible = false;
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateMulte("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateMulte("salvachiudi");
        }


        public void UpdateMulte(string opzione)
        {
            IMulteBL servizioMulte = new MulteBL();

            IMulte multeNew = new Multe
            {
                Importomultapagato = SeoHelper.DecimalString(ddlImportoPagamento.SelectedValue),
                Datapagamento = SeoHelper.DataString(txtDataPagamento.Text),
                Idtitolarepagamento = SeoHelper.IntString(ddlTitolarePag.SelectedValue),
                Spesepagamento = SeoHelper.DecimalString(txtSpesePagamento.Text),
                Idstatuspagamento = 100,
                Idstatuslavorazione = 45,
                Codpagamento = SeoHelper.EncodeString(ddlCodPagamento.SelectedValue),
                Idcontopagamento = SeoHelper.IntString(ddlContoPagamento.SelectedValue),
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
            filePath += "/Repository/multe/";


            if (multeNew.Idtitolarepagamento == -1)
            {
                ddlTitolarePag.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Titolare Pagamento<br />";
            }
            else
            {
                ddlTitolarePag.CssClass = "form-control";
            }

            if (multeNew.Importomultapagato == 0)
            {
                ddlImportoPagamento.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Importo Pagato<br />";
            }
            else
            {
                ddlImportoPagamento.CssClass = "form-control";
            }

            if (multeNew.Datapagamento == DateTime.MinValue)
            {
                txtDataPagamento.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Data Pagamento<br />";
            }
            else
            {
                txtDataPagamento.CssClass = "form-control";
            }

            // controllo se fuFilePagamento contiene un file da caricare
            string filename = SeoHelper.OraAttuale() + "-" + fuFilePagamento.FileName;
            if (fuFilePagamento.HasFile == false)
            {
                multeNew.Filericevutapagamento = filename;
                controlFileLoad = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFilePagamento.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
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
                        fuFilePagamento.SaveAs(filePath);
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
                            string containerName = "multe";
                            string blobName = filename;
                            string fileName = filename;
                            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/multe/";
                            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/multe/";
                            string sas = Global.sas;

                            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                            string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);
                            Response.Write(resultBlob);

                            multeNew.Filericevutapagamento = filename;
                        }
                    }
                }

                if (!controlTrueFileLoad)
                {
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text = "Attenzione! Si sono verificati i seguenti errori:";
                    lblMessage.Text += "<br /><br /><b>E' stato trovato un virus nel file " + fuFilePagamento.FileName + "</b><br />";
                }
                else
                {
                    if (servizioMulte.UpdateMultaPagata(multeNew) == 1)
                    {
                        //inserimento cedolino
                        IMulte cedNew = new Multe
                        {
                            Importo = multeNew.Importomultapagato,
                            Idtipologiacedolino = 10,
                            Datains = multeNew.Datapagamento,
                            UserId = new Guid(SeoHelper.EncodeString(hduserid.Value)),
                            Idmulta = SeoHelper.IntString(hdidmulta.Value),
                            Uidtenant = SeoHelper.ReturnSessionTenant()
                        };


                        IMulte data = servizioMulte.ExistCedolino(cedNew.Idmulta, cedNew.Idtipologiacedolino); // se cedolino e gia esistente lo aggiorna altrimenti lo inserisce
                        if (data != null)
                        {
                            if (servizioMulte.UpdateCedolino(cedNew) == 1)
                            {
                                if (opzione.ToUpper() == "SALVA")
                                {
                                    //messaggio avvenuto inserimento
                                    pnlMessage.Visible = true;
                                    pnlMessage.CssClass = "alert alert-success";
                                    lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Multa/ViewMulteDaPagare") + "'>Ritorna alla Lista</a>";
                                }
                                else
                                {
                                    Response.Redirect("ViewMulteDaPagare");
                                }
                            }
                        }
                        else
                        {
                            if (servizioMulte.InsertCedolino(cedNew) == 1)
                            {
                                ILogBL log = new LogBL();
                                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Pagamento Multa " + multeNew.Uid);


                                if (opzione.ToUpper() == "SALVA")
                                {
                                    //messaggio avvenuto inserimento
                                    pnlMessage.Visible = true;
                                    pnlMessage.CssClass = "alert alert-success";
                                    lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Multa/ViewMulteDaPagare") + "'>Ritorna alla Lista</a>";
                                }
                                else
                                {
                                    Response.Redirect("ViewMulteDaPagare");
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
                        lblMessage.Text += "Operazione fallita";
                    }
                }
            }
        }
    }
}
