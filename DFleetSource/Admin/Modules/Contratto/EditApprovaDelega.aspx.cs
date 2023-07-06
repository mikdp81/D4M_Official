// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="EditApprovaDelega.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using DFleet.Classes;
using System.IO;
using System.Linq;

namespace DFleet.Admin.Modules.Contratto
{
    public partial class EditApprovaDelega : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(76)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailDelega(uid);
                    if (data != null)
                    {
                        BindData(data);
                    }
                    else
                    {
                        Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                    }
                }
            }
        }
        private void BindData(IContratti data)
        {
            IAccountBL servizioAccount = new AccountBL();
            IUtilitysBL servizioUtility = new UtilitysBL();

            hduid.Value = data.Uid.ToString();
            txtNote.Text = data.Noteamministrazione;

            if (!string.IsNullOrEmpty(data.Modulofirmato))
            {
                lblviewfilemodulo.Text += "<a href=\"../../../DownloadFile?type=deleghe&nomefile=" + data.Modulofirmato + "\" target='_blank'>Apri File</a>";
            }
            else
            {
                lblviewfilemodulo.Text = "NON CARICATO";
            }

            if (data.Idtipomodulo == 1)
            {
                lblTipoModulo.Text = "DELEGA";
            }
            if (data.Idtipomodulo == 2)
            {
                lblTipoModulo.Text = "ZTL";
            }

            if (!string.IsNullOrEmpty(data.Checkdoc))
            {
                if (data.Checkdoc.ToUpper() == "SI")
                {
                    lblAppr.Text = "APPROVATO";
                }
                if (data.Checkdoc.ToUpper() == "NO")
                {
                    lblAppr.Text = "NON APPROVATO";
                }
            }
            else
            {
                lblAppr.Text = "DA APPROVARE";
            }

            //dettagli driver
            IAccount dataD = servizioAccount.DetailId(data.UserId);
            if (dataD != null)
            {
                lblDati.Text += dataD.Cognome + " " + dataD.Nome + " (" + dataD.Matricola + ")";

                //societa
                IUtilitys dataS = servizioUtility.DetailSocietaXCodS(dataD.Codsocieta);
                if (dataS != null)
                {
                    lblSocieta.Text = dataS.Siglasocieta;
                }
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateContratti();
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateContratti2();
        }


        public void UpdateContratti()
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            if (servizioContratti.UpdateApprovaDelega("SI", SeoHelper.EncodeString(txtNote.Text), SeoHelper.GuidString(hduid.Value), SeoHelper.ReturnSessionTenant()) == 1)
            {
                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Delega Non Approvata: " + hduid.Value);

                Response.Redirect("ViewDeleghe");
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text += "Operazione fallita";
            }            
        }

        public void UpdateContratti2()
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            if (servizioContratti.UpdateApprovaDelega("NO", SeoHelper.EncodeString(txtNote.Text), SeoHelper.GuidString(hduid.Value), SeoHelper.ReturnSessionTenant()) == 1)
            {
                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Delega Approvata: " + hduid.Value);

                Response.Redirect("ViewDeleghe");
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text += "Operazione fallita";
            }
        }

    }
}
