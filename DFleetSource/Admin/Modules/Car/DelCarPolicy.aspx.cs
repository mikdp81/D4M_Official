// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DelCarPolicy.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using DFleet.Classes;

namespace DFleet.Admin.Modules.Car
{
    public partial class DelCarPolicy : System.Web.UI.Page
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
            string codcarpolicy = string.Empty;
            if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
            {                
                ICarsBL servizioCar = new CarsBL();

                //recupera codcarpolicy
                ICars data = servizioCar.DetailCarPolicyId(uid);
                if (data != null)
                {
                    codcarpolicy = data.Codcarpolicy;
                }


                //cancella car policy
                ICars carListDel = new Cars
                {
                    Codcarpolicy = codcarpolicy,
                    Uidtenant = SeoHelper.ReturnSessionTenant()
                };

                ICars carListDel2 = new Cars
                {
                    Codcarpolicy = codcarpolicy,
                    Uidtenant = SeoHelper.ReturnSessionTenant()
                };

                if (servizioCar.DeleteCarPolicy(carListDel) == 1)
                {
                    if (servizioCar.DeleteCarPolicySocieta(carListDel2) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Cancellazione " + carListDel.Uid);


                        //messaggio avvenuta cancellazione
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Cancellazione avvenuta correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Car/ViewCarPolicy") + "'>Ritorna alla Lista</a>";
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
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text += "Operazione fallita";
            }


        }
    }
}
