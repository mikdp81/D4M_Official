// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="TelePass.aspx.cs" company="">
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

namespace DFleet.Users.Modules.Dash
{
    public partial class TelePass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccountBL servizioAccount = new AccountBL();
            string ltdoc = "";
            int count = 0;
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            hdiduser.Value = Membership.GetUser().ProviderUserKey.ToString();

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                loadPage();

                //lista telepass driver
                List<IAccount> dataFuelCard = servizioAccount.SelectTelePassXUser(UserId);

                if (dataFuelCard != null && dataFuelCard.Count > 0)
                {
                    foreach (IAccount resultFuelCard in dataFuelCard)
                    {
                        ltdoc += "Numero: " + resultFuelCard.Numero + "<br />" +
                                 "Scadenza: " + resultFuelCard.Scadenza.ToString("dd/MM/yyyy") + "<br />" +
                                 "Targa: " + resultFuelCard.Targa + "<br />";
                        count++;
                    }
                }
                else
                {
                    ltdoc += "Nessun telepass assegnato.";
                }

                ltdati.Text = ltdoc;
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
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioFileTracciati.SelectCountConsumiTelePass(UserId, datadal, dataal, search, numerofuelcard, Uidtenant);
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
            Response.Redirect("TelePass");
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
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioFileTracciati.SelectCountConsumiTelePass(UserId, datadal, dataal, search, numerofuelcard, Uidtenant);
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
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioFileTracciati.SelectCountConsumiTelePass(UserId, datadal, dataal, search, numerofuelcard, Uidtenant);
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

    }
}
