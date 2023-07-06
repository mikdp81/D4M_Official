// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CLogProvider.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Permissions;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Security;
using MultiDataConnection;
using BusinessObject;
using BaseProvider;
using DataProvider;


namespace BusinessProvider
{

    [SectionName("log.provider/LogSection")]
    public class LogProvider : DFleetDataProvider, ILogProvider
    {
        public int InsertLogAtt(ILog value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_logattivita ([attivita], [chiave], [UserId], [datains]) VALUES (@attivita, @chiave, @UserId, @datains)";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@datains", DbType.DateTime);
            param1.Value = DateTime.Now;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@chiave", DbType.String);
            param2.Value = value.Chiave;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@attivita", DbType.String);
            param3.Value = value.Idattivita;
            collParams.Add(param3);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }



        public List<ILog> SelectLog(string log)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(log))
            {
                condWhere += " WHERE UIDsession like '%' + @log + '%' or tipologlogin like '%' + @log + '%' ";
            }

            List<ILog> retVal = new List<ILog>();
            string sql = "SELECT * FROM ED_loglogin" + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(log))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UIDsession", DbType.String);
                param0.Value = log;
                collParams.Add(param0);
            }

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ILog item = new Log
                    {
                        IDLogin = DataHelper.IfDBNull<int>(row["ID_login"], 0),
                        Iduser = DataHelper.IfDBNull<Guid>(row["iduser"], new Guid()),
                        Dataloglogin = DataHelper.IfDBNull<DateTime>(row["dataloglogin"], DateTime.Now),
                        Tipologlogin = DataHelper.IfDBNull<string>(row["tipologlogin"], _stringEmpty),
                        UIDsession = DataHelper.IfDBNull<string>(row["UIDsession"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        public List<ILog> SelectLogAtt(string logatt, Guid UserId, Guid uidintervento)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(logatt)) condWhere += " and EF_logattivita.chiave like '%' + @logatt + '%' ";
            if (UserId != new Guid("00000000-0000-0000-0000-000000000000")) condWhere += " and EF_logattivita.iduser = @UserId ";
            if (uidintervento != new Guid("00000000-0000-0000-0000-000000000000")) condWhere += " and EF_logattivita.uidintervento = @uidintervento ";

            List<ILog> retVal = new List<ILog>();
            string sql = "SELECT EF_logattivita.idlogattivita, EF_logattivita.chiave, EF_logattivita.datains, EF_users.nomeuser, EF_users.cognomeuser FROM EF_logattivita ";
            sql += " INNER JOIN EF_users ON EF_logattivita.iduser = EF_users.UserId WHERE EF_logattivita.idlogattivita > 0 " + condWhere + " ORDER BY datains DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(logatt))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@logatt", DbType.String);
                param0.Value = logatt;
                collParams.Add(param0);
            }

            if (UserId != new Guid("00000000-0000-0000-0000-000000000000"))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }

            if (uidintervento != new Guid("00000000-0000-0000-0000-000000000000"))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@uidintervento", DbType.Guid);
                param3.Value = uidintervento;
                collParams.Add(param3);
            }

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ILog item = new Log
                    {
                        Idlogattivita = DataHelper.IfDBNull<int>(row["idlogattivita"], 0),
                        Operatore = DataHelper.IfDBNull<string>(row["nomeuser"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["cognomeuser"], _stringEmpty),
                        Datains = DataHelper.IfDBNull<DateTime>(row["datains"], DateTime.Now),
                        Chiave = DataHelper.IfDBNull<string>(row["chiave"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountLogAtt(string logatt, Guid UserId, Guid uidintervento)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(logatt)) condWhere += " and EF_logattivita.chiave like '%' + @logatt + '%' ";
            if (UserId != new Guid("00000000-0000-0000-0000-000000000000")) condWhere += " and EF_logattivita.iduser = @UserId ";
            if (uidintervento != new Guid("00000000-0000-0000-0000-000000000000")) condWhere += " and EF_logattivita.uidintervento = @uidintervento ";

            string sql = "SELECT COUNT(*) as tot FROM EF_logattivita ";
            sql += " INNER JOIN EF_users ON EF_logattivita.iduser = EF_users.UserId WHERE EF_logattivita.idlogattivita > 0 " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(logatt))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@logatt", DbType.String);
                param0.Value = logatt;
                collParams.Add(param0);
            }

            if (UserId != new Guid("00000000-0000-0000-0000-000000000000"))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }

            if (uidintervento != new Guid("00000000-0000-0000-0000-000000000000"))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@uidintervento", DbType.Guid);
                param3.Value = uidintervento;
                collParams.Add(param3);
            }

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }


        public List<ILog> SelectLogOperatore(Guid iduser, Guid uidintervento)
        {
            List<ILog> retVal = new List<ILog>();
            string sql = "SELECT TOP 5 chiave, datains, EF_users.nomeuser, EF_users.cognomeuser, REPLACE(idattivita, '/Admin/Modules/', '') idattivita, ED_intervento.CodPratica FROM EF_logattivita ";
            sql += " INNER JOIN EF_users ON EF_logattivita.iduser = EF_users.UserId LEFT JOIN ED_intervento ON EF_logattivita.uidintervento = ED_intervento.UIDintervento ";
            sql += " WHERE EF_logattivita.iduser = @iduser and EF_logattivita.uidintervento = @uidintervento and chiave not like '%view%' ORDER BY datains DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();
            
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@iduser", DbType.Guid);
            param0.Value = iduser;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@uidintervento", DbType.Guid);
            param1.Value = uidintervento;
            collParams.Add(param1);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ILog item = new Log
                    {
                        Operatore = DataHelper.IfDBNull<string>(row["nomeuser"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["cognomeuser"], _stringEmpty),
                        Datains = DataHelper.IfDBNull<DateTime>(row["datains"], DateTime.Now),
                        Idattivita = DataHelper.IfDBNull<string>(row["idattivita"], _stringEmpty),
                        Chiave = DataHelper.IfDBNull<string>(row["chiave"], _stringEmpty),
                        CodPratica = DataHelper.IfDBNull<string>(row["codpratica"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
    }
}