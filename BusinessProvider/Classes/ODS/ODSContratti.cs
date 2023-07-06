// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CODSContratti.cs" company="">
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

    public class OdsContratti : ODSProvider<ContrattiProvider>, IOdsContratti
    {
        private readonly ContrattiProvider contrattiProvider = (ContrattiProvider)new ProviderFactory().ServizioAccount;
        
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateContratti(IContratti value)
        {
            return contrattiProvider.UpdateContratti(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteContratti(IContratti value)
        {
            return contrattiProvider.DeleteContratti(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertContratti(IContratti value)
        {
            return contrattiProvider.InsertContratti(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectContratti(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return contrattiProvider.SelectContratti(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountContratti(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountContratti(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllStatusContratto(Guid Uidtenant)
        {
            return contrattiProvider.SelectAllStatusContratto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllStatusContrattoAss(Guid Uidtenant)
        {
            return contrattiProvider.SelectAllStatusContrattoAss(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllStatusContrattoPool(Guid Uidtenant)
        {
            return contrattiProvider.SelectAllStatusContrattoPool(Uidtenant);
        }


        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateOrdini(IContratti value)
        {
            return contrattiProvider.UpdateOrdini(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateOrdini2(IContratti value)
        {
            return contrattiProvider.UpdateOrdini2(value);
        }


        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteOrdini(IContratti value)
        {
            return contrattiProvider.DeleteOrdini(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertOrdini(IContratti value)
        {
            return contrattiProvider.InsertOrdini(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOrdini(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numeroordine, DateTime dataordinedal, DateTime dataordineal, int idstatusordine, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return contrattiProvider.SelectOrdini(codsocieta, UserId, marca, modello, codfornitore, numeroordine, dataordinedal, dataordineal, idstatusordine, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountOrdini(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numeroordine, DateTime dataordinedal, DateTime dataordineal, int idstatusordine, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountOrdini(codsocieta, UserId, marca, modello, codfornitore, numeroordine, dataordinedal, dataordineal, idstatusordine, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllStatusOrdine(Guid Uidtenant)
        {
            return contrattiProvider.SelectAllStatusOrdine(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllStatusOrdineAdmin(Guid Uidtenant)
        {
            return contrattiProvider.SelectAllStatusOrdineAdmin(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertUserCarPolicy(IContratti value)
        {
            return contrattiProvider.InsertUserCarPolicy(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectUserCarPolicyDaApprovare(string carpolicy, Guid UserId, string codsocieta, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectUserCarPolicyDaApprovare(carpolicy, UserId, codsocieta, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountUserCarPolicyDaApprovare(string carpolicy, Guid UserId, string codsocieta, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountUserCarPolicyDaApprovare(carpolicy, UserId, codsocieta, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectUserCarPolicyApprovati(string keysearch, string codsocieta, int flgmail, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectUserCarPolicyApprovati(keysearch, codsocieta, flgmail, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountUserCarPolicyApprovati(string keysearch, string codsocieta, int flgmail, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountUserCarPolicyApprovati(keysearch, codsocieta, flgmail, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarPolicy(string codsocieta, Guid Uidtenant)
        {
            return contrattiProvider.SelectCarPolicy(codsocieta, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateApprovaCarPolicy(Guid Uid, string codcarpolicy, string preassegnazione, DateTime datadecorrenza, Guid Uidtenant)
        {
            return contrattiProvider.UpdateApprovaCarPolicy(Uid, codcarpolicy, preassegnazione, datadecorrenza, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateInvioMailCarPolicy(Guid Uid, Guid Uidtenant)
        {
            return contrattiProvider.UpdateInvioMailCarPolicy(Uid, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarPolicyPool(string codsocieta, string gradepool)
        {
            return contrattiProvider.SelectCarPolicyPool(codsocieta, gradepool);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountCarPolicyPool(string codsocieta, string gradepool)
        {
            return contrattiProvider.SelectCountCarPolicyPool(codsocieta, gradepool);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarPolicyStep2(int idutente)
        {
            return contrattiProvider.SelectCarPolicyStep2(idutente);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountCarPolicyStep2(int idutente)
        {
            return contrattiProvider.SelectCountCarPolicyStep2(idutente);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertOrdineOptional(IContratti value)
        {
            return contrattiProvider.InsertOrdineOptional(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateOrdineOptional(IContratti value)
        {
            return contrattiProvider.UpdateOrdineOptional(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountConfigurazioni(int idapprovazione)
        {
            return contrattiProvider.SelectCountConfigurazioni(idapprovazione);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdini(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectRichiesteOrdini(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, idstatusordine, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRichiesteOrdini(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountRichiesteOrdini(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, idstatusordine, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateChangeStatusOrdine(Guid UserId, int idstatusordine, string motivoscarto, Guid Uidtenant)
        {
            return contrattiProvider.UpdateChangeStatusOrdine(UserId, idstatusordine, motivoscarto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateOrdineConfermaRental(Guid UserId, int idstatusordine, string fileconfermarental, DateTime dataconsegnaprevista, string annotazioniordini, Guid Uidtenant)
        {
            return contrattiProvider.UpdateOrdineConfermaRental(UserId, idstatusordine, fileconfermarental, dataconsegnaprevista, annotazioniordini, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniRental(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal, int numrecord, int pagina)
        {
            return contrattiProvider.SelectRichiesteOrdiniRental(idstatusordine, keysearch, UserId, codfornitore, codsocieta, datadal, dataal, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRichiesteOrdiniRental(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal)
        {
            return contrattiProvider.SelectCountRichiesteOrdiniRental(idstatusordine, keysearch, UserId, codfornitore, codsocieta, datadal, dataal);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniDriver(string keysearch, Guid UserId, int numrecord, int pagina)
        {
            return contrattiProvider.SelectRichiesteOrdiniDriver(keysearch, UserId, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRichiesteOrdiniDriver(string keysearch, Guid UserId)
        {
            return contrattiProvider.SelectCountRichiesteOrdiniDriver(keysearch, UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertKmPercorsi(IContratti value)
        {
            return contrattiProvider.InsertKmPercorsi(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectKmPercorsi(Guid UserId, string targa)
        {
            return contrattiProvider.SelectKmPercorsi(UserId, targa);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectKmPercorsiXTarga(string targa)
        {
            return contrattiProvider.SelectKmPercorsiXTarga(targa);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectVolture(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return contrattiProvider.SelectVolture(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountVolture(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountVolture(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectContrattiXVolture(Guid Uidtenant)
        {
            return contrattiProvider.SelectContrattiXVolture(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateChangeStatusContratto(Guid Uid, int idstatuscontratto, Guid Uidtenant)
        {
            return contrattiProvider.UpdateChangeStatusContratto(Uid, idstatuscontratto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateContrattiXVoltura(IContratti value)
        {
            return contrattiProvider.UpdateContrattiXVoltura(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectVoltureDaAutorizzare(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return contrattiProvider.SelectVoltureDaAutorizzare(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountVoltureDaAutorizzare(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountVoltureDaAutorizzare(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateContrattoVolturato(Guid Uid, DateTime datafinecontratto, Guid Uidtenant)
        {
            return contrattiProvider.UpdateContrattoVolturato(Uid, datafinecontratto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniXDriver(Guid UserId)
        {
            return contrattiProvider.SelectRichiesteOrdiniXDriver(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRichiesteOrdiniXDriver(Guid UserId)
        {
            return contrattiProvider.SelectCountRichiesteOrdiniXDriver(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateRinunciaCarPolicy(int idutente, Guid Uidtenant)
        {
            return contrattiProvider.UpdateRinunciaCarPolicy(idutente, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteConfOrdine(int idordine, Guid Uidtenant)
        {
            return contrattiProvider.DeleteConfOrdine(idordine, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteConfOrdineOptional(int idordine, Guid Uidtenant)
        {
            return contrattiProvider.DeleteConfOrdineOptional(idordine, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectStatusOrdineRental()
        {
            return contrattiProvider.SelectStatusOrdineRental();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectStatusOrdineRentalEvasi()
        {
            return contrattiProvider.SelectStatusOrdineRentalEvasi();
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateDocCarPolicy(Guid Uid, string documentocarpolicy, string documentopatente, string documentofuelcard, Guid Uidtenant)
        {
            return contrattiProvider.UpdateDocCarPolicy(Uid, documentocarpolicy, documentopatente, documentofuelcard, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertOrdiniPool(IContratti value)
        {
            return contrattiProvider.InsertOrdiniPool(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniPool(string keysearch, string codsocieta, string codgrade, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectRichiesteOrdiniPool(keysearch, codsocieta, codgrade, datadal, dataal, UserId, idstatusordine, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRichiesteOrdiniPool(string keysearch, string codsocieta, string codgrade, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountRichiesteOrdiniPool(keysearch, codsocieta, codgrade, datadal, dataal, UserId, idstatusordine, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateChangeStatusOrdinePool(Guid UserId, int idstatusordine, string motivoscarto, Guid Uidtenant)
        {
            return contrattiProvider.UpdateChangeStatusOrdinePool(UserId, idstatusordine, motivoscarto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateContrattiPool(IContratti value)
        {
            return contrattiProvider.UpdateContrattiPool(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniPoolXDriver(Guid UserId)
        {
            return contrattiProvider.SelectRichiesteOrdiniPoolXDriver(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRichiesteOrdiniPoolXDriver(Guid UserId)
        {
            return contrattiProvider.SelectCountRichiesteOrdiniPoolXDriver(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountConfigurazioniPool(Guid UserId)
        {
            return contrattiProvider.SelectCountConfigurazioniPool(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateTerminaAssegnazioneContratto(int idcontratto, DateTime assegnatoal, Guid Uidtenant)
        {
            return contrattiProvider.UpdateTerminaAssegnazioneContratto(idcontratto, assegnatoal, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertInizioAssegnazioneContratto(IContratti value)
        {
            return contrattiProvider.InsertInizioAssegnazioneContratto(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOrdiniContrattualizzati(Guid UserId)
        {
            return contrattiProvider.SelectOrdiniContrattualizzati(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountOrdiniContrattualizzati(Guid UserId)
        {
            return contrattiProvider.SelectCountOrdiniContrattualizzati(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateRifiutaAuto(Guid Uid, Guid Uidtenant)
        {
            return contrattiProvider.UpdateRifiutaAuto(Uid, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateAccettaAuto(Guid Uid, Guid Uidtenant)
        {
            return contrattiProvider.UpdateAccettaAuto(Uid, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRitiriAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectRitiriAuto(targa, UserId, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatusassegnazione, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRitiriAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountRitiriAuto(targa, UserId, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatusassegnazione, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateChangeStatusOrdine2(Guid UserId, int idstatusordine, decimal deltacanone, string annotazioniordini, decimal canoneleasingofferta, string numeroordinefornitore, string alimentazione, Guid Uidtenant)
        {
            return contrattiProvider.UpdateChangeStatusOrdine2(UserId, idstatusordine, deltacanone, annotazioniordini, canoneleasingofferta, numeroordinefornitore, alimentazione, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDocCarPolicy(string check, Guid UserId, DateTime datadal, DateTime dataal, string flgdoccarpolicy, string flgdocpatente, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectDocCarPolicy(check, UserId, datadal, dataal, flgdoccarpolicy, flgdocpatente, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountDocCarPolicy(string check, Guid UserId, DateTime datadal, DateTime dataal, string flgdoccarpolicy, string flgdocpatente, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountDocCarPolicy(check, UserId, datadal, dataal, flgdoccarpolicy, flgdocpatente, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateCheckDocPolicy(Guid Uid, Guid Uidtenant)
        {
            return contrattiProvider.UpdateCheckDocPolicy(Uid, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateNotCheckDocPolicy(Guid Uid, Guid Uidtenant)
        {
            return contrattiProvider.UpdateNotCheckDocPolicy(Uid, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectContrattiAssXIdContratto(int idcontratto)
        {
            return contrattiProvider.SelectContrattiAssXIdContratto(idcontratto);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRunningFleet(string targa, string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return contrattiProvider.SelectRunningFleet(targa, codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRunningFleet(string targa, string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountRunningFleet(targa, codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoPool(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return contrattiProvider.SelectAutoPool(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountAutoPool(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountAutoPool(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertDocDelega(IContratti value)
        {
            return contrattiProvider.InsertDocDelega(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int UpdatePdfDocDelega(int iddelega, string filepdf, Guid Uidtenant)
        {
            return contrattiProvider.UpdatePdfDocDelega(iddelega, filepdf, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllContrattiTipo(Guid Uidtenant)
        {
            return contrattiProvider.SelectAllContrattiTipo(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllContrattiTipoUso(Guid Uidtenant)
        {
            return contrattiProvider.SelectAllContrattiTipoUso(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllContrattiTipoAssegnazione(Guid Uidtenant)
        {
            return contrattiProvider.SelectAllContrattiTipoAssegnazione(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoXCarList(string codcarlist)
        {
            return contrattiProvider.SelectAutoXCarList(codcarlist);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarPolicyXCarList(string codcarlist)
        {
            return contrattiProvider.SelectCarPolicyXCarList(codcarlist);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarPolicyXSocieta(string codsocieta)
        {
            return contrattiProvider.SelectCarPolicyXSocieta(codsocieta);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFornitoreXAuto(string codjatoauto)
        {
            return contrattiProvider.SelectFornitoreXAuto(codjatoauto);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectUsersXSocieta(string codsocieta)
        {
            return contrattiProvider.SelectUsersXSocieta(codsocieta);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRiconsegnaAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectRiconsegnaAuto(targa, UserId, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatusassegnazione, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRiconsegnaAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountRiconsegnaAuto(targa, UserId, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatusassegnazione, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateContrattiAss(IContratti value)
        {
            return contrattiProvider.UpdateContrattiAss(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateCheckContrattiAss(int idassegnazione, DateTime assegnatoal, Guid Uidtenant)
        {
            return contrattiProvider.UpdateCheckContrattiAss(idassegnazione, assegnatoal, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateContrattiAssDriver(IContratti value)
        {
            return contrattiProvider.UpdateContrattiAssDriver(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateRifiutaAuto2(int idassegnazione, string motivorifiutoauto, string filerifiutoauto, Guid Uidtenant)
        {
            return contrattiProvider.UpdateRifiutaAuto2(idassegnazione, motivorifiutoauto, filerifiutoauto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateAccettaAuto2(int idassegnazione, string fileverbaleauto, string filelibrettoauto, Guid Uidtenant)
        {
            return contrattiProvider.UpdateAccettaAuto2(idassegnazione, fileverbaleauto, filelibrettoauto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateContrattoConsegna(IContratti value)
        {
            return contrattiProvider.UpdateContrattoConsegna(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllContrattiAss()
        {
            return contrattiProvider.SelectAllContrattiAss();
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateContrattoUserPool(IContratti value)
        {
            return contrattiProvider.UpdateContrattoUserPool(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectStatusAuto(Guid Uidtenant)
        {
            return contrattiProvider.SelectStatusAuto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertDocZTL(IContratti value)
        {
            return contrattiProvider.InsertDocZTL(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int UpdatePdfDocZTL(int iddelega, string filepdf, Guid Uidtenant)
        {
            return contrattiProvider.UpdatePdfDocZTL(iddelega, filepdf, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int UpdatePdfOrdine(int idordine, string fileordinepdf, Guid Uidtenant)
        {
            return contrattiProvider.UpdatePdfOrdine(idordine, fileordinepdf, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int UpdatePdfOrdineFirmato(Guid Uid, string filefirma, Guid UserIdFirma, Guid Uidtenant)
        {
            return contrattiProvider.UpdatePdfOrdineFirmato(Uid, filefirma, UserIdFirma, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOrdiniDaFirmare(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectOrdiniDaFirmare(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountOrdiniDaFirmare(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountOrdiniDaFirmare(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOrdiniFirmati(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectOrdiniFirmati(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountOrdiniFirmati(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountOrdiniFirmati(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFatture(string keysearch, string codfornitore, string codsocieta, DateTime datadocumentodal, DateTime datadocumentoal, int idstatusfattura, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return contrattiProvider.SelectFatture(keysearch, codfornitore, codsocieta, datadocumentodal, datadocumentoal, idstatusfattura, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountFatture(string keysearch, string codfornitore, string codsocieta, DateTime datadocumentodal, DateTime datadocumentoal, int idstatusfattura, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountFatture(keysearch, codfornitore, codsocieta, datadocumentodal, datadocumentoal, idstatusfattura, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDetailFatture(Guid Uidfattura, Guid Uidtenant, int pagina)
        {
            return contrattiProvider.SelectDetailFatture(Uidfattura, Uidtenant, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountDetailFatture(Guid Uidfattura, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountDetailFatture(Uidfattura, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateAbbinaFattura(IContratti value)
        {
            return contrattiProvider.UpdateAbbinaFattura(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateStatusFattura(Guid Uid, int idstatusfattura, Guid Uidtenant)
        {
            return contrattiProvider.UpdateStatusFattura(Uid, idstatusfattura, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int UpdateInizioAssegnazioneContratto(IContratti value)
        {
            return contrattiProvider.UpdateInizioAssegnazioneContratto(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectTemplateFatture(Guid Uidtenant)
        {
            return contrattiProvider.SelectTemplateFatture(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int UpdateSvuotaAbbinamentoFattura(Guid Uidfattura, Guid Uidtenant)
        {
            return contrattiProvider.UpdateSvuotaAbbinamentoFattura(Uidfattura, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int UpdateStatusOrdineScartato(int idapprovazione, Guid Uid, Guid Uidtenant)
        {
            return contrattiProvider.UpdateStatusOrdineScartato(idapprovazione, Uid, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountConfigurazioniInviate(int idapprovazione)
        {
            return contrattiProvider.SelectCountConfigurazioniInviate(idapprovazione);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountConfigurazioniDaFirmare(int idapprovazione)
        {
            return contrattiProvider.SelectCountConfigurazioniDaFirmare(idapprovazione);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectUserCarPolicy(string keysearch, string codsocieta, Guid UserId, DateTime datadal, DateTime dataal, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectUserCarPolicy(keysearch, codsocieta, UserId, datadal, dataal, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountUserCarPolicy(string keysearch, string codsocieta, Guid UserId, DateTime datadal, DateTime dataal, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountUserCarPolicy(keysearch, codsocieta, UserId, datadal, dataal, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountConfigurazioniDaConfermareInviate(int idapprovazione)
        {
            return contrattiProvider.SelectCountConfigurazioniDaConfermareInviate(idapprovazione);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountConfigurazioniDaEvadereInviate(Guid UserId)
        {
            return contrattiProvider.SelectCountConfigurazioniDaEvadereInviate(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountConfigurazioniEvaseInviate(int idapprovazione)
        {
            return contrattiProvider.SelectCountConfigurazioniEvaseInviate(idapprovazione);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public decimal SelectToTFuelXUser(string targa, Guid UserId)
        {
            return contrattiProvider.SelectToTFuelXUser(targa, UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectStoricoAutoUser(Guid UserId)
        {
            return contrattiProvider.SelectStoricoAutoUser(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDocumentiAuto(string targa)
        {
            return contrattiProvider.SelectDocumentiAuto(targa);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectConsumiAutoXUser(string targa, DateTime datadal, DateTime dataal, Guid UserId)
        {
            return contrattiProvider.SelectConsumiAutoXUser(targa, datadal, dataal, UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertDocAuto(IContratti value)
        {
            return contrattiProvider.InsertDocAuto(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFileAuto(string targa, string codsocieta, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectFileAuto(targa, codsocieta, UserId, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountFileAuto(string targa, string codsocieta, Guid UserId, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountFileAuto(targa, codsocieta, UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFileDocumentiAuto(string targa)
        {
            return contrattiProvider.SelectFileDocumentiAuto(targa);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateFileAuto(IContratti value)
        {
            return contrattiProvider.UpdateFileAuto(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountInConfigurazione(int idapprovazione)
        {
            return contrattiProvider.SelectCountInConfigurazione(idapprovazione);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountFringeInCorso(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountFringeInCorso(codsocieta, UserId, mese, anno, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFringeInCorso(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectFringeInCorso(codsocieta, UserId, mese, anno, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOrdiniInCorsoTeamAppr(string keysearch, string codsocieta, string codgrade, string codcarlist, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectOrdiniInCorsoTeamAppr(keysearch, codsocieta, codgrade, codcarlist, datadal, dataal, UserId, idstatusordine, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountOrdiniInCorsoTeamAppr(string keysearch, string codsocieta, string codgrade, string codcarlist, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountOrdiniInCorsoTeamAppr(keysearch, codsocieta, codgrade, codcarlist, datadal, dataal, UserId, idstatusordine, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllStatusOrdineApprovatori(Guid Uidtenant)
        {
            return contrattiProvider.SelectAllStatusOrdineApprovatori(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarPolicyPoolTeamAppr(string keysearch, string codsocieta, string targa, int idstatuspool, string luogo, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectCarPolicyPoolTeamAppr(keysearch, codsocieta, targa, idstatuspool, luogo, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountCarPolicyPoolTeamAppr(string keysearch, string codsocieta, string targa, int idstatuspool, string luogo, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountCarPolicyPoolTeamAppr(keysearch, codsocieta, targa, idstatuspool, luogo, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRunningTeamAppr(string codsocieta, Guid UserId, string marca, string modello, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectRunningTeamAppr(codsocieta, UserId, marca, modello, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRunningTeamAppr(string codsocieta, Guid UserId, string marca, string modello, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountRunningTeamAppr(codsocieta, UserId, marca, modello, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int UpdateAutoPool(IContratti value)
        {
            return contrattiProvider.UpdateAutoPool(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountOrdiniRental(string codfornitore, int idstatus)
        {
            return contrattiProvider.SelectCountOrdiniRental(codfornitore, idstatus);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniRentalEvasi(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal, int numrecord, int pagina)
        {
            return contrattiProvider.SelectRichiesteOrdiniRentalEvasi(idstatusordine, keysearch, UserId, codfornitore, codsocieta, datadal, dataal, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRichiesteOrdiniRentalEvasi(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal)
        {
            return contrattiProvider.SelectCountRichiesteOrdiniRentalEvasi(idstatusordine, keysearch, UserId, codfornitore, codsocieta, datadal, dataal);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountUserCarPolicyPageAdmin(string codsocieta, string carpolicy, Guid UserId, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountUserCarPolicyPageAdmin(codsocieta, carpolicy, UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectUserCarPolicyPageAdmin(string codsocieta, string carpolicy, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectUserCarPolicyPageAdmin(codsocieta, carpolicy, UserId, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoUser(Guid UserId)
        {
            return contrattiProvider.SelectAutoUser(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOrdiniUser(Guid UserId)
        {
            return contrattiProvider.SelectOrdiniUser(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFuelCardUser(Guid UserId)
        {
            return contrattiProvider.SelectFuelCardUser(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectStatusFatture(Guid Uidtenant)
        {
            return contrattiProvider.SelectStatusFatture(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountFattureNonAbbinate(Guid Uidfattura)
        {
            return contrattiProvider.SelectCountFattureNonAbbinate(Uidfattura);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateProrogaContratto(Guid Uid, DateTime dataproroga, string nota, Guid Uidtenant)
        {
            return contrattiProvider.UpdateProrogaContratto(Uid, dataproroga, nota, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAssegnazioniContratti(string targa, string targasearch, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return contrattiProvider.SelectAssegnazioniContratti(targa, targasearch, UserId, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatusassegnazione, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountAssegnazioniContratti(string targa, string targasearch, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountAssegnazioniContratti(targa, targasearch, UserId, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatusassegnazione, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateAssegnazioneContratto(IContratti value)
        {
            return contrattiProvider.UpdateAssegnazioneContratto(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateRiconsegnaAuto(IContratti value)
        {
            return contrattiProvider.UpdateRiconsegnaAuto(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateFatturaAbb(Guid Uid, int templateabb, DateTime datarifabb, Guid Uidtenant)
        {
            return contrattiProvider.UpdateFatturaAbb(Uid, templateabb, datarifabb, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountAllDeltaCanone(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountAllDeltaCanone(codsocieta, UserId, mese, anno, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllDeltaCanone(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectAllDeltaCanone(codsocieta, UserId, mese, anno, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDetailFattureGroup(Guid Uidfattura)
        {
            return contrattiProvider.SelectDetailFattureGroup(Uidfattura);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDetailConsumiGroup(string numerofattura, int idcompagnia, DateTime datafattura)
        {
            return contrattiProvider.SelectDetailConsumiGroup(numerofattura, idcompagnia, datafattura);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDetailConsumiTelePassGroup(int idcompagnia, DateTime datafatturada, DateTime datafatturaa)
        {
            return contrattiProvider.SelectDetailConsumiTelePassGroup(idcompagnia, datafatturada, datafatturaa);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFattureDeltaCanone(string codsocieta, Guid UserId, string mese, int anno)
        {
            return contrattiProvider.SelectFattureDeltaCanone(codsocieta, UserId, mese, anno);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectNoteCreditoDeltaCanone(string codsocieta, Guid UserId, string mese, int anno)
        {
            return contrattiProvider.SelectNoteCreditoDeltaCanone(codsocieta, UserId, mese, anno);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFattureMulte(string targa, Guid UserId, string mese, int anno)
        {
            return contrattiProvider.SelectFattureMulte(targa, UserId, mese, anno);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFattureMulteFee(string codsocieta, Guid UserId, string mese, int anno)
        {
            return contrattiProvider.SelectFattureMulteFee(codsocieta, UserId, mese, anno);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectNoteCreditoMulte(string targa, Guid UserId, string mese, int anno)
        {
            return contrattiProvider.SelectNoteCreditoMulte(targa, UserId, mese, anno);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdatePoolContratto(Guid Uid, int checkordinepool, string gradepool, Guid Uidtenant)
        {
            return contrattiProvider.UpdatePoolContratto(Uid, checkordinepool, gradepool, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateDataFineContratto(int idcontratto, DateTime datafinecontratto, Guid UserId, Guid Uidtenant)
        {
            return contrattiProvider.UpdateDataFineContratto(idcontratto, datafinecontratto, UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateDeltaCanoneOrdini(IContratti value)
        {
            return contrattiProvider.UpdateDeltaCanoneOrdini(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDelegheUser(int idtipomodulo, Guid UserId)
        {
            return contrattiProvider.SelectDelegheUser(idtipomodulo, UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDeleghe(Guid UserId, DateTime datadocumentodal, DateTime datadocumentoal, string checkapprovatore, int idtipomodulo, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectDeleghe(UserId, datadocumentodal, datadocumentoal, checkapprovatore, idtipomodulo, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountDeleghe(Guid UserId, DateTime datadocumentodal, DateTime datadocumentoal, string checkapprovatore, int idtipomodulo, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountDeleghe(UserId, datadocumentodal, datadocumentoal, checkapprovatore, idtipomodulo, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertDelega(IContratti value)
        {
            return contrattiProvider.InsertDelega(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateDelega(IContratti value)
        {
            return contrattiProvider.UpdateDelega(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoXFornitore(string codfornitore, Guid Uidtenant)
        {
            return contrattiProvider.SelectAutoXFornitore(codfornitore, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdatePoolContratto2(IContratti value)
        {
            return contrattiProvider.UpdatePoolContratto2(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectViewCarPolicyPoolTeamAppr(string keysearch, string codsocieta, string targa, int idstatuspool)
        {
            return contrattiProvider.SelectViewCarPolicyPoolTeamAppr(keysearch, codsocieta, targa, idstatuspool);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateCarPolicy(IContratti value)
        {
            return contrattiProvider.UpdateCarPolicy(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateDocFuelCard(int idassegnazione, string documentofuelcard, Guid Uidtenant)
        {
            return contrattiProvider.UpdateDocFuelCard(idassegnazione, documentofuelcard, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoSostitutive(string targa, Guid UserId, string codsocieta, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectAutoSostitutive(targa, UserId, codsocieta, datacontrattodal, datacontrattoal, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountAutoSostitutive(string targa, Guid UserId, string codsocieta, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountAutoSostitutive(targa, UserId, codsocieta, datacontrattodal, datacontrattoal, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateAutoSost(IContratti value)
        {
            return contrattiProvider.UpdateAutoSost(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertAutoSost(IContratti value)
        {
            return contrattiProvider.InsertAutoSost(value);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteAssegnazione(IContratti value)
        {
            return contrattiProvider.DeleteAssegnazione(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateApprovaDelega(string checkapprovatore, string noteapprovazione, Guid Uid, Guid Uidtenant)
        {
            return contrattiProvider.UpdateApprovaDelega(checkapprovatore, noteapprovazione, Uid, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateModConv(Guid Uid, string moduloconvivenza, Guid Uidtenant)
        {
            return contrattiProvider.UpdateModConv(Uid, moduloconvivenza, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarBenefit(Guid Uidtenant)
        {
            return contrattiProvider.SelectCarBenefit(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateUserCarPolicy(int idapprovazione, string sceltabenefit, string codpacchetto, DateTime datasceltabenefit, Guid Uidtenant)
        {
            return contrattiProvider.UpdateUserCarPolicy(idapprovazione, sceltabenefit, codpacchetto, datasceltabenefit, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertCarPolicy(IContratti value)
        {
            return contrattiProvider.InsertCarPolicy(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertConfigurazionePartner(IContratti value)
        {
            return contrattiProvider.InsertConfigurazionePartner(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertAllegato(IContratti value)
        {
            return contrattiProvider.InsertAllegato(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertDelegaDriver(IContratti value)
        {
            return contrattiProvider.InsertDelegaDriver(value);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteDeleghePartner(IContratti value)
        {
            return contrattiProvider.DeleteDeleghePartner(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDeleghePartner(Guid UserId)
        {
            return contrattiProvider.SelectDeleghePartner(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDelegheDriver(Guid UserId)
        {
            return contrattiProvider.SelectDelegheDriver(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectContrattiPartner(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return contrattiProvider.SelectContrattiPartner(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountContrattiPartner(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountContrattiPartner(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniPartner(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectRichiesteOrdiniPartner(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, idstatusordine, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRichiesteOrdiniPartner(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountRichiesteOrdiniPartner(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, idstatusordine, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectConfigurazioniPartner(DateTime datadal, DateTime dataal, Guid UserId, int idstatuordine, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectConfigurazioniPartner(datadal, dataal, UserId, idstatuordine, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountConfigurazioniPartner(DateTime datadal, DateTime dataal, Guid UserId, int idstatuordine, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountConfigurazioniPartner(datadal, dataal, UserId, idstatuordine, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllegatiConfigurazioniPartner(int idconfigurazione)
        {
            return contrattiProvider.SelectAllegatiConfigurazioniPartner(idconfigurazione);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllTipoPenaleAuto(Guid Uidtenant)
        {
            return contrattiProvider.SelectAllTipoPenaleAuto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectPenaliAuto(Guid UserId, string targa, string codfornitore, string numerofattura, DateTime datafatturadal, DateTime datafatturaal, int idtipopenaleauto, string status, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return contrattiProvider.SelectPenaliAuto(UserId, targa, codfornitore, numerofattura, datafatturadal, datafatturaal, idtipopenaleauto, status, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountPenaliAuto(Guid UserId, string targa, string codfornitore, string numerofattura, DateTime datafatturadal, DateTime datafatturaal, int idtipopenaleauto, string status, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountPenaliAuto(UserId, targa, codfornitore, numerofattura, datafatturadal, datafatturaal, idtipopenaleauto, status, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertPenale(IContratti value)
        {
            return contrattiProvider.InsertPenale(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdatePenale(IContratti value)
        {
            return contrattiProvider.UpdatePenale(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateStatusPenale(IContratti value)
        {
            return contrattiProvider.UpdateStatusPenale(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectStatusConfigurazionePartner(Guid Uidtenant)
        {
            return contrattiProvider.SelectStatusConfigurazionePartner(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateStatusConfigurazionePartner(IContratti value)
        {
            return contrattiProvider.UpdateStatusConfigurazionePartner(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountDelegheDriver(Guid UserId)
        {
            return contrattiProvider.SelectCountDelegheDriver(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRichiesteOrdiniDriverXCodjato(Guid UserId, string codjatoauto)
        {
            return contrattiProvider.SelectCountRichiesteOrdiniDriverXCodjato(UserId, codjatoauto);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOptionalAutoXOrdine(int idordine)
        {
            return contrattiProvider.SelectOptionalAutoXOrdine(idordine);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateFileLibrettoAuto(Guid Uid, string filelibrettoautocontratto, Guid Uidtenant)
        {
            return contrattiProvider.UpdateFileLibrettoAuto(Uid, filelibrettoautocontratto, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteAutoSost(Guid Uid, Guid Uidtenant)
        {
            return contrattiProvider.DeleteAutoSost(Uid, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> ReturnCodiceCDC(DateTime datariferimentoda, DateTime datariferimentoa, string targa)
        {
            return contrattiProvider.ReturnCodiceCDC(datariferimentoda, datariferimentoa, targa);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectExtraPlafond(string codsocieta, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectExtraPlafond(codsocieta, UserId, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountExtraPlafond(string codsocieta, Guid UserId, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountExtraPlafond(codsocieta, UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeletePenali(IContratti value)
        {
            return contrattiProvider.DeletePenali(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRevisioniUser(Guid UserId, string targa, int anno, int numrecord, int pagina)
        {
            return contrattiProvider.SelectRevisioniUser(UserId, targa, anno, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRevisioniUser(Guid UserId, string targa, int anno)
        {
            return contrattiProvider.SelectCountRevisioniUser(UserId, targa, anno);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateCheckRevisione(Guid Uid, string filerev, Guid Uidtenant)
        {
            return contrattiProvider.UpdateCheckRevisione(Uid, filerev, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRevisioniAll(Guid UserId, string targa, int anno, int statuscheck, Guid Uidtenant, int numrecord, int pagina)
        {
            return contrattiProvider.SelectRevisioniAll(UserId, targa, anno, statuscheck, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountRevisioniAll(Guid UserId, string targa, int anno, int statuscheck, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountRevisioniAll(UserId, targa, anno, statuscheck, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectTipoUtilizzo(Guid Uidtenant)
        {
            return contrattiProvider.SelectTipoUtilizzo(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoServizio(string targa, string targasearch, Guid UserId, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return contrattiProvider.SelectAutoServizio(targa, targasearch, UserId, datacontrattodal, datacontrattoal, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountAutoServizio(string targa, string targasearch, Guid UserId, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountAutoServizio(targa, targasearch, UserId, datacontrattodal, datacontrattoal, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectPrenotazioniAutoServizio(string targa)
        {
            return contrattiProvider.SelectPrenotazioniAutoServizio(targa);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertPrenotazioneAutoServizio(IContratti value)
        {
            return contrattiProvider.InsertPrenotazioneAutoServizio(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateAutoServizio(IContratti value)
        {
            return contrattiProvider.UpdateAutoServizio(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectLibrettoAutoServizio(string targa, Guid UserId, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return contrattiProvider.SelectLibrettoAutoServizio(targa, UserId, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountLibrettoAutoServizio(string targa, Guid UserId, Guid Uidtenant)
        {
            return contrattiProvider.SelectCountLibrettoAutoServizio(targa,  UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDetailLibrettoAutoServizio(string targa)
        {
            return contrattiProvider.SelectDetailLibrettoAutoServizio(targa);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllScopoViaggio(Guid Uidtenant)
        {
            return contrattiProvider.SelectAllScopoViaggio(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoServizioDispo(Guid Uidtenant)
        {
            return contrattiProvider.SelectAutoServizioDispo(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> DispoAutoServizioXDay(string targa, DateTime datains)
        {
            return contrattiProvider.DispoAutoServizioXDay(targa, datains);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateAutorizzaAutoServizio(int idassegnazione, Guid Uidtenant)
        {
            return contrattiProvider.UpdateAutorizzaAutoServizio(idassegnazione, Uidtenant);
        }
    }
}
