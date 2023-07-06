// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ICronBL.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using BusinessObject;

namespace BusinessLogic
{
    public interface ICronBL
    {
        List<ICron> SelectMulteDapagare();
        int UpdatePagamento(Guid Uid, Guid Uidtenant);
        List<ICron> SelectCedolini(string mese, string anno);
        int InsertFileCron(ICron value);
        List<ICron> SelectContrattiUserInScadenza();
        bool ExistUserCarPolicy(int idutente);
        int InsertUserCarPolicy(ICron value);
        ICron DetailId(Guid UserId);
        List<ICron> SelectContrattiDaChiudere();
        int UpdateContrattiDaChiudere(Guid Uid, Guid Uidtenant);
        int UpdateContrattiAssDaChiudere(int idcontratto, Guid Uidtenant);
        ICron UrlBlob();
        List<ICron> SelectComunicazioniInserite();
        ICron ReturnTemplateEmail(int idtemplate);
        List<ICron> SelectViewConcur();
        int UpdateStoricoImportazione(ICron value);
        ICron DetailImportazioni(int idprog);
        int InsertStoricoImportazione(ICron value);
        List<ICron> SelectImportazioni();
        List<ICron> SelectImportazioniCron(Guid Uidtenant);
        int UpdateFuelCardConsumoCount(ICron value);
        int InsertFuelCardConsumo(ICron value);
        bool ExistFuelCardConsumo2(string idtransazione, string numerofuelcard, DateTime datatransazione, decimal importo);
        bool ExistFuelCardConsumo3(string numerofuelcard, DateTime datatransazione, decimal importo);
        ICron ExistCodjatoAuto(string marca, string modello, string serie);
        int InsertFringeBenefit(ICron value);
        bool ExistFattura(string codfornitore, string numerodocumento, DateTime datadocumento);
        int InsertFattureXML(ICron value);
        int InsertFattureXMLDettaglio(ICron value);
        ICron UltimoUidFattura();
        List<ICron> SelectUsersDimissionariAttivi();
        int UpdateEmail(ICron value);
        int UpdateUserNameMembership(string NewUsername, string LoweredNewUsername, string OldUsername);
        int UpdateUserNameMembership2(string NewUsername, string LoweredNewUsername, string OldUsername);
        ICron ExistAnagraficaEmail(string email);
        int UpdateAccountCount(ICron value);
        int InsertAccount(ICron value);
        ICron ExistAnagraficaMatricola(string matricola);
        int InsertConcur(ICron value);
        int InsertTelePassConsumo(ICron value);
        bool ExistTelepassConsumo(string numerodispositivo, DateTime dataora);
        ICron ReturnTargaAssegnazioneXConcur(Guid UserId, DateTime dataspesa);
        ICron UltimoIDProg();
        ICron DetailSocieta(string codcompany);
        ICron ReturnCodCarPolicy(string codsocieta, string gradecode);
        ICron DetailIdUser(Guid UserId);
        ICron CredNetwork();
        ICron UltimoIDProgImp();
        List<ICron> SelectAutoImmatricolazione();
        int InsertRevisione(ICron value);
        List<ICron> SelectRevisioniDaEffettuare();
        bool ExistRevisione(string targa, int mese, int anno);
        List<ICron> SelectAllUserEmail();
        string InsTextEmail(string testomail, string nome, string cognome, string matricola, string codsocieta, string codgrade, string param1, string param2, string param3, string param4,
            string param5, string param6, string param7, string param8, string param9, string param10);
        int UpdateInvioMail(int idinvio, Guid Uidtenant);
        int InsertInvioMail(ICron value);
        ICron DetailNumeroFuelCardEnelX(string targa);
        int InsertFuelCard(ICron value);
        bool ExistFuelCard(int idcompagnia, string numerofuelcard);
        int UpdateFuelCardCount(ICron value);
        ICron ReturnSocietaXSigla(string siglasocieta);
        List<ICron> SelectViewConcurTxt();
        bool ExistDataConcur();
        ICron DetailConcur900(string matricola);
        int InsertConcur900(ICron value);
        List<ICron> SelectViewConcur900Txt();
        List<ICron> SelectViewMovisionAnagrafiche();
        List<ICron> SelectViewMovisionBenefit();
        int UpdateZucchetti(ICron value);
        bool ExistMatricola(string matricola, string codsocieta);
        ICron ReturnCodSocieta(string codzucchetti);
    }
}