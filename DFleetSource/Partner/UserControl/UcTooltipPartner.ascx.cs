using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DFleet.Classes;

namespace DFleet.Partner.UserControl
{
    public partial class UcTooltipPartner : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            lblnomeutente.Text = datiUtente.Nomeuser;
        }
    }
}
