// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DetailAuto.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Car
{
    public partial class DetailAuto : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    //recupero dati auto
                    ICars dataCar = servizioCar.DetailCarListAutoId(uid);
                    if (dataCar != null)
                    {
                        lblMarca.Text = dataCar.Marca;
                        lblModello.Text = dataCar.Modello;
                        lblAlimentazione.Text = dataCar.Alimentazione;
                        lblAlimentazionesecondaria.Text = dataCar.Alimentazionesecondaria;
                        lblCilindrata.Text = dataCar.Cilindrata;
                        lblConsumo.Text = dataCar.Consumo.ToString();
                        lblConsumourbano.Text = dataCar.Consumourbano.ToString();
                        lblConsumoextraurbano.Text = dataCar.Consumoextraurbano.ToString();
                        lblEmissioni.Text = dataCar.Emissioni.ToString();
                        lblFringebenefitbase.Text = dataCar.Fringebenefitbase.ToString();
                        lblGiorniConsegna.Text = dataCar.Giorniconsegna.ToString();
                        lblFoto.Text = ReturnFotoAuto(dataCar.Fotoauto);
                        hdcodjatoauto.Value = dataCar.Codjatoauto;
                    }                    
                }
            }
            RecuperaColori();
            RecuperaOptional();
        }
        public void RecuperaColori()
        {
            ICarsBL servizioCar = new CarsBL();
            string codjatoauto = SeoHelper.EncodeString(hdcodjatoauto.Value);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            string elencocolori = "";
            int count = 0;

            List<ICars> dataOpt = servizioCar.SelectAllColori("", Uidtenant);
            if (dataOpt != null && dataOpt.Count > 0)
            {
                foreach (ICars resultOpt in dataOpt)
                {
                    bool existopt = false;
                    ICars dataExs = servizioCar.ExistOptionalAuto(codjatoauto, resultOpt.Codoptional);
                    if (dataExs != null)
                    {
                        existopt = true;
                    }

                    if (existopt)
                    {
                        elencocolori += "<div class='optional-table'>";
                        elencocolori += "<div class='optional-table-left'></div>";
                        elencocolori += "<div class='optional-table-center'>" + resultOpt.Optional + "</div>";
                        elencocolori += "<div class='optional-table-right'></div>";
                        elencocolori += "</div>";
                        count++;
                    }

                }
            }

            if (count > 0)
            {
                ltcolori.Text = elencocolori;
            }
            else
            {
                ltcolori.Text = "Nessun colore";
            }            
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
                                    bool existopt = false;
                                    ICars dataExs = servizioCar.ExistOptionalAuto(codjatoauto, resultOpt.Codoptional);
                                    if (dataExs != null)
                                    {
                                        existopt = true;
                                    }

                                    if (existopt)
                                    {                                        
                                        elencooptional += "<div class='optional-table'>";
                                        elencooptional += "<div class='optional-table-left'></div>";
                                        elencooptional += "<div class='optional-table-center'>" + resultOpt.Optional + "</div>";
                                        elencooptional += "<div class='optional-table-right'>";
                                        if (resultOpt.Importooptional > 0)
                                        {
                                            elencooptional += " &euro; " + resultOpt.Importooptional;
                                        }
                                        else
                                        {
                                            elencooptional += " di serie ";
                                        }

                                        if (resultOpt.Giorniconsegnaagg > 0)
                                        {
                                            elencooptional += " <br /> Giorni aggiuntivi consegna: " + resultOpt.Giorniconsegnaagg;
                                        }
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

            if (countoptional > 0)
            {
                ltoptional.Text = elencooptional;
            }
            else
            {
                ltoptional.Text = "Nessun optional";
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
