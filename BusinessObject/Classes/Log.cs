// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Log.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;

namespace BusinessObject
{
    [Serializable]

    public class Log : ILog
    {
        public static string _stringEmpty = string.Empty;

        public static DateTime _dateInvalid = DateTime.Today;

        private string _tipologlogin = _stringEmpty;
        private string _UIDsession = _stringEmpty;
        private string _idattivita = _stringEmpty;
        private string _chiave = _stringEmpty;
        private string _operatore = _stringEmpty;
        private string _codpratica = _stringEmpty;

        public Guid Iduser
        {
            get;
            set;
        }
        public Guid Uidintervento
        {
            get;
            set;
        }

        public int IDLogin
        {
            get;
            set;
        }

        public int Idlogattivita
        {
            get;
            set;
        }
        public string Tipologlogin
        {
            get
            {
                return _tipologlogin;
            }
            set
            {
                _tipologlogin = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty;
            }
        }

        public string Chiave
        {
            get
            {
                return _chiave;
            }
            set
            {
                _chiave = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty;
            }
        }

        public string Idattivita
        {
            get
            {
                return _idattivita;
            }
            set
            {
                _idattivita = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty;
            }
        }
        public string UIDsession
        {
            get
            {
                return _UIDsession;
            }
            set
            {
                _UIDsession = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty;
            }
        }
        public string Operatore
        {
            get
            {
                return _operatore;
            }
            set
            {
                _operatore = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty;
            }
        }
        public string CodPratica
        {
            get
            {
                return _codpratica;
            }
            set
            {
                _codpratica = (!string.IsNullOrEmpty(value)) ? value.Trim() : _stringEmpty;
            }
        }

        public DateTime Dataloglogin { get; set; } = _dateInvalid;
        public DateTime Datains { get; set; } = _dateInvalid;
        public Guid Uidtenant { get; set; }

    }
}
