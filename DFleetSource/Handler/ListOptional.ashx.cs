// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ListOptional.aspx.cs" company="">
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
    /// Summary description for ListOptional
    /// </summary>
    public class ListOptional : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            ICarsBL servizioCar = new CarsBL();
            HttpRequest request = context.Request;
            List<string> listEmployee = new List<string>();

            string auto = request["term"];
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            List<ICars> data = servizioCar.SelectOptionalTerm(SeoHelper.EncodeString(auto), Uidtenant);

            JavaScriptSerializer JS = new JavaScriptSerializer();
            context.Response.Write(JS.Serialize(data.Select(
                  item => new
                  {
                      label = item.Optional,
                      value = item.Codoptional
                  })
                .ToList()));
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
