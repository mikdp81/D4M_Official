// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsCodCarList.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Car
{
    public partial class InsCodCarList : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(35)) //controllo se la pagina è autorizzata per l'utente 
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
            InsertCarList("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertCarList("salvachiudi");
        }

        public void InsertCarList(string opzione)
        {
            ICarsBL servizioCar = new CarsBL();

            ICars carListNew = new Cars
            {
                Codcarlist = SeoHelper.EncodeString(txtCodice.Text),
                Carlist = SeoHelper.EncodeString(txtDescrizione.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (string.IsNullOrEmpty(carListNew.Codcarlist))
            {
                txtCodice.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice<br />";
            }
            else
            {
                if (servizioCar.ExistCodCarList(carListNew.Codcarlist))
                {
                    txtCodice.CssClass = "form-control is-invalid";
                    error += "Codice gi&agrave; esistente<br />";
                }
                else
                {
                    txtCodice.CssClass = "form-control";
                }
            }

            if (string.IsNullOrEmpty(carListNew.Carlist))
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
                if (servizioCar.InsertCarList(carListNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + carListNew.Codcarlist);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        txtCodice.Text = "";                        
                        txtDescrizione.Text = "";

                        txtCodice.CssClass = "form-control";
                        txtDescrizione.CssClass = "form-control";

                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuova Car List o <a href='" + ResolveUrl("~/Admin/Modules/Car/ViewCodCarList") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewCodCarList");
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
