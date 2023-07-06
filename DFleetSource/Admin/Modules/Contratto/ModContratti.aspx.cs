// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModContratti.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Contratto
{
    public partial class ModContratti : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(41)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {

                if (Request.QueryString["ins"] != null)
                {
                    if (Request.QueryString["ins"].ToString().ToUpper() == "OK")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "RICORDATI DI MODIFICARE LO STATUS IN CORSO</a>";
                    }
                }

                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailContrattiId(uid);
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
        private void BindData(IContratti data)
        {
            IAccountBL servizioAccount = new AccountBL();
            ICarsBL servizioCar = new CarsBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            string dettagliordine = string.Empty;
            string dettagliauto = string.Empty;

            ddlCodsocieta.SelectedValue = data.Codsocieta;
            ddlCodSocietaMod.SelectedValue = data.Codsocieta;
            ddlUsers.SelectedValue = Convert.ToString(data.UserId, CultureInfo.CurrentCulture);
            ddlUserIdPool.SelectedValue = Convert.ToString(data.UserIdpool, CultureInfo.CurrentCulture);
            ddlCodjatoAuto.SelectedValue = data.Codjatoauto;
            ddlCodCarPolicy.SelectedValue = data.Codcarpolicy;
            ddlCodCarList.SelectedValue = data.Codcarlist;
            ddlFornitore.SelectedValue = data.Codfornitore;
            ddlCodTipoContratto.SelectedValue = data.Codtipocontratto;
            ddlCodTipoUsoContratto.SelectedValue = data.Codtipousocontratto;
            txtNumeroOrdine.Text = data.Numordineordine;
            txtNumeroContratto.Text = data.Numerocontratto;
            txtDataContratto.Text = SeoHelper.CheckDataString(data.Datacontratto);
            txtDurataMesi.Text = SeoHelper.CheckIntString(data.Duratamesi);
            txtKmContratto.Text = SeoHelper.CheckIntString(data.Kmcontratto);
            txtFranchigia.Text = SeoHelper.CheckDecimalString(data.Franchigia);
            txtDatainiziocontratto.Text = SeoHelper.CheckDataString(data.Datainiziocontratto);
            txtDatainiziouso.Text = SeoHelper.CheckDataString(data.Datainiziouso);
            txtDatafinecontratto.Text = SeoHelper.CheckDataString(data.Datafinecontratto);
            txtAnnotazionicontratto.Text = data.Annotazionicontratto;
            txtCanoneleasing.Text = SeoHelper.CheckDecimalString(data.Canoneleasing);
            ddlstatus.SelectedValue = data.Idstatuscontratto.ToString();
            txtTarga.Text = data.Targa;
            txtDataimmatricolazione.Text = SeoHelper.CheckDataString(data.Dataimmatricolazione);
            txtBollo.Text = SeoHelper.CheckDecimalString(data.Bollo);
            txtSuperBollo.Text = SeoHelper.CheckDecimalString(data.Superbollo);
            txtScadenzaBollo.Text = SeoHelper.CheckDataString(data.Scadenzabollo);
            txtScadenzaSuperBollo.Text = SeoHelper.CheckDataString(data.Scadenzasuperbollo);
            txtEmissioni.Text = SeoHelper.CheckDecimalString(data.Emissioni);
            txtFringe.Text = SeoHelper.CheckDecimalString(data.Fringebenefit);
            ddlTipoAssegnazione.SelectedValue = data.Idtipoassegnazione.ToString();
            txtDeltaCanone.Text = SeoHelper.CheckDecimalString(data.Deltacanone);
            txtCanoneFinanziario.Text = SeoHelper.CheckDecimalString(data.Canonefinanziario);
            txtCanoneServizi.Text = SeoHelper.CheckDecimalString(data.Canoneservizi);
            txtCostokmeccedente.Text = SeoHelper.CheckDecimalString(data.Costokmeccedente);
            txtCostokmrimborso.Text = SeoHelper.CheckDecimalString(data.Costokmrimborso);
            txtSogliakm.Text = SeoHelper.CheckDecimalString(data.Sogliakm);
            hdidcontratto.Value = data.Idcontratto.ToString();
            hdFileContratto.Value = data.Filecontratto;
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
            txtDatarevisione.Text = SeoHelper.CheckDataString(data.Datarevisione);
            ddlColore.SelectedValue = data.Codcolore;
            txtCanoneFigurativo.Text = SeoHelper.CheckDecimalString(data.Canonefigurativo);
            txtAlimentazione.Text = data.Alimentazionecontratto;
            txtCilindrata.Text = data.Cilindratacontratto;
            txtKwcv.Text = data.Kwcvcontratto;
            ddlTipoUtilizzo.SelectedValue = data.Codutilizzo;
            hdFileLibrettoAuto.Value = data.Filelibrettoautocontratto;

            if (data.Flglibrettoinviato == 1)
            {
                flglibrettoinviato.Checked = true;
            }
            else
            {
                flglibrettoinviato.Checked = false;
            }

            if (data.Checkassegnatario == 1)
            {
                checkassegnatario.Checked = true;
            }
            else
            {
                checkassegnatario.Checked = false;
            }

            if (data.Riparazione == 1)
            {
                checkriparazione.Checked = true;
            }
            else
            {
                checkriparazione.Checked = false;
            }

            if (!string.IsNullOrEmpty(data.Filelibrettoautocontratto))
            {
                lblViewFileLibrettoAuto.Text = "<a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Filelibrettoautocontratto + "\" target='_blank'>Apri File</a><br />";
            }
            if (!string.IsNullOrEmpty(data.Filecontratto))
            {
                lblViewFileContratto.Text = "<a href=\"../../../DownloadFile?type=contratti&nomefile=" + data.Filecontratto + "\" target='_blank'>Apri File</a>";
            }
            lblnoteproroga.Text = data.Notetemplate;

            if (data.Checkpool == 1)
            {
                checkpool.Checked = true;
            }
            else
            {
                checkpool.Checked = false;
            }
            txtNotePool.Text = data.Notepool;
            ddlStatusPool.SelectedValue = data.Idstatuspool.ToString();

            //calcolo fringe benefit
            int percentuale = servizioFileTracciati.ReturnColonnaPerc(data.Emissioni);
            string campo = servizioFileTracciati.ReturnCampoPerc(percentuale);
            decimal valore = servizioFileTracciati.DValorePercentualeFringe(data.Codjatoauto, campo);
            decimal totalefringe = servizioFileTracciati.TotaleFringeBenefit(valore);

            lblCalcoloFringe.Text = "Emissione: " + data.Emissioni.ToString() + " - Colonna: " + percentuale + "% <br />";
            lblCalcoloFringe.Text += "Fringe: " + valore + " / 12 = <strong>&euro; " + totalefringe.ToString("F2") + "</strong>";


            //storico assegnazioni
            List<IContratti> dataStoricoAss = servizioContratti.SelectContrattiAssXIdContratto(data.Idcontratto);
            if (dataStoricoAss != null && dataStoricoAss.Count > 0)
            {
                ltstoricoassegnazioni.Text += "<table class='display nowrap' cellspacing='0' align='Center' style='width:100%;border-collapse:collapse;'>";
                ltstoricoassegnazioni.Text += "<thead><tr>";
                ltstoricoassegnazioni.Text += "<th scope='col' style='width:20%;'>Assegnato A</th><th scope='col' style='width:20%;'>Periodo</th><th scope='col' style='width:20%;'>Societ&agrave;</th><th scope='col' style='width:20%;'>Targa</th><th scope='col' style='width:20%;'>Azioni</th>";
                ltstoricoassegnazioni.Text += "</tr></thead>";
                ltstoricoassegnazioni.Text += "<tbody>";

                foreach (IContratti resultStoricoAss in dataStoricoAss)
                {
                    ltstoricoassegnazioni.Text += "<tr>";
                    ltstoricoassegnazioni.Text += "<td style='width:20%;'>" + resultStoricoAss.Cognome + "</td>";
                    ltstoricoassegnazioni.Text += "<td style='width:20%;'>dal " + resultStoricoAss.Assegnatodal.ToString("dd/MM/yyyy") + " al " + resultStoricoAss.Assegnatoal.ToString("dd/MM/yyyy") + "</td>";
                    ltstoricoassegnazioni.Text += "<td style='width:20%;'>" + resultStoricoAss.Societa + "</td>";
                    ltstoricoassegnazioni.Text += "<td style='width:20%;'>" + resultStoricoAss.Targa + "</td>";
                    ltstoricoassegnazioni.Text += "<td style='width:20%;'><button type='button' class='btn btn-primary btnass' data-toggle='modal' data-id='" + resultStoricoAss.Idassegnazione + "' " +
                                                  "data-userid='" + resultStoricoAss.UserId + "' data-dataassdal='" + resultStoricoAss.Assegnatodal.ToString("dd/MM/yyyy") + "' " +
                                                  "data-dataassal='" + resultStoricoAss.Assegnatoal.ToString("dd/MM/yyyy") + "' data-idstatus='" + resultStoricoAss.Idstatusassegnazione + "' data-target='#exampleModal'>Modifica</button>" +
                                                  " <a href='InsRiconsegna-" + resultStoricoAss.Idassegnazione + "' class='btn btn-primary' target='_blank'>Restituzione</a>" +
                                                  "</td>";
                    ltstoricoassegnazioni.Text += "</tr>";
                }
                ltstoricoassegnazioni.Text += "</tbody></table>";
            }

            //recupero nome driver
            IAccount dataUt = servizioAccount.DetailId(data.UserId);
            if (dataUt != null)
            {
                lblNomeDriver.Text += dataUt.Cognome + " " + dataUt.Nome + " (" + dataUt.Matricola + ")";
            }

            //recupero attuale idassegnazione e documenti auto
            IContratti dataAss = servizioContratti.DetailContrattiAssId(data.Idcontratto, data.UserId);
            if (dataAss != null)
            {
                //dettagli documenti
                IContratti dataDoc = servizioContratti.DetailAssegnazioniContrattiXId(dataAss.Idassegnazione);
                if (dataDoc != null)
                {
                    hdFileVerbaleAuto.Value = dataDoc.Fileverbaleauto;
                    hdFileRifiutoAuto.Value = dataDoc.Filerifiutoauto;
                    hdFileVerbale.Value = dataDoc.Fileverbaleconsegna;
                    hdFileRelazione.Value = dataDoc.Filerelazioneperito;
                    hdFileDenunce.Value = dataDoc.Filedenunce;
                    hdFuelCard.Value = dataDoc.Documentofuelcard;
                    hdidassegnazione_.Value = dataDoc.Idassegnazione.ToString();

                    if (!string.IsNullOrEmpty(dataDoc.Fileverbaleauto))
                    {
                        lblViewFileVerbaleAuto.Text = "<a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataDoc.Fileverbaleauto + "\" target='_blank'>Apri File</a><br />";
                    }
                    if (!string.IsNullOrEmpty(dataDoc.Filerifiutoauto))
                    {
                        lblViewFileRifiutoAuto.Text = "<a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataDoc.Filerifiutoauto + "\" target='_blank'>Apri File</a><br />";
                    }
                    if (!string.IsNullOrEmpty(dataDoc.Fileverbaleconsegna))
                    {
                        lblViewFileVerbale.Text = "<a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataDoc.Fileverbaleconsegna + "\" target='_blank'>Apri File</a><br />";
                    }
                    if (!string.IsNullOrEmpty(dataDoc.Filerelazioneperito))
                    {
                        lblViewFileRelazione.Text = "<a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataDoc.Filerelazioneperito + "\" target='_blank'>Apri File</a><br />";
                    }
                    if (!string.IsNullOrEmpty(dataDoc.Filedenunce))
                    {
                        lblViewFileDenunce.Text = "<a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataDoc.Filedenunce + "\" target='_blank'>Apri File</a><br />";
                    }
                    if (!string.IsNullOrEmpty(dataDoc.Documentofuelcard))
                    {
                        lblViewFuelCard.Text = "<a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataDoc.Documentofuelcard + "\" target='_blank'>Apri File</a><br />";
                    }
                }

            }






            //dettagli ordini
            IContratti dataO = servizioContratti.DetailOrdiniId(data.Uidordine);
            if (dataO != null)
            {
                lblcanoneleasing.Text = "<strong>TOTALE: </strong> <span style='font-weight:bold; color:red;'>&euro;</span> " + dataO.Deltacanone.ToString();

                //dati ordine
                dettagliordine += "Num. Ordine <b>" + dataO.Numeroordine + "</b> del <b>" + dataO.Dataordine.ToString("dd/MM/yyyy") + "</b><br />";
                if (!string.IsNullOrEmpty(dataO.Annotazioniordini))
                {
                    dettagliordine += "Note: " + dataO.Annotazioniordini + "<br />";
                }
                if (!string.IsNullOrEmpty(dataO.Motivoscarto))
                {
                    dettagliordine += "Scartato il " + dataO.Data100.ToString("dd/MM/yyyy") + " motivo scarto: " + dataO.Motivoscarto + "<br />";
                }
                dettagliordine += "Canone Leasing: " + dataO.Canoneleasing + "<br />";
                if (dataO.Dataconsegnaprevista > DateTime.MinValue)
                {
                    dettagliordine += "Consegna prevista il: " + dataO.Dataconsegnaprevista.ToString("dd/MM/yyyy") + "<br />";
                }

                if (!string.IsNullOrEmpty(dataO.Filefirma))
                {
                    dettagliordine += "File Firmato: <a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataO.Filefirma + "\" target='_blank'>Apri File</a><br />";
                }
                if (!string.IsNullOrEmpty(dataO.Fileconfermarental))
                {
                    dettagliordine += "File Conferma Fornitore: <a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataO.Fileconfermarental + "\" target='_blank'>Apri File</a><br />";
                }

                if (dataO.Data10 > DateTime.MinValue)
                {
                    dettagliordine += "Pending presa in carico Rental: " + dataO.Data10.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data20 > DateTime.MinValue)
                {
                    dettagliordine += "In attesa di offerta da Rental: " + dataO.Data20.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data25 > DateTime.MinValue)
                {
                    dettagliordine += "Elaborazione offerta: " + dataO.Data25.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data30 > DateTime.MinValue)
                {
                    dettagliordine += "Offerta da valutare Driver: " + dataO.Data30.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data40 > DateTime.MinValue)
                {
                    dettagliordine += "Offerta da valutare D4M: " + dataO.Data40.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data50 > DateTime.MinValue)
                {
                    dettagliordine += "In attesa di evasione Rental: " + dataO.Data50.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data55 > DateTime.MinValue)
                {
                    dettagliordine += "Evaso Rental: " + dataO.Data55.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data60 > DateTime.MinValue)
                {
                    dettagliordine += "Offerta contrattualizzata: " + dataO.Data60.ToString("dd/MM/yyyy") + "<br />";
                }

                if (dataO.Data110 > DateTime.MinValue)
                {
                    dettagliordine += "Non Autorizzato: " + dataO.Data110.ToString("dd/MM/yyyy") + "<br />";
                }



                lblDatiOrdine.Text = dettagliordine;

                //recupero modello auto
                ICars dataCar = servizioCar.DetailCarListAutoXCodjato(dataO.Codjatoauto, data.Codcarlist);
                if (dataCar != null)
                {
                    lblAuto.Text = dataCar.Modello;
                    dettagliauto += "Cilindrata: " + dataCar.Cilindrata + "<br />";
                    dettagliauto += "Alimentazione: " + dataCar.Alimentazione + "<br />";
                    dettagliauto += "Alimentazione secondaria: " + dataCar.Alimentazionesecondaria + "<br />";
                    dettagliauto += "Consumo: " + dataCar.Consumo + "<br />";
                    dettagliauto += "Consumourbano: " + dataCar.Consumourbano + "<br />";
                    dettagliauto += "Consumoextraurbano: " + dataCar.Consumoextraurbano + "<br />";
                    dettagliauto += "Emissioni: " + dataCar.Emissioni + "<br />";
                    dettagliauto += "Fringe benefit base: " + dataCar.Fringebenefitbase + "<br />";

                    RecuperaColori(data.Codjatoauto, dataO.Idordine);
                    RecuperaOptional(data.Codjatoauto, dataO.Idordine);
                }

                lblDatiAuto.Text = dettagliauto;

            }
        }

        public void RecuperaColori(string codjatoauto, int idordine)
        {
            ICarsBL servizioCar = new CarsBL();
            string elencocolori = "";
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int count = 0;

            elencocolori += "<div class='category'>Colori</div>";

            List<ICars> dataOpt = servizioCar.SelectAllColori(codjatoauto, Uidtenant);
            if (dataOpt != null && dataOpt.Count > 0)
            {
                foreach (ICars resultOpt in dataOpt)
                {
                    elencocolori += "<div class='optional-table'>";
                    if (servizioCar.ExistOrdineOptionalAuto(idordine, resultOpt.Codoptional))
                    {
                        elencocolori += "<div class='optional-table-left'><input type='radio' class='codcolore' data-id='" + count + "'  onclick='return false;' checked='checked' id='codcolore_" + count + "' name='codcolore' value=\"" + resultOpt.Codoptional + "\" /></div>";
                    }
                    else
                    {
                        elencocolori += "<div class='optional-table-left'><input type='radio' class='codcolore' data-id='" + count + "'  onclick='return false;' id='codcolore_" + count + "' name='codcolore' value=\"" + resultOpt.Codoptional + "\" /></div>";
                    }
                    elencocolori += "<div class='optional-table-center'>" + resultOpt.Optional + "</div>";
                    elencocolori += "<div class='optional-table-right'></div>";
                    elencocolori += "</div>";

                    count++;
                }
            }

            ltcolori.Text = elencocolori;
        }

        public void RecuperaOptional(string codjatoauto, int idordine)
        {
            ICarsBL servizioCar = new CarsBL();
            string elencooptional = "";
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

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
                            List<ICars> dataOpt = servizioCar.SelectOptionalAuto(SeoHelper.EncodeString(codjatoauto), resultCatOpt.Codcategoriaoptional, resultSottoCatOpt.Codcategoriaoptional);
                            if (dataOpt != null && dataOpt.Count > 0)
                            {
                                foreach (ICars resultOpt in dataOpt)
                                {
                                    if (servizioCar.ExistOrdineOptionalAuto(idordine, resultOpt.Codoptional))
                                    {
                                        elencooptional += "<div class='optional-table'>";
                                        elencooptional += "<div class='optional-table-left'><input type='checkbox' class='codoptional' onclick='return false;' checked='checked' value=\"" + resultOpt.Codoptional + "\" /></div>";
                                        elencooptional += "<div class='optional-table-center'>" + resultOpt.Optional + "</div>";
                                        elencooptional += "<div class='optional-table-right'>";
                                        if (resultOpt.Importooptional == 0)
                                        {
                                            elencooptional += " di serie";
                                        }
                                        else
                                        {
                                            elencooptional += " &euro; " + servizioCar.DetailImportoOrdineOptionalAuto(idordine, resultOpt.Codoptional).Importooptional;
                                        }
                                        elencooptional += "</div>";
                                        elencooptional += "</div>";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            ltoptional.Text = elencooptional;
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateContratti("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateContratti("salvachiudi");
        }


        public void UpdateContratti(string opzione)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            int _checkpool;
            int _checkassegnatario;
            int _flglibrettoinviato;
            int _riparazione;


            if (checkpool.Checked)
            {
                _checkpool = 1;
            }
            else
            {
                _checkpool = 0;
            }

            if (checkassegnatario.Checked)
            {
                _checkassegnatario = 1;
            }
            else
            {
                _checkassegnatario = 0;
            }

            if (flglibrettoinviato.Checked)
            {
                _flglibrettoinviato = 1;
            }
            else
            {
                _flglibrettoinviato = 0;
            }

            if (checkriparazione.Checked)
            {
                _riparazione = 1;
            }
            else
            {
                _riparazione = 0;
            }

            IContratti contrattoNew = new Contratti
            {
                Codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue),
                Codjatoauto = SeoHelper.EncodeString(ddlCodjatoAuto.SelectedValue),
                Codcarpolicy = SeoHelper.EncodeString(ddlCodCarPolicy.SelectedValue),
                Codcarlist = SeoHelper.EncodeString(ddlCodCarList.SelectedValue),
                Codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue),
                Codtipocontratto = SeoHelper.EncodeString(ddlCodTipoContratto.SelectedValue),
                Codtipousocontratto = SeoHelper.EncodeString(ddlCodTipoUsoContratto.SelectedValue),
                Numordineordine = SeoHelper.EncodeString(txtNumeroOrdine.Text),
                Numerocontratto = SeoHelper.EncodeString(txtNumeroContratto.Text),
                Datacontratto = SeoHelper.DataString(txtDataContratto.Text),
                Duratamesi = SeoHelper.IntString(txtDurataMesi.Text),
                Kmcontratto = SeoHelper.IntString(txtKmContratto.Text),
                Franchigia = SeoHelper.DecimalString(txtFranchigia.Text),
                Datainiziocontratto = SeoHelper.DataString(txtDatainiziocontratto.Text),
                Datainiziouso = SeoHelper.DataString(txtDatainiziouso.Text),
                Datafinecontratto = SeoHelper.DataString(txtDatafinecontratto.Text),
                Annotazionicontratto = SeoHelper.EncodeString(txtAnnotazionicontratto.Text),
                Canoneleasing = SeoHelper.DecimalString(txtCanoneleasing.Text),
                Idstatuscontratto = SeoHelper.IntString(ddlstatus.SelectedValue),
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Dataimmatricolazione = SeoHelper.DataString(txtDataimmatricolazione.Text),
                Scadenzabollo = SeoHelper.DataString(txtScadenzaBollo.Text),
                Scadenzasuperbollo = SeoHelper.DataString(txtScadenzaSuperBollo.Text),
                Bollo = SeoHelper.DecimalString(txtBollo.Text),
                Superbollo = SeoHelper.DecimalString(txtSuperBollo.Text),
                Idtipoassegnazione = SeoHelper.IntString(ddlTipoAssegnazione.SelectedValue),
                Emissioni = SeoHelper.DecimalString(txtEmissioni.Text),
                Deltacanone = SeoHelper.DecimalString(txtDeltaCanone.Text),
                Canonefinanziario = SeoHelper.DecimalString(txtCanoneFinanziario.Text),
                Canoneservizi = SeoHelper.DecimalString(txtCanoneServizi.Text),
                Costokmeccedente = SeoHelper.DecimalString(txtCostokmeccedente.Text),
                Costokmrimborso = SeoHelper.DecimalString(txtCostokmrimborso.Text),
                Sogliakm = SeoHelper.DecimalString(txtSogliakm.Text),
                Fringebenefit = SeoHelper.DecimalString(txtFringe.Text),
                Idstatuspool = SeoHelper.IntString(ddlStatusPool.SelectedValue),
                Checkpool = _checkpool,
                UserIdpool = new Guid(SeoHelper.EncodeString(ddlUserIdPool.SelectedValue)),
                Notepool = SeoHelper.EncodeString(txtNotePool.Text),
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
                Idcontratto = SeoHelper.IntString(hdidcontratto.Value),
                Datarevisione = SeoHelper.DataString(txtDatarevisione.Text),
                Codcolore = SeoHelper.EncodeString(ddlColore.SelectedValue),
                Checkassegnatario = _checkassegnatario,
                Flglibrettoinviato = _flglibrettoinviato,
                Canonefigurativo = SeoHelper.DecimalString(txtCanoneFigurativo.Text),
                Alimentazionecontratto = SeoHelper.EncodeString(txtAlimentazione.Text),
                Cilindratacontratto = SeoHelper.EncodeString(txtCilindrata.Text),
                Kwcvcontratto = SeoHelper.EncodeString(txtKwcv.Text),
                Codutilizzo = SeoHelper.EncodeString(ddlTipoUtilizzo.SelectedValue),
                Riparazione = _riparazione,
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;
            bool controlTipoFile = false;
            bool controlFileLoad;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/contratti/";


            if (string.IsNullOrEmpty(contrattoNew.Codsocieta))
            {
                ddlCodsocieta.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Societ&agrave;<br />";
            }
            else
            {
                ddlCodsocieta.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Codjatoauto))
            {
                ddlCodjatoAuto.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codjato auto<br />";
            }
            else
            {
                ddlCodjatoAuto.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Codfornitore))
            {
                ddlFornitore.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice fornitore<br />";
            }
            else
            {
                ddlFornitore.CssClass = "form-control";
            }

            if (contrattoNew.Idstatuscontratto == -1)
            {
                ddlstatus.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Status contratto<br />";
            }
            else
            {
                ddlstatus.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Targa))
            {
                txtTarga.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Targa<br />";
            }
            else
            {
                txtTarga.CssClass = "form-control";
            }

            // controllo se fuFileContratto contiene un file da caricare
            string filename = SeoHelper.OraAttuale() + "-" + fuFileContratto.FileName;
            if (fuFileContratto.HasFile == false)
            {
                contrattoNew.Filecontratto = filename;
                controlFileLoad = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileContratto.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
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
                        fuFileContratto.SaveAs(filePath);
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
                            string containerName = "contratti";
                            string blobName = filename;
                            string fileName = filename;
                            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/contratti/";
                            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/contratti/";
                            string sas = Global.sas;

                            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                            string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                            Response.Write(resultBlob);

                            contrattoNew.Filecontratto = filename;
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
                    if (servizioContratti.UpdateContratti(contrattoNew) == 1)
                    {

                        /*IContratti contrattoNew3 = new Contratti
                        {
                            UserId = contrattoNew.UserId,
                            Targa = contrattoNew.Targa,
                            Assegnatodal = contrattoNew.Datainiziocontratto,
                            Assegnatoal = contrattoNew.Datafinecontratto,
                            Idstatusassegnazione = 0,
                            Idcontratto = contrattoNew.Idcontratto,
                            Codsocieta = contrattoNew.Codsocieta,
                            Uidtenant = SeoHelper.ReturnSessionTenant()
                        };

                        if (!servizioContratti.ExistAssegnazioneContratto(contrattoNew.UserId, contrattoNew.Idcontratto))
                        {
                            //assegnazione contratto nuovo se non esistente
                            servizioContratti.InsertInizioAssegnazioneContratto(contrattoNew3);
                        }
                        else
                        {
                            //aggiorna assegnazione contratto 
                            //servizioContratti.UpdateInizioAssegnazioneContratto(contrattoNew3);
                        }*/

                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + contrattoNew.Uid);


                        if (opzione.ToUpper() == "SALVA")
                        {
                            //messaggio avvenuto inserimento
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Contratti/ViewContratti") + "'>Ritorna alla Lista</a>";
                        }
                        else
                        {
                            Response.Redirect("ViewContratti");
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
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            Guid Uid = SeoHelper.GuidString(hduid.Value);
            DateTime dataproroga = SeoHelper.DataString(txtDataProroga.Text);

            string error = string.Empty;


            if (dataproroga == DateTime.MinValue)
            {
                txtDataProroga.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Data Proroga<br />";
            }
            else
            {
                txtDataProroga.CssClass = "form-control";
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
                string operatore = "";

                IAccount data = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
                if (data != null)
                {
                    operatore = data.Cognome + " " + data.Nome;
                }
                string nota = " Contratto prorogato dal " + txtDatafinecontratto.Text + " al " + dataproroga.ToString("dd/MM/yyyy") + " da " + operatore + " <br /> ";


                if (servizioContratti.UpdateProrogaContratto(Uid, dataproroga, nota, SeoHelper.ReturnSessionTenant()) == 1)
                {

                    IContratti contrattoNew3 = new Contratti
                    {
                        UserId = SeoHelper.GuidString(ddlUsers.SelectedValue),
                        Assegnatoal = dataproroga,
                        Idstatusassegnazione = 0,
                        Idcontratto = SeoHelper.IntString(hdidcontratto.Value),
                        Codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue),
                        Targa = SeoHelper.EncodeString(txtTarga.Text),
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };


                    IContratti dataC = servizioContratti.DetailContrattiAssId(contrattoNew3.Idcontratto, contrattoNew3.UserId);
                    if (dataC != null)
                    {
                        contrattoNew3.Idassegnazione = dataC.Idassegnazione;
                    }

                    //aggiorna assegnazione contratto 
                    servizioContratti.UpdateInizioAssegnazioneContratto(contrattoNew3);
                    

                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + Uid);

                    Response.Redirect("EditContratti-" + Uid);
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Operazione fallita";
                }
            }
        }
        protected void btnModifica4_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = SeoHelper.GuidString(hduid.Value);

            string error = string.Empty;

            IContratti contrattoNew3 = new Contratti
            {
                UserId = SeoHelper.GuidString(ddlUserAss.SelectedValue),
                Assegnatodal = SeoHelper.DataString(txtDataInizioAssegnazione.Text),
                Assegnatoal = SeoHelper.DataString(txtDataFineAssegnazione.Text),
                Idstatusassegnazione = SeoHelper.IntString(hdistatusassegnazione.Value),
                Idcontratto = SeoHelper.IntString(hdidcontratto.Value),
                Idassegnazione = SeoHelper.IntString(hdidassegnazione.Value),
                Codsocieta = SeoHelper.EncodeString(ddlCodSocietaMod.SelectedValue),
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            if (contrattoNew3.UserId == Guid.Empty)
            {
                ddlUserAss.CssClass = "form-control is-invalid";
                error += "inserire un Driver<br />";
            }
            else
            {
                ddlUserAss.CssClass = "form-control";
            }
            if (string.IsNullOrEmpty(contrattoNew3.Codsocieta))
            {
                ddlCodSocietaMod.CssClass = "form-control is-invalid";
                error += "inserire una Societ&agrave;<br />";
            }
            else
            {
                ddlCodSocietaMod.CssClass = "form-control";
            }
            if (contrattoNew3.Assegnatodal == DateTime.MinValue)
            {
                txtDataInizioAssegnazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Inizio Assegnazione<br />";
            }
            else
            {
                txtDataInizioAssegnazione.CssClass = "form-control";
            }
            if (contrattoNew3.Assegnatoal == DateTime.MinValue)
            {
                txtDataFineAssegnazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Fine Assegnazione<br />";
            }
            else
            {
                txtDataFineAssegnazione.CssClass = "form-control";
            }

            if (servizioContratti.ExistAssegnazione(contrattoNew3.UserId, contrattoNew3.Codsocieta, contrattoNew3.Assegnatodal, contrattoNew3.Assegnatoal, contrattoNew3.Targa))
            {
                error += "Non puoi inserire lo stesso driver, stessa societ&agrave; e stesso periodo.<br />";
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
                IContratti dataC = servizioContratti.ReturnAssegnatoAlMaggiore(contrattoNew3.Idcontratto); //aggiorna la data assegnatoal maggiore
                if (dataC != null)
                {
                    servizioContratti.UpdateDataFineContratto(contrattoNew3.Idcontratto, dataC.Assegnatoal, dataC.UserId, SeoHelper.ReturnSessionTenant());
                }


                if (!servizioContratti.ExistAssegnazioneContratto(contrattoNew3.UserId, contrattoNew3.Idcontratto))
                {
                    //assegnazione contratto nuovo se non esistente
                    servizioContratti.InsertInizioAssegnazioneContratto(contrattoNew3);
                }
                else
                {
                    //aggiorna assegnazione contratto 
                    servizioContratti.UpdateInizioAssegnazioneContratto(contrattoNew3);
                }
                Response.Redirect("EditContratti-" + Uid);
            }
        }
        protected void btnModifica5_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = SeoHelper.GuidString(hduid.Value);

            string error = string.Empty;

            IContratti contrattoNew3 = new Contratti
            {
                UserId = SeoHelper.GuidString(ddlUserAssNew.SelectedValue),
                Assegnatodal = SeoHelper.DataString(txtDataInizioAssegnazioneNew.Text),
                Assegnatoal = SeoHelper.DataString(txtDataFineAssegnazioneNew.Text),
                Idstatusassegnazione = 0,
                Idcontratto = SeoHelper.IntString(hdidcontratto.Value),
                Codsocieta = SeoHelper.EncodeString(ddlCodSocietaNew.SelectedValue),
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            if (contrattoNew3.UserId == Guid.Empty)
            {
                ddlUserAss.CssClass = "form-control is-invalid";
                error += "inserire un Driver<br />";
            }
            else
            {
                ddlUserAss.CssClass = "form-control";
            }
            if (string.IsNullOrEmpty(contrattoNew3.Codsocieta))
            {
                ddlCodSocietaNew.CssClass = "form-control is-invalid";
                error += "inserire una Societ&agrave;<br />";
            }
            else
            {
                ddlCodSocietaNew.CssClass = "form-control";
            }
            if (contrattoNew3.Assegnatodal == DateTime.MinValue)
            {
                txtDataInizioAssegnazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Inizio Assegnazione<br />";
            }
            else
            {
                txtDataInizioAssegnazione.CssClass = "form-control";
            }
            if (contrattoNew3.Assegnatoal == DateTime.MinValue)
            {
                txtDataFineAssegnazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Fine Assegnazione<br />";
            }
            else
            {
                txtDataFineAssegnazione.CssClass = "form-control";
            }

            if (servizioContratti.ExistAssegnazione(contrattoNew3.UserId, contrattoNew3.Codsocieta, contrattoNew3.Assegnatodal, contrattoNew3.Assegnatoal, contrattoNew3.Targa))
            {
                error += "Non puoi inserire lo stesso driver, stessa societ&agrave; e stesso periodo.<br />";
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
                //assegnazione contratto nuovo
                servizioContratti.InsertInizioAssegnazioneContratto(contrattoNew3);

                IContratti dataC = servizioContratti.ReturnAssegnatoAlMaggiore(contrattoNew3.Idcontratto); //aggiorna la data assegnatoal maggiore
                if (dataC != null)
                {
                    servizioContratti.UpdateDataFineContratto(contrattoNew3.Idcontratto, dataC.Assegnatoal, dataC.UserId, SeoHelper.ReturnSessionTenant());
                }

                Response.Redirect("EditContratti-" + Uid + "?ins=ok");
            }
        }

        protected void btnModifica6_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = SeoHelper.GuidString(hduid.Value);
            Guid UserId = Guid.Empty;
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            string error = string.Empty;

            //recupero userid utente pool
            IContratti dataU = servizioContratti.ReturnUserIdAssPool(Uidtenant);
            if (dataU != null)
            {
                UserId = dataU.UserId;
            }
            

            IContratti contrattoNew3 = new Contratti
            {
                UserId = UserId,
                Assegnatodal = SeoHelper.DataString(txtDataInizioAssegnazioneNewPool.Text),
                Assegnatoal = SeoHelper.DataString(txtDataFineAssegnazioneNewPool.Text),
                Idstatusassegnazione = 5,
                Idcontratto = SeoHelper.IntString(hdidcontratto.Value),
                Codsocieta = SeoHelper.EncodeString(ddlSocietaNewPool.SelectedValue),
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };


            if (contrattoNew3.Assegnatodal == DateTime.MinValue)
            {
                txtDataInizioAssegnazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Inizio Assegnazione<br />";
            }
            else
            {
                txtDataInizioAssegnazione.CssClass = "form-control";
            }
            if (contrattoNew3.Assegnatoal == DateTime.MinValue)
            {
                txtDataFineAssegnazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Fine Assegnazione<br />";
            }
            else
            {
                txtDataFineAssegnazione.CssClass = "form-control";
            }

            if (servizioContratti.ExistAssegnazione(contrattoNew3.UserId, contrattoNew3.Codsocieta, contrattoNew3.Assegnatodal, contrattoNew3.Assegnatoal, contrattoNew3.Targa))
            {
                error += "Non puoi inserire lo stesso driver, stessa societ&agrave; e stesso periodo.<br />";
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
                //assegnazione contratto nuovo
                servizioContratti.InsertInizioAssegnazioneContratto(contrattoNew3);

                IContratti dataC = servizioContratti.ReturnAssegnatoAlMaggiore(contrattoNew3.Idcontratto); //aggiorna la data assegnatoal maggiore
                if (dataC != null)
                {
                    servizioContratti.UpdateDataFineContratto(contrattoNew3.Idcontratto, dataC.Assegnatoal, dataC.UserId, SeoHelper.ReturnSessionTenant());
                }

                Response.Redirect("EditContratti-" + Uid);
            }
        }

        protected void btnModifica7_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = SeoHelper.GuidString(hduid.Value);
            Guid UserId = Guid.Empty;

            string error = string.Empty;

            //recupero userid utente pool
            IContratti dataU = servizioContratti.ReturnUserIdAssRitiro();
            if (dataU != null)
            {
                UserId = dataU.UserId;
            }


            IContratti contrattoNew3 = new Contratti
            {
                UserId = UserId,
                Assegnatodal = SeoHelper.DataString(txtDataInizioAssegnazioneNewRitiro.Text),
                Assegnatoal = SeoHelper.DataString(txtDataFineAssegnazioneNewRitiro.Text),
                Idstatusassegnazione = 10,
                Idcontratto = SeoHelper.IntString(hdidcontratto.Value),
                Codsocieta = SeoHelper.EncodeString(ddlSocietaNewRitiro.SelectedValue),
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };


            if (contrattoNew3.Assegnatodal == DateTime.MinValue)
            {
                txtDataInizioAssegnazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Inizio Assegnazione<br />";
            }
            else
            {
                txtDataInizioAssegnazione.CssClass = "form-control";
            }
            if (contrattoNew3.Assegnatoal == DateTime.MinValue)
            {
                txtDataFineAssegnazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Fine Assegnazione<br />";
            }
            else
            {
                txtDataFineAssegnazione.CssClass = "form-control";
            }

            if (servizioContratti.ExistAssegnazione(contrattoNew3.UserId, contrattoNew3.Codsocieta, contrattoNew3.Assegnatodal, contrattoNew3.Assegnatoal, contrattoNew3.Targa))
            {
                error += "Non puoi inserire lo stesso driver, stessa societ&agrave; e stesso periodo.<br />";
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
                //assegnazione contratto nuovo
                servizioContratti.InsertInizioAssegnazioneContratto(contrattoNew3);

                IContratti dataC = servizioContratti.ReturnAssegnatoAlMaggiore(contrattoNew3.Idcontratto); //aggiorna la data assegnatoal maggiore
                if (dataC != null)
                {
                    servizioContratti.UpdateDataFineContratto(contrattoNew3.Idcontratto, dataC.Assegnatoal, dataC.UserId, SeoHelper.ReturnSessionTenant());
                }

                Response.Redirect("EditContratti-" + Uid);
            }
        }




        protected void btnModifica8_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            Guid Uid = SeoHelper.GuidString(hduid.Value);

            IContrattiBL servizioContratti = new ContrattiBL();
            IContratti contrattiNew = new Contratti
            {
                Kmpercorsi = SeoHelper.DecimalString(txtKmPercorsi.Text),
                UserId = SeoHelper.GuidString(ddlUsers.SelectedValue),
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Datains = SeoHelper.DataString(txtDataInsKm.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            if (contrattiNew.Kmpercorsi == 0)
            {
                txtKmPercorsi.CssClass = "form-control is-invalid";
                error += "Inserire un valore valido <br />";
            }
            else
            {
                txtKmPercorsi.CssClass = "form-control";
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
                if (servizioContratti.InsertKmPercorsi(contrattiNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento Km Percorsi " + contrattiNew.UserId);

                    Response.Redirect("EditContratti-" + Uid);
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Operazione fallita";
                }
            }
        }

        protected void btnModifica9_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = SeoHelper.GuidString(hduid.Value);
            int idassegnazione = SeoHelper.IntString(hdidassegnazione_.Value);

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
            bool controlFileLoad2 = false;
            bool controlFileLoad3 = false;
            bool controlFileLoad4 = false;
            bool controlFileLoad5 = false;
            bool controlFileLoad6 = false;
            bool controlFileLoad7 = false;
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
                fileverbale = hdFileVerbale.Value;
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
                    error += "Il file verbale consegna non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        controlTipoFile = false;
                        error += "Il file verbale consegna non può essere caricato perché non ha un'estensione .pdf <br />";
                    }
                    else
                    {
                        controlFileLoad = true;
                        controlTipoFile = true;
                    }
                }
            }


            if (fuFileRelazione.HasFile == false)
            {
                filerelazione = hdFileRelazione.Value;
                controlFileLoad2 = false;
            }
            else
            {
                fileExt2 = Path.GetExtension(filename2).Substring(1);

                // controllo la dimensione del file
                if (fuFileRelazione.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    error += "Il file relazione non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt2))
                    {
                        controlTipoFile = false;
                        error += "Il file relazione non può essere caricato perché non ha un'estensione .pdf <br />";
                    }
                    else
                    {
                        controlFileLoad2 = true;
                        controlTipoFile = true;
                    }
                }
            }


            if (fuFileDenunce.HasFile == false)
            {
                filedenuncia = hdFileDenunce.Value;
                controlFileLoad3 = false;
            }
            else
            {
                fileExt3 = Path.GetExtension(filename3).Substring(1);

                // controllo la dimensione del file
                if (fuFileDenunce.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    error += "Il file denunce non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt3))
                    {
                        controlTipoFile = false;
                        error += "Il file denunce non può essere caricato perché non ha un'estensione .pdf <br />";
                    }
                    else
                    {
                        controlFileLoad3 = true;
                        controlTipoFile = true;
                    }
                }
            }


            if (fuFileRifiutoAuto.HasFile == false)
            {
                filerifiutoauto = hdFileRifiutoAuto.Value;
                controlFileLoad4 = false;
            }
            else
            {
                fileExt4 = Path.GetExtension(filename4).Substring(1);

                // controllo la dimensione del file
                if (fuFileRifiutoAuto.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    error += "Il file rifiuto auto non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt4))
                    {
                        controlTipoFile = false;
                        error += "Il file rifiuto auto non può essere caricato perché non ha un'estensione .pdf <br />";
                    }
                    else
                    {
                        controlFileLoad4 = true;
                        controlTipoFile = true;
                    }
                }
            }

            if (fuFileVerbaleAuto.HasFile == false)
            {
                fileverbaleauto = hdFileVerbaleAuto.Value;
                controlFileLoad5 = false;
            }
            else
            {
                fileExt5 = Path.GetExtension(filename5).Substring(1);

                // controllo la dimensione del file
                if (fuFileVerbaleAuto.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    error += "Il file verbale auto non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt5))
                    {
                        controlTipoFile = false;
                        error += "Il file verbale auto non può essere caricato perché non ha un'estensione .pdf <br />";
                    }
                    else
                    {
                        controlFileLoad5 = true;
                        controlTipoFile = true;
                    }
                }
            }



            if (fuFileLibrettoAuto.HasFile == false)
            {
                filelibrettoauto = hdFileLibrettoAuto.Value;
                controlFileLoad6 = false;
            }
            else
            {
                fileExt6 = Path.GetExtension(filename6).Substring(1);

                // controllo la dimensione del file
                if (fuFileLibrettoAuto.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    error += "Il file libretto auto non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt6))
                    {
                        controlTipoFile = false;
                        error += "Il file libretto auto non può essere caricato perché non ha un'estensione .pdf <br />";
                    }
                    else
                    {
                        controlFileLoad6 = true;
                        controlTipoFile = true;
                    }
                }
            }

            if (fuFuelCard.HasFile == false)
            {
                filefuelcard = hdFuelCard.Value;
                controlFileLoad7 = false;
            }
            else
            {
                fileExt7 = Path.GetExtension(filename7).Substring(1);

                // controllo la dimensione del file
                if (fuFuelCard.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    error += "Il file ritiro fuel card non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt7))
                    {
                        controlTipoFile = false;
                        error += "Il file ritiro fuel card auto non può essere caricato perché non ha un'estensione .pdf <br />";
                    }
                    else
                    {
                        controlFileLoad7 = true;
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
                if (controlFileLoad || controlFileLoad2 || controlFileLoad3 || controlFileLoad4 || controlFileLoad5 || controlFileLoad6 || controlFileLoad7) //c'è un file da caricare
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
                        servizioContratti.UpdateFileLibrettoAuto(Uid, filelibrettoauto, SeoHelper.ReturnSessionTenant());

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
