// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ElaboraTracciati.aspx.cs" company="">
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
using System.IO;
using ExcelDataReader;
using System.Data;
using System.Xml;
using Microsoft.VisualBasic.FileIO;
using BusinessLogic.Services.blob;
using AraneaUtilities.Auth.Roles;

namespace DFleet.Handler
{
    /// <summary>
    /// Summary description for ElaboraTracciati
    /// </summary>
    public class ElaboraTracciati : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            string idprog = request["idprog"];
            string periododal = request["periododal"];
            string periodoal = request["periodoal"];

            IFileTracciati data = servizioFileTracciati.DetailFileCaricati(SeoHelper.IntString(idprog));
            if (data != null)
            {
                //scarica file dal blob
                string containerName = "import";
                string blobName = data.Filexml;
                string fileName = data.Filexml;
                string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
                string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
                string sas = Global.sas;

                AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                string result = azureBlobManager.DownloadBlob(fileName, blobName, true);

                if (result.ToUpper() == "PARTIAL CONTENT")
                {
                    if (ImportTracciato(data.Filexml, data.Idtipofile, periododal, periodoal) == true)
                    {
                        servizioFileTracciati.UpdateFileElaborato(data.Idprog, Uidtenant);
                        response.Write("OK");
                    }
                    else
                    {
                        response.Write("KO TRACCIATO");
                    }
                }
                else
                {
                    response.Write("KO FILE");
                }
            }
            else
            {
                response.Write("KO");
            }

        }


        public bool ImportTracciato(string filename, int idtipofile, string periododal, string periodoal)
        {
            bool retVal = false;

            switch (idtipofile)
            {
                case 1: //Tracciato Carburante ENI
                    if (ImportTracciatoCarburanteENI(filename) == true)
                    {
                        retVal = true;
                    }
                    else
                    {
                        retVal = false;
                    }
                    break;
                case 2: //Tracciato Carburante IP
                    if (ImportTracciatoCarburanteIP(filename) == true)
                    {
                        retVal = true;
                    }
                    else
                    {
                        retVal = false;
                    }
                    break;

                case 3: //Tracciato Fringe Benefit ACI
                    if (ImportTracciatoFringeBenefit(filename, periododal, periodoal) == true)
                    {
                        retVal = true;
                    }
                    else
                    {
                        retVal = false;
                    }
                    break;

                case 4: //Tracciato Fattura
                    if (ImportTracciatoFattura(filename) == true)
                    {
                        retVal = true;
                    }
                    else
                    {
                        retVal = false;
                    }
                    break;

                case 5: //Tracciato Anagrafiche
                    if (ImportTracciatoAnagrafica(filename) == true)
                    {
                        retVal = true;
                    }
                    else
                    {
                        retVal = false;
                    }
                    break;

                case 6: //Tracciato Concur
                    if (ImportTracciatoConcur(filename) == true)
                    {
                        retVal = true;
                    }
                    else
                    {
                        retVal = false;
                    }
                    break;

                case 7: //Tracciato Telepass
                    if (ImportTracciatoTelepass(filename) == true)
                    {
                        retVal = true;
                    }
                    else
                    {
                        retVal = false;
                    }
                    break;

                case 8: //Tracciato Carburante Enel X
                    if (ImportTracciatoCarburanteEnelX(filename) == true)
                    {
                        retVal = true;
                    }
                    else
                    {
                        retVal = false;
                    }
                    break;

                case 9: //Tracciato Concur Storni
                    if (ImportTracciatoConcurStorni(filename) == true)
                    {
                        retVal = true;
                    }
                    else
                    {
                        retVal = false;
                    }
                    break;

                case 10: //Tracciato Concur Fuel
                    if (ImportTracciatoConcurFuel(filename) == true)
                    {
                        retVal = true;
                    }
                    else
                    {
                        retVal = false;
                    }
                    break;
            }

            return retVal;
        }


        public bool ImportTracciatoCarburanteENI(string filename)
        {
            bool retVal = false;
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

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

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IFileTracciati traccIns = new FileTracciati
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
                            Idcompagnia = 1
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

                        if (!servizioFileTracciati.ExistFuelCardConsumo2(traccIns.Idtransazione, traccIns.Numerofuelcard, traccIns.Datatransazione, traccIns.Importofinalefatturato)) //controllo esistenza transazione
                        {
                            if (servizioFileTracciati.InsertFuelCardConsumo(traccIns) == 1)
                            {
                                retVal = true; //inserisce record
                            }
                            else
                            {
                                retVal = false; //errore db
                            }
                        }
                        else
                        {
                            retVal = true; //ignora ma va avanti
                        }
                    }
                }
            }
            return retVal;
        }

        public bool ImportTracciatoCarburanteIP(string filename)
        {

            bool retVal = false;
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

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

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IFileTracciati traccIns = new FileTracciati
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

                        if (!servizioFileTracciati.ExistFuelCardConsumo2(traccIns.Idtransazione, traccIns.Numerofuelcard, traccIns.Datatransazione, traccIns.Importofinalefatturato)) //controllo esistenza transazione
                        {
                            if (servizioFileTracciati.InsertFuelCardConsumo(traccIns) == 1)
                            {
                                retVal = true; //inserisce record
                            }
                            else
                            {
                                retVal = false; //errore db
                            }
                        }
                        else
                        {
                            if (servizioFileTracciati.UpdateFuelCardConsumo(traccIns) == 1)
                            {
                                retVal = true; //aggiorna record
                            }
                            else
                            {
                                retVal = false; //errore db
                            }
                        }
                    }
                }
            }
            return retVal;
        }

        public bool ImportTracciatoFringeBenefit(string filename, string periododal, string periodoal)
        {
            bool retVal = false;
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

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

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IFileTracciati traccIns = new FileTracciati
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
                            Periodoal = SeoHelper.DataString(periodoal)
                        };

                        IFileTracciati data = servizioFileTracciati.ExistCodjatoAuto(traccIns.Marca, traccIns.Modello, traccIns.Serie);
                        if (data != null)
                        {
                            traccIns.Codjatoauto = data.Codjatoauto;
                        }
                        else
                        {
                            traccIns.Codjatoauto = "";
                        }

                        if (servizioFileTracciati.InsertFringeBenefit(traccIns) == 1)
                        {
                            retVal = true; //inserisce record
                        }
                        else
                        {
                            retVal = false; //errore db
                        }
                    }
                }
            }
            return retVal;
        }



        public bool ImportTracciatoFattura(string filename)
        {
            bool retVal = false;
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

            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

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
            IFileTracciati traccIns = new FileTracciati
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
                Filexml = filename
            };

            if (!servizioFileTracciati.ExistFattura(traccIns.Codfornitore, traccIns.Numerodocumento, traccIns.Datadocumento)) //controllo esistenza fattura (se non esiste inserisce)
            {

                servizioFileTracciati.InsertFattureXML(traccIns);

                //recupero uidfattura appena creato
                IFileTracciati data = servizioFileTracciati.UltimoUidFattura();
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

                XmlNodeList xnl7 = root.SelectNodes("FatturaElettronicaBody/DatiBeniServizi/DettaglioLinee");
                foreach (XmlNode node7 in xnl7)
                {
                    //inserimento dati in tabella fatturexml_dettaglio
                    IFileTracciati traccDIns = new FileTracciati
                    {
                        Uidfattura = Uidfattura
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

                    servizioFileTracciati.InsertFattureXMLDettaglio(traccDIns);

                    if (traccIns.Fornitore.ToUpper() == "ALPHABET ITALIA S.P.A." || traccIns.Fornitore.ToUpper() == "ALPHABET ITALIA FLEET MANAGEMENT S.P.A.")
                    {
                        countDett += countlinee;
                    }
                    else
                    {
                        countDett++;
                    }
                }

                retVal = true;

            }

            return retVal;
        }




        public bool ImportTracciatoAnagrafica(string filename)
        {
            bool retVal = false;
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            //selezionare i dimissionari del mese precedente e cambiare la mail aggiungendo il suffisso ex,
            //in users e anche in membership, inoltre portare l'utente dimissionario in status sospeso

            List<IAccount> dataDim = servizioAccount.SelectUsersDimissionariAttivi();

            if (dataDim != null && dataDim.Count > 0)
            {
                foreach (IAccount resultDim in dataDim)
                {
                    IAccount accountNew = new Account
                    {
                        Email = "ex_" + SeoHelper.EncodeString(resultDim.Email),
                        UserId = resultDim.UserId,
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };

                    if (servizioAccount.UpdateEmail(accountNew) == 1)
                    {
                        var user = Membership.GetUser(resultDim.Email);
                        user.Email = accountNew.Email;
                        Membership.UpdateUser(user);

                        servizioAccount.UpdateUserNameMembership(accountNew.Email, accountNew.Email.ToLower(), resultDim.Email);

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

                    IAccount accountNew = new Account
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
                        Provincianascita = SeoHelper.EncodeString(fields[18]),
                        Codicefiscale = SeoHelper.EncodeString(fields[19]),
                        Indirizzoresidenza = SeoHelper.EncodeString(fields[20]),
                        Localitaresidenza = SeoHelper.EncodeString(fields[21]),
                        Provinciaresidenza = SeoHelper.EncodeString(arraypr[0].Trim()),
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
                        Flgadmin = 0
                    };

                    if (accountNew.Gradecode == "10")
                    {
                        accountNew.Persontype = "PEQ";
                    }
                    if (accountNew.Gradecode == "15")
                    {
                        accountNew.Persontype = "PAR";
                    }

                    accountNew.Fasciacarpolicy = ReturnCodCarPolicy(accountNew.Codsocieta, accountNew.Gradecode); // recupero carpolicy

                    IFileTracciati data = servizioFileTracciati.ExistAnagraficaEmail(accountNew.Email);
                    if (data != null)
                    {
                        //se esiste modifica dati

                        accountNew.UserId = data.UserId;


                        if (servizioAccount.Update(accountNew) == 1)
                        {
                            //controllo cambio gradecode
                            if ((data.Gradecode != accountNew.Gradecode) && SeoHelper.IntString(accountNew.Gradecode) > 25)
                            {
                                //controllo esistenza user carpolicy
                                if (!servizioContratti.ExistUserCarPolicy(data.Iduser))
                                {
                                    //inserimento user carpolicy solo se la car policy è diversa da nocar
                                    if (accountNew.Fasciacarpolicy.ToUpper() != "NOCAR")
                                    {
                                        IContratti contrattiuserCarPolicyNew = new Contratti
                                        {
                                            Idutente = data.Iduser,
                                            Codsocieta = accountNew.Codsocieta,
                                            Codcarpolicy = accountNew.Fasciacarpolicy,
                                            Idapprovatore = ReturnIdApprovatore(),
                                            Flgmail = "",
                                            Approvato = 0
                                        };

                                        //servizioContratti.InsertUserCarPolicy(contrattiuserCarPolicyNew);
                                    }
                                }
                            }

                            retVal = true; //modifica record e va avanti
                        }
                        else
                        {
                            retVal = false; //errore db
                        }
                    }
                    else
                    {
                        MembershipUserCollection utenti = Membership.FindUsersByEmail(SeoHelper.EncodeString(accountNew.Email));
                        if (utenti.Count == 0)
                        {
                            //ERR: crea l'utente anche se username = ""
                            Membership.CreateUser(SeoHelper.EncodeString(accountNew.Email), "Dfleet2021.", SeoHelper.EncodeString(accountNew.Email)); //crea utente
                        }

                        // devo passare a User
                        if (!Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User))
                            Roles.AddUserToRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User);
                        // devo rimuovere a Admin
                        if (Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin))
                            Roles.RemoveUserFromRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin);


                        Guid userId = (Guid)Membership.GetUser(SeoHelper.EncodeString(accountNew.Email)).ProviderUserKey; //recupera guid utente

                        accountNew.UserId = userId;

                        if (servizioAccount.Insert(accountNew) == 1) //se non esiste inserisce nuova anagrafica
                        {
                            //controllo esistenza mail
                            if (servizioAccount.ExistUser(accountNew.Email))
                            {
                                //recupero iduser
                                IAccount dataLastId = servizioAccount.UltimoIDUser();
                                if (dataLastId != null)
                                {
                                    //controllo esistenza user carpolicy
                                    if (!servizioContratti.ExistUserCarPolicy(dataLastId.Iduser))
                                    {
                                        //inserimento user carpolicy solo se la car policy è diversa da nocar
                                        if (accountNew.Fasciacarpolicy.ToUpper() != "NOCAR")
                                        {
                                            IContratti contrattiuserCarPolicyNew = new Contratti
                                            {
                                                Idutente = dataLastId.Iduser,
                                                Codsocieta = accountNew.Codsocieta,
                                                Codcarpolicy = ReturnCodCarPolicy(accountNew.Codsocieta, accountNew.Gradecode),
                                                Idapprovatore = ReturnIdApprovatore(),
                                                Flgmail = "",
                                                Approvato = 0
                                            };

                                            //servizioContratti.InsertUserCarPolicy(contrattiuserCarPolicyNew);
                                        }
                                    }
                                }

                            }

                            retVal = true; //inserisce record
                        }
                        else
                        {
                            retVal = false; //errore db
                        }
                    }
                }
            }

            return retVal;
        }






        public bool ImportTracciatoConcur(string filename)
        {
            bool retVal = false;
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

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

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Guid UserId = Guid.Empty;
                        IFileTracciati dataUid = servizioFileTracciati.ExistAnagraficaMatricola(SeoHelper.EncodeString(dt.Rows[i].ItemArray[2].ToString()));
                        if (dataUid != null)
                        {
                            UserId = dataUid.UserId;
                        }

                        IFileTracciati traccIns = new FileTracciati
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
                            Tracciato = "Car Mileage"
                        };

                        if (traccIns.Tipologiaspesa.ToUpper() == "COMPANY CAR MILEAGE")
                        {
                            if (servizioFileTracciati.InsertConcur(traccIns) == 1)
                            {
                                retVal = true; //inserisce record
                            }
                            else
                            {
                                retVal = false; //errore db
                            }
                        }
                    }
                }
            }
            return retVal;
        }



        public bool ImportTracciatoTelepass(string filename)
        {
            bool retVal = false;
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

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

                    for (int i = 16; i < dt.Rows.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i].ItemArray[1].ToString()))
                        {
                            string datatransazione = dt.Rows[i].ItemArray[2].ToString();
                            string[] arraytr = datatransazione.Split('-');
                            string dataora = arraytr[0] + "/" + arraytr[1] + "/" + arraytr[2] + " " + arraytr[3].Replace(".", ":") + ":00";

                            IFileTracciati traccIns = new FileTracciati
                            {
                                Dispositivo = SeoHelper.EncodeString(dt.Rows[i].ItemArray[0].ToString()),
                                Numerodispositivo = SeoHelper.EncodeString(dt.Rows[i].ItemArray[1].ToString()),
                                Dataora = SeoHelper.DataString(dataora),
                                Descrizione = SeoHelper.EncodeString(dt.Rows[i].ItemArray[3].ToString()),
                                Classe = SeoHelper.EncodeString(dt.Rows[i].ItemArray[4].ToString()),
                                Importo = SeoHelper.DecimalString(dt.Rows[i].ItemArray[5].ToString().Replace(".", ","))
                            };


                            if (!servizioFileTracciati.ExistTelepassConsumo(traccIns.Numerodispositivo, traccIns.Dataora)) //controllo esistenza
                            {
                                if (servizioFileTracciati.InsertTelePassConsumo(traccIns) == 1)
                                {
                                    retVal = true; //inserisce record
                                }
                                else
                                {
                                    retVal = false; //errore db
                                }
                            }
                            else
                            {
                                retVal = true; //ignora ma va avanti
                            }
                        }
                    }
                }
            }
            return retVal;
        }



        public bool ImportTracciatoCarburanteEnelX(string filename)
        {
            bool retVal = false;
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

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

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IFileTracciati traccIns = new FileTracciati
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
                            Importoiva = SeoHelper.DecimalString(dt.Rows[i].ItemArray[45].ToString().Replace(".", ",")),
                            Numerofattura = SeoHelper.EncodeString(dt.Rows[i].ItemArray[3].ToString()),
                            Datafattura = SeoHelper.DataString(RicavaData(dt.Rows[i].ItemArray[1].ToString())),
                            Importofinalefatturato = SeoHelper.DecimalString(dt.Rows[i].ItemArray[48].ToString().Replace(".", ",")),
                            Idcompagnia = 3
                        };

                        traccIns.Importo = traccIns.Importofinalefatturato / Convert.ToDecimal(1.22);

                        DateTime datatransazione = SeoHelper.DataString(RicavaData(dt.Rows[i].ItemArray[11].ToString()) + " " + RicavaOra(dt.Rows[i].ItemArray[12].ToString()));

                        if (datatransazione <= DateTime.MinValue)
                        {
                            traccIns.Datatransazione = traccIns.Datafattura;
                        }
                        else
                        {
                            traccIns.Datatransazione = datatransazione;
                        }

                        if (!servizioFileTracciati.ExistFuelCardConsumo2(traccIns.Idtransazione, traccIns.Numerofuelcard, traccIns.Datatransazione, traccIns.Importofinalefatturato)) //controllo esistenza transazione
                        {
                            if (servizioFileTracciati.InsertFuelCardConsumo(traccIns) == 1)
                            {
                                retVal = true; //inserisce record
                            }
                            else
                            {
                                retVal = false; //errore db
                            }
                        }
                        else
                        {
                            retVal = true; //ignora ma va avanti
                        }
                    }
                }
            }
            return retVal;
        }













        public bool ImportTracciatoConcurStorni(string filename)
        {
            bool retVal = false;
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            IContrattiBL servizioContratti = new ContrattiBL();

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

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Guid UserId = Guid.Empty;
                        string targa = string.Empty;
                        IFileTracciati dataUid = servizioFileTracciati.ExistAnagraficaMatricola(SeoHelper.EncodeString(dt.Rows[i].ItemArray[2].ToString()));
                        if (dataUid != null)
                        {
                            UserId = dataUid.UserId;
                        }
                        IContratti dataT = servizioContratti.ReturnTargaAssegnazioneXConcur(UserId, SeoHelper.DataString(dt.Rows[i].ItemArray[14].ToString()));
                        if (dataT != null)
                        {
                            targa = dataT.Targa;
                        }

                        IFileTracciati traccIns = new FileTracciati
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
                            Tracciato = "Storni"
                        };

                        if (servizioFileTracciati.InsertConcur(traccIns) == 1)
                        {
                            retVal = true; //inserisce record
                        }
                        else
                        {
                            retVal = false; //errore db
                        }
                    }
                }
            }
            return retVal;
        }












        public bool ImportTracciatoConcurFuel(string filename)
        {
            bool retVal = false;
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            IContrattiBL servizioContratti = new ContrattiBL();

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

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Guid UserId = Guid.Empty;
                        string targa = string.Empty;
                        IFileTracciati dataUid = servizioFileTracciati.ExistAnagraficaMatricola(SeoHelper.EncodeString(dt.Rows[i].ItemArray[2].ToString()));
                        if (dataUid != null)
                        {
                            UserId = dataUid.UserId;
                        }
                        IContratti dataT = servizioContratti.ReturnTargaAssegnazioneXConcur(UserId, SeoHelper.DataString(dt.Rows[i].ItemArray[14].ToString()));
                        if (dataT != null)
                        {
                            targa = dataT.Targa;
                        }

                        IFileTracciati traccIns = new FileTracciati
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
                            Tracciato = "Fuel"
                        };

                        if (servizioFileTracciati.InsertConcur(traccIns) == 1)
                        {
                            retVal = true; //inserisce record
                        }
                        else
                        {
                            retVal = false; //errore db
                        }
                    }
                }
            }
            return retVal;
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

            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

            IFileTracciati dataTracc = servizioFileTracciati.UltimoIDProg();

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
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            string retVal;

            IFileTracciati dataCodPol = servizioFileTracciati.DetailSocieta(codcompany);
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
            IContrattiBL servizioContratti = new ContrattiBL();
            string retVal;

            IContratti dataCodPol = servizioContratti.ReturnCodCarPolicy(codsocieta, gradecode);
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
            IAccountBL servizioAccount = new AccountBL();
            int retVal = 0;

            IAccount dataId = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
