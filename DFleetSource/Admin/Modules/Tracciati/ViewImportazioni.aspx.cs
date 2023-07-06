// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="ViewImportazioni.aspx.cs" company="">
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
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Net;

namespace DFleet.Admin.Modules.Tracciati
{
    public partial class ViewImportazioni : System.Web.UI.Page
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
            loadPage();
        }
        protected void btnCerca_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            loadPage();
        }
        public void loadPage()
        {
            pnlMessage.Visible = false;

            if (gvImpo.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvImpo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void btnSvuotaFiltri_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewImportazioni");
        }
        protected void btnAggiorna_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewImportazioni");
        }
        protected void btnImporta_Click(object sender, CommandEventArgs e)
        {
            IFileTracciatiBL servizioImport = new FileTracciatiBL();
            string idprog = e.CommandArgument.ToString();

            var ws = Method1(idprog);

            IFileTracciati importUpd3 = new FileTracciati
            {
                Righeimportate = 0,
                Righetotali = 0,
                Texterrori = "",
                Idprog = SeoHelper.IntString(idprog),
                Importato = "IN ELABORAZIONE",
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };
            servizioImport.UpdateStoricoImportazione(importUpd3);

            Response.Redirect("ViewImportazioni");
        }
        public static async Task Method1(string idprog)
        {
            await Task.Run(() =>
            {
                //string url = "https://localhost:44392/Crons/Importazioni.ashx?idprog=" + SeoHelper.EncodeString(idprog);
                //string url = "https://4m.deloitte.it/Crons/Importazioni.ashx?idprog=" + SeoHelper.EncodeString(idprog);
                string url = "https://d4m.deloitte.it/Crons/Importazioni.ashx?idprog=" + SeoHelper.EncodeString(idprog);
                HttpWebRequest request = HttpWebRequest.CreateHttp(url);
                request.GetResponseAsync();
            });
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField importato = (e.Row.FindControl("hdimportato") as HiddenField);
                HtmlInputControl btnAgg = (e.Row.FindControl("btnAggiorna") as HtmlInputControl);
                Button btn = (e.Row.FindControl("btnImporta") as Button);

                if (string.IsNullOrEmpty(importato.Value))
                {
                    btn.Visible = true;
                    btnAgg.Visible = false;
                }
                else
                {
                    if (importato.Value.ToUpper() == "IN ELABORAZIONE")
                    {
                        btn.Visible = false;
                        btnAgg.Visible = true;
                    }
                    else
                    {
                        btn.Visible = false;
                        btnAgg.Visible = false;
                    }
                }
            }
        }
    }
}
