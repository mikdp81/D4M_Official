// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ScegliBenefit.aspx.cs" company="">
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
    public partial class ScegliBenefit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idutente;
            string codcarpolicy = "";
            string codcarbenefit = "";
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();


            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;

                IContratti dataPol = servizioContratti.ReturnTypeCarPolicy(idutente);
                if (dataPol != null)
                {
                    codcarpolicy = dataPol.Codcarpolicy;
                    codcarbenefit = dataPol.Codcarbenefit;
                }

                //se la carpolicy contiene solo codcarbenefit nasconde blocco scelta codcarpolicy
                if (codcarpolicy.ToUpper() == "NOCAR" && codcarbenefit.ToUpper() != "NOBENEFIT")
                {
                    block1.Visible = false;
                }
            }
        }

        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            string sceltabenefit;
            sceltabenefit = Request.Form["sceltabenefit"];

            if (sceltabenefit == null)
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Scegliere un'opzione pe poter proseguire.";
            }
            else
            {
                Session["sceltabenefit"] = sceltabenefit;
                Response.Redirect("ConfermaBenefit");
            }
        }
    }
}
