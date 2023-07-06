// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModMulte.aspx.cs" company="">
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
    public partial class ModMulte : System.Web.UI.Page
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
            ddlUsers.SelectedValue = Convert.ToString(data.UserId, CultureInfo.CurrentCulture);
            txtProtocollo.Text = data.Protocollo;
            ddlTipoTrasm.SelectedValue = SeoHelper.CheckIntString(data.Idtipotrasmissione);
            ddlCodTipoMulta.SelectedValue = data.Codtipomulta;
            ddlTarga.SelectedValue = data.Targa;
            txtNumeroVerbale.Text = data.Numeroverbale;
            txtDataInfrazione.Text = SeoHelper.CheckDataString(data.Datainfrazione);
            txtOraInfrazione.Text = data.Orainfrazione;
            txtDataNotifica.Text = SeoHelper.CheckDataString(data.Datanotifica);
            txtEnte.Text = data.Ente;
            txtInfrazione.Text = data.Infrazione;
            txtPunti.Text = data.Punti.ToString();
            txtImportoMulta.Text = data.Importomulta.ToString();
            txtImportoMultaRidotto.Text = data.Importomultaridotto.ToString();
            txtImportoMultaScontato.Text = data.Importomultascontato.ToString();
            ddlStatusLav.SelectedValue = data.Idstatuslavorazione.ToString();
            ddlStatusPag.SelectedValue = data.Idstatuspagamento.ToString();
            ddlTitolarePag.SelectedValue = data.Idtitolarepagamento.ToString();
            txtSpesePagamento.Text = data.Spesepagamento.ToString();
            hdFileVerbale.Value = data.Fileverbale;
            hdFilePagamento.Value = data.Filericevutapagamento;
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
            ddlCodSocieta.SelectedValue = data.Codsocieta;
            txtCfemittente.Text = data.Cfemittente;
            txtCodPagoPa.Text = data.Codpagopa;
            txtCodPagoPa60.Text = data.Codpagopa60;
            txtIban.Text = data.Iban;
            if (data.Importomultapagato > 0)
            {
                ddlImportoPagamento.SelectedValue = SeoHelper.CheckDecimalString(data.Importomultapagato).Replace(".", ",");
            }
            txtDataPagamento.Text = SeoHelper.CheckDataString(data.Datapagamento);
            ddlCodPagamento.SelectedValue = data.Codpagamento;
            ddlContoPagamento.SelectedValue = data.Idcontopagamento.ToString();

            if (!string.IsNullOrEmpty(data.Fileverbale))
            {
                lblViewFileVerbale.Text = "<a href=\"../../../DownloadFile?type=multe&nomefile=" + data.Fileverbale + "\" target='_blank'>Apri File</a>";
            }
            if (!string.IsNullOrEmpty(data.Filericevutapagamento))
            {
                lblViewFilePagamento.Text = "<a href=\"../../../DownloadFile?type=multe&nomefile=" + data.Filericevutapagamento + "\" target='_blank'>Apri File</a>";
            }
            if (!string.IsNullOrEmpty(data.Filemanleva))
            {
                lblFileManLeva.Text = "<a href=\"../../../DownloadFile?type=multe&nomefile=" + data.Filemanleva + "\" target='_blank'>Apri File</a>";
            }
            else
            {
                lblFileManLeva.Text = "NON PRESENTE";
            }
            txtQuotaSocieta.Text = data.Quotasocieta.ToString();
            txtQuotaDriver.Text = data.Quotadriver.ToString();
            txtAnnotazioni.Text = data.Annotazioni;
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
                Protocollo = SeoHelper.EncodeString(txtProtocollo.Text),
                Idtipotrasmissione = SeoHelper.IntString(ddlTipoTrasm.SelectedValue),
                Codtipomulta = SeoHelper.EncodeString(ddlCodTipoMulta.SelectedValue),
                Targa = SeoHelper.EncodeString(ddlTarga.SelectedValue),
                Numeroverbale = SeoHelper.EncodeString(txtNumeroVerbale.Text),
                Datainfrazione = SeoHelper.DataString(txtDataInfrazione.Text),
                Orainfrazione = SeoHelper.EncodeString(txtOraInfrazione.Text),
                Datanotifica = SeoHelper.DataString(txtDataNotifica.Text),
                Ente = SeoHelper.EncodeString(txtEnte.Text),
                Infrazione = SeoHelper.EncodeString(txtInfrazione.Text),
                Punti = SeoHelper.IntString(txtPunti.Text),
                Importomulta = SeoHelper.DecimalString(txtImportoMulta.Text),
                Importomultaridotto = SeoHelper.DecimalString(txtImportoMultaRidotto.Text),
                Importomultascontato = SeoHelper.DecimalString(txtImportoMultaScontato.Text),
                Idstatuslavorazione = SeoHelper.IntString(ddlStatusLav.SelectedValue),
                Idstatuspagamento = SeoHelper.IntString(ddlStatusPag.SelectedValue),
                Idtitolarepagamento = SeoHelper.IntString(ddlTitolarePag.SelectedValue),
                UserId = SeoHelper.GuidString(ddlUsers.SelectedValue),
                Spesepagamento = SeoHelper.DecimalString(txtSpesePagamento.Text),
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
                Codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue),
                Cfemittente = SeoHelper.EncodeString(txtCfemittente.Text),
                Codpagopa = SeoHelper.EncodeString(txtCodPagoPa.Text),
                Codpagopa60 = SeoHelper.EncodeString(txtCodPagoPa60.Text),
                Iban = SeoHelper.EncodeString(txtIban.Text),
                Importomultapagato = SeoHelper.DecimalString(ddlImportoPagamento.SelectedValue),
                Datapagamento = SeoHelper.DataString(txtDataPagamento.Text),
                Codpagamento = SeoHelper.EncodeString(ddlCodPagamento.SelectedValue),
                Idcontopagamento = SeoHelper.IntString(ddlContoPagamento.SelectedValue),
                Annotazioni = SeoHelper.EncodeString(txtAnnotazioni.Text),
                Quotadriver = SeoHelper.DecimalString(txtQuotaDriver.Text),
                Quotasocieta = SeoHelper.DecimalString(txtQuotaSocieta.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };


            string error = string.Empty;
            bool controlTipoFile = false;
            bool controlFileLoad;
            bool controlFileLoad2;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "pdf", "PDF" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/multe/";


            if (string.IsNullOrEmpty(multeNew.Protocollo))
            {
                txtProtocollo.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Protocollo<br />";
            }
            else
            {
                txtProtocollo.CssClass = "form-control";
            }

            if (multeNew.Idtipotrasmissione == 0)
            {
                ddlTipoTrasm.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Tipo Trasmissione<br />";
            }
            else
            {
                ddlTipoTrasm.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(multeNew.Codtipomulta))
            {
                ddlCodTipoMulta.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Tipo Multa<br />";
            }
            else
            {
                ddlCodTipoMulta.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(multeNew.Targa))
            {
                ddlTarga.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Targa<br />";
            }
            else
            {
                ddlTarga.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(multeNew.Numeroverbale))
            {
                txtNumeroVerbale.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Numero verbale<br />";
            }
            else
            {
                txtNumeroVerbale.CssClass = "form-control";
            }

            if (multeNew.Datainfrazione == DateTime.MinValue)
            {
                txtDataInfrazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Data Infrazione<br />";
            }
            else
            {
                txtDataInfrazione.CssClass = "form-control";
            }


            // controllo se fuFileVerbale contiene un file da caricare
            string filename = SeoHelper.OraAttuale() + "-" + fuFileVerbale.FileName;
            if (fuFileVerbale.HasFile == false)
            {
                multeNew.Fileverbale = hdFileVerbale.Value;
                controlFileLoad = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileVerbale.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
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

            string filename2 = SeoHelper.OraAttuale() + "-" + fuFilePagamento.FileName;
            if (fuFilePagamento.HasFile == false)
            {
                multeNew.Filericevutapagamento = hdFilePagamento.Value;
                controlFileLoad2 = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename2).Substring(1);

                // controllo la dimensione del file
                if (fuFilePagamento.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad2 = true;
                    error += "Il file ricevuta pagamento non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad2 = true;
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        controlTipoFile = false;
                        error += "Il file ricevuta pagamento non può essere caricato perché non ha un'estensione .pdf";
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
                if (controlFileLoad || controlFileLoad2) //c'è un file da caricare
                {
                    if (controlTipoFile) //se i controlli sono corretti carica il file sul server
                    {
                        // salviamo il file nel percorso calcolato
                        if (fuFileVerbale.HasFile == true)
                        {
                            fuFileVerbale.SaveAs(filePath + filename);
                        }
                        if (fuFilePagamento.HasFile == true)
                        {
                            fuFilePagamento.SaveAs(filePath + filename2);
                        }

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
                            string containerName = "multe";
                            string blobName = filename;
                            string blobName2 = filename2;
                            string fileName = filename;
                            string fileName2 = filename2;
                            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/multe/";
                            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/multe/";
                            string sas = Global.sas;

                            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                            string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);
                            string resultBlob2 = azureBlobManager.UploadBlob(fileName2, blobName2, true);

                            Response.Write(resultBlob);
                            Response.Write(resultBlob2);

                            if (fuFileVerbale.HasFile == false)
                            {
                                multeNew.Fileverbale = hdFileVerbale.Value;
                            }
                            else
                            {
                                multeNew.Fileverbale = SeoHelper.EncodeString(filename);
                            }

                            if (fuFilePagamento.HasFile == false)
                            {
                                multeNew.Filericevutapagamento = hdFilePagamento.Value;
                            }
                            else
                            {
                                multeNew.Filericevutapagamento = SeoHelper.EncodeString(filename2);
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
                    if (servizioMulte.UpdateMulte(multeNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + multeNew.Uid);


                        if (opzione.ToUpper() == "SALVA")
                        {
                            //messaggio avvenuto inserimento
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Multa/ViewMulte") + "'>Ritorna alla Lista</a>";
                        }
                        else
                        {
                            Response.Redirect("ViewMulte");
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
