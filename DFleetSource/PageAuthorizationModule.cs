// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="PageAuthorizationModule.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using BusinessLogic;
using BusinessObject;
using BusinessObject.Classes;
using BusinessProvider;
using DocumentFormat.OpenXml.InkML;
using DFleet.Admin;
using System.Globalization;
using AraneaUtilities.Auth.Roles;

namespace DFleet
{
    public class PageAuthorizationModule: IHttpModule, IRequiresSessionState
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            //context.LogRequest += new EventHandler(OnLogRequest);

            context.PreRequestHandlerExecute+= new EventHandler(OnPageRequest);
            //context.PreRequestHandlerExecute += new EventHandler(OnDast);

            //context.AuthorizeRequest += new EventHandler(PostAuthenticate);
            // context.EndRequest += new EventHandler(OnEndRequest);
        }

        #endregion


        public static Dictionary<Guid, List<PageInfo>> listeAttivita = new Dictionary<Guid, List<PageInfo>>();
        private const string AUTH_FOLDER = "admin";
        private Uri url;
        private HttpContext context;

        public void OnDast(object o, EventArgs ea)
        {

            // OWASP: Incomplete or No Cache-control and Pragma HTTP Header Set
            HttpContext.Current.Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            HttpContext.Current.Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            HttpContext.Current.Response.AppendHeader("Expires", "0"); // Proxies.
        }

        public void OnPageRequest(object o, EventArgs ea)
        {

            context = HttpContext.Current;
            url = HttpContext.Current.Request.Url;

            // se punta alle pagine interne ad "admin": valutare autorizzazione
            if (url != null && url.AbsolutePath.ToLower().Contains(AUTH_FOLDER))
            {
                // url della richiesta
                //string urlString = context.Request.Url.ToString().ToLower();

                // se non sono autenticato: security exception
                if (!context.Request.IsAuthenticated)
                {
                    if (!url.ToString().Contains(".js")) // TOPPA per un errore che non so correggere!
                        throw new SecurityException();
                }

                // se sono Admin sono già autorizzato consento la richiesta
                else if (Roles.IsUserInRole(Membership.GetUser().UserName, DFleetGlobals.UserRoles.Admin))
                {
                    // TUTTO OK
                }
                // se sono User o Bank devo valutare l'autorizzazione alla pagina
                else
                {

                    if (context.Request.IsAuthenticated)
                    {
                        if (Roles.IsUserInRole(Membership.GetUser().UserName, DFleetGlobals.UserRoles.User))
                        {
                            context.Response.Redirect("../../../Users/Modules/Dash/Dashboard");
                        }

                        if (Roles.IsUserInRole(Membership.GetUser().UserName, DFleetGlobals.UserRoles.Guest))
                        {
                            context.Response.Redirect("../../../Rental/Modules/Dash/Dashboard");
                        }

                        if (Roles.IsUserInRole(Membership.GetUser().UserName, DFleetGlobals.UserRoles.Partner))
                        {
                            context.Response.Redirect("../../../Partner/Modules/Dash/Dashboard");
                        }

                        if (!checkAuth())
                        {
                            //throw new UnauthorizedAccessException();
                            context.Response.Redirect("../../../UnauthorizedAccess.html?g=" + Membership.GetUser().UserName);
                        }
                    }
                    // per ogni altro tipo di utente: ACCESSO NEGATO
                    else
                    {
                        //throw new UnauthorizedAccessException();
                        context.Response.Redirect("../../../UnauthorizedAccess.html?h=" + Membership.GetUser().UserName);
                    }
                }
            }
        }


        private bool checkAuth()
        {
            bool ok = true;

            return ok;
        }



        public static void OnEndSession(object o, EventArgs ea)
        {
            
        }
    }


}
