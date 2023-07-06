// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewFuelCardConsumi.aspx.cs" company="">
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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using DFleet.Classes;
using System.IO;
using System.Drawing;

namespace DFleet.Admin.Modules.EPartner
{
    public partial class ViewFuelCardConsumi : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(84)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ApriSession();
            }
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
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            pnlMessage.Visible = false;

            if (Page.IsPostBack)
            {
                hdusers.Value = ddlUsers.SelectedValue;
                hdnumerofuel.Value = ddlFuelCard.SelectedValue;
            }

            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string search = SeoHelper.EncodeString(txtSearch.Text);
            string numerofuelcard = SeoHelper.EncodeString(hdnumerofuel.Value);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            InsertSession(search, UserId, numerofuelcard, datadal, dataal, totaleRecord);
            int totaleRighe = servizioFileTracciati.SelectCountConsumiFuelCard(UserId, datadal, dataal, search, numerofuelcard, Uidtenant);
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

        public void ApriSession()
        {
            if (Session["searchconsumi"] != null)
            {
                txtSearch.Text = Session["searchconsumi"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["UserIdconsumi"] != null)
            {
                ddlUsers.SelectedValue = Session["UserIdconsumi"].ToString();
                hdusers.Value = Session["UserIdconsumi"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["fuelconsumi"] != null)
            {
                ddlFuelCard.Text = Session["fuelconsumi"].ToString();
                hdnumerofuel.Value = Session["fuelconsumi"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["datadalconsumi"] != null)
            {
                txtDatadal.Text = Session["datadalconsumi"].ToString().Replace("00:00:00", "");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["dataalconsumi"] != null)
            {
                txtDataal.Text = Session["dataalconsumi"].ToString().Replace("00:00:00", "");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["totaleRecordconsumi"] != null)
            {
                ddlNRecord.SelectedValue = Session["totaleRecordconsumi"].ToString();
            }
        }
        public void InsertSession(string search, Guid UserId, string numerofuelcard, DateTime datadal, DateTime dataal, int totaleRecord)
        {
            if (!string.IsNullOrEmpty(search))
            {
                Session["searchconsumi"] = search;
            }
            if (UserId != Guid.Empty)
            {
                Session["UserIdconsumi"] = UserId.ToString();
            }
            if (!string.IsNullOrEmpty(numerofuelcard))
            {
                Session["fuelconsumi"] = numerofuelcard;
            }
            if (datadal > DateTime.MinValue)
            {
                Session["datadalconsumi"] = datadal.ToString();
            }
            if (dataal > DateTime.MinValue)
            {
                Session["dataalconsumi"] = dataal.ToString();
            }
            if (totaleRecord > 0)
            {
                Session["totaleRecordconsumi"] = totaleRecord.ToString();
            }
        }

        protected void btnSvuotaFiltri_Click(object sender, EventArgs e)
        {
            Session["searchconsumi"] = "";
            Session["UserIdconsumi"] = "";
            Session["fuelconsumi"] = "";
            Session["datadalconsumi"] = "";
            Session["dataalconsumi"] = "";
            Session["totaleRecordconsumi"] = "";
            //Session.Clear();
            Response.Redirect("ViewFuelCardConsumi");
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

            if (Page.IsPostBack)
            {
                hdusers.Value = ddlUsers.SelectedValue;
                hdnumerofuel.Value = ddlFuelCard.SelectedValue;
            }

            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string search = SeoHelper.EncodeString(txtSearch.Text);
            string numerofuelcard = SeoHelper.EncodeString(hdnumerofuel.Value);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioFileTracciati.SelectCountConsumiFuelCard(UserId, datadal, dataal, search, numerofuelcard, Uidtenant);
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            InsertSession(search, UserId, numerofuelcard, datadal, dataal, totaleRecord);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;

            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

            if (Page.IsPostBack)
            {
                hdusers.Value = ddlUsers.SelectedValue;
                hdnumerofuel.Value = ddlFuelCard.SelectedValue;
            }

            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string search = SeoHelper.EncodeString(txtSearch.Text);
            string numerofuelcard = SeoHelper.EncodeString(hdnumerofuel.Value);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioFileTracciati.SelectCountConsumiFuelCard(UserId, datadal, dataal, search, numerofuelcard, Uidtenant);
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            InsertSession(search, UserId, numerofuelcard, datadal, dataal, totaleRecord);
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
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excel = new ExcelPackage())
            {
                string namesheet = "ReportConsumiFuelCard-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

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
                worksheet.Cells["A1"].Value = "Driver";
                worksheet.Cells["B1"].Value = "Targa";
                worksheet.Cells["C1"].Value = "Data Rifornimento";
                worksheet.Cells["D1"].Value = "Tipo Rifornimento";
                worksheet.Cells["E1"].Value = "Quantita";
                worksheet.Cells["F1"].Value = "Prezzo";
                worksheet.Cells["G1"].Value = "Importo";
                worksheet.Cells["H1"].Value = "FuelCard";
                worksheet.Cells["I1"].Value = "Compagnia";
                worksheet.Cells["J1"].Value = "Stazione";

                //righe 

                if (Page.IsPostBack)
                {
                    hdusers.Value = ddlUsers.SelectedValue;
                    hdnumerofuel.Value = ddlFuelCard.SelectedValue;
                }

                Guid UserId = SeoHelper.GuidString(hdusers.Value);
                DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
                DateTime dataal = SeoHelper.DataString(txtDataal.Text);
                string search = SeoHelper.EncodeString(txtSearch.Text);
                string numerofuelcard = SeoHelper.EncodeString(hdnumerofuel.Value);
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();

                List<IFileTracciati> dataExport = servizioFileTracciati.SelectConsumiFuelCard(UserId, datadal, dataal, search, numerofuelcard, Uidtenant, 10000, 1);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (IFileTracciati resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Denominazione;
                        worksheet.Cells["B" + countRow].Value = resultExport.Targa;
                        worksheet.Cells["C" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["C" + countRow].Value = resultExport.Datatransazione;
                        worksheet.Cells["D" + countRow].Value = resultExport.Tiporifornimento;
                        worksheet.Cells["E" + countRow].Value = resultExport.Quantita;
                        worksheet.Cells["F" + countRow].Value = resultExport.Prezzo;
                        worksheet.Cells["G" + countRow].Value = resultExport.Importo;
                        worksheet.Cells["H" + countRow].Value = resultExport.Numerofuelcard;
                        worksheet.Cells["I" + countRow].Value = resultExport.Compagnia;
                        worksheet.Cells["J" + countRow].Value = resultExport.Ragionesociale + " - " + resultExport.Indirizzo + " - " + resultExport.Localita;

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
