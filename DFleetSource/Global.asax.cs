// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Global.asax.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.SessionState;
using BusinessObject;
using BusinessLogic;
using BusinessLogic.Services.exceptions;
using System.Globalization;
using AraneaUtilities.Auth.Roles;

namespace DFleet
{
    public class Global : System.Web.HttpApplication
    {
        public static string sas = ReturnSas();
        
        //public static ICronBL servizioCron = new CronBL();
        //public static string sas = EncryptHelper.Decrypt(servizioCron.UrlBlob().Urlblob, SeoHelper.PassPhrase()); //recupero url azure blob
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["DomainName"] = String.Concat(HttpContext.Current.Request.Url.ToString().Replace(HttpContext.Current.Request.Url.PathAndQuery.ToString(CultureInfo.CurrentCulture), ""), "/");
            Session["Sas"] = sas;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)        
        {
            this.Response.Headers["X-Content-Type-Options"] = "nosniff";
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            if(Context !=null)
            {
                Exception err = Server.GetLastError();
                if(err != null)
                {
                    string errMsg = new DFleetExceptionManager().Execute(err);
                    Application["err"] = errMsg + "\n\n Inner Exception:\n\n" + err.InnerException;
                }
                Server.ClearError();
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //PageAuthorizationModule.OnEndSession(sender, e);
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {

           /* if (Response.Cookies.Count > 0)
            {
                foreach (string s in Response.Cookies.AllKeys)
                {
                    Response.Cookies[s].Secure = true;
                }
            }*/
        }
        public static string ReturnSas()
        {
            //D4M PROD
            return "https://ititsazuprdeuw385sto02.blob.core.windows.net/?sv=2020-08-04&ss=bf&srt=sco&sp=rwdlacitfx&se=2025-05-19T22:01:16Z&st=2022-05-19T14:01:16Z&spr=https&sig=AHeB3LosYh8EOvRKAmKOq0%2FZpwTMIUL37j1MO0Jywg4%3D"; //recupero url azure blob                                

            //4M PROD
            //return "https://itconazuprdeun558sto02.blob.core.windows.net/?sv=2022-11-02&ss=bfqt&srt=sco&sp=rwdlacupiytfx&se=2026-05-23T17:55:05Z&st=2023-05-23T09:55:05Z&spr=https&sig=DeGa5iHPc2YQZQuTMeI59JLliwxjv4kOqzwJGR5E5Mc%3D"; //recupero url azure blob
            
            //D4M TEST
            //return "https://ititsazunpdeun373sto02.blob.core.windows.net/?sv=2020-08-04&ss=bf&srt=co&sp=rwdlacitfx&se=2023-03-31T16:00:00Z&st=2022-03-25T08:33:56Z&spr=https&sig=gWTjigGGxDBe8Jgy1UAxYn98kjy0xa8MpT4Qw1E8pq0%3D";
        
        }
    }
}

