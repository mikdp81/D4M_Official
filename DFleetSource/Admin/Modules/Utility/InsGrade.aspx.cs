// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsGrade.aspx.cs" company="">
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
    public partial class InsGrade : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(29)) //controllo se la pagina è autorizzata per l'utente 
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
            InsertGrade("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertGrade("salvachiudi");
        }

        public void InsertGrade(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys gradeNew = new Utilitys
            {
                Codgrade = SeoHelper.EncodeString(txtCodice.Text),
                Grade = SeoHelper.EncodeString(txtGrade.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (string.IsNullOrEmpty(gradeNew.Codgrade))
            {
                txtCodice.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice Grade<br />";
            }
            else
            {
                txtCodice.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(gradeNew.Grade))
            {
                txtGrade.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Grade<br />";
            }
            else
            {
                txtGrade.CssClass = "form-control";
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
                if (servizioUtility.InsertGrade(gradeNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + gradeNew.Grade);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        txtCodice.Text = "";
                        txtGrade.Text = "";

                        txtCodice.CssClass = "form-control";
                        txtGrade.CssClass = "form-control";


                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuovo Grade o <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewGrade") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewGrade");
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
