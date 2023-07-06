// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IMulte.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BusinessObject
{
    public interface IMulte

    {
        //********************************************  parametri generici

        Guid Uid { get; set; }
        Guid UserIDIns { get; set; }
        Guid UserIdMod { get; set; }
        DateTime Datauserins { get; set; }
        DateTime Datausermod { get; set; }
        string Denominazione { get; set; }
        int Giornitrascorsi { get; set; }
        Guid Uidtenant { get; set; }

        //********************************************  parametri EF_multe

        int Idmulta { get; set; }
        string Protocollo { get; set; }
        int Idtipotrasmissione { get; set; }
        string Targa { get; set; }
        string Modello { get; set; }
        string Marca { get; set; }
        Guid UserId { get; set; }
        string Numeroverbale { get; set; }
        DateTime Datainfrazione { get; set; }
        string Orainfrazione { get; set; }
        DateTime Datanotifica { get; set; }
        DateTime Datapagamento { get; set; }
        string Fileverbale { get; set; }
        string Filemanleva { get; set; }
        string Filericevutapagamento { get; set; }
        string Ente { get; set; }
        string Infrazione { get; set; }
        int Punti { get; set; }
        decimal Importomulta { get; set; }
        decimal Importomultapagato { get; set; }
        decimal Importomultaridotto { get; set; }
        decimal Importomultascontato { get; set; }
        int Ckemaildriver { get; set; }
        int Idstatuslavorazione { get; set; }
        int Idstatuspagamento { get; set; }
        int Idtitolarepagamento { get; set; }
        string Societa { get; set; }
        string Matricola { get; set; }
        string Codsocieta { get; set; }
        string Codicecdc { get; set; }
        string Nome { get; set; }
        string Cognome { get; set; }
        decimal Spesepagamento { get; set; }
        string Cfemittente { get; set; }
        string Codpagopa { get; set; }
        string Iban { get; set; }
        string Codpagamento { get; set; }
        DateTime Datadimissioni { get; set; }
        DateTime Datapreseuntedimissioni { get; set; }
        string Codpagopa60 { get; set; }
        string Annotazioni { get; set; }
        decimal Quotadriver { get; set; }
        decimal Quotasocieta { get; set; }


        //********************************************  parametri EF_multe_statuslavorazione

        string Statuslavorazione { get; set; }

        //********************************************  parametri EF_multe_statuspagamento

        string Statuspagamento { get; set; }

        //********************************************  parametri EF_multe_tipo

        string Codtipomulta { get; set; }
        string Tipomulta { get; set; }
        string Codtemplateemail { get; set; }

        //********************************************  parametri EF_multe_tipotrasmissione

        string Tipotrasmissione { get; set; }

        //********************************************  parametri EF_multe_titolarepagamento

        string Titolarepagamento { get; set; }

        //********************************************  parametri EF_cedolini

        int Idcedolino { get; set; }
        DateTime Datains { get; set; }
        int Idtipologiacedolino { get; set; }
        decimal Importo { get; set; }

        //********************************************  parametri EF_cedolini_tipologie

        string Tipologiacedolino { get; set; }

        //********************************************  parametri EF_multe_contopagamento

        int Idcontopagamento { get; set; }
        string Contopagamento { get; set; }
    }
}