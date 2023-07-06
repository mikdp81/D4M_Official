// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Contratti.cs" company="">
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
   
    public class Contratti : IContratti
    {
        public static string _stringEmpty = string.Empty;

        //********************************************  parametri generici

        public Guid Uid { get; set; }
        public Guid UserIDIns { get; set; }
        public Guid UserIdMod { get; set; }
        public DateTime Datauserins { get; set; }
        public DateTime Datausermod { get; set; }
        public Guid Uidtenant { get; set; }
        public DateTime Dataassunzione { get; set; }
        public int Giorniconsegnaagg { get; set; }
        public decimal Spesepagamento { get; set; }
        public int Checkassegnatario { get; set; }

        private string _matricola = _stringEmpty;
        private string _cellulare = _stringEmpty;
        private string _email = _stringEmpty;
        private string _denominazione = _stringEmpty;
        private string _nome = _stringEmpty;
        private string _marca = _stringEmpty;
        private string _modello = _stringEmpty;
        private string _cilindrata = _stringEmpty;
        private string _alimentazione = _stringEmpty;
        private string _cognome = _stringEmpty;
        private string _fotoauto = _stringEmpty;
        private string _sedelavoro = _stringEmpty;
        private string _compagnia = _stringEmpty;
        private string _excodcarpolicy = _stringEmpty;
        private string _fasciacarpolicy = _stringEmpty;
        private string _cambio = _stringEmpty;
        private string _codcolore = _stringEmpty;
        public string Matricola { get { return _matricola; } set { _matricola = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cellulare { get { return _cellulare; } set { _cellulare = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Email { get { return _email; } set { _email = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Denominazione { get { return _denominazione; } set { _denominazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nome { get { return _nome; } set { _nome = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Marca { get { return _marca; } set { _marca = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Modello { get { return _modello; } set { _modello = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cilindrata { get { return _cilindrata; } set { _cilindrata = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Alimentazione { get { return _alimentazione; } set { _alimentazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cognome { get { return _cognome; } set { _cognome = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fotoauto { get { return _fotoauto; } set { _fotoauto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Sedelavoro { get { return _sedelavoro; } set { _sedelavoro = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Compagnia { get { return _compagnia; } set { _compagnia = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Excodcarpolicy { get { return _excodcarpolicy; } set { _excodcarpolicy = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fasciacarpolicy { get { return _fasciacarpolicy; } set { _fasciacarpolicy = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cambio { get { return _cambio; } set { _cambio = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codcolore { get { return _codcolore; } set { _codcolore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_contratti

        public int Idcontratto { get; set; }
        public Guid UserId { get; set; }
        public DateTime Datacontratto { get; set; }
        public int Duratamesi { get; set; }
        public int Kmcontratto { get; set; }
        public decimal Franchigia { get; set; }
        public DateTime Datainiziocontratto { get; set; }
        public DateTime Datainiziouso { get; set; }
        public DateTime Datafinecontratto { get; set; }
        public decimal Canoneleasing { get; set; }
        public decimal Canoneleasingofferta { get; set; }
        public int Idstatuscontratto { get; set; }
        public Guid Uidordine { get; set; }
        public DateTime Dataimmatricolazione { get; set; }
        public decimal Bollo { get; set; }
        public decimal Superbollo { get; set; }
        public DateTime Scadenzabollo { get; set; }
        public DateTime Scadenzasuperbollo { get; set; }
        public int Flgvoltura { get; set; }
        public Guid Uidcontrattovolturato { get; set; }
        public int Idtipoassegnazione { get; set; }
        public decimal Emissioni { get; set; }
        public int Templateabb { get; set; }
        public DateTime Datarifabb { get; set; }
        public decimal Canonefinanziario { get; set; }
        public decimal Canoneservizi { get; set; }
        public decimal Costokmeccedente { get; set; }
        public decimal Costokmrimborso { get; set; }
        public decimal Sogliakm { get; set; }
        public int Checkpool { get; set; }
        public int Idstatuspool { get; set; }
        public int Checkordinepool { get; set; }
        public DateTime Datarevisione { get; set; }
        public Guid UserIdpool { get; set; }
        public DateTime Datafirma { get; set; }
        public int Idtipomodulo { get; set; }
        public decimal Quotadriver { get; set; }
        public decimal Quotasocieta { get; set; }
        public int Flglibrettoinviato { get; set; }
        public int Riparazione { get; set; }

        private string _codsocieta = _stringEmpty;
        private string _codjatoauto = _stringEmpty;
        private string _codcarpolicy = _stringEmpty;
        private string _codcarlist = _stringEmpty;
        private string _codfornitore = _stringEmpty;
        private string _codtipocontratto = _stringEmpty;
        private string _codtipousocontratto = _stringEmpty;
        private string _numordineordine = _stringEmpty;
        private string _numeroordinefornitore = _stringEmpty;
        private string _numerocontratto = _stringEmpty;
        private string _annotazionicontratto = _stringEmpty;
        private string _filecontratto = _stringEmpty;
        private string _tipocontratto = _stringEmpty;
        private string _fornitore = _stringEmpty;
        private string _notevoltura = _stringEmpty;
        private string _oraconsegna = _stringEmpty;
        private string _luogoconsegna = _stringEmpty;
        private string _tipousocontratto = _stringEmpty;
        private string _tipoassegnazione = _stringEmpty;
        private string _divisa = _stringEmpty;
        private string _naturaiva = _stringEmpty;
        private string _ivatemplate = _stringEmpty;
        private string _descrizionetemplate = _stringEmpty;
        private string _codcompany = _stringEmpty;
        private string _periodo = _stringEmpty;
        private string _gradepool =_stringEmpty;
        private string _notepool =_stringEmpty;
        private string _statuspool = _stringEmpty;
        private string _documentopatente = _stringEmpty;
        private string _modulodafirmare = _stringEmpty;
        private string _modulofirmato = _stringEmpty;
        private string _motivazione = _stringEmpty;
        private string _noteconsegna = _stringEmpty;
        private string _noterestituzione = _stringEmpty;
        private string _Kwcvcontratto = _stringEmpty;
        private string _Alimentazionecontratto = _stringEmpty;
        private string _Cilindratacontratto = _stringEmpty;
        private string _Filelibrettoautocontratto = _stringEmpty;
        public string Codsocieta { get { return _codsocieta; } set { _codsocieta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codjatoauto { get { return _codjatoauto; } set { _codjatoauto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codcarpolicy { get { return _codcarpolicy; } set { _codcarpolicy = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codcarlist { get { return _codcarlist; } set { _codcarlist = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codfornitore { get { return _codfornitore; } set { _codfornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codtipocontratto { get { return _codtipocontratto; } set { _codtipocontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codtipousocontratto { get { return _codtipousocontratto; } set { _codtipousocontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numordineordine { get { return _numordineordine; } set { _numordineordine = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numeroordinefornitore { get { return _numeroordinefornitore; } set { _numeroordinefornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numerocontratto { get { return _numerocontratto; } set { _numerocontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Annotazionicontratto { get { return _annotazionicontratto; } set { _annotazionicontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filecontratto { get { return _filecontratto; } set { _filecontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipocontratto { get { return _tipocontratto; } set { _tipocontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fornitore { get { return _fornitore; } set { _fornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Notevoltura { get { return _notevoltura; } set { _notevoltura = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Oraconsegna { get { return _oraconsegna; } set { _oraconsegna = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Luogoconsegna { get { return _luogoconsegna; } set { _luogoconsegna = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipousocontratto { get { return _tipousocontratto; } set { _tipousocontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipoassegnazione { get { return _tipoassegnazione; } set { _tipoassegnazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Divisa { get { return _divisa; } set { _divisa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Naturaiva { get { return _naturaiva; } set { _naturaiva = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Ivatemplate { get { return _ivatemplate; } set { _ivatemplate = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Descrizionetemplate { get { return _descrizionetemplate; } set { _descrizionetemplate = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codcompany { get { return _codcompany; } set { _codcompany = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Periodo { get { return _periodo; } set { _periodo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Gradepool { get { return _gradepool; } set { _gradepool = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Notepool { get { return _notepool; } set { _notepool = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Statuspool { get { return _statuspool; } set { _statuspool = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Documentopatente { get { return _documentopatente; } set { _documentopatente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Modulodafirmare { get { return _modulodafirmare; } set { _modulodafirmare = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Modulofirmato { get { return _modulofirmato; } set { _modulofirmato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Motivazione { get { return _motivazione; } set { _motivazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Noteconsegna { get { return _noteconsegna; } set { _noteconsegna = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Noterestituzione { get { return _noterestituzione; } set { _noterestituzione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Kwcvcontratto { get { return _Kwcvcontratto; } set { _Kwcvcontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Alimentazionecontratto { get { return _Alimentazionecontratto; } set { _Alimentazionecontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cilindratacontratto { get { return _Cilindratacontratto; } set { _Cilindratacontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filelibrettoautocontratto { get { return _Filelibrettoautocontratto; } set { _Filelibrettoautocontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_contratti_status

        private string _statuscontratto = _stringEmpty;
        public string Statuscontratto { get { return _statuscontratto; } set { _statuscontratto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_ordini

        public int Idordine { get; set; }
        public DateTime Dataordine { get; set; }
        public int Idstatusordine { get; set; }
        public DateTime Dataprimaconsegnaprevista { get; set; }
        public DateTime Dataconsegnaprevista { get; set; }
        public DateTime Dataconsegnaprevistaupdate { get; set; }
        public DateTime Dataconfermaricezione { get; set; }
        public DateTime Datainviolink { get; set; }
        public decimal Deltacanone { get; set; }
        public DateTime Data10 { get; set; }
        public DateTime Data20 { get; set; }
        public DateTime Data25 { get; set; }
        public DateTime Data30 { get; set; }
        public DateTime Data40 { get; set; }
        public DateTime Data50 { get; set; }
        public DateTime Data55 { get; set; }
        public DateTime Data60 { get; set; }
        public DateTime Data100 { get; set; }
        public DateTime Data110 { get; set; }
        public DateTime Dataconsegna { get; set; }


        private string _annotazioniordini = _stringEmpty;
        private string _annotazioniordinirenter = _stringEmpty;
        private string _numeroordine = _stringEmpty;
        private string _societa = _stringEmpty;
        private string _grade = _stringEmpty;
        private string _motivoscarto = _stringEmpty;
        private string _filefirma = _stringEmpty;
        private string _fileconfermarental = _stringEmpty;
        private string _filerifiutoauto = _stringEmpty;
        private string _fileverbaleauto = _stringEmpty;
        private string _filelibrettoauto = _stringEmpty;
        private string _motivorifiutoauto = _stringEmpty;
        private string _flgaccettato = _stringEmpty;
        private string _fileordinepdf = _stringEmpty;
        public string Annotazioniordini { get { return _annotazioniordini; } set { _annotazioniordini = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Annotazioniordinirenter { get { return _annotazioniordinirenter; } set { _annotazioniordinirenter = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numeroordine { get { return _numeroordine; } set { _numeroordine = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Societa { get { return _societa; } set { _societa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Grade { get { return _grade; } set { _grade = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Motivoscarto { get { return _motivoscarto; } set { _motivoscarto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filefirma { get { return _filefirma; } set { _filefirma = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fileconfermarental { get { return _fileconfermarental; } set { _fileconfermarental = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filerifiutoauto { get { return _filerifiutoauto; } set { _filerifiutoauto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fileverbaleauto { get { return _fileverbaleauto; } set { _fileverbaleauto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filelibrettoauto { get { return _filelibrettoauto; } set { _filelibrettoauto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Motivorifiutoauto { get { return _motivorifiutoauto; } set { _motivorifiutoauto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Flgaccettato { get { return _flgaccettato; } set { _flgaccettato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fileordinepdf { get { return _fileordinepdf; } set { _fileordinepdf = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_ordini_status

        private string _statusordine = _stringEmpty;
        public string Statusordine { get { return _statusordine; } set { _statusordine = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        
        //********************************************  parametri EF_contratti_assegnazioni
       
        public int Idassegnazione { get; set; }
        public int Idstatusassegnazione { get; set; }
        public DateTime Assegnatodal { get; set; }
        public DateTime Assegnatoal { get; set; }
        public DateTime Datarestituzione { get; set; }
        public int Idstatoauto { get; set; }
        public DateTime Datacambiogomme { get; set; }
        public decimal Kmrestituzione { get; set; }

        private string _targa = _stringEmpty;
        private string _orarestituzione = _stringEmpty;
        private string _luogorestituzione = _stringEmpty;
        private string _centrorestituzione = _stringEmpty;
        private string _fileverbaleconsegna = _stringEmpty;
        private string _filerelazioneperito = _stringEmpty;
        private string _filedenunce = _stringEmpty;
        private string _noteamministrazione = _stringEmpty;
        private string _notedriver = _stringEmpty;
        private string _checkdoc = _stringEmpty;
        private string _statoauto = _stringEmpty;
        private string _tipogomme = _stringEmpty;
        private string _luogogomme = _stringEmpty;

        public string Targa { get { return _targa; } set { _targa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Orarestituzione { get { return _orarestituzione; } set { _orarestituzione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Luogorestituzione { get { return _luogorestituzione; } set { _luogorestituzione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Centrorestituzione { get { return _centrorestituzione; } set { _centrorestituzione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fileverbaleconsegna { get { return _fileverbaleconsegna; } set { _fileverbaleconsegna = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filerelazioneperito { get { return _filerelazioneperito; } set { _filerelazioneperito = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filedenunce { get { return _filedenunce; } set { _filedenunce = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Noteamministrazione { get { return _noteamministrazione; } set { _noteamministrazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Notedriver { get { return _notedriver; } set { _notedriver = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Checkdoc { get { return _checkdoc; } set { _checkdoc = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Statoauto { get { return _statoauto; } set { _statoauto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipogomme { get { return _tipogomme; } set { _tipogomme = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Luogogomme { get { return _luogogomme; } set { _luogogomme = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_contratti_assegnazioni_status

        private string _statusassegnazione = _stringEmpty;
        public string Statusassegnazione { get { return _statusassegnazione; } set { _statusassegnazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_users_carpolicy

        public int Idapprovazione { get; set; }
        public int Idutente { get; set; }
        public int Idapprovatore { get; set; }
        public DateTime Dataapprovazione { get; set; }
        public DateTime Datamail{ get; set; }
        public int Approvato { get; set; }
        public int Nconfigurazioni { get; set; }
        public DateTime Datadocpolicy { get; set; }
        public DateTime Datadecorrenza { get; set; }
        public Guid Idutentecheck { get; set; }
        public DateTime Datacheck { get; set; }
        public DateTime Datarinuncia { get; set; }
        public DateTime Datafinedecorrenza { get; set; }
        public DateTime Datasceltabenefit { get; set; }


        private string _flgmail = _stringEmpty;
        private string _preassegnazione = _stringEmpty;
        private string _documentocarpolicy = _stringEmpty;
        private string _documentofuelcard = _stringEmpty;
        private string _checkcarpolicy = _stringEmpty;
        private string _sceltabenefit = _stringEmpty;
        private string _codpacchetto = _stringEmpty;
        private string _codcarbenefit = _stringEmpty;
        private string _carbenefit = _stringEmpty;

        public string Flgmail { get { return _flgmail; } set { _flgmail = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Preassegnazione { get { return _preassegnazione; } set { _preassegnazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Documentocarpolicy { get { return _documentocarpolicy; } set { _documentocarpolicy = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Documentofuelcard { get { return _documentofuelcard; } set { _documentofuelcard = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Checkcarpolicy { get { return _checkcarpolicy; } set { _checkcarpolicy = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Sceltabenefit { get { return _sceltabenefit; } set { _sceltabenefit = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codpacchetto { get { return _codpacchetto; } set { _codpacchetto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codcarbenefit { get { return _codcarbenefit; } set { _codcarbenefit = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Carbenefit { get { return _carbenefit; } set { _carbenefit = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_ordini_optional

        public decimal Importooptional { get; set; }

        private string _codoptional = _stringEmpty;
        public string Codoptional { get { return _codoptional; } set { _codoptional = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_contratti_percorrenze
        public decimal Kmpercorsi { get; set; }
        public DateTime Datains { get; set; }


        //********************************************  parametri EF_documenti_deleghe

        public int Iddelega { get; set; }
        public DateTime Datanascita { get; set; }
        public DateTime Datarilasciopatente { get; set; }
        public DateTime Scadenzapatente { get; set; }
        public DateTime Datanascitadelegato { get; set; }
        public DateTime Datarilasciopatentedelegato { get; set; }
        public DateTime Scadenzapatentedelegato { get; set; }
        public DateTime Datadocumento { get; set; }
        public DateTime Datarichiesta { get; set; }


        private string _luogonascita = _stringEmpty;
        private string _indirizzoresidenza = _stringEmpty;
        private string _civicoresidenza = _stringEmpty;
        private string _cittaresidenza = _stringEmpty;
        private string _nrpatente = _stringEmpty;
        private string _entepatente = _stringEmpty;
        private string _tipoutente = _stringEmpty;
        private string _denominazionedelegato = _stringEmpty;
        private string _luogonascitadelegato = _stringEmpty;
        private string _indirizzoresidenzadelegato = _stringEmpty;
        private string _civicoresidenzadelegato = _stringEmpty;
        private string _cittaresidenzadelegato = _stringEmpty;
        private string _nrpatentedelegato = _stringEmpty;
        private string _entepatentedelegato = _stringEmpty;
        private string _veicolo = _stringEmpty;
        private string _filepdf = _stringEmpty;
        private string _luogodocumento = _stringEmpty;
        private string _moduloconvivenza = _stringEmpty;
        public string Luogonascita { get { return _luogonascita; } set { _luogonascita = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Indirizzoresidenza { get { return _indirizzoresidenza; } set { _indirizzoresidenza = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Civicoresidenza { get { return _civicoresidenza; } set { _civicoresidenza = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cittaresidenza { get { return _cittaresidenza; } set { _cittaresidenza = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nrpatente { get { return _nrpatente; } set { _nrpatente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Entepatente { get { return _entepatente; } set { _entepatente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipoutente { get { return _tipoutente; } set { _tipoutente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Denominazionedelegato { get { return _denominazionedelegato; } set { _denominazionedelegato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Luogonascitadelegato { get { return _luogonascitadelegato; } set { _luogonascitadelegato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Indirizzoresidenzadelegato { get { return _indirizzoresidenzadelegato; } set { _indirizzoresidenzadelegato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Civicoresidenzadelegato { get { return _civicoresidenzadelegato; } set { _civicoresidenzadelegato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cittaresidenzadelegato { get { return _cittaresidenzadelegato; } set { _cittaresidenzadelegato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nrpatentedelegato { get { return _nrpatentedelegato; } set { _nrpatentedelegato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Entepatentedelegato { get { return _entepatentedelegato; } set { _entepatentedelegato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Veicolo { get { return _veicolo; } set { _veicolo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filepdf { get { return _filepdf; } set { _filepdf = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Luogodocumento { get { return _luogodocumento; } set { _luogodocumento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Moduloconvivenza { get { return _moduloconvivenza; } set { _moduloconvivenza = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_configurazioni_partner
        public int Idconfigurazione { get; set; }
        public int Idallegato { get; set; }
        public DateTime Datainviato { get; set; }
        private string _Testo = _stringEmpty;
        private string _Allegato = _stringEmpty;
        public string Testo { get { return _Testo; } set { _Testo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Allegato { get { return _Allegato; } set { _Allegato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        public int Flgemailmulte { get; set; }
        public int Flgemailpenali { get; set; }
        public int Flgemailticket { get; set; }

        //********************************************  parametri tracciati fatture (tab. EF_fatturexml)

        public int Idfattura { get; set; }
        public decimal Importototale { get; set; }
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
        public DateTime Datainizioperiodo2 { get; set; }
        public DateTime Datafineperiodo2 { get; set; }
        public DateTime Datainizioperiodo3 { get; set; }
        public DateTime Datafineperiodo3 { get; set; }
        public DateTime Datainizioperiodo4 { get; set; }
        public DateTime Datafineperiodo4 { get; set; }
        public Guid Uidcentrocosto { get; set; }
        public Guid Uidcentrocosto2 { get; set; }
        public Guid Uidcentrocosto3 { get; set; }
        public Guid Uidcentrocosto4 { get; set; }

        public int Idtemplatefattura { get; set; }
        public int Anno { get; set; }
        public int Mese { get; set; }
        public decimal Fringebenefit { get; set; }
        public decimal Fringebenefitbase { get; set; }
        public int Idstatusfattura { get; set; }
        public decimal Canonefigurativo { get; set; }


        private string _tipodocumento = _stringEmpty;
        private string _codcommittente = _stringEmpty;
        private string _committente = _stringEmpty;
        private string _numerodocumento = _stringEmpty;

        private string _descrizione = _stringEmpty;
        private string _tipodato = _stringEmpty;
        private string _riftesto = _stringEmpty;
        private string _centrocostoabb = _stringEmpty;
        private string _tipocentrocosto = _stringEmpty;
        private string _centrocostoabb2 = _stringEmpty;
        private string _tipocentrocosto2 = _stringEmpty;
        private string _centrocostoabb3 = _stringEmpty;
        private string _tipocentrocosto3 = _stringEmpty;
        private string _centrocostoabb4 = _stringEmpty;
        private string _tipocentrocosto4 = _stringEmpty;

        private string _filexml = _stringEmpty;
        private string _nometemplate = _stringEmpty;
        private string _notetemplate = _stringEmpty;
        private string _codicecdc = _stringEmpty;
        private string _nomefile = _stringEmpty;
        private string _tipofile = _stringEmpty;
        private string _statusfattura = _stringEmpty;
        private string _Erratasederestituzione = _stringEmpty;
        private string _Erratarestituzionegomme = _stringEmpty;
        private string _Penaledenuncia = _stringEmpty;

        public string Tipodocumento { get { return _tipodocumento; } set { _tipodocumento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codcommittente { get { return _codcommittente; } set { _codcommittente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Committente { get { return _committente; } set { _committente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numerodocumento { get { return _numerodocumento; } set { _numerodocumento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        public string Descrizione { get { return _descrizione; } set { _descrizione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipodato { get { return _tipodato; } set { _tipodato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Riftesto { get { return _riftesto; } set { _riftesto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Centrocostoabb { get { return _centrocostoabb; } set { _centrocostoabb = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipocentrocosto { get { return _tipocentrocosto; } set { _tipocentrocosto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Centrocostoabb2 { get { return _centrocostoabb2; } set { _centrocostoabb2 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipocentrocosto2 { get { return _tipocentrocosto2; } set { _tipocentrocosto2 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Centrocostoabb3 { get { return _centrocostoabb3; } set { _centrocostoabb3 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipocentrocosto3 { get { return _tipocentrocosto3; } set { _tipocentrocosto3 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Centrocostoabb4 { get { return _centrocostoabb4; } set { _centrocostoabb4 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipocentrocosto4 { get { return _tipocentrocosto4; } set { _tipocentrocosto4 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        public string Filexml { get { return _filexml; } set { _filexml = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nometemplate { get { return _nometemplate; } set { _nometemplate = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Notetemplate { get { return _notetemplate; } set { _notetemplate = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicecdc { get { return _codicecdc; } set { _codicecdc = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nomefile { get { return _nomefile; } set { _nomefile = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipofile { get { return _tipofile; } set { _tipofile = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Statusfattura { get { return _statusfattura; } set { _statusfattura = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Erratasederestituzione { get { return _Erratasederestituzione; } set { _Erratasederestituzione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Erratarestituzionegomme { get { return _Erratarestituzionegomme; } set { _Erratarestituzionegomme = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Penaledenuncia { get { return _Penaledenuncia; } set { _Penaledenuncia = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }



        //********************************************  parametri EF_penali

        public DateTime Datafattura { get; set; }
        public decimal Importo { get; set; }
        public int Idtipopenaleauto { get; set; }

        private string _Numerofattura = _stringEmpty;
        private string _Filepenale = _stringEmpty;
        private string _Notificato = _stringEmpty;
        private string _Tipopenaleauto = _stringEmpty;
        public string Numerofattura { get { return _Numerofattura; } set { _Numerofattura = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filepenale { get { return _Filepenale; } set { _Filepenale = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Notificato { get { return _Notificato; } set { _Notificato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipopenaleauto { get { return _Tipopenaleauto; } set { _Tipopenaleauto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        public int Totuser { get; set; }


        //********************************************  parametri tipo utilizzo

        private string _Codutilizzo = _stringEmpty;
        private string _Tipoutilizzo = _stringEmpty;
        public string Codutilizzo { get { return _Codutilizzo; } set { _Codutilizzo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipoutilizzo { get { return _Tipoutilizzo; } set { _Tipoutilizzo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }



        //********************************************  parametri auto servizio

        public decimal Importospese { get; set; }
        public decimal Kminiziali { get; set; }
        public int Autorizzatoadmin { get; set; }

        private string _Scopoviaggio = _stringEmpty;
        private string _Spese = _stringEmpty;
        public string Scopoviaggio { get { return _Scopoviaggio; } set { _Scopoviaggio = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Spese { get { return _Spese; } set { _Spese = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
    }
}
