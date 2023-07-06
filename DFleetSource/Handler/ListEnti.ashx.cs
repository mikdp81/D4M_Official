﻿// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ListEnti.aspx.cs" company="">
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
    /// Summary description for ListEnti
    /// </summary>
    public class ListEnti : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            IMulteBL servizioMulte = new MulteBL();
            HttpRequest request = context.Request;
            List<string> listEmployee = new List<string>();

            string ente = request["term"];
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            List<IMulte> data = servizioMulte.SelectAllEnti(SeoHelper.EncodeString(ente), Uidtenant);

            if (data != null && data.Count > 0)
            {
                foreach (IMulte result in data)
                {
                    listEmployee.Add(result.Ente);
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
