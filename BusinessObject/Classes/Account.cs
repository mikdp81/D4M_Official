// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Account.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.CompilerServices;
using System.Security.Permissions;

namespace BusinessObject
{
    [Serializable]
   
    public class Account : IAccount, IApiAccount, IApiTeam
    {
        public static string _stringEmpty = string.Empty;

        //********************************************  parametri EF_user

        public Guid Uid { get; set; }
        public int Iduser { get; set; }
        public Guid UserId { get; set; }
        public int Idgruppouser { get; set; }
        public int Idstatususer { get; set; }
        public int Flgadmin { get; set; }
        public int Flgdriver { get; set; }
        public DateTime Datauserins { get; set; }
        public DateTime Datausermod { get; set; }
        public Guid UserIDIns { get; set; }
        public Guid UserIdMod { get; set; }
        public int Idtipodriver { get; set; }
        public DateTime Dataassunzione { get; set; }
        public DateTime Datanascita { get; set; }
        public DateTime Dataemissione { get; set; }
        public DateTime Datascadenza { get; set; }
        public DateTime Datainiziovalidita { get; set; }
        public DateTime Dataprevistadimissione { get; set; }
        public DateTime Datadimissioni { get; set; }
        public DateTime Datainviomail { get; set; }
        public int Perccdc { get; set; }
        public int Perccdc2 { get; set; }
        public int Perccdc3 { get; set; }
        public Guid Uidtenant { get; set; }
        public int Status { get; set; }

        private string _codsocieta = _stringEmpty;
        private string _cognome = _stringEmpty;
        private string _nome = _stringEmpty;
        private string _matricola = _stringEmpty;
        private string _idnumber = _stringEmpty;
        private string _funzione = _stringEmpty;
        private string _maternita = _stringEmpty;
        private string _cellulare = _stringEmpty;
        private string _email = _stringEmpty;
        private string _codicecdc = _stringEmpty;
        private string _codicecdc2 = _stringEmpty;
        private string _codicecdc3 = _stringEmpty;
        private string _descrizionecdc = _stringEmpty;
        private string _fasciacarpolicy = _stringEmpty;
        private string _codicesede = _stringEmpty;
        private string _descrizionesede = _stringEmpty;
        private string _luogonascita = _stringEmpty;
        private string _provincianascita = _stringEmpty;
        private string _codicefiscale = _stringEmpty;
        private string _indirizzoresidenza = _stringEmpty;
        private string _localitaresidenza = _stringEmpty;
        private string _provinciaresidenza = _stringEmpty;
        private string _capresidenza = _stringEmpty;
        private string _nrpatente = _stringEmpty;
        private string _ufficioemittente = _stringEmpty;
        private string _matricolaapprovatore = _stringEmpty;
        private string _codicesocietaapprovatore = _stringEmpty;
        private string _codicesettore = _stringEmpty;
        private string _descrizionesettore = _stringEmpty;
        private string _descrizioneapprovatore = _stringEmpty;
        private string _emailapprovatore = _stringEmpty;
        private string _gradecode = _stringEmpty;
        private string _persontype = _stringEmpty;
        private string _indirizzosede = _stringEmpty;
        private string _cittasede = _stringEmpty;
        private string _provinciasede = _stringEmpty;
        private string _capsede = _stringEmpty;
        private string _codicedivisione = _stringEmpty;
        private string _descrizionedivisione = _stringEmpty;
        private string _fasciaimportazione = _stringEmpty;
        private string _annotazioni = _stringEmpty;
        private string _codfornitore = _stringEmpty;

        private string _clientId = _stringEmpty;
        private string _impersonatedUserId = _stringEmpty;
        private string _authServer = _stringEmpty;
        private string _privateKey = _stringEmpty;
        private string _basePath = _stringEmpty;
        private string _accountId = _stringEmpty;
        private string _pingUrl = _stringEmpty;
        private string _signerEmail = _stringEmpty;
        private string _signerName = _stringEmpty;
        private string _signerClientId = _stringEmpty;

        private string _tenant = _stringEmpty;
        private string _Siglasocieta = _stringEmpty;
        private string _Societa = _stringEmpty;
        private string _Grade = _stringEmpty;

