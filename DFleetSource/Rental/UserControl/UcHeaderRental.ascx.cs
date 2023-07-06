// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="UcHeaderRental.ascx.cs" company="">
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

namespace DFleet.Rental.UserControl
{
    public partial class UcHeaderRental : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccountBL servizioAccount = new AccountBL();

            //recupero tenant
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            IAccount dataTenant = servizioAccount.ReturnPropertyTenant(Uidtenant);
            if (dataTenant != null)
            {
                //logo
                if (!string.IsNullOrEmpty(dataTenant.Logo))
                {
                    ltLogo.Text = "<img src='" + ResolveUrl("~/plugins/images/" + dataTenant.Logo + "") + "' style='width:130px;' alt='home' />";
                }
            }
        }
    }
}
