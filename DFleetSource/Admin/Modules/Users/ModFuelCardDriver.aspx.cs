// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModFuelCardDriver.aspx.cs" company="">
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
    public partial class ModFuelCardDriver : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(40)) //controllo se la pagina è autorizzata per l'utente 
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

                    IAccount data = servizioAccount.DetailFuelCardUserId(uid);
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
            ddlCompagnie.SelectedValue = SeoHelper.CheckIntString(data.Idcompagnia);
            txtTarga.Text = data.Targa;
            txtNumero.Text = data.Numero;
            txtScadenza.Text = SeoHelper.CheckDataString(data.Scadenza);
            txtPIN.Text = data.Pin;
            txtDataAttivazione.Text = SeoHelper.CheckDataString(data.Dataattivazione);
            ddlStatus.SelectedValue = data.Stato;
            ddlCodsocieta.SelectedValue = data.Codsocieta;
            hduid.Value = SeoHelper.CheckGuidString(data.Uid);
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateFuelCard("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateFuelCard("salvachiudi");
        }


        public void UpdateFuelCard(string opzione)
        {
            IAccountBL servizioAccount = new AccountBL();

            IAccount fuelNew = new Account
            {
                Idcompagnia = SeoHelper.IntString(ddlCompagnie.SelectedValue),
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Numero = SeoHelper.EncodeString(txtNumero.Text),
                Scadenza = SeoHelper.DataString(txtScadenza.Text),
                Pin = SeoHelper.EncodeString(txtPIN.Text),
                Uid = SeoHelper.GuidString(hduid.Value),
                Dataattivazione = SeoHelper.DataString(txtDataAttivazione.Text),
                Stato = SeoHelper.EncodeString(ddlStatus.SelectedValue),
                Codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;

            if (fuelNew.Idcompagnia == 0)
            {
                ddlCompagnie.CssClass = "form-control is-invalid";
                error += "Selezionare una Compagnia<br />";
            }
            else
            {
                ddlCompagnie.CssClass = "form-control";
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

            if (string.IsNullOrEmpty(fuelNew.Codsocieta))
            {
                ddlCodsocieta.CssClass = "form-control is-invalid";
                error += "Selezionare una Targa<br />";
            }
            else
            {
                ddlCodsocieta.CssClass = "form-control";
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
                txtScadenza.CssClass = "form-control is-invalid datePicker";
                error += "Inserire un valore valido per il campo Scadenza<br />";
            }
            else
            {
                txtScadenza.CssClass = "form-control datePicker";
            }

            if (fuelNew.Dataattivazione == DateTime.MinValue)
            {
                txtDataAttivazione.CssClass = "form-control is-invalid datePicker";
                error += "Inserire un valore valido per il campo Data Attivazione<br />";
            }
            else
            {
                txtDataAttivazione.CssClass = "form-control datePicker";
            }

            if (string.IsNullOrEmpty(fuelNew.Stato))
            {
                ddlStatus.CssClass = "form-control is-invalid";
                error += "Inserire un valore valido per il campo Status<br />";
            }
            else
            {
                ddlStatus.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(fuelNew.Pin))
            {
                txtPIN.CssClass = "form-control is-invalid";
                error += "Inserire un valore valido per il campo PIN<br />";
            }
            else
            {
                txtPIN.CssClass = "form-control";
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
                if (servizioAccount.UpdateFuelCardUser(fuelNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + fuelNew.Uid);
  

                    if (opzione.ToUpper() == "SALVA")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Users/ViewFuelCardDriver") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewFuelCardDriver");
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
