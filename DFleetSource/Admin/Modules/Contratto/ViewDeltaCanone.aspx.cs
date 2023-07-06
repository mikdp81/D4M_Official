// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewDeltaCanone.aspx.cs" company="">
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
    public partial class ViewDeltaCanone : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(68)) //controllo se la pagina è autorizzata per l'utente 
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
            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
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
            int totaleRighe = servizioContratti.SelectCountAllDeltaCanone(codsocieta, UserId, mese, anno, Uidtenant);
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


            if (gvRicDelta.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicDelta.HeaderRow.TableSection = TableRowSection.TableHeader;
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
            Response.Redirect("ViewDeltaCanone");
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
            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
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
            int totaleRighe = servizioContratti.SelectCountAllDeltaCanone(codsocieta, UserId, mese, anno, Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;

            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
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
            int totaleRighe = servizioContratti.SelectCountAllDeltaCanone(codsocieta, UserId, mese, anno, Uidtenant);
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
                string namesheet = "DELTA_CANONE";

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
                worksheet.Cells["A1"].Value = "Codice Risorsa";
                worksheet.Cells["B1"].Value = "Cod Società";
                worksheet.Cells["C1"].Value = "Rag. Sociale";
                worksheet.Cells["D1"].Value = "Cognome";
                worksheet.Cells["E1"].Value = "Nome";
                worksheet.Cells["F1"].Value = "Targa";
                worksheet.Cells["G1"].Value = "Tot. fattura mensile";
                worksheet.Cells["H1"].Value = "Descrizione";

                //righe           
                string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
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

                List<IContratti> dataExport = servizioContratti.SelectFattureDeltaCanone(codsocieta, UserId, mese, anno);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (IContratti resultExport in dataExport)
                    {
                        string deltacanone;

                        if (resultExport.Giorniconsegnaagg < 0)
                        {
                            deltacanone = (((resultExport.Deltacanone * resultExport.Giorniconsegnaagg) / resultExport.Anno) * Convert.ToDecimal(1.22)).ToString("F2");
                        }
                        else if (resultExport.Giorniconsegnaagg < resultExport.Anno)
                        {
                            deltacanone = (((resultExport.Deltacanone * resultExport.Giorniconsegnaagg) / resultExport.Anno) * Convert.ToDecimal(1.22)).ToString("F2");
                        }
                        else
                        {
                            deltacanone = ((resultExport.Deltacanone) * Convert.ToDecimal(1.22)).ToString("F2");
                        }

                        worksheet.Cells["A" + countRow].Value = resultExport.Matricola;
                        worksheet.Cells["B" + countRow].Value = resultExport.Codsocieta;
                        worksheet.Cells["C" + countRow].Value = resultExport.Societa;
                        worksheet.Cells["D" + countRow].Value = resultExport.Cognome;
                        worksheet.Cells["E" + countRow].Value = resultExport.Nome;
                        worksheet.Cells["F" + countRow].Value = resultExport.Targa;
                        worksheet.Cells["G" + countRow].Value = deltacanone;
                        worksheet.Cells["H" + countRow].Value = resultExport.Targa + " - delta canone ";


                        countRow++;
                    }
                }

                string nomefile = "200327_Payroll_Delta_Canone_" + mese + anno.ToString().Substring(2, 2);

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
            IContrattiBL servizioContratti = new ContrattiBL();
            IUtilitysBL servizioUtilitys = new UtilitysBL();
            IAccountBL servizioAccount = new AccountBL();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string nomefile = "";

            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
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

            string tipodocumento;
            string positingkey;
            string positingkeydett;


            FileInfo newFile = new FileInfo(RequestExtensions.GetPathPhisicalApplication() + "/Repository/report/tracciato_noleggio.xlsx");

            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets[1];

                List<IContratti> dataExport = servizioContratti.SelectFattureDeltaCanone(codsocieta, UserId, mese, anno);

                if (dataExport != null && dataExport.Count > 0)
                {

                    int countRow = 8;
                    string denominazione = "";
                    string codcompany = "";
                    string codicecdc = "";
                    string idnumber = "";

                    foreach (IContratti resultExport in dataExport)
                    {
                        string deltacanoneivato;
                        string deltacanone;
                        nomefile = "";

                        //recupero nominativo driver
                        IAccount dataU = servizioAccount.DetailId(resultExport.UserId);
                        if (dataU != null)
                        {
                            denominazione = dataU.Cognome + " " + dataU.Nome;
                            codicecdc = dataU.Codicecdc;
                            idnumber = dataU.Idnumber;
                        }

                        //tronca denominazione a 20 caratteri 
                        if (denominazione.Length > 20)
                        {
                            denominazione = denominazione.Substring(0, 20);
                        }

                        //recupero codcompany

                        IUtilitys dataS = servizioUtilitys.DetailSocietaXCodS(codsocieta);
                        if (dataU != null)
                        {
                            codcompany = dataS.Codcompany;
                            nomefile += dataS.Codcompany + "_" + dataS.Siglasocieta;
                        }
                        nomefile += "_Delta_Canone_" + mese + anno.ToString().Substring(2, 2);


                        if (resultExport.Giorniconsegnaagg < 0)
                        {
                            tipodocumento = "YG";
                            positingkey = "11";
                            positingkeydett = "40";
                            deltacanoneivato = Math.Abs((((resultExport.Deltacanone * resultExport.Giorniconsegnaagg) / resultExport.Anno) * Convert.ToDecimal(1.22))).ToString("F2");
                            deltacanone = Math.Abs(((resultExport.Deltacanone * resultExport.Giorniconsegnaagg) / resultExport.Anno)).ToString("F2");
                        }
                        else
                        {
                            tipodocumento = "DR";
                            positingkey = "01";
                            positingkeydett = "50";
                            deltacanoneivato = Math.Abs((resultExport.Deltacanone * Convert.ToDecimal(1.22))).ToString("F2");
                            deltacanone = Math.Abs(resultExport.Deltacanone).ToString("F2");
                        }

                        worksheet.Cells["A" + countRow].Value = "";
                        worksheet.Cells["B" + countRow].Value = "";
                        worksheet.Cells["C" + countRow].Value = tipodocumento;
                        worksheet.Cells["D" + countRow].Value = codcompany;
                        worksheet.Cells["E" + countRow].Value = "";
                        worksheet.Cells["F" + countRow].Value = "";
                        worksheet.Cells["G" + countRow].Value = "";
                        worksheet.Cells["H" + countRow].Value = "";
                        worksheet.Cells["I" + countRow].Value = "";
                        worksheet.Cells["J" + countRow].Value = "EUR";
                        worksheet.Cells["K" + countRow].Value = "";
                        worksheet.Cells["L" + countRow].Value = "";
                        worksheet.Cells["M" + countRow].Value = "";
                        worksheet.Cells["N" + countRow].Value = idnumber;
                        worksheet.Cells["O" + countRow].Value = "";
                        worksheet.Cells["P" + countRow].Value = "";
                        worksheet.Cells["Q" + countRow].Value = "";
                        worksheet.Cells["R" + countRow].Value = positingkey;
                        worksheet.Cells["S" + countRow].Value = idnumber;
                        worksheet.Cells["T" + countRow].Value = "";
                        worksheet.Cells["U" + countRow].Value = "";
                        worksheet.Cells["V" + countRow].Value = "";
                        worksheet.Cells["W" + countRow].Value = "";
                        worksheet.Cells["X" + countRow].Value = deltacanoneivato;
                        worksheet.Cells["Y" + countRow].Value = "";
                        worksheet.Cells["Z" + countRow].Value = "";
                        worksheet.Cells["AA" + countRow].Value = "";
                        worksheet.Cells["AB" + countRow].Value = "";
                        worksheet.Cells["AC" + countRow].Value = "";
                        worksheet.Cells["AD" + countRow].Value = "";
                        worksheet.Cells["AE" + countRow].Value = "";
                        worksheet.Cells["AF" + countRow].Value = "";
                        worksheet.Cells["AG" + countRow].Value = "";
                        worksheet.Cells["AH" + countRow].Value = "";
                        worksheet.Cells["AI" + countRow].Value = resultExport.Targa + " - delta canone - " + mese + "/" + anno.ToString().Substring(2, 2);
                        worksheet.Cells["AJ" + countRow].Value = "";
                        worksheet.Cells["AK" + countRow].Value = "";
                        worksheet.Cells["AL" + countRow].Value = "";
                        worksheet.Cells["AM" + countRow].Value = "";
                        worksheet.Cells["AN" + countRow].Value = "";
                        worksheet.Cells["AO" + countRow].Value = "";
                        worksheet.Cells["AP" + countRow].Value = "";
                        worksheet.Cells["AQ" + countRow].Value = "";
                        worksheet.Cells["AR" + countRow].Value = "";
                        worksheet.Cells["AS" + countRow].Value = "";
                        worksheet.Cells["AT" + countRow].Value = "";
                        worksheet.Cells["AU" + countRow].Value = "";
                        worksheet.Cells["AV" + countRow].Value = "";
                        worksheet.Cells["AW" + countRow].Value = "";
                        worksheet.Cells["AX" + countRow].Value = denominazione;

                        countRow++;

                        worksheet.Cells["A" + countRow].Value = "";
                        worksheet.Cells["B" + countRow].Value = "";
                        worksheet.Cells["C" + countRow].Value = "";
                        worksheet.Cells["D" + countRow].Value = "";
                        worksheet.Cells["E" + countRow].Value = "";
                        worksheet.Cells["F" + countRow].Value = "";
                        worksheet.Cells["G" + countRow].Value = "";
                        worksheet.Cells["H" + countRow].Value = "";
                        worksheet.Cells["I" + countRow].Value = "";
                        worksheet.Cells["J" + countRow].Value = "";
                        worksheet.Cells["K" + countRow].Value = "";
                        worksheet.Cells["L" + countRow].Value = "";
                        worksheet.Cells["M" + countRow].Value = "";
                        worksheet.Cells["N" + countRow].Value = "";
                        worksheet.Cells["O" + countRow].Value = "";
                        worksheet.Cells["P" + countRow].Value = "";
                        worksheet.Cells["Q" + countRow].Value = "";
                        worksheet.Cells["R" + countRow].Value = positingkeydett;
                        worksheet.Cells["S" + countRow].Value = "69300012";
                        worksheet.Cells["T" + countRow].Value = "";
                        worksheet.Cells["U" + countRow].Value = "";
                        worksheet.Cells["V" + countRow].Value = "";
                        worksheet.Cells["W" + countRow].Value = "";
                        worksheet.Cells["X" + countRow].Value = deltacanone;
                        worksheet.Cells["Y" + countRow].Value = "";
                        worksheet.Cells["Z" + countRow].Value = "";
                        worksheet.Cells["AA" + countRow].Value = "RA";
                        worksheet.Cells["AB" + countRow].Value = "";
                        worksheet.Cells["AC" + countRow].Value = "";
                        worksheet.Cells["AD" + countRow].Value = "";
                        worksheet.Cells["AE" + countRow].Value = "";
                        worksheet.Cells["AF" + countRow].Value = codicecdc;
                        worksheet.Cells["AG" + countRow].Value = "";
                        worksheet.Cells["AH" + countRow].Value = "";
                        worksheet.Cells["AI" + countRow].Value = resultExport.Targa + " - delta canone - " + mese + "/" + anno.ToString().Substring(2,2);
                        worksheet.Cells["AJ" + countRow].Value = "";
                        worksheet.Cells["AK" + countRow].Value = "";
                        worksheet.Cells["AL" + countRow].Value = "";
                        worksheet.Cells["AM" + countRow].Value = "";
                        worksheet.Cells["AN" + countRow].Value = "";
                        worksheet.Cells["AO" + countRow].Value = "";
                        worksheet.Cells["AP" + countRow].Value = "";
                        worksheet.Cells["AQ" + countRow].Value = "";
                        worksheet.Cells["AR" + countRow].Value = "";
                        worksheet.Cells["AS" + countRow].Value = "";
                        worksheet.Cells["AT" + countRow].Value = "";
                        worksheet.Cells["AU" + countRow].Value = "";
                        worksheet.Cells["AV" + countRow].Value = "";
                        worksheet.Cells["AW" + countRow].Value = "";
                        worksheet.Cells["AX" + countRow].Value = denominazione;


                        countRow++;
                    }
                }

                Response.Clear();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + nomefile + ".xls");
                Response.BinaryWrite(excel.GetAsByteArray());
                Response.End();
            }
        }

        protected void btnEsporta3_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IUtilitysBL servizioUtilitys = new UtilitysBL();
            IAccountBL servizioAccount = new AccountBL();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string nomefile = "";

            string codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue);
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

            string tipodocumento = "YG";
            string positingkey = "11";
            string positingkeydett = "40";


            FileInfo newFile = new FileInfo(RequestExtensions.GetPathPhisicalApplication() + "/Repository/report/tracciato_noleggio.xlsx");

            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets[1];

                List<IContratti> dataExport = servizioContratti.SelectNoteCreditoDeltaCanone(codsocieta, UserId, mese, anno);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 8;
                    string denominazione = "";
                    string codcompany = "";
                    string codicecdc = "";
                    string idnumber = "";

                    foreach (IContratti resultExport in dataExport)
                    {
                        nomefile = "";

                        //recupero nominativo driver
                        IAccount dataU = servizioAccount.DetailId(resultExport.UserId);
                        if (dataU != null)
                        {
                            denominazione = dataU.Cognome + " " + dataU.Nome;
                            codicecdc = dataU.Codicecdc;
                            idnumber = dataU.Idnumber;
                        }

                        //tronca denominazione a 20 caratteri 
                        if (denominazione.Length > 20)
                        {
                            denominazione = denominazione.Substring(0, 20);
                        }

                        //recupero codcompany

                        IUtilitys dataS = servizioUtilitys.DetailSocietaXCodS(codsocieta);
                        if (dataU != null)
                        {
                            codcompany = dataS.Codcompany;
                            nomefile += dataS.Codcompany + "_" + dataS.Siglasocieta;
                        }
                        nomefile += "_Delta_Canone_" + mese + anno.ToString().Substring(2, 2);


                        worksheet.Cells["A" + countRow].Value = "";
                        worksheet.Cells["B" + countRow].Value = "";
                        worksheet.Cells["C" + countRow].Value = tipodocumento;
                        worksheet.Cells["D" + countRow].Value = codcompany;
                        worksheet.Cells["E" + countRow].Value = "";
                        worksheet.Cells["F" + countRow].Value = "";
                        worksheet.Cells["G" + countRow].Value = "";
                        worksheet.Cells["H" + countRow].Value = "";
                        worksheet.Cells["I" + countRow].Value = "";
                        worksheet.Cells["J" + countRow].Value = "EUR";
                        worksheet.Cells["K" + countRow].Value = "";
                        worksheet.Cells["L" + countRow].Value = "";
                        worksheet.Cells["M" + countRow].Value = "";
                        worksheet.Cells["N" + countRow].Value = idnumber;
                        worksheet.Cells["O" + countRow].Value = "";
                        worksheet.Cells["P" + countRow].Value = "";
                        worksheet.Cells["Q" + countRow].Value = "";
                        worksheet.Cells["R" + countRow].Value = positingkey;
                        worksheet.Cells["S" + countRow].Value = idnumber;
                        worksheet.Cells["T" + countRow].Value = "";
                        worksheet.Cells["U" + countRow].Value = "";
                        worksheet.Cells["V" + countRow].Value = "";
                        worksheet.Cells["W" + countRow].Value = "";
                        worksheet.Cells["X" + countRow].Value = Math.Abs((resultExport.Deltacanone * Convert.ToDecimal(1.22))).ToString("F2");
                        worksheet.Cells["Y" + countRow].Value = "";
                        worksheet.Cells["Z" + countRow].Value = "";
                        worksheet.Cells["AA" + countRow].Value = "";
                        worksheet.Cells["AB" + countRow].Value = "";
                        worksheet.Cells["AC" + countRow].Value = "";
                        worksheet.Cells["AD" + countRow].Value = "";
                        worksheet.Cells["AE" + countRow].Value = "";
                        worksheet.Cells["AF" + countRow].Value = "";
                        worksheet.Cells["AG" + countRow].Value = "";
                        worksheet.Cells["AH" + countRow].Value = "";
                        worksheet.Cells["AI" + countRow].Value = resultExport.Targa + " - delta canone - " + mese + "/" + anno.ToString().Substring(2, 2);
                        worksheet.Cells["AJ" + countRow].Value = "";
                        worksheet.Cells["AK" + countRow].Value = "";
                        worksheet.Cells["AL" + countRow].Value = "";
                        worksheet.Cells["AM" + countRow].Value = "";
                        worksheet.Cells["AN" + countRow].Value = "";
                        worksheet.Cells["AO" + countRow].Value = "";
                        worksheet.Cells["AP" + countRow].Value = "";
                        worksheet.Cells["AQ" + countRow].Value = "";
                        worksheet.Cells["AR" + countRow].Value = "";
                        worksheet.Cells["AS" + countRow].Value = "";
                        worksheet.Cells["AT" + countRow].Value = "";
                        worksheet.Cells["AU" + countRow].Value = "";
                        worksheet.Cells["AV" + countRow].Value = "";
                        worksheet.Cells["AW" + countRow].Value = "";
                        worksheet.Cells["AX" + countRow].Value = denominazione;

                        countRow++;

                        worksheet.Cells["A" + countRow].Value = "";
                        worksheet.Cells["B" + countRow].Value = "";
                        worksheet.Cells["C" + countRow].Value = "";
                        worksheet.Cells["D" + countRow].Value = "";
                        worksheet.Cells["E" + countRow].Value = "";
                        worksheet.Cells["F" + countRow].Value = "";
                        worksheet.Cells["G" + countRow].Value = "";
                        worksheet.Cells["H" + countRow].Value = "";
                        worksheet.Cells["I" + countRow].Value = "";
                        worksheet.Cells["J" + countRow].Value = "";
                        worksheet.Cells["K" + countRow].Value = "";
                        worksheet.Cells["L" + countRow].Value = "";
                        worksheet.Cells["M" + countRow].Value = "";
                        worksheet.Cells["N" + countRow].Value = "";
                        worksheet.Cells["O" + countRow].Value = "";
                        worksheet.Cells["P" + countRow].Value = "";
                        worksheet.Cells["Q" + countRow].Value = "";
                        worksheet.Cells["R" + countRow].Value = positingkeydett;
                        worksheet.Cells["S" + countRow].Value = "69300012";
                        worksheet.Cells["T" + countRow].Value = "";
                        worksheet.Cells["U" + countRow].Value = "";
                        worksheet.Cells["V" + countRow].Value = "";
                        worksheet.Cells["W" + countRow].Value = "";
                        worksheet.Cells["X" + countRow].Value = Math.Abs(resultExport.Deltacanone).ToString("F2");
                        worksheet.Cells["Y" + countRow].Value = "";
                        worksheet.Cells["Z" + countRow].Value = "";
                        worksheet.Cells["AA" + countRow].Value = "RA";
                        worksheet.Cells["AB" + countRow].Value = "";
                        worksheet.Cells["AC" + countRow].Value = "";
                        worksheet.Cells["AD" + countRow].Value = "";
                        worksheet.Cells["AE" + countRow].Value = "";
                        worksheet.Cells["AF" + countRow].Value = codicecdc;
                        worksheet.Cells["AG" + countRow].Value = "";
                        worksheet.Cells["AH" + countRow].Value = "";
                        worksheet.Cells["AI" + countRow].Value = resultExport.Targa + " - delta canone - " + mese + "/" + anno.ToString().Substring(2, 2);
                        worksheet.Cells["AJ" + countRow].Value = "";
                        worksheet.Cells["AK" + countRow].Value = "";
                        worksheet.Cells["AL" + countRow].Value = "";
                        worksheet.Cells["AM" + countRow].Value = "";
                        worksheet.Cells["AN" + countRow].Value = "";
                        worksheet.Cells["AO" + countRow].Value = "";
                        worksheet.Cells["AP" + countRow].Value = "";
                        worksheet.Cells["AQ" + countRow].Value = "";
                        worksheet.Cells["AR" + countRow].Value = "";
                        worksheet.Cells["AS" + countRow].Value = "";
                        worksheet.Cells["AT" + countRow].Value = "";
                        worksheet.Cells["AU" + countRow].Value = "";
                        worksheet.Cells["AV" + countRow].Value = "";
                        worksheet.Cells["AW" + countRow].Value = "";
                        worksheet.Cells["AX" + countRow].Value = denominazione;


                        countRow++;
                    }
                }

                Response.Clear();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + nomefile + ".xls");
                Response.BinaryWrite(excel.GetAsByteArray());
                Response.End();
            }

        }
    }
}
