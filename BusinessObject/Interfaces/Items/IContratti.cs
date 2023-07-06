// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IContratti.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BusinessObject
{
    public interface IContratti

    {
        //********************************************  parametri generici

        Guid Uid { get; set; }
        Guid UserIDIns { get; set; }
        Guid UserIdMod { get; set; }
        DateTime Datauserins { get; set; }
        DateTime Datausermod { get; set; }
        DateTime Dataassunzione { get; set; }
        string Denominazione { get; set; }
        string Matricola { get; set; }
        string Nome { get; set; }
        string Cellulare { get; set; }
        string Email { get; set; }
        string Marca { get; set; }
        string Modello { get; set; }
        string Cilindrata { get; set; }
        string Alimentazione { get; set; }
        string Cognome { get; set; }
        string Fotoauto { get; set; }
        int Giorniconsegnaagg { get; set; }
        string Sedelavoro { get; set; }
        string Compagnia { get; set; }
        decimal Spesepagamento { get; set; }
        string Excodcarpolicy { get; set; }
        string Fasciacarpolicy { get; set; }
        string Cambio { get; set; }
        Guid Uidtenant { get; set; }

        //********************************************  parametri EF_contratti

        int Idcontratto { get; set; }
        string Codsocieta { get; set; }
        Guid UserId { get; set; }
        string Codjatoauto { get; set; }
        string Codcarpolicy { get; set; }
        string Codcarlist { get; set; }
        string Codfornitore { get; set; }
        string Codtipocontratto { get; set; }
        string Codtipousocontratto { get; set; }
        string Numordineordine { get; set; }
        string Numeroordinefornitore { get; set; }
        string Numerocontratto { get; set; }
        DateTime Datacontratto { get; set; }
        int Duratamesi { get; set; }
        int Kmcontratto { get; set; }
        decimal Franchigia { get; set; }
        DateTime Datainiziocontratto { get; set; }
        DateTime Datainiziouso { get; set; }
        DateTime Datafinecontratto { get; set; }
        string Annotazionicontratto { get; set; }
        decimal Canoneleasing { get; set; }
        decimal Canoneleasingofferta { get; set; }
        int Idstatuscontratto { get; set; }
        Guid Uidordine { get; set; }
        string Filecontratto { get; set; }
        string Tipocontratto { get; set; }
        string Fornitore { get; set; }
        DateTime Dataimmatricolazione { get; set; }
        decimal Bollo { get; set; }
        decimal Superbollo { get; set; }
        DateTime Scadenzabollo { get; set; }
        DateTime Scadenzasuperbollo { get; set; }
        int Flgvoltura { get; set; }
        string Notevoltura { get; set; }
        Guid Uidcontrattovolturato { get; set; }
        string Tipousocontratto { get; set; }
        int Idtipoassegnazione { get; set; }
        string Tipoassegnazione { get; set; }
        decimal Emissioni { get; set; }
        string Divisa { get; set; }
        int Templateabb { get; set; }
        DateTime Datarifabb { get; set; }
        string Naturaiva { get; set; }
        string Ivatemplate { get; set; }
        string Descrizionetemplate { get; set; }
        decimal Canonefinanziario { get; set; }
        decimal Canoneservizi { get; set; }
        decimal Costokmeccedente { get; set; }
        decimal Costokmrimborso { get; set; }
        decimal Sogliakm { get; set; }
        string Codcompany { get; set; }
        string Periodo { get; set; }
        int Checkpool { get; set; }
        int Idstatuspool { get; set; }
        string Notepool { get; set; }
        int Checkordinepool { get; set; }
        string Gradepool { get; set; }
        string Statuspool { get; set; }
        DateTime Datarevisione { get; set; }
        string Documentopatente { get; set; }
        Guid UserIdpool { get; set; }
        string Modulodafirmare { get; set; }
        string Modulofirmato { get; set; }
        DateTime Datafirma { get; set; }
        int Idtipomodulo { get; set; }
        string Motivazione { get; set; }
        string Noteconsegna { get; set; }
        string Noterestituzione { get; set; }
        decimal Quotadriver { get; set; }
        decimal Quotasocieta { get; set; }
        int Checkassegnatario { get; set; }
        string Codcolore { get; set; }
        int Flglibrettoinviato { get; set; }
        string Kwcvcontratto { get; set; }
        string Alimentazionecontratto { get; set; }
        string Cilindratacontratto { get; set; }
        string Filelibrettoautocontratto { get; set; }
        int Riparazione { get; set; }


        //********************************************  parametri EF_contratti_status

        string Statuscontratto { get; set; }

        //********************************************  parametri EF_ordini

        int Idordine { get; set; }
        string Numeroordine { get; set; }
        DateTime Dataordine { get; set; }
        string Annotazioniordini { get; set; }
        string Annotazioniordinirenter { get; set; }
        int Idstatusordine { get; set; }
        DateTime Dataprimaconsegnaprevista { get; set; }
        DateTime Dataconsegnaprevista { get; set; }
        DateTime Dataconsegnaprevistaupdate { get; set; }
        DateTime Dataconfermaricezione { get; set; }
        DateTime Datainviolink { get; set; }
        decimal Deltacanone { get; set; }
        string Societa { get; set; }
        string Grade { get; set; }
        string Motivoscarto { get; set; }
        string Filefirma { get; set; }
        string Fileconfermarental { get; set; }
        DateTime Data10 { get; set; }
        DateTime Data20 { get; set; }
        DateTime Data25 { get; set; }
        DateTime Data30 { get; set; }
        DateTime Data40 { get; set; }
        DateTime Data50 { get; set; }
        DateTime Data55 { get; set; }
        DateTime Data60 { get; set; }
        DateTime Data100 { get; set; }
        DateTime Data110 { get; set; }
        DateTime Dataconsegna { get; set; }
        string Oraconsegna { get; set; }
        string Luogoconsegna { get; set; }
        string Filerifiutoauto { get; set; }
        string Fileverbaleauto { get; set; }
        string Filelibrettoauto { get; set; }
        string Motivorifiutoauto { get; set; }
        string Flgaccettato { get; set; }
        string Fileordinepdf { get; set; }

        //********************************************  parametri EF_ordini_status

        string Statusordine { get; set; }


        //********************************************  parametri EF_contratti_assegnazioni

        int Idassegnazione { get; set; }
        int Idstatusassegnazione { get; set; }
        DateTime Assegnatodal { get; set; }
        DateTime Assegnatoal { get; set; }
        string Targa { get; set; }
        DateTime Datarestituzione { get; set; }
        string Orarestituzione { get; set; }
        string Luogorestituzione { get; set; }
        string Centrorestituzione { get; set; }
        string Fileverbaleconsegna { get; set; }
        string Filerelazioneperito { get; set; }
        string Filedenunce { get; set; }
        string Checkdoc { get; set; }
        string Noteamministrazione { get; set; }
        string Notedriver { get; set; }
        int Idstatoauto { get; set; }
        string Statoauto { get; set; }
        string Tipogomme { get; set; }
        string Luogogomme { get; set; }
        DateTime Datacambiogomme { get; set; }
        decimal Kmrestituzione { get; set; }

        //********************************************  parametri EF_contratti_assegnazioni_status

        string Statusassegnazione { get; set; }


        //********************************************  parametri EF_users_carpolicy

        int Idapprovazione { get; set; }
        int Idutente { get; set; }
        int Idapprovatore { get; set; }
        DateTime Dataapprovazione { get; set; }
        DateTime Datamail { get; set; }
        int Approvato { get; set; }
        string Flgmail { get; set; }
        int Nconfigurazioni { get; set; }
        string Preassegnazione { get; set; }
        string Documentocarpolicy { get; set; }
        string Documentofuelcard { get; set; }
        DateTime Datadocpolicy { get; set; }
        DateTime Datadecorrenza { get; set; }
        string Checkcarpolicy { get; set; }
        Guid Idutentecheck { get; set; }
        DateTime Datacheck { get; set; }
        DateTime Datarinuncia { get; set; }
        DateTime Datafinedecorrenza { get; set; }
        string Sceltabenefit { get; set; }
        string Codpacchetto { get; set; }
        DateTime Datasceltabenefit { get; set; }
        string Codcarbenefit { get; set; }
        string Carbenefit { get; set; }

        //********************************************  parametri EF_ordini_optional

        string Codoptional { get; set; }
        decimal Importooptional { get; set; }

        //********************************************  parametri EF_contratti_percorrenze
        decimal Kmpercorsi { get; set; }
        DateTime Datains { get; set; }


        //********************************************  parametri EF_documenti_deleghe

        int Iddelega { get; set; }
        DateTime Datanascita { get; set; }
        string Luogonascita { get; set; }
        string Indirizzoresidenza { get; set; }
        string Civicoresidenza { get; set; }
        string Cittaresidenza { get; set; }
        string Nrpatente { get; set; }
        DateTime Datarilasciopatente { get; set; }
        string Entepatente { get; set; }
        DateTime Scadenzapatente { get; set; }
        string Tipoutente { get; set; }
        string Denominazionedelegato { get; set; }
        DateTime Datanascitadelegato { get; set; }
        string Luogonascitadelegato { get; set; }
        string Indirizzoresidenzadelegato { get; set; }
        string Civicoresidenzadelegato { get; set; }
        string Cittaresidenzadelegato { get; set; }
        string Nrpatentedelegato { get; set; }
        DateTime Datarilasciopatentedelegato { get; set; }
        string Entepatentedelegato { get; set; }
        DateTime Scadenzapatentedelegato { get; set; }
        string Veicolo { get; set; }
        DateTime Datadocumento { get; set; }
        DateTime Datarichiesta { get; set; }
        string Filepdf { get; set; }
        string Luogodocumento { get; set; }
        string Moduloconvivenza { get; set; }


        //********************************************  parametri EF_configurazioni_partner
        int Idconfigurazione { get; set; }
        int Idallegato { get; set; }
        string Testo { get; set; }
        DateTime Datainviato { get; set; }
        string Allegato { get; set; }
        int Flgemailmulte { get; set; }
        int Flgemailpenali { get; set; }
        int Flgemailticket { get; set; }


        //********************************************  parametri tracciati fatture (tab. EF_fatturexml)

        int Idfattura { get; set; }
        string Tipodocumento { get; set; }
        string Codcommittente { get; set; }
        string Committente { get; set; }
        string Numerodocumento { get; set; }
        decimal Importototale { get; set; }
        decimal Importopagamento { get; set; }
        DateTime Datascadenzapagamento { get; set; }
        int Idstatusfattura { get; set; }
        string Statusfattura { get; set; }

        int Iddettaglio { get; set; }
        Guid Uidfattura { get; set; }
        int Numerolionea { get; set; }
        string Descrizione { get; set; }
        int QuantitaP { get; set; }
        decimal Prezzoun { get; set; }
        decimal Prezzotot { get; set; }
        decimal Iva { get; set; }
        string Tipodato { get; set; }
        string Riftesto { get; set; }
        DateTime Datainizioperiodo { get; set; }
        DateTime Datafineperiodo { get; set; }
        DateTime Datainizioperiodo2 { get; set; }
        DateTime Datafineperiodo2 { get; set; }
        DateTime Datainizioperiodo3 { get; set; }
        DateTime Datafineperiodo3 { get; set; }
        DateTime Datainizioperiodo4 { get; set; }
        DateTime Datafineperiodo4 { get; set; }
        string Centrocostoabb { get; set; }
        string Tipocentrocosto { get; set; }
        Guid Uidcentrocosto { get; set; }
        string Centrocostoabb2 { get; set; }
        string Tipocentrocosto2 { get; set; }
        Guid Uidcentrocosto2 { get; set; }
        string Centrocostoabb3 { get; set; }
        string Tipocentrocosto3 { get; set; }
        Guid Uidcentrocosto3 { get; set; }
        string Centrocostoabb4 { get; set; }
        string Tipocentrocosto4 { get; set; }
        Guid Uidcentrocosto4 { get; set; }
        string Filexml { get; set; }

        int Idtemplatefattura { get; set; }
        string Nometemplate { get; set; }
        string Notetemplate { get; set; }
        string Codicecdc { get; set; }

        string Nomefile { get; set; }
        string Tipofile { get; set; }
        int Anno { get; set; }
        int Mese { get; set; }
        decimal Fringebenefit { get; set; }
        decimal Fringebenefitbase { get; set; }
        decimal Canonefigurativo { get; set; }
        string Erratasederestituzione { get; set; }
        string Erratarestituzionegomme { get; set; }
        string Penaledenuncia { get; set; }


        //********************************************  parametri EF_penali

        DateTime Datafattura { get; set; }
        string Numerofattura { get; set; }
        decimal Importo { get; set; }
        string Filepenale { get; set; }
        string Notificato { get; set; }
        int Idtipopenaleauto { get; set; }
        string Tipopenaleauto { get; set; }

        int Totuser { get; set; }


        //********************************************  parametri tipo utilizzo

        string Codutilizzo { get; set; }
        string Tipoutilizzo { get; set; }


        //********************************************  parametri auto servizio

        string Scopoviaggio { get; set; }
        string Spese { get; set; }
        decimal Kminiziali { get; set; }
        decimal Importospese { get; set; }
        int Autorizzatoadmin { get; set; }
    }
}