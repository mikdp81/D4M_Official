// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ListCarPolicyXCarList.aspx.cs" company="">
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
    /// Summary description for ListCarPolicyXCarList
    /// </summary>
    public class ListCarPolicyXCarList : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            string codcarlist = request["codcarlist"];
            string jsonResponse = string.Empty;

            List<IContratti> data = servizioContratti.SelectCarPolicyXCarList(SeoHelper.EncodeString(codcarlist));

            if (data != null)
                data.Select(
                  item => new
                  {
                      name = item.Codcarpolicy,
                      id = item.Codcarpolicy
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
