// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CContrattiProvider.cs" company="">
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
    [SectionName("contratti.provider/ContrattiSection")]
    public class ContrattiProvider : DFleetDataProvider, IContrattiProvider
    {

        //aggiorna contratto
        public int UpdateContratti(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti SET [codsocieta] = @codsocieta, [codjatoauto] = @codjatoauto, [codcarpolicy] = @codcarpolicy, [codcarlist] = @codcarlist, " +
                         " [codfornitore] = @codfornitore, [codtipocontratto] = @codtipocontratto, [codtipousocontratto] = @codtipousocontratto, [numordineordine] = @numordineordine, " +
                         " [numerocontratto] = @numerocontratto, [duratamesi] = @duratamesi, [kmcontratto] = @kmcontratto, [franchigia] = @franchigia, [annotazionicontratto] = @annotazionicontratto, " +
                         " [targa] = @targa, [canoneleasing] = @canoneleasing, [idstatuscontratto] = @idstatuscontratto, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod, " +
                         " [filecontratto] = @filecontratto, [bollo] = @bollo, [superbollo] = @superbollo, [idtipoassegnazione] = @idtipoassegnazione, [emissioni] = @emissioni, " +
                         " [fringebenefit] = @fringebenefit, [deltacanone] = @deltacanone, [canonefinanziario] = @canonefinanziario, [canoneservizi] = @canoneservizi, " +
                         " [costokmeccedente] = @costokmeccedente, [costokmrimborso] = @costokmrimborso, [sogliakm] = @sogliakm, " +
                         " [checkpool] = @checkpool, [idstatuspool] = @idstatuspool, [notepool] = @notepool, [UserIdpool] = @UserIdpool, [codcolore] = @codcolore, " +
                         " [checkassegnatario] = @checkassegnatario, [canonefigurativo] = @canonefigurativo, [flglibrettoinviato] = @flglibrettoinviato, [kwcvcontratto] = @kwcvcontratto, " +
                         " [alimentazionecontratto] = @alimentazionecontratto, [cilindratacontratto] = @cilindratacontratto, [codtipoutilizzo] = @codtipoutilizzo, " +
                         " [riparazione] = @riparazione ";

            if (value.Datacontratto > DateTime.MinValue)
            {
                sql += " ,[datacontratto] = @datacontratto ";
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@datacontratto", DbType.DateTime);
                param10.Value = value.Datacontratto;
                collParams.Add(param10);
            }

            if (value.Datainiziocontratto > DateTime.MinValue)
            {
                sql += " ,[datainiziocontratto] = @datainiziocontratto ";
                IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@datainiziocontratto", DbType.DateTime);
                param14.Value = value.Datainiziocontratto;
                collParams.Add(param14);

            }

            if (value.Datainiziouso > DateTime.MinValue)
            {
                sql += " ,[datainiziouso] = @datainiziouso ";
                IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datainiziouso", DbType.DateTime);
                param15.Value = value.Datainiziouso;
                collParams.Add(param15);

            }

            if (value.Datafinecontratto > DateTime.MinValue)
            {
                sql += " ,[datafinecontratto] = @datafinecontratto ";
                IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@datafinecontratto", DbType.DateTime);
                param16.Value = value.Datafinecontratto;
                collParams.Add(param16);
            }

            if (value.Dataimmatricolazione > DateTime.MinValue)
            {
                sql += " ,[dataimmatricolazione] = @dataimmatricolazione ";
                IDbDataParameter param29 = _dataHelper.ProviderConn.CreateDataParameter("@dataimmatricolazione", DbType.DateTime);
                param29.Value = value.Dataimmatricolazione;
                collParams.Add(param29);

            }

            if (value.Scadenzabollo > DateTime.MinValue)
            {
                sql += " ,[scadenzabollo] = @scadenzabollo ";
                IDbDataParameter param30 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzabollo", DbType.DateTime);
                param30.Value = value.Scadenzabollo;
                collParams.Add(param30);

            }

            if (value.Scadenzasuperbollo > DateTime.MinValue)
            {
                sql += " ,[scadenzasuperbollo] = @scadenzasuperbollo ";
                IDbDataParameter param31 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzasuperbollo", DbType.DateTime);
                param31.Value = value.Scadenzasuperbollo;
                collParams.Add(param31);
            }

            if (value.Datarevisione > DateTime.MinValue)
            {
                sql += " ,[datarevisione] = @datarevisione ";
                IDbDataParameter param46 = _dataHelper.ProviderConn.CreateDataParameter("@datarevisione", DbType.DateTime);
                param46.Value = value.Datarevisione;
                collParams.Add(param46);
            }

            sql += " WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param2.Value = value.Codjatoauto;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param3.Value = value.Codcarpolicy;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param4.Value = value.Codcarlist;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param5.Value = value.Codfornitore;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codtipocontratto", DbType.String);
            param6.Value = value.Codtipocontratto;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@codtipousocontratto", DbType.String);
            param7.Value = value.Codtipousocontratto;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@numordineordine", DbType.String);
            param8.Value = value.Numordineordine;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
            param9.Value = value.Numerocontratto;
            collParams.Add(param9);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@duratamesi", DbType.Int32);
            param11.Value = value.Duratamesi;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@kmcontratto", DbType.Int32);
            param12.Value = value.Kmcontratto;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@franchigia", DbType.Decimal);
            param13.Value = value.Franchigia;
            collParams.Add(param13);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@annotazionicontratto", DbType.String);
            param17.Value = value.Annotazionicontratto;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@canoneleasing", DbType.Decimal);
            param18.Value = value.Canoneleasing;
            collParams.Add(param18);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
            param19.Value = value.Idstatuscontratto;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param20.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = value.Uid;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param23.Value = value.Targa;
            collParams.Add(param23);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@filecontratto", DbType.String);
            param26.Value = value.Filecontratto;
            collParams.Add(param26);

            IDbDataParameter param27 = _dataHelper.ProviderConn.CreateDataParameter("@bollo", DbType.Decimal);
            param27.Value = value.Bollo;
            collParams.Add(param27);

            IDbDataParameter param28 = _dataHelper.ProviderConn.CreateDataParameter("@superbollo", DbType.Decimal);
            param28.Value = value.Superbollo;
            collParams.Add(param28);

            IDbDataParameter param32 = _dataHelper.ProviderConn.CreateDataParameter("@idtipoassegnazione", DbType.Int32);
            param32.Value = value.Idtipoassegnazione;
            collParams.Add(param32);

            IDbDataParameter param33 = _dataHelper.ProviderConn.CreateDataParameter("@emissioni", DbType.Decimal);
            param33.Value = value.Emissioni;
            collParams.Add(param33);

            IDbDataParameter param34 = _dataHelper.ProviderConn.CreateDataParameter("@fringebenefit", DbType.Decimal);
            param34.Value = value.Fringebenefit;
            collParams.Add(param34);

            IDbDataParameter param37 = _dataHelper.ProviderConn.CreateDataParameter("@deltacanone", DbType.Decimal);
            param37.Value = value.Deltacanone;
            collParams.Add(param37);

            IDbDataParameter param38 = _dataHelper.ProviderConn.CreateDataParameter("@canonefinanziario", DbType.Decimal);
            param38.Value = value.Canonefinanziario;
            collParams.Add(param38);

            IDbDataParameter param39 = _dataHelper.ProviderConn.CreateDataParameter("@canoneservizi", DbType.Decimal);
            param39.Value = value.Canoneservizi;
            collParams.Add(param39);

            IDbDataParameter param40 = _dataHelper.ProviderConn.CreateDataParameter("@costokmeccedente", DbType.Decimal);
            param40.Value = value.Costokmeccedente;
            collParams.Add(param40);

            IDbDataParameter param41 = _dataHelper.ProviderConn.CreateDataParameter("@costokmrimborso", DbType.Decimal);
            param41.Value = value.Costokmrimborso;
            collParams.Add(param41);

            IDbDataParameter param42 = _dataHelper.ProviderConn.CreateDataParameter("@sogliakm", DbType.Decimal);
            param42.Value = value.Sogliakm;
            collParams.Add(param42);

            IDbDataParameter param43 = _dataHelper.ProviderConn.CreateDataParameter("@checkpool", DbType.Int32);
            param43.Value = value.Checkpool;
            collParams.Add(param43);

            IDbDataParameter param44 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuspool", DbType.Int32);
            param44.Value = value.Idstatuspool;
            collParams.Add(param44);

            IDbDataParameter param45 = _dataHelper.ProviderConn.CreateDataParameter("@notepool", DbType.String);
            param45.Value = value.Notepool;
            collParams.Add(param45);

            IDbDataParameter param47 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdpool", DbType.Guid);
            param47.Value = value.UserIdpool;
            collParams.Add(param47);

            IDbDataParameter param48 = _dataHelper.ProviderConn.CreateDataParameter("@codcolore", DbType.String);
            param48.Value = value.Codcolore;
            collParams.Add(param48);

            IDbDataParameter param49 = _dataHelper.ProviderConn.CreateDataParameter("@checkassegnatario", DbType.Int32);
            param49.Value = value.Checkassegnatario;
            collParams.Add(param49);

            IDbDataParameter param50 = _dataHelper.ProviderConn.CreateDataParameter("@canonefigurativo", DbType.Decimal);
            param50.Value = value.Canonefigurativo;
            collParams.Add(param50);

            IDbDataParameter param51 = _dataHelper.ProviderConn.CreateDataParameter("@flglibrettoinviato", DbType.Int32);
            param51.Value = value.Flglibrettoinviato;
            collParams.Add(param51);

            IDbDataParameter param52 = _dataHelper.ProviderConn.CreateDataParameter("@kwcvcontratto", DbType.String);
            param52.Value = value.Kwcvcontratto;
            collParams.Add(param52);

            IDbDataParameter param53 = _dataHelper.ProviderConn.CreateDataParameter("@alimentazionecontratto", DbType.String);
            param53.Value = value.Alimentazionecontratto;
            collParams.Add(param53);

            IDbDataParameter param54 = _dataHelper.ProviderConn.CreateDataParameter("@cilindratacontratto", DbType.String);
            param54.Value = value.Cilindratacontratto;
            collParams.Add(param54);

            IDbDataParameter param55 = _dataHelper.ProviderConn.CreateDataParameter("@codtipoutilizzo", DbType.String);
            param55.Value = value.Codutilizzo;
            collParams.Add(param55);

            IDbDataParameter param56 = _dataHelper.ProviderConn.CreateDataParameter("@riparazione", DbType.Int32);
            param56.Value = value.Riparazione;
            collParams.Add(param56);

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


        //cancella contratto

        public int DeleteContratti(IContratti value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_contratti WHERE Uid = @Uid AND uidtenant = @Uidtenant";

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

        //inserimento nuovo contratto

        public int InsertContratti(IContratti value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Datacontratto > DateTime.MinValue)
            {
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@datacontratto", DbType.DateTime);
                param10.Value = value.Datacontratto;
                collParams.Add(param10);

                sqlfield += " ,[datacontratto] ";
                sqlvalue += " ,@datacontratto ";
            }

            if (value.Datainiziocontratto > DateTime.MinValue)
            {
                IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@datainiziocontratto", DbType.DateTime);
                param14.Value = value.Datainiziocontratto;
                collParams.Add(param14);

                sqlfield += " ,[datainiziocontratto] ";
                sqlvalue += " ,@datainiziocontratto ";
            }

            if (value.Datainiziouso > DateTime.MinValue)
            {
                IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datainiziouso", DbType.DateTime);
                param15.Value = value.Datainiziouso;
                collParams.Add(param15);

                sqlfield += " ,[datainiziouso] ";
                sqlvalue += " ,@datainiziouso ";
            }

            if (value.Datafinecontratto > DateTime.MinValue)
            {
                IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@datafinecontratto", DbType.DateTime);
                param16.Value = value.Datafinecontratto;
                collParams.Add(param16);

                sqlfield += " ,[datafinecontratto] ";
                sqlvalue += " ,@datafinecontratto ";
            }

            if (value.Dataimmatricolazione > DateTime.MinValue)
            {
                IDbDataParameter param29 = _dataHelper.ProviderConn.CreateDataParameter("@dataimmatricolazione", DbType.DateTime);
                param29.Value = value.Dataimmatricolazione;
                collParams.Add(param29);

                sqlfield += " ,[dataimmatricolazione] ";
                sqlvalue += " ,@dataimmatricolazione ";

            }

            if (value.Scadenzabollo > DateTime.MinValue)
            {
                IDbDataParameter param30 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzabollo", DbType.DateTime);
                param30.Value = value.Scadenzabollo;
                collParams.Add(param30);

                sqlfield += " ,[scadenzabollo] ";
                sqlvalue += " ,@scadenzabollo ";

            }

            if (value.Scadenzasuperbollo > DateTime.MinValue)
            {
                IDbDataParameter param31 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzasuperbollo", DbType.DateTime);
                param31.Value = value.Scadenzasuperbollo;
                collParams.Add(param31);

                sqlfield += " ,[scadenzasuperbollo] ";
                sqlvalue += " ,@scadenzasuperbollo ";
            }

            if (value.Datarevisione > DateTime.MinValue)
            {
                IDbDataParameter param43 = _dataHelper.ProviderConn.CreateDataParameter("@datarevisione", DbType.DateTime);
                param43.Value = value.Datarevisione;
                collParams.Add(param43);

                sqlfield += " ,[datarevisione] ";
                sqlvalue += " ,@datarevisione ";
            }

            string sql = "INSERT INTO EF_contratti ([codsocieta],[UserId],[codjatoauto],[codcarpolicy],[codcarlist],[codfornitore],[codtipocontratto],[codtipousocontratto], " +
                         " [numordineordine],[numerocontratto],[duratamesi],[kmcontratto],[franchigia],[annotazionicontratto],[canoneleasing],[idstatuscontratto],[datauserins], " +
                         " [datausermod],[UserIDIns],[UserIdMod],[targa],[Uidordine],[filecontratto],[bollo],[superbollo],[flgvoltura],[notevoltura],[Uidcontrattovolturato], " +
                         " [idtipoassegnazione],[emissioni],[deltacanone],[canonefinanziario],[canoneservizi],[costokmeccedente],[costokmrimborso],[sogliakm], " +
                         " [codcolore],[canonefigurativo],[codtipoutilizzo],[uidtenant] " + sqlfield + " ) " +
                         " VALUES (@codsocieta,@UserId,@codjatoauto,@codcarpolicy,@codcarlist,@codfornitore,@codtipocontratto,@codtipousocontratto,@numordineordine,@numerocontratto, " +
                         " @duratamesi,@kmcontratto,@franchigia,@annotazionicontratto,@canoneleasing,@idstatuscontratto,@datauserins,@datausermod,@UserIDIns,@UserIdMod, " +
                         " @targa,@Uidordine,@filecontratto,@bollo,@superbollo,@flgvoltura,@notevoltura,@Uidcontrattovolturato,@idtipoassegnazione,@emissioni,@deltacanone, " +
                         " @canonefinanziario,@canoneservizi,@costokmeccedente,@costokmrimborso,@sogliakm,@codcolore,@canonefigurativo,@codtipoutilizzo,@uidtenant " + sqlvalue + " ) ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = value.UserId;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param2.Value = value.Codjatoauto;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param3.Value = value.Codcarpolicy;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param4.Value = value.Codcarlist;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param5.Value = value.Codfornitore;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codtipocontratto", DbType.String);
            param6.Value = value.Codtipocontratto;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@codtipousocontratto", DbType.String);
            param7.Value = value.Codtipousocontratto;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@numordineordine", DbType.String);
            param8.Value = value.Numordineordine;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
            param9.Value = value.Numerocontratto;
            collParams.Add(param9);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@duratamesi", DbType.Int32);
            param11.Value = value.Duratamesi;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@kmcontratto", DbType.Int32);
            param12.Value = value.Kmcontratto;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@franchigia", DbType.Decimal);
            param13.Value = value.Franchigia;
            collParams.Add(param13);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@annotazionicontratto", DbType.String);
            param17.Value = value.Annotazionicontratto;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@canoneleasing", DbType.Decimal);
            param18.Value = value.Canoneleasing;
            collParams.Add(param18);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
            param19.Value = value.Idstatuscontratto;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param20.Value = DateTime.Now;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param21.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param22.Value = DateTime.Now;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param23.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param24.Value = value.Targa;
            collParams.Add(param24);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@Uidordine", DbType.Guid);
            param25.Value = value.Uidordine;
            collParams.Add(param25);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@filecontratto", DbType.String);
            param26.Value = value.Filecontratto;
            collParams.Add(param26);

            IDbDataParameter param27 = _dataHelper.ProviderConn.CreateDataParameter("@bollo", DbType.Decimal);
            param27.Value = value.Bollo;
            collParams.Add(param27);

            IDbDataParameter param28 = _dataHelper.ProviderConn.CreateDataParameter("@superbollo", DbType.Decimal);
            param28.Value = value.Superbollo;
            collParams.Add(param28);

            IDbDataParameter param32 = _dataHelper.ProviderConn.CreateDataParameter("@flgvoltura", DbType.Int32);
            param32.Value = value.Flgvoltura;
            collParams.Add(param32);

            IDbDataParameter param33 = _dataHelper.ProviderConn.CreateDataParameter("@notevoltura", DbType.String);
            param33.Value = value.Notevoltura;
            collParams.Add(param33);

            IDbDataParameter param34 = _dataHelper.ProviderConn.CreateDataParameter("@Uidcontrattovolturato", DbType.Guid);
            param34.Value = value.Uidcontrattovolturato;
            collParams.Add(param34);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@idtipoassegnazione", DbType.Int32);
            param35.Value = value.Idtipoassegnazione;
            collParams.Add(param35);

            IDbDataParameter param36 = _dataHelper.ProviderConn.CreateDataParameter("@emissioni", DbType.Decimal);
            param36.Value = value.Emissioni;
            collParams.Add(param36);

            IDbDataParameter param37 = _dataHelper.ProviderConn.CreateDataParameter("@deltacanone", DbType.Decimal);
            param37.Value = value.Deltacanone;
            collParams.Add(param37);

            IDbDataParameter param38 = _dataHelper.ProviderConn.CreateDataParameter("@canonefinanziario", DbType.Decimal);
            param38.Value = value.Canonefinanziario;
            collParams.Add(param38);

            IDbDataParameter param39 = _dataHelper.ProviderConn.CreateDataParameter("@canoneservizi", DbType.Decimal);
            param39.Value = value.Canoneservizi;
            collParams.Add(param39);

            IDbDataParameter param40 = _dataHelper.ProviderConn.CreateDataParameter("@costokmeccedente", DbType.Decimal);
            param40.Value = value.Costokmeccedente;
            collParams.Add(param40);

            IDbDataParameter param41 = _dataHelper.ProviderConn.CreateDataParameter("@costokmrimborso", DbType.Decimal);
            param41.Value = value.Costokmrimborso;
            collParams.Add(param41);

            IDbDataParameter param42 = _dataHelper.ProviderConn.CreateDataParameter("@sogliakm", DbType.Decimal);
            param42.Value = value.Sogliakm;
            collParams.Add(param42);

            IDbDataParameter param44 = _dataHelper.ProviderConn.CreateDataParameter("@codcolore", DbType.String);
            param44.Value = value.Codcolore;
            collParams.Add(param44);

            IDbDataParameter param45 = _dataHelper.ProviderConn.CreateDataParameter("@canonefigurativo", DbType.Decimal);
            param45.Value = value.Canonefigurativo;
            collParams.Add(param45);

            IDbDataParameter param47 = _dataHelper.ProviderConn.CreateDataParameter("@codtipoutilizzo", DbType.String);
            param47.Value = value.Codutilizzo;
            collParams.Add(param47);

            IDbDataParameter param48 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param48.Value = value.Uidtenant;
            collParams.Add(param48);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli contratti
        public IContratti DetailContrattiId(Guid Uid)
        {
            IContratti retVal = null;
            string sql = "SELECT * FROM EF_contratti WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Idcontratto = DataHelper.IfDBNull<int>(row["idcontratto"], 0),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    UserIdpool = DataHelper.IfDBNull<Guid>(row["UserIdpool"], Guid.Empty),
                    Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                    Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                    Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                    Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                    Codtipocontratto = DataHelper.IfDBNull<string>(row["codtipocontratto"], _stringEmpty),
                    Codtipousocontratto = DataHelper.IfDBNull<string>(row["codtipousocontratto"], _stringEmpty),
                    Numordineordine = DataHelper.IfDBNull<string>(row["numordineordine"], _stringEmpty),
                    Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                    Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                    Duratamesi = DataHelper.IfDBNull<int>(row["duratamesi"], 0),
                    Kmcontratto = DataHelper.IfDBNull<int>(row["kmcontratto"], 0),
                    Franchigia = DataHelper.IfDBNull<decimal>(row["franchigia"], 0),
                    Datainiziocontratto = DataHelper.IfDBNull<DateTime>(row["datainiziocontratto"], DateTime.MinValue),
                    Datainiziouso = DataHelper.IfDBNull<DateTime>(row["datainiziouso"], DateTime.MinValue),
                    Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                    Annotazionicontratto = DataHelper.IfDBNull<string>(row["annotazionicontratto"], _stringEmpty),
                    Canoneleasing = DataHelper.IfDBNull<decimal>(row["canoneleasing"], 0),
                    Idstatuscontratto = DataHelper.IfDBNull<int>(row["idstatuscontratto"], 0),
                    Filecontratto = DataHelper.IfDBNull<string>(row["filecontratto"], _stringEmpty),
                    Bollo = DataHelper.IfDBNull<decimal>(row["bollo"], 0),
                    Superbollo = DataHelper.IfDBNull<decimal>(row["superbollo"], 0),
                    Dataimmatricolazione = DataHelper.IfDBNull<DateTime>(row["dataimmatricolazione"], DateTime.MinValue),
                    Scadenzabollo = DataHelper.IfDBNull<DateTime>(row["scadenzabollo"], DateTime.MinValue),
                    Scadenzasuperbollo = DataHelper.IfDBNull<DateTime>(row["scadenzasuperbollo"], DateTime.MinValue),
                    Uidordine = DataHelper.IfDBNull<Guid>(row["Uidordine"], Guid.Empty),
                    Flgvoltura = DataHelper.IfDBNull<int>(row["flgvoltura"], 0),
                    Notevoltura = DataHelper.IfDBNull<string>(row["notevoltura"], _stringEmpty),
                    Uidcontrattovolturato = DataHelper.IfDBNull<Guid>(row["Uidcontrattovolturato"], Guid.Empty),
                    Idtipoassegnazione = DataHelper.IfDBNull<int>(row["idtipoassegnazione"], 0),
                    Emissioni = DataHelper.IfDBNull<decimal>(row["emissioni"], 0),
                    Fringebenefit = DataHelper.IfDBNull<decimal>(row["fringebenefit"], 0),
                    Notetemplate = DataHelper.IfDBNull<string>(row["noteproroga"], _stringEmpty),
                    Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                    Canonefinanziario = DataHelper.IfDBNull<decimal>(row["canonefinanziario"], 0),
                    Canoneservizi = DataHelper.IfDBNull<decimal>(row["canoneservizi"], 0),
                    Costokmeccedente = DataHelper.IfDBNull<decimal>(row["costokmeccedente"], 0),
                    Costokmrimborso = DataHelper.IfDBNull<decimal>(row["costokmrimborso"], 0),
                    Sogliakm = DataHelper.IfDBNull<decimal>(row["sogliakm"], 0),
                    Checkpool = DataHelper.IfDBNull<int>(row["checkpool"], 0),
                    Checkordinepool = DataHelper.IfDBNull<int>(row["checkordinepool"], 0),
                    Idstatuspool = DataHelper.IfDBNull<int>(row["idstatuspool"], 0),
                    Gradepool = DataHelper.IfDBNull<string>(row["gradepool"], _stringEmpty),
                    Notepool = DataHelper.IfDBNull<string>(row["notepool"], _stringEmpty),
                    Datarevisione = DataHelper.IfDBNull<DateTime>(row["datarevisione"], DateTime.MinValue),
                    Codcolore = DataHelper.IfDBNull<string>(row["codcolore"], _stringEmpty),
                    Checkassegnatario = DataHelper.IfDBNull<int>(row["checkassegnatario"], 0),
                    Canonefigurativo = DataHelper.IfDBNull<decimal>(row["canonefigurativo"], 0),
                    Flglibrettoinviato = DataHelper.IfDBNull<int>(row["flglibrettoinviato"], 0),
                    Kwcvcontratto = DataHelper.IfDBNull<string>(row["kwcvcontratto"], _stringEmpty),
                    Alimentazionecontratto = DataHelper.IfDBNull<string>(row["alimentazionecontratto"], _stringEmpty),
                    Cilindratacontratto = DataHelper.IfDBNull<string>(row["cilindratacontratto"], _stringEmpty),
                    Filelibrettoautocontratto = DataHelper.IfDBNull<string>(row["filelibrettoautocontratto"], _stringEmpty),
                    Codutilizzo = DataHelper.IfDBNull<string>(row["codtipoutilizzo"], _stringEmpty),
                    Riparazione = DataHelper.IfDBNull<int>(row["riparazione"], 0),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }


        // conta contratti 
        // FILTRO: codsocieta, UserId, marca, targa, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto
        public int SelectCountContratti(string codsocieta, Guid UserId, string marca, string targa, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND (a.marca = @marca OR a.modello = @modello ) ";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND c.targa = @targa ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND c.datafinecontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND c.datafinecontratto <= @datacontrattoal";
            if (idstatuscontratto > -1) condWhere += " AND c.idstatuscontratto = @idstatuscontratto ";

            string SQL = " SELECT DISTINCT COUNT(DISTINCT c.Uid) as tot FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_status as cs ON cs.idstatuscontratto = c.idstatuscontratto AND c.uidtenant = cs.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = c.codfornitore AND c.uidtenant = f.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta AND c.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as a ON a.codjatoauto = c.codjatoauto AND c.uidtenant = a.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserId AND c.uidtenant = u.uidtenant " +
                         " WHERE c.idcontratto > 0 AND c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param3.Value = targa;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatuscontratto > -1)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
                param8.Value = idstatuscontratto;
                collParams.Add(param8);
            }

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);
            
            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista contratti
        // FILTRO: codsocieta, UserId, marca, targa, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto
        public List<IContratti> SelectContratti(string codsocieta, Guid UserId, string marca, string targa, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " c.datacontratto ";
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

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND (a.marca = @marca OR a.modello = @modello ) ";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND c.targa = @targa ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND c.datafinecontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND c.datafinecontratto <= @datacontrattoal";
            if (idstatuscontratto > -1) condWhere += " AND c.idstatuscontratto = @idstatuscontratto ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = "SELECT DISTINCT f.codfornitore, c.numerocontratto, c.datacontratto, c.targa, a.modello, a.marca, s.siglasocieta, u.nome, u.cognome, " +
                         " u.matricola, c.duratamesi, c.kmcontratto, c.datafinecontratto, cs.statuscontratto, c.Uid  FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_status as cs ON cs.idstatuscontratto = c.idstatuscontratto AND c.uidtenant = cs.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = c.codfornitore AND c.uidtenant = f.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta AND c.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as a ON a.codjatoauto = c.codjatoauto and a.codcarlist = c.codcarlist AND c.uidtenant = a.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserId AND c.uidtenant = u.uidtenant " +
                         " WHERE c.idcontratto > 0 AND c.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param3.Value = targa;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatuscontratto > -1)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
                param8.Value = idstatuscontratto;
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
                    IContratti item = new Contratti
                    {
                        Fornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Kmcontratto = DataHelper.IfDBNull<int>(row["kmcontratto"], 0),
                        Duratamesi = DataHelper.IfDBNull<int>(row["duratamesi"], 0),
                        Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                        Statuscontratto = DataHelper.IfDBNull<string>(row["statuscontratto"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectAllStatusContratto(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_contratti_status WHERE uidtenant = @Uidtenant ORDER BY statuscontratto ";

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
                    IContratti item = new Contratti
                    {
                        Idstatuscontratto = DataHelper.IfDBNull<int>(row["idstatuscontratto"], 0),
                        Statuscontratto = DataHelper.IfDBNull<string>(row["statuscontratto"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectAllStatusContrattoAss(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_contratti_assegnazioni_status WHERE uidtenant = @Uidtenant ORDER BY statusassegnazione ";

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
                    IContratti item = new Contratti
                    {
                        Idstatusassegnazione = DataHelper.IfDBNull<int>(row["idstatusassegnazione"], 0),
                        Statusassegnazione = DataHelper.IfDBNull<string>(row["statusassegnazione"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectAllStatusContrattoPool(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_contratti_assegnazioni_status_pool WHERE uidtenant = @Uidtenant ORDER BY statuspool ";

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
                    IContratti item = new Contratti
                    {
                        Idstatuspool = DataHelper.IfDBNull<int>(row["idstatuspool"], 0),
                        Statuspool = DataHelper.IfDBNull<string>(row["statuspool"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        //aggiorna ordine
        public int UpdateOrdini(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_ordini SET [codsocieta] = @codsocieta, [UserId] = @UserId, [codjatoauto] = @codjatoauto, [codcarpolicy] = @codcarpolicy, [codcarlist] = @codcarlist, " +
                         " [codfornitore] = @codfornitore, [numeroordine] = @numeroordine, [annotazioniordini] = @annotazioniordini, [deltacanone] = @deltacanone, " +
                         " [canoneleasing] = @canoneleasing, [idstatusordine] = @idstatusordine, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod, [motivoscarto] = @motivoscarto, " +
                         " [filefirma] = @filefirma, [fileconfermarental] = @fileconfermarental ";


            if (value.Dataordine > DateTime.MinValue)
            {
                sql += " ,[dataordine] = @dataordine ";
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@dataordine", DbType.DateTime);
                param10.Value = value.Dataordine;
                collParams.Add(param10);
            }

            if (value.Dataprimaconsegnaprevista > DateTime.MinValue)
            {
                sql += " ,[dataprimaconsegnaprevista] = @dataprimaconsegnaprevista ";
                IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@dataprimaconsegnaprevista", DbType.DateTime);
                param14.Value = value.Dataprimaconsegnaprevista;
                collParams.Add(param14);

            }

            if (value.Dataconsegnaprevista > DateTime.MinValue)
            {
                sql += " ,[dataconsegnaprevista] = @dataconsegnaprevista ";
                IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@dataconsegnaprevista", DbType.DateTime);
                param15.Value = value.Dataconsegnaprevista;
                collParams.Add(param15);

            }

            if (value.Dataconsegnaprevistaupdate > DateTime.MinValue)
            {
                sql += " ,[dataconsegnaprevistaupdate] = @dataconsegnaprevistaupdate ";
                IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@dataconsegnaprevistaupdate", DbType.DateTime);
                param23.Value = value.Dataconsegnaprevistaupdate;
                collParams.Add(param23);
            }

            if (value.Dataconfermaricezione > DateTime.MinValue)
            {
                sql += " ,[dataconfermaricezione] = @dataconfermaricezione ";
                IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@dataconfermaricezione", DbType.DateTime);
                param24.Value = value.Dataconfermaricezione;
                collParams.Add(param24);
            }

            if (value.Datainviolink > DateTime.MinValue)
            {
                sql += " ,[datainviolink] = @datainviolink ";
                IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@datainviolink", DbType.DateTime);
                param25.Value = value.Datainviolink;
                collParams.Add(param25);
            }

            sql += " WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = value.UserId;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param2.Value = value.Codjatoauto;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param3.Value = value.Codcarpolicy;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param4.Value = value.Codcarlist;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param5.Value = value.Codfornitore;
            collParams.Add(param5);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@numeroordine", DbType.String);
            param8.Value = value.Numeroordine;
            collParams.Add(param8);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@annotazioniordini", DbType.String);
            param17.Value = value.Annotazioniordini;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@canoneleasing", DbType.Decimal);
            param18.Value = value.Canoneleasing;
            collParams.Add(param18);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
            param19.Value = value.Idstatusordine;
            collParams.Add(param19);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@deltacanone", DbType.Decimal);
            param26.Value = value.Deltacanone;
            collParams.Add(param26);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param20.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = value.Uid;
            collParams.Add(param22);

            IDbDataParameter param29 = _dataHelper.ProviderConn.CreateDataParameter("@motivoscarto", DbType.String);
            param29.Value = value.Motivoscarto;
            collParams.Add(param29);

            IDbDataParameter param30 = _dataHelper.ProviderConn.CreateDataParameter("@filefirma", DbType.String);
            param30.Value = value.Filefirma;
            collParams.Add(param30);

            IDbDataParameter param31 = _dataHelper.ProviderConn.CreateDataParameter("@fileconfermarental", DbType.String);
            param31.Value = value.Fileconfermarental;
            collParams.Add(param31);

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


        //aggiorna ordine
        public int UpdateOrdini2(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_ordini SET [codsocieta] = @codsocieta, [UserId] = @UserId, [codjatoauto] = @codjatoauto, [codcarlist] = @codcarlist, [codcarpolicy] = @codcarpolicy, " +
                         " [codfornitore] = @codfornitore, [annotazioniordini] = @annotazioniordini, [deltacanone] = @deltacanone, [numeroordinefornitore] = @numeroordinefornitore, " +
                         " [canoneleasing] = @canoneleasing, [idstatusordine] = @idstatusordine, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod, " +
                         " [filefirma] = @filefirma, [fileconfermarental] = @fileconfermarental, [sederecapito] = @sederecapito, [canoneleasingofferta] = @canoneleasingofferta," +
                         " [alimentazione] = @alimentazione ";


            if (value.Dataordine > DateTime.MinValue)
            {
                sql += " ,[dataordine] = @dataordine ";
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@dataordine", DbType.DateTime);
                param10.Value = value.Dataordine;
                collParams.Add(param10);
            }
            if (value.Dataconsegnaprevista > DateTime.MinValue)
            {
                sql += " ,[dataconsegnaprevista] = @dataconsegnaprevista ";
                IDbDataParameter param34 = _dataHelper.ProviderConn.CreateDataParameter("@dataconsegnaprevista", DbType.DateTime);
                param34.Value = value.Dataconsegnaprevista;
                collParams.Add(param34);
            }

            sql += " WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = value.UserId;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param2.Value = value.Codjatoauto;
            collParams.Add(param2);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param4.Value = value.Codcarlist;
            collParams.Add(param4);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param6.Value = value.Codcarpolicy;
            collParams.Add(param6);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param5.Value = value.Codfornitore;
            collParams.Add(param5);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@annotazioniordini", DbType.String);
            param17.Value = value.Annotazioniordini;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@canoneleasing", DbType.Decimal);
            param18.Value = value.Canoneleasing;
            collParams.Add(param18);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
            param19.Value = value.Idstatusordine;
            collParams.Add(param19);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@deltacanone", DbType.Decimal);
            param26.Value = value.Deltacanone;
            collParams.Add(param26);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param20.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = value.Uid;
            collParams.Add(param22);

            IDbDataParameter param30 = _dataHelper.ProviderConn.CreateDataParameter("@filefirma", DbType.String);
            param30.Value = value.Filefirma;
            collParams.Add(param30);

            IDbDataParameter param31 = _dataHelper.ProviderConn.CreateDataParameter("@fileconfermarental", DbType.String);
            param31.Value = value.Fileconfermarental;
            collParams.Add(param31);

            IDbDataParameter param32 = _dataHelper.ProviderConn.CreateDataParameter("@sederecapito", DbType.String);
            param32.Value = value.Sedelavoro;
            collParams.Add(param32);

            IDbDataParameter param33 = _dataHelper.ProviderConn.CreateDataParameter("@canoneleasingofferta", DbType.Decimal);
            param33.Value = value.Canoneleasingofferta;
            collParams.Add(param33);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@numeroordinefornitore", DbType.String);
            param35.Value = value.Numeroordinefornitore;
            collParams.Add(param35);

            IDbDataParameter param37 = _dataHelper.ProviderConn.CreateDataParameter("@alimentazione", DbType.String);
            param37.Value = value.Alimentazione;
            collParams.Add(param37);

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

        //cancella ordine
        public int DeleteOrdini(IContratti value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_ordini WHERE Uid = @Uid AND uidtenant = @Uidtenant";

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

        //inserimento nuovo ordine

        public int InsertOrdini(IContratti value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Dataordine > DateTime.MinValue)
            {
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@dataordine", DbType.DateTime);
                param10.Value = value.Dataordine;
                collParams.Add(param10);

                sqlfield += " ,[dataordine] ";
                sqlvalue += " ,@dataordine ";

                if (value.Idstatusordine == 10)
                {
                    IDbDataParameter param32 = _dataHelper.ProviderConn.CreateDataParameter("@data10", DbType.DateTime);
                    param32.Value = value.Dataordine;
                    collParams.Add(param32);

                    sqlfield += " ,[data10] ";
                    sqlvalue += " ,@data10 ";
                }
            }

            if (value.Dataprimaconsegnaprevista > DateTime.MinValue)
            {
                IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@dataprimaconsegnaprevista", DbType.DateTime);
                param14.Value = value.Dataprimaconsegnaprevista;
                collParams.Add(param14);

                sqlfield += " ,[dataprimaconsegnaprevista] ";
                sqlvalue += " ,@dataprimaconsegnaprevista ";
            }

            if (value.Dataconsegnaprevista > DateTime.MinValue)
            {
                IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@dataconsegnaprevista", DbType.DateTime);
                param15.Value = value.Dataconsegnaprevista;
                collParams.Add(param15);

                sqlfield += " ,[dataconsegnaprevista] ";
                sqlvalue += " ,@dataconsegnaprevista ";
            }

            if (value.Dataconsegnaprevistaupdate > DateTime.MinValue)
            {
                IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@dataconsegnaprevistaupdate", DbType.DateTime);
                param24.Value = value.Dataconsegnaprevistaupdate;
                collParams.Add(param24);

                sqlfield += " ,[dataconsegnaprevistaupdate] ";
                sqlvalue += " ,@dataconsegnaprevistaupdate ";
            }

            if (value.Dataconfermaricezione > DateTime.MinValue)
            {
                IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@dataconfermaricezione", DbType.DateTime);
                param25.Value = value.Dataconfermaricezione;
                collParams.Add(param25);

                sqlfield += " ,[dataconfermaricezione] ";
                sqlvalue += " ,@dataconfermaricezione ";
            }

            if (value.Datainviolink > DateTime.MinValue)
            {
                IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@datainviolink", DbType.DateTime);
                param26.Value = value.Datainviolink;
                collParams.Add(param26);

                sqlfield += " ,[datainviolink] ";
                sqlvalue += " ,@datainviolink ";
            }

            string sql = "INSERT INTO EF_ordini ([codsocieta],[UserId],[codjatoauto],[codcarpolicy],[codcarlist],[codfornitore], " +
                         " [numeroordine],[annotazioniordini],[canoneleasing],[deltacanone],[idstatusordine],[idapprovazione],[datauserins], " +
                         " [datausermod],[UserIDIns],[UserIdMod],[motivoscarto],[filefirma],[fileconfermarental],[sederecapito],[canoneleasingofferta]," +
                         " [numeroordinefornitore],[alimentazione],[uidtenant] " + sqlfield + " ) " +
                         " VALUES (@codsocieta,@UserId,@codjatoauto,@codcarpolicy,@codcarlist,@codfornitore,@numeroordine, " +
                         " @annotazioniordini,@canoneleasing,@deltacanone,@idstatusordine,@idapprovazione,@datauserins,@datausermod,@UserIDIns,@UserIdMod, " +
                         " @motivoscarto,@filefirma,@fileconfermarental,@sederecapito,@canoneleasingofferta,@numeroordinefornitore,@alimentazione,@uidtenant " + sqlvalue + " ) ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = value.UserId;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param2.Value = value.Codjatoauto;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param3.Value = value.Codcarpolicy;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param4.Value = value.Codcarlist;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param5.Value = value.Codfornitore;
            collParams.Add(param5);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@numeroordine", DbType.String);
            param8.Value = value.Numeroordine;
            collParams.Add(param8);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@annotazioniordini", DbType.String);
            param17.Value = value.Annotazioniordini;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@canoneleasing", DbType.Decimal);
            param18.Value = value.Canoneleasing;
            collParams.Add(param18);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
            param19.Value = value.Idstatusordine;
            collParams.Add(param19);

            IDbDataParameter param28 = _dataHelper.ProviderConn.CreateDataParameter("@idapprovazione", DbType.Int32);
            param28.Value = value.Idapprovazione;
            collParams.Add(param28);

            IDbDataParameter param27 = _dataHelper.ProviderConn.CreateDataParameter("@deltacanone", DbType.Decimal);
            param27.Value = value.Deltacanone;
            collParams.Add(param27);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param20.Value = DateTime.Now;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param21.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param22.Value = DateTime.Now;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param23.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param23);

            IDbDataParameter param29 = _dataHelper.ProviderConn.CreateDataParameter("@motivoscarto", DbType.String);
            param29.Value = value.Motivoscarto;
            collParams.Add(param29);

            IDbDataParameter param30 = _dataHelper.ProviderConn.CreateDataParameter("@filefirma", DbType.String);
            param30.Value = value.Filefirma;
            collParams.Add(param30);

            IDbDataParameter param31 = _dataHelper.ProviderConn.CreateDataParameter("@fileconfermarental", DbType.String);
            param31.Value = value.Fileconfermarental;
            collParams.Add(param31);

            IDbDataParameter param34 = _dataHelper.ProviderConn.CreateDataParameter("@sederecapito", DbType.String);
            param34.Value = value.Sedelavoro;
            collParams.Add(param34);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@canoneleasingofferta", DbType.Decimal);
            param35.Value = value.Canoneleasingofferta;
            collParams.Add(param35);

            IDbDataParameter param36 = _dataHelper.ProviderConn.CreateDataParameter("@numeroordinefornitore", DbType.String);
            param36.Value = value.Numeroordinefornitore;
            collParams.Add(param36);

            IDbDataParameter param37 = _dataHelper.ProviderConn.CreateDataParameter("@alimentazione", DbType.String);
            param37.Value = value.Alimentazione;
            collParams.Add(param37);

            IDbDataParameter param38 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param38.Value = value.Uidtenant;
            collParams.Add(param38);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli ordine

        public IContratti DetailOrdiniId(Guid Uid)
        {
            IContratti retVal = null;
            string sql = " SELECT * FROM EF_ordini as o LEFT JOIN EF_societa as s ON o.codsocieta = s.codsocieta " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = o.codfornitore WHERE o.Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Idordine = DataHelper.IfDBNull<int>(row["idordine"], 0),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                    Committente = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                    Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                    Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                    Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                    Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                    Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                    Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                    Dataprimaconsegnaprevista = DataHelper.IfDBNull<DateTime>(row["dataprimaconsegnaprevista"], DateTime.MinValue),
                    Dataconsegnaprevista = DataHelper.IfDBNull<DateTime>(row["dataconsegnaprevista"], DateTime.MinValue),
                    Dataconsegnaprevistaupdate = DataHelper.IfDBNull<DateTime>(row["dataconsegnaprevistaupdate"], DateTime.MinValue),
                    Dataconfermaricezione = DataHelper.IfDBNull<DateTime>(row["dataconfermaricezione"], DateTime.MinValue),
                    Datainviolink = DataHelper.IfDBNull<DateTime>(row["datainviolink"], DateTime.MinValue),
                    Annotazioniordini = DataHelper.IfDBNull<string>(row["annotazioniordini"], _stringEmpty),
                    Annotazioniordinirenter = DataHelper.IfDBNull<string>(row["annotazioniordinirenter"], _stringEmpty),
                    Canoneleasing = DataHelper.IfDBNull<decimal>(row["canoneleasing"], 0),
                    Canoneleasingofferta = DataHelper.IfDBNull<decimal>(row["canoneleasingofferta"], 0),
                    Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                    Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                    Motivoscarto = DataHelper.IfDBNull<string>(row["motivoscarto"], _stringEmpty),
                    Filefirma = DataHelper.IfDBNull<string>(row["filefirma"], _stringEmpty),
                    Fileconfermarental = DataHelper.IfDBNull<string>(row["fileconfermarental"], _stringEmpty),
                    Fileordinepdf = DataHelper.IfDBNull<string>(row["fileordinepdf"], _stringEmpty),
                    Data10 = DataHelper.IfDBNull<DateTime>(row["data10"], DateTime.MinValue),
                    Data20 = DataHelper.IfDBNull<DateTime>(row["data20"], DateTime.MinValue),
                    Data25 = DataHelper.IfDBNull<DateTime>(row["data25"], DateTime.MinValue),
                    Data30 = DataHelper.IfDBNull<DateTime>(row["data30"], DateTime.MinValue),
                    Data40 = DataHelper.IfDBNull<DateTime>(row["data40"], DateTime.MinValue),
                    Data50 = DataHelper.IfDBNull<DateTime>(row["data50"], DateTime.MinValue),
                    Data55 = DataHelper.IfDBNull<DateTime>(row["data55"], DateTime.MinValue),
                    Data60 = DataHelper.IfDBNull<DateTime>(row["data60"], DateTime.MinValue),
                    Data100 = DataHelper.IfDBNull<DateTime>(row["data100"], DateTime.MinValue),
                    Data110 = DataHelper.IfDBNull<DateTime>(row["data110"], DateTime.MinValue),
                    Flgaccettato = DataHelper.IfDBNull<string>(row["flgaccettato"], _stringEmpty),
                    Idapprovazione = DataHelper.IfDBNull<int>(row["idapprovazione"], 0),
                    Sedelavoro = DataHelper.IfDBNull<string>(row["sederecapito"], _stringEmpty),
                    Numeroordinefornitore = DataHelper.IfDBNull<string>(row["numeroordinefornitore"], _stringEmpty),
                    Alimentazione = DataHelper.IfDBNull<string>(row["alimentazione"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }


        // conta ordini 
        // FILTRO: codsocieta, UserId, marca, modello, codfornitore, numeroordine, dataordinedal, dataordineal, idstatusordine
        public int SelectCountOrdini(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numeroordine, DateTime dataordinedal, DateTime dataordineal, int idstatusordine, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND codjatoauto IN (SELECT codjatoauto FROM EF_carlist_auto WHERE marca = @marca) ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND codjatoauto IN (SELECT codjatoauto FROM EF_carlist_auto WHERE modello = @modello) ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numeroordine)) condWhere += " AND numeroordine = @numeroordine ";
            if (dataordinedal > DateTime.MinValue) condWhere += " AND dataordine >= @dataordinedal";
            if (dataordineal > DateTime.MinValue) condWhere += " AND dataordine <= @dataordineal";
            if (idstatusordine > 0) condWhere += " AND idstatusordine = @idstatusordine ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_ordini WHERE idordine > 0 AND uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numeroordine))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numeroordine", DbType.String);
                param5.Value = numeroordine;
                collParams.Add(param5);
            }
            if (dataordinedal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@dataordinedal", DbType.DateTime);
                param6.Value = dataordinedal;
                collParams.Add(param6);
            }
            if (dataordineal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@dataordineal", DbType.DateTime);
                param7.Value = dataordineal;
                collParams.Add(param7);
            }
            if (idstatusordine > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param8.Value = idstatusordine;
                collParams.Add(param8);
            }
            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);
            
            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista ordini
        // FILTRO: codsocieta, UserId, marca, modello, codfornitore, numeroordine, dataordinedal, dataordineal, idstatusordine
        public List<IContratti> SelectOrdini(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numeroordine, DateTime dataordinedal, DateTime dataordineal, int idstatusordine, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " dataordine ";
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

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND codjatoauto IN (SELECT codjatoauto FROM EF_carlist_auto WHERE marca = @marca) ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND codjatoauto IN (SELECT codjatoauto FROM EF_carlist_auto WHERE modello = @modello) ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numeroordine)) condWhere += " AND numeroordine = @numeroordine ";
            if (dataordinedal > DateTime.MinValue) condWhere += " AND dataordine >= @dataordinedal";
            if (dataordineal > DateTime.MinValue) condWhere += " AND dataordine <= @dataordineal";
            if (idstatusordine > 0) condWhere += " AND idstatusordine = @idstatusordine ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = "SELECT * FROM EF_ordini WHERE idordine > 0 AND uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numeroordine))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numeroordine", DbType.String);
                param5.Value = numeroordine;
                collParams.Add(param5);
            }
            if (dataordinedal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@dataordinedal", DbType.DateTime);
                param6.Value = dataordinedal;
                collParams.Add(param6);
            }
            if (dataordineal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@dataordineal", DbType.DateTime);
                param7.Value = dataordineal;
                collParams.Add(param7);
            }
            if (idstatusordine > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param8.Value = idstatusordine;
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
                    IContratti item = new Contratti
                    {
                        Idordine = DataHelper.IfDBNull<int>(row["idordine"], 0),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                        Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Dataprimaconsegnaprevista = DataHelper.IfDBNull<DateTime>(row["dataprimaconsegnaprevista"], DateTime.MinValue),
                        Dataconsegnaprevista = DataHelper.IfDBNull<DateTime>(row["dataconsegnaprevista"], DateTime.MinValue),
                        Dataconsegnaprevistaupdate = DataHelper.IfDBNull<DateTime>(row["dataconsegnaprevistaupdate"], DateTime.MinValue),
                        Dataconfermaricezione = DataHelper.IfDBNull<DateTime>(row["dataconfermaricezione"], DateTime.MinValue),
                        Datainviolink = DataHelper.IfDBNull<DateTime>(row["datainviolink"], DateTime.MinValue),
                        Annotazioniordini = DataHelper.IfDBNull<string>(row["annotazioniordini"], _stringEmpty),
                        Canoneleasing = DataHelper.IfDBNull<decimal>(row["canoneleasing"], 0),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Motivoscarto = DataHelper.IfDBNull<string>(row["motivoscarto"], _stringEmpty),
                        Filefirma = DataHelper.IfDBNull<string>(row["filefirma"], _stringEmpty),
                        Fileconfermarental = DataHelper.IfDBNull<string>(row["fileconfermarental"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectAllStatusOrdine(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_ordini_status WHERE uidtenant = @Uidtenant ORDER BY statusordine ";

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
                    IContratti item = new Contratti
                    {
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectAllStatusOrdineAdmin(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_ordini_status WHERE idstatusordine > 0 AND uidtenant = @Uidtenant ORDER BY idstatusordine ";

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
                    IContratti item = new Contratti
                    {
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //ricava utente in base alla datainfrazione e alla targa

        public IContratti ReturnContrattoUser(DateTime datainfrazione, string targa)
        {
            IContratti retVal = null;
            string sql = " SELECT TOP 1 UserId FROM EF_contratti_assegnazioni " +
                         " WHERE targa = @targa AND assegnatodal <= @datainfrazione AND assegnatoal >= @datainfrazione AND idstatusassegnazione = 0 ORDER BY assegnatoal DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@datainfrazione", DbType.DateTime);
            param0.Value = datainfrazione;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param1.Value = targa;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }


        //inserimento nuovo user carpolicy
        public int InsertUserCarPolicy(IContratti value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Dataapprovazione > DateTime.MinValue)
            {
                IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@dataapprovazione", DbType.DateTime);
                param13.Value = value.Dataapprovazione;
                collParams.Add(param13);

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

            if (value.Datadecorrenza > DateTime.MinValue)
            {
                IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datadecorrenza", DbType.DateTime);
                param15.Value = value.Datadecorrenza;
                collParams.Add(param15);

                sqlfield += " ,[datadecorrenza] ";
                sqlvalue += " ,@datadecorrenza ";
            }

            if (value.Datafinedecorrenza > DateTime.MinValue)
            {
                IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@datafinedecorrenza", DbType.DateTime);
                param16.Value = value.Datafinedecorrenza;
                collParams.Add(param16);

                sqlfield += " ,[datafinedecorrenza] ";
                sqlvalue += " ,@datafinedecorrenza ";
            }

            string sql = " INSERT INTO EF_users_carpolicy ([idutente],[codsocieta],[codcarpolicy],[codcarbenefit],[idapprovatore],[flgmail],[approvato],[preassegnazione], " +
                         " [datauserins], [UserIDIns], [datausermod], [UserIdMod],[uidtenant] " + sqlfield + " ) " +
                         " VALUES (@idutente,@codsocieta,@codcarpolicy,@codcarbenefit,@idapprovatore,@flgmail,@approvato,'NO', " +
                         " @datauserins, @UserIDIns, @datausermod, @UserIdMod, @uidtenant " + sqlvalue + " ) ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idutente", DbType.Int32);
            param1.Value = value.Idutente;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param3.Value = value.Codcarpolicy;
            collParams.Add(param3);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@codcarbenefit", DbType.String);
            param17.Value = value.Codcarbenefit;
            collParams.Add(param17);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idapprovatore", DbType.Int32);
            param4.Value = value.Idapprovatore;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@flgmail", DbType.String);
            param5.Value = value.Flgmail;
            collParams.Add(param5);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@approvato", DbType.Int32);
            param8.Value = value.Approvato;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param9.Value = DateTime.Now;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param10.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param11.Value = DateTime.Now;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param12.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param12);

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

        //esistenza users carpolicy
        public bool ExistUserCarPolicyActive(int idutente)
        {
            bool retVal = false;
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");
            string sql = " SELECT idapprovazione FROM EF_users_carpolicy WHERE idutente = @idutente and approvato = 1 " +
                         " and idstatoapprovazione = 0 and flgmail = 1 and datadecorrenza <= @dataoggi and datafinedecorrenza >= @dataoggi ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idutente", DbType.Int32);
            param1.Value = idutente;
            collParams.Add(param1);

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

        //esistenza users carpolicy
        public bool ExistUserCarPolicy(int idutente)
        {
            bool retVal = false;
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");
            string sql = " SELECT idapprovazione FROM EF_users_carpolicy WHERE idutente = @idutente and approvato = 1 " +
                         " and idstatoapprovazione = 0 and flgmail = 1 "; //and datadecorrenza <= @dataoggi

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idutente", DbType.Int32);
            param1.Value = idutente;
            collParams.Add(param1);

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


        //ricava idapprovazione
        public IContratti ReturnIdApprovazione(int idutente)
        {
            IContratti retVal = null;
            string sql = " SELECT TOP 1 idapprovazione FROM EF_users_carpolicy WHERE idutente = @idutente and approvato = 1 and idstatoapprovazione = 0 ORDER BY datauserins DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idutente", DbType.Int32);
            param0.Value = idutente;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Idapprovazione = DataHelper.IfDBNull<int>(row["idapprovazione"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }

        //ricava codcarpolicy in base al codsocieta e al gradecode
        public IContratti ReturnCodCarPolicy(string codsocieta, string gradecode)
        {
            IContratti retVal = null;
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");
            string sql = " SELECT codcarpolicy, codcarbenefit, Uid FROM EF_carpolicy_assegna_societa WHERE codsocieta = @codsocieta AND codgrade = @gradecode and validodal <= @dataoggi and validoal >= @dataoggi ";

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
                retVal = new Contratti
                {
                    Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                    Codcarbenefit = DataHelper.IfDBNull<string>(row["codcarbenefit"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }



        // lista carpolicy da approvare
        // FILTRO: carpolicy, UserId, codsocieta
        public List<IContratti> SelectUserCarPolicyDaApprovare(string carpolicy, Guid UserId, string codsocieta, Guid Uidtenant, int numrecord, int pagina)
        {
            string condWhere = "";
            string paginazione;

            if (numrecord == 0)
            {
                numrecord = 200;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(carpolicy)) condWhere += " AND c.codcarpolicy = @carpolicy ";
            if (UserId != Guid.Empty) condWhere += " AND u.UserId = @UserId ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT c.idapprovazione, c.Uid, c.codcarpolicy, u.nome, u.cognome, u.matricola, g.grade FROM EF_users_carpolicy as c " +
                         " INNER JOIN EF_users as u ON c.idutente = u.iduser AND c.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND c.uidtenant = g.uidtenant " +
                         " WHERE c.approvato = 0 AND c.codsocieta = @codsocieta " + condWhere + " ORDER BY u.cognome, u.nome " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(carpolicy))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@carpolicy", DbType.String);
                param0.Value = carpolicy;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Idapprovazione = DataHelper.IfDBNull<int>(row["idapprovazione"], 0),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        // conta carpolicy da approvare
        // FILTRO: carpolicy, UserId, codsocieta
        public int SelectCountUserCarPolicyDaApprovare(string carpolicy, Guid UserId, string codsocieta, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(carpolicy)) condWhere += " AND c.codcarpolicy = @carpolicy ";
            if (UserId != Guid.Empty) condWhere += " AND u.UserId = @UserId ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_users_carpolicy as c INNER JOIN EF_users as u ON c.idutente = u.iduser AND c.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND c.uidtenant = g.uidtenant " +
                         " WHERE c.approvato = 0 AND c.codsocieta = @codsocieta " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(carpolicy))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@carpolicy", DbType.String);
                param0.Value = carpolicy;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista carpolicy approvati
        // FILTRO: keysearch, codsocieta, flgmail
        public List<IContratti> SelectUserCarPolicyApprovati(string keysearch, string codsocieta, int flgmail, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND c.codcarpolicy = @keysearch ";
            if (flgmail > -1) condWhere += " AND c.flgmail = @flgmail ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT c.datadecorrenza, c.dataapprovazione, c.datamail, c.idapprovazione, c.Uid, c.codcarpolicy, u.nome, u.cognome, c.preassegnazione, u1.nome as nomeapprovatore, u1.cognome as cognomeapprovatore FROM EF_users_carpolicy as c " +
                         " INNER JOIN EF_users as u ON c.idutente = u.iduser AND c.uidtenant = u.uidtenant " +
                         " INNER JOIN EF_users as u1 ON c.idapprovatore = u1.iduser AND c.uidtenant = u1.uidtenant " +
                         " WHERE c.approvato = 1 AND c.codsocieta = @codsocieta " + condWhere + " ORDER BY c.dataapprovazione DESC, c.datamail DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (flgmail > -1)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@flgmail", DbType.Int32);
                param3.Value = flgmail;
                collParams.Add(param3);
            }

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Idapprovazione = DataHelper.IfDBNull<int>(row["idapprovazione"], 0),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognomeapprovatore"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nomeapprovatore"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Preassegnazione = DataHelper.IfDBNull<string>(row["preassegnazione"], _stringEmpty),
                        Dataapprovazione = DataHelper.IfDBNull<DateTime>(row["dataapprovazione"], DateTime.MinValue),
                        Datadecorrenza = DataHelper.IfDBNull<DateTime>(row["datadecorrenza"], DateTime.MinValue),
                        Datamail = DataHelper.IfDBNull<DateTime>(row["datamail"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        // conta carpolicy approvati
        // FILTRO: keysearch, codsocieta, flgmail
        public int SelectCountUserCarPolicyApprovati(string keysearch, string codsocieta, int flgmail, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND c.codcarpolicy = @keysearch ";
            if (flgmail > -1) condWhere += " AND c.flgmail = @flgmail ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_users_carpolicy as c INNER JOIN EF_users as u ON c.idutente = u.iduser AND c.uidtenant = u.uidtenant " +
                         " WHERE c.approvato = 1 AND c.codsocieta = @codsocieta " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (flgmail > -1)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@flgmail", DbType.Int32);
                param3.Value = flgmail;
                collParams.Add(param3);
            }

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        //dettagli user carpolicy
        public IContratti DetailUserCarPolicyId(Guid Uid)
        {
            IContratti retVal = null;
            string sql = " SELECT s.societa, u.nome, u.cognome, u.matricola, u.cellulare, u.email, u.dataassunzione, u.UserId, c.datamail, c.checkcarpolicy, g.grade, c.documentopatente, " +
                         " c.codcarpolicy, c.approvato, c.Uid, c.preassegnazione, c.documentocarpolicy, c.datadecorrenza, c.datafinedecorrenza, c.documentofuelcard, " +
                         " u1.nome as nomeappr, u1.cognome as cognomeappr, c.dataapprovazione FROM EF_users_carpolicy as c " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta " +
                         " INNER JOIN EF_users as u ON c.idutente = u.iduser " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode " +
                         " LEFT JOIN EF_users as u1 ON c.idutentecheck = u1.UserId WHERE c.Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                    Codsocieta = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                    Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                    Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                    Cellulare = DataHelper.IfDBNull<string>(row["cellulare"], _stringEmpty),
                    Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                    Preassegnazione = DataHelper.IfDBNull<string>(row["preassegnazione"], _stringEmpty),
                    Dataassunzione = DataHelper.IfDBNull<DateTime>(row["dataassunzione"], DateTime.MinValue),
                    Approvato = DataHelper.IfDBNull<int>(row["approvato"], 0),
                    Documentocarpolicy = DataHelper.IfDBNull<string>(row["documentocarpolicy"], _stringEmpty),
                    Documentopatente = DataHelper.IfDBNull<string>(row["documentopatente"], _stringEmpty),
                    Documentofuelcard = DataHelper.IfDBNull<string>(row["documentofuelcard"], _stringEmpty),
                    Datadecorrenza = DataHelper.IfDBNull<DateTime>(row["datadecorrenza"], DateTime.MinValue),
                    Datafinedecorrenza = DataHelper.IfDBNull<DateTime>(row["datafinedecorrenza"], DateTime.MinValue),
                    Datamail = DataHelper.IfDBNull<DateTime>(row["datamail"], DateTime.MinValue),
                    Checkcarpolicy = DataHelper.IfDBNull<string>(row["checkcarpolicy"], _stringEmpty),
                    Cognome = DataHelper.IfDBNull<string>(row["cognomeappr"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nomeappr"], _stringEmpty),
                    Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                    Dataapprovazione = DataHelper.IfDBNull<DateTime>(row["dataapprovazione"], DateTime.MinValue),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }

        //lista carpolicy
        public List<IContratti> SelectCarPolicy(string codsocieta, Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT distinct s.codcarpolicy, c.excodcarpolicy FROM EF_carpolicy_assegna_societa as s " +
                         " INNER JOIN EF_carpolicy as c ON c.codcarpolicy = s.codcarpolicy AND c.uidtenant = s.uidtenant " +
                         " WHERE s.validodal <= Getdate() and s.validoal >= Getdate() and s.codsocieta = @codsocieta AND s.uidtenant = @Uidtenant ORDER BY s.codcarpolicy ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param2.Value = codsocieta;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Excodcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["excodcarpolicy"], _stringEmpty) + ")"
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //stato approva user carpolicy
        public int UpdateApprovaCarPolicy(Guid Uid, string codcarpolicy, string preassegnazione, DateTime datadecorrenza, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users_carpolicy SET [approvato] = 1, [dataapprovazione] = @dataapprovazione, [datadecorrenza] = @datadecorrenza, datafinedecorrenza = @datafinedecorrenza, " +
                         " [codcarpolicy] = @codcarpolicy, [preassegnazione] = @preassegnazione, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod  WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@dataapprovazione", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@datadecorrenza", DbType.Date);
            param25.Value = datadecorrenza;
            collParams.Add(param25);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@datafinedecorrenza", DbType.Date);
            param26.Value = datadecorrenza.AddMonths(1);
            collParams.Add(param26);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param23.Value = codcarpolicy;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@preassegnazione", DbType.String);
            param24.Value = preassegnazione;
            collParams.Add(param24);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param4.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param5.Value = DateTime.Now;
            collParams.Add(param5);

            IDbDataParameter param72 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param72.Value = Uidtenant;
            collParams.Add(param72);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }

        //invio mail user carpolicy
        public int UpdateInvioMailCarPolicy(Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users_carpolicy SET [flgmail] = 1, [datamail] = @datamail  WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datamail", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

            IDbDataParameter param72 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param72.Value = Uidtenant;
            collParams.Add(param72);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //lista carpolicy pool
        public List<IContratti> SelectCarPolicyPool(string codsocieta, string gradepool)
        {
            string condWhere = "";

            if (!string.IsNullOrEmpty(gradepool)) condWhere += " and (gradepool = @gradepool OR gradepool = '' OR gradepool is null) ";

            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT ca.marca, ca.modello, ca.cilindrata, ca.alimentazione, c.Uid, ca.fotoauto, c.deltacanone FROM EF_contratti as c " +
                         " INNER JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto AND ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore " +
                         " WHERE c.codsocieta = @codsocieta and checkpool = 1 and checkordinepool = 1 " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param2.Value = codsocieta;
            collParams.Add(param2);

            if (!string.IsNullOrEmpty(gradepool))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@gradepool", DbType.String);
                param3.Value = gradepool;
                collParams.Add(param3);
            }

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Cilindrata = DataHelper.IfDBNull<string>(row["cilindrata"], _stringEmpty),
                        Alimentazione = DataHelper.IfDBNull<string>(row["alimentazione"], _stringEmpty),
                        Fotoauto = DataHelper.IfDBNull<string>(row["fotoauto"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountCarPolicyPool(string codsocieta, string gradepool)
        {
            string condWhere = "";

            if (!string.IsNullOrEmpty(gradepool)) condWhere += " and (gradepool = @gradepool OR gradepool = '' OR gradepool is null) ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_contratti as c " +
                         " INNER JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto AND ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore " +
                         " WHERE c.codsocieta = @codsocieta and checkpool = 1 and checkordinepool = 1 " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param2.Value = codsocieta;
            collParams.Add(param2);

            if (!string.IsNullOrEmpty(gradepool))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@gradepool", DbType.String);
                param3.Value = gradepool;
                collParams.Add(param3);
            }

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        //lista carpolicy step2
        public List<IContratti> SelectCarPolicyStep2(int idutente)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT a.* FROM EF_carlist_auto as a " +
                         " INNER JOIN EF_carpolicy AS c ON a.codcarlist = c.codcarlist " +
                         " INNER JOIN EF_users_carpolicy as u ON c.codcarpolicy = u.codcarpolicy " +
                         " WHERE u.idutente = @idutente and approvato = '1' and idstatoapprovazione = '0' and visibile='ATTIVO' and datafinedecorrenza >= GETDATE() ORDER BY idapprovazione DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@idutente", DbType.Int32);
            param2.Value = idutente;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Cilindrata = DataHelper.IfDBNull<string>(row["cilindrata"], _stringEmpty),
                        Alimentazione = DataHelper.IfDBNull<string>(row["alimentazione"], _stringEmpty),
                        Fotoauto = DataHelper.IfDBNull<string>(row["fotoauto"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountCarPolicyStep2(int idutente)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_carlist_auto as a " +
                         " INNER JOIN EF_carpolicy AS c ON a.codcarlist = c.codcarlist " +
                         " INNER JOIN EF_users_carpolicy as u ON c.codcarpolicy = u.codcarpolicy " +
                         " WHERE u.idutente = @idutente and approvato = '1' and idstatoapprovazione = '0' ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@idutente", DbType.Int32);
            param2.Value = idutente;
            collParams.Add(param2);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        //ricava codcarlist in base al codcarpolicy
        public IContratti ReturnCodCarList(string codcarpolicy)
        {
            IContratti retVal = null;
            string sql = " SELECT codcarlist FROM EF_carpolicy WHERE codcarpolicy = @codcarpolicy ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param0.Value = codcarpolicy;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }


        //ricava ultimo idordine
        public IContratti ReturnUltimoIdOrdine()
        {
            IContratti retVal = null;
            string sql = " SELECT idordine, Uid FROM EF_ordini ORDER BY idordine DESC ";

            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Idordine = DataHelper.IfDBNull<int>(row["idordine"], 0),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }

        //inserimento nuovo ordine optional
        public int InsertOrdineOptional(IContratti value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_ordini_optional ([idordine],[codoptional],[importooptional],[giorniconsegnaagg],[uidtenant]) " +
                         " VALUES (@idordine,@codoptional,@importooptional,@giorniconsegnaagg,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idordine", DbType.Int32);
            param0.Value = value.Idordine;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codoptional", DbType.String);
            param1.Value = value.Codoptional;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@importooptional", DbType.Decimal);
            param2.Value = value.Importooptional;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@giorniconsegnaagg", DbType.Int32);
            param3.Value = value.Giorniconsegnaagg;
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


        public int UpdateOrdineOptional(IContratti value)
        {
            int retVal = 0;

            string sql = "UPDATE EF_ordini_optional SET [importooptional] = @importooptional WHERE [idordine] = @idordine AND [codoptional] = @codoptional AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idordine", DbType.Int32);
            param0.Value = value.Idordine;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codoptional", DbType.String);
            param1.Value = value.Codoptional;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@importooptional", DbType.Decimal);
            param2.Value = value.Importooptional;
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

        //ricava ultimo numeroordine
        public IContratti ReturnUltimoNumeroOrdine()
        {
            IContratti retVal = null;
            string sql = " SELECT CAST(numeroordine as int) as numeroordine FROM EF_ordini ORDER BY numeroordine DESC ";

            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Nconfigurazioni = DataHelper.IfDBNull<int>(row["numeroordine"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }

        //conta configurazioni effettuate
        public int SelectCountConfigurazioni(int idapprovazione)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini WHERE idapprovazione = @idapprovazione  AND idstatusordine > 0 AND idstatusordine < 100 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idapprovazione", DbType.Int32);
            param0.Value = idapprovazione;
            collParams.Add(param0);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        // conta richieste ordini
        // FILTRO: keysearch, UserId, idstatusordine
        public int SelectCountRichiesteOrdini(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (idstatusordine > 0) condWhere += " AND o.idstatusordine = @idstatusordine ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND g.codgrade = @codgrade ";
            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " AND o.codcarlist = @codcarlist ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND o.codfornitore = @codfornitore ";
            if (datadal > DateTime.MinValue) condWhere += " AND o.dataordine >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND o.dataordine <= @dataal";

            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId AND o.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore AND o.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta AND o.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist as cl ON cl.codcarlist = o.codcarlist AND o.uidtenant = cl.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = o.codfornitore AND o.uidtenant = f.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND g.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine AND o.uidtenant = os.uidtenant " +
                         " WHERE o.idordine > 0 AND o.idstatusordine <> 0 AND o.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (idstatusordine > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param1.Value = idstatusordine;
                collParams.Add(param1);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param4.Value = codgrade;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param5.Value = codcarlist;
                collParams.Add(param5);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param6.Value = codfornitore;
                collParams.Add(param6);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
                collParams.Add(param8);
            }

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);
            
            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista richieste ordini
        // FILTRO: keysearch, UserId, idstatusordine
        public List<IContratti> SelectRichiesteOrdini(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (idstatusordine > -1) condWhere += " AND o.idstatusordine = @idstatusordine ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND g.codgrade = @codgrade ";
            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " AND o.codcarlist = @codcarlist ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND o.codfornitore = @codfornitore ";
            if (datadal > DateTime.MinValue) condWhere += " AND o.dataordine >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND o.dataordine <= @dataal";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.codjatoauto, ca.modello, ca.marca, cl.codcarlist, s.siglasocieta, g.grade, o.dataordine, o.numeroordine, o.Uid, u.cognome, o.dataconsegnaprevista, " +
                         " u.nome, u.matricola, os.statusordine, o.idstatusordine, o.deltacanone, u.iduser, f.fornitore, o.fileordinepdf, o.codfornitore FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId AND o.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore AND o.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta AND o.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist as cl ON cl.codcarlist = o.codcarlist AND o.uidtenant = cl.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = o.codfornitore AND o.uidtenant = f.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND g.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine AND o.uidtenant = os.uidtenant " +
                         " WHERE o.idordine > 0 AND o.idstatusordine <> 0 AND o.uidtenant = @Uidtenant " + condWhere +
                         " ORDER BY o.dataordine DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (idstatusordine > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param1.Value = idstatusordine;
                collParams.Add(param1);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param4.Value = codgrade;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param5.Value = codcarlist;
                collParams.Add(param5);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param6.Value = codfornitore;
                collParams.Add(param6);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
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
                    IContratti item = new Contratti
                    {
                        Idutente = DataHelper.IfDBNull<int>(row["iduser"], 0),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                        Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty),
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Fileordinepdf = DataHelper.IfDBNull<string>(row["fileordinepdf"], _stringEmpty),
                        Dataconsegnaprevista = DataHelper.IfDBNull<DateTime>(row["dataconsegnaprevista"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //cambia stato ordine
        public int UpdateChangeStatusOrdine(Guid Uid, int idstatusordine, string motivoscarto, Guid Uidtenant)
        {
            int retVal = 0;
            string sqlupd = SeoHelper.CampoDataStatusOrdine(idstatusordine) + " = @data ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_ordini SET [idstatusordine] = @idstatusordine, [motivoscarto] = @motivoscarto, " + sqlupd + " WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
            param21.Value = idstatusordine;
            collParams.Add(param21);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@motivoscarto", DbType.String);
            param23.Value = motivoscarto;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@data", DbType.DateTime);
            param24.Value = DateTime.Now;
            collParams.Add(param24);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

            IDbDataParameter param72 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param72.Value = Uidtenant;
            collParams.Add(param72);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }

        //conferma ordine rental
        public int UpdateOrdineConfermaRental(Guid Uid, int idstatusordine, string fileconfermarental, DateTime dataconsegnaprevista, string annotazioniordini, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_ordini SET [idstatusordine] = @idstatusordine, [fileconfermarental] = @fileconfermarental, [annotazioniordinirenter] = @annotazioniordini ";

            if (dataconsegnaprevista > DateTime.MinValue)
            {
                sql += " ,[dataconsegnaprevista] = @dataconsegnaprevista ";
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@dataconsegnaprevista", DbType.DateTime);
                param10.Value = dataconsegnaprevista;
                collParams.Add(param10);
            }

            sql += " WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
            param21.Value = idstatusordine;
            collParams.Add(param21);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@fileconfermarental", DbType.String);
            param23.Value = fileconfermarental;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@annotazioniordini", DbType.String);
            param24.Value = annotazioniordini;
            collParams.Add(param24);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

            IDbDataParameter param72 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param72.Value = Uidtenant;
            collParams.Add(param72);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }



        // conta richieste ordini rental
        // FILTRO: keysearch, UserId
        public int SelectCountRichiesteOrdiniRental(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (idstatusordine > 0)
            {
                condWhere += " AND o.idstatusordine = @idstatusordine ";
            }
            else
            {
                condWhere += " AND o.idstatusordine IN (10,20,25,30,40,50) ";
            }
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (datadal > DateTime.MinValue) condWhere += " AND o.dataordine >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND o.dataordine <= @dataal";

            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine " +
                         " WHERE o.codfornitore = @codfornitore " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (idstatusordine > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param1.Value = idstatusordine;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param6.Value = codsocieta;
                collParams.Add(param6);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
                collParams.Add(param8);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param3.Value = codfornitore;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista richieste ordini rental
        // FILTRO: keysearch, UserId
        public List<IContratti> SelectRichiesteOrdiniRental(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (idstatusordine > 0)
            {
                condWhere += " AND o.idstatusordine = @idstatusordine ";
            }
            else
            {
                condWhere += " AND o.idstatusordine IN (10,20,25,30,40,50) ";
            }
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (datadal > DateTime.MinValue) condWhere += " AND o.dataordine >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND o.dataordine <= @dataal";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.codjatoauto, ca.modello, ca.marca, o.codcarlist, s.siglasocieta, g.grade, o.dataordine, o.numeroordine, o.Uid, u.cognome, " +
                         " u.nome, u.matricola, u.cellulare, u.email, o.sederecapito, os.statusordine, o.idstatusordine, o.deltacanone, o.idordine, o.fileordinepdf, " +
                         " (SELECT DISTINCT ao.optional FROM EF_ordini_optional as o1 LEFT JOIN EF_carlist_optional as ao ON ao.codoptional = o1.codoptional " +
                         " WHERE o1.codoptional IN (SELECT codoptional FROM EF_carlist_optional WHERE codcategoriaoptional = 'COL') and o.idordine = o1.idordine) as colore " + 
                         " FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine " +
                         " WHERE o.codfornitore = @codfornitore " + condWhere +
                         " ORDER BY o.dataordine DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (idstatusordine > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param1.Value = idstatusordine;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param6.Value = codsocieta;
                collParams.Add(param6);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
                collParams.Add(param8);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param3.Value = codfornitore;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Idordine = DataHelper.IfDBNull<int>(row["idordine"], 0),
                        Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty),
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                        Fileordinepdf = DataHelper.IfDBNull<string>(row["fileordinepdf"], _stringEmpty),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Cellulare = DataHelper.IfDBNull<string>(row["cellulare"], _stringEmpty),
                        Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                        Sedelavoro = DataHelper.IfDBNull<string>(row["sederecapito"], _stringEmpty),
                        Codcolore = DataHelper.IfDBNull<string>(row["colore"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        // conta richieste ordini driver
        // FILTRO: keysearch, UserId
        public int SelectCountRichiesteOrdiniDriver(string keysearch, Guid UserId)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine " +
                         " WHERE o.idstatusordine = 30 and o.UserId = @UserId " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param2.Value = UserId;
            collParams.Add(param2);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista richieste ordini driver
        // FILTRO: keysearch, UserId
        public List<IContratti> SelectRichiesteOrdiniDriver(string keysearch, Guid UserId, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.codjatoauto, ca.modello, o.codcarlist, s.societa, g.grade, o.dataordine, o.numeroordine, o.Uid, u.cognome, " +
                         " u.nome, u.matricola, os.statusordine, o.idstatusordine, o.deltacanone FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine " +
                         " WHERE o.idstatusordine = 30 and o.UserId = @UserId " + condWhere +
                         " ORDER BY o.dataordine DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
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
                    IContratti item = new Contratti
                    {
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty),
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //dettagli veicolo attuale driver
        public IContratti DetailVeicoloAttualeDriver(Guid UserId)
        {
            IContratti retVal = null;
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");

            string sql = " SELECT TOP 1 ca.targa, cr.modello, c.datafinecontratto, ct.tipocontratto, c.duratamesi, c.kmcontratto, f.fornitore, c.datarevisione, " +
                         " c.idcontratto, ca.assegnatodal, ca.assegnatoal, c.numerocontratto, cr.fotoauto, c.filelibrettoautocontratto, c.Uid, c.Uidordine FROM  EF_contratti as c " +
                         " LEFT JOIN EF_contratti_assegnazioni as ca ON ca.idcontratto = c.idcontratto" +
                         " LEFT JOIN EF_contratti_tipo as ct ON ct.codtipocontratto = c.codtipocontratto" +
                         " LEFT JOIN EF_carlist_auto as cr ON cr.codjatoauto = c.codjatoauto and cr.codcarlist = c.codcarlist " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = c.codfornitore" +
                         " WHERE c.UserId = @UserId and ca.assegnatoal >= @dataoggi and c.idstatuscontratto<=20 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.DateTime);
            param1.Value = dataoggi;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                    Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                    Tipocontratto = DataHelper.IfDBNull<string>(row["tipocontratto"], _stringEmpty),
                    Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                    Duratamesi = DataHelper.IfDBNull<int>(row["duratamesi"], 0),
                    Kmcontratto = DataHelper.IfDBNull<int>(row["kmcontratto"], 0),
                    Idcontratto = DataHelper.IfDBNull<int>(row["idcontratto"], 0),
                    Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                    Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                    Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                    Fotoauto = DataHelper.IfDBNull<string>(row["fotoauto"], _stringEmpty),
                    Datarevisione = DataHelper.IfDBNull<DateTime>(row["datarevisione"], DateTime.MinValue),
                    Filelibrettoautocontratto = DataHelper.IfDBNull<string>(row["filelibrettoautocontratto"], _stringEmpty),
                    Uidordine = DataHelper.IfDBNull<Guid>(row["Uidordine"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        //dettagli veicolo attuale partner
        public IContratti DetailVeicoloAttualePartner(Guid UserId)
        {
            IContratti retVal = null;

            string sql = " SELECT TOP 1 ca.targa, cr.modello, c.datafinecontratto, ct.tipocontratto, c.duratamesi, c.kmcontratto, f.fornitore, c.datarevisione, " +
                         " c.idcontratto, ca.assegnatodal, ca.assegnatoal, c.numerocontratto, cr.fotoauto FROM  EF_contratti as c " +
                         " LEFT JOIN EF_contratti_assegnazioni as ca ON ca.idcontratto = c.idcontratto" +
                         " LEFT JOIN EF_contratti_tipo as ct ON ct.codtipocontratto = c.codtipocontratto" +
                         " LEFT JOIN EF_carlist_auto as cr ON cr.codjatoauto = c.codjatoauto and cr.codcarlist = c.codcarlist " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = c.codfornitore" +
                         " WHERE c.UserId = @UserId ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                    Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                    Tipocontratto = DataHelper.IfDBNull<string>(row["tipocontratto"], _stringEmpty),
                    Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                    Duratamesi = DataHelper.IfDBNull<int>(row["duratamesi"], 0),
                    Kmcontratto = DataHelper.IfDBNull<int>(row["kmcontratto"], 0),
                    Idcontratto = DataHelper.IfDBNull<int>(row["idcontratto"], 0),
                    Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                    Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                    Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                    Fotoauto = DataHelper.IfDBNull<string>(row["fotoauto"], _stringEmpty),
                    Datarevisione = DataHelper.IfDBNull<DateTime>(row["datarevisione"], DateTime.MinValue),
                };
                data.Dispose();
            }
            return retVal;
        }


        //inserimento km percorsi driver
        public int InsertKmPercorsi(IContratti value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_contratti_percorrenze ([kmpercorsi],[datains],[UserId],[targa],[uidtenant]) " +
                         " VALUES (@kmpercorsi,@datains,@UserId,@targa,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@kmpercorsi", DbType.Decimal);
            param0.Value = value.Kmpercorsi;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@datains", DbType.DateTime);
            param1.Value = value.Datains;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param3.Value = value.UserId;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param4.Value = value.Targa;
            collParams.Add(param4);

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

        //lista km percorsi driver
        public List<IContratti> SelectKmPercorsi(Guid UserId, string targa)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT TOP 1 datains, kmpercorsi FROM EF_contratti_percorrenze WHERE UserId = @UserId and targa = @targa ORDER BY datains DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = UserId;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param2.Value = targa;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Datains = DataHelper.IfDBNull<DateTime>(row["datains"], DateTime.MinValue),
                        Kmpercorsi = DataHelper.IfDBNull<decimal>(row["kmpercorsi"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //lista km percorsi per targa
        public List<IContratti> SelectKmPercorsiXTarga(string targa)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT datains, kmpercorsi FROM EF_contratti_percorrenze WHERE targa = @targa ORDER BY datains DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param2.Value = targa;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Datains = DataHelper.IfDBNull<DateTime>(row["datains"], DateTime.MinValue),
                        Kmpercorsi = DataHelper.IfDBNull<decimal>(row["kmpercorsi"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        // lista Volture
        // FILTRO: codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto
        public List<IContratti> SelectVolture(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " c.datacontratto ";
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

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND c.codjatoauto IN (SELECT codjatoauto FROM EF_carlist_auto WHERE marca = @marca) ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND c.codjatoauto IN (SELECT codjatoauto FROM EF_carlist_auto WHERE modello = @modello) ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND c.datacontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND c.datacontratto <= @datacontrattoal";
            if (idstatuscontratto > 0) condWhere += " AND c.idstatuscontratto = @idstatuscontratto ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT c.codsocieta, u.cognome, u.nome, u.matricola, c.codjatoauto, c.codfornitore, c.numerocontratto, c.datacontratto, s.statuscontratto, c.Uid FROM EF_contratti as c " +
                         " LEFT JOIN EF_users as u ON c.UserId = u.UserId AND c.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_contratti_status as s ON c.idstatuscontratto = s.idstatuscontratto AND c.uidtenant = s.uidtenant " +
                         " WHERE c.flgvoltura = 1 AND c.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param3.Value = modello;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatuscontratto > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
                param8.Value = idstatuscontratto;
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
                    IContratti item = new Contratti
                    {
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                        Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Statuscontratto = DataHelper.IfDBNull<string>(row["statuscontratto"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        // conta volture 
        // FILTRO: codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto
        public int SelectCountVolture(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND c.codjatoauto IN (SELECT codjatoauto FROM EF_carlist_auto WHERE marca = @marca) ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND c.codjatoauto IN (SELECT codjatoauto FROM EF_carlist_auto WHERE modello = @modello) ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND c.datacontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND c.datacontratto <= @datacontrattoal";
            if (idstatuscontratto > 0) condWhere += " AND c.idstatuscontratto = @idstatuscontratto ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_contratti as c LEFT JOIN EF_users as u ON c.UserId = u.UserId AND c.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_contratti_status as s ON c.idstatuscontratto = s.idstatuscontratto AND c.uidtenant = s.uidtenant WHERE c.flgvoltura = 1 AND c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param3.Value = modello;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatuscontratto > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
                param8.Value = idstatuscontratto;
                collParams.Add(param8);
            }

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);            

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public List<IContratti> SelectContrattiXVolture(Guid Uidtenant)
        {
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");
            string driver;
            string scadenza;

            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT c.targa, c.numerocontratto, u.nome, u.cognome, c.Uid, c.datafinecontratto FROM EF_contratti as c " +
                         " INNER JOIN EF_users as u ON c.UserId = u.UserId AND c.uidtenant = u.uidtenant WHERE idstatuscontratto = 0 AND c.uidtenant = @Uidtenant AND datafinecontratto > @dataoggi ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.DateTime);
            param1.Value = dataoggi;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti();
                    driver = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty);
                    scadenza = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty) + " " + DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.Now).ToString("dd/MM/yyyy");
                    item.Codjatoauto = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty) + " - " + driver + " - " + scadenza;
                    item.Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty);
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //cambia status contratto
        public int UpdateChangeStatusContratto(Guid Uid, int idstatuscontratto, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti SET [idstatuscontratto] = @idstatuscontratto WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
            param21.Value = idstatuscontratto;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

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

        //aggiorna contratto fine voltura
        public int UpdateContrattiXVoltura(IContratti value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_contratti SET [idstatuscontratto] = @idstatuscontratto, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod, [datafinecontratto] = @datafinecontratto, " +
                         " [flgvoltura] = @flgvoltura, [notevoltura] = @notevoltura, [Uidcontrattovolturato] = @Uidcontrattovolturato WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@datafinecontratto", DbType.DateTime);
            param16.Value = value.Datafinecontratto;
            collParams.Add(param16);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
            param19.Value = value.Idstatuscontratto;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param20.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param32 = _dataHelper.ProviderConn.CreateDataParameter("@flgvoltura", DbType.Int32);
            param32.Value = value.Flgvoltura;
            collParams.Add(param32);

            IDbDataParameter param33 = _dataHelper.ProviderConn.CreateDataParameter("@notevoltura", DbType.String);
            param33.Value = value.Notevoltura;
            collParams.Add(param33);

            IDbDataParameter param34 = _dataHelper.ProviderConn.CreateDataParameter("@Uidcontrattovolturato", DbType.Guid);
            param34.Value = value.Uidcontrattovolturato;
            collParams.Add(param34);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param35.Value = value.Uid;
            collParams.Add(param35);

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



        // lista Volture da autorizzare
        // FILTRO: codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal
        public List<IContratti> SelectVoltureDaAutorizzare(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " datacontratto ";
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

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND codjatoauto IN (SELECT codjatoauto FROM EF_carlist_auto WHERE marca = @marca) ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND codjatoauto IN (SELECT codjatoauto FROM EF_carlist_auto WHERE modello = @modello) ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND datacontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND datacontratto <= @datacontrattoal";

            List<IContratti> retVal = new List<IContratti>();
            string sql = "SELECT * FROM EF_contratti WHERE flgvoltura = 1 AND idstatuscontratto = 40 AND uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param3.Value = modello;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
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
                    IContratti item = new Contratti
                    {
                        Idcontratto = DataHelper.IfDBNull<int>(row["idcontratto"], 0),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                        Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Codtipocontratto = DataHelper.IfDBNull<string>(row["codtipocontratto"], _stringEmpty),
                        Codtipousocontratto = DataHelper.IfDBNull<string>(row["codtipousocontratto"], _stringEmpty),
                        Numordineordine = DataHelper.IfDBNull<string>(row["numordineordine"], _stringEmpty),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Duratamesi = DataHelper.IfDBNull<int>(row["duratamesi"], 0),
                        Kmcontratto = DataHelper.IfDBNull<int>(row["kmcontratto"], 0),
                        Franchigia = DataHelper.IfDBNull<decimal>(row["franchigia"], 0),
                        Datainiziocontratto = DataHelper.IfDBNull<DateTime>(row["datainiziocontratto"], DateTime.MinValue),
                        Datainiziouso = DataHelper.IfDBNull<DateTime>(row["datainiziouso"], DateTime.MinValue),
                        Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                        Annotazionicontratto = DataHelper.IfDBNull<string>(row["annotazionicontratto"], _stringEmpty),
                        Canoneleasing = DataHelper.IfDBNull<decimal>(row["canoneleasing"], 0),
                        Idstatuscontratto = DataHelper.IfDBNull<int>(row["idstatuscontratto"], 0),
                        Filecontratto = DataHelper.IfDBNull<string>(row["filecontratto"], _stringEmpty),
                        Bollo = DataHelper.IfDBNull<decimal>(row["bollo"], 0),
                        Superbollo = DataHelper.IfDBNull<decimal>(row["superbollo"], 0),
                        Dataimmatricolazione = DataHelper.IfDBNull<DateTime>(row["dataimmatricolazione"], DateTime.MinValue),
                        Scadenzabollo = DataHelper.IfDBNull<DateTime>(row["scadenzabollo"], DateTime.MinValue),
                        Scadenzasuperbollo = DataHelper.IfDBNull<DateTime>(row["scadenzasuperbollo"], DateTime.MinValue),
                        Uidordine = DataHelper.IfDBNull<Guid>(row["Uidordine"], Guid.Empty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        // conta volture da autorizzare
        // FILTRO: codsocieta, UserId, marca, modello, codfornitore, numerocontratto, datacontrattodal, datacontrattoal
        public int SelectCountVoltureDaAutorizzare(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND codjatoauto IN (SELECT codjatoauto FROM EF_carlist_auto WHERE marca = @marca) ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND codjatoauto IN (SELECT codjatoauto FROM EF_carlist_auto WHERE modello = @modello) ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND datacontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND datacontratto <= @datacontrattoal";

            string SQL = "SELECT COUNT(*) as tot FROM EF_contratti WHERE flgvoltura = 1 and idstatuscontratto = 40 AND uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param3.Value = modello;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param8.Value = Uidtenant;
            collParams.Add(param8);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        //contratto scaduto per voltura
        public int UpdateContrattoVolturato(Guid Uid, DateTime datafinecontratto, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti SET [idstatuscontratto] = 100, [datafinecontratto] = @datafinecontratto WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@datafinecontratto", DbType.DateTime);
            param23.Value = datafinecontratto;
            collParams.Add(param23);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param2.Value = Uidtenant;
            collParams.Add(param2);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        // conta richieste ordini per driver
        // FILTRO: UserId
        public int SelectCountRichiesteOrdiniXDriver(Guid UserId)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId and o.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore and ca.uidtenant = o.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta and s.uidtenant = o.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode and g.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine and os.uidtenant = o.uidtenant " +
                         " WHERE o.UserId = @UserId ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param2.Value = UserId;
            collParams.Add(param2);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista richieste ordini per driver
        // FILTRO: UserId
        public List<IContratti> SelectRichiesteOrdiniXDriver(Guid UserId)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.codjatoauto, ca.modello, ca.marca, o.codcarlist, s.societa, g.grade, o.dataordine, o.numeroordine, o.Uid, " +
                         " os.statusordine, o.idstatusordine, o.deltacanone, o.idordine, o.dataconsegnaprevista FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId and o.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore and ca.uidtenant = o.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta and s.uidtenant = o.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode and g.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine and os.uidtenant = o.uidtenant " +
                         " WHERE o.UserId = @UserId " +
                         " ORDER BY o.dataordine DESC ";

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
                    IContratti item = new Contratti
                    {
                        Idordine = DataHelper.IfDBNull<int>(row["idordine"], 0),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty),
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Dataconsegnaprevista = DataHelper.IfDBNull<DateTime>(row["dataconsegnaprevista"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //rinuncia user carpolicy
        public int UpdateRinunciaCarPolicy(int idutente, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users_carpolicy SET [idstatoapprovazione] = 1, [datarinuncia] = @datarinuncia  WHERE idutente = @idutente AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@idutente", DbType.Int32);
            param22.Value = idutente;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@datarinuncia", DbType.DateTime);
            param23.Value = DateTime.Now;
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

        //cancella ordine configurato
        public int DeleteConfOrdine(int idordine, Guid Uidtenant)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_ordini WHERE idordine = @idordine AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@idordine", DbType.Int32);
            paramID.Value = idordine;
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
        //cancella optional ordine configurato
        public int DeleteConfOrdineOptional(int idordine, Guid Uidtenant)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_ordini_optional WHERE idordine = @idordine AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@idordine", DbType.Int32);
            paramID.Value = idordine;
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

        // nome approvatore
        public IContratti ReturnApprovatore(int idutente)
        {
            IContratti retVal = null;
            string sql = " SELECT u.cognome, u.nome FROM EF_users_carpolicy as uc " +
                         " LEFT JOIN EF_users as u ON uc.idapprovatore = u.iduser " +
                         " WHERE uc.idutente = @idutente and idstatoapprovazione='0' ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@idutente", DbType.Int32);
            param2.Value = idutente;
            collParams.Add(param2);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty)
                };

                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectStatusOrdineRental()
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_ordini_status WHERE idstatusordine IN (10,20,50) ORDER BY idstatusordine ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectStatusOrdineRentalEvasi()
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_ordini_status WHERE idstatusordine > 50 ORDER BY idstatusordine ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int UpdateDocCarPolicy(Guid Uid, string documentocarpolicy, string documentopatente, string documentofuelcard, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users_carpolicy SET [datadocpolicy] = @datadocpolicy ";

            if (!string.IsNullOrEmpty(documentocarpolicy))
            {
                sql += " ,[documentocarpolicy] = @documentocarpolicy ";
                IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@documentocarpolicy", DbType.String);
                param21.Value = documentocarpolicy;
                collParams.Add(param21);
            }
            if (!string.IsNullOrEmpty(documentopatente))
            {
                sql += " ,[documentopatente] = @documentopatente ";
                IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@documentopatente", DbType.String);
                param24.Value = documentopatente;
                collParams.Add(param24);
            }
            if (!string.IsNullOrEmpty(documentofuelcard))
            {
                sql += " ,[documentofuelcard] = @documentofuelcard ";
                IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@documentofuelcard", DbType.String);
                param25.Value = documentofuelcard;
                collParams.Add(param25);
            }


            sql += " WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@datadocpolicy", DbType.Date);
            param23.Value = DateTime.Now;
            collParams.Add(param23);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

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
        public IContratti ReturnUidCarPolicy(Guid UserId)
        {
            IContratti retVal = null;

            string sql = " SELECT TOP 1 uc.Uid, uc.documentocarpolicy, uc.documentopatente, uc.documentofuelcard FROM EF_users_carpolicy as uc LEFT JOIN EF_users as u ON uc.idutente = u.iduser " +
                         " WHERE u.UserId = @UserId and approvato = 1 and idstatoapprovazione = 0 ORDER BY dataapprovazione DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = UserId;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                    Documentocarpolicy = DataHelper.IfDBNull<string>(row["documentocarpolicy"], _stringEmpty),
                    Documentopatente = DataHelper.IfDBNull<string>(row["documentopatente"], _stringEmpty),
                    Documentofuelcard = DataHelper.IfDBNull<string>(row["documentofuelcard"], _stringEmpty),
                };
                data.Dispose();
            }
            return retVal;
        }

        //inserimento nuovo ordine
        public int InsertOrdiniPool(IContratti value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_ordini_pool ([codjatoauto],[idcontratto],[codsocieta],[UserId],[numeroordine],[dataordine],[idstatusordine], " +
                         " [datauserins],[datausermod],[UserIDIns],[UserIdMod],[uidtenant]) " +
                         " VALUES (@codjatoauto,@idcontratto,@codsocieta,@UserId,@numeroordine,@dataordine,@idstatusordine,@datauserins,@datausermod,@UserIDIns,@UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param2.Value = value.Codjatoauto;
            collParams.Add(param2);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@idcontratto", DbType.Int32);
            param11.Value = value.Idcontratto;
            collParams.Add(param11);

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = value.UserId;
            collParams.Add(param1);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@numeroordine", DbType.String);
            param8.Value = value.Numeroordine;
            collParams.Add(param8);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@dataordine", DbType.Date);
            param17.Value = value.Dataordine;
            collParams.Add(param17);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
            param19.Value = value.Idstatusordine;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param20.Value = DateTime.Now;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param21.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param22.Value = DateTime.Now;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param23.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param23);

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

        //ricava ultimo numeroordine pool
        public IContratti ReturnUltimoNumeroOrdinePool()
        {
            IContratti retVal = null;
            string sql = " SELECT CAST(numeroordine as int) as numeroordine FROM EF_ordini_pool ORDER BY numeroordine DESC ";

            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Nconfigurazioni = DataHelper.IfDBNull<int>(row["numeroordine"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }


        // conta richieste ordini pool
        public int SelectCountRichiesteOrdiniPool(string keysearch, string codsocieta, string codgrade, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (idstatusordine > 0) condWhere += " AND o.idstatusordine = @idstatusordine ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND g.codgrade = @codgrade ";
            if (datadal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') <= @dataal";

            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini_pool as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId AND o.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto AND o.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta AND o.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND u.uidtenant = g.uidtenant " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine AND o.uidtenant = os.uidtenant " +
                         " WHERE o.idordinepool > 0 AND o.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (idstatusordine > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param1.Value = idstatusordine;
                collParams.Add(param1);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param4.Value = codgrade;
                collParams.Add(param4);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
                collParams.Add(param8);
            }

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista richieste ordini pool
        public List<IContratti> SelectRichiesteOrdiniPool(string keysearch, string codsocieta, string codgrade, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (idstatusordine > 0) condWhere += " AND o.idstatusordine = @idstatusordine ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND g.codgrade = @codgrade ";
            if (datadal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') <= @dataal";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.codjatoauto, ca.modello, s.societa, g.grade, o.dataordine, o.numeroordine, o.Uid, u.cognome, " +
                         " u.nome, u.matricola, os.statusordine, o.idstatusordine, u.iduser FROM EF_ordini_pool as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId AND o.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto AND o.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta AND o.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND g.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine AND o.uidtenant = os.uidtenant " +
                         " WHERE o.idordinepool > 0 AND o.uidtenant = @Uidtenant " + condWhere +
                         " ORDER BY o.dataordine DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (idstatusordine > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param1.Value = idstatusordine;
                collParams.Add(param1);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param4.Value = codgrade;
                collParams.Add(param4);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
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
                    IContratti item = new Contratti
                    {
                        Idutente = DataHelper.IfDBNull<int>(row["iduser"], 0),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty),
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        //dettagli ordine pool
        public IContratti DetailOrdiniPoolId(Guid Uid)
        {
            IContratti retVal = null;
            string sql = " SELECT op.*, o.idordine, o.deltacanone, c.codcarlist FROM EF_ordini_pool as op " +
                         " LEFT JOIN EF_contratti as c ON op.idcontratto = c.idcontratto " +
                         " LEFT JOIN EF_ordini as o ON o.Uid = c.Uidordine  WHERE op.Uid = @Uid ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                    Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                    Idcontratto = DataHelper.IfDBNull<int>(row["idcontratto"], 0),
                    Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                    Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                    Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                    Idordine = DataHelper.IfDBNull<int>(row["idordine"], 0),
                    Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }

        //cambia stato ordine pool
        public int UpdateChangeStatusOrdinePool(Guid Uid, int idstatusordine, string motivoscarto, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_ordini_pool SET [idstatusordine] = @idstatusordine, [motivoscarto] = @motivoscarto WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
            param21.Value = idstatusordine;
            collParams.Add(param21);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@motivoscarto", DbType.String);
            param23.Value = motivoscarto;
            collParams.Add(param23);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

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

        //dettagli contratti
        public IContratti DetailContrattiId2(int idcontratto)
        {
            IContratti retVal = null;
            string sql = "SELECT * FROM EF_contratti WHERE idcontratto = @idcontratto";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idcontratto", DbType.Int32);
            param0.Value = idcontratto;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Idcontratto = DataHelper.IfDBNull<int>(row["idcontratto"], 0),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                    Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                    Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                    Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                    Codtipocontratto = DataHelper.IfDBNull<string>(row["codtipocontratto"], _stringEmpty),
                    Codtipousocontratto = DataHelper.IfDBNull<string>(row["codtipousocontratto"], _stringEmpty),
                    Numordineordine = DataHelper.IfDBNull<string>(row["numordineordine"], _stringEmpty),
                    Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                    Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                    Duratamesi = DataHelper.IfDBNull<int>(row["duratamesi"], 0),
                    Kmcontratto = DataHelper.IfDBNull<int>(row["kmcontratto"], 0),
                    Franchigia = DataHelper.IfDBNull<decimal>(row["franchigia"], 0),
                    Datainiziocontratto = DataHelper.IfDBNull<DateTime>(row["datainiziocontratto"], DateTime.MinValue),
                    Datainiziouso = DataHelper.IfDBNull<DateTime>(row["datainiziouso"], DateTime.MinValue),
                    Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                    Annotazionicontratto = DataHelper.IfDBNull<string>(row["annotazionicontratto"], _stringEmpty),
                    Canoneleasing = DataHelper.IfDBNull<decimal>(row["canoneleasing"], 0),
                    Idstatuscontratto = DataHelper.IfDBNull<int>(row["idstatuscontratto"], 0),
                    Filecontratto = DataHelper.IfDBNull<string>(row["filecontratto"], _stringEmpty),
                    Bollo = DataHelper.IfDBNull<decimal>(row["bollo"], 0),
                    Superbollo = DataHelper.IfDBNull<decimal>(row["superbollo"], 0),
                    Dataimmatricolazione = DataHelper.IfDBNull<DateTime>(row["dataimmatricolazione"], DateTime.MinValue),
                    Scadenzabollo = DataHelper.IfDBNull<DateTime>(row["scadenzabollo"], DateTime.MinValue),
                    Scadenzasuperbollo = DataHelper.IfDBNull<DateTime>(row["scadenzasuperbollo"], DateTime.MinValue),
                    Uidordine = DataHelper.IfDBNull<Guid>(row["Uidordine"], Guid.Empty),
                    Flgvoltura = DataHelper.IfDBNull<int>(row["flgvoltura"], 0),
                    Notevoltura = DataHelper.IfDBNull<string>(row["notevoltura"], _stringEmpty),
                    Uidcontrattovolturato = DataHelper.IfDBNull<Guid>(row["Uidcontrattovolturato"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                    Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                    Canonefinanziario = DataHelper.IfDBNull<decimal>(row["canonefinanziario"], 0),
                    Canoneservizi = DataHelper.IfDBNull<decimal>(row["canoneservizi"], 0),
                    Costokmeccedente = DataHelper.IfDBNull<decimal>(row["costokmeccedente"], 0),
                    Costokmrimborso = DataHelper.IfDBNull<decimal>(row["costokmrimborso"], 0),
                    Sogliakm = DataHelper.IfDBNull<decimal>(row["sogliakm"], 0)
                };

                data.Dispose();
            }
            return retVal;
        }

        //aggiorna contratto terminato per pool 
        public int UpdateContrattiPool(IContratti value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_contratti SET [idstatuscontratto] = @idstatuscontratto, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod, " +
                         " [datafinecontratto] = @datafinecontratto WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@datafinecontratto", DbType.DateTime);
            param16.Value = value.Datafinecontratto;
            collParams.Add(param16);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
            param19.Value = value.Idstatuscontratto;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param20.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param35.Value = value.Uid;
            collParams.Add(param35);

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

        public int SelectCountRichiesteOrdiniPoolXDriver(Guid UserId)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini_pool as o " +
                         " LEFT JOIN EF_contratti as c ON c.idcontratto = o.idcontratto " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine " +
                         " WHERE o.UserId = @UserId ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param2.Value = UserId;
            collParams.Add(param2);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista richieste ordini per driver
        // FILTRO: UserId
        public List<IContratti> SelectRichiesteOrdiniPoolXDriver(Guid UserId)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.codjatoauto, ca.modello, ca.marca, o.Uid, ca.codcarlist, c.deltacanone, " +
                         " os.statusordine, o.idstatusordine, o.idordinepool, o.dataordine FROM EF_ordini_pool as o " +
                         " LEFT JOIN EF_contratti as c ON c.idcontratto = o.idcontratto " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine " +
                         " WHERE o.UserId = @UserId " +
                         " ORDER BY o.dataordine DESC ";

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
                    IContratti item = new Contratti
                    {
                        Idordine = DataHelper.IfDBNull<int>(row["idordinepool"], 0),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty),
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Deltacanone = DataHelper.IfDBNull<int>(row["deltacanone"], 0),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //conta configurazioni pool effettuate
        public int SelectCountConfigurazioniPool(Guid UserId)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini_pool WHERE UserId = @UserId and idstatusordine = 40  ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public int UpdateTerminaAssegnazioneContratto(int idcontratto, DateTime assegnatoal, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti_assegnazioni SET [idstatusassegnazione] = 100, [assegnatoal] = @assegnatoal  WHERE idcontratto = @idcontratto AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@idcontratto", DbType.Int32);
            param22.Value = idcontratto;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatoal", DbType.Date);
            param21.Value = assegnatoal;
            collParams.Add(param21);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param2.Value = Uidtenant;
            collParams.Add(param2);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int InsertInizioAssegnazioneContratto(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " INSERT INTO EF_contratti_assegnazioni ([UserID],[targa],[idcontratto],[assegnatodal],[assegnatoal],[idstatusassegnazione],[codsocieta],[uidtenant]) " +
                         " VALUES (@UserId,@targa,@idcontratto,@assegnatodal,@assegnatoal,@idstatusassegnazione,@codsocieta,@uidtenant) ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@UserID", DbType.Guid);
            param22.Value = value.UserId;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param21.Value = value.Targa;
            collParams.Add(param21);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@idcontratto", DbType.Int32);
            param20.Value = value.Idcontratto;
            collParams.Add(param20);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatodal", DbType.Date);
            param19.Value = value.Assegnatodal;
            collParams.Add(param19);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatoal", DbType.Date);
            param18.Value = value.Assegnatoal;
            collParams.Add(param18);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusassegnazione", DbType.Int32);
            param17.Value = value.Idstatusassegnazione;
            collParams.Add(param17);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param23.Value = value.Codsocieta;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param24.Value = value.Uidtenant;
            collParams.Add(param24);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }

        //ricava ultimo idcontratto
        public IContratti ReturnUltimoIdContratto()
        {
            IContratti retVal = null;
            string sql = " SELECT idcontratto, Uid FROM EF_contratti ORDER BY idcontratto DESC ";

            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Idcontratto = DataHelper.IfDBNull<int>(row["idcontratto"], 0),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }


        public int SelectCountOrdiniContrattualizzati(Guid UserId)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_contratti_assegnazioni as ca " +
                         " LEFT JOIN EF_contratti as c ON c.idcontratto = ca.idcontratto " +
                         " LEFT JOIN EF_users as u ON ca.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as cl ON cl.codjatoauto = c.codjatoauto and cl.codcarlist = c.codcarlist and cl.codfornitore = c.codfornitore " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = ca.codsocieta " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode " +
                         " WHERE ca.UserId = @UserId AND ca.dataconsegna <> '' and ca.dataconsegna is not null and ca.luogoconsegna <>'' and ca.luogoconsegna is not null";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param2.Value = UserId;
            collParams.Add(param2);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectOrdiniContrattualizzati(Guid UserId)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT c.codjatoauto, cl.modello, c.codcarlist, s.societa, g.grade, ca.dataconsegna, ca.oraconsegna, ca.luogoconsegna, ca.targa, ca.idassegnazione " +
                         " FROM EF_contratti_assegnazioni as ca " +
                         " LEFT JOIN EF_contratti as c ON c.idcontratto = ca.idcontratto " +
                         " LEFT JOIN EF_users as u ON ca.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as cl ON cl.codjatoauto = c.codjatoauto and cl.codcarlist = c.codcarlist and cl.codfornitore = c.codfornitore " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = ca.codsocieta " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode " +
                         " WHERE ca.UserId = @UserId AND ca.dataconsegna <> '' and ca.dataconsegna is not null and ca.luogoconsegna <>'' and ca.luogoconsegna is not null " +
                         " ORDER BY ca.dataconsegna DESC ";

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
                    IContratti item = new Contratti
                    {
                        Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Dataconsegna = DataHelper.IfDBNull<DateTime>(row["dataconsegna"], DateTime.MinValue),
                        Oraconsegna = DataHelper.IfDBNull<string>(row["oraconsegna"], _stringEmpty),
                        Luogoconsegna = DataHelper.IfDBNull<string>(row["luogoconsegna"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Idassegnazione = DataHelper.IfDBNull<int>(row["idassegnazione"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateRifiutaAuto(Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_ordini SET [flgaccettato] = 'NO' WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param20.Value = Uid;
            collParams.Add(param20);

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
        public int UpdateAccettaAuto(Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_ordini SET [flgaccettato] = 'SI' WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param20.Value = Uid;
            collParams.Add(param20);

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

        public int UpdateRifiutaAuto2(int idassegnazione, string motivorifiutoauto, string filerifiutoauto, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti_assegnazioni SET [motivorifiutoauto] = @motivorifiutoauto, [filerifiutoauto] = @filerifiutoauto " +
                         " WHERE idassegnazione = @idassegnazione AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@motivorifiutoauto", DbType.String);
            param22.Value = motivorifiutoauto;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@filerifiutoauto", DbType.String);
            param21.Value = filerifiutoauto;
            collParams.Add(param21);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param20.Value = idassegnazione;
            collParams.Add(param20);

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
        public int UpdateAccettaAuto2(int idassegnazione, string fileverbaleauto, string filelibrettoauto, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti_assegnazioni SET [fileverbaleauto] = @fileverbaleauto, [filelibrettoauto] = @filelibrettoauto " +
                         " WHERE idassegnazione = @idassegnazione AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@fileverbaleauto", DbType.String);
            param22.Value = fileverbaleauto;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@filelibrettoauto", DbType.String);
            param21.Value = filelibrettoauto;
            collParams.Add(param21);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param20.Value = idassegnazione;
            collParams.Add(param20);

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



        public int SelectCountRitiriAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND ca.assegnatoal >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND ca.assegnatoal <= @datacontrattoal";
            if (idstatusassegnazione > -1) condWhere += " AND ca.idstatusassegnazione = @idstatusassegnazione ";

            string sql = " SELECT COUNT(ca.idassegnazione) as tot " +
                         " FROM EF_contratti_assegnazioni as ca " +
                         " INNER JOIN EF_contratti as c ON ca.targa = c.targa " +
                         " LEFT JOIN EF_contratti_assegnazioni_status as cs ON cs.idstatusassegnazione = ca.idstatusassegnazione " +
                         " LEFT JOIN EF_users as u ON u.UserId = ca.UserID " +
                         " WHERE ca.idassegnazione > 0 AND ca.uidtenant = @Uidtenant and ca.dataconsegna <> '' and ca.dataconsegna is not null and ca.luogoconsegna <>'' and ca.luogoconsegna is not null " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatusassegnazione > -1)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusassegnazione", DbType.Int32);
                param8.Value = idstatusassegnazione;
                collParams.Add(param8);
            }

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param10.Value = Uidtenant;
            collParams.Add(param10);
            
            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectRitiriAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND ca.assegnatoal >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND ca.assegnatoal <= @datacontrattoal";
            if (idstatusassegnazione > -1) condWhere += " AND ca.idstatusassegnazione = @idstatusassegnazione ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.targa, c.codfornitore, c.numerocontratto, c.datacontratto, u.cognome, u.nome, ca.assegnatodal, ca.assegnatoal, " +
                         " cs.statusassegnazione, ca.idassegnazione, ca.dataconsegna FROM EF_contratti_assegnazioni as ca " +
                         " INNER JOIN EF_contratti as c ON ca.targa = c.targa AND c.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni_status as cs ON cs.idstatusassegnazione = ca.idstatusassegnazione AND ca.uidtenant = cs.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = ca.UserID AND ca.uidtenant = u.uidtenant " +
                         " WHERE ca.idassegnazione > 0 AND ca.uidtenant = @Uidtenant and ca.dataconsegna <> '' and ca.dataconsegna is not null and ca.luogoconsegna <>'' and ca.luogoconsegna is not null " + condWhere +
                         " ORDER BY ca.dataconsegna " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatusassegnazione > -1)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusassegnazione", DbType.Int32);
                param8.Value = idstatusassegnazione;
                collParams.Add(param8);
            }

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param10.Value = Uidtenant;
            collParams.Add(param10);
            
            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                        Dataconsegna = DataHelper.IfDBNull<DateTime>(row["dataconsegna"], DateTime.MinValue),
                        Statusassegnazione = DataHelper.IfDBNull<string>(row["statusassegnazione"], _stringEmpty),
                        Idassegnazione = DataHelper.IfDBNull<int>(row["idassegnazione"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //cambia stato ordine
        public int UpdateChangeStatusOrdine2(Guid Uid, int idstatusordine, decimal deltacanone, string annotazioniordini, decimal canoneleasingofferta, string numeroordinefornitore, string alimentazione, Guid Uidtenant)
        {
            int retVal = 0;
            string sqlupd = SeoHelper.CampoDataStatusOrdine(idstatusordine) + " = @data ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_ordini SET [idstatusordine] = @idstatusordine, [deltacanone] = @deltacanone, " +
                         " [canoneleasingofferta] = @canoneleasingofferta, [numeroordinefornitore] = @numeroordinefornitore, [alimentazione] = @alimentazione, " +
                         " [annotazioniordini] = @annotazioniordini, " + sqlupd + " WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
            param21.Value = idstatusordine;
            collParams.Add(param21);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@deltacanone", DbType.Decimal);
            param23.Value = deltacanone;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@data", DbType.DateTime);
            param24.Value = DateTime.Now;
            collParams.Add(param24);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@annotazioniordini", DbType.String);
            param25.Value = annotazioniordini;
            collParams.Add(param25);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@canoneleasingofferta", DbType.Decimal);
            param26.Value = canoneleasingofferta;
            collParams.Add(param26);

            IDbDataParameter param36 = _dataHelper.ProviderConn.CreateDataParameter("@numeroordinefornitore", DbType.String);
            param36.Value = numeroordinefornitore;
            collParams.Add(param36);

            IDbDataParameter param37 = _dataHelper.ProviderConn.CreateDataParameter("@alimentazione", DbType.String);
            param37.Value = alimentazione;
            collParams.Add(param37);

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
        public List<IContratti> SelectDocCarPolicy(string check, Guid UserId, DateTime datadal, DateTime dataal, string flgdoccarpolicy, string flgdocpatente, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(check)) condWhere += " AND c.checkcarpolicy = @check ";
            if (UserId != Guid.Empty) condWhere += " AND u.UserId = @UserId ";
            if (datadal > DateTime.MinValue) condWhere += " AND c.datadocpolicy >= @datacontrattodal";
            if (dataal > DateTime.MinValue) condWhere += " AND c.datadocpolicy <= @datacontrattoal";
            if (!string.IsNullOrEmpty(flgdoccarpolicy))
            {
                if (flgdoccarpolicy.ToUpper() == "NO")
                {
                    condWhere += " AND (c.documentocarpolicy = '' or c.documentocarpolicy is null ) ";
                }
                if (flgdoccarpolicy.ToUpper() == "SI")
                {
                    condWhere += " AND (c.documentocarpolicy <> '' and c.documentocarpolicy is not null) ";
                }
            }
            if (!string.IsNullOrEmpty(flgdocpatente))
            {
                if (flgdocpatente.ToUpper() == "NO")
                {
                    condWhere += " AND (c.documentopatente = '' or c.documentopatente is null ) ";
                }
                if (flgdocpatente.ToUpper() == "SI")
                {
                    condWhere += " AND (c.documentopatente <> '' and c.documentopatente is not null ) ";
                }
            }

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT c.datadocpolicy, c.checkcarpolicy, u.nome, u.cognome, u.matricola, c.Uid, c.datacheck, c.documentocarpolicy, c.documentopatente FROM EF_users_carpolicy as c " +
                         " LEFT JOIN EF_users as u ON c.idutente = u.iduser AND c.uidtenant = u.uidtenant " +
                         " WHERE (c.checkcarpolicy = 'NO' OR (c.documentocarpolicy <> '' and c.documentocarpolicy is not null)) AND c.uidtenant = @Uidtenant " + condWhere + " ORDER BY checkcarpolicy, c.datadocpolicy DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(check))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@check", DbType.String);
                param0.Value = check;
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
            if (!string.IsNullOrEmpty(flgdoccarpolicy))
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@flgdoccarpolicy", DbType.String);
                param8.Value = flgdoccarpolicy;
                collParams.Add(param8);
            }
            if (!string.IsNullOrEmpty(flgdocpatente))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@flgdocpatente", DbType.String);
                param9.Value = flgdocpatente;
                collParams.Add(param9);
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
                    IContratti item = new Contratti
                    {
                        Checkcarpolicy = DataHelper.IfDBNull<string>(row["checkcarpolicy"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Datadocpolicy = DataHelper.IfDBNull<DateTime>(row["datadocpolicy"], DateTime.MinValue),
                        Datacheck = DataHelper.IfDBNull<DateTime>(row["datacheck"], DateTime.MinValue),
                        Documentocarpolicy = DataHelper.IfDBNull<string>(row["documentocarpolicy"], _stringEmpty),
                        Documentopatente = DataHelper.IfDBNull<string>(row["documentopatente"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountDocCarPolicy(string check, Guid UserId, DateTime datadal, DateTime dataal, string flgdoccarpolicy, string flgdocpatente, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(check)) condWhere += " AND c.checkcarpolicy = @check ";
            if (UserId != Guid.Empty) condWhere += " AND u.UserId = @UserId ";
            if (datadal > DateTime.MinValue) condWhere += " AND c.datadocpolicy >= @datacontrattodal";
            if (dataal > DateTime.MinValue) condWhere += " AND c.datadocpolicy <= @datacontrattoal";
            if (!string.IsNullOrEmpty(flgdoccarpolicy))
            {
                if (flgdoccarpolicy.ToUpper() == "NO")
                {
                    condWhere += " AND (c.documentocarpolicy = '' or c.documentocarpolicy is null ) ";
                }
                if (flgdoccarpolicy.ToUpper() == "SI")
                {
                    condWhere += " AND (c.documentocarpolicy <> '' and c.documentocarpolicy is not null) ";
                }
            }
            if (!string.IsNullOrEmpty(flgdocpatente))
            {
                if (flgdocpatente.ToUpper() == "NO")
                {
                    condWhere += " AND (c.documentopatente = '' or c.documentopatente is null ) ";
                }
                if (flgdocpatente.ToUpper() == "SI")
                {
                    condWhere += " AND (c.documentopatente <> '' and c.documentopatente is not null ) ";
                }
            }

            string SQL = " SELECT COUNT(*) as tot FROM EF_users_carpolicy as c " +
                         " LEFT JOIN EF_users as u ON c.idutente = u.iduser AND c.uidtenant = u.uidtenant " +
                         " WHERE (c.checkcarpolicy = 'NO' OR (c.documentocarpolicy <> '' and c.documentocarpolicy is not null)) AND c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(check))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@check", DbType.String);
                param0.Value = check;
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
            if (!string.IsNullOrEmpty(flgdoccarpolicy))
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@flgdoccarpolicy", DbType.String);
                param8.Value = flgdoccarpolicy;
                collParams.Add(param8);
            }
            if (!string.IsNullOrEmpty(flgdocpatente))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@flgdocpatente", DbType.String);
                param9.Value = flgdocpatente;
                collParams.Add(param9);
            }

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);
            
            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public int UpdateCheckDocPolicy(Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users_carpolicy SET [checkcarpolicy] = 'SI', [datacheck] = @datacheck, [idutentecheck] = @idutentecheck WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datacheck", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@idutentecheck", DbType.Guid);
            param25.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param25);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

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
        public int UpdateNotCheckDocPolicy(Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users_carpolicy SET [checkcarpolicy] = 'NO', [documentocarpolicy] = '', [documentopatente] = '', [datacheck] = @datacheck, [idutentecheck] = @idutentecheck " +
                         " WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datacheck", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@idutentecheck", DbType.Guid);
            param25.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param25);

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
        public List<IContratti> SelectContrattiAssXIdContratto(int idcontratto)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT u.UserId, u.nome, u.cognome, u.matricola, a.assegnatodal, a.assegnatoal, a.datarestituzione, a.orarestituzione, a.luogorestituzione, a.fileverbaleconsegna, " +
                         " a.filerelazioneperito, a.filedenunce, a.noteamministrazione, a.notedriver, a.checkdoc, a.idassegnazione, a.targa, s.siglasocieta, a.idstatusassegnazione " +
                         " FROM EF_contratti_assegnazioni as a " +
                         " LEFT JOIN EF_users as u ON u.UserID = a.UserID " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = a.codsocieta " +
                         " WHERE a.idcontratto = @idcontratto ORDER BY a.assegnatoal DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idcontratto", DbType.Int32);
            param0.Value = idcontratto;
            collParams.Add(param0);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                        Datarestituzione = DataHelper.IfDBNull<DateTime>(row["datarestituzione"], DateTime.MinValue),
                        Orarestituzione = DataHelper.IfDBNull<string>(row["orarestituzione"], _stringEmpty),
                        Luogorestituzione = DataHelper.IfDBNull<string>(row["luogorestituzione"], _stringEmpty),
                        Fileverbaleconsegna = DataHelper.IfDBNull<string>(row["fileverbaleconsegna"], _stringEmpty),
                        Filerelazioneperito = DataHelper.IfDBNull<string>(row["filerelazioneperito"], _stringEmpty),
                        Filedenunce = DataHelper.IfDBNull<string>(row["filedenunce"], _stringEmpty),
                        Noteamministrazione = DataHelper.IfDBNull<string>(row["noteamministrazione"], _stringEmpty),
                        Notedriver = DataHelper.IfDBNull<string>(row["notedriver"], _stringEmpty),
                        Checkdoc = DataHelper.IfDBNull<string>(row["checkdoc"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Idassegnazione = DataHelper.IfDBNull<int>(row["idassegnazione"], 0),
                        Idstatusassegnazione = DataHelper.IfDBNull<int>(row["idstatusassegnazione"], 0),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };

                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        public int SelectCountRunningFleet(string targa, string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND a.targa = @targa ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND ca.marca = @marca ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND ca.modello = @modello ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND c.datafinecontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND c.datafinecontratto <= @datacontrattoal";
            if (idstatuscontratto > 0) condWhere += " AND c.idstatuscontratto = @idstatuscontratto ";

            string SQL = " SELECT COUNT(c.Uid) as tot FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_status as cs ON cs.idstatuscontratto = c.idstatuscontratto AND cs.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON a.idcontratto = c.idcontratto AND a.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni_status_auto as asa ON a.idstatoauto = asa.idstatusauto AND a.uidtenant = asa.uidtenant " +
                         " LEFT JOIN EF_ordini as o ON o.Uid = c.Uidordine AND o.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = c.codfornitore AND f.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta AND s.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto and ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore AND ca.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserId AND u.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND g.uidtenant = u.uidtenant " +
                         " WHERE a.idstatusassegnazione = 0 and a.assegnatoal > GETDATE() AND c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param3.Value = modello;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatuscontratto > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
                param8.Value = idstatuscontratto;
                collParams.Add(param8);
            }
            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param10.Value = Uidtenant;
            collParams.Add(param10);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectRunningFleet(string targa, string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " c.datacontratto ";
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

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND a.targa = @targa ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND ca.marca = @marca ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND ca.modello = @modello ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND c.datafinecontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND c.datafinecontratto <= @datacontrattoal";
            if (idstatuscontratto > 0) condWhere += " AND c.idstatuscontratto = @idstatuscontratto ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT f.fornitore, c.numerocontratto, c.datacontratto, c.targa, c.codcarpolicy, ca.modello, s.siglasocieta, " +
                         " u.nome, u.cognome, u.matricola, o.deltacanone, c.fringebenefit, c.kmcontratto, a.assegnatodal, g.grade, c.datainiziouso, c.datainiziocontratto, " +
                         " (SELECT TOP 1 kmpercorsi FROM EF_contratti_percorrenze as cp WHERE cp.targa = c.targa ORDER BY cp.datains DESC) as kmpercorsi, " +
                         " c.datacontratto, c.datafinecontratto, cs.statuscontratto, asa.statusauto, c.Uid FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_status as cs ON cs.idstatuscontratto = c.idstatuscontratto AND cs.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON a.idcontratto = c.idcontratto AND a.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni_status_auto as asa ON a.idstatoauto = asa.idstatusauto AND a.uidtenant = asa.uidtenant " +
                         " LEFT JOIN EF_ordini as o ON o.Uid = c.Uidordine AND o.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = c.codfornitore AND f.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta AND s.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto and ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore AND ca.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserId AND u.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND g.uidtenant = u.uidtenant " +
                         " WHERE a.idstatusassegnazione = 0 and a.assegnatoal > GETDATE() AND c.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param3.Value = modello;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatuscontratto > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
                param8.Value = idstatuscontratto;
                collParams.Add(param8);
            }
            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param10.Value = Uidtenant;
            collParams.Add(param10);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {                        
                        Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Fringebenefit = DataHelper.IfDBNull<decimal>(row["fringebenefit"], 0),
                        Kmcontratto = DataHelper.IfDBNull<int>(row["kmcontratto"], 0),
                        Kmpercorsi = DataHelper.IfDBNull<decimal>(row["kmpercorsi"], 0),
                        Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Statoauto = DataHelper.IfDBNull<string>(row["statusauto"], _stringEmpty),
                        Statuscontratto = DataHelper.IfDBNull<string>(row["statuscontratto"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Datainiziocontratto = DataHelper.IfDBNull<DateTime>(row["datainiziocontratto"], DateTime.MinValue),
                        Datainiziouso = DataHelper.IfDBNull<DateTime>(row["datainiziouso"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        public int SelectCountAutoPool(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND a.marca = @marca ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND a.modello = @modello ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND c.datafinecontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND c.datafinecontratto <= @datacontrattoal";
            if (idstatuscontratto > 0) condWhere += " AND c.idstatuscontratto = @idstatuscontratto ";

            string SQL = " SELECT COUNT(c.Uid) as tot " +
                         " FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON a.idcontratto = c.idcontratto  and idstatusassegnazione = 5 AND c.uidtenant = a.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni_status_pool as sp ON sp.idstatuspool = c.idstatuspool AND c.uidtenant = sp.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni_status_auto as asa ON a.idstatoauto = asa.idstatusauto AND a.uidtenant = asa.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta AND c.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto and ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore AND ca.uidtenant = c.uidtenant " +
                         " WHERE checkpool = 1 AND c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param3.Value = modello;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatuscontratto > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
                param8.Value = idstatuscontratto;
                collParams.Add(param8);
            }

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);
            
            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectAutoPool(string codsocieta, Guid UserId, string marca, string modello, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " c.datacontratto ";
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

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND ca.marca = @marca ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND ca.modello = @modello ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND c.datafinecontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND c.datafinecontratto <= @datacontrattoal";
            if (idstatuscontratto > 0) condWhere += " AND c.idstatuscontratto = @idstatuscontratto ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT c.codfornitore, c.numerocontratto, c.datacontratto, c.targa, ca.modello, c.codcarpolicy, s.siglasocieta,  c.deltacanone, c.fringebenefit, c.kmcontratto, " +
                         " (SELECT TOP 1 kmpercorsi FROM EF_contratti_percorrenze as cp WHERE cp.targa = c.targa ORDER BY cp.datains desc) as kmpercorsi, " +
                         " c.datacontratto, c.datafinecontratto, a.assegnatodal, a.luogoconsegna, asa.statusauto, sp.statuspool, c.Uid " +
                         " FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON a.idcontratto = c.idcontratto and idstatusassegnazione = 5 AND c.uidtenant = a.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni_status_pool as sp ON sp.idstatuspool = c.idstatuspool AND c.uidtenant = sp.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni_status_auto as asa ON a.idstatoauto = asa.idstatusauto AND a.uidtenant = asa.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta AND c.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto and ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore AND c.uidtenant = ca.uidtenant " +
                         " WHERE checkpool = 1 AND c.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param3.Value = modello;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatuscontratto > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
                param8.Value = idstatuscontratto;
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
                    IContratti item = new Contratti
                    {
                        Fornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Fringebenefit = DataHelper.IfDBNull<decimal>(row["fringebenefit"], 0),
                        Kmcontratto = DataHelper.IfDBNull<int>(row["kmcontratto"], 0),
                        Kmpercorsi = DataHelper.IfDBNull<decimal>(row["kmpercorsi"], 0),
                        Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Luogoconsegna = DataHelper.IfDBNull<string>(row["luogoconsegna"], _stringEmpty),
                        Statoauto = DataHelper.IfDBNull<string>(row["statusauto"], _stringEmpty),
                        Statuspool = DataHelper.IfDBNull<string>(row["statuspool"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        public int InsertDocDelega(IContratti value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Datanascita > DateTime.MinValue)
            {
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@datanascita", DbType.DateTime);
                param10.Value = value.Datanascita;
                collParams.Add(param10);

                sqlfield += " ,[datanascita] ";
                sqlvalue += " ,@datanascita ";
            }

            if (value.Datarilasciopatente > DateTime.MinValue)
            {
                IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@datarilasciopatente", DbType.DateTime);
                param14.Value = value.Datarilasciopatente;
                collParams.Add(param14);

                sqlfield += " ,[datarilasciopatente] ";
                sqlvalue += " ,@datarilasciopatente ";
            }

            if (value.Scadenzapatente > DateTime.MinValue)
            {
                IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzapatente", DbType.DateTime);
                param15.Value = value.Scadenzapatente;
                collParams.Add(param15);

                sqlfield += " ,[scadenzapatente] ";
                sqlvalue += " ,@scadenzapatente ";
            }

            if (value.Datanascitadelegato > DateTime.MinValue)
            {
                IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@datanascitadelegato", DbType.DateTime);
                param16.Value = value.Datanascitadelegato;
                collParams.Add(param16);

                sqlfield += " ,[datanascitadelegato] ";
                sqlvalue += " ,@datanascitadelegato ";
            }

            if (value.Datarilasciopatentedelegato > DateTime.MinValue)
            {
                IDbDataParameter param29 = _dataHelper.ProviderConn.CreateDataParameter("@datarilasciopatentedelegato", DbType.DateTime);
                param29.Value = value.Datarilasciopatentedelegato;
                collParams.Add(param29);

                sqlfield += " ,[datarilasciopatentedelegato] ";
                sqlvalue += " ,@datarilasciopatentedelegato ";

            }

            if (value.Scadenzapatentedelegato > DateTime.MinValue)
            {
                IDbDataParameter param30 = _dataHelper.ProviderConn.CreateDataParameter("@scadenzapatentedelegato", DbType.DateTime);
                param30.Value = value.Scadenzapatentedelegato;
                collParams.Add(param30);

                sqlfield += " ,[scadenzapatentedelegato] ";
                sqlvalue += " ,@scadenzapatentedelegato ";

            }

            if (value.Datadocumento > DateTime.MinValue)
            {
                IDbDataParameter param31 = _dataHelper.ProviderConn.CreateDataParameter("@datadocumento", DbType.DateTime);
                param31.Value = value.Datadocumento;
                collParams.Add(param31);

                sqlfield += " ,[datadocumento] ";
                sqlvalue += " ,@datadocumento ";
            }

            string sql = " INSERT INTO EF_documenti_deleghe ([denominazione],[luogonascita],[indirizzoresidenza],[civicoresidenza],[cittaresidenza],[nrpatente],[entepatente],[tipoutente], " +
                         " [denominazionedelegato],[luogonascitadelegato],[indirizzoresidenzadelegato],[civicoresidenzadelegato],[cittaresidenzadelegato],[nrpatentedelegato], " +
                         " [entepatentedelegato],[veicolo],[targa],[fornitore],[codsocieta],[datarichiesta],[filepdf],[UserId],[uidtenant] " + sqlfield + " ) " +
                         " VALUES (@denominazione,@luogonascita,@indirizzoresidenza,@civicoresidenza,@cittaresidenza,@nrpatente,@entepatente,@tipoutente,@denominazionedelegato, " +
                         " @luogonascitadelegato,@indirizzoresidenzadelegato,@civicoresidenzadelegato,@cittaresidenzadelegato,@nrpatentedelegato,@entepatentedelegato,@veicolo,@targa, " +
                         " @fornitore,@codsocieta,@datarichiesta,@filepdf,@UserId,@uidtenant " + sqlvalue + " ) ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@denominazione", DbType.String);
            param0.Value = value.Denominazione;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = value.UserId;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@luogonascita", DbType.String);
            param2.Value = value.Luogonascita;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@indirizzoresidenza", DbType.String);
            param3.Value = value.Indirizzoresidenza;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@civicoresidenza", DbType.String);
            param4.Value = value.Civicoresidenza;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@cittaresidenza", DbType.String);
            param5.Value = value.Cittaresidenza;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@nrpatente", DbType.String);
            param6.Value = value.Nrpatente;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@entepatente", DbType.String);
            param7.Value = value.Entepatente;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@tipoutente", DbType.String);
            param8.Value = value.Tipoutente;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@denominazionedelegato", DbType.String);
            param9.Value = value.Denominazionedelegato;
            collParams.Add(param9);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@luogonascitadelegato", DbType.String);
            param11.Value = value.Luogonascitadelegato;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@indirizzoresidenzadelegato", DbType.String);
            param12.Value = value.Indirizzoresidenzadelegato;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@civicoresidenzadelegato", DbType.String);
            param13.Value = value.Civicoresidenzadelegato;
            collParams.Add(param13);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@cittaresidenzadelegato", DbType.String);
            param17.Value = value.Cittaresidenzadelegato;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@nrpatentedelegato", DbType.String);
            param18.Value = value.Nrpatentedelegato;
            collParams.Add(param18);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@entepatentedelegato", DbType.String);
            param19.Value = value.Entepatentedelegato;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@datarichiesta", DbType.Date);
            param20.Value = DateTime.Now;
            collParams.Add(param20);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@veicolo", DbType.String);
            param24.Value = value.Veicolo;
            collParams.Add(param24);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param25.Value = value.Targa;
            collParams.Add(param25);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@fornitore", DbType.String);
            param26.Value = value.Fornitore;
            collParams.Add(param26);

            IDbDataParameter param27 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param27.Value = value.Codsocieta;
            collParams.Add(param27);

            IDbDataParameter param28 = _dataHelper.ProviderConn.CreateDataParameter("@filepdf", DbType.String);
            param28.Value = value.Filepdf;
            collParams.Add(param28);

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

        public IContratti ReturnUltimoIdDelega()
        {
            IContratti retVal = null;
            string sql = " SELECT iddelega FROM EF_documenti_deleghe ORDER BY iddelega DESC ";

            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Iddelega = DataHelper.IfDBNull<int>(row["iddelega"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int UpdatePdfDocDelega(int iddelega, string filepdf, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_documenti_deleghe SET [filepdf] = @filepdf WHERE iddelega = @iddelega AND uidtenant = @Uidtenant  ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@iddelega", DbType.Int32);
            param22.Value = iddelega;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@filepdf", DbType.String);
            param21.Value = filepdf;
            collParams.Add(param21);

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

        public IContratti DetailDocDelegaXId(Guid UserId, string targa)
        {
            IContratti retVal = null;
            string sql = "SELECT * FROM EF_documenti_deleghe WHERE UserId = @UserId and targa = @targa";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param1.Value = targa;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Filepdf = DataHelper.IfDBNull<string>(row["filepdf"], _stringEmpty),
                    Tipoutente = DataHelper.IfDBNull<string>(row["tipoutente"], _stringEmpty),
                    Indirizzoresidenza = DataHelper.IfDBNull<string>(row["indirizzoresidenza"], _stringEmpty),
                    Civicoresidenza = DataHelper.IfDBNull<string>(row["civicoresidenza"], _stringEmpty),
                    Cittaresidenza = DataHelper.IfDBNull<string>(row["cittaresidenza"], _stringEmpty),
                    Indirizzoresidenzadelegato = DataHelper.IfDBNull<string>(row["indirizzoresidenzadelegato"], _stringEmpty),
                    Civicoresidenzadelegato = DataHelper.IfDBNull<string>(row["civicoresidenzadelegato"], _stringEmpty),
                    Cittaresidenzadelegato = DataHelper.IfDBNull<string>(row["cittaresidenzadelegato"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectAllContrattiTipo(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_contratti_tipo WHERE uidtenant = @Uidtenant ORDER BY tipocontratto ";

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
                    IContratti item = new Contratti
                    {
                        Codtipocontratto = DataHelper.IfDBNull<string>(row["codtipocontratto"], _stringEmpty),
                        Tipocontratto = DataHelper.IfDBNull<string>(row["tipocontratto"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectAllContrattiTipoUso(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_contratti_tipouso WHERE uidtenant = @Uidtenant ORDER BY tipousocontratto ";

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
                    IContratti item = new Contratti
                    {
                        Codtipousocontratto = DataHelper.IfDBNull<string>(row["codtipousocontratto"], _stringEmpty),
                        Tipousocontratto = DataHelper.IfDBNull<string>(row["tipousocontratto"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectAllContrattiTipoAssegnazione(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_contratti_tipoassegnazione WHERE uidtenant = @Uidtenant ORDER BY tipoassegnazione ";

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
                    IContratti item = new Contratti
                    {
                        Idtipoassegnazione = DataHelper.IfDBNull<int>(row["idtipoassegnazione"], 0),
                        Tipoassegnazione = DataHelper.IfDBNull<string>(row["tipoassegnazione"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectAutoXCarList(string codcarlist)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT codjatoauto, modello FROM EF_carlist_auto WHERE codcarlist = @codcarlist ORDER BY modello ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param2.Value = codcarlist;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectCarPolicyXCarList(string codcarlist)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT codcarpolicy FROM EF_carpolicy WHERE codcarlist = @codcarlist ORDER BY codcarpolicy ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param2.Value = codcarlist;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectCarPolicyXSocieta(string codsocieta)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT codcarpolicy FROM EF_carpolicy_assegna_societa WHERE codsocieta = @codsocieta ORDER BY codcarpolicy ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param2.Value = codsocieta;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectFornitoreXAuto(string codjatoauto)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT DISTINCT a.codfornitore, f.fornitore FROM EF_carlist_auto as a INNER JOIN EF_fornitori as f ON a.codfornitore = f.codfornitore " +
                         " WHERE a.codjatoauto = @codjatoauto ORDER BY f.fornitore ";

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
                    IContratti item = new Contratti
                    {
                        Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectUsersXSocieta(string codsocieta)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT cognome, nome, matricola, UserId FROM EF_users WHERE codsocieta = @codsocieta ORDER BY cognome, nome ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param2.Value = codsocieta;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")"
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectAutoXFornitore(string codfornitore, Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT modello, cilindrata, codcarlist, codjatoauto, Uid FROM EF_carlist_auto WHERE codfornitore = @codfornitore AND uidtenant = @Uidtenant ORDER BY modello ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param2.Value = codfornitore;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                        Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["cilindrata"], _stringEmpty) + " - " + DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountRiconsegnaAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND ca.assegnatoal >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND ca.assegnatoal <= @datacontrattoal";
            if (idstatusassegnazione > -1) condWhere += " AND ca.idstatusassegnazione = @idstatusassegnazione ";

            string sql = " SELECT COUNT(ca.idassegnazione) as tot " +
                         " FROM EF_contratti_assegnazioni as ca " +
                         " INNER JOIN EF_contratti as c ON ca.targa = c.targa AND c.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni_status as cs ON cs.idstatusassegnazione = ca.idstatusassegnazione AND ca.uidtenant = cs.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = ca.UserID AND ca.uidtenant = u.uidtenant " +
                         " WHERE ca.idassegnazione > 0 AND ca.uidtenant = @Uidtenant and ca.datarestituzione <> '' and ca.datarestituzione is not null and ca.datarestituzione <>'' and ca.datarestituzione is not null " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatusassegnazione > -1)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusassegnazione", DbType.Int32);
                param8.Value = idstatusassegnazione;
                collParams.Add(param8);
            }

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);            

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectRiconsegnaAuto(string targa, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND ca.assegnatoal >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND ca.assegnatoal <= @datacontrattoal";
            if (idstatusassegnazione > -1) condWhere += " AND ca.idstatusassegnazione = @idstatusassegnazione ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.targa, c.codfornitore, c.numerocontratto, c.datacontratto, u.cognome, u.nome, ca.assegnatodal, ca.assegnatoal, " +
                         " cs.statusassegnazione, ca.idassegnazione, ca.datarestituzione FROM EF_contratti_assegnazioni as ca " +
                         " INNER JOIN EF_contratti as c ON ca.targa = c.targa AND c.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni_status as cs ON cs.idstatusassegnazione = ca.idstatusassegnazione AND ca.uidtenant = cs.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = ca.UserID AND ca.uidtenant = u.uidtenant " +
                         " WHERE ca.idassegnazione > 0 AND ca.uidtenant = @Uidtenant and ca.datarestituzione <> '' and ca.datarestituzione is not null and ca.datarestituzione <>'' and ca.datarestituzione is not null " + condWhere +
                         " ORDER BY ca.datarestituzione " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatusassegnazione > -1)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusassegnazione", DbType.Int32);
                param8.Value = idstatusassegnazione;
                collParams.Add(param8);
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
                    IContratti item = new Contratti
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                        Datarestituzione = DataHelper.IfDBNull<DateTime>(row["datarestituzione"], DateTime.MinValue),
                        Statusassegnazione = DataHelper.IfDBNull<string>(row["statusassegnazione"], _stringEmpty),
                        Idassegnazione = DataHelper.IfDBNull<int>(row["idassegnazione"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IContratti DetailContrattiAssId(int idcontratto, Guid UserId)
        {
            IContratti retVal = null;
            string sql = "SELECT * FROM EF_contratti_assegnazioni WHERE idcontratto = @idcontratto AND UserId = @UserId ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idcontratto", DbType.Int32);
            param0.Value = idcontratto;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = UserId;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Idcontratto = DataHelper.IfDBNull<int>(row["idcontratto"], 0),
                    Idstatusassegnazione = DataHelper.IfDBNull<int>(row["idstatusassegnazione"], 0),
                    Idstatoauto = DataHelper.IfDBNull<int>(row["idstatoauto"], 0),
                    Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                    Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                    Datarestituzione = DataHelper.IfDBNull<DateTime>(row["datarestituzione"], DateTime.MinValue),
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    Orarestituzione = DataHelper.IfDBNull<string>(row["orarestituzione"], _stringEmpty),
                    Luogorestituzione = DataHelper.IfDBNull<string>(row["luogorestituzione"], _stringEmpty),
                    Centrorestituzione = DataHelper.IfDBNull<string>(row["centrorestituzione"], _stringEmpty),
                    Fileverbaleconsegna = DataHelper.IfDBNull<string>(row["fileverbaleconsegna"], _stringEmpty),
                    Filerelazioneperito = DataHelper.IfDBNull<string>(row["filerelazioneperito"], _stringEmpty),
                    Filedenunce = DataHelper.IfDBNull<string>(row["filedenunce"], _stringEmpty),
                    Noteamministrazione = DataHelper.IfDBNull<string>(row["noteamministrazione"], _stringEmpty),
                    Notedriver = DataHelper.IfDBNull<string>(row["notedriver"], _stringEmpty),
                    Checkdoc = DataHelper.IfDBNull<string>(row["checkdoc"], _stringEmpty),
                    Idassegnazione = DataHelper.IfDBNull<int>(row["idassegnazione"], 0),
                    Dataconsegna = DataHelper.IfDBNull<DateTime>(row["dataconsegna"], DateTime.MinValue),
                    Oraconsegna = DataHelper.IfDBNull<string>(row["oraconsegna"], _stringEmpty),
                    Luogoconsegna = DataHelper.IfDBNull<string>(row["luogoconsegna"], _stringEmpty),
                    Motivoscarto = DataHelper.IfDBNull<string>(row["motivoscarto"], _stringEmpty),
                    Filerifiutoauto = DataHelper.IfDBNull<string>(row["filerifiutoauto"], _stringEmpty),
                    Fileverbaleauto = DataHelper.IfDBNull<string>(row["fileverbaleauto"], _stringEmpty),
                    Filelibrettoauto = DataHelper.IfDBNull<string>(row["filelibrettoauto"], _stringEmpty),
                    Motivorifiutoauto = DataHelper.IfDBNull<string>(row["motivorifiutoauto"], _stringEmpty),
                    Tipogomme = DataHelper.IfDBNull<string>(row["tipogomme"], _stringEmpty),
                    Luogogomme = DataHelper.IfDBNull<string>(row["luogogomme"], _stringEmpty),
                    Datacambiogomme = DataHelper.IfDBNull<DateTime>(row["datacambiogomme"], DateTime.MinValue),
                    Kmrestituzione = DataHelper.IfDBNull<decimal>(row["kmrestituzione"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }

        public int UpdateContrattiAss(IContratti value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_contratti_assegnazioni SET [idstatusassegnazione] = @idstatusassegnazione, [datarestituzione] = @datarestituzione, [orarestituzione] = @orarestituzione, " +
                         " [luogorestituzione] = @luogorestituzione, [centrorestituzione] = @centrorestituzione, [noteamministrazione] = @noteamministrazione, [idstatoauto] = @idstatoauto " +
                         " WHERE idassegnazione = @idassegnazione AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusassegnazione", DbType.Int32);
            param15.Value = value.Idstatusassegnazione;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@datarestituzione", DbType.DateTime);
            param16.Value = value.Datarestituzione;
            collParams.Add(param16);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@orarestituzione", DbType.String);
            param19.Value = value.Orarestituzione;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@luogorestituzione", DbType.String);
            param20.Value = value.Luogorestituzione;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@centrorestituzione", DbType.String);
            param21.Value = value.Centrorestituzione;
            collParams.Add(param21);

            IDbDataParameter param33 = _dataHelper.ProviderConn.CreateDataParameter("@noteamministrazione", DbType.String);
            param33.Value = value.Noteamministrazione;
            collParams.Add(param33);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param35.Value = value.Idassegnazione;
            collParams.Add(param35);

            IDbDataParameter param36 = _dataHelper.ProviderConn.CreateDataParameter("@idstatoauto", DbType.Int32);
            param36.Value = value.Idstatoauto;
            collParams.Add(param36);

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
        public int UpdateCheckContrattiAss(int idassegnazione, DateTime assegnatoal, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = " UPDATE EF_contratti_assegnazioni SET [checkdoc] = 'SI', [assegnatoal] = @assegnatoal WHERE idassegnazione = @idassegnazione AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatoal", DbType.DateTime);
            param16.Value = assegnatoal;
            collParams.Add(param16);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param35.Value = idassegnazione;
            collParams.Add(param35);

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

        public int UpdateContrattiAssDriver(IContratti value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_contratti_assegnazioni SET [fileverbaleconsegna] = @fileverbaleconsegna, [filerelazioneperito] = @filerelazioneperito, [filedenunce] = @filedenunce, " +
                         " [notedriver] = @notedriver, [tipogomme] = @tipogomme, [luogogomme] = @luogogomme, [datacambiogomme] = @datacambiogomme, " +
                         " [kmrestituzione] = @kmrestituzione WHERE idassegnazione = @idassegnazione AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@fileverbaleconsegna", DbType.String);
            param19.Value = value.Fileverbaleconsegna;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@filerelazioneperito", DbType.String);
            param20.Value = value.Filerelazioneperito;
            collParams.Add(param20);

            IDbDataParameter param33 = _dataHelper.ProviderConn.CreateDataParameter("@filedenunce", DbType.String);
            param33.Value = value.Filedenunce;
            collParams.Add(param33);

            IDbDataParameter param34 = _dataHelper.ProviderConn.CreateDataParameter("@notedriver", DbType.String);
            param34.Value = value.Notedriver;
            collParams.Add(param34);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param35.Value = value.Idassegnazione;
            collParams.Add(param35);

            IDbDataParameter param36 = _dataHelper.ProviderConn.CreateDataParameter("@tipogomme", DbType.String);
            param36.Value = value.Tipogomme;
            collParams.Add(param36);

            IDbDataParameter param37 = _dataHelper.ProviderConn.CreateDataParameter("@luogogomme", DbType.String);
            param37.Value = value.Luogogomme;
            collParams.Add(param37);

            IDbDataParameter param38 = _dataHelper.ProviderConn.CreateDataParameter("@datacambiogomme", DbType.DateTime);
            param38.Value = value.Datacambiogomme;
            collParams.Add(param38);

            IDbDataParameter param39 = _dataHelper.ProviderConn.CreateDataParameter("@kmrestituzione", DbType.Decimal);
            param39.Value = value.Kmrestituzione;
            collParams.Add(param39);

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
        public IContratti DetailContrattiXUidordine(Guid Uidordine)
        {
            IContratti retVal = null;
            string sql = "SELECT * FROM EF_contratti WHERE Uidordine = @Uidordine";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uidordine", DbType.Guid);
            param0.Value = Uidordine;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Idcontratto = DataHelper.IfDBNull<int>(row["idcontratto"], 0),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateContrattoConsegna(IContratti value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_contratti_assegnazioni SET [dataconsegna] = @dataconsegna, [oraconsegna] = @oraconsegna, " +
                         " [luogoconsegna] = @luogoconsegna, [noteconsegna] = @noteconsegna WHERE idassegnazione = @idassegnazione AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@dataconsegna", DbType.DateTime);
            param19.Value = value.Dataconsegna;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@oraconsegna", DbType.String);
            param20.Value = value.Oraconsegna;
            collParams.Add(param20);

            IDbDataParameter param33 = _dataHelper.ProviderConn.CreateDataParameter("@luogoconsegna", DbType.String);
            param33.Value = value.Luogoconsegna;
            collParams.Add(param33);

            IDbDataParameter param34 = _dataHelper.ProviderConn.CreateDataParameter("@noteconsegna", DbType.String);
            param34.Value = value.Noteconsegna;
            collParams.Add(param34);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param35.Value = value.Idassegnazione;
            collParams.Add(param35);

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

        public List<IContratti> SelectAllContrattiAss()
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_contratti_assegnazioni_status WHERE idstatusassegnazione > 100 ORDER BY idstatusassegnazione ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Idstatusassegnazione = DataHelper.IfDBNull<int>(row["idstatusassegnazione"], 0),
                        Statusassegnazione = DataHelper.IfDBNull<string>(row["statusassegnazione"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IContratti ReturnUserIdAssPool(Guid Uidtenant)
        {
            IContratti retVal = null;

            string sql = " SELECT UserId FROM EF_users WHERE cognome='POOL' AND uidtenant = @Uidtenant  ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IContratti ReturnUserIdAssRitiro()
        {
            IContratti retVal = null;

            string sql = " SELECT UserId FROM EF_users WHERE cognome='RITIRO AUTO' ";

            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }


        public int UpdateContrattoUserPool(IContratti value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_contratti SET [UserId] = @UserId WHERE idcontratto = @idcontratto AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param16.Value = value.UserId;
            collParams.Add(param16);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@idcontratto", DbType.Int32);
            param19.Value = value.Idcontratto;
            collParams.Add(param19);

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
        public List<IContratti> SelectStatusAuto(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_contratti_assegnazioni_status_auto WHERE uidtenant = @Uidtenant ORDER BY idstatusauto ";

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
                    IContratti item = new Contratti
                    {
                        Idstatoauto = DataHelper.IfDBNull<int>(row["idstatusauto"], 0),
                        Statoauto = DataHelper.IfDBNull<string>(row["statusauto"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int InsertDocZTL(IContratti value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Datanascita > DateTime.MinValue)
            {
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@datanascita", DbType.DateTime);
                param10.Value = value.Datanascita;
                collParams.Add(param10);

                sqlfield += " ,[datanascita] ";
                sqlvalue += " ,@datanascita ";
            }

            if (value.Datainiziocontratto > DateTime.MinValue)
            {
                IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@datainiziocontratto", DbType.DateTime);
                param14.Value = value.Datainiziocontratto;
                collParams.Add(param14);

                sqlfield += " ,[datainiziocontratto] ";
                sqlvalue += " ,@datainiziocontratto ";
            }

            if (value.Datafinecontratto > DateTime.MinValue)
            {
                IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datafinecontratto", DbType.DateTime);
                param15.Value = value.Datafinecontratto;
                collParams.Add(param15);

                sqlfield += " ,[datafinecontratto] ";
                sqlvalue += " ,@datafinecontratto ";
            }

            if (value.Datadocumento > DateTime.MinValue)
            {
                IDbDataParameter param31 = _dataHelper.ProviderConn.CreateDataParameter("@datadocumento", DbType.DateTime);
                param31.Value = value.Datadocumento;
                collParams.Add(param31);

                sqlfield += " ,[datadocumento] ";
                sqlvalue += " ,@datadocumento ";
            }

            string sql = " INSERT INTO EF_documenti_ztl ([denominazione],[luogonascita],[indirizzoresidenza],[civicoresidenza],[cittaresidenza],[numerocontratto], " +
                         " [veicolo],[targa],[fornitore],[codsocieta],[luogodocumento],[datarichiesta],[filepdf],[UserId],[uidtenant] " + sqlfield + " ) " +
                         " VALUES (@denominazione,@luogonascita,@indirizzoresidenza,@civicoresidenza,@cittaresidenza,@numerocontratto,@veicolo,@targa, " +
                         " @fornitore,@codsocieta,@luogodocumento,@datarichiesta,@filepdf,@UserId,@uidtenant " + sqlvalue + " ) ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@denominazione", DbType.String);
            param0.Value = value.Denominazione;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = value.UserId;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@luogonascita", DbType.String);
            param2.Value = value.Luogonascita;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@indirizzoresidenza", DbType.String);
            param3.Value = value.Indirizzoresidenza;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@civicoresidenza", DbType.String);
            param4.Value = value.Civicoresidenza;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@cittaresidenza", DbType.String);
            param5.Value = value.Cittaresidenza;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
            param6.Value = value.Numerocontratto;
            collParams.Add(param6);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@datarichiesta", DbType.Date);
            param20.Value = DateTime.Now;
            collParams.Add(param20);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@veicolo", DbType.String);
            param24.Value = value.Veicolo;
            collParams.Add(param24);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param25.Value = value.Targa;
            collParams.Add(param25);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@fornitore", DbType.String);
            param26.Value = value.Fornitore;
            collParams.Add(param26);

            IDbDataParameter param27 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param27.Value = value.Codsocieta;
            collParams.Add(param27);

            IDbDataParameter param28 = _dataHelper.ProviderConn.CreateDataParameter("@filepdf", DbType.String);
            param28.Value = value.Filepdf;
            collParams.Add(param28);

            IDbDataParameter param29 = _dataHelper.ProviderConn.CreateDataParameter("@luogodocumento", DbType.String);
            param29.Value = value.Luogodocumento;
            collParams.Add(param29);

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

        public IContratti ReturnUltimoIdZTL()
        {
            IContratti retVal = null;
            string sql = " SELECT iddelega FROM EF_documenti_ztl ORDER BY iddelega DESC ";

            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Iddelega = DataHelper.IfDBNull<int>(row["iddelega"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int UpdatePdfDocZTL(int iddelega, string filepdf, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_documenti_ztl SET [filepdf] = @filepdf WHERE iddelega = @iddelega AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@iddelega", DbType.Int32);
            param22.Value = iddelega;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@filepdf", DbType.String);
            param21.Value = filepdf;
            collParams.Add(param21);

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

        public IContratti DetailDocZTLXId(Guid UserId, string targa)
        {
            IContratti retVal = null;
            string sql = "SELECT * FROM EF_documenti_ztl WHERE UserId = @UserId and targa = @targa";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param1.Value = targa;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Filepdf = DataHelper.IfDBNull<string>(row["filepdf"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int UpdatePdfOrdine(int idordine, string fileordinepdf, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_ordini SET [fileordinepdf] = @fileordinepdf WHERE idordine = @idordine AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@idordine", DbType.Int32);
            param22.Value = idordine;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@fileordinepdf", DbType.String);
            param21.Value = fileordinepdf;
            collParams.Add(param21);

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
        public int UpdatePdfOrdineFirmato(Guid Uid, string filefirma, Guid UserIdFirma, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_ordini SET [filefirma] = @filefirma, [UserIdFirma] = @UserIdFirma WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@filefirma", DbType.String);
            param21.Value = filefirma;
            collParams.Add(param21);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdFirma", DbType.Guid);
            param23.Value = UserIdFirma;
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

        
        public int SelectCountOrdiniDaFirmare(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND g.codgrade = @codgrade ";
            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " AND o.codcarlist = @codcarlist ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND o.codfornitore = @codfornitore ";
            if (datadal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') <= @dataal";

            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId AND o.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore AND o.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta AND o.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist as cl ON cl.codcarlist = o.codcarlist AND o.uidtenant = cl.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = o.codfornitore AND o.uidtenant = f.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND u.uidtenant = g.uidtenant " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine AND o.uidtenant = os.uidtenant " +
                         " WHERE o.idordine > 0 AND o.uidtenant = @Uidtenant AND o.idstatusordine = 40 " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param4.Value = codgrade;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param5.Value = codcarlist;
                collParams.Add(param5);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param6.Value = codfornitore;
                collParams.Add(param6);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
                collParams.Add(param8);
            }

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);            

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectOrdiniDaFirmare(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND g.codgrade = @codgrade ";
            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " AND o.codcarlist = @codcarlist ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND o.codfornitore = @codfornitore ";
            if (datadal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') <= @dataal";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.codjatoauto, ca.modello, ca.marca, cl.codcarlist, s.siglasocieta, g.grade, o.dataordine, o.numeroordine, o.Uid, u.cognome, " +
                         " u.nome, u.matricola, os.statusordine, o.idstatusordine, o.deltacanone, u.iduser, f.codfornitore, o.fileordinepdf FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId AND o.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore AND ca.uidtenant = o.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta AND o.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist as cl ON cl.codcarlist = o.codcarlist AND o.uidtenant = cl.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = o.codfornitore AND o.uidtenant = f.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND u.uidtenant = g.uidtenant " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine AND o.uidtenant = os.uidtenant " +
                         " WHERE o.idordine > 0 AND o.uidtenant = @Uidtenant AND o.idstatusordine = 40 " + condWhere +
                         " ORDER BY o.dataordine " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param4.Value = codgrade;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param5.Value = codcarlist;
                collParams.Add(param5);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param6.Value = codfornitore;
                collParams.Add(param6);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
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
                    IContratti item = new Contratti
                    {
                        Idutente = DataHelper.IfDBNull<int>(row["iduser"], 0),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty),
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Fileordinepdf = DataHelper.IfDBNull<string>(row["fileordinepdf"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountOrdiniFirmati(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant)
        {
            Guid UserIdFirma = (Guid)Membership.GetUser().ProviderUserKey;
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND g.codgrade = @codgrade ";
            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " AND o.codcarlist = @codcarlist ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND o.codfornitore = @codfornitore ";
            if (datadal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') <= @dataal";

            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore AND o.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta AND o.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist as cl ON cl.codcarlist = o.codcarlist AND o.uidtenant = cl.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = o.codfornitore AND o.uidtenant = f.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND u.uidtenant = g.uidtenant " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine AND o.uidtenant = os.uidtenant " +
                         " WHERE o.idordine > 0 AND o.uidtenant = @Uidtenant AND o.idstatusordine > 40 AND UserIdFirma = @UserIdFirma " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param4.Value = codgrade;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param5.Value = codcarlist;
                collParams.Add(param5);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param6.Value = codfornitore;
                collParams.Add(param6);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
                collParams.Add(param8);
            }

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param10.Value = Uidtenant;
            collParams.Add(param10);
            
            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdFirma", DbType.Guid);
            param9.Value = UserIdFirma;
            collParams.Add(param9);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectOrdiniFirmati(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
        {
            Guid UserIdFirma = (Guid)Membership.GetUser().ProviderUserKey;
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND g.codgrade = @codgrade ";
            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " AND o.codcarlist = @codcarlist ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND o.codfornitore = @codfornitore ";
            if (datadal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') <= @dataal";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.codjatoauto, ca.modello, ca.marca, cl.carlist, s.siglasocieta as societa, g.grade, o.dataordine, o.numeroordine, o.Uid, u.cognome, " +
                         " u.nome, u.matricola, os.statusordine, o.idstatusordine, o.deltacanone, u.iduser, f.fornitore, o.fileordinepdf, o.filefirma FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore AND o.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta AND o.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist as cl ON cl.codcarlist = o.codcarlist AND o.uidtenant = cl.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = o.codfornitore AND o.uidtenant = f.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND g.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine AND o.uidtenant = os.uidtenant " +
                         " WHERE o.idordine > 0 AND o.uidtenant = @Uidtenant AND o.idstatusordine > 40 AND UserIdFirma = @UserIdFirma " + condWhere +
                         " ORDER BY o.dataordine DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param4.Value = codgrade;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param5.Value = codcarlist;
                collParams.Add(param5);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param6.Value = codfornitore;
                collParams.Add(param6);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
                collParams.Add(param8);
            }

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param10.Value = Uidtenant;
            collParams.Add(param10);
            
            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdFirma", DbType.Guid);
            param9.Value = UserIdFirma;
            collParams.Add(param9);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Idutente = DataHelper.IfDBNull<int>(row["iduser"], 0),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["carlist"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty),
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Fileordinepdf = DataHelper.IfDBNull<string>(row["fileordinepdf"], _stringEmpty),
                        Filefirma = DataHelper.IfDBNull<string>(row["filefirma"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        public List<IContratti> SelectFatture(string keysearch, string codfornitore, string codsocieta, DateTime datadocumentodal, DateTime datadocumentoal, int idstatusfattura, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " datadocumento DESC ";
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND numerodocumento LIKE '%' + @keysearch + '%' ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND codcommittente = @codsocieta ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND codfornitore = @codfornitore ";
            if (datadocumentodal > DateTime.MinValue) condWhere += " AND datadocumento >= @datadocumentodal";
            if (datadocumentoal > DateTime.MinValue) condWhere += " AND datadocumento <= @datadocumentoal";
            if (idstatusfattura > -1) condWhere += " AND f.idstatusfattura = @idstatusfattura";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT * FROM EF_fatturexml as f INNER JOIN EF_fatturexml_status as s ON f.idstatusfattura = s.idstatusfattura AND f.uidtenant = s.uidtenant " +
                         " WHERE idfattura > 0 AND f.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param5.Value = keysearch;
                collParams.Add(param5);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (datadocumentodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datadocumentodal", DbType.DateTime);
                param6.Value = datadocumentodal;
                collParams.Add(param6);
            }
            if (datadocumentoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadocumentoal", DbType.DateTime);
                param7.Value = datadocumentoal;
                collParams.Add(param7);
            }
            if (idstatusfattura > -1)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusfattura", DbType.Int32);
                param8.Value = idstatusfattura;
                collParams.Add(param8);
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
                    IContratti item = new Contratti
                    {
                        Idfattura = DataHelper.IfDBNull<int>(row["idfattura"], 0),
                        Tipodocumento = DataHelper.IfDBNull<string>(row["tipodocumento"], _stringEmpty),
                        Statusfattura = DataHelper.IfDBNull<string>(row["statusfattura"], _stringEmpty),
                        Datadocumento = DataHelper.IfDBNull<DateTime>(row["datadocumento"], DateTime.MinValue),
                        Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                        Codcommittente = DataHelper.IfDBNull<string>(row["codcommittente"], _stringEmpty),
                        Committente = DataHelper.IfDBNull<string>(row["committente"], _stringEmpty),
                        Numerodocumento = DataHelper.IfDBNull<string>(row["numerodocumento"], _stringEmpty),
                        Importototale = DataHelper.IfDBNull<decimal>(row["importototale"], 0),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Importopagamento = DataHelper.IfDBNull<decimal>(row["importopagamento"], 0),
                        Datascadenzapagamento = DataHelper.IfDBNull<DateTime>(row["datascadenzapagamento"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        public int SelectCountFatture(string keysearch, string codfornitore, string codsocieta, DateTime datadocumentodal, DateTime datadocumentoal, int idstatusfattura, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND numerodocumento LIKE '%' + @keysearch + '%' ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND codcommittente = @codsocieta ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND codfornitore = @codfornitore ";
            if (datadocumentodal > DateTime.MinValue) condWhere += " AND datadocumento >= @datadocumentodal";
            if (datadocumentoal > DateTime.MinValue) condWhere += " AND datadocumento <= @datadocumentoal";
            if (idstatusfattura > -1) condWhere += " AND f.idstatusfattura = @idstatusfattura";

            string SQL = " SELECT COUNT(*) as tot FROM EF_fatturexml as f INNER JOIN EF_fatturexml_status as s ON f.idstatusfattura = s.idstatusfattura AND f.uidtenant = s.uidtenant " +
                         " WHERE idfattura > 0 AND f.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param5.Value = keysearch;
                collParams.Add(param5);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (datadocumentodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datadocumentodal", DbType.DateTime);
                param6.Value = datadocumentodal;
                collParams.Add(param6);
            }
            if (datadocumentoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadocumentoal", DbType.DateTime);
                param7.Value = datadocumentoal;
                collParams.Add(param7);
            }
            if (idstatusfattura > -1)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusfattura", DbType.Int32);
                param8.Value = idstatusfattura;
                collParams.Add(param8);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public IContratti DetailFattureId(Guid Uid)
        {
            IContratti retVal = null;
            string sql = "SELECT * FROM EF_fatturexml WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Idfattura = DataHelper.IfDBNull<int>(row["idfattura"], 0),
                    Tipodocumento = DataHelper.IfDBNull<string>(row["tipodocumento"], _stringEmpty),
                    Datadocumento = DataHelper.IfDBNull<DateTime>(row["datadocumento"], DateTime.MinValue),
                    Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                    Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                    Codcommittente = DataHelper.IfDBNull<string>(row["codcommittente"], _stringEmpty),
                    Committente = DataHelper.IfDBNull<string>(row["committente"], _stringEmpty),
                    Numerodocumento = DataHelper.IfDBNull<string>(row["numerodocumento"], _stringEmpty),
                    Importototale = DataHelper.IfDBNull<decimal>(row["importototale"], 0),
                    Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                    Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                    Importopagamento = DataHelper.IfDBNull<decimal>(row["importopagamento"], 0),
                    Datascadenzapagamento = DataHelper.IfDBNull<DateTime>(row["datascadenzapagamento"], DateTime.MinValue),
                    Filexml = DataHelper.IfDBNull<string>(row["filexml"], _stringEmpty),
                    Divisa = DataHelper.IfDBNull<string>(row["divisa"], _stringEmpty),
                    Templateabb = DataHelper.IfDBNull<int>(row["templateabb"], 0),
                    Datarifabb = DataHelper.IfDBNull<DateTime>(row["datarifabb"], DateTime.MinValue),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectDetailFatture(Guid Uidfattura, Guid Uidtenant, int pagina)
        {
            string paginazione;
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * 200 + " ROWS FETCH NEXT 200 ROWS ONLY ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT *, (SELECT COUNT(UserId) as tot FROM EF_contratti_assegnazioni WHERE targa = EF_fatturexml_dettaglio.targa) as totuser " +
                         " FROM EF_fatturexml_dettaglio  WHERE Uidfattura = @Uidfattura AND uidtenant = @Uidtenant ORDER BY iddettaglio " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@Uidfattura", DbType.Guid);
            param5.Value = Uidfattura;
            collParams.Add(param5);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Descrizione = DataHelper.IfDBNull<string>(row["descrizione"], _stringEmpty),
                        Prezzotot = DataHelper.IfDBNull<decimal>(row["prezzotot"], 0),
                        Centrocostoabb = DataHelper.IfDBNull<string>(row["centrocostoabb"], _stringEmpty),
                        Centrocostoabb2 = DataHelper.IfDBNull<string>(row["centrocostoabb2"], _stringEmpty),
                        Centrocostoabb3 = DataHelper.IfDBNull<string>(row["centrocostoabb3"], _stringEmpty),
                        Centrocostoabb4 = DataHelper.IfDBNull<string>(row["centrocostoabb4"], _stringEmpty),
                        Tipocentrocosto = DataHelper.IfDBNull<string>(row["tipocentrocosto"], _stringEmpty),
                        Tipocentrocosto2 = DataHelper.IfDBNull<string>(row["tipocentrocosto2"], _stringEmpty),
                        Tipocentrocosto3 = DataHelper.IfDBNull<string>(row["tipocentrocosto3"], _stringEmpty),
                        Tipocentrocosto4 = DataHelper.IfDBNull<string>(row["tipocentrocosto4"], _stringEmpty),
                        Uidcentrocosto = DataHelper.IfDBNull<Guid>(row["Uidcentrocosto"], Guid.Empty),
                        Uidcentrocosto2 = DataHelper.IfDBNull<Guid>(row["Uidcentrocosto2"], Guid.Empty),
                        Uidcentrocosto3 = DataHelper.IfDBNull<Guid>(row["Uidcentrocosto3"], Guid.Empty),
                        Uidcentrocosto4 = DataHelper.IfDBNull<Guid>(row["Uidcentrocosto4"], Guid.Empty),
                        Riftesto = DataHelper.IfDBNull<string>(row["riftesto"], _stringEmpty),
                        Datainizioperiodo = DataHelper.IfDBNull<DateTime>(row["datainizioperiodo"], DateTime.MinValue),
                        Datafineperiodo = DataHelper.IfDBNull<DateTime>(row["datafineperiodo"], DateTime.MinValue),
                        Datainizioperiodo2 = DataHelper.IfDBNull<DateTime>(row["datainizioperiodo2"], DateTime.MinValue),
                        Datafineperiodo2 = DataHelper.IfDBNull<DateTime>(row["datafineperiodo2"], DateTime.MinValue),
                        Datainizioperiodo3 = DataHelper.IfDBNull<DateTime>(row["datainizioperiodo3"], DateTime.MinValue),
                        Datafineperiodo3 = DataHelper.IfDBNull<DateTime>(row["datafineperiodo3"], DateTime.MinValue),
                        Datainizioperiodo4 = DataHelper.IfDBNull<DateTime>(row["datainizioperiodo4"], DateTime.MinValue),
                        Datafineperiodo4 = DataHelper.IfDBNull<DateTime>(row["datafineperiodo4"], DateTime.MinValue),
                        Naturaiva = DataHelper.IfDBNull<string>(row["naturaiva"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Totuser = DataHelper.IfDBNull<int>(row["totuser"], 0),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountDetailFatture(Guid Uidfattura, Guid Uidtenant)
        {
            string SQL = " SELECT COUNT(iddettaglio) as tot FROM EF_fatturexml_dettaglio WHERE Uidfattura = @Uidfattura AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@Uidfattura", DbType.Guid);
            param5.Value = Uidfattura;
            collParams.Add(param5);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public int UpdateAbbinaFattura(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_fatturexml_dettaglio SET [centrocostoabb] = @centrocostoabb, [tipocentrocosto] = @tipocentrocosto, [Uidcentrocosto] = @Uidcentrocosto, " +
                         " [centrocostoabb2] = @centrocostoabb2, [tipocentrocosto2] = @tipocentrocosto2, [Uidcentrocosto2] = @Uidcentrocosto2, " +
                         " [centrocostoabb3] = @centrocostoabb3, [tipocentrocosto3] = @tipocentrocosto3, [Uidcentrocosto3] = @Uidcentrocosto3, " +
                         " [centrocostoabb4] = @centrocostoabb4, [tipocentrocosto4] = @tipocentrocosto4, [Uidcentrocosto4] = @Uidcentrocosto4, [targa] = @targa ";

            if (value.Datainizioperiodo > DateTime.MinValue)
            {
                sql += " ,[datainizioperiodo] = @datainizioperiodo ";
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@datainizioperiodo", DbType.DateTime);
                param4.Value = value.Datainizioperiodo;
                collParams.Add(param4);
            }
            if (value.Datafineperiodo > DateTime.MinValue)
            {
                sql += " ,[datafineperiodo] = @datafineperiodo ";
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datafineperiodo", DbType.DateTime);
                param5.Value = value.Datafineperiodo;
                collParams.Add(param5);
            }

            if (value.Datainizioperiodo2 > DateTime.MinValue)
            {
                sql += " ,[datainizioperiodo2] = @datainizioperiodo2 ";
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@datainizioperiodo2", DbType.DateTime);
                param9.Value = value.Datainizioperiodo2;
                collParams.Add(param9);
            }
            if (value.Datafineperiodo2 > DateTime.MinValue)
            {
                sql += " ,[datafineperiodo2] = @datafineperiodo2 ";
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@datafineperiodo2", DbType.DateTime);
                param10.Value = value.Datafineperiodo2;
                collParams.Add(param10);
            }

            if (value.Datainizioperiodo3 > DateTime.MinValue)
            {
                sql += " ,[datainizioperiodo3] = @datainizioperiodo3 ";
                IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@datainizioperiodo3", DbType.DateTime);
                param14.Value = value.Datainizioperiodo3;
                collParams.Add(param14);
            }
            if (value.Datafineperiodo3 > DateTime.MinValue)
            {
                sql += " ,[datafineperiodo3] = @datafineperiodo3 ";
                IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datafineperiodo3", DbType.DateTime);
                param15.Value = value.Datafineperiodo3;
                collParams.Add(param15);
            }

            if (value.Datainizioperiodo4 > DateTime.MinValue)
            {
                sql += " ,[datainizioperiodo4] = @datainizioperiodo4 ";
                IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@datainizioperiodo4", DbType.DateTime);
                param19.Value = value.Datainizioperiodo4;
                collParams.Add(param19);
            }
            if (value.Datafineperiodo4 > DateTime.MinValue)
            {
                sql += " ,[datafineperiodo4] = @datafineperiodo4 ";
                IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@datafineperiodo4", DbType.DateTime);
                param20.Value = value.Datafineperiodo4;
                collParams.Add(param20);
            }

            sql += " WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = value.Uid;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@centrocostoabb", DbType.String);
            param1.Value = value.Centrocostoabb;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@tipocentrocosto", DbType.String);
            param2.Value = value.Tipocentrocosto;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidcentrocosto", DbType.Guid);
            param3.Value = value.Uidcentrocosto;
            collParams.Add(param3);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@centrocostoabb2", DbType.String);
            param6.Value = value.Centrocostoabb2;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@tipocentrocosto2", DbType.String);
            param7.Value = value.Tipocentrocosto2;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@Uidcentrocosto2", DbType.Guid);
            param8.Value = value.Uidcentrocosto2;
            collParams.Add(param8);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@centrocostoabb3", DbType.String);
            param11.Value = value.Centrocostoabb3;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@tipocentrocosto3", DbType.String);
            param12.Value = value.Tipocentrocosto3;
            collParams.Add(param12);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@Uidcentrocosto3", DbType.Guid);
            param13.Value = value.Uidcentrocosto3;
            collParams.Add(param13);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@centrocostoabb4", DbType.String);
            param16.Value = value.Centrocostoabb4;
            collParams.Add(param16);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@tipocentrocosto4", DbType.String);
            param17.Value = value.Tipocentrocosto4;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@Uidcentrocosto4", DbType.Guid);
            param18.Value = value.Uidcentrocosto4;
            collParams.Add(param18);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param21.Value = value.Targa;
            collParams.Add(param21);

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
        public int UpdateStatusFattura(Guid Uid, int idstatusfattura, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_fatturexml SET [idstatusfattura] = @idstatusfattura WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusfattura", DbType.Int32);
            param9.Value = idstatusfattura;
            collParams.Add(param9);

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
        public int UpdateFatturaAbb(Guid Uid, int templateabb, DateTime datarifabb, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_fatturexml SET [templateabb] = @templateabb ";

            if (datarifabb > DateTime.MinValue)
            {
                sql += " ,[datarifabb] = @datarifabb ";
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@datarifabb", DbType.DateTime);
                param10.Value = datarifabb;
                collParams.Add(param10);
            }

            sql += " WHERE Uid = @Uid AND uidtenant = @Uidtenant ";


            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@templateabb", DbType.Int32);
            param9.Value = templateabb;
            collParams.Add(param9);

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
        public IContratti DetailFattureDetId(Guid Uid)
        {
            IContratti retVal = null;
            string sql = "SELECT * FROM EF_fatturexml_dettaglio WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Descrizione = DataHelper.IfDBNull<string>(row["descrizione"], _stringEmpty),
                    Prezzotot = DataHelper.IfDBNull<decimal>(row["prezzotot"], 0),
                    Centrocostoabb = DataHelper.IfDBNull<string>(row["centrocostoabb"], _stringEmpty),
                    Centrocostoabb2 = DataHelper.IfDBNull<string>(row["centrocostoabb2"], _stringEmpty),
                    Tipocentrocosto = DataHelper.IfDBNull<string>(row["tipocentrocosto"], _stringEmpty),
                    Tipocentrocosto2 = DataHelper.IfDBNull<string>(row["tipocentrocosto2"], _stringEmpty),
                    Uidcentrocosto = DataHelper.IfDBNull<Guid>(row["Uidcentrocosto"], Guid.Empty),
                    Uidcentrocosto2 = DataHelper.IfDBNull<Guid>(row["Uidcentrocosto2"], Guid.Empty),
                    Riftesto = DataHelper.IfDBNull<string>(row["riftesto"], _stringEmpty),
                    Datainizioperiodo = DataHelper.IfDBNull<DateTime>(row["datainizioperiodo"], DateTime.MinValue),
                    Datafineperiodo = DataHelper.IfDBNull<DateTime>(row["datafineperiodo"], DateTime.MinValue),
                    Datainizioperiodo2 = DataHelper.IfDBNull<DateTime>(row["datainizioperiodo2"], DateTime.MinValue),
                    Datafineperiodo2 = DataHelper.IfDBNull<DateTime>(row["datafineperiodo2"], DateTime.MinValue),
                    Naturaiva = DataHelper.IfDBNull<string>(row["naturaiva"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                    Uidfattura = DataHelper.IfDBNull<Guid>(row["Uidfattura"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }     
        
        //esistenza assegnazione contratto
        public bool ExistAssegnazioneContratto(Guid UserID, int idcontratto)
        {
            bool retVal = false;
            string sql = " SELECT idcontratto FROM EF_contratti_assegnazioni WHERE UserID = @UserID and idcontratto = @idcontratto ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserID", DbType.Guid);
            param0.Value = UserID;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idcontratto", DbType.Int32);
            param1.Value = idcontratto;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public int UpdateInizioAssegnazioneContratto(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti_assegnazioni SET [assegnatoal] = @assegnatoal, [idstatusassegnazione] = @idstatusassegnazione, " + 
                         " [UserID] = @UserId, [targa] = @targa, [codsocieta] = @codsocieta ";

            if (value.Assegnatodal > DateTime.MinValue)
            {
                sql += " ,[assegnatodal] = @assegnatodal ";
                IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatodal", DbType.DateTime);
                param19.Value = value.Assegnatodal;
                collParams.Add(param19);
            }

            sql += " WHERE [idassegnazione] = @idassegnazione AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@UserID", DbType.Guid);
            param22.Value = value.UserId;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param21.Value = value.Targa;
            collParams.Add(param21);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param23.Value = value.Codsocieta;
            collParams.Add(param23);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param20.Value = value.Idassegnazione;
            collParams.Add(param20);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatoal", DbType.Date);
            param18.Value = value.Assegnatoal;
            collParams.Add(param18);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusassegnazione", DbType.Int32);
            param17.Value = value.Idstatusassegnazione;
            collParams.Add(param17);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param2.Value = value.Uidtenant;
            collParams.Add(param2);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public List<IContratti> SelectTemplateFatture(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_fatturexml_template WHERE uidtenant = @Uidtenant ORDER BY idtemplatefattura ";

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
                    IContratti item = new Contratti
                    {
                        Idtemplatefattura = DataHelper.IfDBNull<int>(row["idtemplatefattura"], 0),
                        Nometemplate = DataHelper.IfDBNull<string>(row["nometemplate"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateSvuotaAbbinamentoFattura(Guid Uidfattura, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_fatturexml_dettaglio SET [centrocostoabb] = '', [tipocentrocosto] = '', [Uidcentrocosto] = '" + Guid.Empty + "', " +
                         " [centrocostoabb2] = '', [tipocentrocosto2] = '', [Uidcentrocosto2] = '" + Guid.Empty + "', " +
                         " [centrocostoabb3] = '', [tipocentrocosto3] = '', [Uidcentrocosto3] = '" + Guid.Empty + "', " +
                         " [centrocostoabb4] = '', [tipocentrocosto4] = '', [Uidcentrocosto4] = '" + Guid.Empty + "' " +
                         " WHERE [Uidfattura] = @Uidfattura AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uidfattura", DbType.Guid);
            param22.Value = Uidfattura;
            collParams.Add(param22);

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
        public List<IContratti> ReturnCodiceCDC(DateTime datariferimentoda, DateTime datariferimentoa, string targa)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT u.codicecdc, u.UserId, a.assegnatodal, a.assegnatoal FROM EF_contratti_assegnazioni as a  " +
                         " INNER JOIN EF_users as u ON a.UserID = u.UserId " +
                         " WHERE a.targa = @targa and ((a.assegnatodal <= @datariferimentoda and a.assegnatoal >= @datariferimentoda) OR (a.assegnatodal <= @datariferimentoa and a.assegnatoal >= @datariferimentoa))";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@datariferimentoda", DbType.DateTime);
            param0.Value = datariferimentoda;
            collParams.Add(param0);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@datariferimentoa", DbType.DateTime);
            param2.Value = datariferimentoa;
            collParams.Add(param2);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param1.Value = targa;
            collParams.Add(param1);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Codicecdc = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int UpdateStatusOrdineScartato(int idapprovazione, Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;
            string sqlupd = SeoHelper.CampoDataStatusOrdine(100) + " = @data ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_ordini SET [idstatusordine] = 100, [motivoscarto] = 'Scartato per approvazione altra configurazione', " + sqlupd +
                         " WHERE idapprovazione = @idapprovazione and Uid <> @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@idapprovazione", DbType.Int32);
            param21.Value = idapprovazione;
            collParams.Add(param21);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@data", DbType.DateTime);
            param24.Value = DateTime.Now;
            collParams.Add(param24);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

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

        
        public int SelectCountConfigurazioniInviate(int idapprovazione)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini WHERE idapprovazione = @idapprovazione AND idstatusordine IN (1,10,20,25) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idapprovazione", DbType.Int32);
            param0.Value = idapprovazione;
            collParams.Add(param0);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public int SelectCountConfigurazioniDaFirmare(int idapprovazione)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini WHERE idapprovazione = @idapprovazione AND idstatusordine >= 40 and idstatusordine < 100 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idapprovazione", DbType.Int32);
            param0.Value = idapprovazione;
            collParams.Add(param0);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public List<IContratti> SelectUserCarPolicy(string keysearch, string codsocieta, Guid UserId, DateTime datadal, DateTime dataal, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND c.codcarpolicy = @keysearch ";
            if (UserId != Guid.Empty) condWhere += " AND u.UserId = @UserId ";
            if (datadal > DateTime.MinValue) condWhere += " AND c.dataapprovazione >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND c.dataapprovazione <= @dataal";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT c.dataapprovazione, c.datamail, c.idapprovazione, c.Uid, c.codcarpolicy, u.fasciacarpolicy, u.nome, u.cognome, c.preassegnazione FROM EF_users_carpolicy as c " +
                         " INNER JOIN EF_users as u ON c.idutente = u.iduser AND c.uidtenant = u.uidtenant " +
                         " WHERE c.codsocieta = @codsocieta AND c.uidtenant = @Uidtenant " + condWhere + " ORDER BY c.dataapprovazione DESC, c.datamail DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
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
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Idapprovazione = DataHelper.IfDBNull<int>(row["idapprovazione"], 0),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Fasciacarpolicy = DataHelper.IfDBNull<string>(row["fasciacarpolicy"], _stringEmpty),
                        Preassegnazione = DataHelper.IfDBNull<string>(row["preassegnazione"], _stringEmpty),
                        Dataapprovazione = DataHelper.IfDBNull<DateTime>(row["dataapprovazione"], DateTime.MinValue),
                        Datamail = DataHelper.IfDBNull<DateTime>(row["datamail"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountUserCarPolicy(string keysearch, string codsocieta, Guid UserId, DateTime datadal, DateTime dataal, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND c.codcarpolicy = @keysearch ";
            if (UserId != Guid.Empty) condWhere += " AND u.UserId = @UserId ";
            if (datadal > DateTime.MinValue) condWhere += " AND c.dataapprovazione >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND c.dataapprovazione <= @dataal";

            string SQL = " SELECT COUNT(*) as tot FROM EF_users_carpolicy as c INNER JOIN EF_users as u ON c.idutente = u.iduser AND c.uidtenant = u.uidtenant " +
                         " WHERE c.codsocieta = @codsocieta AND c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
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
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public int SelectCountConfigurazioniDaConfermareInviate(int idapprovazione)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini WHERE idapprovazione = @idapprovazione AND idstatusordine = 30 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idapprovazione", DbType.Int32);
            param0.Value = idapprovazione;
            collParams.Add(param0);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public int SelectCountConfigurazioniDaEvadereInviate(Guid UserId)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini WHERE UserId = @UserId AND idstatusordine IN (40,50,55) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public int SelectCountConfigurazioniEvaseInviate(int idapprovazione)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini WHERE idapprovazione = @idapprovazione AND idstatusordine = 60 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idapprovazione", DbType.Int32);
            param0.Value = idapprovazione;
            collParams.Add(param0);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public decimal SelectToTFuelXUser(string targa, Guid UserId)
        {
            string SQL = " SELECT SUM(importofinalefatturato) as tot FROM EF_users_fuelcard_consumo as c " +
                         " INNER JOIN EF_users_fuelcard as u ON c.numerofuelcard = u.numero " +
                         " INNER JOIN EF_compagnie as g ON c.idcompagnia = g.idcompagnia " +
                         " INNER JOIN EF_contratti_assegnazioni as ca ON ca.targa = u.targa " +
                         " INNER JOIN ef_utility_codifiche as uc ON uc.valore = c.tiporifornimento " +
                         " WHERE c.targa = @targa and datatransazione<= ca.assegnatoal and datatransazione>= ca.assegnatodal and ca.UserId = @UserId AND YEAR(datatransazione) = YEAR(GETDATE()) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param0.Value = targa;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = UserId;
            collParams.Add(param1);

            return _dataHelper.GetValue<decimal>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectStoricoAutoUser(Guid UserId)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.targa, cr.modello, f.fornitore, c.idcontratto, ca.assegnatodal, ca.assegnatoal, c.Uid, ca.idassegnazione, " +
                         " (SELECT TOP 1 kmpercorsi FROM EF_contratti_percorrenze WHERE UserId = c.UserId and targa = c.targa ORDER BY datains desc) as kmpercorsi," +
                         " (SELECT SUM(importofinalefatturato) FROM EF_users_fuelcard_consumo as ufc " +
                         " INNER JOIN EF_users_fuelcard as u ON c.targa = u.targa  and ufc.numerofuelcard = u.numero " +
                         " INNER JOIN EF_compagnie as g ON ufc.idcompagnia = g.idcompagnia " +
                         " INNER JOIN EF_contratti_assegnazioni as ca ON ca.targa = u.targa " +
                         " INNER JOIN ef_utility_codifiche as uc ON uc.valore = ufc.tiporifornimento " +
                         " WHERE ufc.targa = c.targa and ca.UserId = @UserId and datatransazione<= ca.assegnatoal and datatransazione>= ca.assegnatodal ) as importo " +
                         " FROM EF_contratti_assegnazioni as ca " +
                         " LEFT JOIN EF_contratti as c ON ca.targa = c.targa " +
                         " LEFT JOIN EF_carlist_auto as cr ON cr.codjatoauto = c.codjatoauto and cr.codcarlist = c.codcarlist and cr.codfornitore = c.codfornitore " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = c.codfornitore WHERE ca.UserId = @UserId ";


            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = UserId;
            collParams.Add(param1);
           
            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                        Idcontratto = DataHelper.IfDBNull<int>(row["idcontratto"], 0),
                        Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                        Kmpercorsi = DataHelper.IfDBNull<decimal>(row["kmpercorsi"], 0),
                        Idassegnazione = DataHelper.IfDBNull<int>(row["idassegnazione"], 0),
                        Importototale = DataHelper.IfDBNull<decimal>(row["importo"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectDocumentiAuto(string targa)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT * FROM EF_documenti_auto WHERE targa = @targa ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param1.Value = targa;
            collParams.Add(param1);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Nomefile = DataHelper.IfDBNull<string>(row["nomefile"], _stringEmpty),
                        Anno = DataHelper.IfDBNull<int>(row["anno"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectConsumiAutoXUser(string targa, DateTime datadal, DateTime dataal, Guid UserId)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT datatransazione, importofinalefatturato FROM EF_users_fuelcard_consumo as c " +
                         " INNER JOIN  EF_users_fuelcard as u ON c.targa = u.targa  and c.numerofuelcard = u.numero " +
                         " INNER JOIN EF_compagnie as g ON c.idcompagnia = g.idcompagnia " +
                         " INNER JOIN EF_contratti_assegnazioni as ca ON ca.targa = u.targa " +
                         " INNER JOIN ef_utility_codifiche as uc ON uc.valore = c.tiporifornimento " +
                         " WHERE c.targa = @targa and datatransazione >= @datadal and datatransazione <= @dataal and ca.UserId = @UserId ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param1.Value = targa;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
            param2.Value = datadal;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
            param3.Value = dataal;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param4.Value = UserId;
            collParams.Add(param4);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Datains = DataHelper.IfDBNull<DateTime>(row["datatransazione"], DateTime.MinValue),
                        Importototale = DataHelper.IfDBNull<decimal>(row["importofinalefatturato"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int InsertDocAuto(IContratti value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_documenti_auto ([tipofile],[nomefile],[anno],[targa]) " +
                         " VALUES (@tipofile,@nomefile,@anno,@targa) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@tipofile", DbType.String);
            param0.Value = value.Tipofile;
            collParams.Add(param0);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@nomefile", DbType.String);
            param2.Value = value.Nomefile;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@anno", DbType.Int32);
            param3.Value = value.Anno;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param4.Value = value.Targa;
            collParams.Add(param4);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public List<IContratti> SelectFileAuto(string targa, string codsocieta, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND ca.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";

            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT * FROM EF_contratti_assegnazioni as ca " +
                         " LEFT JOIN EF_societa as s ON ca.codsocieta = s.codsocieta AND ca.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_users as u ON ca.UserId = u.UserId AND ca.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_contratti as c ON c.idcontratto = ca.idcontratto AND c.uidtenant = ca.uidtenant " +
                         " WHERE idassegnazione > 0 AND ca.uidtenant = @Uidtenant " + condWhere + " ORDER BY idassegnazione " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param1.Value = targa;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param3.Value = UserId;
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
                    IContratti item = new Contratti
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Fileverbaleconsegna = DataHelper.IfDBNull<string>(row["fileverbaleconsegna"], _stringEmpty),
                        Filerelazioneperito = DataHelper.IfDBNull<string>(row["filerelazioneperito"], _stringEmpty),
                        Filedenunce = DataHelper.IfDBNull<string>(row["filedenunce"], _stringEmpty),
                        Filerifiutoauto = DataHelper.IfDBNull<string>(row["filerifiutoauto"], _stringEmpty),
                        Fileverbaleauto = DataHelper.IfDBNull<string>(row["fileverbaleauto"], _stringEmpty),
                        Filelibrettoauto = DataHelper.IfDBNull<string>(row["filelibrettoautocontratto"], _stringEmpty),
                        Documentofuelcard = DataHelper.IfDBNull<string>(row["documentofuelcard"], _stringEmpty),
                        Idassegnazione = DataHelper.IfDBNull<int>(row["idassegnazione"], 0),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountFileAuto(string targa, string codsocieta, Guid UserId, Guid Uidtenant)
        {
            string condWhere = "";

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND ca.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";

            string sql = " SELECT COUNT(*) as tot FROM EF_contratti_assegnazioni as ca " +
                         " LEFT JOIN EF_societa as s ON ca.codsocieta = s.codsocieta AND ca.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_users as u ON ca.UserId = u.UserId AND ca.uidtenant = u.uidtenant " +
                         " WHERE idassegnazione > 0 AND ca.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param1.Value = targa;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param3.Value = UserId;
                collParams.Add(param3);
            }

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param4.Value = Uidtenant;
            collParams.Add(param4);
            
            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }
        public List<IContratti> SelectFileDocumentiAuto(string targa)
        {
            string condWhere = "";

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND targa = @targa ";

            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT * FROM EF_documenti_auto WHERE iddocumento > 0 " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param1.Value = targa;
            collParams.Add(param1);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Tipofile = DataHelper.IfDBNull<string>(row["tipofile"], _stringEmpty),
                        Nomefile = DataHelper.IfDBNull<string>(row["nomefile"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int UpdateFileAuto(IContratti value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_contratti_assegnazioni SET [fileverbaleconsegna] = @fileverbaleconsegna, [filerelazioneperito] = @filerelazioneperito, [filedenunce] = @filedenunce, " +
                         " [filerifiutoauto] = @filerifiutoauto, [fileverbaleauto] = @fileverbaleauto, " +
                         " [documentofuelcard] = @documentofuelcard WHERE idassegnazione = @idassegnazione AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@fileverbaleconsegna", DbType.String);
            param19.Value = value.Fileverbaleconsegna;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@filerelazioneperito", DbType.String);
            param20.Value = value.Filerelazioneperito;
            collParams.Add(param20);

            IDbDataParameter param33 = _dataHelper.ProviderConn.CreateDataParameter("@filedenunce", DbType.String);
            param33.Value = value.Filedenunce;
            collParams.Add(param33);

            IDbDataParameter param34 = _dataHelper.ProviderConn.CreateDataParameter("@filerifiutoauto", DbType.String);
            param34.Value = value.Filerifiutoauto;
            collParams.Add(param34);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@fileverbaleauto", DbType.String);
            param35.Value = value.Fileverbaleauto;
            collParams.Add(param35);

            IDbDataParameter param38 = _dataHelper.ProviderConn.CreateDataParameter("@documentofuelcard", DbType.String);
            param38.Value = value.Documentofuelcard;
            collParams.Add(param38);

            IDbDataParameter param37 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param37.Value = value.Idassegnazione;
            collParams.Add(param37);

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

        public int SelectCountInConfigurazione(int idapprovazione)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini WHERE idapprovazione = @idapprovazione AND idstatusordine = 0 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idapprovazione", DbType.Int32);
            param0.Value = idapprovazione;
            collParams.Add(param0);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public IContratti SelectKmPercorsiAttuali(string targa)
        {
            IContratti retVal = null;
            string sql = " SELECT TOP 1 kmpercorsi FROM EF_contratti_percorrenze WHERE targa = @targa ORDER BY datains DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param1.Value = targa;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Kmpercorsi = DataHelper.IfDBNull<decimal>(row["kmpercorsi"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectFringeInCorso(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant, int numrecord, int pagina)
        {
            string condWhere = "";
            string condWhere2 = "";
            string paginazione;
            string datainizioass;
            string datafineass;
            string datainizioassprev;
            string datafineassprev;
            string periodo = "01/" + mese + "/" + anno;
            string periodoprev = "01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;

            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(codsocieta))
            {
                condWhere += " AND u.codsocieta = @codsocieta ";
                condWhere2 += " AND u.codsocieta = @codsocieta ";
            }

            if (UserId != Guid.Empty)
            {
                condWhere += " AND u.UserId = @UserId ";
                condWhere2 += " AND u.UserId = @UserId ";
            }

            if (!string.IsNullOrEmpty(mese) && anno > 0)
            {
                datainizioass = "01/" + mese + "/" + anno;
                datafineass = DateTime.DaysInMonth(anno, SeoHelper.IntString(mese)) + "/" + mese + "/" + anno;
                datainizioassprev = Convert.ToDateTime("01/" + mese + "/" + anno).AddMonths(-1).ToString("dd/MM/yyyy");
                datafineassprev = Convert.ToDateTime(DateTime.DaysInMonth(anno, SeoHelper.IntString(mese)) + "/" + mese + "/" + anno).AddMonths(-1).ToString("dd/MM/yyyy");

                condWhere += " AND ((a.assegnatodal >= @datainizioass and a.assegnatoal >= @datafineass) OR (a.assegnatodal <= @datainizioass and a.assegnatoal >= @datafineass)) ";
                condWhere2 += " AND ((a.assegnatodal >= @datainizioassprev and a.assegnatodal <= @datafineassprev) OR (a.assegnatoal >= @datainizioassprev and a.assegnatoal <= @datafineassprev)) ";
            }
            else
            {
                datainizioass = "01/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                datafineass = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                datainizioassprev = "01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
                datafineassprev = DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;

                condWhere += " AND ((a.assegnatodal >= @datainizioass and a.assegnatoal >= @datafineass) OR (a.assegnatodal <= @datainizioass and a.assegnatoal >= @datafineass)) ";
                condWhere2 += " AND ((a.assegnatodal >= @datainizioassprev and a.assegnatodal <= @datafineassprev) OR (a.assegnatoal >= @datainizioassprev and a.assegnatoal <= @datafineassprev)) ";
            }

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT u.nome, u.cognome, u.matricola, c.fringebenefit, c.emissioni, ca.fringebenefitbase, ca.modello, a.assegnatodal, a.assegnatoal, " +
                         " ca.codjatoauto, c.targa, u.codicecdc, u.codsocieta, s.codcompany, s.societa, '" + periodo + "' as periodo FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON c.idcontratto = a.idcontratto AND a.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = a.UserId AND u.uidtenant = a.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto and ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore AND ca.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_societa as s On s.codsocieta = u.codsocieta AND s.uidtenant = u.uidtenant " +
                         " WHERE a.idassegnazione > 0 AND c.uidtenant = @Uidtenant and matricola<>'POOL' and matricola<>'RITIRO' and c.idstatuscontratto <> 110 " + condWhere +
                         " UNION ALL " +
                         " SELECT u.nome, u.cognome, u.matricola, c.fringebenefit, c.emissioni, ca.fringebenefitbase, ca.modello, a.assegnatodal, a.assegnatoal, " +
                         " ca.codjatoauto, c.targa, u.codicecdc, c.codsocieta, s.codcompany, s.societa, '" + periodoprev + "' as periodo FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON c.idcontratto = a.idcontratto AND a.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = a.UserId AND u.uidtenant = a.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto and ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore AND ca.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_societa as s On s.codsocieta = u.codsocieta AND s.uidtenant = u.uidtenant " +
                         " WHERE a.idassegnazione > 0 AND c.uidtenant = @Uidtenant and matricola<>'POOL' and matricola<>'RITIRO' AND codicedivisione= 'Libro Paga' and c.idstatuscontratto <> 110 " + condWhere2 +
                         " ORDER BY a.assegnatoal " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
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

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@datainizioassprev", DbType.DateTime);
            param8.Value = datainizioassprev;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@datafineassprev", DbType.DateTime);
            param9.Value = datafineassprev;
            collParams.Add(param9);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Codicecdc = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Fringebenefit = DataHelper.IfDBNull<decimal>(row["fringebenefit"], 0),
                        Fringebenefitbase = DataHelper.IfDBNull<decimal>(row["fringebenefitbase"], 0),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                        Emissioni = DataHelper.IfDBNull<decimal>(row["emissioni"], 0),
                        Codcompany = DataHelper.IfDBNull<string>(row["codcompany"], _stringEmpty),
                        Periodo = DataHelper.IfDBNull<string>(row["periodo"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountFringeInCorso(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant)
        {
            string condWhere = "";
            string datainizioass;
            string datafineass;

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND u.UserId = @UserId ";
            if (!string.IsNullOrEmpty(mese) && anno > 0)
            {
                datainizioass = "01/" + mese + "/" + anno;
                datafineass = DateTime.DaysInMonth(anno, SeoHelper.IntString(mese)) + "/" + mese + "/" + anno;
                condWhere += " AND ((a.assegnatodal >= @datainizioass and a.assegnatoal >= @datafineass) OR (a.assegnatodal <= @datainizioass and a.assegnatoal >= @datafineass)) ";
            }
            else
            {
                datainizioass = "01/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                datafineass = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                condWhere += " AND ((a.assegnatodal >= @datainizioass and a.assegnatoal >= @datafineass) OR (a.assegnatodal <= @datainizioass and a.assegnatoal >= @datafineass)) ";
            }

            string sql = " SELECT COUNT(a.idassegnazione) as tot FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON c.idcontratto = a.idcontratto AND a.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = a.UserId AND u.uidtenant = a.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto and ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore AND ca.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_societa as s On s.codsocieta = c.codsocieta AND s.uidtenant = c.uidtenant " +
                         " WHERE a.idassegnazione > 0 AND c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
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

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }


        public int SelectCountOrdiniInCorsoTeamAppr(string keysearch, string codsocieta, string codgrade, string codcarlist, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (idstatusordine > 0) condWhere += " AND o.idstatusordine = @idstatusordine ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND g.codgrade = @codgrade ";
            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " AND o.codcarlist = @codcarlist ";
            if (datadal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') <= @dataal";

            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId AND o.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore AND ca.uidtenant = o.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta AND o.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist as cl ON cl.codcarlist = o.codcarlist AND o.uidtenant = cl.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND u.uidtenant = g.uidtenant " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine AND os.uidtenant = o.uidtenant " +
                         " WHERE o.idordine > 0 AND o.idstatusordine > 0 AND o.idstatusordine < 60 AND o.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (idstatusordine > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param1.Value = idstatusordine;
                collParams.Add(param1);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param4.Value = codgrade;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param5.Value = codcarlist;
                collParams.Add(param5);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
                collParams.Add(param8);
            }
            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectOrdiniInCorsoTeamAppr(string keysearch, string codsocieta, string codgrade, string codcarlist, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (idstatusordine > -1) condWhere += " AND o.idstatusordine = @idstatusordine ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND g.codgrade = @codgrade ";
            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " AND o.codcarlist = @codcarlist ";
            if (datadal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND FORMAT(o.dataordine, 'dd/MM/yyyy') <= @dataal";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.codjatoauto, ca.modello, cl.carlist, s.societa, g.grade, o.dataordine, o.numeroordine, o.Uid, u.cognome, " +
                         " u.nome, u.matricola, os.statusordine, o.idstatusordine, o.deltacanone, u.iduser, o.fileordinepdf, o.dataconsegnaprevista FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId AND o.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore AND o.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta AND o.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist as cl ON cl.codcarlist = o.codcarlist AND o.uidtenant = cl.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND u.uidtenant = g.uidtenant " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine AND o.uidtenant = os.uidtenant " +
                         " WHERE o.idordine > 0 AND o.idstatusordine > 0 AND o.idstatusordine < 60 AND o.uidtenant = @Uidtenant " + condWhere +
                         " ORDER BY o.dataordine DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (idstatusordine > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param1.Value = idstatusordine;
                collParams.Add(param1);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param4.Value = codgrade;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param5.Value = codcarlist;
                collParams.Add(param5);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
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
                    IContratti item = new Contratti
                    {
                        Idutente = DataHelper.IfDBNull<int>(row["iduser"], 0),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["carlist"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty),
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Dataconsegnaprevista = DataHelper.IfDBNull<DateTime>(row["dataconsegnaprevista"], DateTime.MinValue),
                        Fileordinepdf = DataHelper.IfDBNull<string>(row["fileordinepdf"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectAllStatusOrdineApprovatori(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_ordini_status WHERE idstatusordine < 60 AND uidtenant = @Uidtenant ORDER BY statusordine ";

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
                    IContratti item = new Contratti
                    {
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectCarPolicyPoolTeamAppr(string keysearch, string codsocieta, string targa, int idstatuspool, string luogo, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (c.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND c.targa = @targa ";
            if (idstatuspool > -1) condWhere += " AND c.idstatuspool = @idstatuspool ";
            if (!string.IsNullOrEmpty(luogo)) condWhere += " AND c.targa = (SELECT targa FROM EF_contratti_assegnazioni AS caaa WHERE (targa = c.Targa) AND (luogorestituzione <> '' and luogorestituzione LIKE '%' + @luogo + '%')) ";

            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT ca.modello, c.targa, c.codcarpolicy, c.deltacanone, c.fringebenefit, c.kmcontratto, c.checkordinepool, u.cognome, u.nome, " +
                         " (SELECT TOP 1 kmpercorsi FROM EF_contratti_percorrenze as cp WHERE cp.targa = c.targa ORDER BY cp.datains DESC) as kmpercorsi, " +
                         " c.datacontratto, c.datafinecontratto, a.assegnatodal,  (SELECT  TOP (1) luogorestituzione FROM dbo.EF_contratti_assegnazioni AS caaa WHERE(targa = c.Targa) AND(luogorestituzione <> '') oRDER BY idassegnazione DESC) AS luogorestituzione, asa.statusauto, sp.statuspool, c.Uid, op.optional, ca.Alimentazione " +
                         " FROM EF_contratti as c  " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON c.idcontratto = a.idcontratto and idstatusassegnazione = 5 AND c.uidtenant = a.uidtenant and a.idassegnazione in (select top 1 idassegnazione from dbo.EF_contratti_assegnazioni where idstatusassegnazione=5 and targa=c.targa order by assegnatoal desc ) " +
                         " LEFT JOIN EF_contratti_assegnazioni_status_pool as sp ON sp.idstatuspool = c.idstatuspool AND c.uidtenant = sp.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni_status_auto as asa ON a.idstatoauto = asa.idstatusauto AND a.uidtenant = asa.uidtenant " +
                         " LEFT JOIN EF_carlist_optional as op ON c.codcolore = op.codoptional AND c.uidtenant = op.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto AND ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore AND ca.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserIdpool AND c.uidtenant = u.uidtenant " +
                         " WHERE checkpool = 1 AND c.uidtenant = @Uidtenant " + condWhere +
                         " ORDER BY c.targa   " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param3.Value = targa;
                collParams.Add(param3);
            }
            if (idstatuspool > -1)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuspool", DbType.Int32);
                param4.Value = idstatuspool;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(luogo))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@luogo", DbType.String);
                param5.Value = luogo;
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
                    IContratti item = new Contratti
                    {
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Fringebenefit = DataHelper.IfDBNull<decimal>(row["fringebenefit"], 0),
                        Kmcontratto = DataHelper.IfDBNull<int>(row["kmcontratto"], 0),
                        Kmpercorsi = DataHelper.IfDBNull<decimal>(row["kmpercorsi"], 0),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Luogoconsegna = DataHelper.IfDBNull<string>(row["luogorestituzione"], _stringEmpty),
                        Statoauto = DataHelper.IfDBNull<string>(row["statusauto"], _stringEmpty),
                        Statuspool = DataHelper.IfDBNull<string>(row["statuspool"], _stringEmpty),
                        Codcolore = DataHelper.IfDBNull<string>(row["optional"], _stringEmpty),
                        Alimentazione = DataHelper.IfDBNull<string>(row["Alimentazione"], _stringEmpty),
                        Checkordinepool = DataHelper.IfDBNull<int>(row["checkordinepool"], 0),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountCarPolicyPoolTeamAppr(string keysearch, string codsocieta, string targa, int idstatuspool, string luogo, Guid Uidtenant)
        {
            string condWhere = "";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (c.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND c.targa = @targa ";
            if (idstatuspool > -1) condWhere += " AND c.idstatuspool = @idstatuspool ";
            if (!string.IsNullOrEmpty(luogo)) condWhere += " AND c.targa = (SELECT targa FROM EF_contratti_assegnazioni AS caaa WHERE (targa = c.Targa) AND (luogorestituzione <> '' and luogorestituzione LIKE '%' + @luogo + '%')) ";

            string SQL = " SELECT COUNT(c.Uid) as tot " +
                         " FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON c.idcontratto = a.idcontratto and idstatusassegnazione = 5 AND c.uidtenant = a.uidtenant and a.idassegnazione in (select top 1 idassegnazione from dbo.EF_contratti_assegnazioni where idstatusassegnazione=5 and targa=c.targa  order by assegnatoal desc ) " +
                         " LEFT JOIN EF_contratti_assegnazioni_status_pool as sp ON sp.idstatuspool = c.idstatuspool AND c.uidtenant = sp.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni_status_auto as asa ON a.idstatoauto = asa.idstatusauto AND a.uidtenant = asa.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto AND ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore AND ca.uidtenant = c.uidtenant " +
                         " WHERE checkpool = 1 AND c.uidtenant = @Uidtenant " + condWhere;

            List <IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param3.Value = targa;
                collParams.Add(param3);
            }
            if (idstatuspool > -1)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuspool", DbType.Int32);
                param4.Value = idstatuspool;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(luogo))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@luogo", DbType.String);
                param5.Value = luogo;
                collParams.Add(param5);
            }
            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param6.Value = Uidtenant;
            collParams.Add(param6);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public int SelectCountRunningTeamAppr(string codsocieta, Guid UserId, string marca, string modello, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND ca.marca = @marca ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND ca.modello = @modello ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND c.datafinecontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND c.datafinecontratto <= @datacontrattoal";
            if (idstatuscontratto > 0) condWhere += " AND c.idstatuscontratto = @idstatuscontratto ";

            string SQL = " SELECT COUNT(c.Uid) as tot FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_status as cs ON cs.idstatuscontratto = c.idstatuscontratto AND c.uidtenant = cs.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto AND ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore AND ca.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserId AND c.uidtenant = u.uidtenant " +
                         " WHERE c.idstatuscontratto <100 AND c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param3.Value = modello;
                collParams.Add(param3);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatuscontratto > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
                param8.Value = idstatuscontratto;
                collParams.Add(param8);
            }
            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);
            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectRunningTeamAppr(string codsocieta, Guid UserId, string marca, string modello, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND ca.marca = @marca ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " AND ca.modello = @modello ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND c.datafinecontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND c.datafinecontratto <= @datacontrattoal";
            if (idstatuscontratto > 0) condWhere += " AND c.idstatuscontratto = @idstatuscontratto ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT c.targa, ca.modello, c.codcarpolicy, u.nome, u.cognome, u.matricola, c.deltacanone, c.fringebenefit, c.kmcontratto, " + 
                         " (SELECT TOP 1 kmpercorsi FROM EF_contratti_percorrenze as cp WHERE cp.targa = c.targa ORDER BY cp.datains DESC) as kmpercorsi, " +
                         " c.datacontratto, c.datafinecontratto, cs.statuscontratto, c.Uid, '' as statusauto, '' as Statuscontratto FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_status as cs ON cs.idstatuscontratto = c.idstatuscontratto AND cs.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto AND ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore AND c.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserId AND u.uidtenant = c.uidtenant " +
                         " WHERE c.idstatuscontratto <100 AND c.uidtenant = @Uidtenant " + condWhere + " ORDER BY c.datafinecontratto DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(modello))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param3.Value = modello;
                collParams.Add(param3);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatuscontratto > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
                param8.Value = idstatuscontratto;
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
                    IContratti item = new Contratti
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " <br>(" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Fringebenefit = DataHelper.IfDBNull<decimal>(row["fringebenefit"], 0),
                        Kmcontratto = DataHelper.IfDBNull<int>(row["kmcontratto"], 0),
                        Kmpercorsi = DataHelper.IfDBNull<decimal>(row["kmpercorsi"], 0),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                        Statoauto = DataHelper.IfDBNull<string>(row["statusauto"], _stringEmpty),
                        Statuscontratto = DataHelper.IfDBNull<string>(row["statuscontratto"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int UpdateAutoPool(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti_assegnazioni SET [idstatusassegnazione] = @idstatusassegnazione, [idstatoauto] = @idstatoauto, [luogoconsegna] = @luogoconsegna, " +
                         " [noteamministrazione] = @noteamministrazione WHERE idcontratto = @idcontratto AND UserId = @UserId AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@idcontratto", DbType.Int32);
            param22.Value = value.Idcontratto;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param21.Value = value.UserId;
            collParams.Add(param21);

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusassegnazione", DbType.Int32);
            param0.Value = value.Idstatusassegnazione;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatoauto", DbType.Int32);
            param1.Value = value.Idstatoauto;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@luogoconsegna", DbType.String);
            param2.Value = value.Luogoconsegna;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@noteamministrazione", DbType.String);
            param3.Value = value.Noteamministrazione;
            collParams.Add(param3);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param12.Value = value.Uidtenant;
            collParams.Add(param12);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        public int SelectCountOrdiniRental(string codfornitore, int idstatus)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini " +
                         " WHERE idstatusordine = @idstatus AND codfornitore = @codfornitore ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param6.Value = codfornitore;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@idstatus", DbType.Int32);
            param7.Value = idstatus;
            collParams.Add(param7);            

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // conta richieste ordini rental evasi
        // FILTRO: keysearch, UserId
        public int SelectCountRichiesteOrdiniRentalEvasi(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (idstatusordine > 0)
            {
                condWhere += " AND o.idstatusordine = @idstatusordine ";
            }
            else
            {
                condWhere += " AND o.idstatusordine > 50 ";
            }
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (datadal > DateTime.MinValue) condWhere += " AND o.dataordine >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND o.dataordine <= @dataal";

            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine " +
                         " WHERE o.codfornitore = @codfornitore " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (idstatusordine > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param1.Value = idstatusordine;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param6.Value = codsocieta;
                collParams.Add(param6);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
                collParams.Add(param8);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param3.Value = codfornitore;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista richieste ordini rental vasi
        // FILTRO: keysearch, UserId
        public List<IContratti> SelectRichiesteOrdiniRentalEvasi(int idstatusordine, string keysearch, Guid UserId, string codfornitore, string codsocieta, DateTime datadal, DateTime dataal, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (idstatusordine > 0)
            {
                condWhere += " AND o.idstatusordine = @idstatusordine ";
            }
            else
            {
                condWhere += " AND o.idstatusordine > 50 ";
            }
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (datadal > DateTime.MinValue) condWhere += " AND o.dataordine >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND o.dataordine <= @dataal";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.codjatoauto, ca.modello, ca.marca, o.codcarlist, s.siglasocieta, g.grade, o.dataordine, o.numeroordine, o.Uid, u.cognome, " +
                         " u.nome, u.matricola, u.cellulare, u.email, o.sederecapito, os.statusordine, o.idstatusordine, o.deltacanone, o.idordine, o.fileordinepdf, " +
                         " (SELECT DISTINCT ao.optional FROM EF_ordini_optional as o1 LEFT JOIN EF_carlist_optional as ao ON ao.codoptional = o1.codoptional " +
                         " WHERE o1.codoptional IN (SELECT codoptional FROM EF_carlist_optional WHERE codcategoriaoptional = 'COL') and o.idordine = o1.idordine) as colore " +
                         " FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine " +
                         " WHERE o.codfornitore = @codfornitore " + condWhere +
                         " ORDER BY o.dataordine DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (idstatusordine > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param1.Value = idstatusordine;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param6.Value = codsocieta;
                collParams.Add(param6);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
                collParams.Add(param8);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param3.Value = codfornitore;
            collParams.Add(param3);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Idordine = DataHelper.IfDBNull<int>(row["idordine"], 0),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty),
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                        Fileordinepdf = DataHelper.IfDBNull<string>(row["fileordinepdf"], _stringEmpty),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Cellulare = DataHelper.IfDBNull<string>(row["cellulare"], _stringEmpty),
                        Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                        Sedelavoro = DataHelper.IfDBNull<string>(row["sederecapito"], _stringEmpty),
                        Codcolore = DataHelper.IfDBNull<string>(row["colore"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        public int SelectCountUserCarPolicyPageAdmin(string codsocieta, string carpolicy, Guid UserId, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(carpolicy)) condWhere += " AND c.codcarpolicy = @carpolicy ";
            if (UserId != Guid.Empty) condWhere += " AND u.UserId = @UserId ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_users_carpolicy as c INNER JOIN EF_users as u ON c.idutente = u.iduser AND c.uidtenant = u.uidtenant " +
                         " WHERE c.idapprovazione > 0 AND c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(carpolicy))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@carpolicy", DbType.String);
                param0.Value = carpolicy;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectUserCarPolicyPageAdmin(string codsocieta, string carpolicy, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(carpolicy)) condWhere += " AND c.codcarpolicy = @carpolicy ";
            if (UserId != Guid.Empty) condWhere += " AND u.UserId = @UserId ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT c.*, u.nome, u.cognome, u.matricola, g.grade, s.siglasocieta FROM EF_users_carpolicy as c INNER JOIN EF_users as u ON c.idutente = u.iduser " +
                         " INNER JOIN EF_societa as s ON s.codsocieta = c.codsocieta AND s.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND u.uidtenant = g.uidtenant " +
                         " WHERE c.idapprovazione > 0 AND c.uidtenant = @Uidtenant " + condWhere + " ORDER BY u.cognome, u.nome " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(carpolicy))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@carpolicy", DbType.String);
                param0.Value = carpolicy;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
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
                    IContratti item = new Contratti
                    {
                        Idapprovazione = DataHelper.IfDBNull<int>(row["idapprovazione"], 0),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Motivazione = DataHelper.IfDBNull<string>(row["motivazione"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Codpacchetto = DataHelper.IfDBNull<string>(row["codpacchetto"], _stringEmpty),
                        Codcarbenefit = DataHelper.IfDBNull<string>(row["codcarbenefit"], _stringEmpty),
                        Sceltabenefit = DataHelper.IfDBNull<string>(row["sceltabenefit"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Preassegnazione = DataHelper.IfDBNull<string>(row["preassegnazione"], _stringEmpty),
                        Dataapprovazione = DataHelper.IfDBNull<DateTime>(row["dataapprovazione"], DateTime.MinValue),
                        Datamail = DataHelper.IfDBNull<DateTime>(row["datamail"], DateTime.MinValue),
                        Approvato = DataHelper.IfDBNull<int>(row["approvato"], 0),
                        Idstatusassegnazione = DataHelper.IfDBNull<int>(row["idstatoapprovazione"], 0),
                        Documentocarpolicy = DataHelper.IfDBNull<string>(row["documentocarpolicy"], _stringEmpty),
                        Datadocpolicy = DataHelper.IfDBNull<DateTime>(row["datadocpolicy"], DateTime.MinValue),
                        Datadecorrenza = DataHelper.IfDBNull<DateTime>(row["datadecorrenza"], DateTime.MinValue),
                        Datafinedecorrenza = DataHelper.IfDBNull<DateTime>(row["datafinedecorrenza"], DateTime.MinValue),
                        Datarinuncia = DataHelper.IfDBNull<DateTime>(row["datarinuncia"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //esistenza vecchia carpolicy
        public IContratti ExistOldUserCarPolicy(int idutente)
        {
            IContratti retVal = null;
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");
            string sql = " SELECT TOP 1 * FROM EF_users_carpolicy WHERE idutente = @idutente and dataapprovazione = @dataoggi ORDER BY idapprovazione DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idutente", DbType.Int32);
            param1.Value = idutente;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.Date);
            param2.Value = dataoggi;
            collParams.Add(param2);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Idapprovatore = DataHelper.IfDBNull<int>(row["idapprovatore"], 0),
                    Dataapprovazione = DataHelper.IfDBNull<DateTime>(row["dataapprovazione"], DateTime.MinValue),
                    Approvato = DataHelper.IfDBNull<int>(row["approvato"], 0),
                    Datadecorrenza = DataHelper.IfDBNull<DateTime>(row["datadecorrenza"], DateTime.MinValue),
                    Datamail = DataHelper.IfDBNull<DateTime>(row["datamail"], DateTime.MinValue),
                    Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                    Codcarbenefit = DataHelper.IfDBNull<string>(row["codcarbenefit"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public bool ExistStoricoAuto(Guid UserID)
        {
            bool retVal = false;
            string sql = " SELECT idcontratto FROM EF_contratti WHERE UserID = @UserID ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserID", DbType.Guid);
            param0.Value = UserID;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public List<IContratti> SelectAutoUser(Guid UserId)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT c.targa, ca.modello, c.codcarpolicy, o.deltacanone, c.fringebenefit, " +
                         " (SELECT TOP 1 kmpercorsi FROM EF_contratti_percorrenze as cp WHERE cp.targa = c.targa ORDER BY cp.datains DESC) as kmpercorsi, " +
                         " c.datacontratto, c.datafinecontratto, a.assegnatodal, a.assegnatoal FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON a.idcontratto = c.idcontratto " +
                         " LEFT JOIN EF_ordini as o ON o.Uid = c.Uidordine " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = c.codjatoauto AND ca.codcarlist = c.codcarlist and ca.codfornitore = c.codfornitore " +
                         " WHERE a.UserId = @UserId ORDER BY c.datacontratto DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = UserId;
            collParams.Add(param1);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Fringebenefit = DataHelper.IfDBNull<decimal>(row["fringebenefit"], 0),
                        Kmpercorsi = DataHelper.IfDBNull<decimal>(row["kmpercorsi"], 0),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectOrdiniUser(Guid UserId)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.codjatoauto, ca.modello, cl.carlist, s.societa, g.grade, o.dataordine, o.numeroordine, o.Uid, u.cognome, " +
                         " u.nome, u.matricola, os.statusordine, o.idstatusordine, o.deltacanone, u.iduser, o.fileordinepdf FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta " +
                         " LEFT JOIN EF_carlist as cl ON cl.codcarlist = o.codcarlist " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine " +
                         " WHERE o.UserId = @UserId ORDER BY o.dataordine DESC ";

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
                    IContratti item = new Contratti
                    {
                        Idutente = DataHelper.IfDBNull<int>(row["iduser"], 0),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["carlist"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty),
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Fileordinepdf = DataHelper.IfDBNull<string>(row["fileordinepdf"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectFuelCardUser(Guid UserId)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT f.Uid, f.scadenza, f.targa, f.numero, c.compagnia FROM EF_users_fuelcard as f " +
                         " INNER JOIN EF_compagnie as c ON c.idcompagnia = f.idcompagnia " +
                         " INNER JOIN EF_contratti_assegnazioni as ca ON ca.targa = f.targa " +
                         " WHERE ca.UserId = @UserId ORDER BY f.scadenza DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = UserId;
            collParams.Add(param1);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Datains = DataHelper.IfDBNull<DateTime>(row["scadenza"], DateTime.MinValue),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Numerodocumento = DataHelper.IfDBNull<string>(row["numero"], _stringEmpty),
                        Compagnia = DataHelper.IfDBNull<string>(row["compagnia"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectStatusFatture(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_fatturexml_status WHERE uidtenant = @Uidtenant ORDER BY idstatusfattura ";

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
                    IContratti item = new Contratti
                    {
                        Idstatusfattura = DataHelper.IfDBNull<int>(row["idstatusfattura"], 0),
                        Statusfattura = DataHelper.IfDBNull<string>(row["statusfattura"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountFattureNonAbbinate(Guid Uidfattura)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_fatturexml_dettaglio " +
                         " WHERE Uidfattura = @Uidfattura AND (centrocostoabb = '' or centrocostoabb is null) AND (centrocostoabb2 = '' or centrocostoabb2 is null) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@Uidfattura", DbType.Guid);
            param2.Value = Uidfattura;
            collParams.Add(param2);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public int UpdateProrogaContratto(Guid Uid, DateTime dataproroga, string nota, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti SET [dataprorogacontratto] = @dataproroga, [datafinecontratto] = @dataproroga, [noteproroga] = @nota WHERE [Uid] = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@nota", DbType.String);
            param21.Value = nota;
            collParams.Add(param21);
            
            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@dataproroga", DbType.Date);
            param18.Value = dataproroga;
            collParams.Add(param18);

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

        public int SelectCountAssegnazioniContratti(string targa, string targasearch, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (!string.IsNullOrEmpty(targasearch)) condWhere += " AND ca.targa = @targasearch ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND ca.assegnatoal >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND ca.assegnatoal <= @datacontrattoal";
            if (idstatusassegnazione > -1) condWhere += " AND ca.idstatusassegnazione = @idstatusassegnazione ";

            string sql = " SELECT COUNT(ca.idassegnazione) as tot FROM EF_contratti_assegnazioni as ca " +
                         " INNER JOIN EF_contratti as c ON ca.targa = c.targa AND ca.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni_status as cs ON cs.idstatusassegnazione = ca.idstatusassegnazione AND cs.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = ca.UserID AND ca.uidtenant = u.uidtenant " +
                         " WHERE ca.idassegnazione > 0 AND ca.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (!string.IsNullOrEmpty(targasearch))
            {
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@targasearch", DbType.String);
                param10.Value = targasearch;
                collParams.Add(param10);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatusassegnazione > -1)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusassegnazione", DbType.Int32);
                param8.Value = idstatusassegnazione;
                collParams.Add(param8);
            }

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);            

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectAssegnazioniContratti(string targa, string targasearch, Guid UserId, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatusassegnazione, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " ca.assegnatoal DESC ";
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

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (!string.IsNullOrEmpty(targasearch)) condWhere += " AND ca.targa = @targasearch ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND ca.assegnatoal >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND ca.assegnatoal <= @datacontrattoal";
            if (idstatusassegnazione > -1) condWhere += " AND ca.idstatusassegnazione = @idstatusassegnazione ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.targa, c.codfornitore, c.numerocontratto, c.datacontratto, u.cognome, u.nome, ca.assegnatodal, ca.assegnatoal, " +
                         " cs.statusassegnazione, ca.idassegnazione, s.siglasocieta FROM EF_contratti_assegnazioni as ca " +
                         " INNER JOIN EF_contratti as c ON ca.targa = c.targa AND c.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_contratti_assegnazioni_status as cs ON cs.idstatusassegnazione = ca.idstatusassegnazione AND cs.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = ca.codsocieta AND s.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = ca.UserID AND ca.uidtenant = u.uidtenant " +
                         " WHERE ca.idassegnazione > 0 AND ca.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (!string.IsNullOrEmpty(targasearch))
            {
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@targasearch", DbType.String);
                param10.Value = targasearch;
                collParams.Add(param10);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatusassegnazione > -1)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusassegnazione", DbType.Int32);
                param8.Value = idstatusassegnazione;
                collParams.Add(param8);
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
                    IContratti item = new Contratti
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                        Statusassegnazione = DataHelper.IfDBNull<string>(row["statusassegnazione"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Idassegnazione = DataHelper.IfDBNull<int>(row["idassegnazione"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IContratti DetailAssegnazioniContrattiXId(int idassegnazione)
        {
            IContratti retVal = null;
            string sql = "SELECT * FROM EF_contratti_assegnazioni WHERE idassegnazione = @idassegnazione ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param0.Value = idassegnazione;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Idcontratto = DataHelper.IfDBNull<int>(row["idcontratto"], 0),
                    Idstatusassegnazione = DataHelper.IfDBNull<int>(row["idstatusassegnazione"], 0),
                    Idstatoauto = DataHelper.IfDBNull<int>(row["idstatoauto"], 0),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                    Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                    Datarestituzione = DataHelper.IfDBNull<DateTime>(row["datarestituzione"], DateTime.MinValue),
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    Orarestituzione = DataHelper.IfDBNull<string>(row["orarestituzione"], _stringEmpty),
                    Luogorestituzione = DataHelper.IfDBNull<string>(row["luogorestituzione"], _stringEmpty),
                    Centrorestituzione = DataHelper.IfDBNull<string>(row["centrorestituzione"], _stringEmpty),
                    Fileverbaleconsegna = DataHelper.IfDBNull<string>(row["fileverbaleconsegna"], _stringEmpty),
                    Filerelazioneperito = DataHelper.IfDBNull<string>(row["filerelazioneperito"], _stringEmpty),
                    Filedenunce = DataHelper.IfDBNull<string>(row["filedenunce"], _stringEmpty),
                    Noteamministrazione = DataHelper.IfDBNull<string>(row["noteamministrazione"], _stringEmpty),
                    Notedriver = DataHelper.IfDBNull<string>(row["notedriver"], _stringEmpty),
                    Checkdoc = DataHelper.IfDBNull<string>(row["checkdoc"], _stringEmpty),
                    Idassegnazione = DataHelper.IfDBNull<int>(row["idassegnazione"], 0),
                    Dataconsegna = DataHelper.IfDBNull<DateTime>(row["dataconsegna"], DateTime.MinValue),
                    Oraconsegna = DataHelper.IfDBNull<string>(row["oraconsegna"], _stringEmpty),
                    Luogoconsegna = DataHelper.IfDBNull<string>(row["luogoconsegna"], _stringEmpty),
                    Motivoscarto = DataHelper.IfDBNull<string>(row["motivoscarto"], _stringEmpty),
                    Filerifiutoauto = DataHelper.IfDBNull<string>(row["filerifiutoauto"], _stringEmpty),
                    Fileverbaleauto = DataHelper.IfDBNull<string>(row["fileverbaleauto"], _stringEmpty),
                    Filelibrettoauto = DataHelper.IfDBNull<string>(row["filelibrettoauto"], _stringEmpty),
                    Motivorifiutoauto = DataHelper.IfDBNull<string>(row["motivorifiutoauto"], _stringEmpty),
                    Tipogomme = DataHelper.IfDBNull<string>(row["tipogomme"], _stringEmpty),
                    Luogogomme = DataHelper.IfDBNull<string>(row["luogogomme"], _stringEmpty),
                    Datacambiogomme = DataHelper.IfDBNull<DateTime>(row["datacambiogomme"], DateTime.MinValue),
                    Noterestituzione = DataHelper.IfDBNull<string>(row["noterestituzione"], _stringEmpty),
                    Noteconsegna = DataHelper.IfDBNull<string>(row["noteconsegna"], _stringEmpty),
                    Kmrestituzione = DataHelper.IfDBNull<decimal>(row["kmrestituzione"], 0),
                    Erratasederestituzione = DataHelper.IfDBNull<string>(row["erratasederestituzione"], _stringEmpty),
                    Erratarestituzionegomme = DataHelper.IfDBNull<string>(row["erratarestituzionegomme"], _stringEmpty),
                    Documentofuelcard = DataHelper.IfDBNull<string>(row["documentofuelcard"], _stringEmpty),
                };
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateAssegnazioneContratto(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti_assegnazioni SET [assegnatodal] = @assegnatodal, [assegnatoal] = @assegnatoal, [UserID] = @UserId " +
                         " WHERE [idassegnazione] = @idassegnazione AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@UserID", DbType.Guid);
            param22.Value = value.UserId;
            collParams.Add(param22);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatodal", DbType.Date);
            param19.Value = value.Assegnatodal;
            collParams.Add(param19);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatoal", DbType.Date);
            param18.Value = value.Assegnatoal;
            collParams.Add(param18);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param17.Value = value.Idassegnazione;
            collParams.Add(param17);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param12.Value = value.Uidtenant;
            collParams.Add(param12);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateRiconsegnaAuto(IContratti value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_contratti_assegnazioni SET [datarestituzione] = @datarestituzione, [orarestituzione] = @orarestituzione, [luogorestituzione] = @luogorestituzione, " +
                         " [centrorestituzione] = @centrorestituzione, [noterestituzione] = @noterestituzione, [erratasederestituzione] = @erratasederestituzione, " +
                         " [erratarestituzionegomme] = @erratarestituzionegomme, [penaledenuncia] = @penaledenuncia " +
                         " WHERE idassegnazione = @idassegnazione AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@datarestituzione", DbType.DateTime);
            param16.Value = value.Datarestituzione;
            collParams.Add(param16);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@orarestituzione", DbType.String);
            param19.Value = value.Orarestituzione;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@luogorestituzione", DbType.String);
            param20.Value = value.Luogorestituzione;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@centrorestituzione", DbType.String);
            param21.Value = value.Centrorestituzione;
            collParams.Add(param21);

            IDbDataParameter param33 = _dataHelper.ProviderConn.CreateDataParameter("@noterestituzione", DbType.String);
            param33.Value = value.Noterestituzione;
            collParams.Add(param33);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param14.Value = value.Idassegnazione;
            collParams.Add(param14);

            IDbDataParameter param34 = _dataHelper.ProviderConn.CreateDataParameter("@erratasederestituzione", DbType.String);
            param34.Value = value.Erratasederestituzione;
            collParams.Add(param34);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@erratarestituzionegomme", DbType.String);
            param35.Value = value.Erratarestituzionegomme;
            collParams.Add(param35);

            IDbDataParameter param36 = _dataHelper.ProviderConn.CreateDataParameter("@penaledenuncia", DbType.String);
            param36.Value = value.Penaledenuncia;
            collParams.Add(param36);

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
        public IContratti DetailDriverXCdc(string tipocentro, Guid Uid)
        {
            IContratti retVal = null;
            string sql;

            if (tipocentro.ToUpper() == "EF_USERS")
            {
                sql = "SELECT CONCAT(cognome, ' ' , nome) as denominazione, matricola FROM EF_users WHERE UserId = @Uid ";
            }
            else
            { 
                sql = "SELECT societa as denominazione, '' as matricola FROM EF_societa WHERE Uid = @Uid ";
            }

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Denominazione = DataHelper.IfDBNull<string>(row["denominazione"], _stringEmpty),
                    Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                };
                data.Dispose();
            }
            return retVal;
        }
        public IContratti DetailTemplateFattureId(int idtemplate)
        {
            IContratti retVal = null;
            string sql = "SELECT * FROM EF_fatturexml_template WHERE idtemplatefattura = @idtemplate";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idtemplate", DbType.Int32);
            param0.Value = idtemplate;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Ivatemplate = DataHelper.IfDBNull<string>(row["ivatemplate"], _stringEmpty),
                    Descrizionetemplate = DataHelper.IfDBNull<string>(row["descrizionetemplate"], _stringEmpty),
                    Nometemplate = DataHelper.IfDBNull<string>(row["nometemplate"], _stringEmpty)
                };

                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectAllDeltaCanone(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant, int numrecord, int pagina)
        {
            string condWhere = "";
            string paginazione;
            string datainizioass;
            string datafineass;

            if (numrecord == 0)
            {
                numrecord = 50;
            }
            if (pagina == 0)
            {
                pagina = 1;
            }
            paginazione = " OFFSET " + (pagina - 1) * numrecord + " ROWS FETCH NEXT " + numrecord + " ROWS ONLY ";

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND u.UserId = @UserId ";
            if (!string.IsNullOrEmpty(mese) && anno > 0)
            {
                datainizioass = Convert.ToDateTime("01/" + mese + "/" + anno).AddMonths(-1).ToString("dd/MM/yyyy");
                datafineass = Convert.ToDateTime(DateTime.DaysInMonth(anno, SeoHelper.IntString(mese)) + "/" + mese + "/" + anno).AddMonths(-1).ToString("dd/MM/yyyy");
                condWhere += " AND ((a.assegnatodal <= @datainizioass  AND a.assegnatoal <= @datainizioass) OR (a.assegnatodal >= @datainizioass ) OR (a.assegnatodal <= @datainizioass  and a.assegnatoal >= @datainizioass)) ";
            }
            else
            {
                datainizioass = "01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
                datafineass = DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
                condWhere += " AND ((a.assegnatodal <= @datainizioass  AND a.assegnatoal <= @datainizioass) OR (a.assegnatodal >= @datainizioass ) OR (a.assegnatodal <= @datainizioass  and a.assegnatoal >= @datainizioass)) ";
            }

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT u.nome, u.cognome, u.matricola, c.targa, u.codicecdc, c.codsocieta, s.societa, c.deltacanone, c.datacontratto, a.UserId FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON c.idcontratto = a.idcontratto AND c.uidtenant = a.uidtenant and a.idstatusassegnazione<>'5' and a.assegnatoal >= @datainizioass  " +
                         " LEFT JOIN EF_users as u ON u.UserId = a.UserId AND u.uidtenant = a.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta AND s.uidtenant = c.uidtenant " +
                         " WHERE c.idcontratto > 0 and c.deltacanone > 0   " + condWhere + " ORDER BY u.cognome, u.nome " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
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
                    IContratti item = new Contratti
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountAllDeltaCanone(string codsocieta, Guid UserId, string mese, int anno, Guid Uidtenant)
        {
            string condWhere = "";
            string datainizioass;
            string datafineass;

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND u.UserId = @UserId ";
            if (!string.IsNullOrEmpty(mese) && anno > 0)
            {
                datainizioass = Convert.ToDateTime("01/" + mese + "/" + anno).AddMonths(-1).ToString("dd/MM/yyyy");
                datafineass = Convert.ToDateTime(DateTime.DaysInMonth(anno, SeoHelper.IntString(mese)) + "/" + mese + "/" + anno).AddMonths(-1).ToString("dd/MM/yyyy");
                condWhere += " AND ((a.assegnatodal <= @datainizioass  AND a.assegnatoal <= @datainizioass) OR (a.assegnatodal >= @datainizioass ) OR (a.assegnatodal <= @datainizioass  and a.assegnatoal >= @datainizioass)) ";
            }
            else
            {
                datainizioass = "01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
                datafineass = DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
                condWhere += " AND ((a.assegnatodal <= @datainizioass  AND a.assegnatoal <= @datainizioass) OR (a.assegnatodal >= @datainizioass ) OR (a.assegnatodal <= @datainizioass  and a.assegnatoal >= @datainizioass)) ";
            }


            string sql = " SELECT COUNT(c.idcontratto) as tot FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON c.idcontratto = a.idcontratto AND c.uidtenant = a.uidtenant and a.idstatusassegnazione<>'5' and a.assegnatoal >= @datainizioass  " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserId AND u.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta AND s.uidtenant = c.uidtenant " +
                         " WHERE c.idcontratto > 0 and c.deltacanone > 0  " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
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

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }
        public List<IContratti> SelectDetailFattureGroup(Guid Uidfattura)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT Uidfattura, SUM(prezzotot) as prezzotot, naturaiva, datainizioperiodo, datafineperiodo, centrocostoabb, Uidcentrocosto, tipocentrocosto, " +
                         " centrocostoabb2, Uidcentrocosto2, tipocentrocosto2, datainizioperiodo2, datafineperiodo2, " +
                         " centrocostoabb3, Uidcentrocosto3, tipocentrocosto3, datainizioperiodo3, datafineperiodo3, " +
                         " centrocostoabb4, Uidcentrocosto4, tipocentrocosto4, datainizioperiodo4, datafineperiodo4, targa, " +
                         " (SELECT TOP 1 riftesto FROM EF_fatturexml_dettaglio as d WHERE Uidfattura = @Uidfattura and d.Uidcentrocosto = fd.Uidcentrocosto) as riftesto " +
                         " FROM EF_fatturexml_dettaglio as fd WHERE Uidfattura = @Uidfattura " +
                         " GROUP BY Uidfattura, naturaiva, datainizioperiodo, datafineperiodo, centrocostoabb, Uidcentrocosto, tipocentrocosto, " +
                         " centrocostoabb2, Uidcentrocosto2, tipocentrocosto2, datainizioperiodo2, datafineperiodo2, " +
                         " centrocostoabb3, Uidcentrocosto3, tipocentrocosto3, datainizioperiodo3, datafineperiodo3, " +
                         " centrocostoabb4, Uidcentrocosto4, tipocentrocosto4, datainizioperiodo4, datafineperiodo4,  targa " +
                         " ORDER BY centrocostoabb ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@Uidfattura", DbType.Guid);
            param5.Value = Uidfattura;
            collParams.Add(param5);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Prezzotot = DataHelper.IfDBNull<decimal>(row["prezzotot"], 0),
                        Centrocostoabb = DataHelper.IfDBNull<string>(row["centrocostoabb"], _stringEmpty),
                        Centrocostoabb2 = DataHelper.IfDBNull<string>(row["centrocostoabb2"], _stringEmpty),
                        Centrocostoabb3 = DataHelper.IfDBNull<string>(row["centrocostoabb3"], _stringEmpty),
                        Centrocostoabb4 = DataHelper.IfDBNull<string>(row["centrocostoabb4"], _stringEmpty),
                        Tipocentrocosto = DataHelper.IfDBNull<string>(row["tipocentrocosto"], _stringEmpty),
                        Tipocentrocosto2 = DataHelper.IfDBNull<string>(row["tipocentrocosto2"], _stringEmpty),
                        Tipocentrocosto3 = DataHelper.IfDBNull<string>(row["tipocentrocosto3"], _stringEmpty),
                        Tipocentrocosto4 = DataHelper.IfDBNull<string>(row["tipocentrocosto4"], _stringEmpty),
                        Uidcentrocosto = DataHelper.IfDBNull<Guid>(row["Uidcentrocosto"], Guid.Empty),
                        Uidcentrocosto2 = DataHelper.IfDBNull<Guid>(row["Uidcentrocosto2"], Guid.Empty),
                        Uidcentrocosto3 = DataHelper.IfDBNull<Guid>(row["Uidcentrocosto3"], Guid.Empty),
                        Uidcentrocosto4 = DataHelper.IfDBNull<Guid>(row["Uidcentrocosto4"], Guid.Empty),
                        Riftesto = DataHelper.IfDBNull<string>(row["riftesto"], _stringEmpty),
                        Datainizioperiodo = DataHelper.IfDBNull<DateTime>(row["datainizioperiodo"], DateTime.MinValue),
                        Datafineperiodo = DataHelper.IfDBNull<DateTime>(row["datafineperiodo"], DateTime.MinValue),
                        Datainizioperiodo2 = DataHelper.IfDBNull<DateTime>(row["datainizioperiodo2"], DateTime.MinValue),
                        Datafineperiodo2 = DataHelper.IfDBNull<DateTime>(row["datafineperiodo2"], DateTime.MinValue),
                        Datainizioperiodo3 = DataHelper.IfDBNull<DateTime>(row["datainizioperiodo3"], DateTime.MinValue),
                        Datafineperiodo3 = DataHelper.IfDBNull<DateTime>(row["datafineperiodo3"], DateTime.MinValue),
                        Datainizioperiodo4 = DataHelper.IfDBNull<DateTime>(row["datainizioperiodo4"], DateTime.MinValue),
                        Datafineperiodo4 = DataHelper.IfDBNull<DateTime>(row["datafineperiodo4"], DateTime.MinValue),
                        Naturaiva = DataHelper.IfDBNull<string>(row["naturaiva"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectDetailConsumiGroup(string numerofattura, int idcompagnia, DateTime datafattura)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT uf.datafattura, SUM(uf.importo) as importofinalefatturato, a.targa, a.UserId, " +
                         " FORMAT(uf.datatransazione, 'dd/MM/yyyy') as datatransazione, uf.numerofuelcard " + 
                         " FROM EF_users_fuelcard_consumo as uf " +
                         " LEFT JOIN EF_users_fuelcard as u ON uf.numerofuelcard = u.numero " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON a.targa = u.targa and a.assegnatodal <= uf.datatransazione and a.assegnatoal >= uf.datatransazione " +
                         " WHERE uf.numerofattura = @numerofattura and uf.idcompagnia = @idcompagnia and uf.datafattura = @datafattura " +
                         " GROUP BY uf.datafattura, a.targa, a.UserId, FORMAT(uf.datatransazione, 'dd/MM/yyyy'), uf.numerofuelcard ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerofattura", DbType.String);
            param5.Value = numerofattura;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
            param6.Value = idcompagnia;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datafattura", DbType.DateTime);
            param7.Value = datafattura;
            collParams.Add(param7);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Importototale = DataHelper.IfDBNull<decimal>(row["importofinalefatturato"], 0),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Riftesto = DataHelper.IfDBNull<string>(row["datatransazione"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectDetailConsumiTelePassGroup(int idcompagnia, DateTime datafatturada, DateTime datafatturaa)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT SUM(uf.importo) as importofinalefatturato, u.targa, a.UserId, FORMAT(uf.dataora, 'dd/MM/yyyy') as datatransazione " +
                         " FROM EF_users_telepass_consumo as uf " +
                         " LEFT JOIN EF_users_telepass as u ON uf.numerodispositivo = u.numero " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON a.targa = u.targa and a.assegnatodal <= uf.dataora and a.assegnatoal >= uf.dataora " +
                         " WHERE u.idcompagnia = @idcompagnia and uf.dataora >= @datafatturada  and uf.dataora <= @datafatturaa " +
                         " GROUP BY u.targa, a.UserId, FORMAT(uf.dataora, 'dd/MM/yyyy') ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@datafatturada", DbType.DateTime);
            param5.Value = datafatturada;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@idcompagnia", DbType.Int32);
            param6.Value = idcompagnia;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datafatturaa", DbType.DateTime);
            param7.Value = datafatturaa;
            collParams.Add(param7);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Importototale = DataHelper.IfDBNull<decimal>(row["importofinalefatturato"], 0),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Riftesto = DataHelper.IfDBNull<string>(row["datatransazione"], _stringEmpty),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectFattureDeltaCanone(string codsocieta, Guid UserId, string mese, int anno)
        {
            string condWhere = "";
            string datainizioass;
            string datafineass;

            string datainiziomese;
            string datafinemese;

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND u.UserId = @UserId ";
            if (!string.IsNullOrEmpty(mese) && anno > 0)
            {
                datainiziomese = Convert.ToDateTime("01/" + mese + "/" + anno).ToString("dd/MM/yyyy");
                datafinemese = Convert.ToDateTime(DateTime.DaysInMonth(anno, SeoHelper.IntString(mese)) + "/" + mese + "/" + anno).ToString("dd/MM/yyyy");

                datainizioass = Convert.ToDateTime("01/" + mese + "/" + anno).AddMonths(-1).ToString("dd/MM/yyyy");
                datafineass = Convert.ToDateTime(DateTime.DaysInMonth(anno, SeoHelper.IntString(mese)) + "/" + mese + "/" + anno).AddMonths(-1).ToString("dd/MM/yyyy");
                condWhere += " AND ((a.assegnatodal <= @datainizioass  AND a.assegnatoal <= @datafineass) OR (a.assegnatodal >= @datainizioass ) OR (a.assegnatodal <= @datainizioass  and a.assegnatoal >= @datafineass)) ";
            }
            else
            {
                datainiziomese = "01/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                datafinemese = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

                datainizioass = "01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
                datafineass = DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
                condWhere += " AND ((a.assegnatodal <= @datainizioass  AND a.assegnatoal <= @datafineass) OR (a.assegnatodal >= @datainizioass ) OR (a.assegnatodal <= @datainizioass  and a.assegnatoal >= @datafineass)) ";
            }

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT u.nome, u.cognome, u.matricola, c.targa, u.codicecdc, c.codsocieta, s.societa, s.codcompany, c.deltacanone, c.datacontratto, a.UserId, a.assegnatodal, a.assegnatoal, " +
                         " DATEDIFF(DAY, @datainizioass, a.assegnatoal) +1 as gg1, " +
                         " DATEDIFF(DAY, @datainizioass, a.assegnatodal) as gg2, " +
                         " DATEDIFF(DAY, @datainizioass, @datafineass) +1 as gg3, " +
                         " CASE WHEN (a.assegnatodal <= @datainizioass AND a.assegnatoal <= @datafineass) " + // se contratto cessato il mese precedente considera i giorni negativi
                         " THEN DATEDIFF(DAY, @datafineass, a.assegnatoal) " +
                         " WHEN (a.assegnatodal >= @datainiziomese) THEN DATEDIFF(DAY, a.assegnatodal, @datafinemese) " + // se contratto iniziato nel mese attuale considera i giorni restanti
                         " ELSE DATEDIFF(DAY, @datainizioass, @datafineass) +1 END AS gg " + // se contratto è compreso nel mese di riferimento
                         " FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON c.idcontratto = a.idcontratto and a.idstatusassegnazione<>5 and a.assegnatoal >= @datainizioass  " + //and a.assegnatodal <= @datafineass VERIFICARE LA CONDIZIONE PER FINE ASSEGNAZIONE
                         " LEFT JOIN EF_users as u ON u.UserId = a.UserId " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta " +
                         " WHERE c.idcontratto > 0 and c.deltacanone > 0  " + condWhere + " ORDER BY u.cognome, u.nome ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
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

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@datainiziomese", DbType.DateTime);
            param8.Value = datainiziomese;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@datafinemese", DbType.DateTime);
            param9.Value = datafinemese;
            collParams.Add(param9);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Codcompany = DataHelper.IfDBNull<string>(row["codcompany"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Giorniconsegnaagg = DataHelper.IfDBNull<int>(row["gg"], 0),
                        Anno = DataHelper.IfDBNull<int>(row["gg3"], 0),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectNoteCreditoDeltaCanone(string codsocieta, Guid UserId, string mese, int anno)
        {
            string condWhere = "";
            string datainizioass;
            string datafineass;

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND u.UserId = @UserId ";
            if (!string.IsNullOrEmpty(mese) && anno > 0)
            {
                datainizioass = Convert.ToDateTime("01/" + mese + "/" + anno).AddMonths(-1).ToString("dd/MM/yyyy");
                datafineass = Convert.ToDateTime(DateTime.DaysInMonth(anno, SeoHelper.IntString(mese)) + "/" + mese + "/" + anno).AddMonths(-1).ToString("dd/MM/yyyy");
                condWhere += " AND ((a.assegnatodal <= @datainizioass  AND a.assegnatoal <= @datafineass) OR (a.assegnatodal >= @datainizioass ) OR (a.assegnatodal <= @datainizioass  and a.assegnatoal >= @datafineass)) ";
            }
            else
            {
                datainizioass = "01/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
                datafineass = DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month) + "/" + DateTime.Now.AddMonths(-1).Month + "/" + DateTime.Now.AddMonths(-1).Year;
                condWhere += " AND ((a.assegnatodal <= @datainizioass  AND a.assegnatoal <= @datafineass) OR (a.assegnatodal >= @datainizioass ) OR (a.assegnatodal <= @datainizioass  and a.assegnatoal >= @datafineass)) ";
            }

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT u.nome, u.cognome, u.matricola, c.targa, u.codicecdc, c.codsocieta, s.societa, c.deltacanone, c.datacontratto, a.UserId, a.assegnatodal, a.assegnatoal, " +
                         " DATEDIFF(DAY, @datainizioass, a.assegnatoal a.assegnatoal) +1 as gg1, " +
                         " DATEDIFF(DAY, @datainizioass, a.assegnatodal) as gg2, " +
                         " DATEDIFF(DAY, @datainizioass, @datafineass) +1 as gg3, " +
                         " CASE WHEN (a.assegnatodal <= @datainizioass AND a.assegnatoal <= @datafineass) " +
                         " THEN DATEDIFF(DAY, @datafineass, a.assegnatoal) " +
                         " WHEN (a.assegnatodal >= @datainizioass) THEN DATEDIFF(DAY, @datainizioass, a.assegnatodal) " +
                         " ELSE DATEDIFF(DAY, @datainizioass, @datafineass) +1 END AS gg " +
                         " FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON c.idcontratto = a.idcontratto and assegnatoal <= @datafineass " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserId " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta " +
                         " WHERE c.idcontratto > 0 and c.deltacanone < 0  " + condWhere + " ORDER BY u.cognome, u.nome ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
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

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Giorniconsegnaagg = DataHelper.IfDBNull<int>(row["gg"], 0),
                        Anno = DataHelper.IfDBNull<int>(row["gg3"], 0),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectFattureMulte(string targa, Guid UserId, string mese, int anno)
        {
            string condWhere = "";
            string datainizioass;
            string datafineass;

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND m.codsocieta = @targa ";
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

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT u.nome, u.cognome, u.matricola, m.targa, u.codicecdc, m.numeroverbale, m.codsocieta, s.societa, " +
                         " m.importomultapagato, m.datapagamento, m.UserId, m.idtitolarepagamento, m.datanotifica, m.spesepagamento, m.quotadriver, m.quotasocieta " +
                         " FROM EF_multe as m " +
                         " LEFT JOIN EF_users as u ON u.UserId = m.UserId " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = m.codsocieta " +
                         " WHERE m.idstatuspagamento = 100 and m.importomultapagato>0   " + condWhere + " ORDER BY m.datanotifica ";

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

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Codicecdc = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Importototale = DataHelper.IfDBNull<decimal>(row["importomultapagato"], 0),
                        Idtipoassegnazione = DataHelper.IfDBNull<int>(row["idtitolarepagamento"], 0),
                        Spesepagamento = DataHelper.IfDBNull<decimal>(row["spesepagamento"], 0),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numeroverbale"], _stringEmpty),
                        Dataconsegna = DataHelper.IfDBNull<DateTime>(row["datapagamento"], DateTime.MinValue),
                        Datarichiesta = DataHelper.IfDBNull<DateTime>(row["datanotifica"], DateTime.MinValue),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                        Quotadriver = DataHelper.IfDBNull<decimal>(row["quotadriver"], 0),
                        Quotasocieta = DataHelper.IfDBNull<decimal>(row["quotasocieta"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectFattureMulteFee(string codsocieta, Guid UserId, string mese, int anno)
        {
            string condWhere = "";
            string datainizioass;
            string datafineass;

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND m.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND m.UserId = @UserId ";
            if (!string.IsNullOrEmpty(mese) && anno > 0)
            {
                datainizioass = "01/" + mese + "/" + anno;
                datafineass = DateTime.DaysInMonth(anno, SeoHelper.IntString(mese)) + "/" + mese + "/" + anno;
                condWhere += " AND ((m.datanotifica >= @datainizioass and m.datanotifica <= @datafineass) OR (m.datapagamento >= @datainizioass and m.datapagamento <= @datafineass)) ";
            }
            else
            {
                datainizioass = "01/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                datafineass = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                condWhere += " AND ((m.datanotifica >= @datainizioass and m.datanotifica <= @datafineass) OR (m.datapagamento >= @datainizioass and m.datapagamento <= @datafineass)) ";
            }

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT u.nome, u.cognome, u.matricola, m.targa, u.codicecdc, m.numeroverbale, m.codsocieta, s.societa, " +
                         " m.importomultapagato, m.UserId, m.idtitolarepagamento, m.spesepagamento, m.datauserins, m.datanotifica, m.datapagamento " +
                         " FROM EF_multe as m " +
                         " LEFT JOIN EF_users as u ON u.UserId = m.UserId " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = m.codsocieta " +
                         " WHERE m.idmulta>0  " + condWhere + " ORDER BY m.datanotifica ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
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

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Codicecdc = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Importototale = DataHelper.IfDBNull<decimal>(row["importomultapagato"], 0),
                        Idtipoassegnazione = DataHelper.IfDBNull<int>(row["idtitolarepagamento"], 0),
                        Spesepagamento = DataHelper.IfDBNull<decimal>(row["spesepagamento"], 0),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numeroverbale"], _stringEmpty),
                        Dataconsegna = DataHelper.IfDBNull<DateTime>(row["datapagamento"], DateTime.MinValue),
                        Datarichiesta = DataHelper.IfDBNull<DateTime>(row["datanotifica"], DateTime.MinValue),
                        Datauserins = DataHelper.IfDBNull<DateTime>(row["datauserins"], DateTime.MinValue),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectNoteCreditoMulte(string targa, Guid UserId, string mese, int anno)
        {
            string condWhere = "";
            string datainizioass;
            string datafineass;

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND a.codsocieta = @targa ";
            if (UserId != Guid.Empty) condWhere += " AND m.UserId = @UserId ";
            if (!string.IsNullOrEmpty(mese) && anno > 0)
            {
                datainizioass = "01/" + mese + "/" + anno;
                datafineass = DateTime.DaysInMonth(anno, SeoHelper.IntString(mese)) + "/" + mese + "/" + anno;
                condWhere += " AND m.datanotifica >= @datainizioass and m.datanotifica <= @datafineass ";
            }
            else
            {
                datainizioass = "01/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                datafineass = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                condWhere += " AND m.datanotifica >= @datainizioass and m.datanotifica <= @datafineass ";
            }

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT u.nome, u.cognome, u.matricola, m.targa, u.codicecdc, m.numeroverbale, a.codsocieta, s.societa, m.importomultapagato, m.datapagamento, m.UserId, m.idtitolarepagamento " +
                         " FROM EF_multe as m " +
                         " LEFT JOIN EF_contratti_assegnazioni as a ON a.targa = m.targa " +
                         " LEFT JOIN EF_users as u ON u.UserId = m.UserId " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = a.codsocieta " +
                         " WHERE m.idmulta > 0 and m.importomultapagato < 0  " + condWhere + " ORDER BY m.datanotifica ";

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

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Codicecdc = DataHelper.IfDBNull<string>(row["codicecdc"], _stringEmpty),
                        Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Importototale = DataHelper.IfDBNull<decimal>(row["importomultapagato"], 0),
                        Idtipoassegnazione = DataHelper.IfDBNull<int>(row["idtitolarepagamento"], 0),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numeroverbale"], _stringEmpty),
                        Dataconsegna = DataHelper.IfDBNull<DateTime>(row["datapagamento"], DateTime.MinValue),
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdatePoolContratto(Guid Uid, int checkordinepool, string gradepool, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti SET [checkordinepool] = @checkordinepool, [gradepool] = @gradepool WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@checkordinepool", DbType.Int32);
            param21.Value = checkordinepool;
            collParams.Add(param21);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@gradepool", DbType.String);
            param23.Value = gradepool;
            collParams.Add(param23);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

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
        public IContratti ReturnAssegnatoAlMaggiore(int idcontratto)
        {
            IContratti retVal = null;
            string sql = " SELECT assegnatoal, UserId FROM EF_contratti_assegnazioni WHERE idcontratto = @idcontratto ORDER BY assegnatoal DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idcontratto", DbType.Int32);
            param0.Value = idcontratto;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateDataFineContratto(int idcontratto, DateTime datafinecontratto, Guid UserId, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti SET [UserId] = @UserId WHERE idcontratto = @idcontratto AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@idcontratto", DbType.Int32);
            param22.Value = idcontratto;
            collParams.Add(param22);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param20.Value = UserId;
            collParams.Add(param20);

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


        public int UpdateDeltaCanoneOrdini(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_ordini SET [deltacanone] = @deltacanone, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@deltacanone", DbType.Decimal);
            param26.Value = value.Deltacanone;
            collParams.Add(param26);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param20.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = value.Uid;
            collParams.Add(param22);

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
        public List<IContratti> SelectDelegheUser(int idtipomodulo, Guid UserId)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT * FROM EF_deleghe LEFT JOIN EF_documenti_deleghe ON EF_deleghe.UserId = EF_documenti_deleghe.UserId " +
                         " WHERE idtipomodulo = @idtipomodulo and EF_deleghe.UserId = @UserId ORDER BY datafirma DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = UserId;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@idtipomodulo", DbType.Int32);
            param2.Value = idtipomodulo;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                        Modulodafirmare = DataHelper.IfDBNull<string>(row["modulodafirmare"], _stringEmpty),
                        Modulofirmato = DataHelper.IfDBNull<string>(row["modulofirmato"], _stringEmpty),
                        Noteamministrazione = DataHelper.IfDBNull<string>(row["noteapprovazione"], _stringEmpty),
                        Checkdoc = DataHelper.IfDBNull<string>(row["checkapprovatore"], _stringEmpty),
                        Datains = DataHelper.IfDBNull<DateTime>(row["datains"], DateTime.MinValue),
                        Datafirma = DataHelper.IfDBNull<DateTime>(row["datafirma"], DateTime.MinValue),
                        Cittaresidenza = DataHelper.IfDBNull<string>(row["cittaresidenza"], _stringEmpty),
                        Indirizzoresidenza = DataHelper.IfDBNull<string>(row["indirizzoresidenza"], _stringEmpty),
                        Civicoresidenza = DataHelper.IfDBNull<string>(row["civicoresidenza"], _stringEmpty),
                        Cittaresidenzadelegato = DataHelper.IfDBNull<string>(row["cittaresidenzadelegato"], _stringEmpty),
                        Indirizzoresidenzadelegato = DataHelper.IfDBNull<string>(row["indirizzoresidenzadelegato"], _stringEmpty),
                        Civicoresidenzadelegato = DataHelper.IfDBNull<string>(row["civicoresidenzadelegato"], _stringEmpty),
                        Moduloconvivenza = DataHelper.IfDBNull<string>(row["moduloconvivenza"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectDeleghe(Guid UserId, DateTime datadocumentodal, DateTime datadocumentoal, string checkapprovatore, int idtipomodulo, Guid Uidtenant, int numrecord, int pagina)
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

            if (UserId != Guid.Empty) condWhere += " AND d.UserId = @UserId ";
            if (datadocumentodal > DateTime.MinValue) condWhere += " AND datains >= @datadocumentodal ";
            if (datadocumentoal > DateTime.MinValue) condWhere += " AND datains <= @datadocumentoal ";
            if (!string.IsNullOrEmpty(checkapprovatore))
            {
                condWhere += " AND checkapprovatore = @checkapprovatore ";
            }
            else
            {
                condWhere += " AND (checkapprovatore is null OR checkapprovatore='' OR datafirma is null OR datafirma='') ";
            }

            if (idtipomodulo > 0) condWhere += " AND idtipomodulo = @idtipomodulo ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT u.nome, u.cognome, u.matricola, s.siglasocieta, d.* FROM EF_deleghe as d " +
                         " LEFT JOIN EF_users as u ON d.UserId = u.UserId AND u.uidtenant = d.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = u.codsocieta AND s.uidtenant = u.uidtenant " +
                         " WHERE idmodulo > 0 AND d.uidtenant = @Uidtenant " + condWhere + " ORDER BY datains DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param0.Value = UserId;
                collParams.Add(param0);
            }
            if (datadocumentodal > DateTime.MinValue)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@datadocumentodal", DbType.DateTime);
                param2.Value = datadocumentodal;
                collParams.Add(param2);
            }
            if (datadocumentoal > DateTime.MinValue)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@datadocumentoal", DbType.DateTime);
                param3.Value = datadocumentoal;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(checkapprovatore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@checkapprovatore", DbType.String);
                param4.Value = checkapprovatore;
                collParams.Add(param4);
            }
            if (idtipomodulo > 0)
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@idtipomodulo", DbType.Int32);
                param5.Value = idtipomodulo;
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
                    IContratti item = new Contratti
                    {
                        Modulodafirmare = DataHelper.IfDBNull<string>(row["modulodafirmare"], _stringEmpty),
                        Modulofirmato = DataHelper.IfDBNull<string>(row["modulofirmato"], _stringEmpty),
                        Noteamministrazione = DataHelper.IfDBNull<string>(row["noteapprovazione"], _stringEmpty),
                        Checkdoc = DataHelper.IfDBNull<string>(row["checkapprovatore"], _stringEmpty),
                        Datains = DataHelper.IfDBNull<DateTime>(row["datains"], DateTime.MinValue),
                        Datafirma = DataHelper.IfDBNull<DateTime>(row["datafirma"], DateTime.MinValue),
                        Idtipomodulo = DataHelper.IfDBNull<int>(row["idtipomodulo"], 0),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Denominazione = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Moduloconvivenza = DataHelper.IfDBNull<string>(row["moduloconvivenza"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountDeleghe(Guid UserId, DateTime datadocumentodal, DateTime datadocumentoal, string checkapprovatore, int idtipomodulo, Guid Uidtenant)
        {
            string condWhere = "";
            if (UserId != Guid.Empty) condWhere += " AND d.UserId = @UserId ";
            if (datadocumentodal > DateTime.MinValue) condWhere += " AND datains >= @datadocumentodal ";
            if (datadocumentoal > DateTime.MinValue) condWhere += " AND datains <= @datadocumentoal ";
            if (!string.IsNullOrEmpty(checkapprovatore))
            {
                condWhere += " AND checkapprovatore = @checkapprovatore ";
            }
            else
            {
                condWhere += " AND (checkapprovatore is null OR checkapprovatore='' OR datafirma is null OR datafirma='') ";
            }
            if (idtipomodulo > 0) condWhere += " AND idtipomodulo = @idtipomodulo ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_deleghe as d " +
                         " LEFT JOIN EF_users as u ON d.UserId = u.UserId AND u.uidtenant = d.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = u.codsocieta AND s.uidtenant = u.uidtenant " +
                         " WHERE idmodulo > 0 AND d.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param0.Value = UserId;
                collParams.Add(param0);
            }
            if (datadocumentodal > DateTime.MinValue)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@datadocumentodal", DbType.DateTime);
                param2.Value = datadocumentodal;
                collParams.Add(param2);
            }
            if (datadocumentoal > DateTime.MinValue)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@datadocumentoal", DbType.DateTime);
                param3.Value = datadocumentoal;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(checkapprovatore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@checkapprovatore", DbType.String);
                param4.Value = checkapprovatore;
                collParams.Add(param4);
            }
            if (idtipomodulo > 0)
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@idtipomodulo", DbType.Int32);
                param5.Value = idtipomodulo;
                collParams.Add(param5);
            }

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param6.Value = Uidtenant;
            collParams.Add(param6);            

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public int InsertDelega(IContratti value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_deleghe ([idtipomodulo],[UserId],[modulofirmato],[datains],[uidtenant]) " +
                         " VALUES (@idtipomodulo,@UserId,@modulofirmato,@datains,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idtipomodulo", DbType.Int32);
            param0.Value = value.Idtipomodulo;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@modulofirmato", DbType.String);
            param2.Value = value.Modulofirmato;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@datains", DbType.DateTime);
            param3.Value = DateTime.Now;
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
        public int UpdateDelega(IContratti value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_deleghe SET [modulofirmato] = @modulofirmato, [datafirma] = @datafirma WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param1.Value = value.Uid;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@modulofirmato", DbType.String);
            param2.Value = value.Modulofirmato;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@datafirma", DbType.DateTime);
            param3.Value = DateTime.Now;
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
        public IContratti DetailDelega(Guid Uid)
        {
            IContratti retVal = null;
            string sql = " SELECT * FROM EF_deleghe WHERE Uid = @Uid ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Modulodafirmare = DataHelper.IfDBNull<string>(row["modulodafirmare"], _stringEmpty),
                    Modulofirmato = DataHelper.IfDBNull<string>(row["modulofirmato"], _stringEmpty),
                    Datains = DataHelper.IfDBNull<DateTime>(row["datains"], DateTime.MinValue),
                    Datafirma = DataHelper.IfDBNull<DateTime>(row["datafirma"], DateTime.MinValue),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Checkdoc = DataHelper.IfDBNull<string>(row["checkapprovatore"], _stringEmpty),
                    Idtipomodulo = DataHelper.IfDBNull<int>(row["idtipomodulo"], 0),
                    Noteamministrazione = DataHelper.IfDBNull<string>(row["noteapprovazione"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int UpdatePoolContratto2(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti SET [idstatuspool] = @idstatuspool, [notepool] = @notepool, [UserIdpool] = @UserIdpool, " +
                         " [checkordinepool] = @checkordinepool, [gradepool] = @gradepool WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param44 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuspool", DbType.Int32);
            param44.Value = value.Idstatuspool;
            collParams.Add(param44);

            IDbDataParameter param45 = _dataHelper.ProviderConn.CreateDataParameter("@notepool", DbType.String);
            param45.Value = value.Notepool;
            collParams.Add(param45);

            IDbDataParameter param47 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdpool", DbType.Guid);
            param47.Value = value.UserIdpool;
            collParams.Add(param47);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@checkordinepool", DbType.Int32);
            param21.Value = value.Checkordinepool;
            collParams.Add(param21);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@gradepool", DbType.String);
            param23.Value = value.Gradepool;
            collParams.Add(param23);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = value.Uid;
            collParams.Add(param22);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param12.Value = value.Uidtenant;
            collParams.Add(param12);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }

        public List<IContratti> SelectViewCarPolicyPoolTeamAppr(string keysearch, string codsocieta, string targa, int idstatuspool)
        {
            string condWhere = "";

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (modello LIKE '%' + @keysearch + '%') ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND targa = @targa ";
            if (idstatuspool > -1) condWhere += " AND idstatuspool = @idstatuspool ";

            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT * FROM view_auto_pool WHERE targa<>'' " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param3.Value = targa;
                collParams.Add(param3);
            }
            if (idstatuspool > -1)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuspool", DbType.Int32);
                param4.Value = idstatuspool;
                collParams.Add(param4);
            }

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Fringebenefit = DataHelper.IfDBNull<decimal>(row["fringebenefit"], 0),
                        Kmcontratto = DataHelper.IfDBNull<int>(row["kmcontratto"], 0),
                        Checkordinepool = DataHelper.IfDBNull<int>(row["checkordinepool"], 0),
                        Denominazione = DataHelper.IfDBNull<string>(row["assegnatario"], _stringEmpty),
                        Kmpercorsi = DataHelper.IfDBNull<decimal>(row["kmpercorsi"], 0),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Luogoconsegna = DataHelper.IfDBNull<string>(row["luogoconsegna"], _stringEmpty),
                        Statoauto = DataHelper.IfDBNull<string>(row["statusauto"], _stringEmpty),
                        Statuspool = DataHelper.IfDBNull<string>(row["statuspool"], _stringEmpty),
                        Emissioni = DataHelper.IfDBNull<decimal>(row["emissioni"], 0),
                        Canoneleasing = DataHelper.IfDBNull<decimal>(row["canoneleasing"], 0),
                        Alimentazione = DataHelper.IfDBNull<string>(row["alimentazione"], _stringEmpty),
                        Cambio = DataHelper.IfDBNull<string>(row["cambio"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["exdriver"], _stringEmpty),
                        Codoptional = DataHelper.IfDBNull<string>(row["colore"], _stringEmpty),
                        Notepool = DataHelper.IfDBNull<string>(row["notepool"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                        Checkassegnatario = DataHelper.IfDBNull<int>(row["checkassegnatario"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateCarPolicy(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users_carpolicy SET [codcarpolicy] = @codcarpolicy, [datadecorrenza] = @datadecorrenza, " +
                         " [datafinedecorrenza] = @datafinedecorrenza, [documentocarpolicy] = @documentocarpolicy, [documentopatente] = @documentopatente WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param20.Value = value.Codcarpolicy;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datadecorrenza", DbType.Date);
            param21.Value = value.Datadecorrenza;
            collParams.Add(param21);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@datafinedecorrenza", DbType.Date);
            param23.Value = value.Datafinedecorrenza;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@documentocarpolicy", DbType.String);
            param24.Value = value.Documentocarpolicy;
            collParams.Add(param24);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@documentopatente", DbType.String);
            param25.Value = value.Documentopatente;
            collParams.Add(param25);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = value.Uid;
            collParams.Add(param22);

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
        public int UpdateDocFuelCard(int idassegnazione, string documentofuelcard, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti_assegnazioni SET [documentofuelcard] = @documentofuelcard WHERE idassegnazione = @idassegnazione AND uidtenant = @Uidtenant ";

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@documentofuelcard", DbType.String);
            param20.Value = documentofuelcard;
            collParams.Add(param20);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param22.Value = idassegnazione;
            collParams.Add(param22);

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
        public IContratti ReturnFileAuto(int idassegnazione)
        {
            IContratti retVal = null;
            string sql = " SELECT * FROM EF_contratti_assegnazioni WHERE idassegnazione = @idassegnazione ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param0.Value = idassegnazione;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Fileverbaleconsegna = DataHelper.IfDBNull<string>(row["fileverbaleconsegna"], _stringEmpty),
                    Filerelazioneperito = DataHelper.IfDBNull<string>(row["filerelazioneperito"], _stringEmpty),
                    Filedenunce = DataHelper.IfDBNull<string>(row["filedenunce"], _stringEmpty),
                    Filerifiutoauto = DataHelper.IfDBNull<string>(row["filerifiutoauto"], _stringEmpty),
                    Fileverbaleauto = DataHelper.IfDBNull<string>(row["fileverbaleauto"], _stringEmpty),
                    Filelibrettoauto = DataHelper.IfDBNull<string>(row["filelibrettoauto"], _stringEmpty),
                    Documentofuelcard = DataHelper.IfDBNull<string>(row["documentofuelcard"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountAutoSostitutive(string targa, Guid UserId, string codsocieta, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND ca.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND ca.assegnatoal >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND ca.assegnatoal <= @datacontrattoal";

            string sql = " SELECT COUNT(ca.idautosostitutiva) as tot FROM EF_contratti_autosostituive as ca " +
                         " LEFT JOIN EF_users as u ON u.UserId = ca.UserID AND ca.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = ca.codsocieta AND s.uidtenant = ca.uidtenant " +
                         " WHERE ca.idautosostitutiva > 0 AND ca.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);
            
            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectAutoSostitutive(string targa, Guid UserId, string codsocieta, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND ca.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND ca.assegnatoal >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND ca.assegnatoal <= @datacontrattoal";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT u.cognome, u.nome, u.matricola, s.siglasocieta, ca.* " +
                         " FROM EF_contratti_autosostituive as ca " +
                         " LEFT JOIN EF_users as u ON u.UserId = ca.UserID AND ca.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = ca.codsocieta AND ca.uidtenant = s.uidtenant " +
                         " WHERE ca.idautosostitutiva > 0 AND ca.uidtenant = @Uidtenant " + condWhere + " ORDER BY ca.assegnatoal " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
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
                    IContratti item = new Contratti
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IContratti DetailAutoSostId(Guid Uid)
        {
            IContratti retVal = null;
            string sql = "SELECT * FROM EF_contratti_autosostituive WHERE Uid = @Uid ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param1.Value = Uid;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                    Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Annotazionicontratto = DataHelper.IfDBNull<string>(row["annotazioni"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                };
                data.Dispose();
            }
            return retVal;
        }

        public int UpdateAutoSost(IContratti value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_contratti_autosostituive SET [targa] = @targa, [codsocieta] = @codsocieta, [assegnatodal] = @assegnatodal, " +
                         " [assegnatoal] = @assegnatoal, [UserId] = @UserId, [annotazioni] = @annotazioni, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod " +
                         " WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param15.Value = value.Targa;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param16.Value = value.Codsocieta;
            collParams.Add(param16);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatodal", DbType.DateTime);
            param19.Value = value.Assegnatodal;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatoal", DbType.DateTime);
            param20.Value = value.Assegnatoal;
            collParams.Add(param20);

            IDbDataParameter param33 = _dataHelper.ProviderConn.CreateDataParameter("@annotazioni", DbType.String);
            param33.Value = value.Annotazionicontratto;
            collParams.Add(param33);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param35.Value = value.UserId;
            collParams.Add(param35);

            IDbDataParameter param36 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param36.Value = value.Uid;
            collParams.Add(param36);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param2.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param2);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param1.Value = DateTime.Now;
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
        public int InsertAutoSost(IContratti value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_contratti_autosostituive ([targa],[codsocieta],[assegnatodal],[assegnatoal],[UserId],[annotazioni], " +
                         " [datauserins],[datausermod],[UserIDIns],[UserIdMod],[uidtenant]) " +
                         " VALUES (@targa,@codsocieta,@assegnatodal,@assegnatoal,@UserId,@annotazioni,@datauserins,@datausermod,@UserIDIns,@UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param15.Value = value.Targa;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param16.Value = value.Codsocieta;
            collParams.Add(param16);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatodal", DbType.DateTime);
            param19.Value = value.Assegnatodal;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatoal", DbType.DateTime);
            param20.Value = value.Assegnatoal;
            collParams.Add(param20);

            IDbDataParameter param33 = _dataHelper.ProviderConn.CreateDataParameter("@annotazioni", DbType.String);
            param33.Value = value.Annotazionicontratto;
            collParams.Add(param33);

            IDbDataParameter param35 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param35.Value = value.UserId;
            collParams.Add(param35);

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param0.Value = DateTime.Now;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param1.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param2.Value = DateTime.Now;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param3.Value = (Guid)Membership.GetUser().ProviderUserKey;
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
        public int DeleteAssegnazione(IContratti value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_contratti_assegnazioni WHERE idassegnazione = @idassegnazione AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            paramID.Value = value.Idassegnazione;
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

        //esistenza targa in assegnazioni
        public bool ExistTargaAss(string targa)
        {
            bool retVal = false;

            string sql = " SELECT idcontratto FROM EF_contratti WHERE Targa = @targa ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param1.Value = targa;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }

        public bool ExistAssegnazione(Guid UserId, string codsocieta, DateTime assegnatodal, DateTime assegnatoal, string targa)
        {
            bool retVal = false;

            string sql = " SELECT idcontratto FROM EF_contratti_assegnazioni WHERE UserId = @UserId AND codsocieta = @codsocieta " +
                         " AND assegnatodal = @assegnatodal AND assegnatoal = @assegnatoal AND targa = @targa ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param1.Value = codsocieta;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatodal", DbType.DateTime);
            param2.Value = assegnatodal;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatoal", DbType.DateTime);
            param3.Value = assegnatoal;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param4.Value = targa;
            collParams.Add(param4);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public int UpdateApprovaDelega(string checkapprovatore, string noteapprovazione, Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;

            string sql = " UPDATE EF_deleghe SET [checkapprovatore] = @checkapprovatore, [noteapprovazione] = @noteapprovazione, [datafirma] = @datafirma WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@checkapprovatore", DbType.String);
            param15.Value = checkapprovatore;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@noteapprovazione", DbType.String);
            param16.Value = noteapprovazione;
            collParams.Add(param16);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@datafirma", DbType.Date);
            param1.Value = DateTime.Now;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param2.Value = Uid;
            collParams.Add(param2);

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


        public IContratti ReturnTargaAssegnazioneXConcur(Guid UserId, DateTime dataspesa)
        {
            IContratti retVal = null;
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
                retVal = new Contratti
                {
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IContratti ReturnModConv(Guid Uid)
        {
            IContratti retVal = null;

            string sql = " SELECT moduloconvivenza FROM EF_deleghe WHERE Uid = @Uid ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param1.Value = Uid;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Moduloconvivenza = DataHelper.IfDBNull<string>(row["moduloconvivenza"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateModConv(Guid Uid, string moduloconvivenza, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_deleghe SET [moduloconvivenza] = @moduloconvivenza, [checkapprovatore] = '' WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@moduloconvivenza", DbType.String);
            param23.Value = moduloconvivenza;
            collParams.Add(param23);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

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
        public IContratti ReturnLuogoRestituzioneXTarga(string targa)
        {
            IContratti retVal = null;

            string sql = " SELECT  TOP (1) luogorestituzione, centrorestituzione FROM EF_contratti_assegnazioni AS caaa WHERE targa = @targa AND luogorestituzione <> '' ORDER BY idassegnazione DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param1.Value = targa;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Luogorestituzione = DataHelper.IfDBNull<string>(row["luogorestituzione"], _stringEmpty),
                    Centrorestituzione = DataHelper.IfDBNull<string>(row["centrorestituzione"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        
        //lista carbenefit
        public List<IContratti> SelectCarBenefit(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT * FROM EF_carbenefit WHERE uidtenant = @Uidtenant ORDER BY codcarbenefit ";

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
                    IContratti item = new Contratti
                    {
                        Codcarbenefit = DataHelper.IfDBNull<string>(row["codcarbenefit"], _stringEmpty),
                        Carbenefit = DataHelper.IfDBNull<string>(row["carbenefit"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //ricava carpolicy e carbenefit
        public IContratti ReturnTypeCarPolicy(int idutente)
        {
            IContratti retVal = null;
            string sql = " SELECT TOP 1 codcarpolicy, codcarbenefit FROM EF_users_carpolicy " +
                         " WHERE idutente = @idutente and approvato = 1 and idstatoapprovazione = 0 and (sceltabenefit = '' or sceltabenefit is null) ORDER BY idapprovazione DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idutente", DbType.Int32);
            param0.Value = idutente;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                    Codcarbenefit = DataHelper.IfDBNull<string>(row["codcarbenefit"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }

        //aggiona  user carpolicy
        public int UpdateUserCarPolicy(int idapprovazione, string sceltabenefit, string codpacchetto, DateTime datasceltabenefit, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_users_carpolicy SET [sceltabenefit] = @sceltabenefit, [codpacchetto] = @codpacchetto, [datasceltabenefit] = @datasceltabenefit " +
                         " WHERE idapprovazione = @idapprovazione AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@idapprovazione", DbType.Int32);
            param22.Value = idapprovazione;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@sceltabenefit", DbType.String);
            param23.Value = sceltabenefit;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@codpacchetto", DbType.String);
            param24.Value = codpacchetto;
            collParams.Add(param24);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@datasceltabenefit", DbType.DateTime);
            param25.Value = datasceltabenefit;
            collParams.Add(param25);

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

        public IContratti ReturnDatiBenefitCarPolicy(int idapprovazione)
        {
            IContratti retVal = null;
            string sql = " SELECT TOP 1 * FROM EF_users_carpolicy " +
                         " WHERE idapprovazione = @idapprovazione and approvato = 1 and idstatoapprovazione = 0 ORDER BY idapprovazione DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idapprovazione", DbType.Int32);
            param0.Value = idapprovazione;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                    Codcarbenefit = DataHelper.IfDBNull<string>(row["codcarbenefit"], _stringEmpty),
                    Sceltabenefit = DataHelper.IfDBNull<string>(row["sceltabenefit"], _stringEmpty),
                    Codpacchetto = DataHelper.IfDBNull<string>(row["codpacchetto"], _stringEmpty),
                    Datasceltabenefit = DataHelper.IfDBNull<DateTime>(row["datasceltabenefit"], DateTime.MinValue),
                    Datafinedecorrenza = DataHelper.IfDBNull<DateTime>(row["datafinedecorrenza"], DateTime.MinValue)
                };
                data.Dispose();
            }
            return retVal;
        }


        public int InsertCarPolicy(IContratti value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Datadecorrenza > DateTime.MinValue)
            {
                IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datadecorrenza", DbType.DateTime);
                param15.Value = value.Datadecorrenza;
                collParams.Add(param15);

                sqlfield += " ,[datadecorrenza] ";
                sqlvalue += " ,@datadecorrenza ";
            }

            if (value.Datafinedecorrenza > DateTime.MinValue)
            {
                IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@datafinedecorrenza", DbType.DateTime);
                param16.Value = value.Datafinedecorrenza;
                collParams.Add(param16);

                sqlfield += " ,[datafinedecorrenza] ";
                sqlvalue += " ,@datafinedecorrenza ";
            }

            string sql = " INSERT INTO EF_users_carpolicy ([idutente],[codsocieta],[codcarpolicy],[codcarbenefit],[documentocarpolicy],[documentopatente], " +
                         " [datauserins], [UserIDIns], [datausermod], [UserIdMod],[uidtenant] " + sqlfield + " ) " +
                         " VALUES (@idutente,@codsocieta,@codcarpolicy,'Nobenefit',@documentocarpolicy,@documentopatente, " +
                         " @datauserins, @UserIDIns, @datausermod, @UserIdMod, @uidtenant " + sqlvalue + " ) ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idutente", DbType.Int32);
            param1.Value = value.Idutente;
            collParams.Add(param1);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param3.Value = value.Codcarpolicy;
            collParams.Add(param3);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@codcarbenefit", DbType.String);
            param17.Value = value.Codcarbenefit;
            collParams.Add(param17);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@documentocarpolicy", DbType.String);
            param5.Value = value.Documentocarpolicy;
            collParams.Add(param5);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@documentopatente", DbType.String);
            param8.Value = value.Documentopatente;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param9.Value = DateTime.Now;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param10.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param11.Value = DateTime.Now;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param12.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param12);

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



        public int InsertConfigurazionePartner(IContratti value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_configurazioni_partner ([UserId],[testo],[datainviato],[idstatusordine],[uidtenant]) VALUES (@UserId,@testo,@datainviato,@idstatusordine,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@testo", DbType.String);
            param0.Value = value.Testo;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
            param1.Value = 1;
            collParams.Add(param1);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@datainviato", DbType.Date);
            param9.Value = DateTime.Now;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param10.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param10);

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
        public IContratti ReturnIdConf()
        {
            IContratti retVal = null;
            string sql = " SELECT idconfigurazione FROM EF_configurazioni_partner ORDER BY idconfigurazione DESC ";

            DataTable data = _dataHelper.GetDataTable(sql, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Idconfigurazione = DataHelper.IfDBNull<int>(row["idconfigurazione"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int InsertAllegato(IContratti value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_configurazioni_partner_allegati ([idconfigurazione],[allegato],[uidtenant]) VALUES (@idconfigurazione,@allegato,@Uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idconfigurazione", DbType.Int32);
            param0.Value = value.Idconfigurazione;
            collParams.Add(param0);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@allegato", DbType.String);
            param9.Value = value.Allegato;
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
        public int InsertDelegaDriver(IContratti value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_partner_delega ([UserIdPartner],[UserId],[flgemailmulte],[flgemailpenali],[flgemailticket],[uidtenant]) " +
                         " VALUES (@UserIdPartner,@UserId,@flgemailmulte,@flgemailpenali,@flgemailticket,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdPartner", DbType.Guid);
            param0.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param0);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param9.Value = value.UserId;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@flgemailmulte", DbType.Int32);
            param10.Value = value.Flgemailmulte;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@flgemailpenali", DbType.Int32);
            param11.Value = value.Flgemailpenali;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@flgemailticket", DbType.Int32);
            param12.Value = value.Flgemailticket;
            collParams.Add(param12);

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
        public int DeleteDeleghePartner(IContratti value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_partner_delega WHERE UserIdPartner = @UserIdPartner AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@UserIdPartner", DbType.Guid);
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
        public List<IContratti> SelectDeleghePartner(Guid UserId)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT TOP 3 u.UserId, u.nome, u.cognome, u.matricola, u.email, p.flgemailmulte, p.flgemailpenali, p.flgemailticket FROM EF_partner_delega as p " +
                         " INNER JOIN EF_users as u ON p.UserId = u.UserId WHERE UserIdPartner = @UserId ";

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
                    IContratti item = new Contratti
                    {
                        UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Email = DataHelper.IfDBNull<string>(row["email"], _stringEmpty),
                        Flgemailmulte = DataHelper.IfDBNull<int>(row["flgemailmulte"], 0),
                        Flgemailpenali = DataHelper.IfDBNull<int>(row["flgemailpenali"], 0),
                        Flgemailticket = DataHelper.IfDBNull<int>(row["flgemailticket"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectDelegheDriver(Guid UserId)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT TOP 3 p.UserIdPartner, u.nome, u.cognome, u.matricola FROM EF_partner_delega as p INNER JOIN EF_users as u ON p.UserIdPartner = u.UserId WHERE p.UserId = @UserId ";

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
                    IContratti item = new Contratti
                    {
                        UserId = DataHelper.IfDBNull<Guid>(row["UserIdPartner"], Guid.Empty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")"
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        // conta contratti 
        // FILTRO: codsocieta, UserId, marca, targa, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto
        public int SelectCountContrattiPartner(string codsocieta, Guid UserId, string marca, string targa, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND (a.marca = @marca OR a.modello = @modello ) ";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND c.targa = @targa ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND c.datafinecontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND c.datafinecontratto <= @datacontrattoal";
            if (idstatuscontratto > -1) condWhere += " AND c.idstatuscontratto = @idstatuscontratto ";

            string SQL = " SELECT DISTINCT COUNT(DISTINCT c.Uid) as tot FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_status as cs ON cs.idstatuscontratto = c.idstatuscontratto AND c.uidtenant = cs.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = c.codfornitore AND c.uidtenant = f.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta AND c.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as a ON a.codjatoauto = c.codjatoauto AND a.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserId AND u.uidtenant = c.uidtenant " +
                         " WHERE c.idcontratto > 0 and u.gradecode IN ('10','15') AND c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param3.Value = targa;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatuscontratto > -1)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
                param8.Value = idstatuscontratto;
                collParams.Add(param8);
            }
            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);
            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista contratti
        // FILTRO: codsocieta, UserId, marca, targa, codfornitore, numerocontratto, datacontrattodal, datacontrattoal, idstatuscontratto
        public List<IContratti> SelectContrattiPartner(string codsocieta, Guid UserId, string marca, string targa, string codfornitore, string numerocontratto, DateTime datacontrattodal, DateTime datacontrattoal, int idstatuscontratto, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " c.datacontratto ";
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

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND c.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " AND (a.marca = @marca OR a.modello = @modello ) ";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND c.targa = @targa ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND c.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerocontratto)) condWhere += " AND c.numerocontratto = @numerocontratto ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND c.datafinecontratto >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND c.datafinecontratto <= @datacontrattoal";
            if (idstatuscontratto > -1) condWhere += " AND c.idstatuscontratto = @idstatuscontratto ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = "SELECT DISTINCT f.codfornitore, c.numerocontratto, c.datacontratto, c.targa, a.modello, a.marca, s.siglasocieta, u.nome, u.cognome, " +
                         " u.matricola, c.duratamesi, c.kmcontratto, c.datafinecontratto, cs.statuscontratto, c.Uid  FROM EF_contratti as c " +
                         " LEFT JOIN EF_contratti_status as cs ON cs.idstatuscontratto = c.idstatuscontratto AND cs.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = c.codfornitore AND f.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = c.codsocieta AND c.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as a ON a.codjatoauto = c.codjatoauto and a.codcarlist = c.codcarlist AND c.uidtenant = a.uidtenant " +
                         " LEFT JOIN EF_users as u ON u.UserId = c.UserId AND c.uidtenant = u.uidtenant " +
                         " WHERE c.idcontratto > 0 and u.gradecode IN ('10','15') AND c.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param0.Value = codsocieta;
                collParams.Add(param0);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(marca))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
                param2.Value = marca;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param3.Value = targa;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerocontratto))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerocontratto", DbType.String);
                param5.Value = numerocontratto;
                collParams.Add(param5);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            if (idstatuscontratto > -1)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idstatuscontratto", DbType.Int32);
                param8.Value = idstatuscontratto;
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
                    IContratti item = new Contratti
                    {
                        Fornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Kmcontratto = DataHelper.IfDBNull<int>(row["kmcontratto"], 0),
                        Duratamesi = DataHelper.IfDBNull<int>(row["duratamesi"], 0),
                        Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                        Statuscontratto = DataHelper.IfDBNull<string>(row["statuscontratto"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        // conta richieste ordini
        // FILTRO: keysearch, UserId, idstatusordine
        public int SelectCountRichiesteOrdiniPartner(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (idstatusordine > 0) condWhere += " AND o.idstatusordine = @idstatusordine ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND g.codgrade = @codgrade ";
            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " AND o.codcarlist = @codcarlist ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND o.codfornitore = @codfornitore ";
            if (datadal > DateTime.MinValue) condWhere += " AND o.dataordine >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND o.dataordine <= @dataal";

            string SQL = " SELECT COUNT(*) as tot FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId AND o.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore AND o.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta AND o.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist as cl ON cl.codcarlist = o.codcarlist AND o.uidtenant = cl.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = o.codfornitore AND o.uidtenant = f.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND u.uidtenant = g.uidtenant " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine AND o.uidtenant = os.uidtenant " +
                         " WHERE o.idordine > 0 AND o.idstatusordine <> 0  and u.gradecode IN ('10','15') AND o.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (idstatusordine > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param1.Value = idstatusordine;
                collParams.Add(param1);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param4.Value = codgrade;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param5.Value = codcarlist;
                collParams.Add(param5);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param6.Value = codfornitore;
                collParams.Add(param6);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
                collParams.Add(param8);
            }
            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista richieste ordini
        // FILTRO: keysearch, UserId, idstatusordine
        public List<IContratti> SelectRichiesteOrdiniPartner(string keysearch, string codsocieta, string codgrade, string codcarlist, string codfornitore, DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.codjatoauto LIKE '%' + @keysearch + '%' OR ca.modello LIKE '%' + @keysearch + '%') ";
            if (UserId != Guid.Empty) condWhere += " AND o.UserId = @UserId ";
            if (idstatusordine > -1) condWhere += " AND o.idstatusordine = @idstatusordine ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND o.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND g.codgrade = @codgrade ";
            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " AND o.codcarlist = @codcarlist ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND o.codfornitore = @codfornitore ";
            if (datadal > DateTime.MinValue) condWhere += " AND o.dataordine >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND o.dataordine <= @dataal";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.codjatoauto, ca.modello, ca.marca, cl.codcarlist, s.siglasocieta, g.grade, o.dataordine, o.numeroordine, o.Uid, u.cognome, o.dataconsegnaprevista, " +
                         " u.nome, u.matricola, os.statusordine, o.idstatusordine, o.deltacanone, u.iduser, f.fornitore, o.fileordinepdf, o.codfornitore FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId AND o.uidtenant = u.uidtenant " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore AND o.uidtenant = ca.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta AND o.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_carlist as cl ON cl.codcarlist = o.codcarlist AND o.uidtenant = cl.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON f.codfornitore = o.codfornitore AND o.uidtenant = f.uidtenant" +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode AND u.uidtenant = g.uidtenant" +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine AND os.uidtenant = o.uidtenant " +
                         " WHERE o.idordine > 0 AND o.idstatusordine <> 0  and u.gradecode IN ('10','15') AND o.uidtenant = @Uidtenant " + condWhere +
                         " ORDER BY o.dataordine DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
            if (idstatusordine > 0)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param1.Value = idstatusordine;
                collParams.Add(param1);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param3.Value = codsocieta;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param4.Value = codgrade;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param5.Value = codcarlist;
                collParams.Add(param5);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param6.Value = codfornitore;
                collParams.Add(param6);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
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
                    IContratti item = new Contratti
                    {
                        Idutente = DataHelper.IfDBNull<int>(row["iduser"], 0),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                        Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Deltacanone = DataHelper.IfDBNull<decimal>(row["deltacanone"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty),
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Numeroordine = DataHelper.IfDBNull<string>(row["numeroordine"], _stringEmpty),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Fileordinepdf = DataHelper.IfDBNull<string>(row["fileordinepdf"], _stringEmpty),
                        Dataconsegnaprevista = DataHelper.IfDBNull<DateTime>(row["dataconsegnaprevista"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }






        public int SelectCountConfigurazioniPartner(DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant)
        {
            string condWhere = "";
            if (UserId != Guid.Empty) condWhere += " AND c.UserId = @UserId ";
            if (datadal > DateTime.MinValue) condWhere += " AND c.datainviato >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND c.datainviato <= @dataal";
            if (idstatusordine > 0) condWhere += " AND c.idstatusordine = @idstatusordine ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_configurazioni_partner as c " +
                         " LEFT JOIN EF_configurazioni_partner_status as s ON s.idstatusordine = c.idstatusordine AND c.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_users as u ON c.UserId = u.UserId AND c.uidtenant = u.uidtenant WHERE c.idconfigurazione > 0 AND c.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
                collParams.Add(param8);
            }
            if (idstatusordine > 0)
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param9.Value = idstatusordine;
                collParams.Add(param9);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectConfigurazioniPartner(DateTime datadal, DateTime dataal, Guid UserId, int idstatusordine, Guid Uidtenant, int numrecord, int pagina)
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
            if (datadal > DateTime.MinValue) condWhere += " AND c.datainviato >= @datadal";
            if (dataal > DateTime.MinValue) condWhere += " AND c.datainviato <= @dataal";
            if (idstatusordine > 0) condWhere += " AND c.idstatusordine = @idstatusordine ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT c.idconfigurazione, c.datainviato, c.Uid, u.Matricola, u.cognome, u.nome, s.statusordine FROM EF_configurazioni_partner as c " +
                         " LEFT JOIN EF_configurazioni_partner_status as s ON s.idstatusordine = c.idstatusordine AND c.uidtenant = s.uidtenant " +
                         " LEFT JOIN EF_users as u ON c.UserId = u.UserId AND c.uidtenant = u.uidtenant WHERE c.idconfigurazione > 0 AND c.uidtenant = @Uidtenant " + condWhere + " ORDER BY c.datainviato DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param2.Value = UserId;
                collParams.Add(param2);
            }
            if (datadal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
                param7.Value = datadal;
                collParams.Add(param7);
            }
            if (dataal > DateTime.MinValue)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
                param8.Value = dataal;
                collParams.Add(param8);
            }
            if (idstatusordine > 0)
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
                param9.Value = idstatusordine;
                collParams.Add(param9);
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
                    IContratti item = new Contratti
                    {
                        Idconfigurazione = DataHelper.IfDBNull<int>(row["idconfigurazione"], 0),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Datainviato = DataHelper.IfDBNull<DateTime>(row["datainviato"], DateTime.MinValue),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        public List<IContratti> SelectAllegatiConfigurazioniPartner(int idconfigurazione)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT * FROM EF_configurazioni_partner_allegati WHERE idconfigurazione = @idconfigurazione ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@idconfigurazione", DbType.Int32);
            param2.Value = idconfigurazione;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Allegato = DataHelper.IfDBNull<string>(row["allegato"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IContratti DetailConfigurazionePartner(Guid Uid)
        {
            IContratti retVal = null;
            string sql = " SELECT * FROM EF_configurazioni_partner WHERE Uid = @Uid ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Idconfigurazione = DataHelper.IfDBNull<int>(row["idconfigurazione"], 0),
                    Testo = DataHelper.IfDBNull<string>(row["testo"], _stringEmpty),
                    Datainviato = DataHelper.IfDBNull<DateTime>(row["datainviato"], DateTime.MinValue),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0)
                };
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectAllTipoPenaleAuto(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_penali_auto_tipo WHERE uidtenant = @Uidtenant ORDER BY tipopenaleauto ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Idtipopenaleauto = DataHelper.IfDBNull<int>(row["idtipopenaleauto"], 0),
                        Tipopenaleauto = DataHelper.IfDBNull<string>(row["tipopenaleauto"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        // conta penali 
        // FILTRO: UserId, targa, codfornitore, numerofattura, datafatturadal, datafatturaal, idtipopenaleauto, status
        public int SelectCountPenaliAuto(Guid UserId, string targa, string codfornitore, string numerofattura, DateTime datafatturadal, DateTime datafatturaal, int idtipopenaleauto, string status, Guid Uidtenant)
        {
            string condWhere = "";
            if (UserId != Guid.Empty) condWhere += " AND p.UserId = @UserId ";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND p.targa = @targa ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND p.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerofattura)) condWhere += " AND p.numerofattura = @numerofattura ";
            if (datafatturadal > DateTime.MinValue) condWhere += " AND p.datafattura >= @datafatturadal";
            if (datafatturaal > DateTime.MinValue) condWhere += " AND p.datafattura <= @datafatturaal";
            if (idtipopenaleauto > 0) condWhere += " AND p.idtipopenaleauto = @idtipopenaleauto ";
            if (!string.IsNullOrEmpty(status)) condWhere += " AND p.status = @status ";

            string SQL = " SELECT COUNT(idpenale) as tot FROM EF_penali_auto as p " +
                         " LEFT JOIN EF_penali_auto_tipo as t ON p.idtipopenaleauto = t.idtipopenaleauto AND p.uidtenant = t.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON p.codfornitore = f.codfornitore AND p.uidtenant = f.uidtenant " +
                         " LEFT JOIN EF_users as u ON p.UserId = u.UserId AND p.uidtenant = u.uidtenant" +
                         " WHERE p.idpenale > 0 AND p.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param3.Value = targa;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerofattura))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerofattura", DbType.String);
                param5.Value = numerofattura;
                collParams.Add(param5);
            }
            if (datafatturadal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datafatturadal", DbType.DateTime);
                param6.Value = datafatturadal;
                collParams.Add(param6);
            }
            if (datafatturaal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datafatturaal", DbType.DateTime);
                param7.Value = datafatturaal;
                collParams.Add(param7);
            }
            if (idtipopenaleauto > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idtipopenaleauto", DbType.Int32);
                param8.Value = idtipopenaleauto;
                collParams.Add(param8);
            }
            if (!string.IsNullOrEmpty(status))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@status", DbType.String);
                param9.Value = status;
                collParams.Add(param9);
            }
            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param10.Value = Uidtenant;
            collParams.Add(param10);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista penali
        // FILTRO: UserId, targa, codfornitore, numerofattura, datafatturadal, datafatturaal, idtipopenaleauto, status
        public List<IContratti> SelectPenaliAuto(Guid UserId, string targa, string codfornitore, string numerofattura, DateTime datafatturadal, DateTime datafatturaal, int idtipopenaleauto, string status, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " p.datafattura ";
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

            if (UserId != Guid.Empty) condWhere += " AND p.UserId = @UserId ";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND p.targa = @targa ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND p.codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(numerofattura)) condWhere += " AND p.numerofattura = @numerofattura ";
            if (datafatturadal > DateTime.MinValue) condWhere += " AND p.datafattura >= @datafatturadal";
            if (datafatturaal > DateTime.MinValue) condWhere += " AND p.datafattura <= @datafatturaal";
            if (idtipopenaleauto > 0) condWhere += " AND p.idtipopenaleauto = @idtipopenaleauto ";
            if (!string.IsNullOrEmpty(status)) condWhere += " AND p.status = @status ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT u.nome, u.cognome, u.matricola, t.tipopenaleauto, f.fornitore, p.targa, p.datafattura, p.numerofattura, p.Uid, p.filepenale, p.status, p.importo FROM EF_penali_auto as p " +
                         " LEFT JOIN EF_penali_auto_tipo as t ON p.idtipopenaleauto = t.idtipopenaleauto AND p.uidtenant = t.uidtenant " +
                         " LEFT JOIN EF_fornitori as f ON p.codfornitore = f.codfornitore AND p.uidtenant = f.uidtenant " +
                         " LEFT JOIN EF_users as u ON p.UserId = u.UserId AND p.uidtenant = u.uidtenant " +
                         " WHERE p.idpenale > 0 AND p.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param3.Value = targa;
                collParams.Add(param3);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param4.Value = codfornitore;
                collParams.Add(param4);
            }
            if (!string.IsNullOrEmpty(numerofattura))
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@numerofattura", DbType.String);
                param5.Value = numerofattura;
                collParams.Add(param5);
            }
            if (datafatturadal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datafatturadal", DbType.DateTime);
                param6.Value = datafatturadal;
                collParams.Add(param6);
            }
            if (datafatturaal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datafatturaal", DbType.DateTime);
                param7.Value = datafatturaal;
                collParams.Add(param7);
            }
            if (idtipopenaleauto > 0)
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@idtipopenaleauto", DbType.Int32);
                param8.Value = idtipopenaleauto;
                collParams.Add(param8);
            }
            if (!string.IsNullOrEmpty(status))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@status", DbType.String);
                param9.Value = status;
                collParams.Add(param9);
            }
            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param10.Value = Uidtenant;
            collParams.Add(param10);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                        Numerofattura = DataHelper.IfDBNull<string>(row["numerofattura"], _stringEmpty),
                        Datafattura = DataHelper.IfDBNull<DateTime>(row["datafattura"], DateTime.MinValue),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Tipopenaleauto = DataHelper.IfDBNull<string>(row["tipopenaleauto"], _stringEmpty),
                        Filepenale = DataHelper.IfDBNull<string>(row["filepenale"], _stringEmpty),
                        Statuscontratto = DataHelper.IfDBNull<string>(row["status"], _stringEmpty),
                        Importo = DataHelper.IfDBNull<int>(row["importo"], 0),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int InsertPenale(IContratti value)
        {
            int retVal = 0;

            string sqlfield = string.Empty;
            string sqlvalue = string.Empty;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (value.Datafattura > DateTime.MinValue)
            {
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@datafattura", DbType.DateTime);
                param10.Value = value.Datafattura;
                collParams.Add(param10);

                sqlfield += " ,[datafattura] ";
                sqlvalue += " ,@datafattura ";
            }
            string sql = " INSERT INTO EF_penali_auto ([targa],[UserId],[codfornitore],[numerofattura],[importo],[filepenale],[notificato],[idtipopenaleauto], " +
                         " [datauserins],[datausermod],[UserIDIns],[UserIdMod],[status],[uidtenant] " + sqlfield + " ) " +
                         " VALUES (@targa,@UserId,@codfornitore,@numerofattura,@importo,@filepenale,@notificato,@idtipopenaleauto, " +
                         " @datauserins,@datausermod,@UserIDIns,@UserIdMod,@status,@uidtenant " + sqlvalue + " ) ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param0.Value = value.Targa;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = value.UserId;
            collParams.Add(param1);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param5.Value = value.Codfornitore;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@numerofattura", DbType.String);
            param6.Value = value.Numerofattura;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@importo", DbType.Decimal);
            param7.Value = value.Importo;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@filepenale", DbType.String);
            param8.Value = value.Filepenale;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@notificato", DbType.String);
            param9.Value = "SI";
            collParams.Add(param9);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@idtipopenaleauto", DbType.Int32);
            param11.Value = value.Idtipopenaleauto;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@status", DbType.String);
            param12.Value = "DA DEFINIRE";
            collParams.Add(param12);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param20.Value = DateTime.Now;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param21.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param22.Value = DateTime.Now;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param23.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param24.Value = value.Uidtenant;
            collParams.Add(param24);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti DetailIdPenale(Guid Uid)
        {
            IContratti retVal = null;
            string sql = " SELECT * FROM EF_penali_auto WHERE Uid = @Uid ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                    Numerofattura = DataHelper.IfDBNull<string>(row["numerofattura"], _stringEmpty),
                    Datafattura = DataHelper.IfDBNull<DateTime>(row["datafattura"], DateTime.MinValue),
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    Filepenale = DataHelper.IfDBNull<string>(row["filepenale"], _stringEmpty),
                    Idtipopenaleauto = DataHelper.IfDBNull<int>(row["idtipopenaleauto"], 0),
                    Importo = DataHelper.IfDBNull<decimal>(row["importo"], 0),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int UpdatePenale(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_penali_auto SET [targa] = @targa, [UserId] = @UserId, [codfornitore] = @codfornitore, [numerofattura] = @numerofattura, " +
                         " [importo] = @importo, [filepenale] = @filepenale, [idtipopenaleauto] = @idtipopenaleauto, [datausermod] = @datausermod, [UserIdMod] = @UserIdMod ";


            if (value.Datafattura > DateTime.MinValue)
            {
                sql += " ,[datafattura] = @datafattura ";
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@datafattura", DbType.DateTime);
                param10.Value = value.Datafattura;
                collParams.Add(param10);
            }

            sql += " WHERE Uid = @Uid AND uidtenant = @Uidtenant  ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param0.Value = value.Targa;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param1.Value = value.UserId;
            collParams.Add(param1);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param5.Value = value.Codfornitore;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@numerofattura", DbType.String);
            param6.Value = value.Numerofattura;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@importo", DbType.Decimal);
            param7.Value = value.Importo;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@filepenale", DbType.String);
            param8.Value = value.Filepenale;
            collParams.Add(param8);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@idtipopenaleauto", DbType.Int32);
            param11.Value = value.Idtipopenaleauto;
            collParams.Add(param11);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param20.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = value.Uid;
            collParams.Add(param22);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param12.Value = value.Uidtenant;
            collParams.Add(param12);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int UpdateStatusPenale(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_penali_auto SET [status] = @status, [datausermod] = @datausermod, [UserIdMod] = @UserIdMod WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@status", DbType.String);
            param0.Value = value.Statuscontratto;
            collParams.Add(param0);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param20.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = value.Uid;
            collParams.Add(param22);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param12.Value = value.Uidtenant;
            collParams.Add(param12);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public List<IContratti> SelectStatusConfigurazionePartner(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_configurazioni_partner_status WHERE uidtenant = @Uidtenant ORDER BY idstatusordine ";

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
                    IContratti item = new Contratti
                    {
                        Idstatusordine = DataHelper.IfDBNull<int>(row["idstatusordine"], 0),
                        Statusordine = DataHelper.IfDBNull<string>(row["statusordine"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateStatusConfigurazionePartner(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_configurazioni_partner SET [idstatusordine] = @idstatusordine WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusordine", DbType.Int32);
            param0.Value = value.Idstatusordine;
            collParams.Add(param0);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = value.Uid;
            collParams.Add(param22);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param12.Value = value.Uidtenant;
            collParams.Add(param12);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public int SelectCountDelegheDriver(Guid UserId)
        {
            string SQL = " SELECT COUNT(UserIdPartner) as tot FROM EF_partner_delega WHERE UserId = @UserId ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param0.Value = UserId;
            collParams.Add(param0);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public IContratti ExistCarPolicyMobilita(string codcarpolicy)
        {
            IContratti retVal = null;
            string dataoggi = DateTime.Now.ToString("dd/MM/yyyy");

            string sql = " SELECT codcarbenefit FROM EF_carpolicy_assegna_societa WHERE codcarpolicy = @codcarpolicy AND validodal <= @dataoggi AND validoal >= @dataoggi ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param0.Value = codcarpolicy;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@dataoggi", DbType.DateTime);
            param1.Value = dataoggi;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Codcarbenefit = DataHelper.IfDBNull<string>(row["codcarbenefit"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountRichiesteOrdiniDriverXCodjato(Guid UserId, string codjatoauto)
        {
            string SQL = " SELECT COUNT(ca.codjatoauto) as tot FROM EF_ordini as o " +
                         " LEFT JOIN EF_users as u ON o.UserId = u.UserId " +
                         " LEFT JOIN EF_carlist_auto as ca ON ca.codjatoauto = o.codjatoauto and ca.codcarlist = o.codcarlist and ca.codfornitore = o.codfornitore " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = o.codsocieta " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = u.gradecode " +
                         " LEFT JOIN EF_ordini_status as os ON os.idstatusordine = o.idstatusordine " +
                         " WHERE o.UserId = @UserId AND o.idstatusordine < 100 and ca.codjatoauto = @codjatoauto ";

            List <IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
            param2.Value = UserId;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param3.Value = codjatoauto;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public List<IContratti> SelectOptionalAutoXOrdine(int idordine)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT DISTINCT ao.optional, idordine, importooptional FROM EF_ordini_optional as o1 LEFT JOIN EF_carlist_optional as ao ON ao.codoptional = o1.codoptional " + 
                         " where o1.codoptional IN(SELECT codoptional FROM EF_carlist_optional WHERE codcategoriaoptional<> 'COL') and idordine = @idordine and importooptional > 0  ";


            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idordine", DbType.Int32);
            param1.Value = idordine;
            collParams.Add(param1);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Codoptional = DataHelper.IfDBNull<string>(row["optional"], _stringEmpty),
                        Importooptional = DataHelper.IfDBNull<decimal>(row["importooptional"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateFileLibrettoAuto(Guid Uid, string filelibrettoautocontratto, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti SET [filelibrettoautocontratto] = @filelibrettoautocontratto WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param22.Value = Uid;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@filelibrettoautocontratto", DbType.String);
            param21.Value = filelibrettoautocontratto;
            collParams.Add(param21);

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

        public int DeleteAutoSost(Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_contratti_autosostituive WHERE Uid = @Uid AND uidtenant = @Uidtenant";

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
        public List<IContratti> SelectExtraPlafond(string codsocieta, Guid UserId, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND p.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND p.UserId = @UserId ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT u.nome, u.cognome, u.matricola, s.societa, p.importopenale, p.userid FROM EF_penali_extraplafond as p " +
                         " LEFT JOIN EF_users as u ON u.UserId = p.UserId AND u.uidtenant = p.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = p.codsocieta AND s.uidtenant = p.uidtenant " +
                         " WHERE p.idplafond > 0 AND p.uidtenant = @Uidtenant " + condWhere + " ORDER BY u.cognome, u.nome " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
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
                    IContratti item = new Contratti
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Importo = DataHelper.IfDBNull<decimal>(row["importopenale"], 0),
                        UserId = DataHelper.IfDBNull<Guid>(row["userid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountExtraPlafond(string codsocieta, Guid UserId, Guid Uidtenant)
        {
            string condWhere = "";

            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND p.codsocieta = @codsocieta ";
            if (UserId != Guid.Empty) condWhere += " AND p.UserId = @UserId ";

            string sql = " SELECT COUNT(p.idplafond) as tot FROM EF_penali_extraplafond as p " +
                         " LEFT JOIN EF_users as u ON u.UserId = p.UserId AND u.uidtenant = p.uidtenant " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = p.codsocieta AND s.uidtenant = p.uidtenant " +
                         " WHERE p.idplafond > 0 AND p.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }

        //cancella penale
        public int DeletePenali(IContratti value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_penali_auto WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

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

        public List<IContratti> SelectRevisioniUser(Guid UserId, string targa, int anno, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND targa LIKE '%' + @targa + '%' ";
            if (UserId != Guid.Empty) condWhere += " AND UserId = @UserId ";
            if (anno > 0) condWhere += " AND anno = @anno";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT * FROM EF_contratti_revisioni WHERE idrevisione > 0 " + condWhere + " ORDER BY anno DESC, mese DESC " + paginazione;

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
            if (anno > 0)
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@anno", DbType.Int32);
                param0.Value = anno;
                collParams.Add(param0);
            }

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Datacheck = DataHelper.IfDBNull<DateTime>(row["datacheck"], DateTime.MinValue),
                        Idstatuscontratto = DataHelper.IfDBNull<int>(row["statuscheck"], 0),
                        Mese = DataHelper.IfDBNull<int>(row["mese"], 0),
                        Anno = DataHelper.IfDBNull<int>(row["anno"], 0),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountRevisioniUser(Guid UserId, string targa, int anno)
        {
            string condWhere = "";

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND targa LIKE '%' + @targa + '%' ";
            if (UserId != Guid.Empty) condWhere += " AND UserId = @UserId ";
            if (anno > 0) condWhere += " AND anno = @anno";

            string sql = " SELECT COUNT(idrevisione) as tot FROM EF_contratti_revisioni WHERE idrevisione > 0 " + condWhere;

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
            if (anno > 0)
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@anno", DbType.Int32);
                param0.Value = anno;
                collParams.Add(param0);
            }

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }
        public IContratti DetailRevisioniId(Guid Uid)
        {
            IContratti retVal = null;
            string sql = "SELECT * FROM EF_contratti_revisioni WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    Filepdf = DataHelper.IfDBNull<string>(row["filerev"], _stringEmpty),
                    Datacheck = DataHelper.IfDBNull<DateTime>(row["datacheck"], DateTime.MinValue),
                    Idstatuscontratto = DataHelper.IfDBNull<int>(row["statuscheck"], 0),
                    Mese = DataHelper.IfDBNull<int>(row["mese"], 0),
                    Anno = DataHelper.IfDBNull<int>(row["anno"], 0),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                };

                data.Dispose();
            }
            return retVal;
        }
        public int UpdateCheckRevisione(Guid Uid, string filerev, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti_revisioni SET [datacheck] = @datacheck, [statuscheck] = 1, [filerev] = @filerev WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param20.Value = Uid;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@datacheck", DbType.DateTime);
            param21.Value = DateTime.Now;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@filerev", DbType.String);
            param22.Value = filerev;
            collParams.Add(param22);

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
        public List<IContratti> SelectRevisioniAll(Guid UserId, string targa, int anno, int statuscheck, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND targa LIKE '%' + @targa + '%' ";
            if (UserId != Guid.Empty) condWhere += " AND r.UserId = @UserId ";
            if (anno > 0) condWhere += " AND anno = @anno";
            if (statuscheck > -1) condWhere += " AND statuscheck = @statuscheck";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT u.cognome, u.nome, u.matricola, r.* FROM EF_contratti_revisioni as r " +
                         " LEFT JOIN EF_users as u ON r.UserId = u.UserId AND r.uidtenant = u.uidtenant WHERE idrevisione > 0 AND r.uidtenant = @Uidtenant " + condWhere + " ORDER BY anno DESC, mese DESC " + paginazione;

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
            if (anno > 0)
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@anno", DbType.Int32);
                param0.Value = anno;
                collParams.Add(param0);
            }
            if (statuscheck > -1)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@statuscheck", DbType.Int32);
                param3.Value = statuscheck;
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
                    IContratti item = new Contratti
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Datacheck = DataHelper.IfDBNull<DateTime>(row["datacheck"], DateTime.MinValue),
                        Idstatuscontratto = DataHelper.IfDBNull<int>(row["statuscheck"], 0),
                        Mese = DataHelper.IfDBNull<int>(row["mese"], 0),
                        Anno = DataHelper.IfDBNull<int>(row["anno"], 0),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountRevisioniAll(Guid UserId, string targa, int anno, int statuscheck, Guid Uidtenant)
        {
            string condWhere = "";

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND targa LIKE '%' + @targa + '%' ";
            if (UserId != Guid.Empty) condWhere += " AND r.UserId = @UserId ";
            if (anno > 0) condWhere += " AND anno = @anno";
            if (statuscheck > -1) condWhere += " AND statuscheck = @statuscheck";

            string sql = " SELECT COUNT(idrevisione) as tot FROM EF_contratti_revisioni as r " +
                         " LEFT JOIN EF_users as u ON r.UserId = u.UserId AND r.uidtenant = u.uidtenant WHERE idrevisione > 0 AND r.uidtenant = @Uidtenant " + condWhere;

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
            if (anno > 0)
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@anno", DbType.Int32);
                param0.Value = anno;
                collParams.Add(param0);
            }
            if (statuscheck > -1)
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@statuscheck", DbType.Int32);
                param3.Value = statuscheck;
                collParams.Add(param3);
            }

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param4.Value = Uidtenant;
            collParams.Add(param4);            

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }

        public List<IContratti> SelectTipoUtilizzo(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT * FROM EF_contratti_utilizzo WHERE uidtenant = @Uidtenant ORDER BY tipoutilizzo ";

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
                    IContratti item = new Contratti
                    {
                        Codutilizzo = DataHelper.IfDBNull<string>(row["codutilizzo"], _stringEmpty),
                        Tipoutilizzo = DataHelper.IfDBNull<string>(row["tipoutilizzo"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountAutoServizio(string targa, string targasearch, Guid UserId, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (!string.IsNullOrEmpty(targasearch)) condWhere += " AND ca.targa = @targasearch ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND ca.assegnatoal >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND ca.assegnatoal <= @datacontrattoal";

            string sql = " SELECT COUNT(ca.idassegnazione) as tot FROM EF_contratti_autoservizio as ca " +
                         " LEFT JOIN EF_contratti as c ON ca.targa = c.targa " +
                         " LEFT JOIN EF_users as u ON u.UserId = ca.UserID " +
                         " WHERE ca.idassegnazione > 0 AND ca.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (!string.IsNullOrEmpty(targasearch))
            {
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@targasearch", DbType.String);
                param10.Value = targasearch;
                collParams.Add(param10);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectAutoServizio(string targa, string targasearch, Guid UserId, DateTime datacontrattodal, DateTime datacontrattoal, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " ca.assegnatoal DESC ";
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

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (!string.IsNullOrEmpty(targasearch)) condWhere += " AND ca.targa = @targasearch ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";
            if (datacontrattodal > DateTime.MinValue) condWhere += " AND ca.assegnatoal >= @datacontrattodal";
            if (datacontrattoal > DateTime.MinValue) condWhere += " AND ca.assegnatoal <= @datacontrattoal";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.autorizzatoadmin, ca.targa, c.codfornitore, c.numerocontratto, c.datacontratto, u.cognome, u.nome, u.matricola, ca.assegnatodal, ca.assegnatoal, " +
                         " ca.idassegnazione, s.siglasocieta, cl.modello, cl.marca, " +
                         " (SELECT COUNT(ca1.targa) FROM EF_contratti_autoservizio as ca1  WHERE ca1.idassegnazione = ca.idassegnazione AND scopoviaggio<>'') as count " + 
                         " FROM EF_contratti_autoservizio as ca " +
                         " LEFT JOIN EF_contratti as c ON ca.targa = c.targa " +
                         " LEFT JOIN EF_carlist_auto as cl ON cl.codjatoauto = c.codjatoauto " +
                         " LEFT JOIN EF_users as u ON u.UserId = ca.UserID " +
                         " LEFT JOIN EF_societa as s ON s.codsocieta = u.codsocieta " +
                         " WHERE ca.idassegnazione > 0 AND ca.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (!string.IsNullOrEmpty(targasearch))
            {
                IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@targasearch", DbType.String);
                param10.Value = targasearch;
                collParams.Add(param10);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            if (datacontrattodal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattodal", DbType.DateTime);
                param6.Value = datacontrattodal;
                collParams.Add(param6);
            }
            if (datacontrattoal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datacontrattoal", DbType.DateTime);
                param7.Value = datacontrattoal;
                collParams.Add(param7);
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
                    IContratti item = new Contratti
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Numerocontratto = DataHelper.IfDBNull<string>(row["numerocontratto"], _stringEmpty),
                        Datacontratto = DataHelper.IfDBNull<DateTime>(row["datacontratto"], DateTime.MinValue),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                        Societa = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Idassegnazione = DataHelper.IfDBNull<int>(row["idassegnazione"], 0),
                        Totuser = DataHelper.IfDBNull<int>(row["count"], 0),
                        Autorizzatoadmin = DataHelper.IfDBNull<int>(row["autorizzatoadmin"], 0),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        public List<IContratti> SelectPrenotazioniAutoServizio(string targa)
        {
            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT ca.targa, u.cognome, u.nome, u.matricola, ca.assegnatodal, ca.assegnatoal, ca.idassegnazione, ca.noteamministrazione FROM EF_contratti_autoservizio as ca " +
                         " LEFT JOIN EF_contratti as c ON ca.targa = c.targa " +
                         " LEFT JOIN EF_users as u ON u.UserId = ca.UserID " +
                         " WHERE ca.idassegnazione > 0 AND ca.autorizzatoadmin = 1 AND ca.targa = @targa ORDER BY ca.assegnatodal ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param9.Value = targa;
            collParams.Add(param9);
            
            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                        Idassegnazione = DataHelper.IfDBNull<int>(row["idassegnazione"], 0),
                        Noteamministrazione = DataHelper.IfDBNull<string>(row["noteamministrazione"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public bool ExistPrenotazioneAutoServizio(DateTime datadal, DateTime dataal, string targa)
        {
            bool retVal = false;

            string sql = " SELECT idassegnazione FROM EF_contratti_autoservizio " +
                         " WHERE ((assegnatodal BETWEEN @datadal AND @dataal) OR (assegnatoal BETWEEN @datadal AND @dataal)) AND Targa = @targa and autorizzatoadmin = 1 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@datadal", DbType.DateTime);
            param1.Value = datadal;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@dataal", DbType.DateTime);
            param2.Value = dataal;
            collParams.Add(param2);

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
        public int InsertPrenotazioneAutoServizio(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " INSERT INTO EF_contratti_autoservizio ([UserID],[targa],[assegnatodal],[assegnatoal],[idstatusassegnazione],[noteamministrazione],[uidtenant],[autorizzatoadmin]) " +
                         " VALUES (@UserId,@targa,@assegnatodal,@assegnatoal,@idstatusassegnazione,@noteamministrazione,@uidtenant,@autorizzatoadmin) ";

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@UserID", DbType.Guid);
            param22.Value = value.UserId;
            collParams.Add(param22);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param21.Value = value.Targa;
            collParams.Add(param21);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatodal", DbType.Date);
            param19.Value = value.Assegnatodal;
            collParams.Add(param19);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@assegnatoal", DbType.Date);
            param18.Value = value.Assegnatoal;
            collParams.Add(param18);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@idstatusassegnazione", DbType.Int32);
            param17.Value = value.Idstatusassegnazione;
            collParams.Add(param17);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@noteamministrazione", DbType.String);
            param23.Value = value.Noteamministrazione;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param24.Value = value.Uidtenant;
            collParams.Add(param24);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@autorizzatoadmin", DbType.Int32);
            param25.Value = value.Autorizzatoadmin;
            collParams.Add(param25);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }
        public IContratti ReturnOrdineFirma(Guid Uidtenant)
        {
            IContratti retVal = null;
            string sql = "SELECT TOP 1 uid FROM EF_ordini WHERE uidtenant = @Uidtenant AND idstatusordine = 40 ORDER BY dataordine ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param0.Value = Uidtenant;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Uid = DataHelper.IfDBNull<Guid>(row["uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public IContratti DetailAutoServizioId(int idassegnazione)
        {
            IContratti retVal = null;
            string sql = " SELECT a.*, cl.modello FROM EF_contratti_autoservizio as a " + 
                         " LEFT JOIN EF_contratti as c ON a.targa = c.targa " +
                         " LEFT JOIN EF_carlist_auto as cl ON cl.codjatoauto = c.codjatoauto WHERE idassegnazione = @idassegnazione ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param1.Value = idassegnazione;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                    Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                    Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                    Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    UserId = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                    Scopoviaggio = DataHelper.IfDBNull<string>(row["scopoviaggio"], _stringEmpty),
                    Kminiziali = DataHelper.IfDBNull<decimal>(row["kminiziali"], 0),
                    Kmrestituzione = DataHelper.IfDBNull<decimal>(row["kmrestituzione"], 0),
                    Spese = DataHelper.IfDBNull<string>(row["spese"], _stringEmpty),
                    Importospese = DataHelper.IfDBNull<decimal>(row["importospese"], 0),
                    Noterestituzione = DataHelper.IfDBNull<string>(row["noterestituzione"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateAutoServizio(IContratti value)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti_autoservizio SET [scopoviaggio] = @scopoviaggio, [kminiziali] = @kminiziali, [kmrestituzione] = @kmrestituzione, " +
                         " [spese] = @spese, [importospese] = @importospese, [noterestituzione] = @noterestituzione WHERE idassegnazione = @idassegnazione AND uidtenant = @Uidtenant ";

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@scopoviaggio", DbType.String);
            param0.Value = value.Scopoviaggio;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@kminiziali", DbType.Decimal);
            param1.Value = value.Kminiziali;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@kmrestituzione", DbType.Decimal);
            param2.Value = value.Kmrestituzione;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@spese", DbType.String);
            param3.Value = value.Spese;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@importospese", DbType.Decimal);
            param4.Value = value.Importospese;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@noterestituzione", DbType.String);
            param5.Value = value.Noterestituzione;
            collParams.Add(param5);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param22.Value = value.Idassegnazione;
            collParams.Add(param22);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param12.Value = value.Uidtenant;
            collParams.Add(param12);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        public int SelectCountLibrettoAutoServizio(string targa, Guid UserId, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";

            string sql = " SELECT COUNT(DISTINCT ca.targa) as tot FROM EF_contratti_autoservizio as ca " +
                         " LEFT JOIN EF_contratti as c ON ca.targa = c.targa " +
                         " LEFT JOIN EF_carlist_auto as cl ON cl.codjatoauto = c.codjatoauto " +
                         " WHERE ca.idassegnazione > 0 AND ca.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
                collParams.Add(param1);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(sql, collParams, CommandType.Text).Data;
        }


        public List<IContratti> SelectLibrettoAutoServizio(string targa, Guid UserId, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " ca.targa ";
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

            if (!string.IsNullOrEmpty(targa)) condWhere += " AND ca.targa = @targa ";
            if (UserId != Guid.Empty) condWhere += " AND ca.UserId = @UserId ";

            List<IContratti> retVal = new List<IContratti>();
            string sql = " SELECT DISTINCT ca.targa, cl.modello FROM EF_contratti_autoservizio as ca " +
                         " LEFT JOIN EF_contratti as c ON ca.targa = c.targa " +
                         " LEFT JOIN EF_carlist_auto as cl ON cl.codjatoauto = c.codjatoauto " +
                         " WHERE ca.idassegnazione > 0 AND ca.autorizzatoadmin = 1 AND ca.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(targa))
            {
                IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
                param9.Value = targa;
                collParams.Add(param9);
            }
            if (UserId != Guid.Empty)
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@UserId", DbType.Guid);
                param1.Value = UserId;
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
                    IContratti item = new Contratti
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public IContratti DetailLibrettoAutoServizioXTarga(string targa)
        {
            IContratti retVal = null;
            string sql = " SELECT cl.marca, cl.modello FROM EF_contratti_autoservizio as ca " +
                         " LEFT JOIN EF_contratti as c ON ca.targa = c.targa " +
                         " LEFT JOIN EF_carlist_auto as cl ON cl.codjatoauto = c.codjatoauto " +
                         " WHERE ca.targa = @targa ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param0.Value = targa;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Contratti
                {
                    Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                    Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectDetailLibrettoAutoServizio(string targa)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT a.*, u.nome, u.cognome, u.matricola FROM EF_contratti_autoservizio as a " +
                         " LEFT JOIN EF_users as u ON a.UserId = u.UserId WHERE a.autorizzatoadmin = 1 AND a.targa = @targa ORDER BY a.assegnatoal DESC ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param9.Value = targa;
            collParams.Add(param9);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty) + " " + DataHelper.IfDBNull<string>(row["nome"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty) + ")",
                        Scopoviaggio = DataHelper.IfDBNull<string>(row["scopoviaggio"], _stringEmpty),
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                        Kminiziali = DataHelper.IfDBNull<decimal>(row["kminiziali"], 0),
                        Kmrestituzione = DataHelper.IfDBNull<decimal>(row["kmrestituzione"], 0),
                        Spese = DataHelper.IfDBNull<string>(row["spese"], _stringEmpty),
                        Importospese = DataHelper.IfDBNull<decimal>(row["importospese"], 0),
                        Noterestituzione = DataHelper.IfDBNull<string>(row["noterestituzione"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> SelectAllScopoViaggio(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = "SELECT descrizione FROM EF_contratti_autoservizio_scopo WHERE uidtenant = @Uidtenant ";

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
                    IContratti item = new Contratti
                    {
                        Descrizione = DataHelper.IfDBNull<string>(row["descrizione"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<IContratti> SelectAutoServizioDispo(Guid Uidtenant)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT DISTINCT c.Targa, cl.modello FROM EF_contratti as c " +
                         " LEFT JOIN EF_carlist_auto as cl ON c.codjatoauto = cl.codjatoauto and c.uidtenant = cl.uidtenant " +
                         " WHERE c.codtipoutilizzo = 'SER' AND c.uidtenant = @Uidtenant ORDER BY c.Targa ";

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
                    IContratti item = new Contratti
                    {
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<IContratti> DispoAutoServizioXDay(string targa, DateTime datains)
        {
            List<IContratti> retVal = new List<IContratti>();

            string sql = " SELECT assegnatodal, assegnatoal, autorizzatoadmin FROM EF_contratti_autoservizio " +
                         " WHERE autorizzatoadmin = 1 AND targa = @targa AND CAST(assegnatodal AS DATE) = @datains ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@targa", DbType.String);
            param0.Value = targa;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@datains", DbType.DateTime);
            param1.Value = datains;
            collParams.Add(param1);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    IContratti item = new Contratti
                    {
                        Assegnatodal = DataHelper.IfDBNull<DateTime>(row["assegnatodal"], DateTime.MinValue),
                        Assegnatoal = DataHelper.IfDBNull<DateTime>(row["assegnatoal"], DateTime.MinValue),
                        Autorizzatoadmin = DataHelper.IfDBNull<int>(row["autorizzatoadmin"], 0)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int UpdateAutorizzaAutoServizio(int idassegnazione, Guid Uidtenant)
        {
            int retVal = 0;

            List<IDataParameter> collParams = new List<IDataParameter>();

            string sql = " UPDATE EF_contratti_autoservizio SET [autorizzatoadmin] = 1 WHERE idassegnazione = @idassegnazione AND uidtenant = @Uidtenant ";

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@idassegnazione", DbType.Int32);
            param20.Value = idassegnazione;
            collParams.Add(param20);

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
    }
}