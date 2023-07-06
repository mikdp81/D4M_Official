// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="MasterpageAdmin.Master.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using BusinessObject;
using BusinessLogic;
using System.Web.UI.WebControls;
using DFleet.Classes;
using System.Web.Helpers;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace DFleet.Admin
{
    public partial class MasterpageAdmin : System.Web.UI.MasterPage
    {
        public event EventHandler ErrorDataBound;

        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            if ((Context.Request.UrlReferrer == null || (Context.Request.Url.Host != Context.Request.UrlReferrer.Host && Context.Request.UrlReferrer.Host != "eu.docusign.net" 
                && Context.Request.UrlReferrer.Host != "demo.docusign.net" && Context.Request.UrlReferrer.Host != "login.microsoftonline.com")))
            {
                //Response.Redirect("~/UnauthorizedAccess.html?d=error_referer");
            }


            //protect against XSRF attacks
            var requestCookie = Session[AntiXsrfTokenKey];
            if (requestCookie != null && Guid.TryParse(requestCookie.ToString(), out Guid requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.ToString();
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {

                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                Session[AntiXsrfTokenKey] = _antiXsrfTokenValue;
            }


            Page.PreLoad += master_Page_PreLoad;
        }
        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    // Set Anti-XSRF token
                    ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                    ViewState[AntiXsrfUserNameKey] = Session.SessionID ?? string.Empty;
                }
                else
                {

                    // Validate the Anti-XSRF token
                    if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                        || (string)ViewState[AntiXsrfUserNameKey] != (Session.SessionID ?? string.Empty))
                    {

                        Response.Redirect("~/UnauthorizedAccess.html");
                    }
                }
            }
            catch
            {
                Response.Redirect("~/UnauthorizedAccess.html");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (IsPostBack)
            {
                AntiForgery.Validate(); // throws an exception if anti XSFR check fails.
                CsrfHandler.Validate(this.Page, forgeryToken);
            }*/


            Guid iduser = (Guid)Membership.GetUser().ProviderUserKey;
            
            string emailuser = string.Empty;

            IAccountBL servizioAccount = new AccountBL();
            IAccount data = servizioAccount.DetailId(iduser);
            if (data != null)
            {
                emailuser = data.Email;
            }
            else
            {
                ErrorDataBound?.Invoke(this, EventArgs.Empty);
            }


            bool auth2 = servizioAccount.ExistUserStatus(emailuser);

            if (!auth2)
            {
                Response.Redirect(ResolveUrl("~/Default"));
            }
            else
            {
                //recupero tenant
                Recuperadatiuser datiUtente = new Recuperadatiuser();
                Guid Uidtenant = datiUtente.ReturnUidTenant();

                if (HttpContext.Current.Session["UidTenant"] == null)
                {
                    HttpContext.Current.Session["UidTenant"] = Uidtenant;
                }
                else
                {
                    Uidtenant = SeoHelper.ReturnSessionTenant();
                }

                IAccount dataTenant = servizioAccount.ReturnPropertyTenant(Uidtenant);
                if (dataTenant != null)
                {
                    ltCss.Text = "<style type='text/css'>" +
                                 ".navbar-header{background:" + dataTenant.Bgbarratop + " !important;}" +
                                 ".sidebar{background:" + dataTenant.Bgbarrasx + " !important;}" +
                                 ".sidebar-nav ul#side-menu li a{color:" + dataTenant.Colormenusx + " !important;}" +
                                 "</style>";
                }
            }
        }
        public string ReturnTxt(string label)
        {
            string resculture = "it-IT";
            if (string.IsNullOrEmpty(resculture)) resculture = HttpContext.Current.Request.UserLanguages[0]; //se non è passata la lingua ricava valore del browser
            ResourceManager resourceManager = new ResourceManager("DFleet.App_GlobalResources", Assembly.GetExecutingAssembly());
            return resourceManager.GetString(label, new CultureInfo(resculture));
        }
    }
}
