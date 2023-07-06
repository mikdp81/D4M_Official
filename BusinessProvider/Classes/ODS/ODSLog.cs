// ***********************************************************************
// Assembly         : BusinessProvider
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CODSLog.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Security.Permissions;
using BusinessObject;
using DataProvider;


namespace BusinessProvider
{
    [DataObject(true)]

    public class OdsLog : ODSProvider<LogProvider>, IOdsLog
    {
        private readonly LogProvider logProvider = (LogProvider)new ProviderFactory().ServizioAccount;

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ILog> SelectLog(string log)
        {
            return logProvider.SelectLog(log);
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ILog> SelectLogAtt(string logatt, Guid UserId, Guid uidintervento)
        {
            return logProvider.SelectLogAtt(logatt, UserId, uidintervento);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public int SelectCountLogAtt(string logatt, Guid UserId, Guid uidintervento)
        {
            return logProvider.SelectCountLogAtt(logatt, UserId, uidintervento);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public int InsertLogAtt(ILog value)
        {
            return logProvider.InsertLogAtt(value);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ILog> SelectLogOperatore(Guid iduser, Guid uidintervento)
        {
            return logProvider.SelectLogOperatore(iduser, uidintervento);
        }

    }
}
