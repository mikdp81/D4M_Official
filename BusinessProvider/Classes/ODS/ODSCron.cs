// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CODSCron.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Permissions;
using BusinessObject;
using DataProvider;

namespace BusinessProvider
{
    [DataObject(true)]
    public class OdsCron : ODSProvider<CronProvider>, IOdsCron
    {
        private readonly CronProvider cronProvider = (CronProvider)new ProviderFactory().ServizioAccount;

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectMulteDapagare()
        {
            return cronProvider.SelectMulteDapagare();
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdatePagamento(Guid Uid, Guid Uidtenant)
        {
            return cronProvider.UpdatePagamento(Uid, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectCedolini(string mese, string anno)
        {
            return cronProvider.SelectCedolini(mese, anno);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFileCron(ICron value)
        {
            return cronProvider.InsertFileCron(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectContrattiUserInScadenza()
        {
            return cronProvider.SelectContrattiUserInScadenza();
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertUserCarPolicy(ICron value)
        {
            return cronProvider.InsertUserCarPolicy(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectContrattiDaChiudere()
        {
            return cronProvider.SelectContrattiDaChiudere();
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateContrattiDaChiudere(Guid Uid, Guid Uidtenant)
        {
            return cronProvider.UpdateContrattiDaChiudere(Uid, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateContrattiAssDaChiudere(int idcontratto, Guid Uidtenant)
        {
            return cronProvider.UpdateContrattiAssDaChiudere(idcontratto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectComunicazioniInserite()
        {
            return cronProvider.SelectComunicazioniInserite();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectViewConcur()
        {
            return cronProvider.SelectViewConcur();
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateStoricoImportazione(ICron value)
        {
            return cronProvider.UpdateStoricoImportazione(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertStoricoImportazione(ICron value)
        {
            return cronProvider.InsertStoricoImportazione(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectImportazioni()
        {
            return cronProvider.SelectImportazioni();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectImportazioniCron(Guid Uidtenant)
        {
            return cronProvider.SelectImportazioniCron(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int UpdateFuelCardConsumoCount(ICron value)
        {
            return cronProvider.UpdateFuelCardConsumoCount(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFuelCardConsumo(ICron value)
        {
            return cronProvider.InsertFuelCardConsumo(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFringeBenefit(ICron value)
        {
            return cronProvider.InsertFringeBenefit(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFattureXML(ICron value)
        {
            return cronProvider.InsertFattureXML(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFattureXMLDettaglio(ICron value)
        {
            return cronProvider.InsertFattureXMLDettaglio(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectUsersDimissionariAttivi()
        {
            return cronProvider.SelectUsersDimissionariAttivi();
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateEmail(ICron value)
        {
            return cronProvider.UpdateEmail(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateUserNameMembership(string NewUsername, string LoweredNewUsername, string OldUsername)
        {
            return cronProvider.UpdateUserNameMembership(NewUsername, LoweredNewUsername, OldUsername);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateUserNameMembership2(string NewUsername, string LoweredNewUsername, string OldUsername)
        {
            return cronProvider.UpdateUserNameMembership2(NewUsername, LoweredNewUsername, OldUsername);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int UpdateAccountCount(ICron value)
        {
            return cronProvider.UpdateAccountCount(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertAccount(ICron value)
        {
            return cronProvider.InsertAccount(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertConcur(ICron value)
        {
            return cronProvider.InsertConcur(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertTelePassConsumo(ICron value)
        {
            return cronProvider.InsertTelePassConsumo(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectAutoImmatricolazione()
        {
            return cronProvider.SelectAutoImmatricolazione();
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertRevisione(ICron value)
        {
            return cronProvider.InsertRevisione(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectRevisioniDaEffettuare()
        {
            return cronProvider.SelectRevisioniDaEffettuare();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectAllUserEmail()
        {
            return cronProvider.SelectAllUserEmail();
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateInvioMail(int idinvio, Guid Uidtenant)
        {
            return cronProvider.UpdateInvioMail(idinvio, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertInvioMail(ICron value)
        {
            return cronProvider.InsertInvioMail(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFuelCard(ICron value)
        {
            return cronProvider.InsertFuelCard(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateFuelCardCount(ICron value)
        {
            return cronProvider.UpdateFuelCardCount(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectViewConcurTxt()
        {
            return cronProvider.SelectViewConcurTxt();
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertConcur900(ICron value)
        {
            return cronProvider.InsertConcur900(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectViewConcur900Txt()
        {
            return cronProvider.SelectViewConcur900Txt();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectViewMovisionAnagrafiche()
        {
            return cronProvider.SelectViewMovisionAnagrafiche();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ICron> SelectViewMovisionBenefit()
        {
            return cronProvider.SelectViewMovisionBenefit();
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateZucchetti(ICron value)
        {
            return cronProvider.UpdateZucchetti(value);
        }
    }
}
