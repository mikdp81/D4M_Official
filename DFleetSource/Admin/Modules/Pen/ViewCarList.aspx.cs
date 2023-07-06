// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewCarList.aspx.cs" company="">
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
    public partial class ViewCarList : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(73)) //controllo se la pagina è autorizzata per l'utente 
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
        public void loadPage()
        {
            ICarsBL servizioCar = new CarsBL();
            pnlMessage.Visible = false;
            string codcarlist = SeoHelper.EncodeString(ddlCodice.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioCar.SelectCountViewCarList(codsocieta, codcarlist, Uidtenant);

            if (gvRicCarList.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicCarList.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            lblNumRecord.Text = "Car List: " + HttpUtility.HtmlEncode(totaleRighe);           
        }

        protected void btnSvuotaFiltri_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCarList");
        }

        

        /********************** ESPORTA EXCEL **********************/

        protected void btnEsporta_Click(object sender, EventArgs e)
        {
            ICarsBL servizioCar = new CarsBL();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excel = new ExcelPackage())
            {
                string namesheet = "ReportCarList-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

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
                worksheet.Cells["A1"].Value = "CarList";
                worksheet.Cells["B1"].Value = "CarPolicy";
                worksheet.Cells["C1"].Value = "Marca";
                worksheet.Cells["D1"].Value = "Modello";
                worksheet.Cells["E1"].Value = "Valido dal";
                worksheet.Cells["F1"].Value = "Valido al";

                //righe           
                string codcarlist = SeoHelper.EncodeString(ddlCodice.SelectedValue);
                string codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value);
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();

                List<ICars> dataExport = servizioCar.SelectViewCarList(codsocieta, codcarlist, Uidtenant);

                if (dataExport != null && dataExport.Count > 0)
                {
                    int countRow = 2;
                    foreach (ICars resultExport in dataExport)
                    {
                        worksheet.Cells["A" + countRow].Value = resultExport.Codcarlist;
                        worksheet.Cells["B" + countRow].Value = resultExport.Codcarpolicy;
                        worksheet.Cells["C" + countRow].Value = resultExport.Marca;
                        worksheet.Cells["D" + countRow].Value = resultExport.Modello; 
                        worksheet.Cells["E" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["E" + countRow].Value = ReturnData(resultExport.Validodal.ToString());
                        worksheet.Cells["F" + countRow].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        worksheet.Cells["F" + countRow].Value = ReturnData(resultExport.Validoal.ToString());

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
