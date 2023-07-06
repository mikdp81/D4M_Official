// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DetailLibrettoAutoServizio.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Contratto
{
    public partial class DetailLibrettoAutoServizio : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(93)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string targa;

            if (!Page.IsPostBack)
            {
                targa = SeoHelper.EncodeString(Request.QueryString["targa"]);
                
                IContratti data = servizioContratti.DetailLibrettoAutoServizioXTarga(targa);
                if (data != null)
                {
                    lblTarga.Text = targa;
                    lblMarca.Text = data.Marca;
                    lblModello.Text = data.Modello;
                }
            }
        }

        public string ReturnScopoViaggio(string scopoviaggio)
        {
            if (!string.IsNullOrEmpty(scopoviaggio))
            {
                return scopoviaggio;
            }
            else
            {
                return "NON COMPILATO";
            }
        }
        public string ReturnKm(string kminiziali, string kmrestituzione)
        {
            if (!string.IsNullOrEmpty(kminiziali) && !string.IsNullOrEmpty(kmrestituzione))
            {
                return kminiziali + " / " + kmrestituzione;
            }
            else
            {
                return "";
            }
        }

        public string ReturnSpese(string spese, string importospese)
        {
            if (!string.IsNullOrEmpty(spese) && !string.IsNullOrEmpty(importospese))
            {
                return spese + ": &euro; " + importospese;
            }
            else
            {
                return "";
            }
        }
    }
}
