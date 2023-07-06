// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CODSMulte.cs" company="">
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

    public class OdsMulte : ODSProvider<MulteProvider>, IOdsMulte
    {
        private readonly MulteProvider multeProvider = (MulteProvider)new ProviderFactory().ServizioAccount;

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateMulte(IMulte value)
        {
            return multeProvider.UpdateMulte(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteMulte(IMulte value)
        {
            return multeProvider.DeleteMulte(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertMulte(IMulte value)
        {
            return multeProvider.DeleteMulte(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectMulte(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return multeProvider.SelectMulte(keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountMulte(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant)
        {
            return multeProvider.SelectCountMulte(keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllStatusLavorazione(Guid Uidtenant)
        {
            return multeProvider.SelectAllStatusLavorazione(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllStatusPagamento(Guid Uidtenant)
        {
            return multeProvider.SelectAllStatusPagamento(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTipoMulte(Guid Uidtenant)
        {
            return multeProvider.SelectAllTipoMulte(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTipoTrasmissioneMulte(Guid Uidtenant)
        {
            return multeProvider.SelectAllTipoTrasmissioneMulte(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateCkEmail(Guid Uid, Guid Uidtenant)
        {
            return multeProvider.UpdateCkEmail(Uid, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int ChangeStasusLavMulta(Guid Uid, int idstatuslavorazione, string filemanleva, Guid Uidtenant)
        {
            return multeProvider.ChangeStasusLavMulta(Uid, idstatuslavorazione, filemanleva, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectMulteDaPagare(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, int idtitolarepagamento, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return multeProvider.SelectMulteDaPagare(keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, idtitolarepagamento, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountMulteDaPagare(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, int idtitolarepagamento, Guid Uidtenant)
        {
            return multeProvider.SelectCountMulteDaPagare(keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal, UserId, idtitolarepagamento, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateMultaPagata(IMulte value)
        {
            return multeProvider.UpdateMultaPagata(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllEnti(string keysearch, Guid Uidtenant)
        {
            return multeProvider.SelectAllEnti(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllInfrazioni(string keysearch, Guid Uidtenant)
        {
            return multeProvider.SelectAllInfrazioni(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTarghe(Guid Uidtenant)
        {
            return multeProvider.SelectAllTarghe(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTargheTerm(string keysearch, Guid Uidtenant)
        {
            return multeProvider.SelectAllTargheTerm(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTargheExt(Guid Uidtenant)
        {
            return multeProvider.SelectAllTargheExt(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllImporto(Guid Uid)
        {
            return multeProvider.SelectAllImporto(Uid);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTitolarePagamento(Guid Uidtenant)
        {
            return multeProvider.SelectAllTitolarePagamento(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertCedolino(IMulte value)
        {
            return multeProvider.InsertCedolino(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int UpdateCedolino(IMulte value)
        {
            return multeProvider.UpdateCedolino(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectCedolini(DateTime datadal, DateTime dataal, Guid UserId, int idtipologiacedolino, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return multeProvider.SelectCedolini(datadal, dataal, UserId, idtipologiacedolino, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountCedolini(DateTime datadal, DateTime dataal, Guid UserId, int idtipologiacedolino)
        {
            return multeProvider.SelectCountCedolini(datadal, dataal, UserId, idtipologiacedolino);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllTipologiaCedolini()
        {
            return multeProvider.SelectAllTipologiaCedolini();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAddebiti(Guid UserId, DateTime datadal, DateTime dataal, int numrecord, int pagina)
        {
            return multeProvider.SelectAddebiti(UserId, datadal, dataal, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountAddebiti(Guid UserId, DateTime datadal, DateTime dataal)
        {
            return multeProvider.SelectCountAddebiti(UserId, datadal, dataal);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectMultePagate(string targa, Guid UserId, string mese, int anno, Guid Uidtenant, int numrecord, int pagina)
        {
            return multeProvider.SelectMultePagate(targa, UserId, mese, anno, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountMultePagate(string targa, Guid UserId, string mese, int anno, Guid Uidtenant)
        {
            return multeProvider.SelectCountMultePagate(targa, UserId, mese, anno, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectAllContoPagamento(Guid Uidtenant)
        {
            return multeProvider.SelectAllContoPagamento(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectTargheAutoServTerm(string keysearch, Guid Uidtenant)
        {
            return multeProvider.SelectTargheAutoServTerm(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IMulte> SelectTargheAutoServ(Guid Uidtenant)
        {
            return multeProvider.SelectTargheAutoServ(Uidtenant);
        }
    }
}
