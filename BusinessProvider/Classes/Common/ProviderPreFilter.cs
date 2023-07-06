using AraneaUtilities.Auth.Roles;
using AraneaUtilities.Auth.WebApi;
using AraneaUtilities.Auth.WebApi.Blacklist;
using AraneaUtilities.Auth.WebApi.Enpoints;
using AraneaUtilities.Auth.WebApi.Jwt;
using AraneaUtilities.InterceptingFilters;
using BusinessObject;
using BusinessObject.Classes;
using System;
using System.Configuration;
using System.Security.Principal;
using System.Web;

namespace BusinessProvider
{
    internal class ProviderPreFilter : IProxyFilter
    {
        private DFleetDataProvider _targetProvider;


        /// <summary>
        /// Crea una nuova istanza di IProxyFilter.
        /// </summary>
        /// <param name="targetProvider">Oggetto di tipo DFleetDataProvider su cui agisce il filtro.</param>
        /// <returns>Un'istanza di IProxyFilter.</returns>
        public ProviderPreFilter(DFleetDataProvider targetProvider)
        {
            // assegno un riferimento all'oggetto decorato dal filtro
            _targetProvider = targetProvider;

        }


        /// <summary>
        /// 1. effettua i controlli di autorizzazione
        /// 2. decora il provider corrente con l'utente corrente
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool Execute(object parameters = null)
        {
            // controllo le autorizzazioni del Principal
            if (CheckByPrincipal())
                return true;


            // controllo le autorizzazioni del JWT + Blacklist
            if (CheckByRest())
                return true;


            // in tutti gli altri casi 
            return false ;
        }

        // se il check è ok: return "utente autorizzato"
        private bool CheckByRest()
        {
            DFleetTokenPayload tokenValidationResult;

            // supero la validazione jwt e blacklist
            try
            {
                // Recupera il valore della chiave "TokenSettings" dal file di configurazione
                ITokenManager<DFleetTokenPayload> tokenManager = TokenManager<DFleetTokenPayload>.GetInstance(DFleetGlobals.JwtSettings);

                IBlacklistManager blacklistManager = BlacklistManager.GetInstance();

                // parte jwt
                string token = HttpContext.Current.Items[DFleetGlobals.TokenKey].ToString();
                tokenValidationResult = tokenManager.ValidateToken(token);

                // SE il token soddisfa tutti requisiti di autorizzazione JWT e di blacklist:
                if (tokenValidationResult.IsAuthenticated && blacklistManager.IsEnabled(tokenValidationResult.Username))
                {
                    // 1. decoro il provider corrente con la username corrente
                        _targetProvider.CurrentUsername = tokenValidationResult.Username;
                    // 2. do risposta positiva
                    return true;
                }
            }
            catch (Exception)
            {
                // L'utente corrente non soddisfa i requisiti di autorizzazione
                return false;
            }

            // ogni altro caso
            return false;

        }


        // se il check è ok: return "utente autorizzato"
        private bool CheckByPrincipal()
        {
            // Ottieni l'oggetto IPrincipal dell'utente corrente
            IPrincipal currentPrincipal = HttpContext.Current.User;

            // Verifica se l'utente corrente è autenticato
            if (currentPrincipal.Identity.IsAuthenticated)
            {
                // TRUE: se trovo almeno una corrispondenza che non sia Anonymous
                foreach (string role in DFleetGlobals.UserRoles.GetValues())
                    if (!DFleetGlobals.UserRoles.IsAnonymous(role) &&
                            currentPrincipal.IsInRole(role))
                    {
                        // 1. decoro il provider corrente con la username corrente
                        _targetProvider.CurrentUsername = currentPrincipal.Identity.Name;
                        // 2. do risposta positiva
                        return true;
                    }
            }

            // Nessuna delle stringhe soddisfa i requisiti di autorizzazione
            return false;
        }

    }
}
