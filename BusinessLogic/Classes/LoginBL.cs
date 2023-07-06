// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CLoginBL.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using BusinessObject;
using BusinessProvider;
using BaseProvider;

namespace BusinessLogic
{
    [Serializable]
    public class LoginBL : BaseBL, ILoginBL
    {
        private ILoginProvider ServizioLogin
        {
            get { return BaseProviderManager<LoginProvider>.Provider; }
        }

        public LoginBL() : base() { }


        public bool ExistUser(string emailuser)
        {
            ILoginProvider servizioLogin = ServizioLogin;
            bool retVal;
            retVal = servizioLogin.ExistUser(emailuser);
            return retVal;
        }
        public IAccount Detail(string emailuser)
        {
            ILoginProvider servizioLogin = ServizioLogin;
            IAccount data = servizioLogin.Detail(emailuser);
            return data;
        }
        public IAccount DetailId(Guid UserId)
        {
            ILoginProvider servizioLogin = ServizioLogin;
            IAccount data = servizioLogin.DetailId(UserId);
            return data;
        }
        public int UpdateDataInvioMail(IAccount value)
        {
            ILoginProvider servizioLogin = ServizioLogin;
            int retVal = 0;
            if (servizioLogin.UpdateDataInvioMail(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }
    }
}