// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="FileTracciati.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AraneaUtilities.Auth.Roles;
using System;
using System.Runtime.CompilerServices;
using System.Security.Permissions;

namespace BusinessObject
{
    [Serializable]
   
    public class FileTracciati : IFileTracciati
    {
        public const string ROLE_ADMIN = "DFleetAdmin";
        public const string ROLE_USER = "DFleetUser";
        public const string ROLE_GUEST = "DFleetGuest";


        public static string _stringEmpty = string.Empty;

        //********************************************  parametri EF_filecaricati

        public Guid Uid { get; set; }
        public int Idprog { get; set; }
        public int Idtipofile { get; set; }
        public DateTime Datacaricato { get; set; }
        public Guid UserIDIns { get; set; }
        public DateTime Datausermod { get; set; }
        public Guid UserIdMod { get; set; }
        public DateTime Dataimportazione { get; set; }
        public Guid Uidtenant { get; set; }

        private string _nomefile = _stringEmpty;
        private string _denominazione = _stringEmpty;
        private string _importato = _stringEmpty;
        public string Nomefile { get { return _nomefile; } set { _nomefile = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Denominazione { get { return _denominazione; } set { _denominazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Importato { get { return _importato; } set { _importato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_tipofile

        private string _tipofile = _stringEmpty;
        public string Tipofile { get { return _tipofile; } set { _tipofile = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri tracciati carburante (tab. EF_users_fuelcard_consumo)

        public int Idcompagnia { get; set; }
        public int Idcarb { get; set; }
        public DateTime Datatransazione { get; set; }
        public decimal Quantita { get; set; }
        public decimal Prezzo { get; set; }
        public decimal Importo { get; set; }
        public decimal Importoiva { get; set; }
        public string Numerofattura { get; set; }
        public DateTime Datafattura { get; set; }
        public decimal Importofinalefatturato { get; set; }
        public DateTime Datauserins { get; set; }
        public decimal Kmtransazione { get; set; }


        private string _codicepuntovendita = _stringEmpty;
        private string _ragionesociale = _stringEmpty;
        private string _localita = _stringEmpty;
        private string _indirizzo = _stringEmpty;
        private string _nazione = _stringEmpty;
        private string _numerofuelcard = _stringEmpty;
        private string _targa = _stringEmpty;
        private string _idtransazione = _stringEmpty;
        private string _compagnia = _stringEmpty;
        private string _tiporifornimento = _stringEmpty;
        public string Codicepuntovendita { get { return _codicepuntovendita; } set { _codicepuntovendita = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Ragionesociale { get { return _ragionesociale; } set { _ragionesociale = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Localita { get { return _localita; } set { _localita = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Indirizzo { get { return _indirizzo; } set { _indirizzo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nazione { get { return _nazione; } set { _nazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numerofuelcard { get { return _numerofuelcard; } set { _numerofuelcard = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Targa { get { return _targa; } set { _targa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Idtransazione { get { return _idtransazione; } set { _idtransazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Compagnia { get { return _compagnia; } set { _compagnia = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tiporifornimento { get { return _tiporifornimento; } set { _tiporifornimento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri tracciati fringe aci (tab. EF_fringe_aci)

        public int Idfringe { get; set; }
        public decimal Costokm { get; set; }
        public decimal Fringe25 { get; set; }
        public decimal Fringe30 { get; set; }
        public decimal Fringe50 { get; set; }
        public decimal Fringe60 { get; set; }
        public DateTime Periododal { get; set; }
        public DateTime Periodoal { get; set; }


        private string _codjatoauto = _stringEmpty;
        private string _marca = _stringEmpty;
        private string _modello = _stringEmpty;
        private string _serie = _stringEmpty;
        public string Codjatoauto { get { return _codjatoauto; } set { _codjatoauto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Marca { get { return _marca; } set { _marca = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Modello { get { return _modello; } set { _modello = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Serie { get { return _serie; } set { _serie = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri tracciati fatture (tab. EF_fatturexml)

        public int Idfattura { get; set; }
        public DateTime Datadocumento { get; set; }
        public decimal Importototale { get; set; }
        public DateTime Datacontratto { get; set; }
        public decimal Importopagamento { get; set; }
        public DateTime Datascadenzapagamento { get; set; }

        public int Iddettaglio { get; set; }
        public Guid Uidfattura { get; set; }
        public int Numerolionea { get; set; }
        public int QuantitaP { get; set; }
        public decimal Prezzoun { get; set; }
        public decimal Prezzotot { get; set; }
        public decimal Iva { get; set; }
        public DateTime Datainizioperiodo { get; set; }
        public DateTime Datafineperiodo { get; set; }
        public Guid Uidcentrocosto { get; set; }
        public Guid Uidcentrocosto2 { get; set; }
        public decimal Percentuale { get; set; }


        private string _tipodocumento = _stringEmpty;
        private string _codfornitore = _stringEmpty;
        private string _fornitore = _stringEmpty;
        private string _codcommittente = _stringEmpty;
        private string _committente = _stringEmpty;
        private string _numerodocumento = _stringEmpty;
        private string _numerocontratto = _stringEmpty;

        private string _descrizione = _stringEmpty;
        private string _tipodato = _stringEmpty;
        private string _riftesto = _stringEmpty;
        private string _centrocostoabb = _stringEmpty;
        private string _tipocentrocosto = _stringEmpty;
        private string _centrocostoabb2 = _stringEmpty;
        private string _tipocentrocosto2 = _stringEmpty; 
        private string _filexml = _stringEmpty;
        private string _divisa = _stringEmpty;
        private string _naturaiva = _stringEmpty;

        public string Tipodocumento { get { return _tipodocumento; } set { _tipodocumento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codfornitore { get { return _codfornitore; } set { _codfornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fornitore { get { return _fornitore; } set { _fornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codcommittente { get { return _codcommittente; } set { _codcommittente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Committente { get { return _committente; } set { _committente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numerodocumento { get { return _numerodocumento; } set { _numerodocumento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numerocontratto { get { return _numerocontratto; } set { _numerocontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        public string Descrizione { get { return _descrizione; } set { _descrizione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipodato { get { return _tipodato; } set { _tipodato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Riftesto { get { return _riftesto; } set { _riftesto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Centrocostoabb { get { return _centrocostoabb; } set { _centrocostoabb = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipocentrocosto { get { return _tipocentrocosto; } set { _tipocentrocosto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Centrocostoabb2 { get { return _centrocostoabb2; } set { _centrocostoabb2 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipocentrocosto2 { get { return _tipocentrocosto2; } set { _tipocentrocosto2 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filexml { get { return _filexml; } set { _filexml = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Divisa { get { return _divisa; } set { _divisa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Naturaiva { get { return _naturaiva; } set { _naturaiva = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri tracciati anagrafiche (tab. EF_users)

        public int Iduser { get; set; }
        public Guid UserId { get; set; }
        public int Idtipodriver { get; set; }
        public DateTime Dataassunzione { get; set; }
        public DateTime Datanascita { get; set; }
        public DateTime Dataemissione { get; set; }
        public DateTime Datascadenza { get; set; }
        public DateTime Datainiziovalidita { get; set; }
        public DateTime Dataprevistadimissione { get; set; }
        public DateTime Datadimissioni { get; set; }
        public int Flgdriver { get; set; }
        public int Idgruppouser { get; set; }
        public int Idstatususer { get; set; }
        public int Flgadmin { get; set; }

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



        //********************************************  parametri tracciati concur (tab. EF_concur)


        public DateTime Dataspesa { get; set; }
        public decimal Distanza { get; set; }
        public decimal Rimborso { get; set; }
        public decimal Importospesa { get; set; }
        public decimal Importodeducibile { get; set; }


        private string _tipologiaspesa = _stringEmpty;
        private string _codcompany = _stringEmpty;
        private string _codservice = _stringEmpty;
        private string _chiave = _stringEmpty;
        private string _tracciato = _stringEmpty;
        public string Tipologiaspesa { get { return _tipologiaspesa; } set { _tipologiaspesa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codcompany { get { return _codcompany; } set { _codcompany = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codservice { get { return _codservice; } set { _codservice = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Chiave { get { return _chiave; } set { _chiave = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tracciato { get { return _tracciato; } set { _tracciato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri tracciati telepass (tab. EF_users_telepass_consumo)

        public int Idtelep { get; set; }
        public DateTime Dataora { get; set; }

        private string _dispositivo = _stringEmpty;
        private string _numerodispositivo = _stringEmpty;
        private string _classe = _stringEmpty;
        public string Dispositivo { get { return _dispositivo; } set { _dispositivo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numerodispositivo { get { return _numerodispositivo; } set { _numerodispositivo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Classe { get { return _classe; } set { _classe = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }



        //********************************************  parametri EF_importazioni_storico

        private string _Texterrori = _stringEmpty;
        private string _Cartellaimport = _stringEmpty;
        public int Righeimportate { get; set; }
        public int Righetotali { get; set; }
        public string Texterrori { get { return _Texterrori; } set { _Texterrori = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cartellaimport { get { return _Cartellaimport; } set { _Cartellaimport = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        private string _Campo1 = _stringEmpty;
        private string _Campo2 = _stringEmpty;
        private string _Campo3 = _stringEmpty;
        private string _Campo4 = _stringEmpty;
        private string _Campo5 = _stringEmpty;
        private string _Campo6 = _stringEmpty;
        private string _Campo7 = _stringEmpty;
        private string _Modifica = _stringEmpty;
        public string Campo1 { get { return _Campo1; } set { _Campo1 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Campo2 { get { return _Campo2; } set { _Campo2 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Campo3 { get { return _Campo3; } set { _Campo3 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Campo4 { get { return _Campo4; } set { _Campo4 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Campo5 { get { return _Campo5; } set { _Campo5 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Campo6 { get { return _Campo6; } set { _Campo6 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Campo7 { get { return _Campo7; } set { _Campo7 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Modifica { get { return _Modifica; } set { _Modifica = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public int Benefit { get; set; }
        public int Benefitalt { get; set; }
    }
}
