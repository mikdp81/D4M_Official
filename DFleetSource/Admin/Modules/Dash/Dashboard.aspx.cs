// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="dashboard.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Security.Permissions;
using System.Threading;
using System.Web.Security;
using BusinessLogic;
using BusinessObject;
using System.Globalization;
using System.Collections.Generic;
using DFleet.Classes;

namespace DFleet.Admin.Modules.Dash
{

    public partial class Dashboard1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ILogBL log = new LogBL();
            log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "View Dashboard");

            IUtilitysBL servizioUtility = new UtilitysBL();
            IAccountBL servizioAccount = new AccountBL();

            Recuperadatiuser datiUtente = new Recuperadatiuser();
            Guid Uidtenant = datiUtente.ReturnUidTenant();

            if (Session["UidTenant"] == null)
            {
                Session["UidTenant"] = Uidtenant;
            }
            else
            {
                Uidtenant = SeoHelper.ReturnSessionTenant();
            }

            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            hduiduser.Value = Membership.GetUser().ProviderUserKey.ToString();

            if (!Page.IsPostBack)
            {
                lblCountTask.Text = servizioUtility.SelectCountTaskAperti(UserId, Uidtenant).ToString();
            }

            IUtilitys data = servizioUtility.ViewDashAdmin(Uidtenant);
            if (data != null)
            {
                lblconfigurazionidaautorizzare.Text = data.Configurazionidaautorizzare.ToString();
                lbloffertedainviareadriver.Text = data.Offertedainviareadriver.ToString();
                lblconfermedafirmare.Text = data.Confermedafirmare.ToString();
                lblfringebenefitdacalcolare.Text = data.Fringebenefitdacalcolare.ToString();
                lblticketaperti.Text = data.Ticketaperti.ToString();
                lblticketlavorazione.Text = data.Ticketlavorazione.ToString();
                lblticketchiusi.Text = data.Ticketchiusi.ToString();
                lblticketcancellati.Text = data.Ticketcancellati.ToString();

                lblcarpolicypep.Text = data.Carpolicydaautorizzare.ToString();
                lbldeleghedafirmare.Text = data.Ztldafirmare.ToString();
                lblinoffertarenter.Text = data.Inoffertarenter.ToString();
                lbloffertevalutazione.Text = data.Offertevalutazioneadriver.ToString();
                lblordinievasione.Text = data.Ordinievasione.ToString();
                lblcarpolicydacontrollare.Text = data.Documentipolicydacontrollare.ToString();
                lblautoritiro.Text = data.Autoritiro.ToString();
                lblautoconsegna.Text = data.Autoconsegna.ToString();
            }

            IUtilitys data2 = servizioUtility.ViewDashPEP(ReturnCodSocieta(), Uidtenant);
            if (data2 != null)
            {
                lblcarpolicydaautorizzare.Text = data2.Carpolicydaautorizzare.ToString();
                lblcarpolicyinviaremail.Text = data2.Carpolicyinviaremail.ToString();
                lblconfigurazionidaautorizzarepp.Text = data2.Configurazionidaautorizzarepp.ToString();
                lblautorunning.Text = data2.Autorunning.ToString();
                lblautopool.Text = data2.Autopool.ToString();
                lblordini.Text = data2.Ordini.ToString();
            }

            IUtilitys data3 = servizioUtility.ViewDashHR(ReturnCodSocieta(), Uidtenant);
            if (data3 != null)
            {
                Label1.Text = "0";
                Label2.Text = "0";
                Label3.Text = "0";
                Label4.Text = "0";
            }



            IUtilitys data4 = servizioUtility.ViewDashPartner(Uidtenant);
            if (data4 != null)
            {
                lblconfermedafirmarePart.Text = data4.Confermedafirmare.ToString();
                lblfringebenefitdacalcolarePart.Text = data4.Fringebenefitdacalcolare.ToString();
                lblticketapertiPart.Text = data4.Ticketaperti.ToString();
                lblticketlavorazionePart.Text = data4.Ticketlavorazione.ToString();
                lblticketchiusiPart.Text = data4.Ticketchiusi.ToString();
                lblticketcancellatiPart.Text = data4.Ticketcancellati.ToString();
                lbldeleghedafirmarePart.Text = data4.Ztldafirmare.ToString();
                lblordinievasionePart.Text = data4.Ordinievasione.ToString();
                lblautoritiroPart.Text = data4.Autoritiro.ToString();
                lblautoconsegnaPart.Text = data4.Autoconsegna.ToString();
                lblconfigurazionicorsoPart.Text = data4.Configurazionicorso.ToString();
                lblconfigurazionievasePart.Text = data4.Configurazionievase.ToString();
                lblpenaligestirePart.Text = data4.Penaligestire.ToString();
                lblpenaliapprovatePart.Text = data4.Penaliapprovate.ToString();
                lblpenalicontestazionePart.Text = data4.Penalicontestazione.ToString();
            }

            IAccount dataTenant = servizioAccount.ReturnPropertyTenant(Uidtenant);
            if (dataTenant != null)
            {
                //logo
                if (!string.IsNullOrEmpty(dataTenant.Logo))
                {
                    ltLogo.Text = "<img src='" + ResolveUrl("~/plugins/images/" + dataTenant.Logo + "") + "' style='max-width:100%'>";
                    ltLogo2.Text = "<img src='" + ResolveUrl("~/plugins/images/" + dataTenant.Logo + "") + "' style='max-width:100%'>";
                    ltLogo3.Text = "<img src='" + ResolveUrl("~/plugins/images/" + dataTenant.Logo + "") + "' style='max-width:100%'>";
                    ltLogo4.Text = "<img src='" + ResolveUrl("~/plugins/images/" + dataTenant.Logo + "") + "' style='max-width:100%'>";
                }
            }
            
        }

        public string ReturnTesto(string testotask, string linktask)
        {
            string retVal = string.Empty;

            retVal += testotask;
            if (!string.IsNullOrEmpty(linktask))
            {
                retVal += " &nbsp; <a href='" + linktask + "' target='_blank'>Clicca qui</a>";
            }
            return retVal;
        }

        public string ReturnCheck(string idtask, string esitotask, string uid, string datatask)
        {
            string retVal;
            string dataoggi;
            string dataora = DateTime.Now.ToString("dd/MM/yyyy");

            if (SeoHelper.DataString(datatask) < SeoHelper.DataString(dataora))
            {
                dataoggi = "NO";
            }
            else
            {
                dataoggi = "SI";
            }

            if (esitotask == "1")
            {
                retVal = "<input id='c7_" + idtask + "' data-id='" + uid + "' data-day='" + dataoggi  + "' class='checktask1' type='checkbox' checked='checked' onclick='return false;'>";
            }
            else
            {
                retVal = "<input id='c7_" + idtask + "' data-id='" + uid + "' data-day='" + dataoggi + "' class='checktask' type='checkbox'>";
            }

            return retVal;
        }
                      
        public int Approvatore()
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            return datiUtente.ReturnAutorizzatore();
        }
        public string ReturnCodSocieta()
        {
            IAccountBL servizioAccount = new AccountBL();
            string retVal = string.Empty;

            IAccount dataId = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
            if (dataId != null)
            {
                retVal = dataId.Codsocieta;
            }

            return retVal;
        }
    }
}
