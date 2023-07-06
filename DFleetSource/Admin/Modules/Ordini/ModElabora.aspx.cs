// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModElabora.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Ordini
{
    public partial class ModElabora : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(10)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
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
                        hdcodjatoauto.Value = data.Codjatoauto;
                        hdidordine.Value = data.Idordine.ToString();
                        hdfilerental.Value = data.Fileconfermarental;
                        lblOptionalCanone.Text = data.Deltacanone.ToString();
                        txtCanoneOfferta.Text = SeoHelper.CheckDecimalString(data.Deltacanone);
                        hduid.Value = uid.ToString();
                        lblCanoneTotale.Text = (data.Deltacanone + data.Canoneleasing).ToString();
                        txtAlimentazione.Text = data.Alimentazione;
                        txtNumOrdineFornitore.Text = data.Numeroordinefornitore;

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
                        dettagliordine += "<tr><td class='width30p nopadding'>Fornitore</td> <td class='width70p nopadding'> " + data.Fornitore + "</td></tr>";
                        if (!string.IsNullOrEmpty(data.Annotazioniordini))
                        {
                            dettagliordine += "<tr><td class='width30p nopadding'>Note</td> <td class='width70p nopadding'> " + data.Annotazioniordini + "</td></tr>";
                        }
                        if (!string.IsNullOrEmpty(data.Annotazioniordinirenter))
                        {
                            dettagliordine += "<tr><td class='width30p nopadding'>Note Renter</td> <td class='width70p nopadding'> " + data.Annotazioniordinirenter + "</td></tr>";
                        }
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
                            lblFringebenefitbase.Text = dataCar.Fringebenefitbase.ToString();
                            lblcanoneleasing.Text = data.Canoneleasing.ToString();
                            hdmesicontratto.Value = dataCar.Mesicontratto.ToString();
                        }

                    }
                    RecuperaColori();
                    RecuperaOptional();
                }
            }
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
            string idordine = hdidordine.Value;
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            string elencooptional = "";
            int countoptional = 0;
            int mesicontratto = SeoHelper.IntString(hdmesicontratto.Value);

            //elenco categorie
            List<ICars> dataCatOpt = servizioCar.SelectAllCategoriePrimoLivello(Uidtenant);
            if (dataCatOpt != null && dataCatOpt.Count > 0)
            {
                foreach (ICars resultCatOpt in dataCatOpt)
                {
                    //elenco sottocategorie
                    List<ICars> dataSottoCatOpt = servizioCar.SelectAllCategorieSecondoLivelloXCod(resultCatOpt.Codcategoriaoptional);
                    if (dataSottoCatOpt != null && dataSottoCatOpt.Count > 0)
                    {
                        foreach (ICars resultSottoCatOpt in dataSottoCatOpt)
                        {
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
                                            elencooptional += "<div class='optional-table blockoptional' id='blockopt_" + countoptional + "' style='height:80px;'>";
                                            elencooptional += "<div class='optional-table-left'><a data-count='" + countoptional + "' data-id='" + idordine + "' data-optional='" + resultOpt.Codoptional + "' class='text-inverse p-r-10 deleteopt' data-toggle='tooltip' data-placement='left' title='' data-original-title='Elimina Optional'><img src='../../../plugins/images/non_autorizza.svg' class='icon20' border='0' alt='' /></a></div>";
                                            elencooptional += "<div class='optional-table-center'>" + resultOpt.Optional + " (" + resultOpt.Codoptional + ")</div>";
                                            elencooptional += "<div class='optional-table-right'>";
                                            elencooptional += " &euro; <input type='text' class='importooptann' name='importoann_" + countoptional + "' id='importoann_" + countoptional + "' data-id='" + countoptional + "' size='10' maxlength='20' value='" + (resultOpt.Importooptional * mesicontratto) + "' /> Annuale";
                                            elencooptional += " <br /> &euro; <input type='text' class='importoopt' name='importo_" + countoptional + "' id='importo_" + countoptional + "' data-id='" + countoptional + "' size='10' maxlength='20' style='margin-top:10px;' value='" + resultOpt.Importooptional + "' /> ";                                            
                                            elencooptional += "<input type='hidden' name='codoptional_" + countoptional + "' value='" + resultOpt.Codoptional + "' /> ";
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


            hdcount.Value = countoptional.ToString();

            if (countoptional > 0)
            {
                ltoptional.Text = elencooptional;
            }
            else
            {
                ltoptional.Text = "Nessun optional aggiuntivo";
            }
        }
        public string ReturnLinkPdf()
        {
            return "../../../DownloadFile?type=ordini&nomefile=" + SeoHelper.EncodeString(hdfilerental.Value);
        }
        protected void btnConferma_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IUtilitysBL servizioUtility = new UtilitysBL();
            IAccountBL servizioAccount = new AccountBL();
            Guid Uid = new Guid(hduid.Value);
            int contaRecord = Convert.ToInt32(hdcount.Value);
            int idordine = Convert.ToInt32(hdidordine.Value);
            string importooptional;
            string codoptional;
            string email = "";
            Guid Userid = Guid.Empty;

            if (servizioContratti.UpdateChangeStatusOrdine2(Uid, 30, SeoHelper.DecimalString(txtCanoneOfferta.Text), SeoHelper.EncodeString(txtNote.Text), 
                SeoHelper.DecimalString(txtImportoTotaleOfferta.Text), SeoHelper.EncodeString(txtNumOrdineFornitore.Text), SeoHelper.EncodeString(txtAlimentazione.Text), SeoHelper.ReturnSessionTenant()) == 1)
            {
                //aggiorna importo optional ordine
                if (contaRecord > 0)
                {
                    for (int i = 0; i < contaRecord; i++)
                    {
                        importooptional = Request.Form["importo_" + i];
                        codoptional = Request.Form["codoptional_" + i];

                        IContratti OptNew = new Contratti
                        {
                            Idordine = idordine,
                            Codoptional = SeoHelper.EncodeString(codoptional),
                            Importooptional = SeoHelper.DecimalString(importooptional),
                            Uidtenant = SeoHelper.ReturnSessionTenant()
                        };

                        servizioContratti.UpdateOrdineOptional(OptNew);
                    }
                }



                IContratti data = servizioContratti.DetailOrdiniId(Uid);
                if (data != null)
                {
                    Userid = data.UserId;

                    //email driver
                    IAccount dataUt = servizioAccount.DetailId(Userid);
                    if (dataUt != null)
                    {
                        email = dataUt.Email;
                    }
                }


                //invio mail
                IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(14);
                if (dataTemplate != null)
                {
                    Recuperadatiuser datiUtente = new Recuperadatiuser();
                    MailHelper.SendMail("", email, "", "", "", "", dataTemplate.Oggetto, servizioUtility.InsComEmail(Userid, Guid.Empty, "", dataTemplate.Corpo), "", datiUtente.ReturnObjectTenant());
                }


                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Elaborazione Offerta " + Uid);

                Response.Redirect("RichiesteOrdini");
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
