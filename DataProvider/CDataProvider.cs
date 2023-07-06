using System.Collections.Specialized;
using System.Configuration;
using MultiDataConnection;
using BaseProvider;

namespace DataProvider
{
    [SectionName("DataProvider")]
    public class DataProvider: BaseProvider.BaseProvider
    {
        protected string _connectionName = string.Empty;
        protected DataHelper _dataHelper;

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
            this._connectionName = config["connectionName"];
            if (string.IsNullOrEmpty(this._connectionName))
                throw new ConfigurationErrorsException("connectionName must be set to the appropriate value");
            this._dataHelper = new DataHelper(this._connectionName);
        }
    }
}