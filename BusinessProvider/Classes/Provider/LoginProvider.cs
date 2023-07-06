// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CLoginProvider.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Permissions;
using System.Data;
using System.Web;
using System.Web.Security;
using MultiDataConnection;
using BusinessObject;
using BaseProvider;
using DataProvider;

namespace BusinessProvider
{
    [SectionName("login.provider/LoginSection")]
    public class LoginProvider : DFleetDataProvider, ILoginProvider
    {
        public bool ExistUser(string emailuser)
        {
            bool retVal = false;
            string sql = "SELECT email FROM EF_users WHERE email = @emailuser";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@emailuser", DbType.String);
            param0.Value = emailuser;
            collParams.Add(param0);
            string data = _dataHelper.GetValue<string>(sql, collParams).Data;
            if (!string.IsNullOrEmpty(data))
            {
                retVal = true;
            }

            return retVal;
        }
        public IAccount Detail(string emailuser)
        {
            IAccount retVal = null;
            string sql = "SELECT * FROM EF_users WHERE email = @emailuser";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@emailuser", DbType.String);
            param0.Value = emailuser;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                    Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                    Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                    Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                    Idstatususer = DataHelper.IfDBNull<int>(row["idstatususer"], 0),
                    Codicefiscale = DataHelper.IfDBNull<string>(row["codicefiscale"], _stringEmpty),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Uidtenant = DataHelper.IfDBNull<Guid>(row["uidtenant"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IAccount DetailId(Guid UserId)
        {
            IAccount retVal = null;
            string sql = "SELECT * FROM EF_users WHERE UserId = @UserId";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                    Idgruppouser = DataHelper.IfDBNull<int>(row["idgruppouser"], 0),
                    Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                    Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                    Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                    Idstatususer = DataHelper.IfDBNull<int>(row["idstatususer"], 0),
                    Flgadmin = DataHelper.IfDBNull<int>(row["flgadmin"], 0),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Uidtenant = DataHelper.IfDBNull<Guid>(row["uidtenant"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateDataInvioMail(IAccount value)
        {
            int retVal = 0;

            string sql = "UPDATE EF_users SET [datainviomail] = @datainviomail WHERE UserId = @UserId AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@datainviomail", DbType.DateTime);
            param0.Value = DateTime.Now;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Int32);
            param1.Value = value.UserId;
            collParams.Add(param1);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
    }

}