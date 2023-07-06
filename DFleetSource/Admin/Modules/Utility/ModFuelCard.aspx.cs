// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModFuelCard.aspx.cs" company="">
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
    public partial class ModFuelCard : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(28)) //controllo se la pagina è autorizzata per l'utente 
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
                    IUtilitys data = servizioUtility.DetailFuelCardId(uid);
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
            txtCodice.Text = data.Codfuelcard;
            txtFuelCard.Text = data.Fuelcard;
            txtValoreFuelCard.Text = SeoHelper.CheckDecimalString(data.Valorefuelcard);
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
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
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys fuelcardNew = new Utilitys
            {
                Codfuelcard = SeoHelper.EncodeString(txtCodice.Text),
                Fuelcard = SeoHelper.EncodeString(txtFuelCard.Text),
                Valorefuelcard = SeoHelper.DecimalString(txtValoreFuelCard.Text),
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (string.IsNullOrEmpty(fuelcardNew.Codfuelcard))
            {
                txtCodice.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice Fuel Card<br />";
            }
            else
            {
                txtCodice.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(fuelcardNew.Fuelcard))
            {
                txtFuelCard.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Fuel Card<br />";
            }
            else
            {
                txtFuelCard.CssClass = "form-control";
            }

            if (fuelcardNew.Valorefuelcard > 0)
            {
                txtValoreFuelCard.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Valore Fuel Card<br />";
            }
            else
            {
                txtValoreFuelCard.CssClass = "form-control";
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
                if (servizioUtility.UpdateFuelCard(fuelcardNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + fuelcardNew.Uid);
  
                    if (opzione.ToUpper() == "SALVA")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewFuelCard") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewFuelCard");
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
