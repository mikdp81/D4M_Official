// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModAvvisi.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Utility
{
    public partial class ModAvvisi : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(74)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IUtilitys data = servizioUtility.DetailAvvisoId(uid);
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
        private void BindData(IUtilitys data)
        {
            ddlCodSocieta.SelectedValue = data.Codsocieta;
            ddlCodGrade.SelectedValue = data.Codgrade;
            ddlCodCarPolicy.SelectedValue = data.Codcarpolicy;
            txtTestoAvviso.Text = data.Testoavviso;
            txtVisibileDal.Text = SeoHelper.CheckDataString(data.Visibiledal);
            txtVisibileAl.Text = SeoHelper.CheckDataString(data.Visibileal);
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateDoc("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateDoc("salvachiudi");
        }


        public void UpdateDoc(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys avvisoNew = new Utilitys
            {
                Testoavviso = SeoHelper.EncodeString(txtTestoAvviso.Text),
                Codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue),
                Codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue),
                Codcarpolicy = SeoHelper.EncodeString(ddlCodCarPolicy.SelectedValue),
                Visibiledal = SeoHelper.DataString(txtVisibileDal.Text),
                Visibileal = SeoHelper.DataString(txtVisibileAl.Text),
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;

            if (string.IsNullOrEmpty(avvisoNew.Testoavviso))
            {
                txtTestoAvviso.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Testo<br />";
            }
            else
            {
                txtTestoAvviso.CssClass = "form-control";
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
                if (servizioUtility.UpdateAvviso(avvisoNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + avvisoNew.Uid);


                    if (opzione.ToUpper() == "SALVA")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewAvvisi") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewAvvisi");
                    }
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
