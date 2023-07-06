// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Multe.cs" company="">
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
   
    public class Multe : IMulte
    {
        public static string _stringEmpty = string.Empty;

        //********************************************  parametri generici

        public Guid Uid { get; set; }
        public Guid UserIDIns { get; set; }
        public Guid UserIdMod { get; set; }
        public DateTime Datauserins { get; set; }
        public DateTime Datausermod { get; set; }
        public int Giornitrascorsi { get; set; }
        public Guid Uidtenant { get; set; }

        private string _denominazione = _stringEmpty;
        public string Denominazione { get { return _denominazione; } set { _denominazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_multe
        public int Idmulta { get; set; }
        public int Idtipotrasmissione { get; set; }
        public Guid UserId { get; set; }
        public DateTime Datainfrazione { get; set; }
        public DateTime Datanotifica { get; set; }
        public DateTime Datapagamento { get; set; }
        public int Punti { get; set; }
        public decimal Importomulta { get; set; }
        public decimal Importomultapagato { get; set; }
        public decimal Importomultaridotto { get; set; }
        public decimal Importomultascontato { get; set; }
        public int Ckemaildriver { get; set; }
        public int Idstatuslavorazione { get; set; }
        public int Idstatuspagamento { get; set; }
        public int Idtitolarepagamento { get; set; }
        public decimal Spesepagamento { get; set; }
        public DateTime Datadimissioni { get; set; }
        public DateTime Datapreseuntedimissioni { get; set; }
        public decimal Quotadriver { get; set; }
        public decimal Quotasocieta { get; set; }

        private string _protocollo = _stringEmpty;
        private string _targa = _stringEmpty;
        private string _modello = _stringEmpty;
        private string _marca = _stringEmpty;
        private string _numeroverbale = _stringEmpty;
        private string _orainfrazione = _stringEmpty;
        private string _fileverbale = _stringEmpty;
        private string _filemanleva = _stringEmpty;
        private string _filericevutapagamento = _stringEmpty;
        private string _ente = _stringEmpty;
        private string _infrazione = _stringEmpty;
        private string _societa = _stringEmpty;
        private string _matricola = _stringEmpty;
        private string _codsocieta = _stringEmpty;
        private string _codicecdc = _stringEmpty;
        private string _nome = _stringEmpty;
        private string _cognome = _stringEmpty;
        private string _cfemittente = _stringEmpty;
        private string _codpagopa = _stringEmpty;
        private string _iban = _stringEmpty;
        private string _codpagamento = _stringEmpty;
        private string _codpagopa60 = _stringEmpty;
        private string _annotazioni = _stringEmpty;

        public string Protocollo { get { return _protocollo; } set { _protocollo = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Targa { get { return _targa; } set { _targa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Modello { get { return _modello; } set { _modello = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Marca { get { return _marca; } set { _marca = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Numeroverbale { get { return _numeroverbale; } set { _numeroverbale = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Orainfrazione { get { return _orainfrazione; } set { _orainfrazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Fileverbale { get { return _fileverbale; } set { _fileverbale = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filemanleva { get { return _filemanleva; } set { _filemanleva = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Filericevutapagamento { get { return _filericevutapagamento; } set { _filericevutapagamento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Ente { get { return _ente; } set { _ente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Infrazione { get { return _infrazione; } set { _infrazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Societa { get { return _societa; } set { _societa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Matricola { get { return _matricola; } set { _matricola = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codsocieta { get { return _codsocieta; } set { _codsocieta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codicecdc { get { return _codicecdc; } set { _codicecdc = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Nome { get { return _nome; } set { _nome = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cognome { get { return _cognome; } set { _cognome = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Cfemittente { get { return _cfemittente; } set { _cfemittente = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codpagopa { get { return _codpagopa; } set { _codpagopa = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Iban { get { return _iban; } set { _iban = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codpagamento { get { return _codpagamento; } set { _codpagamento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codpagopa60 { get { return _codpagopa60; } set { _codpagopa60 = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Annotazioni { get { return _annotazioni; } set { _annotazioni = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_multe_statuslavorazione

        private string _statuslavorazione = _stringEmpty;
        public string Statuslavorazione { get { return _statuslavorazione; } set { _statuslavorazione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_multe_statuspagamento

        private string _statuspagamento = _stringEmpty;
        public string Statuspagamento { get { return _statuspagamento; } set { _statuspagamento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_multe_tipo

        private string _codtipomulta = _stringEmpty;
        private string _tipomulta = _stringEmpty;
        private string _codtemplateemail = _stringEmpty;
        public string Codtipomulta { get { return _codtipomulta; } set { _codtipomulta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Tipomulta { get { return _tipomulta; } set { _tipomulta = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
        public string Codtemplateemail { get { return _codtemplateemail; } set { _codtemplateemail = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_multe_tipotrasmissione

        private string _tipotrasmissione = _stringEmpty;
        public string Tipotrasmissione { get { return _tipotrasmissione; } set { _tipotrasmissione = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_multe_titolarepagamento

        private string _titolarepagamento = _stringEmpty;
        public string Titolarepagamento { get { return _titolarepagamento; } set { _titolarepagamento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }

        //********************************************  parametri EF_cedolini

        public int Idcedolino { get; set; }
        public DateTime Datains { get; set; }
        public int Idtipologiacedolino { get; set; }
        public decimal Importo { get; set; }

        //********************************************  parametri EF_cedolini_tipologie

        private string _tipologiacedolino = _stringEmpty;
        public string Tipologiacedolino { get { return _tipologiacedolino; } set { _tipologiacedolino = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }


        //********************************************  parametri EF_multe_contopagamento

        public int Idcontopagamento { get; set; }

        private string _contopagamento = _stringEmpty;
        public string Contopagamento { get { return _contopagamento; } set { _contopagamento = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty; } }
    }
}
