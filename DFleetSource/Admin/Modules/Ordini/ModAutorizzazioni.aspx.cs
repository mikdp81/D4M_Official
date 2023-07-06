// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModAutorizzazioni.aspx.cs" company="">
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
using System.Linq;
using DFleet.Classes;

namespace DFleet.Admin.Modules.Ordini
{
    public partial class ModAutorizzazioni : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(9)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            hdcodsocieta.Value = ReturnCodSocieta();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["opt"] != null)
                {
                    if (Request.QueryString["opt"].ToString().ToUpper() == "OK")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Autorizzazione avvenuta correttamente";
                    }
                }

                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {

                    IContratti data = servizioContratti.DetailUserCarPolicyId(uid);
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
            rbCarPolicy.SelectedValue = data.Codcarpolicy;
            lblDati.Text = "Societ&agrave;: <h4>" + data.Codsocieta + " </h4>Denominazione:<br><h3> " + data.Denominazione + "</h3>  Matricola: <h4>" + data.Matricola +
                           "</h4>Cellulare: <h4>" + data.Cellulare + "</h4>Email: <h4>" + data.Email + "</h4> Data assunzione: <h4>" + SeoHelper.CheckDataString(data.Dataassunzione) + "</h4>" +
                           "Grade: <h4>" + data.Grade + "</h4>";
            hduid.Value = SeoHelper.CheckGuidString(data.Uid);
            hdidutente.Value = SeoHelper.CheckGuidString(data.UserId);

            if (data.Approvato == 0) // se non approvato disabilita tasto invia mail
            {
                btnModifica2.Visible = false;                
            }
            else
            {
                if (data.Datadecorrenza > DateTime.Now)
                {
                    btnModifica2.Visible = false;
                }
            }

            if (data.Datamail > DateTime.MinValue) // se invio mail effettuato non può modificare il car policy
            {
                rbCarPolicy.Enabled = false;
            }
            else
            {
                rbCarPolicy.Enabled = true;
            }


            if (data.Preassegnazione.ToUpper() == "SI")
            {
                preassegnazione.Checked = true;
            }
            else
            {
                preassegnazione.Checked = false;
            }

            if (data.Datadecorrenza > DateTime.MinValue)
            {
                txtDataDecorrenza.Text = SeoHelper.CheckDataString(data.Datadecorrenza);
                lblDataSuggerita.Text = data.Dataassunzione.AddMonths(6).ToString("dd/MM/yyyy");
            }
            else
            {
                txtDataDecorrenza.Text = SeoHelper.CheckDataString(DateTime.Now);
                if (data.Dataassunzione > DateTime.MinValue)
                {
                    lblDataSuggerita.Text = data.Dataassunzione.AddMonths(6).ToString("dd/MM/yyyy");
                }
            }


        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateApprova();
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateInviaMail();
        }


        public void UpdateApprova()
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            string preass;
            if (preassegnazione.Checked)
            {
                preass = "SI";
            }
            else
            {
                preass = "NO";
            }

            if (rbCarPolicy.SelectedValue.ToUpper() != "NOCAR")
            {
                if (servizioContratti.UpdateApprovaCarPolicy(new Guid(hduid.Value), SeoHelper.EncodeString(rbCarPolicy.SelectedValue), preass, SeoHelper.DataString(txtDataDecorrenza.Text), SeoHelper.ReturnSessionTenant()) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Approva Autorizzazione Car Policy " + SeoHelper.EncodeString(hduid.Value));

                    Response.Redirect("EditAutorizzazione-" + SeoHelper.EncodeString(hduid.Value) + "?opt=ok");
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Operazione fallita";
                }
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text += "Car Policy non approvata perch&egrave; NOCAR";
            }
        }
        public void UpdateInviaMail()
        {
            if (rbCarPolicy.SelectedValue.ToUpper() != "NOCAR")
            {
                IContrattiBL servizioContratti = new ContrattiBL();
                IUtilitysBL servizioUtility = new UtilitysBL();
                Guid UserId = SeoHelper.GuidString(hdidutente.Value);
                DateTime datadecorrenza = SeoHelper.DataString(txtDataDecorrenza.Text);
                servizioContratti.UpdateInvioMailCarPolicy(new Guid(hduid.Value), SeoHelper.ReturnSessionTenant());
                bool result = false;
                IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(2);
                if (dataTemplate != null)
                {
                    //  DA RIATTIVARE
                    if (datadecorrenza <= DateTime.Now)  //se datadecorrenza e minore o uguale alla data di oggi spedisce mail
                    {
                        Recuperadatiuser datiUtente = new Recuperadatiuser();
                        result = MailHelper.SendMail("", ReturnEmail(UserId), "", "", "", "", dataTemplate.Oggetto, servizioUtility.InsCom(UserId, dataTemplate.Corpo), "", datiUtente.ReturnObjectTenant());
                    }
                    //result = true;
                }
                if (result) //se invio mail è andato a buon fine
                {
                    //inserimento comunicazione
                    IUtilitys comunicEmailNew = new Utilitys
                    {
                        Mittente = SeoHelper.EmailMittente(),
                        UserId = UserId,
                        Oggetto = dataTemplate.Oggetto,
                        Testotask = servizioUtility.InsCom(UserId, dataTemplate.Corpo),
                        Tipocomunicazione = "EMAIL",
                        Idstatuscomunicazione = 0,
                        Datainvio = datadecorrenza,
                        Linktask = "UploadCarPolicy"
                    };
                    servizioUtility.InsertComunicazioneEmail(comunicEmailNew);


                    //inserimento task 
                    servizioUtility.InsTask(UserId, "Firmare e caricare la Car Policy", "", datadecorrenza);

                    //log
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Invio Mail Autorizzazione Car Policy " + SeoHelper.EncodeString(hduid.Value));


                    Response.Redirect("Autorizzazioni");
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Errore invio mail";
                }
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text += "Car Policy non approvata perch&egrave; NOCAR";
            }
        }
        public string ReturnCodSocieta()
        {
            IAccountBL servizioAccount = new AccountBL();
            string retVal = string.Empty;

            IAccount dataId = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
            if (dataId != null)
            {
                retVal = dataId.Codsocieta;
            }

            return retVal;
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
