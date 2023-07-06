// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModCarList.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Car
{
    public partial class ModCarList : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(5)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ICarsBL servizioCar = new CarsBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    ICars data = servizioCar.DetailCarListAutoId(uid);
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

            RecuperaColori();
            RecuperaOptional();
        }
        public void RecuperaColori()
        {
            ICarsBL servizioCar = new CarsBL();
            string elencocolori = "";
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int countCol = 0;

            elencocolori += "<div class='category'>Colori</div>";

            List<ICars> dataOpt = servizioCar.SelectAllColori("", Uidtenant);
            if (dataOpt != null && dataOpt.Count > 0)
            {
                hdcountcolor.Value = dataOpt.Count.ToString();
                foreach (ICars resultOpt in dataOpt)
                {
                    bool existopt = false;
                    ICars dataExs = servizioCar.ExistOptionalAuto(SeoHelper.EncodeString(txtCodjatoAuto.Text), resultOpt.Codoptional);
                    if (dataExs != null)
                    {
                        existopt = true;
                    }

                    elencocolori += "<div class='optional-table'>";
                    if (existopt)
                    {
                        elencocolori += "<div class='optional-table-left'><input type='checkbox' name='codcolore_" + countCol + "' checked='checked' value=\"" + resultOpt.Codoptional + "\" /></div>";
                    }
                    else
                    {
                        elencocolori += "<div class='optional-table-left'><input type='checkbox' name='codcolore_" + countCol + "' value=\"" + resultOpt.Codoptional + "\" /></div>";
                    }
                    elencocolori += "<div class='optional-table-center'>" + resultOpt.Optional + "</div>";
                    elencocolori += "<div class='optional-table-right'></div>";
                    elencocolori += "</div>";

                    countCol++;
                }
            }
            ltcolori.Text = elencocolori;
        }

        public void RecuperaOptional()
        {
            ICarsBL servizioCar = new CarsBL();
            string elencooptional = "";
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int count = 0;
            hdcount.Value = servizioCar.SelectCountOptional("", Uidtenant).ToString();

            //elenco categorie
            List<ICars> dataCatOpt = servizioCar.SelectAllCategoriePrimoLivello(Uidtenant);
            if (dataCatOpt != null && dataCatOpt.Count > 0)
            {
                foreach (ICars resultCatOpt in dataCatOpt)
                {
                    elencooptional += "<div class='category'>" + resultCatOpt.Categoriaoptional + "</div>";

                    //elenco sottocategorie
                    List<ICars> dataSottoCatOpt = servizioCar.SelectAllCategorieSecondoLivelloXCod(resultCatOpt.Codcategoriaoptional);
                    if (dataSottoCatOpt != null && dataSottoCatOpt.Count > 0)
                    {
                        foreach (ICars resultSottoCatOpt in dataSottoCatOpt)
                        {
                            elencooptional += "<div class='subcategory'>" + resultSottoCatOpt.Categoriaoptional + "</div>";

                            //elenco optional
                            List<ICars> dataOpt = servizioCar.SelectAllOptionalXCod(resultCatOpt.Codcategoriaoptional, resultSottoCatOpt.Codcategoriaoptional);
                            if (dataOpt != null && dataOpt.Count > 0)
                            {
                                foreach (ICars resultOpt in dataOpt)
                                {
                                    bool existopt = false;
                                    decimal importoopt = 0;
                                    int giorniconsegnaagg = 0;

                                    //controllo se esiste optional
                                    ICars dataExs = servizioCar.ExistOptionalAuto(SeoHelper.EncodeString(txtCodjatoAuto.Text), resultOpt.Codoptional);
                                    if (dataExs != null)
                                    {
                                        existopt = true;
                                        importoopt = dataExs.Importooptional;
                                        giorniconsegnaagg = dataExs.Giorniconsegnaagg;
                                    }


                                    elencooptional += "<div class='optional-table'>";
                                    if (existopt)
                                    {
                                        elencooptional += "<div class='optional-table-left'><input type='checkbox' name='codoptional_" + count + "' checked='checked' value=\"" + resultOpt.Codoptional + "\" /></div>";
                                    }
                                    else
                                    {
                                        elencooptional += "<div class='optional-table-left'><input type='checkbox' name='codoptional_" + count + "' value=\"" + resultOpt.Codoptional + "\" /></div>";
                                    }
                                    elencooptional += "<div class='optional-table-center'>" + resultOpt.Optional + "</div>";
                                    elencooptional += "<div class='optional-table-right'>";
                                    elencooptional += "<select name='tipoimporto_" + count + "'>";
                                    if (importoopt == 0)
                                    {
                                        elencooptional += "<option value='0' selected='selected'>di serie</option>";
                                        elencooptional += "<option value='1'>non di serie</option>";
                                    }
                                    else
                                    {
                                        elencooptional += "<option value='0'>di serie</option>";
                                        elencooptional += "<option value='1' selected='selected'>non di serie</option>";
                                    }
                                    elencooptional += "</select>";
                                    if (importoopt == 0)
                                    {
                                        elencooptional += " <div class='m-t-5'><input type='text' name='importo_" + count + "' size='10' maxlength='20' value='' /> canone mensile</div> ";
                                    }
                                    else
                                    {
                                        elencooptional += " <div class='m-t-5'><input type='text' name='importo_" + count + "' size='10' maxlength='20' value='" + importoopt + "' /> canone mensile</div>";
                                    }

                                    if (giorniconsegnaagg == 0)
                                    {
                                        elencooptional += " <div class='m-t-5'><input type='text' name='giorniconsegnaagg_" + count + "' size='10' maxlength='20' value='' /> giorni consegna aggiuntivi</div>";
                                    }
                                    else
                                    {
                                        elencooptional += " <div class='m-t-5'><input type='text' name='giorniconsegnaagg_" + count + "' size='10' maxlength='20' value='" + giorniconsegnaagg + "' /> giorni consegna aggiuntivi</div>";
                                    }
                                    elencooptional += "</div>";
                                    elencooptional += "</div>";

                                    count++;
                                }
                            }
                        }
                    }
                }
            }

            ltoptional.Text = elencooptional;

        }

        private void BindData(ICars data)
        {
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            ddlCodice.SelectedValue = data.Codcarlist;
            ddlCodFornitore.SelectedValue = data.Codfornitore;
            txtCodjatoAuto.Text = data.Codjatoauto;
            txtMarca.Text = data.Marca;
            txtModello.Text = data.Modello;
            txtCilindrata.Text = data.Cilindrata;
            txtAlimentazione.Text = data.Alimentazione;
            txtAlimentazioneSecondaria.Text = data.Alimentazionesecondaria;
            txtConsumo.Text = SeoHelper.CheckDecimalString(data.Consumo);
            txtConsumoUrbano.Text = SeoHelper.CheckDecimalString(data.Consumourbano);
            txtConsumoExtraUrbano.Text = SeoHelper.CheckDecimalString(data.Consumoextraurbano);
            txtEmissioni.Text = SeoHelper.CheckDecimalString(data.Emissioni);
            txtCostoAutoBase.Text = SeoHelper.CheckDecimalString(data.Costoautobase);
            txtCostoAci.Text = SeoHelper.CheckDecimalString(data.Costoaci);
            txtCanoneLeasing.Text = SeoHelper.CheckDecimalString(data.Canoneleasing);
            txtFringeBenefit.Text = SeoHelper.CheckDecimalString(data.Fringebenefitbase);
            txtGiorni.Text = SeoHelper.CheckIntString(data.Giorniconsegna);
            txtMesiContratto.Text = SeoHelper.CheckIntString(data.Mesicontratto);
            ddlCambio.SelectedValue = data.Cambio;
            ddlVisibile.SelectedValue = data.Visibile;
            txtSerbatoio.Text = SeoHelper.CheckDecimalString(data.Serbatoio);
            txtKwcv.Text = data.Kwcv;
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
            hdFileFotoAuto.Value = data.Fotoauto;
            if (!string.IsNullOrEmpty(data.Fotoauto))
            {
                lblViewFileFotoAuto.Text = "<img src='../../../DownloadFile?type=auto&nomefile=" + data.Fotoauto + "' width='150' alt='' border='0' />";
            }

            if (servizioFileTracciati.ExistAbbinamentoCodjatoAuto(data.Codjatoauto))
            {
                ddlAbbinamento.Visible = false;
                btnModifica4.Visible = false;
                lblAlertAbbinato.Text = "Modello gi&agrave; abbinato alle auto delle tabelle ACI";
            }


            //calcolo fringe benefit
            int percentuale = servizioFileTracciati.ReturnColonnaPerc(data.Emissioni);
            string campo = servizioFileTracciati.ReturnCampoPerc(percentuale);
            decimal valore = servizioFileTracciati.DValorePercentualeFringe(data.Codjatoauto, campo);
            decimal totalefringe = servizioFileTracciati.TotaleFringeBenefit(valore);

            lblCalcoloFringe.Text = "Emissione: " + data.Emissioni.ToString() + " - Colonna: " + percentuale + "% <br />";
            lblCalcoloFringe.Text += "Fringe: " + valore + " / 12 = <strong>&euro; " + totalefringe.ToString("F2") + "</strong>";

        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateCarList("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateCarList("salvachiudi");
        }


        public void UpdateCarList(string opzione)
        {
            ICarsBL servizioCar = new CarsBL();

            ICars carListNew = new Cars
            {
                Codcarlist = SeoHelper.EncodeString(ddlCodice.SelectedValue),
                Codfornitore = SeoHelper.EncodeString(ddlCodFornitore.SelectedValue),
                Codjatoauto = SeoHelper.EncodeString(txtCodjatoAuto.Text),
                Marca = SeoHelper.EncodeString(txtMarca.Text),
                Modello = SeoHelper.EncodeString(txtModello.Text),
                Cilindrata = SeoHelper.EncodeString(txtCilindrata.Text),
                Alimentazione = SeoHelper.EncodeString(txtAlimentazione.Text),
                Alimentazionesecondaria = SeoHelper.EncodeString(txtAlimentazioneSecondaria.Text),
                Consumo = SeoHelper.DecimalString(txtConsumo.Text),
                Consumourbano = SeoHelper.DecimalString(txtConsumoUrbano.Text),
                Consumoextraurbano = SeoHelper.DecimalString(txtConsumoExtraUrbano.Text),
                Emissioni = SeoHelper.DecimalString(txtEmissioni.Text),
                Costoautobase = SeoHelper.DecimalString(txtCostoAutoBase.Text),
                Costoaci = SeoHelper.DecimalString(txtCostoAci.Text),
                Canoneleasing = SeoHelper.DecimalString(txtCanoneLeasing.Text),
                Fringebenefitbase = SeoHelper.DecimalString(txtFringeBenefit.Text),
                Cambio = SeoHelper.EncodeString(ddlCambio.SelectedValue),
                Giorniconsegna = SeoHelper.IntString(txtGiorni.Text),
                Mesicontratto = SeoHelper.IntString(txtMesiContratto.Text),
                Serbatoio = SeoHelper.DecimalString(txtSerbatoio.Text),
                Visibile = SeoHelper.EncodeString(ddlVisibile.SelectedValue),
                Kwcv = SeoHelper.EncodeString(txtKwcv.Text),
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;
            bool controlTipoFile = false;
            bool controlFileLoad;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "jpg", "png" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/auto/";


            if (string.IsNullOrEmpty(carListNew.Codcarlist))
            {
                ddlCodice.CssClass = "form-control is-invalid select2";
                error += "inserire un valore valido per il campo Codice<br />";
            }
            else
            {
                ddlCodice.CssClass = "form-control select2";
            }

            if (string.IsNullOrEmpty(carListNew.Codfornitore))
            {
                ddlCodFornitore.CssClass = "form-control is-invalid select2";
                error += "inserire un valore valido per il campo Codice fornitore<br />";
            }
            else
            {
                ddlCodFornitore.CssClass = "form-control select2";
            }

            if (string.IsNullOrEmpty(carListNew.Codjatoauto))
            {
                txtCodjatoAuto.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codjato auto<br />";
            }
            else
            {
                txtCodjatoAuto.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(carListNew.Marca))
            {
                txtMarca.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Marca<br />";
            }
            else
            {
                txtMarca.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(carListNew.Modello))
            {
                txtModello.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Modello<br />";
            }
            else
            {
                txtModello.CssClass = "form-control";
            }

            // controllo se fuFileFotoAuto contiene un file da caricare
            string filename = SeoHelper.OraAttuale() + "-" + fuFileFotoAuto.FileName;
            if (fuFileFotoAuto.HasFile == false)
            {
                carListNew.Fotoauto = hdFileFotoAuto.Value;
                controlFileLoad = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileFotoAuto.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
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
                if (controlFileLoad) //c'è un file da caricare
                {
                    if (controlTipoFile) //se i controlli sono corretti carica il file sul server
                    {
                        // salviamo il file nel percorso calcolato
                        filePath += filename;
                        fuFileFotoAuto.SaveAs(filePath);
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
                            string containerName = "auto";
                            string blobName = filename;
                            string fileName = filename;
                            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/auto/";
                            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/auto/";
                            string sas = Global.sas;

                            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                            string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                            Response.Write(resultBlob);

                            carListNew.Fotoauto = filename;
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

                    if (servizioCar.UpdateCarListAuto(carListNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + carListNew.Uid);

                        if (opzione.ToUpper() == "SALVA")
                        {
                            //messaggio avvenuto inserimento
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Car/ViewCarList") + "'>Ritorna alla Lista</a>";
                        }
                        else
                        {
                            Response.Redirect("ViewCarList");
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


        protected void btnModifica3_Click(object sender, EventArgs e)
        {
            ICarsBL servizioCar = new CarsBL();

            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            string codoptional;
            string codcolore;
            string importooptional;
            string giorniconsegnaagg;
            string tipoimporto;
            string codjatoauto = txtCodjatoAuto.Text;
            int contaRecord = Convert.ToInt32(hdcount.Value);
            int contaRecordCol = Convert.ToInt32(hdcountcolor.Value);

            if (contaRecordCol > 0)
            {
                //reset tutti i colori codjatoauto
                ICars carListDel = new Cars
                {
                    Codjatoauto = codjatoauto,
                    Optcolore = "SI",
                    Uidtenant = SeoHelper.ReturnSessionTenant()
                };
                servizioCar.DeleteOptionalAuto(carListDel);


                //colori
                for (int i = 0; i < contaRecordCol; i++)
                {
                    codcolore = Request.Form["codcolore_" + i];

                    //inserimento optional solo se selezionato
                    if (codcolore != null)
                    {
                        ICars ColNew = new Cars
                        {
                            Codjatoauto = SeoHelper.EncodeString(codjatoauto),
                            Codoptional = SeoHelper.EncodeString(codcolore),
                            Importooptional = 0,
                            Optcolore = "SI",
                            Uidtenant = Uidtenant
                        };

                        servizioCar.InsertOptionalAuto(ColNew);
                    }
                }
            }

            if (contaRecord > 0)
            {
                //reset tutti gli optional codjatoauto
                ICars carListDel = new Cars
                {
                    Codjatoauto = codjatoauto,
                    Optcolore = "",
                    Uidtenant = SeoHelper.ReturnSessionTenant()
                };
                servizioCar.DeleteOptionalAuto(carListDel);


                //optional
                for (int i = 0; i < contaRecord; i++)
                {
                    importooptional = Request.Form["importo_" + i];
                    codoptional = Request.Form["codoptional_" + i];
                    tipoimporto = Request.Form["tipoimporto_" + i];
                    giorniconsegnaagg = Request.Form["giorniconsegnaagg_" + i];

                    //inserimento optional solo se selezionato
                    if (codoptional != null)
                    {
                        ICars OptNew = new Cars
                        {
                            Codjatoauto = SeoHelper.EncodeString(codjatoauto),
                            Codoptional = SeoHelper.EncodeString(codoptional),
                            Optcolore = "",
                            Uidtenant = Uidtenant
                        };
                        if (tipoimporto == "0") // di serie
                        {
                            OptNew.Importooptional = 0;
                            OptNew.Giorniconsegnaagg = 0;
                        }
                        else //non di serie specifica importo
                        {
                            OptNew.Importooptional = SeoHelper.DecimalString(importooptional);
                            OptNew.Giorniconsegnaagg = SeoHelper.IntString(giorniconsegnaagg);
                        }

                        servizioCar.InsertOptionalAuto(OptNew);
                    }
                }
            }

            Response.Redirect("ViewCarList");
        }

        protected void btnModifica4_Click(object sender, EventArgs e)
        {
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

            IFileTracciati updCod = new FileTracciati
            {
                Codjatoauto = SeoHelper.EncodeString(txtCodjatoAuto.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            IFileTracciati data = servizioFileTracciati.ExistCodjatoAutoXId(SeoHelper.IntString(ddlAbbinamento.SelectedValue));
            if (data != null)
            {
                updCod.Marca = data.Marca;
                updCod.Modello = data.Modello;
                updCod.Serie = data.Serie;
            }


            if (servizioFileTracciati.UpdateCodjatoAuto(updCod) == 1)
            {
                //messaggio avvenuto inserimento
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-success";
                lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Car/ViewCarList") + "'>Ritorna alla Lista</a>";                
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
