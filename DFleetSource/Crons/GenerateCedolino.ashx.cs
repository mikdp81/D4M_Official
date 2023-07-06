// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="GenerateCedolino.aspx.cs" company="">
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

namespace DFleet.Crons
{
    /// <summary>
    /// Summary description for GenerateCedolino
    /// </summary>
    public class GenerateCedolino : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ICronBL servizioCron = new CronBL();
            HttpResponse response = context.Response;
            string fileexcel = "200327_Payroll_multe_mmaa_last.xlsx";

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            FileInfo newFile = new FileInfo(RequestExtensions.GetPathPhisicalApplication() + "/Repository/Documents/" + fileexcel);

            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets[0];
                int i = 2;
                string mese = DateTime.Now.AddMonths(-1).Month.ToString();
                string anno = DateTime.Now.AddMonths(-1).Year.ToString();

                List<ICron> data = servizioCron.SelectCedolini(mese, anno);

                if (data != null && data.Count > 0)
                {
                    foreach (ICron result in data)
                    {
                        worksheet.Cells[i, 1].Value = result.Matricola; //matricola
                        worksheet.Cells[i, 2].Value = result.Cognome; //cognome
                        worksheet.Cells[i, 3].Value = result.Nome; //nome
                        worksheet.Cells[i, 4].Value = anno; //fy (anno)
                        worksheet.Cells[i, 5].Value = mese; //periodo (mese)
                        worksheet.Cells[i, 6].Value = result.Tipologiacedolino; //item (tipologia ceodlino)
                        worksheet.Cells[i, 7].Value = result.Codsocieta; //cod societa
                        worksheet.Cells[i, 8].Value = result.Societa; //denominazione societa
                        worksheet.Cells[i, 9].Value = result.Codicecdc; //cod cdc
                        worksheet.Cells[i, 10].Value = result.Targa; //targa
                        worksheet.Cells[i, 11].Value = result.Importo; //importo contravvenzione
                        i++;
                    }
                }

                //rinomina file
                string filenameexcel = SeoHelper.OraAttuale() + "-" + fileexcel;

                //salva file excel
                byte[] bin = excel.GetAsByteArray();
                File.WriteAllBytes(RequestExtensions.GetPathPhisicalApplication() + "/Repository/cedolini/" + filenameexcel, bin);


                ICron cronNew = new Cron
                {
                    Tipodocumento = "Trattenuta",
                    Pathfile = "cedolini/",
                    Nomefile = SeoHelper.EncodeString(filenameexcel),
                    Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                };
                servizioCron.InsertFileCron(cronNew);

                response.Write("File " + filenameexcel + " creato correttamente");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
