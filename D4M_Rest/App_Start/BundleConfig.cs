using System.Web.Optimization;

namespace DFleetRest
{
    /// <summary>
    /// Classe per la gestione della configurazione dei bundle di script e fogli di stile.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registra i bundle di script e fogli di stile.
        /// </summary>
        /// <param name="bundles">La raccolta di bundle.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Aggiunge il bundle per jQuery.
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Aggiunge il bundle per Modernizr.
            // Utilizza la versione di sviluppo per imparare e sviluppare, poi utilizza lo strumento di compilazione su https://modernizr.com per selezionare solo i test di cui hai bisogno.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Aggiunge il bundle per Bootstrap.
            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            // Aggiunge il bundle per i fogli di stile.
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
