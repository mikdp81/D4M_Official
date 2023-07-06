// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModCategorieOptional.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Car
{
    public partial class ModCategorieOptional : System.Web.UI.Page
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
            ICarsBL servizioCar = new CarsBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    ICars data = servizioCar.DetailCategoriaOptionalId(uid);
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
        private void BindData(ICars data)
        {
            txtCodice.Text = data.Codcategoriaoptional;
            txtCategoria.Text = data.Categoriaoptional;
            txtOrdine.Text = SeoHelper.CheckIntString(data.Ordine);
            ddlCategoriaPadre.SelectedValue = data.Codpadrecategoria;
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateCatOpt("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateCatOpt("salvachiudi");
        }


        public void UpdateCatOpt(string opzione)
        {
            ICarsBL servizioCar = new CarsBL();

            ICars carListNew = new Cars
            {
                Codcategoriaoptional = SeoHelper.EncodeString(txtCodice.Text),
                Categoriaoptional = SeoHelper.EncodeString(txtCategoria.Text),
                Ordine = SeoHelper.IntString(txtOrdine.Text),
                Codpadrecategoria = SeoHelper.EncodeString(ddlCategoriaPadre.SelectedValue),
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
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
                if (servizioCar.UpdateCategorieOptional(carListNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + carListNew.Uid);

                    if (opzione.ToUpper() == "SALVA")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Car/ViewCategorieOptional") + "'>Ritorna alla Lista</a>";
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
