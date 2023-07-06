// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IODSFileTracciati.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface IOdsFileTracciati
    {
        int InsertFileTracciato(IFileTracciati value);
        List<IFileTracciati> SelectTipoFile(Guid Uidtenant);
        int InsertFuelCardConsumo(IFileTracciati value);
        int UpdateFuelCardConsumo(IFileTracciati value);
        int SelectCountConsumiDriver(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard);
        List<IFileTracciati> SelectConsumiDriver(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, int numrecord, int pagina);
        List<IFileTracciati> SelectFuelCardDriver(Guid UserId); 
        List<IFileTracciati> SelectAllFuelCard(Guid Uidtenant);
        int InsertFringeBenefit(IFileTracciati value);
        List<IFileTracciati> SelectAutoXMarca(string marca);
        int UpdateCodjatoAuto(IFileTracciati value);
        List<IFileTracciati> SelectDetailFringeXCod(string codjatoauto);
        int SelectCountFringeBenefit(string marca, string modello, Guid Uidtenant);
        List<IFileTracciati> SelectFringeBenefit(string marca, string modello, Guid Uidtenant, int numrecord, int pagina);
        int InsertFattureXML(IFileTracciati value);
        int InsertFattureXMLDettaglio(IFileTracciati value);
        int SelectCountConsumiFuelCard(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, Guid Uidtenant);
        List<IFileTracciati> SelectConsumiFuelCard(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, Guid Uidtenant, int numrecord, int pagina);
        int InsertConcur(IFileTracciati value);
        int SelectCountConcur(Guid UserId, DateTime datadal, DateTime dataal, string targa, Guid Uidtenant);
        List<IFileTracciati> SelectConcur(Guid UserId, DateTime datadal, DateTime dataal, string targa, Guid Uidtenant, int numrecord, int pagina);
        List<IFileTracciati> SelectViewConcur(string matricola, string targa, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountViewConcur(string matricola, string targa, Guid Uidtenant);
        int InsertTelePassConsumo(IFileTracciati value);
        List<IFileTracciati> SelectAllTelePass(Guid Uidtenant);
        int SelectCountConsumiTelePass(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerodispositivo, Guid Uidtenant);
        List<IFileTracciati> SelectConsumiTelePass(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerodispositivo, Guid Uidtenant, int numrecord, int pagina);
        List<IFileTracciati> SelectFileCaricati();
        int UpdateFileElaborato(int idprog, Guid Uidtenant);
        int UpdateStoricoImportazione(IFileTracciati value);
        int InsertStoricoImportazione(IFileTracciati value);
        List<IFileTracciati> SelectImportazioni(int idtipofile, string nomefile, DateTime datadal, DateTime dataal, Guid Uidtenant);
        int UpdateFuelCardConsumoCount(IFileTracciati value);
        int DeleteFuelConsumo(Guid Uid, Guid Uidtenant);
        List<IFileTracciati> SelectViewConcurTxt();
        int InsertConcur900(IFileTracciati value);
        List<IFileTracciati> SelectViewConcur900Txt();
    }
}
