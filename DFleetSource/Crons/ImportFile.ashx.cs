// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ImportFile.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text;
using BusinessObject;
using BusinessLogic;
using System.Globalization;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using AraneaUtilities.Auth;
using AraneaUtilities.CronAsyncTasks;
using Microsoft.VisualBasic.FileIO;
using AraneaUtilities.Auth.Roles;

namespace DFleet.Crons
{
    /// <summary>
    /// Summary description for ImportFile
    /// </summary>
    public class ImportFile : CronAsyncHandler, System.Web.SessionState.IRequiresSessionState
    {

        protected override void ServeContent(HttpContext context)
        {
            ICronBL servizioCron = new CronBL();
            
            string filePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";

            string path = "\\\\10.71.222.198\\Ufleet\\D4M\\DLT\\HR\\EMPLOYEE\\";

            //recupero credenziali network
            string usernetwork = EncryptHelper.Decrypt(servizioCron.CredNetwork().Network_user, SeoHelper.PassPhrase()); //recupero user network
            string passwordnetwork = EncryptHelper.Decrypt(servizioCron.CredNetwork().Network_password, SeoHelper.PassPhrase()); //recupero pwd network

            //cancella connessioni aperte
            int result = NetworkConnection.CloseConnection("\\\\10.71.222.198\\Ufleet");

            //apre connessione
            using (new NetworkConnection(@"\\10.71.222.198\Ufleet", new NetworkCredential(usernetwork, passwordnetwork))) // "D4MService", "097!<0q)eCf<XFBm>8)^"
            {
                int idprog = 0;
                var directory = new DirectoryInfo(@path);
                FileInfo myFile = (from f in directory.GetFiles()
                                   orderby f.LastWriteTime descending
                                   select f).First();
                filePath += myFile.Name;
                path += myFile.Name;

                if (!File.Exists(@filePath)) // copia file se non è già esistente
                {
                    File.Copy(@path, @filePath);
                }

                //inserisce importazione in storico
                ICron SaveFile = new Cron
                {
                    Idtipofile = 5,
                    Nomefile = SeoHelper.EncodeString(myFile.Name),
                    Flgcron = 1,
                    Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                };

                servizioCron.InsertStoricoImportazione(SaveFile);

                //recupera ultimo idprog
                ICron dataIdp = servizioCron.UltimoIDProgImp();

                if (dataIdp != null)
                {
                    idprog = dataIdp.Idprog;
                }

                //importa tracciato anagrafica
                ICron importUpd3 = new Cron
                {
                    Righeimportate = 0,
                    Righetotali = 0,
                    Texterrori = "",
                    Idprog = idprog,
                    Importato = "IN ELABORAZIONE",
                    Dataimportazione = DateTime.Now,
                    Uidtenant = SeoHelper.ReturnSessionTenant()
                };
                servizioCron.UpdateStoricoImportazione(importUpd3);


                ImportTracciatoAnagrafica(myFile.Name, idprog);
            }


            /* ATTIVARE PER LOCALHOST
            //recupera ultimo idprog
            ICron dataIdp = servizioCron.UltimoIDProgImp();

            if (dataIdp != null)
            {
                ICron importUpd3 = new Cron
                {
                    Righeimportate = 0,
                    Righetotali = 0,
                    Texterrori = "",
                    Idprog = dataIdp.Idprog,
                    Importato = "IN ELABORAZIONE",
                    Dataimportazione = DateTime.Now,
                    Uidtenant = SeoHelper.ReturnSessionTenant()
                };
                servizioCron.UpdateStoricoImportazione(importUpd3);

                //importa tracciato anagrafica
                ImportTracciatoAnagrafica(dataIdp.Nomefile, dataIdp.Idprog);
            }*/

        }

