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

namespace DFleet.Admin.Modules.Car
{
    public partial class ViewDimissionari : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(59)) //controllo se la pagina è autorizzata per l'utente 
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
            ICarsBL servizioCar = new CarsBL();
            pnlMessage.Visible = false;
            string nominativo = SeoHelper.EncodeString(txtDriver.Text);
            string codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
            string codfornitore = SeoHelper.EncodeString(txtFornitore.Text);
            string totautoparco = SeoHelper.EncodeString(ddlAutoParco.SelectedValue);
            DateTime dataassdal = SeoHelper.DataString(txtDataAssdal.Text);
            DateTime dataassal = SeoHelper.DataString(txtDataAssal.Text);
            DateTime datapresdimdal = SeoHelper.DataString(txtDataPresDimdal.Text);
            DateTime datapresdimal = SeoHelper.DataString(txtDataPresDimal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            //se la data dimissioni non è stata seleziona filtra in automatico il mese precedente al corrente
            if (datapresdimdal == DateTime.MinValue)
            {
                datapresdimdal = SeoHelper.DataString("01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year);
                txtDataPresDimdal.Text = "01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
            }
            if (datapresdimal == DateTime.MinValue)
            {
                datapresdimal = SeoHelper.DataString(DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year);
                txtDataPresDimal.Text = DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
            }

            int totaleRighe = servizioCar.SelectCountDimissionari(nominativo, codgrade, codsocieta, codfornitore, dataassdal, dataassal, datapresdimdal, datapresdimal, totautoparco, Uidtenant);
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
            string codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
            string codfornitore = SeoHelper.EncodeString(txtFornitore.Text);
            string totautoparco = SeoHelper.EncodeString(ddlAutoParco.SelectedValue);
            DateTime dataassdal = SeoHelper.DataString(txtDataAssdal.Text);
            DateTime dataassal = SeoHelper.DataString(txtDataAssal.Text);
            DateTime datapresdimdal = SeoHelper.DataString(txtDataPresDimdal.Text);
            DateTime datapresdimal = SeoHelper.DataString(txtDataPresDimal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            //se la data dimissioni non è stata seleziona filtra in automatico il mese precedente al corrente
            if (datapresdimdal == DateTime.MinValue)
            {
                datapresdimdal = SeoHelper.DataString("01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year);
                txtDataPresDimdal.Text = "01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
            }
            if (datapresdimal == DateTime.MinValue)
            {
                datapresdimal = SeoHelper.DataString(DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year);
                txtDataPresDimal.Text = DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
            }
            int totaleRighe = servizioCar.SelectCountDimissionari(nominativo, codgrade, codsocieta, codfornitore, dataassdal, dataassal, datapresdimdal, datapresdimal, totautoparco, Uidtenant);
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
            string codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
            string codfornitore = SeoHelper.EncodeString(txtFornitore.Text);
            string totautoparco = SeoHelper.EncodeString(ddlAutoParco.SelectedValue);
            DateTime dataassdal = SeoHelper.DataString(txtDataAssdal.Text);
            DateTime dataassal = SeoHelper.DataString(txtDataAssal.Text);
            DateTime datapresdimdal = SeoHelper.DataString(txtDataPresDimdal.Text);
            DateTime datapresdimal = SeoHelper.DataString(txtDataPresDimal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            //se la data dimissioni non è stata seleziona filtra in automatico il mese precedente al corrente
            if (datapresdimdal == DateTime.MinValue)
            {
                datapresdimdal = SeoHelper.DataString("01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year);
                txtDataPresDimdal.Text = "01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
            }
            if (datapresdimal == DateTime.MinValue)
            {
                datapresdimal = SeoHelper.DataString(DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year);
                txtDataPresDimal.Text = DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
            }
            int totaleRighe = servizioCar.SelectCountDimissionari(nominativo, codgrade, codsocieta, codfornitore, dataassdal, dataassal, datapresdimdal, datapresdimal, totautoparco, Uidtenant);
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

            FileInfo newFile = new FileInfo(RequestExtensions.GetPathPhisicalApplication() + "/Repository/report/report_dimissionari.xlsx");

            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                string namesheet = "ReportDimissionari-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

                ExcelWorksheet worksheet = excel.Workbook.Worksheets[0];


                //intestazione
                var allCells = worksheet.Cells[1, 1, 200, 16];
                var cellFont = allCells.Style.Font;
                float fontSize = 10.0f; // Provide the appropriate value for the font size
                cellFont.SetFromFont("Arial", fontSize, true, false, false, false);

                //titoli intestazione

                /*worksheet.Cells["A1"].Value = "Cognome";
                worksheet.Cells["B1"].Value = "Nome";
                worksheet.Cells["C1"].Value = "Matricola";
                worksheet.Cells["D1"].Value = "Grade";
                worksheet.Cells["E1"].Value = "Sigla societa";
                worksheet.Cells["F1"].Value = "Data assunzione";
                worksheet.Cells["G1"].Value = "Data prevista dimissione";
                worksheet.Cells["H1"].Value = "Data dimissioni";
                worksheet.Cells["I1"].Value = "Data carpolicy";
                worksheet.Cells["J1"].Value = "Data ordine";
                worksheet.Cells["K1"].Value = "Targa";
                worksheet.Cells["L1"].Value = "Fornitore";
                worksheet.Cells["M1"].Value = "Data inizio contratto";
                worksheet.Cells["N1"].Value = "Data inizio uso";
                worksheet.Cells["O1"].Value = "Data fine contratto";
                worksheet.Cells["P1"].Value = "Durata";
                worksheet.Cells["Q1"].Value = "Canone leasing";
                worksheet.Cells["R1"].Value = "Tot parco auto";
                worksheet.Cells["S1"].Value = "Importo forfettario";
                worksheet.Cells["T1"].Value = "Penale Ordine";
                worksheet.Cells["U1"].Value = "Penale Ritiro";
                worksheet.Cells["V1"].Value = "Canone optional";
                worksheet.Cells["W1"].Value = "Mesi residui";
                worksheet.Cells["X1"].Value = "Residuo optional";
                worksheet.Cells["Y1"].Value = "Multe";
                worksheet.Cells["Z1"].Value = "Fuel";
                worksheet.Cells["AA1"].Value = "Rimborso concur";
                worksheet.Cells["AB1"].Value = "Spese amministrative";*/


                //righe           
                string nominativo = SeoHelper.EncodeString(txtDriver.Text);
                string codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
                string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
                string codfornitore = SeoHelper.EncodeString(txtFornitore.Text);
                string totautoparco = SeoHelper.EncodeString(ddlAutoParco.SelectedValue);
                DateTime dataassdal = SeoHelper.DataString(txtDataAssdal.Text);
                DateTime dataassal = SeoHelper.DataString(txtDataAssal.Text);
                DateTime datapresdimdal = SeoHelper.DataString(txtDataPresDimdal.Text);
                DateTime datapresdimal = SeoHelper.DataString(txtDataPresDimal.Text);
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();
                //se la data dimissioni non è stata seleziona filtra in automatico il mese precedente al corrente
                if (datapresdimdal == DateTime.MinValue)
                {
                    datapresdimdal = SeoHelper.DataString("01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year);
                    txtDataPresDimdal.Text = "01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
                }
                if (datapresdimal == DateTime.MinValue)
                {
                    datapresdimal = SeoHelper.DataString(DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year);
                    txtDataPresDimal.Text = DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
                }

                List<ICars> dataExport = servizioCar.SelectDimissionari(nominativo, codgrade, codsocieta, codfornitore, dataassdal, dataassal, datapresdimdal, datapresdimal, totautoparco, Uidtenant, 100000, 1);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (ICars resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Cognome;
                        worksheet.Cells["B" + countRow].Value = resultExport.Nome;
                        worksheet.Cells["C" + countRow].Value = resultExport.Matricola;
                        worksheet.Cells["D" + countRow].Value = resultExport.Grade;
                        worksheet.Cells["E" + countRow].Value = resultExport.Siglasocieta;
                        worksheet.Cells["F" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["F" + countRow].Value = ReturnData(resultExport.Dataassunzione.ToString());
                        worksheet.Cells["G" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["G" + countRow].Value = ReturnData(resultExport.Dataprevistadimissione.ToString());
                        worksheet.Cells["H" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["H" + countRow].Value = ReturnData(resultExport.Datadimissioni.ToString());
                        worksheet.Cells["I" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["I" + countRow].Value = ReturnData(resultExport.Datadocpolicy.ToString());
                        worksheet.Cells["J" + countRow].Value = resultExport.Ordinecorrente;
                        worksheet.Cells["K" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["K" + countRow].Value = ReturnData(resultExport.Dataordine.ToString());
                        worksheet.Cells["L" + countRow].Value = resultExport.Ordinestatus;
                        worksheet.Cells["M" + countRow].Value = resultExport.Note;
                        worksheet.Cells["N" + countRow].Value = resultExport.Targa;
                        worksheet.Cells["O" + countRow].Value = resultExport.Fornitore;
                        worksheet.Cells["P" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["P" + countRow].Value = ReturnData(resultExport.Datainiziocontratto.ToString());
                        worksheet.Cells["Q" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["Q" + countRow].Value = ReturnData(resultExport.Datainiziouso.ToString());
                        worksheet.Cells["R" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["R" + countRow].Value = ReturnData(resultExport.Datafinecontratto.ToString());
                        worksheet.Cells["S" + countRow].Value = resultExport.Mesicontratto;
                        worksheet.Cells["T" + countRow].Value = ReturnCanone(resultExport.Canoneleasing.ToString());
                        worksheet.Cells["U" + countRow].Value = resultExport.Importoforfettario;
                        worksheet.Cells["V" + countRow].Value = resultExport.Penaleordine;
                        worksheet.Cells["W" + countRow].Value = resultExport.Penaleritiro;
                        worksheet.Cells["X" + countRow].Value = resultExport.Erratasederestituzione;
                        worksheet.Cells["Y" + countRow].Value = resultExport.Erratarestituzionegomme;
                        worksheet.Cells["Z" + countRow].Value = resultExport.Penaledenuncia;
                        worksheet.Cells["AA" + countRow].Value = resultExport.Canoneoptional;
                        worksheet.Cells["AB" + countRow].Value = resultExport.Mesiresidui;
                        worksheet.Cells["AC" + countRow].Value = resultExport.Residuooptional;
                        worksheet.Cells["AD" + countRow].Value = resultExport.Multe;
                        worksheet.Cells["AE" + countRow].Value = resultExport.Fuel;
                        worksheet.Cells["AF" + countRow].Value = resultExport.Rimborsoconcur;
                        worksheet.Cells["AG" + countRow].Value = resultExport.Speseamministrative;


                        countRow++;
                    }
                }

                Response.Clear();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=report-dimissionari.xlsx");
                Response.BinaryWrite(excel.GetAsByteArray());
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
    }
}
