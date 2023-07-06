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

namespace DFleet.Crons
{
    /// <summary>
    /// Summary description for GenerateConcur
    /// </summary>
    public class GenerateConcur : CronAsyncHandler
    {
        protected override void ServeContent(HttpContext context)
        {

            /*IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            ICronBL servizioCron = new CronBL();
            HttpResponse response = context.Response;

            string filecsv = DateTime.Now.Day.ToString("d2") + DateTime.Now.Month.ToString("d2") + DateTime.Now.Year + "_fuel";

            StringBuilder builder = new StringBuilder();
            builder.Append("MODELLO;IDEMPL;ANNUMBER;CODGEST;IDFUELCARD;DTSTARTVL;DTENDVL");
            builder.AppendLine();


            List<IFileTracciati> dataExport = servizioFileTracciati.SelectViewConcur("","",100000,1);

            if (dataExport != null && dataExport.Count > 0)
            {
                foreach (IFileTracciati resultExport in dataExport)
                {
                    builder.Append(resultExport.Modello + ";" + resultExport.Matricola + ";" + resultExport.Targa + ";" + resultExport.Codservice + ";" + resultExport.Numerofuelcard + ";" + resultExport.Datainizioperiodo.ToString("dd/MM/yyyy") + ";31/12/2999");
                    builder.AppendLine();
                }
            }

            //salva file csv
            File.WriteAllText(RequestExtensions.GetPathPhisicalApplication() + "/Repository/export/" + filecsv, builder.ToString());

            ICron cronNew = new Cron
            {
                Tipodocumento = "Concur",
                Pathfile = "export/",
                Nomefile = SeoHelper.EncodeString(filecsv)
            };
            servizioCron.InsertFileCron(cronNew);

            response.Write("File " + filecsv + " creato correttamente"); */


            ICronBL servizioCron = new CronBL();

            string nomefile = "employee_p0605152ufwo_ITC900_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("d2") + DateTime.Now.Day.ToString("d2")
                + DateTime.Now.Hour.ToString("d2") + DateTime.Now.Minute.ToString("d2") + DateTime.Now.Second.ToString("d2") + ".txt";

            StringBuilder builder = new StringBuilder();
            builder.Append("100,0,SSO,UPDATE,EN,N,N");
            builder.AppendLine();

            //controllo sulla tabella EF_concur_900 se c'è una riga con la data di oggi
            if (!servizioCron.ExistDataConcur())
            {
                //se la data è inesistente copio la vista concur nella tabella EF_concur_900 con la data di oggi

                List<ICron> dataExport = servizioCron.SelectViewConcurTxt();

                if (dataExport != null && dataExport.Count > 0)
                {
                    foreach (ICron resultExport in dataExport)
                    {
                        //controllo variazioni per ogni riga di EF_concur_900 di oggi e verifica
                        //se rispetto alla matricola della precedente esportazione, 
                        //la voce descrizione è differente crea nuovo record con la Y
                        string descrizioneold = "";
                        string targaold = "";
                        string tipoold = "";
                        int benefitold = 0;

                        ICron data = servizioCron.DetailConcur900(resultExport.Campo2);
                        if (data != null)
                        {
                            descrizioneold = data.Descrizione;
                            tipoold = data.Campo3;
                            targaold = data.Campo4;
                            benefitold = SeoHelper.IntString(data.Campo6);
                        }

                        if ((resultExport.Campo5.ToUpper() != descrizioneold.ToUpper()) && !string.IsNullOrEmpty(descrizioneold))
                        {
                            //creo nuova riga con aggiunta y
                            ICron RowConcurNew = new Cron
                            {
                                Campo1 = resultExport.Campo1,
                                Campo2 = resultExport.Campo2,
                                Campo3 = tipoold,
                                Campo4 = targaold,
                                Campo5 = descrizioneold,
                                Benefit = benefitold,
                                Modifica = "Y",
                                Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                            };

                            servizioCron.InsertConcur900(RowConcurNew);
                        }

                        //inserimento riga in EF_concur_900
                        ICron RowConcur = new Cron
                        {
                            Campo1 = resultExport.Campo1,
                            Campo2 = resultExport.Campo2,
                            Campo3 = resultExport.Campo3,
                            Campo4 = resultExport.Campo4,
                            Campo5 = resultExport.Campo5,
                            Benefit = SeoHelper.IntString(resultExport.Campo6),
                            Modifica = "",
                            Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                        };
                        servizioCron.InsertConcur900(RowConcur);

                    }
                }
            }


            //elenco concur 900 da scaricare
            List<ICron> dataExport2 = servizioCron.SelectViewConcur900Txt();

            if (dataExport2 != null && dataExport2.Count > 0)
            {
                foreach (ICron resultExport2 in dataExport2)
                {
                    builder.Append(resultExport2.Campo1 + "," + resultExport2.Campo2 + "," + resultExport2.Campo3 + "," + resultExport2.Campo4 + "," + resultExport2.Campo5 + "," + resultExport2.Benefit + "," + resultExport2.Modifica);
                    builder.AppendLine();
                }
            }

            //salva file txt
            string filePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/" + nomefile;
            string path = "\\\\10.71.223.197\\Outbound_Concur\\" + nomefile;

            File.WriteAllText(filePath, builder.ToString());

            //recupero credenziali network
            string usernetwork = EncryptHelper.Decrypt(servizioCron.CredNetwork().Network_user, SeoHelper.PassPhrase()); //recupero user network
            string passwordnetwork = EncryptHelper.Decrypt(servizioCron.CredNetwork().Network_password, SeoHelper.PassPhrase()); //recupero pwd network

            //cancella connessioni aperte
            int result = NetworkConnection.CloseConnection("\\\\10.71.223.197\\Outbound_Concur");

            //apre connessione
            using (new NetworkConnection(@"\\10.71.223.197\Outbound_Concur", new NetworkCredential(usernetwork, passwordnetwork))) 
            {
                if (!File.Exists(@path)) // copia file se non è già esistente
                {
                    File.Copy(@filePath, @path);
                }
            }

        }


    }
}
