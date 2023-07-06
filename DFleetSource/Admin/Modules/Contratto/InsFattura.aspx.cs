// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsFattura.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Contratto
{
    public partial class InsFattura : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(21)) //controllo se la pagina è autorizzata per l'utente 
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
            InsertFattura("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertFattura("salvachiudi");
        }

        public void InsertFattura(string opzione)
        {
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

            //inserimento dati in tabella fatturexml
            IFileTracciati fattNew = new FileTracciati
            {
                Tipodocumento = SeoHelper.EncodeString(ddlTipoDoc.SelectedValue),
                Divisa = SeoHelper.EncodeString(ddlDivisa.SelectedValue),
                Datadocumento = SeoHelper.DataString(txtDataDoc.Text),
                Numerodocumento = SeoHelper.EncodeString(txtNumeroDoc.Text),
                Importototale = SeoHelper.DecimalString(txtImportoTotale.Text),
                Fornitore = SeoHelper.EncodeString(ddlFornitore.Items[ddlFornitore.SelectedIndex].Text),
                Codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue),
                Committente = SeoHelper.EncodeString(ddlCodsocieta.Items[ddlCodsocieta.SelectedIndex].Text),
                Codcommittente = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (string.IsNullOrEmpty(fattNew.Codfornitore))
            {
                ddlFornitore.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice fornitore<br />";
            }
            else
            {
                ddlFornitore.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(fattNew.Codcommittente))
            {
                ddlCodsocieta.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Societ&agrave;<br />";
            }
            else
            {
                ddlCodsocieta.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(fattNew.Tipodocumento))
            {
                ddlTipoDoc.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Tipo documento<br />";
            }
            else
            {
                ddlTipoDoc.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(fattNew.Divisa))
            {
                ddlDivisa.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Divisa<br />";
            }
            else
            {
                ddlDivisa.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(fattNew.Numerodocumento))
            {
                txtNumeroDoc.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Numero Documento<br />";
            }
            else
            {
                txtNumeroDoc.CssClass = "form-control";
            }

            if (fattNew.Datadocumento == DateTime.MinValue)
            {
                txtDataDoc.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Data Documento<br />";
            }
            else
            {
                txtDataDoc.CssClass = "form-control";
            }

            if (fattNew.Importototale == 0)
            {
                txtImportoTotale.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Importo Totale<br />";
            }
            else
            {
                txtImportoTotale.CssClass = "form-control";
            }

            if (!servizioFileTracciati.ExistFattura(fattNew.Codfornitore, fattNew.Numerodocumento, fattNew.Datadocumento)) //controllo esistenza fattura
            {

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
                if (servizioFileTracciati.InsertFattureXML(fattNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + fattNew.Numerodocumento);
   

                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        ddlCodsocieta.ClearSelection();
                        ddlFornitore.ClearSelection();
                        ddlTipoDoc.ClearSelection();
                        ddlDivisa.ClearSelection();
                        txtDataDoc.Text = "";
                        txtNumeroDoc.Text = "";
                        txtImportoTotale.Text = "";


                        ddlCodsocieta.CssClass = "form-control";
                        ddlFornitore.CssClass = "form-control";
                        ddlTipoDoc.CssClass = "form-control";
                        ddlDivisa.CssClass = "form-control";
                        txtDataDoc.CssClass = "form-control";
                        txtNumeroDoc.CssClass = "form-control";
                        txtImportoTotale.CssClass = "form-control";

                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuova Fattura o <a href='" + ResolveUrl("~/Admin/Modules/Contratto/ViewFatture") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewFatture");
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
