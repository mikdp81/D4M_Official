// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CAccountProvider.cs" company="">
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

    [SectionName("account.provider/AccountSection")]
    public class AccountProvider : DFleetDataProvider, IAccountProvider
    {

        //aggiorna user
        public int Update(IAccount value)
        {
            int retVal = 0;

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
                         " [codfornitore] = @codfornitore, [codicecdc2] = @codicecdc2, [codicecdc3] = @codicecdc3, [perccdc] = @perccdc, [perccdc2] = @perccdc2, [perccdc3] = @perccdc3 ";

            if (value.Dataassunzione > DateTime.MinValue)
            {
                sql += " ,[dataassunzione] = @dataassunzione ";
                IDbDataParameter param48 = _dataHelper.ProviderConn.CreateDataParameter("@dataassunzione", DbType.DateTime);
                param48.Value = value.Dataassunzione;
                collParams.Add(param48);
            }
            else
            {
                sql += " ,[dataassunzione] = NULL ";
            }


            if (value.Datanascita > DateTime.MinValue)
            {
                sql += " ,[datanascita] = @datanascita ";
                IDbDataParameter param49 = _dataHelper.ProviderConn.CreateDataParameter("@datanascita", DbType.DateTime);
                param49.Value = value.Datanascita;
                collParams.Add(param49);
            }
            else
            {
                sql += " ,[datanascita] = NULL ";
            }

            if (value.Dataemissione > DateTime.MinValue)
            {
                sql += " ,[dataemissione] = @dataemissione ";
                IDbDataParameter param50 = _dataHelper.ProviderConn.CreateDataParameter("@dataemissione", DbType.DateTime);
                param50.Value = value.Dataemissione;
                collParams.Add(param50);
            }
            else
            {
                sql += " ,[dataemissione] = NULL ";
            }

            if (value.Datascadenza > DateTime.MinValue)
            {
                sql += " ,[datascadenza] = @datascadenza ";
                IDbDataParameter param51 = _dataHelper.ProviderConn.CreateDataParameter("@datascadenza", DbType.DateTime);
                param51.Value = value.Datascadenza;
                collParams.Add(param51);
            }
            else
            {
                sql += " ,[datascadenza] = NULL ";
            }

            if (value.Datainiziovalidita > DateTime.MinValue)
            {
                sql += " ,[datainiziovalidita] = @datainiziovalidita ";
                IDbDataParameter param52 = _dataHelper.ProviderConn.CreateDataParameter("@datainiziovalidita", DbType.DateTime);
                param52.Value = value.Datainiziovalidita;
                collParams.Add(param52);
            }
            else
            {
                sql += " ,[datainiziovalidita] = NULL ";
            }

            if (value.Dataprevistadimissione > DateTime.MinValue)
            {
                sql += " ,[dataprevistadimissione] = @dataprevistadimissione ";
                IDbDataParameter param53 = _dataHelper.ProviderConn.CreateDataParameter("@dataprevistadimissione", DbType.DateTime);
                param53.Value = value.Dataprevistadimissione;
                collParams.Add(param53);
            }
            else
            {
                sql += " ,[dataprevistadimissione] = NULL ";
            }

            if (value.Datadimissioni > DateTime.MinValue)
            {
                sql += " ,[datadimissioni] = @datadimissioni ";
                IDbDataParameter param54 = _dataHelper.ProviderConn.CreateDataParameter("@datadimissioni", DbType.DateTime);
                param54.Value = value.Datadimissioni;
                collParams.Add(param54);
            }
            else
            {
                sql += " ,[datadimissioni] = NULL ";
            }

            sql += " WHERE UserId = @UserId AND uidtenant = @Uidtenant ";


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
            param7.Value = ProviderUserKey;

            ;
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

            IDbDataParameter param57 = _dataHelper.ProviderConn.CreateDataParameter("@codicecdc2", DbType.String);
            param57.Value = value.Codicecdc2;
            collParams.Add(param57);

            IDbDataParameter param58 = _dataHelper.ProviderConn.CreateDataParameter("@codicecdc3", DbType.String);
            param58.Value = value.Codicecdc3;
            collParams.Add(param58);

            IDbDataParameter param59 = _dataHelper.ProviderConn.CreateDataParameter("@perccdc", DbType.Int32);
            param59.Value = value.Perccdc;
            collParams.Add(param59);

            IDbDataParameter param60 = _dataHelper.ProviderConn.CreateDataParameter("@perccdc2", DbType.Int32);
            param60.Value = value.Perccdc2;
            collParams.Add(param60);

            IDbDataParameter param61 = _dataHelper.ProviderConn.CreateDataParameter("@perccdc3", DbType.Int32);
            param61.Value = value.Perccdc3;
            collParams.Add(param61);

            IDbDataParameter param62 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param62.Value = value.Uidtenant;
            collParams.Add(param62);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //cancella user

        public int Delete(IAccount value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_users WHERE UserId = @UserId AND uidtenant = @Uidtenant ";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            paramID.Value = value.UserId;
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

        //inserimento nuovo user

        public int Insert(IAccount value)
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
                         " [indirizzosede],[cittasede],[provinciasede],[capsede],[codicedivisione],[descrizionedivisione],[fasciaimportazione],[annotazioni],[codfornitore], " +
                         " [codicecdc2], [codicecdc3], [perccdc], [perccdc2], [perccdc3],[uidtenant] " + sqlfield + " ) " +
                         " VALUES (@UserId,@idgruppouser,@idstatususer,@flgadmin,@flgdriver,@datauserins,@datausermod,@UserIDIns,@UserIdMod,@codsocieta,@cognome,@nome, " +
                         " @matricola,@idnumber,@idtipodriver,@funzione,@maternita,@cellulare,@email,@codicecdc,@descrizionecdc,@fasciacarpolicy,@codicesede,@descrizionesede, " +
                         " @luogonascita,@provincianascita,@codicefiscale,@indirizzoresidenza,@localitaresidenza,@provinciaresidenza,@capresidenza,@nrpatente,@ufficioemittente, " +
                         " @matricolaapprovatore,@codicesocietaapprovatore,@codicesettore,@descrizionesettore,@descrizioneapprovatore,@emailapprovatore,@gradecode,@persontype, " +
                         " @indirizzosede,@cittasede,@provinciasede,@capsede,@codicedivisione,@descrizionedivisione,@fasciaimportazione,@annotazioni,@codfornitore, " +
                         " @codicecdc2,@codicecdc3,@perccdc,@perccdc2,@perccdc3,@uidtenant " + sqlvalue + " ) ";


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
            param6.Value = ProviderUserKey;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param7.Value = ProviderUserKey;
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

            IDbDataParameter param57 = _dataHelper.ProviderConn.CreateDataParameter("@codicecdc2", DbType.String);
            param57.Value = value.Codicecdc2;
            collParams.Add(param57);

            IDbDataParameter param58 = _dataHelper.ProviderConn.CreateDataParameter("@codicecdc3", DbType.String);
            param58.Value = value.Codicecdc3;
            collParams.Add(param58);

            IDbDataParameter param59 = _dataHelper.ProviderConn.CreateDataParameter("@perccdc", DbType.Int32);
            param59.Value = value.Perccdc;
            collParams.Add(param59);

            IDbDataParameter param60 = _dataHelper.ProviderConn.CreateDataParameter("@perccdc2", DbType.Int32);
            param60.Value = value.Perccdc2;
            collParams.Add(param60);

            IDbDataParameter param61 = _dataHelper.ProviderConn.CreateDataParameter("@perccdc3", DbType.Int32);
            param61.Value = value.Perccdc3;
            collParams.Add(param61);

            IDbDataParameter param62 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param62.Value = value.Uidtenant;
            collParams.Add(param62);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }

        public IAccount GetAccountFromFormIdentity()
        {
            FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
            return Detail(identity.Name);
        }



        //esistenza email

        public bool ExistUser(string email)
        {
            bool retVal = false;
            string sql = "SELECT email FROM EF_users WHERE email = @email";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@email", DbType.String);
            param0.Value = email;
            collParams.Add(param0);
            string data = _dataHelper.GetValue<string>(sql, collParams).Data;
            if (!string.IsNullOrEmpty(data))
            {
                retVal = true;
            }

            return retVal;
        }

        public bool ExistUserStatus(string email)
        {
            bool retVal = false;
            string sql = "SELECT email FROM EF_users WHERE email = @email and idstatususer = 0 ";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@email", DbType.String);
            param0.Value = email;
            collParams.Add(param0);
            string data = _dataHelper.GetValue<string>(sql, collParams).Data;
            if (!string.IsNullOrEmpty(data))
            {
                retVal = true;
            }

            return retVal;
        }
        //dettagli email

        public IAccount Detail(string email)
        {
            IAccount retVal = null;
            string sql = "SELECT * FROM EF_users WHERE email = @email";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@email", DbType.String);
            param0.Value = email;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Idgruppouser = DataHelper.IfDBNull<int>(row["idgruppouser"], 0),
                    Idstatususer = DataHelper.IfDBNull<int>(row["idstatususer"], 0),
                    Flgadmin = DataHelper.IfDBNull<int>(row["flgadmin"], 0),
                    Flgdriver = DataHelper.IfDBNull<int>(row["flgdriver"], 0),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
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
                    Persontype = DataHelper.IfDBNull<string>(row["persontype"], _stringEmpty),
                    Indirizzosede = DataHelper.IfDBNull<string>(row["indirizzosede"], _stringEmpty),
                    Cittasede = DataHelper.IfDBNull<string>(row["cittasede"], _stringEmpty),
                    Provinciasede = DataHelper.IfDBNull<string>(row["provinciasede"], _stringEmpty),
                    Capsede = DataHelper.IfDBNull<string>(row["capsede"], _stringEmpty),
                    Codicedivisione = DataHelper.IfDBNull<string>(row["codicedivisione"], _stringEmpty),
                    Descrizionedivisione = DataHelper.IfDBNull<string>(row["descrizionedivisione"], _stringEmpty),
                    Fasciaimportazione = DataHelper.IfDBNull<string>(row["fasciaimportazione"], _stringEmpty),
                    Annotazioni = DataHelper.IfDBNull<string>(row["annotazioni"], _stringEmpty),
                    Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }

        //dettagli iduser

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
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Idgruppouser = DataHelper.IfDBNull<int>(row["idgruppouser"], 0),
                    Idstatususer = DataHelper.IfDBNull<int>(row["idstatususer"], 0),
                    Flgadmin = DataHelper.IfDBNull<int>(row["flgadmin"], 0),
                    Flgdriver = DataHelper.IfDBNull<int>(row["flgdriver"], 0),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
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
                    ClientId = DataHelper.IfDBNull<string>(row["ClientId"], _stringEmpty),
                    ImpersonatedUserId = DataHelper.IfDBNull<string>(row["ImpersonatedUserId"], _stringEmpty),
                    AuthServer = DataHelper.IfDBNull<string>(row["AuthServer"], _stringEmpty),
                    PrivateKey = DataHelper.IfDBNull<string>(row["PrivateKey"], _stringEmpty),
                    BasePath = DataHelper.IfDBNull<string>(row["BasePath"], _stringEmpty),
                    AccountId = DataHelper.IfDBNull<string>(row["AccountId"], _stringEmpty),
                    PingUrl = DataHelper.IfDBNull<string>(row["PingUrl"], _stringEmpty),
                    SignerEmail = DataHelper.IfDBNull<string>(row["SignerEmail"], _stringEmpty),
                    SignerName = DataHelper.IfDBNull<string>(row["SignerName"], _stringEmpty),
                    SignerClientId = DataHelper.IfDBNull<string>(row["SignerClientId"], _stringEmpty),
                    Uidtenant = DataHelper.IfDBNull<Guid>(row["uidtenant"], Guid.Empty),
                };

                data.Dispose();
            }
            return retVal;
        }


        //gruppo iduser

        public IAccount DetailGruppoUserId(Guid UserId)
        {
            IAccount retVal = null;
            string sql = "SELECT EF_gruppi.gruppouser FROM EF_users INNER JOIN EF_gruppi ON EF_users.idgruppouser = EF_gruppi.idgruppouser WHERE UserId = @UserId";
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
                    Gruppouser = DataHelper.IfDBNull<string>(row["gruppouser"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IAccount DetailId2(int iduser)
        {
            IAccount retVal = null;
            string sql = "SELECT UserId FROM EF_users WHERE iduser = @iduser";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@iduser", DbType.Int32);
            param0.Value = iduser;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }



        public int SelectCountUsername(string userName, int idstatususer, int idgruppouser, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(userName)) condWhere += " and (nome like '%' + @userName + '%' or cognome like '%' + @userName + '%' or email  like '%' + @userName + '%'  or matricola like '%' + @userName + '%') ";
            if (idstatususer > -1) condWhere += " and u.idstatususer = @idstatususer ";
            if (idgruppouser > 0) condWhere += " and u.idgruppouser = @idgruppouser ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_users as u " +
                         " LEFT JOIN EF_userstatus as us ON u.idstatususer = us.idstatususer AND u.uidtenant = us.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = u.codsocieta AND u.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_grade as gr ON gr.codgrade = u.gradecode AND u.uidtenant = gr.uidtenant " +
                         " LEFT JOIN EF_gruppi as g ON g.idgruppouser = u.idgruppouser AND u.uidtenant = g.uidtenant " +
                         " WHERE u.iduser > 0 AND u.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(userName))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Username", DbType.String);
                param0.Value = userName;
                collParams.Add(param0);
            }

            if (idstatususer > -1)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatususer", DbType.Int32);
                param1.Value = idstatususer;
                collParams.Add(param1);
            }

            if (idgruppouser > 0)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@idgruppouser", DbType.Int32);
                param2.Value = idgruppouser;
                collParams.Add(param2);
            }

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public List<IAccount> SelectUsername(string userName, int idstatususer, int idgruppouser, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " cognome ";
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

            if (!string.IsNullOrEmpty(userName)) condWhere += " and (nome like '%' + @userName + '%' or cognome like '%' + @userName + '%' or email  like '%' + @userName + '%'  or matricola like '%' + @userName + '%') ";
            if (idstatususer > -1) condWhere += " and u.idstatususer = @idstatususer ";
            if (idgruppouser > 0) condWhere += " and u.idgruppouser = @idgruppouser ";

            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT u.cognome, u.nome, u.UserId, s.siglasocieta, gr.grade, us.statusutente, g.gruppouser, u.matricola FROM EF_users as u " +
                         " LEFT JOIN EF_userstatus as us ON u.idstatususer = us.idstatususer AND u.uidtenant = us.uidtenant " +
                         " LEFT JOIN EF_gruppi as g ON g.idgruppouser = u.idgruppouser AND u.uidtenant = g.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = u.codsocieta AND u.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_grade as gr ON gr.codgrade = u.gradecode AND u.uidtenant = gr.uidtenant " +
                         " WHERE u.iduser > 0 AND u.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(userName))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Username", DbType.String);
                param0.Value = userName;
                collParams.Add(param0);
            }

            if (idstatususer > -1)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatususer", DbType.Int32);
                param1.Value = idstatususer;
                collParams.Add(param1);
            }

            if (idgruppouser > 0)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@idgruppouser", DbType.Int32);
                param2.Value = idgruppouser;
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
                    IAccount item = new Account
                    {
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Gradecode = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Statusutente = DataHelper.IfDBNull<string>(row["statusutente"], _stringEmpty),
                        Gruppouser = DataHelper.IfDBNull<string>(row["gruppouser"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IAccount> SelectUsers(Guid Uidtenant)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT * FROM EF_users as u " +
                         " LEFT JOIN EF_userstatus as s ON u.idstatususer = s.idstatususer AND u.uidtenant = s.uidtenant " +
                         " WHERE u.uidtenant = @Uidtenant ORDER BY u.cognome, u.nome ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                        Idstatususer = DataHelper.IfDBNull<int>(row["idstatususer"], 0),
                        Statusutente = DataHelper.IfDBNull<string>(row["statusutente"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IAccount> SelectUsersXSocieta(string codsocieta, Guid Uidtenant)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT * FROM EF_users as u " +
                         " LEFT JOIN EF_userstatus as s ON u.idstatususer = s.idstatususer AND u.uidtenant = s.uidtenant " +
                         " WHERE codsocieta = @codsocieta AND u.uidtenant = @Uidtenant ORDER BY u.cognome, u.nome ";

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
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                        Idstatususer = DataHelper.IfDBNull<int>(row["idstatususer"], 0),
                        Statusutente = DataHelper.IfDBNull<string>(row["statusutente"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IAccount> SelectUsersTerm(string keysearch, Guid Uidtenant)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT TOP 10 * FROM EF_users WHERE uidtenant = @Uidtenant AND (cognome LIKE '%' + @keysearch + '%' OR nome LIKE '%' + @keysearch + '%' OR matricola LIKE '%' + @keysearch + '%' " +
                         " OR CONCAT(cognome,' ' ,nome) LIKE '%' + @keysearch + '%' OR CONCAT(nome,' ' ,cognome) LIKE '%' + @keysearch + '%' ) ORDER BY cognome, nome ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
            param0.Value = keysearch;
            collParams.Add(param0);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IAccount> SelectUsersSearch()
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT * FROM EF_users ORDER BY cognome, nome ";

            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IAccount> SelectUsersEmail(Guid Uidtenant)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT * FROM EF_users WHERE uidtenant = @Uidtenant ORDER BY cognome, nome ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["email"], _stringEmpty) + ")",
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //elenco status

        public List<IAccount> SelectStatus(Guid Uidtenant)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT * FROM EF_userstatus WHERE uidtenant = @Uidtenant ORDER BY idstatususer ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Idstatususer = DataHelper.IfDBNull<int>(row["idstatususer"], 0),
                        Statusutente = DataHelper.IfDBNull<string>(row["statusutente"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //ricerca ultimo iduser

        public IAccount UltimoIDUser()
        {
            IAccount retVal = null;
            string sql = "SELECT TOP 1 iduser FROM EF_users ORDER BY iduser DESC";
            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }


        //elenco gruppi
        public List<IAccount> SelectGruppi(Guid Uidtenant)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT * FROM EF_gruppi WHERE uidtenant = @Uidtenant ORDER BY gruppouser ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Idgruppouser = DataHelper.IfDBNull<int>(row["idgruppouser"], 0),
                        Gruppouser = DataHelper.IfDBNull<string>(row["gruppouser"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        //aggiorna team
        public int UpdateTeam(IAccount value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_team SET [team] = @team, [stato] = @stato, [datausermod] = @datausermod, [UserIdMod] = @UserIdMod WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = value.Uid;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@team", DbType.String);
            param1.Value = value.Team;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@stato", DbType.String);
            param2.Value = value.Stato;
            collParams.Add(param2);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param7.Value = ProviderUserKey;
            collParams.Add(param7);

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


        //inserimento nuovo team

        public int InsertTeam(IAccount value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_team ([team],[stato],[datauserins],[datausermod],[UserIDIns],[UserIdMod],[uidtenant]) " +
                         " VALUES (@team,@stato,@datauserins,@datausermod,@UserIDIns,@UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@team", DbType.String);
            param1.Value = value.Team;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@stato", DbType.String);
            param2.Value = value.Stato;
            collParams.Add(param2);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param4.Value = DateTime.Now;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param6.Value = ProviderUserKey;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param7.Value = ProviderUserKey;
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
        public int SelectCountTeam(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND team like '%' + @keysearch + '%' ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_team WHERE idteam > 0 AND uidtenant = @Uidtenant " + condWhere;

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

        public List<IAccount> SelectTeam(string keysearch, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND team like '%' + @keysearch + '%' ";

            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT * FROM EF_team WHERE idteam > 0 AND uidtenant = @Uidtenant " + condWhere + " ORDER BY team " + paginazione;

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
                    IAccount item = new Account
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

        //dettagli team

        public IAccount DetailTeamId(Guid Uid)
        {
            IAccount retVal = null;
            string sql = "SELECT * FROM EF_team WHERE Uid = @Uid";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
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
        public IAccount DetailTeamXId(int idteam)
        {
            IAccount retVal = null;
            string sql = "SELECT autorizzatore FROM EF_team WHERE idteam = @idteam";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idteam", DbType.Int32);
            param0.Value = idteam;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    Autorizzatore = DataHelper.IfDBNull<int>(row["autorizzatore"], 0)
                };

                data.Dispose();
            }
            return retVal;
        }

        //ricerca ultimo idteam
        public IAccount UltimoIDTeam()
        {
            IAccount retVal = null;
            string sql = "SELECT TOP 1 idteam FROM EF_team ORDER BY idteam DESC";
            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    Idteam = DataHelper.IfDBNull<int>(row["idteam"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }


        //inserimento nuovo user team
        public int InsertUserTeam(IAccount value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_users_team ([idteam],[iduser],[uidtenant]) VALUES (@idteam,@iduser,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idteam", DbType.Int32);
            param1.Value = value.Idteam;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@iduser", DbType.Int32);
            param2.Value = value.Iduser;
            collParams.Add(param2);

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

        //inserimento nuovo menu team
        public int InsertPageTeam(IAccount value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_team_menu ([idteam],[idpagina],[uidtenant]) VALUES (@idteam,@idpagina,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idteam", DbType.Int32);
            param1.Value = value.Idteam;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@idpagina", DbType.Int32);
            param2.Value = value.Idpagina;
            collParams.Add(param2);

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

        //cancella user team
        public int DeleteUserTeam(IAccount value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_users_team WHERE idteam = @idteam AND uidtenant = @Uidtenant ";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@idteam", DbType.Int32);
            paramID.Value = value.Idteam;
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

        //cancella menu team
        public int DeletePageTeam(IAccount value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_team_menu WHERE idteam = @idteam AND uidtenant = @Uidtenant ";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@idteam", DbType.Int32);
            paramID.Value = value.Idteam;
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

        //seleziona user team
        public List<IAccount> SelectUserTeam(int idteam)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT iduser FROM EF_users_team WHERE idteam = @idteam ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idteam", DbType.Int32);
            param0.Value = idteam;
            collParams.Add(param0);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //seleziona pagine team
        public List<IAccount> SelectPageTeam(int idteam)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT idpagina FROM EF_team_menu WHERE idteam = @idteam ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idteam", DbType.Int32);
            param0.Value = idteam;
            collParams.Add(param0);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Idpagina = DataHelper.IfDBNull<int>(row["idpagina"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public IAccount ReturnIdteam(Guid UserId, Guid Uidtenant)
        {
            IAccount retVal = null;
            string sql = " SELECT TOP 1 t.team, t.idteam FROM EF_team as t " +
                         " INNER JOIN EF_users_team as ut ON ut.idteam = t.idteam AND ut.uidtenant = t.uidtenant " +
                         " INNER JOIN EF_users as u ON u.iduser = ut.iduser " +
                         " WHERE u.UserId = @UserId and t.uidtenant = @Uidtenant " +
                         " ORDER BY t.idteam ";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    Idteam = DataHelper.IfDBNull<int>(row["idteam"], 0),
                    Team = DataHelper.IfDBNull<string>(row["team"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }

        //seleziona gruppi menu utente
        public List<IAccount> SelectGroupPageTeam(int idteam, Guid UserId)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT DISTINCT pg.gruppo, pg.codgruppopagina, pg.icona, pg.ordine FROM EF_pagine as p  " +
                         " INNER JOIN EF_pagine_gruppi as pg ON pg.codgruppopagina = p.codgruppopagina " +
                         " INNER JOIN EF_team_menu as m ON p.idpagina = m.idpagina " +
                         " INNER JOIN EF_users_team as ut ON ut.idteam = m.idteam " +
                         " INNER JOIN EF_users as u ON u.iduser = ut.iduser " +
                         " WHERE u.UserId = @UserId and ut.idteam = @idteam " +
                         " GROUP BY pg.gruppo, pg.codgruppopagina, pg.icona, pg.ordine " +
                         " ORDER BY pg.ordine ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idteam", DbType.Int32);
            param0.Value = idteam;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = UserId;
            collParams.Add(param1);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Gruppo = DataHelper.IfDBNull<string>(row["gruppo"], _stringEmpty),
                        Codgruppopagina = DataHelper.IfDBNull<string>(row["codgruppopagina"], _stringEmpty),
                        Icona = DataHelper.IfDBNull<string>(row["icona"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //seleziona pagine menu utente
        public List<IAccount> SelectPageTeam(int idteam, Guid UserId, string codgruppopagina)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT DISTINCT p.pagina, p.linkpagina, p.ordine FROM EF_pagine as p " +
                         " INNER JOIN EF_team_menu as m ON p.idpagina = m.idpagina " +
                         " INNER JOIN EF_users_team as ut ON ut.idteam = m.idteam " +
                         " INNER JOIN EF_users as u ON u.iduser = ut.iduser " +
                         " WHERE u.UserId  = @UserId and ut.idteam = @idteam and p.codgruppopagina = @codgruppopagina " +
                         " GROUP BY p.pagina, p.linkpagina, p.ordine " +
                         " ORDER BY p.ordine ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idteam", DbType.Int32);
            param0.Value = idteam;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = UserId;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codgruppopagina", DbType.String);
            param2.Value = codgruppopagina;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Pagina = DataHelper.IfDBNull<string>(row["pagina"], _stringEmpty),
                        Linkpagina = DataHelper.IfDBNull<string>(row["linkpagina"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        //seleziona tutti i team dell'utente
        public List<IAccount> SelectTeamUser(Guid UserId, Guid Uidtenant)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT t.team, t.idteam FROM EF_team as t " +
                         " INNER JOIN EF_users_team as ut ON ut.idteam = t.idteam AND ut.uidtenant = t.uidtenant " +
                         " INNER JOIN EF_users as u ON u.iduser = ut.iduser " +
                         " WHERE u.UserId = @UserId and t.uidtenant = @Uidtenant " +
                         " ORDER BY t.idteam ";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
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
                    IAccount item = new Account
                    {
                        Idteam = DataHelper.IfDBNull<int>(row["idteam"], 0),
                        Team = DataHelper.IfDBNull<string>(row["team"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //esistenza pagina per controlli autoriuzzazioni utente
        public bool ExistPageUser(Guid UserId, int idteam, int idpagina)
        {
            bool retVal = false;
            string sql = " SELECT p.idpagina FROM EF_pagine as p " +
                         " INNER JOIN EF_team_menu as m ON p.idpagina = m.idpagina " +
                         " INNER JOIN EF_users_team as ut ON ut.idteam = m.idteam " +
                         " INNER JOIN EF_users as u ON u.iduser = ut.iduser " +
                         " WHERE u.UserId = @UserId and ut.idteam = @idteam and p.idpagina = @idpagina ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idteam", DbType.Int32);
            param1.Value = idteam;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@idpagina", DbType.Int32);
            param2.Value = idpagina;
            collParams.Add(param2);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }


        //inserimento nuova segnalazione
        public int InsertSegnalazione(IAccount value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_users_segnalazioni ([segnalazione],[UserId]) VALUES (@segnalazione,@UserId) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@segnalazione", DbType.String);
            param1.Value = value.Segnalazione;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param2.Value = ProviderUserKey;
            collParams.Add(param2);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        public int SelectCountSegnalazioni(Guid UserId, Guid Uidtenant)
        {
            string condWhere = "";
            if (UserId != Guid.Empty) condWhere += " AND s.UserId = @UserId ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_users_segnalazioni as s " +
                         " LEFT JOIN EF_users as u ON s.UserId = u.UserId AND s.uidtenant = u.uidtenant " +
                         " WHERE s.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param0.Value = UserId;
                collParams.Add(param0);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public List<IAccount> SelectSegnalazioni(Guid UserId, Guid Uidtenant, int numrecord, int pagina)
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

            if (UserId != Guid.Empty) condWhere += " AND s.UserId = @UserId ";

            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT s.segnalazione, u.nome, u.cognome, u.matricola, s.Uid FROM EF_users_segnalazioni as s " +
                         " LEFT JOIN EF_users as u ON s.UserId = u.UserId AND s.uidtenant = u.uidtenant " +
                         " WHERE s.uidtenant = @Uidtenant " + condWhere + " ORDER BY s.idsegnalazione DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param0.Value = UserId;
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
                    IAccount item = new Account
                    {
                        Segnalazione = DataHelper.IfDBNull<string>(row["segnalazione"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IAccount> SelectFuelCardXUser(Guid UserId)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT f.targa, f.numero, f.scadenza, f.pin, c.compagnia, f.Uid, f.statuscard, IIF(ca.assegnatoal >= GETDATE(), 'INCORSO', 'STORICO') as status FROM EF_users_fuelcard as f " +
                         " LEFT JOIN EF_contratti_assegnazioni as ca ON ca.targa = f.targa " +
                         " LEFT JOIN EF_compagnie as c ON c.idcompagnia = f.idcompagnia " +
                         " WHERE ca.UserID = @UserId AND f.targa IN (SELECT targa FROM EF_contratti_assegnazioni WHERE UserId = @UserId) ORDER BY f.statuscard, f.scadenza DESC ";
            //AND f.dataattivazione <= (SELECT ca.assegnatodal FROM EF_contratti_assegnazioni as ca WHERE ca.UserId = 'DF72AAB1-BD30-45A0-B837-EED608028A7C' and ca.targa = f.targa)

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
                    IAccount item = new Account
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Numero = DataHelper.IfDBNull<string>(row["numero"], _stringEmpty),
                        Pin = DataHelper.IfDBNull<string>(row["pin"], _stringEmpty),
                        Compagnia = DataHelper.IfDBNull<string>(row["compagnia"], _stringEmpty),
                        Scadenza = DataHelper.IfDBNull<DateTime>(row["scadenza"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                        Stato = DataHelper.IfDBNull<string>(row["statuscard"], _stringEmpty),
                        Statusutente = DataHelper.IfDBNull<string>(row["status"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //aggiorna fuel card users
        public int UpdateFuelCardUser(IAccount value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users_fuelcard SET [idcompagnia] = @idcompagnia, [targa] = @targa, [numero] = @numero, [scadenza] = @scadenza, [pin] = @pin, " +
                         " [datausermod] = @datausermod, [UserIdMod] = @UserIdMod, [statuscard] = @statuscard, [dataattivazione] = @dataattivazione, [codsocieta] = @codsocieta " +
                         " WHERE Uid = @Uid AND uidtenant = @Uidtenant ";


            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = value.Uid;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
            param1.Value = value.Idcompagnia;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param3.Value = value.Targa;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@numero", DbType.String);
            param4.Value = value.Numero;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@scadenza", DbType.DateTime);
            param5.Value = value.Scadenza;
            collParams.Add(param5);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@pin", DbType.String);
            param10.Value = value.Pin;
            collParams.Add(param10);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param7.Value = ProviderUserKey;
            collParams.Add(param7);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@dataattivazione", DbType.DateTime);
            param11.Value = value.Dataattivazione;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@statuscard", DbType.String);
            param12.Value = value.Stato;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param13.Value = value.Codsocieta;
            collParams.Add(param13);

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


        //inserimento nuovo fuel card users

        public int InsertFuelCardUser(IAccount value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_users_fuelcard ([idcompagnia],[targa],[numero],[scadenza],[pin],[datauserins],[datausermod],[UserIDIns],[UserIdMod],[statuscard],[dataattivazione],[codsocieta],[uidtenant]) " +
                         " VALUES (@idcompagnia,@targa,@numero,@scadenza,@pin,@datauserins,@datausermod,@UserIDIns,@UserIdMod,@statuscard,@dataattivazione,@codsocieta,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
            param1.Value = value.Idcompagnia;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param3.Value = value.Targa;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@numero", DbType.String);
            param4.Value = value.Numero;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@scadenza", DbType.DateTime);
            param5.Value = value.Scadenza;
            collParams.Add(param5);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@pin", DbType.String);
            param10.Value = value.Pin;
            collParams.Add(param10);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param7.Value = DateTime.Now;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param8.Value = ProviderUserKey;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param9.Value = ProviderUserKey;
            collParams.Add(param9);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@dataattivazione", DbType.DateTime);
            param11.Value = value.Dataattivazione;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@statuscard", DbType.String);
            param12.Value = value.Stato;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param13.Value = value.Codsocieta;
            collParams.Add(param13);

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
        public int SelectCountFuelCardUser(string codsocieta, string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (f.targa  like '%' + @keysearch + '%' or f.numero  like '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";
            if (scadenzada > DateTime.MinValue) condWhere += " AND f.scadenza >= @scadenzada";
            if (scadenzaa > DateTime.MinValue) condWhere += " AND f.scadenza <= @scadenzaa";
            if (idcompagnia > 0) condWhere += " AND f.idcompagnia = @idcompagnia";
            if (!string.IsNullOrEmpty(status)) condWhere += " AND statuscard = @status ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND f.codsocieta = @codsocieta ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_users_fuelcard as f " +
                         " LEFT JOIN EF_compagnie as c ON c.idcompagnia = f.idcompagnia AND f.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni as ca ON ca.targa = f.targa AND f.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = f.codsocieta AND f.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_users as u ON ca.UserId = u.UserId AND u.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND u.uidtenant = g.uidtenant " +
                         " WHERE f.iduserfuel > 0 AND f.uidtenant = @Uidtenant " + condWhere;

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
            if (scadenzada > DateTime.MinValue)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzada", DbType.DateTime);
                param2.Value = scadenzada;
                collParams.Add(param2);
            }
            if (scadenzaa > DateTime.MinValue)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzaa", DbType.DateTime);
                param3.Value = scadenzaa;
                collParams.Add(param3);
            }
            if (idcompagnia > 0)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
                param4.Value = idcompagnia;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(status))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@status", DbType.String);
                param5.Value = status;
                collParams.Add(param5);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param6.Value = codsocieta;
                collParams.Add(param6);
            }

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param7.Value = Uidtenant;
            collParams.Add(param7);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public List<IAccount> SelectFuelCardUser(string codsocieta, string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (f.targa  like '%' + @keysearch + '%' or f.numero  like '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";
            if (scadenzada > DateTime.MinValue) condWhere += " AND f.scadenza >= @scadenzada";
            if (scadenzaa > DateTime.MinValue) condWhere += " AND f.scadenza <= @scadenzaa";
            if (idcompagnia > 0) condWhere += " AND f.idcompagnia = @idcompagnia";
            if (!string.IsNullOrEmpty(status)) condWhere += " AND statuscard = @status ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND f.codsocieta = @codsocieta ";

            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT u.nome, u.cognome, u.matricola, f.Uid, f.scadenza, f.targa, f.numero, c.compagnia, f.statuscard, " +
                         " s.siglasocieta, g.grade, f.dataattivazione, ca.assegnatodal, ca.assegnatoal FROM EF_users_fuelcard as f " +
                         " LEFT JOIN EF_compagnie as c ON c.idcompagnia = f.idcompagnia AND f.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni as ca ON ca.targa = f.targa AND f.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = f.codsocieta AND f.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_users as u ON ca.UserId = u.UserId AND u.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND u.uidtenant = g.uidtenant" +
                         " WHERE f.iduserfuel > 0 AND f.uidtenant = @Uidtenant " + condWhere + " ORDER BY f.scadenza DESC, u.cognome " + paginazione;

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
            if (scadenzada > DateTime.MinValue)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzada", DbType.DateTime);
                param2.Value = scadenzada;
                collParams.Add(param2);
            }
            if (scadenzaa > DateTime.MinValue)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzaa", DbType.DateTime);
                param3.Value = scadenzaa;
                collParams.Add(param3);
            }
            if (idcompagnia > 0)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
                param4.Value = idcompagnia;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(status))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@status", DbType.String);
                param5.Value = status;
                collParams.Add(param5);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param6.Value = codsocieta;
                collParams.Add(param6);
            }

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param7.Value = Uidtenant;
            collParams.Add(param7);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Scadenza = DataHelper.IfDBNull<DateTime>(row["scadenza"], DateTime.MinValue),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Numero = DataHelper.IfDBNull<string>(row["numero"], _stringEmpty),
                        Compagnia = DataHelper.IfDBNull<string>(row["compagnia"], _stringEmpty),
                        Stato = DataHelper.IfDBNull<string>(row["statuscard"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Gradecode = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Dataattivazione = DataHelper.IfDBNull<DateTime>(row["dataattivazione"], DateTime.MinValue),
                        Datainiziovalidita = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Datascadenza = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IAccount DetailFuelCardUserId(Guid Uid)
        {
            IAccount retVal = null;
            string sql = " SELECT ca.UserID, f.idcompagnia, f.targa, f.numero, f.scadenza, f.pin, f.Uid, f.statuscard, f.dataattivazione, f.codsocieta FROM EF_users_fuelcard as f " +
                         " LEFT JOIN  EF_contratti_assegnazioni as ca ON ca.targa = f.targa " +
                         " WHERE f.Uid  = @Uid ";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Idcompagnia = DataHelper.IfDBNull<int>(row["idcompagnia"], 0),
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    Numero = DataHelper.IfDBNull<string>(row["numero"], _stringEmpty),
                    Scadenza = DataHelper.IfDBNull<DateTime>(row["scadenza"], DateTime.MinValue),
                    Pin = DataHelper.IfDBNull<string>(row["pin"], _stringEmpty),
                    Stato = DataHelper.IfDBNull<string>(row["statuscard"], _stringEmpty),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Dataattivazione = DataHelper.IfDBNull<DateTime>(row["dataattivazione"], DateTime.MinValue),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }

        //elenco compagnie
        public List<IAccount> SelectCompagnie(Guid Uidtenant)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT * FROM EF_compagnie WHERE uidtenant = @Uidtenant ORDER BY compagnia ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;

            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Idcompagnia = DataHelper.IfDBNull<int>(row["idcompagnia"], 0),
                        Compagnia = DataHelper.IfDBNull<string>(row["compagnia"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IAccount> SelectCompagnieFuel()
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT * FROM EF_compagnie WHERE tipocompagnia = 'Fuel' ORDER BY compagnia ";

            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Idcompagnia = DataHelper.IfDBNull<int>(row["idcompagnia"], 0),
                        Compagnia = DataHelper.IfDBNull<string>(row["compagnia"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IAccount> SelectCompagnieRoot(Guid Uidtenant)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT * FROM EF_compagnie WHERE tipocompagnia = 'Root' AND uidtenant = @Uidtenant ORDER BY compagnia ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Idcompagnia = DataHelper.IfDBNull<int>(row["idcompagnia"], 0),
                        Compagnia = DataHelper.IfDBNull<string>(row["compagnia"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IAccount> SelectAllTeam()
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT * FROM EF_team ORDER BY team ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
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


        public List<IAccount> SelectTelePassXUser(Guid UserId)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT f.targa, f.numero, f.scadenza, f.Uid FROM EF_users_telepass as f " +
                         " INNER JOIN EF_contratti_assegnazioni as ca ON ca.UserId = f.UserId " +
                         " WHERE f.UserId = @UserId ORDER BY f.scadenza DESC ";

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
                    IAccount item = new Account
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Numero = DataHelper.IfDBNull<string>(row["numero"], _stringEmpty),
                        Scadenza = DataHelper.IfDBNull<DateTime>(row["scadenza"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //aggiorna tele pass users
        public int UpdateTelePassUser(IAccount value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users_telepass SET [UserId] = @UserId, [targa] = @targa, [numero] = @numero, [statustelepass] = @statustelepass, " +
                         " [scadenza] = @scadenza, [idcompagnia] = @idcompagnia, [datausermod] = @datausermod, [UserIdMod] = @UserIdMod WHERE Uid = @Uid AND uidtenant = @Uidtenant ";


            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = value.Uid;
            collParams.Add(param0);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param2.Value = value.UserId;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param3.Value = value.Targa;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@numero", DbType.String);
            param4.Value = value.Numero;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@scadenza", DbType.DateTime);
            param5.Value = value.Scadenza;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param7.Value = ProviderUserKey;
            collParams.Add(param7);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
            param10.Value = value.Idcompagnia;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@statustelepass", DbType.String);
            param11.Value = value.Stato;
            collParams.Add(param11);

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


        //inserimento nuovo tele pass users

        public int InsertTelePassUser(IAccount value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_users_telepass ([UserId],[targa],[numero],[scadenza],[idcompagnia],[datauserins],[datausermod],[UserIDIns],[UserIdMod],[uidtenant]) " +
                         " VALUES (@UserId,@targa,@numero,@scadenza,@idcompagnia,@datauserins,@datausermod,@UserIDIns,@UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param2.Value = value.UserId;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param3.Value = value.Targa;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@numero", DbType.String);
            param4.Value = value.Numero;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@scadenza", DbType.DateTime);
            param5.Value = value.Scadenza;
            collParams.Add(param5);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
            param10.Value = value.Idcompagnia;
            collParams.Add(param10);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param6.Value = DateTime.Now;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param7.Value = DateTime.Now;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param8.Value = ProviderUserKey;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param9.Value = ProviderUserKey;
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
        public int SelectCountTelePassUser(string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (f.targa  like '%' + @keysearch + '%' or f.numero  like '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND f.UserId = @UserId ";
            if (scadenzada > DateTime.MinValue) condWhere += " AND f.scadenza >= @scadenzada";
            if (scadenzaa > DateTime.MinValue) condWhere += " AND f.scadenza <= @scadenzaa";
            if (idcompagnia > 0) condWhere += " AND f.idcompagnia = @idcompagnia";
            if (!string.IsNullOrEmpty(status)) condWhere += " AND statustelepass = @status ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_users_telepass as f " +
                         " INNER JOIN EF_compagnie as c ON c.idcompagnia = f.idcompagnia AND f.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON f.UserId = u.UserId AND f.uidtenant = u.uidtenant WHERE f.idtelepass > 0 AND f.uidtenant = @Uidtenant " + condWhere;

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
            if (scadenzada > DateTime.MinValue)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzada", DbType.DateTime);
                param2.Value = scadenzada;
                collParams.Add(param2);
            }
            if (scadenzaa > DateTime.MinValue)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzaa", DbType.DateTime);
                param3.Value = scadenzaa;
                collParams.Add(param3);
            }
            if (idcompagnia > 0)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
                param4.Value = idcompagnia;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(status))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@status", DbType.String);
                param5.Value = status;
                collParams.Add(param5);
            }

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param6.Value = Uidtenant;
            collParams.Add(param6);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public List<IAccount> SelectTelePassUser(string keysearch, Guid UserId, DateTime scadenzada, DateTime scadenzaa, int idcompagnia, string status, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (f.targa  like '%' + @keysearch + '%' or f.numero  like '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND f.UserId = @UserId ";
            if (scadenzada > DateTime.MinValue) condWhere += " AND f.scadenza >= @scadenzada";
            if (scadenzaa > DateTime.MinValue) condWhere += " AND f.scadenza <= @scadenzaa";
            if (idcompagnia > 0) condWhere += " AND f.idcompagnia = @idcompagnia";
            if (!string.IsNullOrEmpty(status)) condWhere += " AND statustelepass = @status ";

            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT u.nome, u.cognome, u.matricola, f.Uid, f.scadenza, f.targa, f.numero, c.compagnia, f.statustelepass FROM EF_users_telepass as f " +
                         " INNER JOIN EF_compagnie as c ON c.idcompagnia = f.idcompagnia AND f.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON f.UserId = u.UserId AND f.uidtenant = u.uidtenant WHERE f.idtelepass > 0 AND f.uidtenant = @Uidtenant " + condWhere + " ORDER BY f.scadenza DESC " + paginazione;

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
            if (scadenzada > DateTime.MinValue)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzada", DbType.DateTime);
                param2.Value = scadenzada;
                collParams.Add(param2);
            }
            if (scadenzaa > DateTime.MinValue)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzaa", DbType.DateTime);
                param3.Value = scadenzaa;
                collParams.Add(param3);
            }
            if (idcompagnia > 0)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
                param4.Value = idcompagnia;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(status))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@status", DbType.String);
                param5.Value = status;
                collParams.Add(param5);
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
                    IAccount item = new Account
                    {
                        Scadenza = DataHelper.IfDBNull<DateTime>(row["scadenza"], DateTime.MinValue),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Numero = DataHelper.IfDBNull<string>(row["numero"], _stringEmpty),
                        Compagnia = DataHelper.IfDBNull<string>(row["compagnia"], _stringEmpty),
                        Stato = DataHelper.IfDBNull<string>(row["statustelepass"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IAccount DetailTelePassUserId(Guid Uid)
        {
            IAccount retVal = null;
            string sql = "SELECT * FROM EF_users_telepass WHERE Uid = @Uid";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    Numero = DataHelper.IfDBNull<string>(row["numero"], _stringEmpty),
                    Idcompagnia = DataHelper.IfDBNull<int>(row["idcompagnia"], 0),
                    Scadenza = DataHelper.IfDBNull<DateTime>(row["scadenza"], DateTime.MinValue),
                    Stato = DataHelper.IfDBNull<string>(row["statustelepass"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }

        public List<IAccount> SelectUsersPartner(Guid Uidtenant)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT * FROM EF_users WHERE uidtenant = @Uidtenant AND gradecode IN (15,10,17) ORDER BY cognome, nome ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;

            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IAccount> SelectCDCXSocieta(string codsocieta)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT codicecdc, denominazione, tipo, Uid FROM view_codicecdc WHERE codsocieta = @codsocieta ORDER BY denominazione ";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = codsocieta;
            collParams.Add(param0);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Codicecdc = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty) + ";" + DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty) + ";" + DataHelper.IfDBNull<string>(row["tipo"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty) + " - " + DataHelper.IfDBNull<string>(row["denominazione"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IAccount> SelectCDCXSocieta2(string codsocieta, string term)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT TOP 100 codicecdc, denominazione, tipo, Uid FROM view_codicecdc WHERE denominazione  like '%pool%' OR (codsocieta = @codsocieta " +
                         " AND (denominazione LIKE '%' + @term + '%' OR codicecdc LIKE '%' + @term + '%')) ORDER BY denominazione ";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = codsocieta;
            collParams.Add(param0);
            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@term", DbType.String);
            param1.Value = term;
            collParams.Add(param1);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty) + ";" + DataHelper.IfDBNull<string>(row["denominazione"], _stringEmpty) + ";" + DataHelper.IfDBNull<string>(row["tipo"], _stringEmpty) + ";" + DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        public int UpdateCredential(IAccount value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users SET [ClientId] = @ClientId, [ImpersonatedUserId] = @ImpersonatedUserId, [AuthServer] = @AuthServer, [PrivateKey] = @PrivateKey, " +
                         " [BasePath] = @BasePath, [AccountId] = @AccountId, [PingUrl] = @PingUrl, [SignerEmail] = @SignerEmail, [SignerName] = @SignerName, [SignerClientId] = @SignerClientId " +
                         " WHERE UserId = @UserId AND uidtenant = @Uidtenant ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = value.UserId;
            collParams.Add(param0);

            IDbDataParameter param60 = _dataHelper.ProviderConn.CreateDataParameter("@ClientId", DbType.String);
            param60.Value = value.ClientId;
            collParams.Add(param60);

            IDbDataParameter param61 = _dataHelper.ProviderConn.CreateDataParameter("@ImpersonatedUserId", DbType.String);
            param61.Value = value.ImpersonatedUserId;
            collParams.Add(param61);

            IDbDataParameter param62 = _dataHelper.ProviderConn.CreateDataParameter("@AuthServer", DbType.String);
            param62.Value = value.AuthServer;
            collParams.Add(param62);

            IDbDataParameter param63 = _dataHelper.ProviderConn.CreateDataParameter("@PrivateKey", DbType.String);
            param63.Value = value.PrivateKey;
            collParams.Add(param63);

            IDbDataParameter param64 = _dataHelper.ProviderConn.CreateDataParameter("@BasePath", DbType.String);
            param64.Value = value.BasePath;
            collParams.Add(param64);

            IDbDataParameter param65 = _dataHelper.ProviderConn.CreateDataParameter("@AccountId", DbType.String);
            param65.Value = value.AccountId;
            collParams.Add(param65);

            IDbDataParameter param66 = _dataHelper.ProviderConn.CreateDataParameter("@PingUrl", DbType.String);
            param66.Value = value.PingUrl;
            collParams.Add(param66);

            IDbDataParameter param67 = _dataHelper.ProviderConn.CreateDataParameter("@SignerEmail", DbType.String);
            param67.Value = value.SignerEmail;
            collParams.Add(param67);

            IDbDataParameter param68 = _dataHelper.ProviderConn.CreateDataParameter("@SignerName", DbType.String);
            param68.Value = value.SignerName;
            collParams.Add(param68);

            IDbDataParameter param69 = _dataHelper.ProviderConn.CreateDataParameter("@SignerClientId", DbType.String);
            param69.Value = value.SignerClientId;
            collParams.Add(param69);

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


        //aggiorna user
        public int UpdateUsersRobot(string email, Guid UserId)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users SET [UserId] = @UserId  WHERE email = @email ";


            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@email", DbType.String);
            param17.Value = email;
            collParams.Add(param17);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public bool ExistLogin(Guid iduser)
        {
            bool retVal = false;
            string sql = "SELECT * FROM EF_logattivita WHERE UserId = @iduser AND chiave='View Dashboard' ";
            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@iduser", DbType.Guid);
            param0.Value = iduser;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public List<IAccount> SelectUsersDimissionariAttivi()
        {
            string datafineprev = DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;

            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT UserId, email FROM EF_users WHERE idstatususer = 0 AND datadimissioni <= @datafineprev AND UserId='2BEFD1FB-3A8C-4025-AEC2-C1779E0510EF' ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@datafineprev", DbType.DateTime);
            param9.Value = datafineprev;
            collParams.Add(param9);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateEmail(IAccount value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users SET [idstatususer] = 1, [email] = @email, [datausermod] = @datausermod, [UserIdMod] = @UserIdMod WHERE UserId = @UserId AND uidtenant = @Uidtenant ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = value.UserId;
            collParams.Add(param0);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param7.Value = ProviderUserKey;
            collParams.Add(param7);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@email", DbType.String);
            param17.Value = value.Email;
            collParams.Add(param17);

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

        public int UpdateCount(IAccount value)
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
            param7.Value = ProviderUserKey;
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

        public IAccount ExistAnagraficaMatricola(string matricola)
        {
            IAccount retVal = null;
            string sql = "SELECT UserId, gradecode, iduser, idgruppouser FROM EF_users WHERE matricola = @matricola";
            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@matricola", DbType.String);
            param0.Value = matricola;
            collParams.Add(param0);
            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                    Idgruppouser = DataHelper.IfDBNull<int>(row["idgruppouser"], 0),
                    Gradecode = DataHelper.IfDBNull<string>(row["gradecode"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public List<IAccount> SelectUsersXDate(DateTime datarange)
        {
            List<IAccount> retVal = new List<IAccount>();

            string sql = "SELECT * FROM EF_users as u LEFT JOIN EF_userstatus as s ON u.idstatususer = s.idstatususer WHERE u.datauserins>=@datarange ORDER BY u.cognome, u.nome ";

            List<IDataParameter> collParams = new List<IDataParameter>();
            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@datarange", DbType.DateTime);
            param0.Value = datarange;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Iduser = DataHelper.IfDBNull<int>(row["iduser"], 0),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                        Idstatususer = DataHelper.IfDBNull<int>(row["idstatususer"], 0),
                        Statusutente = DataHelper.IfDBNull<string>(row["statusutente"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IAccount ReturnPlafond(Guid UserId)
        {
            IAccount retVal = null;
            string sql = "SELECT TOP 1 * FROM EF_users_fuel_plafond WHERE UserId = @UserId and statusplafond = 0 ORDER BY datarilevazione DESC ";
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
                    Datarilevazione = DataHelper.IfDBNull<DateTime>(row["datarilevazione"], DateTime.MinValue),
                    Plafond = DataHelper.IfDBNull<decimal>(row["plafond"], 0),
                    Delta = DataHelper.IfDBNull<decimal>(row["delta"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IAccount ReturnPropertyTenant(Guid Uidtenant)
        {
            IAccount retVal = null;
            string sql = "SELECT * FROM EF_tenant WHERE uidtenant = @Uidtenant ";
            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param0.Value = Uidtenant;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Account
                {
                    Logo = DataHelper.IfDBNull<string>(row["logo"], _stringEmpty),
                    Bgbarratop = DataHelper.IfDBNull<string>(row["bgbarratop"], _stringEmpty),
                    Bgbarrasx = DataHelper.IfDBNull<string>(row["bgbarrasx"], _stringEmpty),
                    Colormenusx = DataHelper.IfDBNull<string>(row["colormenusx"], _stringEmpty),
                    Urltenant = DataHelper.IfDBNull<string>(row["urltenant"], _stringEmpty),
                    Oggettomail = DataHelper.IfDBNull<string>(row["oggettomail"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        //elenco status

        public List<IAccount> SelectTenant()
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT * FROM EF_tenant ";

            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Uidtenant = DataHelper.IfDBNull<Guid>(row["uidtenant"], Guid.Empty),
                        Tenant = DataHelper.IfDBNull<string>(row["tenant"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IAccount> SelectGroupPageUsers(Guid Uidtenant)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = "SELECT * FROM EF_pagine_users_gruppi WHERE uidtenant = @Uidtenant ORDER BY ordine ";

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
                    IAccount item = new Account
                    {
                        Gruppo = DataHelper.IfDBNull<string>(row["gruppo"], _stringEmpty),
                        Codgruppopagina = DataHelper.IfDBNull<string>(row["codgruppopagina"], _stringEmpty),
                        Icona = DataHelper.IfDBNull<string>(row["icona"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IAccount> SelectPageUsers(string codgruppopagina, Guid Uidtenant)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT pagina, linkpagina, ordine FROM EF_pagine_users " +
                         " WHERE uidtenant = @Uidtenant and codgruppopagina = @codgruppopagina and status = 1 " +
                         " ORDER BY ordine ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codgruppopagina", DbType.String);
            param2.Value = codgruppopagina;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IAccount item = new Account
                    {
                        Pagina = DataHelper.IfDBNull<string>(row["pagina"], _stringEmpty),
                        Linkpagina = DataHelper.IfDBNull<string>(row["linkpagina"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateMenuUsers(int idpagina, int status, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = " UPDATE EF_pagine_users SET [status] = @status WHERE idpagina = @idpagina AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@status", DbType.Int32);
            param7.Value = status;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idpagina", DbType.Int32);
            param8.Value = idpagina;
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
        public List<IAccount> SelectAllPageUsers(Guid Uidtenant)
        {
            List<IAccount> retVal = new List<IAccount>();
            string sql = " SELECT * FROM EF_pagine_users  WHERE uidtenant = @Uidtenant ORDER BY codgruppopagina, ordine ";

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
                    IAccount item = new Account
                    {
                        Pagina = DataHelper.IfDBNull<string>(row["pagina"], _stringEmpty),
                        Idpagina = DataHelper.IfDBNull<int>(row["idpagina"], 0),
                        Status = DataHelper.IfDBNull<int>(row["status"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
    }
}