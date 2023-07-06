// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CUtilityProvider.cs" company="">
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
using Microsoft.SqlServer.Server;
using BusinessObject.Classes;
using System.Globalization;

namespace BusinessProvider
{

    [SectionName("utilitys.provider/UtilitysSection")]
    public class UtilitysProvider : DFleetDataProvider, IUtilitysProvider
    {

        //aggiorna societa
        public int UpdateSocieta(IUtilitys value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_societa SET [codsocieta] = @codsocieta, [codcompany] = @codcompany, [siglasocieta] = @siglasocieta, [societa] = @societa, [servicearea] = @servicearea, " +
                         " [partitaiva] = @partitaiva, [codicecdc] = @codicecdc, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@codcompany", DbType.String);
            param10.Value = value.Codcompany;
            collParams.Add(param10);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@siglasocieta", DbType.String);
            param1.Value = value.Siglasocieta;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@societa", DbType.String);
            param2.Value = value.Societa;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@servicearea", DbType.String);
            param3.Value = value.Servicearea;
            collParams.Add(param3);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@partitaiva", DbType.String);
            param7.Value = value.Partitaiva;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@codicecdc", DbType.String);
            param8.Value = value.Codicecdc;
            collParams.Add(param8);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param4.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param6.Value = value.Uid;
            collParams.Add(param6);

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


