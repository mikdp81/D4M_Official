// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsUserRobotFull.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using System.Web;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Drawing;
using DFleet.Classes;
using AraneaUtilities.Auth.Roles;

namespace DFleet.Admin.Modules.Users
{
    public partial class InsUserRobotFull : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {             
            
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            InsertAccount();
        }


        public void InsertAccount()
        {
            IAccountBL servizioAccount = new AccountBL();
            Guid userId;
            string email;

            List<IAccount> dataExport = servizioAccount.SelectUsersXDate(SeoHelper.DataString("2023-02-23 08:00:00"));

            if (dataExport != null && dataExport.Count > 0)
            {
                foreach (IAccount resultExport in dataExport)
                {
                    email = resultExport.Email;

                    if (!string.IsNullOrEmpty(email))
                    { 
                        // se l'utente non è già esistente: creo utente
                        MembershipUserCollection utenti = Membership.FindUsersByEmail(SeoHelper.EncodeString(email));
                        if (utenti.Count == 0)
                        {
                            Membership.CreateUser(SeoHelper.EncodeString(email), "Dfleet2021.", SeoHelper.EncodeString(email)); //crea utente

                            // devo passare a DCreditUser
                            if (!Roles.IsUserInRole(SeoHelper.EncodeString(email), DFleetGlobals.UserRoles.User))
                                Roles.AddUserToRole(SeoHelper.EncodeString(email), DFleetGlobals.UserRoles.User);
                            // devo rimuovere a DCreditAdmin
                            if (Roles.IsUserInRole(SeoHelper.EncodeString(email), DFleetGlobals.UserRoles.Admin))
                                Roles.RemoveUserFromRole(SeoHelper.EncodeString(email), DFleetGlobals.UserRoles.Admin);


                            //recupera guid utente
                            userId = (Guid)Membership.GetUser(SeoHelper.EncodeString(email)).ProviderUserKey;

                            //aggiorna userid 
                            servizioAccount.UpdateUsersRobot(email, userId);

                            lblMessage.Text += "Nuovo Membership inserito: " + email + "<br />";
                        }
                    }
                }
            }            
        }
    }
}
