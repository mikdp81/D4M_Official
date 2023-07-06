// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CronProvider.aspx.cs" company="">
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
    [SectionName("cron.provider/CronSection")]
    public class CronProvider : DFleetDataProvider, ICronProvider
    {

        public ICron UrlBlob()
        {
            ICron retVal = null;
            string sql = "SELECT urlblob FROM EF_blob ";
            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Urlblob = DataHelper.IfDBNull<string>(row["urlblob"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public ICron CredNetwork()
        {
            ICron retVal = null;
            string sql = "SELECT * FROM EF_network_credential ";
            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Network_user = DataHelper.IfDBNull<string>(row["network_user"], _stringEmpty),
                    Network_password = DataHelper.IfDBNull<string>(row["network_password"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }

        //elenco campi
        public List<ICron> SelectMulteDapagare()
        {
            List<ICron> retVal = new List<ICron>();

            string sql = "SELECT * FROM EF_multe WHERE idstatuspagamento = 0 AND idtitolarepagamento = 0 AND (CAST(datainviomail as date) <= CAST(GETDATE()-1 as date) OR datainviomail is null) ";

            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //aggiorna status pagamento 
        public int UpdatePagamento(Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = " UPDATE EF_multe SET [idstatuspagamento] = 10, [idtitolarepagamento] = 100 WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param23.Value = Uid;
            collParams.Add(param23);

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

        //seleziona cedolini in basa a mese e anno
        public List<ICron> SelectCedolini(string mese, string anno)
        {
            List<ICron> retVal = new List<ICron>();
            string sql = "SELECT u.matricola, u.nome, u.cognome, t.tipologiacedolino, u.codsocieta, s.societa, u.codicecdc, m.targa, c.importo " +
                         " FROM EF_cedolini as c " +
                         " LEFT JOIN EF_cedolini_tipologie as t ON c.idtipologiacedolino = t.idtipologiacedolino " +
                         " LEFT JOIN EF_multe as m ON c.idmulta = m.idmulta " +
                         " LEFT JOIN EF_users as u ON c.UserId = u.UserId " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = u.codsocieta " +
                         " WHERE MONTH(c.datains) = @mese AND YEAR(c.datains) = @anno ORDER BY datains ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@mese", DbType.String);
            param2.Value = mese;
            collParams.Add(param2);
           
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@anno", DbType.String);
            param3.Value = anno;
            collParams.Add(param3);
            

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Tipologiacedolino = DataHelper.IfDBNull<string>(row["tipologiacedolino"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Codicecdc = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Importo = DataHelper.IfDBNull<decimal>(row["importo"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //inserimento file cron
        public int InsertFileCron(ICron value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_cron_file ([data],[tipodocumento],[pathfile],[nomefile],[uidtenant]) " +
                         " VALUES (@data,@tipodocumento,@pathfile,@nomefile,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@data", DbType.DateTime);
            param0.Value = DateTime.Now;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@tipodocumento", DbType.String);
            param1.Value = value.Tipodocumento;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@pathfile", DbType.String);
            param2.Value = value.Pathfile;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@nomefile", DbType.String);
            param3.Value = value.Nomefile;
            collParams.Add(param3);

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


        //lista contratti user in scadenza
        public List<ICron> SelectContrattiUserInScadenza()
        {
            List<ICron> retVal = new List<ICron>();

            string sql = " SELECT * FROM EF_contratti WHERE (CAST(datafinecontratto as date) <= CAST(DATEADD(MONTH, -6, GETDATE()) as date)) ORDER BY datafinecontratto ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }        
        
        //esistenza users carpolicy
        public bool ExistUserCarPolicy(int idutente)
        {
            bool retVal = false;
            string sql = " SELECT idapprovazione FROM EF_users_carpolicy WHERE idutente = @idutente and approvato = 0 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idutente", DbType.Int32);
            param1.Value = idutente;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }


        //inserimento nuovo user carpolicy
        public int InsertUserCarPolicy(ICron value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Dataapprovazione > DateTime.MinValue)
            {
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@dataapprovazione", DbType.DateTime);
                param10.Value = value.Dataapprovazione;
                collParams.Add(param10);

                sqlfield += " ,[dataapprovazione] ";
                sqlvalue += " ,@dataapprovazione ";
            }

            if (value.Datamail > DateTime.MinValue)
            {
                IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@datamail", DbType.DateTime);
                param14.Value = value.Datamail;
                collParams.Add(param14);

                sqlfield += " ,[datamail] ";
                sqlvalue += " ,@datamail ";
            }

            string sql = "INSERT INTO EF_users_carpolicy ([idutente],[codsocieta],[codcarpolicy],[idapprovatore],[flgmail],[approvato],[uidtenant] " + sqlfield + " ) " +
                         " VALUES (@idutente,@codsocieta,@codcarpolicy,@idapprovatore,@flgmail,@approvato,@uidtenant " + sqlvalue + " ) ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idutente", DbType.Int32);
            param1.Value = value.Idutente;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param3.Value = value.Codcarpolicy;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idapprovatore", DbType.Int32);
            param4.Value = value.Idapprovatore;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@flgmail", DbType.String);
            param5.Value = value.Flgmail;
            collParams.Add(param5);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@approvato", DbType.Int32);
            param8.Value = value.Approvato;
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

        //dettagli iduser
        public ICron DetailId(Guid UserId)
        {
            ICron retVal = null;
            string sql = "SELECT * FROM EF_users WHERE UserId = @UserId";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Idutente = DataHelper.IfDBNull<int>(row["iduser"], 0),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Gradecode = DataHelper.IfDBNull<string>(row["gradecode"], _stringEmpty),
                    Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                };
                data.Dispose();
            }
            return retVal;
        }

        public List<ICron> SelectContrattiDaChiudere()
        {
            string dataoggi = DateTime.Now.ToString("yyyy-MM-dd");
            List<ICron> retVal = new List<ICron>();
            string sql = " SELECT a.idcontratto, c.Uid FROM EF_contratti as c INNER JOIN EF_contratti_assegnazioni as a ON c.idcontratto = a.idcontratto WHERE c.datafinecontratto = @dataoggi ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.String);
            param2.Value = dataoggi;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Idcontratto = DataHelper.IfDBNull<int>(row["idcontratto"], 0),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int UpdateContrattiDaChiudere(Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = " UPDATE EF_contratti SET [idstatuscontratto] = 100 WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param23.Value = Uid;
            collParams.Add(param23);

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

        public int UpdateContrattiAssDaChiudere(int idcontratto, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = " UPDATE EF_contratti_assegnazioni SET [idstatusassegnazione] = 100 WHERE idcontratto = @idcontratto AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@idcontratto", DbType.Int32);
            param23.Value = idcontratto;
            collParams.Add(param23);

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


        public List<ICron> SelectComunicazioniInserite()
        {
            List<ICron> retVal = new List<ICron>();

            string sql = " SELECT * FROM EF_comunicazioni WHERE idstatuslettura=0 and datainvio <= DATEADD(MINUTE, -3, GETDATE()) ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Idcomunicazione = DataHelper.IfDBNull<int>(row["idcomunicazione"], 0),
                        Datainvio = DataHelper.IfDBNull<DateTime>(row["datainvio"], DateTime.MinValue),
                        UserIdMittente = DataHelper.IfDBNull<Guid>(row["UserIdMittente"], Guid.Empty),
                        UidcomunicazionePadre = DataHelper.IfDBNull<Guid>(row["UidcomunicazionePadre"], Guid.Empty),
                        Uidcomunicazione = DataHelper.IfDBNull<Guid>(row["Uidcomunicazione"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //dettagli template email
        public ICron ReturnTemplateEmail(int idtemplate)
        {
            ICron retVal = null;
            string sql = "SELECT * FROM EF_email_template WHERE idtemplate = @idtemplate";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idtemplate", DbType.Int32);
            param0.Value = idtemplate;

            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
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
        public List<ICron> SelectViewConcur()
        {
            List<ICron> retVal = new List<ICron>();
            string sql = " SELECT * FROM view_concur ORDER BY annumber, CODGEST DESC ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Modello = DataHelper.IfDBNull<string>(row["MODELLO"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["IDEMPL"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["ANNUMBER"], _stringEmpty),
                        Codservice = DataHelper.IfDBNull<string>(row["CODGEST"], _stringEmpty),
                        Numerofuelcard = DataHelper.IfDBNull<string>(row["IDFUELCARD"], _stringEmpty),
                        Datainizioperiodo = DataHelper.IfDBNull<DateTime>(row["DTSTARTVL"], DateTime.MinValue),
                        Datafineperiodo = DataHelper.IfDBNull<DateTime>(row["DTENDVL"], DateTime.MinValue)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int UpdateStoricoImportazione(ICron value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_importazioni_storico SET [importato] = @importato, [righeimportate] = @righeimportate, " +
                            " righetotali = @righetotali , [texterrori] = @texterrori ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Datafineimportazione > DateTime.MinValue)
            {
                sql += " ,[datafineimportazione] = @datafineimportazione ";
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@datafineimportazione", DbType.DateTime);
                param10.Value = value.Datafineimportazione;
                collParams.Add(param10);
            }

            if (value.Dataimportazione > DateTime.MinValue)
            {
                sql += " ,[dataimportazione] = @dataimportazione ";
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@dataimportazione", DbType.DateTime);
                param2.Value = value.Dataimportazione;
                collParams.Add(param2);
            }
            
            sql += " WHERE idprog = @idprog AND uidtenant = @Uidtenant ";

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@importato", DbType.String);
            param1.Value = value.Importato;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@righeimportate", DbType.Int32);
            param3.Value = value.Righeimportate;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@righetotali", DbType.Int32);
            param4.Value = value.Righetotali;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@texterrori", DbType.String);
            param5.Value = value.Texterrori;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@idprog", DbType.Int32);
            param6.Value = value.Idprog;
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
        public ICron DetailImportazioni(int idprog)
        {
            ICron retVal = null;
            string sql = "SELECT EF_importazioni_storico.*, EF_tipofile.tipofile FROM EF_importazioni_storico INNER JOIN EF_tipofile ON EF_importazioni_storico.idtipofile = EF_tipofile.idtipofile WHERE idprog = @idprog";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idprog", DbType.Int32);
            param0.Value = idprog;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Idprog = DataHelper.IfDBNull<int>(row["idprog"], 0),
                    Idtipofile = DataHelper.IfDBNull<int>(row["idtipofile"], 0),
                    Tipofile = DataHelper.IfDBNull<string>(row["tipofile"], _stringEmpty),
                    Nomefile = DataHelper.IfDBNull<string>(row["nomefile"], _stringEmpty),
                    Importato = DataHelper.IfDBNull<string>(row["importato"], _stringEmpty),
                    Datacaricato = DataHelper.IfDBNull<DateTime>(row["datacaricato"], DateTime.MinValue),
                    Dataimportazione = DataHelper.IfDBNull<DateTime>(row["dataimportazione"], DateTime.MinValue),
                    Periododal = DataHelper.IfDBNull<DateTime>(row["periododal"], DateTime.MinValue),
                    Periodoal = DataHelper.IfDBNull<DateTime>(row["periodoal"], DateTime.MinValue),
                    Righeimportate = DataHelper.IfDBNull<int>(row["righeimportate"], 0),
                    Righetotali = DataHelper.IfDBNull<int>(row["righetotali"], 0),
                    Texterrori = DataHelper.IfDBNull<string>(row["texterrori"], _stringEmpty),
                    Cartellaimport = DataHelper.IfDBNull<string>(row["cartellaimport"], _stringEmpty),
                    UserIDIns = DataHelper.IfDBNull<Guid>(row["UserIDIns"], Guid.Empty),
                    Idtemplate = DataHelper.IfDBNull<int>(row["idtemplate"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int InsertStoricoImportazione(ICron value)
        {
            int retVal = 0;
            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Periododal > DateTime.MinValue)
            {
                IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@periododal", DbType.DateTime);
                param16.Value = value.Periododal;
                collParams.Add(param16);

                sqlfield += " ,[periododal] ";
                sqlvalue += " ,@periododal ";
            }

            if (value.Periodoal > DateTime.MinValue)
            {
                IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@periodoal", DbType.DateTime);
                param17.Value = value.Periodoal;
                collParams.Add(param17);

                sqlfield += " ,[periodoal] ";
                sqlvalue += " ,@periodoal ";
            }

            string sql = " INSERT INTO EF_importazioni_storico ([idtipofile],[nomefile],[datacaricato],[cartellaimport],[flgcron],[uidtenant] " + sqlfield + ") " +
                            " VALUES (@idtipofile, @nomefile, @datacaricato, @cartellaimport,@flgcron,@uidtenant" + sqlvalue + ") ";

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idtipofile", DbType.Int32);
            param1.Value = value.Idtipofile;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@nomefile", DbType.String);
            param2.Value = value.Nomefile;
            collParams.Add(param2);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@cartellaimport", DbType.String);
            param5.Value = value.Cartellaimport;
            collParams.Add(param5);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@datacaricato", DbType.DateTime);
            param3.Value = DateTime.Now;
            collParams.Add(param3);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@flgcron", DbType.Int32);
            param6.Value = value.Flgcron;
            collParams.Add(param6);

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
        public List<ICron> SelectImportazioni()
        {
            List<ICron> retVal = new List<ICron>();
            string sql = "SELECT TOP 500 * FROM EF_importazioni_storico INNER JOIN EF_tipofile ON EF_importazioni_storico.idtipofile = EF_tipofile.idtipofile ORDER BY datacaricato DESC";
            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Idprog = DataHelper.IfDBNull<int>(row["idprog"], 0),
                        Tipofile = DataHelper.IfDBNull<string>(row["tipofile"], _stringEmpty),
                        Nomefile = DataHelper.IfDBNull<string>(row["nomefile"], _stringEmpty),
                        Importato = DataHelper.IfDBNull<string>(row["importato"], _stringEmpty),
                        Datacaricato = DataHelper.IfDBNull<DateTime>(row["datacaricato"], DateTime.MinValue),
                        Periododal = DataHelper.IfDBNull<DateTime>(row["periododal"], DateTime.MinValue),
                        Periodoal = DataHelper.IfDBNull<DateTime>(row["periodoal"], DateTime.MinValue),
                        Righeimportate = DataHelper.IfDBNull<int>(row["righeimportate"], 0),
                        Righetotali = DataHelper.IfDBNull<int>(row["righetotali"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<ICron> SelectImportazioniCron(Guid Uidtenant)
        {
            List<ICron> retVal = new List<ICron>();
            string sql = " SELECT TOP 500 * FROM EF_importazioni_storico " +
                         " INNER JOIN EF_tipofile ON EF_importazioni_storico.idtipofile = EF_tipofile.idtipofile AND EF_importazioni_storico.uidtenant = EF_tipofile.uidtenant " +
                         " WHERE flgcron = 1 AND EF_importazioni_storico.uidtenant = @Uidtenant ORDER BY datacaricato DESC";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Idprog = DataHelper.IfDBNull<int>(row["idprog"], 0),
                        Tipofile = DataHelper.IfDBNull<string>(row["tipofile"], _stringEmpty),
                        Nomefile = DataHelper.IfDBNull<string>(row["nomefile"], _stringEmpty),
                        Importato = DataHelper.IfDBNull<string>(row["importato"], _stringEmpty),
                        Datacaricato = DataHelper.IfDBNull<DateTime>(row["datacaricato"], DateTime.MinValue),
                        Dataimportazione = DataHelper.IfDBNull<DateTime>(row["dataimportazione"], DateTime.MinValue),
                        Datafineimportazione = DataHelper.IfDBNull<DateTime>(row["datafineimportazione"], DateTime.MinValue),
                        Periododal = DataHelper.IfDBNull<DateTime>(row["periododal"], DateTime.MinValue),
                        Periodoal = DataHelper.IfDBNull<DateTime>(row["periodoal"], DateTime.MinValue),
                        Righeimportate = DataHelper.IfDBNull<int>(row["righeimportate"], 0),
                        Righetotali = DataHelper.IfDBNull<int>(row["righetotali"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateFuelCardConsumoCount(ICron value)
        {
            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users_fuelcard_consumo SET [numerofattura] = @numerofattura ";

            if (value.Datafattura > DateTime.MinValue)
            {
                sql += " ,[datafattura] = @datafattura ";
                IDbDataParameter param48 = _dataHelper.ProviderConn.CreateDataParameter("@datafattura", DbType.DateTime);
                param48.Value = value.Datafattura;
                collParams.Add(param48);
            }

            sql += " WHERE idtransazione = @idtransazione and numerofuelcard = @numerofuelcard AND uidtenant = @Uidtenant SELECT @@ROWCOUNT as totRowCorrect ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idtransazione", DbType.String);
            param0.Value = value.Idtransazione;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@numerofuelcard", DbType.String);
            param1.Value = value.Numerofuelcard;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@numerofattura", DbType.String);
            param2.Value = value.Numerofattura;
            collParams.Add(param2);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }
        public bool ExistFuelCardConsumo2(string idtransazione, string numerofuelcard, DateTime datatransazione, decimal importo)
        {
            bool retVal = false;
            string sql = " SELECT idcarb FROM EF_users_fuelcard_consumo WHERE idtransazione = @idtransazione and numerofuelcard = @numerofuelcard " +
                         " and datatransazione = @datatransazione and importofinalefatturato = @importo ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idtransazione", DbType.String);
            param0.Value = idtransazione;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@numerofuelcard", DbType.String);
            param1.Value = numerofuelcard;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@datatransazione", DbType.DateTime);
            param2.Value = datatransazione;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@importo", DbType.Decimal);
            param3.Value = importo;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public bool ExistFuelCardConsumo3(string numerofuelcard, DateTime datatransazione, decimal importo)
        {
            bool retVal = false;
            string sql = " SELECT idcarb FROM EF_users_fuelcard_consumo WHERE numerofuelcard = @numerofuelcard " +
                         " and datatransazione = @datatransazione and importofinalefatturato = @importo ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@numerofuelcard", DbType.String);
            param1.Value = numerofuelcard;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@datatransazione", DbType.DateTime);
            param2.Value = datatransazione;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@importo", DbType.Decimal);
            param3.Value = importo;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public int InsertFuelCardConsumo(ICron value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Datafattura > DateTime.MinValue)
            {
                IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@datafattura", DbType.DateTime);
                param16.Value = value.Datafattura;
                collParams.Add(param16);

                sqlfield += " ,[datafattura] ";
                sqlvalue += " ,@datafattura ";
            }

            string sql = " INSERT INTO EF_users_fuelcard_consumo ([idprog],[idtransazione],[datatransazione],[codicepuntovendita],[ragionesociale],[localita],[indirizzo],[nazione],[tiporifornimento], " +
                         " [kmtransazione],[numerofuelcard],[targa],[quantita],[prezzo],[importo],[importoiva],[numerofattura],[importofinalefatturato],[datauserins],[UserIDIns],[idcompagnia]," +
                         " [uidtenant] " + sqlfield + " ) " +
                         " VALUES (@idprog,@idtransazione,@datatransazione,@codicepuntovendita,@ragionesociale,@localita,@indirizzo,@nazione,@tiporifornimento,@kmtransazione, " +
                         " @numerofuelcard,@targa,@quantita,@prezzo,@importo,@importoiva,@numerofattura,@importofinalefatturato,@datauserins,@UserIDIns,@idcompagnia,@uidtenant " + sqlvalue + " ) ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idprog", DbType.Int32);
            param0.Value = value.Idprog;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idtransazione", DbType.String);
            param1.Value = value.Idtransazione;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@datatransazione", DbType.DateTime);
            param2.Value = value.Datatransazione;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codicepuntovendita", DbType.String);
            param3.Value = value.Codicepuntovendita;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@ragionesociale", DbType.String);
            param4.Value = value.Ragionesociale;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@localita", DbType.String);
            param5.Value = value.Localita;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@indirizzo", DbType.String);
            param6.Value = value.Indirizzo;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@nazione", DbType.String);
            param7.Value = value.Nazione;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@kmtransazione", DbType.Decimal);
            param8.Value = value.Kmtransazione;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@numerofuelcard", DbType.String);
            param9.Value = value.Numerofuelcard;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param10.Value = value.Targa;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@quantita", DbType.Decimal);
            param11.Value = value.Quantita;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@prezzo", DbType.Decimal);
            param12.Value = value.Prezzo;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@importo", DbType.Decimal);
            param13.Value = value.Importo;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@importoiva", DbType.Decimal);
            param14.Value = value.Importoiva;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@numerofattura", DbType.String);
            param15.Value = value.Numerofattura;
            collParams.Add(param15);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@importofinalefatturato", DbType.Decimal);
            param17.Value = value.Importofinalefatturato;
            collParams.Add(param17);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@tiporifornimento", DbType.String);
            param20.Value = value.Tiporifornimento;
            collParams.Add(param20);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.DateTime);
            param18.Value = DateTime.Now;
            collParams.Add(param18);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param19.Value = value.UserIDIns;
            collParams.Add(param19);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
            param21.Value = value.Idcompagnia;
            collParams.Add(param21);

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
        public ICron ExistCodjatoAuto(string marca, string modello, string serie)
        {
            ICron retVal = null;
            string sql = "SELECT * FROM EF_fringe_aci WHERE marca = @marca and modello = @modello and serie = @serie ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
            param0.Value = marca;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
            param1.Value = modello;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@serie", DbType.String);
            param2.Value = serie;
            collParams.Add(param2);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                    Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                    Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                    Serie = DataHelper.IfDBNull<string>(row["serie"], _stringEmpty),
                    Idfringe = DataHelper.IfDBNull<int>(row["idfringe"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int InsertFringeBenefit(ICron value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_fringe_aci ([codjatoauto],[marca],[modello],[serie],[costokm],[fringe25],[fringe30],[fringe50],[fringe60], " +
                         " [periododal],[periodoal],[datauserins],[UserIDIns],[uidtenant]) " +
                         " VALUES (@codjatoauto,@marca,@modello,@serie,@costokm,@fringe25,@fringe30,@fringe50,@fringe60,@periododal,@periodoal,@datauserins,@UserIDIns,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = value.Codjatoauto;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
            param1.Value = value.Marca;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
            param2.Value = value.Modello;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@serie", DbType.String);
            param3.Value = value.Serie;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@costokm", DbType.Decimal);
            param4.Value = value.Costokm;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@fringe25", DbType.Decimal);
            param5.Value = value.Fringe25;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@fringe30", DbType.Decimal);
            param6.Value = value.Fringe30;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@fringe50", DbType.Decimal);
            param7.Value = value.Fringe50;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@fringe60", DbType.Decimal);
            param8.Value = value.Fringe60;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@periododal", DbType.Date);
            param9.Value = value.Periododal;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@periodoal", DbType.Date);
            param10.Value = value.Periodoal;
            collParams.Add(param10);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.DateTime);
            param18.Value = DateTime.Now;
            collParams.Add(param18);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param19.Value = value.UserIDIns;
            collParams.Add(param19);

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
        public bool ExistFattura(string codfornitore, string numerodocumento, DateTime datadocumento)
        {
            bool retVal = false;
            string sql = "SELECT idfattura FROM EF_fatturexml WHERE codfornitore = @codfornitore and numerodocumento = @numerodocumento and datadocumento = @datadocumento ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param0.Value = codfornitore;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@numerodocumento", DbType.String);
            param1.Value = numerodocumento;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@datadocumento", DbType.DateTime);
            param2.Value = datadocumento;
            collParams.Add(param2);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public int InsertFattureXML(ICron value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Datadocumento > DateTime.MinValue)
            {
                IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@datadocumento", DbType.DateTime);
                param14.Value = value.Datadocumento;
                collParams.Add(param14);

                sqlfield += " ,[datadocumento] ";
                sqlvalue += " ,@datadocumento ";
            }

            if (value.Datacontratto > DateTime.MinValue)
            {
                IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datacontratto", DbType.DateTime);
                param15.Value = value.Datacontratto;
                collParams.Add(param15);

                sqlfield += " ,[datacontratto] ";
                sqlvalue += " ,@datacontratto ";
            }

            if (value.Datascadenzapagamento > DateTime.MinValue)
            {
                IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@datascadenzapagamento", DbType.DateTime);
                param16.Value = value.Datascadenzapagamento;
                collParams.Add(param16);

                sqlfield += " ,[datascadenzapagamento] ";
                sqlvalue += " ,@datascadenzapagamento ";
            }

            string sql = " INSERT INTO EF_fatturexml ([tipodocumento],[codfornitore],[fornitore],[codcommittente],[committente],[numerodocumento],[importototale],[numerocontratto], " +
                         " [importopagamento],[datauserins],[datausermod],[UserIDIns],[UserIdMod],[filexml],[divisa],[idstatusfattura],[uidtenant] " + sqlfield + ") " +
                         " VALUES (@tipodocumento,@codfornitore,@fornitore,@codcommittente,@committente,@numerodocumento,@importototale,@numerocontratto, " +
                         " @importopagamento,@datauserins,@datausermod,@UserIDIns,@UserIdMod,@filexml,@divisa,0,@uidtenant " + sqlvalue + ") ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@tipodocumento", DbType.String);
            param0.Value = value.Tipodocumento;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param1.Value = value.Codfornitore;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@fornitore", DbType.String);
            param2.Value = value.Fornitore;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codcommittente", DbType.String);
            param3.Value = value.Codcommittente;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@committente", DbType.String);
            param4.Value = value.Committente;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerodocumento", DbType.String);
            param5.Value = value.Numerodocumento;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@importototale", DbType.Decimal);
            param6.Value = value.Importototale;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
            param7.Value = value.Numerocontratto;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@importopagamento", DbType.Decimal);
            param8.Value = value.Importopagamento;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@numerofuelcard", DbType.String);
            param9.Value = value.Numerofuelcard;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.DateTime);
            param10.Value = DateTime.Now;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param11.Value = value.UserIDIns;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.DateTime);
            param12.Value = DateTime.Now;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param13.Value = value.UserIDIns;
            collParams.Add(param13);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@filexml", DbType.String);
            param17.Value = value.Filexml;
            collParams.Add(param17);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@divisa", DbType.String);
            param19.Value = value.Divisa;
            collParams.Add(param19);

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
        public int InsertFattureXMLDettaglio(ICron value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Datainizioperiodo > DateTime.MinValue)
            {
                IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@datainizioperiodo", DbType.DateTime);
                param19.Value = value.Datainizioperiodo;
                collParams.Add(param19);

                sqlfield += " ,[datainizioperiodo] ";
                sqlvalue += " ,@datainizioperiodo ";
            }

            if (value.Datafineperiodo > DateTime.MinValue)
            {
                IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@datafineperiodo", DbType.DateTime);
                param20.Value = value.Datafineperiodo;
                collParams.Add(param20);

                sqlfield += " ,[datafineperiodo] ";
                sqlvalue += " ,@datafineperiodo ";
            }

            string sql = " INSERT INTO EF_fatturexml_dettaglio ([Uidfattura],[numerolionea],[descrizione],[quantita],[prezzoun],[prezzotot],[iva],[tipodato],[riftesto],[centrocostoabb], " +
                         " [tipocentrocosto],[centrocostoabb2],[tipocentrocosto2],[naturaiva],[datauserins],[datausermod],[UserIDIns],[UserIdMod],[uidtenant] " + sqlfield + ") " +
                         " VALUES (@Uidfattura,@numerolionea,@descrizione,@quantita,@prezzoun,@prezzotot,@iva,@tipodato,@riftesto,@centrocostoabb,@tipocentrocosto, " +
                         " @centrocostoabb2,@tipocentrocosto2,@naturaiva,@datauserins,@datausermod,@UserIDIns,@UserIdMod,@uidtenant " + sqlvalue + ") ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uidfattura", DbType.Guid);
            param0.Value = value.Uidfattura;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@numerolionea", DbType.String);
            param1.Value = value.Numerolionea;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@descrizione", DbType.String);
            param2.Value = value.Descrizione;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@quantita", DbType.Int32);
            param3.Value = value.QuantitaP;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@prezzoun", DbType.Decimal);
            param4.Value = value.Prezzoun;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@prezzotot", DbType.Decimal);
            param5.Value = value.Prezzotot;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@iva", DbType.Decimal);
            param6.Value = value.Iva;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@tipodato", DbType.String);
            param7.Value = value.Tipodato;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@riftesto", DbType.String);
            param8.Value = value.Riftesto;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@centrocostoabb", DbType.String);
            param9.Value = value.Centrocostoabb;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@tipocentrocosto", DbType.String);
            param10.Value = value.Tipocentrocosto;
            collParams.Add(param10);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@centrocostoabb2", DbType.String);
            param12.Value = value.Centrocostoabb2;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@tipocentrocosto2", DbType.String);
            param13.Value = value.Tipocentrocosto2;
            collParams.Add(param13);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.DateTime);
            param15.Value = DateTime.Now;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param16.Value = value.UserIDIns;
            collParams.Add(param16);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.DateTime);
            param17.Value = DateTime.Now;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param18.Value = value.UserIDIns;
            collParams.Add(param18);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@naturaiva", DbType.String);
            param21.Value = value.Naturaiva;
            collParams.Add(param21);

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
        public ICron UltimoUidFattura()
        {
            ICron retVal = null;
            string sql = "SELECT TOP 1 Uid FROM EF_fatturexml ORDER BY idfattura DESC";
            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public List<ICron> SelectUsersDimissionariAttivi()
        {
            string datafineprev = DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
            //string datafineprev = "2021-06-01";

            List<ICron> retVal = new List<ICron>();
            string sql = "SELECT UserId, email, matricola FROM EF_users WHERE idstatususer = 0 AND datadimissioni <= @datafineprev "; // AND UserId='2BEFD1FB-3A8C-4025-AEC2-C1779E0510EF'

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@datafineprev", DbType.DateTime);
            param9.Value = datafineprev;
            collParams.Add(param9);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateEmail(ICron value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users SET [idstatususer] = 2, [email] = @email, [datausermod] = @datausermod, [UserIdMod] = @UserIdMod WHERE UserId = @UserId AND uidtenant = @Uidtenant ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = value.UserId;
            collParams.Add(param0);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param7.Value = value.UserIDIns;
            collParams.Add(param7);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@email", DbType.String);
            param17.Value = value.Email;
            collParams.Add(param17);

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
        public int UpdateUserNameMembership2(string NewUsername, string LoweredNewUsername, string OldUsername)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = "UPDATE aspnet_Membership SET Email = @NewUsername, LoweredEmail = @LoweredNewUsername WHERE Email=@OldUsername";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@NewUsername", DbType.String);
            param0.Value = NewUsername;
            collParams.Add(param0);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@LoweredNewUsername", DbType.String);
            param5.Value = LoweredNewUsername;
            collParams.Add(param5);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@OldUsername", DbType.String);
            param17.Value = OldUsername;
            collParams.Add(param17);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateUserNameMembership(string NewUsername, string LoweredNewUsername, string OldUsername)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = "UPDATE aspnet_Users SET UserName=@NewUsername,LoweredUserName=@LoweredNewUsername WHERE UserName=@OldUsername";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@NewUsername", DbType.String);
            param0.Value = NewUsername;
            collParams.Add(param0);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@LoweredNewUsername", DbType.String);
            param5.Value = LoweredNewUsername;
            collParams.Add(param5);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@OldUsername", DbType.String);
            param17.Value = OldUsername;
            collParams.Add(param17);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public ICron ExistAnagraficaEmail(string email)
        {
            ICron retVal = null;
            string sql = "SELECT UserId, gradecode, iduser FROM EF_users WHERE email = @email";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@email", DbType.String);
            param0.Value = email;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                    Gradecode = DataHelper.IfDBNull<string>(row["gradecode"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateAccountCount(ICron value)
        {
            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users SET [idgruppouser] = @idgruppouser,[idstatususer] = @idstatususer,[flgadmin] = @flgadmin,[flgdriver] = @flgdriver,[datausermod] = @datausermod,[UserIdMod] = @UserIdMod, " +
                         " [codsocieta] = @codsocieta,[cognome] = @cognome,[nome] = @nome,[matricola] = @matricola,[idnumber] = @idnumber,[idtipodriver] = @idtipodriver,[funzione] = @funzione, " +
                         " [maternita] = @maternita,[cellulare] = @cellulare,[email] = @email,[codicecdc] = @codicecdc,[descrizionecdc] = @descrizionecdc,[fasciacarpolicy] = @fasciacarpolicy, " +
                         " [codicesede] = @codicesede,[descrizionesede] = @descrizionesede,[luogonascita] = @luogonascita,[provincianascita] = @provincianascita,[codicefiscale] = @codicefiscale, " +
                         " [indirizzoresidenza] = @indirizzoresidenza,[localitaresidenza] = @localitaresidenza,[provinciaresidenza] = @provinciaresidenza,[capresidenza] = @capresidenza," +
                         " [nrpatente] = @nrpatente,[ufficioemittente] = @ufficioemittente,[matricolaapprovatore] = @matricolaapprovatore,[codicesocietaapprovatore] = @codicesocietaapprovatore, " +
                         " [codicesettore] = @codicesettore,[descrizionesettore] = @descrizionesettore,[descrizioneapprovatore] = @descrizioneapprovatore,[emailapprovatore] = @emailapprovatore, " +
                         " [gradecode] = @gradecode,[persontype] = @persontype,[indirizzosede] = @indirizzosede,[cittasede] = @cittasede,[provinciasede] = @provinciasede,[capsede] = @capsede, " +
                         " [codicedivisione] = @codicedivisione,[descrizionedivisione] = @descrizionedivisione,[fasciaimportazione] = @fasciaimportazione,[annotazioni] = @annotazioni, " +
                         " [codfornitore] = @codfornitore ";

            if (value.Dataassunzione > DateTime.MinValue)
            {
                sql += " ,[dataassunzione] = @dataassunzione ";
                IDbDataParameter param48 = _dataHelper.ProviderConn.CreateDataParameter("@dataassunzione", DbType.DateTime);
                param48.Value = value.Dataassunzione;
                collParams.Add(param48);
            }

            if (value.Datanascita > DateTime.MinValue)
            {
                sql += " ,[datanascita] = @datanascita ";
                IDbDataParameter param49 = _dataHelper.ProviderConn.CreateDataParameter("@datanascita", DbType.DateTime);
                param49.Value = value.Datanascita;
                collParams.Add(param49);
            }

            if (value.Dataemissione > DateTime.MinValue)
            {
                sql += " ,[dataemissione] = @dataemissione ";
                IDbDataParameter param50 = _dataHelper.ProviderConn.CreateDataParameter("@dataemissione", DbType.DateTime);
                param50.Value = value.Dataemissione;
                collParams.Add(param50);
            }

            if (value.Datascadenza > DateTime.MinValue)
            {
                sql += " ,[datascadenza] = @datascadenza ";
                IDbDataParameter param51 = _dataHelper.ProviderConn.CreateDataParameter("@datascadenza", DbType.DateTime);
                param51.Value = value.Datascadenza;
                collParams.Add(param51);
            }

            if (value.Datainiziovalidita > DateTime.MinValue)
            {
                sql += " ,[datainiziovalidita] = @datainiziovalidita ";
                IDbDataParameter param52 = _dataHelper.ProviderConn.CreateDataParameter("@datainiziovalidita", DbType.DateTime);
                param52.Value = value.Datainiziovalidita;
                collParams.Add(param52);
            }

            if (value.Dataprevistadimissione > DateTime.MinValue)
            {
                sql += " ,[dataprevistadimissione] = @dataprevistadimissione ";
                IDbDataParameter param53 = _dataHelper.ProviderConn.CreateDataParameter("@dataprevistadimissione", DbType.DateTime);
                param53.Value = value.Dataprevistadimissione;
                collParams.Add(param53);
            }

            if (value.Datadimissioni > DateTime.MinValue)
            {
                sql += " ,[datadimissioni] = @datadimissioni ";
                IDbDataParameter param54 = _dataHelper.ProviderConn.CreateDataParameter("@datadimissioni", DbType.DateTime);
                param54.Value = value.Datadimissioni;
                collParams.Add(param54);
            }

            sql += " WHERE UserId = @UserId AND uidtenant = @Uidtenant SELECT @@ROWCOUNT as totRowCorrect ";


            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = value.UserId;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idgruppouser", DbType.Int32);
            param1.Value = value.Idgruppouser;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@idstatususer", DbType.Int32);
            param2.Value = value.Idstatususer;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@flgadmin", DbType.Int32);
            param3.Value = value.Flgadmin;
            collParams.Add(param3);

            IDbDataParameter param56 = _dataHelper.ProviderConn.CreateDataParameter("@flgdriver", DbType.Int32);
            param56.Value = value.Flgdriver;
            collParams.Add(param56);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param7.Value = value.UserIDIns;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param8.Value = value.Codsocieta;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@cognome", DbType.String);
            param9.Value = value.Cognome;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@nome", DbType.String);
            param10.Value = value.Nome;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@matricola", DbType.String);
            param11.Value = value.Matricola;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@idnumber", DbType.String);
            param12.Value = value.Idnumber;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@idtipodriver", DbType.Int32);
            param13.Value = value.Idtipodriver;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@funzione", DbType.String);
            param14.Value = value.Funzione;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@maternita", DbType.String);
            param15.Value = value.Maternita;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@cellulare", DbType.String);
            param16.Value = value.Cellulare;
            collParams.Add(param16);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@email", DbType.String);
            param17.Value = value.Email;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@codicecdc", DbType.String);
            param18.Value = value.Codicecdc;
            collParams.Add(param18);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@descrizionecdc", DbType.String);
            param19.Value = value.Descrizionecdc;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@fasciacarpolicy", DbType.String);
            param20.Value = value.Fasciacarpolicy;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@codicesede", DbType.String);
            param21.Value = value.Codicesede;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@descrizionesede", DbType.String);
            param22.Value = value.Descrizionesede;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@luogonascita", DbType.String);
            param23.Value = value.Luogonascita;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@provincianascita", DbType.String);
            param24.Value = value.Provincianascita;
            collParams.Add(param24);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@codicefiscale", DbType.String);
            param25.Value = value.Codicefiscale;
            collParams.Add(param25);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@indirizzoresidenza", DbType.String);
            param26.Value = value.Indirizzoresidenza;
            collParams.Add(param26);

            IDbDataParameter param27 = _dataHelper.ProviderConn.CreateDataParameter("@localitaresidenza", DbType.String);
            param27.Value = value.Localitaresidenza;
            collParams.Add(param27);

            IDbDataParameter param28 = _dataHelper.ProviderConn.CreateDataParameter("@provinciaresidenza", DbType.String);
            param28.Value = value.Provinciaresidenza;
            collParams.Add(param28);

            IDbDataParameter param29 = _dataHelper.ProviderConn.CreateDataParameter("@capresidenza", DbType.String);
            param29.Value = value.Capresidenza;
            collParams.Add(param29);

            IDbDataParameter param30 = _dataHelper.ProviderConn.CreateDataParameter("@nrpatente", DbType.String);
            param30.Value = value.Nrpatente;
            collParams.Add(param30);

            IDbDataParameter param31 = _dataHelper.ProviderConn.CreateDataParameter("@ufficioemittente", DbType.String);
            param31.Value = value.Ufficioemittente;
            collParams.Add(param31);

            IDbDataParameter param32 = _dataHelper.ProviderConn.CreateDataParameter("@matricolaapprovatore", DbType.String);
            param32.Value = value.Matricolaapprovatore;
            collParams.Add(param32);

            IDbDataParameter param33 = _dataHelper.ProviderConn.CreateDataParameter("@codicesocietaapprovatore", DbType.String);
            param33.Value = value.Codicesocietaapprovatore;
            collParams.Add(param33);

            IDbDataParameter param34 = _dataHelper.ProviderConn.CreateDataParameter("@codicesettore", DbType.String);
            param34.Value = value.Codicesettore;
            collParams.Add(param34);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@descrizionesettore", DbType.String);
            param35.Value = value.Descrizionesettore;
            collParams.Add(param35);

            IDbDataParameter param36 = _dataHelper.ProviderConn.CreateDataParameter("@descrizioneapprovatore", DbType.String);
            param36.Value = value.Descrizioneapprovatore;
            collParams.Add(param36);

            IDbDataParameter param37 = _dataHelper.ProviderConn.CreateDataParameter("@emailapprovatore", DbType.String);
            param37.Value = value.Emailapprovatore;
            collParams.Add(param37);

            IDbDataParameter param38 = _dataHelper.ProviderConn.CreateDataParameter("@gradecode", DbType.String);
            param38.Value = value.Gradecode;
            collParams.Add(param38);

            IDbDataParameter param39 = _dataHelper.ProviderConn.CreateDataParameter("@persontype", DbType.String);
            param39.Value = value.Persontype;
            collParams.Add(param39);

            IDbDataParameter param40 = _dataHelper.ProviderConn.CreateDataParameter("@indirizzosede", DbType.String);
            param40.Value = value.Indirizzosede;
            collParams.Add(param40);

            IDbDataParameter param41 = _dataHelper.ProviderConn.CreateDataParameter("@cittasede", DbType.String);
            param41.Value = value.Cittasede;
            collParams.Add(param41);

            IDbDataParameter param42 = _dataHelper.ProviderConn.CreateDataParameter("@provinciasede", DbType.String);
            param42.Value = value.Provinciasede;
            collParams.Add(param42);

            IDbDataParameter param43 = _dataHelper.ProviderConn.CreateDataParameter("@capsede", DbType.String);
            param43.Value = value.Capsede;
            collParams.Add(param43);

            IDbDataParameter param44 = _dataHelper.ProviderConn.CreateDataParameter("@codicedivisione", DbType.String);
            param44.Value = value.Codicedivisione;
            collParams.Add(param44);

            IDbDataParameter param45 = _dataHelper.ProviderConn.CreateDataParameter("@descrizionedivisione", DbType.String);
            param45.Value = value.Descrizionedivisione;
            collParams.Add(param45);

            IDbDataParameter param46 = _dataHelper.ProviderConn.CreateDataParameter("@fasciaimportazione", DbType.String);
            param46.Value = value.Fasciaimportazione;
            collParams.Add(param46);

            IDbDataParameter param47 = _dataHelper.ProviderConn.CreateDataParameter("@annotazioni", DbType.String);
            param47.Value = value.Annotazioni;
            collParams.Add(param47);

            IDbDataParameter param55 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param55.Value = value.Codfornitore;
            collParams.Add(param55);

            IDbDataParameter param72 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param72.Value = value.Uidtenant;
            collParams.Add(param72);

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }
        public int InsertAccount(ICron value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Dataassunzione > DateTime.MinValue)
            {
                IDbDataParameter param48 = _dataHelper.ProviderConn.CreateDataParameter("@dataassunzione", DbType.DateTime);
                param48.Value = value.Dataassunzione;
                collParams.Add(param48);

                sqlfield += " ,[dataassunzione] ";
                sqlvalue += " ,@dataassunzione ";
            }

            if (value.Datanascita > DateTime.MinValue)
            {
                IDbDataParameter param49 = _dataHelper.ProviderConn.CreateDataParameter("@datanascita", DbType.DateTime);
                param49.Value = value.Datanascita;
                collParams.Add(param49);

                sqlfield += " ,[datanascita] ";
                sqlvalue += " ,@datanascita ";
            }

            if (value.Dataemissione > DateTime.MinValue)
            {
                IDbDataParameter param50 = _dataHelper.ProviderConn.CreateDataParameter("@dataemissione", DbType.DateTime);
                param50.Value = value.Dataemissione;
                collParams.Add(param50);

                sqlfield += " ,[dataemissione] ";
                sqlvalue += " ,@dataemissione ";
            }

            if (value.Datascadenza > DateTime.MinValue)
            {
                IDbDataParameter param51 = _dataHelper.ProviderConn.CreateDataParameter("@datascadenza", DbType.DateTime);
                param51.Value = value.Datascadenza;
                collParams.Add(param51);

                sqlfield += " ,[datascadenza] ";
                sqlvalue += " ,@datascadenza ";
            }

            if (value.Datainiziovalidita > DateTime.MinValue)
            {
                IDbDataParameter param52 = _dataHelper.ProviderConn.CreateDataParameter("@datainiziovalidita", DbType.DateTime);
                param52.Value = value.Datainiziovalidita;
                collParams.Add(param52);

                sqlfield += " ,[datainiziovalidita] ";
                sqlvalue += " ,@datainiziovalidita ";
            }

            if (value.Dataprevistadimissione > DateTime.MinValue)
            {
                IDbDataParameter param53 = _dataHelper.ProviderConn.CreateDataParameter("@dataprevistadimissione", DbType.DateTime);
                param53.Value = value.Dataprevistadimissione;
                collParams.Add(param53);

                sqlfield += " ,[dataprevistadimissione] ";
                sqlvalue += " ,@dataprevistadimissione ";
            }

            if (value.Datadimissioni > DateTime.MinValue)
            {
                IDbDataParameter param54 = _dataHelper.ProviderConn.CreateDataParameter("@datadimissioni", DbType.DateTime);
                param54.Value = value.Datadimissioni;
                collParams.Add(param54);

                sqlfield += " ,[datadimissioni] ";
                sqlvalue += " ,@datadimissioni ";
            }

            string sql = "INSERT INTO EF_users ([UserId],[idgruppouser],[idstatususer],[flgadmin],[flgdriver],[datauserins],[datausermod],[UserIDIns],[UserIdMod],[codsocieta],[cognome],[nome], " +
                         " [matricola],[idnumber],[idtipodriver],[funzione],[maternita],[cellulare],[email],[codicecdc],[descrizionecdc],[fasciacarpolicy],[codicesede],[descrizionesede], " +
                         " [luogonascita],[provincianascita],[codicefiscale],[indirizzoresidenza],[localitaresidenza],[provinciaresidenza],[capresidenza],[nrpatente],[ufficioemittente], " +
                         " [matricolaapprovatore],[codicesocietaapprovatore],[codicesettore],[descrizionesettore],[descrizioneapprovatore],[emailapprovatore],[gradecode],[persontype], " +
                         " [indirizzosede],[cittasede],[provinciasede],[capsede],[codicedivisione],[descrizionedivisione],[fasciaimportazione],[annotazioni],[codfornitore],[uidtenant] " + sqlfield + " ) " +
                         " VALUES (@UserId,@idgruppouser,@idstatususer,@flgadmin,@flgdriver,@datauserins,@datausermod,@UserIDIns,@UserIdMod,@codsocieta,@cognome,@nome, " +
                         " @matricola,@idnumber,@idtipodriver,@funzione,@maternita,@cellulare,@email,@codicecdc,@descrizionecdc,@fasciacarpolicy,@codicesede,@descrizionesede, " +
                         " @luogonascita,@provincianascita,@codicefiscale,@indirizzoresidenza,@localitaresidenza,@provinciaresidenza,@capresidenza,@nrpatente,@ufficioemittente, " +
                         " @matricolaapprovatore,@codicesocietaapprovatore,@codicesettore,@descrizionesettore,@descrizioneapprovatore,@emailapprovatore,@gradecode,@persontype, " +
                         " @indirizzosede,@cittasede,@provinciasede,@capsede,@codicedivisione,@descrizionedivisione,@fasciaimportazione,@annotazioni,@codfornitore,@uidtenant " + sqlvalue + " ) ";


            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = value.UserId;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idgruppouser", DbType.Int32);
            param1.Value = value.Idgruppouser;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@idstatususer", DbType.Int32);
            param2.Value = value.Idstatususer;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@flgadmin", DbType.Int32);
            param3.Value = value.Flgadmin;
            collParams.Add(param3);

            IDbDataParameter param56 = _dataHelper.ProviderConn.CreateDataParameter("@flgdriver", DbType.Int32);
            param56.Value = value.Flgdriver;
            collParams.Add(param56);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param4.Value = DateTime.Now;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param6.Value = value.UserIDIns;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param7.Value = value.UserIDIns;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param8.Value = value.Codsocieta;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@cognome", DbType.String);
            param9.Value = value.Cognome;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@nome", DbType.String);
            param10.Value = value.Nome;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@matricola", DbType.String);
            param11.Value = value.Matricola;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@idnumber", DbType.String);
            param12.Value = value.Idnumber;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@idtipodriver", DbType.Int32);
            param13.Value = value.Idtipodriver;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@funzione", DbType.String);
            param14.Value = value.Funzione;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@maternita", DbType.String);
            param15.Value = value.Maternita;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@cellulare", DbType.String);
            param16.Value = value.Cellulare;
            collParams.Add(param16);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@email", DbType.String);
            param17.Value = value.Email;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@codicecdc", DbType.String);
            param18.Value = value.Codicecdc;
            collParams.Add(param18);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@descrizionecdc", DbType.String);
            param19.Value = value.Descrizionecdc;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@fasciacarpolicy", DbType.String);
            param20.Value = value.Fasciacarpolicy;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@codicesede", DbType.String);
            param21.Value = value.Codicesede;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@descrizionesede", DbType.String);
            param22.Value = value.Descrizionesede;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@luogonascita", DbType.String);
            param23.Value = value.Luogonascita;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@provincianascita", DbType.String);
            param24.Value = value.Provincianascita;
            collParams.Add(param24);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@codicefiscale", DbType.String);
            param25.Value = value.Codicefiscale;
            collParams.Add(param25);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@indirizzoresidenza", DbType.String);
            param26.Value = value.Indirizzoresidenza;
            collParams.Add(param26);

            IDbDataParameter param27 = _dataHelper.ProviderConn.CreateDataParameter("@localitaresidenza", DbType.String);
            param27.Value = value.Localitaresidenza;
            collParams.Add(param27);

            IDbDataParameter param28 = _dataHelper.ProviderConn.CreateDataParameter("@provinciaresidenza", DbType.String);
            param28.Value = value.Provinciaresidenza;
            collParams.Add(param28);

            IDbDataParameter param29 = _dataHelper.ProviderConn.CreateDataParameter("@capresidenza", DbType.String);
            param29.Value = value.Capresidenza;
            collParams.Add(param29);

            IDbDataParameter param30 = _dataHelper.ProviderConn.CreateDataParameter("@nrpatente", DbType.String);
            param30.Value = value.Nrpatente;
            collParams.Add(param30);

            IDbDataParameter param31 = _dataHelper.ProviderConn.CreateDataParameter("@ufficioemittente", DbType.String);
            param31.Value = value.Ufficioemittente;
            collParams.Add(param31);

            IDbDataParameter param32 = _dataHelper.ProviderConn.CreateDataParameter("@matricolaapprovatore", DbType.String);
            param32.Value = value.Matricolaapprovatore;
            collParams.Add(param32);

            IDbDataParameter param33 = _dataHelper.ProviderConn.CreateDataParameter("@codicesocietaapprovatore", DbType.String);
            param33.Value = value.Codicesocietaapprovatore;
            collParams.Add(param33);

            IDbDataParameter param34 = _dataHelper.ProviderConn.CreateDataParameter("@codicesettore", DbType.String);
            param34.Value = value.Codicesettore;
            collParams.Add(param34);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@descrizionesettore", DbType.String);
            param35.Value = value.Descrizionesettore;
            collParams.Add(param35);

            IDbDataParameter param36 = _dataHelper.ProviderConn.CreateDataParameter("@descrizioneapprovatore", DbType.String);
            param36.Value = value.Descrizioneapprovatore;
            collParams.Add(param36);

            IDbDataParameter param37 = _dataHelper.ProviderConn.CreateDataParameter("@emailapprovatore", DbType.String);
            param37.Value = value.Emailapprovatore;
            collParams.Add(param37);

            IDbDataParameter param38 = _dataHelper.ProviderConn.CreateDataParameter("@gradecode", DbType.String);
            param38.Value = value.Gradecode;
            collParams.Add(param38);

            IDbDataParameter param39 = _dataHelper.ProviderConn.CreateDataParameter("@persontype", DbType.String);
            param39.Value = value.Persontype;
            collParams.Add(param39);

            IDbDataParameter param40 = _dataHelper.ProviderConn.CreateDataParameter("@indirizzosede", DbType.String);
            param40.Value = value.Indirizzosede;
            collParams.Add(param40);

            IDbDataParameter param41 = _dataHelper.ProviderConn.CreateDataParameter("@cittasede", DbType.String);
            param41.Value = value.Cittasede;
            collParams.Add(param41);

            IDbDataParameter param42 = _dataHelper.ProviderConn.CreateDataParameter("@provinciasede", DbType.String);
            param42.Value = value.Provinciasede;
            collParams.Add(param42);

            IDbDataParameter param43 = _dataHelper.ProviderConn.CreateDataParameter("@capsede", DbType.String);
            param43.Value = value.Capsede;
            collParams.Add(param43);

            IDbDataParameter param44 = _dataHelper.ProviderConn.CreateDataParameter("@codicedivisione", DbType.String);
            param44.Value = value.Codicedivisione;
            collParams.Add(param44);

            IDbDataParameter param45 = _dataHelper.ProviderConn.CreateDataParameter("@descrizionedivisione", DbType.String);
            param45.Value = value.Descrizionedivisione;
            collParams.Add(param45);

            IDbDataParameter param46 = _dataHelper.ProviderConn.CreateDataParameter("@fasciaimportazione", DbType.String);
            param46.Value = value.Fasciaimportazione;
            collParams.Add(param46);

            IDbDataParameter param47 = _dataHelper.ProviderConn.CreateDataParameter("@annotazioni", DbType.String);
            param47.Value = value.Annotazioni;
            collParams.Add(param47);

            IDbDataParameter param55 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param55.Value = value.Codfornitore;
            collParams.Add(param55);

            IDbDataParameter param57 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param57.Value = value.Uidtenant;
            collParams.Add(param57);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public ICron ExistAnagraficaMatricola(string matricola)
        {
            ICron retVal = null;
            string sql = "SELECT UserId, gradecode, iduser, idgruppouser, flgdriver FROM EF_users WHERE matricola = @matricola";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@matricola", DbType.String);
            param0.Value = matricola;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                    Idgruppouser = DataHelper.IfDBNull<int>(row["idgruppouser"], 0),
                    Flgdriver = DataHelper.IfDBNull<int>(row["flgdriver"], 0),
                    Gradecode = DataHelper.IfDBNull<string>(row["gradecode"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int InsertConcur(ICron value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Dataspesa > DateTime.MinValue)
            {
                IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@dataspesa", DbType.DateTime);
                param19.Value = value.Dataspesa;
                collParams.Add(param19);

                sqlfield += " ,[dataspesa] ";
                sqlvalue += " ,@dataspesa ";
            }

            string sql = " INSERT INTO EF_concur ([UserId],[codcompany],[codservice],[tipologiaspesa],[distanza],[rimborso],[importospesa],[targa],[importodeducibile], " +
                         " [datauserins],[datausermod],[UserIDIns],[UserIdMod],[chiave],[tracciato],[uidtenant] " + sqlfield + ") " +
                         " VALUES (@UserId,@codcompany,@codservice,@tipologiaspesa,@distanza,@rimborso,@importospesa,@targa,@importodeducibile, " +
                         " @datauserins,@datausermod,@UserIDIns,@UserIdMod,@chiave,@tracciato,@uidtenant " + sqlvalue + ") ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = value.UserId;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codcompany", DbType.String);
            param1.Value = value.Codcompany;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codservice", DbType.String);
            param2.Value = value.Codservice;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@tipologiaspesa", DbType.String);
            param3.Value = value.Tipologiaspesa;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@distanza", DbType.Decimal);
            param4.Value = value.Distanza;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@rimborso", DbType.Decimal);
            param5.Value = value.Rimborso;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@importospesa", DbType.Decimal);
            param6.Value = value.Importospesa;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param7.Value = value.Targa;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@importodeducibile", DbType.Decimal);
            param8.Value = value.Importodeducibile;
            collParams.Add(param8);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.DateTime);
            param15.Value = DateTime.Now;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param16.Value = value.UserIDIns;
            collParams.Add(param16);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.DateTime);
            param17.Value = DateTime.Now;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param18.Value = value.UserIDIns;
            collParams.Add(param18);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@chiave", DbType.String);
            param20.Value = value.Chiave;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@tracciato", DbType.String);
            param21.Value = value.Tracciato;
            collParams.Add(param21);

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
        public int InsertTelePassConsumo(ICron value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_users_telepass_consumo ([dispositivo],[numerodispositivo],[dataora],[descrizione],[classe],[importo],[datauserins],[UserIDIns],[uidtenant] ) " +
                         " VALUES (@dispositivo,@numerodispositivo,@dataora,@descrizione,@classe,@importo,@datauserins,@UserIDIns,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@dispositivo", DbType.String);
            param7.Value = value.Dispositivo;
            collParams.Add(param7);

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@numerodispositivo", DbType.String);
            param0.Value = value.Numerodispositivo;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@descrizione", DbType.String);
            param1.Value = value.Descrizione;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@dataora", DbType.DateTime);
            param2.Value = value.Dataora;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@classe", DbType.String);
            param3.Value = value.Classe;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@importo", DbType.Decimal);
            param4.Value = value.Importo;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.DateTime);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param6.Value = value.UserIDIns;
            collParams.Add(param6);

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
        public bool ExistTelepassConsumo(string numerodispositivo, DateTime dataora)
        {
            bool retVal = false;
            string sql = " SELECT idtelep FROM EF_users_telepass_consumo WHERE numerodispositivo = @numerodispositivo and dataora = @dataora ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@numerodispositivo", DbType.String);
            param0.Value = numerodispositivo;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@dataora", DbType.DateTime);
            param1.Value = dataora;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public ICron ReturnTargaAssegnazioneXConcur(Guid UserId, DateTime dataspesa)
        {
            ICron retVal = null;
            string sql = " SELECT targa FROM EF_contratti_assegnazioni WHERE UserId = @UserId and assegnatodal <= @dataspesa AND assegnatoal >= @dataspesa ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = UserId;
            collParams.Add(param1);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@dataspesa", DbType.DateTime);
            param6.Value = dataspesa;
            collParams.Add(param6);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public ICron UltimoIDProg()
        {
            ICron retVal = null;
            string sql = "SELECT TOP 1 idprog FROM EF_filecaricati ORDER BY idprog DESC";
            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Idprog = DataHelper.IfDBNull<int>(row["idprog"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public ICron UltimoIDProgImp()
        {
            ICron retVal = null;
            string sql = "SELECT TOP 1 idprog, nomefile FROM EF_importazioni_storico ORDER BY idprog DESC";
            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Idprog = DataHelper.IfDBNull<int>(row["idprog"], 0),
                    Nomefile = DataHelper.IfDBNull<string>(row["nomefile"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public ICron DetailSocieta(string codcompany)
        {
            ICron retVal = null;
            string sql = "SELECT codsocieta FROM EF_societa WHERE codcompany = @codcompany";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcompany", DbType.String);
            param0.Value = codcompany;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public ICron ReturnCodCarPolicy(string codsocieta, string gradecode)
        {
            ICron retVal = null;
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");
            string sql = " SELECT codcarpolicy, Uid FROM EF_carpolicy_assegna_societa WHERE codsocieta = @codsocieta AND codgrade = @gradecode and validodal <= @dataoggi and validoal >= @dataoggi ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = codsocieta;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@gradecode", DbType.String);
            param1.Value = gradecode;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.Date);
            param2.Value = dataoggi;
            collParams.Add(param2);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public ICron DetailIdUser(Guid UserId)
        {
            ICron retVal = null;
            string sql = "SELECT * FROM EF_users WHERE UserId = @UserId";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                };

                data.Dispose();
            }
            return retVal;
        }
        public List<ICron> SelectAutoImmatricolazione()
        {
            int mesecorrente = DateTime.Now.Month;
            int anni4 = DateTime.Now.AddYears(-4).Year;
            int anni6 = DateTime.Now.AddYears(-6).Year;
            int anni8 = DateTime.Now.AddYears(-8).Year;
            int anni10 = DateTime.Now.AddYears(-10).Year;

            List<ICron> retVal = new List<ICron>();
            string sql = " SELECT targa, UserId FROM EF_contratti WHERE DATEPART(month,dataimmatricolazione) = @mesecorrente " +
                         " AND(DATEPART(year, dataimmatricolazione) = @anni4 OR DATEPART(year, dataimmatricolazione) = @anni6 OR DATEPART(year, dataimmatricolazione) = @anni8 " +
                         " OR DATEPART(year, dataimmatricolazione) = @anni10) and idstatuscontratto = 0 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@mesecorrente", DbType.Int32);
            param0.Value = mesecorrente;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@anni4", DbType.Int32);
            param1.Value = anni4;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@anni6", DbType.Int32);
            param2.Value = anni6;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@anni8", DbType.Int32);
            param3.Value = anni8;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@anni10", DbType.Int32);
            param4.Value = anni10;
            collParams.Add(param4);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int InsertRevisione(ICron value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_contratti_revisioni ([targa],[UserId],[mese],[anno],[uidtenant]) " +
                         " VALUES (@targa,@UserId,@mese,@anno,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param7.Value = value.Targa;
            collParams.Add(param7);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param6.Value = value.UserId;
            collParams.Add(param6);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@mese", DbType.Int32);
            param8.Value = value.Mese;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@anno", DbType.Int32);
            param9.Value = value.Anno;
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
        public List<ICron> SelectRevisioniDaEffettuare()
        {
            List<ICron> retVal = new List<ICron>();

            string sql = " SELECT EF_users.email FROM EF_contratti_revisioni LEFT JOIN EF_users ON EF_contratti_revisioni.UserId = EF_users.UserId WHERE statuscheck = 0 ";

            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public bool ExistRevisione(string targa, int mese, int anno)
        {
            bool retVal = false;
            string sql = " SELECT idrevisione FROM EF_contratti_revisioni WHERE targa = @targa and mese = @mese and anno = @anno ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param0.Value = targa;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@mese", DbType.Int32);
            param1.Value = mese;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@anno", DbType.Int32);
            param2.Value = anno;
            collParams.Add(param2);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public List<ICron> SelectAllUserEmail()
        {
            List<ICron> retVal = new List<ICron>();

            string sql = "SELECT * FROM EF_email_invio WHERE flginviato = '' or flginviato is null  ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
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
        public int UpdateInvioMail(int idinvio, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = " UPDATE EF_email_invio SET [flginviato] = 1, [datainvio] = @datainvio WHERE idinvio = @idinvio AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datainvio", DbType.Date);
            param7.Value = DateTime.Now;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idinvio", DbType.Int32);
            param8.Value = idinvio;
            collParams.Add(param8);

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
        public int InsertInvioMail(ICron value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_email_invio ([nome],[cognome],[matricola],[codsocieta],[codgrade],[email],[param1],[param2],[param3],[param4],[param5], " +
                         " [param6],[param7],[param8],[param9],[param10],[uidtenant]) " +
                         " VALUES (@nome,@cognome,@matricola,@codsocieta,@codgrade,@email,@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9,@param10,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@nome", DbType.String);
            param11.Value = value.Nome;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@cognome", DbType.String);
            param12.Value = value.Cognome;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@matricola", DbType.String);
            param13.Value = value.Matricola;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param14.Value = value.Codsocieta;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
            param15.Value = value.Codgrade;
            collParams.Add(param15);

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@email", DbType.String);
            param0.Value = value.Email;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@param1", DbType.String);
            param1.Value = value.Param1;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@param2", DbType.String);
            param2.Value = value.Param2;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@param3", DbType.String);
            param3.Value = value.Param3;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@param4", DbType.String);
            param4.Value = value.Param4;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@param5", DbType.String);
            param5.Value = value.Param5;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@param6", DbType.String);
            param6.Value = value.Param6;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@param7", DbType.String);
            param7.Value = value.Param7;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@param8", DbType.String);
            param8.Value = value.Param8;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@param9", DbType.String);
            param9.Value = value.Param9;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@param10", DbType.String);
            param10.Value = value.Param10;
            collParams.Add(param10);

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

        public ICron DetailNumeroFuelCardEnelX(string targa)
        {
            string dataoggi = DateTime.Now.ToString("yyyy-MM-dd");
            ICron retVal = null;

            string sql = "SELECT numero FROM EF_users_fuelcard WHERE targa=@targa and idcompagnia=3 and dataattivazione<=@dataoggi and statuscard='ATTIVA' and scadenza>=@dataoggi ";
            
            List<IDataParameter> collParams = new List<IDataParameter>();
            
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param0.Value = targa;
            collParams.Add(param0);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.String);
            param2.Value = dataoggi;
            collParams.Add(param2);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Numerofuelcard = DataHelper.IfDBNull<string>(row["numero"], _stringEmpty),
                };

                data.Dispose();
            }
            return retVal;
        }

        public int InsertFuelCard(ICron value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Scadenza > DateTime.MinValue)
            {
                IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@scadenza", DbType.DateTime);
                param16.Value = value.Scadenza;
                collParams.Add(param16);

                sqlfield += " ,[scadenza] ";
                sqlvalue += " ,@scadenza ";
            }
            if (value.Dataattivazione > DateTime.MinValue)
            {
                IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@dataattivazione", DbType.DateTime);
                param17.Value = value.Dataattivazione;
                collParams.Add(param17);

                sqlfield += " ,[dataattivazione] ";
                sqlvalue += " ,@dataattivazione ";
            }

            string sql = " INSERT INTO EF_users_fuelcard ([idcompagnia],[codsocieta],[targa],[numero],[pin],[statuscard],[uidtenant] " + sqlfield + " ) " +
                         " VALUES (@idcompagnia,@codsocieta,@targa,@numero,@pin,@statuscard,@uidtenant " + sqlvalue + " ) ";

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
            param21.Value = value.Idcompagnia;
            collParams.Add(param21);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param3.Value = value.Codsocieta;
            collParams.Add(param3);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param10.Value = value.Targa;
            collParams.Add(param10);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@numero", DbType.String);
            param4.Value = value.Numerofuelcard;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@pin", DbType.String);
            param5.Value = value.Pin;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@statuscard", DbType.String);
            param6.Value = value.Statuscard;
            collParams.Add(param6);

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
        public bool ExistFuelCard(int idcompagnia, string numerofuelcard)
        {
            bool retVal = false;
            string sql = " SELECT iduserfuel FROM EF_users_fuelcard WHERE idcompagnia = @idcompagnia and numero = @numerofuelcard ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
            param0.Value = idcompagnia;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@numerofuelcard", DbType.String);
            param1.Value = numerofuelcard;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public int UpdateFuelCardCount(ICron value)
        {
            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users_fuelcard SET [codsocieta] = @codsocieta, [targa] = @targa, [pin] = @pin, [statuscard] = @statuscard ";

            if (value.Scadenza > DateTime.MinValue)
            {
                sql += " ,[scadenza] = @scadenza ";
                IDbDataParameter param48 = _dataHelper.ProviderConn.CreateDataParameter("@scadenza", DbType.DateTime);
                param48.Value = value.Scadenza;
                collParams.Add(param48);
            }
            if (value.Scadenza > DateTime.MinValue)
            {
                sql += " ,[dataattivazione] = @dataattivazione ";
                IDbDataParameter param47 = _dataHelper.ProviderConn.CreateDataParameter("@dataattivazione", DbType.DateTime);
                param47.Value = value.Dataattivazione;
                collParams.Add(param47);
            }

            sql += " WHERE idcompagnia = @idcompagnia and numero = @numerofuelcard AND uidtenant = @Uidtenant SELECT @@ROWCOUNT as totRowCorrect ";

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param3.Value = value.Codsocieta;
            collParams.Add(param3);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param10.Value = value.Targa;
            collParams.Add(param10);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@pin", DbType.String);
            param5.Value = value.Pin;
            collParams.Add(param5);

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
            param0.Value = value.Idcompagnia;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@numerofuelcard", DbType.String);
            param1.Value = value.Numerofuelcard;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@statuscard", DbType.String);
            param2.Value = value.Statuscard;
            collParams.Add(param2);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }
        public ICron ReturnSocietaXSigla(string siglasocieta)
        {
            ICron retVal = null;
            string sql = " SELECT codsocieta FROM EF_societa WHERE siglasocieta = @siglasocieta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@siglasocieta", DbType.String);
            param1.Value = siglasocieta;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }

        public List<ICron> SelectViewConcurTxt()
        {
            List<ICron> retVal = new List<ICron>();
            string sql = " SELECT * FROM view_concur_900 ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Campo1 = DataHelper.IfDBNull<string>(row["Trx Type"], _stringEmpty),
                        Campo2 = DataHelper.IfDBNull<string>(row["Employee ID"], _stringEmpty),
                        Campo3 = DataHelper.IfDBNull<string>(row["Car Type"], _stringEmpty),
                        Campo4 = DataHelper.IfDBNull<string>(row["Vehicle ID"], _stringEmpty),
                        Campo5 = DataHelper.IfDBNull<string>(row["Car Criteria Name"], _stringEmpty),
                        Campo6 = DataHelper.IfDBNull<string>(row["Initial Distance"], _stringEmpty),
                        Campo7 = DataHelper.IfDBNull<string>(row["Inactive"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //esistenza data concur
        public bool ExistDataConcur()
        {
            bool retVal = false;
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");
            string sql = " SELECT idriga FROM EF_concur_900 WHERE data = @dataoggi ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.DateTime);
            param2.Value = dataoggi;
            collParams.Add(param2);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public ICron DetailConcur900(string matricola)
        {
            ICron retVal = null;
            string sql = "SELECT TOP 1 * FROM EF_concur_900 WHERE matricola = @matricola and modifica<>'Y' ORDER BY data DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@matricola", DbType.String);
            param0.Value = matricola;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Descrizione = DataHelper.IfDBNull<string>(row["descrizione"], _stringEmpty),
                    Campo1 = DataHelper.IfDBNull<string>(row["codice"], _stringEmpty),
                    Campo2 = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                    Campo3 = DataHelper.IfDBNull<string>(row["tipo"], _stringEmpty),
                    Campo4 = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    Campo5 = DataHelper.IfDBNull<string>(row["descrizione"], _stringEmpty),
                    Benefit = DataHelper.IfDBNull<int>(row["benefit"], 0),
                };
                data.Dispose();
            }
            return retVal;
        }
        public int InsertConcur900(ICron value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_concur_900 ([data],[codice],[matricola],[tipo],[targa],[descrizione],[benefit],[benefitalt],[modifica],[uidtenant]) " +
                            " VALUES (@data, @codice, @matricola, @tipo, @targa, @descrizione, @benefit, @benefitalt, @modifica, @uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@data", DbType.DateTime);
            param1.Value = DateTime.Now;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codice", DbType.String);
            param2.Value = value.Campo1;
            collParams.Add(param2);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@matricola", DbType.String);
            param5.Value = value.Campo2;
            collParams.Add(param5);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@tipo", DbType.String);
            param3.Value = value.Campo3;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param4.Value = value.Campo4;
            collParams.Add(param4);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@descrizione", DbType.String);
            param6.Value = value.Campo5;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@benefit", DbType.Int32);
            param7.Value = value.Benefit;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@benefitalt", DbType.Int32);
            param8.Value = value.Benefitalt;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@modifica", DbType.String);
            param9.Value = value.Modifica;
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
        public List<ICron> SelectViewConcur900Txt()
        {
            string dataoggi = DateTime.Now.ToString("yyyy-MM-dd");

            List<ICron> retVal = new List<ICron>();
            string sql = " SELECT * FROM EF_concur_900 WHERE data = @dataoggi ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.String);
            param0.Value = dataoggi;
            collParams.Add(param0);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Campo1 = DataHelper.IfDBNull<string>(row["codice"], _stringEmpty),
                        Campo2 = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Campo3 = DataHelper.IfDBNull<string>(row["tipo"], _stringEmpty),
                        Campo4 = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Campo5 = DataHelper.IfDBNull<string>(row["descrizione"], _stringEmpty),
                        Benefit = DataHelper.IfDBNull<int>(row["benefit"], 0),
                        Benefitalt = DataHelper.IfDBNull<int>(row["benefitalt"], 0),
                        Modifica = DataHelper.IfDBNull<string>(row["modifica"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<ICron> SelectViewMovisionAnagrafiche()
        {
            List<ICron> retVal = new List<ICron>();
            string sql = " SELECT * FROM view_movesion_anagrafiche ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Matricola = DataHelper.IfDBNull<string>(row["Matricola"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["Codice Azienda"], _stringEmpty),
                        Idzucchetti = DataHelper.IfDBNull<string>(row["IdZucchetti"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["Cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["Nome"], _stringEmpty),
                        Email = DataHelper.IfDBNull<string>(row["Email"], _stringEmpty),
                        Username = DataHelper.IfDBNull<string>(row["Username"], _stringEmpty),
                        Codicefiscale = DataHelper.IfDBNull<string>(row["CodiceFiscale"], _stringEmpty),
                        Stato = DataHelper.IfDBNull<string>(row["Stato"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<ICron> SelectViewMovisionBenefit()
        {
            List<ICron> retVal = new List<ICron>();
            string sql = " SELECT * FROM view_movision_benefit ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICron item = new Cron
                    {
                        Email = DataHelper.IfDBNull<string>(row["Email"], _stringEmpty),
                        Sceltabenefit = DataHelper.IfDBNull<string>(row["Benefit"], _stringEmpty),
                        Importo = DataHelper.IfDBNull<decimal>(row["ImportoMensile"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public bool ExistMatricola(string matricola, string codsocieta)
        {
            bool retVal = false;
            string sql = " SELECT iduser FROM EF_users WHERE Matricola = @matricola and codsocieta = @codsocieta ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param3.Value = codsocieta;
            collParams.Add(param3);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@matricola", DbType.String);
            param10.Value = matricola;
            collParams.Add(param10);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public int UpdateZucchetti(ICron value)
        {
            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users SET [idzucchetti] = @idzucchetti WHERE Matricola = @matricola and codsocieta = @codsocieta AND uidtenant = @Uidtenant SELECT @@ROWCOUNT as totRowCorrect ";

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param3.Value = value.Codsocieta;
            collParams.Add(param3);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@matricola", DbType.String);
            param10.Value = value.Matricola;
            collParams.Add(param10);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@idzucchetti", DbType.String);
            param5.Value = value.Idzucchetti;
            collParams.Add(param5);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param22.Value = value.Uidtenant;
            collParams.Add(param22);

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }
        public ICron ReturnCodSocieta(string codzucchetti)
        {
            ICron retVal = null;
            string sql = "SELECT TOP 1 codsocieta FROM EF_societa WHERE codzucchetti = @codzucchetti ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codzucchetti", DbType.String);
            param0.Value = codzucchetti;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cron
                {
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
    }
}