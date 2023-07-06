// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModSocieta.aspx.cs" company="">
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
    public partial class ModSocieta : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(31)) //controllo se la pagina è autorizzata per l'utente 
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
                    IUtilitys data = servizioUtility.DetailSocietaId(uid);
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
            txtCodice.Text = data.Codsocieta;
            txtCompany.Text = data.Codcompany;
            txtSigla.Text = data.Siglasocieta;
            txtSocieta.Text = data.Societa;
            txtServiceArea.Text = data.Servicearea;
            txtPartitaIVA.Text = data.Partitaiva;
            txtCodiceCDC.Text = data.Codicecdc;
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateSocieta("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateSocieta("salvachiudi");
        }


        public void UpdateSocieta(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys societaNew = new Utilitys
            {
                Codsocieta = SeoHelper.EncodeString(txtCodice.Text),
                Codcompany = SeoHelper.EncodeString(txtCompany.Text),
                Siglasocieta = SeoHelper.EncodeString(txtSigla.Text),
                Societa = SeoHelper.EncodeString(txtSocieta.Text),
                Servicearea = SeoHelper.EncodeString(txtServiceArea.Text),
                Partitaiva = SeoHelper.EncodeString(txtPartitaIVA.Text),
                Codicecdc = SeoHelper.EncodeString(txtCodiceCDC.Text),
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (string.IsNullOrEmpty(societaNew.Codsocieta))
            {
                txtCodice.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Legacy Company Code<br />";
            }
            else
            {
                txtCodice.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(societaNew.Codcompany))
            {
                txtCompany.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Company Code<br />";
            }
            else
            {
                txtCompany.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(societaNew.Siglasocieta))
            {
                txtSigla.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Sigla<br />";
            }
            else
            {
                txtSigla.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(societaNew.Societa))
            {
                txtSocieta.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Societ&agrave;<br />";
            }
            else
            {
                txtSocieta.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(societaNew.Partitaiva))
            {
                txtPartitaIVA.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Partita IVA<br />";
            }
            else
            {
                txtPartitaIVA.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(societaNew.Codicecdc))
            {
                txtCodiceCDC.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice CDC<br />";
            }
            else
            {
                txtCodiceCDC.CssClass = "form-control";
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
                if (servizioUtility.UpdateSocieta(societaNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + societaNew.Uid);


                    if (opzione.ToUpper() == "SALVA")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewSocieta") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewSocieta");
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
