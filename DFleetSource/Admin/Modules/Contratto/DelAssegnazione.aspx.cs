// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DelAssegnazione.aspx.cs" company="">
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
    public partial class DelAssegnazione : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(64)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            ICarsBL servizioCar = new CarsBL();

            if (Int32.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out int uid))
            {
                hdidass.Value = uid.ToString();

                IContratti dataA = servizioContratti.DetailAssegnazioniContrattiXId(uid);
                if (dataA != null)
                { 
                    lblTarga.Text = dataA.Targa;

                    //nome driver
                    IAccount dataU = servizioAccount.DetailId(dataA.UserId);
                    if (dataU != null)
                    {
                        lblDriver.Text = dataU.Cognome + " " + dataU.Nome;
                    }

                    IContratti dataC = servizioContratti.DetailContrattiId2(dataA.Idcontratto);
                    if (dataC != null)
                    {
                        //recupero modello auto
                        ICars dataCar = servizioCar.DetailCarListAutoXCodjato(dataC.Codjatoauto, dataC.Codcarlist);
                        if (dataCar != null)
                        {
                            lblModello.Text = dataCar.Modello;
                        }
                    }
                }
            }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            //cancella contratto
            IContratti contrattotDel = new Contratti
            {
                Idassegnazione = SeoHelper.IntString(hdidass.Value),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            if (servizioContratti.DeleteAssegnazione(contrattotDel) == 1)
            {
                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Cancellazione Assegnazione " + contrattotDel.Idassegnazione);

                Response.Redirect("ViewContratti");
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
