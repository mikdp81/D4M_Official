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

namespace DFleet.Users.Modules.Dash
{
    public partial class InsTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {             
            pnlMessage.Visible = false;
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertTask();
        }

        public void InsertTask()
        {
            IUtilitysBL servizioUtility = new UtilitysBL(); 
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            Guid Uidtenant = datiUtente.ReturnUidTenant();

            IUtilitys taskNew = new Utilitys
            {
                UserId = (Guid)Membership.GetUser().ProviderUserKey,
                Uidteam = Guid.Empty,
                Testotask = SeoHelper.EncodeString(txtTesto.Text),
                Datatask = SeoHelper.DataString(txtData.Text),
                Esitotask = 0,
                Linktask = SeoHelper.EncodeString(txtLink.Text),
                Uidtenant = Uidtenant
            };

            string error = string.Empty;

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

                    Response.Redirect("../Dash/Dashboard");                       
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
