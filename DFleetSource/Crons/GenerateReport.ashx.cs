// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="GenerateReport.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text;
using BusinessObject;
using BusinessLogic;
using System.Globalization;
using System.Web.Script.Serialization;
using OfficeOpenXml;
using System.IO;
using AraneaUtilities.Auth;
using AraneaUtilities.CronAsyncTasks;
using System.Data;
using DFleet.Classes;

namespace DFleet.Crons
{
    /// <summary>
    /// Summary description for GenerateReport
    /// </summary>
    public class GenerateReport : CronAsyncHandler, System.Web.SessionState.IRequiresSessionState
    {
        DataView dataview;
#pragma warning disable IDE0044 // Add readonly modifier
        Dictionary<string, string> insertTipoDatoColonne = new Dictionary<string, string>();
#pragma warning restore IDE0044 // Add readonly modifier

        protected override void ServeContent(HttpContext context)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys data = servizioUtility.DetailReportId(22); //MDM
            if (data != null)
            {
                dataview = new DataView(ReturnEstrazioneReport(data.Viewreport, "", "", "", Guid.Empty));


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
                            else if (item.Value.ToUpper() == "NVARCHAR")
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
                    byte[] bin = excel.GetAsByteArray();
                    File.WriteAllBytes(RequestExtensions.GetPathPhisicalApplication() + "/Repository/allegatimail/" + filenameexcel, bin);

                    string testo = "Report Giornaliero MTM del " + DateTime.Now.ToString("dd/MM/yyyy");
                    //invio mail con allegato file excel
                    Recuperadatiuser datiUtente = new Recuperadatiuser();
                    MailHelper.SendMail("", "michelemezzina@gmail.com", "mimezzina@deloitte.it", "", "", "", testo, testo, filenameexcel, datiUtente.ReturnObjectTenant());
                    //MailHelper.SendMail("", "web@araneamarketing.it", "", "", "", "", testo, testo, filenameexcel);


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
    }
}
