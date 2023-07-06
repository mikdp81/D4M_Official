// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="DashboardReact2.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Security.Permissions;
using System.Threading;
using System.Web.Security;
using BusinessLogic;
using BusinessObject;
using System.Globalization;
using System.Collections.Generic;
using DFleet.Classes;

namespace DFleet.Admin.Modules.Dash
{

    public partial class DashboardReact2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            hduiduser.Value = Membership.GetUser().ProviderUserKey.ToString();

            if (!Page.IsPostBack)
            {
                lblCountTask.Text = servizioUtility.SelectCountTaskAperti(UserId, Uidtenant).ToString();
            }
        }
        public string ReturnTesto(string testotask, string linktask)
        {
            string retVal = string.Empty;

            retVal += testotask;
            if (!string.IsNullOrEmpty(linktask))
            {
                retVal += " &nbsp; <a href='" + linktask + "' target='_blank'>Clicca qui</a>";
            }
            return retVal;
        }

        public string ReturnCheck(string idtask, string esitotask, string uid, string datatask)
        {
            string retVal;
            string dataoggi;
            string dataora = DateTime.Now.ToString("dd/MM/yyyy");

            if (SeoHelper.DataString(datatask) < SeoHelper.DataString(dataora))
            {
                dataoggi = "NO";
            }
            else
            {
                dataoggi = "SI";
            }

            if (esitotask == "1")
            {
                retVal = "<input id='c7_" + idtask + "' data-id='" + uid + "' data-day='" + dataoggi + "' class='checktask1' type='checkbox' checked='checked' onclick='return false;'>";
            }
            else
            {
                retVal = "<input id='c7_" + idtask + "' data-id='" + uid + "' data-day='" + dataoggi + "' class='checktask' type='checkbox'>";
            }

            return retVal;
        }
        public int Approvatore()
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            return datiUtente.ReturnAutorizzatore();
        }
    }
}
