// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DefaultDeloitte.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Security;
using AraneaUtilities.Auth;
using AraneaUtilities.Auth.Roles;
using BusinessLogic;
using BusinessObject;
using DFleet.Classes;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace DFleet
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                new AuthenticationProperties { RedirectUri = "Default" },
                OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
            else
            {
                string redirect;
                var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;

                string email = claimsIdentity.Name;

                if (!string.IsNullOrEmpty(email))
                {
                    bool ok;
                    string sessionID = "U" + "idUtente" + "-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
                    HttpContext.Current.Session["UIDsession"] = sessionID;

                    //autorizza gli accessi
                    ok = AuthManager.SignIn(sessionID, email, false);

                    if (ok)
                    {
                        if (Roles.IsUserInRole(email, DFleetGlobals.UserRoles.Partner))
                        {
                            redirect = "Partner/Modules/Dash/Dashboard";
                        }
                        else
                        {
                            if (Roles.IsUserInRole(email, DFleetGlobals.UserRoles.Guest))
                            {
                                redirect = "Rental/Modules/Dash/Dashboard";
                            }
                            else
                            {
                                if (Roles.IsUserInRole(email, DFleetGlobals.UserRoles.User))
                                {
                                    redirect = "Users/Modules/Dash/Dashboard";
                                }
                                else
                                {
                                    if (Roles.IsUserInRole(email, DFleetGlobals.UserRoles.Admin))
                                    {
                                        redirect = "Admin/Modules/Dash/dashboard";
                                    }
                                    else
                                    {
                                        redirect = "UnauthorizedAccess.html?d=emailerrata";
                                    }
                                }
                            }
                        }
                        Response.Redirect(redirect);

                    }
                    else
                    {
                        Response.Redirect(ResolveUrl("UnauthorizedAccess.html?d=emailerrata"));
                    }
                }
                else
                {
                    Response.Redirect(ResolveUrl("UnauthorizedAccess.html?d=emailerrata"));
                }

            }
        }
    }
}
