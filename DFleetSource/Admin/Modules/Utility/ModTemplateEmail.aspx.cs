// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModTemplateEmail.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Utility
{
    public partial class ModTemplateEmail : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(32)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Int32.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out int uid))
                {
                    IUtilitys data = servizioUtility.ReturnTemplateEmail(uid);
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
        private void BindData(IUtilitys data)
        {
            txtTitolo.Text = data.Titolo;
            txtOggetto.Text = data.Oggetto;
            txtCorpo.Text = data.Corpo;
            hduid.Value = Convert.ToString(data.Idtemplate, CultureInfo.CurrentCulture);
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateTemplateEmail("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateTemplateEmail("salvachiudi");
        }


        public void UpdateTemplateEmail(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys tempNew = new Utilitys
            {
                Titolo = SeoHelper.EncodeString(txtTitolo.Text),
                Oggetto = SeoHelper.EncodeString(txtOggetto.Text),
                Corpo = SeoHelper.EncodeString(txtCorpo.Text),
                Idtemplate = SeoHelper.IntString(hduid.Value),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (string.IsNullOrEmpty(tempNew.Titolo))
            {
                txtTitolo.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Titolo<br />";
            }
            else
            {
                txtTitolo.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(tempNew.Oggetto))
            {
                txtOggetto.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Oggetto<br />";
            }
            else
            {
                txtOggetto.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(tempNew.Corpo))
            {
                txtCorpo.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Corpo Mail<br />";
            }
            else
            {
                txtCorpo.CssClass = "form-control";
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
                if (servizioUtility.UpdateTemplateEmail(tempNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + tempNew.Idtemplate);


                    if (opzione.ToUpper() == "SALVA")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewTemplateEmail") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewSocieta");
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
