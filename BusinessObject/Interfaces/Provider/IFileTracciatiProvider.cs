// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IFileTracciatiProvider.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject.Classes;
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface IFileTracciatiProvider : IOdsFileTracciati
    {
        IFileTracciati UltimoIDProg();
        bool ExistFuelCardConsumo(string idtransazione, string numerofuelcard);
        bool ExistFuelCardConsumo2(string idtransazione, string numerofuelcard, DateTime datatransazione, decimal importo);
        IFileTracciati ExistCodjatoAuto(string marca, string modello, string serie);
        bool ExistAbbinamentoCodjatoAuto(string codjatoauto);
        IFileTracciati ExistCodjatoAutoXId(int idfringe);
        IFileTracciati UltimoUidFattura();
        bool ExistFattura(string codfornitore, string numerodocumento, DateTime datadocumento);
        IFileTracciati PercentualeFringe(decimal emissione);
        IFileTracciati ValorePercentualeFringe(string codjatoauto, string campo);
        IFileTracciati ExistAnagrafica(string codicefiscale);
        IFileTracciati ExistAnagraficaEmail(string email);
        IFileTracciati ExistAnagraficaMatricola(string matricola);
        IFileTracciati DetailSocieta(string codcompany);
        bool ExistTelepassConsumo(string numerodispositivo, DateTime dataora);
        IFileTracciati DetailFileCaricati(int idprog);
        IFileTracciati DetailImportazioni(int idprog);
        bool ExistDataConcur();
        IFileTracciati DetailConcur900(string matricola);
    }
}
