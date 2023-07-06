using DFleetRest.AuthorizationAttribute.Common;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DFleetRest.AuthorizationAttributes
{
    /// <summary>
    /// Attributo di autorizzazione personalizzato per il framework REST.
    /// Estende l'attributo D4MRestAuthorizeAttribute.
    /// </summary>
    public class AuthorizeRestAttribute : D4MRestAuthorizeAttribute
    {
        private readonly AuthorizeJwtAttribute _jwtAttribute;
        private readonly AuthorizeEndpointsAttribute _endpointsAttribute;
        private readonly AuthorizeBlacklistAttribute _blacklistAttribute;

        /// <summary>
        /// Creates a new instance of the AuthorizeRestAttribute attribute.
        /// </summary>
        /// <param name="jwtAttribute">The AuthorizeJwtAttribute instance.</param>
        /// <param name="endpointsAttribute">The AuthorizeEndpointsAttribute instance.</param>
        /// <param name="blacklistAttribute">The AuthorizeBlacklistAttribute instance.</param>
        public AuthorizeRestAttribute(AuthorizeJwtAttribute jwtAttribute,
                                      AuthorizeEndpointsAttribute endpointsAttribute,
                                      AuthorizeBlacklistAttribute blacklistAttribute)
        {
            _jwtAttribute = jwtAttribute;
            _endpointsAttribute = endpointsAttribute;
            _blacklistAttribute = blacklistAttribute;
        }

        /// <summary>
        /// Crea una nuova istanza dell'attributo AuthorizeRestAttribute.
        /// </summary>
        public AuthorizeRestAttribute()
        {

            // Risolvi le istanze tramite DependencyResolver
            var resolver = GlobalConfiguration.Configuration.DependencyResolver;

            _jwtAttribute = resolver.GetService(typeof(AuthorizeJwtAttribute)) as AuthorizeJwtAttribute;
            _blacklistAttribute = resolver.GetService(typeof(AuthorizeBlacklistAttribute)) as AuthorizeBlacklistAttribute;
            _endpointsAttribute = resolver.GetService(typeof(AuthorizeEndpointsAttribute)) as AuthorizeEndpointsAttribute;
        }


        /// <inheritdoc/>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            bool result = _jwtAttribute.CheckAuthorization(actionContext) &&
                          _endpointsAttribute.CheckAuthorization(actionContext) &&
                          _blacklistAttribute.CheckAuthorization(actionContext);

            return result;
        }
    }
}
