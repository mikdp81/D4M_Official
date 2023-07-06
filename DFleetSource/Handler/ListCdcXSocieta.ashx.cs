// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ListCdcXSocieta.aspx.cs" company="">
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
    /// Summary description for ListCdcXSocieta
    /// </summary>
    public class ListCdcXSocieta : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            IAccountBL servizioAccount = new AccountBL();
            HttpRequest request = context.Request;
            List<string> listEmployee = new List<string>();

            string codsocieta = request["codsocieta"];
            string term = request["term"];

            List<IAccount> data = servizioAccount.SelectCDCXSocieta2(SeoHelper.EncodeString(codsocieta), SeoHelper.EncodeString(term));

            if (data != null && data.Count > 0)
            {
                foreach (IAccount result in data)
                {
                    listEmployee.Add(result.Cognome);
                }
            }
            JavaScriptSerializer JS = new JavaScriptSerializer();
            context.Response.Write(JS.Serialize(listEmployee));
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
