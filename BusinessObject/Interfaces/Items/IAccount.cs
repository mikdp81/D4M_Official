// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IAccount.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BusinessObject
{
    public interface IAccount

    {
        //********************************************  parametri EF_user

        Guid Uid { get; set; }
        int Iduser { get; set; }
        Guid UserId { get; set; }
        int Idgruppouser { get; set; }
        int Idstatususer { get; set; }
        int Flgadmin { get; set; }
        int Flgdriver { get; set; }
        DateTime Datauserins { get; set; }
        DateTime Datausermod { get; set; }
        Guid UserIDIns { get; set; }
        Guid UserIdMod { get; set; }
        string Codsocieta { get; set; }
        string Cognome { get; set; }
        string Nome { get; set; }
        string Matricola { get; set; }
        string Idnumber { get; set; }
        int Idtipodriver { get; set; }
        string Funzione { get; set; }
        string Maternita { get; set; }
        string Cellulare { get; set; }
        string Email { get; set; }
        DateTime Dataassunzione { get; set; }
        string Codicecdc { get; set; }
        string Codicecdc2 { get; set; }
        string Codicecdc3 { get; set; }
        string Descrizionecdc { get; set; }
        string Fasciacarpolicy { get; set; }
        string Codicesede { get; set; }
        string Descrizionesede { get; set; }
        DateTime Datanascita { get; set; }
        string Luogonascita { get; set; }
        string Provincianascita { get; set; }
        string Codicefiscale { get; set; }
        string Indirizzoresidenza { get; set; }
        string Localitaresidenza { get; set; }
        string Provinciaresidenza { get; set; }
        string Capresidenza { get; set; }
        string Nrpatente { get; set; }
        DateTime Dataemissione { get; set; }
        DateTime Datascadenza { get; set; }
        string Ufficioemittente { get; set; }
        string Matricolaapprovatore { get; set; }
        string Codicesocietaapprovatore { get; set; }
        DateTime Datainiziovalidita { get; set; }
        string Codicesettore { get; set; }
        string Descrizionesettore { get; set; }
        string Descrizioneapprovatore { get; set; }
        string Emailapprovatore { get; set; }
        DateTime Dataprevistadimissione { get; set; }
        DateTime Datadimissioni { get; set; }
        string Gradecode { get; set; }
        string Persontype { get; set; }
        string Indirizzosede { get; set; }
        string Cittasede { get; set; }
        string Provinciasede { get; set; }
        string Capsede { get; set; }
        string Codicedivisione { get; set; }
        string Descrizionedivisione { get; set; }
        string Fasciaimportazione { get; set; }
        string Annotazioni { get; set; }
        string Codfornitore { get; set; }
        DateTime Datainviomail { get; set; }
        int Perccdc { get; set; }
        int Perccdc2 { get; set; }
        int Perccdc3 { get; set; }
        string Siglasocieta { get; set; }
        string Societa { get; set; }
        string Grade { get; set; }

        // JWT
        string ClientId { get; set; }
        string ImpersonatedUserId { get; set; }
        string AuthServer { get; set; }
        string PrivateKey { get; set; }

        // SIGN
        string BasePath { get; set; }
        string AccountId { get; set; }
        string PingUrl { get; set; }
        string SignerEmail { get; set; }
        string SignerName { get; set; }
        string SignerClientId { get; set; }
        Guid Uidtenant { get; set; }
        string Tenant { get; set; }
        string Urltenant { get; set; }
        string Oggettomail { get; set; }
        int Status { get; set; }


        //********************************************  parametri EF_userstatus
        string Statusutente { get; set; }

        //********************************************  parametri EF_gruppi
        string Gruppouser { get; set; }


        //********************************************  parametri EF_team e menu relativo

        int Idteam { get; set; }
        string Team { get; set; }
        string Stato { get; set; }
        int Idpagina { get; set; }         
        string Gruppo  { get; set; }
        string Codgruppopagina  { get; set; }
        string Icona  { get; set; }
        string Pagina { get; set; }
        string Linkpagina { get; set; }
        int Autorizzatore { get; set; }

        //********************************************  parametri EF_users_segnalazioni
        string Segnalazione { get; set; }

        //********************************************  parametri EF_users_fuelcard
        
        int Iduserfuel { get; set; }
        int Idcompagnia { get; set; }
        string Compagnia { get; set; }
        string Targa { get; set; }
        string Numero{ get; set; }
        string Pin { get; set; }
        DateTime Scadenza{ get; set; }
        DateTime Dataattivazione { get; set; }

        //********************************************  parametri EF_users_fuel_plafond

        int Idplafond { get; set; }
        DateTime Datarilevazione { get; set; }
        decimal Plafond { get; set; }
        decimal Delta { get; set; }


        //********************************************  parametri EF_tenant

        string Logo { get; set; }
        string Bgbarratop { get; set; }
        string Bgbarrasx { get; set; }
        string Colormenusx { get; set; }


    }
}