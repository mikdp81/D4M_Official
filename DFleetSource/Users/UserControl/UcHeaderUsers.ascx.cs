// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ucHeaderUsers.ascx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Web.Security;
using BusinessObject;
using BusinessLogic;
using System.Web.Services;
using System.Globalization;
using DFleet.Classes;

namespace DFleet.Users.UserControl
{
    public partial class UcHeaderUsers : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();

            //recupero tenant
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            IAccount dataTenant = servizioAccount.ReturnPropertyTenant(Uidtenant);
            if (dataTenant != null)
            {
                //logo
                if (!string.IsNullOrEmpty(dataTenant.Logo))
                {
                    ltLogo.Text = "<img src='" + ResolveUrl("~/plugins/images/" + dataTenant.Logo + "") + "' style='width:130px;' alt='home' /></a>";

                    //logo per mobile
                    ltLogoMobile.Text = "<img src='" + ResolveUrl("~/plugins/images/" + dataTenant.Logo + "") + "' style='width:100px;' alt='home' />";
                }
            }

            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            hduseridteam.Value = Membership.GetUser().ProviderUserKey.ToString();

            lblCountTask.Text = servizioUtility.SelectCountTaskAperti(UserId, Uidtenant).ToString();
            lblCountComunic.Text = servizioComunicazioni.SelectCountComunicazioniAperte(UserId, Uidtenant).ToString();

            if (servizioContratti.SelectCountDelegheDriver(UserId) == 0)
            {
                ddlChangeUser.Visible = false;
            }           

        }
        protected void ddlChangeUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = (DropDownList)sender;
            string value = (string)list.SelectedValue;

            Response.Redirect(ResolveUrl("~/ChangePartner-" + value));
        }
        public string ReturnTestoTask(string testotask, string linktask)
        {
            string retVal;

            if (!string.IsNullOrEmpty(linktask))
            {
                if (testotask == "Accetta/Contesta multa")
                {
                    retVal = "<a href='" + ResolveUrl("~/Users/Modules/Multa/" + linktask + "") + "'><div><p><strong>" + testotask + "</strong></p></div></a>";
                }
                else                 
                {
                    retVal = "<a href='" + ResolveUrl("~/Users/Modules/Ordini/" + linktask + "") + "'><div><p><strong>" + testotask + "</strong></p></div></a>";
                }
            }
            else
            {
                retVal = "<a href='javascript: void(0);'><div><p><strong>" + testotask + "</strong></p></div></a>";
            }

            return retVal;
        }
    }
}
