// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ImportFile.aspx.cs" company="">
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
using Microsoft.VisualBasic.FileIO;

namespace DFleet.Crons
{
    /// <summary>
    /// Summary description for ImportFileZucchetti
    /// </summary>
    public class ImportFileZucchetti : CronAsyncHandler, System.Web.SessionState.IRequiresSessionState
    {
        protected override void ServeContent(HttpContext context)
        {
            ICronBL servizioCron = new CronBL();

            string filePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";

            string path = "\\\\10.71.222.198\\Ufleet\\D4M\\DLT\\HR\\ZUCCHETTI\\";

            //recupero credenziali network
            string usernetwork = EncryptHelper.Decrypt(servizioCron.CredNetwork().Network_user, SeoHelper.PassPhrase()); //recupero user network
            string passwordnetwork = EncryptHelper.Decrypt(servizioCron.CredNetwork().Network_password, SeoHelper.PassPhrase()); //recupero pwd network

            //cancella connessioni aperte
            int result = NetworkConnection.CloseConnection("\\\\10.71.222.198\\Ufleet");

            //apre connessione
            using (new NetworkConnection(@"\\10.71.222.198\Ufleet", new NetworkCredential(usernetwork, passwordnetwork))) // "D4MService", "097!<0q)eCf<XFBm>8)^"
            {
                int idprog = 0;
                var directory = new DirectoryInfo(@path);
                FileInfo myFile = (from f in directory.GetFiles()
                                   orderby f.LastWriteTime descending
                                   select f).First();
                filePath += myFile.Name;
                path += myFile.Name;

                if (!File.Exists(@filePath)) // copia file se non è già esistente
                {
                    File.Copy(@path, @filePath);
                }


                //inserisce importazione in storico
                ICron SaveFile = new Cron
                {
                    Idtipofile = 13,
                    Nomefile = SeoHelper.EncodeString(myFile.Name),
                    Flgcron = 1,
                    Uidtenant = SeoHelper.ReturnSessionTenant()
                };

                servizioCron.InsertStoricoImportazione(SaveFile);

                //recupera ultimo idprog
                ICron dataIdp = servizioCron.UltimoIDProgImp();

                if (dataIdp != null)
                {
                    idprog = dataIdp.Idprog;
                }

                //importa tracciato anagrafica
                ICron importUpd3 = new Cron
                {
                    Righeimportate = 0,
                    Righetotali = 0,
                    Texterrori = "",
                    Idprog = idprog,
                    Importato = "IN ELABORAZIONE",
                    Dataimportazione = DateTime.Now,
                    Uidtenant = SeoHelper.ReturnSessionTenant()
                };
                servizioCron.UpdateStoricoImportazione(importUpd3);


                ImportTracciatoZucchetti(myFile.Name, idprog);
            }
        }

        public void ImportTracciatoZucchetti(string filename, int idprog)
        {
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;
            string codsocieta = "";
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            using (TextFieldParser csvParser = new TextFieldParser(filePath, Encoding.GetEncoding("iso-8859-1")))
            {
                csvParser.TextFieldType = FieldType.Delimited;
                csvParser.SetDelimiters(";");
                csvParser.HasFieldsEnclosedInQuotes = false;

                bool firstLine = true;
                int z = 2;

                var lines = File.ReadAllLines(filePath);
                righetotali = (lines.Length) - 1;

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();

                    if (firstLine)
                    {
                        firstLine = false;

                        continue;
                    }

                    string codazienda = SeoHelper.EncodeString(fields[0]);
                    string matricola = SeoHelper.EncodeString(fields[1]);
                    string idzucchetti = SeoHelper.EncodeString(fields[2]);

                    //recupero codsocieta filtrando il codazienda
                    ICron dataS = servizioCron.ReturnCodSocieta(codazienda);
                    if (dataS != null)
                    {
                        codsocieta = dataS.Codsocieta;
                    }


                    //controllo esistenza matricola e codsocieta
                    if (servizioCron.ExistMatricola(matricola, codsocieta))
                    {
                        ICron updZucc = new Cron
                        {
                            Codsocieta = codsocieta,
                            Matricola = matricola,
                            Idzucchetti = idzucchetti,
                            Uidtenant = SeoHelper.ReturnSessionTenant()
                        };

                        if (servizioCron.UpdateZucchetti(updZucc) == 1)
                        {
                            righeimportate++; //incrementa righe importate correttamente
                        }
                        else
                        {
                            errorefile += z + "; ";
                        }
                    }
                    else
                    {
                        errorefile += z + "; ";
                    }


                    ICron importUpd3 = new Cron
                    {
                        Righeimportate = righeimportate,
                        Righetotali = righetotali,
                        Texterrori = errorefile,
                        Idprog = idprog,
                        Dataimportazione = DateTime.Now,
                        Importato = "IN ELABORAZIONE",
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };
                    servizioCron.UpdateStoricoImportazione(importUpd3);


                    z++;
                }
            }

            ICron importUpd = new Cron();

            if (!string.IsNullOrEmpty(errorefile))
            {
                importUpd.Importato = "IMPORTATO CON ERRORI";
            }
            else
            {
                importUpd.Importato = "IMPORTATO CORRETTAMENTE";
            }
            importUpd.Righeimportate = righeimportate;
            importUpd.Righetotali = righetotali;
            importUpd.Texterrori = errorefile;
            importUpd.Idprog = idprog;
            importUpd.Datafineimportazione = DateTime.Now;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);
        }
    }
}
