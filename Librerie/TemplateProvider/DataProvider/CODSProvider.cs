using Provider;

namespace Provider.Data
{
    public class ODSProvider<T> where T : DataProvider
    {
        private static T defaultProvider = BaseProviderManager<T>.Provider;

        public static T DefaultProvider
        {
            get
            {
                if ((object)ODSProvider<T>.defaultProvider == null)
                    ODSProvider<T>.defaultProvider = BaseProviderManager<T>.Provider;
                return ODSProvider<T>.defaultProvider;
            }
        }

        static ODSProvider()
        {
        }

        protected ODSProvider()
        {
            if ((object)ODSProvider<T>.defaultProvider != null)
                return;
            ODSProvider<T>.defaultProvider = BaseProviderManager<T>.Provider;
        }
    }
}
