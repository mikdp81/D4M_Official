using AraneaUtilities.Auth.WebApi.Jwt;
using BusinessObject;
using DFleetRest.AuthorizationAttribute.Common;
using DFleetRest.Utility;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DFleetRest.AuthorizationAttributes
{
    /// <summary>
    /// Attributo di autorizzazione personalizzato per JWT.
    /// Estende l'attributo D4MRestAuthorizeAttribute.
    /// </summary>
    public class AuthorizeJwtAttribute : D4MRestAuthorizeAttribute
    {
        private readonly ITokenManager<DFleetTokenPayload> _tokenManager;

        /// <summary>
        /// Creates a new instance of the AuthorizeJwtAttribute attribute.
        /// </summary>
        /// <param name="tokenManager">The token manager instance for handling JWT tokens.</param>
        public AuthorizeJwtAttribute(ITokenManager<DFleetTokenPayload> tokenManager)
        {
            _tokenManager = tokenManager;
        }


        /// <summary>
        /// Crea una nuova istanza dell'attributo AuthorizeJwtAttribute.
        /// </summary>
        public AuthorizeJwtAttribute()
        {
            // Risolvi l'istanza di ITokenManager tramite DependencyResolver
            var resolver = GlobalConfiguration.Configuration.DependencyResolver;
            _tokenManager = resolver.GetService(typeof(ITokenManager<DFleetTokenPayload>)) as ITokenManager<DFleetTokenPayload>;
        }

        /// <inheritdoc/>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {

            // Recupera il valore del token dall'header della richiesta
            string token = actionContext.Request.Headers.Authorization?.Parameter;
            //Adattamento per swagger
            if (token == null)
                token = actionContext.Request.Headers.Authorization?.Scheme;

            // Salva l'output del tokenManager nel contesto HTTP
            DFleetTokenPayload tokenValidationResult = _tokenManager.ValidateToken(token);

            // se l'esito della validazione è positiva
            if (tokenValidationResult != null && tokenValidationResult.IsAuthenticated)
            {
                // assegno il payload validato nella request
                actionContext.Request.Properties[DFleetGlobals.TokenPayloadKey] = tokenValidationResult;

                // assegno il token nel context
                if (HttpContext.Current.Items[DFleetGlobals.TokenKey] == null)
                    HttpContext.Current.Items[DFleetGlobals.TokenKey] = token;
                else
                    return false;

                return true;
            }
            else
                return false;
        }
    }
}
