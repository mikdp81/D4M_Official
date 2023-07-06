using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MultiDataConnection
{
    public class DataHelper : BaseDataHelper
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private string _connectionName = string.Empty;
#pragma warning restore IDE0044 // Add readonly modifier
        private SettingsConnessione _settingConn;
        private ProviderConnessione _provider;


        public SettingsConnessione SettingConn
        {
            get
            {
                if (this._settingConn == null)
                    this._settingConn = (SettingsConnessione)SettingsConnessione.LoadSettings()[(object)this._connectionName];
                return this._settingConn;
            }
        }

        public ProviderConnessione ProviderConn
        {
            get
            {
                if (this._provider == null)
                    this._provider = this.SettingConn.ProviderConnessione;
                return this._provider;
            }
        }

        public string ConnectionString
        {
            get
            {
                return this._settingConn.ConnectionStringValue;
            }
        }

        public DataHelper(string ConnectionName)
        {
            this._connectionName = ConnectionName;

            this._settingConn = (SettingsConnessione)SettingsConnessione.LoadSettings()[(object)this._connectionName];
            this._provider = this._settingConn.ProviderConnessione;
        }

        public IReturnValue<int> RunCommand(string sqlCommand)
        {
            IReturnValue<int> returnValue = (IReturnValue<int>)new ReturnValue<int>();
            
            // "using": per usare ADO.NET Connection Pooling
            using (IDbConnection connection = this._settingConn.Connessione())
            {
                try
                {
                    // "Open()": recupera se c'è una connessione aperta nel pool
                    connection.Open();

                    // operazioni varie
                    IDbCommand command = this._provider.CreateCommand(sqlCommand, connection);
                    
                    command.CommandType = CommandType.Text;
                    returnValue.Data = command.ExecuteNonQuery();
                    command.Dispose();
                    //connection.Close()???
                }
                catch (Exception ex)
                {
                    returnValue.Error = true;
                    returnValue.Message = ex.Message;
                    returnValue.Data = 0;
                }
                /* usando il Connection Pooling ADO.NET == NON SERVE PIU'
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        connection.Dispose();
                    }
                }
                */
            }
            return returnValue;
        }

        public IReturnValue<int> RunCommand(string sqlCommand, CommandType type)
        {
            IReturnValue<int> returnValue = (IReturnValue<int>)new ReturnValue<int>();

            // "using": per usare ADO.NET Connection Pooling
            using (IDbConnection connection = this._settingConn.Connessione())
            {
                try
                {
                    // "Open()": recupera se c'è una connessione aperta nel pool
                    connection.Open();

                    // operazioni varie
                    IDbCommand command = this._provider.CreateCommand(sqlCommand, connection);
                    
                    command.CommandType = type;
                    returnValue.Data = command.ExecuteNonQuery();
                    command.Dispose();
                    //connection.Close()???
                }
                catch (Exception ex)
                {
                    returnValue.Error = true;
                    returnValue.Message = ex.Message;
                    returnValue.Data = 0;
                }
                /* usando il Connection Pooling ADO.NET == NON SERVE PIU'
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        connection.Dispose();
                    }
                }
                */
            }
            return returnValue;
        }

        public IReturnValue<int> RunCommand(string sqlCommand, List<IDataParameter> args)
        {
            IReturnValue<int> returnValue = (IReturnValue<int>)new ReturnValue<int>();

            // "using": per usare ADO.NET Connection Pooling
            using (IDbConnection connection = this._settingConn.Connessione())
            {
                try
                {
                    // "Open()": recupera se c'è una connessione aperta nel pool
                    connection.Open();

                    // operazioni varie
                    IDbCommand command = this._provider.CreateCommand(sqlCommand, connection);
                    
                    command.CommandType = CommandType.Text;
                    foreach (IDataParameter dataParameter in args)
                        command.Parameters.Add((object)dataParameter);
                    returnValue.Data = command.ExecuteNonQuery();
                    command.Dispose();
                    //connection.Close()???
                }
                catch (Exception ex)
                {
                    returnValue.Error = true;
                    returnValue.Message = ex.Message;
                    returnValue.Data = 0;
                }
                /* usando il Connection Pooling ADO.NET == NON SERVE PIU'
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        connection.Dispose();
                    }
                }
                */
            }
            return returnValue;
        }

        public IReturnValue<int> RunCommand(string sqlCommand, List<IDataParameter> args, CommandType type)
        {
            IReturnValue<int> returnValue = (IReturnValue<int>)new ReturnValue<int>();

            // "using": per usare ADO.NET Connection Pooling
            using (IDbConnection connection = this._settingConn.Connessione())
            {
                try
                {
                    // "Open()": recupera se c'è una connessione aperta nel pool
                    connection.Open();

                    // operazioni varie
                    IDbCommand command = this._provider.CreateCommand(sqlCommand, connection);
                    
                    command.CommandType = type;
                    foreach (IDataParameter dataParameter in args)
                        command.Parameters.Add((object)dataParameter);
                    returnValue.Data = command.ExecuteNonQuery();
                    command.Dispose();
                    //connection.Close()???
                }
                catch (Exception ex)
                {
                    returnValue.Error = true;
                    returnValue.Message = ex.Message;
                    returnValue.Data = 0;
                }
                /* usando il Connection Pooling ADO.NET == NON SERVE PIU'
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        connection.Dispose();
                    }
                }
                */
            }
            return returnValue;
        }

        public IReturnValue<T> GetValue<T>(string sqlCommand)
        {
            IReturnValue<T> returnValue = (IReturnValue<T>)new ReturnValue<T>();

            // "using": per usare ADO.NET Connection Pooling
            using (IDbConnection connection = this._settingConn.Connessione())
            {
                try
                {
                    // "Open()": recupera se c'è una connessione aperta nel pool
                    connection.Open();

                    // operazioni varie
                    IDbCommand command = this._provider.CreateCommand(sqlCommand, connection);
                    
                    command.CommandType = CommandType.Text;
                    T obj2 = (T)command.ExecuteScalar();
                    returnValue.Data = obj2;
                    command.Dispose();
                    //connection.Close()???
                }
                catch (Exception ex)
                {
                    returnValue.Error = true;
                    returnValue.Message = ex.Message;
                }
                
                /* usando il Connection Pooling ADO.NET == NON SERVE PIU'
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        connection.Dispose();
                    }
                }
                */
            }
            return returnValue;
        }

        public IReturnValue<T> GetValue<T>(string sqlCommand, CommandType type)
        {

            IReturnValue<T> returnValue = (IReturnValue<T>)new ReturnValue<T>();

            // "using": per usare ADO.NET Connection Pooling
            using (IDbConnection connection = this._settingConn.Connessione())
            {
                try
                {
                    // "Open()": recupera se c'è una connessione aperta nel pool
                    connection.Open();

                    // operazioni varie
                    IDbCommand command = this._provider.CreateCommand(sqlCommand, connection);
                    command.CommandType = type;
                    
                    T obj2 = (T)command.ExecuteScalar();
                    returnValue.Data = obj2;
                    command.Dispose();
                    //connection.Close()???
                }
                catch (Exception ex)
                {
                    returnValue.Error = true;
                    returnValue.Message = ex.Message;
                }
                /* usando il Connection Pooling ADO.NET == NON SERVE PIU'
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        connection.Dispose();
                    }
                }
                */
            }
            return returnValue;
        }

        public IReturnValue<T> GetValue<T>(string sqlCommand, List<IDataParameter> args)
        {
            IReturnValue<T> returnValue = (IReturnValue<T>)new ReturnValue<T>();

            // "using": per usare ADO.NET Connection Pooling
            using (IDbConnection connection = this._settingConn.Connessione())
            {
                try
                {
                    // "Open()": recupera se c'è una connessione aperta nel pool
                    connection.Open();

                    // operazioni varie
                    IDbCommand command = this._provider.CreateCommand(sqlCommand, connection);
                    
                    command.CommandType = CommandType.Text;
                    foreach (IDataParameter dataParameter in args)
                        command.Parameters.Add((object)dataParameter);
                    T obj2 = (T)command.ExecuteScalar();
                    returnValue.Data = obj2;
                    command.Dispose();
                    //connection.Close()???
                }
                catch (Exception ex)
                {
                    returnValue.Error = true;
                    returnValue.Message = ex.Message;
                }
                /* usando il Connection Pooling ADO.NET == NON SERVE PIU'
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        connection.Dispose();
                    }
                }
                */
            }
            return returnValue;
        }

        public IReturnValue<T> GetValue<T>(string sqlCommand, List<IDataParameter> args, CommandType type)
        {
            IReturnValue<T> returnValue = (IReturnValue<T>)new ReturnValue<T>();

            // "using": per usare ADO.NET Connection Pooling
            using (IDbConnection connection = this._settingConn.Connessione())
            {
                try
                {
                    // "Open()": recupera se c'è una connessione aperta nel pool
                    connection.Open();

                    // operazioni varie
                    IDbCommand command = this._provider.CreateCommand(sqlCommand, connection);
                    
                    command.CommandType = type;
                    foreach (IDataParameter dataParameter in args)
                        command.Parameters.Add((object)dataParameter);
                    T obj2 = (T)command.ExecuteScalar();
                    returnValue.Data = obj2;
                    command.Dispose();
                    //connection.Close()???
                }
                catch (Exception ex)
                {
                    returnValue.Error = true;
                    returnValue.Message = ex.Message;
                }
                /* usando il Connection Pooling ADO.NET == NON SERVE PIU'
                 finally
                 {
                     if (connection != null)
                     {
                         if (connection.State == ConnectionState.Open)
                             connection.Close();
                         connection.Dispose();
                     }
                 }
                 */
            }
            return returnValue;
        }

        public IReturnValue<DataTable> GetDataTable(string sqlCommand)
        {
            IReturnValue<DataTable> returnValue = (IReturnValue<DataTable>)new ReturnValue<DataTable>();

            // "using": per usare ADO.NET Connection Pooling
            using (IDbConnection connection = this._settingConn.Connessione())
            {
                try
                {
                    // "Open()": recupera se c'è una connessione aperta nel pool
                    connection.Open();

                    // operazioni varie
                    IDbCommand command = this._provider.CreateCommand(sqlCommand, connection);
                    
                    command.CommandType = CommandType.Text;
                    IDataReader reader = command.ExecuteReader();
                    returnValue.Data = new DataTable();
                    returnValue.Data.Load(reader);
                    reader.Close();
                    reader.Dispose();
                   // connection.Close();
                }
                catch (Exception ex)
                {
                    returnValue.Error = true;
                    returnValue.Message = ex.Message;
                    returnValue.Data = (DataTable)null;
                }
                /* usando il Connection Pooling ADO.NET == NON SERVE PIU'
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        connection.Dispose();
                    }
                }
                */
            }
            return returnValue;
        }

        public IReturnValue<DataTable> GetDataTable(string sqlCommand, CommandType type)
        {
            IReturnValue<DataTable> returnValue = (IReturnValue<DataTable>)new ReturnValue<DataTable>();
                                       
            // "using": per usare ADO.NET Connection Pooling
            using (IDbConnection connection = this._settingConn.Connessione())
            {
                try
                {
                    // "Open()": recupera se c'è una connessione aperta nel pool
                    connection.Open();

                    // operazioni varie
                    IDbCommand command = this._provider.CreateCommand(sqlCommand, connection);
                   
                    command.CommandType = type;
                    IDataReader reader = command.ExecuteReader();
                    returnValue.Data = new DataTable();
                    returnValue.Data.Load(reader);
                    reader.Close();
                    reader.Dispose();
                    //connection.Close();
                }
                catch (Exception ex)
                {
                    returnValue.Error = true;
                    returnValue.Message = ex.Message;
                    returnValue.Data = (DataTable)null;
                }
                /* usando il Connection Pooling ADO.NET == NON SERVE PIU'
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        connection.Dispose();
                    }
                }
                */
            }
            return returnValue;
        }

        public IReturnValue<DataTable> GetDataTable(string sqlCommand, List<IDataParameter> args)
        {
            IReturnValue<DataTable> returnValue = (IReturnValue<DataTable>)new ReturnValue<DataTable>();
            
            // "using": per usare ADO.NET Connection Pooling
            using (IDbConnection connection = this._settingConn.Connessione())
            {
                try
                {
                    // "Open()": recupera se c'è una connessione aperta nel pool
                    connection.Open();

                    // operazioni varie
                    IDbCommand command = this._provider.CreateCommand(sqlCommand, connection);
                    
                    command.CommandType = CommandType.Text;
                    foreach (IDataParameter dataParameter in args)
                        command.Parameters.Add((object)dataParameter);
                    IDataReader reader = command.ExecuteReader();
                    returnValue.Data = new DataTable();
                    returnValue.Data.Load(reader);
                    reader.Close();
                    reader.Dispose();

                    // "Close()": rimette nel pool la connessione aperta, non serve invocarlo
                    //connection.Close();
                }
                catch (Exception ex)
                {
                    returnValue.Error = true;
                    returnValue.Message = ex.Message;
                    returnValue.Data = (DataTable)null;
                }

                /* usando il Connection Pooling ADO.NET == NON SERVE PIU'
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        connection.Dispose();
                    }
                }
                */
            }
            return returnValue;
        }

        public IReturnValue<DataTable> GetDataTable(string sqlCommand, List<IDataParameter> args, CommandType type)
        {
            IReturnValue<DataTable> returnValue = (IReturnValue<DataTable>)new ReturnValue<DataTable>();

            // "using": per usare ADO.NET Connection Pooling
            using (IDbConnection connection = this._settingConn.Connessione())
            {
                try
                {
                    // "Open()": recupera se c'è una connessione aperta nel pool
                    connection.Open();

                    // operazioni varie
                    IDbCommand command = this._provider.CreateCommand(sqlCommand, connection);
                    command.CommandType = type;
                    
                    foreach (IDataParameter dataParameter in args)
                        command.Parameters.Add((object)dataParameter);
                    IDataReader reader = command.ExecuteReader();
                    returnValue.Data = new DataTable();
                    returnValue.Data.Load(reader);
                    reader.Close();
                    reader.Dispose();
                    //connection.Close();
                }
                catch (Exception ex)
                {
                    returnValue.Error = true;
                    returnValue.Message = ex.Message;
                    returnValue.Data = (DataTable)null;
                }
                /* usando il Connection Pooling ADO.NET == NON SERVE PIU'
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        connection.Dispose();
                    }
                }
                */
            }
            return returnValue;
        }

        public IReturnValue<DataTable> GetPagedDataTable(string TableOrViewName, int numberOfRecords, int maximumRows, int startRowIndex, string orderColumn)
        {
            int selectedPage = BaseDataHelper.GetSelectedPage(startRowIndex, maximumRows);
            int numberOfPages = BaseDataHelper.GetNumberOfPages(numberOfRecords, maximumRows);
            return this.GetDataTable(BaseDataHelper.GetPagedString(TableOrViewName, maximumRows, selectedPage, numberOfPages, numberOfRecords, orderColumn), CommandType.Text);
        }

        public IReturnValue<DataTable> GetPagedDataTable(string TableOrViewName, int numberOfRecords, int maximumRows, int startRowIndex, string orderColumn, string orderDirection)
        {
            int selectedPage = BaseDataHelper.GetSelectedPage(startRowIndex, maximumRows);
            int numberOfPages = BaseDataHelper.GetNumberOfPages(numberOfRecords, maximumRows);
            return this.GetDataTable(BaseDataHelper.GetPagedString(TableOrViewName, maximumRows, selectedPage, numberOfPages, numberOfRecords, orderColumn, orderDirection), CommandType.Text);
        }

        public IReturnValue<DataTable> GetPagedDataTable(string TableOrViewName, int numberOfRecords, int maximumRows, int startRowIndex, string orderColumn, string orderDirection, string whereClause)
        {
            int selectedPage = BaseDataHelper.GetSelectedPage(startRowIndex, maximumRows);
            int numberOfPages = BaseDataHelper.GetNumberOfPages(numberOfRecords, maximumRows);
            return this.GetDataTable(BaseDataHelper.GetPagedString(TableOrViewName, maximumRows, selectedPage, numberOfPages, numberOfRecords, orderColumn, orderDirection, whereClause), CommandType.Text);
        }

        public IReturnValue<DataTable> GetPagedDataTable(string TableOrViewName, int numberOfRecords, int maximumRows, int startRowIndex, string orderColumn, List<IDataParameter> args)
        {
            int selectedPage = BaseDataHelper.GetSelectedPage(startRowIndex, maximumRows);
            int numberOfPages = BaseDataHelper.GetNumberOfPages(numberOfRecords, maximumRows);
            return this.GetDataTable(BaseDataHelper.GetPagedString(TableOrViewName, maximumRows, selectedPage, numberOfPages, numberOfRecords, orderColumn), args, CommandType.Text);
        }

        public IReturnValue<DataTable> GetPagedDataTable(string TableOrViewName, int numberOfRecords, int maximumRows, int startRowIndex, string orderColumn, string orderDirection, List<IDataParameter> args)
        {
            int selectedPage = BaseDataHelper.GetSelectedPage(startRowIndex, maximumRows);
            int numberOfPages = BaseDataHelper.GetNumberOfPages(numberOfRecords, maximumRows);
            return this.GetDataTable(BaseDataHelper.GetPagedString(TableOrViewName, maximumRows, selectedPage, numberOfPages, numberOfRecords, orderColumn, orderDirection), args, CommandType.Text);
        }

        public IReturnValue<DataTable> GetPagedDataTable(string TableOrViewName, int numberOfRecords, int maximumRows, int startRowIndex, string orderColumn, string orderDirection, string whereClause, List<IDataParameter> args)
        {
            int selectedPage = BaseDataHelper.GetSelectedPage(startRowIndex, maximumRows);
            int numberOfPages = BaseDataHelper.GetNumberOfPages(numberOfRecords, maximumRows);
            return this.GetDataTable(BaseDataHelper.GetPagedString(TableOrViewName, maximumRows, selectedPage, numberOfPages, numberOfRecords, orderColumn, orderDirection, whereClause), args, CommandType.Text);
        }

        public IReturnValue<DataTable> GetPagedDataTableWithKey(string TableOrViewName, int numberOfRecords, int maximumRows, int startRowIndex, string orderColumn, string Key)
        {
            int selectedPage = BaseDataHelper.GetSelectedPage(startRowIndex, maximumRows);
            int numberOfPages = BaseDataHelper.GetNumberOfPages(numberOfRecords, maximumRows);
            return this.GetDataTable(BaseDataHelper.GetPagedStringWithKey(TableOrViewName, maximumRows, selectedPage, numberOfPages, numberOfRecords, orderColumn, Key), CommandType.Text);
        }

        public IReturnValue<DataTable> GetPagedDataTableWithKey(string TableOrViewName, int numberOfRecords, int maximumRows, int startRowIndex, string orderColumn, string orderDirection, string Key)
        {
            int selectedPage = BaseDataHelper.GetSelectedPage(startRowIndex, maximumRows);
            int numberOfPages = BaseDataHelper.GetNumberOfPages(numberOfRecords, maximumRows);
            return this.GetDataTable(BaseDataHelper.GetPagedStringWithKey(TableOrViewName, maximumRows, selectedPage, numberOfPages, numberOfRecords, orderColumn, orderDirection, Key), CommandType.Text);
        }

        public IReturnValue<DataTable> GetPagedDataTableWithKey(string TableOrViewName, int numberOfRecords, int maximumRows, int startRowIndex, string orderColumn, string orderDirection, string whereClause, string Key)
        {
            int selectedPage = BaseDataHelper.GetSelectedPage(startRowIndex, maximumRows);
            int numberOfPages = BaseDataHelper.GetNumberOfPages(numberOfRecords, maximumRows);
            return this.GetDataTable(BaseDataHelper.GetPagedStringWithKey(TableOrViewName, maximumRows, selectedPage, numberOfPages, numberOfRecords, orderColumn, orderDirection, whereClause, Key), CommandType.Text);
        }
    }
}