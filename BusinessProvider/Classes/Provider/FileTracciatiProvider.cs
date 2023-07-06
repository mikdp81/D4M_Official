// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CFileTracciatiProvider.cs" company="">
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

    [SectionName("filetracciati.provider/FileTracciatiSection")]
    public class FileTracciatiProvider : DFleetDataProvider, IFileTracciatiProvider
    {

        public int InsertFileTracciato(IFileTracciati value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_filecaricati ([idtipofile],[nomefile],[datacaricato],[UserIDIns] ) " +
                         " VALUES (@idtipofile,@nomefile,@datacaricato,@UserIDIns) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idtipofile", DbType.Int32);
            param0.Value = value.Idtipofile;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@nomefile", DbType.String);
            param1.Value = value.Nomefile;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@datacaricato", DbType.DateTime);
            param2.Value = DateTime.Now;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param3.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param3);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }

        public List<IFileTracciati> SelectTipoFile(Guid Uidtenant)
        {
            List<IFileTracciati> retVal = new List<IFileTracciati>();

            string sql = "SELECT * FROM EF_tipofile WHERE uidtenant = @Uidtenant ORDER BY tipofile ";

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
                    IFileTracciati item = new FileTracciati
                    {
                        Idtipofile = DataHelper.IfDBNull<int>(row["idtipofile"], 0),
                        Tipofile = DataHelper.IfDBNull<string>(row["tipofile"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int InsertFuelCardConsumo(IFileTracciati value)
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
                         " [kmtransazione],[numerofuelcard],[targa],[quantita],[prezzo],[importo],[importoiva],[numerofattura],[importofinalefatturato],[datauserins],[UserIDIns],[idcompagnia] " + sqlfield + " ) " +
                         " VALUES (@idprog,@idtransazione,@datatransazione,@codicepuntovendita,@ragionesociale,@localita,@indirizzo,@nazione,@tiporifornimento,@kmtransazione, " +
                         " @numerofuelcard,@targa,@quantita,@prezzo,@importo,@importoiva,@numerofattura,@importofinalefatturato,@datauserins,@UserIDIns,@idcompagnia " + sqlvalue + " ) ";

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
            param19.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param19);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
            param21.Value = value.Idcompagnia;
            collParams.Add(param21);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        public int UpdateFuelCardConsumo(IFileTracciati value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users_fuelcard_consumo SET [numerofattura] = @numerofattura ";

            if (value.Datafattura > DateTime.MinValue)
            {
                sql += " ,[datafattura] = @datafattura ";
                IDbDataParameter param48 = _dataHelper.ProviderConn.CreateDataParameter("@datafattura", DbType.DateTime);
                param48.Value = value.Datafattura;
                collParams.Add(param48);
            }

            sql += " WHERE idtransazione = @idtransazione and numerofuelcard = @numerofuelcard AND uidtenant = @Uidtenant ";

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

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IFileTracciati UltimoIDProg()
        {
            IFileTracciati retVal = null;
            string sql = "SELECT TOP 1 idprog FROM EF_filecaricati ORDER BY idprog DESC";
            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new FileTracciati
                {
                    Idprog = DataHelper.IfDBNull<int>(row["idprog"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public bool ExistFuelCardConsumo(string idtransazione, string numerofuelcard)
        {
            bool retVal = false;
            string sql = " SELECT idcarb FROM EF_users_fuelcard_consumo WHERE idtransazione = @idtransazione and numerofuelcard = @numerofuelcard ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idtransazione", DbType.String);
            param0.Value = idtransazione;
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

        // conta consumi fuelcard driver
        // FILTRO: UserId, datadal, dataal
        public int SelectCountConsumiDriver(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard)
        {
            string condWhere = "";
            if (datadal > DateTime.MinValue) condWhere += " AND c.datatransazione >= @datadal ";
            if (dataal > DateTime.MinValue) condWhere += " AND c.datatransazione <= @dataal ";
            if (!string.IsNullOrEmpty(search)) condWhere += " AND (c.ragionesociale like '%' + @search + '%' or c.localita like '%' + @search + '%' or c.indirizzo like '%' + @search + '%') ";
            if (!string.IsNullOrEmpty(numerofuelcard)) condWhere += " AND c.numerofuelcard = @numerofuelcard ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_users_fuelcard_consumo as c " +
                         " INNER JOIN  EF_users_fuelcard as u ON c.targa = u.targa  and c.numerofuelcard = u.numero " +
                         " INNER JOIN EF_compagnie as g ON c.idcompagnia = g.idcompagnia " +
                         " INNER JOIN EF_contratti_assegnazioni as ca ON ca.targa = u.targa " +
                         " INNER JOIN ef_utility_codifiche as uc ON uc.valore = c.tiporifornimento " +
                         " WHERE c.targa IN (SELECT targa FROM EF_contratti_assegnazioni WHERE ca.UserId = @UserId) and datatransazione<=ca.assegnatoal and datatransazione>=ca.assegnatodal " + condWhere;

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
            if (!string.IsNullOrEmpty(search))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@search", DbType.String);
                param3.Value = search;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(numerofuelcard))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@numerofuelcard", DbType.String);
                param4.Value = numerofuelcard;
                collParams.Add(param4);
            }
            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param2.Value = UserId;
            collParams.Add(param2);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista consumi fuelcard driver
        // FILTRO: UserId, datadal, dataal
        public List<IFileTracciati> SelectConsumiDriver(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, int numrecord, int pagina)
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

            if (datadal > DateTime.MinValue) condWhere += " AND c.datatransazione >= @datadal ";
            if (dataal > DateTime.MinValue) condWhere += " AND c.datatransazione <= @dataal ";
            if (!string.IsNullOrEmpty(search)) condWhere += " AND (c.ragionesociale like '%' + @search + '%' or c.localita like '%' + @search + '%' or c.indirizzo like '%' + @search + '%') ";
            if (!string.IsNullOrEmpty(numerofuelcard)) condWhere += " AND c.numerofuelcard = @numerofuelcard ";

            List<IFileTracciati> retVal = new List<IFileTracciati>();
            string sql = " SELECT c.ragionesociale, c.localita, c.indirizzo, c.quantita, c.prezzo, c.importo, c.importo, c.numerofuelcard, " +
                         " c.importofinalefatturato, c.datatransazione, c.targa, g.compagnia, uc.codifica " +
                         " FROM EF_users_fuelcard_consumo as c " + 
                         " INNER JOIN  EF_users_fuelcard as u ON c.targa = u.targa  and c.numerofuelcard = u.numero " +
                         " INNER JOIN EF_compagnie as g ON c.idcompagnia = g.idcompagnia " +
                         " INNER JOIN EF_contratti_assegnazioni as ca ON ca.targa = u.targa " +
                         " left JOIN ef_utility_codifiche as uc ON uc.valore = c.tiporifornimento " +
                         " WHERE c.targa IN (SELECT targa FROM EF_contratti_assegnazioni WHERE ca.UserId = @UserId) and datatransazione<=ca.assegnatoal and datatransazione>=ca.assegnatodal " + condWhere +
                         " ORDER BY c.datatransazione DESC " + paginazione;

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
            if (!string.IsNullOrEmpty(search))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@search", DbType.String);
                param3.Value = search;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(numerofuelcard))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@numerofuelcard", DbType.String);
                param4.Value = numerofuelcard;
                collParams.Add(param4);
            }
            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param2.Value = UserId;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IFileTracciati item = new FileTracciati
                    {
                        Ragionesociale = DataHelper.IfDBNull<string>(row["ragionesociale"], _stringEmpty),
                        Localita = DataHelper.IfDBNull<string>(row["localita"], _stringEmpty),
                        Indirizzo = DataHelper.IfDBNull<string>(row["indirizzo"], _stringEmpty),
                        Quantita = DataHelper.IfDBNull<decimal>(row["quantita"], 0),
                        Prezzo = DataHelper.IfDBNull<decimal>(row["prezzo"], 0),
                        Importo = DataHelper.IfDBNull<decimal>(row["importo"], 0),
                        Numerofuelcard = DataHelper.IfDBNull<string>(row["numerofuelcard"], _stringEmpty),
                        Compagnia = DataHelper.IfDBNull<string>(row["compagnia"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Tiporifornimento = DataHelper.IfDBNull<string>(row["codifica"], _stringEmpty),
                        Datatransazione = DataHelper.IfDBNull<DateTime>(row["datatransazione"], DateTime.MinValue),
                        Importofinalefatturato = DataHelper.IfDBNull<decimal>(row["importofinalefatturato"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IFileTracciati> SelectFuelCardDriver(Guid UserId)
        {
            List<IFileTracciati> retVal = new List<IFileTracciati>();

            string sql = " SELECT numero FROM EF_users_fuelcard as f " +
                         " INNER JOIN EF_contratti_assegnazioni as ca ON ca.targa = f.targa " + 
                         " WHERE f.targa IN (SELECT targa FROM EF_contratti_assegnazioni WHERE ca.UserId = @UserId) ORDER BY numero ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param2.Value = UserId;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IFileTracciati item = new FileTracciati
                    {
                        Numerofuelcard = DataHelper.IfDBNull<string>(row["numero"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IFileTracciati> SelectAllFuelCard(Guid Uidtenant)
        {
            List<IFileTracciati> retVal = new List<IFileTracciati>();

            string sql = "SELECT numero FROM EF_users_fuelcard WHERE uidtenant = @Uidtenant ORDER BY numero ";

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
                    IFileTracciati item = new FileTracciati
                    {
                        Numerofuelcard = DataHelper.IfDBNull<string>(row["numero"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int InsertFringeBenefit(IFileTracciati value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_fringe_aci ([codjatoauto],[marca],[modello],[serie],[costokm],[fringe25],[fringe30],[fringe50],[fringe60], " +
                         " [periododal],[periodoal],[datauserins],[UserIDIns]) " +
                         " VALUES (@codjatoauto,@marca,@modello,@serie,@costokm,@fringe25,@fringe30,@fringe50,@fringe60,@periododal,@periodoal,@datauserins,@UserIDIns) ";

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
            param19.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param19);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IFileTracciati ExistCodjatoAuto(string marca, string modello, string serie)
        {
            IFileTracciati retVal = null;
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
                retVal = new FileTracciati
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

        public bool ExistAbbinamentoCodjatoAuto(string codjatoauto)
        {
            bool retVal = false;
            string sql = " SELECT codjatoauto FROM EF_fringe_aci WHERE codjatoauto = @codjatoauto ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = codjatoauto;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public List<IFileTracciati> SelectAutoXMarca(string marca)
        {
            List<IFileTracciati> retVal = new List<IFileTracciati>();

            string sql = "SELECT DISTINCT marca, modello, serie, idfringe FROM EF_fringe_aci WHERE CHARINDEX(marca, @marca, 1)<>0 and codjatoauto='' ORDER BY modello ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
            param2.Value = marca;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IFileTracciati item = new FileTracciati
                    {
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["modello"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["serie"], _stringEmpty),
                        Idfringe = DataHelper.IfDBNull<int>(row["idfringe"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateCodjatoAuto(IFileTracciati value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_fringe_aci SET [codjatoauto] = @codjatoauto WHERE marca = @marca AND modello = @modello AND serie = @serie AND uidtenant = @Uidtenant ";

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
        public IFileTracciati ExistCodjatoAutoXId(int idfringe)
        {
            IFileTracciati retVal = null;
            string sql = "SELECT * FROM EF_fringe_aci WHERE idfringe = @idfringe ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idfringe", DbType.Int32);
            param0.Value = idfringe;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new FileTracciati
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
        public List<IFileTracciati> SelectDetailFringeXCod(string codjatoauto)
        {
            List<IFileTracciati> retVal = new List<IFileTracciati>();

            string sql = "SELECT * FROM EF_fringe_aci WHERE codjatoauto = @codjatoauto ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param2.Value = codjatoauto;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IFileTracciati item = new FileTracciati
                    {
                        Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Serie = DataHelper.IfDBNull<string>(row["serie"], _stringEmpty),
                        Idfringe = DataHelper.IfDBNull<int>(row["idfringe"], 0),
                        Fringe25 = DataHelper.IfDBNull<decimal>(row["fringe25"], 0),
                        Fringe30 = DataHelper.IfDBNull<decimal>(row["fringe30"], 0),
                        Fringe50 = DataHelper.IfDBNull<decimal>(row["fringe50"], 0),
                        Fringe60 = DataHelper.IfDBNull<decimal>(row["fringe60"], 0),
                        Costokm = DataHelper.IfDBNull<decimal>(row["costokm"], 0),
                        Periododal = DataHelper.IfDBNull<DateTime>(row["periododal"], DateTime.MinValue),
                        Periodoal = DataHelper.IfDBNull<DateTime>(row["periodoal"], DateTime.MinValue)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        public int SelectCountFringeBenefit(string marca, string modello, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND marca like '%' + @marca + '%' ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND modello like '%' + @modello + '%' ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_fringe_aci WHERE idfringe > 0 AND uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param3.Value = marca;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param4.Value = modello;
                collParams.Add(param4);
            }
            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param2.Value = Uidtenant;
            collParams.Add(param2);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public List<IFileTracciati> SelectFringeBenefit(string marca, string modello, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(marca)) condWhere += " AND marca like '%' + @marca + '%' ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND modello like '%' + @modello + '%' ";

            List<IFileTracciati> retVal = new List<IFileTracciati>();
            string sql = " SELECT * FROM EF_fringe_aci WHERE idfringe > 0 AND uidtenant = @Uidtenant " + condWhere +
                         " ORDER BY marca, modello " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param3.Value = marca;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param4.Value = modello;
                collParams.Add(param4);
            }
            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param2.Value = Uidtenant;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IFileTracciati item = new FileTracciati
                    {
                        Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Serie = DataHelper.IfDBNull<string>(row["serie"], _stringEmpty),
                        Idfringe = DataHelper.IfDBNull<int>(row["idfringe"], 0),
                        Fringe25 = DataHelper.IfDBNull<decimal>(row["fringe25"], 0),
                        Fringe30 = DataHelper.IfDBNull<decimal>(row["fringe30"], 0),
                        Fringe50 = DataHelper.IfDBNull<decimal>(row["fringe50"], 0),
                        Fringe60 = DataHelper.IfDBNull<decimal>(row["fringe60"], 0),
                        Costokm = DataHelper.IfDBNull<decimal>(row["costokm"], 0),
                        Periododal = DataHelper.IfDBNull<DateTime>(row["periododal"], DateTime.MinValue),
                        Periodoal = DataHelper.IfDBNull<DateTime>(row["periodoal"], DateTime.MinValue)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        public int InsertFattureXML(IFileTracciati value)
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
            param11.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.DateTime);
            param12.Value = DateTime.Now;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param13.Value = (Guid)Membership.GetUser().ProviderUserKey;
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
        public int InsertFattureXMLDettaglio(IFileTracciati value)
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
                         " [tipocentrocosto],[centrocostoabb2],[tipocentrocosto2],[naturaiva],[datauserins],[datausermod],[UserIDIns],[UserIdMod] " + sqlfield + ") " +
                         " VALUES (@Uidfattura,@numerolionea,@descrizione,@quantita,@prezzoun,@prezzotot,@iva,@tipodato,@riftesto,@centrocostoabb,@tipocentrocosto, " +
                         " @centrocostoabb2,@tipocentrocosto2,@naturaiva,@datauserins,@datausermod,@UserIDIns,@UserIdMod " + sqlvalue + ") ";

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
            param16.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param16);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.DateTime);
            param17.Value = DateTime.Now;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param18.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param18);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@naturaiva", DbType.String);
            param21.Value = value.Naturaiva;
            collParams.Add(param21);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IFileTracciati UltimoUidFattura()
        {
            IFileTracciati retVal = null;
            string sql = "SELECT TOP 1 Uid FROM EF_fatturexml ORDER BY idfattura DESC";
            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new FileTracciati
                {
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
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

        public IFileTracciati PercentualeFringe(decimal emissione)
        {
            IFileTracciati retVal = null;
            
            string sql = "SELECT percentuale FROM EF_fringe_options WHERE emissioneda <= @emissione and emissionea >= @emissione ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@emissione", DbType.Decimal);
            param0.Value = emissione;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new FileTracciati
                {
                    Percentuale = DataHelper.IfDBNull<decimal>(row["percentuale"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IFileTracciati ValorePercentualeFringe(string codjatoauto, string campo)
        {
            IFileTracciati retVal = null;
            string sql = "SELECT TOP 1 " + SeoHelper.EncodeString(campo) + " FROM EF_fringe_aci WHERE codjatoauto = @codjatoauto ORDER BY periodoal DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = codjatoauto;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new FileTracciati
                {
                    Fringe25 = DataHelper.IfDBNull<decimal>(row[campo], 0),
                };
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountConsumiFuelCard(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, Guid Uidtenant)
        {
            string condWhere = "";
            if (datadal > DateTime.MinValue) condWhere += " AND FORMAT(c.datatransazione, 'dd/MM/yyyy') >= @datadal ";
            if (dataal > DateTime.MinValue) condWhere += " AND FORMAT(c.datatransazione, 'dd/MM/yyyy') <= @dataal ";
            if (!string.IsNullOrEmpty(search)) condWhere += " AND (c.ragionesociale like '%' + @search + '%' or c.localita like '%' + @search + '%' or c.indirizzo like '%' + @search + '%' or c.targa like '%' + @search + '%') ";
            if (!string.IsNullOrEmpty(numerofuelcard)) condWhere += " AND c.numerofuelcard = @numerofuelcard ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_users_fuelcard_consumo as c " +
                         " LEFT JOIN EF_users_fuelcard as u ON c.targa = u.targa  and c.numerofuelcard = u.numero AND c.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni as ca ON ca.targa = c.targa AND ca.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as us ON us.UserId = ca.UserId AND us.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_compagnie as g ON c.idcompagnia = g.idcompagnia AND c.uidtenant = g.uidtenant " +
                         " WHERE idcarb > 0 AND c.uidtenant = @Uidtenant " + condWhere;

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
            if (!string.IsNullOrEmpty(search))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@search", DbType.String);
                param3.Value = search;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(numerofuelcard))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@numerofuelcard", DbType.String);
                param4.Value = numerofuelcard;
                collParams.Add(param4);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param5.Value = Uidtenant;
            collParams.Add(param5);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IFileTracciati> SelectConsumiFuelCard(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerofuelcard, Guid Uidtenant, int numrecord, int pagina)
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

            if (datadal > DateTime.MinValue) condWhere += " AND FORMAT(c.datatransazione, 'dd/MM/yyyy') >= @datadal ";
            if (dataal > DateTime.MinValue) condWhere += " AND FORMAT(c.datatransazione, 'dd/MM/yyyy') <= @dataal ";
            if (!string.IsNullOrEmpty(search)) condWhere += " AND (c.ragionesociale like '%' + @search + '%' or c.localita like '%' + @search + '%' or c.indirizzo like '%' + @search + '%' or c.targa like '%' + @search + '%') ";
            if (!string.IsNullOrEmpty(numerofuelcard)) condWhere += " AND c.numerofuelcard = @numerofuelcard ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";

            List<IFileTracciati> retVal = new List<IFileTracciati>();
            string sql = " SELECT c.ragionesociale, c.localita, c.indirizzo, c.quantita, c.prezzo, c.importofinalefatturato, c.numerofuelcard, " +
                         " c.datatransazione, c.targa, g.compagnia, c.tiporifornimento, us.nome, us.cognome, c.Uid FROM EF_users_fuelcard_consumo as c " +
                         " LEFT JOIN EF_users_fuelcard as u ON c.targa = u.targa  and c.numerofuelcard = u.numero AND c.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni as ca ON ca.targa = c.targa AND ca.uidtenant = c.uidtenant and ca.assegnatodal<=c.datatransazione and ca.assegnatoal >=c.datatransazione " +
                         " LEFT JOIN EF_users as us ON us.UserId = ca.UserId AND ca.uidtenant = us.uidtenant " +
                         " LEFT JOIN EF_compagnie as g ON c.idcompagnia = g.idcompagnia AND c.uidtenant = g.uidtenant " +
                         " WHERE idcarb > 0 AND c.uidtenant = @Uidtenant " + condWhere +
                         " ORDER BY c.datatransazione DESC " + paginazione;

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
            if (!string.IsNullOrEmpty(search))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@search", DbType.String);
                param3.Value = search;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(numerofuelcard))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@numerofuelcard", DbType.String);
                param4.Value = numerofuelcard;
                collParams.Add(param4);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param5.Value = Uidtenant;
            collParams.Add(param5);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IFileTracciati item = new FileTracciati
                    {
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Ragionesociale = DataHelper.IfDBNull<string>(row["ragionesociale"], _stringEmpty),
                        Localita = DataHelper.IfDBNull<string>(row["localita"], _stringEmpty),
                        Indirizzo = DataHelper.IfDBNull<string>(row["indirizzo"], _stringEmpty),
                        Quantita = DataHelper.IfDBNull<decimal>(row["quantita"], 0),
                        Prezzo = DataHelper.IfDBNull<decimal>(row["prezzo"], 0),
                        Importo = DataHelper.IfDBNull<decimal>(row["importofinalefatturato"], 0),
                        Numerofuelcard = DataHelper.IfDBNull<string>(row["numerofuelcard"], _stringEmpty),
                        Compagnia = DataHelper.IfDBNull<string>(row["compagnia"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Tiporifornimento = DataHelper.IfDBNull<string>(row["tiporifornimento"], _stringEmpty),
                        Datatransazione = DataHelper.IfDBNull<DateTime>(row["datatransazione"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IFileTracciati ExistAnagrafica(string codicefiscale)
        {
            IFileTracciati retVal = null;
            string sql = "SELECT UserId, gradecode, iduser FROM EF_users WHERE codicefiscale = @codicefiscale";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codicefiscale", DbType.String);
            param0.Value = codicefiscale;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new FileTracciati
                {
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                    Gradecode = DataHelper.IfDBNull<string>(row["gradecode"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IFileTracciati ExistAnagraficaEmail(string email)
        {
            IFileTracciati retVal = null;
            string sql = "SELECT UserId, gradecode, iduser FROM EF_users WHERE email = @email";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@email", DbType.String);
            param0.Value = email;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new FileTracciati
                {
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                    Gradecode = DataHelper.IfDBNull<string>(row["gradecode"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IFileTracciati ExistAnagraficaMatricola(string matricola)
        {
            IFileTracciati retVal = null;
            string sql = "SELECT UserId, gradecode, iduser FROM EF_users WHERE matricola = @matricola";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@matricola", DbType.String);
            param0.Value = matricola;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new FileTracciati
                {
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                    Gradecode = DataHelper.IfDBNull<string>(row["gradecode"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IFileTracciati DetailSocieta(string codcompany)
        {
            IFileTracciati retVal = null;
            string sql = "SELECT codsocieta FROM EF_societa WHERE codcompany = @codcompany";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcompany", DbType.String);
            param0.Value = codcompany;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new FileTracciati
                {
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int InsertConcur(IFileTracciati value)
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
                         " [datauserins],[datausermod],[UserIDIns],[UserIdMod],[chiave],[tracciato] " + sqlfield + ") " +
                         " VALUES (@UserId,@codcompany,@codservice,@tipologiaspesa,@distanza,@rimborso,@importospesa,@targa,@importodeducibile, " +
                         " @datauserins,@datausermod,@UserIDIns,@UserIdMod,@chiave,@tracciato " + sqlvalue + ") ";

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
            param16.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param16);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.DateTime);
            param17.Value = DateTime.Now;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param18.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param18);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@chiave", DbType.String);
            param20.Value = value.Chiave;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@tracciato", DbType.String);
            param21.Value = value.Tracciato;
            collParams.Add(param21);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountConcur(Guid UserId, DateTime datadal, DateTime dataal, string targa, Guid Uidtenant)
        {
            string condWhere = "";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (datadal > DateTime.MinValue) condWhere += " AND c.dataspesa >= @datadal ";
            if (dataal > DateTime.MinValue) condWhere += " AND c.dataspesa <= @dataal ";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND c.targa = @targa ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_concur as c LEFT JOIN EF_users as u ON c.UserId = u.UserId AND c.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_societa as s ON c.codcompany = s.codcompany AND c.uidtenant = s.uidtenant " +
                         " WHERE c.idconcur > 0 AND c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
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
            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param3.Value = targa;
                collParams.Add(param3);
            }

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param4.Value = Uidtenant;
            collParams.Add(param4);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IFileTracciati> SelectConcur(Guid UserId, DateTime datadal, DateTime dataal, string targa, Guid Uidtenant, int numrecord, int pagina)
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

            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (datadal > DateTime.MinValue) condWhere += " AND c.dataspesa >= @datadal ";
            if (dataal > DateTime.MinValue) condWhere += " AND c.dataspesa <= @dataal ";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND c.targa = @targa ";

            List<IFileTracciati> retVal = new List<IFileTracciati>();
            string sql = " SELECT u.nome, u.cognome, u.matricola, s.siglasocieta, c.* FROM EF_concur as c LEFT JOIN EF_users as u ON c.UserId = u.UserId AND c.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_societa as s ON c.codcompany = s.codcompany AND c.uidtenant = s.uidtenant " +
                         " WHERE c.idconcur > 0 AND c.uidtenant = @Uidtenant " + condWhere + " ORDER BY c.dataspesa DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
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
            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param3.Value = targa;
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
                    IFileTracciati item = new FileTracciati
                    {
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Codcompany = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Dataspesa = DataHelper.IfDBNull<DateTime>(row["dataspesa"], DateTime.MinValue),
                        Codservice = DataHelper.IfDBNull<string>(row["codservice"], _stringEmpty),
                        Tipologiaspesa = DataHelper.IfDBNull<string>(row["tipologiaspesa"], _stringEmpty),
                        Distanza = DataHelper.IfDBNull<decimal>(row["distanza"], 0),
                        Rimborso = DataHelper.IfDBNull<decimal>(row["rimborso"], 0),
                        Importospesa = DataHelper.IfDBNull<decimal>(row["importospesa"], 0),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Importodeducibile = DataHelper.IfDBNull<decimal>(row["importodeducibile"], 0),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        public List<IFileTracciati> SelectViewConcur(string matricola, string targa, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(matricola)) condWhere += " AND IDEMPL = @matricola ";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ANNUMBER = @targa ";

            List<IFileTracciati> retVal = new List<IFileTracciati>();
            string sql = " SELECT * FROM view_concur WHERE MODELLO <> '' AND uidtenant = @Uidtenant " + condWhere + " ORDER BY annumber, CODGEST DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(matricola))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@matricola", DbType.String);
                param2.Value = matricola;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param3.Value = targa;
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
                    IFileTracciati item = new FileTracciati
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
        public int SelectCountViewConcur(string matricola, string targa, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(matricola)) condWhere += " AND IDEMPL = @matricola ";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ANNUMBER = @targa ";

            string SQL = " SELECT COUNT(*) as tot FROM view_concur WHERE MODELLO <> '' AND uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(matricola))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@matricola", DbType.String);
                param2.Value = matricola;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param3.Value = targa;
                collParams.Add(param3);
            }
            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param4.Value = Uidtenant;
            collParams.Add(param4);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public int InsertTelePassConsumo(IFileTracciati value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_users_telepass_consumo ([dispositivo],[numerodispositivo],[dataora],[descrizione],[classe],[importo],[datauserins],[UserIDIns] ) " +
                         " VALUES (@dispositivo,@numerodispositivo,@dataora,@descrizione,@classe,@importo,@datauserins,@UserIDIns) ";

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
            param6.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param6);

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
        public List<IFileTracciati> SelectAllTelePass(Guid Uidtenant)
        {
            List<IFileTracciati> retVal = new List<IFileTracciati>();

            string sql = "SELECT numero FROM EF_users_telepass WHERE uidtenant = @Uidtenant ORDER BY numero ";

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
                    IFileTracciati item = new FileTracciati
                    {
                        Numerofuelcard = DataHelper.IfDBNull<string>(row["numero"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountConsumiTelePass(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerodispositivo, Guid Uidtenant)
        {
            string condWhere = "";
            if (datadal > DateTime.MinValue) condWhere += " AND FORMAT(c.dataora, 'dd/MM/yyyy') >= @datadal ";
            if (dataal > DateTime.MinValue) condWhere += " AND FORMAT(c.dataora, 'dd/MM/yyyy') <= @dataal ";
            if (!string.IsNullOrEmpty(search)) condWhere += " AND c.descrizione like '%' + @search + '%' ";
            if (!string.IsNullOrEmpty(numerodispositivo)) condWhere += " AND c.numerodispositivo = @numerodispositivo ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_users_telepass_consumo as c " +
                         " LEFT JOIN EF_users_telepass as u ON c.numerodispositivo = u.numero AND c.uidtenant = u.uidtenant" +
                         " LEFT JOIN EF_contratti_assegnazioni as ca ON ca.targa = u.targa AND ca.uidtenant = u.uidtenant" +
                         " LEFT JOIN EF_users as us ON us.UserId = ca.UserId AND ca.uidtenant = us.uidtenant" +
                         " LEFT JOIN EF_compagnie as g ON u.idcompagnia = g.idcompagnia AND g.uidtenant = u.uidtenant" +
                         " WHERE idtelep > 0 AND c.uidtenant = @Uidtenant " + condWhere;

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
            if (!string.IsNullOrEmpty(search))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@search", DbType.String);
                param3.Value = search;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(numerodispositivo))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@numerodispositivo", DbType.String);
                param4.Value = numerodispositivo;
                collParams.Add(param4);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param5.Value = Uidtenant;
            collParams.Add(param5);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IFileTracciati> SelectConsumiTelePass(Guid UserId, DateTime datadal, DateTime dataal, string search, string numerodispositivo, Guid Uidtenant, int numrecord, int pagina)
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

            if (datadal > DateTime.MinValue) condWhere += " AND FORMAT(c.dataora, 'dd/MM/yyyy') >= @datadal ";
            if (dataal > DateTime.MinValue) condWhere += " AND FORMAT(c.dataora, 'dd/MM/yyyy') <= @dataal ";
            if (!string.IsNullOrEmpty(search)) condWhere += " AND c.descrizione like '%' + @search + '%' ";
            if (!string.IsNullOrEmpty(numerodispositivo)) condWhere += " AND c.numerodispositivo = @numerodispositivo ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";

            List<IFileTracciati> retVal = new List<IFileTracciati>();
            string sql = " SELECT us.nome, us.cognome, u.targa, c.numerodispositivo, c.dataora, c.descrizione, c.importo, g.compagnia " +
                         " FROM EF_users_telepass_consumo as c " +
                         " LEFT JOIN EF_users_telepass as u ON c.numerodispositivo = u.numero AND c.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni as ca ON ca.targa = u.targa AND ca.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_users as us ON us.UserId = ca.UserId AND ca.uidtenant = us.uidtenant " +
                         " LEFT JOIN EF_compagnie as g ON u.idcompagnia = g.idcompagnia AND g.uidtenant = u.uidtenant " +
                         " WHERE idtelep > 0 AND c.uidtenant = @Uidtenant " + condWhere +
                         " ORDER BY c.dataora DESC " + paginazione;

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
            if (!string.IsNullOrEmpty(search))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@search", DbType.String);
                param3.Value = search;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(numerodispositivo))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@numerodispositivo", DbType.String);
                param4.Value = numerodispositivo;
                collParams.Add(param4);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param5.Value = Uidtenant;
            collParams.Add(param5);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IFileTracciati item = new FileTracciati
                    {
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Numerofuelcard = DataHelper.IfDBNull<string>(row["numerodispositivo"], _stringEmpty),
                        Dataora = DataHelper.IfDBNull<DateTime>(row["dataora"], DateTime.MinValue),
                        Descrizione = DataHelper.IfDBNull<string>(row["descrizione"], _stringEmpty),
                        Importo = DataHelper.IfDBNull<decimal>(row["importo"], 0),
                        Compagnia = DataHelper.IfDBNull<string>(row["compagnia"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IFileTracciati> SelectFileCaricati()
        {
            List<IFileTracciati> retVal = new List<IFileTracciati>();

            string sql = "SELECT TOP 30 f.*, t.tipofile FROM EF_filecaricati as f LEFT JOIN EF_tipofile as t ON f.idtipofile = t.idtipofile ORDER BY datacaricato DESC ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IFileTracciati item = new FileTracciati
                    {
                        Idprog = DataHelper.IfDBNull<int>(row["idprog"], 0),
                        Tipofile = DataHelper.IfDBNull<string>(row["tipofile"], _stringEmpty),
                        Filexml = DataHelper.IfDBNull<string>(row["nomefile"], _stringEmpty),
                        Datacaricato = DataHelper.IfDBNull<DateTime>(row["datacaricato"], DateTime.MinValue),
                        Importato = DataHelper.IfDBNull<string>(row["importato"], _stringEmpty),
                        Dataimportazione = DataHelper.IfDBNull<DateTime>(row["dataimportazione"], DateTime.MinValue)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IFileTracciati DetailFileCaricati(int idprog)
        {
            IFileTracciati retVal = null;
            string sql = "SELECT * FROM EF_filecaricati WHERE idprog = @idprog";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idprog", DbType.Int32);
            param0.Value = idprog;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new FileTracciati
                {
                    Idprog = DataHelper.IfDBNull<int>(row["idprog"], 0),
                    Idtipofile = DataHelper.IfDBNull<int>(row["idtipofile"], 0),
                    Filexml = DataHelper.IfDBNull<string>(row["nomefile"], _stringEmpty),
                };
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateFileElaborato(int idprog, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = " UPDATE EF_filecaricati SET [importato] = 'SI', [dataimportazione] = @dataimportazione WHERE idprog = @idprog AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idprog", DbType.Int32);
            param0.Value = idprog;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@dataimportazione", DbType.DateTime);
            param1.Value = DateTime.Now;
            collParams.Add(param1);

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

        public int UpdateStoricoImportazione(IFileTracciati value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_importazioni_storico SET [importato] = @importato, [dataimportazione] = @dataimportazione, [righeimportate] = @righeimportate, " +
                            " righetotali = @righetotali , [texterrori] = @texterrori WHERE idprog = @idprog AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@importato", DbType.String);
            param1.Value = value.Importato;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@dataimportazione", DbType.DateTime);
            param2.Value = DateTime.Now;
            collParams.Add(param2);

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
        public IFileTracciati DetailImportazioni(int idprog)
        {
            IFileTracciati retVal = null;
            string sql = "SELECT * FROM EF_importazioni_storico INNER JOIN EF_tipofile ON EF_importazioni_storico.idtipofile = EF_tipofile.idtipofile WHERE idprog = @idprog";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idprog", DbType.Int32);
            param0.Value = idprog;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new FileTracciati
                {
                    Idprog = DataHelper.IfDBNull<int>(row["idprog"], 0),
                    Tipofile = DataHelper.IfDBNull<string>(row["tipofile"], _stringEmpty),
                    Nomefile = DataHelper.IfDBNull<string>(row["nomefile"], _stringEmpty),
                    Importato = DataHelper.IfDBNull<string>(row["importato"], _stringEmpty),
                    Datacaricato = DataHelper.IfDBNull<DateTime>(row["datacaricato"], DateTime.MinValue),
                    Dataimportazione = DataHelper.IfDBNull<DateTime>(row["dataimportazione"], DateTime.MinValue),
                    Datafineperiodo = DataHelper.IfDBNull<DateTime>(row["datafineimportazione"], DateTime.MinValue),
                    Periododal = DataHelper.IfDBNull<DateTime>(row["periododal"], DateTime.MinValue),
                    Periodoal = DataHelper.IfDBNull<DateTime>(row["periodoal"], DateTime.MinValue),
                    Righeimportate = DataHelper.IfDBNull<int>(row["righeimportate"], 0),
                    Righetotali = DataHelper.IfDBNull<int>(row["righetotali"], 0),
                    Texterrori = DataHelper.IfDBNull<string>(row["texterrori"], _stringEmpty),
                    Cartellaimport = DataHelper.IfDBNull<string>(row["cartellaimport"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int InsertStoricoImportazione(IFileTracciati value)
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

            string sql = " INSERT INTO EF_importazioni_storico ([idtipofile],[nomefile],[datacaricato],[UserIDIns],[cartellaimport],[idtemplate],[uidtenant] " + sqlfield + ") " +
                            " VALUES (@idtipofile, @nomefile, @datacaricato, @UserIDIns, @cartellaimport,@idtemplate,@uidtenant " + sqlvalue + ") ";

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

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param4.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param4);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@idtemplate", DbType.Int32);
            param6.Value = value.Idtelep;
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
        public List<IFileTracciati> SelectImportazioni(int idtipofile, string nomefile, DateTime datadal, DateTime dataal, Guid Uidtenant)
        {
            string condWhere = "";

            if (!string.IsNullOrEmpty(nomefile)) condWhere += "  AND EF_importazioni_storico.nomefile LIKE '%' + @nomefile + '%' ";
            if (datadal > DateTime.MinValue) condWhere += " AND EF_importazioni_storico.dataimportazione >= @datacontrattodal";
            if (dataal > DateTime.MinValue) condWhere += " AND EF_importazioni_storico.dataimportazione <= @datacontrattoal";
            if (idtipofile > 0) condWhere += " AND EF_importazioni_storico.idtipofile = @idtipofile ";

            List<IFileTracciati> retVal = new List<IFileTracciati>();

            string sql = " SELECT TOP 500 * FROM EF_importazioni_storico " +
                         " INNER JOIN EF_tipofile ON EF_importazioni_storico.idtipofile = EF_tipofile.idtipofile AND EF_importazioni_storico.uidtenant = EF_tipofile.uidtenant " +
                         " WHERE idprog > 0 AND EF_importazioni_storico.uidtenant = @Uidtenant " + condWhere + " ORDER BY datacaricato DESC";

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(nomefile))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@nomefile", DbType.String);
                param0.Value = nomefile;
                collParams.Add(param0);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param6.Value = datadal;
                collParams.Add(param6);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param7.Value = dataal;
                collParams.Add(param7);
            }
            if (idtipofile > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idtipofile", DbType.Int32);
                param8.Value = idtipofile;
                collParams.Add(param8);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IFileTracciati item = new FileTracciati
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
        public int UpdateFuelCardConsumoCount(IFileTracciati value)
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
        public int DeleteFuelConsumo(Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_users_fuelcard_consumo WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = Uid;
            collParams.Add(paramID);
            
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
        public List<IFileTracciati> SelectViewConcurTxt()
        {
            List<IFileTracciati> retVal = new List<IFileTracciati>();
            string sql = " SELECT * FROM view_concur_900 ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IFileTracciati item = new FileTracciati
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
        public IFileTracciati DetailConcur900(string matricola)
        {
            IFileTracciati retVal = null;
            string sql = "SELECT TOP 1 * FROM EF_concur_900 WHERE matricola = @matricola and modifica<>'Y' ORDER BY data DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@matricola", DbType.String);
            param0.Value = matricola;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new FileTracciati
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
        public int InsertConcur900(IFileTracciati value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_concur_900 ([data],[codice],[matricola],[tipo],[targa],[descrizione],[benefit],[benefitalt],[modifica]) " +
                            " VALUES (@data, @codice, @matricola, @tipo, @targa, @descrizione, @benefit, @benefitalt, @modifica) ";

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

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }


            return retVal;
        }
        public List<IFileTracciati> SelectViewConcur900Txt()
        {
            string dataoggi = DateTime.Now.ToString("yyyy-MM-dd");

            List<IFileTracciati> retVal = new List<IFileTracciati>();
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
                    IFileTracciati item = new FileTracciati
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
    }
}