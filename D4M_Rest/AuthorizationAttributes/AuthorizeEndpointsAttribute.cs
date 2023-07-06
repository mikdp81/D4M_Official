using AraneaUtilities.Auth.WebApi;
using AraneaUtilities.Auth.WebApi.Enpoints;
using BusinessObject;
using DFleetRest.AuthorizationAttribute.Common;
using DFleetRest.Utility;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DFleetRest.AuthorizationAttributes
{
    /// <summary>
    /// Attributo di autorizzazione personalizzato per gli endpoint.
    /// Estende l'attributo D4MRestAuthorizeAttribute.
    /// </summary>
    public class AuthorizeEndpointsAttribute : D4MRestAuthorizeAttribute
    {
        private IEndpointsManager _endpointsManager;

        /// <summary>
        /// Crea una nuova istanza dell'attributo AuthorizeEndpointAttribute.
        /// </summary>
        /// <param name="endpointsManager">IEndpointsManager da utilizzare</param>
        public AuthorizeEndpointsAttribute(EndpointsManager endpointsManager)
        {
            _endpointsManager = endpointsManager;
        }

        /// <summary>
        /// Crea una nuova istanza dell'attributo AuthorizeEndpointAttribute.
        /// </summary>
        public AuthorizeEndpointsAttribute()
        {
            // Risolvi l'istanza di IEndpointsManager tramite DependencyResolver
            var resolver = GlobalConfiguration.Configuration.DependencyResolver;
            _endpointsManager = resolver.GetService(typeof(IEndpointsManager)) as IEndpointsManager;
        }

        /// <inheritdoc/>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // Recupero l'endpoint dell'API chiamata
            string endpoint = actionContext.Request.RequestUri.LocalPath;

            // Recupero il payload risultato della validazione
            DFleetTokenPayload dFleetTokenPayload = (DFleetTokenPayload)actionContext.Request.Properties[DFleetGlobals.TokenPayloadKey];

            // cerco i ruoli assegnati all'utente
            string[] payloadRoles = dFleetTokenPayload.Roles;
            if (payloadRoles != null && payloadRoles.Length > 0)
                // Verifico l'autorizzazione utilizzando l'endpoint e i ruoli dell'utente
                return _endpointsManager.IsAuthorized(endpoint, payloadRoles);
            
            // se non ho ruoli per l'utente faccio un controllo senza ruoli
                return _endpointsManager.IsAuthorized(endpoint);
        }
    }
}
