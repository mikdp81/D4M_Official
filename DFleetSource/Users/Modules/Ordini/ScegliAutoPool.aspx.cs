﻿// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ScegliAutoPool.aspx.cs" company="">
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

namespace DFleet.Users.Modules.Ordini
{
    public partial class ScegliAutoPool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
            IContrattiBL servizioContratti = new ContrattiBL();
            ICarsBL servizioCar = new CarsBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailContrattiId(uid);
                    if (data != null)
                    {
                        hdidcontratto.Value = data.Idcontratto.ToString();
                        hdcodjatoauto.Value = data.Codjatoauto;
                        lblkmtotali.Text = data.Kmcontratto.ToString();
                        lblscadenza.Text = data.Datafinecontratto.ToString("dd/MM/yyyy");
                        lblFringebenefitbase.Text = data.Fringebenefit.ToString();
                        lbloptionalcanone.Text = data.Deltacanone.ToString();


                        IContratti dataP = servizioContratti.ReturnUserIdAssPool(Uidtenant);
                        if (dataP != null)
                        {
                            IContratti dataA = servizioContratti.DetailContrattiAssId(data.Idcontratto, dataP.UserId);
                            if (dataA != null)
                            {
                                lblluogoritiro.Text = dataA.Luogoconsegna;
                            }
                        }                        

                        IContratti dataK = servizioContratti.SelectKmPercorsiAttuali(data.Targa);
                        if (dataK != null)
                        {
                            lblkmattuali.Text = dataK.Kmpercorsi.ToString();
                        }

                        IContratti data2 = servizioContratti.DetailOrdiniId(data.Uidordine);
                        if (data2 != null)
                        {
                            hdidordine.Value = data2.Idordine.ToString();
                        }

                        //recupero modello auto
                        ICars dataCar = servizioCar.DetailCarListAutoXCodjato(data.Codjatoauto, data.Codcarlist);
                        if (dataCar != null)
                        {
                            lblMarca.Text = dataCar.Marca;
                            lblModello.Text = dataCar.Modello;
                            lblAlimentazione.Text = dataCar.Alimentazione;
                            lblCilindrata.Text = dataCar.Cilindrata;
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
                                            elencooptional += " &euro; " + resultOpt.Importooptional;
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
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            Guid Uidtenant = datiUtente.ReturnUidTenant();

            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();

            string codsocieta = string.Empty;
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;

            //recupero codsocieta
            IAccount dataUt = servizioAccount.DetailId(UserId);
            if (dataUt != null)
            {
                codsocieta = dataUt.Codsocieta;
            }

            //inserimento ordine
            IContratti ordineNew = new Contratti
            {
                Codsocieta = codsocieta,
                UserId = UserId,
                Codjatoauto = SeoHelper.EncodeString(hdcodjatoauto.Value),
                Idcontratto = SeoHelper.IntString(hdidcontratto.Value),
                Numeroordine = ReturnNumeroOrdine(),
                Dataordine = DateTime.Now,
                Idstatusordine = 1,
                Uidtenant = Uidtenant
            };

            if (servizioContratti.InsertOrdiniPool(ordineNew) == 1)
            {
                Response.Redirect("RichiesteOrdini");
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Operazione fallita";
            }
        }

        public string ReturnNumeroOrdine()
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string retVal;

            IContratti data = servizioContratti.ReturnUltimoNumeroOrdinePool();
            if (data != null)
            {
                retVal = (data.Nconfigurazioni + 1).ToString();
            }
            else
            {
                retVal = "1";
            }

            return retVal;
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
