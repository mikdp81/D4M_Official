// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModAbbinaFattura.aspx.cs" company="">
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
    public partial class ModAbbinaFattura : System.Web.UI.Page
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
            IContrattiBL servizioContratti = new ContrattiBL();

            if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
            {
                hduid.Value = uid.ToString(); 

                IContratti data = servizioContratti.DetailFattureDetId(uid);
                if (data != null)
                {
                    hduidfattura.Value = data.Uidfattura.ToString();
                }
            }
            else
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }


        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IContratti contrattoNew = new Contratti();

            if (servizioContratti.UpdateAbbinaFattura(contrattoNew) == 1)
            {
                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Fattura Abbinata a centro costo " + hduid.Value);


                //messaggio avvenuta cancellazione
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-success";
                lblMessage.Text = "Fattura Abbinata  <br /> <a href='" + ResolveUrl("~/Admin/Modules/Contratto/EditFattura-" + SeoHelper.EncodeString(hduidfattura.Value)) + "'>Torna indietro</a>";
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text += "Operazione fallita";
            }

        }

        public string ReturnLink()
        {
            return "EditFattura-" + SeoHelper.EncodeString(hduidfattura.Value);
        }
    }
}
