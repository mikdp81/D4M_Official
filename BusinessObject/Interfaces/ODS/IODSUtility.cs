// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IODSUtiity.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface IOdsUtilitys
    {
        int UpdateSocieta(IUtilitys value);
        int DeleteSocieta(IUtilitys value);
        int InsertSocieta(IUtilitys value);
        List<IUtilitys> SelectSocieta(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountSocieta(string keysearch, Guid Uidtenant);
        List<IUtilitys> SelectAllSocieta(Guid Uidtenant);

        int UpdateConti(IUtilitys value);
        int DeleteConti(IUtilitys value);
        int InsertConti(IUtilitys value);
        List<IUtilitys> SelectConti(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountConti(string keysearch, Guid Uidtenant);
        List<IUtilitys> SelectAllConti();

        int UpdateFornitori(IUtilitys value);
        int DeleteFornitori(IUtilitys value);
        int InsertFornitori(IUtilitys value);
        List<IUtilitys> SelectFornitori(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountFornitori(string keysearch, Guid Uidtenant);
        List<IUtilitys> SelectAllFornitori(Guid Uidtenant);

        int UpdateFuelCard(IUtilitys value);
        int DeleteFuelCard(IUtilitys value);
        int InsertFuelCard(IUtilitys value);
        List<IUtilitys> SelectFuelCard(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountFuelCard(string keysearch, Guid Uidtenant);
        List<IUtilitys> SelectAllFuelCard(Guid Uidtenant);

        int UpdateGrade(IUtilitys value);
        int DeleteGrade(IUtilitys value);
        int InsertGrade(IUtilitys value);
        List<IUtilitys> SelectGrade(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountGrade(string keysearch, Guid Uidtenant);
        List<IUtilitys> SelectAllGrade(Guid Uidtenant);

        int UpdatePersonType(IUtilitys value);
        int DeletePersonType(IUtilitys value);
        int InsertPersonType(IUtilitys value);
        List<IUtilitys> SelectPersonType(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountPersonType(string keysearch, Guid Uidtenant);
        List<IUtilitys> SelectAllPersonType();

        int InsertComunicazioneEmail(IUtilitys value);

        List<IUtilitys> SelectTemplateEmail(string keysearch, Guid Uidtenant);
        int SelectCountTemplateEmail(string keysearch, Guid Uidtenant);
        int UpdateTemplateEmail(IUtilitys value);

        List<IUtilitys> SelectDocumenti(string keysearch, DateTime datadal, DateTime dataal, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountDocumenti(string keysearch, DateTime datadal, DateTime dataal, Guid Uidtenant);

        List<IUtilitys> SelectAllAttivita();

        int UpdateDocumento(IUtilitys value);
        int DeleteDocumento(IUtilitys value);
        int InsertDocumento(IUtilitys value);
        List<IUtilitys> SelectDocumenti(string keysearch, int idcategoria, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountDocumenti(string keysearch, int idcategoria, Guid Uidtenant);
        List<IUtilitys> SelectAllCatDoc(Guid Uidtenant);
        List<IUtilitys> SelectDocumentiXUser(int idcategoria, string codsocieta, string codgrade, string codcarpolicy);


        List<IUtilitys> SelectAllReport();
        List<IUtilitys> SelectAllReportPartner();
        List<IUtilitys> FieldReportExcel(string viewtable);

        int InsertTask(IUtilitys value);
        List<IUtilitys> SelectTaskAperti(Guid UserId, Guid Uidtenant);
        int SelectCountTaskAperti(Guid UserId, Guid Uidtenant);
        int UpdateChiudiTask(Guid Uid, Guid Uidtenant);
        List<IUtilitys> SelectAllTask(Guid UserId);
        List<IUtilitys> ViewFlottaAutoCircolazione(Guid Uidtenant);
        List<IUtilitys> ViewAuto(string viewtable);
        List<IUtilitys> ViewPoolAutoCircolazione(Guid Uidtenant);
        List<IUtilitys> ViewDriverAttivi(Guid Uidtenant);

        int UpdateArgomentiFAQ(IUtilitys value);
        int DeleteArgomentoFAQ(IUtilitys value);
        int InsertArgomentoFAQ(IUtilitys value);
        List<IUtilitys> SelectArgomentoFAQ(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountArgomentoFAQ(string keysearch, Guid Uidtenant);
        List<IUtilitys> SelectAllArgomentoFAQ(Guid Uidtenant);

        int UpdateFAQ(IUtilitys value);
        int DeleteFAQ(IUtilitys value);
        int InsertFAQ(IUtilitys value);
        List<IUtilitys> SelectFAQ(string keysearch, int idargomentofaq, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountFAQ(string keysearch, int idargomentofaq, Guid Uidtenant);
        List<IUtilitys> SelectArgomentoFAQAttivi();
        List<IUtilitys> SelectFAQXId(int idargomentofaq, string keysearch);

        int UpdatePenale(IUtilitys value);
        int DeletePenale(IUtilitys value);
        int InsertPenale(IUtilitys value);
        List<IUtilitys> SelectPenali(string codsocieta, string codgrade, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountPenali(string codsocieta, string codgrade, Guid Uidtenant);
        List<IUtilitys> SelectExCarPolicy(Guid Uidtenant);

        int UpdateAvviso(IUtilitys value);
        int DeleteAvviso(IUtilitys value);
        int InsertAvviso(IUtilitys value);
        List<IUtilitys> SelectAvvisi(string keysearch, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountAvvisi(string keysearch, Guid Uidtenant);
        List<IUtilitys> SelectAvvisiXUser(string codsocieta, string codgrade, string codcarpolicy, Guid Uidtenant);
        List<IUtilitys> SelectAllTemplateEmail(Guid Uidtenant);
        List<IUtilitys> SelectAllUserEmail();
        int UpdateInvioMail(int idinvio); 
        
        int UpdateCentri(IUtilitys value);
        int DeleteCentri(IUtilitys value);
        int InsertCentri(IUtilitys value);
        List<IUtilitys> SelectCentri(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountCentri(string keysearch, Guid Uidtenant);
        List<IUtilitys> SelectAllCentri(Guid Uidtenant);
        List<IUtilitys> SelectAllCittaCentri(Guid Uidtenant);
        List<IUtilitys> SelectCentriXCitta(string citta, Guid Uidtenant);
        List<IUtilitys> SelectDashFlottaStatusContratto(Guid Uidtenant);
        List<IUtilitys> SelectDashFlottaContratto(Guid Uidtenant);
        List<IUtilitys> SelectDashFlottaNonAssegnato(Guid Uidtenant);
        List<IUtilitys> SelectDashFlottaSocieta(Guid Uidtenant);
        List<IUtilitys> SelectDashFlottaGrade(Guid Uidtenant);
        List<IUtilitys> SelectDashFlottaSedeDriver(Guid Uidtenant);
        List<IUtilitys> SelectDashFlottaFornitore(Guid Uidtenant);
        List<IUtilitys> SelectDashFlottaFornitoreCanone(Guid Uidtenant);
        List<IUtilitys> SelectDashFlottaMarca(Guid Uidtenant);
        List<IUtilitys> SelectDashFlottaAnnualita(Guid Uidtenant);
        List<IUtilitys> SelectDashFlottaAlimentazione(Guid Uidtenant);
        int SelectCountViewFlotta(string viewtable);
        decimal SelectCountViewFlotta2(string viewtable);
        List<IUtilitys> SelectDashPoolSocieta(Guid Uidtenant);
        List<IUtilitys> SelectDashPoolFornitore(Guid Uidtenant);
        List<IUtilitys> SelectDashPoolFornitoreCanone(Guid Uidtenant);
        List<IUtilitys> SelectDashPoolMarca(Guid Uidtenant);
        List<IUtilitys> SelectDashPoolAnnualita(Guid Uidtenant);
        List<IUtilitys> SelectDashPoolAlimentazione(Guid Uidtenant);
        List<IUtilitys> SelectDashOrdiniStatusOrdine(Guid Uidtenant);
        List<IUtilitys> SelectDashOrdiniSocieta(Guid Uidtenant);
        List<IUtilitys> SelectDashOrdiniGrade(Guid Uidtenant);
        List<IUtilitys> SelectDashOrdiniSedeDriver(Guid Uidtenant);
        List<IUtilitys> SelectDashOrdiniFornitore(Guid Uidtenant);
        List<IUtilitys> SelectDashOrdiniFornitoreCanone(Guid Uidtenant);
        List<IUtilitys> SelectDashOrdiniMarca(Guid Uidtenant);
        List<IUtilitys> SelectDashOrdiniAnnualita(Guid Uidtenant);
        List<IUtilitys> SelectDashOrdiniAlimentazione(Guid Uidtenant);
        List<IUtilitys> SelectDashFlottaTempo(Guid Uidtenant);
        List<IUtilitys> SelectDashPoolStatus(Guid Uidtenant);
        List<IUtilitys> SelectDashRenterStatusOrdini(Guid Uidtenant);
        List<IUtilitys> SelectDashDriverGrade(Guid Uidtenant);
        List<IUtilitys> SelectDashDriverSede(Guid Uidtenant);
        List<IUtilitys> SelectDashDriverEta(Guid Uidtenant);
        List<IUtilitys> SelectDashMulteMese(Guid Uidtenant);
        List<IUtilitys> SelectDashMulteStatus(Guid Uidtenant);
        List<IUtilitys> SelectDashMulteSocieta(Guid Uidtenant);
        List<IUtilitys> SelectDashMulteGrade(Guid Uidtenant);
        List<IUtilitys> SelectDashMulteCitta(Guid Uidtenant);
        List<IUtilitys> SelectDashMulteTipo(Guid Uidtenant);
        List<IUtilitys> SelectDashContabilitaFattureMese(Guid Uidtenant);
        List<IUtilitys> SelectDashContabilitaSocieta(Guid Uidtenant);
        List<IUtilitys> SelectDashContabilitaFornitore(Guid Uidtenant);
        List<IUtilitys> SelectDashContabilitaTemplate(Guid Uidtenant);
        List<IUtilitys> SelectDashContabilitaSocietaImporto(Guid Uidtenant);
        List<IUtilitys> SelectDashContabilitaFornitoreImporto(Guid Uidtenant);
        List<IUtilitys> SelectDashContabilitaTemplateImporto(Guid Uidtenant);
    }
}
