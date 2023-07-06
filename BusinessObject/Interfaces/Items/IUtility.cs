// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IUtility.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BusinessObject
{
    public interface IUtilitys

    {
        //********************************************  parametri generici

        Guid Uid { get; set; }
        Guid UserIDIns { get; set; }
        Guid UserIdMod { get; set; }
        DateTime Datauserins { get; set; }
        DateTime Datausermod { get; set; }
        Guid Uidtenant { get; set; }

        //********************************************  parametri EF_societa

        string Codsocieta { get; set; }
        string Codcompany { get; set; }
        string Siglasocieta { get; set; }
        string Societa { get; set; }
        string Servicearea { get; set; }
        string Partitaiva { get; set; }
        string Codicecdc { get; set; }
        string Excodcarpolicy { get; set; }

        //********************************************  parametri EF_conti

        string Codconto { get; set; }
        string Descrizioneconto { get; set; }
        string Annotazioni { get; set; }

        //********************************************  parametri EF_fornitori

        string Codfornitore { get; set; }
        string Fornitore { get; set; }

        //********************************************  parametri EF_fuelcard
        string Codfuelcard { get; set; }
        string Fuelcard { get; set; }
        decimal Valorefuelcard { get; set; }

        //********************************************  parametri EF_grade

        string Codgrade { get; set; }
        string Grade { get; set; }

        //********************************************  parametri EF_persontype
        string Codpersontype { get; set; }
        string Persontype { get; set; }

        //********************************************  parametri EF_email_template
        int Idtemplate { get; set; }
        string Titolo { get; set; }
        string Oggetto { get; set; }
        string Corpo { get; set; }


        //********************************************  parametri EF_comunicazioni_email
        
        int Idcomunicazione { get; set; }
        string Mittente { get; set; }
        Guid UserId { get; set; }
        string Tipocomunicazione { get; set; }
        int Idstatuscomunicazione { get; set; }
        DateTime Datainvio { get; set; }
        DateTime Dataricezione { get; set; }


        //********************************************  parametri EF_comunicazioni_status

        string Statuscomunicazione { get; set; }

        //********************************************  parametri EF_cron_file

        int Idcron { get; set; }
        DateTime Data { get; set; }
        string Tipodocumento { get; set; }
        string Pathfile { get; set; }
        string Nomefile { get; set; }

        //********************************************  parametri EF_pagine

        int Idpagina { get; set; }
        string Pagina { get; set; }

        //********************************************  parametri EF_documenti
    
        int Iddoc { get; set; }
        int Idcatdoc { get; set; }
        string Nomedocumento { get; set; }
        string Filedocumento { get; set; }
        string Codcarpolicy { get; set; }
        string Categoriadocumento { get; set; }
        DateTime Visibiledal { get; set; }
        DateTime Visibileal { get; set; }


        //********************************************  parametri EF_report

        int Idreport { get; set; }
        string Nomereport { get; set; }
        string Viewreport { get; set; }
        string Fileexcel { get; set; }
        string Column { get; set; }
        string TipoDato { get; set; }
        string Filtrocodsocieta { get; set; }
        string Filtrocodgrade { get; set; }
        string Filtrodriver { get; set; }
        string Filtrocodfornitore { get; set; }


        //********************************************  parametri EF_task

        int Idtask { get; set; }
        Guid Uidteam { get; set; }
        string Testotask { get; set; }
        DateTime Datatask { get; set; }
        int Esitotask { get; set; }
        string Linktask { get; set; }

        //********************************************  parametri viste dashboard
        
        int Tot { get; set; }
        int Configurazionidaautorizzare { get; set; }
        int Offertedainviareadriver { get; set; }
        int Confermedafirmare  { get; set; }
        int Richiesteautoinpool { get; set; }
        int Richiesteautoinpool2 { get; set; }
        int Richiestepreassegnazioni { get; set; }
        int Richiestevolture { get; set; }
        int Volturedaautorizzare { get; set; }
        int Multedaregistrare { get; set; }
        int Multeconpunti { get; set; }
        int Fatturedaelaborare { get; set; }
        int Fringebenefitdacalcolare { get; set; }

        int Autoincircolazione { get; set; }
        int Autoinpool { get; set; }
        int Saldoauto { get; set; }
        int Meseconsegna { get; set; }
        int Annoconsegna { get; set; }
        string Fornitore1 { get; set; }
        string Fornitore2 { get; set; }
        decimal Kmmedi { get; set; }
        int Percultimoannokm { get; set; }
        int Etamedia { get; set; }
        int Percultimoannoeta { get; set; }
        int Etamediadriver { get; set; }
        int Percultimoannoetadriver { get; set; }
        string Etichetta { get; set; }
        int Autototali { get; set; }
        int Ready { get; set; }
        int Dariparare { get; set; }
        int Driverattivi { get; set; }
        int Driverattesaauto { get; set; }
        int Driverdimissionari { get; set; }

        int Carpolicydaautorizzare { get; set; }
        int Carpolicyinviaremail { get; set; }
        int Configurazionidaautorizzarepp { get; set; }
        int Autorunning { get; set; }
        int Autopool { get; set; }
        int Ordini { get; set; }
        int Ticketaperti { get; set; }
        int Ticketlavorazione { get; set; }
        int Ticketchiusi { get; set; }
        int Ticketcancellati { get; set; }

        int Documentipolicydacontrollare { get; set; }
        int Ztldafirmare { get; set; }
        int Inoffertarenter { get; set; }
        int Offertevalutazioneadriver { get; set; }
        int Ordinievasione { get; set; }
        int Autoritiro { get; set; }
        int Autoconsegna { get; set; }
        int Configurazione { get; set; }
        int Configurazione30gg { get; set; }
        int Configurazionicorso { get; set; }
        int Configurazionievase { get; set; }
        int Penaligestire { get; set; }
        int Penaliapprovate { get; set; }
        int Penalicontestazione { get; set; }
        decimal Canone { get; set; }
        int Numerodeltacanone { get; set; }
        decimal Maxdeltacanone { get; set; }
        decimal Mediadeltacanone { get; set; }
        decimal Mediafringebenefit { get; set; }
        decimal Maxfringebenefit { get; set; }
        decimal Mediaemissioni { get; set; }
        decimal Maxemissioni { get; set; }
        int Offerte { get; set; }
        int Approvazione { get; set; }
        int Conferma { get; set; }
        int Dafirmare { get; set; }
        int Tempirisposta { get; set; }
        decimal Importototale { get; set; }



        //********************************************  parametri EF_faq

        int Idfaq { get; set; }
        int Idargomentofaq { get; set; }
        string Domanda { get; set; }
        string Risposta { get; set; }
        DateTime Validadal { get; set; }
        DateTime Validaal { get; set; }
        string Status { get; set; }
        string Argomento { get; set; }
        string Immagine { get; set; }


        //********************************************  parametri EF_penali 

        int Idpenale { get; set; }
        decimal Importopenale { get; set; }
        string Tipopenale { get; set; }

        //********************************************  parametri EF_avvisi

        string Testoavviso { get; set; }


        //********************************************  parametri EF_email_invio

        string Nome { get; set; }
        string Cognome { get; set; }
        string Matricola { get; set; }
        string Email { get; set; }
        string Param1 { get; set; }
        string Param2 { get; set; }
        string Param3 { get; set; }
        string Param4 { get; set; }
        string Param5 { get; set; }
        string Param6 { get; set; }
        string Param7 { get; set; }
        string Param8 { get; set; }
        string Param9 { get; set; }
        string Param10 { get; set; }
        int Flginviato{ get; set; }
        int Idinvio { get; set; }


        //********************************************  parametri EF_centri
        int Idcentro { get; set; }
        string Centro { get; set; }
        string Citta { get; set; }
    }
}