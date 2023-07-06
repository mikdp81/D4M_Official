// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="insUser.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text.RegularExpressions;
using System.Web;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using DFleet.Classes;
using AraneaUtilities.Auth.Roles;

namespace DFleet.Admin.Modules.Users
{
    public partial class InsUserRobot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {             
            pnlMessage.Visible = false;
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            InsertAccount();
        }


        public void InsertAccount()
        {
            IAccountBL servizioAccount = new AccountBL();
            Guid userId;

            //controllo email corretta
            Regex emailregexp = new Regex("(?<user>[^@]+)@(?<host>.+)");
            Match controlloEmail = emailregexp.Match(txtEmail.Text);

            if (!controlloEmail.Success)
            {
                txtEmail.CssClass = "form-control is-invalid";
            }
            else
            {
                txtEmail.CssClass = "form-control";

                // se l'utente non è già esistente: creo utente
                MembershipUserCollection utenti = Membership.FindUsersByEmail(SeoHelper.EncodeString(txtEmail.Text));
                if (utenti.Count == 0)
                {
                    //ERR: crea l'utente anche se username = ""
                    Membership.CreateUser(SeoHelper.EncodeString(txtEmail.Text), "Dfleet2021.", SeoHelper.EncodeString(txtEmail.Text)); //crea utente
                }
                // altrimenti?
                //else ????

                //controllo check amministratore
                if (ddlGruppo.SelectedValue != null)
                {
                    switch (ddlGruppo.SelectedValue)
                    {
                        case "2": //UTENTE

                            // devo passare a DCreditUser
                            if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User))
                                Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User);
                            // devo rimuovere a DCreditAdmin
                            if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin))
                                Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin);

                            break;
                        case "1": //AMMINISTATORE

                            // devo passare a DCreditAdmin
                            if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin))
                                Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin);
                            // devo rimuovere a DCreditUser
                            if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User))
                                Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User);

                            break;

                        case "3": //GUEST

                            // devo passare a DCreditGuest
                            if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Guest))
                                Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Guest);
                            // devo rimuovere a DCreditAdmin
                            if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin))
                                Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin);

                            break;

                        case "4": //PARTNER

                            // devo passare a DCreditPartner
                            if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Partner))
                                Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Partner);
                            // devo rimuovere a DCreditAdmin
                            if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin))
                                Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin);

                            break;

                        default: //UTENTE

                            // devo passare a DCreditUser
                            if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User))
                                Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User);
                            // devo rimuovere a DCreditAdmin
                            if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin))
                                Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin);

                            break;
                    }
                }

                userId = (Guid)Membership.GetUser(SeoHelper.EncodeString(txtEmail.Text)).ProviderUserKey; //recupera guid utente


                //aggiorna userid 

                servizioAccount.UpdateUsersRobot(txtEmail.Text, userId);
            }

            txtEmail.Text = "";

            //messaggio avvenuto inserimento
            pnlMessage.Visible = true;
            pnlMessage.CssClass = "alert alert-success";
            lblMessage.Text = "Inserimento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Users/ViewUsers") + "'>Ritorna alla Lista</a>";
            
        }
    }
}
