// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IODSCron.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface IOdsCron
    {
        List<ICron> SelectMulteDapagare();
        int UpdatePagamento(Guid Uid, Guid Uidtenant);
        List<ICron> SelectCedolini(string mese, string anno);
        int InsertFileCron(ICron value);
        List<ICron> SelectContrattiUserInScadenza();
        int InsertUserCarPolicy(ICron value);
        List<ICron> SelectContrattiDaChiudere();
        int UpdateContrattiDaChiudere(Guid Uid, Guid Uidtenant);
        int UpdateContrattiAssDaChiudere(int idcontratto, Guid Uidtenant);
        List<ICron> SelectComunicazioniInserite();
        List<ICron> SelectViewConcur();
        int UpdateStoricoImportazione(ICron value);
        int InsertStoricoImportazione(ICron value);
        List<ICron> SelectImportazioni();
        List<ICron> SelectImportazioniCron(Guid Uidtenant);
        int UpdateFuelCardConsumoCount(ICron value);
        int InsertFuelCardConsumo(ICron value);
        int InsertFringeBenefit(ICron value);
        int InsertFattureXML(ICron value);
        int InsertFattureXMLDettaglio(ICron value);
        List<ICron> SelectUsersDimissionariAttivi();
        int UpdateEmail(ICron value);
        int UpdateUserNameMembership(string NewUsername, string LoweredNewUsername, string OldUsername);
        int UpdateUserNameMembership2(string NewUsername, string LoweredNewUsername, string OldUsername);
        int UpdateAccountCount(ICron value);
        int InsertAccount(ICron value);
        int InsertConcur(ICron value);
        int InsertTelePassConsumo(ICron value);
        List<ICron> SelectAutoImmatricolazione();
        int InsertRevisione(ICron value);
        List<ICron> SelectRevisioniDaEffettuare();
        List<ICron> SelectAllUserEmail();
        int UpdateInvioMail(int idinvio, Guid Uidtenant);
        int InsertInvioMail(ICron value);
        int InsertFuelCard(ICron value);
        int UpdateFuelCardCount(ICron value);
        int InsertConcur900(ICron value);
        List<ICron> SelectViewConcur900Txt();
        List<ICron> SelectViewMovisionAnagrafiche();
        List<ICron> SelectViewMovisionBenefit();
        int UpdateZucchetti(ICron value);
    }
}
