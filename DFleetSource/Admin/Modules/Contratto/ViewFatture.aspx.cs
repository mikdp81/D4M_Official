﻿// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewFatture.aspx.cs" company="">
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
    public partial class ViewFatture : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(21)) //controllo se la pagina è autorizzata per l'utente 
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
            string keysearch = SeoHelper.EncodeString(txtSearch.Text);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idstatusfattura = SeoHelper.IntString(ddlStatusFattura.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountFatture(keysearch, codfornitore, codsocieta, datadal, dataal, idstatusfattura, Uidtenant);
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


            if (gvRicFatture.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicFatture.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            lblNumRecord.Text = "Fatture: " + HttpUtility.HtmlEncode(totaleRighe);
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
            Response.Redirect("ViewFatture");
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
            string keysearch = SeoHelper.EncodeString(txtSearch.Text);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idstatusfattura = SeoHelper.IntString(ddlStatusFattura.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRighe = servizioContratti.SelectCountFatture(keysearch, codfornitore, codsocieta, datadal, dataal, idstatusfattura, Uidtenant);
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
            string keysearch = SeoHelper.EncodeString(txtSearch.Text);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idstatusfattura = SeoHelper.IntString(ddlStatusFattura.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRighe = servizioContratti.SelectCountFatture(keysearch, codfornitore, codsocieta, datadal, dataal, idstatusfattura, Uidtenant);
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
                string namesheet = "ReportFatture-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

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
                worksheet.Cells["B1"].Value = "Committente";
                worksheet.Cells["C1"].Value = "Numero documento";
                worksheet.Cells["D1"].Value = "Data documento";
                worksheet.Cells["E1"].Value = "Importo totale";
                worksheet.Cells["F1"].Value = "Data scadenza pagamento";

                //righe 
                string keysearch = SeoHelper.EncodeString(txtSearch.Text);
                string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
                string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
                DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
                DateTime dataal = SeoHelper.DataString(txtDataal.Text);
                string ordine = SeoHelper.EncodeString(ddlOrdina.SelectedValue);
                string tipoordine = SeoHelper.EncodeString(ddlTipoOrdina.SelectedValue);
                int idstatusfattura = SeoHelper.IntString(ddlStatusFattura.SelectedValue);
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();

                List<IContratti> dataExport = servizioContratti.SelectFatture(keysearch, codfornitore, codsocieta, datadal, dataal, idstatusfattura, Uidtenant, ordine, tipoordine, 10000, 1);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (IContratti resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Fornitore;
                        worksheet.Cells["B" + countRow].Value = resultExport.Committente;
                        worksheet.Cells["C" + countRow].Value = resultExport.Numerodocumento;
                        worksheet.Cells["D" + countRow].Value = resultExport.Datadocumento;
                        worksheet.Cells["E" + countRow].Value = resultExport.Importototale;
                        worksheet.Cells["F" + countRow].Value = resultExport.Datascadenzapagamento;

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


        public string ReturnData(string data)
        {
            string retVal = string.Empty;

            if (string.IsNullOrEmpty(data) || data == "01/01/0001 00:00:00")
            {
                retVal = "";
            }
            else
            {
                retVal += data.Replace("00:00:00", "");
            }

            return retVal;
        }

    }
}
