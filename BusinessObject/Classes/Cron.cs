// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Cron.cs" company="">
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
   
    public class Cron : ICron
    {
        public static string _stringEmpty = string.Empty;

        //********************************************  parametri generici

        public Guid Uid { get; set; }
        public Guid UserIDIns { get; set; }
        public Guid UserIdMod { get; set; }
        public Guid UserId { get; set; }
        public DateTime Datauserins { get; set; }
        public DateTime Datausermod { get; set; }
        public Guid Uidtenant { get; set; }
        public int Idcomunicazione { get; set; }
        public DateTime Datainvio { get; set; }
        public Guid UidcomunicazionePadre { get; set; }
        public Guid Uidcomunicazione { get; set; }
        public int Idtemplate { get; set; }
        public int Idapprovazione { get; set; }
        public int Idutente { get; set; }
        public int Idapprovatore { get; set; }
        public DateTime Dataapprovazione { get; set; }
        public DateTime Datamail { get; set; }
        public int Approvato { get; set; }
        public int Idcontratto { get; set; }
        public int Idcron { get; set; }
        public DateTime Data { get; set; }
        public decimal Importo { get; set; }
        public Guid UserIdMittente { get; set; }
        public DateTime Datainizioperiodo { get; set; }
        public DateTime Datafineperiodo { get; set; }
        public int Mese { get; set; }
        public int Anno { get; set; }



        private string _urlblob = _stringEmpty;
        private string _matricola = _stringEmpty;
        private string _nome = _stringEmpty;
        private string _cognome = _stringEmpty;
        private string _tipologiacedolino = _stringEmpty;
        private string _codsocieta = _stringEmpty;
        private string _societa = _stringEmpty;
        private string _codicecdc = _stringEmpty;
        private string _targa = _stringEmpty;
        private string _tipodocumento = _stringEmpty;
        private string _pathfile = _stringEmpty;
        private string _nomefile = _stringEmpty;
        private string _flgmail = _stringEmpty;
        private string _codcarpolicy = _stringEmpty;
        private string _gradecode = _stringEmpty;
        private string _titolo = _stringEmpty;
        private string _oggetto = _stringEmpty;
        private string _corpo = _stringEmpty;
        private string _email = _stringEmpty;
        private string _modello = _stringEmpty;
        private string _codservice = _stringEmpty;
        private string _numerofuelcard = _stringEmpty;

        public string Urlblob { get { return _urlblob; } set { _urlblob = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Matricola { get { return _matricola; } set { _matricola = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nome { get { return _nome; } set { _nome = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cognome { get { return _cognome; } set { _cognome = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipologiacedolino { get { return _tipologiacedolino; } set { _tipologiacedolino = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codsocieta { get { return _codsocieta; } set { _codsocieta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Societa { get { return _societa; } set { _societa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicecdc { get { return _codicecdc; } set { _codicecdc = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Targa { get { return _targa; } set { _targa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipodocumento { get { return _tipodocumento; } set { _tipodocumento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Pathfile { get { return _pathfile; } set { _pathfile = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nomefile { get { return _nomefile; } set { _nomefile = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Flgmail { get { return _flgmail; } set { _flgmail = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codcarpolicy { get { return _codcarpolicy; } set { _codcarpolicy = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Gradecode { get { return _gradecode; } set { _gradecode = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Titolo { get { return _titolo; } set { _titolo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Oggetto { get { return _oggetto; } set { _oggetto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Corpo { get { return _corpo; } set { _corpo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Email { get { return _email; } set { _email = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Modello { get { return _modello; } set { _modello = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codservice { get { return _codservice; } set { _codservice = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numerofuelcard { get { return _numerofuelcard; } set { _numerofuelcard = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_importazioni_storico

        public int Idprog { get; set; }
        public int Idtipofile { get; set; }
        public DateTime Datacaricato { get; set; }
        public DateTime Dataimportazione { get; set; }
        public DateTime Periododal { get; set; }
        public DateTime Periodoal { get; set; }
        public int Righeimportate { get; set; }
        public int Righetotali { get; set; }
        public DateTime Datafattura { get; set; }

        private string _Texterrori = _stringEmpty;
        private string _Cartellaimport = _stringEmpty;
        private string _Importato = _stringEmpty;
        private string _Tipofile = _stringEmpty;
        private string _Idtransazione = _stringEmpty;
        private string _Numerofattura = _stringEmpty;
        public string Texterrori { get { return _Texterrori; } set { _Texterrori = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cartellaimport { get { return _Cartellaimport; } set { _Cartellaimport = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Importato { get { return _Importato; } set { _Importato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipofile { get { return _Tipofile; } set { _Tipofile = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Idtransazione { get { return _Idtransazione; } set { _Idtransazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numerofattura { get { return _Numerofattura; } set { _Numerofattura = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        public DateTime Datatransazione { get; set; }
        public decimal Kmtransazione { get; set; }
        public decimal Quantita { get; set; }
        public decimal Prezzo { get; set; }
        public decimal Importoiva { get; set; }
        public decimal Importofinalefatturato { get; set; }
        public int Idcompagnia { get; set; }
        public int Idfringe { get; set; }
        public decimal Costokm { get; set; }
        public decimal Fringe25 { get; set; }
        public decimal Fringe30 { get; set; }
        public decimal Fringe50 { get; set; }
        public decimal Fringe60 { get; set; }
        public DateTime Datadocumento { get; set; }
        public decimal Importototale { get; set; }
        public DateTime Datacontratto { get; set; }
        public decimal Importopagamento { get; set; }
        public DateTime Datascadenzapagamento { get; set; }
        public Guid Uidfattura { get; set; }
        public int QuantitaP { get; set; }
        public decimal Prezzoun { get; set; }
        public decimal Prezzotot { get; set; }
        public decimal Iva { get; set; }
        public int Numerolionea { get; set; }
        public int Iduser { get; set; }



        private string _Codicepuntovendita = _stringEmpty;
        private string _Ragionesociale = _stringEmpty;
        private string _Localita = _stringEmpty;
        private string _Indirizzo = _stringEmpty;
        private string _Nazione = _stringEmpty;
        private string _Tiporifornimento = _stringEmpty;
        private string _Codjatoauto = _stringEmpty;
        private string _Marca = _stringEmpty;
        private string _Serie = _stringEmpty;
        private string _Divisa = _stringEmpty;
        private string _Numerodocumento = _stringEmpty;
        private string _Fornitore = _stringEmpty;
        private string _Codfornitore = _stringEmpty;
        private string _Committente = _stringEmpty;
        private string _Codcommittente = _stringEmpty;
        private string _Numerocontratto = _stringEmpty;
        private string _Filexml = _stringEmpty;
        private string _Descrizione = _stringEmpty;
        private string _Tipodato = _stringEmpty;
        private string _Riftesto = _stringEmpty;
        private string _Centrocostoabb = _stringEmpty;
        private string _Tipocentrocosto = _stringEmpty;
        private string _Centrocostoabb2 = _stringEmpty;
        private string _Tipocentrocosto2 = _stringEmpty;
        private string _Naturaiva = _stringEmpty;

        public string Codicepuntovendita { get { return _Codicepuntovendita; } set { _Codicepuntovendita = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Ragionesociale { get { return _Ragionesociale; } set { _Ragionesociale = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Localita { get { return _Localita; } set { _Localita = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Indirizzo { get { return _Indirizzo; } set { _Indirizzo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nazione { get { return _Nazione; } set { _Nazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tiporifornimento { get { return _Tiporifornimento; } set { _Tiporifornimento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codjatoauto { get { return _Codjatoauto; } set { _Codjatoauto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Marca { get { return _Marca; } set { _Marca = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Serie { get { return _Serie; } set { _Serie = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Divisa { get { return _Divisa; } set { _Divisa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numerodocumento { get { return _Numerodocumento; } set { _Numerodocumento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fornitore { get { return _Fornitore; } set { _Fornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codfornitore { get { return _Codfornitore; } set { _Codfornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Committente { get { return _Committente; } set { _Committente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codcommittente { get { return _Codcommittente; } set { _Codcommittente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numerocontratto { get { return _Numerocontratto; } set { _Numerocontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filexml { get { return _Filexml; } set { _Filexml = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Descrizione { get { return _Descrizione; } set { _Descrizione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipodato { get { return _Tipodato; } set { _Tipodato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Riftesto { get { return _Riftesto; } set { _Riftesto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Centrocostoabb { get { return _Centrocostoabb; } set { _Centrocostoabb = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipocentrocosto { get { return _Tipocentrocosto; } set { _Tipocentrocosto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Centrocostoabb2 { get { return _Centrocostoabb2; } set { _Centrocostoabb2 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipocentrocosto2 { get { return _Tipocentrocosto2; } set { _Tipocentrocosto2 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Naturaiva { get { return _Naturaiva; } set { _Naturaiva = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }





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


        private string _Idnumber = _stringEmpty;
        private string _Funzione = _stringEmpty;
        private string _Maternita = _stringEmpty;
        private string _Cellulare = _stringEmpty;
        private string _Descrizionecdc = _stringEmpty;
        private string _Codicesede = _stringEmpty;
        private string _Descrizionesede = _stringEmpty;
        private string _Luogonascita = _stringEmpty;
        private string _Provincianascita = _stringEmpty;
        private string _Codicefiscale = _stringEmpty;
        private string _Indirizzoresidenza = _stringEmpty;
        private string _Localitaresidenza = _stringEmpty;
        private string _Provinciaresidenza = _stringEmpty;
        private string _Capresidenza = _stringEmpty;
        private string _Nrpatente = _stringEmpty;
        private string _Ufficioemittente = _stringEmpty;
        private string _Matricolaapprovatore = _stringEmpty;
        private string _Codicesocietaapprovatore = _stringEmpty;
        private string _Codicesettore = _stringEmpty;
        private string _Descrizionesettore = _stringEmpty;
        private string _Descrizioneapprovatore = _stringEmpty;
        private string _Emailapprovatore = _stringEmpty;
        private string _Persontype = _stringEmpty;
        private string _Indirizzosede = _stringEmpty;
        private string _Cittasede = _stringEmpty;
        private string _Provinciasede = _stringEmpty;
        private string _Capsede = _stringEmpty;
        private string _Codicedivisione = _stringEmpty;
        private string _Descrizionedivisione = _stringEmpty;
        private string _Fasciaimportazione = _stringEmpty;
        private string _Annotazioni = _stringEmpty;
        private string _Fasciacarpolicy = _stringEmpty; 
        public string Idnumber { get { return _Idnumber; } set { _Idnumber = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Funzione { get { return _Funzione; } set { _Funzione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Maternita { get { return _Maternita; } set { _Maternita = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cellulare { get { return _Cellulare; } set { _Cellulare = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Descrizionecdc { get { return _Descrizionecdc; } set { _Descrizionecdc = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicesede { get { return _Codicesede; } set { _Codicesede = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Descrizionesede { get { return _Descrizionesede; } set { _Descrizionesede = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Luogonascita { get { return _Luogonascita; } set { _Luogonascita = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Provincianascita { get { return _Provincianascita; } set { _Provincianascita = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicefiscale { get { return _Codicefiscale; } set { _Codicefiscale = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Indirizzoresidenza { get { return _Indirizzoresidenza; } set { _Indirizzoresidenza = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Localitaresidenza { get { return _Localitaresidenza; } set { _Localitaresidenza = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Provinciaresidenza { get { return _Provinciaresidenza; } set { _Provinciaresidenza = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Capresidenza { get { return _Capresidenza; } set { _Capresidenza = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nrpatente { get { return _Nrpatente; } set { _Nrpatente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Ufficioemittente { get { return _Ufficioemittente; } set { _Ufficioemittente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Matricolaapprovatore { get { return _Matricolaapprovatore; } set { _Matricolaapprovatore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicesocietaapprovatore { get { return _Codicesocietaapprovatore; } set { _Codicesocietaapprovatore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicesettore { get { return _Codicesettore; } set { _Codicesettore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Descrizionesettore { get { return _Descrizionesettore; } set { _Descrizionesettore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Descrizioneapprovatore { get { return _Descrizioneapprovatore; } set { _Descrizioneapprovatore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Emailapprovatore { get { return _Emailapprovatore; } set { _Emailapprovatore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Persontype { get { return _Persontype; } set { _Persontype = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Indirizzosede { get { return _Indirizzosede; } set { _Indirizzosede = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cittasede { get { return _Cittasede; } set { _Cittasede = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Provinciasede { get { return _Provinciasede; } set { _Provinciasede = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Capsede { get { return _Capsede; } set { _Capsede = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicedivisione { get { return _Codicedivisione; } set { _Codicedivisione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Descrizionedivisione { get { return _Descrizionedivisione; } set { _Descrizionedivisione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fasciaimportazione { get { return _Fasciaimportazione; } set { _Fasciaimportazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Annotazioni { get { return _Annotazioni; } set { _Annotazioni = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fasciacarpolicy { get { return _Fasciacarpolicy; } set { _Fasciacarpolicy = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }



        public DateTime Dataspesa { get; set; }
        public decimal Distanza { get; set; }
        public decimal Rimborso { get; set; }
        public decimal Importospesa { get; set; }
        public decimal Importodeducibile { get; set; }

        private string _Codcompany = _stringEmpty;
        private string _Tipologiaspesa = _stringEmpty;
        private string _Chiave = _stringEmpty;
        private string _Tracciato = _stringEmpty;
        public string Codcompany { get { return _Codcompany; } set { _Codcompany = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipologiaspesa { get { return _Tipologiaspesa; } set { _Tipologiaspesa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Chiave { get { return _Chiave; } set { _Chiave = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tracciato { get { return _Tracciato; } set { _Tracciato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        private string _Dispositivo = _stringEmpty;
        private string _Numerodispositivo = _stringEmpty;
        private string _Classe = _stringEmpty;
        public DateTime Dataora { get; set; }
        public string Dispositivo { get { return _Dispositivo; } set { _Dispositivo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numerodispositivo { get { return _Numerodispositivo; } set { _Numerodispositivo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Classe { get { return _Classe; } set { _Classe = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }



        private string _Network_user = _stringEmpty;
        private string _Network_password = _stringEmpty;
        public string Network_user { get { return _Network_user; } set { _Network_user = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Network_password { get { return _Network_password; } set { _Network_password = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        public int Flgcron { get; set; }
        public DateTime Datafineimportazione { get; set; }


        private string _Codgrade = _stringEmpty;
        private string _Param1 = _stringEmpty;
        private string _Param2 = _stringEmpty;
        private string _Param3 = _stringEmpty;
        private string _Param4 = _stringEmpty;
        private string _Param5 = _stringEmpty;
        private string _Param6 = _stringEmpty;
        private string _Param7 = _stringEmpty;
        private string _Param8 = _stringEmpty;
        private string _Param9 = _stringEmpty;
        private string _Param10 = _stringEmpty;
        public string Codgrade { get { return _Codgrade; } set { _Codgrade = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Param1 { get { return _Param1; } set { _Param1 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Param2 { get { return _Param2; } set { _Param2 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Param3 { get { return _Param3; } set { _Param3 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Param4 { get { return _Param4; } set { _Param4 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Param5 { get { return _Param5; } set { _Param5 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Param6 { get { return _Param6; } set { _Param6 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Param7 { get { return _Param7; } set { _Param7 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Param8 { get { return _Param8; } set { _Param8 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Param9 { get { return _Param9; } set { _Param9 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Param10 { get { return _Param10; } set { _Param10 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public int Idinvio { get; set; }


        public DateTime Scadenza { get; set; }
        public DateTime Dataattivazione { get; set; }

        private string _Pin = _stringEmpty;
        private string _Statuscard = _stringEmpty;
        private string _Idzucchetti = _stringEmpty;
        private string _Username = _stringEmpty;
        private string _Stato = _stringEmpty;
        private string _Benefit = _stringEmpty;
        public string Pin { get { return _Pin; } set { _Pin = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Statuscard { get { return _Statuscard; } set { _Statuscard = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Idzucchetti { get { return _Idzucchetti; } set { _Idzucchetti = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Username { get { return _Username; } set { _Username = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Stato { get { return _Stato; } set { _Stato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Sceltabenefit { get { return _Benefit; } set { _Benefit = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }




        //********************************************  parametri EF_importazioni_storico

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
