// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IODSAccount.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface IOdsAccount
    {
        int Update(IAccount value);
        int Delete(IAccount value);
        int Insert(IAccount value);
        List<IAccount> SelectUsername(string userName, int idstatususer, int idgruppouser, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        List<IAccount> SelectUsers(Guid Uidtenant);
        List<IAccount> SelectUsersXSocieta(string codsocieta, Guid Uidtenant);
        List<IAccount> SelectUsersTerm(string keysearch, Guid Uidtenant);
        int SelectCountUsername(string userName, int idstatususer, int idgruppouser, Guid Uidtenant);
        List<IAccount> SelectStatus(Guid Uidtenant);
        List<IAccount> SelectGruppi(Guid Uidtenant);
        int UpdateTeam(IAccount value);
        int InsertTeam(IAccount value);
        List<IAccount> SelectTeam(string keysearch, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountTeam(string keysearch, Guid Uidtenant);
        List<IAccount> SelectUsersSearch();
        List<IAccount> SelectUsersEmail(Guid Uidtenant);
        int InsertUserTeam(IAccount value);
        int InsertPageTeam(IAccount value);
        int DeleteUserTeam(IAccount value);
        int DeletePageTeam(IAccount value);
        List<IAccount> SelectUserTeam(int idteam);
        List<IAccount> SelectPageTeam(int idteam);
        List<IAccount> SelectGroupPageTeam(int idteam, Guid UserId);
        List<IAccount> SelectPageTeam(int idteam, Guid UserId, string codgruppopagina);
        List<IAccount> SelectTeamUser(Guid UserId, Guid Uidtenant);
        int InsertSegnalazione(IAccount value);
        List<IAccount> SelectSegnalazioni(Guid UserId, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountSegnalazioni(Guid UserId, Guid Uidtenant);
        List<IAccount> SelectFuelCardXUser(Guid UserId);
        int UpdateFuelCardUser(IAccount value);
        int InsertFuelCardUser(IAccount value);
        List<IAccount> SelectFuelCardUser(string codsocieta, string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountFuelCardUser(string codsocieta, string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant);
        List<IAccount> SelectCompagnie(Guid Uidtenant);
        List<IAccount> SelectCompagnieFuel();
        List<IAccount> SelectCompagnieRoot(Guid Uidtenant);
        List<IAccount> SelectAllTeam();

        List<IAccount> SelectTelePassXUser(Guid UserId);
        int UpdateTelePassUser(IAccount value);
        int InsertTelePassUser(IAccount value);
        List<IAccount> SelectTelePassUser(string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountTelePassUser(string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant);
        List<IAccount> SelectUsersPartner(Guid Uidtenant);
        List<IAccount> SelectCDCXSocieta(string codsocieta);
        List<IAccount> SelectCDCXSocieta2(string codsocieta, string term);
        int UpdateCredential(IAccount value);
        int UpdateUsersRobot(string email, Guid UserId);
        List<IAccount> SelectUsersDimissionariAttivi();
        int UpdateEmail(IAccount value);
        int UpdateUserNameMembership(string NewUsername, string LoweredNewUsername, string OldUsername);
        int UpdateCount(IAccount value);
        List<IAccount> SelectUsersXDate(DateTime datarange);
        List<IAccount> SelectTenant();
        List<IAccount> SelectGroupPageUsers(Guid Uidtenant);
        List<IAccount> SelectPageUsers(string codgruppopagina, Guid Uidtenant);
        int UpdateMenuUsers(int idpagina, int status, Guid Uidtenant);
        List<IAccount> SelectAllPageUsers(Guid Uidtenant);
    }
}
