// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ListDriver.aspx.cs" company="">
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
using Newtonsoft.Json;

namespace DFleet.Handler
{
    /// <summary>
    /// Summary description for ListDriver
    /// </summary>
    public class ListDriver : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            IAccountBL servizioAccount = new AccountBL();
            HttpRequest request = context.Request;
            List<string> listEmployee = new List<string>();

            string term = request["term"];
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            List<IAccount> data = servizioAccount.SelectUsersTerm(SeoHelper.EncodeString(term), Uidtenant);
            
            JavaScriptSerializer JS = new JavaScriptSerializer();
            context.Response.Write(JS.Serialize(data.Select(
                  item => new
                  {
                      label = item.Cognome,
                      value = item.UserId
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
