// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ILogBL.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using BusinessObject;

namespace BusinessLogic
{
    public interface ILogBL
    {
        List<ILog> SelectLogAtt(string logatt, Guid UserId, Guid uidintervento);
        List<ILog> SelectLog(string log);
        int SelectCountLogAtt(string logatt, Guid UserId, Guid uidintervento);
        int InsertLogAtt(ILog value);
        List<ILog> SelectLogOperatore(Guid iduser, Guid uidintervento);
        void InsLog(string idattivita, string chiave);
    }
}