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
using BusinessObject;
using BusinessProvider;
using System;
using System.Collections.Generic;
using System.Web.Security;

namespace BusinessLogic
{
    [Serializable]
    public class ApiAccountBL : BaseBL, IApiAccountBL
    {
        public ApiAccountBL()
        {
        }

        private IApiAccountProvider ServizioApiAccount
        {
            get { return ProviderFactory.ServizioApiAccount; }
        }


        //** autentica e in caso positivo restituisce i ruoli assegnati all'utente
        public string[] Authenticate(string emailuser, string password)
        {
            string[] roles = null;
            if (Membership.ValidateUser(emailuser, password))
                roles = Roles.GetRolesForUser(emailuser);

            return roles;
        }

        public List<IApiAccount> SelectUser(Guid Uidtenant, string codsocieta, string keysearch, int idstatususer, int idgruppouser, int pagina)
        {
            IApiAccountProvider servizioAPI = ServizioApiAccount;
            List<IApiAccount> apiUsers = servizioAPI.SelectUser(Uidtenant, codsocieta, keysearch, idstatususer, idgruppouser, pagina);
            return apiUsers;
        }

        public IApiAccount UserDetail(string emailuser)
        {
            IApiAccountProvider servizioAPI = ServizioApiAccount;
            IApiAccount data = servizioAPI.UserDetail(emailuser);
            return data;
        }

        public int UpdateUser(IApiAccount value)
        {
            IApiAccountProvider servizioAPI = ServizioApiAccount;
            int retVal = 0;
            if (servizioAPI.UpdateUser(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }


        public int InsertUser(IApiAccount value)
        {
            IApiAccountProvider servizioAPI = ServizioApiAccount;
            int retVal = 0;
            if (servizioAPI.InsertUser(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteUser(IApiAccount value)
        {
            IApiAccountProvider servizioAPI = ServizioApiAccount;
            int retVal = 0;
            if (servizioAPI.DeleteUser(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }


        public List<IApiAccount> SelectTeam(Guid Uidtenant, string keysearch, int pagina)
        {
            IApiAccountProvider servizioAPI = ServizioApiAccount;
            List<IApiAccount> apiUsers = servizioAPI.SelectTeam(Uidtenant,  keysearch, pagina);
            return apiUsers;
        }

        public IApiAccount TeamDetail(int idteam, Guid Uidtenant)
        {
            IApiAccountProvider servizioAPI = ServizioApiAccount;
            IApiAccount data = servizioAPI.TeamDetail(idteam, Uidtenant);
            return data;
        }

        public int UpdateTeam(IApiAccount value)
        {
            IApiAccountProvider servizioAPI = ServizioApiAccount;
            int retVal = 0;
            if (servizioAPI.UpdateTeam(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int InsertTeam(IApiAccount value)
        {
            IApiAccountProvider servizioAPI = ServizioApiAccount;
            int retVal = 0;
            if (servizioAPI.InsertTeam(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int DeleteTeam(IApiAccount value)
        {
            IApiAccountProvider servizioAPI = ServizioApiAccount;
            int retVal = 0;
            if (servizioAPI.DeleteTeam(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
    }
}
