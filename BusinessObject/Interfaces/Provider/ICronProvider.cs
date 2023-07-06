// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ICronProvider.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject.Classes;
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface ICronProvider : IOdsCron
    {
        bool ExistUserCarPolicy(int idutente);
        ICron DetailId(Guid UserId);
        ICron UrlBlob();
        ICron ReturnTemplateEmail(int idtemplate);
        ICron DetailImportazioni(int idprog);
        bool ExistFuelCardConsumo2(string idtransazione, string numerofuelcard, DateTime datatransazione, decimal importo);
        bool ExistFuelCardConsumo3(string numerofuelcard, DateTime datatransazione, decimal importo);
        ICron ExistCodjatoAuto(string marca, string modello, string serie);
        bool ExistFattura(string codfornitore, string numerodocumento, DateTime datadocumento);
        ICron UltimoUidFattura();
        ICron ExistAnagraficaEmail(string email);
        ICron ExistAnagraficaMatricola(string matricola);
        bool ExistTelepassConsumo(string numerodispositivo, DateTime dataora);
        ICron ReturnTargaAssegnazioneXConcur(Guid UserId, DateTime dataspesa);
        ICron UltimoIDProg();
        ICron DetailSocieta(string codcompany);
        ICron ReturnCodCarPolicy(string codsocieta, string gradecode);
        ICron DetailIdUser(Guid UserId);
        ICron CredNetwork();
        ICron UltimoIDProgImp();
        bool ExistRevisione(string targa, int mese, int anno);
        ICron DetailNumeroFuelCardEnelX(string targa);
        bool ExistFuelCard(int idcompagnia, string numerofuelcard);
        ICron ReturnSocietaXSigla(string siglasocieta);
        bool ExistDataConcur();
        ICron DetailConcur900(string matricola);
        bool ExistMatricola(string matricola, string codsocieta);
        ICron ReturnCodSocieta(string codzucchetti);
    }
}
