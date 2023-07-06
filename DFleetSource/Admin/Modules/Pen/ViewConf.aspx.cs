﻿// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewConf.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using System.Web;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Drawing;
using DFleet.Classes;

namespace DFleet.Admin.Modules.Pen
{
    public partial class ViewConf : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(56)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            IContrattiBL servizioContratti = new ContrattiBL();
            ICarsBL servizioCar = new CarsBL();

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailOrdiniId(uid);
                    if (data != null)
                    {
                        hdcodjatoauto.Value = data.Codjatoauto;
                        hdidordine.Value = data.Idordine.ToString();
                        hduid.Value = uid.ToString();
                        lblcanoneleasing.Text = data.Deltacanone.ToString();


                        //dati ordine
                        lbldatiordine.Text += "Num. Ordine <b>" + data.Numeroordine + "</b> del <b>" + data.Dataordine.ToString("dd/MM/yyyy") + "</b><br />";
                        if (!string.IsNullOrEmpty(data.Annotazioniordini))
                        {
                            lbldatiordine.Text += "Note: " + data.Annotazioniordini + "<br />";
                        }
                        if (!string.IsNullOrEmpty(data.Motivoscarto))
                        {
                            lbldatiordine.Text += "Scartato il " + data.Data100.ToString("dd/MM/yyyy") + " motivo scarto: " + data.Motivoscarto + "<br />";
                        }
                   
                        if (data.Dataconsegnaprevista > DateTime.MinValue)
                        {
                            lbldatiordine.Text += "Consegna prevista il: " + data.Dataconsegnaprevista.ToString("dd/MM/yyyy") + "<br />";
                        }

       
                        if (data.Data10 > DateTime.MinValue)
                        {
                            lbldatiordine.Text += "Pending presa in carico Rental: " + data.Data10.ToString("dd/MM/yyyy") + "<br />";
                        }
                        if (data.Data20 > DateTime.MinValue)
                        {
                            lbldatiordine.Text += "In attesa di offerta da Rental: " + data.Data20.ToString("dd/MM/yyyy") + "<br />";
                        }
                        if (data.Data25 > DateTime.MinValue)
                        {
                            lbldatiordine.Text += "Elaborazione offerta: " + data.Data25.ToString("dd/MM/yyyy") + "<br />";
                        }
                        if (data.Data30 > DateTime.MinValue)
                        {
                            lbldatiordine.Text += "Offerta da valutare Driver: " + data.Data30.ToString("dd/MM/yyyy") + "<br />";
                        }
                        if (data.Data40 > DateTime.MinValue)
                        {
                            lbldatiordine.Text += "Offerta da valutare D4M: " + data.Data40.ToString("dd/MM/yyyy") + "<br />";
                        }
                        if (data.Data50 > DateTime.MinValue)
                        {
                            lbldatiordine.Text += "In attesa di evasione Rental: " + data.Data50.ToString("dd/MM/yyyy") + "<br />";
                        }
                        if (data.Data55 > DateTime.MinValue)
                        {
                            lbldatiordine.Text += "Evaso Rental: " + data.Data55.ToString("dd/MM/yyyy") + "<br />";
                        }
                        if (data.Data60 > DateTime.MinValue)
                        {
                            lbldatiordine.Text += "Offerta contrattualizzata: " + data.Data60.ToString("dd/MM/yyyy") + "<br />";
                        }

                        if (data.Data110 > DateTime.MinValue)
                        {
                            lbldatiordine.Text += "Non Autorizzato: " + data.Data110.ToString("dd/MM/yyyy") + "<br />";
                        }



                        ICars dataCar = servizioCar.DetailCarListAutoXCodjato(data.Codjatoauto, data.Codcarlist);
                        if (dataCar != null)
                        {

                            lblMarca.Text = dataCar.Marca;
                            lblModello.Text = dataCar.Modello;
                            lblAlimentazione.Text = dataCar.Alimentazione;
                            lblAlimentazionesecondaria.Text = dataCar.Alimentazionesecondaria;
                            lblCilindrata.Text = dataCar.Cilindrata;
                            lblFringebenefitbase.Text = dataCar.Fringebenefitbase.ToString();
                            lblConsumo.Text = dataCar.Consumo.ToString();
                            lblConsumourbano.Text = dataCar.Consumourbano.ToString();
                            lblConsumoextraurbano.Text = dataCar.Consumoextraurbano.ToString();
                            lblEmissioni.Text = dataCar.Emissioni.ToString();
                            lblFoto.Text = ReturnFotoAuto(dataCar.Fotoauto);

                        }
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
            int count = 0;

            List<ICars> dataOpt = servizioCar.SelectAllColori("", Uidtenant);
            if (dataOpt != null && dataOpt.Count > 0)
            {
                foreach (ICars resultOpt in dataOpt)
                {
                    if (servizioCar.ExistOrdineOptionalAuto(SeoHelper.IntString(hdidordine.Value), resultOpt.Codoptional))
                    {
                        elencocolori += "<div class='optional-table'>";
                        elencocolori += "<div class='optional-table-left'><input type='radio' class='codcolore' onclick='return false;' checked='checked' name='codcolore' value=\"" + resultOpt.Codoptional + "\" /></div>";
                        elencocolori += "<div class='optional-table-center'>" + resultOpt.Optional + "</div>";
                        elencocolori += "<div class='optional-table-right'></div>";
                        elencocolori += "</div>";
                    }

                    count++;
                }
            }

            ltcolori.Text = elencocolori;
        }
        public void RecuperaOptional()
        {
            ICarsBL servizioCar = new CarsBL();
            string codjatoauto = hdcodjatoauto.Value;
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            string elencooptional = "";
            int countoptional = 0;

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
                                    if (servizioCar.ExistOrdineOptionalAuto(SeoHelper.IntString(hdidordine.Value), resultOpt.Codoptional))
                                    {
                                        if (resultOpt.Importooptional > 0)
                                        {
                                            elencooptional += "<div class='optional-table'>";
                                            elencooptional += "<div class='optional-table-left'><input type='checkbox' class='codoptional' onclick='return false;' checked='checked' value=\"" + resultOpt.Codoptional + "\" /></div>";
                                            elencooptional += "<div class='optional-table-center'>" + resultOpt.Optional + "</div>";
                                            elencooptional += "<div class='optional-table-right'>";
                                            elencooptional += " &euro; " + servizioCar.DetailImportoOrdineOptionalAuto(SeoHelper.IntString(hdidordine.Value), resultOpt.Codoptional).Importooptional;
                                            elencooptional += "</div>";
                                            elencooptional += "</div>";
                                            countoptional++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (countoptional > 0)
            {
                ltoptional.Text = elencooptional;
            }
            else
            {
                ltoptional.Text = "Nessun optional aggiuntivo";
            }
        }
        public string ReturnFotoAuto(string fotoauto)
        {
            string retVal;

            if (!string.IsNullOrEmpty(fotoauto))
            {
                retVal = "<img src='../../../DownloadFile?type=auto&nomefile=" + fotoauto + "' class='img-responsive' style='height: 300px !important;'>";
            }
            else
            {
                retVal = "<img src='../../../Repository/auto/nofoto.png' class='img-responsive' style='height: 300px !important;'>";
            }

            return retVal;
        }
    }
}