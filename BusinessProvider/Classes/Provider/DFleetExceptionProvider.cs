using BaseProvider;
using BusinessObject;
using MultiDataConnection;
using System.Collections.Generic;
using System.Data;

namespace BusinessProvider
{
    /// <summary>
    /// Provider per le eccezioni di DFleet.
    /// Eredita dalla classe DFleetDataProvider e implementa l'interfaccia IDFleetExceptionProvider.
    /// </summary>
    [SectionName("dfleetException.provider/DFleetExceptionSection")]
    public class DFleetExceptionProvider : DFleetDataProvider, IDFleetExceptionProvider
    {
        /// <summary>
        /// Inserisce un'eccezione DFleet nel database.
        /// </summary>
        /// <param name="value">L'oggetto DFleetException da inserire.</param>
        /// <returns>Il numero di righe inserite (1 se l'operazione ha avuto successo).</returns>
        public int Insert(DFleetException value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_Exception ([Data], [HelpLink], [HResult], [InnerException], [Message], [Source], ";
            sql += "[iduserins], [datauserins], [TargetSite], [StackTrace]) ";
            sql += " VALUES (@Data, @HelpLink, @HResult, @InnerException, @Message, @Source,";
            sql += "@iduserins, @datauserins, @TargetSite, @StackTrace)";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Data", DbType.String);
            param0.Value = value.Data;
            collParams.Add(param0);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@StackTrace", DbType.String);
            param9.Value = value.StackTrace;
            collParams.Add(param9);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@Source", DbType.String);
            param8.Value = value.Source;
            collParams.Add(param8);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@TargetSite", DbType.String);
            param7.Value = value.TargetSite;
            collParams.Add(param7);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@HelpLink", DbType.String);
            param10.Value = value.HelpLink;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@HResult", DbType.String);
            param11.Value = value.HResult;
            collParams.Add(param11);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@InnerException", DbType.String);
            param2.Value = value.InnerException;
            collParams.Add(param2);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.DateTime);
            param5.Value = value.DataUserins;
            collParams.Add(param5);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Message", DbType.String);
            param3.Value = value.Message;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@iduserins", DbType.Int32);
            param4.Value = value.Iduserins;
            collParams.Add(param4);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }


            return retVal;
        }


    }
}