        public string Codsocieta { get { return _codsocieta; } set { _codsocieta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cognome { get { return _cognome; } set { _cognome = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nome { get { return _nome; } set { _nome = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Matricola { get { return _matricola; } set { _matricola = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Idnumber { get { return _idnumber; } set { _idnumber = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Funzione { get { return _funzione; } set { _funzione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Maternita { get { return _maternita; } set { _maternita = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cellulare { get { return _cellulare; } set { _cellulare = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Email { get { return _email; } set { _email = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicecdc { get { return _codicecdc; } set { _codicecdc = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicecdc2 { get { return _codicecdc2; } set { _codicecdc2 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicecdc3 { get { return _codicecdc3; } set { _codicecdc3 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Descrizionecdc { get { return _descrizionecdc; } set { _descrizionecdc = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fasciacarpolicy { get { return _fasciacarpolicy; } set { _fasciacarpolicy = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicesede { get { return _codicesede; } set { _codicesede = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Descrizionesede { get { return _descrizionesede; } set { _descrizionesede = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Luogonascita { get { return _luogonascita; } set { _luogonascita = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Provincianascita { get { return _provincianascita; } set { _provincianascita = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicefiscale { get { return _codicefiscale; } set { _codicefiscale = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Indirizzoresidenza { get { return _indirizzoresidenza; } set { _indirizzoresidenza = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Localitaresidenza { get { return _localitaresidenza; } set { _localitaresidenza = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Provinciaresidenza { get { return _provinciaresidenza; } set { _provinciaresidenza = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Capresidenza { get { return _capresidenza; } set { _capresidenza = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nrpatente { get { return _nrpatente; } set { _nrpatente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Ufficioemittente { get { return _ufficioemittente; } set { _ufficioemittente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Matricolaapprovatore { get { return _matricolaapprovatore; } set { _matricolaapprovatore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicesocietaapprovatore { get { return _codicesocietaapprovatore; } set { _codicesocietaapprovatore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicesettore { get { return _codicesettore; } set { _codicesettore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Descrizionesettore { get { return _descrizionesettore; } set { _descrizionesettore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Descrizioneapprovatore { get { return _descrizioneapprovatore; } set { _descrizioneapprovatore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Emailapprovatore { get { return _emailapprovatore; } set { _emailapprovatore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Gradecode { get { return _gradecode; } set { _gradecode = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Persontype { get { return _persontype; } set { _persontype = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Indirizzosede { get { return _indirizzosede; } set { _indirizzosede = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cittasede { get { return _cittasede; } set { _cittasede = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Provinciasede { get { return _provinciasede; } set { _provinciasede = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Capsede { get { return _capsede; } set { _capsede = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicedivisione { get { return _codicedivisione; } set { _codicedivisione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Descrizionedivisione { get { return _descrizionedivisione; } set { _descrizionedivisione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fasciaimportazione { get { return _fasciaimportazione; } set { _fasciaimportazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Annotazioni { get { return _annotazioni; } set { _annotazioni = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codfornitore { get { return _codfornitore; } set { _codfornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        public string Siglasocieta { get { return _Siglasocieta; } set { _Siglasocieta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Societa { get { return _Societa; } set { _Societa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Grade { get { return _Grade; } set { _Grade = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        // JWT
        public string ClientId { get { return _clientId; } set { _clientId = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string ImpersonatedUserId { get { return _impersonatedUserId; } set { _impersonatedUserId = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string AuthServer { get { return _authServer; } set { _authServer = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string PrivateKey { get { return _privateKey; } set { _privateKey = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        // SIGN
        public string BasePath { get { return _basePath; } set { _basePath = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string AccountId { get { return _accountId; } set { _accountId = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string PingUrl { get { return _pingUrl; } set { _pingUrl = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string SignerEmail { get { return _signerEmail; } set { _signerEmail = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string SignerName { get { return _signerName; } set { _signerName = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string SignerClientId { get { return _signerClientId; } set { _signerClientId = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        public string Tenant { get { return _tenant; } set { _tenant = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_userstatus


        private string _statusutente = _stringEmpty;
        public string Statusutente { get { return _statusutente; } set { _statusutente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_gruppi

        private string _gruppouser = _stringEmpty;
        public string Gruppouser { get { return _gruppouser; } set { _gruppouser = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_team e menu relativo

        public int Idteam { get; set; }
        public int Idpagina { get; set; }
        public int Autorizzatore { get; set; }

        private string _team = _stringEmpty;
        private string _stato = _stringEmpty;
        private string _gruppo = _stringEmpty;
        private string _codgruppopagina = _stringEmpty;
        private string _icona = _stringEmpty;
        private string _pagina = _stringEmpty;
        private string _linkpagina = _stringEmpty;

        public string Team { get { return _team; } set { _team = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Stato { get { return _stato; } set { _stato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Gruppo { get { return _gruppo; } set { _gruppo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codgruppopagina { get { return _codgruppopagina; } set { _codgruppopagina = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Icona { get { return _icona; } set { _icona = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Pagina { get { return _pagina; } set { _pagina = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Linkpagina { get { return _linkpagina; } set { _linkpagina = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_users_segnalazioni

        private string _segnalazione = _stringEmpty;
        public string Segnalazione { get { return _segnalazione; } set { _segnalazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_users_fuelcard

        public int Iduserfuel { get; set; }
        public int Idcompagnia { get; set; }
        public DateTime Scadenza { get; set; }
        public DateTime Dataattivazione { get; set; }

        private string _targa = _stringEmpty;
        private string _numero = _stringEmpty;
        private string _pin = _stringEmpty;
        private string _compagnia = _stringEmpty;
        public string Targa { get { return _targa; } set { _targa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numero { get { return _numero; } set { _numero = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Pin { get { return _pin; } set { _pin = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Compagnia { get { return _compagnia; } set { _compagnia = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_users_fuel_plafond

        public int Idplafond { get; set; }
        public DateTime Datarilevazione { get; set; }
        public decimal Plafond { get; set; }
        public decimal Delta { get; set; }

        //********************************************  parametri EF_tenant

        private string _Logo = _stringEmpty;
        private string _Bgbarratop = _stringEmpty;
        private string _Bgbarrasx = _stringEmpty;
        private string _Colormenusx = _stringEmpty;
        private string _Urltenant = _stringEmpty;
        private string _Oggettomail = _stringEmpty;
        public string Logo { get { return _Logo; } set { _Logo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Bgbarratop { get { return _Bgbarratop; } set { _Bgbarratop = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Bgbarrasx { get { return _Bgbarrasx; } set { _Bgbarrasx = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Colormenusx { get { return _Colormenusx; } set { _Colormenusx = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Urltenant { get { return _Urltenant; } set { _Urltenant = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Oggettomail { get { return _Oggettomail; } set { _Oggettomail = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


    }
}
