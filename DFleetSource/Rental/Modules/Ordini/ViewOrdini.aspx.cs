// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewOrdini.aspx.cs" company="">
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
    public partial class ViewOrdini : System.Web.UI.Page
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
            
            int totaleRighe = servizioContratti.SelectCountRichiesteOrdiniRental(idstatusordine, search, UserId, codfornitore, codsocieta, datadal, dataal);
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
            if (Session["searchordini"] != null)
            {
                txtSearch.Text = Session["searchordini"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["idstatusordineordini"] != null)
            {
                ddlStatusOrdini.SelectedValue = Session["idstatusordineordini"].ToString();
                hdstatusordini.Value = Session["idstatusordineordini"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["UserIdordini"] != null)
            {
                ddlUsers.SelectedValue = Session["UserIdordini"].ToString();
                hdusers.Value = Session["UserIdordini"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["codsocietaordini"] != null)
            {
                ddlCodSocieta.SelectedValue = Session["codsocietaordini"].ToString();
                hdcodsocieta.Value = Session["codsocietaordini"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["datadalordini"] != null)
            {
                txtDatadal.Text = Session["datadalordini"].ToString().Replace("00:00:00", "");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["dataalordini"] != null)
            {
                txtDataal.Text = Session["dataalordini"].ToString().Replace("00:00:00", "");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["totaleRecordordini"] != null)
            {
                ddlNRecord.SelectedValue = Session["totaleRecordordini"].ToString();
            }
        }
        public void InsertSession(int idstatusordine, string search, Guid UserId, string codsocieta, DateTime datadal, DateTime dataal, int totaleRecord)
        {
            if (!string.IsNullOrEmpty(search))
            {
                Session["searchordini"] = search;
            }
            if (idstatusordine > 0)
            {
                Session["idstatusordineordini"] = idstatusordine.ToString();
            }
            if (UserId != Guid.Empty)
            {
                Session["UserIdordini"] = UserId.ToString();
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                Session["codsocietaordini"] = codsocieta;
            }
            if (datadal > DateTime.MinValue)
            {
                Session["datadalordini"] = datadal.ToString();
            }
            if (dataal > DateTime.MinValue)
            {
                Session["dataalordini"] = dataal.ToString();
            }
            if (totaleRecord > 0)
            {
                Session["totaleRecordordini"] = totaleRecord.ToString();
            }
        }

        protected void btnSvuotaFiltri_Click(object sender, EventArgs e)
        {
            Session["searchordini"] = "";        
            Session["idstatusordineordini"] = "";
            Session["UserIdordini"] = "";
            Session["codsocietaordini"] = "";
            Session["datadalrdini"] = "";
            Session["dataalordini"] = "";
            Session["totaleRecordordini"] = "";
            //Session.Clear();
            Response.Redirect("ViewOrdini");
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
            int totaleRighe = servizioContratti.SelectCountRichiesteOrdiniRental(idstatusordine, search, UserId, codfornitore, codsocieta, datadal, dataal);
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
            int totaleRighe = servizioContratti.SelectCountRichiesteOrdiniRental(idstatusordine, search, UserId, codfornitore, codsocieta, datadal, dataal);
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
                string namesheet = "ReportOrdini-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

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
                worksheet.Cells["J1"].Value = "Optional Canone";
                worksheet.Cells["K1"].Value = "Colore";
                worksheet.Cells["L1"].Value = "Optional Aggiuntivi";
                worksheet.Cells["M1"].Value = "Stato";

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

                List<IContratti> dataExport = servizioContratti.SelectRichiesteOrdiniRental(idstatusordine, search, UserId, codfornitore, codsocieta, datadal, dataal, 10000, 1);

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
                        worksheet.Cells["J" + countRow].Value = resultExport.Deltacanone;
                        worksheet.Cells["K" + countRow].Value = resultExport.Codcolore;
                        worksheet.Cells["L" + countRow].Value = RecuperaOptional(resultExport.Idordine);
                        worksheet.Cells["M" + countRow].Value = resultExport.Statusordine;

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
            string retVal;

            retVal = "<a href='ViewConf-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Visualizza configurazione'><img src='../../../plugins/images/visualizza_ordine.svg' class='icon20' border='0' alt='' /></a>";
            
            switch (idstatusordine.ToUpper())
            {
                case "10": //Pending presa in carico Rental

                    break;
                case "20": //In attesa di offerta da Rental
                    retVal += "<a href='EditOrdine-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Carica Offerta'><img src='../../../plugins/images/elabora_offerta.svg' class='icon20' border='0' alt='' /></a>";
                    break;
                case "25":
                   
                    break;
                case "30":
                    
                    break;
                case "40":
                   
                    break;
                case "50": //In attesa di evasione Rental
                    retVal += "<a href='EditEvadi-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Evadi'><img src='../../../plugins/images/firma_e_conferma.svg' class='icon20' border='0' alt='' /></a>";
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
                        elencocolori += resultOpt.Optional;
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
