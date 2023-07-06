// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ucHeaderAdmin.ascx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Web.Security;
using BusinessObject;
using BusinessLogic;
using System.Web.Services;
using System.Globalization;
using DFleet.Classes;

namespace DFleet.Admin
{
    public partial class UCHeaderAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccountBL servizioAccount = new AccountBL();
            IUtilitysBL servizioUtility = new UtilitysBL();
            IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;

            //recupero tenant
            Recuperadatiuser datiUtente = new Recuperadatiuser(); 
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            IAccount dataTenant = servizioAccount.ReturnPropertyTenant(Uidtenant);
            if (dataTenant != null)
            {
                //logo
                if (!string.IsNullOrEmpty(dataTenant.Logo))
                {
                    ltLogo.Text = "<img src='" + ResolveUrl("~/plugins/images/" + dataTenant.Logo + "") + "' style='width:130px;' alt='home' />";
                }
            }

            //recupero idgruppo users
            IAccount dataG = servizioAccount.DetailId(UserId);
            if (dataG != null)
            {
                if (dataG.Idgruppouser != 10) //se utente non master rende scelta tenant non visibile
                {
                    ddlChangeTenant.Visible = false;
                }
            }

            hduseridteam.Value = Membership.GetUser().ProviderUserKey.ToString();            
            string tmpidteam;
            string tmpuidtenant;

            if (!IsPostBack)
            {
                if (Session["UidTenant"] != null)
                {
                    tmpuidtenant = Session["UidTenant"].ToString();
                }
                else
                {
                    //crea sessione uidtenant                
                    Session["UidTenant"] = datiUtente.ReturnUidTenant();
                    tmpuidtenant = Session["UidTenant"].ToString();
                }

                if (Session["IdTeam"] != null)
                {
                    tmpidteam = Session["IdTeam"].ToString();
                }
                else
                {
                    //crea sessione idteam                
                    Session["IdTeam"] = datiUtente.Idteam;
                    tmpidteam = Session["IdTeam"].ToString();
                }

                if (datiUtente.Flgdriver == 1)
                {
                    lblentradriver.Text = "<a href='" + ResolveUrl("~/ChangeRoles-" + UserId) + "' style='color:#fff;'><img src='../../../plugins/images/entra_come_driver.svg' class='icon35' alt='Entra come driver' title='Entra come driver' border='0' /></a>";
                }

                ddlChangeTeam.SelectedValue = tmpidteam;
                ddlChangeTenant.SelectedValue = tmpuidtenant;

                lblCountTask.Text = servizioUtility.SelectCountTaskAperti(UserId, Uidtenant).ToString();
                if (datiUtente.ReturnAutorizzatore() == 1)
                {
                    lblCountComunic.Text = servizioComunicazioni.SelectCountComunicazioniAperte(UserId, Uidtenant).ToString();
                    gvCom.Visible = false;
                    gvComAppr.Visible = true;
                }
                else
                {
                    lblCountComunic.Text = servizioComunicazioni.SelectCountComunicazioniAperteAdmin(Uidtenant).ToString();
                    gvCom.Visible = true;
                    gvComAppr.Visible = false;
                }
            }
        }

        protected void ddlChangeTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = (DropDownList)sender;
            string value = (string)list.SelectedValue;

            HttpContext.Current.Session["IdTeam"] = value;

            Response.Redirect(ResolveUrl("~/Admin/Modules/Dash/Dashboard"));
        }

        protected void ddlChangeTenant_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = (DropDownList)sender;
            string value = (string)list.SelectedValue;

            HttpContext.Current.Session["UidTenant"] = value;
            HttpContext.Current.Session.Remove("IdTeam");
            HttpContext.Current.Session["IdTeam"] = null;

            Response.Redirect(ResolveUrl("~/Admin/Modules/Dash/Dashboard"));

        }
    }
}
