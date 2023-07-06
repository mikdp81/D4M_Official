// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ConfermaBenefit.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;

namespace DFleet.Users.Modules.Ordini
{
    public partial class ConfermaBenefit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idutente = 0;
            int idapprovazione = 0;
            string sceltabenefit = "";
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();

            if (Session["sceltabenefit"] != null)
            {
                sceltabenefit = Session["sceltabenefit"].ToString();
            }


            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;

                IContratti data2 = servizioContratti.ReturnIdApprovazione(idutente);
                if (data2 != null)
                {
                    idapprovazione = data2.Idapprovazione;
                }
            }

            bool ValOk = false;
            string redirect = "";

            //update scelta benefit
            switch (sceltabenefit.ToUpper())
            {
                case "AUTO":

                    if (servizioContratti.UpdateUserCarPolicy(idapprovazione, sceltabenefit, "", DateTime.Now, SeoHelper.ReturnSessionTenant()) == 1)
                    {
                        ValOk = true;
                        redirect = "ConfiguraAuto";
                    }

                    break;
                case "MOBILITA1":
                case "MOBILITA2":

                    if (servizioContratti.UpdateUserCarPolicy(idapprovazione, "MOBILITA", sceltabenefit, DateTime.Now, SeoHelper.ReturnSessionTenant()) == 1)
                    {
                        ValOk = true;
                        redirect = "ConfermaBenefitOk";
                    }

                    break;
                case "RINUNCIA":

                    if (servizioContratti.UpdateRinunciaCarPolicy(idutente, SeoHelper.ReturnSessionTenant()) == 1)
                    {
                        ValOk = true;
                        redirect = "ConfermaBenefitOk";
                    }

                    break;

            }

            if (ValOk)
            {
                Response.Redirect(redirect);
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text += "Operazione fallita";
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScegliBenefit");
        }
    }
}
