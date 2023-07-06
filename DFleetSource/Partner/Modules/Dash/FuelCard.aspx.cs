// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="FuelCard.aspx.cs" company="">
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
using System.Windows.Forms;

namespace DFleet.Partner.Modules.Dash
{
    public partial class FuelCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccountBL servizioAccount = new AccountBL();
            string ltdocattivi = "";
            string ltdocscaduti = "";
            int count = 0;
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            hdiduser.Value = Membership.GetUser().ProviderUserKey.ToString();


            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                loadPage();

                //lista fuelcard driver
                List<IAccount> dataFuelCard = servizioAccount.SelectFuelCardXUser(UserId);

                if (dataFuelCard != null && dataFuelCard.Count > 0)
                {
                    foreach (IAccount resultFuelCard in dataFuelCard)
                    {
                        if (resultFuelCard.Statusutente.ToUpper() == "INCORSO") //fuel card attive
                        {
                            ltdocattivi += "<div class='col-sm-3 white-box' style='height:180px;'>" +
                                     "<div class='col-sm-6'><strong>" + resultFuelCard.Compagnia + "</strong></div><br />" +
                                     "<div class='col-sm-3'>ID:</div><div class='col-sm-3'> " + resultFuelCard.Numero + "</div><br />" +
                                     "<div class='col-sm-3'>Scad.:</div> <div class='col-sm-3'>" + resultFuelCard.Scadenza.ToString("dd/MM/yyyy") + "</div><br />" +
                                     "<div class='col-sm-3'>Targa:</div> <div class='col-sm-2'>" + resultFuelCard.Targa + "</div><br />" +
                                     "<div class='col-sm-3'>Status: </div><div class='col-sm-2'>" + resultFuelCard.Stato + "</div><br />";

                            if (!string.IsNullOrEmpty(resultFuelCard.Pin))
                            {
                                ltdocattivi += "<div class='text-center mt-5'><input type='button' class='mostrapin ' id='mostrapin_" + count + "' data-id='" + count + "' value='MOSTRA PIN'>" +
                                            "<div class='pin_" + count + " text-verde h4' style='display:none;' >" + resultFuelCard.Pin + "</div></div>";
                            }                            

                            ltdocattivi += "</div>";
                        }
                        else //fuel card scadute o bloccate
                        {
                            ltdocscaduti += "<div class='col-sm-3 white-box' style='height:180px;'>" +
                                           "<div class='col-sm-6'><strong>" + resultFuelCard.Compagnia + "</strong></div><br />" +
                                           "<div class='col-sm-3'>ID:</div><div class='col-sm-3'> " + resultFuelCard.Numero + "</div><br />" +
                                           "<div class='col-sm-3'>Scad.:</div> <div class='col-sm-3'>" + resultFuelCard.Scadenza.ToString("dd/MM/yyyy") + "</div><br />" +
                                           "<div class='col-sm-3'>Targa:</div> <div class='col-sm-2'>" + resultFuelCard.Targa + "</div><br />" +
                                           "<div class='col-sm-3'>Status: </div><div class='col-sm-2'>" + resultFuelCard.Stato + "</div><br />";

                            ltdocscaduti += "</div>";
                        }

                        count++;
                    }
                }

                ltdatiattivi.Text = ltdocattivi;
                ltdatiscaduti.Text = ltdocscaduti;
            }
            else
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            loadPage();
        }
        public void loadPage()
        {
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            pnlMessage.Visible = false;
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string search = SeoHelper.EncodeString(txtSearch.Text);
            string numerofuelcard = SeoHelper.EncodeString(ddlFuelCard.SelectedValue);
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioFileTracciati.SelectCountConsumiDriver(UserId, datadal, dataal, search, numerofuelcard);
            int maxPage = (totaleRighe / totaleRecord) + 1;
            int pagina;


            if (string.IsNullOrEmpty(hdPagina.Value))
            {
                pagina = 1;
                hdPagina.Value = "1";
            }
            else
            {
                pagina = Convert.ToInt32(hdPagina.Value, CultureInfo.CurrentCulture);
            }


            if (gvConsumi.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvConsumi.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            lblNumRecord.Text = "Consumi: " + HttpUtility.HtmlEncode(totaleRighe);
            if (totaleRighe == 0)
            {
                lblMessage.Text = "Nessun dato disponibile. Ricerca con altri parametri.";
                pnlMessage.Visible = true;
            }
            else
            {
                pnlMessage.Visible = false;
            }

            if ((pagina - 1) <= 1)
            {
                pagingprec.Enabled = false;
                pagingprec.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingprec.Enabled = true;
                pagingprec.CssClass = "paginate_button";
            }

            if (maxPage < (pagina + 1))
            {
                pagingnext.Enabled = false;
                pagingnext.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingnext.Enabled = true;
                pagingnext.CssClass = "paginate_button";
            }
        }

        protected void btnSvuotaFiltri_Click(object sender, EventArgs e)
        {
            Response.Redirect("FuelCard");
        }

        /********************** PAGINAZIONE **********************/
        protected void pagingprec_Click(object sender, EventArgs e)
        {
            int valore = Convert.ToInt32(hdPagina.Value, CultureInfo.CurrentCulture);
            Paginations("prec", valore);
        }

        protected void pagingnext_Click(object sender, EventArgs e)
        {
            int valore = Convert.ToInt32(hdPagina.Value, CultureInfo.CurrentCulture);
            Paginations("next", valore);
        }

        protected void txtnumpag_TextChanged(object sender, EventArgs e)
        {
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string search = SeoHelper.EncodeString(txtSearch.Text);
            string numerofuelcard = SeoHelper.EncodeString(ddlFuelCard.SelectedValue);
            int totaleRighe = servizioFileTracciati.SelectCountConsumiDriver(UserId, datadal, dataal, search, numerofuelcard);
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;

            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string search = SeoHelper.EncodeString(txtSearch.Text);
            string numerofuelcard = SeoHelper.EncodeString(ddlFuelCard.SelectedValue);
            int totaleRighe = servizioFileTracciati.SelectCountConsumiDriver(UserId, datadal, dataal, search, numerofuelcard);
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int pagina = 0;
            int tmppaginaprec = 0;
            int tmppaginanext = 0;

            switch (tipo.ToUpper())
            {
                case "PREC":
                    pagina = valore - 1;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;
                case "NEXT":
                    pagina = valore + 1;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;
                case "ELENCO":
                    pagina = valore;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;

            }


            if ((tmppaginaprec) < 1)
            {
                pagingprec.Enabled = false;
                pagingprec.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingprec.Enabled = true;
                pagingprec.CssClass = "paginate_button";
            }

            if (maxPage < (tmppaginanext))
            {
                pagingnext.Enabled = false;
                pagingnext.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingnext.Enabled = true;
                pagingnext.CssClass = "paginate_button";
            }

            hdPagina.Value = Convert.ToString(pagina, CultureInfo.CurrentCulture);
            txtnumpag.Text = Convert.ToString(pagina, CultureInfo.CurrentCulture);
        }


        /********************** FINE PAGINAZIONE **********************/
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            decimal total = 0;

            foreach (GridViewRow row in gvConsumi.Rows)
            {
                HiddenField importo = (HiddenField)row.FindControl("hdimporto");

                total += Convert.ToDecimal(importo.Value);
            }            

            lblTotImporto.Text = "Totale: &euro; " + total;
        }
    }
}
