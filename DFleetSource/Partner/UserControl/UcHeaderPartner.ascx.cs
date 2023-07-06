// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="UcHeaderPartner.ascx.cs" company="">
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

namespace DFleet.Partner.UserControl
{
    public partial class UcHeaderPartner : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            hduseridteam.Value = Membership.GetUser().ProviderUserKey.ToString();

            lblCountTask.Text = servizioUtility.SelectCountTaskAperti(UserId, Uidtenant).ToString();
            lblCountComunic.Text = servizioComunicazioni.SelectCountComunicazioniAperte(UserId, Uidtenant).ToString();
        }
        public string ReturnTestoTask(string testotask, string linktask)
        {
            string retVal;

            if (!string.IsNullOrEmpty(linktask))
            {
                retVal = "<a href='" + ResolveUrl("~/Partner/Modules/Dash/" + linktask + "") + "'><div><p><strong>" + testotask + "</strong></p></div></a>";
            }
            else
            {
                retVal = "<a href='javascript: void(0);'><div><p><strong>" + testotask + "</strong></p></div></a>";
            }

            return retVal;
        }
    }
}
