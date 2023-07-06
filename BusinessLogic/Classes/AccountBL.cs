// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CAccountBL.cs" company="">
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
    public class AccountBL : BaseBL, IAccountBL
    {

        public AccountBL()
        {
        }

        private IAccountProvider ServizioAccount
        {
            get { return ProviderFactory.ServizioAccount; }
        }

        public int Update(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.Update(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }



        public int Delete(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.Delete(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }


        public int Insert(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.Insert(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }


        //** autentica e in caso positivo rende e si abilita per l'autorizzazione
        public bool Authenticate(string emailuser, string password)
        {
            bool ok = false;

            if (Membership.ValidateUser(emailuser, password))
            {
                //crea sessionID: NON SO SE SERVE ANCORA
                string sessionID = "U" + "idUtente" + "-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
                HttpContext.Current.Session["UIDsession"] = sessionID;

                //autorizza gli accessi
                ok = AuthManager.SignIn(sessionID, emailuser, false);
            }
            return ok; // user;
        }



        //** autentica e in caso positivo rende e si abilita per l'autorizzazione
        public string[] AuthenticateAndGetRoles(string emailuser, string password)
        {
            string[] roles = null;
            if (Authenticate(emailuser, password))
                roles = Roles.GetRolesForUser(emailuser);

            return roles;
        }

        public bool Authenticate2(string emailuser, string password)
        {
            bool ok = false;

            if (Membership.ValidateUser(emailuser, password))
            {
                //autorizza gli accessi
                ok = AuthManager.SignIn2(emailuser, false);
            }
            return ok; // user;
        }

        public bool ExistUser(string emailuser)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            bool retVal;
            retVal = servizioAccount.ExistUser(emailuser);
            return retVal;
        }

        public bool ExistUserStatus(string emailuser)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            bool retVal;
            retVal = servizioAccount.ExistUserStatus(emailuser);
            return retVal;
        }

        public IAccount Detail(string emailuser)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.Detail(emailuser);
            return data;
        }


        public IAccount DetailId(Guid UserId)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.DetailId(UserId);
            return data;
        }
        public IAccount DetailGruppoUserId(Guid UserId)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.DetailGruppoUserId(UserId);
            return data;
        }

        public IAccount DetailId2(int iduser)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.DetailId2(iduser);
            return data;
        }

        public int SelectCountUsername(string userName, int idstatususer, int idgruppouser, Guid Uidtenant)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal;
            retVal = servizioAccount.SelectCountUsername(userName, idstatususer, idgruppouser, Uidtenant);
            return retVal;
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsername(string userName, int idstatususer, int idgruppouser, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            return OdsAccount.DefaultProvider.SelectUsername(userName, idstatususer, idgruppouser, Uidtenant, ordine, tipoordine, numrecord, pagina);
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsers(Guid Uidtenant)
        {
            return OdsAccount.DefaultProvider.SelectUsers(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersXSocieta(string codsocieta, Guid Uidtenant)
        {
            return OdsAccount.DefaultProvider.SelectUsersXSocieta(codsocieta, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersTerm(string keysearch, Guid Uidtenant)
        {
            return OdsAccount.DefaultProvider.SelectUsersTerm(keysearch, Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectStatus(Guid Uidtenant)
        {
            return OdsAccount.DefaultProvider.SelectStatus(Uidtenant);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectGruppi(Guid Uidtenant)
        {
            return OdsAccount.DefaultProvider.SelectGruppi(Uidtenant);
        }
        public IAccount UltimoIDUser()
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.UltimoIDUser();
            return data;
        }
        public int UpdateTeam(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.UpdateTeam(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int InsertTeam(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.InsertTeam(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int SelectCountTeam(string keysearch, Guid Uidtenant)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal;
            retVal = servizioAccount.SelectCountTeam(keysearch, Uidtenant);
            return retVal;
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectTeam(string keysearch, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsAccount.DefaultProvider.SelectTeam(keysearch, Uidtenant, numrecord, pagina);
        }
        public IAccount DetailTeamId(Guid Uid)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.DetailTeamId(Uid);
            return data;
        }
        public IAccount DetailTeamXId(int idteam)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.DetailTeamXId(idteam);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersSearch()
        {
            return OdsAccount.DefaultProvider.SelectUsersSearch();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersEmail(Guid Uidtenant)
        {
            return OdsAccount.DefaultProvider.SelectUsersEmail(Uidtenant);
        }
        public IAccount UltimoIDTeam()
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.UltimoIDTeam();
            return data;
        }
        public int InsertUserTeam(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.InsertUserTeam(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int InsertPageTeam(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.InsertPageTeam(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int DeleteUserTeam(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.DeleteUserTeam(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int DeletePageTeam(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.DeletePageTeam(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUserTeam(int idteam)
        {
            return OdsAccount.DefaultProvider.SelectUserTeam(idteam);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectPageTeam(int idteam)
        {
            return OdsAccount.DefaultProvider.SelectPageTeam(idteam);
        }
        public IAccount ReturnIdteam(Guid UserId, Guid Uidtenant)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.ReturnIdteam(UserId, Uidtenant);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectGroupPageTeam(int idteam, Guid UserId)
        {
            return OdsAccount.DefaultProvider.SelectGroupPageTeam(idteam, UserId);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectPageTeam(int idteam, Guid UserId, string codgruppopagina)
        {
            return OdsAccount.DefaultProvider.SelectPageTeam(idteam, UserId, codgruppopagina);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectTeamUser(Guid UserId, Guid Uidtenant)
        {
            return OdsAccount.DefaultProvider.SelectTeamUser(UserId, Uidtenant);
        }
        public bool ExistPageUser(Guid UserId, int idteam, int idpagina)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            bool retVal;
            retVal = servizioAccount.ExistPageUser(UserId, idteam, idpagina);
            return retVal;
        }
        public int InsertSegnalazione(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.InsertSegnalazione(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountSegnalazioni(Guid UserId, Guid Uidtenant)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal;
            retVal = servizioAccount.SelectCountSegnalazioni(UserId, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectSegnalazioni(Guid UserId, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsAccount.DefaultProvider.SelectSegnalazioni(UserId, Uidtenant, numrecord, pagina);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectFuelCardXUser(Guid UserId)
        {
            return OdsAccount.DefaultProvider.SelectFuelCardXUser(UserId);
        }
        public int UpdateFuelCardUser(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.UpdateFuelCardUser(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int InsertFuelCardUser(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.InsertFuelCardUser(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountFuelCardUser(string codsocieta, string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal;
            retVal = servizioAccount.SelectCountFuelCardUser(codsocieta, keysearch, UserId, scadenzada, scadenzaa, idcompagnia, status, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectFuelCardUser(string codsocieta, string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsAccount.DefaultProvider.SelectFuelCardUser(codsocieta, keysearch, UserId, scadenzada, scadenzaa, idcompagnia, status, Uidtenant, numrecord, pagina);
        }
        public IAccount DetailFuelCardUserId(Guid Uid)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.DetailFuelCardUserId(Uid);
            return data;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectCompagnie(Guid Uidtenant)
        {
            return OdsAccount.DefaultProvider.SelectCompagnie(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectCompagnieFuel()
        {
            return OdsAccount.DefaultProvider.SelectCompagnieFuel();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectCompagnieRoot(Guid Uidtenant)
        {
            return OdsAccount.DefaultProvider.SelectCompagnieRoot(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectAllTeam()
        {
            return OdsAccount.DefaultProvider.SelectAllTeam();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectTelePassXUser(Guid UserId)
        {
            return OdsAccount.DefaultProvider.SelectTelePassXUser(UserId);
        }
        public int UpdateTelePassUser(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.UpdateTelePassUser(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int InsertTelePassUser(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.InsertTelePassUser(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountTelePassUser(string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal;
            retVal = servizioAccount.SelectCountTelePassUser(keysearch, UserId, scadenzada, scadenzaa, idcompagnia, status, Uidtenant);
            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectTelePassUser(string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant, int numrecord, int pagina)
        {
            return OdsAccount.DefaultProvider.SelectTelePassUser(keysearch, UserId, scadenzada, scadenzaa, idcompagnia, status, Uidtenant, numrecord, pagina);
        }
        public IAccount DetailTelePassUserId(Guid Uid)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.DetailTelePassUserId(Uid);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersPartner(Guid Uidtenant)
        {
            return OdsAccount.DefaultProvider.SelectUsersPartner(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectCDCXSocieta(string codsocieta)
        {
            return OdsAccount.DefaultProvider.SelectCDCXSocieta(codsocieta);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectCDCXSocieta2(string codsocieta, string term)
        {
            return OdsAccount.DefaultProvider.SelectCDCXSocieta2(codsocieta, term);
        }
        public int UpdateCredential(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.UpdateCredential(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateUsersRobot(string email, Guid UserId)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.UpdateUsersRobot(email, UserId) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public bool ExistLogin(Guid iduser)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            bool retVal;
            retVal = servizioAccount.ExistLogin(iduser);
            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersDimissionariAttivi()
        {
            return OdsAccount.DefaultProvider.SelectUsersDimissionariAttivi();
        }
        public int UpdateEmail(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.UpdateEmail(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateUserNameMembership(string NewUsername, string LoweredNewUsername, string OldUsername)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.UpdateUserNameMembership(NewUsername, LoweredNewUsername, OldUsername) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateCount(IAccount value)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal;
            retVal = servizioAccount.UpdateCount(value);
            return retVal;
        }
        public IAccount ExistAnagraficaMatricola(string matricola)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.ExistAnagraficaMatricola(matricola);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectUsersXDate(DateTime datarange)
        {
            return OdsAccount.DefaultProvider.SelectUsersXDate(datarange);
        }
        public IAccount ReturnPlafond(Guid UserId)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.ReturnPlafond(UserId);
            return data;
        }
        public IAccount ReturnPropertyTenant(Guid Uidtenant)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            IAccount data = servizioAccount.ReturnPropertyTenant(Uidtenant);
            return data;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectTenant()
        {
            return OdsAccount.DefaultProvider.SelectTenant();
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectGroupPageUsers(Guid Uidtenant)
        {
            return OdsAccount.DefaultProvider.SelectGroupPageUsers(Uidtenant);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectPageUsers(string codgruppopagina, Guid Uidtenant)
        {
            return OdsAccount.DefaultProvider.SelectPageUsers(codgruppopagina, Uidtenant);
        }
        public int UpdateMenuUsers(int idpagina, int status, Guid Uidtenant)
        {
            IAccountProvider servizioAccount = ServizioAccount;
            int retVal = 0;
            if (servizioAccount.UpdateMenuUsers(idpagina, status, Uidtenant) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IAccount> SelectAllPageUsers(Guid Uidtenant)
        {
            return OdsAccount.DefaultProvider.SelectAllPageUsers(Uidtenant);
        }
    }
}
