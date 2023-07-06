using System;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;

namespace Provider
{
    public static class BaseProviderManager<T> where T : BaseProvider
    {
        private static T defaultProvider;
        private static BaseProviderCollection<T> providers;

        public static T Provider
        {
            get
            {
                return BaseProviderManager<T>.defaultProvider;
            }
        }

        public static BaseProviderCollection<T> Providers
        {
            get
            {
                return BaseProviderManager<T>.providers;
            }
        }

        static BaseProviderManager()
        {
            BaseProviderManager<T>.Initialize();
        }

        private static void Initialize()
        {
            BaseServiceSection baseServiceSection = (BaseServiceSection)ConfigurationManager.GetSection(BaseProviderManager<T>.GetSectionName<T>());
            if (baseServiceSection == null)
                throw new ConfigurationErrorsException("Provider configuration section is not set up correctly");
            BaseProviderManager<T>.providers = new BaseProviderCollection<T>();
            ProvidersHelper.InstantiateProviders(baseServiceSection.Providers, (ProviderCollection)BaseProviderManager<T>.providers, typeof(T));
            BaseProviderManager<T>.providers.SetReadOnly();
            BaseProviderManager<T>.defaultProvider = BaseProviderManager<T>.providers[baseServiceSection.DefaultProvider];
            if ((object)BaseProviderManager<T>.defaultProvider == null)
                throw new Exception("defaultProvider");
        }

        public static string GetSectionName<T>() where T : BaseProvider
        {
            return (typeof(T).GetCustomAttributes(typeof(SectionNameAttribute), true)[0] as SectionNameAttribute).SectionName;
        }
    }
}