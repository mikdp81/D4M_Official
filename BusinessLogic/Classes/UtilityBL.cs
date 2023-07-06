// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CUtilityBL.cs" company="">
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
using System.Data;

namespace BusinessLogic
{
    [Serializable]
    public class UtilitysBL : BaseBL, IUtilitysBL
    {

        public UtilitysBL() {
        }

        private IUtilitysProvider ServizioUtility
        {
            get { return ProviderFactory.ServizioUtility; }
        }
        private IAccountProvider ServizioAccount
        {
            get { return ProviderFactory.ServizioAccount; }
        }
        private IComunicazioniProvider ServizioComunicazioni
        {
            get { return ProviderFactory.ServizioComunicazioni; }
        }
        private IMulteProvider ServizioMulte
        {
            get { return ProviderFactory.ServizioMulte; }
        }

        public int UpdateSocieta(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdateSocieta(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        
        public int DeleteSocieta(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.DeleteSocieta(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        
        public int InsertSocieta(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertSocieta(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }       
        
        public IUtilitys DetailSocietaId(Guid Uid)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailSocietaId(Uid);
            return data;
        }
                
        public int SelectCountSocieta(string keysearch, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountSocieta(keysearch, Uidtenant);
            return retVal;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectSocieta(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsUtilitys.DefaultProvider.SelectSocieta(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllSocieta(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectAllSocieta(Uidtenant);
        }


        public int UpdateConti(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdateConti(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteConti(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.DeleteConti(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertConti(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertConti(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IUtilitys DetailContiId(Guid Uid)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailContiId(Uid);
            return data;
        }

        public int SelectCountConti(string keysearch, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountConti(keysearch, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectConti(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsUtilitys.DefaultProvider.SelectConti(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllConti()
        {
            return OdsUtilitys.DefaultProvider.SelectAllConti();
        }


        public int UpdateFornitori(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdateFornitori(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteFornitori(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.DeleteFornitori(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertFornitori(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertFornitori(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IUtilitys DetailFornitoriId(Guid Uid)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailFornitoriId(Uid);
            return data;
        }

        public int SelectCountFornitori(string keysearch, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountFornitori(keysearch, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectFornitori(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsUtilitys.DefaultProvider.SelectFornitori(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllFornitori(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectAllFornitori(Uidtenant);
        }


        public int UpdateFuelCard(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdateFuelCard(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteFuelCard(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.DeleteFuelCard(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertFuelCard(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertFuelCard(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IUtilitys DetailFuelCardId(Guid Uid)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailFuelCardId(Uid);
            return data;
        }

        public int SelectCountFuelCard(string keysearch, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountFuelCard(keysearch, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectFuelCard(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsUtilitys.DefaultProvider.SelectFuelCard(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllFuelCard(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectAllFuelCard(Uidtenant);
        }


        public int UpdateGrade(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdateGrade(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteGrade(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.DeleteGrade(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertGrade(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertGrade(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IUtilitys DetailGradeId(Guid Uid)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailGradeId(Uid);
            return data;
        }

        public int SelectCountGrade(string keysearch, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountGrade(keysearch, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectGrade(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsUtilitys.DefaultProvider.SelectGrade(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllGrade(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectAllGrade(Uidtenant);
        }


        public int UpdatePersonType(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdatePersonType(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeletePersonType(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.DeletePersonType(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertPersonType(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertPersonType(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IUtilitys DetailPersonTypeId(Guid Uid)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailPersonTypeId(Uid);
            return data;
        }

        public int SelectCountPersonType(string keysearch, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountPersonType(keysearch, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectPersonType(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsUtilitys.DefaultProvider.SelectPersonType(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllPersonType()
        {
            return OdsUtilitys.DefaultProvider.SelectAllPersonType();
        }
        public IUtilitys ReturnTemplateEmail(int idtemplate)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.ReturnTemplateEmail(idtemplate);
            return data;
        }
        public int InsertComunicazioneEmail(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertComunicazioneEmail(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountTemplateEmail(string keysearch, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountTemplateEmail(keysearch, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectTemplateEmail(string keysearch, Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectTemplateEmail(keysearch, Uidtenant);
        }
        public int UpdateTemplateEmail(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdateTemplateEmail(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountDocumenti(string keysearch, DateTime datadal, DateTime dataal, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountDocumenti(keysearch, datadal, dataal, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDocumenti(string keysearch, DateTime datadal, DateTime dataal, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsUtilitys.DefaultProvider.SelectDocumenti(keysearch, datadal, dataal, Uidtenant, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllAttivita()
        {
            return OdsUtilitys.DefaultProvider.SelectAllAttivita();
        }


        public int UpdateDocumento(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdateDocumento(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteDocumento(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.DeleteDocumento(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertDocumento(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertDocumento(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IUtilitys DetailDocumentoId(Guid Uid)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailDocumentoId(Uid);
            return data;
        }

        public int SelectCountDocumenti(string keysearch, int idcategoria, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountDocumenti(keysearch, idcategoria, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDocumenti(string keysearch, int idcategoria, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsUtilitys.DefaultProvider.SelectDocumenti(keysearch, idcategoria, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllCatDoc(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectAllCatDoc(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDocumentiXUser(int idcategoria, string codsocieta, string codgrade, string codcarpolicy)
        {
            return OdsUtilitys.DefaultProvider.SelectDocumentiXUser(idcategoria, codsocieta, codgrade, codcarpolicy);
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllReport()
        {
            return OdsUtilitys.DefaultProvider.SelectAllReport();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllReportPartner()
        {
            return OdsUtilitys.DefaultProvider.SelectAllReportPartner();
        }
        public IUtilitys DetailReportId(int idreport)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailReportId(idreport);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> FieldReportExcel(string viewtable)
        {
            return OdsUtilitys.DefaultProvider.FieldReportExcel(viewtable);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public DataTable ViewEstrazioneReport(string viewtable, string codsocieta, string codgrade, string codfornitore, Guid UserId, Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.ViewEstrazioneReport(viewtable, codsocieta, codgrade, codfornitore, UserId, Uidtenant);
        }
        public IUtilitys DetailTaskId(Guid Uid)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailTaskId(Uid);
            return data;
        }
        public int InsertTask(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertTask(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountTaskAperti(Guid UserId, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountTaskAperti(UserId, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectTaskAperti(Guid UserId, Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectTaskAperti(UserId, Uidtenant);
        }
        public int UpdateChiudiTask(Guid Uid, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdateChiudiTask(Uid, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllTask(Guid UserId)
        {
            return OdsUtilitys.DefaultProvider.SelectAllTask(UserId);
        }

        public void InsTask(Guid UserId, string testotask, string linktask, DateTime datatask)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys taskNew = new Utilitys
            {
                UserId = UserId,
                Uidteam = Guid.Empty,
                Testotask = SeoHelper.EncodeString(testotask),
                Datatask = datatask,
                Esitotask = 0,
                Linktask = SeoHelper.EncodeString(linktask),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };
            servizioUtility.InsertTask(taskNew);
        }
        public IUtilitys ViewDashAdmin(Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.ViewDashAdmin(Uidtenant);
            return data;
        }
        public IUtilitys ViewDashPEP(string codsocieta, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.ViewDashPEP(codsocieta, Uidtenant);
            return data;
        }
        public IUtilitys ViewDashHR(string codsocieta, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.ViewDashHR(codsocieta, Uidtenant);
            return data;
        }
        public IUtilitys ViewDashFlotta(Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.ViewDashFlotta(Uidtenant);
            return data;
        }
        public IUtilitys ViewDashOrdini(Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.ViewDashOrdini(Uidtenant);
            return data;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> ViewFlottaAutoCircolazione(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.ViewFlottaAutoCircolazione(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> ViewAuto(string viewtable)
        {
            return OdsUtilitys.DefaultProvider.ViewAuto(viewtable);
        }
        public IUtilitys ViewDashPool(Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.ViewDashPool(Uidtenant);
            return data;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> ViewPoolAutoCircolazione(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.ViewPoolAutoCircolazione(Uidtenant);
        }
        public IUtilitys ViewDashDriver(Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.ViewDashDriver(Uidtenant);
            return data;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> ViewDriverAttivi(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.ViewDriverAttivi(Uidtenant);
        }

        public IUtilitys DetailFornitoriCod(string codfornitore)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailFornitoriCod(codfornitore);
            return data;
        }
        public IUtilitys DetailSocietaXPIVA(string partitaiva)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailSocietaXPIVA(partitaiva);
            return data;
        }
        public int UpdateArgomentiFAQ(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdateArgomentiFAQ(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteArgomentoFAQ(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.DeleteArgomentoFAQ(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertArgomentoFAQ(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertArgomentoFAQ(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IUtilitys DetailArgomentoFAQId(Guid Uid)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailArgomentoFAQId(Uid);
            return data;
        }

        public int SelectCountArgomentoFAQ(string keysearch, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountArgomentoFAQ(keysearch, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectArgomentoFAQ(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsUtilitys.DefaultProvider.SelectArgomentoFAQ(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllArgomentoFAQ(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectAllArgomentoFAQ(Uidtenant);
        }

        public int UpdateFAQ(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdateFAQ(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteFAQ(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.DeleteFAQ(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertFAQ(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertFAQ(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IUtilitys DetailFAQId(Guid Uid)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailFAQId(Uid);
            return data;
        }

        public int SelectCountFAQ(string keysearch, int idargomentofaq, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountFAQ(keysearch, idargomentofaq, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectFAQ(string keysearch, int idargomentofaq, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsUtilitys.DefaultProvider.SelectFAQ(keysearch, idargomentofaq, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectArgomentoFAQAttivi()
        {
            return OdsUtilitys.DefaultProvider.SelectArgomentoFAQAttivi();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectFAQXId(int idargomentofaq, string keysearch)
        {
            return OdsUtilitys.DefaultProvider.SelectFAQXId(idargomentofaq, keysearch);
        }
        public string InsCom(Guid UserId, string testotask)
        {
            string retVal;

            //nome utente
            string denominazione = "";
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                denominazione = data.Nome + " " + data.Cognome;
            }

            retVal = testotask.Replace("[Utente]", denominazione);

            return retVal;
        }
        public string InsComEmail(Guid UserId, Guid UidComunicazione, string testoutente, string testoreplace)
        {
            string retVal;

            //nome utente
            string denominazione = "";
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                denominazione = data.Nome + " " + data.Cognome;
            }

            //numero comunicazione        
            int numerocomunicazione = 0;
            IComunicazioniProvider servizioComunicazioni = ServizioComunicazioni;
            IComunicazioni data2 = servizioComunicazioni.DetailComunicazioni(UidComunicazione);
            if (data2 != null)
            {
                numerocomunicazione = data2.Idcomunicazione;
            }

            testoreplace = testoreplace.Replace("[Testo]", testoutente);
            testoreplace = testoreplace.Replace("[Denominazione]", denominazione);
            testoreplace = testoreplace.Replace("[Data]", DateTime.Now.ToString("dd/MM/yyyy HH:d"));
            testoreplace = testoreplace.Replace("[Ncom]", numerocomunicazione.ToString());

            retVal = testoreplace;

            return retVal;
        }
        public string InsMultaEmail(Guid UserId, Guid UidMulta, string testomail)
        {
            string retVal;

            //nome utente
            string denominazione = "";
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                denominazione = data.Nome + " " + data.Cognome;
            }

            //dati multa
            string targa = "";
            string nverbale = "";
            DateTime dataverbale = DateTime.MinValue;
            decimal importodapagare = 0;
            decimal importodapagare30 = 0;
            decimal importodapagareridotto = 0;
            int day = (int)DateTime.Now.DayOfWeek;
            DateTime datainvio = DateTime.MinValue;
            IMulteProvider servizioMulte = ServizioMulte;
            IMulte data2 = servizioMulte.DetailMulteId(UidMulta);
            if (data2 != null)
            {
                targa = data2.Targa;
                nverbale = data2.Numeroverbale;
                dataverbale = data2.Datainfrazione;
                importodapagare = data2.Importomulta;
                importodapagare30 = data2.Importomultascontato;
                importodapagareridotto = data2.Importomultaridotto;

                if (day == 1 || day == 2 || day == 3)
                {
                    datainvio = data2.Datanotifica.AddDays(2);
                }
                else
                {
                    datainvio = data2.Datanotifica.AddDays(4);
                }
            }

            if (importodapagare30 == 0) importodapagare30 = importodapagareridotto;


            testomail = testomail.Replace("[Denominazione]", denominazione);
            testomail = testomail.Replace("[Targa]", targa);
            testomail = testomail.Replace("[NVerbale]", nverbale);
            testomail = testomail.Replace("[DataVerbale]", dataverbale.ToString("dd/MM/yyyy"));
            testomail = testomail.Replace("[Importo]", importodapagare.ToString("F2"));
            testomail = testomail.Replace("[Importo30]", importodapagare30.ToString("F2"));
            testomail = testomail.Replace("[DataInvio]", datainvio.ToString("dd/MM/yyyy"));

            retVal = testomail;

            return retVal;
        }

        public string InsPenaleEmail(Guid UserId, string targa, string testomail)
        {
            string retVal;

            //nome utente
            string denominazione = "";
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                denominazione = data.Nome + " " + data.Cognome;
            }

            testomail = testomail.Replace("[Denominazione]", denominazione);
            testomail = testomail.Replace("[Targa]", targa);
            retVal = testomail;

            return retVal;
        }
        public IUtilitys DetailFornitoriPIva(string partitaiva)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailFornitoriPIva(partitaiva);
            return data;
        }


        public int UpdatePenale(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdatePenale(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeletePenale(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.DeletePenale(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertPenale(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertPenale(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IUtilitys DetailPenaleId(Guid Uid)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailPenaleId(Uid);
            return data;
        }

        public int SelectCountPenali(string codsocieta, string codgrade, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountPenali(codsocieta, codgrade, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectPenali(string codsocieta, string codgrade, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsUtilitys.DefaultProvider.SelectPenali(codsocieta, codgrade, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        public IUtilitys DetailSocietaXCodS(string codsocieta)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailSocietaXCodS(codsocieta);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectExCarPolicy(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectExCarPolicy(Uidtenant);
        }

        public int UpdateAvviso(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdateAvviso(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteAvviso(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.DeleteAvviso(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertAvviso(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertAvviso(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IUtilitys DetailAvvisoId(Guid Uid)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailAvvisoId(Uid);
            return data;
        }

        public int SelectCountAvvisi(string keysearch, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountAvvisi(keysearch, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAvvisi(string keysearch, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsUtilitys.DefaultProvider.SelectAvvisi(keysearch, Uidtenant, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAvvisiXUser(string codsocieta, string codgrade, string codcarpolicy, Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectAvvisiXUser(codsocieta, codgrade, codcarpolicy, Uidtenant);
        }
        public IUtilitys ViewDashPartner(Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.ViewDashPartner(Uidtenant);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllTemplateEmail(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectAllTemplateEmail(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllUserEmail()
        {
            return OdsUtilitys.DefaultProvider.SelectAllUserEmail();
        }
        public int UpdateInvioMail(int idinvio)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdateInvioMail(idinvio) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public string InsTextEmail(string testomail, string nome, string cognome, string matricola, string codsocieta, string codgrade, string param1, string param2, string param3, string param4,
            string param5, string param6, string param7, string param8, string param9, string param10)
        {
            string retVal;

            testomail = testomail.Replace("[nome]", nome);
            testomail = testomail.Replace("[cognome]", cognome);
            testomail = testomail.Replace("[matricola]", matricola);
            testomail = testomail.Replace("[codsocieta]", codsocieta);
            testomail = testomail.Replace("[codgrade]", codgrade);
            testomail = testomail.Replace("[param1]", param1);
            testomail = testomail.Replace("[param2]", param2);
            testomail = testomail.Replace("[param3]", param3);
            testomail = testomail.Replace("[param4]", param4);
            testomail = testomail.Replace("[param5]", param5);
            testomail = testomail.Replace("[param6]", param6);
            testomail = testomail.Replace("[param7]", param7);
            testomail = testomail.Replace("[param8]", param8);
            testomail = testomail.Replace("[param9]", param9);
            testomail = testomail.Replace("[param10]", param10);

            retVal = testomail;

            return retVal;
        }

        public IUtilitys ReturnGradeXCod(string codgrade)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.ReturnGradeXCod(codgrade);
            return data;
        }



        public int UpdateCentri(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.UpdateCentri(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteCentri(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.DeleteCentri(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertCentri(IUtilitys value)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal = 0;
            if (servizioUtility.InsertCentri(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IUtilitys DetailCentriId(Guid Uid)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.DetailCentriId(Uid);
            return data;
        }

        public int SelectCountCentri(string keysearch, Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountCentri(keysearch, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectCentri(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsUtilitys.DefaultProvider.SelectCentri(keysearch, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllCentri(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectAllCentri(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectAllCittaCentri(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectAllCittaCentri(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectCentriXCitta(string citta, Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectCentriXCitta(citta, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaStatusContratto(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashFlottaStatusContratto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaContratto(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashFlottaContratto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaNonAssegnato(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashFlottaNonAssegnato(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaSocieta(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashFlottaSocieta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaGrade(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashFlottaGrade(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaSedeDriver(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashFlottaSedeDriver(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaFornitore(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashFlottaFornitore(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaFornitoreCanone(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashFlottaFornitoreCanone(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaMarca(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashFlottaMarca(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaAnnualita(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashFlottaAnnualita(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaAlimentazione(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashFlottaAlimentazione(Uidtenant);
        }
        public int SelectCountViewFlotta(string viewtable)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            int retVal;
            retVal = servizioUtility.SelectCountViewFlotta(viewtable);
            return retVal;
        }
        public decimal SelectCountViewFlotta2(string viewtable)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            decimal retVal;
            retVal = servizioUtility.SelectCountViewFlotta2(viewtable);
            return retVal;
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolSocieta(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashPoolSocieta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolFornitore(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashPoolFornitore(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolFornitoreCanone(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashPoolFornitoreCanone(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolMarca(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashPoolMarca(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolAnnualita(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashPoolAnnualita(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolAlimentazione(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashPoolAlimentazione(Uidtenant);
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniStatusOrdine(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashOrdiniStatusOrdine(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniSocieta(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashOrdiniSocieta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniGrade(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashOrdiniGrade(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniSedeDriver(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashOrdiniSedeDriver(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniFornitore(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashOrdiniFornitore(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniFornitoreCanone(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashOrdiniFornitoreCanone(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniMarca(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashOrdiniMarca(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniAnnualita(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashOrdiniAnnualita(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashOrdiniAlimentazione(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashOrdiniAlimentazione(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashFlottaTempo(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashFlottaTempo(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashPoolStatus(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashPoolStatus(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashRenterStatusOrdini(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashRenterStatusOrdini(Uidtenant);
        }
        public IUtilitys ViewDashRenter(Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.ViewDashRenter(Uidtenant);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashDriverGrade(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashDriverGrade(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashDriverSede(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashDriverSede(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashDriverEta(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashDriverEta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashMulteMese(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashMulteMese(Uidtenant);
        }
        public IUtilitys ViewDashMulte(Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.ViewDashMulte(Uidtenant);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashMulteStatus(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashMulteStatus(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashMulteSocieta(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashMulteSocieta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashMulteGrade(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashMulteGrade(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashMulteCitta(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashMulteCitta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashMulteTipo(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashMulteTipo(Uidtenant);
        }
        public IUtilitys ViewDashContabilita(Guid Uidtenant)
        {
            IUtilitysProvider servizioUtility = ServizioUtility;
            IUtilitys data = servizioUtility.ViewDashContabilita(Uidtenant);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaFattureMese(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashContabilitaFattureMese(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaSocieta(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashContabilitaSocieta(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaFornitore(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashContabilitaFornitore(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaTemplate(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashContabilitaTemplate(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaSocietaImporto(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashContabilitaSocietaImporto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaFornitoreImporto(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashContabilitaFornitoreImporto(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IUtilitys> SelectDashContabilitaTemplateImporto(Guid Uidtenant)
        {
            return OdsUtilitys.DefaultProvider.SelectDashContabilitaTemplateImporto(Uidtenant);
        }

    }
}
