// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ConvertDaPagareDeloitte.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text;
using BusinessObject;
using BusinessLogic;
using System.Globalization;
using System.Web.Script.Serialization;

namespace DFleet.Crons
{
    /// <summary>
    /// Summary description for ConvertDaPagareDeloitte
    /// </summary>
    public class ConvertDaPagareDeloitte : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            ICronBL servizioCron = new CronBL();
            HttpResponse response = context.Response;

            List<ICron> data = servizioCron.SelectMulteDapagare();

            if (data != null && data.Count > 0)
            {
                foreach (ICron result in data)
                {
                    if (servizioCron.UpdatePagamento(result.Uid, Uidtenant) == 1)
                    {
                        response.Write("UPDATE EF_multe SET [idstatuspagamento] = 10, [idtitolarepagamento] = 100 WHERE Uid = " + result.Uid + "<br />");
                    }
                    else
                    {
                        response.Write("Multa " + result.Uid + " - ERRORE! Non processata. <br />");
                    }
                }
            }
            else
            {
                response.Write("Nessuna multa processata");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
