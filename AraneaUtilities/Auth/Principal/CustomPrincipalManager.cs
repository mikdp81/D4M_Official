// ***********************************************************************
// Assembly         : AraneaUtilities
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CustomPrincipalManager.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AraneaUtilities.Auth
{
    public class CustomPrincipalManager
    {
        internal const string CP = "customPrincipal";
        internal const string UID = "UIDsession";
        internal const string ROLES = "CPRoles";

        //******************* static methods

        public static ICustomPrincipal CreateInstance(string user)
        {
            return new CustomPrincipal(user);
        }


        public static ICustomPrincipal CreateInstance(string user, string[] roles)
        {
            return new CustomPrincipal(user, roles);
        }


        public static ICustomPrincipal GetInstanceFromSession()
        {
                if (HttpContext.Current.Session == null)
                    return null;
                else
                    return (ICustomPrincipal)HttpContext.Current.Session[CustomPrincipalManager.CP];
        }


        public static bool SetInstanceToSession(ICustomPrincipal cp)
        {
            return cp.SetInstanceToSession();
        }

        internal static string[] GetRolesFromSession()
        {
            if (HttpContext.Current.Session == null)
                return null;
            else
                return (string[])HttpContext.Current.Session[ROLES];
        }

        //** se IsAuthenticated = true: crea un Principal e lo attiva in un Thread
        // se toSession = true: salva il Principal in sessione
        static public bool Start(string uidUser, bool toSession)
        {


            // recupero dalla sessione i ruoli abbinati autorizzati
            string[] sessionRoles = (string[])GetRolesFromSession();

            // creo il CustomPrincipal potenziale
            ICustomPrincipal cp = new CustomPrincipal(uidUser, sessionRoles);

            bool ok;
            // valuto se il principal è gia stato è autenticato e quindi lo attivo (e quindi ora è autorizzato)
            ok = cp.Activate();

            // se toSession = true: salvo il principal attivato anche in sessione
            if (ok && toSession)
                    cp.SetInstanceToSession();

            return ok;
        }


        //** riprende un Principal dalla sessione e lo attiva in un Thread

        static public bool Resume()
        {
            bool ok = false;

            //recupero il customPrincipal dalla sessione
            ICustomPrincipal cp = (ICustomPrincipal)GetInstanceFromSession();

            // se il cp esiste in sessione
            if (cp != null)
                //  e se è autenticato (coincide con UIDsession): attivo il Principal per questo flusso
                ok= cp.Activate();

            return ok;
        }

        //** disattiva i Principal e svuota la sessione

        static public void Kill()
        {
            Thread.CurrentPrincipal = null;
            HttpContext.Current.User = null;

            HttpContext.Current.Session[CP] = null;
        }

        //** true se c'è un principal attivo
        public static bool IsActive()
        {
            return Thread.CurrentPrincipal.Identity.IsAuthenticated;
        }
    }
}

