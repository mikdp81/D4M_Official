// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="SalvaFile.aspx.cs" company="">
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
using System.Net;
using System.IO;
using AraneaUtilities.Auth;
using AraneaUtilities.CronAsyncTasks;

namespace DFleet.Crons
{
    /// <summary>
    /// Summary description for SalvaFile
    /// </summary>
    public class SalvaFile : CronAsyncHandler
    {

        protected override void ServeContent(HttpContext context)
        {
            ICronBL servizioCron = new CronBL();

            string nomefile = DateTime.Now.Day.ToString("d2") + DateTime.Now.Month.ToString("d2") + DateTime.Now.Year.ToString().Substring(2, 2) + "_fuel.csv";

            StringBuilder builder = new StringBuilder();
            builder.Append("MODELLO;IDEMPL;ANNUMBER;CODGEST;IDFUELCARD;DTSTARTVL;DTENDVL");
            builder.AppendLine();

            List<ICron> dataExport = servizioCron.SelectViewConcur();

            if (dataExport != null && dataExport.Count > 0)
            {
                foreach (ICron resultExport in dataExport)
                {
                    builder.Append(resultExport.Modello + ";" + resultExport.Matricola + ";" + resultExport.Targa + ";" + resultExport.Codservice + ";" + resultExport.Numerofuelcard + ";" + resultExport.Datainizioperiodo.ToString("dd/MM/yyyy") + ";31/12/2999");
                    builder.AppendLine();
                }
            }

            //scrive file csv
            string filePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/" + nomefile;
            string path = "\\\\10.71.222.198\\Ufleet\\D4M\\D4M\\CONCUR\\" + nomefile;

            File.WriteAllText(filePath, builder.ToString());

            //recupero credenziali network
            string usernetwork = EncryptHelper.Decrypt(servizioCron.CredNetwork().Network_user, SeoHelper.PassPhrase()); //recupero user network
            string passwordnetwork = EncryptHelper.Decrypt(servizioCron.CredNetwork().Network_password, SeoHelper.PassPhrase()); //recupero pwd network

            //cancella connessioni aperte
            int result = NetworkConnection.CloseConnection("\\\\10.71.222.198\\Ufleet");

            //apre connessione
            using (new NetworkConnection(@"\\10.71.222.198\Ufleet", new NetworkCredential(usernetwork, passwordnetwork))) // "D4MService", "097!<0q)eCf<XFBm>8)^"
            {
                if (!File.Exists(@path)) // copia file se non è già esistente
                {
                    File.Copy(@filePath, @path);
                }
            }

        }
    }
}
