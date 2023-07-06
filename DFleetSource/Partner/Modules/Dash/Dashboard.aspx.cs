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

namespace DFleet.Partner.Modules.Dash
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ILogBL log = new LogBL();
            log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "View Dashboard");

            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();

            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idutente = 0;

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;
            }


            //esistenza car policy -- se non esiste opacizza il blocco scegli auto
            if (!servizioContratti.ExistUserCarPolicyActive(idutente))
            {
                //schedasx.Attributes.Remove("onclick");
                //schedasx.Attributes["class"] = "backgroundopacity50";
            }


            //dati auto
            IContratti data2 = servizioContratti.DetailVeicoloAttualeDriver(UserId);
            if (data2 != null)
            {
                lblRental.Text = data2.Fornitore;
                lblTarga.Text = data2.Targa;
                lblModello.Text = data2.Modello;

                IContratti dataA = servizioContratti.DetailContrattiAssId(data2.Idcontratto, UserId);
                if (dataA != null)
                {
                    lbldataritiro.Text = dataA.Assegnatodal.ToString("dd/MM/yyyy");
                }
            }
        }
    }
}
