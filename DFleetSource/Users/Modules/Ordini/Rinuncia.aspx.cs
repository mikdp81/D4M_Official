// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Rinuncia.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using System.Linq;
using DFleet.Classes;

namespace DFleet.Users.Modules.Ordini
{
    public partial class Rinuncia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
            int idutente = 0;
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();

            IAccount data = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
            if (data != null)
            {
                idutente = data.Iduser;
            }

            if (servizioContratti.UpdateRinunciaCarPolicy(idutente, SeoHelper.ReturnSessionTenant()) == 1)
            {
                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Rinuncia configurazione Users: " + (Guid)Membership.GetUser().ProviderUserKey);

                //messaggio avvenuta cancellazione
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-success";
                lblMessage.Text = "Rinuncia avvenuta correttamente";
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
