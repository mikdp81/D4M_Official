// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CContrattiBL.cs" company="">
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
    public class ContrattiBL : BaseBL, IContrattiBL
    {

        public ContrattiBL() {
        }

        private IContrattiProvider ServizioContratti
        {
            get { return ProviderFactory.ServizioContratti; }
        }

        public int UpdateContratti(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateContratti(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }


        
        public int DeleteContratti(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.DeleteContratti(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        
        public int InsertContratti(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertContratti(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }       
        
        public IContratti DetailContrattiId(Guid Uid)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailContrattiId(Uid);
            return data;
        }
                
        public int SelectCountContratti(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountContratti(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant);
            return retVal;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectContratti(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectContratti(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllStatusContratto(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectAllStatusContratto(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllStatusContrattoAss(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectAllStatusContrattoAss(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllStatusContrattoPool(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectAllStatusContrattoPool(Uidtenant);
        }


        public int UpdateOrdini(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateOrdini(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateOrdini2(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateOrdini2(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }



        public int DeleteOrdini(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.DeleteOrdini(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }


        public int InsertOrdini(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertOrdini(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IContratti DetailOrdiniId(Guid Uid)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailOrdiniId(Uid);
            return data;
        }

        public int SelectCountOrdini(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numeroordine, DateTime dataordinedal, DateTime dataordineal, int idstatusordine, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountOrdini(codsocieta, UserId, marca, modello, codfornitore, numeroordine, dataordinedal, dataordineal, idstatusordine, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOrdini(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numeroordine, DateTime dataordinedal, DateTime dataordineal, int idstatusordine, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectOrdini(codsocieta, UserId, marca, modello, codfornitore, numeroordine, dataordinedal, dataordineal, idstatusordine, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllStatusOrdine(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectAllStatusOrdine(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllStatusOrdineAdmin(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectAllStatusOrdineAdmin(Uidtenant);
        }
        public IContratti ReturnContrattoUser(DateTime datainfrazione, string targa)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnContrattoUser(datainfrazione, targa);
            return data;
        }
        public int InsertUserCarPolicy(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertUserCarPolicy(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public bool ExistUserCarPolicyActive(int idutente)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            bool retVal;
            retVal = servizioContratti.ExistUserCarPolicyActive(idutente);
            return retVal;
        }
        public bool ExistUserCarPolicy(int idutente)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            bool retVal;
            retVal = servizioContratti.ExistUserCarPolicy(idutente);
            return retVal;
        }
        public IContratti ReturnIdApprovazione(int idutente)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnIdApprovazione(idutente);
            return data;
        }
        public IContratti ReturnCodCarPolicy(string codsocieta, string gradecode)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnCodCarPolicy(codsocieta, gradecode);
            return data;
        }
        public int SelectCountUserCarPolicyDaApprovare(string carpolicy, Guid UserId, string codsocieta, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountUserCarPolicyDaApprovare(carpolicy, UserId, codsocieta, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectUserCarPolicyDaApprovare(string carpolicy, Guid UserId, string codsocieta, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectUserCarPolicyDaApprovare(carpolicy, UserId, codsocieta, Uidtenant, numrecord, pagina);
        }
        public int SelectCountUserCarPolicyApprovati(string keysearch, string codsocieta, int flgmail, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountUserCarPolicyApprovati(keysearch, codsocieta, flgmail, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectUserCarPolicyApprovati(string keysearch, string codsocieta, int flgmail, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectUserCarPolicyApprovati(keysearch, codsocieta, flgmail, Uidtenant, numrecord, pagina);
        }
        public IContratti DetailUserCarPolicyId(Guid Uid)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailUserCarPolicyId(Uid);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarPolicy(string codsocieta, Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectCarPolicy(codsocieta, Uidtenant);
        }
        public int UpdateApprovaCarPolicy(Guid Uid, string codcarpolicy, string preassegnazione, DateTime datadecorrenza, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateApprovaCarPolicy(Uid, codcarpolicy, preassegnazione, datadecorrenza, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateInvioMailCarPolicy(Guid Uid, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateInvioMailCarPolicy(Uid, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarPolicyPool(string codsocieta, string gradepool)
        {
            return OdsContratti.DefaultProvider.SelectCarPolicyPool(codsocieta, gradepool);
        }
        public int SelectCountCarPolicyPool(string codsocieta, string gradepool)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountCarPolicyPool(codsocieta, gradepool);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarPolicyStep2(int idutente)
        {
            return OdsContratti.DefaultProvider.SelectCarPolicyStep2(idutente);
        }
        public int SelectCountCarPolicyStep2(int idutente)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountCarPolicyStep2(idutente);
            return retVal;
        }
        public IContratti ReturnCodCarList(string codcarpolicy)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnCodCarList(codcarpolicy);
            return data;
        }
        public IContratti ReturnUltimoIdOrdine()
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnUltimoIdOrdine();
            return data;
        }
        public int InsertOrdineOptional(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertOrdineOptional(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateOrdineOptional(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateOrdineOptional(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnUltimoNumeroOrdine()
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnUltimoNumeroOrdine();
            return data;
        }
        public int SelectCountConfigurazioni(int idapprovazione)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountConfigurazioni(idapprovazione);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdini(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectRichiesteOrdini(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, idstatusordine, Uidtenant, numrecord, pagina);
        }
        public int SelectCountRichiesteOrdini(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRichiesteOrdini(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, idstatusordine, Uidtenant);
            return retVal;
        }
        public int UpdateChangeStatusOrdine(Guid UserId, int idstatusordine, string motivoscarto, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateChangeStatusOrdine(UserId, idstatusordine, motivoscarto, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateOrdineConfermaRental(Guid UserId, int idstatusordine, string fileconfermarental, DateTime dataconsegnaprevista, string annotazioniordini, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateOrdineConfermaRental(UserId, idstatusordine, fileconfermarental, dataconsegnaprevista, annotazioniordini, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniRental(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectRichiesteOrdiniRental(idstatusordine, keysearch, UserId, codfornitore, codsocieta, datadal, dataal, numrecord, pagina);
        }
        public int SelectCountRichiesteOrdiniRental(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRichiesteOrdiniRental(idstatusordine, keysearch, UserId, codfornitore, codsocieta, datadal, dataal);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniDriver(string keysearch, Guid UserId, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectRichiesteOrdiniDriver(keysearch, UserId, numrecord, pagina);
        }
        public int SelectCountRichiesteOrdiniDriver(string keysearch, Guid UserId)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRichiesteOrdiniDriver(keysearch, UserId);
            return retVal;
        }
        public IContratti DetailVeicoloAttualeDriver(Guid UserId)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailVeicoloAttualeDriver(UserId);
            return data;
        }
        public IContratti DetailVeicoloAttualePartner(Guid UserId)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailVeicoloAttualePartner(UserId);
            return data;
        }
        public int InsertKmPercorsi(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertKmPercorsi(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectKmPercorsi(Guid UserId, string targa)
        {
            return OdsContratti.DefaultProvider.SelectKmPercorsi(UserId, targa);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectKmPercorsiXTarga(string targa)
        {
            return OdsContratti.DefaultProvider.SelectKmPercorsiXTarga(targa);
        }

        public int SelectCountVolture(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountVolture(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectVolture(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectVolture(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectContrattiXVolture(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectContrattiXVolture(Uidtenant);
        }
        public int UpdateChangeStatusContratto(Guid Uid, int idstatuscontratto, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateChangeStatusContratto(Uid, idstatuscontratto, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateContrattiXVoltura(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateContrattiXVoltura(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int SelectCountVoltureDaAutorizzare(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountVoltureDaAutorizzare(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectVoltureDaAutorizzare(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectVoltureDaAutorizzare(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        public int UpdateContrattoVolturato(Guid Uid, DateTime datafinecontratto, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateContrattoVolturato(Uid, datafinecontratto, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniXDriver(Guid UserId)
        {
            return OdsContratti.DefaultProvider.SelectRichiesteOrdiniXDriver(UserId);
        }
        public int SelectCountRichiesteOrdiniXDriver(Guid UserId)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRichiesteOrdiniXDriver(UserId);
            return retVal;
        }
        public int UpdateRinunciaCarPolicy(int idutente, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateRinunciaCarPolicy(idutente, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int DeleteConfOrdine(int idordine, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.DeleteConfOrdine(idordine, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int DeleteConfOrdineOptional(int idordine, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.DeleteConfOrdineOptional(idordine, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnApprovatore(int idutente)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnApprovatore(idutente);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectStatusOrdineRental()
        {
            return OdsContratti.DefaultProvider.SelectStatusOrdineRental();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectStatusOrdineRentalEvasi()
        {
            return OdsContratti.DefaultProvider.SelectStatusOrdineRentalEvasi();
        }
        public int UpdateDocCarPolicy(Guid Uid, string documentocarpolicy, string documentopatente, string documentofuelcard, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateDocCarPolicy(Uid, documentocarpolicy, documentopatente, documentofuelcard, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnUidCarPolicy(Guid UserId)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnUidCarPolicy(UserId);
            return data;
        }
        public int InsertOrdiniPool(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertOrdiniPool(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnUltimoNumeroOrdinePool()
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnUltimoNumeroOrdinePool();
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniPool(string keysearch, string codsocieta, string codgrade, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectRichiesteOrdiniPool(keysearch, codsocieta, codgrade, datadal, dataal, UserId, idstatusordine, Uidtenant, numrecord, pagina);
        }
        public int SelectCountRichiesteOrdiniPool(string keysearch, string codsocieta, string codgrade, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRichiesteOrdiniPool(keysearch, codsocieta, codgrade, datadal, dataal, UserId, idstatusordine, Uidtenant);
            return retVal;
        }
        public IContratti DetailOrdiniPoolId(Guid UserId)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailOrdiniPoolId(UserId);
            return data;
        }
        public int UpdateChangeStatusOrdinePool(Guid UserId, int idstatusordine, string motivoscarto, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateChangeStatusOrdinePool(UserId, idstatusordine, motivoscarto, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti DetailContrattiId2(int idcontratto)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailContrattiId2(idcontratto);
            return data;
        }
        public int UpdateContrattiPool(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateContrattiPool(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniPoolXDriver(Guid UserId)
        {
            return OdsContratti.DefaultProvider.SelectRichiesteOrdiniPoolXDriver(UserId);
        }
        public int SelectCountRichiesteOrdiniPoolXDriver(Guid UserId)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRichiesteOrdiniPoolXDriver(UserId);
            return retVal;
        }
        public int SelectCountConfigurazioniPool(Guid UserId)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountConfigurazioniPool(UserId);
            return retVal;
        }
        public int UpdateTerminaAssegnazioneContratto(int idcontratto, DateTime assegnatoal, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateTerminaAssegnazioneContratto(idcontratto, assegnatoal, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int InsertInizioAssegnazioneContratto(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertInizioAssegnazioneContratto(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnUltimoIdContratto()
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnUltimoIdContratto();
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOrdiniContrattualizzati(Guid UserId)
        {
            return OdsContratti.DefaultProvider.SelectOrdiniContrattualizzati(UserId);
        }
        public int SelectCountOrdiniContrattualizzati(Guid UserId)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountOrdiniContrattualizzati(UserId);
            return retVal;
        }
        public int UpdateRifiutaAuto(Guid Uid, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateRifiutaAuto(Uid, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateAccettaAuto(Guid Uid, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateAccettaAuto(Uid, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRitiriAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectRitiriAuto(targa, UserId, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatusassegnazione, Uidtenant, numrecord, pagina);
        }
        public int SelectCountRitiriAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRitiriAuto(targa, UserId, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatusassegnazione, Uidtenant);
            return retVal;
        }
        public int UpdateChangeStatusOrdine2(Guid UserId, int idstatusordine, decimal deltacanone, string annotazioniordini, decimal canoneleasingofferta, string numeroordinefornitore, string alimentazione, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateChangeStatusOrdine2(UserId, idstatusordine, deltacanone, annotazioniordini, canoneleasingofferta, numeroordinefornitore, alimentazione, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDocCarPolicy(string check, Guid UserId, DateTime datadal, DateTime dataal, string flgdoccarpolicy, string flgdocpatente, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectDocCarPolicy(check, UserId, datadal, dataal, flgdoccarpolicy, flgdocpatente, Uidtenant, numrecord, pagina);
        }
        public int SelectCountDocCarPolicy(string check, Guid UserId, DateTime datadal, DateTime dataal, string flgdoccarpolicy, string flgdocpatente, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountDocCarPolicy(check, UserId, datadal, dataal, flgdoccarpolicy, flgdocpatente, Uidtenant);
            return retVal;
        }
        public int UpdateCheckDocPolicy(Guid Uid, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateCheckDocPolicy(Uid, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateNotCheckDocPolicy(Guid Uid, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateNotCheckDocPolicy(Uid, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectContrattiAssXIdContratto(int idcontratto)
        {
            return OdsContratti.DefaultProvider.SelectContrattiAssXIdContratto(idcontratto);
        }
        public int SelectCountRunningFleet(string targa, string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRunningFleet(targa, codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRunningFleet(string targa, string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectRunningFleet(targa, codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        public int SelectCountAutoPool(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountAutoPool(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoPool(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectAutoPool(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        public int InsertDocDelega(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertDocDelega(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdatePdfDocDelega(int iddelega, string filepdf, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdatePdfDocDelega(iddelega, filepdf, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnUltimoIdDelega()
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnUltimoIdDelega();
            return data;
        }
        public IContratti DetailDocDelegaXId(Guid UserId, string targa)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailDocDelegaXId(UserId, targa);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllContrattiTipo(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectAllContrattiTipo(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllContrattiTipoUso(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectAllContrattiTipoUso(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllContrattiTipoAssegnazione(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectAllContrattiTipoAssegnazione(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoXCarList(string codcarlist)
        {
            return OdsContratti.DefaultProvider.SelectAutoXCarList(codcarlist);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarPolicyXCarList(string codcarlist)
        {
            return OdsContratti.DefaultProvider.SelectCarPolicyXCarList(codcarlist);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarPolicyXSocieta(string codsocieta)
        {
            return OdsContratti.DefaultProvider.SelectCarPolicyXSocieta(codsocieta);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFornitoreXAuto(string codjatoauto)
        {
            return OdsContratti.DefaultProvider.SelectFornitoreXAuto(codjatoauto);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectUsersXSocieta(string codsocieta)
        {
            return OdsContratti.DefaultProvider.SelectUsersXSocieta(codsocieta);
        }
        public int SelectCountRiconsegnaAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRiconsegnaAuto(targa, UserId, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatusassegnazione, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRiconsegnaAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectRiconsegnaAuto(targa, UserId, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatusassegnazione, Uidtenant, numrecord, pagina);
        }
        public IContratti DetailContrattiAssId(int idcontratto, Guid UserId)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailContrattiAssId(idcontratto, UserId);
            return data;
        }
        public int UpdateContrattiAss(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateContrattiAss(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateCheckContrattiAss(int idassegnazione, DateTime assegnatoal, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateCheckContrattiAss(idassegnazione, assegnatoal, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateContrattiAssDriver(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateContrattiAssDriver(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti DetailContrattiXUidordine(Guid Uidordine)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailContrattiXUidordine(Uidordine);
            return data;
        }
        public int UpdateRifiutaAuto2(int idassegnazione, string motivorifiutoauto, string filerifiutoauto, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateRifiutaAuto2(idassegnazione, motivorifiutoauto, filerifiutoauto, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateAccettaAuto2(int idassegnazione, string fileverbaleauto, string filelibrettoauto, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateAccettaAuto2(idassegnazione, fileverbaleauto, filelibrettoauto, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateContrattoConsegna(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateContrattoConsegna(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllContrattiAss()
        {
            return OdsContratti.DefaultProvider.SelectAllContrattiAss();
        }
        public IContratti ReturnUserIdAssPool(Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnUserIdAssPool(Uidtenant);
            return data;
        }
        public IContratti ReturnUserIdAssRitiro()
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnUserIdAssRitiro();
            return data;
        }
        public int UpdateContrattoUserPool(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateContrattoUserPool(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectStatusAuto(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectStatusAuto(Uidtenant);
        }
        public int InsertDocZTL(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertDocZTL(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdatePdfDocZTL(int iddelega, string filepdf, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdatePdfDocZTL(iddelega, filepdf, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnUltimoIdZTL()
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnUltimoIdZTL();
            return data;
        }
        public IContratti DetailDocZTLXId(Guid UserId, string targa)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailDocZTLXId(UserId, targa);
            return data;
        }
        public int UpdatePdfOrdine(int idordine, string fileordinepdf, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdatePdfOrdine(idordine, fileordinepdf, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdatePdfOrdineFirmato(Guid Uid, string filefirma, Guid UserIdFirma, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdatePdfOrdineFirmato(Uid, filefirma, UserIdFirma, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOrdiniDaFirmare(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectOrdiniDaFirmare(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant, numrecord, pagina);
        }
        public int SelectCountOrdiniDaFirmare(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountOrdiniDaFirmare(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOrdiniFirmati(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectOrdiniFirmati(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant, numrecord, pagina);
        }
        public int SelectCountOrdiniFirmati(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountOrdiniFirmati(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFatture(string keysearch, string codfornitore, string codsocieta, DateTime datadocumentodal, DateTime datadocumentoal, int idstatusfattura, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectFatture(keysearch, codfornitore, codsocieta, datadocumentodal, datadocumentoal, idstatusfattura, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        public int SelectCountFatture(string keysearch, string codfornitore, string codsocieta, DateTime datadocumentodal, DateTime datadocumentoal, int idstatusfattura, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountFatture(keysearch, codfornitore, codsocieta, datadocumentodal, datadocumentoal, idstatusfattura, Uidtenant);
            return retVal;
        }
        public IContratti DetailFattureId(Guid Uid)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailFattureId(Uid);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDetailFatture(Guid Uidfattura, Guid Uidtenant, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectDetailFatture(Uidfattura, Uidtenant, pagina);
        }
        public int SelectCountDetailFatture(Guid Uidfattura, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountDetailFatture(Uidfattura, Uidtenant);
            return retVal;
        }
        public int UpdateAbbinaFattura(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateAbbinaFattura(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateStatusFattura(Guid Uid, int idstatusfattura, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateStatusFattura(Uid, idstatusfattura, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti DetailFattureDetId(Guid Uid)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailFattureDetId(Uid);
            return data;
        }
        public bool ExistAssegnazioneContratto(Guid UserID, int idcontratto)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            bool retVal;
            retVal = servizioContratti.ExistAssegnazioneContratto(UserID, idcontratto);
            return retVal;
        }
        public int UpdateInizioAssegnazioneContratto(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateInizioAssegnazioneContratto(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectTemplateFatture(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectTemplateFatture(Uidtenant);
        }
        public int UpdateSvuotaAbbinamentoFattura(Guid Uidfattura, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateSvuotaAbbinamentoFattura(Uidfattura, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> ReturnCodiceCDC(DateTime datariferimentoda, DateTime datariferimentoa, string targa)
        {
            return OdsContratti.DefaultProvider.ReturnCodiceCDC(datariferimentoda, datariferimentoa, targa);
        }
        public int UpdateStatusOrdineScartato(int idapprovazione, Guid Uid, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateStatusOrdineScartato(idapprovazione, Uid, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountConfigurazioniInviate(int idapprovazione)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountConfigurazioniInviate(idapprovazione);
            return retVal;
        }
        public int SelectCountConfigurazioniDaFirmare(int idapprovazione)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountConfigurazioniDaFirmare(idapprovazione);
            return retVal;
        }
        public int SelectCountUserCarPolicy(string keysearch, string codsocieta, Guid UserId, DateTime datadal, DateTime dataal, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountUserCarPolicy(keysearch, codsocieta, UserId, datadal, dataal, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectUserCarPolicy(string keysearch, string codsocieta, Guid UserId, DateTime datadal, DateTime dataal, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectUserCarPolicy(keysearch, codsocieta, UserId, datadal, dataal, Uidtenant, numrecord, pagina);
        }
        public int SelectCountConfigurazioniDaConfermareInviate(int idapprovazione)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountConfigurazioniDaConfermareInviate(idapprovazione);
            return retVal;
        }
        public int SelectCountConfigurazioniDaEvadereInviate(Guid UserId)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountConfigurazioniDaEvadereInviate(UserId);
            return retVal;
        }
        public int SelectCountConfigurazioniEvaseInviate(int idapprovazione)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountConfigurazioniEvaseInviate(idapprovazione);
            return retVal;
        }
        public decimal SelectToTFuelXUser(string targa, Guid UserId)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            decimal retVal;
            retVal = servizioContratti.SelectToTFuelXUser(targa, UserId);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectStoricoAutoUser(Guid UserId)
        {
            return OdsContratti.DefaultProvider.SelectStoricoAutoUser(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDocumentiAuto(string targa)
        {
            return OdsContratti.DefaultProvider.SelectDocumentiAuto(targa);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectConsumiAutoXUser(string targa, DateTime datadal, DateTime dataal, Guid UserId)
        {
            return OdsContratti.DefaultProvider.SelectConsumiAutoXUser(targa, datadal, dataal, UserId);
        }
        public int InsertDocAuto(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertDocAuto(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFileAuto(string targa, string codsocieta, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectFileAuto(targa, codsocieta, UserId, Uidtenant, numrecord, pagina);
        }
        public int SelectCountFileAuto(string targa, string codsocieta, Guid UserId, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountFileAuto(targa, codsocieta, UserId, Uidtenant);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFileDocumentiAuto(string targa)
        {
            return OdsContratti.DefaultProvider.SelectFileDocumentiAuto(targa);
        }
        public int UpdateFileAuto(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateFileAuto(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountInConfigurazione(int idapprovazione)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountInConfigurazione(idapprovazione);
            return retVal;
        }

        public IContratti SelectKmPercorsiAttuali(string targa)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.SelectKmPercorsiAttuali(targa);
            return data;
        }
        public int SelectCountFringeInCorso(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountFringeInCorso(codsocieta, UserId, mese, anno, Uidtenant);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFringeInCorso(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectFringeInCorso(codsocieta, UserId, mese, anno, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOrdiniInCorsoTeamAppr(string keysearch, string codsocieta, string codgrade, string codcarlist, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectOrdiniInCorsoTeamAppr(keysearch, codsocieta, codgrade, codcarlist, datadal, dataal, UserId, idstatusordine, Uidtenant, numrecord, pagina);
        }
        public int SelectCountOrdiniInCorsoTeamAppr(string keysearch, string codsocieta, string codgrade, string codcarlist, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountOrdiniInCorsoTeamAppr(keysearch, codsocieta, codgrade, codcarlist, datadal, dataal, UserId, idstatusordine, Uidtenant);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllStatusOrdineApprovatori(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectAllStatusOrdineApprovatori(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarPolicyPoolTeamAppr(string keysearch, string codsocieta, string targa, int idstatuspool, string luogo, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectCarPolicyPoolTeamAppr(keysearch, codsocieta, targa, idstatuspool, luogo, Uidtenant, numrecord, pagina);
        }
        public int SelectCountCarPolicyPoolTeamAppr(string keysearch, string codsocieta, string targa, int idstatuspool, string luogo, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountCarPolicyPoolTeamAppr(keysearch, codsocieta, targa, idstatuspool, luogo, Uidtenant);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRunningTeamAppr(string codsocieta, Guid UserId, string marca, string modello, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectRunningTeamAppr(codsocieta, UserId, marca, modello, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant, numrecord, pagina);
        }
        public int SelectCountRunningTeamAppr(string codsocieta, Guid UserId, string marca, string modello, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRunningTeamAppr(codsocieta, UserId, marca, modello, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant);
            return retVal;
        }
        public int UpdateAutoPool(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateAutoPool(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountOrdiniRental(string codfornitore, int idstatus)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountOrdiniRental(codfornitore, idstatus);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniRentalEvasi(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectRichiesteOrdiniRentalEvasi(idstatusordine, keysearch, UserId, codfornitore, codsocieta, datadal, dataal, numrecord, pagina);
        }
        public int SelectCountRichiesteOrdiniRentalEvasi(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRichiesteOrdiniRentalEvasi(idstatusordine, keysearch, UserId, codfornitore, codsocieta, datadal, dataal);
            return retVal;
        }
        public int SelectCountUserCarPolicyPageAdmin(string codsocieta, string carpolicy, Guid UserId, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountUserCarPolicyPageAdmin(codsocieta, carpolicy, UserId, Uidtenant);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectUserCarPolicyPageAdmin(string codsocieta, string carpolicy, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectUserCarPolicyPageAdmin(codsocieta, carpolicy, UserId, Uidtenant, numrecord, pagina);
        }
        public IContratti ExistOldUserCarPolicy(int idutente)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ExistOldUserCarPolicy(idutente);
            return data;
        }
        public bool ExistStoricoAuto(Guid UserID)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            bool retVal;
            retVal = servizioContratti.ExistStoricoAuto(UserID);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoUser(Guid UserId)
        {
            return OdsContratti.DefaultProvider.SelectAutoUser(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOrdiniUser(Guid UserId)
        {
            return OdsContratti.DefaultProvider.SelectOrdiniUser(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFuelCardUser(Guid UserId)
        {
            return OdsContratti.DefaultProvider.SelectFuelCardUser(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectStatusFatture(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectStatusFatture(Uidtenant);
        }
        public int SelectCountFattureNonAbbinate(Guid Uidfattura)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountFattureNonAbbinate(Uidfattura);
            return retVal;
        }
        public int UpdateProrogaContratto(Guid Uid, DateTime dataproroga, string nota, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateProrogaContratto(Uid, dataproroga, nota, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAssegnazioniContratti(string targa, string targasearch, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectAssegnazioniContratti(targa, targasearch, UserId, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatusassegnazione, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        public int SelectCountAssegnazioniContratti(string targa, string targasearch, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountAssegnazioniContratti(targa, targasearch, UserId, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatusassegnazione, Uidtenant);
            return retVal;
        }
        public IContratti DetailAssegnazioniContrattiXId(int idassegnazione)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailAssegnazioniContrattiXId(idassegnazione);
            return data;
        }
        public int UpdateAssegnazioneContratto(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateAssegnazioneContratto(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateRiconsegnaAuto(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateRiconsegnaAuto(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti DetailDriverXCdc(string tipocentro, Guid Uid)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailDriverXCdc(tipocentro, Uid);
            return data;
        }
        public int UpdateFatturaAbb(Guid Uid, int templateabb, DateTime datarifabb, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateFatturaAbb(Uid, templateabb, datarifabb, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti DetailTemplateFattureId(int idtemplate)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailTemplateFattureId(idtemplate);
            return data;
        }
        public int SelectCountAllDeltaCanone(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountAllDeltaCanone(codsocieta, UserId, mese, anno, Uidtenant);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllDeltaCanone(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectAllDeltaCanone(codsocieta, UserId, mese, anno, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDetailFattureGroup(Guid Uidfattura)
        {
            return OdsContratti.DefaultProvider.SelectDetailFattureGroup(Uidfattura);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDetailConsumiGroup(string numerofattura, int idcompagnia, DateTime datafattura)
        {
            return OdsContratti.DefaultProvider.SelectDetailConsumiGroup(numerofattura, idcompagnia, datafattura);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDetailConsumiTelePassGroup(int idcompagnia, DateTime datafatturada, DateTime datafatturaa)
        {
            return OdsContratti.DefaultProvider.SelectDetailConsumiTelePassGroup(idcompagnia, datafatturada, datafatturaa);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFattureDeltaCanone(string codsocieta, Guid UserId, string mese, int anno)
        {
            return OdsContratti.DefaultProvider.SelectFattureDeltaCanone(codsocieta, UserId, mese, anno);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectNoteCreditoDeltaCanone(string codsocieta, Guid UserId, string mese, int anno)
        {
            return OdsContratti.DefaultProvider.SelectNoteCreditoDeltaCanone(codsocieta, UserId, mese, anno);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFattureMulte(string targa, Guid UserId, string mese, int anno)
        {
            return OdsContratti.DefaultProvider.SelectFattureMulte(targa, UserId, mese, anno);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectFattureMulteFee(string codsocieta, Guid UserId, string mese, int anno)
        {
            return OdsContratti.DefaultProvider.SelectFattureMulteFee(codsocieta, UserId, mese, anno);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectNoteCreditoMulte(string targa, Guid UserId, string mese, int anno)
        {
            return OdsContratti.DefaultProvider.SelectNoteCreditoMulte(targa, UserId, mese, anno);
        }
        public int UpdatePoolContratto(Guid Uid, int checkordinepool, string gradepool, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdatePoolContratto(Uid, checkordinepool, gradepool, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnAssegnatoAlMaggiore(int idcontratto)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnAssegnatoAlMaggiore(idcontratto);
            return data;
        }
        public int UpdateDataFineContratto(int idcontratto, DateTime datafinecontratto, Guid UserId, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateDataFineContratto(idcontratto, datafinecontratto, UserId, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateDeltaCanoneOrdini(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateDeltaCanoneOrdini(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDelegheUser(int idtipomodulo, Guid UserId)
        {
            return OdsContratti.DefaultProvider.SelectDelegheUser(idtipomodulo, UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDeleghe(Guid UserId, DateTime datadocumentodal, DateTime datadocumentoal, string checkapprovatore, int idtipomodulo, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectDeleghe(UserId, datadocumentodal, datadocumentoal, checkapprovatore, idtipomodulo, Uidtenant, numrecord, pagina);
        }
        public int SelectCountDeleghe(Guid UserId, DateTime datadocumentodal, DateTime datadocumentoal, string checkapprovatore, int idtipomodulo, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountDeleghe(UserId, datadocumentodal, datadocumentoal, checkapprovatore, idtipomodulo, Uidtenant);
            return retVal;
        }
        public int InsertDelega(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertDelega(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateDelega(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateDelega(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti DetailDelega(Guid Uid)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailDelega(Uid);
            return data;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoXFornitore(string codfornitore, Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectAutoXFornitore(codfornitore, Uidtenant);
        }
        public int UpdatePoolContratto2(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdatePoolContratto2(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectViewCarPolicyPoolTeamAppr(string keysearch, string codsocieta, string targa, int idstatuspool)
        {
            return OdsContratti.DefaultProvider.SelectViewCarPolicyPoolTeamAppr(keysearch, codsocieta, targa, idstatuspool);
        }
        public int UpdateCarPolicy(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateCarPolicy(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateDocFuelCard(int idassegnazione, string documentofuelcard, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateDocFuelCard(idassegnazione, documentofuelcard, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnFileAuto(int idassegnazione)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnFileAuto(idassegnazione);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoSostitutive(string targa, Guid UserId, string codsocieta, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectAutoSostitutive(targa, UserId, codsocieta, datacontrattodal, datacontrattoal, Uidtenant, numrecord, pagina);
        }
        public int SelectCountAutoSostitutive(string targa, Guid UserId, string codsocieta, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountAutoSostitutive(targa, UserId, codsocieta, datacontrattodal, datacontrattoal, Uidtenant);
            return retVal;
        }
        public IContratti DetailAutoSostId(Guid Uid)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailAutoSostId(Uid);
            return data;
        }
        public int UpdateAutoSost(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateAutoSost(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int InsertAutoSost(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertAutoSost(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int DeleteAssegnazione(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.DeleteAssegnazione(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public bool ExistTargaAss(string targa)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            bool retVal;
            retVal = servizioContratti.ExistTargaAss(targa);
            return retVal;
        }
        public bool ExistAssegnazione(Guid UserId, string codsocieta, DateTime assegnatodal, DateTime assegnatoal, string targa)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            bool retVal;
            retVal = servizioContratti.ExistAssegnazione(UserId, codsocieta, assegnatodal, assegnatoal, targa);
            return retVal;
        }
        public int UpdateApprovaDelega(string checkapprovatore, string noteapprovazione, Guid Uid, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateApprovaDelega(checkapprovatore, noteapprovazione, Uid, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnTargaAssegnazioneXConcur(Guid UserId, DateTime dataspesa)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnTargaAssegnazioneXConcur(UserId, dataspesa);
            return data;
        }
        public IContratti ReturnModConv(Guid Uid)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnModConv(Uid);
            return data;
        }
        public int UpdateModConv(Guid Uid, string moduloconvivenza, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateModConv(Uid, moduloconvivenza, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnLuogoRestituzioneXTarga(string targa)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnLuogoRestituzioneXTarga(targa);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectCarBenefit(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectCarBenefit(Uidtenant);
        }
        public IContratti ReturnTypeCarPolicy(int idutente)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnTypeCarPolicy(idutente);
            return data;
        }
        public int UpdateUserCarPolicy(int idapprovazione, string sceltabenefit, string codpacchetto, DateTime datasceltabenefit, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateUserCarPolicy(idapprovazione, sceltabenefit, codpacchetto, datasceltabenefit, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnDatiBenefitCarPolicy(int idapprovazione)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnDatiBenefitCarPolicy(idapprovazione);
            return data;
        }
        public int InsertCarPolicy(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertCarPolicy(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int InsertConfigurazionePartner(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertConfigurazionePartner(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnIdConf()
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnIdConf();
            return data;
        }
        public int InsertAllegato(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertAllegato(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int InsertDelegaDriver(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertDelegaDriver(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int DeleteDeleghePartner(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.DeleteDeleghePartner(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDeleghePartner(Guid UserId)
        {
            return OdsContratti.DefaultProvider.SelectDeleghePartner(UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDelegheDriver(Guid UserId)
        {
            return OdsContratti.DefaultProvider.SelectDelegheDriver(UserId);
        }
        public int SelectCountContrattiPartner(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountContrattiPartner(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectContrattiPartner(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectContrattiPartner(codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRichiesteOrdiniPartner(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectRichiesteOrdiniPartner(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, idstatusordine, Uidtenant, numrecord, pagina);
        }
        public int SelectCountRichiesteOrdiniPartner(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRichiesteOrdiniPartner(keysearch, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, idstatusordine, Uidtenant);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectConfigurazioniPartner(DateTime datadal, DateTime dataal, Guid UserId, int idstatuordine, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectConfigurazioniPartner(datadal, dataal, UserId, idstatuordine, Uidtenant, numrecord, pagina);
        }
        public int SelectCountConfigurazioniPartner(DateTime datadal, DateTime dataal, Guid UserId, int idstatuordine, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountConfigurazioniPartner(datadal, dataal, UserId, idstatuordine, Uidtenant);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllegatiConfigurazioniPartner(int idconfigurazione)
        {
            return OdsContratti.DefaultProvider.SelectAllegatiConfigurazioniPartner(idconfigurazione);
        }
        public IContratti DetailConfigurazionePartner(Guid Uid)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailConfigurazionePartner(Uid);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllTipoPenaleAuto(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectAllTipoPenaleAuto(Uidtenant);
        }
        public int SelectCountPenaliAuto(Guid UserId, string targa, string codfornitore, string numerofattura, DateTime datafatturadal, DateTime datafatturaal, int idtipopenaleauto, string status, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountPenaliAuto(UserId, targa, codfornitore, numerofattura, datafatturadal, datafatturaal, idtipopenaleauto, status, Uidtenant);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectPenaliAuto(Guid UserId, string targa, string codfornitore, string numerofattura, DateTime datafatturadal, DateTime datafatturaal, int idtipopenaleauto, string status, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectPenaliAuto(UserId, targa, codfornitore, numerofattura, datafatturadal, datafatturaal, idtipopenaleauto, status, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        public int InsertPenale(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertPenale(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti DetailIdPenale(Guid Uid)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailIdPenale(Uid);
            return data;
        }
        public int UpdatePenale(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdatePenale(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateStatusPenale(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateStatusPenale(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectStatusConfigurazionePartner(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectStatusConfigurazionePartner(Uidtenant);
        }
        public int UpdateStatusConfigurazionePartner(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateStatusConfigurazionePartner(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int SelectCountDelegheDriver(Guid UserId)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountDelegheDriver(UserId);
            return retVal;
        }
        public IContratti ExistCarPolicyMobilita(string codcarpolicy)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ExistCarPolicyMobilita(codcarpolicy);
            return data;
        }
        public int SelectCountRichiesteOrdiniDriverXCodjato(Guid UserId, string codjatoauto)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRichiesteOrdiniDriverXCodjato(UserId, codjatoauto);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectOptionalAutoXOrdine(int idordine)
        {
            return OdsContratti.DefaultProvider.SelectOptionalAutoXOrdine(idordine);
        }
        public int UpdateFileLibrettoAuto(Guid Uid, string filelibrettoautocontratto, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateFileLibrettoAuto(Uid, filelibrettoautocontratto, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int DeleteAutoSost(Guid Uid, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.DeleteAutoSost(Uid, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectExtraPlafond(string codsocieta, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectExtraPlafond(codsocieta, UserId, Uidtenant, numrecord, pagina);
        }
        public int SelectCountExtraPlafond(string codsocieta, Guid UserId, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountExtraPlafond(codsocieta, UserId, Uidtenant);
            return retVal;
        }
        public int DeletePenali(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.DeletePenali(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRevisioniUser(Guid UserId, string targa, int anno, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectRevisioniUser(UserId, targa, anno, numrecord, pagina);
        }
        public int SelectCountRevisioniUser(Guid UserId, string targa, int anno)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRevisioniUser(UserId, targa, anno);
            return retVal;
        }
        public IContratti DetailRevisioniId(Guid Uid)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailRevisioniId(Uid);
            return data;
        }
        public int UpdateCheckRevisione(Guid Uid, string filerev, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateCheckRevisione(Uid, filerev, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectRevisioniAll(Guid UserId, string targa, int anno, int statuscheck, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectRevisioniAll(UserId, targa, anno, statuscheck, Uidtenant, numrecord, pagina);
        }
        public int SelectCountRevisioniAll(Guid UserId, string targa, int anno, int statuscheck, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountRevisioniAll(UserId, targa, anno, statuscheck, Uidtenant);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectTipoUtilizzo(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectTipoUtilizzo(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoServizio(string targa, string targasearch, Guid UserId, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectAutoServizio(targa, targasearch, UserId, datacontrattodal, datacontrattoal, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        public int SelectCountAutoServizio(string targa, string targasearch, Guid UserId, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountAutoServizio(targa, targasearch, UserId, datacontrattodal, datacontrattoal, Uidtenant);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectPrenotazioniAutoServizio(string targa)
        {
            return OdsContratti.DefaultProvider.SelectPrenotazioniAutoServizio(targa);
        }
        public bool ExistPrenotazioneAutoServizio(DateTime datadal, DateTime dataal, string targa)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            bool retVal;
            retVal = servizioContratti.ExistPrenotazioneAutoServizio(datadal, dataal, targa);
            return retVal;
        }
        public int InsertPrenotazioneAutoServizio(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.InsertPrenotazioneAutoServizio(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnOrdineFirma(Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.ReturnOrdineFirma(Uidtenant);
            return data;
        }
        public IContratti DetailAutoServizioId(int idassegnazione)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailAutoServizioId(idassegnazione);
            return data;
        }
        public int UpdateAutoServizio(IContratti value)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateAutoServizio(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectLibrettoAutoServizio(string targa, Guid UserId, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsContratti.DefaultProvider.SelectLibrettoAutoServizio(targa, UserId, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        public int SelectCountLibrettoAutoServizio(string targa, Guid UserId, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal;
            retVal = servizioContratti.SelectCountLibrettoAutoServizio(targa, UserId, Uidtenant);
            return retVal;
        }
        public IContratti DetailLibrettoAutoServizioXTarga(string targa)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            IContratti data = servizioContratti.DetailLibrettoAutoServizioXTarga(targa);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectDetailLibrettoAutoServizio(string targa)
        {
            return OdsContratti.DefaultProvider.SelectDetailLibrettoAutoServizio(targa);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAllScopoViaggio(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectAllScopoViaggio(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> SelectAutoServizioDispo(Guid Uidtenant)
        {
            return OdsContratti.DefaultProvider.SelectAutoServizioDispo(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IContratti> DispoAutoServizioXDay(string targa, DateTime datains)
        {
            return OdsContratti.DefaultProvider.DispoAutoServizioXDay(targa, datains);
        }
        public int UpdateAutorizzaAutoServizio(int idassegnazione, Guid Uidtenant)
        {
            IContrattiProvider servizioContratti = ServizioContratti;
            int retVal = 0;
            if (servizioContratti.UpdateAutorizzaAutoServizio(idassegnazione, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
    }
}
