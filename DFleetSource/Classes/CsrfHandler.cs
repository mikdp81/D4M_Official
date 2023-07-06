// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CsrfHandler.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DFleet.Classes
{
    public static class CsrfHandler
    {
        public static void Validate(Page page, HiddenField forgeryToken)
        {
            if (!page.IsPostBack)
            {
                Guid antiforgeryToken = Guid.NewGuid();
                page.Session["AntiforgeryToken"] = antiforgeryToken;
                forgeryToken.Value = antiforgeryToken.ToString();
            }
            else
            {
                if (page.Session["AntiforgeryToken"] != null)
                {
                    Guid stored = (Guid)page.Session["AntiforgeryToken"];
                    Guid sent = new Guid(forgeryToken.Value);
                    if (sent != stored)
                    {
                        // you can throw an exception, in my case I'm just logging the user out
                        page.Session.Abandon();
                        //page.Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    page.Session.Abandon();
                }
            }
        }
    }
}
