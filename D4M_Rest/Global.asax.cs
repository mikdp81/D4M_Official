

using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace DFleetRest
{
    /// <summary>
    /// Classe principale dell'applicazione Web API.
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Metodo che viene eseguito all'avvio dell'applicazione.
        /// Viene utilizzato per registrare gli elementi fondamentali dell'applicazione
        /// come i controller, i filtri, i percorsi di routing e i bundle di script e stili.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
