using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Security;
using BusinessLogic;
using BusinessObject;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace DFleet
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Request.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                        new AuthenticationProperties { RedirectUri = "Admin/Modules/Dash/dashboard" },
                        //new AuthenticationProperties { RedirectUri = "Login/login" },
                        OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
            /*else
             {
                 Response.Redirect("~/defaultEX");
                 // LOGOUT
                 /*HttpContext.Current.GetOwinContext().Authentication.SignOut(
                         OpenIdConnectAuthenticationDefaults.AuthenticationType,
                         CookieAuthenticationDefaults.AuthenticationType);
             }*/
        }
    }
}
