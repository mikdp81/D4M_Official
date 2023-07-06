// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="delUser.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using DFleet.Classes;
using AraneaUtilities.Auth.Roles;

namespace DFleet.Admin.Modules.Users
{
    public partial class DelUser : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(1)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = string.Empty;
            if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
            {
                IAccountBL servizioAccount = new AccountBL();

                //recupera email utente
                IAccount dataemail = servizioAccount.DetailId(uid);
                if (dataemail != null)
                {
                    email = dataemail.Email;
                }

                //cancella user
                IAccount accountDel = new Account
                {
                    UserId = uid,
                    Uidtenant = SeoHelper.ReturnSessionTenant()
                };
                bool isAdmin = Roles.IsUserInRole(email, DFleetGlobals.UserRoles.Admin);
                bool isUser = Roles.IsUserInRole(email, DFleetGlobals.UserRoles.User);
                bool isGuest = Roles.IsUserInRole(email, DFleetGlobals.UserRoles.Guest);
                bool isPartner = Roles.IsUserInRole(email, DFleetGlobals.UserRoles.Partner);

                if (servizioAccount.Delete(accountDel) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Delete " + accountDel.UserId);


                    if (isAdmin)
                    {
                        Roles.RemoveUserFromRole(email, DFleetGlobals.UserRoles.Admin);
                    }

                    if (isUser)
                    {
                        Roles.RemoveUserFromRole(email, DFleetGlobals.UserRoles.User);
                    }

                    if (isGuest)
                    {
                        Roles.RemoveUserFromRole(email, DFleetGlobals.UserRoles.Guest);
                    }

                    if (isPartner)
                    {
                        Roles.RemoveUserFromRole(email, DFleetGlobals.UserRoles.Partner);
                    }

                    Membership.DeleteUser(email);

                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Operazione fallita";
                }
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text += "Operazione fallita";
            }


        }
    }
}
