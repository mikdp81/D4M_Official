// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="PercorrenzaAutoveicolo.aspx.cs" company="">
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

namespace DFleet.Users.Modules.Dash
{
    public partial class PercorrenzaAutoveicolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdiduser.Value = Membership.GetUser().ProviderUserKey.ToString();
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
                IContratti data = servizioContratti.DetailVeicoloAttualeDriver(UserId);
                if (data != null)
                {
                    lblTarga.Text = data.Targa;
                    ltdati.Text += "Targa attuale: <strong>" + data.Targa  + "</strong><br />" +
                                   "Veicolo: <strong>" + data.Modello + "</strong><br />" +
                                   "Fornitore: <strong> " + data.Fornitore + " </strong><br /> " +
                                   "Fine contratto: <strong>" + data.Datafinecontratto.ToString("dd/MM/yyyy") + "</strong><br />" +
                                   "Tipo contratto: <strong>" + data.Tipocontratto + "</strong><br />" +
                                   "Mesi contrattuali: <strong>" + data.Duratamesi + "</strong><br />" +
                                   "Km contrattuali: <strong>" + data.Kmcontratto + "</strong><br />";
                }
            }
        }
        protected void btnModifica_Click(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            Guid Uidtenant = datiUtente.ReturnUidTenant();

            string error = string.Empty;

            IContrattiBL servizioContratti = new ContrattiBL();
            IContratti contrattiNew = new Contratti
            {
                Kmpercorsi = SeoHelper.DecimalString(txtKmPercorsi.Text),
                UserId = (Guid)Membership.GetUser().ProviderUserKey,
                Targa = SeoHelper.EncodeString(lblTarga.Text),
                Datains = DateTime.Now,
                Uidtenant = Uidtenant
            };

            if (contrattiNew.Kmpercorsi == 0)
            {
                txtKmPercorsi.CssClass = "form-control is-invalid";
                error += "Inserire un valore valido <br />";
            }
            else
            {
                txtKmPercorsi.CssClass = "form-control";
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
                if (servizioContratti.InsertKmPercorsi(contrattiNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento Km Percorsi " + contrattiNew.UserId);

                    Response.Redirect("PercorrenzaAutoveicolo");
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
