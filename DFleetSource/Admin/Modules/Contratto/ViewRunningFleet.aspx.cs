// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewRunningFleet.aspx.cs" company="">
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
    public partial class ViewRunningFleet : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(6)) //controllo se la pagina è autorizzata per l'utente 
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
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string marca = SeoHelper.EncodeString(txtMarca.Text);
            string modello = SeoHelper.EncodeString(txtModello.Text);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
            string numerocontratto = SeoHelper.EncodeString(txtNumerocontratto.Text);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idstatuscontratto = SeoHelper.IntString(ddlstatus.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountRunningFleet(targa, codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datadal, dataal, idstatuscontratto, Uidtenant);
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


            if (gvRicContratti.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicContratti.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            lblNumRecord.Text = "Contratti Running Fleet: " + HttpUtility.HtmlEncode(totaleRighe);
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
            Response.Redirect("ViewRunningFleet");
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
            IContrattiBL servizioContratti = new ContrattiBL();
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string marca = SeoHelper.EncodeString(txtMarca.Text);
            string modello = SeoHelper.EncodeString(txtModello.Text);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
            string numerocontratto = SeoHelper.EncodeString(txtNumerocontratto.Text);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idstatuscontratto = SeoHelper.IntString(ddlstatus.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioContratti.SelectCountRunningFleet(targa, codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datadal, dataal, idstatuscontratto, Uidtenant);
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;
            
            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string marca = SeoHelper.EncodeString(txtMarca.Text);
            string modello = SeoHelper.EncodeString(txtModello.Text);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
            string numerocontratto = SeoHelper.EncodeString(txtNumerocontratto.Text);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idstatuscontratto = SeoHelper.IntString(ddlstatus.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioContratti.SelectCountRunningFleet(targa, codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datadal, dataal, idstatuscontratto, Uidtenant);
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
            IContrattiBL servizioContratti = new ContrattiBL();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excel = new ExcelPackage())
            {
                string namesheet = "ReportRunningFleet-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

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
                worksheet.Cells["A1"].Value = "Fornitore";
                worksheet.Cells["B1"].Value = "Numero contratto";
                worksheet.Cells["C1"].Value = "Data contratto";
                worksheet.Cells["D1"].Value = "Targa";
                worksheet.Cells["E1"].Value = "CarPolicy";
                worksheet.Cells["F1"].Value = "Modello";
                worksheet.Cells["G1"].Value = "Societa";
                worksheet.Cells["H1"].Value = "Nome";
                worksheet.Cells["I1"].Value = "Cognome";
                worksheet.Cells["J1"].Value = "Matricola";
                worksheet.Cells["K1"].Value = "Grade";
                worksheet.Cells["L1"].Value = "Optional canone";
                worksheet.Cells["M1"].Value = "Fringe";
                worksheet.Cells["N1"].Value = "Km percorsi";
                worksheet.Cells["O1"].Value = "Km contratto";
                worksheet.Cells["P1"].Value = "Inizio contratto";
                worksheet.Cells["Q1"].Value = "Inizio uso";
                worksheet.Cells["R1"].Value = "Inizio assegnazione";
                worksheet.Cells["S1"].Value = "Data scadenza";
                worksheet.Cells["T1"].Value = "Condizione auto";
                worksheet.Cells["U1"].Value = "Stato";

                //righe 
                string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
                string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
                Guid UserId = SeoHelper.GuidString(hdusers.Value);
                string marca = SeoHelper.EncodeString(txtMarca.Text);
                string modello = SeoHelper.EncodeString(txtModello.Text);
                string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
                string numerocontratto = SeoHelper.EncodeString(txtNumerocontratto.Text);
                DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
                DateTime dataal = SeoHelper.DataString(txtDataal.Text);
                int idstatuscontratto = SeoHelper.IntString(ddlstatus.SelectedValue);
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();
                string ordine = SeoHelper.EncodeString(ddlOrdina.SelectedValue);
                string tipoordine = SeoHelper.EncodeString(ddlTipoOrdina.SelectedValue);

                List<IContratti> dataExport = servizioContratti.SelectRunningFleet(targa, codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datadal, dataal, idstatuscontratto, Uidtenant, ordine, tipoordine, 10000, 1);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (IContratti resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Codfornitore;
                        worksheet.Cells["B" + countRow].Value = resultExport.Numerocontratto;
                        worksheet.Cells["C" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["C" + countRow].Value = resultExport.Datacontratto;
                        worksheet.Cells["D" + countRow].Value = resultExport.Targa;
                        worksheet.Cells["E" + countRow].Value = resultExport.Codcarpolicy;
                        worksheet.Cells["F" + countRow].Value = resultExport.Modello;
                        worksheet.Cells["G" + countRow].Value = resultExport.Societa;
                        worksheet.Cells["H" + countRow].Value = resultExport.Cognome;
                        worksheet.Cells["I" + countRow].Value = resultExport.Nome;
                        worksheet.Cells["J" + countRow].Value = resultExport.Matricola;
                        worksheet.Cells["K" + countRow].Value = resultExport.Grade;
                        worksheet.Cells["L" + countRow].Value = resultExport.Deltacanone;
                        worksheet.Cells["M" + countRow].Value = resultExport.Fringebenefit;
                        worksheet.Cells["N" + countRow].Value = resultExport.Kmpercorsi.ToString("F2");
                        worksheet.Cells["O" + countRow].Value = resultExport.Kmcontratto.ToString("F2");
                        worksheet.Cells["P" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["P" + countRow].Value = resultExport.Datainiziocontratto;
                        worksheet.Cells["Q" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["Q" + countRow].Value = resultExport.Datainiziouso;
                        worksheet.Cells["R" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["R" + countRow].Value = resultExport.Assegnatodal;
                        worksheet.Cells["S" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["S" + countRow].Value = resultExport.Datafinecontratto;
                        worksheet.Cells["T" + countRow].Value = resultExport.Statoauto;
                        worksheet.Cells["U" + countRow].Value = resultExport.Statuscontratto;

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
    }
}
