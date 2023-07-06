// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsOptional.aspx.cs" company="">
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
using System.Web.UI.WebControls;

namespace DFleet.Admin.Modules.Car
{
    public partial class InsOptional : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(37)) //controllo se la pagina è autorizzata per l'utente 
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
            InsertOpt("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertOpt("salvachiudi");
        }

        public void InsertOpt(string opzione)
        {
            ICarsBL servizioCar = new CarsBL();

            ICars carListNew = new Cars
            {
                Codoptional = SeoHelper.EncodeString(txtCodice.Text),
                Codcategoriaoptional = SeoHelper.EncodeString(ddlCategoria.SelectedValue),
                Codsottocategoriaoptional = SeoHelper.EncodeString(ddlSottoCategoria.SelectedValue),
                Optional = SeoHelper.EncodeString(txtOptional.Text),
                Note = SeoHelper.EncodeString(txtNote.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (string.IsNullOrEmpty(carListNew.Codoptional))
            {
                txtCodice.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice<br />";
            }
            else
            {
                if (servizioCar.ExistCodOptional(carListNew.Codoptional))
                {
                    txtCodice.CssClass = "form-control is-invalid";
                    error += "Codice gi&agrave; esistente<br />";
                }
                else
                {
                    txtCodice.CssClass = "form-control";
                }
            }

            if (string.IsNullOrEmpty(carListNew.Optional))
            {
                txtOptional.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Optional<br />";
            }
            else
            {
                txtOptional.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(carListNew.Codcategoriaoptional))
            {
                ddlCategoria.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Categoria<br />";
            }
            else
            {
                ddlCategoria.CssClass = "form-control";
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

                if (servizioCar.InsertOptional(carListNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + carListNew.Codcategoriaoptional);

                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        ddlCategoria.ClearSelection();
                        ddlSottoCategoria.ClearSelection();
                        txtCodice.Text = "";
                        txtOptional.Text = "";
                        txtNote.Text = "";

                        txtCodice.CssClass = "form-control";
                        txtOptional.CssClass = "form-control";
                        ddlCategoria.CssClass = "form-control";

                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuovo Optional o <a href='" + ResolveUrl("~/Admin/Modules/Car/ViewOptional") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewOptional");
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
