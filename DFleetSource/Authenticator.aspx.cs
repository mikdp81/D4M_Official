// ***********************************************************************
// Assembly         : DDocument
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="Authenticator.ascx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;
using BusinessLogic;
using Google.Authenticator;
using DFleet.Classes;
using AraneaUtilities.Auth.Roles;

namespace DFleet
{
    public partial class Authenticator : System.Web.UI.Page
    {
#pragma warning disable IDE0044 // Add readonly modifier
        Recuperadatiuser tnomeutente = new Recuperadatiuser();
#pragma warning restore IDE0044 // Add readonly modifier
        protected void Page_Load(object sender, EventArgs e)
        {
            //controllo login (se esiste rende immagine qr non visibile)
            IAccountBL servizioAccount = new AccountBL();

            if (servizioAccount.ExistLogin((Guid)Membership.GetUser().ProviderUserKey))
            {
                Image1.Visible = false;
            }



            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();

            var setupInfo = tfa.GenerateSetupCode("D4M", tnomeutente.Emailuser, tnomeutente.Emailuser, false, 3);//the width and height of the Qr Code

            string qrCodeImageUrl = setupInfo.QrCodeSetupImageUrl; //  assigning the Qr code information + URL to string
            //string manualEntrySetupCode = setupInfo.ManualEntryKey; // show the Manual Entry Key for the users that don't have app or phone
            Image1.ImageUrl = qrCodeImageUrl;// showing the qr code on the page "linking the string to image element"
            //Label1.Text = manualEntrySetupCode; // showing the manual Entry setup code for the users that can not use their phone
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string returnUrl = string.Empty;

            string user_enter = TextBox1.Text;
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();

            bool isCorrectPIN = tfa.ValidateTwoFactorPIN(tnomeutente.Emailuser, user_enter, TimeSpan.FromSeconds(60));
            if (isCorrectPIN == true)
            {
                if (Roles.IsUserInRole(tnomeutente.Emailuser, DFleetGlobals.UserRoles.Guest)) //se cliente
                {
                    returnUrl = "Rental/Modules/Dash/Dashboard";
                }

                Response.Redirect(returnUrl);
            }
            else
            {
                Label2.Text = "Errore di autenticazione";
            }
        }
    }
}
