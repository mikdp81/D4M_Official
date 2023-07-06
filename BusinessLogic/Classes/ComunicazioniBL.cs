// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CComunicazioniBL.cs" company="">
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
    public class ComunicazioniBL : BaseBL, IComunicazioniBL
    {

        public ComunicazioniBL() {
        }

        private IComunicazioniProvider ServizioComunicazioni
        {
            get { return ProviderFactory.ServizioComunicazioni; }
        }

        public int InsertComunicazione(IComunicazioni value)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            int retVal = 0;
            if (servizioComunicazioni.InsertComunicazione(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectOggetto(Guid Uidtenant)
        {
            return OdsComunicazioni.DefaultProvider.SelectOggetto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectOggettoRenter(Guid Uidtenant)
        {
            return OdsComunicazioni.DefaultProvider.SelectOggettoRenter(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectOggettoDriver(Guid Uidtenant)
        {
            return OdsComunicazioni.DefaultProvider.SelectOggettoDriver(Uidtenant);
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectStatusComunicazioni(Guid Uidtenant)
        {
            return OdsComunicazioni.DefaultProvider.SelectStatusComunicazioni(Uidtenant);
        }

        public int SelectCountComunicazioni(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            int retVal;
            retVal = servizioComunicazioni.SelectCountComunicazioni(UserId, datadal, dataal, oggetto, idstatuscomunicazione, autorizzatore, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectComunicazioni(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsComunicazioni.DefaultProvider.SelectComunicazioni(UserId, datadal, dataal, oggetto, idstatuscomunicazione, autorizzatore, Uidtenant, numrecord, pagina);
        }

        public int InsertAllegato(IComunicazioni value)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            int retVal = 0;
            if (servizioComunicazioni.InsertAllegato(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IComunicazioni ReturnUidCom()
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            IComunicazioni data = servizioComunicazioni.ReturnUidCom();
            return data;
        }

        public IComunicazioni DetailAllegato(Guid UIDallegato)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            IComunicazioni data = servizioComunicazioni.DetailAllegato(UIDallegato);
            return data;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectAllegati(Guid UIDcomunicazione)
        {
            return OdsComunicazioni.DefaultProvider.SelectAllegati(UIDcomunicazione);
        }

        public IComunicazioni DetailComunicazioni(Guid UIDcomunicazione)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            IComunicazioni data = servizioComunicazioni.DetailComunicazioni(UIDcomunicazione);
            return data;
        }

        public int UpdatStatoLettura(Guid UidcomunicazionePadre, Guid Uidtenant)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            int retVal = 0;
            if (servizioComunicazioni.UpdatStatoLettura(UidcomunicazionePadre, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectComunicazioniCorrelate(Guid UIDcomunicazione)
        {
            return OdsComunicazioni.DefaultProvider.SelectComunicazioniCorrelate(UIDcomunicazione);
        }

        public int SelectCountAllegatiComunicaione(Guid UidComunicazionePadre)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            int retVal;
            retVal = servizioComunicazioni.SelectCountAllegatiComunicaione(UidComunicazionePadre);
            return retVal;
        }

        public int UpdateUidComunicazionePadre(IComunicazioni value)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            int retVal = 0;
            if (servizioComunicazioni.UpdateUidComunicazionePadre(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int UpdateStatoComunicazione(int idstatuscomunicazione, Guid UidcomunicazionePadre, Guid Uidtenant)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            int retVal = 0;
            if (servizioComunicazioni.UpdateStatoComunicazione(idstatuscomunicazione, UidcomunicazionePadre, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int UpdateChiusuraComunicazione(Guid UidcomunicazionePadre, Guid Uidtenant)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            int retVal = 0;
            if (servizioComunicazioni.UpdateChiusuraComunicazione(UidcomunicazionePadre, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectTop5Comunicazioni(Guid UserId, Guid Uidtenant)
        {
            return OdsComunicazioni.DefaultProvider.SelectTop5Comunicazioni(UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectTop5ComunicazioniAdmin(Guid Uidtenant)
        {
            return OdsComunicazioni.DefaultProvider.SelectTop5ComunicazioniAdmin(Uidtenant);
        }
        public int SelectCountComunicazioniAperte(Guid UserId, Guid Uidtenant)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            int retVal;
            retVal = servizioComunicazioni.SelectCountComunicazioniAperte(UserId, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectComunicazioniAperte(Guid UserId, Guid Uidtenant)
        {
            return OdsComunicazioni.DefaultProvider.SelectComunicazioniAperte(UserId, Uidtenant);
        }
        public int SelectCountComunicazioniAperteAdmin(Guid Uidtenant)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            int retVal;
            retVal = servizioComunicazioni.SelectCountComunicazioniAperteAdmin(Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectComunicazioniAperteAdmin(Guid Uidtenant)
        {
            return OdsComunicazioni.DefaultProvider.SelectComunicazioniAperteAdmin(Uidtenant);
        }
        public IComunicazioni SelectEmailMittente(Guid UIDcomunicazionePadre)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            IComunicazioni data = servizioComunicazioni.SelectEmailMittente(UIDcomunicazionePadre);
            return data;
        }
        public int UpdateRiAperturaComunicazione(Guid UidcomunicazionePadre, Guid Uidtenant)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            int retVal = 0;
            if (servizioComunicazioni.UpdateRiAperturaComunicazione(UidcomunicazionePadre, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectTop5ComunicazioniPartner(Guid Uidtenant)
        {
            return OdsComunicazioni.DefaultProvider.SelectTop5ComunicazioniPartner(Uidtenant);
        }

        public int SelectCountComunicazioniPartner(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant)
        {
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            int retVal;
            retVal = servizioComunicazioni.SelectCountComunicazioniPartner(UserId, datadal, dataal, oggetto, idstatuscomunicazione, autorizzatore, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IComunicazioni> SelectComunicazioniPartner(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsComunicazioni.DefaultProvider.SelectComunicazioniPartner(UserId, datadal, dataal, oggetto, idstatuscomunicazione, autorizzatore, Uidtenant, numrecord, pagina);
        }
    }
}
