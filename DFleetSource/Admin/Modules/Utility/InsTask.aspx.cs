// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsTask.aspx.cs" company="">
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
    public partial class InsTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {             
            pnlMessage.Visible = false;
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            InsertConto("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertConto("salvachiudi");
        }

        public void InsertConto(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            IUtilitys taskNew = new Utilitys
            {
                UserId = SeoHelper.GuidString(ddlUsers.SelectedValue),
                Uidteam = SeoHelper.GuidString(ddlTeam.SelectedValue),
                Testotask = SeoHelper.EncodeString(txtTesto.Text),
                Datatask = SeoHelper.DataString(txtData.Text),
                Esitotask = 0,
                Linktask = SeoHelper.EncodeString(txtLink.Text)
            };

            string error = string.Empty;

            if (taskNew.UserId == Guid.Empty && taskNew.Uidteam == Guid.Empty)
            {
                ddlUsers.CssClass = "form-control is-invalid";
                ddlTeam.CssClass = "form-control is-invalid";
                error += "Scegliere almeno un utente o un team<br />";
            }
            else
            {
                ddlUsers.CssClass = "form-control";
                ddlTeam.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(taskNew.Testotask))
            {
                txtTesto.CssClass = "form-control is-invalid";
                error += "inserire una testo<br />";
            }
            else
            {
                txtTesto.CssClass = "form-control";
            }

            if (taskNew.Datatask == DateTime.MinValue)
            {
                txtData.CssClass = "form-control is-invalid";
                error += "inserire una data valida<br />";
            }
            else
            {
                txtData.CssClass = "form-control";
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
                if (servizioUtility.InsertTask(taskNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + taskNew.Testotask);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        ddlUsers.ClearSelection();
                        ddlTeam.ClearSelection();
                        txtData.Text = "";
                        txtLink.Text = "";
                        txtTesto.Text = "";

                        ddlUsers.CssClass = "form-control";
                        ddlTeam.CssClass = "form-control";
                        txtData.CssClass = "form-control";
                        txtTesto.CssClass = "form-control";


                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuovo Task o <a href='" + ResolveUrl("~/Admin/Modules/Dash/Dashboard") + "'>Ritorna alla Dashboard</a>";
                    }
                    else
                    {
                        Response.Redirect("../Dash/Dashboard");
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
