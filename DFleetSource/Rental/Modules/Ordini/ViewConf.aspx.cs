// ***********************************************************************
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

namespace DFleet.Rental.Modules.Ordini
{
    public partial class ViewConf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            ICarsBL servizioCar = new CarsBL();
            IAccountBL servizioAccount = new AccountBL();
            string dettagliordine = "";

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailOrdiniId(uid);
                    if (data != null)
                    {
                        //aggiorna status ordine solo se è in pending (STATUS 1 o 10)
                        if (data.Idstatusordine <= 10)
                        {
                            servizioContratti.UpdateChangeStatusOrdine(uid, 20, "", SeoHelper.ReturnSessionTenant());
                        }



                        hdcodjatoauto.Value = data.Codjatoauto;
                        hdidordine.Value = data.Idordine.ToString();
                        lblcanoneleasing.Text = data.Deltacanone.ToString();
                        hduid.Value = uid.ToString();


                        //dati driver
                        IAccount dataUt = servizioAccount.DetailId(data.UserId);
                        if (dataUt != null)
                        {
                            lblDatiDriver.Text += "<div class='table-responsive'><table class='table'>" +
                                           "<tr><td class='width30p nopadding'>Societ&agrave;</td> <td class='width70p nopadding'> " + data.Committente + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Dipendente</td> <td class='width70p nopadding'>" + dataUt.Nome + " " + dataUt.Cognome + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Email</td> <td class='width70p nopadding'> " + dataUt.Email + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Cellulare</td> <td class='width70p nopadding'> " + dataUt.Cellulare + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Sede</td> <td class='width70p nopadding'> " + data.Sedelavoro + "</td></tr>" +
                                           "</table></div>";
                        }



                        //dati ordine
                        dettagliordine += "<div class='table-responsive'><table class='table'><tr><td class='width30p nopadding'>Num. e data ordine</td> <td class='width70p nopadding'>" + data.Numeroordine + " del " + data.Dataordine.ToString("dd/MM/yyyy") + "</td></tr>";
                        if (!string.IsNullOrEmpty(data.Annotazioniordini))
                        {
                            dettagliordine += "<tr><td class='width30p nopadding'>Note</td> <td class='width70p nopadding'> " + data.Annotazioniordini + "</td></tr>";
                        }
                        if (!string.IsNullOrEmpty(data.Motivoscarto))
                        {
                            dettagliordine += "<tr><td class='width30p nopadding'>Scartato il </td> <td class='width70p nopadding'>" + data.Data100.ToString("dd/MM/yyyy") + " motivo scarto: " + data.Motivoscarto + "</td></tr>";
                        }
                        dettagliordine += "<tr><td class='width30p nopadding'>Canone Leasing</td> <td class='width70p nopadding'> " + data.Canoneleasing + "</td></tr>";
                        if (data.Dataconsegnaprevista > DateTime.MinValue)
                        {
                            dettagliordine += "<tr><td class='width30p nopadding'>Consegna prevista il</td> <td class='width70p nopadding'> " + data.Dataconsegnaprevista.ToString("dd/MM/yyyy") + "</td></tr>";
                        }

                        if (!string.IsNullOrEmpty(data.Fileordinepdf))
                        {
                            dettagliordine += "<tr class='no-print'><td class='width30p nopadding'>Configurazione</td> <td class='width70p nopadding'> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Fileordinepdf + "\" target='_blank'>Visualizza</a></td></tr>";
                        }
                        if (!string.IsNullOrEmpty(data.Fileconfermarental))
                        {
                            dettagliordine += "<tr class='no-print'><td class='width30p nopadding'>Offerta</td> <td class='width70p nopadding'> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Fileconfermarental + "\" target='_blank'>Visualizza</a></td></tr>";
                        }
                        if (!string.IsNullOrEmpty(data.Filefirma))
                        {
                            dettagliordine += "<tr class='no-print'><td class='width30p nopadding'>Ordine Firmato</td> <td class='width70p nopadding'> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Filefirma + "\" target='_blank'>Visualizza</a></td></tr>";
                        }

                        dettagliordine += "</table></div>";



                        lblDatiOrdine.Text = dettagliordine;

                        ICars dataCar = servizioCar.DetailCarListAutoXCodjato(data.Codjatoauto, data.Codcarlist);
                        if (dataCar != null)
                        {
                            lblCodjatoauto.Text = dataCar.Codjatoauto;
                            lblMarca.Text = dataCar.Marca;
                            lblModello.Text = dataCar.Modello;
                            lblAlimentazione.Text = dataCar.Alimentazione;
                            lblAlimentazionesecondaria.Text = dataCar.Alimentazionesecondaria;
                            lblCilindrata.Text = dataCar.Cilindrata;
                            lblFringebenefitbase.Text = dataCar.Fringebenefitbase.ToString();
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

            //elencocolori += "<div class='category'>Colori</div>";

            List<ICars> dataOpt = servizioCar.SelectAllColori("", Uidtenant);
            if (dataOpt != null && dataOpt.Count > 0)
            {
                hdcountcolor.Value = dataOpt.Count.ToString();
                foreach (ICars resultOpt in dataOpt)
                {
                    if (servizioCar.ExistOrdineOptionalAuto(SeoHelper.IntString(hdidordine.Value), resultOpt.Codoptional))
                    {
                        elencocolori += "<div class='optional-table'>";
                        elencocolori += "<div class='optional-table-left'><input type='radio' class='codcolore' onclick='return false;' checked='checked' name='codcolore' value=\"" + resultOpt.Codoptional + "\" /></div>";
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
                ltcolori.Text = "Nessun colore inserito";
            }
        }

        public void RecuperaOptional()
        {
            ICarsBL servizioCar = new CarsBL();
            string codjatoauto = hdcodjatoauto.Value;
            string elencooptional = "";
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int countoptional = 0;

            //elenco categorie
            List<ICars> dataCatOpt = servizioCar.SelectAllCategoriePrimoLivello(Uidtenant);
            if (dataCatOpt != null && dataCatOpt.Count > 0)
            {
                foreach (ICars resultCatOpt in dataCatOpt)
                {
                    if (servizioCar.SelectCountOptionalAutoCat(codjatoauto, resultCatOpt.Codcategoriaoptional) > 0)
                    {
                        //elencooptional += "<div class='category'>" + resultCatOpt.Categoriaoptional + "</div>";
                    }

                    //elenco sottocategorie
                    List<ICars> dataSottoCatOpt = servizioCar.SelectAllCategorieSecondoLivelloXCod(resultCatOpt.Codcategoriaoptional);
                    if (dataSottoCatOpt != null && dataSottoCatOpt.Count > 0)
                    {
                        foreach (ICars resultSottoCatOpt in dataSottoCatOpt)
                        {
                            if (servizioCar.SelectCountOptionalAutoSottoCat(codjatoauto, resultCatOpt.Codcategoriaoptional, resultSottoCatOpt.Codcategoriaoptional) > 0)
                            {
                                //elencooptional += "<div class='subcategory'>" + resultSottoCatOpt.Categoriaoptional + "</div>";
                            }

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
                                            elencooptional += "<div class='optional-table-center'>" + resultOpt.Optional + " (" + resultOpt.Codoptional + ")</div>";
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
