// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CODSFileTracciati.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using BusinessObject;
using DataProvider;

namespace BusinessProvider
{
    [DataObject(true)]

    public class OdsFileTracciati : ODSProvider<FileTracciatiProvider>, IOdsFileTracciati
    {
        private readonly FileTracciatiProvider filetracciatiProvider = (FileTracciatiProvider)new ProviderFactory().ServizioAccount;
        
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFileTracciato(IFileTracciati value)
        {
            return filetracciatiProvider.InsertFileTracciato(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectTipoFile(Guid Uidtenant)
        {
            return filetracciatiProvider.SelectTipoFile(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFuelCardConsumo(IFileTracciati value)
        {
            return filetracciatiProvider.InsertFuelCardConsumo(value);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateFuelCardConsumo(IFileTracciati value)
        {
            return filetracciatiProvider.UpdateFuelCardConsumo(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountConsumiDriver(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard)
        {
            return filetracciatiProvider.SelectCountConsumiDriver(UserId, datadal, dataal, search, numerofuelcard);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectConsumiDriver(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, int numrecord, int pagina)
        {
            return filetracciatiProvider.SelectConsumiDriver(UserId, datadal, datadal, search, numerofuelcard, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectFuelCardDriver(Guid UserId)
        {
            return filetracciatiProvider.SelectFuelCardDriver(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectAllFuelCard(Guid Uidtenant)
        {
            return filetracciatiProvider.SelectAllFuelCard(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFringeBenefit(IFileTracciati value)
        {
            return filetracciatiProvider.InsertFringeBenefit(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int UpdateCodjatoAuto(IFileTracciati value)
        {
            return filetracciatiProvider.UpdateCodjatoAuto(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectAutoXMarca(string marca)
        {
            return filetracciatiProvider.SelectAutoXMarca(marca);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectDetailFringeXCod(string codjatoauto)
        {
            return filetracciatiProvider.SelectDetailFringeXCod(codjatoauto);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountFringeBenefit(string marca, string modello, Guid Uidtenant)
        {
            return filetracciatiProvider.SelectCountFringeBenefit(marca, modello, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectFringeBenefit(string marca, string modello, Guid Uidtenant, int numrecord, int pagina)
        {
            return filetracciatiProvider.SelectFringeBenefit(marca, modello, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFattureXML(IFileTracciati value)
        {
            return filetracciatiProvider.InsertFattureXML(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFattureXMLDettaglio(IFileTracciati value)
        {
            return filetracciatiProvider.InsertFattureXMLDettaglio(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountConsumiFuelCard(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, Guid Uidtenant)
        {
            return filetracciatiProvider.SelectCountConsumiFuelCard(UserId, datadal, dataal, search, numerofuelcard, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectConsumiFuelCard(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, Guid Uidtenant, int numrecord, int pagina)
        {
            return filetracciatiProvider.SelectConsumiFuelCard(UserId, datadal, datadal, search, numerofuelcard, Uidtenant, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertConcur(IFileTracciati value)
        {
            return filetracciatiProvider.InsertConcur(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountConcur(Guid UserId, DateTime datadal, DateTime dataal, string targa, Guid Uidtenant)
        {
            return filetracciatiProvider.SelectCountConcur(UserId, datadal, dataal, targa, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectConcur(Guid UserId, DateTime datadal, DateTime dataal, string targa, Guid Uidtenant, int numrecord, int pagina)
        {
            return filetracciatiProvider.SelectConcur(UserId, datadal, dataal, targa, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectViewConcur(string matricola, string targa, Guid Uidtenant, int numrecord, int pagina)
        {
            return filetracciatiProvider.SelectViewConcur(matricola, targa, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountViewConcur(string matricola, string targa, Guid Uidtenant)
        {
            return filetracciatiProvider.SelectCountViewConcur(matricola, targa, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertTelePassConsumo(IFileTracciati value)
        {
            return filetracciatiProvider.InsertTelePassConsumo(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectAllTelePass(Guid Uidtenant)
        {
            return filetracciatiProvider.SelectAllTelePass(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountConsumiTelePass(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerodispositivo, Guid Uidtenant)
        {
            return filetracciatiProvider.SelectCountConsumiTelePass(UserId, datadal, dataal, search, numerodispositivo, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectConsumiTelePass(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerodispositivo, Guid Uidtenant, int numrecord, int pagina)
        {
            return filetracciatiProvider.SelectConsumiTelePass(UserId, datadal, datadal, search, numerodispositivo, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectFileCaricati()
        {
            return filetracciatiProvider.SelectFileCaricati();
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateFileElaborato(int idprog, Guid Uidtenant)
        {
            return filetracciatiProvider.UpdateFileElaborato(idprog, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateStoricoImportazione(IFileTracciati value)
        {
            return filetracciatiProvider.UpdateStoricoImportazione(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertStoricoImportazione(IFileTracciati value)
        {
            return filetracciatiProvider.InsertStoricoImportazione(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectImportazioni(int idtipofile, string nomefile, DateTime datadal, DateTime dataal, Guid Uidtenant)
        {
            return filetracciatiProvider.SelectImportazioni(idtipofile, nomefile, datadal, dataal, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int UpdateFuelCardConsumoCount(IFileTracciati value)
        {
            return filetracciatiProvider.UpdateFuelCardConsumoCount(value);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteFuelConsumo(Guid Uid, Guid Uidtenant)
        {
            return filetracciatiProvider.DeleteFuelConsumo(Uid, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectViewConcurTxt()
        {
            return filetracciatiProvider.SelectViewConcurTxt();
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertConcur900(IFileTracciati value)
        {
            return filetracciatiProvider.InsertConcur900(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IFileTracciati> SelectViewConcur900Txt()
        {
            return filetracciatiProvider.SelectViewConcur900Txt();
        }
    }
}
