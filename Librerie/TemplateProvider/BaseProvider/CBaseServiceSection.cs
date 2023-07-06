using System.Configuration;

namespace Provider
{
    public class BaseServiceSection : ConfigurationSection
    {
        [ConfigurationProperty("providers")]
        public ProviderSettingsCollection Providers
        {
            get
            {
                return (ProviderSettingsCollection)this["providers"];
            }
        }

        [ConfigurationProperty("DefaultProvider", DefaultValue = "BaseProvider")]
        public string DefaultProvider
        {
            get
            {
                return (string)this["DefaultProvider"];
            }
            set
            {
                this["DefaultProvider"] = (object)value;
            }
        }
    }
}
