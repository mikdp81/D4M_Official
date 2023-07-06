// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="DetailImport.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Text.RegularExpressions;
using System.Web;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using System.IO;
using System.Linq;
using DFleet.Classes;
using ExcelDataReader;
using System.Data;

namespace DFleet.Admin.Modules.Tracciati
{
    public partial class DetailImport : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(41)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IFileTracciatiBL servizioImport = new FileTracciatiBL();

            if (Int32.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out int idprog))
            {
                IFileTracciati data = servizioImport.DetailImportazioni(idprog);

                if (data != null)
                {
                    lblDetail.Text += "File: " + data.Nomefile + "<br />" +
                                      "Tipo File: " + data.Tipofile + "<br />" +
                                      "Periodo dal:  " + data.Periododal.ToString("dd/MM/yyyy") + "<br />" +
                                      "Periodo al:  " + data.Periodoal.ToString("dd/MM/yyyy") + "<br />" +
                                      "Data caricamento: " + data.Datacaricato.ToString("dd/MM/yyyy") + "<br />" +
                                      "Esito: " + data.Importato + "<br />" +
                                      "Data importazione: " + data.Dataimportazione.ToString("dd/MM/yyyy") + "<br />" +
                                      "Righe importate: " + data.Righeimportate + "<br />" +
                                      "Righe totali: " + data.Righetotali + "<br />" +
                                      "Righe Errori: " + data.Texterrori + "<br />";
                }
            }
        }
    }
}
