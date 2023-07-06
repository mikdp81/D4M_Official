// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModConti.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Utility
{
    public partial class ModConti : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(26)) //controllo se la pagina è autorizzata per l'utente 
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
                    IUtilitys data = servizioUtility.DetailContiId(uid);
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
            txtCodice.Text = data.Codconto;
            txtCodiceSocieta.Text = data.Codsocieta;
            txtServiceArea.Text = data.Servicearea;
            txtDescrizione.Text = data.Descrizioneconto;
            txtAnnotazioni.Text = data.Annotazioni;
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateConto("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateConto("salvachiudi");
        }


        public void UpdateConto(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys contiNew = new Utilitys
            {
                Codconto = SeoHelper.EncodeString(txtCodice.Text),
                Codsocieta = SeoHelper.EncodeString(txtCodiceSocieta.Text),
                Servicearea = SeoHelper.EncodeString(txtServiceArea.Text),
                Descrizioneconto = SeoHelper.EncodeString(txtDescrizione.Text),
                Annotazioni = SeoHelper.EncodeString(txtAnnotazioni.Text),
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (string.IsNullOrEmpty(contiNew.Codconto))
            {
                txtCodice.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice Conto<br />";
            }
            else
            {
                txtCodice.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contiNew.Codsocieta))
            {
                txtCodiceSocieta.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice Societ&agrave;<br />";
            }
            else
            {
                txtCodiceSocieta.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contiNew.Servicearea))
            {
                txtServiceArea.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Service Area<br />";
            }
            else
            {
                txtServiceArea.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contiNew.Descrizioneconto))
            {
                txtDescrizione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Descrizione<br />";
            }
            else
            {
                txtDescrizione.CssClass = "form-control";
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
                if (servizioUtility.UpdateConti(contiNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + contiNew.Uid);
  

                    if (opzione.ToUpper() == "SALVA")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewConti") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewConti");
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
