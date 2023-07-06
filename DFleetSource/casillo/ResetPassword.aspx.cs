// ***********************************************************************
// Assembly         : DDocument
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="ResetPassword.ascx.cs" company="">
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

namespace DFleet.casillo
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    HttpContext.Current.Session["Sessionpwd"] = uid;
                    ILoginBL servizioLogin = new LoginBL();

                    IAccount data = servizioLogin.DetailId(uid);
                    if (data != null)
                    {

                        //hdemailuser.Value = data.Emailuser;

                        //verifica data - 1 ora
                        DateTime dataattuale = DateTime.Now;
                        DateTime datainviomail = data.Datainviomail;

                        int oredifferenza = dataattuale.Subtract(datainviomail).Hours;

                        if (oredifferenza > 1)
                        {
                            Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                        }


                        TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();

                        var setupInfo = tfa.GenerateSetupCode("4M-Casillo", data.Email, data.Email, false, 3);//the width and height of the Qr Code

                        string qrCodeImageUrl = setupInfo.QrCodeSetupImageUrl; //  assigning the Qr code information + URL to string
                                                                               //string manualEntrySetupCode = setupInfo.ManualEntryKey; // show the Manual Entry Key for the users that don't have app or phone
                        Image1.ImageUrl = qrCodeImageUrl;// showing the qr code on the page "linking the string to image element"
                                                         //Label1.Text = manualEntrySetupCode; // showing the manual Entry setup code for the users that can not use their phone
                    }
                    else
                    {
                        Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                    }
                }
            }
        }

        static bool ValidatePassword(string password)
        {
            const int MIN_LENGTH = 8;

            if (password == null) throw new ArgumentNullException();

            bool meetsLengthRequirements = password.Length >= MIN_LENGTH;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;

            if (meetsLengthRequirements)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    else if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;
                }
            }

            bool isValid = meetsLengthRequirements
                        && hasUpperCaseLetter
                        && hasLowerCaseLetter
                        && hasDecimalDigit
                        ;
            return isValid;

        }

        protected void btnInvia_Click(object sender, EventArgs e)
        {
            string error = string.Empty;

            if (!ValidatePassword(txtNuovaPassword.Text))
            {
                txtNuovaPassword.CssClass = "form-control is-invalid";
                error += "La password deve essere lunga almeno 8 caratteri, contenere almeno un carattere minuscolo, maiuscolo, numerico<br />";
            }
            else
            {
                if (txtNuovaPassword.Text != txtRipetiNuovaPassword.Text)
                {
                    error += "Le password non coincidono<br />";
                }
            }


            if (!string.IsNullOrEmpty(error))
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione. Il modulo non è stato compilato correttamente. Si sono verificati i seguenti errori:";
                lblMessage.Text += "<br /><br /><b>" + error + "</b><br />";
            }
            else
            {

                if (Guid.TryParse(SeoHelper.EncodeString(HttpContext.Current.Session["Sessionpwd"].ToString()), out Guid uid))
                {
                    ILoginBL servizioLogin = new LoginBL();

                    IAccount data = servizioLogin.DetailId(uid);
                    if (data != null)
                    {
                        MembershipUser user = Membership.GetUser(data.Email);
                        user.ChangePassword(user.ResetPassword(), txtNuovaPassword.Text);
                        Response.Redirect("ResetPasswordOK");
                    }
                    else
                    {
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-danger";
                        lblMessage.Text = "Operazione fallita.";
                    }
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text = "Operazione fallita.";
                }
            }
        }
    }
}
