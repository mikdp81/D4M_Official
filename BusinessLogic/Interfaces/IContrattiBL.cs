﻿// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IContratti.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using BusinessObject;

namespace BusinessLogic
{
    public interface IContrattiBL
    {
        int UpdateContratti(IContratti value);
        int DeleteContratti(IContratti value);
        int InsertContratti(IContratti value);
        IContratti DetailContrattiId(Guid Uid);
        List<IContratti> SelectContratti(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountContratti(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant);
        List<IContratti> SelectAllStatusContratto(Guid Uidtenant);
        List<IContratti> SelectAllStatusContrattoAss(Guid Uidtenant);
        List<IContratti> SelectAllStatusContrattoPool(Guid Uidtenant);
        int UpdateOrdini(IContratti value);
        int UpdateOrdini2(IContratti value);
        int DeleteOrdini(IContratti value);
        int InsertOrdini(IContratti value);
        IContratti DetailOrdiniId(Guid Uid);
        List<IContratti> SelectOrdini(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numeroordine, DateTime dataordinedal, DateTime dataordineal, int idstatusordine, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountOrdini(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numeroordine, DateTime dataordinedal, DateTime dataordineal, int idstatusordine, Guid Uidtenant);
        List<IContratti> SelectAllStatusOrdine(Guid Uidtenant);
        List<IContratti> SelectAllStatusOrdineAdmin(Guid Uidtenant);
        IContratti ReturnContrattoUser(DateTime datainfrazione, string targa);
        int InsertUserCarPolicy(IContratti value);
        bool ExistUserCarPolicyActive(int idutente);
        bool ExistUserCarPolicy(int idutente);
        IContratti ReturnIdApprovazione(int idutente);
        IContratti ReturnCodCarPolicy(string codsocieta, string gradecode);
        List<IContratti> SelectUserCarPolicyDaApprovare(string carpolicy, Guid UserId, string codsocieta, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountUserCarPolicyDaApprovare(string carpolicy, Guid UserId, string codsocieta, Guid Uidtenant);
        List<IContratti> SelectUserCarPolicyApprovati(string keysearch, string codsocieta, int flgmail, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountUserCarPolicyApprovati(string keysearch, string codsocieta, int flgmail, Guid Uidtenant);
        IContratti DetailUserCarPolicyId(Guid Uid);
        List<IContratti> SelectCarPolicy(string codsocieta, Guid Uidtenant);
        int UpdateApprovaCarPolicy(Guid Uid, string codcarpolicy, string preassegnazione, DateTime datadecorrenza, Guid Uidtenant);
        int UpdateInvioMailCarPolicy(Guid Uid, Guid Uidtenant);
        List<IContratti> SelectCarPolicyPool(string codsocieta, string gradepool);
        int SelectCountCarPolicyPool(string codsocieta, string gradepool);
        List<IContratti> SelectCarPolicyStep2(int idutente);
        int SelectCountCarPolicyStep2(int idutente);
        IContratti ReturnCodCarList(string codcarpolicy);
        IContratti ReturnUltimoIdOrdine();
        int InsertOrdineOptional(IContratti value);
        int UpdateOrdineOptional(IContratti value);
        IContratti ReturnUltimoNumeroOrdine();
        int SelectCountConfigurazioni(int idapprovazione);
        List<IContratti> SelectRichiesteOrdini(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountRichiesteOrdini(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant);
        int UpdateChangeStatusOrdine(Guid UserId, int idstatusordine, string motivoscarto, Guid Uidtenant);
        int UpdateOrdineConfermaRental(Guid Uid, int idstatusordine, string fileconfermarental, DateTime dataconsegnaprevista, string annotazioniordini, Guid Uidtenant);
        List<IContratti> SelectRichiesteOrdiniRental(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal, int numrecord, int pagina);
        int SelectCountRichiesteOrdiniRental(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal);
        List<IContratti> SelectRichiesteOrdiniDriver(string keysearch, Guid UserId, int numrecord, int pagina);
        int SelectCountRichiesteOrdiniDriver(string keysearch, Guid UserId);
        IContratti DetailVeicoloAttualeDriver(Guid UserId);
        IContratti DetailVeicoloAttualePartner(Guid UserId);
        int InsertKmPercorsi(IContratti value);
        List<IContratti> SelectKmPercorsi(Guid UserId, string targa);
        List<IContratti> SelectKmPercorsiXTarga(string targa);
        List<IContratti> SelectVolture(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountVolture(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant);
        List<IContratti> SelectContrattiXVolture(Guid Uidtenant);
        int UpdateChangeStatusContratto(Guid Uid, int idstatuscontratto, Guid Uidtenant);
        int UpdateContrattiXVoltura(IContratti value);
        List<IContratti> SelectVoltureDaAutorizzare(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountVoltureDaAutorizzare(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant);
        int UpdateContrattoVolturato(Guid Uid, DateTime datafinecontratto, Guid Uidtenant);
        List<IContratti> SelectRichiesteOrdiniXDriver(Guid UserId);
        int SelectCountRichiesteOrdiniXDriver(Guid UserId);
        int UpdateRinunciaCarPolicy(int idutente, Guid Uidtenant);
        int DeleteConfOrdine(int idordine, Guid Uidtenant);
        int DeleteConfOrdineOptional(int idordine, Guid Uidtenant);
        IContratti ReturnApprovatore(int idutente);
        List<IContratti> SelectStatusOrdineRental();
        List<IContratti> SelectStatusOrdineRentalEvasi();
        int UpdateDocCarPolicy(Guid Uid, string documentocarpolicy, string documentopatente, string documentofuelcard, Guid Uidtenant);
        IContratti ReturnUidCarPolicy(Guid UserId);
        int InsertOrdiniPool(IContratti value);
        IContratti ReturnUltimoNumeroOrdinePool();
        List<IContratti> SelectRichiesteOrdiniPool(string keysearch, string codsocieta, string codgrade, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountRichiesteOrdiniPool(string keysearch, string codsocieta, string codgrade, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant);
        IContratti DetailOrdiniPoolId(Guid UserId);
        int UpdateChangeStatusOrdinePool(Guid UserId, int idstatusordine, string motivoscarto, Guid Uidtenant);
        IContratti DetailContrattiId2(int idcontratto);
        int UpdateContrattiPool(IContratti value);
        List<IContratti> SelectRichiesteOrdiniPoolXDriver(Guid UserId);
        int SelectCountRichiesteOrdiniPoolXDriver(Guid UserId);
        int SelectCountConfigurazioniPool(Guid UserId);
        int UpdateTerminaAssegnazioneContratto(int idcontratto, DateTime assegnatoal, Guid Uidtenant);
        int InsertInizioAssegnazioneContratto(IContratti value);
        IContratti ReturnUltimoIdContratto();
        List<IContratti> SelectOrdiniContrattualizzati(Guid UserId);
        int SelectCountOrdiniContrattualizzati(Guid UserId);
        int UpdateRifiutaAuto(Guid Uid, Guid Uidtenant);
        int UpdateAccettaAuto(Guid Uid, Guid Uidtenant);
        List<IContratti> SelectRitiriAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountRitiriAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant);
        int UpdateChangeStatusOrdine2(Guid UserId, int idstatusordine, decimal deltacanone, string annotazioniordini, decimal canoneleasingofferta, string numeroordinefornitore, string alimentazione, Guid Uidtenant);
        List<IContratti> SelectDocCarPolicy(string check, Guid UserId, DateTime datadal, DateTime dataal, string flgdoccarpolicy, string flgdocpatente, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountDocCarPolicy(string check, Guid UserId, DateTime datadal, DateTime dataal, string flgdoccarpolicy, string flgdocpatente, Guid Uidtenant);
        int UpdateCheckDocPolicy(Guid Uid, Guid Uidtenant);
        int UpdateNotCheckDocPolicy(Guid Uid, Guid Uidtenant);
        List<IContratti> SelectContrattiAssXIdContratto(int idcontratto);
        List<IContratti> SelectRunningFleet(string targa, string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountRunningFleet(string targa, string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant);
        List<IContratti> SelectAutoPool(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountAutoPool(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant);
        int InsertDocDelega(IContratti value);
        int UpdatePdfDocDelega(int iddelega, string filepdf, Guid Uidtenant);
        IContratti ReturnUltimoIdDelega();
        IContratti DetailDocDelegaXId(Guid UserId, string targa);
        List<IContratti> SelectAllContrattiTipo(Guid Uidtenant);
        List<IContratti> SelectAllContrattiTipoUso(Guid Uidtenant);
        List<IContratti> SelectAllContrattiTipoAssegnazione(Guid Uidtenant);
        List<IContratti> SelectAutoXCarList(string codcarlist);
        List<IContratti> SelectCarPolicyXCarList(string codcarlist);
        List<IContratti> SelectCarPolicyXSocieta(string codsocieta);
        List<IContratti> SelectFornitoreXAuto(string codjatoauto);
        List<IContratti> SelectUsersXSocieta(string codsocieta);
        List<IContratti> SelectRiconsegnaAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountRiconsegnaAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant);
        IContratti DetailContrattiAssId(int idcontratto, Guid UserId); 
        int UpdateContrattiAss(IContratti value);
        int UpdateCheckContrattiAss(int idassegnazione, DateTime assegnatoal, Guid Uidtenant);
        int UpdateContrattiAssDriver(IContratti value);
        IContratti DetailContrattiXUidordine(Guid Uidordine);
        int UpdateRifiutaAuto2(int idassegnazione, string motivorifiutoauto, string filerifiutoauto, Guid Uidtenant);
        int UpdateAccettaAuto2(int idassegnazione, string fileverbaleauto, string filelibrettoauto, Guid Uidtenant);
        int UpdateContrattoConsegna(IContratti value);
        List<IContratti> SelectAllContrattiAss();
        IContratti ReturnUserIdAssPool(Guid Uidtenant);
        IContratti ReturnUserIdAssRitiro();
        int UpdateContrattoUserPool(IContratti value);
        List<IContratti> SelectStatusAuto(Guid Uidtenant);
        int InsertDocZTL(IContratti value);
        int UpdatePdfDocZTL(int iddelega, string filepdf, Guid Uidtenant);
        IContratti ReturnUltimoIdZTL();
        IContratti DetailDocZTLXId(Guid UserId, string targa);
        int UpdatePdfOrdine(int idordine, string fileordinepdf, Guid Uidtenant);
        int UpdatePdfOrdineFirmato(Guid Uid, string filefirma, Guid UserIdFirma, Guid Uidtenant);
        List<IContratti> SelectOrdiniDaFirmare(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountOrdiniDaFirmare(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant);
        List<IContratti> SelectOrdiniFirmati(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountOrdiniFirmati(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant);
        List<IContratti> SelectFatture(string keysearch, string codfornitore, string codsocieta, DateTime datadocumentodal, DateTime datadocumentoal, int idstatusfattura, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountFatture(string keysearch, string codfornitore, string codsocieta, DateTime datadocumentodal, DateTime datadocumentoal, int idstatusfattura, Guid Uidtenant);
        IContratti DetailFattureId(Guid Uid);
        List<IContratti> SelectDetailFatture(Guid Uidfattura, Guid Uidtenant, int pagina);
        int SelectCountDetailFatture(Guid Uidfattura, Guid Uidtenant);
        int UpdateAbbinaFattura(IContratti value);
        int UpdateStatusFattura(Guid Uid, int idstatusfattura, Guid Uidtenant);
        IContratti DetailFattureDetId(Guid Uid);
        bool ExistAssegnazioneContratto(Guid UserID, int idcontratto);
        int UpdateInizioAssegnazioneContratto(IContratti value);
        List<IContratti> SelectTemplateFatture(Guid Uidtenant);
        int UpdateSvuotaAbbinamentoFattura(Guid Uidfattura, Guid Uidtenant);
        List<IContratti> ReturnCodiceCDC(DateTime datariferimentoda, DateTime datariferimentoa, string targa);
        int UpdateStatusOrdineScartato(int idapprovazione, Guid Uid, Guid Uidtenant);
        int SelectCountConfigurazioniInviate(int idapprovazione);
        int SelectCountConfigurazioniDaFirmare(int idapprovazione);
        List<IContratti> SelectUserCarPolicy(string keysearch, string codsocieta, Guid UserId, DateTime datadal, DateTime dataal, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountUserCarPolicy(string keysearch, string codsocieta, Guid UserId, DateTime datadal, DateTime dataal, Guid Uidtenant);
        int SelectCountConfigurazioniDaConfermareInviate(int idapprovazione);
        int SelectCountConfigurazioniDaEvadereInviate(Guid UserId);
        int SelectCountConfigurazioniEvaseInviate(int idapprovazione);
        decimal SelectToTFuelXUser(string targa, Guid UserId);
        List<IContratti> SelectStoricoAutoUser(Guid UserId);
        List<IContratti> SelectDocumentiAuto(string targa);
        List<IContratti> SelectConsumiAutoXUser(string targa, DateTime datadal, DateTime dataal, Guid UserId);
        int InsertDocAuto(IContratti value);
        List<IContratti> SelectFileAuto(string targa, string codsocieta, Guid UserId, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountFileAuto(string targa, string codsocieta, Guid UserId, Guid Uidtenant);
        List<IContratti> SelectFileDocumentiAuto(string targa);
        int UpdateFileAuto(IContratti value);
        int SelectCountInConfigurazione(int idapprovazione);
        IContratti SelectKmPercorsiAttuali(string targa);
        int SelectCountFringeInCorso(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant);
        List<IContratti> SelectFringeInCorso(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant, int numrecord, int pagina);
        List<IContratti> SelectOrdiniInCorsoTeamAppr(string keysearch, string codsocieta, string codgrade, string codcarlist, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountOrdiniInCorsoTeamAppr(string keysearch, string codsocieta, string codgrade, string codcarlist, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant);
        List<IContratti> SelectAllStatusOrdineApprovatori(Guid Uidtenant);
        List<IContratti> SelectCarPolicyPoolTeamAppr(string keysearch, string codsocieta, string targa, int idstatuspool, string luogo, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountCarPolicyPoolTeamAppr(string keysearch, string codsocieta, string targa, int idstatuspool, string luogo, Guid Uidtenant);
        List<IContratti> SelectRunningTeamAppr(string codsocieta, Guid UserId, string marca, string modello, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountRunningTeamAppr(string codsocieta, Guid UserId, string marca, string modello, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant);
        int UpdateAutoPool(IContratti value);
        int SelectCountOrdiniRental(string codfornitore, int idstatus);
        List<IContratti> SelectRichiesteOrdiniRentalEvasi(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal, int numrecord, int pagina);
        int SelectCountRichiesteOrdiniRentalEvasi(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal);
        int SelectCountUserCarPolicyPageAdmin(string codsocieta, string carpolicy, Guid UserId, Guid Uidtenant);
        List<IContratti> SelectUserCarPolicyPageAdmin(string codsocieta, string carpolicy, Guid UserId, Guid Uidtenant, int numrecord, int pagina);
        IContratti ExistOldUserCarPolicy(int idutente);
        bool ExistStoricoAuto(Guid UserID);
        List<IContratti> SelectAutoUser(Guid UserId);
        List<IContratti> SelectOrdiniUser(Guid UserId);
        List<IContratti> SelectFuelCardUser(Guid UserId);
        List<IContratti> SelectStatusFatture(Guid Uidtenant);
        int SelectCountFattureNonAbbinate(Guid Uidfattura);
        int UpdateProrogaContratto(Guid Uid, DateTime dataproroga, string nota, Guid Uidtenant);
        List<IContratti> SelectAssegnazioniContratti(string targa, string targasearch, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountAssegnazioniContratti(string targa, string targasearch, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant);
        IContratti DetailAssegnazioniContrattiXId(int idassegnazione);
        int UpdateAssegnazioneContratto(IContratti value);
        int UpdateRiconsegnaAuto(IContratti value);
        IContratti DetailDriverXCdc(string tipocentro, Guid Uid);
        int UpdateFatturaAbb(Guid Uid, int templateabb, DateTime datarifabb, Guid Uidtenant);
        IContratti DetailTemplateFattureId(int idtemplate);
        int SelectCountAllDeltaCanone(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant);
        List<IContratti> SelectAllDeltaCanone(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant, int numrecord, int pagina);
        List<IContratti> SelectDetailFattureGroup(Guid Uidfattura);
        List<IContratti> SelectDetailConsumiGroup(string numerofattura, int idcompagnia, DateTime datafattura);
        List<IContratti> SelectDetailConsumiTelePassGroup(int idcompagnia, DateTime datafatturada, DateTime datafatturaa);
        List<IContratti> SelectFattureDeltaCanone(string codsocieta, Guid UserId, string mese, int anno);
        List<IContratti> SelectNoteCreditoDeltaCanone(string codsocieta, Guid UserId, string mese, int anno);
        List<IContratti> SelectFattureMulte(string targa, Guid UserId, string mese, int anno);
        List<IContratti> SelectFattureMulteFee(string codsocieta, Guid UserId, string mese, int anno);
        List<IContratti> SelectNoteCreditoMulte(string targa, Guid UserId, string mese, int anno);
        int UpdatePoolContratto(Guid Uid, int checkordinepool, string gradepool, Guid Uidtenant);
        IContratti ReturnAssegnatoAlMaggiore(int idcontratto);
        int UpdateDataFineContratto(int idcontratto, DateTime datafinecontratto, Guid UserId, Guid Uidtenant);
        int UpdateDeltaCanoneOrdini(IContratti value);
        List<IContratti> SelectDelegheUser(int idtipomodulo, Guid UserId);
        List<IContratti> SelectDeleghe(Guid UserId, DateTime datadocumentodal, DateTime datadocumentoal, string checkapprovatore, int idtipomodulo, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountDeleghe(Guid UserId, DateTime datadocumentodal, DateTime datadocumentoal, string checkapprovatore, int idtipomodulo, Guid Uidtenant);
        int InsertDelega(IContratti value);
        int UpdateDelega(IContratti value);
        IContratti DetailDelega(Guid Uid);
        List<IContratti> SelectAutoXFornitore(string codfornitore, Guid Uidtenant);
        int UpdatePoolContratto2(IContratti value);
        List<IContratti> SelectViewCarPolicyPoolTeamAppr(string keysearch, string codsocieta, string targa, int idstatuspool);
        int UpdateCarPolicy(IContratti value);
        int UpdateDocFuelCard(int idassegnazione, string documentofuelcard, Guid Uidtenant);
        IContratti ReturnFileAuto(int idassegnazione);
        List<IContratti> SelectAutoSostitutive(string targa, Guid UserId, string codsocieta, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountAutoSostitutive(string targa, Guid UserId, string codsocieta, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant);
        int UpdateAutoSost(IContratti value);
        int InsertAutoSost(IContratti value);
        IContratti DetailAutoSostId(Guid Uid);
        int DeleteAssegnazione(IContratti value);
        bool ExistTargaAss(string targa);
        bool ExistAssegnazione(Guid UserId, string codsocieta, DateTime assegnatodal, DateTime assegnatoal, string targa);
        int UpdateApprovaDelega(string checkapprovatore, string noteapprovazione, Guid Uid, Guid Uidtenant);
        IContratti ReturnTargaAssegnazioneXConcur(Guid UserId, DateTime dataspesa);
        IContratti ReturnModConv(Guid Uid);
        int UpdateModConv(Guid Uid, string moduloconvivenza, Guid Uidtenant);
        IContratti ReturnLuogoRestituzioneXTarga(string targa);
        List<IContratti> SelectCarBenefit(Guid Uidtenant);
        IContratti ReturnTypeCarPolicy(int idutente);
        int UpdateUserCarPolicy(int idapprovazione, string sceltabenefit, string codpacchetto, DateTime datasceltabenefit, Guid Uidtenant);
        IContratti ReturnDatiBenefitCarPolicy(int idapprovazione);
        int InsertCarPolicy(IContratti value);
        int InsertConfigurazionePartner(IContratti value);
        IContratti ReturnIdConf();
        int InsertAllegato(IContratti value);
        int InsertDelegaDriver(IContratti value);
        int DeleteDeleghePartner(IContratti value);
        List<IContratti> SelectDeleghePartner(Guid UserId);
        List<IContratti> SelectDelegheDriver(Guid UserId);
        List<IContratti> SelectContrattiPartner(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountContrattiPartner(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant);
        List<IContratti> SelectRichiesteOrdiniPartner(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountRichiesteOrdiniPartner(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant);
        List<IContratti> SelectConfigurazioniPartner(DateTime datadal, DateTime dataal, Guid UserId, int idstatuordine, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountConfigurazioniPartner(DateTime datadal, DateTime dataal, Guid UserId, int idstatuordine, Guid Uidtenant);
        List<IContratti> SelectAllegatiConfigurazioniPartner(int idconfigurazione);
        IContratti DetailConfigurazionePartner(Guid Uid);
        List<IContratti> SelectAllTipoPenaleAuto(Guid Uidtenant);
        List<IContratti> SelectPenaliAuto(Guid UserId, string targa, string codfornitore, string numerofattura, DateTime datafatturadal, DateTime datafatturaal, int idtipopenaleauto, string status, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountPenaliAuto(Guid UserId, string targa, string codfornitore, string numerofattura, DateTime datafatturadal, DateTime datafatturaal, int idtipopenaleauto, string status, Guid Uidtenant);
        int InsertPenale(IContratti value);
        IContratti DetailIdPenale(Guid Uid);
        int UpdatePenale(IContratti value);
        int UpdateStatusPenale(IContratti value);
        List<IContratti> SelectStatusConfigurazionePartner(Guid Uidtenant);
        int UpdateStatusConfigurazionePartner(IContratti value);
        int SelectCountDelegheDriver(Guid UserId);
        IContratti ExistCarPolicyMobilita(string codcarpolicy);
        int SelectCountRichiesteOrdiniDriverXCodjato(Guid UserId, string codjatoauto);
        List<IContratti> SelectOptionalAutoXOrdine(int idordine);
        int UpdateFileLibrettoAuto(Guid Uid, string filelibrettoautocontratto, Guid Uidtenant);
        int DeleteAutoSost(Guid Uid, Guid Uidtenant);
        List<IContratti> SelectExtraPlafond(string codsocieta, Guid UserId, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountExtraPlafond(string codsocieta, Guid UserId, Guid Uidtenant);
        int DeletePenali(IContratti value);
        List<IContratti> SelectRevisioniUser(Guid UserId, string targa, int anno, int numrecord, int pagina);
        int SelectCountRevisioniUser(Guid UserId, string targa, int anno);
        IContratti DetailRevisioniId(Guid Uid);
        int UpdateCheckRevisione(Guid Uid, string filerev, Guid Uidtenant);
        List<IContratti> SelectRevisioniAll(Guid UserId, string targa, int anno, int statuscheck, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountRevisioniAll(Guid UserId, string targa, int anno, int statuscheck, Guid Uidtenant);
        List<IContratti> SelectTipoUtilizzo(Guid Uidtenant);
        List<IContratti> SelectAutoServizio(string targa, string targasearch, Guid UserId, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountAutoServizio(string targa, string targasearch, Guid UserId, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant);
        List<IContratti> SelectPrenotazioniAutoServizio(string targa);
        bool ExistPrenotazioneAutoServizio(DateTime datadal, DateTime dataal, string targa);
        int InsertPrenotazioneAutoServizio(IContratti value);
        IContratti ReturnOrdineFirma(Guid Uidtenant);
        IContratti DetailAutoServizioId(int idassegnazione);
        int UpdateAutoServizio(IContratti value);
        List<IContratti> SelectLibrettoAutoServizio(string targa, Guid UserId, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountLibrettoAutoServizio(string targa, Guid UserId, Guid Uidtenant);
        IContratti DetailLibrettoAutoServizioXTarga(string targa);
        List<IContratti> SelectDetailLibrettoAutoServizio(string targa);
        List<IContratti> SelectAllScopoViaggio(Guid Uidtenant);
        List<IContratti> SelectAutoServizioDispo(Guid Uidtenant);
        List<IContratti> DispoAutoServizioXDay(string targa, DateTime datains);
        int UpdateAutorizzaAutoServizio(int idassegnazione, Guid Uidtenant);
    }
}