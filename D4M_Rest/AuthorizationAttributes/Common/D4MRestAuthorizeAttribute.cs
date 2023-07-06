using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
namespace DFleetRest.AuthorizationAttribute.Common
{
    /// <summary>
    /// Classe base per le classi di tipo AuthorizeAttribute di D4M.
    /// </summary>
    public abstract class D4MRestAuthorizeAttribute : AuthorizeAttribute, IDFleetAuthorizeAttribute
    {
        /// <summary>
        /// Crea una nuova istanza della classe <see cref="D4MRestAuthorizeAttribute"/>.
        /// </summary>
        public D4MRestAuthorizeAttribute()
        {
        }

        /// <inheritdoc/>
        public bool CheckAuthorization(HttpActionContext actionContext)
        {
            return IsAuthorized(actionContext);
        }
    }
}
