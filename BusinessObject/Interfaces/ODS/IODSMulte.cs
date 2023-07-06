// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IODSMulte.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface IOdsMulte
    {
        int UpdateMulte(IMulte value);
        int DeleteMulte(IMulte value);
        int InsertMulte(IMulte value);
        List<IMulte> SelectMulte(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountMulte(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant);
        List<IMulte> SelectAllStatusLavorazione(Guid Uidtenant);
        List<IMulte> SelectAllStatusPagamento(Guid Uidtenant);
        List<IMulte> SelectAllTipoMulte(Guid Uidtenant);
        List<IMulte> SelectAllTipoTrasmissioneMulte(Guid Uidtenant);
        int UpdateCkEmail(Guid Uid, Guid Uidtenant);
        int ChangeStasusLavMulta(Guid Uid, int idstatuslavorazione, string filemanleva, Guid Uidtenant);
        List<IMulte> SelectMulteDaPagare(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, int idtitolarepagamento, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountMulteDaPagare(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, int idtitolarepagamento, Guid Uidtenant);
        int UpdateMultaPagata(IMulte value);
        List<IMulte> SelectAllEnti(string keysearch, Guid Uidtenant);
        List<IMulte> SelectAllInfrazioni(string keysearch, Guid Uidtenant);
        List<IMulte> SelectAllTarghe(Guid Uidtenant);
        List<IMulte> SelectAllTargheTerm(string keysearch, Guid Uidtenant);
        List<IMulte> SelectAllTargheExt(Guid Uidtenant);
        List<IMulte> SelectAllImporto(Guid Uid);
        List<IMulte> SelectAllTitolarePagamento(Guid Uidtenant);
        int InsertCedolino(IMulte value);
        int UpdateCedolino(IMulte value);
        List<IMulte> SelectCedolini(DateTime datadal, DateTime dataal, Guid UserId, int idtipologiacedolino, string ordine, string tipoordine, int numrecord, int pagina);
        int SelectCountCedolini(DateTime datadal, DateTime dataal, Guid UserId, int idtipologiacedolino);
        List<IMulte> SelectAllTipologiaCedolini();
        List<IMulte> SelectAddebiti(Guid UserId, DateTime datadal, DateTime dataal, int numrecord, int pagina);
        int SelectCountAddebiti(Guid UserId, DateTime datadal, DateTime dataal);
        List<IMulte> SelectMultePagate(string targa, Guid UserId, string mese, int anno, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountMultePagate(string targa, Guid UserId, string mese, int anno, Guid Uidtenant);
        List<IMulte> SelectAllContoPagamento(Guid Uidtenant);
        List<IMulte> SelectTargheAutoServTerm(string keysearch, Guid Uidtenant);
        List<IMulte> SelectTargheAutoServ(Guid Uidtenant);
    }
}