        public void ImportTracciatoAnagrafica(string filename, int idprog)
        {
            ICronBL servizioCron = new CronBL();
            int righetotali = 0;
            int righeimportate = 0;
            string errorefile = string.Empty;

            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/temp/";
            filePath += filename;

            //selezionare i dimissionari del mese precedente e cambiare la mail aggiungendo il suffisso ex,
            //in users e anche in membership, inoltre portare l'utente dimissionario in status sospeso

            List<ICron> dataDim = servizioCron.SelectUsersDimissionariAttivi();

            if (dataDim != null && dataDim.Count > 0)
            {
                foreach (ICron resultDim in dataDim)
                {
                    ICron accountNew = new Cron
                    {
                        Email = "ex_" + SeoHelper.EncodeString(resultDim.Email),
                        UserId = resultDim.UserId,
                        UserIDIns = Guid.Empty,
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };

                    if (servizioCron.UpdateEmail(accountNew) == 1)
                    {
                        if (!string.IsNullOrEmpty(accountNew.Email))
                        {
                            var user = Membership.GetUser(resultDim.Email);
                            MembershipUserCollection utenti = Membership.FindUsersByEmail(SeoHelper.EncodeString(resultDim.Email));
                            if (utenti.Count > 0)
                            {
                                user.Email = accountNew.Email;
                                Membership.UpdateUser(user);

                                servizioCron.UpdateUserNameMembership(accountNew.Email, accountNew.Email.ToLower(), resultDim.Email);
                            }
                        }
                    }
                }
            }
            //fine



            using (TextFieldParser csvParser = new TextFieldParser(filePath, Encoding.GetEncoding("iso-8859-1")))
            {
                csvParser.TextFieldType = FieldType.Delimited;
                csvParser.SetDelimiters(";");
                csvParser.HasFieldsEnclosedInQuotes = false;

                bool firstLine = true;
                int z = 2;

                var lines = File.ReadAllLines(filePath);
                righetotali = (lines.Length) - 1;

                while (!csvParser.EndOfData)
                {

                    string[] fields = csvParser.ReadFields();

                    if (firstLine)
                    {
                        firstLine = false;

                        continue;
                    }

                    string persontype = fields[38];
                    string[] arraypt = persontype.Split('-');

                    string gradecode = fields[6];
                    string[] arraygc = gradecode.Split('-');

                    string provinciares = fields[22];
                    string[] arraypr = provinciares.Split('-');

                    //controlli lunghezza stringa provincia
                    string provincianascita = "";
                    string provinciaresidenza = "";
                    if (fields[18].Length > 3)
                    {
                        provincianascita = SeoHelper.EncodeString(fields[18].Substring(0, 3));
                    }
                    else
                    {
                        provincianascita = SeoHelper.EncodeString(fields[18]);
                    }
                    if (arraypr[0].Trim().Length > 3)
                    {
                        provinciaresidenza = SeoHelper.EncodeString(arraypr[0].Trim().Substring(0, 3));
                    }
                    else
                    {
                        provinciaresidenza = SeoHelper.EncodeString(arraypr[0].Trim());
                    }
                    

                    ICron accountNew = new Cron
                    {
                        Codsocieta = ReturnCodSocieta(fields[0]),
                        Cognome = SeoHelper.EncodeString(fields[1]),
                        Nome = SeoHelper.EncodeString(fields[2]),
                        Matricola = SeoHelper.EncodeString(fields[3]),
                        Idnumber = SeoHelper.EncodeString(fields[4]),
                        Idtipodriver = SeoHelper.IntString(fields[5]),
                        Funzione = SeoHelper.EncodeString(fields[6]),
                        Maternita = SeoHelper.EncodeString(fields[7]),
                        Cellulare = SeoHelper.EncodeString(fields[8]),
                        Email = SeoHelper.EncodeString(fields[9]),
                        Dataassunzione = SeoHelper.DataString(fields[10]),
                        Codicecdc = SeoHelper.EncodeString(fields[11]),
                        Descrizionecdc = SeoHelper.EncodeString(fields[12]),
                        Codicesede = SeoHelper.EncodeString(fields[14]),
                        Descrizionesede = SeoHelper.EncodeString(fields[15]),
                        Datanascita = SeoHelper.DataString(fields[16]),
                        Luogonascita = SeoHelper.EncodeString(fields[17]),
                        Provincianascita = provincianascita,
                        Codicefiscale = SeoHelper.EncodeString(fields[19]),
                        Indirizzoresidenza = SeoHelper.EncodeString(fields[20]),
                        Localitaresidenza = SeoHelper.EncodeString(fields[21]),
                        Provinciaresidenza = provinciaresidenza,
                        Capresidenza = SeoHelper.EncodeString(fields[23]),
                        Nrpatente = SeoHelper.EncodeString(fields[24]),
                        Dataemissione = SeoHelper.DataString(fields[25]),
                        Datascadenza = SeoHelper.DataString(fields[26]),
                        Ufficioemittente = SeoHelper.EncodeString(fields[27]),
                        Matricolaapprovatore = SeoHelper.EncodeString(fields[28]),
                        Codicesocietaapprovatore = SeoHelper.EncodeString(fields[29]),
                        Datainiziovalidita = SeoHelper.DataString(fields[30]),
                        Codicesettore = SeoHelper.EncodeString(fields[31]),
                        Descrizionesettore = SeoHelper.EncodeString(fields[32]),
                        Descrizioneapprovatore = SeoHelper.EncodeString(fields[33]),
                        Emailapprovatore = SeoHelper.EncodeString(fields[34]),
                        Dataprevistadimissione = SeoHelper.DataString(fields[35]),
                        Datadimissioni = SeoHelper.DataString(fields[36]),
                        Gradecode = SeoHelper.EncodeString(arraygc[0].Trim()),
                        Persontype = SeoHelper.EncodeString(arraypt[0].Trim()),
                        Indirizzosede = SeoHelper.EncodeString(fields[39]),
                        Cittasede = SeoHelper.EncodeString(fields[40]),
                        Provinciasede = SeoHelper.EncodeString(fields[41]),
                        Capsede = SeoHelper.EncodeString(fields[42]),
                        Codicedivisione = SeoHelper.EncodeString(fields[43]),
                        Descrizionedivisione = SeoHelper.EncodeString(fields[44]),
                        Fasciaimportazione = "",
                        Annotazioni = "",
                        Codfornitore = "",
                        Flgdriver = 0,
                        Idgruppouser = 2,
                        Idstatususer = 0,
                        Flgadmin = 0,
                        UserIDIns = Guid.Empty,
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };

                    if (accountNew.Gradecode == "10")
                    {
                        accountNew.Persontype = "PEQ";
                        accountNew.Idgruppouser = 4;
                    }
                    if (accountNew.Gradecode == "15")
                    {
                        accountNew.Persontype = "PAR";
                        accountNew.Idgruppouser = 4;
                    }

                    accountNew.Fasciacarpolicy = ReturnCodCarPolicy(accountNew.Codsocieta, accountNew.Gradecode); // recupero carpolicy

                    //controllo esistenza matricola, se esiste aggiorna i dati dell'utente
                    ICron data = servizioCron.ExistAnagraficaMatricola(accountNew.Matricola);
                    if (data != null)
                    {
                        //se esiste modifica dati

                        accountNew.UserId = data.UserId;

                        if (data.Idgruppouser == 1) //se amministratore
                        {
                            accountNew.Idgruppouser = 1;
                            accountNew.Flgadmin = 1;
                        }

                        if (data.Flgdriver == 1) //se flgdriver è 1
                        {
                            accountNew.Flgdriver = 1;
                        }


                        if (servizioCron.UpdateAccountCount(accountNew) > 0)
                        {
                            righeimportate++; //incrementa righe importate correttamente
                        }
                        else
                        {
                            errorefile += z + "; ";
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(accountNew.Email))
                        {
                            Membership.CreateUser(SeoHelper.EncodeString(accountNew.Email), "Dfleet2021.", SeoHelper.EncodeString(accountNew.Email)); //crea utente

                            if (accountNew.Idgruppouser == 1) //se admin
                            {
                                // devo passare Admin
                                if (!Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin))
                                    Roles.AddUserToRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin);
                                // devo rimuovere User
                                if (Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User))
                                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User);
                                // devo rimuovere Partner
                                if (Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Partner))
                                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Partner);
                            }

