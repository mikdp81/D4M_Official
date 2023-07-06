// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsSocieta.aspx.cs" company="">
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
    public partial class InsSocieta : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(31)) //controllo se la pagina è autorizzata per l'utente 
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
            InsertSocieta("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertSocieta("salvachiudi");
        }

        public void InsertSocieta(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();

            IUtilitys societaNew = new Utilitys
            {
                Codsocieta = SeoHelper.EncodeString(txtCodice.Text),
                Codcompany = SeoHelper.EncodeString(txtCompany.Text),
                Siglasocieta = SeoHelper.EncodeString(txtSigla.Text),
                Societa = SeoHelper.EncodeString(txtSocieta.Text),
                Servicearea = SeoHelper.EncodeString(txtServiceArea.Text),
                Partitaiva = SeoHelper.EncodeString(txtPartitaIVA.Text),
                Codicecdc = SeoHelper.EncodeString(txtCodiceCDC.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (string.IsNullOrEmpty(societaNew.Codsocieta))
            {
                txtCodice.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Legacy Company Code<br />";
            }
            else
            {
                txtCodice.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(societaNew.Codcompany))
            {
                txtCompany.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Company Code<br />";
            }
            else
            {
                txtCompany.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(societaNew.Siglasocieta))
            {
                txtSigla.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Sigla<br />";
            }
            else
            {
                txtSigla.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(societaNew.Societa))
            {
                txtSocieta.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Societ&agrave;<br />";
            }
            else
            {
                txtSocieta.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(societaNew.Partitaiva))
            {
                txtPartitaIVA.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Partita IVA<br />";
            }
            else
            {
                txtPartitaIVA.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(societaNew.Codicecdc))
            {
                txtCodiceCDC.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice CDC<br />";
            }
            else
            {
                txtCodiceCDC.CssClass = "form-control";
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
                if (servizioUtility.InsertSocieta(societaNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + societaNew.Societa);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        txtCodice.Text = "";
                        txtCompany.Text = "";
                        txtSigla.Text = "";
                        txtSocieta.Text = "";
                        txtServiceArea.Text = "";
                        txtPartitaIVA.Text = "";
                        txtCodiceCDC.Text = "";
                        txtCodice.CssClass = "form-control";
                        txtCompany.CssClass = "form-control";
                        txtSigla.CssClass = "form-control";
                        txtSocieta.CssClass = "form-control";
                        txtPartitaIVA.CssClass = "form-control";
                        txtCodiceCDC.CssClass = "form-control";


                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuova Societ&agrave; o <a href='" + ResolveUrl("~/Admin/Modules/Utility/ViewSocieta") + "'>Ritorna alla Lista</a>";
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
