// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CComunicazioniProvider.cs" company="">
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

    [SectionName("comunicazioni.provider/ComunicazioniSection")]
    public class ComunicazioniProvider : DFleetDataProvider, IComunicazioniProvider
    {

        public int InsertComunicazione(IComunicazioni value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_comunicazioni ([idoggetto],[UserIdMittente],[UseridDestinatario],[datainvio],[testocomunicazione],[idstatuscomunicazione],[priorita], " +
                         " [idstatuslettura],[UidcomunicazionePadre],[datauserins],[datausermod],[UserIDIns],[UserIdMod],[dataultimoaggiornamento],[uidtenant]) " +
                         " VALUES (@idoggetto,@UserIdMittente,@UseridDestinatario,@datainvio,@testocomunicazione,@idstatuscomunicazione,@priorita, " +
                         " @idstatuslettura,@UidcomunicazionePadre,@datauserins,@datausermod,@UserIDIns,@UserIdMod,@dataultimoaggiornamento,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idoggetto", DbType.Int32);
            param0.Value = value.Idoggetto;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMittente", DbType.Guid);
            param1.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UseridDestinatario", DbType.Guid);
            param2.Value = value.UseridDestinatario;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@datainvio", DbType.DateTime);
            param3.Value = DateTime.Now;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@testocomunicazione", DbType.String);
            param4.Value = value.Testocomunicazione;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscomunicazione", DbType.Int32);
            param5.Value = value.Idstatuscomunicazione;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@priorita", DbType.Int32);
            param6.Value = value.Priorita;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuslettura", DbType.Int32);
            param7.Value = value.Idstatuslettura;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@UidcomunicazionePadre", DbType.Guid);
            param8.Value = value.UidcomunicazionePadre;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.DateTime);
            param9.Value = DateTime.Now;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.DateTime);
            param10.Value = DateTime.Now;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param11.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param12.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@dataultimoaggiornamento", DbType.DateTime);
            param13.Value = DateTime.Now;
            collParams.Add(param13);

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

        public List<IComunicazioni> SelectOggetto(Guid Uidtenant)
        {
            List<IComunicazioni> retVal = new List<IComunicazioni>();

            string sql = "SELECT * FROM EF_comunicazioni_oggetto WHERE uidtenant = @Uidtenant ORDER BY oggetto ";

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
                    IComunicazioni item = new Comunicazioni
                    {
                        Idoggetto = DataHelper.IfDBNull<int>(row["idoggetto"], 0),
                        Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IComunicazioni> SelectOggettoRenter(Guid Uidtenant)
        {
            List<IComunicazioni> retVal = new List<IComunicazioni>();

            string sql = "SELECT * FROM EF_comunicazioni_oggetto WHERE renter=1 AND uidtenant = @Uidtenant ORDER BY oggetto ";

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
                    IComunicazioni item = new Comunicazioni
                    {
                        Idoggetto = DataHelper.IfDBNull<int>(row["idoggetto"], 0),
                        Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IComunicazioni> SelectOggettoDriver(Guid Uidtenant)
        {
            List<IComunicazioni> retVal = new List<IComunicazioni>();

            string sql = "SELECT * FROM EF_comunicazioni_oggetto WHERE driver=1 AND uidtenant = @Uidtenant ORDER BY oggetto ";

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
                    IComunicazioni item = new Comunicazioni
                    {
                        Idoggetto = DataHelper.IfDBNull<int>(row["idoggetto"], 0),
                        Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IComunicazioni> SelectStatusComunicazioni(Guid Uidtenant)
        {
            List<IComunicazioni> retVal = new List<IComunicazioni>();

            string sql = "SELECT * FROM EF_comunicazioni_status WHERE uidtenant = @Uidtenant ORDER BY statuscomunicazione ";

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
                    IComunicazioni item = new Comunicazioni
                    {
                        Idstatuscomunicazione = DataHelper.IfDBNull<int>(row["idstatuscomunicazione"], 0),
                        Statuscomunicazione = DataHelper.IfDBNull<string>(row["statuscomunicazione"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        // conta comunicazioni
        // FILTRO: UserId, datadal, dataal, oggetto, idstatuscomunicazione
        public int SelectCountComunicazioni(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant)
        {
            string condWhere = "";
            Guid UserIdM = (Guid)Membership.GetUser().ProviderUserKey;
            if (autorizzatore == 1)
            {
                condWhere += " AND c.UserIdMittente = @UserIdM ";
            }
            else
            {
                if (UserId != Guid.Empty) condWhere += " AND c.UserIdMittente = @UserId ";
            }
            if (datadal > DateTime.MinValue) condWhere += " AND c.datainvio >= @datadal ";
            if (dataal > DateTime.MinValue) condWhere += " AND c.datainvio <= @dataal ";
            if (oggetto > 0) condWhere += " AND c.idoggetto = @oggetto ";
            if (idstatuscomunicazione > -1) condWhere += " AND c.idstatuscomunicazione = @idstatuscomunicazione ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_comunicazioni as c " +
                         " INNER JOIN EF_comunicazioni_oggetto as o ON o.idoggetto = c.idoggetto AND c.uidtenant = o.uidtenant " +
                         " INNER JOIN EF_comunicazioni_status as s ON s.idstatuscomunicazione = c.idstatuscomunicazione AND c.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserIdMittente AND c.uidtenant = u.uidtenant " +
                         " WHERE c.idcomunicazione > 0 and c.UIDcomunicazione = c.UIdcomunicazionePadre and c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.Date);
                param0.Value = datadal;
                collParams.Add(param0);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.Date);
                param1.Value = dataal;
                collParams.Add(param1);
            }
            if (oggetto > 0)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@oggetto", DbType.Int32);
                param3.Value = oggetto;
                collParams.Add(param3);
            }
            if (autorizzatore == 1)
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdM", DbType.Guid);
                param5.Value = UserIdM;
                collParams.Add(param5);
            }
            else
            {
                if (UserId != Guid.Empty)
                {
                    IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                    param2.Value = UserId;
                    collParams.Add(param2);
                }
            }
            if (idstatuscomunicazione > -1)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscomunicazione", DbType.Int32);
                param4.Value = idstatuscomunicazione;
                collParams.Add(param4);
            }
            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param6.Value = Uidtenant;
            collParams.Add(param6);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista consumi fuelcard driver
        // FILTRO: UserId, datadal, dataal, oggetto, idstatuscomunicazione
        public List<IComunicazioni> SelectComunicazioni(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant, int numrecord, int pagina)
        {
            string condWhere = "";
            Guid UserIdM = (Guid)Membership.GetUser().ProviderUserKey;
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

            if (autorizzatore == 1)
            {
                condWhere += " AND (c.UserIdMittente = @UserIdM OR c.UseridDestinatario = @UserIdM) ";
            }
            else
            {
                if (UserId != Guid.Empty) condWhere += " AND c.UserIdMittente = @UserId ";
            }
            if (datadal > DateTime.MinValue) condWhere += " AND c.datainvio >= @datadal ";
            if (dataal > DateTime.MinValue) condWhere += " AND c.datainvio <= @dataal ";
            if (oggetto > 0) condWhere += " AND c.idoggetto = @oggetto ";
            if (idstatuscomunicazione > -1) condWhere += " AND c.idstatuscomunicazione = @idstatuscomunicazione ";

            List<IComunicazioni> retVal = new List<IComunicazioni>();
            string sql = " SELECT c.idcomunicazione, s.statuscomunicazione, u.cognome, u.nome, u.matricola, u1.cognome as cognomedest, u1.nome as nomedest, o.oggetto, g.grade, " +
                         " c.Uidcomunicazione, c.UidcomunicazionePadre, c.idstatuslettura, c.priorita, c.datainvio, c.dataultimoaggiornamento, so.siglasocieta, " +
                         " (SELECT TOP 1 datachiusura  FROM EF_comunicazioni WHERE  UIDcomunicazione = c.UIdcomunicazionePadre  ORDER BY datainvio DESC) as datachiusura, " +
                         " (SELECT TOP 1 CONCAT(cognome, ' ', nome) FROM EF_comunicazioni INNER JOIN EF_users ON EF_comunicazioni.UserIdMittente = EF_users.UserId AND EF_comunicazioni.uidtenant = EF_users.uidtenant WHERE UIdcomunicazionePadre = c.UIdcomunicazionePadre ORDER BY datainvio DESC ) as ultimomittente " +
                         " FROM EF_comunicazioni as c " +
                         " INNER JOIN EF_comunicazioni_oggetto as o ON o.idoggetto = c.idoggetto AND c.uidtenant = o.uidtenant " +
                         " INNER JOIN EF_comunicazioni_status as s ON s.idstatuscomunicazione = c.idstatuscomunicazione AND c.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserIdMittente AND c.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_societa as so ON u.codsocieta = so.codsocieta AND c.uidtenant = so.uidtenant " +
                         " LEFT JOIN EF_grade as g ON u.gradecode = g.codgrade AND c.uidtenant = g.uidtenant " +
                         " LEFT JOIN EF_users as u1 ON u1.UserId = c.UseridDestinatario AND c.uidtenant = u1.uidtenant " +
                         " WHERE c.idcomunicazione > 0 and c.UIDcomunicazione = c.UIdcomunicazionePadre and c.uidtenant = @Uidtenant " + condWhere +
                         " ORDER BY c.dataultimoaggiornamento DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.Date);
                param0.Value = datadal;
                collParams.Add(param0);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.Date);
                param1.Value = dataal;
                collParams.Add(param1);
            }
            if (oggetto > 0)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@oggetto", DbType.Int32);
                param3.Value = oggetto;
                collParams.Add(param3);
            }
            if (autorizzatore == 1)
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdM", DbType.Guid);
                param5.Value = UserIdM;
                collParams.Add(param5);
            }
            else
            {
                if (UserId != Guid.Empty)
                {
                    IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                    param2.Value = UserId;
                    collParams.Add(param2);
                }
            }
            if (idstatuscomunicazione > -1)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscomunicazione", DbType.Int32);
                param4.Value = idstatuscomunicazione;
                collParams.Add(param4);
            }
            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param6.Value = Uidtenant;
            collParams.Add(param6);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IComunicazioni item = new Comunicazioni
                    {
                        Idcomunicazione = DataHelper.IfDBNull<int>(row["idcomunicazione"], 0),
                        Datainvio = DataHelper.IfDBNull<DateTime>(row["datainvio"], DateTime.MinValue),
                        Datachiusura = DataHelper.IfDBNull<DateTime>(row["datachiusura"], DateTime.MinValue),
                        Statuscomunicazione = DataHelper.IfDBNull<string>(row["statuscomunicazione"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Priorita = DataHelper.IfDBNull<int>(row["priorita"], 0),
                        Idstatuslettura = DataHelper.IfDBNull<int>(row["idstatuslettura"], 0),
                        Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty),
                        Ultimomittente = DataHelper.IfDBNull<string>(row["ultimomittente"], _stringEmpty),
                        Destinatario = DataHelper.IfDBNull<string>(row["cognomedest"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nomedest"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        UidcomunicazionePadre = DataHelper.IfDBNull<Guid>(row["UidcomunicazionePadre"], Guid.Empty),
                        Uidcomunicazione = DataHelper.IfDBNull<Guid>(row["Uidcomunicazione"], Guid.Empty),
                        Dataultimoaggiornamento = DataHelper.IfDBNull<DateTime>(row["dataultimoaggiornamento"], DateTime.MinValue)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int InsertAllegato(IComunicazioni value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_comunicazioni_allegati ([UIDcomunicazione],[allegato],[uidtenant]) ";
            sql += " VALUES (@UIDcomunicazione, @allegato, @uidtenant)";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UIDcomunicazione", DbType.Guid);
            param1.Value = value.UIDcomunicazione;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@allegato", DbType.String);
            param3.Value = value.Allegato;
            collParams.Add(param3);

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

        //ultimo uid comunicazione
        public IComunicazioni ReturnUidCom()
        {
            IComunicazioni retVal = null;
            string sql = "SELECT TOP 1 Uidcomunicazione FROM EF_comunicazioni ORDER BY idcomunicazione DESC ";
            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Comunicazioni
                {
                    UIDcomunicazione = DataHelper.IfDBNull<Guid>(row["Uidcomunicazione"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }

        public IComunicazioni DetailAllegato(Guid UIDallegato)
        {
            IComunicazioni retVal = null;
            string sql = "SELECT * FROM EF_comunicazioni_allegati WHERE UIDallegato = @UIDallegato";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UIDallegato", DbType.Guid);
            param0.Value = UIDallegato;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Comunicazioni
                {
                    Allegato = DataHelper.IfDBNull<string>(row["allegato"], _stringEmpty),
                    UIDallegato = DataHelper.IfDBNull<Guid>(row["UIDallegato"], Guid.NewGuid()),
                    UIDcomunicazione = DataHelper.IfDBNull<Guid>(row["UIDcomunicazione"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }

        //lista allegati
        public List<IComunicazioni> SelectAllegati(Guid UIDcomunicazione)
        {
            List<IComunicazioni> retVal = new List<IComunicazioni>();
            string sql = "SELECT UIDallegato, allegato FROM EF_comunicazioni_allegati WHERE UIDcomunicazione = @UIDcomunicazione ";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UIDcomunicazione", DbType.Guid);
            param0.Value = UIDcomunicazione;
            collParams.Add(param0);
            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IComunicazioni item = new Comunicazioni
                    {
                        Allegato = DataHelper.IfDBNull<string>(row["allegato"], _stringEmpty),
                        UIDallegato = DataHelper.IfDBNull<Guid>(row["UIDallegato"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        //dettagli comunicazioni
        public IComunicazioni DetailComunicazioni(Guid UIDcomunicazione)
        {
            IComunicazioni retVal = null;
            string sql = " SELECT c.idcomunicazione, s.statuscomunicazione, u.cognome, u.nome, u.matricola, u.email, u1.cognome as cognomedest, u1.nome as nomedest, o.oggetto, " +
                         " c.Uidcomunicazione, c.UidcomunicazionePadre, c.UserIdMittente, so.siglasocieta, g.grade, " +
                         " c.idstatuslettura, c.priorita, c.datainvio, c.testocomunicazione, c.idoggetto, c.idstatuscomunicazione FROM EF_comunicazioni as c " +
                         " INNER JOIN EF_comunicazioni_oggetto as o ON o.idoggetto = c.idoggetto " +
                         " INNER JOIN EF_comunicazioni_status as s ON s.idstatuscomunicazione = c.idstatuscomunicazione " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserIdMittente " +
                         " LEFT JOIN EF_societa as so ON u.codsocieta = so.codsocieta " +
                         " LEFT JOIN EF_grade as g ON u.gradecode = g.codgrade " +
                         " LEFT JOIN EF_users as u1 ON u1.UserId = c.UseridDestinatario " +
                         " WHERE c.Uidcomunicazione = @UIDcomunicazione ";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UIDcomunicazione", DbType.Guid);
            param0.Value = UIDcomunicazione;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Comunicazioni
                {
                    Idcomunicazione = DataHelper.IfDBNull<int>(row["idcomunicazione"], 0),
                    Datainvio = DataHelper.IfDBNull<DateTime>(row["datainvio"], DateTime.MinValue),
                    Statuscomunicazione = DataHelper.IfDBNull<string>(row["statuscomunicazione"], _stringEmpty),
                    Testocomunicazione = DataHelper.IfDBNull<string>(row["testocomunicazione"], _stringEmpty),
                    Priorita = DataHelper.IfDBNull<int>(row["priorita"], 0),
                    Idstatuslettura = DataHelper.IfDBNull<int>(row["idstatuslettura"], 0),
                    Idstatuscomunicazione = DataHelper.IfDBNull<int>(row["idstatuscomunicazione"], 0),
                    Idoggetto = DataHelper.IfDBNull<int>(row["idoggetto"], 0),
                    Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty),
                    Destinatario = DataHelper.IfDBNull<string>(row["cognomedest"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nomedest"], _stringEmpty),
                    Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                    Emailmittente = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                    UidcomunicazionePadre = DataHelper.IfDBNull<Guid>(row["UidcomunicazionePadre"], Guid.Empty),
                    Uidcomunicazione = DataHelper.IfDBNull<Guid>(row["Uidcomunicazione"], Guid.Empty),
                    UserIdMittente = DataHelper.IfDBNull<Guid>(row["UserIdMittente"], Guid.Empty),
                    Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                    Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }

        //aggiorna stato lettura
        public int UpdatStatoLettura(Guid UidcomunicazionePadre, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = "UPDATE EF_comunicazioni SET [idstatuslettura] = 1 WHERE UidcomunicazionePadre = @UidcomunicazionePadre AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@UidcomunicazionePadre", DbType.Guid);
            param11.Value = UidcomunicazionePadre;
            collParams.Add(param11);

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

        //lista comunicazioni correlate
        public List<IComunicazioni> SelectComunicazioniCorrelate(Guid UIDcomunicazione)
        {
            List<IComunicazioni> retVal = new List<IComunicazioni>();
            string sql = " SELECT s.statuscomunicazione, u.cognome, u.nome, u.matricola, u1.cognome as cognomedest, u1.nome as nomedest, o.oggetto, c.Uidcomunicazione, c.UidcomunicazionePadre, " +
                         " c.idstatuslettura, c.priorita, c.datainvio, c.testocomunicazione, c.UserIdMittente FROM EF_comunicazioni as c " +
                         " INNER JOIN EF_comunicazioni_oggetto as o ON o.idoggetto = c.idoggetto " +
                         " INNER JOIN EF_comunicazioni_status as s ON s.idstatuscomunicazione = c.idstatuscomunicazione " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserIdMittente " +
                         " LEFT JOIN EF_users as u1 ON u1.UserId = c.UseridDestinatario " +
                         " WHERE UidcomunicazionePadre = @UIDcomunicazione or UidcomunicazionePadre = @UIDcomunicazione or" +
                         " UidcomunicazionePadre = (select UidcomunicazionePadre from EF_comunicazioni where Uidcomunicazione=@UIDcomunicazione)  ORDER BY c.datainvio ";


            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UIDcomunicazione", DbType.Guid);
            param0.Value = UIDcomunicazione;
            collParams.Add(param0);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IComunicazioni item = new Comunicazioni
                    {
                        Datainvio = DataHelper.IfDBNull<DateTime>(row["datainvio"], DateTime.MinValue),
                        Statuscomunicazione = DataHelper.IfDBNull<string>(row["statuscomunicazione"], _stringEmpty),
                        Testocomunicazione = DataHelper.IfDBNull<string>(row["testocomunicazione"], _stringEmpty),
                        Priorita = DataHelper.IfDBNull<int>(row["priorita"], 0),
                        Idstatuslettura = DataHelper.IfDBNull<int>(row["idstatuslettura"], 0),
                        Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty),
                        Destinatario = DataHelper.IfDBNull<string>(row["cognomedest"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nomedest"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        UidcomunicazionePadre = DataHelper.IfDBNull<Guid>(row["UidcomunicazionePadre"], Guid.Empty),
                        Uidcomunicazione = DataHelper.IfDBNull<Guid>(row["Uidcomunicazione"], Guid.Empty),
                        UserIdMittente = DataHelper.IfDBNull<Guid>(row["UserIdMittente"], Guid.Empty)
                    };
                    item.Statuscomunicazione = DataHelper.IfDBNull<string>(row["statuscomunicazione"], _stringEmpty);
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountAllegatiComunicaione(Guid UidComunicazionePadre)
        {
            string SQL = "SELECT COUNT(idallegato) as tot FROM EF_comunicazioni_allegati " +
                         " WHERE Uidcomunicazione IN (select Uidcomunicazione FROM EF_comunicazioni WHERE Uidcomunicazionepadre = @UidComunicazionePadre) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UidComunicazionePadre", DbType.Guid);
            param0.Value = UidComunicazionePadre;
            collParams.Add(param0);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        //aggiorna UidComunicazionePadre
        public int UpdateUidComunicazionePadre(IComunicazioni value)
        {
            int retVal = 0;

            string sql = "UPDATE EF_comunicazioni SET [UIdcomunicazionePadre]=@UIdcomunicazionePadre WHERE [UIDcomunicazione]=@UIDcomunicazione AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@UIdcomunicazionePadre", DbType.Guid);
            param12.Value = value.UidcomunicazionePadre;
            collParams.Add(param12);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@UIDcomunicazione", DbType.Guid);
            param11.Value = value.UIDcomunicazione;
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

        //aggiorna stato comunicazione
        public int UpdateStatoComunicazione(int idstatuscomunicazione, Guid UidcomunicazionePadre, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = " UPDATE EF_comunicazioni SET [idstatuscomunicazione] = @idstatuscomunicazione, [dataultimoaggiornamento] = @dataultimoaggiornamento " +
                         " WHERE UidcomunicazionePadre = @UidcomunicazionePadre AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscomunicazione", DbType.Int32);
            param10.Value = idstatuscomunicazione;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@UidcomunicazionePadre", DbType.Guid);
            param11.Value = UidcomunicazionePadre;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@dataultimoaggiornamento", DbType.DateTime);
            param12.Value = DateTime.Now;
            collParams.Add(param12);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }

        public int UpdateChiusuraComunicazione(Guid UidcomunicazionePadre, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = " UPDATE EF_comunicazioni SET [idstatuscomunicazione] = 100, [datachiusura] = @datachiusura, [dataultimoaggiornamento] = @dataultimoaggiornamento " +
                         " WHERE UidcomunicazionePadre = @UidcomunicazionePadre AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@datachiusura", DbType.DateTime);
            param10.Value = DateTime.Now;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@UidcomunicazionePadre", DbType.Guid);
            param11.Value = UidcomunicazionePadre;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@dataultimoaggiornamento", DbType.DateTime);
            param12.Value = DateTime.Now;
            collParams.Add(param12);

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
        public List<IComunicazioni> SelectTop5Comunicazioni(Guid UserId, Guid Uidtenant)
        {
            List<IComunicazioni> retVal = new List<IComunicazioni>();
            string sql = " SELECT TOP 5 s.statuscomunicazione, u.cognome, u.nome, u.matricola, o.oggetto, c.Uidcomunicazione, c.UidcomunicazionePadre, c.idstatuslettura, c.priorita, c.datainvio " +
                         " FROM EF_comunicazioni as c " +
                         " INNER JOIN EF_comunicazioni_oggetto as o ON o.idoggetto = c.idoggetto AND o.uidtenant = c.uidtenant " +
                         " INNER JOIN EF_comunicazioni_status as s ON s.idstatuscomunicazione = c.idstatuscomunicazione AND s.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserIdMittente AND u.uidtenant = c.uidtenant " +
                         " WHERE c.idcomunicazione > 0 and c.UIDcomunicazione = c.UIdcomunicazionePadre AND c.UserIdMittente = @UserId AND c.uidtenant = @Uidtenant " +
                         " ORDER BY c.datainvio DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
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
                    IComunicazioni item = new Comunicazioni
                    {
                        Datainvio = DataHelper.IfDBNull<DateTime>(row["datainvio"], DateTime.MinValue),
                        Statuscomunicazione = DataHelper.IfDBNull<string>(row["statuscomunicazione"], _stringEmpty),
                        Priorita = DataHelper.IfDBNull<int>(row["priorita"], 0),
                        Idstatuslettura = DataHelper.IfDBNull<int>(row["idstatuslettura"], 0),
                        Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        UidcomunicazionePadre = DataHelper.IfDBNull<Guid>(row["UidcomunicazionePadre"], Guid.Empty),
                        Uidcomunicazione = DataHelper.IfDBNull<Guid>(row["Uidcomunicazione"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IComunicazioni> SelectTop5ComunicazioniAdmin(Guid Uidtenant)
        {
            List<IComunicazioni> retVal = new List<IComunicazioni>();
            string sql = " SELECT TOP 5 s.statuscomunicazione, u.cognome, u.nome, u.matricola, o.oggetto, c.Uidcomunicazione, c.UidcomunicazionePadre, c.idstatuslettura, c.priorita, c.datainvio " +
                         " FROM EF_comunicazioni as c " +
                         " INNER JOIN EF_comunicazioni_oggetto as o ON o.idoggetto = c.idoggetto AND o.uidtenant = c.uidtenant " +
                         " INNER JOIN EF_comunicazioni_status as s ON s.idstatuscomunicazione = c.idstatuscomunicazione AND s.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserIdMittente AND u.uidtenant = c.uidtenant " +
                         " WHERE c.UIDcomunicazione = c.UIdcomunicazionePadre AND c.idstatuscomunicazione < 100 AND c.uidtenant = @Uidtenant " +
                         " ORDER BY c.datainvio DESC ";

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
                    IComunicazioni item = new Comunicazioni
                    {
                        Datainvio = DataHelper.IfDBNull<DateTime>(row["datainvio"], DateTime.MinValue),
                        Statuscomunicazione = DataHelper.IfDBNull<string>(row["statuscomunicazione"], _stringEmpty),
                        Priorita = DataHelper.IfDBNull<int>(row["priorita"], 0),
                        Idstatuslettura = DataHelper.IfDBNull<int>(row["idstatuslettura"], 0),
                        Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        UidcomunicazionePadre = DataHelper.IfDBNull<Guid>(row["UidcomunicazionePadre"], Guid.Empty),
                        Uidcomunicazione = DataHelper.IfDBNull<Guid>(row["Uidcomunicazione"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountComunicazioniAperte(Guid UserId, Guid Uidtenant)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_comunicazioni  WHERE UserIdMittente = @UserId and uidtenant = @Uidtenant " +
                         " and UIDcomunicazione = UIdcomunicazionePadre and idstatuscomunicazione = 0 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param2.Value = UserId;
            collParams.Add(param2);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param22.Value = Uidtenant;
            collParams.Add(param22);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public List<IComunicazioni> SelectComunicazioniAperte(Guid UserId, Guid Uidtenant)
        {
            List<IComunicazioni> retVal = new List<IComunicazioni>();
            string sql = " SELECT o.oggetto, c.Uidcomunicazione, c.UidcomunicazionePadre, c.datainvio " +
                         " FROM EF_comunicazioni as c " +
                         " INNER JOIN EF_comunicazioni_oggetto as o ON o.idoggetto = c.idoggetto " +
                         " WHERE c.idstatuscomunicazione = 0 and c.UIDcomunicazione = c.UIdcomunicazionePadre AND c.UserIdMittente = @UserId and uidtenant = @Uidtenant " +
                         " ORDER BY c.datainvio DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param2.Value = UserId;
            collParams.Add(param2);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param22.Value = Uidtenant;
            collParams.Add(param22);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IComunicazioni item = new Comunicazioni
                    {
                        Datainvio = DataHelper.IfDBNull<DateTime>(row["datainvio"], DateTime.MinValue),
                        Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty),
                        UidcomunicazionePadre = DataHelper.IfDBNull<Guid>(row["UidcomunicazionePadre"], Guid.Empty),
                        Uidcomunicazione = DataHelper.IfDBNull<Guid>(row["Uidcomunicazione"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountComunicazioniAperteAdmin(Guid Uidtenant)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_comunicazioni  WHERE UIDcomunicazione = UIdcomunicazionePadre and idstatuscomunicazione = 0 AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public List<IComunicazioni> SelectComunicazioniAperteAdmin(Guid Uidtenant)
        {
            List<IComunicazioni> retVal = new List<IComunicazioni>();
            string sql = " SELECT o.oggetto, c.Uidcomunicazione, c.UidcomunicazionePadre, c.datainvio, u.cognome, u.nome " +
                         " FROM EF_comunicazioni as c " +
                         " INNER JOIN EF_comunicazioni_oggetto as o ON o.idoggetto = c.idoggetto AND o.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserIdMittente " +
                         " WHERE c.idstatuscomunicazione = 0 and c.UIDcomunicazione = c.UIdcomunicazionePadre AND c.uidtenant = @Uidtenant  " +
                         " ORDER BY c.datainvio DESC ";

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
                    IComunicazioni item = new Comunicazioni
                    {
                        Datainvio = DataHelper.IfDBNull<DateTime>(row["datainvio"], DateTime.MinValue),
                        Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        UidcomunicazionePadre = DataHelper.IfDBNull<Guid>(row["UidcomunicazionePadre"], Guid.Empty),
                        Uidcomunicazione = DataHelper.IfDBNull<Guid>(row["Uidcomunicazione"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public IComunicazioni SelectEmailMittente(Guid UIDcomunicazionePadre)
        {
            IComunicazioni retVal = null;
            string sql = " SELECT u.email, c.UserIdMittente FROM EF_comunicazioni as c " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserIdMittente " +
                         " WHERE c.UIDcomunicazione = @UIDcomunicazionePadre ";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UIDcomunicazionePadre", DbType.Guid);
            param0.Value = UIDcomunicazionePadre;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Comunicazioni
                {
                    Emailmittente = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                    UserIdMittente = DataHelper.IfDBNull<Guid>(row["UserIdMittente"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }

        public int UpdateRiAperturaComunicazione(Guid UidcomunicazionePadre, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = " UPDATE EF_comunicazioni SET [idstatuscomunicazione] = 0, [dataultimoaggiornamento] = @dataultimoaggiornamento " +
                         " WHERE UidcomunicazionePadre = @UidcomunicazionePadre AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@UidcomunicazionePadre", DbType.Guid);
            param11.Value = UidcomunicazionePadre;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@dataultimoaggiornamento", DbType.DateTime);
            param12.Value = DateTime.Now;
            collParams.Add(param12);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public List<IComunicazioni> SelectTop5ComunicazioniPartner(Guid Uidtenant)
        {
            List<IComunicazioni> retVal = new List<IComunicazioni>();
            string sql = " SELECT TOP 5 s.statuscomunicazione, u.cognome, u.nome, u.matricola, o.oggetto, c.Uidcomunicazione, c.UidcomunicazionePadre, c.idstatuslettura, c.priorita, c.datainvio " +
                         " FROM EF_comunicazioni as c " +
                         " INNER JOIN EF_comunicazioni_oggetto as o ON o.idoggetto = c.idoggetto AND o.uidtenant = c.uidtenant " +
                         " INNER JOIN EF_comunicazioni_status as s ON s.idstatuscomunicazione = c.idstatuscomunicazione AND s.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserIdMittente AND u.uidtenant = c.uidtenant " +
                         " WHERE c.UIDcomunicazione = c.UIdcomunicazionePadre AND c.idstatuscomunicazione < 100 AND u.gradecode IN ('10','15') AND c.uidtenant = @Uidtenant " +
                         " ORDER BY c.datainvio DESC ";

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
                    IComunicazioni item = new Comunicazioni
                    {
                        Datainvio = DataHelper.IfDBNull<DateTime>(row["datainvio"], DateTime.MinValue),
                        Statuscomunicazione = DataHelper.IfDBNull<string>(row["statuscomunicazione"], _stringEmpty),
                        Priorita = DataHelper.IfDBNull<int>(row["priorita"], 0),
                        Idstatuslettura = DataHelper.IfDBNull<int>(row["idstatuslettura"], 0),
                        Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        UidcomunicazionePadre = DataHelper.IfDBNull<Guid>(row["UidcomunicazionePadre"], Guid.Empty),
                        Uidcomunicazione = DataHelper.IfDBNull<Guid>(row["Uidcomunicazione"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        // conta comunicazioni
        // FILTRO: UserId, datadal, dataal, oggetto, idstatuscomunicazione
        public int SelectCountComunicazioniPartner(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant)
        {
            string condWhere = "";
            Guid UserIdM = (Guid)Membership.GetUser().ProviderUserKey;
            if (autorizzatore == 1)
            {
                condWhere += " AND c.UserIdMittente = @UserIdM ";
            }
            else
            {
                if (UserId != Guid.Empty) condWhere += " AND c.UserIdMittente = @UserId ";
            }
            if (datadal > DateTime.MinValue) condWhere += " AND c.datainvio >= @datadal ";
            if (dataal > DateTime.MinValue) condWhere += " AND c.datainvio <= @dataal ";
            if (oggetto > 0) condWhere += " AND c.idoggetto = @oggetto ";
            if (idstatuscomunicazione > -1) condWhere += " AND c.idstatuscomunicazione = @idstatuscomunicazione ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_comunicazioni as c " +
                         " INNER JOIN EF_comunicazioni_oggetto as o ON o.idoggetto = c.idoggetto AND c.uidtenant = o.uidtenant " +
                         " INNER JOIN EF_comunicazioni_status as s ON s.idstatuscomunicazione = c.idstatuscomunicazione AND c.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserIdMittente AND c.uidtenant = u.uidtenant " +
                         " WHERE c.idcomunicazione > 0 and c.UIDcomunicazione = c.UIdcomunicazionePadre and u.gradecode IN ('10','15') AND c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.Date);
                param0.Value = datadal;
                collParams.Add(param0);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.Date);
                param1.Value = dataal;
                collParams.Add(param1);
            }
            if (oggetto > 0)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@oggetto", DbType.Int32);
                param3.Value = oggetto;
                collParams.Add(param3);
            }
            if (autorizzatore == 1)
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdM", DbType.Guid);
                param5.Value = UserIdM;
                collParams.Add(param5);
            }
            else
            {
                if (UserId != Guid.Empty)
                {
                    IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                    param2.Value = UserId;
                    collParams.Add(param2);
                }
            }
            if (idstatuscomunicazione > -1)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscomunicazione", DbType.Int32);
                param4.Value = idstatuscomunicazione;
                collParams.Add(param4);
            }
            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param6.Value = Uidtenant;
            collParams.Add(param6);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista consumi fuelcard driver
        // FILTRO: UserId, datadal, dataal, oggetto, idstatuscomunicazione
        public List<IComunicazioni> SelectComunicazioniPartner(Guid UserId, DateTime datadal, DateTime dataal, int oggetto, int idstatuscomunicazione, int autorizzatore, Guid Uidtenant, int numrecord, int pagina)
        {
            string condWhere = "";
            Guid UserIdM = (Guid)Membership.GetUser().ProviderUserKey;
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

            if (autorizzatore == 1)
            {
                condWhere += " AND (c.UserIdMittente = @UserIdM OR c.UseridDestinatario = @UserIdM) ";
            }
            else
            {
                if (UserId != Guid.Empty) condWhere += " AND c.UserIdMittente = @UserId ";
            }
            if (datadal > DateTime.MinValue) condWhere += " AND c.datainvio >= @datadal ";
            if (dataal > DateTime.MinValue) condWhere += " AND c.datainvio <= @dataal ";
            if (oggetto > 0) condWhere += " AND c.idoggetto = @oggetto ";
            if (idstatuscomunicazione > -1) condWhere += " AND c.idstatuscomunicazione = @idstatuscomunicazione ";

            List<IComunicazioni> retVal = new List<IComunicazioni>();
            string sql = " SELECT c.idcomunicazione, s.statuscomunicazione, u.cognome, u.nome, u.matricola, u1.cognome as cognomedest, u1.nome as nomedest, o.oggetto, g.grade, " +
                         " c.Uidcomunicazione, c.UidcomunicazionePadre, c.idstatuslettura, c.priorita, c.datainvio, c.dataultimoaggiornamento, so.siglasocieta, " +
                         " (SELECT TOP 1 datachiusura  FROM EF_comunicazioni WHERE  UIDcomunicazione = c.UIdcomunicazionePadre  ORDER BY datainvio DESC) as datachiusura, " +
                         " (SELECT TOP 1 CONCAT(cognome, ' ', nome) FROM EF_comunicazioni INNER JOIN EF_users ON EF_comunicazioni.UserIdMittente = EF_users.UserId AND EF_comunicazioni.uidtenant = EF_users.uidtenant WHERE UIdcomunicazionePadre = c.UIdcomunicazionePadre ORDER BY datainvio DESC ) as ultimomittente " +
                         " FROM EF_comunicazioni as c " +
                         " INNER JOIN EF_comunicazioni_oggetto as o ON o.idoggetto = c.idoggetto AND c.uidtenant = o.uidtenant " +
                         " INNER JOIN EF_comunicazioni_status as s ON s.idstatuscomunicazione = c.idstatuscomunicazione AND c.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserIdMittente AND c.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_societa as so ON u.codsocieta = so.codsocieta AND c.uidtenant = so.uidtenant " +
                         " LEFT JOIN EF_grade as g ON u.gradecode = g.codgrade AND g.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_users as u1 ON u1.UserId = c.UseridDestinatario AND c.uidtenant = u1.uidtenant " +
                         " WHERE c.idcomunicazione > 0 and c.UIDcomunicazione = c.UIdcomunicazionePadre and u.gradecode IN ('10','15') AND c.uidtenant = @Uidtenant " + condWhere +
                         " ORDER BY c.dataultimoaggiornamento DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.Date);
                param0.Value = datadal;
                collParams.Add(param0);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.Date);
                param1.Value = dataal;
                collParams.Add(param1);
            }
            if (oggetto > 0)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@oggetto", DbType.Int32);
                param3.Value = oggetto;
                collParams.Add(param3);
            }
            if (autorizzatore == 1)
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdM", DbType.Guid);
                param5.Value = UserIdM;
                collParams.Add(param5);
            }
            else
            {
                if (UserId != Guid.Empty)
                {
                    IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                    param2.Value = UserId;
                    collParams.Add(param2);
                }
            }
            if (idstatuscomunicazione > -1)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscomunicazione", DbType.Int32);
                param4.Value = idstatuscomunicazione;
                collParams.Add(param4);
            }
            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param6.Value = Uidtenant;
            collParams.Add(param6);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IComunicazioni item = new Comunicazioni
                    {
                        Idcomunicazione = DataHelper.IfDBNull<int>(row["idcomunicazione"], 0),
                        Datainvio = DataHelper.IfDBNull<DateTime>(row["datainvio"], DateTime.MinValue),
                        Datachiusura = DataHelper.IfDBNull<DateTime>(row["datachiusura"], DateTime.MinValue),
                        Statuscomunicazione = DataHelper.IfDBNull<string>(row["statuscomunicazione"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Priorita = DataHelper.IfDBNull<int>(row["priorita"], 0),
                        Idstatuslettura = DataHelper.IfDBNull<int>(row["idstatuslettura"], 0),
                        Oggetto = DataHelper.IfDBNull<string>(row["oggetto"], _stringEmpty),
                        Ultimomittente = DataHelper.IfDBNull<string>(row["ultimomittente"], _stringEmpty),
                        Destinatario = DataHelper.IfDBNull<string>(row["cognomedest"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nomedest"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        UidcomunicazionePadre = DataHelper.IfDBNull<Guid>(row["UidcomunicazionePadre"], Guid.Empty),
                        Uidcomunicazione = DataHelper.IfDBNull<Guid>(row["Uidcomunicazione"], Guid.Empty),
                        Dataultimoaggiornamento = DataHelper.IfDBNull<DateTime>(row["dataultimoaggiornamento"], DateTime.MinValue)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
    }
}