// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewOrdiniEvasi.aspx.cs" company="">
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

namespace DFleet.Rental.Modules.Ordini
{
    public partial class ViewOrdiniEvasi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            hdcodfornitore.Value = datiUtente.Codfornitore; 
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
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;
            string search = SeoHelper.EncodeString(txtSearch.Text);
            if (Page.IsPostBack)
            {
                hdusers.Value = ddlUsers.SelectedValue;
                hdstatusordini.Value = ddlStatusOrdini.SelectedValue;
                hdcodsocieta.Value = ddlCodSocieta.SelectedValue;
            }

            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            int idstatusordine = SeoHelper.IntString(hdstatusordini.Value);
            string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string codfornitore = hdcodfornitore.Value;
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            InsertSession(idstatusordine, search, UserId, codsocieta, datadal, dataal, totaleRecord);
            int totaleRighe = servizioContratti.SelectCountRichiesteOrdiniRentalEvasi(idstatusordine, search, UserId, codfornitore, codsocieta, datadal, dataal);
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


            if (gvRicOrdini.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicOrdini.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            if (totaleRighe == 0)
            {
                lblMessage.Text = "Nessun dato disponibile. Ricerca con altri parametri.";
                pnlMessage.Visible = true;
            }
            else
            {
                pnlMessage.Visible = false;
            }


            lblNumRecord.Text = "Ordini: " + HttpUtility.HtmlEncode(totaleRighe);
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
            if (Session["searchordiniev"] != null)
            {
                txtSearch.Text = Session["searchordiniev"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["idstatusordineordiniev"] != null)
            {
                ddlStatusOrdini.SelectedValue = Session["idstatusordineordiniev"].ToString();
                hdstatusordini.Value = Session["idstatusordineordiniev"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["UserIdordiniev"] != null)
            {
                ddlUsers.SelectedValue = Session["UserIdordinevi"].ToString();
                hdusers.Value = Session["UserIdordiniev"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["codsocietaordiniev"] != null)
            {
                ddlCodSocieta.SelectedValue = Session["codsocietaordiniev"].ToString();
                hdcodsocieta.Value = Session["codsocietaordiniev"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["datadalordiniev"] != null)
            {
                txtDatadal.Text = Session["datadalordiniev"].ToString().Replace("00:00:00", "");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["dataalordiniev"] != null)
            {
                txtDataal.Text = Session["dataalordiniev"].ToString().Replace("00:00:00", "");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["totaleRecordordiniev"] != null)
            {
                ddlNRecord.SelectedValue = Session["totaleRecordordiniev"].ToString();
            }
        }
        public void InsertSession(int idstatusordine, string search, Guid UserId, string codsocieta, DateTime datadal, DateTime dataal, int totaleRecord)
        {
            if (!string.IsNullOrEmpty(search))
            {
                Session["searchordiniev"] = search;
            }
            if (idstatusordine > 0)
            {
                Session["idstatusordineordiniev"] = idstatusordine.ToString();
            }
            if (UserId != Guid.Empty)
            {
                Session["UserIdordiniev"] = UserId.ToString();
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                Session["codsocietaordiniev"] = codsocieta;
            }
            if (datadal > DateTime.MinValue)
            {
                Session["datadalordiniev"] = datadal.ToString();
            }
            if (dataal > DateTime.MinValue)
            {
                Session["dataalordiniev"] = dataal.ToString();
            }
            if (totaleRecord > 0)
            {
                Session["totaleRecordordiniev"] = totaleRecord.ToString();
            }
        }

        protected void btnSvuotaFiltri_Click(object sender, EventArgs e)
        {
            Session["searchordiniev"] = "";
            Session["idstatusordineordiniev"] = "";
            Session["UserIdordiniev"] = "";
            Session["codsocietaordiniev"] = "";
            Session["datadalrdiniev"] = "";
            Session["dataalordiniev"] = "";
            Session["totaleRecordordiniev"] = "";
            //Session.Clear();
            Response.Redirect("ViewOrdiniEvasi");
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
            string search = SeoHelper.EncodeString(txtSearch.Text);
            if (Page.IsPostBack)
            {
                hdusers.Value = ddlUsers.SelectedValue;
                hdstatusordini.Value = ddlStatusOrdini.SelectedValue;
                hdcodsocieta.Value = ddlCodSocieta.SelectedValue;
            }

            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            int idstatusordine = SeoHelper.IntString(hdstatusordini.Value);
            string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string codfornitore = hdcodfornitore.Value;
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            InsertSession(idstatusordine, search, UserId, codsocieta, datadal, dataal, totaleRecord);
            int totaleRighe = servizioContratti.SelectCountRichiesteOrdiniRentalEvasi(idstatusordine, search, UserId, codfornitore, codsocieta, datadal, dataal);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;

            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string search = SeoHelper.EncodeString(txtSearch.Text);
            if (Page.IsPostBack)
            {
                hdusers.Value = ddlUsers.SelectedValue;
                hdstatusordini.Value = ddlStatusOrdini.SelectedValue;
                hdcodsocieta.Value = ddlCodSocieta.SelectedValue;
            }

            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            int idstatusordine = SeoHelper.IntString(hdstatusordini.Value);
            string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            string codfornitore = hdcodfornitore.Value;
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            InsertSession(idstatusordine, search, UserId, codsocieta, datadal, dataal, totaleRecord);
            int totaleRighe = servizioContratti.SelectCountRichiesteOrdiniRentalEvasi(idstatusordine, search, UserId, codfornitore, codsocieta, datadal, dataal);
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
                string namesheet = "ReportOrdiniEvasi-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

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
                worksheet.Cells["A1"].Value = "Società";
                worksheet.Cells["B1"].Value = "Driver";
                worksheet.Cells["C1"].Value = "Telefono";
                worksheet.Cells["D1"].Value = "Email";
                worksheet.Cells["E1"].Value = "Sede lavoro";
                worksheet.Cells["F1"].Value = "Marca";
                worksheet.Cells["G1"].Value = "Modello";
                worksheet.Cells["H1"].Value = "Numero ordine";
                worksheet.Cells["I1"].Value = "Data ordine";
                worksheet.Cells["J1"].Value = "Colore";
                worksheet.Cells["K1"].Value = "Optional";
                worksheet.Cells["L1"].Value = "Stato";

                //righe 
                string search = SeoHelper.EncodeString(txtSearch.Text);
                if (Page.IsPostBack)
                {
                    hdusers.Value = ddlUsers.SelectedValue;
                    hdstatusordini.Value = ddlStatusOrdini.SelectedValue;
                    hdcodsocieta.Value = ddlCodSocieta.SelectedValue;
                }

                Guid UserId = SeoHelper.GuidString(hdusers.Value);
                int idstatusordine = SeoHelper.IntString(hdstatusordini.Value);
                string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
                DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
                DateTime dataal = SeoHelper.DataString(txtDataal.Text);
                string codfornitore = hdcodfornitore.Value;

                List<IContratti> dataExport = servizioContratti.SelectRichiesteOrdiniRentalEvasi(idstatusordine, search, UserId, codfornitore, codsocieta, datadal, dataal, 10000, 1);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (IContratti resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Societa;
                        worksheet.Cells["B" + countRow].Value = resultExport.Denominazione;
                        worksheet.Cells["C" + countRow].Value = resultExport.Cellulare;
                        worksheet.Cells["D" + countRow].Value = resultExport.Email;
                        worksheet.Cells["E" + countRow].Value = resultExport.Sedelavoro;
                        worksheet.Cells["F" + countRow].Value = resultExport.Marca;
                        worksheet.Cells["G" + countRow].Value = resultExport.Modello;
                        worksheet.Cells["H" + countRow].Value = resultExport.Numeroordine;
                        worksheet.Cells["I" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["I" + countRow].Value = resultExport.Dataordine;
                        worksheet.Cells["J" + countRow].Value = resultExport.Codcolore;
                        worksheet.Cells["K" + countRow].Value = RecuperaOptional(resultExport.Idordine);
                        worksheet.Cells["L" + countRow].Value = resultExport.Statusordine;

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


        public string ReturnAzioni(string Uid, string idstatusordine)
        {
            string retVal = string.Empty;

            switch (idstatusordine.ToUpper())
            {
                case "55": //Evaso Rental
                    retVal = "<a href='ViewConf-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Visualizza configurazione'><img src='../../../plugins/images/visualizza_ordine.svg' class='icon20' border='0' alt='' /></a>" +
                             "<a href='ReWork-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Rework'><img src='../../../plugins/images/elabora_offerta.svg' class='icon20' border='0' alt='' /></a";
                    break;
                case "60": //Offerta contrattualizzata
                    retVal = "<a href='ViewConf-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Visualizza configurazione'><img src='../../../plugins/images/visualizza_ordine.svg' class='icon20' border='0' alt='' /></a>" +
                             "<a href='EditConsegna-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' title='' data-original-title='Consegna Auto'><img src='../../../plugins/images/consegna_auto.svg' class='icon20'/></a>";
                    break;
                case "100": //Scartato Driver
                    retVal = "<a href='ViewConf-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Visualizza configurazione'><img src='../../../plugins/images/visualizza_ordine.svg' class='icon20' border='0' alt='' /></a>";
                    break;
                case "110": //Non Autorizzato
                    retVal = "<a href='ViewConf-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Visualizza configurazione'><img src='../../../plugins/images/visualizza_ordine.svg' class='icon20' border='0' alt='' /></a>";
                    break;
            }

            return retVal;
        }
        public string RecuperaColori(string codjatoauto, int idordine)
        {
            string retVal;
            ICarsBL servizioCar = new CarsBL();
            string elencocolori = "";
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int count = 0;

            List<ICars> dataOpt = servizioCar.SelectAllColori(codjatoauto, Uidtenant);
            if (dataOpt != null && dataOpt.Count > 0)
            {
                foreach (ICars resultOpt in dataOpt)
                {
                    if (servizioCar.ExistOrdineOptionalAuto(idordine, resultOpt.Codoptional))
                    {
                        elencocolori += resultOpt.Optional + "\n";
                        count++;
                    }
                }
            }

            if (count > 0)
            {
                retVal = elencocolori;
            }
            else
            {
                retVal = "Nessun colore inserito";
            }

            return retVal;
        }

        public string RecuperaOptional(int idordine)
        {
            string retVal;
            IContrattiBL servizioContratti = new ContrattiBL();
            string elencooptional = "";
            int countoptional = 0;

            //elenco optional
            List<IContratti> dataOpt = servizioContratti.SelectOptionalAutoXOrdine(idordine);
            if (dataOpt != null && dataOpt.Count > 0)
            {
                foreach (IContratti resultOpt in dataOpt)
                {
                    elencooptional += resultOpt.Codoptional + " - € " + resultOpt.Importooptional + " | ";
                    countoptional++;
                }
            }

            if (countoptional > 0)
            {
                retVal = elencooptional;
            }
            else
            {
                retVal = "Nessun optional aggiuntivo";
            }

            return retVal;
        }
    }
}
