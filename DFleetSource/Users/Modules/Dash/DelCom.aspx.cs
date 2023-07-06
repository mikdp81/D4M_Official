// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DelCom.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using DFleet.Classes;

namespace DFleet.Users.Modules.Dash
{
    public partial class DelCom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
            {
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();
                IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
                IAccountBL servizioAccount = new AccountBL();
                IUtilitysBL servizioUtility = new UtilitysBL();

                //cancella comunicazione
                if (servizioComunicazioni.UpdateStatoComunicazione(1000, uid, Uidtenant) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Cancellazione " + uid);


                    //invio mail
                    IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(4);
                    if (dataTemplate != null)
                    {
                        Recuperadatiuser datiUtente = new Recuperadatiuser();
                        MailHelper.SendMail("", servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey).Email, "", "", "", "", "Chiusura Comunicazione", servizioUtility.InsComEmail((Guid)Membership.GetUser().ProviderUserKey, uid, "", dataTemplate.Corpo), "", datiUtente.ReturnObjectTenant());
                    }

                    //messaggio avvenuta cancellazione
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-success";
                    lblMessage.Text = "Cancellazione avvenuta correttamente <br /> <a href='" + ResolveUrl("~/Users/Modules/Dash/ViewComunicazioni") + "'>Ritorna alla Lista</a>";
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
