// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModPenale.aspx.cs" company="">
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
using BusinessLogic.Services.blob;

namespace DFleet.Admin.Modules.EPartner
{
    public partial class ModPenale : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(82)) //controllo se la pagina è autorizzata per l'utente 
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
                    IContratti data = servizioContratti.DetailIdPenale(uid);
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
            txtNumeroFattura.Text = data.Numerofattura;
            txtDataFattura.Text = SeoHelper.CheckDataString(data.Datafattura);
            txtImporto.Text = SeoHelper.CheckDecimalString(data.Importo);
            ddltipopenaleauto.SelectedValue = Convert.ToString(data.Idtipopenaleauto, CultureInfo.CurrentCulture);
            ddlUsers.SelectedValue = Convert.ToString(data.UserId, CultureInfo.CurrentCulture);
            hduserid.Value = Convert.ToString(data.UserId, CultureInfo.CurrentCulture);
            ddlFornitore.SelectedValue = data.Codfornitore;
            txtTarga.Text = data.Targa;
            hdtarga.Value = data.Targa;
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);

            if (!string.IsNullOrEmpty(data.Filepenale))
            {
                lblViewFilePenale.Text = "<a href=\"../../../DownloadFile?type=contratti&nomefile=" + data.Filepenale + "\" target='_blank'>Apri File</a>";
            }

        }

        protected void btnAccetta_Click(object sender, EventArgs e)
        {
            UpdatePenali("ACCETTATO");
        }
        protected void btnContesta_Click(object sender, EventArgs e)
        {
            UpdatePenali("CONTESTATO");
        }


        public void UpdatePenali(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid UserId = SeoHelper.GuidString(hduserid.Value);
            string targa = SeoHelper.EncodeString(hdtarga.Value);

            IContratti contrattoNew = new Contratti
            {
                Uid = SeoHelper.GuidString(hduid.Value),
                Statuscontratto = SeoHelper.EncodeString(opzione),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            if (servizioContratti.UpdateStatusPenale(contrattoNew) == 1)
            {
                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + contrattoNew.Uid);

                //se accettato invia mail notifica al partner
                if (opzione.ToUpper() == "ACCETTATO")
                {
                    bool result = true;

                    IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(16);
                    if (dataTemplate != null)
                    {
                        Recuperadatiuser datiUtente = new Recuperadatiuser();
                        result = MailHelper.SendMail("", ReturnEmail(UserId), "", "", "", "", "Notifica nuova penale", servizioUtility.InsPenaleEmail(UserId, targa, dataTemplate.Corpo), "", datiUtente.ReturnObjectTenant());
                    }

                    if (result) //se invio mail è andato a buon fine
                    {
                        Response.Redirect("ViewPenali");
                    }
                    else
                    {
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-danger";
                        lblMessage.Text += "Invio email fallito";
                    }
                }
                else
                {
                    Response.Redirect("ViewPenali");
                }
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text += "Operazione fallita";
            }
        }

        public string ReturnEmail(Guid userId)
        {
            string retVal = string.Empty;

            IAccountBL servizioAccount = new AccountBL();
            IAccount data = servizioAccount.DetailId(userId);
            if (data != null)
            {
                retVal = data.Email;
            }

            return retVal;
        }
    }
}
