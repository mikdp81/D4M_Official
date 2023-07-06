using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;

namespace MultiDataConnection
{
    public class SettingsConnessione
    {
        private static Hashtable _settingsConnessione = (Hashtable)ConfigurationManager.GetSection("connection/Data");
        private string _name = string.Empty;
        private string _connectionStringName = string.Empty;
        private string _connectionStringValue = string.Empty;
        private bool _useWebConfigConnectionString;
        private int _providerType;
        private bool _crypted;
        private ProviderConnessione _providerConnessione;

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public bool UseWebConfigConnectionString
        {
            get
            {
                return this._useWebConfigConnectionString;
            }
            set
            {
                this._useWebConfigConnectionString = value;
            }
        }

        public string ConnectionStringName
        {
            get
            {
                return this._connectionStringName;
            }
            set
            {
                this._connectionStringName = value;
            }
        }

        public string ConnectionStringValue
        {
            get
            {
                return this._connectionStringValue;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Stringa di connessione vuota.");
                if (value.ToLower().Trim().IndexOf("provider=microsoft.jet.oledb.4.0") != -1)
                    this._connectionStringValue = "Provider=Microsoft.Jet.OLEDB.4.0; DATA SOURCE=" + HttpRuntime.AppDomainAppPath + value.ToLower().Trim().Replace("provider=microsoft.jet.oledb.4.0; data source=", "");
                else
                    this._connectionStringValue = value;
            }
        }

        public int ProviderType
        {
            get
            {
                return this._providerType;
            }
            set
            {
                this._providerType = value;
            }
        }

        public bool Crypted
        {
            get
            {
                return this._crypted;
            }
            set
            {
                this._crypted = value;
            }
        }

        public ProviderConnessione ProviderConnessione
        {
            get
            {
                if (this._providerConnessione == null)
                    this._providerConnessione = new ProviderConnessione(this._providerType);
                return this._providerConnessione;
            }
        }

        static SettingsConnessione()
        {
        }

        public IDbConnection Connessione()
        {
            return this.ProviderConnessione.CreateConnection(this._connectionStringValue);
        }

        public static Hashtable LoadSettings()
        {
            if (SettingsConnessione._settingsConnessione != null)
                return SettingsConnessione._settingsConnessione;
            SettingsConnessione._settingsConnessione = (Hashtable)ConfigurationManager.GetSection("connection/Data");
            return SettingsConnessione._settingsConnessione;
        }
    }
}