// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="AutorizzaVoltura.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using DFleet.Classes;

namespace DFleet.Admin.Modules.Contratto
{
    public partial class AutorizzaVoltura : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(43)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
            {                
                IContrattiBL servizioContratti = new ContrattiBL();

                if (servizioContratti.UpdateChangeStatusContratto(uid, 0, SeoHelper.ReturnSessionTenant()) == 1)
                {
                    //dati voltura precedente se esistente
                    IContratti data = servizioContratti.DetailContrattiId(uid);
                    if (data != null)
                    {
                        if (data.Uidcontrattovolturato != Guid.Empty)
                        {
                            servizioContratti.UpdateContrattoVolturato(data.Uidcontrattovolturato, data.Datainiziocontratto.AddDays(-1), SeoHelper.ReturnSessionTenant());
                        }

                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Autorizzazione voltura " + uid);


                        //messaggio avvenuta cancellazione
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Autorizzazione voltura avvenuta correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Contratto/ViewAutorizzaVolture") + "'>Ritorna alla Lista</a>";
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
