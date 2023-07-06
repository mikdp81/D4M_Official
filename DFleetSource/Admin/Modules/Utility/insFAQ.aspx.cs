﻿// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="insFAQ.aspx.cs" company="">
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
using DFleet.Classes;

namespace DFleet.Admin.Modules.Utility
{
    public partial class insFAQ : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(58)) //controllo se la pagina è autorizzata per l'utente 
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
            InsertFAQ("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertFAQ("salvachiudi");
        }

        public void InsertFAQ(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys faqNew = new Utilitys
            {
                Idargomentofaq = SeoHelper.IntString(ddlArgomento.SelectedValue),
                Domanda = SeoHelper.EncodeString(txtDomanda.Text),
                Risposta = SeoHelper.EncodeString(txtRisposta.Text),
                Validadal = SeoHelper.DataString(txtValidaDal.Text),
                Validaal = SeoHelper.DataString(txtValidaAl.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (faqNew.Idargomentofaq == 0)
            {
                ddlArgomento.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Argomento<br />";
            }
            else
            {
                ddlArgomento.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(faqNew.Domanda))
            {
                txtDomanda.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Domanda<br />";
            }
            else
            {
                txtDomanda.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(faqNew.Risposta))
            {
                txtRisposta.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Risposta<br />";
            }
            else
            {
                txtRisposta.CssClass = "form-control";
            }

            if (faqNew.Validadal == DateTime.MinValue)
            {
                txtValidaDal.CssClass = "form-control is-invalid";
                error += "inserire una data corretta in Valida DAL<br />";
            }
            else
            {
                txtValidaDal.CssClass = "form-control";
            }

            if (faqNew.Validaal == DateTime.MinValue)
            {
                txtValidaAl.CssClass = "form-control is-invalid";
                error += "inserire una data corretta in Valida AL<br />";
            }
            else
            {
                txtValidaAl.CssClass = "form-control";
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
                if (servizioUtility.InsertFAQ(faqNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + faqNew.Domanda);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        ddlArgomento.ClearSelection();
                        txtDomanda.Text = "";
                        txtRisposta.Text = "";
                        txtValidaDal.Text = "";
                        txtValidaAl.Text = "";
                        ddlArgomento.CssClass = "form-control";
                        txtDomanda.CssClass = "form-control";
                        txtRisposta.CssClass = "form-control";
                        txtValidaDal.CssClass = "form-control";
                        txtValidaAl.CssClass = "form-control";

                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuova FAQ o <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewFAQ") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewFAQ");
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
