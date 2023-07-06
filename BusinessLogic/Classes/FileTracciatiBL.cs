// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CFileTracciatiBL.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using System.Threading;
using BaseProvider;
using System.Web;
using System.Diagnostics;
using BusinessObject;
using BusinessProvider;
using AraneaUtilities.Auth;
using System.Security;
using System.Web.Security;

namespace BusinessLogic
{
    [Serializable]
    public class FileTracciatiBL : BaseBL, IFileTracciatiBL
    {

        public FileTracciatiBL()
        {
        }

        private IFileTracciatiProvider ServizioFileTracciati
        {
            get { return ProviderFactory.ServizioFileTracciati; }
        }

        public int InsertFileTracciato(IFileTracciati value)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal = 0;
            if (servizioFileTracciati.InsertFileTracciato(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectTipoFile(Guid Uidtenant)
        {
            return OdsFileTracciati.DefaultProvider.SelectTipoFile(Uidtenant);
        }

        public int InsertFuelCardConsumo(IFileTracciati value)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal = 0;
            if (servizioFileTracciati.InsertFuelCardConsumo(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateFuelCardConsumo(IFileTracciati value)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal = 0;
            if (servizioFileTracciati.UpdateFuelCardConsumo(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IFileTracciati UltimoIDProg()
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            IFileTracciati data = servizioFileTracciati.UltimoIDProg();
            return data;
        }

        public bool ExistFuelCardConsumo(string idtransazione, string numerofuelcard)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            bool retVal;
            retVal = servizioFileTracciati.ExistFuelCardConsumo(idtransazione, numerofuelcard);
            return retVal;
        }
        public bool ExistFuelCardConsumo2(string idtransazione, string numerofuelcard, DateTime datatransazione, decimal importo)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            bool retVal;
            retVal = servizioFileTracciati.ExistFuelCardConsumo2(idtransazione, numerofuelcard, datatransazione, importo);
            return retVal;
        }

        public int SelectCountConsumiDriver(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal;
            retVal = servizioFileTracciati.SelectCountConsumiDriver(UserId, datadal, dataal, search, numerofuelcard);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectConsumiDriver(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, int numrecord, int pagina)
        {
            return OdsFileTracciati.DefaultProvider.SelectConsumiDriver(UserId, datadal, dataal, search, numerofuelcard, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectFuelCardDriver(Guid UserId)
        {
            return OdsFileTracciati.DefaultProvider.SelectFuelCardDriver(UserId);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectAllFuelCard(Guid Uidtenant)
        {
            return OdsFileTracciati.DefaultProvider.SelectAllFuelCard(Uidtenant);
        }
        public int InsertFringeBenefit(IFileTracciati value)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal = 0;
            if (servizioFileTracciati.InsertFringeBenefit(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IFileTracciati ExistCodjatoAuto(string marca, string modello, string serie)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            IFileTracciati data = servizioFileTracciati.ExistCodjatoAuto(marca, modello, serie);
            return data;
        }
        public bool ExistAbbinamentoCodjatoAuto(string codjatoauto)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            bool retVal;
            retVal = servizioFileTracciati.ExistAbbinamentoCodjatoAuto(codjatoauto);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectAutoXMarca(string marca)
        {
            return OdsFileTracciati.DefaultProvider.SelectAutoXMarca(marca);
        }
        public int UpdateCodjatoAuto(IFileTracciati value)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal = 0;
            if (servizioFileTracciati.UpdateCodjatoAuto(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IFileTracciati ExistCodjatoAutoXId(int idfringe)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            IFileTracciati data = servizioFileTracciati.ExistCodjatoAutoXId(idfringe);
            return data;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectDetailFringeXCod(string codjatoauto)
        {
            return OdsFileTracciati.DefaultProvider.SelectDetailFringeXCod(codjatoauto);
        }

        public int SelectCountFringeBenefit(string marca, string modello, Guid Uidtenant)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal;
            retVal = servizioFileTracciati.SelectCountFringeBenefit(marca, modello, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectFringeBenefit(string marca, string modello, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsFileTracciati.DefaultProvider.SelectFringeBenefit(marca, modello, Uidtenant, numrecord, pagina);
        }
        public int InsertFattureXML(IFileTracciati value)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal = 0;
            if (servizioFileTracciati.InsertFattureXML(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int InsertFattureXMLDettaglio(IFileTracciati value)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal = 0;
            if (servizioFileTracciati.InsertFattureXMLDettaglio(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IFileTracciati UltimoUidFattura()
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            IFileTracciati data = servizioFileTracciati.UltimoUidFattura();
            return data;
        }
        public bool ExistFattura(string codfornitore, string numerodocumento, DateTime datadocumento)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            bool retVal;
            retVal = servizioFileTracciati.ExistFattura(codfornitore, numerodocumento, datadocumento);
            return retVal;
        }
        public IFileTracciati PercentualeFringe(decimal emissione)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            IFileTracciati data = servizioFileTracciati.PercentualeFringe(emissione);
            return data;
        }
        public IFileTracciati ValorePercentualeFringe(string codjatoauto, string campo)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            IFileTracciati data = servizioFileTracciati.ValorePercentualeFringe(codjatoauto, campo);
            return data;
        }
        public int ReturnColonnaPerc(decimal emissioni)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int percentuale = 0;

            IFileTracciati data = servizioFileTracciati.PercentualeFringe(emissioni);
            if (data != null)
            {
                percentuale = Convert.ToInt32(data.Percentuale);
            }

            return percentuale;
        }
        public string ReturnCampoPerc(int percentuale)
        {
            string retVal = "fringe25";
            switch (percentuale)
            {
                case 25:
                    retVal = "fringe25";
                    break;

                case 30:
                    retVal = "fringe30";
                    break;

                case 50:
                    retVal = "fringe50";
                    break;

                case 60:
                    retVal = "fringe60";
                    break;
            }

            return retVal;
        }
        public decimal DValorePercentualeFringe(string codjatoauto, string campo)
        {
            decimal valore = 0;

            IFileTracciati data = ValorePercentualeFringe(codjatoauto, campo);
            if (data != null)
            {
                valore = data.Fringe25;
            }

            return valore;
        }
        public decimal TotaleFringeBenefit(decimal valore)
        {
            return valore / 12;
        }
        public decimal CalcoloFringeBenefit(string codjatoauto, decimal emissioni)
        {
            int percentuale = ReturnColonnaPerc(emissioni);
            string campo = ReturnCampoPerc(percentuale);
            decimal valore = DValorePercentualeFringe(codjatoauto, campo);
            decimal totalefringe = TotaleFringeBenefit(valore);
            return totalefringe;
        }
        public int SelectCountConsumiFuelCard(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, Guid Uidtenant)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal;
            retVal = servizioFileTracciati.SelectCountConsumiFuelCard(UserId, datadal, dataal, search, numerofuelcard, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectConsumiFuelCard(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsFileTracciati.DefaultProvider.SelectConsumiFuelCard(UserId, datadal, dataal, search, numerofuelcard, Uidtenant, numrecord, pagina);
        }
        public IFileTracciati ExistAnagrafica(string codicefiscale)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            IFileTracciati data = servizioFileTracciati.ExistAnagrafica(codicefiscale);
            return data;
        }
        public IFileTracciati ExistAnagraficaEmail(string email)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            IFileTracciati data = servizioFileTracciati.ExistAnagraficaEmail(email);
            return data;
        }
        public IFileTracciati ExistAnagraficaMatricola(string matricola)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            IFileTracciati data = servizioFileTracciati.ExistAnagraficaMatricola(matricola);
            return data;
        }
        public IFileTracciati DetailSocieta(string codcompany)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            IFileTracciati data = servizioFileTracciati.DetailSocieta(codcompany);
            return data;
        }
        public int InsertConcur(IFileTracciati value)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal = 0;
            if (servizioFileTracciati.InsertConcur(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountConcur(Guid UserId, DateTime datadal, DateTime dataal, string targa, Guid Uidtenant)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal;
            retVal = servizioFileTracciati.SelectCountConcur(UserId, datadal, dataal, targa, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectConcur(Guid UserId, DateTime datadal, DateTime dataal, string targa, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsFileTracciati.DefaultProvider.SelectConcur(UserId, datadal, dataal, targa, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectViewConcur(string matricola, string targa, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsFileTracciati.DefaultProvider.SelectViewConcur(matricola, targa, Uidtenant, numrecord, pagina);
        }
        public int SelectCountViewConcur(string matricola, string targa, Guid Uidtenant)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal;
            retVal = servizioFileTracciati.SelectCountViewConcur(matricola, targa, Uidtenant);
            return retVal;
        }
        public int InsertTelePassConsumo(IFileTracciati value)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal = 0;
            if (servizioFileTracciati.InsertTelePassConsumo(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public bool ExistTelepassConsumo(string numerodispositivo, DateTime dataora)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            bool retVal;
            retVal = servizioFileTracciati.ExistTelepassConsumo(numerodispositivo, dataora);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectAllTelePass(Guid Uidtenant)
        {
            return OdsFileTracciati.DefaultProvider.SelectAllTelePass(Uidtenant);
        }
        public int SelectCountConsumiTelePass(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, Guid Uidtenant)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal;
            retVal = servizioFileTracciati.SelectCountConsumiTelePass(UserId, datadal, dataal, search, numerofuelcard, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectConsumiTelePass(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerodispositivo, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsFileTracciati.DefaultProvider.SelectConsumiTelePass(UserId, datadal, dataal, search, numerodispositivo, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectFileCaricati()
        {
            return OdsFileTracciati.DefaultProvider.SelectFileCaricati();
        }
        public IFileTracciati DetailFileCaricati(int idprog)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            IFileTracciati data = servizioFileTracciati.DetailFileCaricati(idprog);
            return data;
        }
        public int UpdateFileElaborato(int idprog, Guid Uidtenant)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal = 0;
            if (servizioFileTracciati.UpdateFileElaborato(idprog, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateStoricoImportazione(IFileTracciati value)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal = 0;
            if (servizioFileTracciati.UpdateStoricoImportazione(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IFileTracciati DetailImportazioni(int idprog)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            IFileTracciati data = servizioFileTracciati.DetailImportazioni(idprog);
            return data;
        }
        public int InsertStoricoImportazione(IFileTracciati value)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal = 0;
            if (servizioFileTracciati.InsertStoricoImportazione(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectImportazioni(int idtipofile, string nomefile, DateTime datadal, DateTime dataal, Guid Uidtenant)
        {
            return OdsFileTracciati.DefaultProvider.SelectImportazioni(idtipofile, nomefile, datadal, dataal, Uidtenant);
        }
        public int UpdateFuelCardConsumoCount(IFileTracciati value)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal;
            retVal = servizioFileTracciati.UpdateFuelCardConsumoCount(value);
            return retVal;
        }
        public int DeleteFuelConsumo(Guid Uid, Guid Uidtenant)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal;
            retVal = servizioFileTracciati.DeleteFuelConsumo(Uid, Uidtenant);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectViewConcurTxt()
        {
            return OdsFileTracciati.DefaultProvider.SelectViewConcurTxt();
        }
        public bool ExistDataConcur()
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            bool retVal;
            retVal = servizioFileTracciati.ExistDataConcur();
            return retVal;
        }
        public IFileTracciati DetailConcur900(string matricola)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            IFileTracciati data = servizioFileTracciati.DetailConcur900(matricola);
            return data;
        }
        public int InsertConcur900(IFileTracciati value)
        {
            IFileTracciatiProvider servizioFileTracciati = ServizioFileTracciati;
            int retVal = 0;
            if (servizioFileTracciati.InsertConcur900(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectViewConcur900Txt()
        {
            return OdsFileTracciati.DefaultProvider.SelectViewConcur900Txt();
        }
    }
}