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

namespace DFleet.Admin.UserControl
{
    public partial class UcMenuLeftAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            string tmpidteam;
            int idteam;

            if (Session["IdTeam"] != null)
            {
                tmpidteam = Session["IdTeam"].ToString();
            }
            else
            {
                //crea sessione idteam                
                Recuperadatiuser datiUtente = new Recuperadatiuser();
                Session["IdTeam"] = datiUtente.Idteam;
                tmpidteam = Session["IdTeam"].ToString();
            }

            idteam = SeoHelper.IntString(tmpidteam);

            CreateMenu(idteam, UserId);            

        }

        public void CreateMenu(int idteam, Guid UserId)
        {
            string lblmenu = string.Empty;
            IAccountBL servizioAccount = new AccountBL();

            //lista gruppi menu
            List<IAccount> dataGruppiMenu = servizioAccount.SelectGroupPageTeam(idteam, UserId);

            if (dataGruppiMenu != null && dataGruppiMenu.Count > 0)
            {
                foreach (IAccount resultGruppiMenu in dataGruppiMenu)
                {
                    lblmenu += "<li>";
                    lblmenu += "<a class='waves-effect' href='javascript:void(0);' aria-expanded='false'><i class='" + resultGruppiMenu.Icona + " fa-fw text-white'></i> <span class='hide-menu'> " + resultGruppiMenu.Gruppo + "</span></a>";

                    //lista pagine menu
                    List<IAccount> dataPageMenu = servizioAccount.SelectPageTeam(idteam, UserId, resultGruppiMenu.Codgruppopagina);

                    if (dataPageMenu != null && dataPageMenu.Count > 0)
                    {
                        lblmenu += "<ul aria-expanded='false' class='collapse'>";

                        foreach (IAccount resultPageMenu in dataPageMenu)
                        {
                            lblmenu += "<li> <a href='" + ResolveUrl("~/Admin/Modules/" + resultPageMenu.Linkpagina) + "'>" + resultPageMenu.Pagina + "</a> </li>";
                        }

                        lblmenu += "</ul>";
                    }

                    lblmenu += "</li>";
                }
            }

            ltMenu.Text = lblmenu;
        }


    }
}
