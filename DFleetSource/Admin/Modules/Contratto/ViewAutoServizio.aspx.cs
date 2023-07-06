﻿// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewAutoServizio.aspx.cs" company="">
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
    public partial class ViewAutoServizio : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(93)) //controllo se la pagina è autorizzata per l'utente 
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
        protected void btnSvuotaFiltri_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAutoServizio");
        }
        public void loadPage()
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;
            string targasearch = SeoHelper.EncodeString(Request.QueryString["targa"] + "");
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountAutoServizio(targa, targasearch, UserId, datadal, dataal, Uidtenant);
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


            lblNumRecord.Text = "Prenotazioni Auto Servizio: " + HttpUtility.HtmlEncode(totaleRighe);
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
            string targasearch = SeoHelper.EncodeString(Request.QueryString["targa"] + "");
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioContratti.SelectCountAutoServizio(targa, targasearch, UserId, datadal, dataal, Uidtenant);
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
            string targasearch = SeoHelper.EncodeString(Request.QueryString["targa"] + "");
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioContratti.SelectCountAutoServizio(targa, targasearch, UserId, datadal, dataal, Uidtenant);
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
                string namesheet = "ReportAssContratti-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

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
                worksheet.Cells["A1"].Value = "N. e Data Contratto";
                worksheet.Cells["B1"].Value = "Targa";
                worksheet.Cells["C1"].Value = "Driver";
                worksheet.Cells["D1"].Value = "Fornitore";
                worksheet.Cells["E1"].Value = "Assegnato Dal/Al";
                worksheet.Cells["F1"].Value = "Stato";

                //righe 
                string targasearch = SeoHelper.EncodeString(Request.QueryString["targa"] + "");
                string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
                Guid UserId = SeoHelper.GuidString(hdusers.Value);
                DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
                DateTime dataal = SeoHelper.DataString(txtDataal.Text);
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();
                string ordine = SeoHelper.EncodeString(ddlOrdina.SelectedValue);
                string tipoordine = SeoHelper.EncodeString(ddlTipoOrdina.SelectedValue);

                List<IContratti> dataExport = servizioContratti.SelectAutoServizio(targa, targasearch, UserId, datadal, dataal, Uidtenant, ordine, tipoordine, 100000, 1);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (IContratti resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Numerocontratto + " del " + resultExport.Datacontratto.ToString("dd/MM/yyyy");
                        worksheet.Cells["B" + countRow].Value = resultExport.Targa;
                        worksheet.Cells["C" + countRow].Value = resultExport.Cognome + " " + resultExport.Nome;
                        worksheet.Cells["D" + countRow].Value = resultExport.Fornitore;
                        worksheet.Cells["E" + countRow].Value = resultExport.Assegnatodal.ToString("dd/MM/yyyy") + " al " + resultExport.Assegnatoal.ToString("dd/MM/yyyy");
                        worksheet.Cells["F" + countRow].Value = resultExport.Statusassegnazione;

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


        public string ReturnAutorizzato(string autorizzato)
        {
            if (autorizzato == "1")
            {
                return "AUTORIZZATO";
            }
            else
            {
                return "DA AUTORIZZARE";
            }
        }
        public bool ReturnVisible(string autorizzato)
        {
            if (autorizzato == "1")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            if (e.CommandName == "Autorizza")
            {
                int idassegnazione = SeoHelper.IntString(e.CommandArgument.ToString());
                string targa = "";
                DateTime datadal = DateTime.MinValue;
                DateTime dataal = DateTime.MinValue;

                //recupero date e targa
                IContratti data = servizioContratti.DetailAutoServizioId(idassegnazione);
                if (data != null)
                {
                    targa = data.Targa;
                    datadal = data.Assegnatodal;
                    dataal = data.Assegnatoal;
                }

                if (servizioContratti.ExistPrenotazioneAutoServizio(datadal, dataal, targa))
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text = "Attenzione. La data inserita &egrave; gi&agrave; stata autorizzata. ";
                }
                else
                { 
                    if (servizioContratti.UpdateAutorizzaAutoServizio(idassegnazione, SeoHelper.ReturnSessionTenant()) == 1)
                    {
                        Response.Redirect("ViewAutoServizio");
                    }
                }
            }
        }

    }
}
