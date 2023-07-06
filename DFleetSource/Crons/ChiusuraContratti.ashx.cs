// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ChiusuraContratti.aspx.cs" company="">
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
    /// Summary description for ChiusuraContratti
    /// </summary>
    public class ChiusuraContratti : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            ICronBL servizioCron = new CronBL();
            HttpResponse response = context.Response;

            List<ICron> data = servizioCron.SelectContrattiDaChiudere();

            if (data != null && data.Count > 0)
            {
                foreach (ICron result in data)
                {
                    if (servizioCron.UpdateContrattiDaChiudere(result.Uid, Uidtenant) == 1)
                    {
                        if (servizioCron.UpdateContrattiAssDaChiudere(result.Idcontratto, Uidtenant) == 1)
                        {
                            response.Write("UPDATE EF_contratti SET [idstatuscontratto] = 100 WHERE Uid = " + result.Uid + "<br />");
                            response.Write("UPDATE EF_contratti_assegnazioni SET [idstatusassegnazione] = 100 WHERE idcontratto = " + result.Idcontratto + "<br />");
                        }
                    }
                    else
                    {
                        response.Write("Contratto " + result.Uid + " - ERRORE! Non processato. <br />");
                    }
                }
            }
            else
            {
                response.Write("Nessun contratto chiuso");
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
