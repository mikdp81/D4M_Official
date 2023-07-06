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

namespace DFleet.Admin.Modules.EPartner
{
    public partial class ModContratti : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(78)) //controllo se la pagina è autorizzata per l'utente 
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
            ICarsBL servizioCar = new CarsBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            string dettagliordine = string.Empty;
            string dettagliauto = string.Empty;

            ddlCodsocieta.SelectedValue = data.Codsocieta;
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

            if (data.Checkassegnatario == 1)
            {
                checkassegnatario.Checked = true;
            }
            else
            {
                checkassegnatario.Checked = false;
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
                ltstoricoassegnazioni.Text += "<th scope='col' style='width:20%;'>Assegnato A</th><th scope='col' style='width:20%;'>Periodo</th><th scope='col' style='width:20%;'>Societ&agrave;</th><th scope='col' style='width:20%;'>Targa</th>";
                ltstoricoassegnazioni.Text += "</tr></thead>";
                ltstoricoassegnazioni.Text += "<tbody>";

                foreach (IContratti resultStoricoAss in dataStoricoAss)
                {
                    ltstoricoassegnazioni.Text += "<tr>";
                    ltstoricoassegnazioni.Text += "<td style='width:20%;'>" + resultStoricoAss.Cognome + "</td>";
                    ltstoricoassegnazioni.Text += "<td style='width:20%;'>dal " + resultStoricoAss.Assegnatodal.ToString("dd/MM/yyyy") + " al " + resultStoricoAss.Assegnatoal.ToString("dd/MM/yyyy") + "</td>";
                    ltstoricoassegnazioni.Text += "<td style='width:20%;'>" + resultStoricoAss.Societa + "</td>";
                    ltstoricoassegnazioni.Text += "<td style='width:20%;'>" + resultStoricoAss.Targa + "</td>";
                   ltstoricoassegnazioni.Text += "</tr>";
                }
                ltstoricoassegnazioni.Text += "</tbody></table>";
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
    }
}
