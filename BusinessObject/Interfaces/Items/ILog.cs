// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ILog.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BusinessObject
{
    public interface ILog
    {
        string Chiave { get; set; }
        DateTime Datains { get; set; }
        DateTime Dataloglogin { get; set; }
        int IDLogin { get; set; }
        string Idattivita { get; set; }
        int Idlogattivita { get; set; }
        Guid Iduser { get; set; }
        string Tipologlogin { get; set; }
        string UIDsession { get; set; }
        Guid Uidintervento { get; set; }
        string Operatore { get; set; }
        string CodPratica { get; set; }
        Guid Uidtenant { get; set; }
    }
}