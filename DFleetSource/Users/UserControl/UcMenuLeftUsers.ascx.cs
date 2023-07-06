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

namespace DFleet.Users.UserControl
{
    public partial class UcMenuLeftUsers : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccountBL servizioAccount = new AccountBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idutente = 0;

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;
            }

            CreateMenu(idutente);
        }
        public void CreateMenu(int idutente)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();

            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            string lblmenu = string.Empty;
            string codcarpolicy = "";
            int idapprovazione = 0;

            IContratti data2 = servizioContratti.ReturnIdApprovazione(idutente);
            if (data2 != null)
            {
                idapprovazione = data2.Idapprovazione;
            }

            //ricava scelta benefit
            IContratti dataB = servizioContratti.ReturnDatiBenefitCarPolicy(idapprovazione);
            if (dataB != null)
            {
                codcarpolicy = dataB.Codcarpolicy;
            }



            //lista gruppi menu
            List<IAccount> dataGruppiMenu = servizioAccount.SelectGroupPageUsers(Uidtenant);

            if (dataGruppiMenu != null && dataGruppiMenu.Count > 0)
            {
                foreach (IAccount resultGruppiMenu in dataGruppiMenu)
                {
                    switch (resultGruppiMenu.Codgruppopagina.ToUpper())
                    {
                        case "COR": //AUTO IN CORSO
                            lblmenu += MenuAutoInCorso(resultGruppiMenu, Uidtenant, UserId);
                            break;

                        case "STO": //STORICO AUTO
                            lblmenu += MenuStoricoAuto(resultGruppiMenu, Uidtenant, UserId);
                            break;

                        case "CON": //CONFIGURAZIONE
                            lblmenu += MenuConfigurazione(resultGruppiMenu, Uidtenant, UserId, idutente, codcarpolicy, idapprovazione);
                            break;

                        default: // ALTRI MENU
                            lblmenu += MenuDefault(resultGruppiMenu, Uidtenant);
                            break;
                    }                   

                }
            }

            ltMenu.Text = lblmenu;
        }

        public string MenuDefault(IAccount resultGruppiMenu, Guid Uidtenant)
        {
            IAccountBL servizioAccount = new AccountBL();
            string retVal = "";

            //lista pagine menu
            List<IAccount> dataPageMenu = servizioAccount.SelectPageUsers(resultGruppiMenu.Codgruppopagina, Uidtenant);

            if (dataPageMenu != null && dataPageMenu.Count > 0)
            {
                retVal += "<li>";
                retVal += "<a class='waves-effect' href='javascript:void(0);' aria-expanded='false'><img src='../../../plugins/images/" + resultGruppiMenu.Icona + "' class='icon20'/> <span class='hide-menu'> " + resultGruppiMenu.Gruppo + "</span></a>";

                retVal += "<ul aria-expanded='false' class='collapse'>";

                foreach (IAccount resultPageMenu in dataPageMenu)
                {
                    retVal += "<li> <a href='" + ResolveUrl("~/Users/Modules/" + resultPageMenu.Linkpagina) + "'>" + resultPageMenu.Pagina + "</a> </li>";
                }

                retVal += "</ul>";
                retVal += "</li>";
            }


            return retVal;
        }

        public string MenuConfigurazione(IAccount resultGruppiMenu, Guid Uidtenant, Guid UserId, int idutente, string codcarpolicy, int idapprovazione)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            string retVal = "";

            if (servizioContratti.ExistUserCarPolicy(idutente))
            {
                //lista pagine menu
                List<IAccount> dataPageMenu = servizioAccount.SelectPageUsers(resultGruppiMenu.Codgruppopagina, Uidtenant);

                if (dataPageMenu != null && dataPageMenu.Count > 0)
                {
                    retVal += "<li>";
                    retVal += "<a class='waves-effect' href='javascript:void(0);' aria-expanded='false'><img src='../../../plugins/images/" + resultGruppiMenu.Icona + "' class='icon20'/> <span class='hide-menu'> " + resultGruppiMenu.Gruppo + "</span></a>";

                    retVal += "<ul aria-expanded='false' class='collapse'>";

                    foreach (IAccount resultPageMenu in dataPageMenu)
                    {

                        if (codcarpolicy.ToUpper() == "NOCAR")
                        {
                            if (resultPageMenu.Pagina.ToUpper() == "STORICO PACCHETTI")
                            {
                                retVal += "<li> <a href='" + ResolveUrl("~/Users/Modules/" + resultPageMenu.Linkpagina) + "'>" + resultPageMenu.Pagina + "</a> </li>";
                            }
                        }


                        if (codcarpolicy.ToUpper() != "NOCAR")
                        {
                            if (resultPageMenu.Pagina.ToUpper() == "CARICA DOCUMENTO CARPOLICY" || resultPageMenu.Pagina.ToUpper() == "CONFIGURA AUTO")
                            {
                                if (servizioContratti.ExistUserCarPolicyActive(idutente))
                                {
                                    if (servizioContratti.SelectCountConfigurazioniDaFirmare(idapprovazione) == 0)
                                    {
                                        retVal += "<li> <a href='" + ResolveUrl("~/Users/Modules/" + resultPageMenu.Linkpagina) + "'>" + resultPageMenu.Pagina + "</a> </li>";
                                    }
                                }
                            }

                            if (resultPageMenu.Pagina.ToUpper() == "STORICO CONFIGURAZIONI")
                            {
                                retVal += "<li> <a href='" + ResolveUrl("~/Users/Modules/" + resultPageMenu.Linkpagina) + "'>" + resultPageMenu.Pagina + "</a> </li>";
                            }
                        }



                        IContratti data = servizioContratti.DetailVeicoloAttualeDriver(UserId);
                        if (data != null)
                        {
                            IContratti dataA = servizioContratti.DetailContrattiAssId(data.Idcontratto, UserId);
                            if (dataA != null)
                            {
                                if (resultPageMenu.Pagina.ToUpper() == "RESTITUZIONE AUTO")
                                {
                                    if (dataA.Datarestituzione > DateTime.MinValue && !string.IsNullOrEmpty(dataA.Luogorestituzione))
                                    {
                                        retVal += "<li> <a href='" + ResolveUrl("~/Users/Modules/" + resultPageMenu.Linkpagina) + "'>" + resultPageMenu.Pagina + "</a> </li>";
                                    }
                                }

                                if (resultPageMenu.Pagina.ToUpper() == "RITIRO AUTO")
                                {
                                    if (dataA.Dataconsegna > DateTime.MinValue && !string.IsNullOrEmpty(dataA.Luogoconsegna))
                                    {
                                        retVal += "<li> <a href='" + ResolveUrl("~/Users/Modules/" + resultPageMenu.Linkpagina) + "'>" + resultPageMenu.Pagina + "</a> </li>";
                                    }
                                }

                            }
                        }
                    }

                    retVal += "</ul>";
                    retVal += "</li>";
                }

            }


            return retVal;
        }

        public string MenuStoricoAuto(IAccount resultGruppiMenu, Guid Uidtenant, Guid UserId)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            string retVal = "";

            if (servizioContratti.ExistStoricoAuto(UserId))
            {

                //lista pagine menu
                List<IAccount> dataPageMenu = servizioAccount.SelectPageUsers(resultGruppiMenu.Codgruppopagina, Uidtenant);

                if (dataPageMenu != null && dataPageMenu.Count > 0)
                {
                    retVal += "<li>";
                    retVal += "<a class='waves-effect' href='javascript:void(0);' aria-expanded='false'><img src='../../../plugins/images/" + resultGruppiMenu.Icona + "' class='icon20'/> <span class='hide-menu'> " + resultGruppiMenu.Gruppo + "</span></a>";

                    retVal += "<ul aria-expanded='false' class='collapse'>";

                    foreach (IAccount resultPageMenu in dataPageMenu)
                    {
                        retVal += "<li> <a href='" + ResolveUrl("~/Users/Modules/" + resultPageMenu.Linkpagina) + "'>" + resultPageMenu.Pagina + "</a> </li>";
                    }

                    retVal += "</ul>";
                    retVal += "</li>";
                }

            }

            return retVal;
        }

        public string MenuAutoInCorso(IAccount resultGruppiMenu, Guid Uidtenant, Guid UserId)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            string retVal = "";

            IContratti data = servizioContratti.DetailVeicoloAttualeDriver(UserId);
            if (data != null)
            {
                IContratti dataA = servizioContratti.DetailContrattiAssId(data.Idcontratto, UserId);
                if (dataA != null)
                {

                    //lista pagine menu
                    List<IAccount> dataPageMenu = servizioAccount.SelectPageUsers(resultGruppiMenu.Codgruppopagina, Uidtenant);

                    if (dataPageMenu != null && dataPageMenu.Count > 0)
                    {
                        retVal += "<li>";
                        retVal += "<a class='waves-effect' href='javascript:void(0);' aria-expanded='false'><img src='../../../plugins/images/" + resultGruppiMenu.Icona + "' class='icon20'/> <span class='hide-menu'> " + resultGruppiMenu.Gruppo + "</span></a>";

                        retVal += "<ul aria-expanded='false' class='collapse'>";

                        foreach (IAccount resultPageMenu in dataPageMenu)
                        {
                            retVal += "<li> <a href='" + ResolveUrl("~/Users/Modules/" + resultPageMenu.Linkpagina) + "'>" + resultPageMenu.Pagina + "</a> </li>";
                        }

                        retVal += "</ul>";
                        retVal += "</li>";
                    }
                }
            }

            return retVal;
        }
    }

}
