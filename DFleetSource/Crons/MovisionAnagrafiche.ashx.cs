// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="GenerateConcur.aspx.cs" company="">
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
using System.Net;
using BusinessLogic.Services.blob;

namespace DFleet.Crons
{
    /// <summary>
    /// Summary description for MovisionAnagrafiche
    /// </summary>
    public class MovisionAnagrafiche : CronAsyncHandler2
    {

        protected override void ServeContent(HttpContext context)
        {
            ICronBL servizioCron = new CronBL();
            string filecsv = "report_movesion_anagrafiche.csv";
            string newFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("d2") + DateTime.Now.Day.ToString("d2") + filecsv;

            //sposta il file report_movesion_benefit in blob movesionarchivio
            string containerName = "movesion";
            string blobName = "movesion";
            string blobNameDest = "movesionarchivio";
            string fileName = filecsv;
            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
            string sas = Global.sas;

            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
            azureBlobManager.MoveAndRenameFile(sas, fileName, newFile, blobName, blobNameDest);


            //creo file csv
            StringBuilder builder = new StringBuilder();
            builder.Append("Matricola;Codice Azienda;IdZucchetti;Cognome;Nome;Email;Username;CodiceFiscale;Stato");
            builder.AppendLine();

            List<ICron> dataExport = servizioCron.SelectViewMovisionAnagrafiche();

            if (dataExport != null && dataExport.Count > 0)
            {
                foreach (ICron resultExport in dataExport)
                {
                    builder.Append(resultExport.Matricola + ";" + resultExport.Codsocieta + ";" + resultExport.Idzucchetti + ";" + resultExport.Cognome + ";" + resultExport.Nome + ";" + 
                                    resultExport.Email + ";" + resultExport.Username + ";" + resultExport.Codicefiscale + ";" + resultExport.Stato);
                    builder.AppendLine();
                }
            }

            //salva file csv su cartella temp
            File.WriteAllText(RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/" + filecsv, builder.ToString());


            //salva file csv sul blob movesion
            string containerNameUp = "movesion";
            string blobNameUp = filecsv;
            string fileNameUp = filecsv;
            string fileSourcePathUp = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
            string fileTargetPathUp = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
            string sasUp = Global.sas;

            AzureBlobManager azureBlobManagerUp = new AzureBlobManager(sasUp, fileSourcePathUp, fileTargetPathUp, containerNameUp);
            string resultUp = azureBlobManagerUp.UploadBlob(fileNameUp, blobNameUp, true); // salva file nella cartella movesion

            context.Response.Write(resultUp);

        }


    }
}
