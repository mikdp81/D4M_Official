// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsPenale.aspx.cs" company="">
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
    public partial class InsPenale : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(66)) //controllo se la pagina è autorizzata per l'utente 
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
            InsertPenale("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertPenale("salvachiudi");
        }

        public void InsertPenale(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys penaleNew = new Utilitys
            {
                Codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue),
                Codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue),
                Importopenale = SeoHelper.DecimalString(txtImporto.Text),
                Tipopenale = SeoHelper.EncodeString(ddlTipo.SelectedValue),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (string.IsNullOrEmpty(penaleNew.Codsocieta))
            {
                ddlCodsocieta.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Societ&agrave;<br />";
            }
            else
            {
                ddlCodsocieta.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(penaleNew.Codgrade))
            {
                ddlCodGrade.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Grade<br />";
            }
            else
            {
                ddlCodGrade.CssClass = "form-control";
            }

            if (penaleNew.Importopenale == 0)
            {
                txtImporto.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Importo<br />";
            }
            else
            {
                txtImporto.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(penaleNew.Tipopenale))
            {
                ddlTipo.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Tipo<br />";
            }
            else
            {
                ddlTipo.CssClass = "form-control";
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
                if (servizioUtility.InsertPenale(penaleNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + penaleNew.Codsocieta + " " + penaleNew.Codgrade + " " + penaleNew.Importopenale + " " + penaleNew.Tipopenale);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        ddlCodsocieta.ClearSelection();
                        ddlCodGrade.ClearSelection();
                        ddlTipo.ClearSelection();
                        txtImporto.Text = "";
                        ddlCodsocieta.CssClass = "form-control";
                        ddlCodGrade.CssClass = "form-control";
                        ddlTipo.CssClass = "form-control";
                        txtImporto.CssClass = "form-control";


                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuova Penale o <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewPenali") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewPenali");
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
