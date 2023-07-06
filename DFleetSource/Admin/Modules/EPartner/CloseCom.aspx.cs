// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CloseCom.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using DFleet.Classes;

namespace DFleet.Admin.Modules.EPartner
{
    public partial class CloseCom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
            {
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();
                IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
                IUtilitysBL servizioUtility = new UtilitysBL();

                //cancella comunicazione
                if (servizioComunicazioni.UpdateChiusuraComunicazione(uid, Uidtenant) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Chiusura " + uid);

                    //invio mail
                    IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(4);
                    if (dataTemplate != null)
                    {
                        Recuperadatiuser datiUtente = new Recuperadatiuser();
                        MailHelper.SendMail("", servizioComunicazioni.SelectEmailMittente(uid).Emailmittente, "", "", "", "", "Help Desk - Chiusura Ticket", servizioUtility.InsComEmail((Guid)Membership.GetUser().ProviderUserKey, uid, "", dataTemplate.Corpo), "", datiUtente.ReturnObjectTenant());
                    }

                    //messaggio avvenuta cancellazione
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-success";
                    lblMessage.Text = "Chiusura avvenuta correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/EPartner/ViewComunicazioni") + "'>Ritorna alla Lista</a>";
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
