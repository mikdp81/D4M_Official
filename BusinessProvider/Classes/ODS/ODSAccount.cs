// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CODSAccount.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject;
using BusinessProvider;
using DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BusinessProvider
{
    [DataObject(true)]

    public class OdsAccount : ODSProvider<AccountProvider>, IOdsAccount
    {

        private readonly AccountProvider accountProvider = (AccountProvider)new ProviderFactory().ServizioAccount;

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int Update(IAccount value)
        {
            return accountProvider.Update(value);
        }


        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateSession(IAccount value)
        {
            return accountProvider.Update(value);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int Delete(IAccount value)
        {
            return accountProvider.Delete(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int Insert(IAccount value)
        {
            return accountProvider.Insert(value);
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsers(Guid Uidtenant)
        {
            return accountProvider.SelectUsers(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersXSocieta(string codsocieta, Guid Uidtenant)
        {
            return accountProvider.SelectUsersXSocieta(codsocieta, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersTerm(string keysearch, Guid Uidtenant)
        {
            return accountProvider.SelectUsersTerm(keysearch, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsername(string userName, int idstatususer, int idgruppouser, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return accountProvider.SelectUsername(userName, idstatususer, idgruppouser, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountUsername(string userName, int idstatususer, int idgruppouser, Guid Uidtenant)
        {
            return accountProvider.SelectCountUsername(userName, idstatususer, idgruppouser, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectStatus(Guid Uidtenant)
        {
            return accountProvider.SelectStatus(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectGruppi(Guid Uidtenant)
        {
            return accountProvider.SelectGruppi(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateTeam(IAccount value)
        {
            return accountProvider.UpdateTeam(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertTeam(IAccount value)
        {
            return accountProvider.InsertTeam(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectTeam(string keysearch, Guid Uidtenant, int numrecord, int pagina)
        {
            return accountProvider.SelectTeam(keysearch, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountTeam(string keysearch, Guid Uidtenant)
        {
            return accountProvider.SelectCountTeam(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersSearch()
        {
            return accountProvider.SelectUsersSearch();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersEmail(Guid Uidtenant)
        {
            return accountProvider.SelectUsersEmail(Uidtenant);
        }


        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertUserTeam(IAccount value)
        {
            return accountProvider.InsertUserTeam(value);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertPageTeam(IAccount value)
        {
            return accountProvider.InsertPageTeam(value);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeleteUserTeam(IAccount value)
        {
            return accountProvider.DeleteUserTeam(value);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public int DeletePageTeam(IAccount value)
        {
            return accountProvider.DeletePageTeam(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUserTeam(int idteam)
        {
            return accountProvider.SelectUserTeam(idteam);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectPageTeam(int idteam)
        {
            return accountProvider.SelectPageTeam(idteam);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectGroupPageTeam(int idteam, Guid UserId)
        {
            return accountProvider.SelectGroupPageTeam(idteam, UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectPageTeam(int idteam, Guid UserId, string codgruppopagina)
        {
            return accountProvider.SelectPageTeam(idteam, UserId, codgruppopagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectTeamUser(Guid UserId, Guid Uidtenant)
        {
            return accountProvider.SelectTeamUser(UserId, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertSegnalazione(IAccount value)
        {
            return accountProvider.InsertSegnalazione(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectSegnalazioni(Guid UserId, Guid Uidtenant, int numrecord, int pagina)
        {
            return accountProvider.SelectSegnalazioni(UserId, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountSegnalazioni(Guid UserId, Guid Uidtenant)
        {
            return accountProvider.SelectCountSegnalazioni(UserId, Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectFuelCardXUser(Guid UserId)
        {
            return accountProvider.SelectFuelCardXUser(UserId);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateFuelCardUser(IAccount value)
        {
            return accountProvider.UpdateFuelCardUser(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertFuelCardUser(IAccount value)
        {
            return accountProvider.InsertFuelCardUser(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectFuelCardUser(string codsocieta, string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant, int numrecord, int pagina)
        {
            return accountProvider.SelectFuelCardUser(codsocieta, keysearch, UserId, scadenzada, scadenzaa, idcompagnia, status, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountFuelCardUser(string codsocieta, string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant)
        {
            return accountProvider.SelectCountFuelCardUser(codsocieta, keysearch, UserId, scadenzada, scadenzaa, idcompagnia, status, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectCompagnie(Guid Uidtenant)
        {
            return accountProvider.SelectCompagnie(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectCompagnieFuel()
        {
            return accountProvider.SelectCompagnieFuel();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectCompagnieRoot(Guid Uidtenant)
        {
            return accountProvider.SelectCompagnieRoot(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectAllTeam()
        {
            return accountProvider.SelectAllTeam();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectTelePassXUser(Guid UserId)
        {
            return accountProvider.SelectTelePassXUser(UserId);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateTelePassUser(IAccount value)
        {
            return accountProvider.UpdateTelePassUser(value);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertTelePassUser(IAccount value)
        {
            return accountProvider.InsertTelePassUser(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectTelePassUser(string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant, int numrecord, int pagina)
        {
            return accountProvider.SelectTelePassUser(keysearch, UserId, scadenzada, scadenzaa, idcompagnia, status, Uidtenant, numrecord, pagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountTelePassUser(string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant)
        {
            return accountProvider.SelectCountTelePassUser(keysearch, UserId, scadenzada, scadenzaa, idcompagnia, status, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersPartner(Guid Uidtenant)
        {
            return accountProvider.SelectUsersPartner(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectCDCXSocieta(string codsocieta)
        {
            return accountProvider.SelectCDCXSocieta(codsocieta);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectCDCXSocieta2(string codsocieta, string term)
        {
            return accountProvider.SelectCDCXSocieta2(codsocieta, term);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateCredential(IAccount value)
        {
            return accountProvider.UpdateCredential(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateUsersRobot(string email, Guid UserId)
        {
            return accountProvider.UpdateUsersRobot(email, UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersDimissionariAttivi()
        {
            return accountProvider.SelectUsersDimissionariAttivi();
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateEmail(IAccount value)
        {
            return accountProvider.UpdateEmail(value);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateUserNameMembership(string NewUsername, string LoweredNewUsername, string OldUsername)
        {
            return accountProvider.UpdateUserNameMembership(NewUsername, LoweredNewUsername, OldUsername);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int UpdateCount(IAccount value)
        {
            return accountProvider.UpdateCount(value);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersXDate(DateTime datarange)
        {
            return accountProvider.SelectUsersXDate(datarange);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectTenant()
        {
            return accountProvider.SelectTenant();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectGroupPageUsers(Guid Uidtenant)
        {
            return accountProvider.SelectGroupPageUsers(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectPageUsers(string codgruppopagina, Guid Uidtenant)
        {
            return accountProvider.SelectPageUsers(codgruppopagina, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int UpdateMenuUsers(int idpagina, int status, Guid Uidtenant)
        {
            return accountProvider.UpdateMenuUsers(idpagina, status, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectAllPageUsers(Guid Uidtenant)
        {
            return accountProvider.SelectAllPageUsers(Uidtenant);
        }
    }
}
