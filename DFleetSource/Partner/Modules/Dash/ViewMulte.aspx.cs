// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewMulte.aspx.cs" company="">
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

namespace DFleet.Partner.Modules.Dash
{
    public partial class ViewMulte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdUserId.Value = Membership.GetUser().ProviderUserKey.ToString();
            loadPage();
        }
        protected void btnCerca_Click(object sender, EventArgs e)
        {
            loadPage();
        }
        public void loadPage()
        {
            IMulteBL servizioMulte = new MulteBL();
            pnlMessage.Visible = false;
            string keysearch = SeoHelper.EncodeString(txtKeySearch.Text);
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idstatuslavorazione = 0;
            int idstatuspagamento = SeoHelper.IntString(ddlStatusPag.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string codtipomulta = SeoHelper.EncodeString(ddlCodTipoMulta.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioMulte.SelectCountMulte(keysearch, 0, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, Uidtenant);
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


            if (gvRicMulte.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicMulte.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            lblNumRecord.Text = "Multe: " + HttpUtility.HtmlEncode(totaleRighe);
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
            Response.Redirect("ViewMulte");
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
            IMulteBL servizioMulte = new MulteBL();
            string keysearch = SeoHelper.EncodeString(txtKeySearch.Text);
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idstatuslavorazione = 0;
            int idstatuspagamento = SeoHelper.IntString(ddlStatusPag.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string codtipomulta = SeoHelper.EncodeString(ddlCodTipoMulta.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioMulte.SelectCountMulte(keysearch, 0, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, Uidtenant);
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;
            
            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            IMulteBL servizioMulte = new MulteBL();
            string keysearch = SeoHelper.EncodeString(txtKeySearch.Text);
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idstatuslavorazione = 0;
            int idstatuspagamento = SeoHelper.IntString(ddlStatusPag.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string codtipomulta = SeoHelper.EncodeString(ddlCodTipoMulta.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioMulte.SelectCountMulte(keysearch, 0, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, Uidtenant);
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

        public string ReturnImporti(string importomulta, string importomultaridotto, string importomultascontato, string importomultapagato)
        {
            string retVal = "";

            if (!string.IsNullOrEmpty(importomultapagato) && importomultapagato != "0,00")
            {
                retVal += "Importo pagato: " + importomultapagato + "<br />";
            }
            else
            {
                if (!string.IsNullOrEmpty(importomultascontato) && importomultascontato != "0,00")
                {
                    retVal += "Scontato (1-5 gg): " + importomultascontato + "<br />";
                }
                if (!string.IsNullOrEmpty(importomultaridotto) && importomultaridotto != "0,00")
                {
                    retVal += "Ridotto (6-60 gg): " + importomultaridotto + "<br />";
                }
                if (!string.IsNullOrEmpty(importomulta) && importomulta != "0,00")
                {
                    retVal += "Intero (oltre 60 gg): " + importomulta;
                }
            }

            return retVal;
        }


    }
}
