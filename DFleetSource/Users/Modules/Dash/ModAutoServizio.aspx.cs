// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModRevisioni.aspx.cs" company="">
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
using System.IO;
using System.Linq;
using BusinessLogic.Services.blob;

namespace DFleet.Users.Modules.Dash
{
    public partial class ModAutoServizio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Int32.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out int uid))
                {
                    hduid.Value = uid.ToString();
                    IContratti data = servizioContratti.DetailAutoServizioId(uid);
                    if (data != null)
                    {
                        BindData(data);
                    }
                    else
                    {
                        Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                    }
                }
            }
        }
        private void BindData(IContratti data)
        {
            lblDatiRev.Text += "Targa<br /><h3>" + data.Targa + " - " + data.Modello + "</h3>" +
                           "Periodo <br /><h3>DAL " + data.Assegnatodal.ToString("dd/MM/yyyy HH:mm") + " AL " + data.Assegnatoal.ToString("dd/MM/yyyy HH:mm") + "</h3>";

            ddlScopoViaggio.SelectedValue = data.Scopoviaggio;
            txtKminiziali.Text = SeoHelper.CheckDecimalString(data.Kminiziali);
            txtKmrestituzione.Text = SeoHelper.CheckDecimalString(data.Kmrestituzione);
            txtSpese.Text = data.Spese;
            txtImportospese.Text = SeoHelper.CheckDecimalString(data.Importospese);
            txtNote.Text = data.Noterestituzione;
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            string error = string.Empty;

            IContratti contrattoNew = new Contratti
            {
                Scopoviaggio = SeoHelper.EncodeString(ddlScopoViaggio.SelectedValue),
                Kminiziali = SeoHelper.DecimalString(txtKminiziali.Text),
                Kmrestituzione = SeoHelper.DecimalString(txtKmrestituzione.Text),
                Spese = SeoHelper.EncodeString(txtSpese.Text),
                Importospese = SeoHelper.DecimalString(txtImportospese.Text),
                Noterestituzione = SeoHelper.EncodeString(txtNote.Text),
                Idassegnazione = SeoHelper.IntString(hduid.Value),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };


            if (!string.IsNullOrEmpty(error))
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione. Il modulo non è stato compilato correttamente. Si sono verificati i seguenti errori:";
                lblMessage.Text += "<br /><br /><b>" + error + "</b><br />";
            }
            else
            {                
                if (servizioContratti.UpdateAutoServizio(contrattoNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica Libretto di bordo " + SeoHelper.EncodeString(hduid.Value));

                    Response.Redirect("ViewAutoServizio");
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
}
