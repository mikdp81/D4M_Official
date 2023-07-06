// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsCarPolicy.aspx.cs" company="">
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
    public partial class InsCarPolicy : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(4)) //controllo se la pagina è autorizzata per l'utente 
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

            int _checkoptionalpag;

            if (checkoptionalpag.Checked)
            {
                _checkoptionalpag = 1;
            }
            else
            {
                _checkoptionalpag = 0;
            }

            ICars carListNew = new Cars
            {
                Codcarpolicy = SeoHelper.EncodeString(txtCarPolicy.Text),
                Codcarlist = SeoHelper.EncodeString(ddlCodCarList.SelectedValue),
                Codfuelcard = SeoHelper.EncodeString(ddlFuelCard.SelectedValue),
                Excodcarpolicy = SeoHelper.EncodeString(ddlExCarPolicy.SelectedValue),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;


            if (string.IsNullOrEmpty(carListNew.Codcarpolicy))
            {
                txtCarPolicy.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Car Policy<br />";
            }
            else
            {
                if (servizioCar.ExistCarPolicy(carListNew.Codcarpolicy))
                {
                    txtCarPolicy.CssClass = "form-control is-invalid";
                    error += "Car Policy gi&agrave; esistente<br />";
                }
                else
                {
                    txtCarPolicy.CssClass = "form-control";
                }
            }

            if (string.IsNullOrEmpty(carListNew.Codcarlist))
            {
                ddlCodCarList.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Car List<br />";
            }
            else
            {
                ddlCodCarList.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(carListNew.Codfuelcard))
            {
                ddlFuelCard.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Fuel Card<br />";
            }
            else
            {
                ddlFuelCard.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(carListNew.Excodcarpolicy))
            {
                ddlExCarPolicy.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Ex Car Policy<br />";
            }
            else
            {
                ddlExCarPolicy.CssClass = "form-control";
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
                if (servizioCar.InsertCarPolicy(carListNew) == 1)
                {
                    //inserimento car policy assegna societa
                    foreach (ListItem item in ddlCodGrade.Items)
                    {
                        if (item.Selected)
                        {
                            ICars carListNew2 = new Cars
                            {
                                Codcarpolicy = SeoHelper.EncodeString(carListNew.Codcarpolicy),
                                Codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue),
                                Codpersontype = SeoHelper.EncodeString(ddlCodPersonType.SelectedValue),
                                Codgrade = SeoHelper.EncodeString(item.Value),
                                Codsubgrade = SeoHelper.EncodeString(ddlCodSubGrade.SelectedValue),
                                Validodal = SeoHelper.DataString(txtValidoDal.Text),
                                Validoal = SeoHelper.DataString(txtValidoAl.Text),
                                Checkoptionalpag = _checkoptionalpag,
                                Uidtenant = SeoHelper.ReturnSessionTenant()
                            };
                            servizioCar.InsertCarPolicySocieta(carListNew2);
                        }
                    }

                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + carListNew.Codcarpolicy);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        ddlCodCarList.ClearSelection();
                        ddlFuelCard.ClearSelection();
                        ddlExCarPolicy.ClearSelection();
                        txtCarPolicy.Text = "";

                        ddlCodCarList.CssClass = "form-control";
                        ddlFuelCard.CssClass = "form-control";
                        txtCarPolicy.CssClass = "form-control";
                        ddlExCarPolicy.CssClass = "form-control";

                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuova Car Policy o <a href='" + ResolveUrl("~/Admin/Modules/Car/ViewCarPolicy") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewCarPolicy");
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
