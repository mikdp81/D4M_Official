// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="Report.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Security.Permissions;
using System.Threading;
using System.Web.Security;
using BusinessLogic;
using BusinessObject;
using System.Globalization;
using System.Collections.Generic;
using DFleet.Classes;
using OfficeOpenXml;
using System.Data;
using System.Linq;
using System.IO;

namespace DFleet.Admin.Modules.Dash
{

    public partial class Report : System.Web.UI.Page
    {
        DataView dataview;
#pragma warning disable IDE0044 // Add readonly modifier
        Dictionary<string, string> insertTipoDatoColonne = new Dictionary<string, string>();
#pragma warning restore IDE0044 // Add readonly modifier
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(48)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            codsocieta.Visible = false;
            codgrade.Visible = false;
            codfornitore.Visible = false;
            driver.Visible = false;
            btnCerca.Visible = false;
        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            int idreport = SeoHelper.IntString(ddlReport.SelectedValue);
            string codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue);
            string codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
            string codfornitore = SeoHelper.EncodeString(ddlCodFornitore.SelectedValue);
            Guid UserId = SeoHelper.GuidString(ddlUsers.SelectedValue);

            IUtilitys data = servizioUtility.DetailReportId(idreport);
            if (data != null)
            {
                dataview = new DataView(ReturnEstrazioneReport(data.Viewreport, codsocieta, codgrade, codfornitore, UserId));


                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                FileInfo newFile = new FileInfo(RequestExtensions.GetPathPhisicalApplication() + "/Repository/report/" + data.Fileexcel);

                using (ExcelPackage excel = new ExcelPackage(newFile))
                {
                    string namesheet = "Report_" + data.Viewreport + "_" + SeoHelper.OraAttuale();
                    int incrementoriga = 1;
                    int rigaintestazione = 1;
                    int rigapartenza = 1;

                    ExcelWorksheet worksheet = excel.Workbook.Worksheets[0];

                    //titoli intestazione
                    int countCol = 1;

                    //rinomina file
                    string filenameexcel;

                    if (data.Nomereport.ToUpper() == "MDM")
                    {
                        filenameexcel = data.Fileexcel.Replace(".xlsx", "") + "_" + SeoHelper.OraAttuale() + ".xlsx";
                        rigaintestazione = 3;
                        rigapartenza = 3;
                    }
                    else
                    {
                        filenameexcel = data.Fileexcel.Replace(".xlsx", "") + "_" + SeoHelper.OraAttuale() + ".xlsx";
                    }



                    List<IUtilitys> dataNameTbl = servizioUtility.FieldReportExcel(data.Viewreport);

                    if (dataNameTbl != null && dataNameTbl.Count > 0)
                    {
                        foreach (IUtilitys result in dataNameTbl)
                        {
                            worksheet.Cells[rigaintestazione, countCol].Value = result.Column;

                            countCol++;
                        }
                    }

                    //int numcelle = 1 + dataview.Count;
                    int numcelle = dataview.Count;





                    //righe
                    for (int i = rigapartenza; i < numcelle; i++)
                    {
                        for (int y = 0; y < insertTipoDatoColonne.Count(); y++)
                        {

                            string displayText = dataview[i][y].ToString();

                            var item = insertTipoDatoColonne.ElementAt(y);
                            if (item.Value.ToUpper() == "DECIMAL" || item.Value.ToUpper() == "NUMERIC")
                            {
                                if (Decimal.TryParse(displayText, out decimal valorestringa))
                                {
                                    worksheet.Cells[i + 1, y + 1].Value = valorestringa;
                                    worksheet.Cells[i + 1, y + 1].Style.Numberformat.Format = "#,###.00";
                                }
                            }
                            else if (item.Value.ToUpper() == "NVARCHAR" )
                            {
                                worksheet.Cells[i + 1, y + 1].Value = displayText;
                                worksheet.Cells[i + 1, y + 1].Style.Numberformat.Format = "dd/mm/yyyy";                               
                            }
                            else
                            {
                                worksheet.Cells[i + incrementoriga, y + 1].Value = displayText.Replace(" 00:00:00", "");
                            }
                        }
                    }


                    //salva file excel
                    //byte[] bin = excel.GetAsByteArray();
                    //File.WriteAllBytes(RequestExtensions.GetPathPhisicalApplication() + "/Repository/Deleghe/Storico/" + filenameexcel, bin);

                    Response.Clear();
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filenameexcel);
                    Response.BinaryWrite(excel.GetAsByteArray());
                    Response.End();

                }
            }
        }

        private DataTable ReturnEstrazioneReport(string viewreport, string codsocieta, string codgrade, string codfornitore, Guid UserId)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            DataTable table1 = new DataTable("ViewReport");
            DataRow dr = table1.NewRow();
            int countcolumn = 0;

            List<IUtilitys> dataNameTbl = servizioUtility.FieldReportExcel(viewreport);

            if (dataNameTbl != null && dataNameTbl.Count > 0)
            {
                foreach (IUtilitys result in dataNameTbl)
                {
                    table1.Columns.Add(result.Column);
                    dr[countcolumn] = result.Column;
                    if (!insertTipoDatoColonne.ContainsKey(countcolumn.ToString()))
                    {
                        insertTipoDatoColonne.Add(countcolumn.ToString(), result.TipoDato);
                    }
                    countcolumn++;
                }
            }

            table1.Rows.Add(dr);

            DataTable dataReport = servizioUtility.ViewEstrazioneReport(viewreport, codsocieta, codgrade, codfornitore, UserId, Uidtenant);

            if (dataReport != null)
            {
                foreach (DataRow row in dataReport.Rows)
                {
                    table1.Rows.Add(row.ItemArray);
                }
            }
            DataSet set = new DataSet("ViewReportS");
            set.Tables.Add(table1);

            return set.Tables[0];
        }

        protected void ddlReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            int idreport = SeoHelper.IntString(ddlReport.SelectedItem.Value);

            IUtilitys data = servizioUtility.DetailReportId(idreport);
            if (data != null)
            {
                btnCerca.Visible = true;

                if (data.Filtrocodsocieta.ToUpper() == "SI")
                {
                    codsocieta.Visible = true;
                }
                if (data.Filtrocodgrade.ToUpper() == "SI")
                {
                    codgrade.Visible = true;
                }
                if (data.Filtrocodfornitore.ToUpper() == "SI")
                {
                    codfornitore.Visible = true;
                }
                if (data.Filtrodriver.ToUpper() == "SI")
                {
                    driver.Visible = true;
                }
            }
        }
    }
}
