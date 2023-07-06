// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModPenale.aspx.cs" company="">
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
using BusinessLogic.Services.blob;

namespace DFleet.Partner.Modules.Dash
{
    public partial class ModPenale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailIdPenale(uid);
                    if (data != null)
                    {
                        ltdati.Text += "<div class='table-responsive'><table class='table'>" +
                                       "<tr><td>Num e Data fattura</td> <td>" + data.Numerofattura + " del " + data.Datafattura.ToString("dd/MM/yyyy") + "</td></tr>" +
                                       "<tr><td>Importo</td> <td> " + data.Importo + "</td></tr>" +
                                       "<tr><td>Targa</td> <td> " + data.Targa + "</td></tr>" +
                                       "<tr><td>Fornitore</td> <td> " + data.Codfornitore + "</td></tr>";

                                        if (!string.IsNullOrEmpty(data.Filepenale))
                                        {
                                            ltdati.Text += "<tr><td><a href=\"../../../DownloadFile?type=contratti&nomefile=" + data.Filepenale + "\" target='_blank'>Apri File</a></td></tr>";
                                        }

                        ltdati.Text += "</table></div>";
                    }
                    else
                    {
                        Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                    }
                }
            }
        }      
    }
}