                            if (accountNew.Idgruppouser == 2) //se user
                            {
                                // devo passare User
                                if (!Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User))
                                    Roles.AddUserToRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User);
                                // devo rimuovere Admin
                                if (Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin))
                                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin);
                                // devo rimuovere Partner
                                if (Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Partner))
                                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Partner);
                            }


                            if (accountNew.Idgruppouser == 4) //se partner
                            {
                                // devo passare Partner
                                if (!Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Partner))
                                    Roles.AddUserToRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Partner);
                                // devo rimuovere Admin
                                if (Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin))
                                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.Admin);
                                // devo rimuovere User
                                if (Roles.IsUserInRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User))
                                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(accountNew.Email), DFleetGlobals.UserRoles.User);
                            }

                            Guid userId = (Guid)Membership.GetUser(SeoHelper.EncodeString(accountNew.Email)).ProviderUserKey; //recupera guid utente

                            accountNew.UserId = userId;

                            if (servizioCron.InsertAccount(accountNew) == 1) //se non esiste inserisce nuova anagrafica
                            {
                                righeimportate++; //incrementa righe importate correttamente
                            }
                            else
                            {
                                errorefile += z + "; ";
                            }
                        }
                        else
                        {
                            errorefile += z + "; ";
                        }
                    }

                    ICron importUpd3 = new Cron
                    {
                        Righeimportate = righeimportate,
                        Righetotali = righetotali,
                        Texterrori = errorefile,
                        Idprog = idprog,
                        Importato = "IN ELABORAZIONE",
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };
                    servizioCron.UpdateStoricoImportazione(importUpd3);


                    z++;
                }
            }

            ICron importUpd = new Cron();

            if (!string.IsNullOrEmpty(errorefile))
            {
                importUpd.Importato = "IMPORTATO CON ERRORI";
            }
            else
            {
                importUpd.Importato = "IMPORTATO CORRETTAMENTE";
            }
            importUpd.Righeimportate = righeimportate;
            importUpd.Righetotali = righetotali;
            importUpd.Texterrori = errorefile;
            importUpd.Idprog = idprog;
            importUpd.Datafineimportazione = DateTime.Now;
            importUpd.Uidtenant = SeoHelper.ReturnSessionTenant();

            servizioCron.UpdateStoricoImportazione(importUpd);
        }
        public string ReturnCodSocieta(string codcompany)
        {
            ICronBL servizioCron = new CronBL();
            string retVal;

            ICron dataCodPol = servizioCron.DetailSocieta(codcompany);
            if (dataCodPol != null)
            {
                retVal = dataCodPol.Codsocieta;
            }
            else
            {
                retVal = "";
            }

            return retVal;
        }
        public string ReturnCodCarPolicy(string codsocieta, string gradecode)
        {
            ICronBL servizioCron = new CronBL();
            string retVal;

            ICron dataCodPol = servizioCron.ReturnCodCarPolicy(codsocieta, gradecode);
            if (dataCodPol != null)
            {
                retVal = dataCodPol.Codcarpolicy;
            }
            else
            {
                retVal = "Nocar";
            }

            return retVal;
        }
    }
}
