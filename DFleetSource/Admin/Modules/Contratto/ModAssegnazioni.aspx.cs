// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModAssegnazioni.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Contratto
{
    public partial class ModAssegnazioni : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(64)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (int.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out int uid))
                {
                    IContratti data = servizioContratti.DetailAssegnazioniContrattiXId(uid);
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
            ddlUserAss.SelectedValue = Convert.ToString(data.UserId, CultureInfo.CurrentCulture);
            txtDataInizioAssegnazione.Text = SeoHelper.CheckDataString(data.Assegnatodal);
            txtDataFineAssegnazione.Text = SeoHelper.CheckDataString(data.Assegnatoal);
            hduid.Value = Convert.ToString(data.Idassegnazione, CultureInfo.CurrentCulture);
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string error = string.Empty;

            IContratti contrattoNew3 = new Contratti
            {
                UserId = SeoHelper.GuidString(ddlUserAss.SelectedValue),
                Assegnatodal = SeoHelper.DataString(txtDataInizioAssegnazione.Text),
                Assegnatoal = SeoHelper.DataString(txtDataFineAssegnazione.Text),
                Idassegnazione = SeoHelper.IntString(hduid.Value),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            if (contrattoNew3.UserId == Guid.Empty)
            {
                ddlUserAss.CssClass = "form-control is-invalid";
                error += "inserire un Driver<br />";
            }
            else
            {
                ddlUserAss.CssClass = "form-control";
            }
            if (contrattoNew3.Assegnatodal == DateTime.MinValue)
            {
                txtDataInizioAssegnazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Inizio Assegnazione<br />";
            }
            else
            {
                txtDataInizioAssegnazione.CssClass = "form-control";
            }
            if (contrattoNew3.Assegnatoal == DateTime.MinValue)
            {
                txtDataFineAssegnazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Fine Assegnazione<br />";
            }
            else
            {
                txtDataFineAssegnazione.CssClass = "form-control";
            }

            if (!string.IsNullOrEmpty(error))
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione. Il modulo non è stato compilato correttamente. Si sono verificati i seguenti errori:";
                lblMessage.Text += "<br /><br /><b>" + error + "</b><br />";
            }
            else
            {
                //aggiorna assegnazione contratto 
                if (servizioContratti.UpdateAssegnazioneContratto(contrattoNew3) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + contrattoNew3.Idassegnazione);

                    Response.Redirect("Assegnazioni");
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
