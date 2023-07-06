// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="EditRimuoviConf.aspx.cs" company="">
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
    public partial class EditRimuoviConf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
            IContrattiBL servizioContratti = new ContrattiBL();

            if (!Page.IsPostBack)
            {
                if (Int32.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out int uid))
                {
                    Guid Uidtenant = SeoHelper.ReturnSessionTenant();

                    if (servizioContratti.DeleteConfOrdine(uid, Uidtenant) == 1)
                    {
                        if (servizioContratti.DeleteConfOrdineOptional(uid, Uidtenant) == 1)
                        {
                            ILogBL log = new LogBL();
                            log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Rimozione configurazione " + uid);

                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Rimozione configurazione avvenuta correttamente<br /> <a href='" + ResolveUrl("~/Users/Modules/Ordini/ConfiguraAuto") + "'>Riconfigura</a>";
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
                else
                {
                    Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                }
            }
        }
    }
}
