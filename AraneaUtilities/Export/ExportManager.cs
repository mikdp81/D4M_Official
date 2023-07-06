// ***********************************************************************
// Assembly         : AraneaUtilities
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ExportManager.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using DataTable = System.Data.DataTable;

namespace AraneaUtilities.Export
{
    public abstract class ExportManager
    {
        private Dictionary<string, string> _joinTables = new Dictionary<string, string>(); // ENCAPSULATE FIELD BY CODEIT.RIGHT

        protected Dictionary<string, string> JoinTables
        {
            get
            {
                return _joinTables;
            }
            set
            {
                _joinTables = value;
            }
        }
        private const string SeparateValue = ";";
        private readonly List<ExportField> exportFields = new List<ExportField>();
        public string Query 
        { 
            get { return UpdateQuery(); } 
        }


        public void Add(ExportField exportField)
        {
            this.exportFields.Add(exportField);
           
        }

        public void AddAll(List<ExportField> exportFields)
        {
            this.exportFields.AddRange(exportFields);

        }

        // output file.csv
        public void ExportCsv()
        {
            this.ExportCsv(this.Query);
        }

        // output file.csv
        public void ExportCsv(string query)
        {

            // crea response
            HttpContext.Current.Response.Clear();
            //CSV
            HttpContext.Current.Response.ContentType = "text/csv";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=esporta.csv");
            HttpContext.Current.Response.Write(this.BuilderCsv(query).ToString());
            HttpContext.Current.Response.End();

        }

        private StringBuilder BuilderCsv(string query)
        {
            StringBuilder builder = new StringBuilder();
            DataTable dataSet = GetDataFromSource(query);

            // crea la riga di intestazioni 
            string csvLabelRow = CreateCsvLabelsRow();

            // crea tutte le righe dati del file CSV
            string[] csvDataRows = CreateCsvDataRows(dataSet);

            // crea e popola file csv
            builder.Append(csvLabelRow).Append("\n");
            foreach (string csvDataRow in csvDataRows)
            {
                builder.Append(csvDataRow).Append("\n");
            }

            return builder;
        }

        // output file.xlsx
        public void ExportExcel()
        {
            this.ExportExcel(this.Query);
        }

        // output file.xlsx
        public void ExportExcel(string query)
        {

            var format = new ExcelTextFormat
            {
                Delimiter = ';',
                EOL = "\n"
            };
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage(new FileInfo("export.xls"));
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("export");
            worksheet.Cells["A1"].LoadFromText(this.BuilderCsv(query).ToString(), format);

            // crea response
            HttpContext.Current.Response.Clear();
            //EXCEL
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=esporta.xlsx");
            HttpContext.Current.Response.BinaryWrite(package.GetAsByteArray());
            HttpContext.Current.Response.End();
        }

        private string CreateCsvLabelsRow()
        {
            string labelsRow = "";
            foreach (ExportField exportField in exportFields)
                labelsRow = labelsRow + SeparateValue + exportField.Label;

            // rimuovo il primo separate value superfluo
            labelsRow = labelsRow.Substring(SeparateValue.Length, labelsRow.Length - SeparateValue.Length);
            return labelsRow;
        }

        private string[] CreateCsvDataRows(DataTable dataSet)
        {

            List<string> csvRows = new List<string>();
            DataTable data = dataSet;

            //crea e accodo nel csv una riga dati per ogni label mappata
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                
                foreach(DataRow row in data.Rows)
                {
                    string csvRow = "";
                    int count = 0;
                    string value;
                    foreach (ExportField exportField in exportFields)
                    {
                        if (exportField.IsFisso)
                            value = exportField.ValoreFisso;
                        else
                        {
                            value = row[count].ToString();
                            count++;
                        }

                        csvRow = csvRow + SeparateValue + value;
                    }

                    // rimuovo il primo separate value superfluo
                    csvRow = csvRow.Substring(SeparateValue.Length, csvRow.Length - SeparateValue.Length);
                    csvRows.Add(csvRow);
                    
                };
                data.Dispose();
            }

            return csvRows.ToArray();
        }

        // restutuisce il dataTable dopo una interrogazione sul Provider
        protected abstract DataTable GetDataFromSource(string query);

        // calcola la Query usando il contenuto di listFields
        protected string UpdateQuery()
        {
            string queryFields = "";
            string queryTables = "";
            HashSet<string> tables = new HashSet<string>();
            string queryWhere = "";

            // alcuni exportField non sono legati al DB ma hanno un valoreFisso
            foreach (ExportField exportField in this.exportFields)
            {
                if(!exportField.IsFisso)
                {
                    // componiamo i campi da selezionare
                    queryFields += "," + exportField.Table + "." + exportField.Field;

                    // componiamo le tabelle da cui prelevare (previo eventuale recupero del percorso in JOIN)
                    string myTable;
                    if (this.JoinTables.ContainsKey(exportField.Table))
                    {
                        if (this.JoinTables[exportField.Table] == null)
                        {
                            myTable = exportField.Table;
                        }
                        else
                        {
                            myTable = this.JoinTables[exportField.Table];
                        }
                    }
                    else
                    {
                        myTable = exportField.Table;
                    }

                    if (tables.Add(myTable))
                        queryTables += " " + myTable;

                    // componiamo la parte WHERE
                    queryWhere += " " + exportField.Where;
                }

                queryWhere = queryWhere.Trim();
            }
            // query finale
            string query = "SELECT " + queryFields.Substring(1) + " FROM " + queryTables.Substring(1);
            if(queryWhere.Length != 0)
                query = query + " WHERE " + queryWhere;
            
            return query;
        }

        
    }
}
