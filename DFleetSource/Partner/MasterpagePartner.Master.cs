// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="MasterpagePartner.Master.cs" company="">
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

namespace DFleet.Partner
{
    public partial class MasterpagePartner : System.Web.UI.MasterPage
    {
        public event EventHandler ErrorDataBound;
        protected void Page_Init(object sender, EventArgs e)
        {
            if ((Context.Request.UrlReferrer == null || (Context.Request.Url.Host != Context.Request.UrlReferrer.Host && Context.Request.UrlReferrer.Host != "eu.docusign.net"
                && Context.Request.UrlReferrer.Host != "login.microsoftonline.com")))
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
            }
        }
    }
}
