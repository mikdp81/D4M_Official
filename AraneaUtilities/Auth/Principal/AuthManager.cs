// ***********************************************************************
// Assembly         : AraneaUtilities
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="AuthManager.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace AraneaUtilities.Auth
{
    public class AuthManager
    {

        private const string UID = "UIDsession";

        //** true se c'è un principal attivo
        internal static bool IsActive()
        {
            return Thread.CurrentPrincipal.Identity.IsAuthenticated;
         }


        //** se IsAuthenticated = true: 
        //          1. autentica l'utente (FormAuthentication) ==> autorizza pagine
        //          2. crea un Principal e lo attiva in un Thread ==> autorizza back-end
        static public bool SignIn(string uidUser, string user, bool persistentCookie)
        {
            bool ok = false;
            // se la uid dinamica coincide posso andare avanti
            if(IsValid(uidUser))
            {
                ok = true;
                // autentico l'utente ==> autorizzo le pagine
                FormsAuthentication.SetAuthCookie(user, persistentCookie);
                
                //creo un Principal ==> autorizzo il back-end
                IPrincipal principal = new GenericPrincipal(new GenericIdentity(user), null);
                // attivo il principal
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;

                //TEST
                //throw new SecurityException();
            }
            return ok;
        }

        //** se IsAuthenticated = true: 
        //          1. autentica l'utente (FormAuthentication) ==> autorizza pagine
        //          2. crea un Principal e lo attiva in un Thread ==> autorizza back-end
        static public bool SignIn2( string user, bool persistentCookie)
        {
            // autentico l'utente ==> autorizzo le pagine
            //FormsAuthentication.SetAuthCookie(user, persistentCookie);

            //creo un Principal ==> autorizzo il back-end
            IPrincipal principal = new GenericPrincipal(new GenericIdentity(user), null);
            // attivo il principal
            Thread.CurrentPrincipal = principal;
            return true;
        }

        //** 1. logout utente
        //   2. azzero autorizzazioni
        public static void SignOut()
        {
            // logout
            FormsAuthentication.SignOut();

            // azzero autorizzazioni
            Thread.CurrentPrincipal = null;
            HttpContext.Current.User = null;
        }

        private static bool IsValid(string uidUser)
        {
            bool ok = true;

            return ok;
        }

    }
}

