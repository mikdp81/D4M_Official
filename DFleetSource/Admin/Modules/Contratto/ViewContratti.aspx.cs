// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewContratti.aspx.cs" company="">
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
    public partial class ViewContratti : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(44)) //controllo se la pagina è autorizzata per l'utente 
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
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;

            if (Page.IsPostBack)
            {
                hdusers.Value = hduiduser.Value;
                hdcodfornitore.Value = ddlFornitore.SelectedValue;
                hdcodsocieta.Value = ddlCodsocieta.SelectedValue;
                hdtarga.Value = txtTarga.Text;
                hdstatus.Value = ddlstatus.SelectedValue;
            }

            string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string targa = SeoHelper.EncodeString(hdtarga.Value);
            string codfornitore = SeoHelper.EncodeString(hdcodfornitore.Value);
            string marca = SeoHelper.EncodeString(txtMarca.Text);
            string numerocontratto = SeoHelper.EncodeString(txtNumerocontratto.Text);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idstatuscontratto = SeoHelper.IntString(ddlstatus.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            string ordine = SeoHelper.EncodeString(ddlOrdina.SelectedValue);
            string tipoordine = SeoHelper.EncodeString(ddlTipoOrdina.SelectedValue);
            InsertSession(codsocieta, UserId, marca, targa, codfornitore, numerocontratto, datadal, dataal, idstatuscontratto, totaleRecord, ordine, tipoordine);
            int totaleRighe = servizioContratti.SelectCountContratti(codsocieta, UserId, marca, targa, codfornitore, numerocontratto, datadal, dataal, idstatuscontratto, Uidtenant);
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


            lblNumRecord.Text = "Contratti: " + HttpUtility.HtmlEncode(totaleRighe);
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
            if (Session["codsocietacontratti"] != null)
            {
                ddlCodsocieta.SelectedValue = Session["codsocietacontratti"].ToString();
                hdcodsocieta.Value = Session["codsocietacontratti"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["UserIdcontratti"] != null)
            {
                hduiduser.Value = Session["UserIdcontratti"].ToString();
                hdusers.Value = Session["UserIdcontratti"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["marcacontratti"] != null)
            {
                txtMarca.Text = Session["marcacontratti"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["targacontratti"] != null)
            {
                txtTarga.Text = Session["targacontratti"].ToString();
                hdtarga.Value = Session["targacontratti"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["fornitorecontratti"] != null)
            {
                ddlFornitore.SelectedValue = Session["fornitorecontratti"].ToString();
                hdcodfornitore.Value = Session["fornitorecontratti"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["numerocontratti"] != null)
            {
                txtNumerocontratto.Text = Session["numerocontratti"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }

            if (Session["datadalcontratti"] != null)
            {
                txtDatadal.Text = Session["datadalcontratti"].ToString().Replace("00:00:00", "");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["dataalcontratti"] != null)
            {
                txtDataal.Text = Session["dataalcontratti"].ToString().Replace("00:00:00", "");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["statuscontratti"] != null)
            {
                ddlstatus.SelectedValue = Session["statuscontratti"].ToString();
                hdstatus.Value = Session["statuscontratti"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["ordinacontratti"] != null)
            {
                ddlOrdina.SelectedValue = Session["ordinacontratti"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriOrdinamento()", true);
            }
            if (Session["tipoordinacontratti"] != null)
            {
                ddlTipoOrdina.SelectedValue = Session["tipoordinacontratti"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriOrdinamento()", true);
            }
            if (Session["totaleRecordcontratti"] != null)
            {
                ddlNRecord.SelectedValue = Session["totaleRecordcontratti"].ToString();
            }
        }
        public void InsertSession(string codsocieta, Guid userId, string marca, string targa, string codfornitore, string numerocontratto, DateTime datadal, DateTime dataal, int idstatuscontratto, int totaleRecord, string ordine, string tipoordine)
        {
            if (!string.IsNullOrEmpty(codsocieta))
            {
                Session["codsocietacontratti"] = codsocieta;
            }
            if (userId != Guid.Empty)
            {
                Session["UserIdcontratti"] = userId.ToString();
            }
            if (!string.IsNullOrEmpty(marca))
            {
                Session["marcacontratti"] = marca;
            }
            if (!string.IsNullOrEmpty(targa))
            {
                Session["targacontratti"] = targa;
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                Session["fornitorecontratti"] = codfornitore;
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                Session["numerocontratti"] = numerocontratto;
            }
            if (datadal > DateTime.MinValue)
            {
                Session["datadalcontratti"] = datadal.ToString();
            }
            if (dataal > DateTime.MinValue)
            {
                Session["dataalcontratti"] = dataal.ToString();
            }
            if (!string.IsNullOrEmpty(ordine))
            {
                Session["ordinacontratti"] = ordine;
            }
            if (idstatuscontratto > -1)
            {
                Session["statuscontratti"] = idstatuscontratto.ToString();
            }
            if (!string.IsNullOrEmpty(tipoordine))
            {
                Session["tipoordinacontratti"] = tipoordine;
            }
            if (totaleRecord > 0)
            {
                Session["totaleRecordcontratti"] = totaleRecord.ToString();
            }
        }

        protected void btnSvuotaFiltri_Click(object sender, EventArgs e)
        {
            Session["codsocietacontratti"] = "";        
            Session["UserIdcontratti"] = "";
            Session["marcacontratti"] = "";
            Session["targacontratti"] = "";
            Session["fornitorecontratti"] = "";
            Session["numerocontratti"] = "";
            Session["datadalcontratti"] = "";
            Session["dataalcontratti"] = "";
            Session["ordinacontratti"] = "";
            Session["statuscontratti"] = "-1";
            Session["tipoordinacontratti"] = "";
            Session["totaleRecordcontratti"] = "";
            //Session.Clear();
            Response.Redirect("ViewContratti");
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

            if (Page.IsPostBack)
            {
                hdusers.Value = hduiduser.Value;
                hdcodfornitore.Value = ddlFornitore.SelectedValue;
                hdcodsocieta.Value = ddlCodsocieta.SelectedValue;
                hdtarga.Value = txtTarga.Text;
                hdstatus.Value = ddlstatus.SelectedValue;
            }

            string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string targa = SeoHelper.EncodeString(hdtarga.Value);
            string codfornitore = SeoHelper.EncodeString(hdcodfornitore.Value);
            string marca = SeoHelper.EncodeString(txtMarca.Text);
            string numerocontratto = SeoHelper.EncodeString(txtNumerocontratto.Text);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idstatuscontratto = SeoHelper.IntString(ddlstatus.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            string ordine = SeoHelper.EncodeString(ddlOrdina.SelectedValue);
            string tipoordine = SeoHelper.EncodeString(ddlTipoOrdina.SelectedValue);
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            InsertSession(codsocieta, UserId, marca, targa, codfornitore, numerocontratto, datadal, dataal, idstatuscontratto, totaleRecord, ordine, tipoordine);
            int totaleRighe = servizioContratti.SelectCountContratti(codsocieta, UserId, marca, targa, codfornitore, numerocontratto, datadal, dataal, idstatuscontratto, Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;
            
            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            IContrattiBL servizioContratti = new ContrattiBL(); 
            if (Page.IsPostBack)
            {
                hdusers.Value = hduiduser.Value;
                hdcodfornitore.Value = ddlFornitore.SelectedValue;
                hdcodsocieta.Value = ddlCodsocieta.SelectedValue;
                hdtarga.Value = txtTarga.Text;
                hdstatus.Value = ddlstatus.SelectedValue;
            }

            string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string targa = SeoHelper.EncodeString(hdtarga.Value);
            string codfornitore = SeoHelper.EncodeString(hdcodfornitore.Value);
            string marca = SeoHelper.EncodeString(txtMarca.Text);
            string numerocontratto = SeoHelper.EncodeString(txtNumerocontratto.Text);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idstatuscontratto = SeoHelper.IntString(ddlstatus.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            string ordine = SeoHelper.EncodeString(ddlOrdina.SelectedValue);
            string tipoordine = SeoHelper.EncodeString(ddlTipoOrdina.SelectedValue);
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            InsertSession(codsocieta, UserId, marca, targa, codfornitore, numerocontratto, datadal, dataal, idstatuscontratto, totaleRecord, ordine, tipoordine);
            int totaleRighe = servizioContratti.SelectCountContratti(codsocieta, UserId, marca, targa, codfornitore, numerocontratto, datadal, dataal, idstatuscontratto, Uidtenant);
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
                string namesheet = "ReportContratti-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

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
                worksheet.Cells["C1"].Value = "Modello";
                worksheet.Cells["D1"].Value = "Fornitore";
                worksheet.Cells["E1"].Value = "Società";
                worksheet.Cells["F1"].Value = "Driver";
                worksheet.Cells["G1"].Value = "Scadenza";
                worksheet.Cells["H1"].Value = "Km Contratto";
                worksheet.Cells["I1"].Value = "Stato";

                //righe 
                if (Page.IsPostBack)
                {
                    hdusers.Value = hduiduser.Value;
                    hdcodfornitore.Value = ddlFornitore.SelectedValue;
                    hdcodsocieta.Value = ddlCodsocieta.SelectedValue;
                    hdtarga.Value = txtTarga.Text;
                }

                string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
                Guid UserId = SeoHelper.GuidString(hdusers.Value);
                string targa = SeoHelper.EncodeString(hdtarga.Value);
                string codfornitore = SeoHelper.EncodeString(hdcodfornitore.Value);                
                string marca = SeoHelper.EncodeString(txtMarca.Text);
                string numerocontratto = SeoHelper.EncodeString(txtNumerocontratto.Text);
                DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
                DateTime dataal = SeoHelper.DataString(txtDataal.Text);
                int idstatuscontratto = SeoHelper.IntString(ddlstatus.SelectedValue);
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();
                string ordine = SeoHelper.EncodeString(ddlOrdina.SelectedValue);
                string tipoordine = SeoHelper.EncodeString(ddlTipoOrdina.SelectedValue);

                List<IContratti> dataExport = servizioContratti.SelectContratti(codsocieta, UserId, marca, targa, codfornitore, numerocontratto, datadal, dataal, idstatuscontratto, Uidtenant, ordine, tipoordine, 100000, 1);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (IContratti resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Numerocontratto + " del " + resultExport.Datacontratto.ToString("dd/MM/yyyy");
                        worksheet.Cells["B" + countRow].Value = resultExport.Targa;
                        worksheet.Cells["C" + countRow].Value = resultExport.Marca + " - " + resultExport.Modello;
                        worksheet.Cells["D" + countRow].Value = resultExport.Fornitore;
                        worksheet.Cells["E" + countRow].Value = resultExport.Societa;
                        worksheet.Cells["F" + countRow].Value = resultExport.Cognome;
                        worksheet.Cells["G" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["G" + countRow].Value = resultExport.Datafinecontratto;
                        worksheet.Cells["H" + countRow].Value = resultExport.Kmcontratto;
                        worksheet.Cells["I" + countRow].Value = resultExport.Statuscontratto;

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
