// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DeleteOptional.aspx.cs" company="">
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

namespace DFleet.Handler
{
    /// <summary>
    /// Summary description for DeleteOptionalAuto
    /// </summary>
    public class DeleteOptionalAuto : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            ICarsBL servizioCars = new CarsBL();
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            string value = request["value"];
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            if (servizioCars.DeleteOptionalAuto(SeoHelper.GuidString(value), Uidtenant) == 1)
            {
                response.Write("OK");
            }
            else
            {
                response.Write("KO");
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
