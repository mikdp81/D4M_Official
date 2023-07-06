// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewMovision.aspx.cs" company="">
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
using BusinessLogic.Services.blob;

namespace DFleet.Admin.Modules.Utility
{
    public partial class ViewMovision : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(88)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string sas = Global.sas;

            lblContainer.Text = TableViewFile("movesion", sas, "");
            lblContainer2.Text = TableViewFile("movesionarchivio", sas, "2");
            lblContainer3.Text = TableViewFile("movesionpayroll", sas, "3");
        }
        public string TableViewFile(string containerName, string sas, string num)
        {
            string retVal = "";

            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, "", "", containerName);
            retVal += "<table class='display nowrap dataTable" + num + "' cellspacing='0' align='Center' style='width:100%; border-collapse:collapse; '>" +
                      "<thead><tr><th scope='col'>Nome</th><th scope='col'>Ultima Modifica</th><th scope='col'>Dimensione</th><th scope='col'>Visualizza</th></tr></thead>" +
                      "<tbody>" +
                      azureBlobManager.ListBlob(containerName) +
                      "</tbody>" +
                      "</table>";

            return retVal;
        }

    }
}
