// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewDimissionari.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Pen
{
    public partial class ViewDimissionari : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(72)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            hdcodsocieta.Value = ReturnCodSocieta();
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
            ICarsBL servizioCar = new CarsBL();
            pnlMessage.Visible = false;
            string nominativo = SeoHelper.EncodeString(txtDriver.Text);
            string codgrade = SeoHelper.EncodeString(txtGrade.Text);
            string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
            string codfornitore = SeoHelper.EncodeString(txtFornitore.Text);
            DateTime dataassdal = SeoHelper.DataString(txtDataAssdal.Text);
            DateTime dataassal = SeoHelper.DataString(txtDataAssal.Text);
            DateTime datapresdimdal = SeoHelper.DataString(txtDataPresDimdal.Text);
            DateTime datapresdimal = SeoHelper.DataString(txtDataPresDimal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioCar.SelectCountDimissionari(nominativo, codgrade, codsocieta, codfornitore, dataassdal, dataassal, datapresdimdal, datapresdimal, "", Uidtenant);
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


            if (gvRicDim.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicDim.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            lblNumRecord.Text = "Voci: " + HttpUtility.HtmlEncode(totaleRighe);
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
            Response.Redirect("ViewDimissionari");
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
            ICarsBL servizioCar = new CarsBL();
            string nominativo = SeoHelper.EncodeString(txtDriver.Text);
            string codgrade = SeoHelper.EncodeString(txtGrade.Text);
            string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
            string codfornitore = SeoHelper.EncodeString(txtFornitore.Text);
            DateTime dataassdal = SeoHelper.DataString(txtDataAssdal.Text);
            DateTime dataassal = SeoHelper.DataString(txtDataAssal.Text);
            DateTime datapresdimdal = SeoHelper.DataString(txtDataPresDimdal.Text);
            DateTime datapresdimal = SeoHelper.DataString(txtDataPresDimal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioCar.SelectCountDimissionari(nominativo, codgrade, codsocieta, codfornitore, dataassdal, dataassal, datapresdimdal, datapresdimal, "", Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;
            
            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            ICarsBL servizioCar = new CarsBL();
            string nominativo = SeoHelper.EncodeString(txtDriver.Text);
            string codgrade = SeoHelper.EncodeString(txtGrade.Text);
            string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
            string codfornitore = SeoHelper.EncodeString(txtFornitore.Text);
            DateTime dataassdal = SeoHelper.DataString(txtDataAssdal.Text);
            DateTime dataassal = SeoHelper.DataString(txtDataAssal.Text);
            DateTime datapresdimdal = SeoHelper.DataString(txtDataPresDimdal.Text);
            DateTime datapresdimal = SeoHelper.DataString(txtDataPresDimal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioCar.SelectCountDimissionari(nominativo, codgrade, codsocieta, codfornitore, dataassdal, dataassal, datapresdimdal, datapresdimal, "", Uidtenant);
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
            ICarsBL servizioCar = new CarsBL();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excel = new ExcelPackage())
            {
                string namesheet = "ReportDimissionari-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

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
                worksheet.Cells["A1"].Value = "Nominativo";
                worksheet.Cells["B1"].Value = "Assunzione";
                worksheet.Cells["C1"].Value = "Dimissioni";
                worksheet.Cells["D1"].Value = "Ordine pending";
                worksheet.Cells["E1"].Value = "Targa";
                worksheet.Cells["F1"].Value = "Fornitore";
                worksheet.Cells["G1"].Value = "Inizio contratto";
                worksheet.Cells["H1"].Value = "Inizio uso";
                worksheet.Cells["I1"].Value = "Fine contratto";
                worksheet.Cells["J1"].Value = "Importo canone (iva escl)";
                worksheet.Cells["K1"].Value = "Auto già presente nel parco?";

                //righe           
                string nominativo = SeoHelper.EncodeString(txtDriver.Text);
                string codgrade = SeoHelper.EncodeString(txtGrade.Text);
                string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
                string codfornitore = SeoHelper.EncodeString(txtFornitore.Text);
                DateTime dataassdal = SeoHelper.DataString(txtDataAssdal.Text);
                DateTime dataassal = SeoHelper.DataString(txtDataAssal.Text);
                DateTime datapresdimdal = SeoHelper.DataString(txtDataPresDimdal.Text);
                DateTime datapresdimal = SeoHelper.DataString(txtDataPresDimal.Text);
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();

                List<ICars> dataExport = servizioCar.SelectDimissionari(nominativo, codgrade, codsocieta, codfornitore, dataassdal, dataassal, datapresdimdal, datapresdimal, "", Uidtenant, 10000, 1);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (ICars resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Cognome + " " + resultExport.Nome + " - " + resultExport.Grade;
                        worksheet.Cells["B" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["B" + countRow].Value = ReturnData(resultExport.Dataassunzione.ToString());
                        worksheet.Cells["C" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["C" + countRow].Value = ReturnData(resultExport.Dataprevistadimissione.ToString());
                        worksheet.Cells["D" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["D" + countRow].Value = ReturnData(resultExport.Dataordine.ToString());
                        worksheet.Cells["E" + countRow].Value = resultExport.Targa;
                        worksheet.Cells["F" + countRow].Value = resultExport.Fornitore;
                        worksheet.Cells["G" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["G" + countRow].Value = ReturnData(resultExport.Datainiziocontratto.ToString());
                        worksheet.Cells["H" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["H" + countRow].Value = ReturnData(resultExport.Datainiziouso.ToString());
                        worksheet.Cells["I" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["I" + countRow].Value = ReturnData(resultExport.Datafinecontratto.ToString());
                        worksheet.Cells["J" + countRow].Value = ReturnCanone(resultExport.Canoneleasing.ToString());
                        worksheet.Cells["K" + countRow].Value = ReturnAutoParco(resultExport.Totparcoauto.ToString());
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

        public string ReturnOrdinePending(string dataordine)
        {
            string retVal;

            if (string.IsNullOrEmpty(dataordine) || dataordine == "01/01/0001 00:00:00")
            {
                retVal = "NO";
            }
            else
            {
                retVal = "SI";
            }

            return retVal;
        }

        public string ReturnAutoParco(string totparcoauto)
        {
            string retVal;

            if (SeoHelper.IntString(totparcoauto) > 1)
            {
                retVal = "SI";
            }
            else
            {
                retVal = "NO";
            }

            return retVal;
        }
        public string ReturnData(string data)
        {
            string retVal = string.Empty;

            if (string.IsNullOrEmpty(data) || data == "01/01/0001 00:00:00")
            {
                retVal = "";
            }
            else
            {
                string[] data1 = data.Split(' ');
                retVal += data1[0];
            }

            return retVal;
        }
        public string ReturnCanone(string canoneleasing)
        {
            string retVal;

            if (string.IsNullOrEmpty(canoneleasing) || canoneleasing == "0" || canoneleasing == "0,00" || canoneleasing == "0.00")
            {
                retVal = "";
            }
            else
            {
                retVal = canoneleasing;
            }

            return retVal;
        }
        public string ReturnCodSocieta()
        {
            IAccountBL servizioAccount = new AccountBL();
            IUtilitysBL servizioUtility = new UtilitysBL();
            string retVal = string.Empty;
            string codsocieta = string.Empty;

            IAccount dataId = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
            if (dataId != null)
            {
                codsocieta = dataId.Codsocieta;
            }

            IUtilitys dataS = servizioUtility.DetailSocietaXCodS(codsocieta);
            if (dataS != null)
            {
                retVal = dataS.Siglasocieta;
            }

            return retVal;
        }
    }
}
