// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CODSComunicazioni.cs" company="">
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

    public class OdsComunicazioni : ODSProvider<ComunicazioniProvider>, IOdsComunicazioni
    {
        private readonly ComunicazioniProvider comunicazioniProvider = (ComunicazioniProvider)new ProviderFactory().ServizioAccount;

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertComunicazione(IComunicazioni value)
        {
            return comunicazioniProvider.InsertComunicazione(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectOggetto(Guid Uidtenant)
        {
            return comunicazioniProvider.SelectOggetto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectOggettoRenter(Guid Uidtenant)
        {
            return comunicazioniProvider.SelectOggettoRenter(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectOggettoDriver(Guid Uidtenant)
        {
            return comunicazioniProvider.SelectOggettoDriver(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectStatusComunicazioni(Guid Uidtenant)
        {
            return comunicazioniProvider.SelectStatusComunicazioni(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountComunicazioni(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant)
        {
            return comunicazioniProvider.SelectCountComunicazioni(UserId, datadal, dataal, oggetto, idstatuscomunicazione, autorizzatore, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectComunicazioni(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant, int numrecord, int pagina)
        {
            return comunicazioniProvider.SelectComunicazioni(UserId, datadal, datadal, oggetto, idstatuscomunicazione, autorizzatore, Uidtenant, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertAllegato(IComunicazioni value)
        {
            return comunicazioniProvider.InsertAllegato(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectAllegati(Guid UIDcomunicazione)
        {
            return comunicazioniProvider.SelectAllegati(UIDcomunicazione);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdatStatoLettura(Guid UidcomunicazionePadre, Guid Uidtenant)
        {
            return comunicazioniProvider.UpdatStatoLettura(UidcomunicazionePadre, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectComunicazioniCorrelate(Guid UIDcomunicazione)
        {
            return comunicazioniProvider.SelectComunicazioniCorrelate(UIDcomunicazione);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountAllegatiComunicaione(Guid UidComunicazionePadre)
        {
            return comunicazioniProvider.SelectCountAllegatiComunicaione(UidComunicazionePadre);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateUidComunicazionePadre(IComunicazioni value)
        {
            return comunicazioniProvider.UpdateUidComunicazionePadre(value);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateStatoComunicazione(int idstatuscomunicazione, Guid UidcomunicazionePadre, Guid Uidtenant)
        {
            return comunicazioniProvider.UpdateStatoComunicazione(idstatuscomunicazione, UidcomunicazionePadre, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateChiusuraComunicazione(Guid UidcomunicazionePadre, Guid Uidtenant)
        {
            return comunicazioniProvider.UpdateChiusuraComunicazione(UidcomunicazionePadre, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectTop5Comunicazioni(Guid UserId, Guid Uidtenant)
        {
            return comunicazioniProvider.SelectTop5Comunicazioni(UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectTop5ComunicazioniAdmin(Guid Uidtenant)
        {
            return comunicazioniProvider.SelectTop5ComunicazioniAdmin(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountComunicazioniAperte(Guid UserId, Guid Uidtenant)
        {
            return comunicazioniProvider.SelectCountComunicazioniAperte(UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectComunicazioniAperte(Guid UserId, Guid Uidtenant)
        {
            return comunicazioniProvider.SelectComunicazioniAperte(UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountComunicazioniAperteAdmin(Guid Uidtenant)
        {
            return comunicazioniProvider.SelectCountComunicazioniAperteAdmin(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectComunicazioniAperteAdmin(Guid Uidtenant)
        {
            return comunicazioniProvider.SelectComunicazioniAperteAdmin(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateRiAperturaComunicazione(Guid UidcomunicazionePadre, Guid Uidtenant)
        {
            return comunicazioniProvider.UpdateRiAperturaComunicazione(UidcomunicazionePadre, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectTop5ComunicazioniPartner(Guid Uidtenant)
        {
            return comunicazioniProvider.SelectTop5ComunicazioniPartner(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountComunicazioniPartner(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant)
        {
            return comunicazioniProvider.SelectCountComunicazioniPartner(UserId, datadal, dataal, oggetto, idstatuscomunicazione, autorizzatore, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectComunicazioniPartner(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant, int numrecord, int pagina)
        {
            return comunicazioniProvider.SelectComunicazioniPartner(UserId, datadal, datadal, oggetto, idstatuscomunicazione, autorizzatore, Uidtenant, numrecord, pagina);
        }
    }
}
