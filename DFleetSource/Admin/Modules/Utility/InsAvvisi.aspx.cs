// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsAvvisi.aspx.cs" company="">
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
using System.IO;
using System.Linq;
using BusinessLogic.Services.blob;

namespace DFleet.Admin.Modules.Utility
{
    public partial class InsAvvisi : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(74)) //controllo se la pagina è autorizzata per l'utente 
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
            InsertDoc("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertDoc("salvachiudi");
        }

        public void InsertDoc(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys avvisoNew = new Utilitys
            {
                Testoavviso = SeoHelper.EncodeString(txtTestoAvviso.Text),
                Codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue),
                Codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue),
                Codcarpolicy = SeoHelper.EncodeString(ddlCodCarPolicy.SelectedValue),
                Visibiledal = SeoHelper.DataString(txtVisibileDal.Text),
                Visibileal = SeoHelper.DataString(txtVisibileAl.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;

            if (string.IsNullOrEmpty(avvisoNew.Testoavviso))
            {
                txtTestoAvviso.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Testo<br />";
            }
            else
            {
                txtTestoAvviso.CssClass = "form-control";
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
                if (servizioUtility.InsertAvviso(avvisoNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + avvisoNew.Testoavviso);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        ddlCodSocieta.ClearSelection();
                        ddlCodGrade.ClearSelection();
                        ddlCodCarPolicy.ClearSelection();
                        txtTestoAvviso.Text = "";

                        txtTestoAvviso.CssClass = "form-control";

                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuovo Avviso o <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewAvvisi") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewAvvisi");
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
