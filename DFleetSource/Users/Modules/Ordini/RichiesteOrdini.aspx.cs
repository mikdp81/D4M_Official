// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="RichiesteOrdini.aspx.cs" company="">
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

namespace DFleet.Users.Modules.Ordini
{
    public partial class RichiesteOrdini : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdiduser.Value = Membership.GetUser().ProviderUserKey.ToString();
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;

            int totaleRighe = servizioContratti.SelectCountRichiesteOrdiniXDriver((Guid)Membership.GetUser().ProviderUserKey);
            int totaleRighe2 = servizioContratti.SelectCountRichiesteOrdiniPoolXDriver((Guid)Membership.GetUser().ProviderUserKey);

            if (gvRicOrdini.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicOrdini.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (gvRicOrdiniPool.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicOrdiniPool.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            if (totaleRighe == 0)
            {
                gvRicOrdini.Visible = false;
                pnlMessage.Visible = false;
            }
            else
            {
                gvRicOrdini.Visible = true;
            }

            if (totaleRighe2 == 0)
            {
                gvRicOrdiniPool.Visible = false;
                pnlMessage2.Visible = false;
                lblTitoloOrdiniPool.Text = "";
            }
            else
            {
                gvRicOrdiniPool.Visible = true;
                pnlMessage2.Visible = false;
                lblTitoloOrdiniPool.Text = "<br /><h3>Richieste ordini auto in pool</h3>";
            }

            if (totaleRighe == 0 && totaleRighe2 == 0)
            {
                pnlMessage.Visible = true;
                lblMessage.Text = "Nessuna configurazione";
            }
        }
        public string ReturnAzioni(string uid, string idordine, string idstatusordine)
        {
            string retVal = string.Empty;

            if (idstatusordine.ToUpper() == "0") //configurato
            {
                retVal += "<a href='EditConf-" + SeoHelper.EncodeString(uid) + "' class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Modifica'><img src='../../../plugins/images/ico_modify.svg' class='icon20'/></a>";
                retVal += "<a href='EditRimuoviConf-" + SeoHelper.EncodeString(idordine) + "' onclick=\"return confirm('Sei sicuro di voler cancellare questa configurazione?');\" class='text-inverse p-r-10' data-toggle='tooltip' data-placement='left' title='' data-original-title='Cancella'><img src='../../../plugins/images/cancella_configurazione.svg' class='icon20'/></a>";
            }

            if (idstatusordine.ToUpper() == "30") //da valutare driver
            {
                retVal += "<a href='Accetta-" + SeoHelper.EncodeString(uid) + "' class='text-inverse p-r-10' data-toggle='tooltip' title='' data-placement='left' data-original-title='Visualizza Preventivo e Accetta'><img src='../../../plugins/images/visual_prev_accetta.svg' class='icon20'/></a>";
            }

            return retVal;
        }
        public string ReturnData(string data)
        {
            string retVal = string.Empty;

            if (string.IsNullOrEmpty(data) || data == "01/01/0001 00:00:00")
            {
                retVal = "";
            }
            else
            {
                string[] data1 = data.Split(' ');
                retVal += "Data consegna prevista: <strong class='text-red'>" + data1[0] + "</strong>";
            }

            return retVal;
        }
    }
}
