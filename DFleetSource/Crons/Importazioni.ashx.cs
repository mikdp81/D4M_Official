// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Importazioni.aspx.cs" company="">
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
using BusinessLogic.Services.blob;
using ExcelDataReader;
using System.Xml;
using Microsoft.VisualBasic.FileIO;
using System.Security.Principal;
using System.Threading;
using DFleet.Classes;
using AraneaUtilities.Auth.Roles;

namespace DFleet.Crons
{
    /// <summary>
    /// Summary description for Importazioni
    /// </summary>
    public class Importazioni : CronAsyncHandler2, System.Web.SessionState.IRequiresSessionState
    {

        protected override void ServeContent(HttpContext context)
        {
            ICronBL servizioCron = new CronBL();

            int idprog = SeoHelper.IntString(context.Request["idprog"].ToString(CultureInfo.CurrentCulture));

            ICron data = servizioCron.DetailImportazioni(idprog);

            if (data != null)
            {
                //scarica file dal blob
                string containerName = "import";
                string blobName = data.Nomefile;
                string fileName = data.Nomefile;
                string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
                string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
                string sas = Global.sas;
                AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                string result = azureBlobManager.DownloadBlob(fileName, blobName, true);
                //string result = "PARTIAL CONTENT";

                if (result.ToUpper() == "PARTIAL CONTENT")
                {
                    switch (data.Idtipofile)
                    {
                        case 1: //Tracciato Carburante ENI
                            ImportTracciatoCarburanteENI(data.Nomefile, data.UserIDIns, idprog);
                            break;

                        case 2: //Tracciato Carburante IP
                            ImportTracciatoCarburanteIP(data.Nomefile, data.UserIDIns, idprog);
                            break;

                        case 3: //Tracciato Fringe Benefit ACI
                            ImportTracciatoFringeBenefit(data.Nomefile, data.UserIDIns, data.Periododal.ToString("dd/MM/yyyy"), data.Periodoal.ToString("dd/MM/yyyy"), idprog);
                            break;

                        case 4: //Tracciato Fattura
                            ImportTracciatoFattura(data.Nomefile, data.UserIDIns, idprog);
                            break;

                        case 5: //Tracciato Anagrafiche
                            ImportTracciatoAnagrafica(data.Nomefile, data.UserIDIns, idprog);
                            break;

                        case 6: //Tracciato Concur
                            ImportTracciatoConcur(data.Nomefile, data.UserIDIns, idprog);
                            break;

                        case 7: //Tracciato Telepass
                            ImportTracciatoTelepass(data.Nomefile, data.UserIDIns, idprog);
                            break;

                        case 8: //Tracciato Carburante Enel X
                            ImportTracciatoCarburanteEnelX(data.Nomefile, data.UserIDIns, idprog);
                            break;

                        case 9: //Tracciato Concur Storni
                            ImportTracciatoConcurStorni(data.Nomefile, data.UserIDIns, idprog);
                            break;

                        case 10: //Tracciato Concur Fuel
                            ImportTracciatoConcurFuel(data.Nomefile, data.UserIDIns, idprog);
                            break;

                        case 11: //Invio Email
                            ImportInvioEmail(data.Nomefile, idprog, data.Idtemplate);
                            break;

                        case 12: //Tracciato FuelCard
                            ImportTracciatoFuelCard(data.Nomefile, data.UserIDIns, idprog);
                            break;

                        case 14: //Tracciato Carburante Q8
                            ImportTracciatoCarburanteQ8(data.Nomefile, data.UserIDIns, idprog);
                            break;

                        case 15: //Tracciato Carburante DKV
                            ImportTracciatoCarburanteDKV(data.Nomefile, data.UserIDIns, idprog);
                            break;
                    }
                }
                else
                {
                    //se file non scaricato rilascia errore nella tabella importazioni storico cron
                    ICron importUpd3 = new Cron
                    {
                        Righeimportate = 0,
                        Righetotali = 0,
                        Texterrori = "ERRORE FILE NON PRESENTE.",
                        Idprog = idprog,
                        Importato = "IMPORTATO CON ERRORI",
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };
                    servizioCron.UpdateStoricoImportazione(importUpd3);
                }
            }
        }


        public void ImportTracciatoCarburanteENI(string filename, Guid UserIDIns, int idprog)
        {
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //legge file excel
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,

                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable dt = result.Tables[0];

                    righetotali = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int z = i + 2;
                        ICron traccIns = new Cron
                        {
                            Idprog = UltimoIdProg(),
                            Idtransazione = SeoHelper.EncodeString(dt.Rows[i].ItemArray[10].ToString()),
                            Codicepuntovendita = SeoHelper.EncodeString(dt.Rows[i].ItemArray[23].ToString()),
                            Ragionesociale = SeoHelper.EncodeString(dt.Rows[i].ItemArray[24].ToString()),
                            Localita = SeoHelper.EncodeString(dt.Rows[i].ItemArray[27].ToString()),
                            Indirizzo = SeoHelper.EncodeString(dt.Rows[i].ItemArray[25].ToString()),
                            Nazione = "",
                            Kmtransazione = SeoHelper.DecimalString(dt.Rows[i].ItemArray[15].ToString()),
                            Numerofuelcard = SeoHelper.EncodeString(dt.Rows[i].ItemArray[7].ToString()),
                            Targa = SeoHelper.EncodeString(dt.Rows[i].ItemArray[13].ToString()),
                            Tiporifornimento = SeoHelper.EncodeString(dt.Rows[i].ItemArray[31].ToString()),
                            Quantita = SeoHelper.DecimalString(dt.Rows[i].ItemArray[36].ToString().Replace(".", ",")),
                            Prezzo = SeoHelper.DecimalString(dt.Rows[i].ItemArray[39].ToString().Replace(".", ",")),
                            Importo = SeoHelper.DecimalString(dt.Rows[i].ItemArray[46].ToString().Replace(".", ",")),
                            Numerofattura = SeoHelper.EncodeString(dt.Rows[i].ItemArray[3].ToString()),
                            Datafattura = SeoHelper.DataString(RicavaData(dt.Rows[i].ItemArray[1].ToString())),
                            Importofinalefatturato = SeoHelper.DecimalString(dt.Rows[i].ItemArray[48].ToString().Replace(".", ",")),
                            Idcompagnia = 1,
                            UserIDIns = UserIDIns,
                            Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                        };

                        traccIns.Importoiva = (traccIns.Importo * Convert.ToDecimal(0.22));

                        DateTime datatransazione = SeoHelper.DataString(RicavaData(dt.Rows[i].ItemArray[11].ToString()) + " " + RicavaOra(dt.Rows[i].ItemArray[12].ToString()));

                        if (datatransazione <= DateTime.MinValue)
                        {
                            traccIns.Datatransazione = traccIns.Datafattura;
                        }
                        else
                        {
                            traccIns.Datatransazione = datatransazione;
                        }

                        if (!servizioCron.ExistFuelCardConsumo2(traccIns.Idtransazione, traccIns.Numerofuelcard, traccIns.Datatransazione, traccIns.Importofinalefatturato)) //controllo esistenza transazione
                        {
                            if (servizioCron.InsertFuelCardConsumo(traccIns) == 1)
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
                    }
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Idprog = idprog;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);


        }

