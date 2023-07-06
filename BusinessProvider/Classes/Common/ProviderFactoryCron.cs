using BaseProvider;
using BusinessObject;

namespace BusinessProvider
{
    /// <summary>
    /// Classe factory per la creazione di istanze del provider Cron.
    /// </summary>
    public class ProviderFactoryCron
    {
        private static ICronProvider servizioCron = null;

        /// <summary>
        /// Ottiene o imposta il provider ICronProvider.
        /// </summary>
        public ICronProvider ServizioCron
        {
            get
            {
                return ServizioSingleton<ICronProvider, CronProvider>(servizioCron);
            }
        }

        /// <summary>
        /// Ottiene un provider proxy a partire dall'oggetto del provider target e dall'interfaccia del servizio provider.
        /// Ottiene un'istanza del servizio singleton se non è già presente, utilizzando un provider di target specifico.
        /// </summary>
        /// <typeparam name="SP">Il tipo dell'interfaccia del servizio provider.</typeparam>
        /// <typeparam name="TP">La classe dell'oggetto provider target.</typeparam>
        /// <param name="servizioProvider">L'istanza del servizio singleton esistente o null se non presente.</param>
        /// <returns>L'istanza del servizio singleton.</returns>
        private SP ServizioSingleton<SP, TP>(SP servizioProvider) where TP : DFleetDataProvider, SP
        {
            if (servizioProvider == null)
            {
                // Ottiene un provider
                servizioProvider = BaseProviderManager<TP>.Provider;
            }

            return servizioProvider;
        }
    }
}
