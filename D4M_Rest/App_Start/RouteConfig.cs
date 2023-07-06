using System.Web.Mvc;
using System.Web.Routing;

namespace DFleetRest
{
    /// <summary>
    /// Configura le rotte dell'applicazione.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registra le rotte specificate nella collezione di rotte.
        /// </summary>
        /// <param name="routes">La collezione di rotte a cui aggiungere le rotte configurate.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Ignora le richieste per i file .axd
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Configura la rotta di default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
