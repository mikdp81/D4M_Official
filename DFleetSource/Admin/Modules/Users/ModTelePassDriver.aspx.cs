// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModTelePassDriver.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Users
{
    public partial class ModTelePassDriver : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(19)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccountBL servizioAccount = new AccountBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {

                    IAccount data = servizioAccount.DetailTelePassUserId(uid);
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
        private void BindData(IAccount data)
        {
            ddlUsers.SelectedValue = SeoHelper.CheckGuidString(data.UserId);
            txtTarga.Text = data.Targa;
            txtNumero.Text = data.Numero;
            txtScadenza.Text = SeoHelper.CheckDataString(data.Scadenza);
            ddlCompagnie.SelectedValue = data.Idcompagnia.ToString();
            ddlStatus.SelectedValue = data.Stato;
            hduid.Value = SeoHelper.CheckGuidString(data.Uid);
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateTelePass("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateTelePass("salvachiudi");
        }


        public void UpdateTelePass(string opzione)
        {
            IAccountBL servizioAccount = new AccountBL();

            IAccount fuelNew = new Account
            {
                UserId = SeoHelper.GuidString(ddlUsers.SelectedValue),
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Numero = SeoHelper.EncodeString(txtNumero.Text),
                Scadenza = SeoHelper.DataString(txtScadenza.Text),
                Idcompagnia = SeoHelper.IntString(ddlCompagnie.SelectedValue),
                Stato = SeoHelper.EncodeString(ddlStatus.SelectedValue),
                Uid = SeoHelper.GuidString(hduid.Value),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;

            if (fuelNew.UserId == Guid.Empty)
            {
                ddlUsers.CssClass = "form-control is-invalid";
                error += "Selezionare un Driver<br />";
            }
            else
            {
                ddlUsers.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(fuelNew.Targa))
            {
                txtTarga.CssClass = "form-control is-invalid";
                error += "Selezionare una Targa<br />";
            }
            else
            {
                txtTarga.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(fuelNew.Numero))
            {
                txtNumero.CssClass = "form-control is-invalid";
                error += "Inserire un valore valido per il campo Numero<br />";
            }
            else
            {
                txtNumero.CssClass = "form-control";
            }

            if (fuelNew.Scadenza == DateTime.MinValue)
            {
                txtScadenza.CssClass = "form-control is-invalid";
                error += "Inserire un valore valido per il campo Scadenza<br />";
            }
            else
            {
                txtScadenza.CssClass = "form-control";
            }

            if (fuelNew.Idcompagnia == 0)
            {
                ddlCompagnie.CssClass = "form-control is-invalid";
                error += "Selezionare il Tipo<br />";
            }
            else
            {
                ddlCompagnie.CssClass = "form-control";
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
                if (servizioAccount.UpdateTelePassUser(fuelNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + fuelNew.Uid);
 

                    if (opzione.ToUpper() == "SALVA")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Users/ViewTelePassDriver") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewTelePassDriver");
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
