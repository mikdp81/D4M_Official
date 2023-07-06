// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CMulteProvider.cs" company="">
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

    [SectionName("multe.provider/MulteSection")]
    public class MulteProvider : DFleetDataProvider, IMulteProvider
    {

        //aggiorna multa
        public int UpdateMulte(IMulte value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_multe SET [UserId] = @UserId, [protocollo] = @protocollo, [idtipotrasmissione] = @idtipotrasmissione, [targa] = @targa, [numeroverbale] = @numeroverbale, " +
                         " [orainfrazione] = @orainfrazione, [fileverbale] = @fileverbale, [ente] = @ente, " +
                         " [infrazione] = @infrazione, [punti] = @punti, [importomulta] = @importomulta, [importomultaridotto] = @importomultaridotto, " +
                         " [importomultascontato] = @importomultascontato, [codtipomulta] = @codtipomulta, [datausermod] = @datausermod, [UserIdMod] = @UserIdMod, " +
                         " [idstatuslavorazione] = @idstatuslavorazione, [idstatuspagamento] = @idstatuspagamento, [idtitolarepagamento] = @idtitolarepagamento, [spesepagamento] = @spesepagamento, " +
                         " [codsocieta] = @codsocieta, [cfemittente] = @cfemittente, [codpagopa] = @codpagopa, [iban] = @iban, [codpagopa60] = @codpagopa60, " +
                         " [filericevutapagamento] = @filericevutapagamento, [importomultapagato] = @importomultapagato, " +
                         " [codpagamento] = @codpagamento, [idcontopagamento] = @idcontopagamento, [annotazioni] = @annotazioni, [quotadriver] = @quotadriver, [quotasocieta] = @quotasocieta ";

            if (value.Datainfrazione > DateTime.MinValue)
            {
                sql += " ,[datainfrazione] = @datainfrazione ";
                IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@datainfrazione", DbType.DateTime);
                param18.Value = value.Datainfrazione;
                collParams.Add(param18);
            }

            if (value.Datanotifica > DateTime.MinValue)
            {
                sql += " ,[datanotifica] = @datanotifica ";
                IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@datanotifica", DbType.DateTime);
                param19.Value = value.Datanotifica;
                collParams.Add(param19);
            }

            if (value.Datapagamento > DateTime.MinValue)
            {
                sql += " ,[datapagamento] = @datapagamento ";
                IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@datapagamento", DbType.DateTime);
                param20.Value = value.Datapagamento;
                collParams.Add(param20);
            }

            sql += " WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param3.Value = value.UserId;
            collParams.Add(param3);

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@protocollo", DbType.String);
            param0.Value = value.Protocollo;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idtipotrasmissione", DbType.Int32);
            param1.Value = value.Idtipotrasmissione;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param2.Value = value.Targa;
            collParams.Add(param2);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@numeroverbale", DbType.String);
            param4.Value = value.Numeroverbale;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@orainfrazione", DbType.String);
            param5.Value = value.Orainfrazione;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@fileverbale", DbType.String);
            param6.Value = value.Fileverbale;
            collParams.Add(param6);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@ente", DbType.String);
            param9.Value = value.Ente;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@infrazione", DbType.String);
            param10.Value = value.Infrazione;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@punti", DbType.Int32);
            param11.Value = value.Punti;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@importomulta", DbType.Decimal);
            param12.Value = value.Importomulta;
            collParams.Add(param12);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@importomultaridotto", DbType.Decimal);
            param14.Value = value.Importomultaridotto;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@importomultascontato", DbType.Decimal);
            param15.Value = value.Importomultascontato;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuslavorazione", DbType.Int32);
            param16.Value = value.Idstatuslavorazione;
            collParams.Add(param16);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuspagamento", DbType.Int32);
            param17.Value = value.Idstatuspagamento;
            collParams.Add(param17);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@idtitolarepagamento", DbType.Int32);
            param24.Value = value.Idtitolarepagamento;
            collParams.Add(param24);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@codtipomulta", DbType.String);
            param25.Value = value.Codtipomulta;
            collParams.Add(param25);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param21.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param22.Value = DateTime.Now;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param23.Value = value.Uid;
            collParams.Add(param23);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@spesepagamento", DbType.Decimal);
            param26.Value = value.Spesepagamento;
            collParams.Add(param26);

            IDbDataParameter param27 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param27.Value = value.Codsocieta;
            collParams.Add(param27);

            IDbDataParameter param28 = _dataHelper.ProviderConn.CreateDataParameter("@cfemittente", DbType.String);
            param28.Value = value.Cfemittente;
            collParams.Add(param28);

            IDbDataParameter param29 = _dataHelper.ProviderConn.CreateDataParameter("@codpagopa", DbType.String);
            param29.Value = value.Codpagopa;
            collParams.Add(param29);

            IDbDataParameter param30 = _dataHelper.ProviderConn.CreateDataParameter("@iban", DbType.String);
            param30.Value = value.Iban;
            collParams.Add(param30);

            IDbDataParameter param31 = _dataHelper.ProviderConn.CreateDataParameter("@codpagopa60", DbType.String);
            param31.Value = value.Codpagopa60;
            collParams.Add(param31);

            IDbDataParameter param32 = _dataHelper.ProviderConn.CreateDataParameter("@filericevutapagamento", DbType.String);
            param32.Value = value.Filericevutapagamento;
            collParams.Add(param32);

            IDbDataParameter param34 = _dataHelper.ProviderConn.CreateDataParameter("@codpagamento", DbType.String);
            param34.Value = value.Codpagamento;
            collParams.Add(param34);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@idcontopagamento", DbType.Int32);
            param35.Value = value.Idcontopagamento;
            collParams.Add(param35);

            IDbDataParameter param36 = _dataHelper.ProviderConn.CreateDataParameter("@importomultapagato", DbType.Decimal);
            param36.Value = value.Importomultapagato;
            collParams.Add(param36);

            IDbDataParameter param37 = _dataHelper.ProviderConn.CreateDataParameter("@annotazioni", DbType.String);
            param37.Value = value.Annotazioni;
            collParams.Add(param37);

            IDbDataParameter param38 = _dataHelper.ProviderConn.CreateDataParameter("@quotadriver", DbType.Decimal);
            param38.Value = value.Quotadriver;
            collParams.Add(param38);

            IDbDataParameter param39 = _dataHelper.ProviderConn.CreateDataParameter("@quotasocieta", DbType.Decimal);
            param39.Value = value.Quotasocieta;
            collParams.Add(param39);

            IDbDataParameter param72 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param72.Value = value.Uidtenant;
            collParams.Add(param72);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //cestina multa

        public int DeleteMulte(IMulte value)
        {
            int retVal = 0;
            string sql = "UPDATE EF_multe SET [idstatuslavorazione] = 60 WHERE Uid = @Uid AND uidtenant = @Uidtenant";

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

        //inserimento nuova multa

        public int InsertMulte(IMulte value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Datainfrazione > DateTime.MinValue)
            {
                IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@datainfrazione", DbType.DateTime);
                param18.Value = value.Datainfrazione;
                collParams.Add(param18);

                sqlfield += " ,[datainfrazione] ";
                sqlvalue += " ,@datainfrazione ";
            }

            if (value.Datanotifica > DateTime.MinValue)
            {
                IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@datanotifica", DbType.DateTime);
                param19.Value = value.Datanotifica;
                collParams.Add(param19);

                sqlfield += " ,[datanotifica] ";
                sqlvalue += " ,@datanotifica ";
            }

            if (value.Datapagamento > DateTime.MinValue)
            {
                IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@datapagamento", DbType.DateTime);
                param20.Value = value.Datapagamento;
                collParams.Add(param20);

                sqlfield += " ,[datapagamento] ";
                sqlvalue += " ,@datapagamento ";
            }

            string sql = "INSERT INTO EF_multe ([protocollo], [idtipotrasmissione], [targa], [UserId], [numeroverbale], [orainfrazione], [fileverbale], [filemanleva], [filericevutapagamento], " +
                         " [ente], [infrazione], [punti], [importomulta], [importomultapagato], [importomultaridotto], [importomultascontato], [idstatuslavorazione], [idstatuspagamento], [codtipomulta], " +
                         " [datauserins], [datausermod], [UserIDIns], [UserIdMod], [idtitolarepagamento], [spesepagamento], [codsocieta], [cfemittente], [codpagopa], [iban], [codpagopa60], [uidtenant] " + sqlfield + " ) " +
                         " VALUES (@protocollo, @idtipotrasmissione, @targa, @UserId, @numeroverbale, @orainfrazione, @fileverbale, @filemanleva, @filericevutapagamento, @ente, @infrazione, " +
                         " @punti, @importomulta, @importomultapagato, @importomultaridotto, @importomultascontato, @idstatuslavorazione, @idstatuspagamento, @codtipomulta, " +
                         " @datauserins, @datausermod, @UserIDIns, @UserIdMod, 0, @spesepagamento, @codsocieta, @cfemittente, @codpagopa, @iban, @codpagopa60, @uidtenant " + sqlvalue + " ) ";


            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@protocollo", DbType.String);
            param0.Value = value.Protocollo;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idtipotrasmissione", DbType.Int32);
            param1.Value = value.Idtipotrasmissione;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param2.Value = value.Targa;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param3.Value = value.UserId;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@numeroverbale", DbType.String);
            param4.Value = value.Numeroverbale;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@orainfrazione", DbType.String);
            param5.Value = value.Orainfrazione;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@fileverbale", DbType.String);
            param6.Value = value.Fileverbale;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@filemanleva", DbType.String);
            param7.Value = value.Filemanleva;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@filericevutapagamento", DbType.String);
            param8.Value = value.Filericevutapagamento;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@ente", DbType.String);
            param9.Value = value.Ente;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@infrazione", DbType.String);
            param10.Value = value.Infrazione;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@punti", DbType.Int32);
            param11.Value = value.Punti;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@importomulta", DbType.Decimal);
            param12.Value = value.Importomulta;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@importomultapagato", DbType.Decimal);
            param13.Value = value.Importomultapagato;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@importomultaridotto", DbType.Decimal);
            param14.Value = value.Importomultaridotto;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@importomultascontato", DbType.Decimal);
            param15.Value = value.Importomultascontato;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuslavorazione", DbType.Int32);
            param16.Value = value.Idstatuslavorazione;
            collParams.Add(param16);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuspagamento", DbType.Int32);
            param17.Value = value.Idstatuspagamento;
            collParams.Add(param17);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@codtipomulta", DbType.String);
            param25.Value = value.Codtipomulta;
            collParams.Add(param25);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param22.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param23.Value = DateTime.Now;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param24.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param24);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@spesepagamento", DbType.Decimal);
            param26.Value = value.Spesepagamento;
            collParams.Add(param26);

            IDbDataParameter param27 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param27.Value = value.Codsocieta;
            collParams.Add(param27);

            IDbDataParameter param28 = _dataHelper.ProviderConn.CreateDataParameter("@cfemittente", DbType.String);
            param28.Value = value.Cfemittente;
            collParams.Add(param28);

            IDbDataParameter param29 = _dataHelper.ProviderConn.CreateDataParameter("@codpagopa", DbType.String);
            param29.Value = value.Codpagopa;
            collParams.Add(param29);

            IDbDataParameter param30 = _dataHelper.ProviderConn.CreateDataParameter("@iban", DbType.String);
            param30.Value = value.Iban;
            collParams.Add(param30);

            IDbDataParameter param31 = _dataHelper.ProviderConn.CreateDataParameter("@codpagopa60", DbType.String);
            param31.Value = value.Codpagopa60;
            collParams.Add(param31);

            IDbDataParameter param32 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param32.Value = value.Uidtenant;
            collParams.Add(param32);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli multa

        public IMulte DetailMulteId(Guid Uid)
        {
            IMulte retVal = null;
            string sql = " SELECT m.*, t.tipomulta, u.nome, u.cognome, u.dataprevistadimissione, u.datadimissioni, s.siglasocieta FROM EF_multe as m " +
                         " LEFT JOIN EF_multe_tipo as t ON m.codtipomulta = t.codtipomulta " +
                         " LEFT JOIN EF_users as u ON u.UserId = m.UserId " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON a.targa = m.targa " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = a.codsocieta " +
                         " WHERE m.Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Multe
                {
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                    Idmulta = DataHelper.IfDBNull<int>(row["idmulta"], 0),
                    Protocollo = DataHelper.IfDBNull<string>(row["protocollo"], _stringEmpty),
                    Idtipotrasmissione = DataHelper.IfDBNull<int>(row["idtipotrasmissione"], 0),
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Numeroverbale = DataHelper.IfDBNull<string>(row["numeroverbale"], _stringEmpty),
                    Orainfrazione = DataHelper.IfDBNull<string>(row["orainfrazione"], _stringEmpty),
                    Fileverbale = DataHelper.IfDBNull<string>(row["fileverbale"], _stringEmpty),
                    Filemanleva = DataHelper.IfDBNull<string>(row["filemanleva"], _stringEmpty),
                    Filericevutapagamento = DataHelper.IfDBNull<string>(row["filericevutapagamento"], _stringEmpty),
                    Ente = DataHelper.IfDBNull<string>(row["ente"], _stringEmpty),
                    Infrazione = DataHelper.IfDBNull<string>(row["infrazione"], _stringEmpty),
                    Punti = DataHelper.IfDBNull<int>(row["punti"], 0),
                    Importomulta = DataHelper.IfDBNull<decimal>(row["importomulta"], 0),
                    Importomultapagato = DataHelper.IfDBNull<decimal>(row["importomultapagato"], 0),
                    Importomultaridotto = DataHelper.IfDBNull<decimal>(row["importomultaridotto"], 0),
                    Importomultascontato = DataHelper.IfDBNull<decimal>(row["importomultascontato"], 0),
                    Ckemaildriver = DataHelper.IfDBNull<int>(row["ckemaildriver"], 0),
                    Idstatuslavorazione = DataHelper.IfDBNull<int>(row["idstatuslavorazione"], 0),
                    Idstatuspagamento = DataHelper.IfDBNull<int>(row["idstatuspagamento"], 0),
                    Idtitolarepagamento = DataHelper.IfDBNull<int>(row["idtitolarepagamento"], 0),
                    Codtipomulta = DataHelper.IfDBNull<string>(row["codtipomulta"], _stringEmpty),
                    Tipomulta = DataHelper.IfDBNull<string>(row["tipomulta"], _stringEmpty),
                    Datainfrazione = DataHelper.IfDBNull<DateTime>(row["datainfrazione"], DateTime.MinValue),
                    Datanotifica = DataHelper.IfDBNull<DateTime>(row["datanotifica"], DateTime.MinValue),
                    Datapagamento = DataHelper.IfDBNull<DateTime>(row["datapagamento"], DateTime.MinValue),
                    Spesepagamento = DataHelper.IfDBNull<decimal>(row["spesepagamento"], 0),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Cfemittente = DataHelper.IfDBNull<string>(row["cfemittente"], _stringEmpty),
                    Codpagopa = DataHelper.IfDBNull<string>(row["codpagopa"], _stringEmpty),
                    Codpagopa60 = DataHelper.IfDBNull<string>(row["codpagopa60"], _stringEmpty),
                    Iban = DataHelper.IfDBNull<string>(row["iban"], _stringEmpty),
                    Codpagamento = DataHelper.IfDBNull<string>(row["codpagamento"], _stringEmpty),
                    Denominazione = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                    Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                    Datadimissioni = DataHelper.IfDBNull<DateTime>(row["datadimissioni"], DateTime.MinValue),
                    Datapreseuntedimissioni = DataHelper.IfDBNull<DateTime>(row["dataprevistadimissione"], DateTime.MinValue),
                    Idcontopagamento = DataHelper.IfDBNull<int>(row["idcontopagamento"], 0),
                    Annotazioni = DataHelper.IfDBNull<string>(row["annotazioni"], _stringEmpty),
                    Quotadriver = DataHelper.IfDBNull<decimal>(row["quotadriver"], 0),
                    Quotasocieta = DataHelper.IfDBNull<decimal>(row["quotasocieta"], 0),
                    Datains = DataHelper.IfDBNull<DateTime>(row["datainviomail"], DateTime.MinValue),
                };
                data.Dispose();
            }
            return retVal;
        }


        //conta multe - FILTRO: keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal,  UserId
        public int SelectCountMulte(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (m.numeroverbale like '%' + @keysearch + '%' or m.targa  like '%' + @keysearch + '%') ";
            if (idtipotrasmissione > 0) condWhere += " AND m.idtipotrasmissione = @idtipotrasmissione ";
            if (idstatuslavorazione > 0) condWhere += " AND m.idstatuslavorazione = @idstatuslavorazione ";
            if (idstatuspagamento > -1) condWhere += " AND m.idstatuspagamento = @idstatuspagamento ";
            if (datadal > DateTime.MinValue) condWhere += " AND m.datanotifica >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND m.datanotifica <= @dataal";
            if (UserId != Guid.Empty) condWhere += " AND m.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codtipomulta)) condWhere += " AND m.codtipomulta = @codtipomulta ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_multe as m " +
                         " LEFT JOIN EF_multe_statuslavorazione as l ON m.idstatuslavorazione = l.idstatuslavorazione AND m.uidtenant = l.uidtenant " +
                         " LEFT JOIN EF_multe_tipotrasmissione as tt ON m.idtipotrasmissione = tt.idtipotrasmissione AND m.uidtenant = tt.uidtenant " +
                         " LEFT JOIN EF_multe_statuspagamento as p ON m.idstatuspagamento = p.idstatuspagamento AND m.uidtenant = p.uidtenant " +
                         " LEFT JOIN EF_multe_tipo as t ON m.codtipomulta = t.codtipomulta AND m.uidtenant = t.uidtenant " +
                         " LEFT JOIN EF_users as u ON m.UserId = u.UserId AND m.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_contratti as c ON c.targa = m.targa AND c.uidtenant = m.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta AND c.uidtenant = s.uidtenant" +
                         " WHERE m.idstatuslavorazione <> 60 AND m.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
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
            if (idtipotrasmissione > 0)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idtipotrasmissione", DbType.Int32);
                param4.Value = idtipotrasmissione;
                collParams.Add(param4);
            }
            if (idstatuslavorazione > 0)
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuslavorazione", DbType.Int32);
                param5.Value = idstatuslavorazione;
                collParams.Add(param5);
            }
            if (idstatuspagamento > -1)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuspagamento", DbType.Int32);
                param6.Value = idstatuspagamento;
                collParams.Add(param6);
            }
            if (!string.IsNullOrEmpty(codtipomulta))
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@codtipomulta", DbType.String);
                param7.Value = codtipomulta;
                collParams.Add(param7);
            }
            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param8.Value = Uidtenant;
            collParams.Add(param8);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista multe
        // FILTRO: keysearch, idtipotrasmissione, idstatuslavorazione, idstatuspagamento, codtipomulta, datadal, dataal,  UserId
        public List<IMulte> SelectMulte(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " m.datanotifica DESC ";
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (m.numeroverbale like '%' + @keysearch + '%' or m.targa  like '%' + @keysearch + '%') ";
            if (idtipotrasmissione > 0) condWhere += " AND m.idtipotrasmissione = @idtipotrasmissione ";
            if (idstatuslavorazione > 0) condWhere += " AND m.idstatuslavorazione = @idstatuslavorazione ";
            if (idstatuspagamento > -1) condWhere += " AND m.idstatuspagamento = @idstatuspagamento ";
            if (datadal > DateTime.MinValue) condWhere += " AND m.datanotifica >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND m.datanotifica <= @dataal";
            if (UserId != Guid.Empty) condWhere += " AND m.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codtipomulta)) condWhere += " AND m.codtipomulta = @codtipomulta ";

            List<IMulte> retVal = new List<IMulte>();
            string sql = " SELECT m.*, l.statuslavorazione, tt.tipotrasmissione, p.statuspagamento, t.tipomulta, u.nome, u.cognome, s.siglasocieta FROM EF_multe as m " +
                         " LEFT JOIN EF_multe_statuslavorazione as l ON m.idstatuslavorazione = l.idstatuslavorazione AND m.uidtenant = l.uidtenant " +
                         " LEFT JOIN EF_multe_tipotrasmissione as tt ON m.idtipotrasmissione = tt.idtipotrasmissione AND m.uidtenant = tt.uidtenant " +
                         " LEFT JOIN EF_multe_statuspagamento as p ON m.idstatuspagamento = p.idstatuspagamento AND m.uidtenant = p.uidtenant " +
                         " LEFT JOIN EF_multe_tipo as t ON m.codtipomulta = t.codtipomulta AND m.uidtenant = t.uidtenant " +
                         " LEFT JOIN EF_users as u ON m.UserId = u.UserId AND m.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_contratti as c ON c.targa = m.targa AND m.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta AND c.uidtenant = s.uidtenant " +
                         " WHERE m.idstatuslavorazione <> 60 AND m.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();


            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
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
            if (idtipotrasmissione > 0)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idtipotrasmissione", DbType.Int32);
                param4.Value = idtipotrasmissione;
                collParams.Add(param4);
            }
            if (idstatuslavorazione > 0)
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuslavorazione", DbType.Int32);
                param5.Value = idstatuslavorazione;
                collParams.Add(param5);
            }
            if (idstatuspagamento > -1)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuspagamento", DbType.Int32);
                param6.Value = idstatuspagamento;
                collParams.Add(param6);
            }
            if (!string.IsNullOrEmpty(codtipomulta))
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@codtipomulta", DbType.String);
                param7.Value = codtipomulta;
                collParams.Add(param7);
            }
            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param8.Value = Uidtenant;
            collParams.Add(param8);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IMulte item = new Multe
                    {
                        Protocollo = DataHelper.IfDBNull<string>(row["protocollo"], _stringEmpty),
                        Idtipotrasmissione = DataHelper.IfDBNull<int>(row["idtipotrasmissione"], 0),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                        Numeroverbale = DataHelper.IfDBNull<string>(row["numeroverbale"], _stringEmpty),
                        Datainfrazione = DataHelper.IfDBNull<DateTime>(row["datainfrazione"], DateTime.MinValue),
                        Datanotifica = DataHelper.IfDBNull<DateTime>(row["datanotifica"], DateTime.MinValue),
                        Fileverbale = DataHelper.IfDBNull<string>(row["fileverbale"], _stringEmpty),
                        Filemanleva = DataHelper.IfDBNull<string>(row["filemanleva"], _stringEmpty),
                        Filericevutapagamento = DataHelper.IfDBNull<string>(row["filericevutapagamento"], _stringEmpty),
                        Ente = DataHelper.IfDBNull<string>(row["ente"], _stringEmpty),
                        Infrazione = DataHelper.IfDBNull<string>(row["infrazione"], _stringEmpty),
                        Punti = DataHelper.IfDBNull<int>(row["punti"], 0),
                        Importomulta = DataHelper.IfDBNull<decimal>(row["importomulta"], 0),
                        Importomultapagato = DataHelper.IfDBNull<decimal>(row["importomultapagato"], 0),
                        Importomultaridotto = DataHelper.IfDBNull<decimal>(row["importomultaridotto"], 0),
                        Importomultascontato = DataHelper.IfDBNull<decimal>(row["importomultascontato"], 0),
                        Ckemaildriver = DataHelper.IfDBNull<int>(row["ckemaildriver"], 0),
                        Idstatuslavorazione = DataHelper.IfDBNull<int>(row["idstatuslavorazione"], 0),
                        Idstatuspagamento = DataHelper.IfDBNull<int>(row["idstatuspagamento"], 0),
                        Tipotrasmissione = DataHelper.IfDBNull<string>(row["tipotrasmissione"], _stringEmpty),
                        Statuslavorazione = DataHelper.IfDBNull<string>(row["statuslavorazione"], _stringEmpty),
                        Statuspagamento = DataHelper.IfDBNull<string>(row["statuspagamento"], _stringEmpty),
                        Tipomulta = DataHelper.IfDBNull<string>(row["tipomulta"], _stringEmpty),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IMulte> SelectAllStatusLavorazione(Guid Uidtenant)
        {
            List<IMulte> retVal = new List<IMulte>();

            string sql = "SELECT idstatuslavorazione, statuslavorazione FROM EF_multe_statuslavorazione WHERE uidtenant = @Uidtenant ORDER BY statuslavorazione ";

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
                    IMulte item = new Multe
                    {
                        Idstatuslavorazione = DataHelper.IfDBNull<int>(row["idstatuslavorazione"], 0),
                        Statuslavorazione = DataHelper.IfDBNull<string>(row["statuslavorazione"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IMulte> SelectAllStatusPagamento(Guid Uidtenant)
        {
            List<IMulte> retVal = new List<IMulte>();

            string sql = "SELECT idstatuspagamento, statuspagamento FROM EF_multe_statuspagamento WHERE uidtenant = @Uidtenant ORDER BY statuspagamento ";

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
                    IMulte item = new Multe
                    {
                        Idstatuspagamento = DataHelper.IfDBNull<int>(row["idstatuspagamento"], 0),
                        Statuspagamento = DataHelper.IfDBNull<string>(row["statuspagamento"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IMulte> SelectAllTipoMulte(Guid Uidtenant)
        {
            List<IMulte> retVal = new List<IMulte>();

            string sql = "SELECT codtipomulta, tipomulta FROM EF_multe_tipo WHERE uidtenant = @Uidtenant ORDER BY tipomulta ";

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
                    IMulte item = new Multe
                    {
                        Codtipomulta = DataHelper.IfDBNull<string>(row["codtipomulta"], _stringEmpty),
                        Tipomulta = DataHelper.IfDBNull<string>(row["tipomulta"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IMulte> SelectAllTipoTrasmissioneMulte(Guid Uidtenant)
        {
            List<IMulte> retVal = new List<IMulte>();

            string sql = "SELECT idtipotrasmissione, tipotrasmissione FROM EF_multe_tipotrasmissione WHERE uidtenant = @Uidtenant ORDER BY tipotrasmissione ";

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
                    IMulte item = new Multe
                    {
                        Idtipotrasmissione = DataHelper.IfDBNull<int>(row["idtipotrasmissione"], 0),
                        Tipotrasmissione = DataHelper.IfDBNull<string>(row["tipotrasmissione"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IMulte UltimoIDMulta()
        {
            IMulte retVal = null;
            string sql = "SELECT TOP 1 Uid FROM EF_multe ORDER BY idmulta DESC";
            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Multe
                {
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        
        //aggiorna check email 
        public int UpdateCkEmail(Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = " UPDATE EF_multe SET [ckemaildriver] = 1, [idstatuslavorazione] = 20, [datainviomail] = @datainviomail WHERE Uid = @Uid AND uidtenant = @Uidtenant  ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param23.Value = Uid;
            collParams.Add(param23);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@datainviomail", DbType.DateTime);
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

        //cambia stato lavorazione multa
        public int ChangeStasusLavMulta(Guid Uid, int idstatuslavorazione, string filemanleva, Guid Uidtenant)
        {
            int retVal = 0;
            string sql = "UPDATE EF_multe SET [idstatuslavorazione] = @idstatuslavorazione, [filemanleva] = @filemanleva WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = Uid;
            collParams.Add(paramID);

            IDbDataParameter paramID2 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuslavorazione", DbType.Int32);
            paramID2.Value = idstatuslavorazione;
            collParams.Add(paramID2);

            IDbDataParameter paramID3 = _dataHelper.ProviderConn.CreateDataParameter("@filemanleva", DbType.String);
            paramID3.Value = filemanleva;
            collParams.Add(paramID3);

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

        //conta multe da pagare
        public int SelectCountMulteDaPagare(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, int idtitolarepagamento, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (m.numeroverbale like '%' + @keysearch + '%' or m.targa  like '%' + @keysearch + '%') ";
            if (idtipotrasmissione > 0) condWhere += " AND m.idtipotrasmissione = @idtipotrasmissione ";
            if (idstatuslavorazione > 0) condWhere += " AND m.idstatuslavorazione = @idstatuslavorazione ";
            if (idstatuspagamento > -1) condWhere += " AND m.idstatuspagamento = @idstatuspagamento ";
            if (idtitolarepagamento > 0) condWhere += " AND m.idtitolarepagamento = @idtitolarepagamento ";
            if (datadal > DateTime.MinValue) condWhere += " AND m.datanotifica >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND m.datanotifica <= @dataal";
            if (UserId != Guid.Empty) condWhere += " AND m.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codtipomulta)) condWhere += " AND m.codtipomulta = @codtipomulta ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_multe as m " +
                         " LEFT JOIN EF_multe_statuslavorazione as l ON m.idstatuslavorazione = l.idstatuslavorazione AND m.uidtenant = l.uidtenant " +
                         " LEFT JOIN EF_multe_tipotrasmissione as tt ON m.idtipotrasmissione = tt.idtipotrasmissione AND m.uidtenant = tt.uidtenant " +
                         " LEFT JOIN EF_multe_statuspagamento as p ON m.idstatuspagamento = p.idstatuspagamento AND m.uidtenant = p.uidtenant " +
                         " LEFT JOIN EF_multe_tipo as t ON m.codtipomulta = t.codtipomulta AND m.uidtenant = t.uidtenant " +
                         " LEFT JOIN EF_users as u ON m.UserId = u.UserId AND m.uidtenant = u.uidtenant " +
                         " WHERE m.idstatuslavorazione <> 60 AND m.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
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
            if (idtipotrasmissione > 0)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idtipotrasmissione", DbType.Int32);
                param4.Value = idtipotrasmissione;
                collParams.Add(param4);
            }
            if (idstatuslavorazione > 0)
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuslavorazione", DbType.Int32);
                param5.Value = idstatuslavorazione;
                collParams.Add(param5);
            }
            if (idstatuspagamento > -1)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuspagamento", DbType.Int32);
                param6.Value = idstatuspagamento;
                collParams.Add(param6);
            }
            if (!string.IsNullOrEmpty(codtipomulta))
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@codtipomulta", DbType.String);
                param7.Value = codtipomulta;
                collParams.Add(param7);
            }
            if (idtitolarepagamento > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idtitolarepagamento", DbType.Int32);
                param8.Value = idtitolarepagamento;
                collParams.Add(param8);
            }
            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista multe da pagare
        public List<IMulte> SelectMulteDaPagare(string keysearch, int idtipotrasmissione, int idstatuslavorazione, int idstatuspagamento, string codtipomulta, DateTime datadal, DateTime dataal, Guid UserId, int idtitolarepagamento, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " giornitrascorsi DESC ";
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (m.numeroverbale like '%' + @keysearch + '%' or m.targa  like '%' + @keysearch + '%') ";
            if (idtipotrasmissione > 0) condWhere += " AND m.idtipotrasmissione = @idtipotrasmissione ";
            if (idstatuslavorazione > 0) condWhere += " AND m.idstatuslavorazione = @idstatuslavorazione ";
            if (idstatuspagamento > -1) condWhere += " AND m.idstatuspagamento = @idstatuspagamento ";
            if (idtitolarepagamento > 0) condWhere += " AND m.idtitolarepagamento = @idtitolarepagamento ";
            if (datadal > DateTime.MinValue) condWhere += " AND m.datanotifica >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND m.datanotifica <= @dataal";
            if (UserId != Guid.Empty) condWhere += " AND m.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codtipomulta)) condWhere += " AND m.codtipomulta = @codtipomulta ";

            List<IMulte> retVal = new List<IMulte>();
            string sql = "SELECT m.*, l.statuslavorazione, tt.tipotrasmissione, p.statuspagamento, t.tipomulta, u.nome, u.cognome, tp.titolarepagamento, " +
                         " DATEDIFF(day, m.datanotifica, GETDATE()) as giornitrascorsi FROM EF_multe as m " +
                         " LEFT JOIN EF_multe_statuslavorazione as l ON m.idstatuslavorazione = l.idstatuslavorazione AND m.uidtenant = l.uidtenant " +
                         " LEFT JOIN EF_multe_tipotrasmissione as tt ON m.idtipotrasmissione = tt.idtipotrasmissione AND m.uidtenant = tt.uidtenant " +
                         " LEFT JOIN EF_multe_statuspagamento as p ON m.idstatuspagamento = p.idstatuspagamento AND m.uidtenant = p.uidtenant " +
                         " LEFT JOIN EF_multe_tipo as t ON m.codtipomulta = t.codtipomulta AND m.uidtenant = t.uidtenant " +
                         " LEFT JOIN EF_multe_titolarepagamento as tp ON m.idtitolarepagamento = tp.idtitolarepagamento AND m.uidtenant = tp.uidtenant " +
                         " LEFT JOIN EF_users as u ON m.UserId = u.UserId AND m.uidtenant = u.uidtenant " +
                         " WHERE m.idstatuslavorazione <> 60 AND m.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();


            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
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
            if (idtipotrasmissione > 0)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idtipotrasmissione", DbType.Int32);
                param4.Value = idtipotrasmissione;
                collParams.Add(param4);
            }
            if (idstatuslavorazione > 0)
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuslavorazione", DbType.Int32);
                param5.Value = idstatuslavorazione;
                collParams.Add(param5);
            }
            if (idstatuspagamento > -1)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuspagamento", DbType.Int32);
                param6.Value = idstatuspagamento;
                collParams.Add(param6);
            }
            if (!string.IsNullOrEmpty(codtipomulta))
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@codtipomulta", DbType.String);
                param7.Value = codtipomulta;
                collParams.Add(param7);
            }
            if (idtitolarepagamento > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idtitolarepagamento", DbType.Int32);
                param8.Value = idtitolarepagamento;
                collParams.Add(param8);
            }
            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IMulte item = new Multe
                    {
                        Protocollo = DataHelper.IfDBNull<string>(row["protocollo"], _stringEmpty),
                        Idtipotrasmissione = DataHelper.IfDBNull<int>(row["idtipotrasmissione"], 0),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                        Numeroverbale = DataHelper.IfDBNull<string>(row["numeroverbale"], _stringEmpty),
                        Datainfrazione = DataHelper.IfDBNull<DateTime>(row["datainfrazione"], DateTime.MinValue),
                        Datanotifica = DataHelper.IfDBNull<DateTime>(row["datanotifica"], DateTime.MinValue),
                        Orainfrazione = DataHelper.IfDBNull<string>(row["orainfrazione"], _stringEmpty),
                        Fileverbale = DataHelper.IfDBNull<string>(row["fileverbale"], _stringEmpty),
                        Filemanleva = DataHelper.IfDBNull<string>(row["filemanleva"], _stringEmpty),
                        Filericevutapagamento = DataHelper.IfDBNull<string>(row["filericevutapagamento"], _stringEmpty),
                        Ente = DataHelper.IfDBNull<string>(row["ente"], _stringEmpty),
                        Infrazione = DataHelper.IfDBNull<string>(row["infrazione"], _stringEmpty),
                        Punti = DataHelper.IfDBNull<int>(row["punti"], 0),
                        Importomulta = DataHelper.IfDBNull<decimal>(row["importomulta"], 0),
                        Importomultapagato = DataHelper.IfDBNull<decimal>(row["importomultapagato"], 0),
                        Importomultaridotto = DataHelper.IfDBNull<decimal>(row["importomultaridotto"], 0),
                        Importomultascontato = DataHelper.IfDBNull<decimal>(row["importomultascontato"], 0),
                        Ckemaildriver = DataHelper.IfDBNull<int>(row["ckemaildriver"], 0),
                        Idstatuslavorazione = DataHelper.IfDBNull<int>(row["idstatuslavorazione"], 0),
                        Idstatuspagamento = DataHelper.IfDBNull<int>(row["idstatuspagamento"], 0),
                        Tipotrasmissione = DataHelper.IfDBNull<string>(row["tipotrasmissione"], _stringEmpty),
                        Statuslavorazione = DataHelper.IfDBNull<string>(row["statuslavorazione"], _stringEmpty),
                        Statuspagamento = DataHelper.IfDBNull<string>(row["statuspagamento"], _stringEmpty),
                        Tipomulta = DataHelper.IfDBNull<string>(row["tipomulta"], _stringEmpty),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                        Giornitrascorsi = DataHelper.IfDBNull<int>(row["giornitrascorsi"], 0),
                        Titolarepagamento = DataHelper.IfDBNull<string>(row["titolarepagamento"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //pagamento multa DBS
        public int UpdateMultaPagata(IMulte value)
        {
            int retVal = 0;
            string sql = " UPDATE EF_multe SET [idstatuslavorazione] = @idstatuslavorazione, [idtitolarepagamento] = @idtitolarepagamento, [filericevutapagamento] = @filericevutapagamento, " +
                         " [idstatuspagamento] = @idstatuspagamento, [importomultapagato] = @importomultapagato, [datapagamento] = @datapagamento, " +
                         " [spesepagamento] = @spesepagamento, [codpagamento] = @codpagamento, [idcontopagamento] = @idcontopagamento WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuslavorazione", DbType.Int32);
            param6.Value = value.Idstatuslavorazione;
            collParams.Add(param6);

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = value.Uid;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@importomultapagato", DbType.Decimal);
            param1.Value = value.Importomultapagato;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@filericevutapagamento", DbType.String);
            param2.Value = value.Filericevutapagamento;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@datapagamento", DbType.DateTime);
            param3.Value = value.Datapagamento;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuspagamento", DbType.Int32);
            param4.Value = value.Idstatuspagamento;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@idtitolarepagamento", DbType.Int32);
            param5.Value = value.Idtitolarepagamento;
            collParams.Add(param5);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@spesepagamento", DbType.Decimal);
            param7.Value = value.Spesepagamento;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@codpagamento", DbType.String);
            param8.Value = value.Codpagamento;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@idcontopagamento", DbType.Int32);
            param9.Value = value.Idcontopagamento;
            collParams.Add(param9);

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
        public List<IMulte> SelectAllEnti(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND ente LIKE '%' + @keysearch + '%' ";

            List<IMulte> retVal = new List<IMulte>();

            string sql = "SELECT DISTINCT TOP 10 ente FROM EF_multe WHERE uidtenant = @Uidtenant " + condWhere + "  ORDER BY ente ";

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
                    IMulte item = new Multe
                    {
                        Ente = DataHelper.IfDBNull<string>(row["ente"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IMulte> SelectAllInfrazioni(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND infrazione LIKE '%' + @keysearch + '%' ";

            List<IMulte> retVal = new List<IMulte>();

            string sql = "SELECT DISTINCT TOP 10 infrazione FROM EF_multe WHERE uidtenant = @Uidtenant " + condWhere + "  ORDER BY infrazione ";

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
                    IMulte item = new Multe
                    {
                        Infrazione = DataHelper.IfDBNull<string>(row["infrazione"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IMulte> SelectAllTarghe(Guid Uidtenant)
        {
            List<IMulte> retVal = new List<IMulte>();

            string sql = "SELECT DISTINCT targa FROM EF_contratti WHERE uidtenant = @Uidtenant ORDER BY targa ";

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
                    IMulte item = new Multe
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IMulte> SelectAllTargheTerm(string keysearch, Guid Uidtenant)
        {
            List<IMulte> retVal = new List<IMulte>();

            string sql = "SELECT DISTINCT TOP 10 targa FROM EF_contratti WHERE uidtenant = @Uidtenant and targa LIKE '%' + @keysearch + '%' ORDER BY targa ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
            param0.Value = keysearch;
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
                    IMulte item = new Multe
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IMulte> SelectAllTargheExt(Guid Uidtenant)
        {
            List<IMulte> retVal = new List<IMulte>();

            string sql = "SELECT DISTINCT targa FROM EF_contratti WHERE uidtenant = @Uidtenant UNION SELECT DISTINCT targa FROM EF_contratti_autosostituive WHERE uidtenant = @Uidtenant ORDER BY targa ";

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
                    IMulte item = new Multe
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IMulte> SelectAllImporto(Guid Uid)
        {
            List<IMulte> retVal = new List<IMulte>();

            string sql = " SELECT 'importo intero' as tipomulta, importomulta as importo FROM EF_multe WHERE Uid = @Uid " +
                         " UNION SELECT 'importo ridotto' as tipomulta, importomultaridotto as importo FROM EF_multe WHERE  Uid = @Uid " +
                         " UNION SELECT 'importo scontato' as tipomulta, importomultascontato as importo FROM EF_multe WHERE Uid = @Uid ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);            

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IMulte item = new Multe
                    {
                        Tipomulta = DataHelper.IfDBNull<string>(row["tipomulta"], _stringEmpty) + " - € " + DataHelper.IfDBNull<decimal>(row["importo"], 0),
                        Importomulta = DataHelper.IfDBNull<decimal>(row["importo"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IMulte> SelectAllTitolarePagamento(Guid Uidtenant)
        {
            List<IMulte> retVal = new List<IMulte>();

            string sql = "SELECT idtitolarepagamento, titolarepagamento FROM EF_multe_titolarepagamento WHERE uidtenant = @Uidtenant ORDER BY titolarepagamento ";

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
                    IMulte item = new Multe
                    {
                        Idtitolarepagamento = DataHelper.IfDBNull<int>(row["idtitolarepagamento"], 0),
                        Titolarepagamento = DataHelper.IfDBNull<string>(row["titolarepagamento"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //inserimento cedloino
        public int InsertCedolino(IMulte value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_cedolini ([UserId],[datains],[idtipologiacedolino],[importo],[datauserins],[datausermod],[UserIDIns],[UserIdMod],[idmulta],[uidtenant]) " +
                         " VALUES (@UserId, @datains, @idtipologiacedolino, @importo, @datauserins, @datausermod, @UserIDIns, @UserIdMod, @idmulta, @uidtenant) ";


            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = value.UserId;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@datains", DbType.DateTime);
            param1.Value = value.Datains;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@idtipologiacedolino", DbType.Int32);
            param2.Value = value.Idtipologiacedolino;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@importo", DbType.Decimal);
            param3.Value = value.Importo;
            collParams.Add(param3);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param22.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param23.Value = DateTime.Now;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param24.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param24);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@idmulta", DbType.Int32);
            param25.Value = value.Idmulta;
            collParams.Add(param25);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param26.Value = value.Uidtenant;
            collParams.Add(param26);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }

        //aggiorna cedloino
        public int UpdateCedolino(IMulte value)
        {
            int retVal = 0;

            string sql = "UPDATE EF_cedolini SET [datains] = @datains, [importo] = @importo, [datausermod] = @datausermod, [UserIdMod] = @UserIdMod WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@datains", DbType.DateTime);
            param1.Value = value.Datains;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@importo", DbType.Decimal);
            param3.Value = value.Importo;
            collParams.Add(param3);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param23.Value = DateTime.Now;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param24.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param24);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param25.Value = value.Uid;
            collParams.Add(param25);

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

        public IMulte ExistCedolino(int idmulta, int idtipologiacedolino)
        {
            IMulte retVal = null;
            string sql = "SELECT Uid FROM EF_cedolini WHERE idmulta = @idmulta AND idtipologiacedolino = @idtipologiacedolino ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idmulta", DbType.Int32);
            param1.Value = idmulta;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@idtipologiacedolino", DbType.Int32);
            param3.Value = idtipologiacedolino;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Multe
                {
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }

        //conta cedolini - FILTRO: datadal, dataal,  UserId, idtipologiacedolino
        public int SelectCountCedolini(DateTime datadal, DateTime dataal, Guid UserId, int idtipologiacedolino)
        {
            string condWhere = "";
            if (datadal > DateTime.MinValue) condWhere += " AND c.datains >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND c.datains <= @dataal";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (idtipologiacedolino > 0) condWhere += " AND c.idtipologiacedolino = @idtipologiacedolino ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_cedolini as c " +
                         " LEFT JOIN EF_cedolini_tipologie as t ON c.idtipologiacedolino = t.idtipologiacedolino " +
                         " LEFT JOIN EF_users as u ON c.UserId = u.UserId " +
                         " WHERE c.idtipologiacedolino = 10 " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
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
            if (idtipologiacedolino > 0)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idtipologiacedolino", DbType.Int32);
                param4.Value = idtipologiacedolino;
                collParams.Add(param4);
            }

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista cedolini
        // FILTRO: datadal, dataal,  UserId, idtipologiacedolino
        public List<IMulte> SelectCedolini(DateTime datadal, DateTime dataal, Guid UserId, int idtipologiacedolino, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " c.datains DESC ";
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

            if (datadal > DateTime.MinValue) condWhere += " AND c.datains >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND c.datains <= @dataal";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (idtipologiacedolino > 0) condWhere += " AND c.idtipologiacedolino = @idtipologiacedolino ";

            List<IMulte> retVal = new List<IMulte>();
            string sql = "SELECT c.*, u.nome, u.cognome,t.tipologiacedolino FROM EF_cedolini as c " +
                         " LEFT JOIN EF_cedolini_tipologie as t ON c.idtipologiacedolino = t.idtipologiacedolino " +
                         " LEFT JOIN EF_users as u ON c.UserId = u.UserId " +
                         " WHERE c.idtipologiacedolino = 10 " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
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
            if (idtipologiacedolino > 0)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idtipologiacedolino", DbType.Int32);
                param4.Value = idtipologiacedolino;
                collParams.Add(param4);
            }

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IMulte item = new Multe
                    {
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                        Datains = DataHelper.IfDBNull<DateTime>(row["datains"], DateTime.MinValue),
                        Importo = DataHelper.IfDBNull<decimal>(row["importo"], 0),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Tipologiacedolino = DataHelper.IfDBNull<string>(row["tipologiacedolino"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IMulte> SelectAllTipologiaCedolini()
        {
            List<IMulte> retVal = new List<IMulte>();

            string sql = "SELECT idtipologiacedolino, tipologiacedolino FROM EF_cedolini_tipologie ORDER BY tipologiacedolino ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IMulte item = new Multe
                    {
                        Idtipologiacedolino = DataHelper.IfDBNull<int>(row["idtipologiacedolino"], 0),
                        Tipologiacedolino = DataHelper.IfDBNull<string>(row["tipologiacedolino"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        //conta addebiti driver - FILTRO: UserId, datadal, dataal
        public int SelectCountAddebiti(Guid UserId, DateTime datadal, DateTime dataal)
        {
            string condWhere = "";
            string condWhere2 = "";

            if (datadal > DateTime.MinValue)
            {
                condWhere += " AND c.datains >= @datadal";
            }
            if (dataal > DateTime.MinValue)
            {
                condWhere += " AND c.datains <= @dataal";
                condWhere2 += " AND ca.assegnatodal <= @dataal AND ca.assegnatoal >= @dataal";
            }

            string SQL = " SELECT COUNT(*) as tot FROM EF_cedolini as c " +
                         " LEFT JOIN EF_cedolini_tipologie as ct ON ct.idtipologiacedolino = c.idtipologiacedolino " +
                         " INNER JOIN EF_contratti as co ON c.UserId = co.UserId " +
                         " INNER JOIN EF_contratti_assegnazioni as ca ON ca.idcontratto = co.idcontratto " + condWhere2 +
                         " LEFT JOIN EF_carlist_auto as cr ON cr.codjatoauto = co.codjatoauto AND cr.codcarlist = co.codcarlist " +
                         " WHERE c.UserId = @UserId " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();
                        
            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = UserId;
            collParams.Add(param1);
            
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

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista addebiti utente
        // FILTRO: UserId, datadal, dataal
        public List<IMulte> SelectAddebiti(Guid UserId, DateTime datadal, DateTime dataal, int numrecord, int pagina)
        {
            string condWhere = "";
            string condWhere2 = "";
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

            if (datadal > DateTime.MinValue)
            {
                condWhere += " AND c.datains >= @datadal";
            }
            if (dataal > DateTime.MinValue)
            {
                condWhere += " AND c.datains <= @dataal";
                condWhere2 += " AND ca.assegnatodal <= @dataal AND ca.assegnatoal >= @dataal";
            }

            List<IMulte> retVal = new List<IMulte>();
            string sql = " SELECT c.datains, ct.tipologiacedolino, c.importo, ca.targa, cr.modello FROM EF_cedolini as c " +
                         " LEFT JOIN EF_cedolini_tipologie as ct ON ct.idtipologiacedolino = c.idtipologiacedolino " +
                         " INNER JOIN EF_contratti as co ON c.UserId = co.UserId " +
                         " INNER JOIN EF_contratti_assegnazioni as ca ON ca.idcontratto = co.idcontratto " + condWhere2 +
                         " LEFT JOIN EF_carlist_auto as cr ON cr.codjatoauto = co.codjatoauto AND cr.codcarlist = co.codcarlist " +
                         " WHERE c.UserId = @UserId " + condWhere + " ORDER BY c.datains DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();
                      
            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = UserId;
            collParams.Add(param1);
            
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

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IMulte item = new Multe
                    {
                        Datains = DataHelper.IfDBNull<DateTime>(row["datains"], DateTime.MinValue),
                        Tipologiacedolino = DataHelper.IfDBNull<string>(row["tipologiacedolino"], _stringEmpty),
                        Importo = DataHelper.IfDBNull<decimal>(row["importo"], 0),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        public int SelectCountMultePagate(string targa, Guid UserId, string mese, int anno, Guid Uidtenant)
        {
            string condWhere = "";
            string datainizioass;
            string datafineass;

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND m.targa = @targa ";
            if (UserId != Guid.Empty) condWhere += " AND m.UserId = @UserId ";
            if (!string.IsNullOrEmpty(mese) && anno > 0)
            {
                datainizioass = "01/" + mese + "/" + anno;
                datafineass = DateTime.DaysInMonth(anno, SeoHelper.IntString(mese)) + "/" + mese + "/" + anno;
                condWhere += " AND m.datapagamento >= @datainizioass and m.datapagamento <= @datafineass ";
            }
            else
            {
                datainizioass = "01/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                datafineass = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                condWhere += " AND m.datapagamento >= @datainizioass and m.datapagamento <= @datafineass ";
            }

            string SQL = " SELECT COUNT(tot) as tot2 FROM (SELECT COUNT(m.targa) AS tot, m.targa " +
                         " FROM EF_multe as m " +
                         " LEFT JOIN EF_users as u ON m.UserId = u.UserId AND m.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_societa as s ON m.codsocieta = s.codsocieta AND m.uidtenant = s.uidtenant " +
                         " WHERE m.idstatuspagamento = 100 and (m.idtitolarepagamento = 10 OR m.idtitolarepagamento = 200) and m.importomultapagato>0 AND m.uidtenant = @Uidtenant " + condWhere +
                         " GROUP BY m.targa, m.importomultapagato, u.nome, u.cognome, u.matricola, s.codcompany, s.societa, u.codicecdc, m.spesepagamento)c ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param2.Value = targa;
                collParams.Add(param2);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datainizioass", DbType.DateTime);
            param6.Value = datainizioass;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datafineass", DbType.DateTime);
            param7.Value = datafineass;
            collParams.Add(param7);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IMulte> SelectMultePagate(string targa, Guid UserId, string mese, int anno, Guid Uidtenant, int numrecord, int pagina)
        {
            string condWhere = "";
            string datainizioass;
            string datafineass;
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

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND m.targa = @targa ";
            if (UserId != Guid.Empty) condWhere += " AND m.UserId = @UserId ";
            if (!string.IsNullOrEmpty(mese) && anno > 0)
            {
                datainizioass = "01/" + mese + "/" + anno;
                datafineass = DateTime.DaysInMonth(anno, SeoHelper.IntString(mese)) + "/" + mese + "/" + anno;
                condWhere += " AND m.datapagamento >= @datainizioass and m.datapagamento <= @datafineass ";
            }
            else
            {
                datainizioass = "01/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                datafineass = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                condWhere += " AND m.datapagamento >= @datainizioass and m.datapagamento <= @datafineass ";
            }

            List<IMulte> retVal = new List<IMulte>();
            string sql = " SELECT m.targa, iif(m.idtitolarepagamento = 200, SUM(m.quotadriver), SUM(m.importomultapagato) ) as importomultapagato, " +
                         " u.nome, u.cognome, u.matricola, s.codcompany, s.societa, u.codicecdc, SUM(m.spesepagamento) as spesepagamento " +
                         " FROM EF_multe as m " +
                         " LEFT JOIN EF_users as u ON m.UserId = u.UserId AND m.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_societa as s ON m.codsocieta = s.codsocieta AND m.uidtenant = s.uidtenant " +
                         " WHERE m.idstatuspagamento = 100 and (m.idtitolarepagamento = 10 OR m.idtitolarepagamento = 200) and m.importomultapagato>0 AND m.uidtenant = @Uidtenant " + condWhere +
                         " GROUP BY m.targa, u.nome, u.cognome, u.matricola, s.codcompany, s.societa, u.codicecdc, m.idtitolarepagamento " +
                         " ORDER BY u.cognome, u.nome " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param2.Value = targa;
                collParams.Add(param2);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datainizioass", DbType.DateTime);
            param6.Value = datainizioass;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datafineass", DbType.DateTime);
            param7.Value = datafineass;
            collParams.Add(param7);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IMulte item = new Multe
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codcompany"], _stringEmpty),
                        Codicecdc = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Importomultapagato = DataHelper.IfDBNull<decimal>(row["importomultapagato"], 0),
                        Spesepagamento = DataHelper.IfDBNull<decimal>(row["spesepagamento"], 0),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IMulte> SelectAllContoPagamento(Guid Uidtenant)
        {
            List<IMulte> retVal = new List<IMulte>();

            string sql = "SELECT * FROM EF_multe_contopagamento WHERE uidtenant = @Uidtenant ORDER BY contopagamento ";

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
                    IMulte item = new Multe
                    {
                        Idcontopagamento = DataHelper.IfDBNull<int>(row["idcontopagamento"], 0),
                        Contopagamento = DataHelper.IfDBNull<string>(row["contopagamento"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public bool ExistVerbaleMulta(string numeroverbale, string targa)
        {
            bool retVal = false;
            string sql = "SELECT Uid FROM EF_multe WHERE numeroverbale = @numeroverbale AND targa = @targa ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@numeroverbale", DbType.String);
            param1.Value = numeroverbale;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param3.Value = targa;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public List<IMulte> SelectTargheAutoServTerm(string keysearch, Guid Uidtenant)
        {
            List<IMulte> retVal = new List<IMulte>();

            string sql = "SELECT DISTINCT TOP 10 targa FROM EF_contratti WHERE codtipoutilizzo = 'SER' AND uidtenant = @Uidtenant AND targa LIKE '%' + @keysearch + '%' ORDER BY targa ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
            param0.Value = keysearch;
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
                    IMulte item = new Multe
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IMulte> SelectTargheAutoServ(Guid Uidtenant)
        {
            List<IMulte> retVal = new List<IMulte>();

            string sql = " SELECT c.targa, cl.Modello, cl.Marca FROM EF_contratti as c " +
                         " LEFT JOIN EF_carlist_auto as cl ON c.codjatoauto = cl.codjatoauto " +
                         " WHERE c.codtipoutilizzo = 'SER' AND c.uidtenant = @Uidtenant ORDER BY targa ";

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
                    IMulte item = new Multe
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty) + " - " + DataHelper.IfDBNull<string>(row["marca"], _stringEmpty) + " - " + DataHelper.IfDBNull<string>(row["modello"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
    }
}