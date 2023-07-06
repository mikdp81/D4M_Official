// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewPenali.aspx.cs" company="">
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
    public partial class ViewPenali : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(85)) //controllo se la pagina è autorizzata per l'utente 
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
                hdstatus.Value = ddlStatus.SelectedValue;
                hdtarga.Value = txtTarga.Text;
                hdidtipopenale.Value = ddltipopenaleauto.SelectedValue;
            }

            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string targa = SeoHelper.EncodeString(hdtarga.Value);
            string codfornitore = SeoHelper.EncodeString(hdcodfornitore.Value);
            string numerofattura = SeoHelper.EncodeString(txtNumerofattura.Text);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idtipopenaleauto = SeoHelper.IntString(ddltipopenaleauto.SelectedValue);
            string status = SeoHelper.EncodeString(hdstatus.Value);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            string ordine = SeoHelper.EncodeString(ddlOrdina.SelectedValue);
            string tipoordine = SeoHelper.EncodeString(ddlTipoOrdina.SelectedValue);
            InsertSession(UserId,  targa, codfornitore, numerofattura, datadal, dataal, idtipopenaleauto, status, totaleRecord, ordine, tipoordine);
            int totaleRighe = servizioContratti.SelectCountPenaliAuto(UserId, targa, codfornitore, numerofattura, datadal, dataal, idtipopenaleauto, status, Uidtenant);
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


            if (gvRicPenali.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicPenali.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            lblNumRecord.Text = "Penali: " + HttpUtility.HtmlEncode(totaleRighe);
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
            if (Session["UserIdpenali"] != null)
            {
                hduiduser.Value = Session["UserIdpenali"].ToString();
                hdusers.Value = Session["UserIdpenali"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["targapenali"] != null)
            {
                txtTarga.Text = Session["targapenali"].ToString();
                hdtarga.Value = Session["targapenali"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["fornitorepenali"] != null)
            {
                ddlFornitore.SelectedValue = Session["fornitorepenali"].ToString();
                hdcodfornitore.Value = Session["fornitorepenali"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["numeropenali"] != null)
            {
                txtNumerofattura.Text = Session["numeropenali"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }

            if (Session["datadalpenali"] != null)
            {
                txtDatadal.Text = Session["datadalpenali"].ToString().Replace("00:00:00", "");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["dataalpenali"] != null)
            {
                txtDataal.Text = Session["dataalpenali"].ToString().Replace("00:00:00", "");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["tipopenali"] != null)
            {
                ddltipopenaleauto.SelectedValue = Session["tipopenali"].ToString();
                hdidtipopenale.Value = Session["tipopenali"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["statuspenali"] != null)
            {
                ddlStatus.SelectedValue = Session["statuspenali"].ToString();
                hdstatus.Value = Session["statuspenali"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            }
            if (Session["ordinapenali"] != null)
            {
                ddlOrdina.SelectedValue = Session["ordinapenali"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriOrdinamento()", true);
            }
            if (Session["tipoordinapenali"] != null)
            {
                ddlTipoOrdina.SelectedValue = Session["tipoordinapenali"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriOrdinamento()", true);
            }
            if (Session["totaleRecordpenali"] != null)
            {
                ddlNRecord.SelectedValue = Session["totaleRecordpenali"].ToString();
            }
        }
        public void InsertSession(Guid userId, string targa, string codfornitore, string numerofattura, DateTime datadal, DateTime dataal, int idtipopenaleauto, string status, int totaleRecord, string ordine, string tipoordine)
        {
            if (userId != Guid.Empty)
            {
                Session["UserIdpenali"] = userId.ToString();
            }
            if (!string.IsNullOrEmpty(targa))
            {
                Session["targapenali"] = targa;
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                Session["fornitorepenali"] = codfornitore;
            }
            if (!string.IsNullOrEmpty(numerofattura))
            {
                Session["numeropenali"] = numerofattura;
            }
            if (datadal > DateTime.MinValue)
            {
                Session["datadalpenali"] = datadal.ToString();
            }
            if (dataal > DateTime.MinValue)
            {
                Session["dataalpenali"] = dataal.ToString();
            }
            if (idtipopenaleauto > 0)
            {
                Session["tipopenali"] = idtipopenaleauto.ToString();
            }
            if(!string.IsNullOrEmpty(status))
            {
                Session["statuspenali"] = status;
            }
            if (!string.IsNullOrEmpty(ordine))
            {
                Session["ordinapenali"] = ordine;
            }
            if (!string.IsNullOrEmpty(tipoordine))
            {
                Session["tipoordinapenali"] = tipoordine;
            }
            if (totaleRecord > 0)
            {
                Session["totaleRecordpenali"] = totaleRecord.ToString();
            }
        }

        protected void btnSvuotaFiltri_Click(object sender, EventArgs e)
        {       
            Session["UserIdpenali"] = "";
            Session["targapenali"] = "";
            Session["fornitorepenali"] = "";
            Session["numeropenali"] = "";
            Session["datadalpenali"] = "";
            Session["dataalpenali"] = "";
            Session["tipopenali"] = "";
            Session["ordinapenali"] = "";
            Session["statuspenali"] = "";
            Session["tipoordinapenali"] = "";
            Session["totaleRecordpenali"] = "";
            //Session.Clear();
            Response.Redirect("ViewPenali");
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
                hdstatus.Value = ddlStatus.SelectedValue;
                hdtarga.Value = txtTarga.Text;
                hdidtipopenale.Value = ddltipopenaleauto.SelectedValue;
            }

            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string targa = SeoHelper.EncodeString(hdtarga.Value);
            string codfornitore = SeoHelper.EncodeString(hdcodfornitore.Value);
            string numerofattura = SeoHelper.EncodeString(txtNumerofattura.Text);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idtipopenaleauto = SeoHelper.IntString(ddltipopenaleauto.SelectedValue);
            string status = SeoHelper.EncodeString(hdstatus.Value);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            string ordine = SeoHelper.EncodeString(ddlOrdina.SelectedValue);
            string tipoordine = SeoHelper.EncodeString(ddlTipoOrdina.SelectedValue);
            InsertSession(UserId, targa, codfornitore, numerofattura, datadal, dataal, idtipopenaleauto, status, totaleRecord, ordine, tipoordine);
            int totaleRighe = servizioContratti.SelectCountPenaliAuto(UserId, targa, codfornitore, numerofattura, datadal, dataal, idtipopenaleauto, status, Uidtenant);
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
                hdstatus.Value = ddlStatus.SelectedValue;
                hdtarga.Value = txtTarga.Text;
                hdidtipopenale.Value = ddltipopenaleauto.SelectedValue;
            }

            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string targa = SeoHelper.EncodeString(hdtarga.Value);
            string codfornitore = SeoHelper.EncodeString(hdcodfornitore.Value);
            string numerofattura = SeoHelper.EncodeString(txtNumerofattura.Text);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            int idtipopenaleauto = SeoHelper.IntString(ddltipopenaleauto.SelectedValue);
            string status = SeoHelper.EncodeString(hdstatus.Value);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            string ordine = SeoHelper.EncodeString(ddlOrdina.SelectedValue);
            string tipoordine = SeoHelper.EncodeString(ddlTipoOrdina.SelectedValue);
            InsertSession(UserId, targa, codfornitore, numerofattura, datadal, dataal, idtipopenaleauto, status, totaleRecord, ordine, tipoordine);
            int totaleRighe = servizioContratti.SelectCountPenaliAuto(UserId, targa, codfornitore, numerofattura, datadal, dataal, idtipopenaleauto, status, Uidtenant);
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
                string namesheet = "ReportPenali-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

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
                worksheet.Cells["A1"].Value = "N. e Data fattura";
                worksheet.Cells["B1"].Value = "Targa";
                worksheet.Cells["C1"].Value = "Fornitore";
                worksheet.Cells["D1"].Value = "Driver";
                worksheet.Cells["E1"].Value = "Tipo penale";
                worksheet.Cells["F1"].Value = "Status";

                //righe 
                if (Page.IsPostBack)
                {
                    hdusers.Value = hduiduser.Value;
                    hdcodfornitore.Value = ddlFornitore.SelectedValue;
                    hdstatus.Value = ddlStatus.SelectedValue;
                    hdtarga.Value = txtTarga.Text;
                    hdidtipopenale.Value = ddltipopenaleauto.SelectedValue;
                }

                Guid UserId = SeoHelper.GuidString(hdusers.Value);
                string targa = SeoHelper.EncodeString(hdtarga.Value);
                string codfornitore = SeoHelper.EncodeString(hdcodfornitore.Value);
                string numerofattura = SeoHelper.EncodeString(txtNumerofattura.Text);
                DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
                DateTime dataal = SeoHelper.DataString(txtDataal.Text);
                int idtipopenaleauto = SeoHelper.IntString(ddltipopenaleauto.SelectedValue);
                string status = SeoHelper.EncodeString(hdstatus.Value);
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();
                int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
                string ordine = SeoHelper.EncodeString(ddlOrdina.SelectedValue);
                string tipoordine = SeoHelper.EncodeString(ddlTipoOrdina.SelectedValue);

                List<IContratti> dataExport = servizioContratti.SelectPenaliAuto(UserId, targa, codfornitore, numerofattura, datadal, dataal, idtipopenaleauto, status, Uidtenant, ordine, tipoordine, 100000, 1);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (IContratti resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Numerofattura + " del " + resultExport.Datafattura.ToString("dd/MM/yyyy");
                        worksheet.Cells["B" + countRow].Value = resultExport.Targa;
                        worksheet.Cells["C" + countRow].Value = resultExport.Fornitore;
                        worksheet.Cells["D" + countRow].Value = resultExport.Cognome;
                        worksheet.Cells["E" + countRow].Value = resultExport.Tipopenaleauto;
                        worksheet.Cells["F" + countRow].Value = resultExport.Statuscontratto;

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
