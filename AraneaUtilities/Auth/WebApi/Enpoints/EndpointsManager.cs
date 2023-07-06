using AraneaUtilities.Auth.Roles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AraneaUtilities.Auth.WebApi.Enpoints
{
    /// <summary>
    /// Classe che rappresenta il gestore degli endpoint di autorizzazione delle API.
    /// </summary>
    public class EndpointsManager : IEndpointsManager
    {
        private static EndpointsManager _endpointsManager = null;

        private IUserRoles _userRoles;
        private IEndpoints _endpoints;

        /// <summary>
        /// Ottiene l'istanza condivisa del EndpointsManager.
        /// </summary>
        /// <returns>Un'istanza del EndpointsManager</returns>
        public static EndpointsManager GetInstance(IEndpoints endpoints, IUserRoles userRoles)
        {
            if (_endpointsManager == null)
                _endpointsManager = new EndpointsManager(endpoints, userRoles);
            else
            {
                _endpointsManager._endpoints = endpoints;
                _endpointsManager._userRoles = userRoles;
            }

            return _endpointsManager;
        }

        /// <summary>
        /// Crea una nuova istanza di EndpointsManager e inizializza il gestore degli endpoint di autorizzazione delle API.
        /// </summary>
        /// <param name="endpoints">L'istanza di Endpoints per la gestione dei ruoli degli endpoint.</param>
        /// <param name="userRoles">L'istanza di UserRoles per la gestione dei ruoli validi.</param>
        private EndpointsManager(IEndpoints endpoints, IUserRoles userRoles)
        {
            // Inizializza gli attributi
            _endpoints = endpoints;
            _userRoles = userRoles;

            // Verifica la coerenza dei valori nel dizionario con quelli definiti nella classe TokenValidationResult
            VerifyRolesConsistency();
        }

        /// <inheritdoc />
        public bool IsAuthorized(string endpoint, string[] userRoles = null)
        {
            List<string> endpointRoles = new List<string>();
            List<string> userRolesList = new List<string>();

            // Se tra i ruoli c'è "Admin", autorizza a prescindere
            if (userRoles != null && userRoles.All(role => _userRoles.IsAdmin(role)))
                return true;

            // Recupera i ruoli abilitati per l'endpoint
            endpointRoles = _endpoints.GetRoles(endpoint);

            // Inizializza i ruoli dell'utente
            if (userRoles != null && userRoles.Length > 0)
                userRolesList = userRoles.ToList();
            // Altrimenti assegna solo il suo ruolo di default
            else
                userRolesList.Add(_userRoles.Default);

            // Se c'è un'intersezione tra endpointRoles e userRolesList, restituisce true, altrimenti false
            return userRolesList.Intersect(endpointRoles).Any();
        }

        /// <summary>
        /// Verifica che tutti i ruoli citati dagli endpoints appartengano al dominio UserRoles.
        /// </summary>
        private void VerifyRolesConsistency()
        {
            // Prendi tutti i ruoli distinti presenti in EndpointsMap
            List<string> allEndpointsRoles = _endpoints.GetAllRoles();

            // Verifica che tutti i ruoli di EndpointsMap abbiano un valore valido
            foreach (string endpointRole in allEndpointsRoles)
            {
                if (!_userRoles.IsValid(endpointRole))
                {
                    // Gestisci l'errore di coerenza qui, ad esempio generando un'eccezione o eseguendo un log
                    throw new Exception($"Il ruolo '{endpointRole}' nell'EndpointsMap non è valido.");
                }
            }
        }
    }
}
