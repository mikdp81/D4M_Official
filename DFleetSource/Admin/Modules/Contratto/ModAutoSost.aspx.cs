// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModAutoSost.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Contratto
{
    public partial class ModAutoSost : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(75)) //controllo se la pagina è autorizzata per l'utente 
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
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailAutoSostId(uid);
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
            ddlCodsocieta.SelectedValue = data.Codsocieta;
            ddlUsers.SelectedValue = Convert.ToString(data.UserId, CultureInfo.CurrentCulture);
            txtTarga.Text = data.Targa;
            txtDataInizioAssegnazione.Text = SeoHelper.CheckDataString(data.Assegnatodal);
            txtDataFineAssegnazione.Text = SeoHelper.CheckDataString(data.Assegnatoal);
            txtAnnotazioni.Text = data.Annotazionicontratto;
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {      
            IContrattiBL servizioContratti = new ContrattiBL();

            string error = string.Empty;

            IContratti contrattoNew = new Contratti
            {
                UserId = SeoHelper.GuidString(ddlUsers.SelectedValue),
                Codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue),
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Assegnatodal = SeoHelper.DataString(txtDataInizioAssegnazione.Text),
                Assegnatoal = SeoHelper.DataString(txtDataFineAssegnazione.Text),
                Annotazionicontratto = SeoHelper.EncodeString(txtAnnotazioni.Text),
                Uid = SeoHelper.GuidString(hduid.Value),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };


            if (contrattoNew.Assegnatodal == DateTime.MinValue)
            {
                txtDataInizioAssegnazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Assegnato dal<br />";
            }
            else
            {
                txtDataInizioAssegnazione.CssClass = "form-control";
            }

            if (contrattoNew.Assegnatoal == DateTime.MinValue)
            {
                txtDataFineAssegnazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Assegnato al<br />";
            }
            else
            {
                txtDataFineAssegnazione.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Codsocieta))
            {
                ddlCodsocieta.CssClass = "form-control select2 is-invalid";
                error += "inserire un valore valido per il campo Societ&agrave;<br />";
            }
            else
            {
                ddlCodsocieta.CssClass = "form-control select2";
            }

            if (string.IsNullOrEmpty(contrattoNew.Targa))
            {
                txtTarga.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Targa<br />";
            }
            else
            {
                txtTarga.CssClass = "form-control";
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
                if (servizioContratti.UpdateAutoSost(contrattoNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica auto sostitutiva " + contrattoNew.Uid);

                    Response.Redirect("ViewAutoSostitutive");
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Operazione fallita";
                }
            }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = SeoHelper.GuidString(hduid.Value);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            if (servizioContratti.DeleteAutoSost(Uid, Uidtenant) == 1)
            {
                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Elimina auto sostitutiva " + Uid);

                Response.Redirect("ViewAutoSostitutive");
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
