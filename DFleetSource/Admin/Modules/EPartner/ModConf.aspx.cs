// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewConf.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.EPartner
{
    public partial class ModConf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailConfigurazionePartner(uid);
                    if (data != null)
                    {
                        hduidconf.Value = uid.ToString();
                        hdidconf.Value = data.Idconfigurazione.ToString();
                        ddlStatusOrdini.SelectedValue = data.Idstatusordine.ToString();

                        //dati driver
                        IAccount dataUt = servizioAccount.DetailId(data.UserId);
                        if (dataUt != null)
                        {
                            lblDatiDriver.Text += "<div class='table-responsive'><table class='table'>" +
                                           "<tr><td class='width30p nopadding'>Partner</td> <td class='width70p nopadding'>" + dataUt.Nome + " " + dataUt.Cognome + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Email</td> <td class='width70p nopadding'> " + dataUt.Email + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Cellulare</td> <td class='width70p nopadding'> " + dataUt.Cellulare + "</td></tr>" +
                                           "</table></div>";
                        }

                        //dati configurazione
                        lblDatiOrdine.Text += "<div class='table-responsive'><table class='table'><tr><td class='width30p nopadding'>Num. e data configurazione</td> <td class='width70p nopadding'>" + data.Idconfigurazione + " del " + data.Datainviato.ToString("dd/MM/yyyy") + "</td></tr>";
                        lblDatiOrdine.Text += "<tr><td class='width30p nopadding'>Testo</td> <td class='width70p nopadding'> " + data.Testo + "</td></tr>";
                        lblDatiOrdine.Text += "</table></div>";
                    }
                }
            }
        }
        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            IContratti contrattoNew = new Contratti
            {
                Uid = SeoHelper.GuidString(hduidconf.Value),
                Idstatusordine = SeoHelper.IntString(ddlStatusOrdini.SelectedValue),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            if (servizioContratti.UpdateStatusConfigurazionePartner(contrattoNew) == 1)
            {
                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + contrattoNew.Uid);

                Response.Redirect("RichiesteConf");                
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
