// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IODSComunicazioni.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface IOdsComunicazioni
    {
        int InsertComunicazione(IComunicazioni value);
        List<IComunicazioni> SelectOggetto(Guid Uidtenant);
        List<IComunicazioni> SelectOggettoRenter(Guid Uidtenant);
        List<IComunicazioni> SelectOggettoDriver(Guid Uidtenant);
        List<IComunicazioni> SelectStatusComunicazioni(Guid Uidtenant);
        int SelectCountComunicazioni(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant);
        List<IComunicazioni> SelectComunicazioni(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant, int numrecord, int pagina);
        int InsertAllegato(IComunicazioni value);
        List<IComunicazioni> SelectAllegati(Guid UIDcomunicazione);
        int UpdatStatoLettura(Guid UidcomunicazionePadre, Guid Uidtenant);
        List<IComunicazioni> SelectComunicazioniCorrelate(Guid UIDcomunicazione);
        int SelectCountAllegatiComunicaione(Guid UidComunicazionePadre);
        int UpdateUidComunicazionePadre(IComunicazioni value);
        int UpdateStatoComunicazione(int idstatuscomunicazione, Guid UidcomunicazionePadre, Guid Uidtenant);
        int UpdateChiusuraComunicazione(Guid UidcomunicazionePadre, Guid Uidtenant);
        List<IComunicazioni> SelectTop5Comunicazioni(Guid UserId, Guid Uidtenant);
        List<IComunicazioni> SelectTop5ComunicazioniAdmin(Guid Uidtenant);
        int SelectCountComunicazioniAperte(Guid UserId, Guid Uidtenant);
        List<IComunicazioni> SelectComunicazioniAperte(Guid UserId, Guid Uidtenant);
        int SelectCountComunicazioniAperteAdmin(Guid Uidtenant);
        List<IComunicazioni> SelectComunicazioniAperteAdmin(Guid Uidtenant);
        int UpdateRiAperturaComunicazione(Guid UidcomunicazionePadre, Guid Uidtenant);
        List<IComunicazioni> SelectTop5ComunicazioniPartner(Guid Uidtenant);
        int SelectCountComunicazioniPartner(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant);
        List<IComunicazioni> SelectComunicazioniPartner(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant, int numrecord, int pagina);
    }
}
