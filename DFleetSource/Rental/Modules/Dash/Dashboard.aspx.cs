// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Dashboard.aspx.cs" company="">
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
using DFleet.Classes;

namespace DFleet.Rental.Modules.Dash
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ILogBL log = new LogBL();
            log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "View Dashboard");

            IContrattiBL servizioContratti = new ContrattiBL();
            IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            hdcodfornitore.Value = datiUtente.Codfornitore;
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            hduiduser.Value = Membership.GetUser().ProviderUserKey.ToString();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            lblstatus10.Text = servizioContratti.SelectCountOrdiniRental(SeoHelper.EncodeString(hdcodfornitore.Value), 10).ToString();
            lblstatus20.Text = servizioContratti.SelectCountOrdiniRental(SeoHelper.EncodeString(hdcodfornitore.Value), 20).ToString();
            lblstatus50.Text = servizioContratti.SelectCountOrdiniRental(SeoHelper.EncodeString(hdcodfornitore.Value), 50).ToString();
            lblstatus55.Text = servizioContratti.SelectCountOrdiniRental(SeoHelper.EncodeString(hdcodfornitore.Value), 55).ToString();

            //conta comunicazioni
            if (servizioComunicazioni.SelectCountComunicazioni(UserId, DateTime.MinValue, DateTime.MinValue, 0, 0, 0, Uidtenant) == 0)
            {
                pnlMessage.Visible = true;
                lblMessage.Text = "<br><br> Nessun ticket aperto.";
            }
            else
            {
                pnlMessage.Visible = false;
            }
        }
    }
}
