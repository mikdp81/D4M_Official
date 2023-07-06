using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;
using BusinessLogic;
using DFleet.Classes;

namespace DFleet.Partner.UserControl
{
    public partial class UcMenuLeftPartner : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccountBL servizioAccount = new AccountBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idutente = 0;
            string grade = "";

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;
                grade = data.Gradecode;
            }

            CreateMenu(idutente, grade);
        }
        public void CreateMenu(int idutente, string grade)
        {
            string ltordinicorso = string.Empty;
            string ltautocorso = string.Empty;
            string ltstoricoauto = string.Empty;
            int idapprovazione = 0;
            string sceltabenefit = "";
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            IContrattiBL servizioContratti = new ContrattiBL();

            IContratti data2 = servizioContratti.ReturnIdApprovazione(idutente);
            if (data2 != null)
            {
                idapprovazione = data2.Idapprovazione;
            }

            //ricava scelta benefit
            IContratti dataB = servizioContratti.ReturnDatiBenefitCarPolicy(idapprovazione);
            if (dataB != null)
            {
                sceltabenefit = dataB.Sceltabenefit;
            }

            //menu configura auto
            //if (servizioContratti.ExistUserCarPolicy(idutente))
            //{
                switch (sceltabenefit.ToUpper())
                {
                    case "AUTO":
                    case "":

                        ltordinicorso += "<li>" +
                                 "<a class='waves-effect' href='javascript:void(0);' aria-expanded='false'><img src='../../../plugins/images/configurazione.svg' class='icon20'/> <span class='hide-menu' style='color:#fff;'>Configurazione</span></a>" +

                                 "<ul aria-expanded='false' class='collapse'>";

                        /*if (servizioContratti.ExistUserCarPolicyActive(idutente))
                        { 
                            if (servizioContratti.SelectCountConfigurazioniDaFirmare(idapprovazione) == 0)
                            {
                                ltordinicorso += "<li>" +
                                             "<a href='" + ResolveUrl("~/Partner/Modules/Ordini/UploadCarPolicy") + "'>Carica Documento CarPolicy</a>" +
                                             "</li>" +

                                             "<li>" +
                                             "<a href='" + ResolveUrl("~/Partner/Modules/Ordini/ConfiguraAuto") + "'>Configura Auto</a>" +
                                             "</li>";
                            }
                        }*/


                        ltordinicorso += "<li>" +
                                     "<a href='" + ResolveUrl("~/Partner/Modules/Dash/RichiesteOrdini") + "' style='color:#fff;'>Visualizza Configurazioni</a>" +
                                     "</li>" +

                                     "</ul>" +
                                     "</li>";

                        break;
                    case "MOBILITA":
                        ltordinicorso += "<li>" +
                                 "<a href='" + ResolveUrl("~/Partner/Modules/Dash/ViewBenefit") + "' style='color:#fff;'><img src='../../../plugins/images/configurazione.svg' class='icon20'/> <span class='hide-menu' style='color:#fff;'>Benefit</span></a>" +
                                 "</li>";

                        break;

                }

            //}


            //menu storico auto
            if (servizioContratti.ExistStoricoAuto(UserId))
            {
                ltstoricoauto += "<li>" +
                    "<a href='" + ResolveUrl("~/Partner/Modules/Dash/StoricoAuto") + "' aria-expanded='false'><img src='../../../plugins/images/storico_auto.svg' class='icon20'/> <span class='hide-menu' style='color:#fff;'>Storico Auto</span></a>" +
                    "</li>";
            }

            //menu riconsegna auto
            IContratti data = servizioContratti.DetailVeicoloAttualePartner(UserId);
            if (data != null)
            {
                IContratti dataA = servizioContratti.DetailContrattiAssId(data.Idcontratto, UserId);
                if (dataA != null)
                {
                    if (dataA.Datarestituzione > DateTime.MinValue && !string.IsNullOrEmpty(dataA.Luogorestituzione))
                    {
                        ltordinicorso += "<li>" +
                                         "<a href='" + ResolveUrl("~/Partner/Modules/Dash/RiconsegnaAuto") + "' aria-expanded='false'><img src='../../../plugins/images/riconsegna.svg' class='icon20'/> <span class='hide-menu' style='color:#fff;'>Restituzione Auto</span></a>" +
                                         "</li>";
                    }
                    if (dataA.Dataconsegna > DateTime.MinValue && !string.IsNullOrEmpty(dataA.Luogoconsegna))
                    {
                        ltordinicorso += "<li>" +
                                         "<a href='" + ResolveUrl("~/Partner/Modules/Dash/RitiroAuto") + "' aria-expanded='false'><img src='../../../plugins/images/riconsegna.svg' class='icon20'/> <span class='hide-menu' style='color:#fff;'>Ritiro Auto</span></a>" + 
                                         "</li>";
                    }

                    ltautocorso += "<li>" +
                                        "<a class='waves-effect' href='javascript:void(0);' aria-expanded='false'><img src='../../../plugins/images/auto_in_corso.svg' class='icon20'/> <span class='hide-menu' style='color:#fff;'>Auto in corso</span></a>" +

                                        "<ul aria-expanded='false' class='collapse'>" +

                                        "<li>" +
                                        "<a href='" + ResolveUrl("~/Partner/Modules/Dash/Procedure") + "' style='color:#fff;'>Delega - ZTL</a>" +
                                        "</li>" +

                                        "<li>" +
                                        "<a href='" + ResolveUrl("~/Partner/Modules/Dash/PercorrenzaAutoveicolo") + "' style='color:#fff;'>Percorrenza autoveicolo</a>" +
                                        "</li>" +

                                        "<li>" +
                                        "<a href='" + ResolveUrl("~/Partner/Modules/Dash/FuelCard") + "' style='color:#fff;'>Fuel Card</a>" +
                                        "</li>" +

                                        "<li>" +
                                        "<a href='" + ResolveUrl("~/Partner/Modules/Dash/ViewRevisioni") + "' style='color:#fff;'>Revisioni</a>" +
                                        "</li>";

                                        /*"<li>" +
                                        "<a href='" + ResolveUrl("~/Partner/Modules/Dash/ViewConcur") + "'>Riepilogo Concur</a>" +
                                        "</li>"*/

                    if (grade.ToUpper() == "15") //solo se partner può visualizzare i telepass
                    {
                        ltautocorso += "<li>" +
                                            "<a href='" + ResolveUrl("~/Partner/Modules/Dash/TelePass") + "' style='color:#fff;'>Tele Pass</a>" +
                                            "</li>";
                    }

                    ltautocorso += "<li>" +
                                        "<a href='" + ResolveUrl("~/Partner/Modules/Dash/StoricoAddebiti") + "' style='color:#fff;'>Storico Addebiti</a>" +
                                        "</li>" +

                                        "<li>" +
                                        "<a href='" + ResolveUrl("~/Partner/Modules/Dash/ViewMulte") + "' style='color:#fff;'>Multe</a>" +
                                        "</li>";



                    ltautocorso += "</ul>" +
                                    "</li>";
                    
                }
            }

            ltOrdiniCorso.Text = ltordinicorso;
            ltAutoCorso.Text = ltautocorso;
            ltStoricoAuto.Text = ltstoricoauto;
        }
    }
}
