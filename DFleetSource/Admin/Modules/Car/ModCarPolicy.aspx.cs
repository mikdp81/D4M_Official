// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModCarPolicy.aspx.cs" company="">
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
    public partial class ModCarPolicy : System.Web.UI.Page
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
            ICarsBL servizioCar = new CarsBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    ICars data = servizioCar.DetailCarPolicyId(uid);
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
            txtCarPolicy.Text = data.Codcarpolicy;
            ddlCodCarList.SelectedValue = data.Codcarlist;
            ddlFuelCard.SelectedValue = data.Codfuelcard;
            ddlCodSocieta.SelectedValue = data.Codsocieta;
            ddlCodPersonType.SelectedValue = data.Codpersontype;
            ddlCodGrade.SelectedValue = data.Codgrade;
            ddlCodSubGrade.SelectedValue = data.Codsubgrade;
            ddlExCarPolicy.SelectedValue = data.Excodcarpolicy;
            txtValidoDal.Text = SeoHelper.CheckDataString(data.Validodal);
            txtValidoAl.Text = SeoHelper.CheckDataString(data.Validoal);
            hduidsocieta.Value = Convert.ToString(data.Uidsocieta, CultureInfo.CurrentCulture);
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture); 
            if (data.Checkoptionalpag == 1)
            {
                checkoptionalpag.Checked = true;
            }
            else
            {
                checkoptionalpag.Checked = false;
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateCarList("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateCarList("salvachiudi");
        }


        public void UpdateCarList(string opzione)
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
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
                Excodcarpolicy = SeoHelper.EncodeString(ddlExCarPolicy.SelectedValue),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            ICars carListNew2 = new Cars
            {
                Codcarpolicy = SeoHelper.EncodeString(carListNew.Codcarpolicy),
                Codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue),
                Codpersontype = SeoHelper.EncodeString(ddlCodPersonType.SelectedValue),
                Codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue),
                Codsubgrade = SeoHelper.EncodeString(ddlCodSubGrade.SelectedValue),
                Validodal = SeoHelper.DataString(txtValidoDal.Text),
                Validoal = SeoHelper.DataString(txtValidoAl.Text),
                Uid = new Guid(SeoHelper.EncodeString(hduidsocieta.Value)),
                Checkoptionalpag = _checkoptionalpag,
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
                txtCarPolicy.CssClass = "form-control";
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
                if (servizioCar.UpdateCarPolicy(carListNew) == 1)
                {
                    if (servizioCar.UpdateCarPolicySocieta(carListNew2) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + carListNew.Uid);

                        if (opzione.ToUpper() == "SALVA")
                        {
                            //messaggio avvenuto inserimento
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Car/ViewCarPolicy") + "'>Ritorna alla Lista</a>";
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
