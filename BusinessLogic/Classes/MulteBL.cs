// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CMulteBL.cs" company="">
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
    public class MulteBL : BaseBL, IMulteBL
    {

        public MulteBL() {
        }

        private IMulteProvider ServizioMulte
        {
            get { return ProviderFactory.ServizioMulte; }
        }

        public int UpdateMulte(IMulte value)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            int retVal = 0;
            if (servizioMulte.UpdateMulte(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }


        
        public int DeleteMulte(IMulte value)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            int retVal = 0;
            if (servizioMulte.DeleteMulte(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        
        public int InsertMulte(IMulte value)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            int retVal = 0;
            if (servizioMulte.InsertMulte(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }       
        
        public IMulte DetailMulteId(Guid Uid)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            IMulte data = servizioMulte.DetailMulteId(Uid);
            return data;
        }
                
        public int SelectCountMulte(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            int retVal;
            retVal = servizioMulte.SelectCountMulte(keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, Uidtenant);
            return retVal;
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectMulte (string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsMulte.DefaultProvider.SelectMulte(keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllStatusLavorazione(Guid Uidtenant)
        {
            return OdsMulte.DefaultProvider.SelectAllStatusLavorazione(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllStatusPagamento(Guid Uidtenant)
        {
            return OdsMulte.DefaultProvider.SelectAllStatusPagamento(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTipoMulte(Guid Uidtenant)
        {
            return OdsMulte.DefaultProvider.SelectAllTipoMulte(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTipoTrasmissioneMulte(Guid Uidtenant)
        {
            return OdsMulte.DefaultProvider.SelectAllTipoTrasmissioneMulte(Uidtenant);
        }
        public IMulte UltimoIDMulta()
        {
            IMulteProvider servizioMulte = ServizioMulte;
            IMulte data = servizioMulte.UltimoIDMulta();
            return data;
        }
        public int UpdateCkEmail(Guid Uid, Guid Uidtenant)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            int retVal = 0;
            if (servizioMulte.UpdateCkEmail(Uid, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int ChangeStasusLavMulta(Guid Uid, int idstatuslavorazione, string filemanleva, Guid Uidtenant)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            int retVal = 0;
            if (servizioMulte.ChangeStasusLavMulta(Uid, idstatuslavorazione, filemanleva, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountMulteDaPagare(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, int idtitolarepagamento, Guid Uidtenant)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            int retVal;
            retVal = servizioMulte.SelectCountMulteDaPagare(keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, idtitolarepagamento, Uidtenant);
            return retVal;
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectMulteDaPagare(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, int idtitolarepagamento, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsMulte.DefaultProvider.SelectMulteDaPagare(keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, idtitolarepagamento, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        public int UpdateMultaPagata(IMulte value)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            int retVal = 0;
            if (servizioMulte.UpdateMultaPagata(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllEnti(string keysearch, Guid Uidtenant)
        {
            return OdsMulte.DefaultProvider.SelectAllEnti(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllInfrazioni(string keysearch, Guid Uidtenant)
        {
            return OdsMulte.DefaultProvider.SelectAllInfrazioni(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTarghe(Guid Uidtenant)
        {
            return OdsMulte.DefaultProvider.SelectAllTarghe(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTargheTerm(string keysearch, Guid Uidtenant)
        {
            return OdsMulte.DefaultProvider.SelectAllTargheTerm(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTargheExt(Guid Uidtenant)
        {
            return OdsMulte.DefaultProvider.SelectAllTargheExt(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllImporto(Guid Uid)
        {
            return OdsMulte.DefaultProvider.SelectAllImporto(Uid);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTitolarePagamento(Guid Uidtenant)
        {
            return OdsMulte.DefaultProvider.SelectAllTitolarePagamento(Uidtenant);
        }
        public int InsertCedolino(IMulte value)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            int retVal = 0;
            if (servizioMulte.InsertCedolino(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateCedolino(IMulte value)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            int retVal = 0;
            if (servizioMulte.UpdateCedolino(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountCedolini(DateTime datadal, DateTime dataal, Guid UserId, int idtipologiacedolino)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            int retVal;
            retVal = servizioMulte.SelectCountCedolini(datadal, dataal, UserId, idtipologiacedolino);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectCedolini(DateTime datadal, DateTime dataal, Guid UserId, int idtipologiacedolino, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsMulte.DefaultProvider.SelectCedolini(datadal, dataal, UserId, idtipologiacedolino, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTipologiaCedolini()
        {
            return OdsMulte.DefaultProvider.SelectAllTipologiaCedolini();
        }
        public IMulte ExistCedolino(int idmulta, int idtipologiacedolino)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            IMulte data = servizioMulte.ExistCedolino(idmulta, idtipologiacedolino);
            return data;
        }
        public int SelectCountAddebiti(Guid UserId, DateTime datadal, DateTime dataal)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            int retVal;
            retVal = servizioMulte.SelectCountAddebiti(UserId, datadal, dataal);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAddebiti(Guid UserId, DateTime datadal, DateTime dataal, int numrecord, int pagina)
        {
            return OdsMulte.DefaultProvider.SelectAddebiti(UserId, datadal, dataal, numrecord, pagina);
        }
        public int SelectCountMultePagate(string targa, Guid UserId, string mese, int anno, Guid Uidtenant)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            int retVal;
            retVal = servizioMulte.SelectCountMultePagate(targa, UserId, mese, anno, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectMultePagate(string targa, Guid UserId, string mese, int anno, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsMulte.DefaultProvider.SelectMultePagate(targa, UserId, mese, anno, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllContoPagamento(Guid Uidtenant)
        {
            return OdsMulte.DefaultProvider.SelectAllContoPagamento(Uidtenant);
        }
        public bool ExistVerbaleMulta(string numeroverbale, string targa)
        {
            IMulteProvider servizioMulte = ServizioMulte;
            bool retVal;
            retVal = servizioMulte.ExistVerbaleMulta(numeroverbale, targa);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectTargheAutoServTerm(string keysearch, Guid Uidtenant)
        {
            return OdsMulte.DefaultProvider.SelectTargheAutoServTerm(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectTargheAutoServ(Guid Uidtenant)
        {
            return OdsMulte.DefaultProvider.SelectTargheAutoServ(Uidtenant);
        }
    }
}
