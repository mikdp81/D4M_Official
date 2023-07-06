// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModScarta.aspx.cs" company="">
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
    public partial class ModScarta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    hduid.Value = Convert.ToString(uid, CultureInfo.CurrentCulture);
                }
                else
                {
                    Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                }
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = new Guid(hduid.Value);

            if (servizioContratti.UpdateChangeStatusOrdine(Uid, 100, SeoHelper.EncodeString(txtMotivoScarto.Text), SeoHelper.ReturnSessionTenant()) == 1)
            {
                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Scartato Ordine Driver " + Uid);


                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-success";
                lblMessage.Text = "Ordine Scartato<br /> <a href='" + ResolveUrl("~/Users/Modules/Ordini/ViewOrdini") + "'>Ritorna alla Lista</a>";
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
