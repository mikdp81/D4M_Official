// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsFuelCardDriver.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text.RegularExpressions;
using System.Web;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using System.Web.UI.WebControls;
using DFleet.Classes;

namespace DFleet.Admin.Modules.Users
{
    public partial class InsFuelCardDriver : System.Web.UI.Page
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
            pnlMessage.Visible = false;
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            InsertFuelCard("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertFuelCard("salvachiudi");
        }


        public void InsertFuelCard(string opzione)
        {
            IAccountBL servizioAccount = new AccountBL();

            IAccount fuelNew = new Account
            {
                Idcompagnia = SeoHelper.IntString(ddlCompagnie.SelectedValue),
                Targa = SeoHelper.EncodeString(ddlTarga.SelectedValue),
                Numero = SeoHelper.EncodeString(txtNumero.Text),
                Scadenza = SeoHelper.DataString(txtScadenza.Text),
                Pin = SeoHelper.EncodeString(txtPIN.Text),
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
                ddlTarga.CssClass = "form-control is-invalid";
                error += "Selezionare una Targa<br />";
            }
            else
            {
                ddlTarga.CssClass = "form-control";
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
                if (servizioAccount.InsertFuelCardUser(fuelNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + fuelNew.Numero);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset di tutti campi
                        ddlCompagnie.ClearSelection();
                        ddlTarga.ClearSelection();
                        ddlStatus.ClearSelection();
                        ddlCodsocieta.ClearSelection();
                        txtNumero.Text = "";
                        txtScadenza.Text = "";
                        txtDataAttivazione.Text = "";
                        txtPIN.Text = "";

                        ddlCompagnie.CssClass = "form-control";
                        ddlTarga.CssClass = "form-control";
                        ddlStatus.CssClass = "form-control";
                        ddlCodsocieta.CssClass = "form-control";
                        txtNumero.CssClass = "form-control";
                        txtScadenza.CssClass = "form-control";
                        txtScadenza.CssClass = "form-control";
                        txtPIN.CssClass = "form-control";

                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Users/ViewFuelCardDriver") + "'>Ritorna alla Lista</a>";
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
