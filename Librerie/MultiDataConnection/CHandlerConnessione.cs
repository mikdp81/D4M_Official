using System;
using System.Collections;
using System.Configuration;
using System.Xml;
using Sicurezza;

namespace MultiDataConnection
{
    public class HandlerConnessione : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            Hashtable hashtable = new Hashtable();
            if (section.ChildNodes.Count > 0)
            {
                foreach (XmlNode xmlNode in section.ChildNodes)
                {
                    SettingsConnessione settingsConnessione = new SettingsConnessione();
                    settingsConnessione.Name = xmlNode.Attributes["name"].Value;
                    if (!Convert.ToBoolean(xmlNode.Attributes["useWebConfigConnectionString"].Value))
                    {
                        settingsConnessione.ConnectionStringValue = xmlNode.Attributes["connectionStringValue"].Value;
                        settingsConnessione.ProviderType = Convert.ToInt32(xmlNode.Attributes["providerType"].Value);
                        settingsConnessione.Crypted = Convert.ToBoolean(xmlNode.Attributes["crypted"].Value);
                        if (settingsConnessione.Crypted)
                            settingsConnessione.ConnectionStringValue = SettingsSicurezza.Decrypt(settingsConnessione.ConnectionStringValue);
                    }
                    else
                    {
                        settingsConnessione.ConnectionStringValue = ConfigurationManager.ConnectionStrings[xmlNode.Attributes["webConfigConnectionStringName"].Value].ConnectionString;
                        settingsConnessione.ProviderType = Convert.ToInt32(xmlNode.Attributes["providerType"].Value);
                    }
                    hashtable.Add((object)settingsConnessione.Name, (object)settingsConnessione);
                }
            }
            return (object)hashtable;
        }
    }
}