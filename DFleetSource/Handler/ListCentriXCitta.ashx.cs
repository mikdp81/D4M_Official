// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ListCentriXCitta.aspx.cs" company="">
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
    /// Summary description for ListCentriXCitta
    /// </summary>
    public class ListCentriXCitta : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            string citta = request["citta"];
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            string jsonResponse = string.Empty;

            List<IUtilitys> data = servizioUtility.SelectCentriXCitta(SeoHelper.EncodeString(citta), Uidtenant);

            if (data != null)
                data.Select(
                  item => new
                  {
                      name = item.Centro,
                      id = item.Centro
                  })
                .ToList()
                .SerializeListTo(out jsonResponse);

            response.Clear();
            response.ClearHeaders();
            response.ClearContent();
            response.ContentEncoding = Encoding.UTF8;
            response.ContentType = "text/javascript";
            response.Write(jsonResponse);
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
