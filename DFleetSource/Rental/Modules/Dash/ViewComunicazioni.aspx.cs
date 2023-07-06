// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewComunicazioni.aspx.cs" company="">
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

namespace DFleet.Rental.Modules.Dash
{
    public partial class ViewComunicazioni : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdiduser.Value = Membership.GetUser().ProviderUserKey.ToString();
            loadPage();
        }
        protected void btnCerca_Click(object sender, EventArgs e)
        {
            loadPage();
        }

        public void loadPage()
        {
            IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
            pnlMessage.Visible = false;
            Guid UserId = SeoHelper.GuidString(hdiduser.Value);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idoggetto = SeoHelper.IntString(ddlOggetto.SelectedValue);
            int idstatuscomunicazione = SeoHelper.IntString(ddlStatusComunicazioni.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioComunicazioni.SelectCountComunicazioni(UserId, datadal, dataal, idoggetto, idstatuscomunicazione, 1, Uidtenant);
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


            if (gvCom.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvCom.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            lblNumRecord.Text = "Comunicazioni: " + HttpUtility.HtmlEncode(totaleRighe);
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
            Response.Redirect("ViewComunicazioni");
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
            IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
            Guid UserId = SeoHelper.GuidString(hdiduser.Value);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idoggetto = SeoHelper.IntString(ddlOggetto.SelectedValue);
            int idstatuscomunicazione = SeoHelper.IntString(ddlStatusComunicazioni.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioComunicazioni.SelectCountComunicazioni(UserId, datadal, dataal, idoggetto, idstatuscomunicazione, 1, Uidtenant);
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;

            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
            Guid UserId = SeoHelper.GuidString(hdiduser.Value);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idoggetto = SeoHelper.IntString(ddlOggetto.SelectedValue);
            int idstatuscomunicazione = SeoHelper.IntString(ddlStatusComunicazioni.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioComunicazioni.SelectCountComunicazioni(UserId, datadal, dataal, idoggetto, idstatuscomunicazione, 1, Uidtenant);
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

        public string ReturnOggetto(string idstatuslettura, string oggetto)
        {
            string retVal;

            if (idstatuslettura == "0")
            {
                retVal = "<strong'>" + oggetto + "</strong>";
            }
            else
            { 
                retVal = oggetto;
            }

            return retVal;
        }
        public string ReturnPriorita(string priorita)
        {
            string retVal;

            if (priorita == "0")
            {
                retVal = "";
            }
            else
            {
                retVal = "<i class='fa fa-exclamation'></i>";
            }

            return retVal;
        }

        public string ReturnIconAttach(string uidcomunicazionepadre)
        {
            string retVal;

            IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();

            int totaleRighe = servizioComunicazioni.SelectCountAllegatiComunicaione(new Guid(uidcomunicazionepadre));

            if (totaleRighe == 0)
            {
                retVal = "";
            }
            else
            {
                retVal = "<i class='fa fa-paperclip'></i>";
            }

            return retVal;
        }

        public string ReturnCancel(string idstatuscomunicazione, string UIDcomunicazione)
        {
            string retVal;

            if (idstatuscomunicazione == "0")
            {
                retVal = "<a href='DelCom-" + SeoHelper.EncodeString(UIDcomunicazione) + "' data-toggle='tooltip' data-placement='left' title='' data-original-title='Cancella Ticket'><img src='../../../plugins/images/chiudi_ticket.svg' class='icon20' border='0' alt='' /></a>";
            }   
            else
            {
                retVal = "";
            }

            return retVal;
        }


        public string ReturnData(string data)
        {
            string retVal = string.Empty;

            if (string.IsNullOrEmpty(data) || data == "01/01/0001 00:00:00")
            {
                retVal = "";
            }
            else
            {
                string[] data1 = data.Split(' ');
                retVal += data1[0];
            }

            return retVal;
        }
    }
}