        //cancella societa
        public int DeleteSocieta(IUtilitys value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_societa WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = value.Uid;
            collParams.Add(paramID);

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

        //inserimento nuova societa
        public int InsertSocieta(IUtilitys value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_societa ([codsocieta], [codcompany], [siglasocieta], [societa], [servicearea], [partitaiva], [codicecdc], [datauserins], [UserIDIns], [datausermod], [UserIdMod],[uidtenant]) " +
                         " VALUES (@codsocieta, @codcompany, @siglasocieta, @societa, @servicearea, @partitaiva, @codicecdc, @datauserins, @UserIDIns, @datausermod, @UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@codcompany", DbType.String);
            param10.Value = value.Codcompany;
            collParams.Add(param10);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@siglasocieta", DbType.String);
            param1.Value = value.Siglasocieta;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@societa", DbType.String);
            param2.Value = value.Societa;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@servicearea", DbType.String);
            param3.Value = value.Servicearea;
            collParams.Add(param3);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@partitaiva", DbType.String);
            param8.Value = value.Partitaiva;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@codicecdc", DbType.String);
            param9.Value = value.Codicecdc;
            collParams.Add(param9);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param4.Value = DateTime.Now;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param5.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param7.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param7);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli societa
        public IUtilitys DetailSocietaId(Guid Uid)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_societa WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Codcompany = DataHelper.IfDBNull<string>(row["codcompany"], _stringEmpty),
                    Siglasocieta = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                    Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                    Partitaiva = DataHelper.IfDBNull<string>(row["partitaiva"], _stringEmpty),
                    Codicecdc = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty),
                    Servicearea = DataHelper.IfDBNull<string>(row["servicearea"], _stringEmpty),
                    Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                    Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                    UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                    UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }

        public IUtilitys DetailSocietaXCodS(string codsocieta)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_societa WHERE codsocieta = @codsocieta";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = codsocieta;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Codcompany = DataHelper.IfDBNull<string>(row["codcompany"], _stringEmpty),
                    Siglasocieta = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                    Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                    Partitaiva = DataHelper.IfDBNull<string>(row["partitaiva"], _stringEmpty),
                    Codicecdc = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty),
                    Servicearea = DataHelper.IfDBNull<string>(row["servicearea"], _stringEmpty),
                    Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                    Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                    UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                    UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }


        //conta societa - FILTRO: keysearch
        public int SelectCountSocieta(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codsocieta like '%' + @keysearch + '%' or siglasocieta like '%' + @keysearch + '%' or societa  like '%' + @keysearch + '%') ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_societa WHERE uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista societa
        // FILTRO: keysearch
        public List<IUtilitys> SelectSocieta(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            string condWhere = "";
            string orderby;
            string paginazione;

            if (!string.IsNullOrEmpty(ordine))
            {
                orderby = ordine + " " + tipoordine;
            }
            else
            {
                orderby = " societa ";
            }
            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codsocieta like '%' + @keysearch + '%' or codcompany like '%' + @keysearch + '%' or siglasocieta like '%' + @keysearch + '%' or societa  like '%' + @keysearch + '%') ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = "SELECT * FROM EF_societa WHERE uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Codcompany = DataHelper.IfDBNull<string>(row["codcompany"], _stringEmpty),
                        Siglasocieta = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Servicearea = DataHelper.IfDBNull<string>(row["servicearea"], _stringEmpty),
                        Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                        Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                        UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                        UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectAllSocieta(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT partitaiva, societa, codsocieta, siglasocieta FROM EF_societa WHERE uidtenant = @Uidtenant ORDER BY societa ";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Partitaiva = DataHelper.IfDBNull<string>(row["partitaiva"], _stringEmpty),
                        Siglasocieta = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        //aggiorna conti
        public int UpdateConti(IUtilitys value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_conti SET [codconto] = @codconto, [codsocieta] = @codsocieta, [servicearea] = @servicearea, [descrizioneconto] = @descrizioneconto, " +
                         " [annotazioni] = @annotazioni, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codconto", DbType.String);
            param0.Value = value.Codconto;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param1.Value = value.Codsocieta;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@servicearea", DbType.String);
            param2.Value = value.Servicearea;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@descrizioneconto", DbType.String);
            param3.Value = value.Descrizioneconto;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@annotazioni", DbType.String);
            param4.Value = value.Annotazioni;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param5.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param7.Value = value.Uid;
            collParams.Add(param7);

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


        //cancella conti

        public int DeleteConti(IUtilitys value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_conti WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = value.Uid;
            collParams.Add(paramID);

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

        //inserimento nuovo conto

        public int InsertConti(IUtilitys value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_conti ([codconto], [codsocieta], [servicearea], [descrizioneconto], [annotazioni], [datauserins], [UserIDIns], [datausermod], [UserIdMod],[uidtenant]) " +
                         " VALUES (@codconto, @codsocieta, @servicearea, @descrizioneconto, @annotazioni, @datauserins, @UserIDIns, @datausermod, @UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codconto", DbType.String);
            param0.Value = value.Codconto;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param1.Value = value.Codsocieta;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@servicearea", DbType.String);
            param2.Value = value.Servicearea;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@descrizioneconto", DbType.String);
            param3.Value = value.Descrizioneconto;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@annotazioni", DbType.String);
            param4.Value = value.Annotazioni;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param6.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param7.Value = DateTime.Now;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param8.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param8); 
            
            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli conto

        public IUtilitys DetailContiId(Guid Uid)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_conti WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Codconto = DataHelper.IfDBNull<string>(row["codconto"], _stringEmpty),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Servicearea = DataHelper.IfDBNull<string>(row["servicearea"], _stringEmpty),
                    Descrizioneconto = DataHelper.IfDBNull<string>(row["descrizioneconto"], _stringEmpty),
                    Annotazioni = DataHelper.IfDBNull<string>(row["annotazioni"], _stringEmpty),
                    Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                    Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                    UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                    UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }


        //conta conti - FILTRO: keysearch
        public int SelectCountConti(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codconto like '%' + @keysearch + '%' or descrizioneconto like '%' + @keysearch + '%') ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_conti WHERE uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista conti
        // FILTRO: keysearch
        public List<IUtilitys> SelectConti(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            string condWhere = "";
            string orderby;
            string paginazione;

            if (!string.IsNullOrEmpty(ordine))
            {
                orderby = ordine + " " + tipoordine;
            }
            else
            {
                orderby = " codconto ";
            }
            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codconto like '%' + @keysearch + '%' or descrizioneconto like '%' + @keysearch + '%') ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = "SELECT * FROM EF_conti WHERE uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Codconto = DataHelper.IfDBNull<string>(row["codconto"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Servicearea = DataHelper.IfDBNull<string>(row["servicearea"], _stringEmpty),
                        Descrizioneconto = DataHelper.IfDBNull<string>(row["descrizioneconto"], _stringEmpty),
                        Annotazioni = DataHelper.IfDBNull<string>(row["annotazioni"], _stringEmpty),
                        Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                        Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                        UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                        UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectAllConti()
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT codconto FROM EF_conti ORDER BY codconto ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Codconto = DataHelper.IfDBNull<string>(row["codconto"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        //aggiorna fornitori
        public int UpdateFornitori(IUtilitys value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_fornitori SET [codfornitore] = @codfornitore, [fornitore] = @fornitore, " +
                         " [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param0.Value = value.Codfornitore;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@fornitore", DbType.String);
            param1.Value = value.Fornitore;
            collParams.Add(param1);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param5.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param7.Value = value.Uid;
            collParams.Add(param7);

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


        //cancella fornitori

        public int DeleteFornitori(IUtilitys value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_fornitori WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = value.Uid;
            collParams.Add(paramID); 
            
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

        //inserimento nuovo fornitore

        public int InsertFornitori(IUtilitys value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_fornitori ([codfornitore], [fornitore], [datauserins], [UserIDIns], [datausermod], [UserIdMod],[uidtenant]) " +
                         " VALUES (@codfornitore, @fornitore, @datauserins, @UserIDIns, @datausermod, @UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param0.Value = value.Codfornitore;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@fornitore", DbType.String);
            param1.Value = value.Fornitore;
            collParams.Add(param1);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param6.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param7.Value = DateTime.Now;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param8.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param8);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli fornitore

        public IUtilitys DetailFornitoriId(Guid Uid)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_fornitori WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                    Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                    Codicecdc = DataHelper.IfDBNull<string>(row["centrodicosto"], _stringEmpty),
                    Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                    Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                    UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                    UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys DetailFornitoriCod(string codfornitore)
        {
            IUtilitys retVal = null;
            string sql = "SELECT fornitore FROM EF_fornitori WHERE codfornitore = @codfornitore";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param0.Value = codfornitore;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys DetailFornitoriPIva(string partitaiva)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_fornitori WHERE partitaiva = @partitaiva";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@partitaiva", DbType.String);
            param0.Value = partitaiva;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                    Codicecdc = DataHelper.IfDBNull<string>(row["centrodicosto"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }

        //conta fornitori - FILTRO: keysearch
        public int SelectCountFornitori(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codfornitore like '%' + @keysearch + '%' or fornitore like '%' + @keysearch + '%') ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_fornitori WHERE uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista fornitori
        // FILTRO: keysearch
        public List<IUtilitys> SelectFornitori(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            string condWhere = "";
            string orderby;
            string paginazione;

            if (!string.IsNullOrEmpty(ordine))
            {
                orderby = ordine + " " + tipoordine;
            }
            else
            {
                orderby = " fornitore ";
            }
            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codfornitore like '%' + @keysearch + '%' or fornitore like '%' + @keysearch + '%') ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = "SELECT * FROM EF_fornitori WHERE uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                        Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                        Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                        UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                        UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectAllFornitori(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT partitaiva, codfornitore, fornitore FROM EF_fornitori WHERE uidtenant = @Uidtenant ORDER BY codfornitore ";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                        Partitaiva = DataHelper.IfDBNull<string>(row["partitaiva"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        //aggiorna fuelcard
        public int UpdateFuelCard(IUtilitys value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_fuelcard SET [codfuelcard] = @codfuelcard, [fuelcard] = @fuelcard, [valorefuelcard] = @valorefuelcard, " +
                         " [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codfuelcard", DbType.String);
            param0.Value = value.Codfuelcard;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@fuelcard", DbType.String);
            param1.Value = value.Fuelcard;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@valorefuelcard", DbType.Decimal);
            param2.Value = value.Valorefuelcard;
            collParams.Add(param2);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param5.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param7.Value = value.Uid;
            collParams.Add(param7);

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


        //cancella fuelcard

        public int DeleteFuelCard(IUtilitys value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_fuelcard WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = value.Uid;
            collParams.Add(paramID);

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

        //inserimento nuovo fuelcard

        public int InsertFuelCard(IUtilitys value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_fuelcard ([codfuelcard], [fuelcard], [valorefuelcard], [datauserins], [UserIDIns], [datausermod], [UserIdMod],[uidtenant]) " +
                         " VALUES (@codfuelcard, @fuelcard, @valorefuelcard, @datauserins, @UserIDIns, @datausermod, @UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codfuelcard", DbType.String);
            param0.Value = value.Codfuelcard;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@fuelcard", DbType.String);
            param1.Value = value.Fuelcard;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@valorefuelcard", DbType.Decimal);
            param2.Value = value.Valorefuelcard;
            collParams.Add(param2);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param6.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param7.Value = DateTime.Now;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param8.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param8);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli fuelcard

        public IUtilitys DetailFuelCardId(Guid Uid)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_fuelcard WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Codfuelcard = DataHelper.IfDBNull<string>(row["codfuelcard"], _stringEmpty),
                    Fuelcard = DataHelper.IfDBNull<string>(row["fuelcard"], _stringEmpty),
                    Valorefuelcard = DataHelper.IfDBNull<decimal>(row["valorefuelcard"], 0),
                    Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                    Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                    UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                    UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }


        //conta fuelcard - FILTRO: keysearch
        public int SelectCountFuelCard(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codfuelcard like '%' + @keysearch + '%' or fuelcard like '%' + @keysearch + '%') ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_fuelcard WHERE uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista fuelcard
        // FILTRO: keysearch
        public List<IUtilitys> SelectFuelCard(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            string condWhere = "";
            string orderby;
            string paginazione;

            if (!string.IsNullOrEmpty(ordine))
            {
                orderby = ordine + " " + tipoordine;
            }
            else
            {
                orderby = " fuelcard ";
            }
            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codfuelcard like '%' + @keysearch + '%' or fuelcard like '%' + @keysearch + '%') ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = "SELECT * FROM EF_fuelcard WHERE uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Codfuelcard = DataHelper.IfDBNull<string>(row["codfuelcard"], _stringEmpty),
                        Fuelcard = DataHelper.IfDBNull<string>(row["fuelcard"], _stringEmpty),
                        Valorefuelcard = DataHelper.IfDBNull<decimal>(row["valorefuelcard"], 0),
                        Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                        Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                        UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                        UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectAllFuelCard(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT codfuelcard, fuelcard FROM EF_fuelcard WHERE uidtenant = @Uidtenant ORDER BY codfuelcard ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Codfuelcard = DataHelper.IfDBNull<string>(row["codfuelcard"], _stringEmpty),
                        Fuelcard = DataHelper.IfDBNull<string>(row["fuelcard"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }




        //aggiorna grade
        public int UpdateGrade(IUtilitys value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_grade SET [codgrade] = @codgrade, [grade] = @grade, " +
                         " [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
            param0.Value = value.Codgrade;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@grade", DbType.String);
            param1.Value = value.Grade;
            collParams.Add(param1);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param5.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param7.Value = value.Uid;
            collParams.Add(param7);

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


        //cancella grade

        public int DeleteGrade(IUtilitys value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_grade WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = value.Uid;
            collParams.Add(paramID);

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

        //inserimento nuovo grade

        public int InsertGrade(IUtilitys value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_grade ([codgrade], [grade], [datauserins], [UserIDIns], [datausermod], [UserIdMod],[uidtenant]) " +
                         " VALUES (@codgrade, @grade, @datauserins, @UserIDIns, @datausermod, @UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
            param0.Value = value.Codgrade;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@grade", DbType.String);
            param1.Value = value.Grade;
            collParams.Add(param1);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param6.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param7.Value = DateTime.Now;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param8.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param8);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli grade

        public IUtilitys DetailGradeId(Guid Uid)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_grade WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Codgrade = DataHelper.IfDBNull<string>(row["codgrade"], _stringEmpty),
                    Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                    Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                    Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                    UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                    UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys ReturnGradeXCod(string codgrade)
        {
            IUtilitys retVal = null;
            string sql = "SELECT grade FROM EF_grade WHERE codgrade = @codgrade";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
            param0.Value = codgrade;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }


        //conta grade - FILTRO: keysearch
        public int SelectCountGrade(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codgrade like '%' + @keysearch + '%' or grade like '%' + @keysearch + '%') ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_grade WHERE uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista grade
        // FILTRO: keysearch
        public List<IUtilitys> SelectGrade(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            string condWhere = "";
            string orderby;
            string paginazione;

            if (!string.IsNullOrEmpty(ordine))
            {
                orderby = ordine + " " + tipoordine;
            }
            else
            {
                orderby = " grade ";
            }
            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codgrade like '%' + @keysearch + '%' or grade like '%' + @keysearch + '%') ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = "SELECT * FROM EF_grade WHERE uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Codgrade = DataHelper.IfDBNull<string>(row["codgrade"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                        Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                        UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                        UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectAllGrade(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT codgrade, grade FROM EF_grade WHERE uidtenant = @Uidtenant and codgrade<>'0' ORDER BY codgrade ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Codgrade = DataHelper.IfDBNull<string>(row["codgrade"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        //aggiorna persontype
        public int UpdatePersonType(IUtilitys value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_persontype SET [codpersontype] = @codpersontype, [persontype] = @persontype, " +
                         " [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codpersontype", DbType.String);
            param0.Value = value.Codpersontype;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@persontype", DbType.String);
            param1.Value = value.Persontype;
            collParams.Add(param1);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param5.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param7.Value = value.Uid;
            collParams.Add(param7);

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


        //cancella persontype

        public int DeletePersonType(IUtilitys value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_persontype WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = value.Uid;
            collParams.Add(paramID);

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

        //inserimento nuovo persontype

        public int InsertPersonType(IUtilitys value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_persontype ([codpersontype], [persontype], [datauserins], [UserIDIns], [datausermod], [UserIdMod],[uidtenant]) " +
                         " VALUES (@codpersontype, @persontype, @datauserins, @UserIDIns, @datausermod, @UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codpersontype", DbType.String);
            param0.Value = value.Codpersontype;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@persontype", DbType.String);
            param1.Value = value.Persontype;
            collParams.Add(param1);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param6.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param7.Value = DateTime.Now;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param8.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param8);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli persontype

        public IUtilitys DetailPersonTypeId(Guid Uid)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_persontype WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Codpersontype = DataHelper.IfDBNull<string>(row["codpersontype"], _stringEmpty),
                    Persontype = DataHelper.IfDBNull<string>(row["persontype"], _stringEmpty),
                    Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                    Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                    UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                    UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }


        //conta persontype - FILTRO: keysearch
        public int SelectCountPersonType(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codpersontype like '%' + @keysearch + '%' or persontype like '%' + @keysearch + '%') ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_persontype WHERE uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista persontype
        // FILTRO: keysearch
        public List<IUtilitys> SelectPersonType(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            string condWhere = "";
            string orderby;
            string paginazione;

            if (!string.IsNullOrEmpty(ordine))
            {
                orderby = ordine + " " + tipoordine;
            }
            else
            {
                orderby = " persontype ";
            }
            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codpersontype like '%' + @keysearch + '%' or persontype like '%' + @keysearch + '%') ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = "SELECT * FROM EF_persontype WHERE uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Codpersontype = DataHelper.IfDBNull<string>(row["codpersontype"], _stringEmpty),
                        Persontype = DataHelper.IfDBNull<string>(row["persontype"], _stringEmpty),
                        Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                        Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                        UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                        UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectAllPersonType()
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT codpersontype, persontype FROM EF_persontype ORDER BY codpersontype ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Codpersontype = DataHelper.IfDBNull<string>(row["codpersontype"], _stringEmpty),
                        Persontype = DataHelper.IfDBNull<string>(row["persontype"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //dettagli template email
        public IUtilitys ReturnTemplateEmail(int idtemplate)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_email_template WHERE idtemplate = @idtemplate";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idtemplate", DbType.Int32);
            param0.Value = idtemplate;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Idtemplate = DataHelper.IfDBNull<int>(row["idtemplate"], 0),
                    Titolo = DataHelper.IfDBNull<string>(row["titolo"], _stringEmpty),
                    Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty),
                    Corpo = DataHelper.IfDBNull<string>(row["corpo"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }

        //inserimento comunicazione email
        public int InsertComunicazioneEmail(IUtilitys value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_comunicazioni_email ([mittente],[UserId],[oggetto],[tipocomunicazione],[idstatuscomunicazione],[datainvio],[testo],[uidtenant] ) " +
                         " VALUES (@mittente, @UserId, @oggetto, @tipocomunicazione, @idstatuscomunicazione,@datainvio,@testo,@uidtenant) ";


            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@mittente", DbType.String);
            param0.Value = value.Mittente;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@oggetto", DbType.String);
            param1.Value = value.Oggetto;
            collParams.Add(param1);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param5.Value = value.UserId;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@tipocomunicazione", DbType.String);
            param6.Value = value.Tipocomunicazione;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscomunicazione", DbType.Int32);
            param7.Value = value.Idstatuscomunicazione;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@datainvio", DbType.DateTime);
            param8.Value = value.Datainvio;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@testo", DbType.String);
            param9.Value = value.Testotask;
            collParams.Add(param9);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //conta template email - FILTRO: keysearch
        public int SelectCountTemplateEmail(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (titolo like '%' + @keysearch + '%' or oggetto like '%' + @keysearch + '%') ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_email_template WHERE uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista template email
        // FILTRO: keysearch
        public List<IUtilitys> SelectTemplateEmail(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (titolo like '%' + @keysearch + '%' or oggetto like '%' + @keysearch + '%') ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = "SELECT * FROM EF_email_template WHERE uidtenant = @Uidtenant " + condWhere + " ORDER BY titolo ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Titolo = DataHelper.IfDBNull<string>(row["titolo"], _stringEmpty),
                        Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty),
                        Idtemplate = DataHelper.IfDBNull<int>(row["idtemplate"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //aggiorna template email
        public int UpdateTemplateEmail(IUtilitys value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_email_template SET [titolo] = @titolo, [oggetto] = @oggetto, [corpo] = @corpo WHERE idtemplate = @idtemplate AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@titolo", DbType.String);
            param0.Value = value.Titolo;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@oggetto", DbType.String);
            param1.Value = value.Oggetto;
            collParams.Add(param1);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@corpo", DbType.String);
            param5.Value = value.Corpo;
            collParams.Add(param5);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@idtemplate", DbType.Int32);
            param7.Value = value.Idtemplate;
            collParams.Add(param7);

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


        //conta documenti - FILTRO: keysearch, datadal, dataal
        public int SelectCountDocumenti(string keysearch, DateTime datadal, DateTime dataal, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND nomefile like '%' + @keysearch + '%' ";
            if (datadal > DateTime.MinValue) condWhere += " AND data >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND data <= @dataal";

            string SQL = "SELECT COUNT(*) as tot FROM EF_cron_file WHERE idcron > 0 AND uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param2.Value = datadal;
                collParams.Add(param2);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param3.Value = dataal;
                collParams.Add(param3);
            }
            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param4.Value = Uidtenant;
            collParams.Add(param4);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista societa
        // FILTRO: keysearch, datadal, dataal
        public List<IUtilitys> SelectDocumenti(string keysearch, DateTime datadal, DateTime dataal, Guid Uidtenant, int numrecord, int pagina)
        {
            string condWhere = "";
            string paginazione;

            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND nomefile like '%' + @keysearch + '%' ";
            if (datadal > DateTime.MinValue) condWhere += " AND data >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND data <= @dataal";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = "SELECT * FROM EF_cron_file WHERE idcron > 0 AND uidtenant = @Uidtenant " + condWhere + " ORDER BY data DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param2.Value = datadal;
                collParams.Add(param2);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param3.Value = dataal;
                collParams.Add(param3);
            }
            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param4.Value = Uidtenant;
            collParams.Add(param4);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Data = DataHelper.IfDBNull<DateTime>(row["data"], DateTime.MinValue),
                        Tipodocumento = DataHelper.IfDBNull<string>(row["tipodocumento"], _stringEmpty),
                        Pathfile = DataHelper.IfDBNull<string>(row["pathfile"], _stringEmpty),
                        Nomefile = DataHelper.IfDBNull<string>(row["nomefile"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        
        // lista attivita (pagine)
        public List<IUtilitys> SelectAllAttivita()
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM EF_pagine ORDER BY pagina ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Pagina = DataHelper.IfDBNull<string>(row["pagina"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["codgruppopagina"], _stringEmpty) + ")",
                        Idpagina = DataHelper.IfDBNull<int>(row["idpagina"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //aggiorna documento
        public int UpdateDocumento(IUtilitys value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_documenti SET [idcatdoc] = @idcatdoc, [nomedocumento] = @nomedocumento, [filedocumento] = @filedocumento, " +
                         " [codsocieta] = @codsocieta, [codgrade] = @codgrade, [codcarpolicy] = @codcarpolicy, [visibiledal] = @visibiledal, [visibileal] = @visibileal, " +
                         " [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idcatdoc", DbType.Int32);
            param0.Value = value.Idcatdoc;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@nomedocumento", DbType.String);
            param1.Value = value.Nomedocumento;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@filedocumento", DbType.String);
            param2.Value = value.Filedocumento;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param3.Value = value.Codsocieta;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
            param4.Value = value.Codgrade;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param5.Value = value.Codcarpolicy;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param6.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param7.Value = DateTime.Now;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param8.Value = value.Uid;
            collParams.Add(param8);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@visibiledal", DbType.DateTime);
            param10.Value = value.Visibiledal;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@visibileal", DbType.DateTime);
            param11.Value = value.Visibileal;
            collParams.Add(param11);

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


        //cancella documento
        public int DeleteDocumento(IUtilitys value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_documenti WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = value.Uid;
            collParams.Add(paramID);

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

        //inserimento nuovo documento
        public int InsertDocumento(IUtilitys value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_documenti ([idcatdoc],[nomedocumento],[filedocumento],[codsocieta],[codgrade],[codcarpolicy],[visibiledal],[visibileal], " +
                         " [datauserins], [UserIDIns], [datausermod], [UserIdMod],[uidtenant]) " +
                         " VALUES (@idcatdoc, @nomedocumento, @filedocumento, @codsocieta, @codgrade, @codcarpolicy, @visibiledal, @visibileal, " +
                         " @datauserins, @UserIDIns, @datausermod, @UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idcatdoc", DbType.Int32);
            param0.Value = value.Idcatdoc;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@nomedocumento", DbType.String);
            param1.Value = value.Nomedocumento;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@filedocumento", DbType.String);
            param2.Value = value.Filedocumento;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param3.Value = value.Codsocieta;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
            param4.Value = value.Codgrade;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param5.Value = value.Codcarpolicy;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param7.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param8.Value = DateTime.Now;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param9.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@visibiledal", DbType.DateTime);
            param10.Value = value.Visibiledal;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@visibileal", DbType.DateTime);
            param11.Value = value.Visibileal;
            collParams.Add(param11);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli documento
        public IUtilitys DetailDocumentoId(Guid Uid)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_documenti WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Idcatdoc = DataHelper.IfDBNull<int>(row["idcatdoc"], 0),
                    Nomedocumento = DataHelper.IfDBNull<string>(row["nomedocumento"], _stringEmpty),
                    Filedocumento = DataHelper.IfDBNull<string>(row["filedocumento"], _stringEmpty),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Codgrade = DataHelper.IfDBNull<string>(row["codgrade"], _stringEmpty),
                    Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                    Visibiledal = DataHelper.IfDBNull<DateTime>(row["visibiledal"], DateTime.Now),
                    Visibileal = DataHelper.IfDBNull<DateTime>(row["visibileal"], DateTime.Now),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }


        //conta documenti - FILTRO: keysearch, idcategoria
        public int SelectCountDocumenti(string keysearch, int idcategoria, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (d.nomedocumento like '%' + @keysearch + '%' or d.filedocumento like '%' + @keysearch + '%') ";
            if (idcategoria > 0) condWhere += " AND d.idcatdoc = @idcategoria ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_documenti as d " +
                         " LEFT JOIN EF_documenti_categorie as c ON d.idcatdoc = c.idcatdoc AND c.uidtenant = d.uidtenant " +
                         " WHERE d.iddoc > 0 AND d.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }

            if (idcategoria > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idcategoria", DbType.Int32);
                param1.Value = idcategoria;
                collParams.Add(param1);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista documenti
        // FILTRO: keysearch, idcategoria
        public List<IUtilitys> SelectDocumenti(string keysearch, int idcategoria, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            string condWhere = "";
            string orderby;
            string paginazione;

            if (!string.IsNullOrEmpty(ordine))
            {
                orderby = ordine + " " + tipoordine;
            }
            else
            {
                orderby = " d.nomedocumento ";
            }
            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (d.nomedocumento like '%' + @keysearch + '%' or d.filedocumento like '%' + @keysearch + '%') ";
            if (idcategoria > 0) condWhere += " AND d.idcatdoc = @idcategoria ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = " SELECT * FROM EF_documenti as d " +
                         " LEFT JOIN EF_documenti_categorie as c ON d.idcatdoc = c.idcatdoc AND c.uidtenant = d.uidtenant " +
                         " WHERE d.iddoc > 0 AND d.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }

            if (idcategoria > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idcategoria", DbType.Int32);
                param1.Value = idcategoria;
                collParams.Add(param1);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Categoriadocumento = DataHelper.IfDBNull<string>(row["categoriadocumento"], _stringEmpty),
                        Nomedocumento = DataHelper.IfDBNull<string>(row["nomedocumento"], _stringEmpty),
                        Filedocumento = DataHelper.IfDBNull<string>(row["filedocumento"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Codgrade = DataHelper.IfDBNull<string>(row["codgrade"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Visibiledal = DataHelper.IfDBNull<DateTime>(row["visibiledal"], DateTime.Now),
                        Visibileal = DataHelper.IfDBNull<DateTime>(row["visibileal"], DateTime.Now),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectAllCatDoc(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM EF_documenti_categorie WHERE uidtenant = @Uidtenant ORDER BY idcatdoc, categoriadocumento ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Idcatdoc = DataHelper.IfDBNull<int>(row["idcatdoc"], 0),
                        Categoriadocumento = DataHelper.IfDBNull<string>(row["categoriadocumento"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDocumentiXUser(int idcategoria, string codsocieta, string codgrade, string codcarpolicy)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");
            string condWhere = "";

            if (!string.IsNullOrEmpty(codsocieta)) condWhere = " AND (codsocieta = @codsocieta OR codsocieta = '' OR codsocieta is null) ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere = " AND (codgrade = @codgrade OR codgrade = '' OR codgrade is null) ";
            if (!string.IsNullOrEmpty(codcarpolicy)) condWhere = " AND (codcarpolicy = @codcarpolicy OR codcarpolicy = '' OR codcarpolicy is null) ";

            if (!string.IsNullOrEmpty(codsocieta) && !string.IsNullOrEmpty(codgrade)) condWhere = " AND (codsocieta = @codsocieta OR codsocieta = '' OR codsocieta is null) AND (codgrade = @codgrade OR codgrade = '' OR codgrade is null) ";
            if (!string.IsNullOrEmpty(codsocieta) && !string.IsNullOrEmpty(codcarpolicy)) condWhere = " AND (codsocieta = @codsocieta OR codsocieta = '' OR codsocieta is null) AND (codcarpolicy = @codcarpolicy OR codcarpolicy = '' OR codcarpolicy is null) ";
            if (!string.IsNullOrEmpty(codgrade) && !string.IsNullOrEmpty(codcarpolicy)) condWhere = " AND (codgrade = @codgrade OR codgrade = '' OR codgrade is null) AND (codcarpolicy = @codcarpolicy OR codcarpolicy = '' OR codcarpolicy is null) ";

            if (!string.IsNullOrEmpty(codsocieta) && !string.IsNullOrEmpty(codgrade) && !string.IsNullOrEmpty(codcarpolicy)) condWhere = " AND (codsocieta = @codsocieta OR codsocieta = '' OR codsocieta is null) AND (codgrade = @codgrade OR codgrade = '' OR codgrade is null) AND (codcarpolicy = @codcarpolicy OR codcarpolicy = '' OR codcarpolicy is null) ";


            string sql = "SELECT * FROM EF_documenti WHERE idcatdoc = @idcategoria AND visibiledal <= @dataoggi AND visibileal >= @dataoggi " + condWhere + "ORDER BY nomedocumento";

            List<IDataParameter> collParams = new List<IDataParameter>();
                       
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@idcategoria", DbType.Int32);
            param3.Value = idcategoria;
            collParams.Add(param3);

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }

            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param1.Value = codgrade;
                collParams.Add(param1);
            }

            if (!string.IsNullOrEmpty(codcarpolicy))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
                param2.Value = codcarpolicy;
                collParams.Add(param2);
            }

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.Date);
            param4.Value = dataoggi;
            collParams.Add(param4);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Nomedocumento = DataHelper.IfDBNull<string>(row["nomedocumento"], _stringEmpty),
                        Filedocumento = DataHelper.IfDBNull<string>(row["filedocumento"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        public List<IUtilitys> SelectAllReport()
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM EF_report ORDER BY nomereport ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Idreport = DataHelper.IfDBNull<int>(row["idreport"], 0),
                        Nomereport = DataHelper.IfDBNull<string>(row["nomereport"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectAllReportPartner()
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM EF_report WHERE flgpartner='SI' ORDER BY nomereport ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Idreport = DataHelper.IfDBNull<int>(row["idreport"], 0),
                        Nomereport = DataHelper.IfDBNull<string>(row["nomereport"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public IUtilitys DetailReportId(int idreport)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_report WHERE idreport = @idreport";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idreport", DbType.Int32);
            param0.Value = idreport;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Idreport = DataHelper.IfDBNull<int>(row["idreport"], 0),
                    Nomereport = DataHelper.IfDBNull<string>(row["nomereport"], _stringEmpty),
                    Viewreport = DataHelper.IfDBNull<string>(row["viewreport"], _stringEmpty),
                    Fileexcel = DataHelper.IfDBNull<string>(row["fileexcel"], _stringEmpty),
                    Filtrocodsocieta = DataHelper.IfDBNull<string>(row["filtrocodsocieta"], _stringEmpty),
                    Filtrocodgrade = DataHelper.IfDBNull<string>(row["filtrocodgrade"], _stringEmpty),
                    Filtrodriver = DataHelper.IfDBNull<string>(row["filtrodriver"], _stringEmpty),
                    Filtrocodfornitore = DataHelper.IfDBNull<string>(row["filtrocodfornitore"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> FieldReportExcel(string viewtable)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = "SELECT COLUMN_NAME as columns, DATA_TYPE as tipo FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @viewtable ";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@viewtable", DbType.String);
            param0.Value = viewtable;
            collParams.Add(param0);
            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Column = DataHelper.IfDBNull<string>(row["columns"], _stringEmpty),
                        TipoDato = DataHelper.IfDBNull<string>(row["tipo"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public DataTable ViewEstrazioneReport(string viewtable, string codsocieta, string codgrade, string codfornitore, Guid UserId, Guid Uidtenant)
        {
            string condWhere = "";

            if (!string.IsNullOrEmpty(codsocieta)) condWhere = " AND codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere = " AND codgrade = @codgrade ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere = " AND codfornitore = @codfornitore ";
            if (UserId != Guid.Empty) condWhere = " AND UserId = @UserId ";
            if (Uidtenant != new Guid("2adfc3b4-b21d-4545-8fdc-723832ac0969")) condWhere = " AND uidtenant = @Uidtenant ";

            string sql = "SELECT * FROM " + SeoHelper.EncodeString(viewtable) + " WHERE 1 = 1 " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();
                        
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@viewtable", DbType.String);
            param0.Value = viewtable;
            collParams.Add(param0);            

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param1.Value = codsocieta;
                collParams.Add(param1);
            }

            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param2.Value = codgrade;
                collParams.Add(param2);
            }

            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param3.Value = codfornitore;
                collParams.Add(param3);
            }

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param4.Value = UserId;
                collParams.Add(param4);
            }
            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param6.Value = Uidtenant;
            collParams.Add(param6);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;

            return data;
        }

        public IUtilitys DetailTaskId(Guid Uid)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_task WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Idtask = DataHelper.IfDBNull<int>(row["idtask"], 0),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Uidteam = DataHelper.IfDBNull<Guid>(row["Uidteam"], Guid.Empty),
                    Testotask = DataHelper.IfDBNull<string>(row["testotask"], _stringEmpty),
                    Datatask = DataHelper.IfDBNull<DateTime>(row["datatask"], DateTime.MinValue),
                    Esitotask = DataHelper.IfDBNull<int>(row["esitotask"], 0),
                    Linktask = DataHelper.IfDBNull<string>(row["linktask"], _stringEmpty),
                    Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                    Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                    UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                    UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }

        public int InsertTask(IUtilitys value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_task ([UserId],[Uidteam],[testotask],[datatask],[esitotask],[linktask],[datauserins],[UserIDIns],[datausermod],[UserIdMod],[uidtenant] ) " +
                         " VALUES (@UserId, @Uidteam, @testotask, @datatask, @esitotask,@linktask,@datauserins,@UserIDIns,@datausermod,@UserIdMod,@uidtenant) ";


            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = value.UserId;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@Uidteam", DbType.Guid);
            param1.Value = value.Uidteam;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@testotask", DbType.String);
            param2.Value = value.Testotask;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@datatask", DbType.DateTime);
            param3.Value = value.Datatask;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@esitotask", DbType.Int32);
            param4.Value = value.Esitotask;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@linktask", DbType.String);
            param5.Value = value.Linktask;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.DateTime);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param7.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param8.Value = DateTime.Now;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param9.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param9);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param14.Value = value.Uidtenant;
            collParams.Add(param14);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int SelectCountTaskAperti(Guid UserId, Guid Uidtenant)
        {
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");

            string SQL = " SELECT COUNT(*) as tot FROM EF_task WHERE uidtenant = @Uidtenant AND esitotask = 0 AND datatask <= @dataoggi  AND (UserId = @UserId OR Uidteam IN " +
                         " (SELECT t.Uid FROM EF_users as u INNER JOIN EF_users_team as ut ON ut.iduser = u.iduser INNER JOIN EF_team as t ON t.idteam = ut.idteam WHERE u.UserId = @UserId)) ";

            List<IDataParameter> collParams = new List<IDataParameter>();
           
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.DateTime);
            param3.Value = dataoggi;
            collParams.Add(param3);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param2.Value = Uidtenant;
            collParams.Add(param2);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public List<IUtilitys> SelectTaskAperti(Guid UserId, Guid Uidtenant)
        {
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = " SELECT * FROM EF_task WHERE uidtenant = @Uidtenant AND ((esitotask = 1 AND datatask = @dataoggi) OR (esitotask = 0 AND datatask <= @dataoggi)) AND (UserId = @UserId OR Uidteam IN " +
                         " (SELECT t.Uid FROM EF_users as u INNER JOIN EF_users_team as ut ON ut.iduser = u.iduser INNER JOIN EF_team as t ON t.idteam = ut.idteam WHERE u.UserId = @UserId)) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.DateTime);
            param3.Value = dataoggi;
            collParams.Add(param3);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param2.Value = Uidtenant;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Idtask = DataHelper.IfDBNull<int>(row["idtask"], 0),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                        Uidteam = DataHelper.IfDBNull<Guid>(row["Uidteam"], Guid.Empty),
                        Testotask = DataHelper.IfDBNull<string>(row["testotask"], _stringEmpty),
                        Datatask = DataHelper.IfDBNull<DateTime>(row["datatask"], DateTime.MinValue),
                        Esitotask = DataHelper.IfDBNull<int>(row["esitotask"], 0),
                        Linktask = DataHelper.IfDBNull<string>(row["linktask"], _stringEmpty),
                        Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                        Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                        UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                        UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateChiudiTask(Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = " UPDATE EF_task SET [esitotask] = 1, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param4.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param6.Value = Uid;
            collParams.Add(param6);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param22.Value = Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public List<IUtilitys> SelectAllTask(Guid UserId)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = " SELECT * FROM EF_task WHERE (UserId = @UserId OR Uidteam IN " +
                         " (SELECT t.Uid FROM EF_users as u INNER JOIN EF_users_team as ut ON ut.iduser = u.iduser INNER JOIN EF_team as t ON t.idteam = ut.idteam WHERE u.UserId = @UserId)) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Idtask = DataHelper.IfDBNull<int>(row["idtask"], 0),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                        Uidteam = DataHelper.IfDBNull<Guid>(row["Uidteam"], Guid.Empty),
                        Testotask = DataHelper.IfDBNull<string>(row["testotask"], _stringEmpty),
                        Datatask = DataHelper.IfDBNull<DateTime>(row["datatask"], DateTime.MinValue),
                        Esitotask = DataHelper.IfDBNull<int>(row["esitotask"], 0),
                        Linktask = DataHelper.IfDBNull<string>(row["linktask"], _stringEmpty),
                        Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                        Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                        UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                        UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys ViewDashAdmin(Guid Uidtenant)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM view_dashboard_admin WHERE uidtenant = @uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Configurazionidaautorizzare = DataHelper.IfDBNull<int>(row["configurazionidaautorizzare"], 0),
                    Offertedainviareadriver = DataHelper.IfDBNull<int>(row["offertedainviareadriver"], 0),
                    Confermedafirmare = DataHelper.IfDBNull<int>(row["confermedafirmare"], 0),
                    Richiesteautoinpool = DataHelper.IfDBNull<int>(row["richiesteautoinpool"], 0),
                    Richiesteautoinpool2 = DataHelper.IfDBNull<int>(row["richiesteautoinpool2"], 0),
                    Richiestepreassegnazioni = DataHelper.IfDBNull<int>(row["richiestepreassegnazioni"], 0),
                    Richiestevolture = DataHelper.IfDBNull<int>(row["richiestevolture"], 0),
                    Volturedaautorizzare = DataHelper.IfDBNull<int>(row["volturedaautorizzare"], 0),
                    Multedaregistrare = DataHelper.IfDBNull<int>(row["multedaregistrare"], 0),
                    Multeconpunti = DataHelper.IfDBNull<int>(row["multeconpunti"], 0),
                    Fatturedaelaborare = DataHelper.IfDBNull<int>(row["fatturedaelaborare"], 0),
                    Fringebenefitdacalcolare = DataHelper.IfDBNull<int>(row["fringebenefitdacalcolare"], 0),
                    Ticketaperti = DataHelper.IfDBNull<int>(row["ticketaperti"], 0),
                    Ticketlavorazione = DataHelper.IfDBNull<int>(row["ticketlavorazione"], 0),
                    Ticketchiusi = DataHelper.IfDBNull<int>(row["ticketchiusi"], 0),
                    Ticketcancellati = DataHelper.IfDBNull<int>(row["ticketcancellati"], 0),
                    Documentipolicydacontrollare = DataHelper.IfDBNull<int>(row["documentipolicydacontrollare"], 0),
                    Ztldafirmare = DataHelper.IfDBNull<int>(row["ztldafirmare"], 0),
                    Inoffertarenter = DataHelper.IfDBNull<int>(row["inoffertarenter"], 0),
                    Offertevalutazioneadriver = DataHelper.IfDBNull<int>(row["offertevalutazioneadriver"], 0),
                    Ordinievasione = DataHelper.IfDBNull<int>(row["ordinievasione"], 0),
                    Autoritiro = DataHelper.IfDBNull<int>(row["autoritiro"], 0),
                    Autoconsegna = DataHelper.IfDBNull<int>(row["autoconsegna"], 0),
                };
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys ViewDashOrdini(Guid Uidtenant)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM view_dashboard_ordini WHERE uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Configurazione = DataHelper.IfDBNull<int>(row["configurazione"], 0),
                    Offerte = DataHelper.IfDBNull<int>(row["offerte"], 0),
                    Approvazione = DataHelper.IfDBNull<int>(row["approvazione"], 0),
                    Conferma = DataHelper.IfDBNull<int>(row["conferma"], 0),
                    Numerodeltacanone = DataHelper.IfDBNull<int>(row["numerodeltacanone"], 0),
                    Maxdeltacanone = DataHelper.IfDBNull<decimal>(row["maxdeltacanone"], 0),
                    Mediadeltacanone = DataHelper.IfDBNull<decimal>(row["mediadeltacanone"], 0),
                    Mediafringebenefit = DataHelper.IfDBNull<decimal>(row["mediafringebenefit"], 0),
                    Maxfringebenefit = DataHelper.IfDBNull<decimal>(row["maxfringebenefit"], 0),
                    Mediaemissioni = DataHelper.IfDBNull<decimal>(row["mediaemissioni"], 0),
                    Maxemissioni = DataHelper.IfDBNull<decimal>(row["maxemissioni"], 0)

                };
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys ViewDashPEP(string codsocieta, Guid Uidtenant)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM view_dashboard_pep WHERE codsocieta = @codsocieta AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = codsocieta;
            collParams.Add(param0);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Carpolicydaautorizzare = DataHelper.IfDBNull<int>(row["carpolicydaautorizzare"], 0),
                    Carpolicyinviaremail = DataHelper.IfDBNull<int>(row["carpolicyinviaremail"], 0),
                    Configurazionidaautorizzarepp = DataHelper.IfDBNull<int>(row["configurazionidaautorizzarepp"], 0),
                    Autorunning = DataHelper.IfDBNull<int>(row["autorunning"], 0),
                    Autopool = DataHelper.IfDBNull<int>(row["autopool"], 0),
                    Ordini = DataHelper.IfDBNull<int>(row["ordini"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys ViewDashHR(string codsocieta, Guid Uidtenant)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM view_dashboard_hr WHERE codsocieta = @codsocieta AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = codsocieta;
            collParams.Add(param0);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Carpolicydaautorizzare = DataHelper.IfDBNull<int>(row["carpolicydaautorizzare"], 0),
                    Carpolicyinviaremail = DataHelper.IfDBNull<int>(row["carpolicyinviaremail"], 0),
                    Configurazionidaautorizzarepp = DataHelper.IfDBNull<int>(row["configurazionidaautorizzarepp"], 0),
                    Autorunning = DataHelper.IfDBNull<int>(row["autorunning"], 0),
                    Autopool = DataHelper.IfDBNull<int>(row["autopool"], 0),
                    Ordini = DataHelper.IfDBNull<int>(row["ordini"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys ViewDashFlotta(Guid Uidtenant)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM view_dashboard_flotta WHERE uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Autoincircolazione = DataHelper.IfDBNull<int>(row["autoincircolazione"], 0),
                    Autoinpool = DataHelper.IfDBNull<int>(row["autoinpool"], 0),
                    Saldoauto = DataHelper.IfDBNull<int>(row["saldoauto"], 0),
                    Meseconsegna = DataHelper.IfDBNull<int>(row["meseconsegna"], 0),
                    Annoconsegna = DataHelper.IfDBNull<int>(row["annoconsegna"], 0),
                    Kmmedi = DataHelper.IfDBNull<decimal>(row["kmmedi"], 0),
                    Etamedia = DataHelper.IfDBNull<int>(row["etamedia"], 0),
                    Numerodeltacanone = DataHelper.IfDBNull<int>(row["numerodeltacanone"], 0),
                    Maxdeltacanone = DataHelper.IfDBNull<decimal>(row["maxdeltacanone"], 0),
                    Mediadeltacanone = DataHelper.IfDBNull<decimal>(row["mediadeltacanone"], 0),
                    Mediafringebenefit = DataHelper.IfDBNull<decimal>(row["mediafringebenefit"], 0),
                    Maxfringebenefit = DataHelper.IfDBNull<decimal>(row["maxfringebenefit"], 0),
                    Mediaemissioni = DataHelper.IfDBNull<decimal>(row["mediaemissioni"], 0),
                    Maxemissioni = DataHelper.IfDBNull<decimal>(row["maxemissioni"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> ViewFlottaAutoCircolazione(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = " SELECT tot FROM view_flotta_auto_circolazione WHERE uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> ViewAuto(string viewtable)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = " SELECT * FROM " + SeoHelper.EncodeString(viewtable);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys ViewDashPool(Guid Uidtenant)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM view_dashboard_pool WHERE uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Autototali = DataHelper.IfDBNull<int>(row["autototali"], 0),
                    Ready = DataHelper.IfDBNull<int>(row["ready"], 0),
                    Dariparare = DataHelper.IfDBNull<int>(row["dariparare"], 0),
                    Meseconsegna = DataHelper.IfDBNull<int>(row["meseconsegna"], 0),
                    Annoconsegna = DataHelper.IfDBNull<int>(row["annoconsegna"], 0),
                    Kmmedi = DataHelper.IfDBNull<int>(row["kmmedi"], 0),
                    Numerodeltacanone = DataHelper.IfDBNull<int>(row["numerodeltacanone"], 0),
                    Maxdeltacanone = DataHelper.IfDBNull<decimal>(row["maxdeltacanone"], 0),
                    Mediadeltacanone = DataHelper.IfDBNull<decimal>(row["mediadeltacanone"], 0),
                    Mediafringebenefit = DataHelper.IfDBNull<decimal>(row["mediafringebenefit"], 0),
                    Maxfringebenefit = DataHelper.IfDBNull<decimal>(row["maxfringebenefit"], 0),
                    Mediaemissioni = DataHelper.IfDBNull<decimal>(row["mediaemissioni"], 0),
                    Maxemissioni = DataHelper.IfDBNull<decimal>(row["maxemissioni"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> ViewPoolAutoCircolazione(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = " SELECT tot FROM view_pool_auto_circolazione WHERE uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys ViewDashDriver(Guid Uidtenant)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM view_dashboard_driver WHERE uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Etamediadriver = DataHelper.IfDBNull<int>(row["etamediadriver"], 0),
                };
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> ViewDriverAttivi(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = " SELECT tot FROM view_driver_auto_attivi WHERE uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys DetailSocietaXPIVA(string partitaiva)
        {
            IUtilitys retVal = null;
            string sql = "SELECT codsocieta, codcompany FROM EF_societa WHERE partitaiva = @partitaiva";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@partitaiva", DbType.String);
            param0.Value = partitaiva;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Codcompany = DataHelper.IfDBNull<string>(row["codcompany"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }



        public int UpdateArgomentiFAQ(IUtilitys value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_faq_argomenti SET [argomento] = @argomento, [immagine] = @immagine, [status] = @status, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@argomento", DbType.String);
            param0.Value = value.Argomento;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@immagine", DbType.String);
            param1.Value = value.Immagine;
            collParams.Add(param1);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@status", DbType.String);
            param10.Value = value.Status;
            collParams.Add(param10);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param4.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param6.Value = value.Uid;
            collParams.Add(param6);

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


        public int DeleteArgomentoFAQ(IUtilitys value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_faq_argomenti WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = value.Uid;
            collParams.Add(paramID);

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


        public int InsertArgomentoFAQ(IUtilitys value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_faq_argomenti ([argomento], [immagine], [status], [datauserins], [UserIDIns], [datausermod], [UserIdMod],[uidtenant]) " +
                         " VALUES (@argomento, @immagine, @status, @datauserins, @UserIDIns, @datausermod, @UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@argomento", DbType.String);
            param0.Value = value.Argomento;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@immagine", DbType.String);
            param1.Value = value.Immagine;
            collParams.Add(param1);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@status", DbType.String);
            param10.Value = value.Status;
            collParams.Add(param10);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param4.Value = DateTime.Now;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param5.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param7.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param7);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        public IUtilitys DetailArgomentoFAQId(Guid Uid)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_faq_argomenti WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Argomento = DataHelper.IfDBNull<string>(row["argomento"], _stringEmpty),
                    Immagine = DataHelper.IfDBNull<string>(row["immagine"], _stringEmpty),
                    Idargomentofaq = DataHelper.IfDBNull<int>(row["idargomentofaq"], 0),
                    Status = DataHelper.IfDBNull<string>(row["status"], _stringEmpty),
                    Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                    Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                    UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                    UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }


        public int SelectCountArgomentoFAQ(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (argomento like '%' + @keysearch + '%') ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_faq_argomenti WHERE uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public List<IUtilitys> SelectArgomentoFAQ(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            string condWhere = "";
            string orderby;
            string paginazione;

            if (!string.IsNullOrEmpty(ordine))
            {
                orderby = ordine + " " + tipoordine;
            }
            else
            {
                orderby = " argomento ";
            }
            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (argomento like '%' + @keysearch + '%') ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = "SELECT * FROM EF_faq_argomenti WHERE uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Argomento = DataHelper.IfDBNull<string>(row["argomento"], _stringEmpty),
                        Status = DataHelper.IfDBNull<string>(row["status"], _stringEmpty),
                        Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                        Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                        UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                        UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectAllArgomentoFAQ(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT idargomentofaq, argomento FROM EF_faq_argomenti WHERE uidtenant = @Uidtenant ORDER BY argomento ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Idargomentofaq = DataHelper.IfDBNull<int>(row["idargomentofaq"], 0),
                        Argomento = DataHelper.IfDBNull<string>(row["argomento"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        public int UpdateFAQ(IUtilitys value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_faq SET [idargomentofaq] = @idargomentofaq, [domanda] = @domanda, [risposta] = @risposta, " +
                         " [validadal] = @validadal, [validaal] = @validaal, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idargomentofaq", DbType.Int32);
            param0.Value = value.Idargomentofaq;
            collParams.Add(param0);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@domanda", DbType.String);
            param10.Value = value.Domanda;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@risposta", DbType.String);
            param11.Value = value.Risposta;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@validadal", DbType.Date);
            param12.Value = value.Validadal;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@validaal", DbType.Date);
            param13.Value = value.Validaal;
            collParams.Add(param13);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param4.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param6.Value = value.Uid;
            collParams.Add(param6);

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


        public int DeleteFAQ(IUtilitys value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_faq WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = value.Uid;
            collParams.Add(paramID);

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


        public int InsertFAQ(IUtilitys value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_faq ([idargomentofaq], [domanda], [risposta], [validadal], [validaal], [datauserins], [UserIDIns], [datausermod], [UserIdMod],[uidtenant]) " +
                         " VALUES (@idargomentofaq, @domanda, @risposta, @validadal, @validaal, @datauserins, @UserIDIns, @datausermod, @UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idargomentofaq", DbType.Int32);
            param0.Value = value.Idargomentofaq;
            collParams.Add(param0);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@domanda", DbType.String);
            param10.Value = value.Domanda;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@risposta", DbType.String);
            param11.Value = value.Risposta;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@validadal", DbType.Date);
            param12.Value = value.Validadal;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@validaal", DbType.Date);
            param13.Value = value.Validaal;
            collParams.Add(param13);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param4.Value = DateTime.Now;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param5.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param7.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param7);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        public IUtilitys DetailFAQId(Guid Uid)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_faq WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Idargomentofaq = DataHelper.IfDBNull<int>(row["idargomentofaq"], 0),
                    Domanda = DataHelper.IfDBNull<string>(row["domanda"], _stringEmpty),
                    Risposta = DataHelper.IfDBNull<string>(row["risposta"], _stringEmpty),
                    Validadal = DataHelper.IfDBNull<DateTime>(row["validadal"], DateTime.MinValue),
                    Validaal = DataHelper.IfDBNull<DateTime>(row["validaal"], DateTime.MinValue),
                    Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                    Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                    UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                    UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }


        public int SelectCountFAQ(string keysearch, int idargomentofaq, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (f.domanda like '%' + @keysearch + '%') ";
            if (idargomentofaq > 0) condWhere += " AND f.idargomentofaq = @idargomentofaq ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_faq as f " +
                         " LEFT JOIN EF_faq_argomenti as fa ON fa.idargomentofaq = f.idargomentofaq AND fa.uidtenant = f.uidtenant " +
                         " WHERE f.idfaq > 0 AND f.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (idargomentofaq > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idargomentofaq", DbType.Int32);
                param1.Value = idargomentofaq;
                collParams.Add(param1);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public List<IUtilitys> SelectFAQ(string keysearch, int idargomentofaq, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            string condWhere = "";
            string orderby;
            string paginazione;

            if (!string.IsNullOrEmpty(ordine))
            {
                orderby = ordine + " " + tipoordine;
            }
            else
            {
                orderby = " fa.argomento ";
            }
            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (f.domanda like '%' + @keysearch + '%') ";
            if (idargomentofaq > 0) condWhere += " AND f.idargomentofaq = @idargomentofaq ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = " SELECT fa.argomento, f.domanda, f.uid FROM EF_faq as f " +
                         " LEFT JOIN EF_faq_argomenti as fa ON fa.idargomentofaq = f.idargomentofaq AND fa.uidtenant = f.uidtenant " +
                         " WHERE f.idfaq > 0 AND f.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (idargomentofaq > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idargomentofaq", DbType.Int32);
                param1.Value = idargomentofaq;
                collParams.Add(param1);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Argomento = DataHelper.IfDBNull<string>(row["argomento"], _stringEmpty),
                        Domanda = DataHelper.IfDBNull<string>(row["domanda"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectArgomentoFAQAttivi()
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM EF_faq_argomenti WHERE status='ATTIVO' ORDER BY argomento ";
            
            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Argomento = DataHelper.IfDBNull<string>(row["argomento"], _stringEmpty),
                        Immagine = DataHelper.IfDBNull<string>(row["immagine"], _stringEmpty),
                        Idargomentofaq = DataHelper.IfDBNull<int>(row["idargomentofaq"], 0),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectFAQXId(int idargomentofaq, string keysearch)
        {
            string condWhere = "";
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (domanda like '%' + @keysearch + '%' or risposta like '%' + @keysearch + '%') ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = " SELECT * FROM EF_faq WHERE idargomentofaq = @idargomentofaq and validadal <= @dataoggi and validaal >= @dataoggi " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idargomentofaq", DbType.Int32);
            param0.Value = idargomentofaq;
            collParams.Add(param0);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.DateTime);
            param3.Value = dataoggi;
            collParams.Add(param3);

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param1.Value = keysearch;
                collParams.Add(param1);
            }

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Domanda = DataHelper.IfDBNull<string>(row["domanda"], _stringEmpty),
                        Risposta = DataHelper.IfDBNull<string>(row["risposta"], _stringEmpty),
                        Idargomentofaq = DataHelper.IfDBNull<int>(row["idargomentofaq"], 0),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        //aggiorna penale
        public int UpdatePenale(IUtilitys value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_penali SET [codsocieta] = @codsocieta, [codgrade] = @codgrade, [importopenale] = @importopenale, [tipopenale] = @tipopenale, " +
                         " [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
            param10.Value = value.Codgrade;
            collParams.Add(param10);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@importopenale", DbType.Decimal);
            param1.Value = value.Importopenale;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@tipopenale", DbType.String);
            param2.Value = value.Tipopenale;
            collParams.Add(param2);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param4.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param6.Value = value.Uid;
            collParams.Add(param6);

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


        //cancella penale
        public int DeletePenale(IUtilitys value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_penali WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = value.Uid;
            collParams.Add(paramID);

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

        //inserimento nuova penale
        public int InsertPenale(IUtilitys value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_penali ([codsocieta], [codgrade], [importopenale], [tipopenale], [datauserins], [UserIDIns], [datausermod], [UserIdMod],[uidtenant]) " +
                         " VALUES (@codsocieta, @codgrade, @importopenale, @tipopenale, @datauserins, @UserIDIns, @datausermod, @UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
            param10.Value = value.Codgrade;
            collParams.Add(param10);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@importopenale", DbType.Decimal);
            param1.Value = value.Importopenale;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@tipopenale", DbType.String);
            param2.Value = value.Tipopenale;
            collParams.Add(param2);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param4.Value = DateTime.Now;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param5.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param7.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param7);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli penale
        public IUtilitys DetailPenaleId(Guid Uid)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_penali WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Codgrade = DataHelper.IfDBNull<string>(row["codgrade"], _stringEmpty),
                    Importopenale = DataHelper.IfDBNull<decimal>(row["importopenale"], 0),
                    Tipopenale = DataHelper.IfDBNull<string>(row["tipopenale"], _stringEmpty),
                    Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                    Datausermod = DataHelper.IfDBNull<DateTime>(row["datausermod"], DateTime.MinValue),
                    UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                    UserIdMod = DataHelper.IfDBNull<Guid>(row["UserIdMod"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }


        //conta penali
        public int SelectCountPenali(string codsocieta, string codgrade, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND p.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND p.codgrade = @codgrade ";

            string SQL = " SELECT COUNT(p.idpenale) as tot FROM EF_penali as p " +
                         " INNER JOIN EF_societa as s ON s.codsocieta = p.codsocieta AND s.uidtenant = p.uidtenant " +
                         " INNER JOIN EF_grade as g ON g.codgrade = p.codgrade AND g.uidtenant = p.uidtenant " +
                         " WHERE p.idpenale > 0 AND p.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }

            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param1.Value = codgrade;
                collParams.Add(param1);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista penali
        public List<IUtilitys> SelectPenali(string codsocieta, string codgrade, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            string condWhere = "";
            string orderby;
            string paginazione;

            if (!string.IsNullOrEmpty(ordine))
            {
                orderby = ordine + " " + tipoordine;
            }
            else
            {
                orderby = " p.codsocieta ";
            }
            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND p.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND p.codgrade = @codgrade ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = " SELECT s.siglasocieta, g.grade, p.importopenale, p.tipopenale, p.Uid FROM EF_penali as p " +
                         " INNER JOIN EF_societa as s ON s.codsocieta = p.codsocieta AND s.uidtenant = p.uidtenant " +
                         " INNER JOIN EF_grade as g ON g.codgrade = p.codgrade AND g.uidtenant = p.uidtenant " +
                         " WHERE p.idpenale > 0 AND p.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }

            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param1.Value = codgrade;
                collParams.Add(param1);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Siglasocieta = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Importopenale = DataHelper.IfDBNull<decimal>(row["importopenale"], 0),
                        Tipopenale = DataHelper.IfDBNull<string>(row["tipopenale"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectExCarPolicy(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT excodcarpolicy FROM EF_carpolicy_excodifica WHERE uidtenant = @Uidtenant ORDER BY excodcarpolicy ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Excodcarpolicy = DataHelper.IfDBNull<string>(row["excodcarpolicy"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }





        //aggiorna avviso
        public int UpdateAvviso(IUtilitys value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_avvisi SET [testoavviso] = @testoavviso, " +
                         " [codsocieta] = @codsocieta, [codgrade] = @codgrade, [codcarpolicy] = @codcarpolicy, [visibiledal] = @visibiledal, [visibileal] = @visibileal, " +
                         " [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@testoavviso", DbType.String);
            param1.Value = value.Testoavviso;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param3.Value = value.Codsocieta;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
            param4.Value = value.Codgrade;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param5.Value = value.Codcarpolicy;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param6.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param7.Value = DateTime.Now;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param8.Value = value.Uid;
            collParams.Add(param8);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@visibiledal", DbType.DateTime);
            param10.Value = value.Visibiledal;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@visibileal", DbType.DateTime);
            param11.Value = value.Visibileal;
            collParams.Add(param11);

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


        //cancella avviso
        public int DeleteAvviso(IUtilitys value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_avvisi WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = value.Uid;
            collParams.Add(paramID);

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

        //inserimento nuovo avviso
        public int InsertAvviso(IUtilitys value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_avvisi ([testoavviso],[codsocieta],[codgrade],[codcarpolicy],[visibiledal],[visibileal], " +
                         " [datauserins], [UserIDIns], [datausermod], [UserIdMod],[uidtenant]) " +
                         " VALUES (@testoavviso, @codsocieta, @codgrade, @codcarpolicy, @visibiledal, @visibileal, " +
                         " @datauserins, @UserIDIns, @datausermod, @UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@testoavviso", DbType.String);
            param1.Value = value.Testoavviso;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param3.Value = value.Codsocieta;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
            param4.Value = value.Codgrade;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param5.Value = value.Codcarpolicy;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param7.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param8.Value = DateTime.Now;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param9.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@visibiledal", DbType.DateTime);
            param10.Value = value.Visibiledal;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@visibileal", DbType.DateTime);
            param11.Value = value.Visibileal;
            collParams.Add(param11);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli avviso
        public IUtilitys DetailAvvisoId(Guid Uid)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_avvisi WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Testoavviso = DataHelper.IfDBNull<string>(row["testoavviso"], _stringEmpty),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Codgrade = DataHelper.IfDBNull<string>(row["codgrade"], _stringEmpty),
                    Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                    Visibiledal = DataHelper.IfDBNull<DateTime>(row["visibiledal"], DateTime.Now),
                    Visibileal = DataHelper.IfDBNull<DateTime>(row["visibileal"], DateTime.Now),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }


        //conta avviso - FILTRO: keysearch
        public int SelectCountAvvisi(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND testoavviso like '%' + @keysearch + '%' ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_avvisi WHERE idavviso > 0 AND uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista avviso
        // FILTRO: keysearch
        public List<IUtilitys> SelectAvvisi(string keysearch, Guid Uidtenant, int numrecord, int pagina)
        {
            string condWhere = "";
            string paginazione;

            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND testoavviso like '%' + @keysearch + '%' ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = "SELECT * FROM EF_avvisi WHERE idavviso > 0 AND uidtenant = @Uidtenant " + condWhere + " ORDER BY idavviso " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Testoavviso = DataHelper.IfDBNull<string>(row["testoavviso"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Codgrade = DataHelper.IfDBNull<string>(row["codgrade"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Visibiledal = DataHelper.IfDBNull<DateTime>(row["visibiledal"], DateTime.Now),
                        Visibileal = DataHelper.IfDBNull<DateTime>(row["visibileal"], DateTime.Now),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectAvvisiXUser(string codsocieta, string codgrade, string codcarpolicy, Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");
            string condWhere = "";

            if (!string.IsNullOrEmpty(codsocieta)) condWhere = " AND (codsocieta = @codsocieta OR codsocieta = '' OR codsocieta is null) ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere = " AND (codgrade = @codgrade OR codgrade = '' OR codgrade is null) ";
            if (!string.IsNullOrEmpty(codcarpolicy)) condWhere = " AND (codcarpolicy = @codcarpolicy OR codcarpolicy = '' OR codcarpolicy is null) ";

            if (!string.IsNullOrEmpty(codsocieta) && !string.IsNullOrEmpty(codgrade)) condWhere = " AND (codsocieta = @codsocieta OR codsocieta = '' OR codsocieta is null) AND (codgrade = @codgrade OR codgrade = '' OR codgrade is null) ";
            if (!string.IsNullOrEmpty(codsocieta) && !string.IsNullOrEmpty(codcarpolicy)) condWhere = " AND (codsocieta = @codsocieta OR codsocieta = '' OR codsocieta is null) AND (codcarpolicy = @codcarpolicy OR codcarpolicy = '' OR codcarpolicy is null) ";
            if (!string.IsNullOrEmpty(codgrade) && !string.IsNullOrEmpty(codcarpolicy)) condWhere = " AND (codgrade = @codgrade OR codgrade = '' OR codgrade is null) AND (codcarpolicy = @codcarpolicy OR codcarpolicy = '' OR codcarpolicy is null) ";

            if (!string.IsNullOrEmpty(codsocieta) && !string.IsNullOrEmpty(codgrade) && !string.IsNullOrEmpty(codcarpolicy)) condWhere = " AND (codsocieta = @codsocieta OR codsocieta = '' OR codsocieta is null) AND (codgrade = @codgrade OR codgrade = '' OR codgrade is null) AND (codcarpolicy = @codcarpolicy OR codcarpolicy = '' OR codcarpolicy is null) ";


            string sql = "SELECT * FROM EF_avvisi WHERE visibiledal <= @dataoggi AND visibileal >= @dataoggi AND uidtenant = @Uidtenant " + condWhere + "ORDER BY idavviso";

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }

            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param1.Value = codgrade;
                collParams.Add(param1);
            }

            if (!string.IsNullOrEmpty(codcarpolicy))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
                param2.Value = codcarpolicy;
                collParams.Add(param2);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);
            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.Date);
            param4.Value = dataoggi;
            collParams.Add(param4);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Testoavviso = DataHelper.IfDBNull<string>(row["testoavviso"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys ViewDashPartner(Guid Uidtenant)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM view_dashboard_partner WHERE uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Configurazionidaautorizzare = DataHelper.IfDBNull<int>(row["configurazionidaautorizzare"], 0),
                    Offertedainviareadriver = DataHelper.IfDBNull<int>(row["offertedainviareadriver"], 0),
                    Confermedafirmare = DataHelper.IfDBNull<int>(row["confermedafirmare"], 0),
                    Richiesteautoinpool = DataHelper.IfDBNull<int>(row["richiesteautoinpool"], 0),
                    Richiesteautoinpool2 = DataHelper.IfDBNull<int>(row["richiesteautoinpool2"], 0),
                    Richiestepreassegnazioni = DataHelper.IfDBNull<int>(row["richiestepreassegnazioni"], 0),
                    Richiestevolture = DataHelper.IfDBNull<int>(row["richiestevolture"], 0),
                    Volturedaautorizzare = DataHelper.IfDBNull<int>(row["volturedaautorizzare"], 0),
                    Multedaregistrare = DataHelper.IfDBNull<int>(row["multedaregistrare"], 0),
                    Multeconpunti = DataHelper.IfDBNull<int>(row["multeconpunti"], 0),
                    Fatturedaelaborare = DataHelper.IfDBNull<int>(row["fatturedaelaborare"], 0),
                    Fringebenefitdacalcolare = DataHelper.IfDBNull<int>(row["fringebenefitdacalcolare"], 0),
                    Ticketaperti = DataHelper.IfDBNull<int>(row["ticketaperti"], 0),
                    Ticketlavorazione = DataHelper.IfDBNull<int>(row["ticketlavorazione"], 0),
                    Ticketchiusi = DataHelper.IfDBNull<int>(row["ticketchiusi"], 0),
                    Ticketcancellati = DataHelper.IfDBNull<int>(row["ticketcancellati"], 0),
                    Documentipolicydacontrollare = DataHelper.IfDBNull<int>(row["documentipolicydacontrollare"], 0),
                    Ztldafirmare = DataHelper.IfDBNull<int>(row["ztldafirmare"], 0),
                    Inoffertarenter = DataHelper.IfDBNull<int>(row["inoffertarenter"], 0),
                    Offertevalutazioneadriver = DataHelper.IfDBNull<int>(row["offertevalutazioneadriver"], 0),
                    Ordinievasione = DataHelper.IfDBNull<int>(row["ordinievasione"], 0),
                    Autoritiro = DataHelper.IfDBNull<int>(row["autoritiro"], 0),
                    Autoconsegna = DataHelper.IfDBNull<int>(row["autoconsegna"], 0),
                    Configurazionicorso = DataHelper.IfDBNull<int>(row["configurazionicorso"], 0),
                    Configurazionievase = DataHelper.IfDBNull<int>(row["configurazionievase"], 0),
                    Penaligestire = DataHelper.IfDBNull<int>(row["penaligestire"], 0),
                    Penaliapprovate = DataHelper.IfDBNull<int>(row["penaliapprovate"], 0),
                    Penalicontestazione = DataHelper.IfDBNull<int>(row["penalicontestazione"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectAllTemplateEmail(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM EF_email_template WHERE flgtipo = 1 AND uidtenant = @Uidtenant ORDER BY titolo ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Titolo = DataHelper.IfDBNull<string>(row["titolo"], _stringEmpty),
                        Idtemplate = DataHelper.IfDBNull<int>(row["idtemplate"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectAllUserEmail()
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM EF_email_invio WHERE flginviato = '' or flginviato is null  ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Codgrade = DataHelper.IfDBNull<string>(row["codgrade"], _stringEmpty),
                        Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                        Param1 = DataHelper.IfDBNull<string>(row["param1"], _stringEmpty),
                        Param2 = DataHelper.IfDBNull<string>(row["param2"], _stringEmpty),
                        Param3 = DataHelper.IfDBNull<string>(row["param3"], _stringEmpty),
                        Param4 = DataHelper.IfDBNull<string>(row["param4"], _stringEmpty),
                        Param5 = DataHelper.IfDBNull<string>(row["param5"], _stringEmpty),
                        Param6 = DataHelper.IfDBNull<string>(row["param6"], _stringEmpty),
                        Param7 = DataHelper.IfDBNull<string>(row["param7"], _stringEmpty),
                        Param8 = DataHelper.IfDBNull<string>(row["param8"], _stringEmpty),
                        Param9 = DataHelper.IfDBNull<string>(row["param9"], _stringEmpty),
                        Param10 = DataHelper.IfDBNull<string>(row["param10"], _stringEmpty),
                        Idinvio = DataHelper.IfDBNull<int>(row["idinvio"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateInvioMail(int idinvio)
        {
            int retVal = 0;

            string sql = " UPDATE EF_email_invio SET [flginviato] = 1, [datainvio] = @datainvio WHERE idinvio = @idinvio";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datainvio", DbType.Date);
            param7.Value = DateTime.Now;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idinvio", DbType.Int32);
            param8.Value = idinvio;
            collParams.Add(param8);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }

        //aggiorna centri
        public int UpdateCentri(IUtilitys value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_centri SET [citta] = @citta, [centro] = @centro WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@citta", DbType.String);
            param0.Value = value.Citta;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@centro", DbType.String);
            param1.Value = value.Centro;
            collParams.Add(param1);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param7.Value = value.Uid;
            collParams.Add(param7);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = value.Uidtenant;
            collParams.Add(param3);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //cancella centri

        public int DeleteCentri(IUtilitys value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_centri WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = value.Uid;
            collParams.Add(paramID);

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

        //inserimento nuovo centro

        public int InsertCentri(IUtilitys value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_centri ([citta], [centro], [uidtenant]) " +
                         " VALUES (@citta, @centro, @uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@citta", DbType.String);
            param0.Value = value.Citta;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@centro", DbType.String);
            param1.Value = value.Centro;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = value.Uidtenant;
            collParams.Add(param3);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli centro

        public IUtilitys DetailCentriId(Guid Uid)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM EF_centri WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Citta = DataHelper.IfDBNull<string>(row["citta"], _stringEmpty),
                    Centro = DataHelper.IfDBNull<string>(row["centro"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }


        //conta centri - FILTRO: keysearch
        public int SelectCountCentri(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (citta like '%' + @keysearch + '%' or centro like '%' + @keysearch + '%') ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_centri WHERE uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista conti
        // FILTRO: keysearch
        public List<IUtilitys> SelectCentri(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
        {
            string condWhere = "";
            string orderby;
            string paginazione;

            if (!string.IsNullOrEmpty(ordine))
            {
                orderby = ordine + " " + tipoordine;
            }
            else
            {
                orderby = " centro ";
            }
            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (citta like '%' + @keysearch + '%' or centro like '%' + @keysearch + '%') ";

            List<IUtilitys> retVal = new List<IUtilitys>();
            string sql = "SELECT * FROM EF_centri WHERE uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Citta = DataHelper.IfDBNull<string>(row["citta"], _stringEmpty),
                        Centro = DataHelper.IfDBNull<string>(row["centro"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectAllCentri(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM EF_centri WHERE uidtenant = @Uidtenant ORDER BY centro ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);            

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Idcentro = DataHelper.IfDBNull<int>(row["idcentro"], 0),
                        Citta = DataHelper.IfDBNull<string>(row["citta"], _stringEmpty),
                        Centro = DataHelper.IfDBNull<string>(row["centro"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectAllCittaCentri(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT DISTINCT citta FROM EF_centri WHERE uidtenant = @Uidtenant ORDER BY citta ";

            List<IDataParameter> collParams = new List<IDataParameter>();
                      
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);            

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Citta = DataHelper.IfDBNull<string>(row["citta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectCentriXCitta(string citta, Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM EF_centri WHERE citta = @citta AND uidtenant = @Uidtenant ORDER BY centro ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@citta", DbType.String);
            param0.Value = citta;
            collParams.Add(param0);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);            

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Idcentro = DataHelper.IfDBNull<int>(row["idcentro"], 0),
                        Citta = DataHelper.IfDBNull<string>(row["citta"], _stringEmpty),
                        Centro = DataHelper.IfDBNull<string>(row["centro"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        public List<IUtilitys> SelectDashFlottaStatusContratto(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_flotta_statuscontratto WHERE uidtenant = @Uidtenant ORDER BY idstatuscontratto ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashFlottaContratto(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_flotta_contratto WHERE uidtenant = @Uidtenant ORDER BY idstatuscontratto ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashFlottaNonAssegnato(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_flotta_nonassegnato WHERE uidtenant = @Uidtenant ORDER BY idstatuscontratto ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashFlottaSocieta(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_flotta_societa WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashFlottaGrade(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_flotta_grade WHERE uidtenant = @Uidtenant ORDER BY codgrade DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashFlottaSedeDriver(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_flotta_sededriver WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashFlottaFornitore(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_flotta_fornitori WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashFlottaFornitoreCanone(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_flotta_fornitori_canone WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                        Canone = DataHelper.IfDBNull<decimal>(row["tot"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashFlottaMarca(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_flotta_marche WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashFlottaAnnualita(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_flotta_annualita WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Annoconsegna = DataHelper.IfDBNull<int>(row["etichetta"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashFlottaAlimentazione(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_flotta_alimentazione WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountViewFlotta(string viewtable)
        {
            string SQL = "SELECT SUM(tot) as tot FROM " + SeoHelper.EncodeString(viewtable);
            return _dataHelper.GetValue<int>(SQL, CommandType.Text).Data;
        }
        public decimal SelectCountViewFlotta2(string viewtable)
        {
            string SQL = "SELECT SUM(tot) as tot FROM " + SeoHelper.EncodeString(viewtable);
            return _dataHelper.GetValue<decimal>(SQL, CommandType.Text).Data;
        }
        public List<IUtilitys> SelectDashPoolSocieta(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_pool_societa WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectDashPoolFornitore(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_pool_fornitori WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashPoolFornitoreCanone(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_pool_fornitori_canone WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                        Canone = DataHelper.IfDBNull<decimal>(row["tot"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashPoolMarca(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_pool_marche WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashPoolAnnualita(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_pool_annualita WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Annoconsegna = DataHelper.IfDBNull<int>(row["etichetta"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashPoolAlimentazione(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_pool_alimentazione WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        public List<IUtilitys> SelectDashOrdiniStatusOrdine(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_ordini_status WHERE uidtenant = @Uidtenant ORDER BY idstatusordine ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashOrdiniSocieta(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_ordini_societa WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashOrdiniGrade(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_ordini_grade WHERE uidtenant = @Uidtenant ORDER BY codgrade DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashOrdiniSedeDriver(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_ordini_sededriver WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashOrdiniFornitore(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_ordini_fornitori WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashOrdiniFornitoreCanone(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_ordini_fornitori_canone WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                        Canone = DataHelper.IfDBNull<decimal>(row["tot"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashOrdiniMarca(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_ordini_marche WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashOrdiniAnnualita(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_ordini_annualita WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Annoconsegna = DataHelper.IfDBNull<int>(row["etichetta"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashOrdiniAlimentazione(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_ordini_alimentazione WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashFlottaTempo(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_flotta_tempo WHERE uidtenant = @Uidtenant ORDER BY anno, mese ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["totale"], 0),
                        Annoconsegna = DataHelper.IfDBNull<int>(row["anno"], 0),
                        Meseconsegna = DataHelper.IfDBNull<int>(row["mese"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IUtilitys> SelectDashPoolStatus(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_pool_status WHERE uidtenant = @Uidtenant ORDER BY idstatuspool ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashRenterStatusOrdini(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_renter_status WHERE uidtenant = @Uidtenant ORDER BY idstatusordine ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys ViewDashRenter(Guid Uidtenant)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM view_dashboard_renter WHERE uidtenant = @Uidtenant "; 
            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Dafirmare = DataHelper.IfDBNull<int>(row["dafirmare"], 0),
                    Tempirisposta = DataHelper.IfDBNull<int>(row["tempirisposta"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashDriverGrade(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_driver_grade WHERE uidtenant = @Uidtenant ORDER BY codgrade ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashDriverSede(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_driver_sede WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashDriverEta(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_driver_eta WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Annoconsegna = DataHelper.IfDBNull<int>(row["etichetta"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys ViewDashMulte(Guid Uidtenant)
        {
            IUtilitys retVal = null;

            string sql = "SELECT * FROM view_dashboard_multe WHERE uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Tot = DataHelper.IfDBNull<int>(row["totalemulte"], 0),
                };
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashMulteMese(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_multe_mese WHERE uidtenant = @Uidtenant ORDER BY anno, mese ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["totale"], 0),
                        Annoconsegna = DataHelper.IfDBNull<int>(row["anno"], 0),
                        Meseconsegna = DataHelper.IfDBNull<int>(row["mese"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashMulteStatus(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_multe_status WHERE uidtenant = @Uidtenant ORDER BY idstatuspagamento";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashMulteSocieta(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_multe_societa WHERE uidtenant = @Uidtenant ORDER BY etichetta";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashMulteGrade(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_multe_grade WHERE uidtenant = @Uidtenant ORDER BY codgrade ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashMulteCitta(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_multe_citta WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashMulteTipo(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_multe_tipo WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IUtilitys ViewDashContabilita(Guid Uidtenant)
        {
            IUtilitys retVal = null;
            string sql = "SELECT * FROM view_dashboard_contabilita WHERE uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Utilitys
                {
                    Tot = DataHelper.IfDBNull<int>(row["numtotalefatture"], 0),
                };
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashContabilitaFattureMese(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_contabilita_mese WHERE uidtenant = @Uidtenant ORDER BY anno, mese ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["totale"], 0),
                        Annoconsegna = DataHelper.IfDBNull<int>(row["anno"], 0),
                        Meseconsegna = DataHelper.IfDBNull<int>(row["mese"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashContabilitaSocieta(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_contabilita_societa WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashContabilitaFornitore(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_contabilita_fornitori WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashContabilitaTemplate(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_contabilita_template WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Tot = DataHelper.IfDBNull<int>(row["tot"], 0),
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashContabilitaSocietaImporto(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_contabilita_societa_importo WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                        Importototale = DataHelper.IfDBNull<decimal>(row["tot"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashContabilitaFornitoreImporto(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_contabilita_fornitori_importo WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                        Importototale = DataHelper.IfDBNull<decimal>(row["tot"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IUtilitys> SelectDashContabilitaTemplateImporto(Guid Uidtenant)
        {
            List<IUtilitys> retVal = new List<IUtilitys>();

            string sql = "SELECT * FROM view_contabilita_template_importo WHERE uidtenant = @Uidtenant ORDER BY etichetta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IUtilitys item = new Utilitys
                    {
                        Etichetta = DataHelper.IfDBNull<string>(row["etichetta"], _stringEmpty),
                        Importototale = DataHelper.IfDBNull<decimal>(row["tot"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
    }
}