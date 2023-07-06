// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IFileTracciati.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BusinessObject
{
    public interface IFileTracciati

    {
        //********************************************  parametri EF_filecaricati

        Guid Uid { get; set; }
        int Idprog { get; set; }
        int Idtipofile{ get; set; }
        string Nomefile { get; set; }
        DateTime Datacaricato { get; set; }
        Guid UserIDIns { get; set; }
        DateTime Datausermod { get; set; }
        Guid UserIdMod { get; set; }
        string Denominazione { get; set; }
        DateTime Dataimportazione { get; set; }
        string Importato { get; set; }
        Guid Uidtenant { get; set; }

        //********************************************  parametri EF_tipofile

        string Tipofile { get; set; }


        //********************************************  parametri tracciati carburante (tab. EF_users_fuelcard_consumo)

        int Idcompagnia { get; set; }
        int Idcarb { get; set; }
        string Idtransazione { get; set; }
        DateTime Datatransazione { get; set; }
        string Codicepuntovendita { get; set; }
        string Ragionesociale { get; set; }
        string Localita { get; set; }
        string Indirizzo { get; set; }
        string Nazione { get; set; }
        decimal Kmtransazione { get; set; }
        string Numerofuelcard { get; set; }
        string Targa { get; set; }
        decimal Quantita { get; set; }
        decimal Prezzo { get; set; }
        decimal Importo { get; set; }
        decimal Importoiva { get; set; }
        string Numerofattura { get; set; }
        DateTime Datafattura { get; set; }
        decimal Importofinalefatturato { get; set; }
        DateTime Datauserins { get; set; }
        string Compagnia { get; set; }
        string Tiporifornimento { get; set; }

        //********************************************  parametri tracciati fringe aci (tab. EF_fringe_aci)

        int Idfringe { get; set; }
        string Codjatoauto { get; set; }
        string Marca { get; set; }
        string Modello { get; set; }
        string Serie { get; set; }
        decimal Costokm { get; set; }
        decimal Fringe25 { get; set; }
        decimal Fringe30 { get; set; }
        decimal Fringe50 { get; set; }
        decimal Fringe60 { get; set; }
        DateTime Periododal { get; set; }
        DateTime Periodoal { get; set; }

        //********************************************  parametri tracciati fatture (tab. EF_fatturexml)

        int Idfattura { get; set; }
        string Tipodocumento { get; set; }
        DateTime Datadocumento { get; set; }
        string Codfornitore { get; set; }
        string Fornitore { get; set; }
        string Codcommittente { get; set; }
        string Committente { get; set; }
        string Numerodocumento { get; set; }
        decimal Importototale { get; set; }
        string Numerocontratto { get; set; }
        DateTime Datacontratto { get; set; }
        decimal Importopagamento { get; set; }
        DateTime Datascadenzapagamento { get; set; }


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
        string Centrocostoabb { get; set; }
        string Tipocentrocosto { get; set; }
        Guid Uidcentrocosto { get; set; }
        string Centrocostoabb2 { get; set; }
        string Tipocentrocosto2 { get; set; }
        Guid Uidcentrocosto2 { get; set; }
        string Filexml { get; set; }
        decimal Percentuale { get; set; }
        string Divisa { get; set; }
        string Naturaiva { get; set; }

        //********************************************  parametri tracciati anagrafiche (tab. EF_users)

        int Iduser { get; set; }
        int Flgdriver { get; set; }
        int Idgruppouser { get; set; }
        int Idstatususer { get; set; }
        int Flgadmin { get; set; }
        Guid UserId { get; set; }
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


        //********************************************  parametri tracciati concur (tab. EF_concur)


        string Codcompany { get; set; }
        string Codservice { get; set; }
        DateTime Dataspesa { get; set; }
        string Tipologiaspesa { get; set; }
        decimal Distanza { get; set; }
        decimal Rimborso { get; set; }
        decimal Importospesa { get; set; }
        decimal Importodeducibile { get; set; }
        string Chiave { get; set; }
        string Tracciato { get; set; }


        //********************************************  parametri tracciati telepass (tab. EF_users_telepass_consumo)

        int Idtelep { get; set; }
        string Dispositivo { get; set; }
        string Numerodispositivo { get; set; }
        DateTime Dataora { get; set; }
        string Classe { get; set; }



        //********************************************  parametri EF_importazioni_storico

        int Righeimportate { get; set; }
        int Righetotali { get; set; }
        string Texterrori { get; set; }
        string Cartellaimport { get; set; }


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