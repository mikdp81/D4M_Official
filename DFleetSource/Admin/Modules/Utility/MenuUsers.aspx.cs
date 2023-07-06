// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="MenuUsers.aspx.cs" company="">
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
using System.IO;
using System.Linq;
using System.Web.UI.HtmlControls;

namespace DFleet.Admin.Modules.Utility
{
    public partial class MenuUsers : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(95)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
        }
        protected bool GetCheckedStatus(string status)
        {
            if (status == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IAccountBL servizioAccount = new AccountBL();
            int idpagina;
            int status;

            foreach (GridViewRow row in gvImpo.Rows)
            {
                CheckBox statusCheckbox = (CheckBox)row.FindControl("status");
                HiddenField idpaginaHidden = (HiddenField)row.FindControl("hdidpagina");
                bool checkstatus = statusCheckbox.Checked;
                if (checkstatus)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                idpagina = SeoHelper.IntString(idpaginaHidden.Value);

                servizioAccount.UpdateMenuUsers(idpagina, status, SeoHelper.ReturnSessionTenant());
                
            }

            Response.Redirect("MenuUsers");

        }
    }
}
