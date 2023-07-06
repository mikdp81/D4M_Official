using AraneaUtilities.Auth.WebApi;
using AraneaUtilities.Auth.WebApi.Blacklist;
using BusinessObject;
using DFleetRest.AuthorizationAttribute.Common;
using DFleetRest.Utility;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DFleetRest.AuthorizationAttributes
{
    /// <summary>
    /// Attributo di autorizzazione personalizzato per verificare se l'utente è in blacklist.
    /// Estende l'attributo D4MRestAuthorizeAttribute.
    /// </summary>
    public class AuthorizeBlacklistAttribute : D4MRestAuthorizeAttribute
    {
        private readonly IBlacklistManager _blacklistManager;

        /// <summary>
        /// Creates a new instance of the AuthorizeBlacklistAttribute attribute.
        /// </summary>
        public AuthorizeBlacklistAttribute(IBlacklistManager blacklistManager)
        {
            _blacklistManager = blacklistManager;  
        }

        /// <summary>
        /// Creates a new instance of the AuthorizeBlacklistAttribute attribute.
        /// </summary>
        public AuthorizeBlacklistAttribute()
        {
            // Resolves the instance of IBlacklistManager using the DependencyResolver
            var resolver = GlobalConfiguration.Configuration.DependencyResolver;
            _blacklistManager = resolver.GetService(typeof(IBlacklistManager)) as IBlacklistManager;
        }


        /// <summary>
        /// Verifica se l'utente è abilitato.
        /// </summary>
        /// <param name="actionContext">Il contesto dell'azione HTTP.</param>
        /// <returns>True se l'utente è abilitato, altrimenti false.</returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // Se non trovo "TOKEN_USERNAME_KEY", l'utente non è autenticato => non autorizzato
            if (!actionContext.Request.Properties.ContainsKey(DFleetGlobals.TokenPayloadKey))
                return false;

            // Valuto se l'utente autenticato è ancora abilitato
            DFleetTokenPayload dFleetTokenPayload = (DFleetTokenPayload)actionContext.Request.Properties[DFleetGlobals.TokenPayloadKey];
            return _blacklistManager.IsEnabled(dFleetTokenPayload.Username);
        }
    }
}
