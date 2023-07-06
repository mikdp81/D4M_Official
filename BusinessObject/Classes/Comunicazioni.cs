// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Comunicazioni.cs" company="">
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

    public class Comunicazioni : IComunicazioni
    {

        public static string _stringEmpty = string.Empty;

        //********************************************  parametri EF_comunicazioni

        public int Idcomunicazione { get; set; }
        public int Idoggetto { get; set; }
        public Guid UserIdMittente { get; set; }
        public Guid UseridDestinatario { get; set; }
        public DateTime Datainvio { get; set; }
        public DateTime Datachiusura { get; set; }
        public int Idstatuscomunicazione { get; set; }
        public int Priorita { get; set; }
        public int Idstatuslettura { get; set; }
        public Guid Uidcomunicazione { get; set; }
        public DateTime Datauserins { get; set; }
        public DateTime Datausermod { get; set; }
        public Guid UserIDIns { get; set; }
        public Guid UserIdMod { get; set; }
        public Guid UidcomunicazionePadre { get; set; }
        public DateTime Dataultimoaggiornamento { get; set; }
        public Guid Uidtenant { get; set; }

        private string _testocomunicazione = _stringEmpty;
        private string _cognome = _stringEmpty;
        private string _statuscomunicazione = _stringEmpty;
        private string _ultimomittente = _stringEmpty;
        private string _emailmittente = _stringEmpty;
        private string _destinatario = _stringEmpty;
        private string _societa = _stringEmpty;
        private string _grade = _stringEmpty;
        public string Testocomunicazione { get { return _testocomunicazione; } set { _testocomunicazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cognome { get { return _cognome; } set { _cognome = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Statuscomunicazione { get { return _statuscomunicazione; } set { _statuscomunicazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Ultimomittente { get { return _ultimomittente; } set { _ultimomittente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Emailmittente { get { return _emailmittente; } set { _emailmittente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Destinatario { get { return _destinatario; } set { _destinatario = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Societa { get { return _societa; } set { _societa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Grade { get { return _grade; } set { _grade = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_comunicazioni_oggetto

        public Guid Uidoggetto { get; set; }

        private string _oggetto = _stringEmpty;
        public string Oggetto { get { return _oggetto; } set { _oggetto = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_comunicazioni_allegati

        public int Idallegato { get; set; }
        public Guid UIDallegato { get; set; }
        public Guid UIDcomunicazione { get; set; }

        private string _allegato = _stringEmpty;
        public string Allegato { get { return _allegato; } set { _allegato = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

    }
}
