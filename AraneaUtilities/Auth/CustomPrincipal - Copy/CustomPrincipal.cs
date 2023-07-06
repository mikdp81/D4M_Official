using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AraneaUtilities.Authorization.CustomPrincipal
{
    internal class CustomPrincipal : ICustomPrincipal
    {
        private IPrincipal principal;


        public IPrincipal Principal {
            get { return principal; }   // get method
            private set { principal = value; }  // set method
        }

        public IIdentity Identity {
            get { return Principal.Identity; }   // get method
        }


        //** crea Principal con i ruoli
        internal CustomPrincipal(string user, string[] roles)
        {
            if (user != null)
            {
                Principal = new GenericPrincipal(new GenericIdentity(user), roles);
            }
        }


        //** crea un Custom Principal senza i ruoli
        internal CustomPrincipal(string user)
        {
            new CustomPrincipal(user, null);
        }


        //** cp è autenticato se il nome di Identity trova riscontro nella variabile di sessione UIDsession
        public bool IsAuthenticated()
        {
            bool ok = false;
            string uidSession = (string)CustomPrincipalManager.getSessionVar(SESSION_VARS.UID);
            if (Identity.Name != null && Identity.Name == uidSession)
                ok = true;

            return ok;
        }

        //** attiva il Principal in un Thread
        // attivabile solo se IsAuthenticaded() = true
        // se toSession = true: salva il Principal in sessione
        public bool Start(bool toSession)
        {
            bool ok = this.IsAuthenticated();
            if (ok)
            {
                this.SetActive();
                if (toSession)
                    this.SetInstanceToSession();
            }

            return ok;
        }


        //** se il principal è autenticato salva il Principal in sessione 
        public bool SetInstanceToSession()
        {
            bool ok = this.IsAuthenticated();
            if (ok)
                CustomPrincipalManager.setSessionVar(SESSION_VARS.CP, this);
        
            return ok;
        }



        //** true se il il principal appartiene al ruolo indicato in input

        public bool IsInRole(string role)
        {
            bool ok = false;
            if (Principal != null)
                ok = Principal.IsInRole(role);
            return ok;
        }

        public void SetActive()
        {
            Thread.CurrentPrincipal = principal;
            HttpContext.Current.User = principal;
        }
    }
}