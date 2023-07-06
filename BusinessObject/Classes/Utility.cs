// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Utility.cs" company="">
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
   
    public class Utilitys : IUtilitys
    {
        public static string _stringEmpty = string.Empty;

        //********************************************  parametri generici

        public Guid Uid { get; set; }
        public Guid UserIDIns { get; set; }
        public Guid UserIdMod { get; set; }
        public DateTime Datauserins { get; set; }
        public DateTime Datausermod { get; set; }
        public Guid Uidtenant { get; set; }

        //********************************************  parametri EF_societa

        private string _codsocieta = _stringEmpty;
        private string _codcompany = _stringEmpty;
        private string _siglasocieta = _stringEmpty;
        private string _societa = _stringEmpty;
        private string _servicearea = _stringEmpty;
        private string _partitaiva = _stringEmpty;
        private string _codicecdc = _stringEmpty;
        private string _excodcarpolicy = _stringEmpty;

        public string Codsocieta { get { return _codsocieta; } set { _codsocieta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codcompany { get { return _codcompany; } set { _codcompany = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Siglasocieta { get { return _siglasocieta; } set { _siglasocieta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Societa { get { return _societa; } set { _societa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Servicearea { get { return _servicearea; } set { _servicearea = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Partitaiva { get { return _partitaiva; } set { _partitaiva = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicecdc { get { return _codicecdc; } set { _codicecdc = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Excodcarpolicy { get { return _excodcarpolicy; } set { _excodcarpolicy = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_conti

        private string _codconto = _stringEmpty;
        private string _descrizioneconto = _stringEmpty;
        private string _annotazioni = _stringEmpty;

        public string Codconto { get { return _codconto; } set { _codconto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Descrizioneconto { get { return _descrizioneconto; } set { _descrizioneconto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Annotazioni { get { return _annotazioni; } set { _annotazioni = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_fornitori

        private string _codfornitore = _stringEmpty;
        private string _fornitore = _stringEmpty;

        public string Codfornitore { get { return _codfornitore; } set { _codfornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fornitore { get { return _fornitore; } set { _fornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_fuelcard
                
        public decimal Valorefuelcard { get; set; }
        private string _codfuelcard = _stringEmpty;
        private string _fuelcard = _stringEmpty;

        public string Codfuelcard { get { return _codfuelcard; } set { _codfuelcard = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fuelcard { get { return _fuelcard; } set { _fuelcard = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_grade

        private string _codgrade = _stringEmpty;
        private string _grade = _stringEmpty;

        public string Codgrade { get { return _codgrade; } set { _codgrade = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Grade { get { return _grade; } set { _grade = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_persontype

        private string _codpersontype = _stringEmpty;
        private string _persontype = _stringEmpty;

        public string Codpersontype { get { return _codpersontype; } set { _codpersontype = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Persontype { get { return _persontype; } set { _persontype = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_email_template
        public int Idtemplate { get; set; }

        private string _titolo = _stringEmpty;
        private string _oggetto = _stringEmpty;
        private string _corpo = _stringEmpty;
        public string Titolo { get { return _titolo; } set { _titolo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Oggetto { get { return _oggetto; } set { _oggetto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Corpo { get { return _corpo; } set { _corpo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_comunicazioni_email

        public int Idcomunicazione { get; set; }
        public Guid UserId { get; set; }
        public int Idstatuscomunicazione { get; set; }
        public DateTime Datainvio { get; set; }
        public DateTime Dataricezione { get; set; }

        private string _mittente = _stringEmpty;
        private string _tipocomunicazione = _stringEmpty;
        public string Mittente { get { return _mittente; } set { _mittente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipocomunicazione { get { return _tipocomunicazione; } set { _tipocomunicazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_comunicazioni_status

        private string _statuscomunicazione = _stringEmpty;
        public string Statuscomunicazione { get { return _statuscomunicazione; } set { _statuscomunicazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_cron_file
        public int Idcron { get; set; }
        public DateTime Data { get; set; }


        private string _tipodocumento = _stringEmpty;
        private string _pathfile = _stringEmpty;
        private string _nomefile = _stringEmpty;
        public string Tipodocumento { get { return _tipodocumento; } set { _tipodocumento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Pathfile { get { return _pathfile; } set { _pathfile = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nomefile { get { return _nomefile; } set { _nomefile = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_pagine

        public int Idpagina { get; set; }
        private string _pagina = _stringEmpty;
        public string Pagina { get { return _pagina; } set { _pagina = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_documenti

        public int Iddoc { get; set; }
        public int Idcatdoc { get; set; }
        public DateTime Visibiledal { get; set; }
        public DateTime Visibileal { get; set; }

        private string _nomedocumento = _stringEmpty;
        private string _filedocumento = _stringEmpty;
        private string _codcarpolicy = _stringEmpty;
        private string _categoriadocumento = _stringEmpty;
        public string Nomedocumento { get { return _nomedocumento; } set { _nomedocumento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filedocumento { get { return _filedocumento; } set { _filedocumento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codcarpolicy { get { return _codcarpolicy; } set { _codcarpolicy = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Categoriadocumento { get { return _categoriadocumento; } set { _categoriadocumento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_report

        public int Idreport { get; set; }
        private string _nomereport = _stringEmpty;
        private string _viewreport = _stringEmpty;
        private string _fileexcel = _stringEmpty;
        private string _column = _stringEmpty;
        private string _tipodato = _stringEmpty;
        private string _filtrocodsocieta = _stringEmpty;
        private string _filtrocodgrade = _stringEmpty;
        private string _filtrodriver = _stringEmpty;
        private string _filtrocodfornitore = _stringEmpty;
        public string Nomereport { get { return _nomereport; } set { _nomereport = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Viewreport { get { return _viewreport; } set { _viewreport = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fileexcel { get { return _fileexcel; } set { _fileexcel = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Column { get { return _column; } set { _column = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string TipoDato { get { return _tipodato; } set { _tipodato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filtrocodsocieta { get { return _filtrocodsocieta; } set { _filtrocodsocieta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filtrocodgrade { get { return _filtrocodgrade; } set { _filtrocodgrade = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filtrodriver { get { return _filtrodriver; } set { _filtrodriver = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filtrocodfornitore { get { return _filtrocodfornitore; } set { _filtrocodfornitore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_task

        public int Idtask { get; set; }
        public Guid Uidteam { get; set; }
        public DateTime Datatask { get; set; }
        public int Esitotask { get; set; }

        private string _testotask = _stringEmpty;
        private string _linktask = _stringEmpty;
        public string Testotask { get { return _testotask; } set { _testotask = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Linktask { get { return _linktask; } set { _linktask = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri viste dashboard

        public int Tot { get; set; }
        public int Configurazionidaautorizzare { get; set; }
        public int Offertedainviareadriver { get; set; }
        public int Confermedafirmare { get; set; }
        public int Richiesteautoinpool { get; set; }
        public int Richiesteautoinpool2 { get; set; }
        public int Richiestepreassegnazioni { get; set; }
        public int Richiestevolture { get; set; }
        public int Volturedaautorizzare { get; set; }
        public int Multedaregistrare { get; set; }
        public int Multeconpunti { get; set; }
        public int Fatturedaelaborare { get; set; }
        public int Fringebenefitdacalcolare { get; set; }

        public int Autoincircolazione { get; set; }
        public int Autoinpool { get; set; }
        public int Saldoauto { get; set; }
        public int Meseconsegna { get; set; }
        public int Annoconsegna { get; set; }
        public decimal Kmmedi { get; set; }
        public int Percultimoannokm { get; set; }
        public int Etamedia { get; set; }
        public int Percultimoannoeta { get; set; }
        public int Etamediadriver { get; set; }
        public int Percultimoannoetadriver { get; set; }
        public int Autototali { get; set; }
        public int Ready { get; set; }
        public int Dariparare { get; set; }
        public int Driverattivi { get; set; }
        public int Driverattesaauto { get; set; }
        public int Driverdimissionari { get; set; }

        public int Carpolicydaautorizzare { get; set; }
        public int Carpolicyinviaremail { get; set; }
        public int Configurazionidaautorizzarepp { get; set; }
        public int Autorunning { get; set; }
        public int Autopool { get; set; }
        public int Ordini { get; set; }
        public int Ticketaperti { get; set; }
        public int Ticketlavorazione { get; set; }
        public int Ticketchiusi { get; set; }
        public int Ticketcancellati { get; set; }
        public int Documentipolicydacontrollare { get; set; }
        public int Ztldafirmare { get; set; }
        public int Inoffertarenter { get; set; }
        public int Offertevalutazioneadriver { get; set; }
        public int Ordinievasione { get; set; }
        public int Autoritiro { get; set; }
        public int Autoconsegna { get; set; }
        public int Configurazione { get; set; }
        public int Configurazione30gg { get; set; }
        public int Configurazionicorso { get; set; }
        public int Configurazionievase { get; set; }
        public int Penaligestire { get; set; }
        public int Penaliapprovate { get; set; }
        public int Penalicontestazione { get; set; }
        public decimal Canone { get; set; }
        public int Numerodeltacanone { get; set; }
        public decimal Maxdeltacanone { get; set; }
        public decimal Mediadeltacanone { get; set; }
        public decimal Mediafringebenefit { get; set; }
        public decimal Maxfringebenefit { get; set; }
        public decimal Mediaemissioni { get; set; }
        public decimal Maxemissioni { get; set; }
        public int Offerte { get; set; }
        public int Approvazione { get; set; }
        public int Conferma { get; set; }
        public int Dafirmare { get; set; }
        public int Tempirisposta { get; set; }
        public decimal Importototale { get; set; }


        private string _fornitore1 = _stringEmpty;
        private string _fornitore2 = _stringEmpty;
        private string _etichetta = _stringEmpty;
        public string Fornitore1 { get { return _fornitore1; } set { _fornitore1 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fornitore2 { get { return _fornitore2; } set { _fornitore2 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Etichetta { get { return _etichetta; } set { _etichetta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_faq

        public int Idfaq { get; set; }
        public int Idargomentofaq { get; set; }
        public DateTime Validadal { get; set; }
        public DateTime Validaal { get; set; }

        private string _domanda = _stringEmpty;
        private string _risposta = _stringEmpty;
        private string _status = _stringEmpty;
        private string _argomento = _stringEmpty;
        private string _immagine = _stringEmpty;
        public string Domanda { get { return _domanda; } set { _domanda = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Risposta { get { return _risposta; } set { _risposta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Status { get { return _status; } set { _status = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Argomento { get { return _argomento; } set { _argomento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Immagine { get { return _immagine; } set { _immagine = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_penali 
        public int Idpenale { get; set; }
        public decimal Importopenale { get; set; }

        private string _tipopenale = _stringEmpty;
        public string Tipopenale { get { return _tipopenale; } set { _tipopenale = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_avvisi

        private string _testoavviso = _stringEmpty;
        public string Testoavviso { get { return _testoavviso; } set { _testoavviso = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_email_invio
        private string _Nome = _stringEmpty;
        private string _Cognome = _stringEmpty;
        private string _Matricola = _stringEmpty;
        private string _Email = _stringEmpty;
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

        public string Nome { get { return _Nome; } set { _Nome = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cognome { get { return _Cognome; } set { _Cognome = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Matricola { get { return _Matricola; } set { _Matricola = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Email { get { return _Email; } set { _Email = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
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
        public int Flginviato { get; set; }
        public int Idinvio { get; set; }

        //********************************************  parametri EF_centri
        public int Idcentro { get; set; }
        private string _Centro = _stringEmpty;
        private string _Citta = _stringEmpty;
        public string Centro { get { return _Centro; } set { _Centro = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Citta { get { return _Citta; } set { _Citta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

    }
}
