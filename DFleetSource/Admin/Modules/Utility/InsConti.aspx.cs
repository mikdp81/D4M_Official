// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsConti.aspx.cs" company="">
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
    public partial class InsConti : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(26)) //controllo se la pagina è autorizzata per l'utente 
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
            InsertConto("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertConto("salvachiudi");
        }

        public void InsertConto(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys contiNew = new Utilitys
            {
                Codconto = SeoHelper.EncodeString(txtCodice.Text),
                Codsocieta = SeoHelper.EncodeString(txtCodiceSocieta.Text),
                Servicearea = SeoHelper.EncodeString(txtServiceArea.Text),
                Descrizioneconto = SeoHelper.EncodeString(txtDescrizione.Text),
                Annotazioni = SeoHelper.EncodeString(txtAnnotazioni.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (string.IsNullOrEmpty(contiNew.Codconto))
            {
                txtCodice.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice Conto<br />";
            }
            else
            {
                txtCodice.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contiNew.Codsocieta))
            {
                txtCodiceSocieta.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice Societ&agrave;<br />";
            }
            else
            {
                txtCodiceSocieta.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contiNew.Servicearea))
            {
                txtServiceArea.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Service Area<br />";
            }
            else
            {
                txtServiceArea.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contiNew.Descrizioneconto))
            {
                txtDescrizione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Descrizione<br />";
            }
            else
            {
                txtDescrizione.CssClass = "form-control";
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
                if (servizioUtility.InsertConti(contiNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + contiNew.Codconto);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        txtCodice.Text = "";
                        txtCodiceSocieta.Text = "";
                        txtServiceArea.Text = "";
                        txtDescrizione.Text = "";
                        txtAnnotazioni.Text = "";

                        txtCodice.CssClass = "form-control";
                        txtCodiceSocieta.CssClass = "form-control";
                        txtServiceArea.CssClass = "form-control";
                        txtDescrizione.CssClass = "form-control";


                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuovo Conto o <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewConti") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewConti");
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
