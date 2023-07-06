// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewConfDriver.aspx.cs" company="">
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
using System.Web.UI.HtmlControls;

namespace DFleet.Admin.Modules.Ordini
{
    public partial class ViewConfDriver : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(60)) //controllo se la pagina è autorizzata per l'utente 
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
            string carpolicy = SeoHelper.EncodeString(ddlCarPolicy.SelectedValue);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountUserCarPolicyPageAdmin(codsocieta, carpolicy, UserId, Uidtenant);
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


            if (gvRicAppr.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicAppr.HeaderRow.TableSection = TableRowSection.TableHeader;
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


            lblNumRecord.Text = "Configurazioni: " + HttpUtility.HtmlEncode(totaleRighe);
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
            Response.Redirect("ViewConfDriver");
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
            string carpolicy = SeoHelper.EncodeString(ddlCarPolicy.SelectedValue);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountUserCarPolicyPageAdmin(codsocieta, carpolicy, UserId, Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;

            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string carpolicy = SeoHelper.EncodeString(ddlCarPolicy.SelectedValue);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountUserCarPolicyPageAdmin(codsocieta, carpolicy, UserId, Uidtenant);
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
                string namesheet = "ReportConfigurazioniDriver-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

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
                worksheet.Cells["B1"].Value = "Matricola";
                worksheet.Cells["C1"].Value = "Grade";
                worksheet.Cells["D1"].Value = "CarPolicy";
                worksheet.Cells["E1"].Value = "Società";
                worksheet.Cells["F1"].Value = "Preass";
                worksheet.Cells["G1"].Value = "Approvato";
                worksheet.Cells["H1"].Value = "Invio Mail";
                worksheet.Cells["I1"].Value = "Decorrenza dal";
                worksheet.Cells["J1"].Value = "Decorrenza al";
                worksheet.Cells["K1"].Value = "Motivazione";
                worksheet.Cells["L1"].Value = "Accetta";
                worksheet.Cells["M1"].Value = "Rinuncia";

                //righe 
                string carpolicy = SeoHelper.EncodeString(ddlCarPolicy.SelectedValue);
                Guid UserId = SeoHelper.GuidString(hdusers.Value);
                string codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue);
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();


                List<IContratti> dataExport = servizioContratti.SelectUserCarPolicyPageAdmin(codsocieta, carpolicy, UserId, Uidtenant, 10000, 1);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (IContratti resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Denominazione;
                        worksheet.Cells["B" + countRow].Value = resultExport.Matricola;
                        worksheet.Cells["C" + countRow].Value = resultExport.Grade;
                        worksheet.Cells["D" + countRow].Value = resultExport.Codcarpolicy;
                        worksheet.Cells["E" + countRow].Value = resultExport.Societa;
                        worksheet.Cells["F" + countRow].Value = resultExport.Preassegnazione;
                        worksheet.Cells["G" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["G" + countRow].Value = ReturnData(resultExport.Dataapprovazione.ToString());
                        worksheet.Cells["H" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["H" + countRow].Value = ReturnData(resultExport.Datamail.ToString());
                        worksheet.Cells["I" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["I" + countRow].Value = ReturnData(resultExport.Datadecorrenza.ToString());
                        worksheet.Cells["J" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["J" + countRow].Value = ReturnData(resultExport.Datafinedecorrenza.ToString());
                        worksheet.Cells["K" + countRow].Value = resultExport.Motivazione;
                        worksheet.Cells["L" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["L" + countRow].Value = ReturnData(resultExport.Datadocpolicy.ToString());
                        worksheet.Cells["M" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["M" + countRow].Value = ReturnData(resultExport.Datarinuncia.ToString());

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
            string retVal;

            if (string.IsNullOrEmpty(data) || data == "01/01/0001 00:00:00")
            {
                retVal = "";
            }
            else
            {
                retVal = data.Substring(0, 10);
            }

            return retVal;
        }
        public string ReturnDataDecorrenza(string datadecorrenza, string datafinedecorrenza)
        {
            string retVal;

            if (string.IsNullOrEmpty(datadecorrenza) || datadecorrenza == "01/01/0001 00:00:00")
            {
                retVal = "";
            }
            else
            {
                retVal = "DAL " + datadecorrenza.Substring(0, 10);
            }

            if (string.IsNullOrEmpty(datafinedecorrenza) || datafinedecorrenza == "01/01/0001 00:00:00")
            {
                retVal += "";
            }
            else
            {
                retVal += " AL " + datafinedecorrenza.Substring(0, 10);
            }

            return retVal;
        }
        public string ReturnApprovato(string approvato)
        {
            string retVal;

            if (!string.IsNullOrEmpty(approvato))
            {
                if (approvato == "1")
                {
                    retVal = "SI";
                }
                else
                {
                    retVal = "NO";
                }
            }
            else
            {
                retVal = "";
            }

            return retVal;
        }
    }
}
