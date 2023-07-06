// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CODSUtility.cs" company="">
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

    public class OdsUtilitys : ODSProvider<UtilitysProvider>, IOdsUtilitys
    {
        private readonly UtilitysProvider utilitysProvider = (UtilitysProvider)new ProviderFactory().ServizioAccount;

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateSocieta(IUtilitys value)
        {
            return utilitysProvider.UpdateSocieta(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteSocieta(IUtilitys value)
        {
            return utilitysProvider.DeleteSocieta(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertSocieta(IUtilitys value)
        {
            return utilitysProvider.InsertSocieta(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectSocieta(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return utilitysProvider.SelectSocieta(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountSocieta(string keysearch, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountSocieta(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllSocieta(Guid Uidtenant)
        {
            return utilitysProvider.SelectAllSocieta(Uidtenant);
        }


        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateConti(IUtilitys value)
        {
            return utilitysProvider.UpdateConti(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteConti(IUtilitys value)
        {
            return utilitysProvider.DeleteConti(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertConti(IUtilitys value)
        {
            return utilitysProvider.InsertConti(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectConti(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return utilitysProvider.SelectConti(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountConti(string keysearch, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountConti(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllConti()
        {
            return utilitysProvider.SelectAllConti();
        }


        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateFornitori(IUtilitys value)
        {
            return utilitysProvider.UpdateFornitori(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteFornitori(IUtilitys value)
        {
            return utilitysProvider.DeleteFornitori(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFornitori(IUtilitys value)
        {
            return utilitysProvider.InsertFornitori(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectFornitori(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return utilitysProvider.SelectFornitori(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountFornitori(string keysearch, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountFornitori(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllFornitori(Guid Uidtenant)
        {
            return utilitysProvider.SelectAllFornitori(Uidtenant);
        }


        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateFuelCard(IUtilitys value)
        {
            return utilitysProvider.UpdateFuelCard(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteFuelCard(IUtilitys value)
        {
            return utilitysProvider.DeleteFuelCard(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFuelCard(IUtilitys value)
        {
            return utilitysProvider.InsertFuelCard(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectFuelCard(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return utilitysProvider.SelectFuelCard(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountFuelCard(string keysearch, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountFuelCard(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllFuelCard(Guid Uidtenant)
        {
            return utilitysProvider.SelectAllFuelCard(Uidtenant);
        }


        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateGrade(IUtilitys value)
        {
            return utilitysProvider.UpdateGrade(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteGrade(IUtilitys value)
        {
            return utilitysProvider.DeleteGrade(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertGrade(IUtilitys value)
        {
            return utilitysProvider.InsertGrade(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectGrade(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return utilitysProvider.SelectGrade(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountGrade(string keysearch, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountGrade(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllGrade(Guid Uidtenant)
        {
            return utilitysProvider.SelectAllGrade(Uidtenant);
        }


        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdatePersonType(IUtilitys value)
        {
            return utilitysProvider.UpdatePersonType(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeletePersonType(IUtilitys value)
        {
            return utilitysProvider.DeletePersonType(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertPersonType(IUtilitys value)
        {
            return utilitysProvider.InsertPersonType(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectPersonType(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return utilitysProvider.SelectPersonType(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountPersonType(string keysearch, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountPersonType(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllPersonType()
        {
            return utilitysProvider.SelectAllPersonType();
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertComunicazioneEmail(IUtilitys value)
        {
            return utilitysProvider.InsertComunicazioneEmail(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectTemplateEmail(string keysearch, Guid Uidtenant)
        {
            return utilitysProvider.SelectTemplateEmail(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountTemplateEmail(string keysearch, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountTemplateEmail(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateTemplateEmail(IUtilitys value)
        {
            return utilitysProvider.UpdateTemplateEmail(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDocumenti(string keysearch, DateTime datadal, DateTime dataal, Guid Uidtenant, int numrecord, int pagina)
        {
            return utilitysProvider.SelectDocumenti(keysearch, datadal, dataal, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountDocumenti(string keysearch, DateTime datadal, DateTime dataal, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountDocumenti(keysearch, datadal, dataal, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllAttivita()
        {
            return utilitysProvider.SelectAllAttivita();
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateDocumento(IUtilitys value)
        {
            return utilitysProvider.UpdateDocumento(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteDocumento(IUtilitys value)
        {
            return utilitysProvider.DeleteDocumento(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertDocumento(IUtilitys value)
        {
            return utilitysProvider.InsertDocumento(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDocumenti(string keysearch, int idcategoria, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return utilitysProvider.SelectDocumenti(keysearch, idcategoria, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountDocumenti(string keysearch, int idcategoria, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountDocumenti(keysearch, idcategoria, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllCatDoc(Guid Uidtenant)
        {
            return utilitysProvider.SelectAllCatDoc(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDocumentiXUser(int idcategoria, string codsocieta, string codgrade, string codcarpolicy)
        {
            return utilitysProvider.SelectDocumentiXUser(idcategoria, codsocieta, codgrade, codcarpolicy);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllReport()
        {
            return utilitysProvider.SelectAllReport();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllReportPartner()
        {
            return utilitysProvider.SelectAllReportPartner();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> FieldReportExcel(string viewtable)
        {
            return utilitysProvider.FieldReportExcel(viewtable);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertTask(IUtilitys value)
        {
            return utilitysProvider.InsertTask(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectTaskAperti(Guid UserId, Guid Uidtenant)
        {
            return utilitysProvider.SelectTaskAperti(UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountTaskAperti(Guid UserId, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountTaskAperti(UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateChiudiTask(Guid Uid, Guid Uidtenant)
        {
            return utilitysProvider.UpdateChiudiTask(Uid, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllTask(Guid UserId)
        {
            return utilitysProvider.SelectAllTask(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> ViewFlottaAutoCircolazione(Guid Uidtenant)
        {
            return utilitysProvider.ViewFlottaAutoCircolazione(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> ViewAuto(string viewtable)
        {
            return utilitysProvider.ViewAuto(viewtable);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> ViewPoolAutoCircolazione(Guid Uidtenant)
        {
            return utilitysProvider.ViewPoolAutoCircolazione(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> ViewDriverAttivi(Guid Uidtenant)
        {
            return utilitysProvider.ViewDriverAttivi(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateArgomentiFAQ(IUtilitys value)
        {
            return utilitysProvider.UpdateArgomentiFAQ(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteArgomentoFAQ(IUtilitys value)
        {
            return utilitysProvider.DeleteArgomentoFAQ(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertArgomentoFAQ(IUtilitys value)
        {
            return utilitysProvider.InsertArgomentoFAQ(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectArgomentoFAQ(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return utilitysProvider.SelectArgomentoFAQ(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountArgomentoFAQ(string keysearch, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountArgomentoFAQ(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllArgomentoFAQ(Guid Uidtenant)
        {
            return utilitysProvider.SelectAllArgomentoFAQ(Uidtenant);
        }


        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateFAQ(IUtilitys value)
        {
            return utilitysProvider.UpdateFAQ(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteFAQ(IUtilitys value)
        {
            return utilitysProvider.DeleteFAQ(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFAQ(IUtilitys value)
        {
            return utilitysProvider.InsertFAQ(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectFAQ(string keysearch, int idargomentofaq, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return utilitysProvider.SelectFAQ(keysearch, idargomentofaq, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountFAQ(string keysearch, int idargomentofaq, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountFAQ(keysearch, idargomentofaq, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectArgomentoFAQAttivi()
        {
            return utilitysProvider.SelectArgomentoFAQAttivi();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectFAQXId(int idargomentofaq, string keysearch)
        {
            return utilitysProvider.SelectFAQXId(idargomentofaq, keysearch);
        }


        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdatePenale(IUtilitys value)
        {
            return utilitysProvider.UpdatePenale(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeletePenale(IUtilitys value)
        {
            return utilitysProvider.DeletePenale(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertPenale(IUtilitys value)
        {
            return utilitysProvider.InsertPenale(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectPenali(string codsocieta, string codgrade, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return utilitysProvider.SelectPenali(codsocieta, codgrade, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountPenali(string codsocieta, string codgrade, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountPenali(codsocieta, codgrade, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectExCarPolicy(Guid Uidtenant)
        {
            return utilitysProvider.SelectExCarPolicy(Uidtenant);
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAvvisi(string keysearch, Guid Uidtenant, int numrecord, int pagina)
        {
            return utilitysProvider.SelectAvvisi(keysearch, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountAvvisi(string keysearch, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountAvvisi(keysearch, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateAvviso(IUtilitys value)
        {
            return utilitysProvider.UpdateAvviso(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteAvviso(IUtilitys value)
        {
            return utilitysProvider.DeleteAvviso(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertAvviso(IUtilitys value)
        {
            return utilitysProvider.InsertAvviso(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAvvisiXUser(string codsocieta, string codgrade, string codcarpolicy, Guid Uidtenant)
        {
            return utilitysProvider.SelectAvvisiXUser(codsocieta, codgrade, codcarpolicy, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllTemplateEmail(Guid Uidtenant)
        {
            return utilitysProvider.SelectAllTemplateEmail(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllUserEmail()
        {
            return utilitysProvider.SelectAllUserEmail();
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateInvioMail(int idinvio)
        {
            return utilitysProvider.UpdateInvioMail(idinvio);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateCentri(IUtilitys value)
        {
            return utilitysProvider.UpdateCentri(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteCentri(IUtilitys value)
        {
            return utilitysProvider.DeleteCentri(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertCentri(IUtilitys value)
        {
            return utilitysProvider.InsertCentri(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectCentri(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return utilitysProvider.SelectCentri(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountCentri(string keysearch, Guid Uidtenant)
        {
            return utilitysProvider.SelectCountCentri(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllCentri(Guid Uidtenant)
        {
            return utilitysProvider.SelectAllCentri(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllCittaCentri(Guid Uidtenant)
        {
            return utilitysProvider.SelectAllCittaCentri(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectCentriXCitta(string citta, Guid Uidtenant)
        {
            return utilitysProvider.SelectCentriXCitta(citta, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaStatusContratto(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashFlottaStatusContratto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaContratto(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashFlottaContratto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaNonAssegnato(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashFlottaNonAssegnato(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaSocieta(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashFlottaSocieta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaGrade(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashFlottaGrade(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaSedeDriver(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashFlottaSedeDriver(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaFornitore(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashFlottaFornitore(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaFornitoreCanone(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashFlottaFornitoreCanone(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaMarca(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashFlottaMarca(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaAnnualita(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashFlottaAnnualita(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaAlimentazione(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashFlottaAlimentazione(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountViewFlotta(string viewtable)
        {
            return utilitysProvider.SelectCountViewFlotta(viewtable);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public decimal SelectCountViewFlotta2(string viewtable)
        {
            return utilitysProvider.SelectCountViewFlotta2(viewtable);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolSocieta(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashPoolSocieta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolFornitore(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashPoolFornitore(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolFornitoreCanone(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashPoolFornitoreCanone(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolMarca(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashPoolMarca(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolAnnualita(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashPoolAnnualita(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolAlimentazione(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashPoolAlimentazione(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniStatusOrdine(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashOrdiniStatusOrdine(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniSocieta(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashOrdiniSocieta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniGrade(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashOrdiniGrade(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniSedeDriver(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashOrdiniSedeDriver(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniFornitore(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashOrdiniFornitore(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniFornitoreCanone(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashOrdiniFornitoreCanone(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniMarca(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashOrdiniMarca(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniAnnualita(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashOrdiniAnnualita(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniAlimentazione(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashOrdiniAlimentazione(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaTempo(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashFlottaTempo(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolStatus(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashPoolStatus(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashRenterStatusOrdini(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashRenterStatusOrdini(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashDriverGrade(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashDriverGrade(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashDriverSede(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashDriverSede(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashDriverEta(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashDriverEta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashMulteMese(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashMulteMese(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashMulteStatus(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashMulteStatus(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashMulteSocieta(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashMulteSocieta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashMulteGrade(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashMulteGrade(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashMulteCitta(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashMulteCitta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashMulteTipo(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashMulteTipo(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaFattureMese(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashContabilitaFattureMese(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaSocieta(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashContabilitaSocieta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaFornitore(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashContabilitaFornitore(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaTemplate(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashContabilitaTemplate(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaSocietaImporto(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashContabilitaSocietaImporto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaFornitoreImporto(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashContabilitaFornitoreImporto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaTemplateImporto(Guid Uidtenant)
        {
            return utilitysProvider.SelectDashContabilitaTemplateImporto(Uidtenant);
        }
    }
}
