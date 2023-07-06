// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModOrdini.aspx.cs" company="">
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
    public partial class ModOrdini : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(10)) //controllo se la pagina è autorizzata per l'utente 
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
                    IContratti data = servizioContratti.DetailOrdiniId(uid);
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
            txtCodjatoAuto.Text = data.Codjatoauto;
            txtCodcarpolicy.Text = data.Codcarpolicy;
            txtCodcarlist.Text = data.Codcarlist;
            ddlFornitore.SelectedValue = data.Codfornitore;
            txtNumeroOrdine.Text = data.Numeroordine;
            txtDataOrdine.Text = SeoHelper.CheckDataString(data.Dataordine);
            txtDataprimaconsegnaprevista.Text = SeoHelper.CheckDataString(data.Datainviolink);
            txtDataconsegnaprevista.Text = SeoHelper.CheckDataString(data.Dataconsegnaprevista);
            txtDataconsegnaprevistaupdate.Text = SeoHelper.CheckDataString(data.Dataconsegnaprevistaupdate);
            txtDataconfermaricezione.Text = SeoHelper.CheckDataString(data.Dataconfermaricezione);
            txtDatainviolink.Text = SeoHelper.CheckDataString(data.Datainviolink);
            txtAnnotazioniordine.Text = data.Annotazioniordini;
            txtCanoneleasing.Text = SeoHelper.CheckDecimalString(data.Canoneleasing);
            txtDeltaCanone.Text = SeoHelper.CheckDecimalString(data.Deltacanone);
            txtMotivoScarto.Text = data.Motivoscarto;
            ddlstatus.SelectedValue = data.Idstatusordine.ToString();
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateOrdini("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateOrdini("salvachiudi");
        }


        public void UpdateOrdini(string opzione)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            IContratti ordineNew = new Contratti
            {
                Codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue),
                UserId = SeoHelper.GuidString(ddlUsers.SelectedValue),
                Codjatoauto = SeoHelper.EncodeString(txtCodjatoAuto.Text),
                Codcarpolicy = SeoHelper.EncodeString(txtCodcarpolicy.Text),
                Codcarlist = SeoHelper.EncodeString(txtCodcarlist.Text),
                Codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue),
                Numeroordine = SeoHelper.EncodeString(txtNumeroOrdine.Text),
                Dataordine = SeoHelper.DataString(txtDataOrdine.Text),
                Dataprimaconsegnaprevista = SeoHelper.DataString(txtDataprimaconsegnaprevista.Text),
                Dataconsegnaprevista = SeoHelper.DataString(txtDataconsegnaprevista.Text),
                Dataconsegnaprevistaupdate = SeoHelper.DataString(txtDataconsegnaprevistaupdate.Text),
                Dataconfermaricezione = SeoHelper.DataString(txtDataconfermaricezione.Text),
                Datainviolink = SeoHelper.DataString(txtDatainviolink.Text),
                Annotazioniordini = SeoHelper.EncodeString(txtAnnotazioniordine.Text),
                Canoneleasing = SeoHelper.DecimalString(txtCanoneleasing.Text),
                Deltacanone = SeoHelper.DecimalString(txtDeltaCanone.Text),
                Idstatusordine = SeoHelper.IntString(ddlstatus.SelectedValue),
                Motivoscarto = SeoHelper.EncodeString(txtMotivoScarto.Text),
                Filefirma = "",
                Fileconfermarental = "",
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (string.IsNullOrEmpty(ordineNew.Codsocieta))
            {
                ddlCodsocieta.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Societ&agrave;<br />";
            }
            else
            {
                ddlCodsocieta.CssClass = "form-control";
            }

            if (ordineNew.UserId == Guid.Empty)
            {
                ddlUsers.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice fornitore<br />";
            }
            else
            {
                ddlUsers.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(ordineNew.Codjatoauto))
            {
                txtCodjatoAuto.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codjato auto<br />";
            }
            else
            {
                txtCodjatoAuto.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(ordineNew.Codfornitore))
            {
                ddlFornitore.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice fornitore<br />";
            }
            else
            {
                ddlFornitore.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(ordineNew.Numeroordine))
            {
                txtNumeroOrdine.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Numero ordine<br />";
            }
            else
            {
                txtNumeroOrdine.CssClass = "form-control";
            }

            if (ordineNew.Idstatusordine == 0)
            {
                ddlstatus.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Status ordine<br />";
            }
            else
            {
                ddlstatus.CssClass = "form-control";
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
                if (servizioContratti.UpdateOrdini(ordineNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + ordineNew.Uid);


                    if (opzione.ToUpper() == "SALVA")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Contratti/ViewOrdini") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewOrdini");
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
