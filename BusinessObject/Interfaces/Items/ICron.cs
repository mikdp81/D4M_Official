// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ICron.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BusinessObject
{
    public interface ICron

    {
        //********************************************  parametri generici

        Guid Uid { get; set; }
        Guid UserIDIns { get; set; }
        Guid UserIdMod { get; set; }
        DateTime Datauserins { get; set; }
        DateTime Datausermod { get; set; }
        Guid UserId { get; set; }
        Guid Uidtenant { get; set; }
        string Urlblob { get; set; }
        int Idcomunicazione { get; set; }
        DateTime Datainvio { get; set; }
        Guid UidcomunicazionePadre { get; set; }
        Guid Uidcomunicazione { get; set; }
        Guid UserIdMittente { get; set; }
        int Idtemplate { get; set; }
        int Mese { get; set; }
        int Anno { get; set; }

        string Matricola { get; set; }
        string Nome { get; set; }
        string Cognome { get; set; }
        string Tipologiacedolino { get; set; }
        string Codsocieta { get; set; }
        string Societa { get; set; }
        string Codicecdc { get; set; }
        string Targa { get; set; }
        decimal Importo { get; set; }

        int Idcron { get; set; }
        DateTime Data { get; set; }
        string Tipodocumento { get; set; }
        string Pathfile { get; set; }
        string Nomefile { get; set; }


        int Idapprovazione { get; set; }
        int Idutente { get; set; }
        int Idapprovatore { get; set; }
        DateTime Dataapprovazione { get; set; }
        DateTime Datamail { get; set; }
        int Approvato { get; set; }
        string Flgmail { get; set; }
        string Codcarpolicy { get; set; }
        string Gradecode { get; set; }
        int Idcontratto { get; set; }
        string Titolo { get; set; }
        string Oggetto { get; set; }
        string Corpo { get; set; }
        string Email { get; set; }
        string Modello { get; set; }
        string Codservice { get; set; }
        string Numerofuelcard { get; set; }
        DateTime Datainizioperiodo { get; set; }
        DateTime Datafineperiodo { get; set; }

        //********************************************  parametri EF_importazioni_storico

        int Idprog { get; set; }
        int Idtipofile { get; set; }
        DateTime Datacaricato { get; set; }
        DateTime Dataimportazione { get; set; }
        DateTime Periododal { get; set; }
        DateTime Periodoal { get; set; }
        int Righeimportate { get; set; }
        int Righetotali { get; set; }
        string Texterrori { get; set; }
        string Cartellaimport { get; set; }
        string Importato { get; set; }
        string Tipofile { get; set; }
        DateTime Datafattura { get; set; }
        string Idtransazione { get; set; }
        string Numerofattura { get; set; }

        DateTime Datatransazione { get; set; }
        string Codicepuntovendita { get; set; }
        string Ragionesociale { get; set; }
        string Localita { get; set; }
        string Indirizzo { get; set; }
        string Nazione { get; set; }
        decimal Kmtransazione { get; set; }
        decimal Quantita { get; set; }
        decimal Prezzo { get; set; }
        decimal Importoiva { get; set; }
        decimal Importofinalefatturato { get; set; }
        string Tiporifornimento { get; set; }
        int Idcompagnia { get; set; }
        string Codjatoauto { get; set; }
        string Marca { get; set; }
        string Serie { get; set; }
        int Idfringe { get; set; }
        decimal Costokm { get; set; }
        decimal Fringe25 { get; set; }
        decimal Fringe30 { get; set; }
        decimal Fringe50 { get; set; }
        decimal Fringe60 { get; set; }
        string Divisa { get; set; }
        DateTime Datadocumento { get; set; }
        string Numerodocumento { get; set; }
        decimal Importototale { get; set; }
        string Fornitore { get; set; }
        string Codfornitore { get; set; }
        string Committente { get; set; }
        string Codcommittente { get; set; }
        string Numerocontratto { get; set; }
        DateTime  Datacontratto { get; set; }
        decimal Importopagamento { get; set; }
        DateTime Datascadenzapagamento { get; set; }
        string Filexml { get; set; }
        Guid Uidfattura { get; set; }
        int Numerolionea { get; set; }
        string Descrizione { get; set; }
        int QuantitaP { get; set; }
        decimal Prezzoun { get; set; }
        decimal Prezzotot { get; set; }
        decimal Iva { get; set; }
        string Tipodato { get; set; }
        string Riftesto { get; set; }
        string Centrocostoabb { get; set; }
        string Tipocentrocosto { get; set; }
        string Centrocostoabb2 { get; set; }
        string Tipocentrocosto2 { get; set; }
        string Naturaiva { get; set; }
        int Iduser { get; set; }


        string Idnumber { get; set; }
        int Idtipodriver { get; set; }
        string Funzione { get; set; }
        string Maternita { get; set; }
        string Cellulare { get; set; }
        DateTime Dataassunzione { get; set; }
        string Descrizionecdc { get; set; }
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
        string Persontype { get; set; }
        string Indirizzosede { get; set; }
        string Cittasede { get; set; }
        string Provinciasede { get; set; }
        string Capsede { get; set; }
        string Codicedivisione { get; set; }
        string Descrizionedivisione { get; set; }
        string Fasciaimportazione { get; set; }
        string Annotazioni { get; set; }
        int Flgdriver { get; set; }
        int Idgruppouser { get; set; }
        int Idstatususer { get; set; }
        int Flgadmin { get; set; }
        string Fasciacarpolicy { get; set; }

        string Codcompany { get; set; }
        DateTime Dataspesa { get; set; }
        string Tipologiaspesa { get; set; }
        decimal Distanza { get; set; }
        decimal Rimborso { get; set; }  
        decimal Importospesa { get; set; }
        decimal Importodeducibile { get; set; }
        string Chiave { get; set; }
        string Tracciato { get; set; }

        string Dispositivo { get; set; }
        string Numerodispositivo { get; set; }
        DateTime Dataora { get; set; }
        string Classe { get; set; }

        string Network_user { get; set; }
        string Network_password { get; set; }
        int Flgcron { get; set; }
        DateTime Datafineimportazione { get; set; }

        string Codgrade { get; set; }
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
        int Idinvio { get; set; }
        DateTime Scadenza { get; set; }
        DateTime Dataattivazione { get; set; }
        string Pin { get; set; }
        string Statuscard { get; set; }
        string Idzucchetti { get; set; }
        string Username { get; set; }
        string Stato { get; set; }
        string Sceltabenefit { get; set; }

        //********************************************  parametri EF_importazioni_storico

        string Campo1 { get; set; }
        string Campo2 { get; set; }
        string Campo3 { get; set; }
        string Campo4 { get; set; }
        string Campo5 { get; set; }
        string Campo6 { get; set; }
        string Campo7 { get; set; }
        string Modifica { get; set; }
        int Benefit { get; set; }
        int Benefitalt { get; set; }
    }
}