using System.Web.Http.Controllers;

namespace DFleetRest.AuthorizationAttribute.Common
{
    /// <summary>
    /// Interfaccia per l'attributo di autorizzazione DFleet.
    /// </summary>
    internal interface IDFleetAuthorizeAttribute
    {
        /// <summary>
        /// Verifica l'autorizzazione per il contesto dell'azione HTTP.
        /// </summary>
        /// <param name="actionContext">Contesto dell'azione HTTP.</param>
        /// <returns>True se l'autorizzazione è verificata, altrimenti False.</returns>
        bool CheckAuthorization(HttpActionContext actionContext);
    }
}
