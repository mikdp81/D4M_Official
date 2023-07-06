// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IComunicazioni.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BusinessObject
{
    public interface IComunicazioni

    {
        //********************************************  parametri EF_comunicazioni


        int Idcomunicazione { get; set; }
        int Idoggetto { get; set; }
        Guid UserIdMittente { get; set; }
        Guid UseridDestinatario { get; set; }
        DateTime Datainvio { get; set; }
        DateTime Datachiusura { get; set; }
        string Testocomunicazione { get; set; }
        int Idstatuscomunicazione { get; set; }
        int Priorita { get; set; }
        int Idstatuslettura { get; set; }
        Guid Uidcomunicazione { get; set; }
        DateTime Datauserins { get; set; }
        DateTime Datausermod { get; set; }
        Guid UserIDIns { get; set; }
        Guid UserIdMod { get; set; }
        Guid UidcomunicazionePadre { get; set; }
        Guid Uidtenant { get; set; }
        string Cognome { get; set; }
        string Statuscomunicazione { get; set; }
        string Ultimomittente { get; set; }
        string Emailmittente { get; set; }
        string Destinatario { get; set; }
        DateTime Dataultimoaggiornamento { get; set; }
        string Societa { get; set; }
        string Grade { get; set; }


        //********************************************  parametri EF_comunicazioni_oggetto

        Guid Uidoggetto { get; set; }
        string Oggetto { get; set; }


        //********************************************  parametri EF_comunicazioni_allegati

        int Idallegato { get; set; }
        Guid UIDallegato { get; set; }      
        Guid UIDcomunicazione { get; set; }
        string Allegato { get; set; }

    }
}