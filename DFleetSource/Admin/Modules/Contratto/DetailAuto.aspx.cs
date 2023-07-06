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

namespace DFleet.Admin.Modules.Contratto
{
    public partial class DetailAuto : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(7)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
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


                        //storico assegnazioni
                        List<IContratti> dataStoricoAss = servizioContratti.SelectContrattiAssXIdContratto(data.Idcontratto);
                        if (dataStoricoAss != null && dataStoricoAss.Count > 0)
                        {
                            foreach (IContratti resultStoricoAss in dataStoricoAss)
                            {
                                ltstoricoassegnazioni.Text += "- Assegnata a " + resultStoricoAss.Cognome + " dal " + resultStoricoAss.Assegnatodal.ToString("dd/MM/yyyy") +
                                                              " al " + resultStoricoAss.Assegnatoal.ToString("dd/MM/yyyy") + "<br />";
                            }
                        }

                        IContratti dataP = servizioContratti.ReturnUserIdAssPool(Uidtenant);
                        if (dataP != null)
                        {
                            hdUserId.Value = dataP.UserId.ToString();
                            IContratti dataA = servizioContratti.DetailContrattiAssId(data.Idcontratto, dataP.UserId);
                            if (dataA != null)
                            {
                                lblluogoritiro.Text = dataA.Luogoconsegna;
                                txtLuogo.Text = dataA.Luogoconsegna;
                                txtNote.Text = dataA.Noteamministrazione;
                                ddlCondizione.SelectedValue = dataA.Idstatoauto.ToString();
                                ddlstatus.SelectedValue = dataA.Idstatusassegnazione.ToString();
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
                            lblAlimentazionesecondaria.Text = dataCar.Alimentazionesecondaria;
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
                    if (servizioCar.SelectCountOptionalAutoCat(codjatoauto, resultCatOpt.Codcategoriaoptional) > 0)
                    {
                        elencooptional += "<div class='category'>" + resultCatOpt.Categoriaoptional + "</div>";
                    }

                    //elenco sottocategorie
                    List<ICars> dataSottoCatOpt = servizioCar.SelectAllCategorieSecondoLivelloXCod(resultCatOpt.Codcategoriaoptional);
                    if (dataSottoCatOpt != null && dataSottoCatOpt.Count > 0)
                    {
                        foreach (ICars resultSottoCatOpt in dataSottoCatOpt)
                        {
                            if (servizioCar.SelectCountOptionalAutoSottoCat(codjatoauto, resultCatOpt.Codcategoriaoptional, resultSottoCatOpt.Codcategoriaoptional) > 0)
                            {
                                elencooptional += "<div class='subcategory'>" + resultSottoCatOpt.Categoriaoptional + "</div>";
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

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            IContratti contrattoNew = new Contratti
            {
                UserId = SeoHelper.GuidString(hdUserId.Value),
                Idcontratto = SeoHelper.IntString(hdidcontratto.Value),
                Idstatusassegnazione = SeoHelper.IntString(ddlstatus.SelectedValue),
                Idstatoauto = SeoHelper.IntString(ddlCondizione.SelectedValue),
                Luogoconsegna = SeoHelper.EncodeString(txtLuogo.Text),
                Noteamministrazione = SeoHelper.EncodeString(txtNote.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };


            string error = string.Empty;

            if (contrattoNew.Idstatusassegnazione == -1)
            {
                ddlstatus.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Status Assegnazione<br />";
            }
            else
            {
                ddlstatus.CssClass = "form-control";
            }

            if (contrattoNew.Idstatoauto == -1)
            {
                ddlCondizione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Condizione Auto<br />";
            }
            else
            {
                ddlCondizione.CssClass = "form-control";
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
                if (servizioContratti.UpdateAutoPool(contrattoNew) == 1)
                {                    
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica Auto Pool " + contrattoNew.Idcontratto);
                      
                    Response.Redirect("ViewAutoPool");                                       
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
