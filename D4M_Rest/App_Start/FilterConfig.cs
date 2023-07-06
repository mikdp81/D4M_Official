
using System.Web.Mvc;


namespace DFleetRest
{
    /// <summary>
    /// Configura i filtri globali dell'applicazione.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registra i filtri globali dell'applicazione.
        /// </summary>
        /// <param name="filters">La raccolta di filtri globali.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

}
