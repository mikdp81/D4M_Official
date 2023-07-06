// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsCategorieOptional.aspx.cs" company="">
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
    public partial class InsCategorieOptional : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(36)) //controllo se la pagina è autorizzata per l'utente 
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
            InsertCatOpt("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertCatOpt("salvachiudi");
        }

        public void InsertCatOpt(string opzione)
        {
            ICarsBL servizioCar = new CarsBL();

            ICars carListNew = new Cars
            {
                Codcategoriaoptional = SeoHelper.EncodeString(txtCodice.Text),
                Categoriaoptional = SeoHelper.EncodeString(txtCategoria.Text),
                Ordine = SeoHelper.IntString(txtOrdine.Text),
                Codpadrecategoria = SeoHelper.EncodeString(ddlCategoriaPadre.SelectedValue),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };
            if (!string.IsNullOrEmpty(carListNew.Codpadrecategoria))
            {
                carListNew.Livello = 2;
            }
            else
            {
                carListNew.Livello = 1;
            }

            string error = string.Empty;


            if (string.IsNullOrEmpty(carListNew.Codcategoriaoptional))
            {
                txtCodice.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice<br />";
            }
            else
            {
                txtCodice.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(carListNew.Categoriaoptional))
            {
                txtCategoria.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Categoria<br />";
            }
            else
            {
                txtCategoria.CssClass = "form-control";
            }

            if (carListNew.Ordine == 0)
            {
                txtOrdine.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Ordine<br />";
            }
            else
            {
                txtOrdine.CssClass = "form-control";
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

                if (servizioCar.InsertCategorieOptional(carListNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + carListNew.Codcategoriaoptional);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        ddlCategoriaPadre.ClearSelection();
                        txtCodice.Text = "";
                        txtCategoria.Text = "";
                        txtOrdine.Text = "";

                        txtCodice.CssClass = "form-control";
                        txtCategoria.CssClass = "form-control";
                        txtOrdine.CssClass = "form-control";

                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuova Categoria o <a href='" + ResolveUrl("~/Admin/Modules/Car/ViewCategorieOptional") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewCategorieOptional");
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
