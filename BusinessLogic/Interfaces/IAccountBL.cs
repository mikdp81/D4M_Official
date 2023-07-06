// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IAccountBL.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using BusinessObject;

namespace BusinessLogic
{
    public interface IAccountBL
    {
        int Update(IAccount value);
        int Delete(IAccount value);
        int Insert(IAccount value);
        bool Authenticate(string emailuser, string password);
        string[] AuthenticateAndGetRoles(string emailuser, string password);
        bool Authenticate2(string emailuser, string password);
        bool ExistUser(string emailuser);
        bool ExistUserStatus(string emailuser);
        IAccount Detail(string emailuser);
        IAccount DetailGruppoUserId(Guid UserId);
        IAccount DetailId(Guid UserId);
        IAccount DetailId2(int iduser);
        int SelectCountUsername(string userName, int idstatususer, int idgruppouser, Guid Uidtenant);
        List<IAccount> SelectUsername(string userName, int idstatususer, int idgruppouser, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina);
        List<IAccount> SelectUsers(Guid Uidtenant);
        List<IAccount> SelectUsersXSocieta(string codsocieta, Guid Uidtenant);
        List<IAccount> SelectUsersTerm(string keysearch, Guid Uidtenant);
        List<IAccount> SelectStatus(Guid Uidtenant);
        IAccount UltimoIDUser();
        List<IAccount> SelectGruppi(Guid Uidtenant);
        int UpdateTeam(IAccount value);
        int InsertTeam(IAccount value);
        List<IAccount> SelectTeam(string keysearch, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountTeam(string keysearch, Guid Uidtenant);
        IAccount DetailTeamId(Guid Uid);
        IAccount DetailTeamXId(int idteam);
        List<IAccount> SelectUsersSearch();
        List<IAccount> SelectUsersEmail(Guid Uidtenant);
        IAccount UltimoIDTeam();
        int InsertUserTeam(IAccount value);
        int InsertPageTeam(IAccount value);
        int DeleteUserTeam(IAccount value);
        int DeletePageTeam(IAccount value);
        List<IAccount> SelectUserTeam(int idteam);
        List<IAccount> SelectPageTeam(int idteam);
        IAccount ReturnIdteam(Guid UserId, Guid Uidtenant);
        List<IAccount> SelectGroupPageTeam(int idteam, Guid UserId);
        List<IAccount> SelectPageTeam(int idteam, Guid UserId, string codgruppopagina);
        List<IAccount> SelectTeamUser(Guid UserId, Guid Uidtenant);
        bool ExistPageUser(Guid UserId, int idteam, int idpagina);
        int InsertSegnalazione(IAccount value);
        List<IAccount> SelectSegnalazioni(Guid UserId, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountSegnalazioni(Guid UserId, Guid Uidtenant);
        List<IAccount> SelectFuelCardXUser(Guid UserId);
        int UpdateFuelCardUser(IAccount value);
        int InsertFuelCardUser(IAccount value);
        List<IAccount> SelectFuelCardUser(string codsocieta, string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountFuelCardUser(string codsocieta, string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant);
        IAccount DetailFuelCardUserId(Guid Uid);
        List<IAccount> SelectCompagnie(Guid Uidtenant);
        List<IAccount> SelectCompagnieFuel();
        List<IAccount> SelectCompagnieRoot(Guid Uidtenant);
        List<IAccount> SelectAllTeam();

        List<IAccount> SelectTelePassXUser(Guid UserId);
        int UpdateTelePassUser(IAccount value);
        int InsertTelePassUser(IAccount value);
        List<IAccount> SelectTelePassUser(string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant, int numrecord, int pagina);
        int SelectCountTelePassUser(string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant);
        IAccount DetailTelePassUserId(Guid Uid);
        List<IAccount> SelectUsersPartner(Guid Uidtenant);
        List<IAccount> SelectCDCXSocieta(string codsocieta);
        List<IAccount> SelectCDCXSocieta2(string codsocieta, string term);
        int UpdateCredential(IAccount value);
        int UpdateUsersRobot(string email, Guid UserId);
        bool ExistLogin(Guid iduser);
        List<IAccount> SelectUsersDimissionariAttivi();
        int UpdateEmail(IAccount value);
        int UpdateUserNameMembership(string NewUsername, string LoweredNewUsername, string OldUsername);
        int UpdateCount(IAccount value);
        IAccount ExistAnagraficaMatricola(string matricola);
        List<IAccount> SelectUsersXDate(DateTime datarange);
        IAccount ReturnPlafond(Guid UserId);
        IAccount ReturnPropertyTenant(Guid Uidtenant);
        List<IAccount> SelectTenant();
        List<IAccount> SelectGroupPageUsers(Guid Uidtenant);
        List<IAccount> SelectPageUsers(string codgruppopagina, Guid Uidtenant);
        int UpdateMenuUsers(int idpagina, int status, Guid Uidtenant);
        List<IAccount> SelectAllPageUsers(Guid Uidtenant);
    }
}