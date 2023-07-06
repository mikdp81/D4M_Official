// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DelCategorieOptional.aspx.cs" company="">
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
    public partial class DelCategorieOptional : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(36)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
            {                
                ICarsBL servizioCar = new CarsBL();

                //cancella categoria
                ICars carListDel = new Cars
                {
                    Uid = uid,
                    Uidtenant = SeoHelper.ReturnSessionTenant()
                };

                if (servizioCar.DeleteCategorieOptional(carListDel) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Cancellazione " + carListDel.Uid);


                    //messaggio avvenuta cancellazione
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-success";
                    lblMessage.Text = "Cancellazione avvenuta correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Car/ViewCategorieOptional") + "'>Ritorna alla Lista</a>";
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
