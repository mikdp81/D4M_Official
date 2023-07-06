// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CLogBL.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using BusinessObject;
using BusinessProvider;
using BaseProvider;

namespace BusinessLogic
{
    [Serializable]
    public class LogBL : BaseBL, ILogBL
    {
        private ILogProvider ServizioLog
        {
            get { return BaseProviderManager<LogProvider>.Provider; }
        }

        public LogBL() : base() { }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ILog> SelectLog(string log)
        {
            return OdsLog.DefaultProvider.SelectLog(log);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ILog> SelectLogAtt(string logatt, Guid UserId, Guid uidintervento)
        {
            return OdsLog.DefaultProvider.SelectLogAtt(logatt, UserId, uidintervento);
        }

        public int InsertLogAtt(ILog value)
        {
            ILogProvider servizioLog = ServizioLog;
            int retVal = 0;
            if (servizioLog.InsertLogAtt(value) == 1)
            {
                retVal = 1;
            }

            return retVal;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ILog> SelectLogOperatore(Guid iduser, Guid uidintervento)
        {
            return OdsLog.DefaultProvider.SelectLogOperatore(iduser, uidintervento);
        }
        public int SelectCountLogAtt(string logatt, Guid UserId, Guid uidintervento)
        {
            ILogProvider servizioLog = ServizioLog;
            int retVal;
            retVal = servizioLog.SelectCountLogAtt(logatt, UserId, uidintervento);
            return retVal;
        }

        public void InsLog(string idattivita, string chiave)
        {
            ILogProvider servizioLog = ServizioLog;
            ILog logNew = new Log
            { 
                Idattivita = SeoHelper.EncodeString(idattivita),
                Chiave = SeoHelper.EncodeString(chiave)
            };
            servizioLog.InsertLogAtt(logNew);
        }
    }
}