        public void ImportTracciatoCarburanteIP(string filename, Guid UserIDIns, int idprog)
        {
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //legge file excel
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,

                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable dt = result.Tables[0];

                    righetotali = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int z = i + 2;
                        ICron traccIns = new Cron
                        {
                            Idprog = UltimoIdProg(),
                            Idtransazione = SeoHelper.EncodeString(dt.Rows[i].ItemArray[0].ToString()),
                            Codicepuntovendita = SeoHelper.EncodeString(dt.Rows[i].ItemArray[2].ToString()),
                            Ragionesociale = SeoHelper.EncodeString(dt.Rows[i].ItemArray[3].ToString()),
                            Localita = SeoHelper.EncodeString(dt.Rows[i].ItemArray[4].ToString()),
                            Indirizzo = SeoHelper.EncodeString(dt.Rows[i].ItemArray[5].ToString()),
                            Nazione = SeoHelper.EncodeString(dt.Rows[i].ItemArray[1].ToString()),
                            Kmtransazione = SeoHelper.DecimalString(dt.Rows[i].ItemArray[10].ToString()),
                            Numerofuelcard = SeoHelper.EncodeString(dt.Rows[i].ItemArray[12].ToString()),
                            Targa = SeoHelper.EncodeString(dt.Rows[i].ItemArray[13].ToString()),
                            Tiporifornimento = SeoHelper.EncodeString(dt.Rows[i].ItemArray[15].ToString()),
                            Quantita = SeoHelper.DecimalString(dt.Rows[i].ItemArray[16].ToString().Replace(".", ",")),
                            Prezzo = SeoHelper.DecimalString(dt.Rows[i].ItemArray[18].ToString().Replace(".", ",")),
                            Importo = SeoHelper.DecimalString(dt.Rows[i].ItemArray[29].ToString().Replace(".", ",")),
                            Numerofattura = SeoHelper.EncodeString(dt.Rows[i].ItemArray[23].ToString()),
                            Datafattura = SeoHelper.DataString(dt.Rows[i].ItemArray[24].ToString()),
                            Idcompagnia = 2,
                            UserIDIns = UserIDIns,
                            Uidtenant = SeoHelper.ReturnSessionTenant()
                        };

                        //decimal scontofattura = SeoHelper.DecimalString(dt.Rows[i].ItemArray[26].ToString());
                        //traccIns.Importo = (traccIns.Quantita * traccIns.Prezzo) - traccIns.Importoiva - (scontofattura / Convert.ToDecimal(1.22));

                        traccIns.Importoiva = (traccIns.Importo * Convert.ToDecimal(0.22));
                        traccIns.Importofinalefatturato = (traccIns.Importo * Convert.ToDecimal(1.22));

                        DateTime datatransazione = SeoHelper.DataString(dt.Rows[i].ItemArray[7].ToString().Replace("00:00:00", "") + " " + dt.Rows[i].ItemArray[8].ToString());

                        if (datatransazione <= DateTime.MinValue)
                        {
                            traccIns.Datatransazione = traccIns.Datafattura;
                        }
                        else
                        {
                            traccIns.Datatransazione = datatransazione;
                        }

                        if (!servizioCron.ExistFuelCardConsumo2(traccIns.Idtransazione, traccIns.Numerofuelcard, traccIns.Datatransazione, traccIns.Importofinalefatturato)) //controllo esistenza transazione
                        {
                            if (servizioCron.InsertFuelCardConsumo(traccIns) == 1)
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
                            if (servizioCron.UpdateFuelCardConsumoCount(traccIns) > 0)
                            {
                                righeimportate++; //incrementa righe importate correttamente
                            }
                            else
                            {
                                errorefile += z + "; ";
                            }
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
                    }
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);
        }

        public void ImportTracciatoFringeBenefit(string filename, Guid UserIDIns, string periododal, string periodoal, int idprog)
        {
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //legge file excel
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,

                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable dt = result.Tables[0];

                    righetotali = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int z = i + 2;
                        ICron traccIns = new Cron
                        {
                            Marca = SeoHelper.EncodeString(dt.Rows[i].ItemArray[0].ToString()),
                            Modello = SeoHelper.EncodeString(dt.Rows[i].ItemArray[1].ToString()),
                            Serie = SeoHelper.EncodeString(dt.Rows[i].ItemArray[2].ToString()),
                            Costokm = SeoHelper.DecimalString(dt.Rows[i].ItemArray[3].ToString()),
                            Fringe25 = SeoHelper.DecimalString(dt.Rows[i].ItemArray[4].ToString()),
                            Fringe30 = SeoHelper.DecimalString(dt.Rows[i].ItemArray[5].ToString()),
                            Fringe50 = SeoHelper.DecimalString(dt.Rows[i].ItemArray[6].ToString()),
                            Fringe60 = SeoHelper.DecimalString(dt.Rows[i].ItemArray[7].ToString()),
                            Periododal = SeoHelper.DataString(periododal),
                            Periodoal = SeoHelper.DataString(periodoal),
                            UserIDIns = UserIDIns,
                            Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                        };

                        ICron data = servizioCron.ExistCodjatoAuto(traccIns.Marca, traccIns.Modello, traccIns.Serie);
                        if (data != null)
                        {
                            traccIns.Codjatoauto = data.Codjatoauto;
                        }
                        else
                        {
                            traccIns.Codjatoauto = "";
                        }

                        if (servizioCron.InsertFringeBenefit(traccIns) == 1)
                        {
                            righeimportate++; //incrementa righe importate correttamente
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
                    }
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);
        }



        public void ImportTracciatoFattura(string filename, Guid UserIDIns, int idprog)
        {
            string tipodocumento = "";
            string divisa = "";
            DateTime datadocumento = DateTime.MinValue;
            string codfornitore = "";
            string fornitore = "";
            string codcommittente = "";
            string committente = "";
            string numerodocumento = "";
            decimal importototale = 0;
            string numerocontratto = "";
            DateTime datacontratto = DateTime.MinValue;
            decimal importopagamento = 0;
            DateTime datascadenzapagamento = DateTime.MinValue;
            Guid Uidfattura = Guid.Empty;
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            ICronBL servizioCron = new CronBL();

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;


            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            /*XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("xmlns:ds", "http://www.w3.org/2000/09/xmldsig#");
            nsmgr.AddNamespace("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");*/

            XmlElement root = doc.DocumentElement;

            XmlNodeList xnl = root.SelectNodes("FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento");
            foreach (XmlNode node in xnl)
            {
                if (node["TipoDocumento"] != null)
                {
                    tipodocumento = node["TipoDocumento"].InnerText.ToString();
                }
                if (node["Divisa"] != null)
                {
                    divisa = node["Divisa"].InnerText.ToString();
                }
                if (node["Data"] != null)
                {
                    datadocumento = ReturnFormatData(node["Data"].InnerText);
                }
                if (node["Numero"] != null)
                {
                    numerodocumento = node["Numero"].InnerText;
                }
                if (node["ImportoTotaleDocumento"] != null)
                {
                    importototale = SeoHelper.DecimalString(node["ImportoTotaleDocumento"].InnerText.Replace(".", ","));
                }
            }

            XmlNodeList xnl1 = root.SelectNodes("FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/IdFiscaleIVA");
            foreach (XmlNode node1 in xnl1)
            {
                if (node1["IdCodice"] != null)
                {
                    codfornitore = node1["IdCodice"].InnerText;
                }
            }

            XmlNodeList xnl2 = root.SelectNodes("FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica");
            foreach (XmlNode node2 in xnl2)
            {
                if (node2["Denominazione"] != null)
                {
                    fornitore = node2["Denominazione"].InnerText;
                }
            }

            XmlNodeList xnl3 = root.SelectNodes("FatturaElettronicaHeader/CessionarioCommittente/DatiAnagrafici/IdFiscaleIVA");
            foreach (XmlNode node3 in xnl3)
            {
                if (node3["IdCodice"] != null)
                {
                    codcommittente = node3["IdCodice"].InnerText;
                }
            }

            XmlNodeList xnl4 = root.SelectNodes("FatturaElettronicaHeader/CessionarioCommittente/DatiAnagrafici/Anagrafica");
            foreach (XmlNode node4 in xnl4)
            {
                if (node4["Denominazione"] != null)
                {
                    committente = node4["Denominazione"].InnerText;
                }
            }

            XmlNodeList xnl5 = root.SelectNodes("FatturaElettronicaBody/DatiGenerali/DatiContratto");
            foreach (XmlNode node5 in xnl5)
            {
                if (node5["IdDocumento"] != null)
                {
                    numerocontratto = node5["IdDocumento"].InnerText;
                }
                if (node5["Data"] != null)
                {
                    datacontratto = ReturnFormatData(node5["Data"].InnerText);
                }
            }

            XmlNodeList xnl6 = root.SelectNodes("FatturaElettronicaBody/DatiPagamento/DettaglioPagamento");
            foreach (XmlNode node6 in xnl6)
            {
                if (node6["ImportoPagamento"] != null)
                {
                    importopagamento = SeoHelper.DecimalString(node6["ImportoPagamento"].InnerText.Replace(".", ","));
                }
                if (node6["DataScadenzaPagamento"] != null)
                {
                    datascadenzapagamento = ReturnFormatData(node6["DataScadenzaPagamento"].InnerText);
                }
            }

            //inserimento dati in tabella fatturexml
            ICron traccIns = new Cron
            {
                Tipodocumento = SeoHelper.EncodeString(tipodocumento),
                Divisa = SeoHelper.EncodeString(divisa),
                Datadocumento = datadocumento,
                Numerodocumento = SeoHelper.EncodeString(numerodocumento),
                Importototale = importototale,
                Fornitore = SeoHelper.EncodeString(fornitore),
                Codfornitore = SeoHelper.EncodeString(codfornitore),
                Committente = SeoHelper.EncodeString(committente),
                Codcommittente = SeoHelper.EncodeString(codcommittente),
                Numerocontratto = SeoHelper.EncodeString(numerocontratto),
                Datacontratto = datacontratto,
                Importopagamento = importopagamento,
                Datascadenzapagamento = datascadenzapagamento,
                Filexml = filename,
                UserIDIns = UserIDIns,
                Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
            };

            if (!servizioCron.ExistFattura(traccIns.Codfornitore, traccIns.Numerodocumento, traccIns.Datadocumento)) //controllo esistenza fattura (se non esiste inserisce)
            {

                servizioCron.InsertFattureXML(traccIns);

                //recupero uidfattura appena creato
                ICron data = servizioCron.UltimoUidFattura();
                if (data != null)
                {
                    Uidfattura = data.Uid;
                }


                int countDett;

                if (traccIns.Fornitore.ToUpper() == "ALPHABET ITALIA S.P.A." || traccIns.Fornitore.ToUpper() == "ALPHABET ITALIA FLEET MANAGEMENT S.P.A.")
                {
                    countDett = 4;
                }
                else
                {
                    countDett = 1;
                }

                int z = 1;
                XmlNodeList xnl7 = root.SelectNodes("FatturaElettronicaBody/DatiBeniServizi/DettaglioLinee");
                righetotali = xnl7.Count;
                foreach (XmlNode node7 in xnl7)
                {
                    //inserimento dati in tabella fatturexml_dettaglio
                    ICron traccDIns = new Cron
                    {
                        Uidfattura = Uidfattura,
                        Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                    };
                    if (node7["NumeroLinea"] != null)
                    {
                        traccDIns.Numerolionea = SeoHelper.IntString(node7["NumeroLinea"].InnerText);
                    }

                    if (node7["Descrizione"] != null)
                    {
                        traccDIns.Descrizione = node7["Descrizione"].InnerText;
                    }

                    if (node7["Quantita"] != null)
                    {
                        traccDIns.QuantitaP = SeoHelper.IntString(node7["Quantita"].InnerText.Replace(".00", ""));
                    }
                    else
                    {
                        traccDIns.QuantitaP = 1;
                    }

                    if (node7["PrezzoUnitario"] != null)
                    {
                        traccDIns.Prezzoun = SeoHelper.DecimalString(node7["PrezzoUnitario"].InnerText.Replace(".", ","));
                    }

                    if (node7["PrezzoTotale"] != null)
                    {
                        traccDIns.Prezzotot = SeoHelper.DecimalString(node7["PrezzoTotale"].InnerText.Replace(".", ","));
                    }

                    if (node7["AliquotaIVA"] != null)
                    {
                        traccDIns.Iva = SeoHelper.DecimalString(node7["AliquotaIVA"].InnerText.Replace(".", ","));
                    }

                    if (node7["DataInizioPeriodo"] != null)
                    {
                        traccDIns.Datainizioperiodo = ReturnFormatData(node7["DataInizioPeriodo"].InnerText);
                    }
                    else
                    {
                        traccDIns.Datainizioperiodo = DateTime.MinValue;
                    }

                    if (node7["DataFinePeriodo"] != null)
                    {
                        traccDIns.Datafineperiodo = ReturnFormatData(node7["DataFinePeriodo"].InnerText);
                    }
                    else
                    {
                        traccDIns.Datafineperiodo = DateTime.MinValue;
                    }

                    if (node7["Natura"] != null)
                    {
                        traccDIns.Naturaiva = node7["Natura"].InnerText;
                    }


                    traccDIns.Tipodato = "";
                    traccDIns.Riftesto = "";

                    int countlinee = 1;
                    XmlNodeList xnl7a = root.SelectNodes("FatturaElettronicaBody/DatiBeniServizi/DettaglioLinee[NumeroLinea=" + countDett + "]/AltriDatiGestionali");
                    foreach (XmlNode node7a in xnl7a)
                    {
                        if (node7a["TipoDato"] != null)
                        {
                            traccDIns.Tipodato += node7a["TipoDato"].InnerText + "***";
                        }
                        if (node7a["RiferimentoTesto"] != null)
                        {
                            traccDIns.Riftesto += node7a["RiferimentoTesto"].InnerText + "***";
                        }
                        countlinee++;
                    }

                    traccDIns.Centrocostoabb = "";
                    traccDIns.Tipocentrocosto = "";
                    traccDIns.Centrocostoabb2 = "";
                    traccDIns.Tipocentrocosto2 = "";
                    traccDIns.UserIDIns = UserIDIns;

                    if (servizioCron.InsertFattureXMLDettaglio(traccDIns) == 1)
                    {
                        righeimportate++; //incrementa righe importate correttamente
                    }
                    else
                    {
                        errorefile += z + "; ";
                    }

                    if (traccIns.Fornitore.ToUpper() == "ALPHABET ITALIA S.P.A." || traccIns.Fornitore.ToUpper() == "ALPHABET ITALIA FLEET MANAGEMENT S.P.A.")
                    {
                        countDett += countlinee;
                    }
                    else
                    {
                        countDett++;
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
            else
            {
                errorefile += "Fattura già esistente";
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);
        }




        public void ImportTracciatoAnagrafica(string filename, Guid UserIDIns, int idprog)
        {
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            //selezionare i dimissionari del mese precedente e cambiare la mail aggiungendo il suffisso ex,
            //in users e anche in membership, inoltre portare l'utente dimissionario in status sospeso
            
            List<ICron> dataDim = servizioCron.SelectUsersDimissionariAttivi();

            if (dataDim != null && dataDim.Count > 0)
            {
                foreach (ICron resultDim in dataDim)
                {
                    ICron accountNew = new Cron
                    {
                        Email = "ex_" + SeoHelper.EncodeString(resultDim.Email),
                        UserId = resultDim.UserId,
                        UserIDIns = UserIDIns,
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };

                    if (servizioCron.UpdateEmail(accountNew) == 1)
                    {
                        if (!string.IsNullOrEmpty(accountNew.Email))
                        {
                            MembershipUserCollection utenti = Membership.FindUsersByEmail(SeoHelper.EncodeString(resultDim.Email));
                            if (utenti.Count > 0)
                            {
                                servizioCron.UpdateUserNameMembership2(accountNew.Email, accountNew.Email.ToLower(), resultDim.Email);
                                servizioCron.UpdateUserNameMembership(accountNew.Email, accountNew.Email.ToLower(), resultDim.Email);
                            }
                        }
                    }
                }
            }
            //fine
            


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

                    string persontype = fields[38];
                    string[] arraypt = persontype.Split('-');

                    string gradecode = fields[6];
                    string[] arraygc = gradecode.Split('-');

                    string provinciares = fields[22];
                    string[] arraypr = provinciares.Split('-');

                    //controlli lunghezza stringa provincia
                    string provincianascita = "";
                    string provinciaresidenza = "";
                    if (fields[18].Length > 3)
                    {
                        provincianascita = SeoHelper.EncodeString(fields[18].Substring(0, 3));
                    }
                    else
                    {
                        provincianascita = SeoHelper.EncodeString(fields[18]);
                    }
                    if (arraypr[0].Trim().Length > 3)
                    {
                        provinciaresidenza = SeoHelper.EncodeString(arraypr[0].Trim().Substring(0, 3));
                    }
                    else
                    {
                        provinciaresidenza = SeoHelper.EncodeString(arraypr[0].Trim());
                    }

                    ICron accountNew = new Cron
                    {
                        Codsocieta = ReturnCodSocieta(fields[0]),
                        Cognome = SeoHelper.EncodeString(fields[1]),
                        Nome = SeoHelper.EncodeString(fields[2]),
                        Matricola = SeoHelper.EncodeString(fields[3]),
                        Idnumber = SeoHelper.EncodeString(fields[4]),
                        Idtipodriver = SeoHelper.IntString(fields[5]),
                        Funzione = SeoHelper.EncodeString(fields[6]),
                        Maternita = SeoHelper.EncodeString(fields[7]),
                        Cellulare = SeoHelper.EncodeString(fields[8]),
                        Email = SeoHelper.EncodeString(fields[9]),
                        Dataassunzione = SeoHelper.DataString(fields[10]),
                        Codicecdc = SeoHelper.EncodeString(fields[11]),
                        Descrizionecdc = SeoHelper.EncodeString(fields[12]),
                        Codicesede = SeoHelper.EncodeString(fields[14]),
                        Descrizionesede = SeoHelper.EncodeString(fields[15]),
                        Datanascita = SeoHelper.DataString(fields[16]),
                        Luogonascita = SeoHelper.EncodeString(fields[17]),
                        Provincianascita = provincianascita,
                        Codicefiscale = SeoHelper.EncodeString(fields[19]),
                        Indirizzoresidenza = SeoHelper.EncodeString(fields[20]),
                        Localitaresidenza = SeoHelper.EncodeString(fields[21]),
                        Provinciaresidenza = provinciaresidenza,
                        Capresidenza = SeoHelper.EncodeString(fields[23]),
                        Nrpatente = SeoHelper.EncodeString(fields[24]),
                        Dataemissione = SeoHelper.DataString(fields[25]),
                        Datascadenza = SeoHelper.DataString(fields[26]),
                        Ufficioemittente = SeoHelper.EncodeString(fields[27]),
                        Matricolaapprovatore = SeoHelper.EncodeString(fields[28]),
                        Codicesocietaapprovatore = SeoHelper.EncodeString(fields[29]),
                        Datainiziovalidita = SeoHelper.DataString(fields[30]),
                        Codicesettore = SeoHelper.EncodeString(fields[31]),
                        Descrizionesettore = SeoHelper.EncodeString(fields[32]),
                        Descrizioneapprovatore = SeoHelper.EncodeString(fields[33]),
                        Emailapprovatore = SeoHelper.EncodeString(fields[34]),
                        Dataprevistadimissione = SeoHelper.DataString(fields[35]),
                        Datadimissioni = SeoHelper.DataString(fields[36]),
                        Gradecode = SeoHelper.EncodeString(arraygc[0].Trim()),
                        Persontype = SeoHelper.EncodeString(arraypt[0].Trim()),
                        Indirizzosede = SeoHelper.EncodeString(fields[39]),
                        Cittasede = SeoHelper.EncodeString(fields[40]),
                        Provinciasede = SeoHelper.EncodeString(fields[41]),
                        Capsede = SeoHelper.EncodeString(fields[42]),
                        Codicedivisione = SeoHelper.EncodeString(fields[43]),
                        Descrizionedivisione = SeoHelper.EncodeString(fields[44]),
                        Fasciaimportazione = "",
                        Annotazioni = "",
                        Codfornitore = "",
                        Flgdriver = 0,
                        Idgruppouser = 2,
                        Idstatususer = 0,
                        Flgadmin = 0,
                        UserIDIns = UserIDIns,
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };

                    if (accountNew.Gradecode == "10")
                    {
                        accountNew.Persontype = "PEQ";
                        accountNew.Idgruppouser = 4;
                    }
                    if (accountNew.Gradecode == "15")
                    {
                        accountNew.Persontype = "PAR";
                        accountNew.Idgruppouser = 4;
                    }

                    accountNew.Fasciacarpolicy = ReturnCodCarPolicy(accountNew.Codsocieta, accountNew.Gradecode); // recupero carpolicy

                    //controllo esistenza matricola, se esiste aggiorna i dati dell'utente
                    ICron data = servizioCron.ExistAnagraficaMatricola(accountNew.Matricola);
                    if (data != null)
                    {
                        //se esiste modifica dati

                        accountNew.UserId = data.UserId;

                        if (data.Idgruppouser == 1) //se amministratore
                        {
                            accountNew.Idgruppouser = 1;
                            accountNew.Flgadmin = 1;
                        }

                        if (data.Flgdriver == 1) //se flgdriver è 1
                        {
                            accountNew.Flgdriver = 1;
                        }

                        if (servizioCron.UpdateAccountCount(accountNew) > 0)
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
                        if (!string.IsNullOrEmpty(accountNew.Email))
                        {
                            Membership.CreateUser(SeoHelper.EncodeString(accountNew.Email), "Dfleet2021.", SeoHelper.EncodeString(accountNew.Email)); //crea utente

                            if (accountNew.Idgruppouser == 1) //se admin
                            {
                                // devo passare Admin
                                if (!Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin))
                                    Roles.AddUserToRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin);
                                // devo rimuovere User
                                if (Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User))
                                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User);
                                // devo rimuovere Partner
                                if (Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Partner))
                                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Partner);
                            }

                            if (accountNew.Idgruppouser == 2) //se user
                            {
                                // devo passare User
                                if (!Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User))
                                    Roles.AddUserToRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User);
                                // devo rimuovere Admin
                                if (Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin))
                                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin);
                                // devo rimuovere Partner
                                if (Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Partner))
                                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Partner);
                            }


                            if (accountNew.Idgruppouser == 4) //se partner
                            {
                                // devo passare Partner
                                if (!Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Partner))
                                    Roles.AddUserToRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Partner);
                                // devo rimuovere Admin
                                if (Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin))
                                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin);
                                // devo rimuovere User
                                if (Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User))
                                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User);
                            }

                            Guid userId = (Guid)Membership.GetUser(SeoHelper.EncodeString(accountNew.Email)).ProviderUserKey; //recupera guid utente

                            accountNew.UserId = userId;

                            if (servizioCron.InsertAccount(accountNew) == 1) //se non esiste inserisce nuova anagrafica
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);
        }






        public void ImportTracciatoConcur(string filename, Guid UserIDIns, int idprog)
        {
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //legge file excel
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,

                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable dt = result.Tables[0];

                    righetotali = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int z = i + 2;
                        Guid UserId = Guid.Empty;
                        ICron dataUid = servizioCron.ExistAnagraficaMatricola(SeoHelper.EncodeString(dt.Rows[i].ItemArray[2].ToString()));
                        if (dataUid != null)
                        {
                            UserId = dataUid.UserId;
                        }

                        ICron traccIns = new Cron
                        {
                            UserId = UserId,
                            Codcompany = SeoHelper.EncodeString(dt.Rows[i].ItemArray[3].ToString()),
                            Codservice = SeoHelper.EncodeString(dt.Rows[i].ItemArray[5].ToString()),
                            Dataspesa = SeoHelper.DataString(dt.Rows[i].ItemArray[14].ToString()),
                            Tipologiaspesa = SeoHelper.EncodeString(dt.Rows[i].ItemArray[15].ToString()),
                            Distanza = SeoHelper.DecimalString(dt.Rows[i].ItemArray[16].ToString()),
                            Rimborso = Convert.ToDecimal(0.15),
                            Importospesa = (SeoHelper.DecimalString(dt.Rows[i].ItemArray[16].ToString()) * Convert.ToDecimal(0.15)),
                            Targa = SeoHelper.EncodeString(dt.Rows[i].ItemArray[21].ToString()),
                            Importodeducibile = 0,
                            Chiave = SeoHelper.EncodeString(dt.Rows[i].ItemArray[26].ToString()),
                            Tracciato = "Car Mileage",
                            UserIDIns = UserIDIns,
                            Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                        };

                        if (traccIns.Tipologiaspesa.ToUpper() == "COMPANY CAR MILEAGE")
                        {
                            if (servizioCron.InsertConcur(traccIns) == 1)
                            {
                                righeimportate++; //incrementa righe importate correttamente
                            }
                            else
                            {
                                errorefile += z + "; ";
                            }
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
                    }
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);
        }



        public void ImportTracciatoTelepass(string filename, Guid UserIDIns, int idprog)
        {
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //legge file excel
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,

                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable dt = result.Tables[0];

                    righetotali = (dt.Rows.Count) - 15;
                    for (int i = 16; i < dt.Rows.Count; i++)
                    {
                        int z = i + 2;
                        if (!string.IsNullOrEmpty(dt.Rows[i].ItemArray[1].ToString()))
                        {
                            string datatransazione = dt.Rows[i].ItemArray[2].ToString();
                            string[] arraytr = datatransazione.Split('-');
                            string dataora = arraytr[0] + "/" + arraytr[1] + "/" + arraytr[2] + " " + arraytr[3].Replace(".", ":") + ":00";

                            ICron traccIns = new Cron
                            {
                                Dispositivo = SeoHelper.EncodeString(dt.Rows[i].ItemArray[0].ToString()),
                                Numerodispositivo = SeoHelper.EncodeString(dt.Rows[i].ItemArray[1].ToString()),
                                Dataora = SeoHelper.DataString(dataora),
                                Descrizione = SeoHelper.EncodeString(dt.Rows[i].ItemArray[3].ToString()),
                                Classe = SeoHelper.EncodeString(dt.Rows[i].ItemArray[4].ToString()),
                                Importo = SeoHelper.DecimalString(dt.Rows[i].ItemArray[5].ToString().Replace(".", ",")),
                                UserIDIns = UserIDIns,
                                Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                            };


                            if (!servizioCron.ExistTelepassConsumo(traccIns.Numerodispositivo, traccIns.Dataora)) //controllo esistenza
                            {
                                if (servizioCron.InsertTelePassConsumo(traccIns) == 1)
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
                    }
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);
        }



        public void ImportTracciatoCarburanteEnelX(string filename, Guid UserIDIns, int idprog)
        {
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //legge file excel
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,

                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable dt = result.Tables[0];

                    righetotali = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int z = i + 2;
                        ICron traccIns = new Cron
                        {
                            Idprog = UltimoIdProg(),
                            Idtransazione = SeoHelper.EncodeString(dt.Rows[i].ItemArray[18].ToString()),
                            Codicepuntovendita = "",
                            Ragionesociale = SeoHelper.EncodeString(dt.Rows[i].ItemArray[11].ToString()),
                            Localita = SeoHelper.EncodeString(dt.Rows[i].ItemArray[12].ToString()),
                            Indirizzo = "",
                            Nazione = "",
                            Kmtransazione = 0,
                            Targa = SeoHelper.EncodeString(dt.Rows[i].ItemArray[5].ToString()),
                            Tiporifornimento = SeoHelper.EncodeString(dt.Rows[i].ItemArray[13].ToString()),
                            Quantita = SeoHelper.DecimalString(dt.Rows[i].ItemArray[14].ToString().Replace(".", ",")),
                            Prezzo = SeoHelper.DecimalString(dt.Rows[i].ItemArray[15].ToString().Replace(".", ",")),
                            Importo = SeoHelper.DecimalString(dt.Rows[i].ItemArray[16].ToString().Replace(".", ",")),
                            Importofinalefatturato = SeoHelper.DecimalString(dt.Rows[i].ItemArray[17].ToString().Replace(".", ",")),                            
                            Numerofattura = "",
                            Datafattura = DateTime.MinValue,
                            Idcompagnia = 3,
                            UserIDIns = UserIDIns,
                            Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                        };

                        traccIns.Importoiva = traccIns.Importofinalefatturato - traccIns.Importo;
                        string tmpdatatransazione = dt.Rows[i].ItemArray[6].ToString();

                        DateTime datatransazione = SeoHelper.DataString(tmpdatatransazione.Replace("00:00:00", "") + " " + RicavaOra(dt.Rows[i].ItemArray[7].ToString()));

                        if (datatransazione <= DateTime.MinValue)
                        {
                            traccIns.Datatransazione = traccIns.Datafattura;
                        }
                        else
                        {
                            traccIns.Datatransazione = datatransazione;
                        }

                        //recupero numero fuelcard
                        ICron dataNF = servizioCron.DetailNumeroFuelCardEnelX(traccIns.Targa);

                        if (dataNF != null)
                        {
                            traccIns.Numerofuelcard = dataNF.Numerofuelcard;
                        }


                        if (!servizioCron.ExistFuelCardConsumo2(traccIns.Idtransazione, traccIns.Numerofuelcard, traccIns.Datatransazione, traccIns.Importofinalefatturato)) //controllo esistenza transazione
                        {
                            if (servizioCron.InsertFuelCardConsumo(traccIns) == 1)
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
                    }
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);
        }





        public void ImportTracciatoConcurStorni(string filename, Guid UserIDIns, int idprog)
        {
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //legge file excel
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,

                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable dt = result.Tables[0];

                    righetotali = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int z = i + 2;
                        Guid UserId = Guid.Empty;
                        string targa = string.Empty;
                        ICron dataUid = servizioCron.ExistAnagraficaMatricola(SeoHelper.EncodeString(dt.Rows[i].ItemArray[2].ToString()));
                        if (dataUid != null)
                        {
                            UserId = dataUid.UserId;
                        }
                        ICron dataT = servizioCron.ReturnTargaAssegnazioneXConcur(UserId, SeoHelper.DataString(dt.Rows[i].ItemArray[14].ToString()));
                        if (dataT != null)
                        {
                            targa = dataT.Targa;
                        }

                        ICron traccIns = new Cron
                        {
                            UserId = UserId,
                            Codcompany = SeoHelper.EncodeString(dt.Rows[i].ItemArray[3].ToString()),
                            Codservice = SeoHelper.EncodeString(dt.Rows[i].ItemArray[5].ToString()),
                            Dataspesa = SeoHelper.DataString(dt.Rows[i].ItemArray[14].ToString()),
                            Tipologiaspesa = SeoHelper.EncodeString(dt.Rows[i].ItemArray[15].ToString()),
                            Distanza = SeoHelper.DecimalString(dt.Rows[i].ItemArray[16].ToString()),
                            Rimborso = Convert.ToDecimal(-0.15),
                            Importospesa = (SeoHelper.DecimalString(dt.Rows[i].ItemArray[16].ToString()) * Convert.ToDecimal(-0.15)),
                            Targa = targa,
                            Importodeducibile = 0,
                            Chiave = SeoHelper.EncodeString(dt.Rows[i].ItemArray[22].ToString()),
                            Tracciato = "Storni",
                            UserIDIns = UserIDIns,
                            Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                        };

                        if (servizioCron.InsertConcur(traccIns) == 1)
                        {
                            righeimportate++; //incrementa righe importate correttamente
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
                    }
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);
        }



        public void ImportTracciatoConcurFuel(string filename, Guid UserIDIns, int idprog)
        {
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //legge file excel
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,

                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable dt = result.Tables[0];

                    righetotali = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int z = i + 2;
                        Guid UserId = Guid.Empty;
                        string targa = string.Empty;
                        ICron dataUid = servizioCron.ExistAnagraficaMatricola(SeoHelper.EncodeString(dt.Rows[i].ItemArray[2].ToString()));
                        if (dataUid != null)
                        {
                            UserId = dataUid.UserId;
                        }
                        ICron dataT = servizioCron.ReturnTargaAssegnazioneXConcur(UserId, SeoHelper.DataString(dt.Rows[i].ItemArray[14].ToString()));
                        if (dataT != null)
                        {
                            targa = dataT.Targa;
                        }

                        ICron traccIns = new Cron
                        {
                            UserId = UserId,
                            Codcompany = SeoHelper.EncodeString(dt.Rows[i].ItemArray[3].ToString()),
                            Codservice = SeoHelper.EncodeString(dt.Rows[i].ItemArray[5].ToString()),
                            Dataspesa = SeoHelper.DataString(dt.Rows[i].ItemArray[14].ToString()),
                            Tipologiaspesa = SeoHelper.EncodeString(dt.Rows[i].ItemArray[15].ToString()),
                            Distanza = SeoHelper.DecimalString(dt.Rows[i].ItemArray[16].ToString()),
                            Rimborso = Convert.ToDecimal(-1),
                            Importospesa = (SeoHelper.DecimalString(dt.Rows[i].ItemArray[16].ToString()) * Convert.ToDecimal(-1)),
                            Targa = targa,
                            Importodeducibile = 0,
                            Chiave = SeoHelper.EncodeString(dt.Rows[i].ItemArray[21].ToString()),
                            Tracciato = "Fuel",
                            UserIDIns = UserIDIns,
                            Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                        };

                        if (servizioCron.InsertConcur(traccIns) == 1)
                        {
                            righeimportate++; //incrementa righe importate correttamente
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
                    }
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);
        }





        public void ImportInvioEmail(string filename, int idprog, int idtemplate)
        {
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //legge file excel
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,

                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable dt = result.Tables[0];

                    righetotali = dt.Rows.Count;
                    
                    //inserisce tutte le mail
                    for (int x = 0; x < dt.Rows.Count; x++)
                    {
                        ICron traccIns = new Cron
                        {
                            Nome = SeoHelper.EncodeString(dt.Rows[x].ItemArray[0].ToString()),
                            Cognome = SeoHelper.EncodeString(dt.Rows[x].ItemArray[1].ToString()),
                            Matricola = SeoHelper.EncodeString(dt.Rows[x].ItemArray[2].ToString()),
                            Codsocieta = SeoHelper.EncodeString(dt.Rows[x].ItemArray[3].ToString()),
                            Codgrade = SeoHelper.EncodeString(dt.Rows[x].ItemArray[4].ToString()),
                            Email = SeoHelper.EncodeString(dt.Rows[x].ItemArray[5].ToString()),
                            Param1 = SeoHelper.EncodeString(dt.Rows[x].ItemArray[6].ToString()),
                            Param2 = SeoHelper.EncodeString(dt.Rows[x].ItemArray[7].ToString()),
                            Param3 = SeoHelper.EncodeString(dt.Rows[x].ItemArray[8].ToString()),
                            Param4 = SeoHelper.EncodeString(dt.Rows[x].ItemArray[9].ToString()),
                            Param5 = SeoHelper.EncodeString(dt.Rows[x].ItemArray[10].ToString()),
                            Param6 = SeoHelper.EncodeString(dt.Rows[x].ItemArray[11].ToString()),
                            Param7 = SeoHelper.EncodeString(dt.Rows[x].ItemArray[12].ToString()),
                            Param8 = SeoHelper.EncodeString(dt.Rows[x].ItemArray[13].ToString()),
                            Param9 = SeoHelper.EncodeString(dt.Rows[x].ItemArray[14].ToString()),
                            Param10 = SeoHelper.EncodeString(dt.Rows[x].ItemArray[15].ToString()),
                            Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                        };

                        servizioCron.InsertInvioMail(traccIns);
                    }
                }
            }
        


            //dettagli template
            ICron dataTemplate = servizioCron.ReturnTemplateEmail(idtemplate);
            if (dataTemplate != null)
            {
                string oggetto = dataTemplate.Oggetto;
                string corpo = dataTemplate.Corpo;

                bool resultMail;

                //ricerca tutte le email degli utenti ai quali inviare la mail
                List<ICron> dataUserMail = servizioCron.SelectAllUserEmail();

                if (dataUserMail != null && dataUserMail.Count > 0)
                {
                    int i = 0;
                    foreach (ICron resultUserMail in dataUserMail)
                    {
                        int z = i + 2;

                        //invio mail
                        Recuperadatiuser datiUtente = new Recuperadatiuser();
                        resultMail = MailHelper.SendMail("", resultUserMail.Email, "", "", "", "", oggetto, servizioCron.InsTextEmail(corpo, resultUserMail.Nome, resultUserMail.Cognome,
                            resultUserMail.Matricola, resultUserMail.Codsocieta, resultUserMail.Codgrade, resultUserMail.Param1, resultUserMail.Param2, resultUserMail.Param3, resultUserMail.Param4,
                            resultUserMail.Param5, resultUserMail.Param6, resultUserMail.Param7, resultUserMail.Param8, resultUserMail.Param9, resultUserMail.Param10), "", datiUtente.ReturnObjectTenant());

                        if (resultMail) //se mail andata a buon fine aggiorna flg inviato e data invio
                        {
                            servizioCron.UpdateInvioMail(resultUserMail.Idinvio, Uidtenant);
                            righeimportate++; //incrementa righe importate correttamente
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

                        i++;
                    }
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Idprog = idprog;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);

        }



        public void ImportTracciatoFuelCard(string filename, Guid UserIDIns, int idprog)
        {

            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //legge file excel
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,

                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable dt = result.Tables[0];

                    righetotali = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int z = i + 2;
                        string codsocieta = string.Empty;

                        ICron dataS = servizioCron.ReturnSocietaXSigla(SeoHelper.EncodeString(dt.Rows[i].ItemArray[2].ToString()));
                        if (dataS != null)
                        {
                            codsocieta = dataS.Codsocieta;
                        }

                        ICron traccIns = new Cron
                        {
                            Idcompagnia = SeoHelper.IntString(dt.Rows[i].ItemArray[0].ToString()),
                            Statuscard = SeoHelper.EncodeString(dt.Rows[i].ItemArray[1].ToString()),
                            Numerofuelcard = SeoHelper.EncodeString(dt.Rows[i].ItemArray[3].ToString()),
                            Targa = SeoHelper.EncodeString(dt.Rows[i].ItemArray[4].ToString()),
                            Dataattivazione = SeoHelper.DataString(dt.Rows[i].ItemArray[5].ToString()),
                            Scadenza = SeoHelper.DataString(dt.Rows[i].ItemArray[6].ToString()),
                            Pin = SeoHelper.EncodeString(dt.Rows[i].ItemArray[7].ToString()),
                            Codsocieta = codsocieta,
                            Uidtenant = SeoHelper.ReturnSessionTenant()
                        };

                        if (!servizioCron.ExistFuelCard(traccIns.Idcompagnia, traccIns.Numerofuelcard)) //controllo esistenza fuelcard
                        {
                            if (servizioCron.InsertFuelCard(traccIns) == 1)
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
                            if (servizioCron.UpdateFuelCardCount(traccIns) > 0)
                            {
                                righeimportate++; //incrementa righe importate correttamente
                            }
                            else
                            {
                                errorefile += z + "; ";
                            }
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
                    }
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);
        }




        public void ImportTracciatoCarburanteQ8(string filename, Guid UserIDIns, int idprog)
        {
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //legge file excel
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,

                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable dt = result.Tables[0];

                    righetotali = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int z = i + 2;
                        ICron traccIns = new Cron
                        {
                            Idprog = UltimoIdProg(),
                            Idtransazione = SeoHelper.EncodeString(dt.Rows[i].ItemArray[0].ToString()),
                            Codicepuntovendita = SeoHelper.EncodeString(dt.Rows[i].ItemArray[16].ToString()),
                            Localita = SeoHelper.EncodeString(dt.Rows[i].ItemArray[18].ToString()),
                            Indirizzo = SeoHelper.EncodeString(dt.Rows[i].ItemArray[17].ToString()),
                            Kmtransazione = SeoHelper.DecimalString(dt.Rows[i].ItemArray[13].ToString()),
                            Numerofuelcard = SeoHelper.EncodeString(dt.Rows[i].ItemArray[3].ToString()),
                            Targa = SeoHelper.EncodeString(dt.Rows[i].ItemArray[11].ToString()),
                            Tiporifornimento = SeoHelper.EncodeString(dt.Rows[i].ItemArray[8].ToString()),
                            Quantita = SeoHelper.DecimalString(dt.Rows[i].ItemArray[21].ToString().Replace(".", ",")),
                            Prezzo = SeoHelper.DecimalString(dt.Rows[i].ItemArray[22].ToString().Replace(".", ",")),
                            Importo = SeoHelper.DecimalString(dt.Rows[i].ItemArray[27].ToString().Replace(".", ",")),
                            Numerofattura = SeoHelper.EncodeString(dt.Rows[i].ItemArray[29].ToString()),
                            Importofinalefatturato = SeoHelper.DecimalString(dt.Rows[i].ItemArray[25].ToString().Replace(".", ",")),
                            Datatransazione = SeoHelper.DataString(dt.Rows[i].ItemArray[6].ToString()),
                            Idcompagnia = 7,
                            UserIDIns = UserIDIns,
                            Uidtenant = SeoHelper.GuidString("03334B8F-B8BB-4419-85C7-B21B0BF4F051")
                        };

                        traccIns.Importoiva = traccIns.Importofinalefatturato - traccIns.Importo;


                        if (!servizioCron.ExistFuelCardConsumo3(traccIns.Numerofuelcard, traccIns.Datatransazione, traccIns.Importofinalefatturato)) //controllo esistenza transazione
                        {
                            if (servizioCron.InsertFuelCardConsumo(traccIns) == 1)
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
                    }
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Idprog = idprog;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);


        }




        public void ImportTracciatoCarburanteDKV(string filename, Guid UserIDIns, int idprog)
        {
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //legge file excel
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,

                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable dt = result.Tables[0];

                    righetotali = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int z = i + 2;
                        ICron traccIns = new Cron
                        {
                            Idprog = UltimoIdProg(),
                            Idtransazione = SeoHelper.EncodeString(dt.Rows[i].ItemArray[6].ToString()),
                            Codicepuntovendita = SeoHelper.EncodeString(dt.Rows[i].ItemArray[23].ToString()),
                            Localita = SeoHelper.EncodeString(dt.Rows[i].ItemArray[22].ToString()),
                            Kmtransazione = SeoHelper.DecimalString(dt.Rows[i].ItemArray[28].ToString()),
                            Numerofuelcard = SeoHelper.EncodeString(dt.Rows[i].ItemArray[0].ToString()),
                            Targa = SeoHelper.EncodeString(dt.Rows[i].ItemArray[1].ToString().Replace(" ", "")),
                            Tiporifornimento = SeoHelper.EncodeString(dt.Rows[i].ItemArray[9].ToString()),
                            Quantita = SeoHelper.DecimalString(dt.Rows[i].ItemArray[11].ToString().Replace(".", ",")),
                            Prezzo = SeoHelper.DecimalString(dt.Rows[i].ItemArray[13].ToString().Replace(".", ",")),
                            Numerofattura = SeoHelper.EncodeString(dt.Rows[i].ItemArray[6].ToString()),
                            Importofinalefatturato = SeoHelper.DecimalString(dt.Rows[i].ItemArray[16].ToString().Replace(".", ",")),
                            Datatransazione = SeoHelper.DataString(dt.Rows[i].ItemArray[3].ToString()),
                            Idcompagnia = 6,
                            UserIDIns = UserIDIns,
                            Uidtenant = SeoHelper.GuidString("03334B8F-B8BB-4419-85C7-B21B0BF4F051")
                        };

                        traccIns.Importoiva = (traccIns.Importofinalefatturato * Convert.ToDecimal(0.22));
                        traccIns.Importo = traccIns.Importofinalefatturato - traccIns.Importoiva;


                        if (!servizioCron.ExistFuelCardConsumo3(traccIns.Numerofuelcard, traccIns.Datatransazione, traccIns.Importofinalefatturato)) //controllo esistenza transazione
                        {
                            if (servizioCron.InsertFuelCardConsumo(traccIns) == 1)
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
                    }
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
            importUpd.Dataimportazione = DateTime.Now;
            importUpd.Idprog = idprog;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);


        }




        public DateTime ReturnFormatData(string innerText)
        {
            DateTime retVal = DateTime.MinValue;

            if (!string.IsNullOrEmpty(innerText))
            {
                if (innerText.Length == 10)
                {
                    retVal = SeoHelper.DataString(innerText.Substring(8, 2) + "/" + innerText.Substring(5, 2) + "/" + innerText.Substring(0, 4));
                }
            }

            return retVal;
        }

        public int UltimoIdProg()
        {
            int retVal = 1;

            ICronBL servizioCron = new CronBL();

            ICron dataTracc = servizioCron.UltimoIDProg();

            if (dataTracc != null)
            {
                retVal = dataTracc.Idprog;
            }

            return retVal;
        }
        public string RicavaOra(string ora)
        {
            string retVal;

            if (!string.IsNullOrEmpty(ora))
            {
                if (ora.Length == 4)
                {
                    retVal = ora.Substring(0, 2) + ":" + ora.Substring(2, 2) + ":00";
                }
                else
                {
                    retVal = "00:00:00";
                }
            }
            else
            {
                retVal = "00:00:00";
            }

            return retVal;
        }

        public string RicavaData(string data)
        {
            string retVal;

            if (!string.IsNullOrEmpty(data))
            {
                if (data.Length == 8)
                {
                    retVal = data.Substring(6, 2) + "/" + data.Substring(4, 2) + "/" + data.Substring(0, 4);
                }
                else
                {
                    retVal = "";
                }
            }
            else
            {
                retVal = "";
            }

            return retVal;
        }
        public string ReturnCodSocieta(string codcompany)
        {
            ICronBL servizioCron = new CronBL();
            string retVal;

            ICron dataCodPol = servizioCron.DetailSocieta(codcompany);
            if (dataCodPol != null)
            {
                retVal = dataCodPol.Codsocieta;
            }
            else
            {
                retVal = "";
            }

            return retVal;
        }
        public string ReturnCodCarPolicy(string codsocieta, string gradecode)
        {
            ICronBL servizioCron = new CronBL();
            string retVal;

            ICron dataCodPol = servizioCron.ReturnCodCarPolicy(codsocieta, gradecode);
            if (dataCodPol != null)
            {
                retVal = dataCodPol.Codcarpolicy;
            }
            else
            {
                retVal = "Nocar";
            }

            return retVal;
        }
        public int ReturnIdApprovatore()
        {
            ICronBL servizioCron = new CronBL();
            int retVal = 0;

            ICron dataId = servizioCron.DetailIdUser((Guid)Membership.GetUser().ProviderUserKey);
            if (dataId != null)
            {
                retVal = dataId.Iduser;
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
        public string ReturnImportazione(string importato, string dataimportazione)
        {
            string retVal = "";

            if (importato.ToUpper() == "SI")
            {
                retVal += "SI";
            }
            else
            {
                retVal += "NO";
            }

            if (!string.IsNullOrEmpty(ReturnData(dataimportazione)))
            {
                retVal += "<br />il " + dataimportazione;
            }

            return retVal;
        }
    }
}
