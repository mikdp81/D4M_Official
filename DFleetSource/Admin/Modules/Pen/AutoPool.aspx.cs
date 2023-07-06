// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="AutoPool.aspx.cs" company="">
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
    public partial class AutoPool : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(54)) //controllo se la pagina è autorizzata per l'utente 
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
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;
            string search = SeoHelper.EncodeString(txtSearch.Text);
            string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            int idstatuspool = SeoHelper.IntString(ddlStatusPool.SelectedValue);
            string luogo = SeoHelper.EncodeString(txtLuogo.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountCarPolicyPoolTeamAppr(search, codsocieta, targa, idstatuspool, luogo, Uidtenant);
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


            if (gvRicCarListPool.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicCarListPool.HeaderRow.TableSection = TableRowSection.TableHeader;
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


            lblNumRecord.Text = "Auto in Pool: " + HttpUtility.HtmlEncode(totaleRighe);
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
            Response.Redirect("AutoPool");
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
            string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            int idstatuspool = SeoHelper.IntString(ddlStatusPool.SelectedValue);
            string luogo = SeoHelper.EncodeString(txtLuogo.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountCarPolicyPoolTeamAppr(search, codsocieta, targa, idstatuspool, luogo, Uidtenant);
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
            string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            int idstatuspool = SeoHelper.IntString(ddlStatusPool.SelectedValue);
            string luogo = SeoHelper.EncodeString(txtLuogo.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountCarPolicyPoolTeamAppr(search, codsocieta, targa, idstatuspool, luogo, Uidtenant);
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

            FileInfo newFile = new FileInfo(RequestExtensions.GetPathPhisicalApplication() + "/Repository/report/report-auto-pool-function.xlsx");

            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                string namesheet = "ReportAutoInPool-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

                ExcelWorksheet worksheet = excel.Workbook.Worksheets[0];

                //intestazione
                var allCells = worksheet.Cells[1, 1, 200, 16];
                var cellFont = allCells.Style.Font;
                float fontSize = 10.0f; // Provide the appropriate value for the font size
                cellFont.SetFromFont("Arial", fontSize, true, false, false, false);

                //titoli intestazione
                worksheet.Cells["A1"].Value = "Società";
                worksheet.Cells["B1"].Value = "Targa";
                worksheet.Cells["C1"].Value = "Carpolicy";
                worksheet.Cells["D1"].Value = "Fornitore";
                worksheet.Cells["E1"].Value = "Modello";
                worksheet.Cells["F1"].Value = "Alimentazione";
                worksheet.Cells["G1"].Value = "Cambio";
                worksheet.Cells["H1"].Value = "Colore";
                worksheet.Cells["I1"].Value = "Emissioni";
                worksheet.Cells["J1"].Value = "Fringe";
                worksheet.Cells["K1"].Value = "Canone leasing";
                worksheet.Cells["L1"].Value = "Km percorsi";
                worksheet.Cells["M1"].Value = "Km contratto";
                worksheet.Cells["N1"].Value = "Data contratto";
                worksheet.Cells["O1"].Value = "Data scadenza";
                worksheet.Cells["P1"].Value = "Ex Driver";
                worksheet.Cells["Q1"].Value = "Disponibile dal";
                worksheet.Cells["R1"].Value = "Assegnatario";
                worksheet.Cells["S1"].Value = "Solo già assegnatari";
                worksheet.Cells["T1"].Value = "Luogo consegna";
                worksheet.Cells["U1"].Value = "Condizione";
                worksheet.Cells["V1"].Value = "Status";
                worksheet.Cells["W1"].Value = "Note";

                //righe 
                string search = SeoHelper.EncodeString(txtSearch.Text);
                string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
                string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
                int idstatuspool = SeoHelper.IntString(ddlStatusPool.SelectedValue);

                List<IContratti> dataExport = servizioContratti.SelectViewCarPolicyPoolTeamAppr(search, codsocieta, targa, idstatuspool);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (IContratti resultExport in dataExport)
                    {
                        string checkassegnatario = "";

                        if (resultExport.Checkassegnatario == 1)
                        {
                            checkassegnatario = "SI";
                        }
                        else
                        {
                            checkassegnatario = "NO";
                        }

                        worksheet.Cells["A" + countRow].Value = resultExport.Societa;
                        worksheet.Cells["B" + countRow].Value = resultExport.Targa;
                        worksheet.Cells["C" + countRow].Value = resultExport.Codcarpolicy;
                        worksheet.Cells["D" + countRow].Value = resultExport.Codfornitore;
                        worksheet.Cells["E" + countRow].Value = resultExport.Modello;
                        worksheet.Cells["F" + countRow].Value = resultExport.Alimentazione;
                        worksheet.Cells["G" + countRow].Value = resultExport.Cambio;
                        worksheet.Cells["H" + countRow].Value = resultExport.Codoptional;
                        worksheet.Cells["I" + countRow].Value = resultExport.Emissioni;
                        worksheet.Cells["J" + countRow].Value = resultExport.Fringebenefit;
                        worksheet.Cells["K" + countRow].Value = resultExport.Canoneleasing;
                        worksheet.Cells["L" + countRow].Value = resultExport.Kmpercorsi.ToString("F2");
                        worksheet.Cells["M" + countRow].Value = resultExport.Kmcontratto.ToString("F2");
                        worksheet.Cells["N" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["N" + countRow].Value = resultExport.Datacontratto;
                        worksheet.Cells["O" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["O" + countRow].Value = resultExport.Datafinecontratto;
                        worksheet.Cells["P" + countRow].Value = resultExport.Cognome;
                        worksheet.Cells["Q" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["Q" + countRow].Value = resultExport.Assegnatodal;
                        worksheet.Cells["R" + countRow].Value = resultExport.Denominazione;
                        worksheet.Cells["S" + countRow].Value = checkassegnatario;
                        worksheet.Cells["T" + countRow].Value = resultExport.Luogoconsegna;
                        worksheet.Cells["U" + countRow].Value = resultExport.Statoauto;
                        worksheet.Cells["V" + countRow].Value = resultExport.Statuspool;
                        worksheet.Cells["W" + countRow].Value = resultExport.Notepool;

                        countRow++;
                    }
                }

                Response.Clear();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=report-auto-pool-function.xlsx");
                Response.BinaryWrite(excel.GetAsByteArray());
                Response.End();
            }
        }

        /********************** FINE ESPORTA EXCEL **********************/

        public string ReturnCodSocieta()
        {
            IAccountBL servizioAccount = new AccountBL();
            string retVal = string.Empty;

            IAccount dataId = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
            if (dataId != null)
            {
                retVal = dataId.Codsocieta;
            }

            return retVal;
        }

        public string ReturnVisual(string checkordinepool)
        {
            string retVal;

            if (checkordinepool == "0")
            {
                retVal = "NO";
            }
            else
            {
                retVal = "SI";
            }

            return retVal;
        }
        public string ReturnOpzionata(string statuspool, string denominazione)
        {
            string retVal;

            if (statuspool.ToUpper() == "OPZIONATA")
            {
                retVal = "SI <br /> " + denominazione;
            }
            else
            {
                retVal = "NO";
            }

            return retVal;
        }
    }
}
