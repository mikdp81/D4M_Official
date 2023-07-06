// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewMulteDaPagare.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Multa
{
    public partial class ViewMulteDaPagare : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(20) && !datiUtente.ReturnExistPage(22)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadPage();
        }
        protected void btnCerca_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            loadPage();
        }
        protected void btnOrdina_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriOrdinamento()", true);
            loadPage();
        }
        public void loadPage()
        {
            IMulteBL servizioMulte = new MulteBL();
            pnlMessage.Visible = false;
            int idstatuspagamento;
            string keysearch = SeoHelper.EncodeString(txtKeySearch.Text);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            int idtipotrasmissione = SeoHelper.IntString(ddlTipoTrasm.SelectedValue);
            int idstatuslavorazione = SeoHelper.IntString(ddlStatusLav.SelectedValue);
            int idtitolarepagamento = SeoHelper.IntString(ddlTitolarePag.SelectedValue);
            if (!string.IsNullOrEmpty(ddlStatusPag.SelectedValue) && ddlStatusPag.SelectedValue != "-1")
            {
                idstatuspagamento = SeoHelper.IntString(ddlStatusPag.SelectedValue);
            }
            else
            {
                ddlStatusPag.SelectedValue = "0";
                idstatuspagamento = 0;
            }

            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string codtipomulta = SeoHelper.EncodeString(ddlCodTipoMulta.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioMulte.SelectCountMulteDaPagare(keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, idtitolarepagamento, Uidtenant);
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
            Response.Redirect("ViewMulteDaPagare");
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
            int idstatuspagamento;
            string keysearch = SeoHelper.EncodeString(txtKeySearch.Text);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            int idtipotrasmissione = SeoHelper.IntString(ddlTipoTrasm.SelectedValue);
            int idstatuslavorazione = SeoHelper.IntString(ddlStatusLav.SelectedValue);
            int idtitolarepagamento = SeoHelper.IntString(ddlTitolarePag.SelectedValue);
            if (!string.IsNullOrEmpty(ddlStatusPag.SelectedValue) && ddlStatusPag.SelectedValue != "-1")
            {
                idstatuspagamento = SeoHelper.IntString(ddlStatusPag.SelectedValue);
            }
            else
            {
                ddlStatusPag.SelectedValue = "0";
                idstatuspagamento = 0;
            }
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string codtipomulta = SeoHelper.EncodeString(ddlCodTipoMulta.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioMulte.SelectCountMulteDaPagare(keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, idtitolarepagamento, Uidtenant);
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
            int idstatuslavorazione = 0;
            string keysearch = SeoHelper.EncodeString(txtKeySearch.Text);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            int idtipotrasmissione = SeoHelper.IntString(ddlTipoTrasm.SelectedValue);
            int idstatuspagamento;
            int idtitolarepagamento = SeoHelper.IntString(ddlTitolarePag.SelectedValue);
            if (!string.IsNullOrEmpty(ddlStatusPag.SelectedValue) && ddlStatusPag.SelectedValue != "-1")
            {
                idstatuspagamento = SeoHelper.IntString(ddlStatusPag.SelectedValue);
            }
            else
            {
                ddlStatusPag.SelectedValue = "0";
                idstatuspagamento = 0;
            }
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string codtipomulta = SeoHelper.EncodeString(ddlCodTipoMulta.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioMulte.SelectCountMulteDaPagare(keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, idtitolarepagamento, Uidtenant);
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


        /********************** ESPORTA EXCEL **********************/

        protected void btnEsporta_Click(object sender, EventArgs e)
        {
            IMulteBL servizioMulte = new MulteBL();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excel = new ExcelPackage())
            {
                string namesheet = "ReportMulte-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

                excel.Workbook.Worksheets.Add(namesheet);

                FileInfo excelFile = new FileInfo(namesheet + ".xls");
                ExcelPackage package = new ExcelPackage(new FileInfo(namesheet + ".xls"));
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(namesheet);

                //intestazione
                var allCells = worksheet.Cells[1, 1, 200, 16];
                var cellFont = allCells.Style.Font;
                float fontSize = 10.0f; // Provide the appropriate value for the font size
                cellFont.SetFromFont("Arial", fontSize, true, false, false, false);

                //titoli intestazione
                worksheet.Cells["A1"].Value = "Numero Verbale";
                worksheet.Cells["B1"].Value = "Data Infrazione";
                worksheet.Cells["C1"].Value = "Status Lavorazione";
                worksheet.Cells["D1"].Value = "Status Pagamento";
                worksheet.Cells["E1"].Value = "Tipo Trasmissione";
                worksheet.Cells["F1"].Value = "Tipo Multa";

                //righe 
                int idstatuslavorazione = 0;
                string keysearch = SeoHelper.EncodeString(txtKeySearch.Text);
                Guid UserId = SeoHelper.GuidString(hdusers.Value);
                int idtipotrasmissione = SeoHelper.IntString(ddlTipoTrasm.SelectedValue);
                int idstatuspagamento = SeoHelper.IntString(ddlStatusLav.SelectedValue);
                int idtitolarepagamento = SeoHelper.IntString(ddlTitolarePag.SelectedValue);
                if (!string.IsNullOrEmpty(ddlStatusPag.SelectedValue) && ddlStatusPag.SelectedValue != "-1")
                {
                    idstatuspagamento = SeoHelper.IntString(ddlStatusPag.SelectedValue);
                }
                else
                {
                    ddlStatusPag.SelectedValue = "0";
                    idstatuspagamento = 0;
                }
                DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
                DateTime dataal = SeoHelper.DataString(txtDataal.Text);
                string codtipomulta = SeoHelper.EncodeString(ddlCodTipoMulta.Text);
                string ordine = SeoHelper.EncodeString(ddlOrdina.SelectedValue);
                string tipoordine = SeoHelper.EncodeString(ddlTipoOrdina.SelectedValue);
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();

                List<IMulte> dataExport = servizioMulte.SelectMulteDaPagare(keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, idtitolarepagamento, Uidtenant, ordine, tipoordine, 10000, 1);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (IMulte resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Numeroverbale;
                        worksheet.Cells["B" + countRow].Value = resultExport.Datainfrazione;
                        worksheet.Cells["C" + countRow].Value = resultExport.Statuslavorazione;
                        worksheet.Cells["D" + countRow].Value = resultExport.Statuspagamento;
                        worksheet.Cells["E" + countRow].Value = resultExport.Tipotrasmissione;
                        worksheet.Cells["F" + countRow].Value = resultExport.Tipomulta;

                        countRow++;
                    }
                }

                Response.Clear();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + namesheet + ".xls");
                Response.BinaryWrite(package.GetAsByteArray());
                Response.End();
            }
        }

        /********************** FINE ESPORTA EXCEL **********************/


        public string TextTipoMulta(string tipomulta)
        {
            string retVal;

            if (tipomulta.Length > 20)
            {
                retVal = tipomulta.Substring(0, 20) + "...";
            }
            else
            {
                retVal = tipomulta;
            }

            return retVal;
        }

        public string ReturnImportodaPagare(string giornitrascorsi, string importo, string importoridotto, string importoscontato)
        {
            string retVal = "";

            int giorni = SeoHelper.IntString(giornitrascorsi);

            if (giorni > 0 && giorni <= 5)
            {
                retVal = importoscontato.ToString();
            }
            if (giorni >= 6 && giorni <= 60)
            {
                retVal = importoridotto.ToString();
            }
            if (giorni > 60)
            {
                retVal = importo.ToString();
            }

            return retVal;
        }

    }
}
