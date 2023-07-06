
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AraneaUtilities.Authorization.CustomPrincipal
{
    public class CustomPrincipalManager
    {
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
            if (!NullSessionVariable())
                return (ICustomPrincipal)getSessionVar(SESSION_VARS.CP);
            else
                return null;
        }


        //** se IsAuthenticated = true: crea un Principal e lo attiva in un Thread
        // se toSession = true: salva il Principal in sessione
        static public bool Start(string uidUser, bool toSession)
        {


            // recupero dalla sessione i ruoli abbinati autorizzati
            string[] sessionRoles = (string[])getSessionVar(SESSION_VARS.ROLES);

            // creo il CustomPrincipal potenziale
            ICustomPrincipal cp = new CustomPrincipal(uidUser, sessionRoles);

            // valuto se il principal è gia stato è autenticato (e quindi ora è autorizzato)
            bool ok = cp.IsAuthenticated();

            // se è autenticato
            if (ok)
            {
                // attivo il Principal per questo flusso
                cp.SetActive();

                // se toSession = true: salvo il principal attivato anche in sessione
                if (toSession)
                    cp.SetInstanceToSession();
            }

            return ok;
        }


        //** riprende un Principal dalla sessione e lo attiva in un Thread

        static public bool Resume()
        {
            bool ok = true;

            //recupero il customPrincipal dalla sessione
            ICustomPrincipal cp = (ICustomPrincipal)GetInstanceFromSession();

            // se il cp esiste in sessione e se è autenticato (coincide con UIDsession)
            if (cp != null && cp.IsAuthenticated())//&& cp.Identity.IsAuthenticated)
            {
                // attivo il Principal per questo flusso
                cp.SetActive();
            }
            else
                ok = false;

            return ok;
        }


        private static bool NullSessionVariable()
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session[SESSION_VARS.CP] == null)
                return true;
            else
                return false;
        }

        internal static object getSessionVar(string sessionVar)
        {
            return HttpContext.Current.Session[sessionVar];
        }

        internal static void setSessionVar(string sessionVar, object value)
        {
            HttpContext.Current.Session[sessionVar] = value;
        }


        //** true se c'è un principal attivo
        public static bool IsActive()
        {
            return Thread.CurrentPrincipal.Identity.IsAuthenticated;
        }
    }
}

