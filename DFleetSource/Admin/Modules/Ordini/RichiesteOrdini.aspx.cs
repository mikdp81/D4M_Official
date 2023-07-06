// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="RichiesteOrdini.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Ordini
{
    public partial class RichiesteOrdini : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(10)) //controllo se la pagina è autorizzata per l'utente 
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
            loadPage();
        }

        public void loadPage()
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;
            string search = SeoHelper.EncodeString(txtSearch.Text);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            int idstatusordine = SeoHelper.IntString(ddlStatusOrdini.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue);
            string codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
            string codcarlist = SeoHelper.EncodeString(ddlCodCarList.SelectedValue);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountRichiesteOrdini(search, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, idstatusordine, Uidtenant);
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


            lblNumRecord.Text = "Richieste Ordini: " + HttpUtility.HtmlEncode(totaleRighe);
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
            Response.Redirect("RichiesteOrdini");
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
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            int idstatusordine = SeoHelper.IntString(ddlStatusOrdini.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue);
            string codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
            string codcarlist = SeoHelper.EncodeString(ddlCodCarList.SelectedValue);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountRichiesteOrdini(search, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, idstatusordine, Uidtenant);
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
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            int idstatusordine = SeoHelper.IntString(ddlStatusOrdini.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue);
            string codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
            string codcarlist = SeoHelper.EncodeString(ddlCodCarList.SelectedValue);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountRichiesteOrdini(search, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, idstatusordine, Uidtenant);
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
                worksheet.Cells["A1"].Value = "Numero";
                worksheet.Cells["B1"].Value = "Data";
                worksheet.Cells["C1"].Value = "Societa";
                worksheet.Cells["D1"].Value = "Nome";
                worksheet.Cells["E1"].Value = "Cognome";
                worksheet.Cells["F1"].Value = "Matricola";
                worksheet.Cells["G1"].Value = "Grade";
                worksheet.Cells["H1"].Value = "CarList";
                worksheet.Cells["I1"].Value = "Fornitore";
                worksheet.Cells["J1"].Value = "Marca";
                worksheet.Cells["K1"].Value = "Modello";
                worksheet.Cells["L1"].Value = "Optional canone";
                worksheet.Cells["M1"].Value = "Stato";

                //righe 
                string search = SeoHelper.EncodeString(txtSearch.Text);
                Guid UserId = SeoHelper.GuidString(hdusers.Value);
                int idstatusordine = SeoHelper.IntString(ddlStatusOrdini.SelectedValue);
                string codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue);
                string codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
                string codcarlist = SeoHelper.EncodeString(ddlCodCarList.SelectedValue);
                string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
                DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
                DateTime dataal = SeoHelper.DataString(txtDataal.Text);
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();

                List<IContratti> dataExport = servizioContratti.SelectRichiesteOrdini(search, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, idstatusordine, Uidtenant, 10000, 1);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (IContratti resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Numeroordine;
                        worksheet.Cells["B" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["B" + countRow].Value = resultExport.Dataordine;
                        worksheet.Cells["C" + countRow].Value = resultExport.Societa;
                        worksheet.Cells["D" + countRow].Value = resultExport.Cognome;
                        worksheet.Cells["E" + countRow].Value = resultExport.Nome;
                        worksheet.Cells["F" + countRow].Value = resultExport.Matricola;
                        worksheet.Cells["G" + countRow].Value = resultExport.Grade;
                        worksheet.Cells["H" + countRow].Value = resultExport.Codcarlist;
                        worksheet.Cells["I" + countRow].Value = resultExport.Codfornitore;
                        worksheet.Cells["J" + countRow].Value = resultExport.Marca;
                        worksheet.Cells["K" + countRow].Value = resultExport.Modello;
                        worksheet.Cells["L" + countRow].Value = resultExport.Deltacanone;
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
            string retVal = string.Empty;

            retVal += "<a href='EditOrdini-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Modifica Ordine'><img src='../../../plugins/images/ico_modify.svg' class='icon20' border='0' alt='' /></a>";
            retVal += "<a href='ViewConf-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Visualizza Ordine'><img src='../../../plugins/images/visualizza_ordine.svg' class='icon20' border='0' alt='' /></a>";

            switch (idstatusordine.ToUpper())
            {
                case "1": //Configurato da autorizzare
                    retVal += "<a href='EditFirma-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Autorizza'><img src='../../../plugins/images/autorizza.svg' class='icon20' border='0' alt='' /></a>";
                    retVal += "<a href='EditScarta-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Non Autorizza'><img src='../../../plugins/images/non_autorizza.svg' class='icon20' border='0' alt='' /></a>";
                    break;
                case "10": //Autorizzato in attesa di presa in carico
                    retVal += "<a href='EditScarta-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Non Autorizza'><img src='../../../plugins/images/non_autorizza.svg' class='icon20' border='0' alt='' /></a>";
                    break;
                case "20": //In attesa di offerta da Rental
                    retVal += "<a href='EditScarta-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Non Autorizza'><img src='../../../plugins/images/non_autorizza.svg' class='icon20' border='0' alt='' /></a>";
                    break;
                case "25": //Elaborazione offerta 
                    retVal += "<a href='EditElabora-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Elabora Offerta'><img src='../../../plugins/images/elabora_offerta.svg' class='icon20' border='0' alt='' /></a>";
                    retVal += "<a href='EditScarta-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Non Autorizza'><img src='../../../plugins/images/non_autorizza.svg' class='icon20' border='0' alt='' /></a>";
                    break;
                case "30": //Offerta da valutare Driver
                    retVal += "<a href='EditScarta-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Non Autorizza'><img src='../../../plugins/images/non_autorizza.svg' class='icon20' border='0' alt='' /></a>";
                    break;
                case "40": //Conferma ordine in firma
                    //retVal += "<a href='EditConferma-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Firma e Conferma'  target='_blank'><img src='../../../plugins/images/firma_e_conferma.svg' class='icon20' border='0' alt='' /></a>";
                    retVal += "<a href='EditScarta-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Non Autorizza'><img src='../../../plugins/images/non_autorizza.svg' class='icon20' border='0' alt='' /></a>";
                    break;
                case "50": //In attesa di evasione Rental
                    retVal += "<a href='EditScarta-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Non Autorizza'><img src='../../../plugins/images/non_autorizza.svg' class='icon20' border='0' alt='' /></a>";
                    break;
                case "55": //Evaso Rental
                    retVal += "<a href='EditContratto-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Trasforma in Contratto'><img src='../../../plugins/images/trasforma_in_contratto.svg' class='icon20' border='0' alt='' /></a>";
                    retVal += "<a href='EditScarta-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Non Autorizza'><img src='../../../plugins/images/non_autorizza.svg' class='icon20' border='0' alt='' /></a>";
                    break;
                case "60": //Offerta contrattualizzata
                    retVal += "<a href='EditConsegna-" + Uid + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Consegna Auto'><img src='../../../plugins/images/consegna_auto.svg' class='icon20' border='0' alt='' /></a>";
                    break;
                case "100": //Scartato Driver

                    break;
                case "110": //Non Autorizzato

                    break;
            }

            return retVal;
        }

        public string ReturnApprovatore(string idutente)
        {
            string retVal = string.Empty;
            IContrattiBL servizioContratti = new ContrattiBL();

            IContratti dataId = servizioContratti.ReturnApprovatore(SeoHelper.IntString(idutente));
            if (dataId != null)
            {
                retVal = dataId.Cognome;
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
    }
}
