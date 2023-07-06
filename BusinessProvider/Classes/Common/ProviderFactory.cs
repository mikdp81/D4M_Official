
using AraneaUtilities.InterceptingFilters;
using BaseProvider;
using BusinessObject;
using System;

namespace BusinessProvider
{

    /// <summary>
    /// Classe factory per ottenere i provider proxy per diversi servizi provider.
    /// </summary>
    public class ProviderFactory
    {
        private readonly bool PROXY_MODE_ON = DFleetGlobals.ProviderProxy_ON;


        /// <summary>
        /// Ottiene un'interfaccia a un proxy che esegue il provider target con i suoi filtri.
        /// l'istanza è create in modalità singleton
        /// </summary>
        /// <typeparam name="IP">Interfaccia del provider.</typeparam>
        /// <typeparam name="TP">Classe del provider target a partire dal quale verrà creato il proxy.</typeparam>
        /// <param name="interfaceProvider">Riferimento al provider esistente o null se non presente.</param>
        /// <returns>L'interfaccia di un proxy che esegue il provider target con i filtri applicati.</returns>
        private IP GetProvider<IP, TP>(ref IP interfaceProvider)
            where IP : class
            where TP : DFleetDataProvider, IP

        {
            // ottengo in singleton il provider (e se PROXY_MODE_ON genero il proxy)
            return interfaceProvider = GetSingleInstance<IP, TP>(ref interfaceProvider);
        }

        /// <summary>
        /// Ottiene un'istanza del servizio in modalità singleton.
        /// se  PROXY_MODE_ON invoca generazione PROXY
        /// </summary>
        /// <typeparam name="IP">Interfaccia del provider target da ottenere.</typeparam>
        /// <typeparam name="TP">Classe del provider da ottenere.</typeparam>
        /// <param name="interfaceProvider">Riferimento al provider esistente o null se non presente.</param>
        /// <returns>L'interfaccia del provider creato/ottenuto.</returns>
        private IP GetSingleInstance<IP, TP>(ref IP interfaceProvider)
            where IP : class
            where TP : DFleetDataProvider, IP
        {
            if (interfaceProvider == null)
            {
                // Ottiene un provider
                interfaceProvider = BaseProviderManager<TP>.Provider;
                // se il proxy è attivo creo il proxy a partire dal targetProvider
                if (PROXY_MODE_ON)
                    interfaceProvider = CreateProviderProxy<IP, TP>(ref interfaceProvider);
            }

            return interfaceProvider;
        }



        /// <summary>
        /// Ottiene un'interfaccia a un proxy che esegue il provider target con i suoi filtri.
        /// </summary>
        /// <typeparam name="IP">Interfaccia del provider.</typeparam>
        /// <typeparam name="TP">Classe del provider target a partire dal quale verrà creato il proxy.</typeparam>
        /// <param name="interfaceProvider">Riferimento al provider esistente o null se non presente.</param>
        /// <returns>L'interfaccia di un proxy che esegue il provider target con i filtri applicati.</returns>
        private IP CreateProviderProxy<IP, TP>(ref IP interfaceProvider)
            where IP : class
            where TP : DFleetDataProvider, IP
        {
            // Ottiene il filtro di pre-elaborazione che agisce sul provider target
            IProxyFilter proxyPreFilter = new ProviderPreFilter((TP)interfaceProvider);

            // Ottiene un proxy per intercettare le richieste
            IInterceptingProxyGenerator<IP> interceptingProxy = InterceptingProxyGenerator<TP, IP>.GetInstance(proxyPreFilter, null, (TP)interfaceProvider);

            // Ottiene il target provider con l'aggiunta del filtro creato
            interfaceProvider = interceptingProxy.GenerateProxy();

            return interfaceProvider;
        }



        private static IAccountProvider servizioAccount = null;
        public IAccountProvider ServizioAccount
        {
            get
            {
                return GetProvider<IAccountProvider, AccountProvider>(ref servizioAccount);
            }
        }

        
        private static ILogProvider servizioLog = null;
        public ILogProvider ServizioLog
        {
            get
            {
                return GetProvider<ILogProvider, LogProvider>(ref servizioLog);
            }
        }


        private static ILoginProvider servizioLogin = null;
        public ILoginProvider ServizioLogin
        {
            get
            {
                return GetProvider<ILoginProvider, LoginProvider>(ref servizioLogin);
            }
        }

        private static IUtilitysProvider servizioUtility = null;
        public IUtilitysProvider ServizioUtility
        {
            get
            {
                return GetProvider<IUtilitysProvider, UtilitysProvider>(ref servizioUtility);
            }
        }

        private static ICarsProvider servizioCar = null;
        public ICarsProvider ServizioCar
        {
            get
            {
                return GetProvider<ICarsProvider, CarsProvider>(ref servizioCar);
            }
        }

        private static IContrattiProvider servizioContratti = null;
        public IContrattiProvider ServizioContratti
        {
            get
            {
                return GetProvider<IContrattiProvider, ContrattiProvider>(ref servizioContratti);
            }
        }

        private static IMulteProvider servizioMulte = null;
        public IMulteProvider ServizioMulte
        {
            get
            {
                return GetProvider<IMulteProvider, MulteProvider>(ref servizioMulte);
            }
        }

        private static IFileTracciatiProvider servizioFileTracciati = null;
        public IFileTracciatiProvider ServizioFileTracciati
        {
            get
            {
                return GetProvider<IFileTracciatiProvider, FileTracciatiProvider>(ref servizioFileTracciati);
            }
        }

        private static IComunicazioniProvider servizioComunicazioni = null;
        public IComunicazioniProvider ServizioComunicazioni
        {
            get
            {
                return GetProvider<IComunicazioniProvider, ComunicazioniProvider>(ref servizioComunicazioni);
            }
        }
        

        private static IApiAccountProvider servizioApiAccount = null;
        public IApiAccountProvider ServizioApiAccount
        {
            get
            {
                return GetProvider<IApiAccountProvider, ApiAccountProvider>(ref servizioApiAccount);
            }
        }
       
        private static IDFleetExceptionProvider servizioDFleetException = null;
        public IDFleetExceptionProvider ServizioDFleetException
        {
            get
            {
                return GetProvider<IDFleetExceptionProvider, DFleetExceptionProvider>(ref servizioDFleetException);
            }
        }
 
    }
}
