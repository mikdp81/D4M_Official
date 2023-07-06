// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IFileTracciatiBL.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using BusinessObject;

namespace BusinessLogic
{
    public interface IFileTracciatiBL
    {

        int InsertFileTracciato(IFileTracciati value);
        List<IFileTracciati> SelectTipoFile(Guid Uidtenant);
        int InsertFuelCardConsumo(IFileTracciati value);
        int UpdateFuelCardConsumo(IFileTracciati value);
        IFileTracciati UltimoIDProg();
        bool ExistFuelCardConsumo(string idtransazione, string numerofuelcard);
        bool ExistFuelCardConsumo2(string idtransazione, string numerofuelcard, DateTime datatransazione, decimal importo);
        int SelectCountConsumiDriver(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard);
        List<IFileTracciati> SelectConsumiDriver(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, int numrecord, int pagina);
        List<IFileTracciati> SelectFuelCardDriver(Guid UserId);
        List<IFileTracciati> SelectAllFuelCard(Guid Uidtenant);
        int InsertFringeBenefit(IFileTracciati value);
        IFileTracciati ExistCodjatoAuto(string marca, string modello, string serie);
        bool ExistAbbinamentoCodjatoAuto(string codjatoauto);
        List<IFileTracciati> SelectAutoXMarca(string marca);
        IFileTracciati ExistCodjatoAutoXId(int idfringe);
        int UpdateCodjatoAuto(IFileTracciati value);
        List<IFileTracciati> SelectDetailFringeXCod(string codjatoauto);
        int SelectCountFringeBenefit(string marca, string modello, Guid Uidtenant);
        List<IFileTracciati> SelectFringeBenefit(string marca, string modell, Guid Uidtenanto, int numrecord, int pagina);
        int InsertFattureXML(IFileTracciati value);
        int InsertFattureXMLDettaglio(IFileTracciati value);
        IFileTracciati UltimoUidFattura();
        bool ExistFattura(string codfornitore, string numerodocumento, DateTime datadocumento);
        IFileTracciati PercentualeFringe(decimal emissione);
        IFileTracciati ValorePercentualeFringe(string codjatoauto, string campo);
        int ReturnColonnaPerc(decimal emissioni);
        string ReturnCampoPerc(int percentuale);
        decimal DValorePercentualeFringe(string codjatoauto, string campo);
        decimal TotaleFringeBenefit(decimal valore);
        decimal CalcoloFringeBenefit(string codjatoauto, decimal emissioni);
        int SelectCountConsumiFuelCard(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, Guid Uidtenant);
        List<IFileTracciati> SelectConsumiFuelCard(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, Guid Uidtenant, int numrecord, int pagina);
        IFileTracciati ExistAnagrafica(string codicefiscale);
        IFileTracciati ExistAnagraficaEmail(string email);
        IFileTracciati ExistAnagraficaMatricola(string matricola);
        IFileTracciati DetailSocieta(string codcompany);
        int InsertConcur(IFileTracciati value);
        int SelectCountConcur(Guid UserId, DateTime datadal, DateTime dataal, string targa, Guid Uidtenant);
        List<IFileTracciati> SelectConcur(Guid UserId, DateTime datadal, DateTime dataal, string targa, Guid Uidtenant, int numrecord, int pagina);
        List<IFileTracciati> SelectViewConcur(string matricola, string targa, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountViewConcur(string matricola, string targa, Guid Uidtenant);
        int InsertTelePassConsumo(IFileTracciati value);
        bool ExistTelepassConsumo(string numerodispositivo, DateTime dataora);
        List<IFileTracciati> SelectAllTelePass(Guid Uidtenant);
        int SelectCountConsumiTelePass(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerodispositivo, Guid Uidtenant);
        List<IFileTracciati> SelectConsumiTelePass(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerodispositivo, Guid Uidtenant, int numrecord, int pagina);
        List<IFileTracciati> SelectFileCaricati();
        IFileTracciati DetailFileCaricati(int idprog);
        int UpdateFileElaborato(int idprog, Guid Uidtenant);
        int UpdateStoricoImportazione(IFileTracciati value);
        IFileTracciati DetailImportazioni(int idprog);
        int InsertStoricoImportazione(IFileTracciati value);
        List<IFileTracciati> SelectImportazioni(int idtipofile, string nomefile, DateTime datadal, DateTime dataal, Guid Uidtenant);
        int UpdateFuelCardConsumoCount(IFileTracciati value);
        int DeleteFuelConsumo(Guid Uid, Guid Uidtenant);
        List<IFileTracciati> SelectViewConcurTxt();
        bool ExistDataConcur();
        IFileTracciati DetailConcur900(string matricola);
        int InsertConcur900(IFileTracciati value);
        List<IFileTracciati> SelectViewConcur900Txt();
    }
}