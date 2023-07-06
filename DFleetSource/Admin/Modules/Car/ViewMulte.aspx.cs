// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewMulte.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Car
{
    public partial class ViewMulte : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(70)) //controllo se la pagina è autorizzata per l'utente 
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
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string mese;
            int anno;
            if (!string.IsNullOrEmpty(ddlMese.SelectedValue))
            {
                mese = SeoHelper.EncodeString(ddlMese.SelectedValue);
            }
            else
            {
                mese = SeoHelper.EncodeString(DateTime.Now.Month.ToString("d2"));
                ddlMese.SelectedValue = mese;
            }

            if (!string.IsNullOrEmpty(txtAnno.Text))
            {
                anno = SeoHelper.IntString(txtAnno.Text);
            }
            else
            {
                anno = DateTime.Now.Year;
                txtAnno.Text = anno.ToString();
            }
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioMulte.SelectCountMultePagate(targa, UserId, mese, anno, Uidtenant);
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
            Response.Redirect("ViewMulte");
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
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string mese;
            int anno;
            if (!string.IsNullOrEmpty(ddlMese.SelectedValue))
            {
                mese = SeoHelper.EncodeString(ddlMese.SelectedValue);
            }
            else
            {
                mese = SeoHelper.EncodeString(DateTime.Now.Month.ToString("d2"));
                ddlMese.SelectedValue = mese;
            }

            if (!string.IsNullOrEmpty(txtAnno.Text))
            {
                anno = SeoHelper.IntString(txtAnno.Text);
            }
            else
            {
                anno = DateTime.Now.Year;
                txtAnno.Text = anno.ToString();
            }
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioMulte.SelectCountMultePagate(targa, UserId, mese, anno, Uidtenant);
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
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string mese;
            int anno;
            if (!string.IsNullOrEmpty(ddlMese.SelectedValue))
            {
                mese = SeoHelper.EncodeString(ddlMese.SelectedValue);
            }
            else
            {
                mese = SeoHelper.EncodeString(DateTime.Now.Month.ToString("d2"));
                ddlMese.SelectedValue = mese;
            }

            if (!string.IsNullOrEmpty(txtAnno.Text))
            {
                anno = SeoHelper.IntString(txtAnno.Text);
            }
            else
            {
                anno = DateTime.Now.Year;
                txtAnno.Text = anno.ToString();
            }
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioMulte.SelectCountMultePagate(targa, UserId, mese, anno, Uidtenant);
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
                string namesheet = "MULTE";                
                string nomefile = "200327_Payroll_multe_" + DateTime.Now.Month + DateTime.Now.Year;

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
                worksheet.Cells["A1"].Value = "Matricola";
                worksheet.Cells["B1"].Value = "Cognome";
                worksheet.Cells["C1"].Value = "Nome";
                worksheet.Cells["D1"].Value = "FY";
                worksheet.Cells["E1"].Value = "Periodo";
                worksheet.Cells["F1"].Value = "Item";
                worksheet.Cells["G1"].Value = "Cod società";
                worksheet.Cells["H1"].Value = "Denominazione società";
                worksheet.Cells["I1"].Value = "Cod_Cdc";
                worksheet.Cells["J1"].Value = "Targa";
                worksheet.Cells["K1"].Value = "Importo contravvenzione";

                //righe 
                string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
                Guid UserId = SeoHelper.GuidString(hdusers.Value);
                string mese;
                int anno;
                if (!string.IsNullOrEmpty(ddlMese.SelectedValue))
                {
                    mese = SeoHelper.EncodeString(ddlMese.SelectedValue);
                }
                else
                {
                    mese = SeoHelper.EncodeString(DateTime.Now.Month.ToString("d2"));
                    ddlMese.SelectedValue = mese;
                }

                if (!string.IsNullOrEmpty(txtAnno.Text))
                {
                    anno = SeoHelper.IntString(txtAnno.Text);
                }
                else
                {
                    anno = DateTime.Now.Year;
                    txtAnno.Text = anno.ToString();
                }
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();

                List<IMulte> dataExport = servizioMulte.SelectMultePagate(targa, UserId, mese, anno, Uidtenant, 100000, 1);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (IMulte resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Matricola;
                        worksheet.Cells["B" + countRow].Value = resultExport.Cognome;
                        worksheet.Cells["C" + countRow].Value = resultExport.Nome;
                        worksheet.Cells["D" + countRow].Value = SeoHelper.FiscalYear(mese, anno.ToString().Substring(2));
                        worksheet.Cells["E" + countRow].Value = SeoHelper.FirstLetterToUpper(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(SeoHelper.IntString(mese)));
                        worksheet.Cells["F" + countRow].Value = "TRATTENUTA PER CONTRAVVENZIONE";
                        worksheet.Cells["G" + countRow].Value = resultExport.Codsocieta;
                        worksheet.Cells["H" + countRow].Value = resultExport.Societa;
                        worksheet.Cells["I" + countRow].Value = resultExport.Codicecdc;
                        worksheet.Cells["J" + countRow].Value = resultExport.Targa;
                        worksheet.Cells["K" + countRow].Value = resultExport.Importomultapagato.ToString("0.00");

                        countRow++;
                    }
                }

                Response.Clear();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + nomefile + ".xls");
                Response.BinaryWrite(package.GetAsByteArray());
                Response.End();
            }
        }

        /********************** FINE ESPORTA EXCEL **********************/

        protected void btnEsporta2_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnEsporta3_Click(object sender, EventArgs e)
        {            

        }


    }
}
