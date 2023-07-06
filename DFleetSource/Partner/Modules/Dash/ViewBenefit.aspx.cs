// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewBenefit.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using System.Web;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Drawing;
using DFleet.Classes;

namespace DFleet.Partner.Modules.Dash
{
    public partial class ViewBenefit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idutente;
            int idapprovazione = 0;
            string codpacchetto;
            pacchetto1.Visible = false;
            pacchetto2.Visible = false;

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;

                IContratti dataApp = servizioContratti.ReturnIdApprovazione(idutente);
                if (dataApp != null)
                {
                    idapprovazione = dataApp.Idapprovazione;
                }


                IContratti data2 = servizioContratti.ReturnIdApprovazione(idutente);
                if (data2 != null)
                {
                    IContratti dataB = servizioContratti.ReturnDatiBenefitCarPolicy(idapprovazione);
                    if (dataB != null)
                    {
                        codpacchetto = dataB.Codpacchetto;


                        if (codpacchetto.ToUpper() == "MOBILITA1")
                        {
                            pacchetto1.Visible = true;
                        }

                        if (codpacchetto.ToUpper() == "MOBILITA2")
                        {
                            pacchetto2.Visible = true;
                        }

                    }
                }
            }
        }
    }
}
