using BusinessObject;
using System;
using System.Collections.Specialized;
using System.Web.Security;

namespace BusinessProvider
{
    /// <summary>
    /// Classe base per tutti i provider dell'applicazione DFleet.
    /// </summary>
    public class DFleetDataProvider : DataProvider.DataProvider
    {
        internal protected static string _stringEmpty = string.Empty;
        internal protected SecurityHelper _securityHelper = null;

        /// <summary>
        /// Restituisce la chiave utente del provider.
        /// </summary>
        protected internal Guid ProviderUserKey
        {
            get
            {
                return (Guid)Membership.GetUser(this.CurrentUsername).ProviderUserKey;
            }
        }

        /// <summary>
        /// Nome utente corrente.
        /// </summary>
        internal string CurrentUsername { get; set; }

        /// <summary>
        /// Inizializza il provider con il nome e la configurazione specificati.
        /// </summary>
        /// <param name="name">Nome del provider.</param>
        /// <param name="config">Configurazione del provider.</param>
        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);

            _securityHelper = new SecurityHelper();
        }
    }
}
