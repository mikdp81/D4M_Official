// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CCarProvider.cs" company="">
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

    [SectionName("cars.provider/CarsSection")]
    public class CarsProvider : DFleetDataProvider, ICarsProvider
    {

        //aggiorna carlist
        public int UpdateCarListAuto(ICars value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_carlist_auto SET [codcarlist] = @codcarlist, [codfornitore] = @codfornitore, [codjatoauto] = @codjatoauto, [marca] = @marca, [modello] = @modello, " +
                         " [cilindrata] = @cilindrata, [alimentazione] = @alimentazione, [alimentazionesecondaria] = @alimentazionesecondaria, [consumo] = @consumo, " + 
                         " [consumourbano] = @consumourbano, [consumoextraurbano] = @consumoextraurbano, [emissioni] = @emissioni, [costoautobase] = @costoautobase, " +
                         " [costoaci] = @costoaci, [canoneleasing] = @canoneleasing, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod, [fringebenefitbase] = @fringebenefitbase, " +
                         " [fotoauto] = @fotoauto, [cambio] = @cambio, [giorniconsegna] = @giorniconsegna, [mesicontratto] = @mesicontratto, [serbatoio] = @serbatoio, [visibile] = @visibile, " +
                         " [kwcv] = @kwcv WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param0.Value = value.Codcarlist;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param1.Value = value.Codfornitore;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param2.Value = value.Codjatoauto;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
            param3.Value = value.Marca;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@cilindrata", DbType.String);
            param4.Value = value.Cilindrata;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@alimentazione", DbType.String);
            param5.Value = value.Alimentazione;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@alimentazionesecondaria", DbType.String);
            param6.Value = value.Alimentazionesecondaria;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@consumo", DbType.Decimal);
            param7.Value = value.Consumo;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@consumourbano", DbType.Decimal);
            param8.Value = value.Consumourbano;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@consumoextraurbano", DbType.Decimal);
            param9.Value = value.Consumoextraurbano;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@emissioni", DbType.Decimal);
            param10.Value = value.Emissioni;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@costoautobase", DbType.Decimal);
            param11.Value = value.Costoautobase;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@costoaci", DbType.Decimal);
            param12.Value = value.Costoaci;
            collParams.Add(param12);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@canoneleasing", DbType.Decimal);
            param16.Value = value.Canoneleasing;
            collParams.Add(param16);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
            param18.Value = value.Modello;
            collParams.Add(param18);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param13.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param14.Value = DateTime.Now;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param15.Value = value.Uid;
            collParams.Add(param15);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@fringebenefitbase", DbType.Decimal);
            param17.Value = value.Fringebenefitbase;
            collParams.Add(param17);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@fotoauto", DbType.String);
            param19.Value = value.Fotoauto;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@cambio", DbType.String);
            param20.Value = value.Cambio;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@giorniconsegna", DbType.Int32);
            param21.Value = value.Giorniconsegna;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@mesicontratto", DbType.Int32);
            param22.Value = value.Mesicontratto;
            collParams.Add(param22);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@serbatoio", DbType.Decimal);
            param24.Value = value.Serbatoio;
            collParams.Add(param24);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@visibile", DbType.String);
            param25.Value = value.Visibile;
            collParams.Add(param25);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@kwcv", DbType.String);
            param26.Value = value.Kwcv;
            collParams.Add(param26);

            IDbDataParameter param32 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param32.Value = value.Uidtenant;
            collParams.Add(param32);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);
            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //cancella carlist

        public int DeleteCarListAuto(ICars value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_carlist_auto WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

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

        //inserimento nuova carlist

        public int InsertCarListAuto(ICars value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_carlist_auto ([codcarlist],[codfornitore],[codjatoauto],[marca],[modello],[cilindrata],[alimentazione], " +
                         " [alimentazionesecondaria],[consumo],[cambio],[consumourbano],[consumoextraurbano],[emissioni],[costoautobase],[costoaci], " +
                         " [canoneleasing],[datauserins],[UserIDIns],[datausermod],[UserIdMod],[fringebenefitbase],[fotoauto],[giorniconsegna], " +
                         " [mesicontratto],[serbatoio],[visibile],[kwcv],[uidtenant] ) " +
                         " VALUES (@codcarlist,@codfornitore,@codjatoauto,@marca,@modello,@cilindrata,@alimentazione,@alimentazionesecondaria,@consumo,@cambio,@consumourbano,@consumoextraurbano, " +
                         " @emissioni,@costoautobase,@costoaci,@canoneleasing,@datauserins,@UserIDIns,@datausermod,@UserIdMod,@fringebenefitbase,@fotoauto,@giorniconsegna, " +
                         " @mesicontratto,@serbatoio,@visibile,@kwcv,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param0.Value = value.Codcarlist;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param1.Value = value.Codfornitore;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param2.Value = value.Codjatoauto;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@marca", DbType.String);
            param3.Value = value.Marca;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@cilindrata", DbType.String);
            param4.Value = value.Cilindrata;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@alimentazione", DbType.String);
            param5.Value = value.Alimentazione;
            collParams.Add(param5);

            IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@alimentazionesecondaria", DbType.String);
            param6.Value = value.Alimentazionesecondaria;
            collParams.Add(param6);

            IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@consumo", DbType.Decimal);
            param7.Value = value.Consumo;
            collParams.Add(param7);

            IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@consumourbano", DbType.Decimal);
            param8.Value = value.Consumourbano;
            collParams.Add(param8);

            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@consumoextraurbano", DbType.Decimal);
            param9.Value = value.Consumoextraurbano;
            collParams.Add(param9);

            IDbDataParameter param10 = _dataHelper.ProviderConn.CreateDataParameter("@emissioni", DbType.Decimal);
            param10.Value = value.Emissioni;
            collParams.Add(param10);

            IDbDataParameter param11 = _dataHelper.ProviderConn.CreateDataParameter("@costoautobase", DbType.Decimal);
            param11.Value = value.Costoautobase;
            collParams.Add(param11);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@costoaci", DbType.Decimal);
            param12.Value = value.Costoaci;
            collParams.Add(param12);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@canoneleasing", DbType.Decimal);
            param17.Value = value.Canoneleasing;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
            param18.Value = value.Modello;
            collParams.Add(param18);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param13.Value = DateTime.Now;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param14.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param15.Value = DateTime.Now;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param16.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param16);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@fringebenefitbase", DbType.Decimal);
            param19.Value = value.Fringebenefitbase;
            collParams.Add(param19);

            IDbDataParameter param20 = _dataHelper.ProviderConn.CreateDataParameter("@fotoauto", DbType.String);
            param20.Value = value.Fotoauto;
            collParams.Add(param20);

            IDbDataParameter param21 = _dataHelper.ProviderConn.CreateDataParameter("@cambio", DbType.String);
            param21.Value = value.Cambio;
            collParams.Add(param21);

            IDbDataParameter param22 = _dataHelper.ProviderConn.CreateDataParameter("@giorniconsegna", DbType.Int32);
            param22.Value = value.Giorniconsegna;
            collParams.Add(param22);

            IDbDataParameter param23 = _dataHelper.ProviderConn.CreateDataParameter("@mesicontratto", DbType.Int32);
            param23.Value = value.Mesicontratto;
            collParams.Add(param23);

            IDbDataParameter param24 = _dataHelper.ProviderConn.CreateDataParameter("@serbatoio", DbType.Decimal);
            param24.Value = value.Serbatoio;
            collParams.Add(param24);

            IDbDataParameter param25 = _dataHelper.ProviderConn.CreateDataParameter("@visibile", DbType.String);
            param25.Value = value.Visibile;
            collParams.Add(param25);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@kwcv", DbType.String);
            param26.Value = value.Kwcv;
            collParams.Add(param26);

            IDbDataParameter param27 = _dataHelper.ProviderConn.CreateDataParameter("@uidtenant", DbType.Guid);
            param27.Value = value.Uidtenant;
            collParams.Add(param27);

            IReturnValue<int> result = _dataHelper.RunCommand(sql, collParams, CommandType.Text);

            if (!result.Error)
            {
                retVal = 1;
            }

            return retVal;
        }


        //dettagli car list
        public ICars DetailCarListAutoId(Guid Uid)
        {
            ICars retVal = null;
            string sql = "SELECT * FROM EF_carlist_auto WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cars
                {
                    Idcarlistauto = DataHelper.IfDBNull<int>(row["idcarlistauto"], 0),
                    Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                    Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                    Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                    Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                    Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                    Cilindrata = DataHelper.IfDBNull<string>(row["cilindrata"], _stringEmpty),
                    Alimentazione = DataHelper.IfDBNull<string>(row["alimentazione"], _stringEmpty),
                    Alimentazionesecondaria = DataHelper.IfDBNull<string>(row["alimentazionesecondaria"], _stringEmpty),
                    Consumo = DataHelper.IfDBNull<decimal>(row["consumo"], 0),
                    Consumourbano = DataHelper.IfDBNull<decimal>(row["consumourbano"], 0),
                    Consumoextraurbano = DataHelper.IfDBNull<decimal>(row["consumoextraurbano"], 0),
                    Emissioni = DataHelper.IfDBNull<decimal>(row["emissioni"], 0),
                    Costoautobase = DataHelper.IfDBNull<decimal>(row["costoautobase"], 0),
                    Costoaci = DataHelper.IfDBNull<decimal>(row["costoaci"], 0),
                    Canoneleasing = DataHelper.IfDBNull<decimal>(row["canoneleasing"], 0),
                    Fringebenefitbase = DataHelper.IfDBNull<decimal>(row["fringebenefitbase"], 0),
                    Fotoauto = DataHelper.IfDBNull<string>(row["fotoauto"], _stringEmpty),
                    Cambio = DataHelper.IfDBNull<string>(row["cambio"], _stringEmpty),
                    Giorniconsegna = DataHelper.IfDBNull<int>(row["giorniconsegna"], 0),
                    Mesicontratto = DataHelper.IfDBNull<int>(row["mesicontratto"], 0),
                    Serbatoio = DataHelper.IfDBNull<decimal>(row["serbatoio"], 0),
                    Visibile = DataHelper.IfDBNull<string>(row["visibile"], _stringEmpty),
                    Kwcv = DataHelper.IfDBNull<string>(row["kwcv"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }
        //dettagli car list
        public ICars DetailCarListAutoId2(string codjatoauto, string codcarlist, string codfornitore)
        {
            ICars retVal = null;
            string sql = "SELECT * FROM EF_carlist_auto WHERE codjatoauto = @codjatoauto AND codcarlist = @codcarlist AND codfornitore = @codfornitore ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = codjatoauto;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param1.Value = codcarlist;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
            param2.Value = codfornitore;
            collParams.Add(param2);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cars
                {
                    Idcarlistauto = DataHelper.IfDBNull<int>(row["idcarlistauto"], 0),
                    Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                    Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                    Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                    Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                    Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                    Cilindrata = DataHelper.IfDBNull<string>(row["cilindrata"], _stringEmpty),
                    Alimentazione = DataHelper.IfDBNull<string>(row["alimentazione"], _stringEmpty),
                    Alimentazionesecondaria = DataHelper.IfDBNull<string>(row["alimentazionesecondaria"], _stringEmpty),
                    Consumo = DataHelper.IfDBNull<decimal>(row["consumo"], 0),
                    Consumourbano = DataHelper.IfDBNull<decimal>(row["consumourbano"], 0),
                    Consumoextraurbano = DataHelper.IfDBNull<decimal>(row["consumoextraurbano"], 0),
                    Emissioni = DataHelper.IfDBNull<decimal>(row["emissioni"], 0),
                    Costoautobase = DataHelper.IfDBNull<decimal>(row["costoautobase"], 0),
                    Costoaci = DataHelper.IfDBNull<decimal>(row["costoaci"], 0),
                    Canoneleasing = DataHelper.IfDBNull<decimal>(row["canoneleasing"], 0),
                    Fringebenefitbase = DataHelper.IfDBNull<decimal>(row["fringebenefitbase"], 0),
                    Fotoauto = DataHelper.IfDBNull<string>(row["fotoauto"], _stringEmpty),
                    Cambio = DataHelper.IfDBNull<string>(row["cambio"], _stringEmpty),
                    Giorniconsegna = DataHelper.IfDBNull<int>(row["giorniconsegna"], 0),
                    Mesicontratto = DataHelper.IfDBNull<int>(row["mesicontratto"], 0),
                    Serbatoio = DataHelper.IfDBNull<decimal>(row["serbatoio"], 0),
                    Visibile = DataHelper.IfDBNull<string>(row["visibile"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }

        //conta carlist - FILTRO: keysearch
        public int SelectCountCarListAuto(string codcarlist, string codfornitore, string marca, string modello, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " and codcarlist = @codcarlist ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " and codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " and (marca like '%' + @marca + '%') ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " and (modello like '%' + @modello + '%') ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_carlist_auto WHERE idcarlistauto>0 AND uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param0.Value = codcarlist;
                collParams.Add(param0);
            }

            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param1.Value = codfornitore;
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
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param4.Value = modello;
                collParams.Add(param4);
            }

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);            

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista carlist
        // FILTRO: keysearch
        public List<ICars> SelectCarListAuto(string codcarlist, string codfornitore, string marca, string modello, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " codcarlist ";
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

            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " and codcarlist = @codcarlist ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " and codfornitore = @codfornitore ";
            if (!string.IsNullOrEmpty(marca)) condWhere += " and (marca like '%' + @marca + '%') ";
            if (!string.IsNullOrEmpty(modello)) condWhere += " and (modello like '%' + @modello + '%') ";

            List<ICars> retVal = new List<ICars>();
            string sql = "SELECT * FROM EF_carlist_auto WHERE idcarlistauto>0 AND uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param0.Value = codcarlist;
                collParams.Add(param0);
            }

            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param1.Value = codfornitore;
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
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@modello", DbType.String);
                param4.Value = modello;
                collParams.Add(param4);
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
                    ICars item = new Cars
                    {
                        Idcarlistauto = DataHelper.IfDBNull<int>(row["idcarlistauto"], 0),
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Cilindrata = DataHelper.IfDBNull<string>(row["cilindrata"], _stringEmpty),
                        Alimentazione = DataHelper.IfDBNull<string>(row["alimentazione"], _stringEmpty),
                        Alimentazionesecondaria = DataHelper.IfDBNull<string>(row["alimentazionesecondaria"], _stringEmpty),
                        Consumo = DataHelper.IfDBNull<decimal>(row["consumo"], 0),
                        Consumourbano = DataHelper.IfDBNull<decimal>(row["consumourbano"], 0),
                        Consumoextraurbano = DataHelper.IfDBNull<decimal>(row["consumoextraurbano"], 0),
                        Emissioni = DataHelper.IfDBNull<decimal>(row["emissioni"], 0),
                        Costoautobase = DataHelper.IfDBNull<decimal>(row["costoautobase"], 0),
                        Costoaci = DataHelper.IfDBNull<decimal>(row["costoaci"], 0),
                        Canoneleasing = DataHelper.IfDBNull<decimal>(row["canoneleasing"], 0),
                        Fotoauto = DataHelper.IfDBNull<string>(row["fotoauto"], _stringEmpty),
                        Cambio = DataHelper.IfDBNull<string>(row["cambio"], _stringEmpty),
                        Visibile = DataHelper.IfDBNull<string>(row["visibile"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<ICars> SelectAllCarList(Guid Uidtenant)
        {
            List<ICars> retVal = new List<ICars>();

            string sql = "SELECT codcarlist, carlist FROM EF_carlist WHERE uidtenant = @Uidtenant ORDER BY codcarlist ";

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
                    ICars item = new Cars
                    {
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Carlist = DataHelper.IfDBNull<string>(row["carlist"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        //aggiorna carlist
        public int UpdateCarList(ICars value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_carlist SET [codcarlist] = @codcarlist, [carlist] = @carlist, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param0.Value = value.Codcarlist;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@carlist", DbType.String);
            param1.Value = value.Carlist;
            collParams.Add(param1);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param13.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param14.Value = DateTime.Now;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param15.Value = value.Uid;
            collParams.Add(param15);

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


        //cancella carlist

        public int DeleteCarList(ICars value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_carlist WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

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

        //inserimento nuova carlist

        public int InsertCarList(ICars value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_carlist ([codcarlist],[carlist],[datauserins],[UserIDIns],[datausermod],[UserIdMod],[uidtenant] ) " +
                         " VALUES (@codcarlist,@carlist,@datauserins,@UserIDIns,@datausermod,@UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param0.Value = value.Codcarlist;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@carlist", DbType.String);
            param1.Value = value.Carlist;
            collParams.Add(param1);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param13.Value = DateTime.Now;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param14.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param15.Value = DateTime.Now;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param16.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param16);

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


        //dettagli car list

        public ICars DetailCarListId(Guid Uid)
        {
            ICars retVal = null;
            string sql = "SELECT * FROM EF_carlist WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cars
                {
                    Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                    Carlist = DataHelper.IfDBNull<string>(row["carlist"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }


        //conta carlist - FILTRO: keysearch
        public int SelectCountCarList(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codcarlist like '%' + @keysearch + '%' OR carlist like '%' + @keysearch + '%') ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_carlist WHERE codcarlist<>'' AND uidtenant = @Uidtenant " + condWhere;

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

        // lista carlist
        // FILTRO: keysearch
        public List<ICars> SelectCarList(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " codcarlist ";
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (codcarlist like '%' + @keysearch + '%' OR carlist like '%' + @keysearch + '%') ";

            List<ICars> retVal = new List<ICars>();
            string sql = "SELECT * FROM EF_carlist WHERE codcarlist<>'' AND uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

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
                    ICars item = new Cars
                    {
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Carlist = DataHelper.IfDBNull<string>(row["carlist"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }




        //aggiorna carpolicy
        public int UpdateCarPolicy(ICars value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_carpolicy SET [codcarpolicy] = @codcarpolicy, [codcarlist] = @codcarlist, [codfuelcard] = @codfuelcard, [excodcarpolicy] = @excodcarpolicy, " +
                         " [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param0.Value = value.Codcarlist;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param1.Value = value.Codcarpolicy;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codfuelcard", DbType.String);
            param2.Value = value.Codfuelcard;
            collParams.Add(param2);
            
            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param13.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param14.Value = DateTime.Now;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param15.Value = value.Uid;
            collParams.Add(param15);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@excodcarpolicy", DbType.String);
            param12.Value = value.Excodcarpolicy;
            collParams.Add(param12);

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


        //cancella carpolicy 
        public int DeleteCarPolicy(ICars value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_carpolicy WHERE codcarpolicy = @codcarpolicy AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            paramID.Value = value.Codcarpolicy;
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

        //inserimento nuova carpolicy
        public int InsertCarPolicy(ICars value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_carpolicy ([codcarlist],[codcarpolicy],[codfuelcard],[excodcarpolicy],[datauserins],[UserIDIns],[datausermod],[UserIdMod],[uidtenant] ) " +
                         " VALUES (@codcarlist,@codcarpolicy,@codfuelcard,@excodcarpolicy,@datauserins,@UserIDIns,@datausermod,@UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param0.Value = value.Codcarlist;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param1.Value = value.Codcarpolicy;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codfuelcard", DbType.String);
            param2.Value = value.Codfuelcard;
            collParams.Add(param2);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param13.Value = DateTime.Now;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param14.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param15.Value = DateTime.Now;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param16.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param16);

            IDbDataParameter param12 = _dataHelper.ProviderConn.CreateDataParameter("@excodcarpolicy", DbType.String);
            param12.Value = value.Excodcarpolicy;
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


        //dettagli carpolicy
        public ICars DetailCarPolicyId(Guid Uid)
        {
            ICars retVal = null;
            string sql = " SELECT s.codsocieta, s.codpersontype, s.codgrade, s.codsubgrade, c.codcarpolicy, c.codcarlist, c.codfuelcard, c.uid, s.uid as uidsocieta, " +
                         " s.validodal, s.validoal, c.excodcarpolicy, s.checkoptionalpag " +
                         " FROM EF_carpolicy_assegna_societa as s INNER JOIN EF_carpolicy as c ON s.codcarpolicy = c.codcarpolicy WHERE s.Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cars
                {
                    Codsocieta = DataHelper.IfDBNull<string>(row["codsocieta"], _stringEmpty),
                    Codpersontype = DataHelper.IfDBNull<string>(row["codpersontype"], _stringEmpty),
                    Codgrade = DataHelper.IfDBNull<string>(row["codgrade"], _stringEmpty),
                    Codsubgrade = DataHelper.IfDBNull<string>(row["codsubgrade"], _stringEmpty),
                    Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                    Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                    Codfuelcard = DataHelper.IfDBNull<string>(row["codfuelcard"], _stringEmpty),
                    Validodal = DataHelper.IfDBNull<DateTime>(row["validodal"], DateTime.Now),
                    Validoal = DataHelper.IfDBNull<DateTime>(row["validoal"], DateTime.Now),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty),
                    Excodcarpolicy = DataHelper.IfDBNull<string>(row["excodcarpolicy"], _stringEmpty),
                    Uidsocieta = DataHelper.IfDBNull<Guid>(row["Uidsocieta"], Guid.Empty),
                    Checkoptionalpag = DataHelper.IfDBNull<int>(row["checkoptionalpag"], 0),
                };

                data.Dispose();
            }
            return retVal;
        }


        //conta carpolicy - FILTRO: keysearch, codsocieta, codgrade
        public int SelectCountCarPolicy(string keysearch, string codsocieta, string codgrade, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND s.codcarpolicy like '%' + @keysearch + '%' ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND s.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND s.codgrade = @codgrade ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_carpolicy_assegna_societa as s " +
                         " INNER JOIN EF_carpolicy as c ON s.codcarpolicy = c.codcarpolicy AND s.uidtenant = c.uidtenant " +
                         " WHERE s.idcarpolicysocieta > 0 AND s.uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
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

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);            

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista carlist
        // FILTRO: keysearch, codsocieta, codgrade
        public List<ICars> SelectCarPolicy(string keysearch, string codsocieta, string codgrade, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " s.codcarpolicy";
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND s.codcarpolicy like '%' + @keysearch + '%' ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND s.codsocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND s.codgrade = @codgrade ";

            List<ICars> retVal = new List<ICars>();
            string sql = " SELECT sc.societa, g.grade, c.codcarpolicy, c.codcarlist,s.validodal,s.validoal, s.Uid FROM EF_carpolicy_assegna_societa as s " +
                         " INNER JOIN EF_carpolicy as c ON s.codcarpolicy = c.codcarpolicy AND s.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_societa as sc ON sc.codsocieta = s.codsocieta AND s.uidtenant = sc.uidtenant " +
                         " LEFT JOIN EF_grade as g ON g.codgrade = s.codgrade AND s.uidtenant = g.uidtenant " +
                         " WHERE s.idcarpolicysocieta > 0 AND s.uidtenant = @Uidtenant " + condWhere + 
                         " ORDER BY " + orderby + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(keysearch))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@keysearch", DbType.String);
                param0.Value = keysearch;
                collParams.Add(param0);
            }
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

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);            

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICars item = new Cars
                    {
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Societa = DataHelper.IfDBNull<string>(row["societa"], _stringEmpty),
                        Validodal = DataHelper.IfDBNull<DateTime>(row["validodal"], DateTime.Now),
                        Validoal = DataHelper.IfDBNull<DateTime>(row["validoal"], DateTime.Now),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        //aggiorna carpolicy societa
        public int UpdateCarPolicySocieta(ICars value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_carpolicy_assegna_societa SET [codsocieta] = @codsocieta, [codpersontype] = @codpersontype, [codgrade] = @codgrade, [codsubgrade] = @codsubgrade, " +
                         " [codcarpolicy] = @codcarpolicy, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod, [validodal] = @validodal, [validoal] = @validoal, " +
                         " [checkoptionalpag] = @checkoptionalpag WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codpersontype", DbType.String);
            param1.Value = value.Codpersontype;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
            param2.Value = value.Codgrade;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsubgrade", DbType.String);
            param3.Value = value.Codsubgrade;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param4.Value = value.Codcarpolicy;
            collParams.Add(param4);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param13.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param14.Value = DateTime.Now;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param15.Value = value.Uid;
            collParams.Add(param15);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@validodal", DbType.Date);
            param17.Value = value.Validodal;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@validoal", DbType.Date);
            param18.Value = value.Validoal;
            collParams.Add(param18);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@checkoptionalpag", DbType.Int32);
            param19.Value = value.Checkoptionalpag;
            collParams.Add(param19);

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


        //cancella carpolicy societa
        public int DeleteCarPolicySocieta(ICars value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_carpolicy_assegna_societa WHERE codcarpolicy = @codcarpolicy AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            paramID.Value = value.Codcarpolicy;
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

        //inserimento nuova carpolicy societa
        public int InsertCarPolicySocieta(ICars value)
        {
            int retVal = 0;

            string sql = " INSERT INTO EF_carpolicy_assegna_societa ([codsocieta],[codpersontype],[codgrade],[codsubgrade],[codcarpolicy],[validodal],[validoal], " +
                         " [datauserins],[UserIDIns],[datausermod],[UserIdMod],[checkoptionalpag],[uidtenant] ) " +
                         " VALUES (@codsocieta,@codpersontype,@codgrade,@codsubgrade,@codcarpolicy,@validodal,@validoal,@datauserins,@UserIDIns,@datausermod,@UserIdMod,@checkoptionalpag,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
            param0.Value = value.Codsocieta;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codpersontype", DbType.String);
            param1.Value = value.Codpersontype;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
            param2.Value = value.Codgrade;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codsubgrade", DbType.String);
            param3.Value = value.Codsubgrade;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codcarpolicy", DbType.String);
            param4.Value = value.Codcarpolicy;
            collParams.Add(param4);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param13.Value = DateTime.Now;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param14.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param15.Value = DateTime.Now;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param16.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param16);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@validodal", DbType.Date);
            param17.Value = value.Validodal;
            collParams.Add(param17);

            IDbDataParameter param18 = _dataHelper.ProviderConn.CreateDataParameter("@validoal", DbType.Date);
            param18.Value = value.Validoal;
            collParams.Add(param18);

            IDbDataParameter param19 = _dataHelper.ProviderConn.CreateDataParameter("@checkoptionalpag", DbType.Int32);
            param19.Value = value.Checkoptionalpag;
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



        //aggiorna categoria optional
        public int UpdateCategorieOptional(ICars value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_carlist_optional_categorie SET [codcategoriaoptional] = @codcategoriaoptional, [categoriaoptional] = @categoriaoptional, [livello] = @livello," +
                         " [ordine] = @ordine, [codpadrecategoria] = @codpadrecategoria, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcategoriaoptional", DbType.String);
            param0.Value = value.Codcategoriaoptional;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@categoriaoptional", DbType.String);
            param1.Value = value.Categoriaoptional;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@livello", DbType.Int32);
            param2.Value = value.Livello;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@ordine", DbType.Int32);
            param3.Value = value.Ordine;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codpadrecategoria", DbType.String);
            param4.Value = value.Codpadrecategoria;
            collParams.Add(param4);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param13.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param14.Value = DateTime.Now;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param15.Value = value.Uid;
            collParams.Add(param15);

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


        //cancella categoria optional
        public int DeleteCategorieOptional(ICars value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_carlist_optional_categorie WHERE Uid = @Uid AND uidtenant = @Uidtenant";

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

        //inserimento categoria optional

        public int InsertCategorieOptional(ICars value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_carlist_optional_categorie ([codcategoriaoptional],[categoriaoptional],[livello],[ordine],[codpadrecategoria], " +
                         " [datauserins],[UserIDIns],[datausermod],[UserIdMod],[uidtenant] ) " +
                         " VALUES (@codcategoriaoptional,@categoriaoptional,@livello,@ordine,@codpadrecategoria, " +
                         " @datauserins,@UserIDIns,@datausermod,@UserIdMod,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcategoriaoptional", DbType.String);
            param0.Value = value.Codcategoriaoptional;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@categoriaoptional", DbType.String);
            param1.Value = value.Categoriaoptional;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@livello", DbType.Int32);
            param2.Value = value.Livello;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@ordine", DbType.Int32);
            param3.Value = value.Ordine;
            collParams.Add(param3);

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codpadrecategoria", DbType.String);
            param4.Value = value.Codpadrecategoria;
            collParams.Add(param4);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param13.Value = DateTime.Now;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param14.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param15.Value = DateTime.Now;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param16.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param16);

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


        //dettagli categoria optional
        public ICars DetailCategoriaOptionalId(Guid Uid)
        {
            ICars retVal = null;
            string sql = "SELECT * FROM EF_carlist_optional_categorie WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cars
                {
                    Codcategoriaoptional = DataHelper.IfDBNull<string>(row["codcategoriaoptional"], _stringEmpty),
                    Categoriaoptional = DataHelper.IfDBNull<string>(row["categoriaoptional"], _stringEmpty),
                    Livello = DataHelper.IfDBNull<int>(row["livello"], 0),
                    Ordine = DataHelper.IfDBNull<int>(row["ordine"], 0),
                    Codpadrecategoria = DataHelper.IfDBNull<string>(row["codpadrecategoria"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }


        //conta categorie optional - FILTRO: keysearch
        public int SelectCountCategoriaOptional(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (categoriaoptional like '%' + @categoriaoptional + '%') ";

            string SQL = "SELECT COUNT(*) as tot FROM EF_carlist_optional_categorie WHERE uidtenant = @Uidtenant " + condWhere;

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

        // lista categorie optional
        // FILTRO: keysearch
        public List<ICars> SelectCategoriaOptional(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " categoriaoptional ";
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (categoriaoptional like '%' + @categoriaoptional + '%') ";

            List<ICars> retVal = new List<ICars>();
            string sql = "SELECT * FROM EF_carlist_optional_categorie WHERE uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

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
                    ICars item = new Cars
                    {
                        Codcategoriaoptional = DataHelper.IfDBNull<string>(row["codcategoriaoptional"], _stringEmpty),
                        Categoriaoptional = DataHelper.IfDBNull<string>(row["categoriaoptional"], _stringEmpty),
                        Livello = DataHelper.IfDBNull<int>(row["livello"], 0),
                        Ordine = DataHelper.IfDBNull<int>(row["ordine"], 0),
                        Codpadrecategoria = DataHelper.IfDBNull<string>(row["codpadrecategoria"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<ICars> SelectAllCategoriaOptional()
        {
            List<ICars> retVal = new List<ICars>();

            string sql = "SELECT codcategoriaoptional, categoriaoptional FROM EF_carlist_optional_categorie ORDER BY categoriaoptional ";

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICars item = new Cars
                    {
                        Codcategoriaoptional = DataHelper.IfDBNull<string>(row["codcategoriaoptional"], _stringEmpty),
                        Categoriaoptional = DataHelper.IfDBNull<string>(row["categoriaoptional"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<ICars> SelectAllCategoriePrimoLivello2(Guid Uidtenant)
        {
            List<ICars> retVal = new List<ICars>();

            string sql = "SELECT codcategoriaoptional, categoriaoptional FROM EF_carlist_optional_categorie WHERE livello IN (0,1) AND uidtenant = @Uidtenant ORDER BY categoriaoptional ";

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
                    ICars item = new Cars
                    {
                        Codcategoriaoptional = DataHelper.IfDBNull<string>(row["codcategoriaoptional"], _stringEmpty),
                        Categoriaoptional = DataHelper.IfDBNull<string>(row["categoriaoptional"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<ICars> SelectAllCategoriePrimoLivello(Guid Uidtenant)
        {
            List<ICars> retVal = new List<ICars>();

            string sql = "SELECT codcategoriaoptional, categoriaoptional FROM EF_carlist_optional_categorie WHERE livello=1 AND uidtenant = @Uidtenant  ORDER BY categoriaoptional ";

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
                    ICars item = new Cars
                    {
                        Codcategoriaoptional = DataHelper.IfDBNull<string>(row["codcategoriaoptional"], _stringEmpty),
                        Categoriaoptional = DataHelper.IfDBNull<string>(row["categoriaoptional"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        //aggiorna optional
        public int UpdateOptional(ICars value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_carlist_optional SET [codoptional] = @codoptional, [codcategoriaoptional] = @codcategoriaoptional, [codsottocategoriaoptional] = @codsottocategoriaoptional, " +
                         " [optional] = @optional, [UserIdMod] = @UserIdMod, [datausermod] = @datausermod, [note] = @note WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codoptional", DbType.String);
            param0.Value = value.Codoptional;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codcategoriaoptional", DbType.String);
            param1.Value = value.Codcategoriaoptional;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsottocategoriaoptional", DbType.String);
            param2.Value = value.Codsottocategoriaoptional;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@optional", DbType.String);
            param3.Value = value.Optional;
            collParams.Add(param3);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param13.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param14.Value = DateTime.Now;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param15.Value = value.Uid;
            collParams.Add(param15);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@note", DbType.String);
            param17.Value = value.Note;
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


        //cancella optional
        public int DeleteOptional(ICars value)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_carlist_optional WHERE Uid = @Uid AND uidtenant = @Uidtenant ";

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

        //inserimento categoria optional
        public int InsertOptional(ICars value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_carlist_optional ([codoptional],[codcategoriaoptional],[codsottocategoriaoptional],[optional], " +
                         " [datauserins],[UserIDIns],[datausermod],[UserIdMod],[note],[uidtenant] ) " +
                         " VALUES (@codoptional,@codcategoriaoptional,@codsottocategoriaoptional,@optional, " +
                         " @datauserins,@UserIDIns,@datausermod,@UserIdMod,@note,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codoptional", DbType.String);
            param0.Value = value.Codoptional;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codcategoriaoptional", DbType.String);
            param1.Value = value.Codcategoriaoptional;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsottocategoriaoptional", DbType.String);
            param2.Value = value.Codsottocategoriaoptional;
            collParams.Add(param2);

            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@optional", DbType.String);
            param3.Value = value.Optional;
            collParams.Add(param3);

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param13.Value = DateTime.Now;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param14.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param15.Value = DateTime.Now;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param16.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param16);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@note", DbType.String);
            param17.Value = value.Note;
            collParams.Add(param17);

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


        //dettagli optional
        public ICars DetailOptionalId(Guid Uid)
        {
            ICars retVal = null;
            string sql = "SELECT * FROM EF_carlist_optional WHERE Uid = @Uid";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param0.Value = Uid;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cars
                {
                    Codoptional = DataHelper.IfDBNull<string>(row["codoptional"], _stringEmpty),
                    Codcategoriaoptional = DataHelper.IfDBNull<string>(row["codcategoriaoptional"], _stringEmpty),
                    Codsottocategoriaoptional = DataHelper.IfDBNull<string>(row["codsottocategoriaoptional"], _stringEmpty),
                    Optional = DataHelper.IfDBNull<string>(row["optional"], _stringEmpty),
                    Note = DataHelper.IfDBNull<string>(row["note"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }
        public ICars DetailOptionalXCod(string codoptional)
        {
            ICars retVal = null;
            string sql = "SELECT * FROM EF_carlist_optional WHERE codoptional = @codoptional";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codoptional", DbType.String);
            param0.Value = codoptional;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cars
                {
                    Codoptional = DataHelper.IfDBNull<string>(row["codoptional"], _stringEmpty),
                    Codcategoriaoptional = DataHelper.IfDBNull<string>(row["codcategoriaoptional"], _stringEmpty),
                    Codsottocategoriaoptional = DataHelper.IfDBNull<string>(row["codsottocategoriaoptional"], _stringEmpty),
                    Optional = DataHelper.IfDBNull<string>(row["optional"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }


        //conta optional - FILTRO: keysearch
        public int SelectCountOptional(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.optional like '%' + @keysearch + '%') ";

            string SQL = " SELECT COUNT(*) as tot FROM EF_carlist_optional as o " +
                         " LEFT JOIN EF_carlist_optional_categorie as c ON o.codcategoriaoptional = c.codcategoriaoptional AND o.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_carlist_optional_categorie as c1 ON o.codsottocategoriaoptional = c1.codcategoriaoptional AND o.uidtenant = c1.uidtenant " +
                         " WHERE o.uidtenant = @Uidtenant " + condWhere;

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

        // lista optional
        // FILTRO: keysearch
        public List<ICars> SelectOptional(string keysearch, Guid Uidtenant, string ordine, string tipoordine, int numrecord, int pagina)
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
                orderby = " o.optional ";
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

            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND (o.optional like '%' + @keysearch + '%') ";

            List<ICars> retVal = new List<ICars>();
            string sql = " SELECT o.codoptional, o.optional, o.Uid, c.categoriaoptional as categoria, c1.categoriaoptional as sottocategoria FROM EF_carlist_optional as o " +
                         " LEFT JOIN EF_carlist_optional_categorie as c ON o.codcategoriaoptional = c.codcategoriaoptional AND o.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_carlist_optional_categorie as c1 ON o.codsottocategoriaoptional = c1.codcategoriaoptional AND o.uidtenant = c1.uidtenant " +
                         " WHERE o.uidtenant = @Uidtenant " + condWhere + " ORDER BY " + orderby + paginazione;

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
                    ICars item = new Cars
                    {
                        Codoptional = DataHelper.IfDBNull<string>(row["codoptional"], _stringEmpty),
                        Categoriaoptional = DataHelper.IfDBNull<string>(row["categoria"], _stringEmpty),
                        Sottocategoriaoptional = DataHelper.IfDBNull<string>(row["sottocategoria"], _stringEmpty),
                        Optional = DataHelper.IfDBNull<string>(row["optional"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<ICars> SelectOptionalTerm(string keysearch, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(keysearch)) condWhere += " AND o.optional LIKE '%' + @keysearch + '%' ";

            List<ICars> retVal = new List<ICars>();

            string sql = "SELECT DISTINCT TOP 10 o.optional, o.codoptional, c.categoriaoptional as categoria, c1.categoriaoptional as sottocategoria FROM EF_carlist_optional as o " +
                         " LEFT JOIN EF_carlist_optional_categorie as c ON o.codcategoriaoptional = c.codcategoriaoptional AND o.uidtenant = c.uidtenant " +
                         " LEFT JOIN EF_carlist_optional_categorie as c1 ON o.codsottocategoriaoptional = c1.codcategoriaoptional AND o.uidtenant = c1.uidtenant " +
                         " WHERE o.uidtenant = @Uidtenant " + condWhere + "  ORDER BY o.optional ";

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
                    ICars item = new Cars
                    {
                        Optional = DataHelper.IfDBNull<string>(row["categoria"], _stringEmpty) + " - " + DataHelper.IfDBNull<string>(row["sottocategoria"], _stringEmpty) + " - " + DataHelper.IfDBNull<string>(row["optional"], _stringEmpty),
                        Codoptional = DataHelper.IfDBNull<string>(row["codoptional"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<ICars> SelectAllCategorieSecondoLivello(Guid Uidtenant)
        {
            List<ICars> retVal = new List<ICars>();

            string sql = "SELECT codcategoriaoptional, categoriaoptional FROM EF_carlist_optional_categorie WHERE livello=2 AND uidtenant = @Uidtenant ORDER BY categoriaoptional ";

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
                    ICars item = new Cars
                    {
                        Codcategoriaoptional = DataHelper.IfDBNull<string>(row["codcategoriaoptional"], _stringEmpty),
                        Categoriaoptional = DataHelper.IfDBNull<string>(row["categoriaoptional"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public List<ICars> SelectAllCategorieSecondoLivelloXCod(string codcategoriaoptional)
        {
            List<ICars> retVal = new List<ICars>();

            string sql = "SELECT codcategoriaoptional, categoriaoptional FROM EF_carlist_optional_categorie WHERE livello=2 and codpadrecategoria=@codcategoriaoptional ORDER BY categoriaoptional ";
            
            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcategoriaoptional", DbType.String);
            param0.Value = codcategoriaoptional;
            collParams.Add(param0);            

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICars item = new Cars
                    {
                        Codcategoriaoptional = DataHelper.IfDBNull<string>(row["codcategoriaoptional"], _stringEmpty),
                        Categoriaoptional = DataHelper.IfDBNull<string>(row["categoriaoptional"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }


        public List<ICars> SelectAllOptionalXCod(string codcategoria, string codsottocategoria)
        {
            List<ICars> retVal = new List<ICars>();

            string sql = "SELECT codoptional, optional FROM EF_carlist_optional WHERE codcategoriaoptional=@codcategoria and codsottocategoriaoptional=@codsottocategoria ORDER BY optional ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcategoria", DbType.String);
            param0.Value = codcategoria;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codsottocategoria", DbType.String);
            param1.Value = codsottocategoria;
            collParams.Add(param1);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICars item = new Cars
                    {
                        Optional = DataHelper.IfDBNull<string>(row["optional"], _stringEmpty),
                        Codoptional = DataHelper.IfDBNull<string>(row["codoptional"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //cancella optional auto
        public int DeleteOptionalAuto(ICars value)
        {
            string condWhere = "";

            if (value.Optcolore.ToUpper() == "SI")
            {
                condWhere += " AND optcolore = 'SI' ";
            }
            else
            {
                condWhere += " AND (optcolore = '' OR optcolore is null ) ";
            }
        
            int retVal = 0;
            string sql = "DELETE FROM EF_carlist_auto_optional WHERE codjatoauto = @codjatoauto AND uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            paramID.Value = value.Codjatoauto;
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

        //inserimento optional auto
        public int InsertOptionalAuto(ICars value)
        {
            int retVal = 0;

            string sql = "INSERT INTO EF_carlist_auto_optional ([codjatoauto],[codoptional],[importooptional],[giorniconsegnaagg], " +
                         " [datauserins],[UserIDIns],[datausermod],[UserIdMod],[optcolore],[uidtenant] ) " +
                         " VALUES (@codjatoauto,@codoptional,@importooptional,@giorniconsegnaagg, " +
                         " @datauserins,@UserIDIns,@datausermod,@UserIdMod,@optcolore,@uidtenant) ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = value.Codjatoauto;
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

            IDbDataParameter param13 = _dataHelper.ProviderConn.CreateDataParameter("@datauserins", DbType.Date);
            param13.Value = DateTime.Now;
            collParams.Add(param13);

            IDbDataParameter param14 = _dataHelper.ProviderConn.CreateDataParameter("@UserIDIns", DbType.Guid);
            param14.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param14);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@datausermod", DbType.Date);
            param15.Value = DateTime.Now;
            collParams.Add(param15);

            IDbDataParameter param16 = _dataHelper.ProviderConn.CreateDataParameter("@UserIdMod", DbType.Guid);
            param16.Value = (Guid)Membership.GetUser().ProviderUserKey;
            collParams.Add(param16);

            IDbDataParameter param17 = _dataHelper.ProviderConn.CreateDataParameter("@optcolore", DbType.String);
            param17.Value = value.Optcolore;
            collParams.Add(param17);

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


        //esistenza optional auto
        public ICars ExistOptionalAuto(string codjatoauto, string codoptional)
        {
            ICars retVal = null;
            string sql = "SELECT Uid, importooptional, giorniconsegnaagg FROM EF_carlist_auto_optional WHERE codjatoauto = @codjatoauto and codoptional = @codoptional ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = codjatoauto;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codoptional", DbType.String);
            param1.Value = codoptional;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cars
                {
                    Importooptional = DataHelper.IfDBNull<decimal>(row["importooptional"], 0),
                    Giorniconsegnaagg = DataHelper.IfDBNull<int>(row["giorniconsegnaagg"], 0),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };

                data.Dispose();
            }
            return retVal;
        }



        //conta optional auto
        public int SelectCountOptionalAuto(string codjatoauto)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_carlist_auto_optional WHERE codjatoauto = @codjatoauto ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = codjatoauto;
            collParams.Add(param0);            

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        // lista optional auto
        public List<ICars> SelectOptionalAuto(string codjatoauto, string codcategoria, string codsottocategoria)
        {
            List<ICars> retVal = new List<ICars>();
            string sql = " SELECT o.codoptional, o.optional, o.Uid, o.note, c.categoriaoptional as categoria, c1.categoriaoptional as sottocategoria, " + 
                         " ao.importooptional, ao.giorniconsegnaagg FROM EF_carlist_optional as o " +
                         " LEFT JOIN EF_carlist_auto_optional as ao ON ao.codoptional = o.codoptional " +
                         " LEFT JOIN EF_carlist_optional_categorie as c ON o.codcategoriaoptional = c.codcategoriaoptional " +
                         " LEFT JOIN EF_carlist_optional_categorie as c1 ON o.codsottocategoriaoptional = c1.codcategoriaoptional " +
                         " WHERE ao.codjatoauto = @codjatoauto and o.codcategoriaoptional=@codcategoria and o.codsottocategoriaoptional=@codsottocategoria ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = codjatoauto;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codcategoria", DbType.String);
            param1.Value = codcategoria;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsottocategoria", DbType.String);
            param2.Value = codsottocategoria;
            collParams.Add(param2);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICars item = new Cars
                    {
                        Codoptional = DataHelper.IfDBNull<string>(row["codoptional"], _stringEmpty),
                        Categoriaoptional = DataHelper.IfDBNull<string>(row["categoria"], _stringEmpty),
                        Sottocategoriaoptional = DataHelper.IfDBNull<string>(row["sottocategoria"], _stringEmpty),
                        Optional = DataHelper.IfDBNull<string>(row["optional"], _stringEmpty),
                        Note = DataHelper.IfDBNull<string>(row["note"], _stringEmpty),
                        Importooptional = DataHelper.IfDBNull<decimal>(row["importooptional"], 0),
                        Giorniconsegnaagg = DataHelper.IfDBNull<int>(row["giorniconsegnaagg"], 0),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountOptionalAutoCat(string codjatoauto, string codcategoria)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_carlist_auto_optional as ca INNER JOIN EF_carlist_optional as o ON ca.codoptional = o.codoptional " +
                         " WHERE ca.codjatoauto = @codjatoauto and o.codcategoriaoptional=@codcategoria and ca.importooptional > 0 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = codjatoauto;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codcategoria", DbType.String);
            param1.Value = codcategoria;
            collParams.Add(param1);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public int SelectCountOptionalAutoSottoCat(string codjatoauto, string codcategoria, string codsottocategoria)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_carlist_auto_optional as ca INNER JOIN EF_carlist_optional as o ON ca.codoptional = o.codoptional  " +
                         " WHERE ca.codjatoauto = @codjatoauto and o.codcategoriaoptional=@codcategoria and o.codsottocategoriaoptional=@codsottocategoria and ca.importooptional > 0 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = codjatoauto;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codcategoria", DbType.String);
            param1.Value = codcategoria;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsottocategoria", DbType.String);
            param2.Value = codsottocategoria;
            collParams.Add(param2);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public int SelectCountOptionalAutoCatDiSerie(string codjatoauto, string codcategoria)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_carlist_auto_optional as ca INNER JOIN EF_carlist_optional as o ON ca.codoptional = o.codoptional " +
                         " WHERE ca.codjatoauto = @codjatoauto and o.codcategoriaoptional=@codcategoria and ca.importooptional = 0 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = codjatoauto;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codcategoria", DbType.String);
            param1.Value = codcategoria;
            collParams.Add(param1);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public int SelectCountOptionalAutoSottoCatDiSerie(string codjatoauto, string codcategoria, string codsottocategoria)
        {
            string SQL = " SELECT COUNT(*) as tot FROM EF_carlist_auto_optional as ca INNER JOIN EF_carlist_optional as o ON ca.codoptional = o.codoptional  " +
                         " WHERE ca.codjatoauto = @codjatoauto and o.codcategoriaoptional=@codcategoria and o.codsottocategoriaoptional=@codsottocategoria and ca.importooptional = 0 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = codjatoauto;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codcategoria", DbType.String);
            param1.Value = codcategoria;
            collParams.Add(param1);

            IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsottocategoria", DbType.String);
            param2.Value = codsottocategoria;
            collParams.Add(param2);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }

        public List<ICars> SelectAllCarPolicy(Guid Uidtenant)
        {
            List<ICars> retVal = new List<ICars>();

            string sql = "SELECT codcarpolicy FROM EF_carpolicy WHERE uidtenant = @Uidtenant ORDER BY codcarpolicy ";

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
                    ICars item = new Cars
                    {
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        //esistenza optional auto in ordine
        public bool ExistOrdineOptionalAuto(int idordine, string codoptional)
        {
            bool retVal = false;
            string sql = "SELECT importooptional FROM EF_ordini_optional WHERE idordine = @idordine and codoptional = @codoptional ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idordine", DbType.Int32);
            param0.Value = idordine;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codoptional", DbType.String);
            param1.Value = codoptional;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public ICars DetailImportoOrdineOptionalAuto(int idordine, string codoptional)
        {
            ICars retVal = null;
            string sql = "SELECT importooptional, codoptional FROM EF_ordini_optional WHERE idordine = @idordine and codoptional = @codoptional ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@idordine", DbType.Int32);
            param0.Value = idordine;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codoptional", DbType.String);
            param1.Value = codoptional;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cars
                {
                    Importooptional = DataHelper.IfDBNull<decimal>(row["importooptional"], 0),
                    Codoptional = DataHelper.IfDBNull<string>(row["codoptional"], _stringEmpty)
                };
                data.Dispose();
            }
            return retVal;
        }

        //dettagli car list tramite codjatoauto
        public ICars DetailCarListAutoXCodjato(string codjatoauto, string codcarlist)
        {
            ICars retVal = null;
            string sql = "SELECT * FROM EF_carlist_auto WHERE codjatoauto = @codjatoauto AND codcarlist = @codcarlist";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = codjatoauto;
            collParams.Add(param0);

            IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param1.Value = codcarlist;
            collParams.Add(param1);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                retVal = new Cars
                {
                    Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                    Codfornitore = DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                    Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                    Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                    Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                    Cilindrata = DataHelper.IfDBNull<string>(row["cilindrata"], _stringEmpty),
                    Alimentazione = DataHelper.IfDBNull<string>(row["alimentazione"], _stringEmpty),
                    Alimentazionesecondaria = DataHelper.IfDBNull<string>(row["alimentazionesecondaria"], _stringEmpty),
                    Consumo = DataHelper.IfDBNull<decimal>(row["consumo"], 0),
                    Consumourbano = DataHelper.IfDBNull<decimal>(row["consumourbano"], 0),
                    Consumoextraurbano = DataHelper.IfDBNull<decimal>(row["consumoextraurbano"], 0),
                    Emissioni = DataHelper.IfDBNull<decimal>(row["emissioni"], 0),
                    Costoautobase = DataHelper.IfDBNull<decimal>(row["costoautobase"], 0),
                    Costoaci = DataHelper.IfDBNull<decimal>(row["costoaci"], 0),
                    Canoneleasing = DataHelper.IfDBNull<decimal>(row["canoneleasing"], 0),
                    Fringebenefitbase = DataHelper.IfDBNull<decimal>(row["fringebenefitbase"], 0),
                    Fotoauto = DataHelper.IfDBNull<string>(row["fotoauto"], _stringEmpty),
                    Cambio = DataHelper.IfDBNull<string>(row["cambio"], _stringEmpty),
                    Giorniconsegna = DataHelper.IfDBNull<int>(row["giorniconsegna"], 0),
                    Mesicontratto = DataHelper.IfDBNull<int>(row["mesicontratto"], 0),
                    Kwcv = DataHelper.IfDBNull<string>(row["kwcv"], _stringEmpty),
                    Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                };
                data.Dispose();
            }
            return retVal;
        }

        //esistenza carpolicy
        public bool ExistCarPolicy(string codcarpolicy)
        {
            bool retVal = false;
            string sql = "SELECT codcarpolicy FROM EF_carpolicy WHERE codcarpolicy = @codcarpolicy ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = codcarpolicy;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public List<ICars> SelectAllColori(string codjatoauto, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(codjatoauto)) condWhere += " AND ao.codjatoauto = @codjatoauto ";

            List<ICars> retVal = new List<ICars>();

            string sql = " SELECT DISTINCT o.codoptional, o.optional FROM EF_carlist_optional as o " +
                         " LEFT JOIN EF_carlist_auto_optional as ao ON ao.codoptional = o.codoptional AND o.uidtenant = ao.uidtenant " +
                         " LEFT JOIN EF_carlist_optional_categorie as c ON o.codcategoriaoptional = c.codcategoriaoptional AND o.uidtenant = c.uidtenant " +
                         " WHERE o.codcategoriaoptional = 'COL' AND o.uidtenant = @Uidtenant " + condWhere + " ORDER BY o.optional ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codjatoauto))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
                param0.Value = codjatoauto;
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
                    ICars item = new Cars
                    {
                        Codoptional = DataHelper.IfDBNull<string>(row["codoptional"], _stringEmpty),
                        Optional = DataHelper.IfDBNull<string>(row["optional"], _stringEmpty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public bool ExistCodCarList(string codcarlist)
        {
            bool retVal = false;
            string sql = "SELECT codcarlist FROM EF_carlist WHERE codcarlist = @codcarlist ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
            param0.Value = codcarlist;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }

        public bool ExistCodOptional(string codoptional)
        {
            bool retVal = false;
            string sql = "SELECT codoptional FROM EF_carlist_optional WHERE codoptional = @codoptional ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codoptional", DbType.String);
            param0.Value = codoptional;
            collParams.Add(param0);

            DataTable data = _dataHelper.GetDataTable(sql, collParams, CommandType.Text).Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                retVal = true;
            }

            return retVal;
        }
        public List<ICars> SelectAllAuto(Guid Uidtenant)
        {
            List<ICars> retVal = new List<ICars>();

            string sql = "SELECT codjatoauto, modello, Uid, codcarlist, codfornitore FROM EF_carlist_auto WHERE uidtenant = @Uidtenant ORDER BY modello ";

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
                    ICars item = new Cars
                    {
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty) + " - " + DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty) + " - " + DataHelper.IfDBNull<string>(row["codfornitore"], _stringEmpty),
                        Codjatoauto = DataHelper.IfDBNull<string>(row["codjatoauto"], _stringEmpty),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public List<ICars> SelectDimissionari(string nominativo, string codgrade, string codsocieta, string codfornitore, DateTime dataassdal, DateTime dataassal, DateTime datapresdimdal, DateTime datapresdimal, string totautoparc, Guid Uidtenant, int numrecord, int pagina)
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

            if (!string.IsNullOrEmpty(nominativo)) condWhere += " AND (cognome LIKE '%' + @nominativo + '%' OR nome LIKE '%' + @nominativo + '%' OR matricola LIKE '%' + @nominativo + '%') ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND grade = @codgrade ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND siglasocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND fornitore LIKE '%' + @codfornitore + '%' ";
            if (!string.IsNullOrEmpty(totautoparc)) condWhere += " AND totparcoauto = @totautoparc ";
            if (dataassdal > DateTime.MinValue) condWhere += " AND dataassunzione >= @dataassdal ";
            if (dataassal > DateTime.MinValue) condWhere += " AND dataassunzione <= @dataassal ";
            if (datapresdimdal > DateTime.MinValue) condWhere += " AND datadimissioni >= @datapresdimdal ";
            if (datapresdimal > DateTime.MinValue) condWhere += " AND datadimissioni <= @datapresdimal ";

            List<ICars> retVal = new List<ICars>();

            string sql = " SELECT * FROM view_report_dimissionari " +
                         " WHERE nome <> '' AND uidtenant = @Uidtenant " + condWhere + " ORDER BY datadimissioni DESC, dataprevistadimissione DESC " + paginazione;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(nominativo))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@nominativo", DbType.String);
                param0.Value = nominativo;
                collParams.Add(param0);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param1.Value = codgrade;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param3.Value = codfornitore;
                collParams.Add(param3);
            }
            if (dataassdal > DateTime.MinValue)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@dataassdal", DbType.DateTime);
                param4.Value = dataassdal;
                collParams.Add(param4);
            }
            if (dataassal > DateTime.MinValue)
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@dataassal", DbType.DateTime);
                param5.Value = dataassal;
                collParams.Add(param5);
            }
            if (datapresdimdal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datapresdimdal", DbType.DateTime);
                param6.Value = datapresdimdal;
                collParams.Add(param6);
            }
            if (datapresdimal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datapresdimal", DbType.DateTime);
                param7.Value = datapresdimal;
                collParams.Add(param7);
            }
            if (!string.IsNullOrEmpty(totautoparc))
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@totautoparc", DbType.String);
                param8.Value = totautoparc;
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
                    ICars item = new Cars
                    {
                        Cognome = DataHelper.IfDBNull<string>(row["cognome"], _stringEmpty),
                        Nome = DataHelper.IfDBNull<string>(row["nome"], _stringEmpty),
                        Matricola = DataHelper.IfDBNull<string>(row["matricola"], _stringEmpty),
                        Grade = DataHelper.IfDBNull<string>(row["grade"], _stringEmpty),
                        Siglasocieta = DataHelper.IfDBNull<string>(row["siglasocieta"], _stringEmpty),
                        Dataassunzione = DataHelper.IfDBNull<DateTime>(row["dataassunzione"], DateTime.MinValue),
                        Datadimissioni = DataHelper.IfDBNull<DateTime>(row["datadimissioni"], DateTime.MinValue),
                        Dataprevistadimissione = DataHelper.IfDBNull<DateTime>(row["dataprevistadimissione"], DateTime.MinValue),
                        Datadocpolicy = DataHelper.IfDBNull<DateTime>(row["datadocpolicy"], DateTime.MinValue),
                        Dataordine = DataHelper.IfDBNull<DateTime>(row["dataordine"], DateTime.MinValue),
                        Targa = DataHelper.IfDBNull<string>(row["targa"], _stringEmpty),
                        Fornitore = DataHelper.IfDBNull<string>(row["fornitore"], _stringEmpty),
                        Datainiziocontratto = DataHelper.IfDBNull<DateTime>(row["datainiziocontratto"], DateTime.MinValue),
                        Datainiziouso = DataHelper.IfDBNull<DateTime>(row["datainiziouso"], DateTime.MinValue),
                        Datafinecontratto = DataHelper.IfDBNull<DateTime>(row["datafinecontratto"], DateTime.MinValue),
                        Canoneleasing = DataHelper.IfDBNull<decimal>(row["canoneleasing"], 0),
                        Note = DataHelper.IfDBNull<string>(row["totparcoauto"], _stringEmpty),
                        Mesicontratto = DataHelper.IfDBNull<int>(row["durata"], 0),
                        Importoforfettario = DataHelper.IfDBNull<decimal>(row["importoforfettario"], 0),
                        Penaleordine = DataHelper.IfDBNull<decimal>(row["penaleOrdine"], 0),
                        Penaleritiro = DataHelper.IfDBNull<decimal>(row["penaleRitiro"], 0),
                        Canoneoptional = DataHelper.IfDBNull<decimal>(row["canoneoptional"], 0),
                        Mesiresidui = DataHelper.IfDBNull<int>(row["mesiresidui"], 0),
                        Residuooptional = DataHelper.IfDBNull<decimal>(row["residuooptional"], 0),
                        Multe = DataHelper.IfDBNull<int>(row["multe"], 0),
                        Fuel = DataHelper.IfDBNull<decimal>(row["fuel"], 0),
                        Rimborsoconcur = DataHelper.IfDBNull<decimal>(row["rimborsoconcur"], 0),
                        Speseamministrative = DataHelper.IfDBNull<decimal>(row["speseamministrative"], 0),
                        Ordinecorrente = DataHelper.IfDBNull<string>(row["ordinecorrente"], _stringEmpty),
                        UserIDIns = DataHelper.IfDBNull<Guid>(row["UserId"], Guid.Empty),
                        Ordinestatus = DataHelper.IfDBNull<string>(row["ordinestatus"], _stringEmpty),
                        Erratasederestituzione = DataHelper.IfDBNull<string>(row["erratasederestituzione"], _stringEmpty),
                        Erratarestituzionegomme = DataHelper.IfDBNull<string>(row["erratarestituzionegomme"], _stringEmpty),
                        Penaledenuncia = DataHelper.IfDBNull<string>(row["penaledenuncia"], _stringEmpty),
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }
        public int SelectCountDimissionari(string nominativo, string codgrade, string codsocieta, string codfornitore, DateTime dataassdal, DateTime dataassal, DateTime datapresdimdal, DateTime datapresdimal, string totautoparc, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(nominativo)) condWhere += " AND (cognome LIKE '%' + @nominativo + '%' OR nome LIKE '%' + @nominativo + '%' OR matricola LIKE '%' + @nominativo + '%') ";
            if (!string.IsNullOrEmpty(codgrade)) condWhere += " AND grade LIKE '%' + @codgrade + '%' ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " AND siglasocieta = @codsocieta ";
            if (!string.IsNullOrEmpty(codfornitore)) condWhere += " AND fornitore LIKE '%' + @codfornitore + '%' ";
            if (!string.IsNullOrEmpty(totautoparc)) condWhere += " AND totparcoauto = @totautoparc ";
            if (dataassdal > DateTime.MinValue) condWhere += " AND dataassunzione >= @dataassdal ";
            if (dataassal > DateTime.MinValue) condWhere += " AND dataassunzione <= @dataassal ";
            if (datapresdimdal > DateTime.MinValue) condWhere += " AND datadimissioni >= @datapresdimdal ";
            if (datapresdimal > DateTime.MinValue) condWhere += " AND datadimissioni <= @datapresdimal ";

            string SQL = " SELECT COUNT(*) as tot FROM view_report_dimissionari " +
                         " WHERE nome <> '' AND uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();


            if (!string.IsNullOrEmpty(nominativo))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@nominativo", DbType.String);
                param0.Value = nominativo;
                collParams.Add(param0);
            }
            if (!string.IsNullOrEmpty(codgrade))
            {
                IDbDataParameter param1 = _dataHelper.ProviderConn.CreateDataParameter("@codgrade", DbType.String);
                param1.Value = codgrade;
                collParams.Add(param1);
            }
            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param2 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param2.Value = codsocieta;
                collParams.Add(param2);
            }
            if (!string.IsNullOrEmpty(codfornitore))
            {
                IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@codfornitore", DbType.String);
                param3.Value = codfornitore;
                collParams.Add(param3);
            }
            if (dataassdal > DateTime.MinValue)
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@dataassdal", DbType.DateTime);
                param4.Value = dataassdal;
                collParams.Add(param4);
            }
            if (dataassal > DateTime.MinValue)
            {
                IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@dataassal", DbType.DateTime);
                param5.Value = dataassal;
                collParams.Add(param5);
            }
            if (datapresdimdal > DateTime.MinValue)
            {
                IDbDataParameter param6 = _dataHelper.ProviderConn.CreateDataParameter("@datapresdimdal", DbType.DateTime);
                param6.Value = datapresdimdal;
                collParams.Add(param6);
            }
            if (datapresdimal > DateTime.MinValue)
            {
                IDbDataParameter param7 = _dataHelper.ProviderConn.CreateDataParameter("@datapresdimal", DbType.DateTime);
                param7.Value = datapresdimal;
                collParams.Add(param7);
            }
            if (!string.IsNullOrEmpty(totautoparc))
            {
                IDbDataParameter param8 = _dataHelper.ProviderConn.CreateDataParameter("@totautoparc", DbType.String);
                param8.Value = totautoparc;
                collParams.Add(param8);
            }
            IDbDataParameter param9 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param9.Value = Uidtenant;
            collParams.Add(param9);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }
        public int DeleteOptionalOrdine(int idordine, string codoptional, Guid Uidtenant)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_ordini_optional WHERE idordine = @idordine AND codoptional = @codoptional AND uidtenant = @Uidtenant ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@codoptional", DbType.String);
            paramID.Value = codoptional;
            collParams.Add(paramID);

            IDbDataParameter paramID2 = _dataHelper.ProviderConn.CreateDataParameter("@idordine", DbType.Int32);
            paramID2.Value = idordine;
            collParams.Add(paramID2);

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
        public List<ICars> SelectAllOptionalAuto(string codjatoauto)
        {
            List<ICars> retVal = new List<ICars>();
            string sql = " SELECT o.codoptional, o.optional FROM EF_carlist_optional as o " +
                         " LEFT JOIN EF_carlist_auto_optional as ao ON ao.codoptional = o.codoptional WHERE ao.codjatoauto = @codjatoauto and ao.importooptional > 0 ";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codjatoauto", DbType.String);
            param0.Value = codjatoauto;
            collParams.Add(param0);

            IReturnValue<DataTable> result = _dataHelper.GetDataTable(sql, collParams, CommandType.Text);
            DataTable data = result.Data;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    ICars item = new Cars
                    {
                        Codoptional = DataHelper.IfDBNull<string>(row["codoptional"], _stringEmpty),
                        Optional = DataHelper.IfDBNull<string>(row["optional"], _stringEmpty) + " (" + DataHelper.IfDBNull<string>(row["codoptional"], _stringEmpty) + ")" 
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }

        public int SelectCountViewCarList(string codsocieta, string codcarlist, Guid Uidtenant)
        {
            string condWhere = "";
            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " and codcarlist = @codcarlist ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " and codsocieta = @codsocieta ";

            string SQL = "SELECT COUNT(*) as tot FROM view_carlist_attuale WHERE codsocieta<>'' AND uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param0.Value = codcarlist;
                collParams.Add(param0);
            }

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param4.Value = codsocieta;
                collParams.Add(param4);
            }
            IDbDataParameter param3 = _dataHelper.ProviderConn.CreateDataParameter("@Uidtenant", DbType.Guid);
            param3.Value = Uidtenant;
            collParams.Add(param3);

            return _dataHelper.GetValue<int>(SQL, collParams, CommandType.Text).Data;
        }


        public List<ICars> SelectViewCarList(string codsocieta, string codcarlist, Guid Uidtenant)
        {
            string condWhere = "";

            if (!string.IsNullOrEmpty(codcarlist)) condWhere += " and codcarlist = @codcarlist ";
            if (!string.IsNullOrEmpty(codsocieta)) condWhere += " and codsocieta = @codsocieta ";

            List<ICars> retVal = new List<ICars>();
            string sql = "SELECT * FROM view_carlist_attuale WHERE codsocieta<>'' AND uidtenant = @Uidtenant " + condWhere;

            List<IDataParameter> collParams = new List<IDataParameter>();

            if (!string.IsNullOrEmpty(codcarlist))
            {
                IDbDataParameter param0 = _dataHelper.ProviderConn.CreateDataParameter("@codcarlist", DbType.String);
                param0.Value = codcarlist;
                collParams.Add(param0);
            }

            if (!string.IsNullOrEmpty(codsocieta))
            {
                IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@codsocieta", DbType.String);
                param4.Value = codsocieta;
                collParams.Add(param4);
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
                    ICars item = new Cars
                    {
                        Codcarlist = DataHelper.IfDBNull<string>(row["codcarlist"], _stringEmpty),
                        Codcarpolicy = DataHelper.IfDBNull<string>(row["codcarpolicy"], _stringEmpty),
                        Marca = DataHelper.IfDBNull<string>(row["marca"], _stringEmpty),
                        Modello = DataHelper.IfDBNull<string>(row["modello"], _stringEmpty),
                        Validodal = DataHelper.IfDBNull<DateTime>(row["validodal"], DateTime.MinValue),
                        Validoal = DataHelper.IfDBNull<DateTime>(row["validoal"], DateTime.MinValue),
                        Uid = DataHelper.IfDBNull<Guid>(row["Uid"], Guid.Empty)
                    };
                    retVal.Add(item);
                }
                data.Dispose();
            }
            return retVal;
        }



        public int UpdateCarListContrattoAuto(ICars value)
        {
            int retVal = 0;

            string sql = " UPDATE EF_carlist_auto SET [cilindrata] = @cilindrata, [alimentazione] = @alimentazione, [kwcv] = @kwcv WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter param4 = _dataHelper.ProviderConn.CreateDataParameter("@cilindrata", DbType.String);
            param4.Value = value.Cilindrata;
            collParams.Add(param4);

            IDbDataParameter param5 = _dataHelper.ProviderConn.CreateDataParameter("@alimentazione", DbType.String);
            param5.Value = value.Alimentazione;
            collParams.Add(param5);

            IDbDataParameter param15 = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            param15.Value = value.Uid;
            collParams.Add(param15);

            IDbDataParameter param26 = _dataHelper.ProviderConn.CreateDataParameter("@kwcv", DbType.String);
            param26.Value = value.Kwcv;
            collParams.Add(param26);

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
        public int DeleteOptionalAuto(Guid Uid, Guid Uidtenant)
        {
            int retVal = 0;
            string sql = "DELETE FROM EF_carlist_auto_optional WHERE Uid = @Uid AND uidtenant = @Uidtenant";

            List<IDataParameter> collParams = new List<IDataParameter>();

            IDbDataParameter paramID = _dataHelper.ProviderConn.CreateDataParameter("@Uid", DbType.Guid);
            paramID.Value = Uid;
            collParams.Add(paramID);

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