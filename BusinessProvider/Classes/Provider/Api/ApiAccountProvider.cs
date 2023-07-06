using BaseProvider;
using BusinessObject;
using MultiDataConnection;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessProvider
{
    /// <summary>
    /// Rappresenta un provider di account API.
    /// </summary>
    [SectionName("apiaccount.provider/ApiAccountSection")]
    public class ApiAccountProvider : DFleetDataProvider, IApiAccountProvider
    {
        private readonly IAccountProvider accountProvider = new ProviderFactory().ServizioAccount;

        /// <summary>
        /// Elimina un team.
        /// </summary>
        /// <param name="value">Oggetto account API che rappresenta il team.</param>
        /// <returns>Il numero di righe interessate.</returns>
        public int DeleteTeam(IApiAccount value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_team WHERE idteam = @idteam and uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@idteam", DbType.Int32);
            paramID.Value = ((IAccount)value).Idteam;
            collParams.Add(paramID);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param1.Value = ((IAccount)value).Uidtenant;
            collParams.Add(param1);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }
            return retVal;
        }

        /// <summary>
        /// Elimina un utente.
        /// </summary>
        /// <param name="value">Oggetto account API che rappresenta l'utente.</param>
        /// <returns>Il numero di righe interessate.</returns>
        public int DeleteUser(IApiAccount value)
        {
            return accountProvider.Delete(value);
        }

        /// <summary>
        /// Inserisce un team.
        /// </summary>
        /// <param name="value">Oggetto account API che rappresenta il team da inserire.</param>
        /// <returns>Il numero di righe interessate.</returns>
        public int InsertTeam(IApiAccount value)
        {
            return accountProvider.InsertTeam(value);
        }

        /// <summary>
        /// Inserisce un utente.
        /// </summary>
        /// <param name="value">Oggetto account API che rappresenta l'utente da inserire.</param>
        /// <returns>Il numero di righe interessate.</returns>
        public int InsertUser(IApiAccount value)
        {
            return accountProvider.Insert(value);
        }

        /// <summary>
        /// Seleziona i team in base ai criteri specificati.
        /// </summary>
        /// <param name="Uidtenant">L'UID del tenant.</param>
        /// <param name="keysearch">La stringa di ricerca per il nome del team (opzionale).</param>
        /// <param name="pagina">Il numero di pagina dei risultati (opzionale, valore predefinito: 1).</param>
        /// <returns>Una lista di account API che rappresentano i team selezionati.</returns>
        public List<IApiAccount> SelectTeam(Guid Uidtenant, string keysearch, int pagina)
        {
            string condWhere = "";
            string paginazione;
            int numrecord = 1000;
            if (pagina == 0)
            {
                pagina = 1;
            }

            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND team like '%' + @keysearch + '%' ";

            List<IApiAccount> retVal = new List<IApiAccount>();
            string sql = "SELECT * FROM EF_team WHERE idteam > 0 AND uidtenant = @Uidtenant " + condWhere + " ORDER BY team " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param1.Value = Uidtenant;
            collParams.Add(param1);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IApiAccount item = new Account
                    {
                        Idteam = DataHelper.IfDBNull<int>(row["idteam"], 0),
                        Team = DataHelper.IfDBNull<string>(row["team"], _stringEmpty),
                        Stato = DataHelper.IfDBNull<string>(row["stato"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        /// <summary>
        /// Seleziona gli utenti in base ai criteri specificati.
        /// </summary>
        /// <param name="Uidtenant">L'identificatore univoco del tenant.</param>
        /// <param name="codsocieta">Il codice della società.</param>
        /// <param name="keysearch">La chiave di ricerca per il nome, il cognome, l'email o la matricola.</param>
        /// <param name="idstatususer">L'ID dello stato dell'utente.</param>
        /// <param name="idgruppouser">L'ID del gruppo dell'utente.</param>
        /// <param name="pagina">Il numero di pagina.</param>
        /// <returns>Una lista di oggetti IApiAccount corrispondenti ai criteri di ricerca.</returns>
        public List<IApiAccount> SelectUser(Guid Uidtenant, string codsocieta, string keysearch, int idstatususer, int idgruppouser, int pagina)
        {
            string condWhere = "";
            string paginazione;
            int numrecord = 1000;

            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " and (u.nome like '%' + @keysearch + '%' or u.cognome like '%' + @keysearch + '%' or u.email  like '%' + @keysearch + '%' or u.matricola like '%' + @keysearch + '%') ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " and u.codsocieta = @codsocieta ";
            if (idstatususer > -1) condWhere += " and u.idstatususer = @idstatususer ";
            if (idgruppouser > 0) condWhere += " and u.idgruppouser = @idgruppouser ";

            List<IApiAccount> retVal = new List<IApiAccount>();
            string sql = " SELECT * FROM EF_users as u " +
                         " LEFT JOIN EF_userstatus as us ON u.idstatususer = us.idstatususer AND u.uidtenant = us.uidtenant " +
                         " LEFT JOIN EF_gruppi as g ON g.idgruppouser = u.idgruppouser AND g.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = u.codsocieta AND s.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_grade as gr ON gr.codgrade = u.gradecode AND gr.uidtenant = u.uidtenant " +
                         " WHERE u.iduser > 0 and u.Uidtenant = @Uidtenant " + condWhere + " ORDER BY cognome, nome " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param0.Value = Uidtenant;
            collParams.Add(param0);

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param1.Value = keysearch;
                collParams.Add(param1);
            }

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }

            if (idstatususer > -1)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@idstatususer", DbType.Int32);
                param3.Value = idstatususer;
                collParams.Add(param3);
            }

            if (idgruppouser > 0)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idgruppouser", DbType.Int32);
                param4.Value = idgruppouser;
                collParams.Add(param4);
            }

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IApiAccount item = new Account
                    {
                        Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                        Idgruppouser = DataHelper.IfDBNull<int>(row["idgruppouser"], 0),
                        Gruppouser = DataHelper.IfDBNull<string>(row["gruppouser"], _stringEmpty),
                        Idstatususer = DataHelper.IfDBNull<int>(row["idstatususer"], 0),
                        Statusutente = DataHelper.IfDBNull<string>(row["statusutente"], _stringEmpty),
                        Flgadmin = DataHelper.IfDBNull<int>(row["flgadmin"], 0),
                        Flgdriver = DataHelper.IfDBNull<int>(row["flgdriver"], 0),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Siglasocieta = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Idnumber = DataHelper.IfDBNull<string>(row["idnumber"], _stringEmpty),
                        Idtipodriver = DataHelper.IfDBNull<int>(row["idtipodriver"], 0),
                        Funzione = DataHelper.IfDBNull<string>(row["funzione"], _stringEmpty),
                        Maternita = DataHelper.IfDBNull<string>(row["maternita"], _stringEmpty),
                        Cellulare = DataHelper.IfDBNull<string>(row["cellulare"], _stringEmpty),
                        Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                        Dataassunzione = DataHelper.IfDBNull<DateTime>(row["dataassunzione"], DateTime.MinValue),
                        Codicecdc = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty),
                        Codicecdc2 = DataHelper.IfDBNull<string>(row["codicecdc2"], _stringEmpty),
                        Codicecdc3 = DataHelper.IfDBNull<string>(row["codicecdc3"], _stringEmpty),
                        Perccdc = DataHelper.IfDBNull<int>(row["perccdc"], 0),
                        Perccdc2 = DataHelper.IfDBNull<int>(row["perccdc2"], 0),
                        Perccdc3 = DataHelper.IfDBNull<int>(row["perccdc3"], 0),
                        Descrizionecdc = DataHelper.IfDBNull<string>(row["descrizionecdc"], _stringEmpty),
                        Fasciacarpolicy = DataHelper.IfDBNull<string>(row["fasciacarpolicy"], _stringEmpty),
                        Codicesede = DataHelper.IfDBNull<string>(row["codicesede"], _stringEmpty),
                        Descrizionesede = DataHelper.IfDBNull<string>(row["descrizionesede"], _stringEmpty),
                        Datanascita = DataHelper.IfDBNull<DateTime>(row["datanascita"], DateTime.MinValue),
                        Luogonascita = DataHelper.IfDBNull<string>(row["luogonascita"], _stringEmpty),
                        Provincianascita = DataHelper.IfDBNull<string>(row["provincianascita"], _stringEmpty),
                        Codicefiscale = DataHelper.IfDBNull<string>(row["codicefiscale"], _stringEmpty),
                        Indirizzoresidenza = DataHelper.IfDBNull<string>(row["indirizzoresidenza"], _stringEmpty),
                        Localitaresidenza = DataHelper.IfDBNull<string>(row["localitaresidenza"], _stringEmpty),
                        Provinciaresidenza = DataHelper.IfDBNull<string>(row["provinciaresidenza"], _stringEmpty),
                        Capresidenza = DataHelper.IfDBNull<string>(row["capresidenza"], _stringEmpty),
                        Nrpatente = DataHelper.IfDBNull<string>(row["nrpatente"], _stringEmpty),
                        Dataemissione = DataHelper.IfDBNull<DateTime>(row["dataemissione"], DateTime.MinValue),
                        Datascadenza = DataHelper.IfDBNull<DateTime>(row["datascadenza"], DateTime.MinValue),
                        Ufficioemittente = DataHelper.IfDBNull<string>(row["ufficioemittente"], _stringEmpty),
                        Matricolaapprovatore = DataHelper.IfDBNull<string>(row["matricolaapprovatore"], _stringEmpty),
                        Codicesocietaapprovatore = DataHelper.IfDBNull<string>(row["codicesocietaapprovatore"], _stringEmpty),
                        Datainiziovalidita = DataHelper.IfDBNull<DateTime>(row["datainiziovalidita"], DateTime.MinValue),
                        Codicesettore = DataHelper.IfDBNull<string>(row["codicesettore"], _stringEmpty),
                        Descrizionesettore = DataHelper.IfDBNull<string>(row["descrizionesettore"], _stringEmpty),
                        Descrizioneapprovatore = DataHelper.IfDBNull<string>(row["descrizioneapprovatore"], _stringEmpty),
                        Emailapprovatore = DataHelper.IfDBNull<string>(row["emailapprovatore"], _stringEmpty),
                        Dataprevistadimissione = DataHelper.IfDBNull<DateTime>(row["dataprevistadimissione"], DateTime.MinValue),
                        Datadimissioni = DataHelper.IfDBNull<DateTime>(row["datadimissioni"], DateTime.MinValue),
                        Gradecode = DataHelper.IfDBNull<string>(row["gradecode"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Persontype = DataHelper.IfDBNull<string>(row["persontype"], _stringEmpty),
                        Indirizzosede = DataHelper.IfDBNull<string>(row["indirizzosede"], _stringEmpty),
                        Cittasede = DataHelper.IfDBNull<string>(row["cittasede"], _stringEmpty),
                        Provinciasede = DataHelper.IfDBNull<string>(row["provinciasede"], _stringEmpty),
                        Capsede = DataHelper.IfDBNull<string>(row["capsede"], _stringEmpty),
                        Codicedivisione = DataHelper.IfDBNull<string>(row["codicedivisione"], _stringEmpty),
                        Descrizionedivisione = DataHelper.IfDBNull<string>(row["descrizionedivisione"], _stringEmpty),
                        Fasciaimportazione = DataHelper.IfDBNull<string>(row["fasciaimportazione"], _stringEmpty),
                        Annotazioni = DataHelper.IfDBNull<string>(row["annotazioni"], _stringEmpty),
                        Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Uidtenant = DataHelper.IfDBNull<Guid>(row["uidtenant"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        /// <summary>
        /// Ottiene i dettagli di un team in base all'ID del team.
        /// </summary>
        /// <param name="idteam">L'ID del team.</param>
        /// <param name="idteam">L'Uidtenant del team.</param>
        /// <returns>Un oggetto IApiAccount contenente i dettagli del team.</returns>
        public IApiAccount TeamDetail(int idteam, Guid Uidtenant)
        {
            IApiAccount retVal = null;
            string sql = "SELECT * FROM EF_team WHERE idteam = @idteam AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idteam", DbType.Int32);
            param1.Value = idteam;
            collParams.Add(param1);

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param0.Value = Uidtenant;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    Idteam = DataHelper.IfDBNull<int>(row["idteam"], 0),
                    Team = DataHelper.IfDBNull<string>(row["team"], _stringEmpty),
                    Stato = DataHelper.IfDBNull<string>(row["stato"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }

        /// <summary>
        /// Aggiorna un team esistente nel sistema.
        /// </summary>
        /// <param name="value">L'oggetto IApiAccount che rappresenta il team da aggiornare.</param>
        /// <returns>Il numero di righe interessate dall'operazione di aggiornamento.</returns>
        public int UpdateTeam(IApiAccount value)
        {
            return accountProvider.UpdateTeam(value);
        }

        /// <summary>
        /// Aggiorna un utente esistente nel sistema.
        /// </summary>
        /// <param name="value">L'oggetto IApiAccount che rappresenta l'utente da aggiornare.</param>
        /// <returns>Il numero di righe interessate dall'operazione di aggiornamento.</returns>
        public int UpdateUser(IApiAccount value)
        {
            return accountProvider.Update(value);
        }

        /// <summary>
        /// Ottiene i dettagli di un utente in base all'email dell'utente.
        /// </summary>
        /// <param name="emailuser">L'email dell'utente.</param>
        /// <returns>Un oggetto IApiAccount contenente i dettagli dell'utente.</returns>
        public IApiAccount UserDetail(string emailuser)
        {
            IApiAccount retVal = null;
            string sql = " SELECT * FROM EF_users as u " +
                         " LEFT JOIN EF_userstatus as us ON u.idstatususer = us.idstatususer " +
                         " LEFT JOIN EF_gruppi as g ON g.idgruppouser = u.idgruppouser " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = u.codsocieta " +
                         " LEFT JOIN EF_grade as gr ON gr.codgrade = u.gradecode " +
                         " WHERE u.email = @emailuser ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@emailuser", DbType.String);
            param1.Value = emailuser;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Idgruppouser = DataHelper.IfDBNull<int>(row["idgruppouser"], 0),
                    Gruppouser = DataHelper.IfDBNull<string>(row["gruppouser"], _stringEmpty),
                    Idstatususer = DataHelper.IfDBNull<int>(row["idstatususer"], 0),
                    Statusutente = DataHelper.IfDBNull<string>(row["statusutente"], _stringEmpty),
                    Flgadmin = DataHelper.IfDBNull<int>(row["flgadmin"], 0),
                    Flgdriver = DataHelper.IfDBNull<int>(row["flgdriver"], 0),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Siglasocieta = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                    Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                    Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                    Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                    Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                    Idnumber = DataHelper.IfDBNull<string>(row["idnumber"], _stringEmpty),
                    Idtipodriver = DataHelper.IfDBNull<int>(row["idtipodriver"], 0),
                    Funzione = DataHelper.IfDBNull<string>(row["funzione"], _stringEmpty),
                    Maternita = DataHelper.IfDBNull<string>(row["maternita"], _stringEmpty),
                    Cellulare = DataHelper.IfDBNull<string>(row["cellulare"], _stringEmpty),
                    Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                    Dataassunzione = DataHelper.IfDBNull<DateTime>(row["dataassunzione"], DateTime.MinValue),
                    Codicecdc = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty),
                    Codicecdc2 = DataHelper.IfDBNull<string>(row["codicecdc2"], _stringEmpty),
                    Codicecdc3 = DataHelper.IfDBNull<string>(row["codicecdc3"], _stringEmpty),
                    Perccdc = DataHelper.IfDBNull<int>(row["perccdc"], 0),
                    Perccdc2 = DataHelper.IfDBNull<int>(row["perccdc2"], 0),
                    Perccdc3 = DataHelper.IfDBNull<int>(row["perccdc3"], 0),
                    Descrizionecdc = DataHelper.IfDBNull<string>(row["descrizionecdc"], _stringEmpty),
                    Fasciacarpolicy = DataHelper.IfDBNull<string>(row["fasciacarpolicy"], _stringEmpty),
                    Codicesede = DataHelper.IfDBNull<string>(row["codicesede"], _stringEmpty),
                    Descrizionesede = DataHelper.IfDBNull<string>(row["descrizionesede"], _stringEmpty),
                    Datanascita = DataHelper.IfDBNull<DateTime>(row["datanascita"], DateTime.MinValue),
                    Luogonascita = DataHelper.IfDBNull<string>(row["luogonascita"], _stringEmpty),
                    Provincianascita = DataHelper.IfDBNull<string>(row["provincianascita"], _stringEmpty),
                    Codicefiscale = DataHelper.IfDBNull<string>(row["codicefiscale"], _stringEmpty),
                    Indirizzoresidenza = DataHelper.IfDBNull<string>(row["indirizzoresidenza"], _stringEmpty),
                    Localitaresidenza = DataHelper.IfDBNull<string>(row["localitaresidenza"], _stringEmpty),
                    Provinciaresidenza = DataHelper.IfDBNull<string>(row["provinciaresidenza"], _stringEmpty),
                    Capresidenza = DataHelper.IfDBNull<string>(row["capresidenza"], _stringEmpty),
                    Nrpatente = DataHelper.IfDBNull<string>(row["nrpatente"], _stringEmpty),
                    Dataemissione = DataHelper.IfDBNull<DateTime>(row["dataemissione"], DateTime.MinValue),
                    Datascadenza = DataHelper.IfDBNull<DateTime>(row["datascadenza"], DateTime.MinValue),
                    Ufficioemittente = DataHelper.IfDBNull<string>(row["ufficioemittente"], _stringEmpty),
                    Matricolaapprovatore = DataHelper.IfDBNull<string>(row["matricolaapprovatore"], _stringEmpty),
                    Codicesocietaapprovatore = DataHelper.IfDBNull<string>(row["codicesocietaapprovatore"], _stringEmpty),
                    Datainiziovalidita = DataHelper.IfDBNull<DateTime>(row["datainiziovalidita"], DateTime.MinValue),
                    Codicesettore = DataHelper.IfDBNull<string>(row["codicesettore"], _stringEmpty),
                    Descrizionesettore = DataHelper.IfDBNull<string>(row["descrizionesettore"], _stringEmpty),
                    Descrizioneapprovatore = DataHelper.IfDBNull<string>(row["descrizioneapprovatore"], _stringEmpty),
                    Emailapprovatore = DataHelper.IfDBNull<string>(row["emailapprovatore"], _stringEmpty),
                    Dataprevistadimissione = DataHelper.IfDBNull<DateTime>(row["dataprevistadimissione"], DateTime.MinValue),
                    Datadimissioni = DataHelper.IfDBNull<DateTime>(row["datadimissioni"], DateTime.MinValue),
                    Gradecode = DataHelper.IfDBNull<string>(row["gradecode"], _stringEmpty),
                    Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                    Persontype = DataHelper.IfDBNull<string>(row["persontype"], _stringEmpty),
                    Indirizzosede = DataHelper.IfDBNull<string>(row["indirizzosede"], _stringEmpty),
                    Cittasede = DataHelper.IfDBNull<string>(row["cittasede"], _stringEmpty),
                    Provinciasede = DataHelper.IfDBNull<string>(row["provinciasede"], _stringEmpty),
                    Capsede = DataHelper.IfDBNull<string>(row["capsede"], _stringEmpty),
                    Codicedivisione = DataHelper.IfDBNull<string>(row["codicedivisione"], _stringEmpty),
                    Descrizionedivisione = DataHelper.IfDBNull<string>(row["descrizionedivisione"], _stringEmpty),
                    Fasciaimportazione = DataHelper.IfDBNull<string>(row["fasciaimportazione"], _stringEmpty),
                    Annotazioni = DataHelper.IfDBNull<string>(row["annotazioni"], _stringEmpty),
                    Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                    Uidtenant = DataHelper.IfDBNull<Guid>(row["uidtenant"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }
    }
}
