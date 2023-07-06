using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Reflection;

namespace MultiDataConnection
{
    public class ProviderConnessione
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private static Type[] _connectionTypes = new Type[2]
#pragma warning restore IDE0044 // Add readonly modifier
    {
      typeof (OleDbConnection),
      typeof (SqlConnection)
    };
        private static Type[] _commandTypes = new Type[2]
    {
      typeof (OleDbCommand),
      typeof (SqlCommand)
    };
        private static Type[] _dataAdapterTypes = new Type[2]
    {
      typeof (OleDbDataAdapter),
      typeof (SqlDataAdapter)
    };
        private static Type[] _dataParameterTypes = new Type[2]
    {
      typeof (OleDbParameter),
      typeof (SqlParameter)
    };
        private ProviderType _provider;

        public ProviderType Provider
        {
            get
            {
                return this._provider;
            }
            set
            {
                this._provider = value;
            }
        }

        static ProviderConnessione()
        {
        }

        public ProviderConnessione()
        {
        }

        public ProviderConnessione(int provider)
        {
            this._provider = (ProviderType)provider;
        }

        public IDbConnection CreateConnection()
        {
            try
            {
                return (IDbConnection)Activator.CreateInstance(ProviderConnessione._connectionTypes[(int)this._provider]);
            }
            catch (TargetInvocationException ex)
            {
                throw new SystemException(ex.InnerException.Message, ex.InnerException);
            }
        }

        public IDbConnection CreateConnection(string connectionString)
        {
            object[] objArray = new object[1]
      {
        (object) connectionString
      };
            try
            {
                return (IDbConnection)Activator.CreateInstance(ProviderConnessione._connectionTypes[(int)this._provider], objArray);
            }
            catch (TargetInvocationException ex)
            {
                throw new SystemException(ex.InnerException.Message, ex.InnerException);
            }
        }

        public IDbConnection CreateConnection(int provider, string connectionString)
        {
            object[] objArray = new object[1]
      {
        (object) connectionString
      };
            try
            {
                return (IDbConnection)Activator.CreateInstance(ProviderConnessione._connectionTypes[(int)this._provider], objArray);
            }
            catch (TargetInvocationException ex)
            {
                throw new SystemException(ex.InnerException.Message, ex.InnerException);
            }
        }

        public IDbCommand CreateCommand()
        {
            try
            {
                return (IDbCommand)Activator.CreateInstance(ProviderConnessione._commandTypes[(int)this._provider]);
            }
            catch (TargetInvocationException ex)
            {
                throw new SystemException(ex.InnerException.Message, ex.InnerException);
            }
        }

        public IDbCommand CreateCommand(string cmdText)
        {
            object[] objArray = new object[1]
      {
        (object) cmdText
      };
            try
            {
                return (IDbCommand)Activator.CreateInstance(ProviderConnessione._commandTypes[(int)this._provider], objArray);
            }
            catch (TargetInvocationException ex)
            {
                throw new SystemException(ex.InnerException.Message, ex.InnerException);
            }
        }

        public IDbCommand CreateCommand(string cmdText, IDbConnection connection)
        {
            object[] objArray = new object[2]
      {
        (object) cmdText,
        (object) connection
      };
            try
            {
                return (IDbCommand)Activator.CreateInstance(ProviderConnessione._commandTypes[(int)this._provider], objArray);
            }
            catch (TargetInvocationException ex)
            {
                throw new SystemException(ex.InnerException.Message, ex.InnerException);
            }
        }

        public IDbCommand CreateCommand(string cmdText, IDbConnection connection, IDbTransaction transaction)
        {
            object[] objArray = new object[3]
      {
        (object) cmdText,
        (object) connection,
        (object) transaction
      };
            try
            {
                return (IDbCommand)Activator.CreateInstance(ProviderConnessione._commandTypes[(int)this._provider], objArray);
            }
            catch (TargetInvocationException ex)
            {
                throw new SystemException(ex.InnerException.Message, ex.InnerException);
            }
        }

