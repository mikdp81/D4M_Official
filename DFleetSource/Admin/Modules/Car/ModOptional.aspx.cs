// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModOptional.aspx.cs" company="">
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
    public partial class ModOptional : System.Web.UI.Page
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
            ICarsBL servizioCar = new CarsBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    ICars data = servizioCar.DetailOptionalId(uid);
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
            txtCodice.Text = data.Codoptional;
            txtOptional.Text = data.Optional;
            txtNote.Text = data.Note;
            ddlCategoria.SelectedValue = data.Codcategoriaoptional;
            ddlSottoCategoria.SelectedValue = data.Codsottocategoriaoptional;
            hdSottoCategoria.Value = data.Codsottocategoriaoptional;
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateOpt("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateOpt("salvachiudi");
        }


        public void UpdateOpt(string opzione)
        {
            string codsottocategoria;

            if (!string.IsNullOrEmpty(ddlSottoCategoria.SelectedValue))
            {
                codsottocategoria = ddlSottoCategoria.SelectedValue;
            }
            else
            {
                if (!string.IsNullOrEmpty(hdSottoCategoria.Value))
                {
                    codsottocategoria = hdSottoCategoria.Value;
                }
                else
                {
                    codsottocategoria = "";
                }
            }

            ICarsBL servizioCar = new CarsBL();

            ICars carListNew = new Cars
            {
                Codoptional = SeoHelper.EncodeString(txtCodice.Text),
                Codcategoriaoptional = SeoHelper.EncodeString(ddlCategoria.SelectedValue),
                Codsottocategoriaoptional = SeoHelper.EncodeString(codsottocategoria),
                Optional = SeoHelper.EncodeString(txtOptional.Text),
                Note = SeoHelper.EncodeString(txtNote.Text),
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
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
                txtCodice.CssClass = "form-control";
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
                if (servizioCar.UpdateOptional(carListNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + carListNew.Uid);


                    if (opzione.ToUpper() == "SALVA")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Car/ViewOptional") + "'>Ritorna alla Lista</a>";
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
