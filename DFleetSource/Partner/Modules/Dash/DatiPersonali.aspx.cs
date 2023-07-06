// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DatiPersonali.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using DFleet.Classes;

namespace DFleet.Partner.Modules.Dash
{
    public partial class DatiPersonali : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //hdiduser.Value = Membership.GetUser().ProviderUserKey.ToString();
            IAccountBL servizioAccount = new AccountBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                Guid uid = (Guid)Membership.GetUser().ProviderUserKey;
                IAccount data = servizioAccount.DetailId(uid);
                if (data != null)
                {
                    ltdati.Text += "<div class='table - responsive'><table class='table'>" +
                                   "<tr><td>Nome</td> <td>" + data.Nome + "</td></tr>" +
                                   "<tr><td>Cognome</td> <td> " + data.Cognome + "</td></tr>" +
                                   "<tr><td>Email</td> <td> " + data.Email + "</td></tr>" +
                                   "<tr><td>Cellulare</td> <td> " + data.Cellulare + "</td></tr>" +
                                   "<tr><td>Sede di lavoro</td> <td> " + data.Cittasede + " (" + data.Provinciasede + ")</td></tr>" +

                                   "</table></div>";
                }
                else
                {
                    Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                }                
            }
        }
        
    }
}