        public IDbDataAdapter CreateDataAdapter()
        {
            try
            {
                return (IDbDataAdapter)Activator.CreateInstance(ProviderConnessione._dataAdapterTypes[(int)this._provider]);
            }
            catch (TargetInvocationException ex)
            {
                throw new SystemException(ex.InnerException.Message, ex.InnerException);
            }
        }

        public IDbDataAdapter CreateDataAdapter(IDbCommand selectCommand)
        {
            object[] objArray = new object[1]
      {
        (object) selectCommand
      };
            try
            {
                return (IDbDataAdapter)Activator.CreateInstance(ProviderConnessione._dataAdapterTypes[(int)this._provider], objArray);
            }
            catch (TargetInvocationException ex)
            {
                throw new SystemException(ex.InnerException.Message, ex.InnerException);
            }
        }

        public IDbDataAdapter CreateDataAdapter(string selectCommandText, IDbConnection selectConnection)
        {
            object[] objArray = new object[2]
      {
        (object) selectCommandText,
        (object) selectConnection
      };
            try
            {
                return (IDbDataAdapter)Activator.CreateInstance(ProviderConnessione._dataAdapterTypes[(int)this._provider], objArray);
            }
            catch (TargetInvocationException ex)
            {
                throw new SystemException(ex.InnerException.Message, ex.InnerException);
            }
        }

        public IDbDataAdapter CreateDataAdapter(string selectCommandText, string selectConnectionString)
        {
            object[] objArray = new object[2]
      {
        (object) selectCommandText,
        (object) selectConnectionString
      };
            try
            {
                return (IDbDataAdapter)Activator.CreateInstance(ProviderConnessione._dataAdapterTypes[(int)this._provider], objArray);
            }
            catch (TargetInvocationException ex)
            {
                throw new SystemException(ex.InnerException.Message, ex.InnerException);
            }
        }

        public IDbDataParameter CreateDataParameter()
        {
            try
            {
                return (IDbDataParameter)Activator.CreateInstance(ProviderConnessione._dataParameterTypes[(int)this._provider]);
            }
            catch (TargetInvocationException ex)
            {
                throw new SystemException(ex.InnerException.Message, ex.InnerException);
            }
        }

        public IDbDataParameter CreateDataParameter(string parameterName, object value)
        {
            object[] objArray = new object[2]
      {
        (object) parameterName,
        value
      };
            try
            {
                return (IDbDataParameter)Activator.CreateInstance(ProviderConnessione._dataParameterTypes[(int)this._provider], objArray);
            }
            catch (TargetInvocationException ex)
            {
                throw new SystemException(ex.InnerException.Message, ex.InnerException);
            }
        }

        public IDbDataParameter CreateDataParameter(string parameterName, DbType dataType)
        {
            IDbDataParameter dataParameter = this.CreateDataParameter();
            if (dataParameter != null)
            {
                dataParameter.ParameterName = parameterName;
                dataParameter.DbType = dataType;
            }
            return dataParameter;
        }

        public IDbDataParameter CreateDataParameter(string parameterName, DbType dataType, int size)
        {
            IDbDataParameter dataParameter = this.CreateDataParameter();
            if (dataParameter != null)
            {
                dataParameter.ParameterName = parameterName;
                dataParameter.DbType = dataType;
                dataParameter.Size = size;
            }
            return dataParameter;
        }

        public IDbDataParameter CreateDataParameter(string parameterName, DbType dataType, int size, string sourceColumn)
        {
            IDbDataParameter dataParameter = this.CreateDataParameter();
            if (dataParameter != null)
            {
                dataParameter.ParameterName = parameterName;
                dataParameter.DbType = dataType;
                dataParameter.Size = size;
                dataParameter.SourceColumn = sourceColumn;
            }
            return dataParameter;
        }
    }
}