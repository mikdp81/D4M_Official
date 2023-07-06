// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="IODSLog.cs" company="">
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

namespace BusinessObject
{
    public interface IOdsLog
    {

        List<ILog> SelectLog(string log);

        List<ILog> SelectLogAtt(string logatt, Guid UserId, Guid uidintervento);
        int SelectCountLogAtt(string logatt, Guid UserId, Guid uidintervento);

        int InsertLogAtt(ILog value);

        List<ILog> SelectLogOperatore(Guid iduser, Guid uidintervento);

    }
}
