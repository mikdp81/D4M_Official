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

namespace DFleet.Admin.Modules.Users
{
    public partial class RinnovaConf : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(1)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccountBL servizioAccount = new AccountBL();
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
                    if (Request.QueryString["opt"].ToString().ToUpper() == "OKMAIL")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Invio Mail avvenuto correttamente";
                    }
                }

                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IAccount data = servizioAccount.DetailId(uid);
                    if (data != null)
                    {
                        BindData(data);
                    }
                }
            }
        }
        private void BindData(IAccount data)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            txtDataDecorrenza.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDataFineDecorrenza.Text = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy");

            //dati driver
            lblDati.Text = "Denominazione:<br><h3> " + data.Cognome + " " + data.Nome + "</h3> Societ&agrave;: <h4>" + ReturnSocieta(data.Codsocieta) + "</h4> Grade: <h4>" + ReturnGrade(data.Gradecode) + "</h4> Matricola: <h4>" + data.Matricola +
                           "</h4>Cellulare: <h4>" + data.Cellulare + "</h4>Email: <h4>" + data.Email + "</h4> Data assunzione: <h4>" + SeoHelper.CheckDataString(data.Dataassunzione) + "</h4>";
            hdidutente.Value = SeoHelper.CheckGuidString(data.UserId);
            hdiduser.Value = data.Iduser.ToString();
            hdcodsocieta.Value = data.Codsocieta;

            //controllo esistenza vecchia carpolicy
            IContratti data2 = servizioContratti.ExistOldUserCarPolicy(data.Iduser);
            if (data2 != null)
            {
                hduid.Value = data2.Uid.ToString();
                hdidappr.Value = data2.Idapprovatore.ToString();
                hddataappr.Value = data2.Dataapprovazione.ToString();

                if (data2.Approvato == 0) // se non approvato disabilita tasto invia mail
                {
                    btnModifica2.Visible = false;
                }
                else
                {
                    if (data2.Datadecorrenza > DateTime.Now)
                    {
                        btnModifica2.Visible = false;
                    }
                }

                rbCarPolicy.SelectedValue = data2.Codcarpolicy;
                rbCarBenefit.SelectedValue = data2.Codcarbenefit;
                rbCarPolicy.Enabled = false;
                rbCarBenefit.Enabled = false;

            }
            else
            {
                IContratti dataCodPol = servizioContratti.ReturnCodCarPolicy(data.Codsocieta, data.Gradecode);
                if (dataCodPol != null)
                {
                    rbCarPolicy.SelectedValue = dataCodPol.Codcarpolicy;
                    rbCarBenefit.SelectedValue = dataCodPol.Codcarbenefit;
                }
                else
                {
                    rbCarPolicy.SelectedValue = "Nocar";
                    rbCarBenefit.SelectedValue = "Nobenefit";
                }

                btnModifica2.Visible = false;
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
            string error = string.Empty;
            
            if (rbCarPolicy.SelectedItem == null)
            {
                error += "Scegliere una carpolicy<br />";
            }

            if (rbCarBenefit.SelectedItem == null)
            {
                error += "Scegliere una carbenefit<br />";
            }

            if (SeoHelper.DataString(txtDataDecorrenza.Text) == DateTime.MinValue)
            {
                txtDataDecorrenza.CssClass = "form-control is-invalid";
                error += "Inserire una data di decorrenza<br />";
            }
            else
            {
                txtDataDecorrenza.CssClass = "form-control";
            }

            if (SeoHelper.DataString(txtDataFineDecorrenza.Text) == DateTime.MinValue)
            {
                txtDataFineDecorrenza.CssClass = "form-control is-invalid";
                error += "Inserire una data di fine decorrenza<br />";
            }
            else
            {
                txtDataFineDecorrenza.CssClass = "form-control";
            }

            if (!string.IsNullOrEmpty(error))
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione. Il modulo non è stato compilato correttamente. Si sono verificati i seguenti errori:";
                lblMessage.Text += "<br /><br /><b>" + error + "</b><br />";
            }
            else
            {
                DateTime dataapprovazione = DateTime.Now;
                int idapprovatore = 1;

                /*if (SeoHelper.DataString(hddataappr.Value) > DateTime.MinValue)
                {
                    dataapprovazione = SeoHelper.DataString(hddataappr.Value);
                }*/
                if (SeoHelper.IntString(hdidappr.Value) > 0)
                {
                    idapprovatore = SeoHelper.IntString(hdidappr.Value);
                }

                if (rbCarPolicy.SelectedValue.ToUpper() == "NOCAR" && rbCarBenefit.SelectedValue.ToUpper() == "NOBENEFIT")                
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Car Policy non approvata perch&egrave; NOCAR e NOBENEFIT";
                }
                else
                { 
                    //inserimento user carpolicy

                    IContratti contrattiuserCarPolicyNew = new Contratti
                    {
                        Idutente = SeoHelper.IntString(hdiduser.Value),
                        Codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value),
                        Codcarpolicy = SeoHelper.EncodeString(rbCarPolicy.SelectedValue),
                        Codcarbenefit = SeoHelper.EncodeString(rbCarBenefit.SelectedValue),
                        Datadecorrenza = SeoHelper.DataString(txtDataDecorrenza.Text),
                        Datafinedecorrenza = SeoHelper.DataString(txtDataFineDecorrenza.Text),
                        Dataapprovazione = dataapprovazione,
                        Idapprovatore = idapprovatore,
                        Flgmail = "",
                        Approvato = 1,
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };

                    if (servizioContratti.InsertUserCarPolicy(contrattiuserCarPolicyNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Approva Autorizzazione Car Policy " + SeoHelper.EncodeString(hdidutente.Value));

                        Response.Redirect("RinnovaConf-" + SeoHelper.EncodeString(hdidutente.Value) + "?opt=ok");
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
        public void UpdateInviaMail()
        {
            if (rbCarPolicy.SelectedValue.ToUpper() == "NOCAR" && rbCarBenefit.SelectedValue.ToUpper() == "NOBENEFIT")
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text += "Car Policy non approvata perch&egrave; NOCAR e NOBENEFIT";
            }
            else
            {
                IContrattiBL servizioContratti = new ContrattiBL();
                IUtilitysBL servizioUtility = new UtilitysBL();
                Guid UserId = SeoHelper.GuidString(hdidutente.Value);
                DateTime datadecorrenza = SeoHelper.DataString(txtDataDecorrenza.Text);
                servizioContratti.UpdateInvioMailCarPolicy(new Guid(hduid.Value), SeoHelper.ReturnSessionTenant());

                //template di default per invio a chi configura un'auto senza benefit
                int idtemplate = 2;
                string allegato = "";

                //template per i partner con allegato
                if (rbCarPolicy.SelectedValue.ToUpper() == "PARTNER")
                {
                    idtemplate = 17;
                    allegato = "guida_d4m_premium.pdf";
                }

                //template per chi ha la sola mobilità 
                if (rbCarPolicy.SelectedValue.ToUpper() == "NOCAR" && rbCarBenefit.SelectedValue.ToUpper() == "MOBILITA")
                {
                    idtemplate = 25;
                }

                //template per chi puo scegliere tra auto e mobilità 
                if (rbCarPolicy.SelectedValue.ToUpper() != "NOCAR" && rbCarBenefit.SelectedValue.ToUpper() == "MOBILITA")
                {
                    idtemplate = 18;
                }




                bool result = false;
                IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(idtemplate);
                if (dataTemplate != null)
                {
                    if (datadecorrenza <= DateTime.Now)  //se datadecorrenza e minore o uguale alla data di oggi spedisce mail
                    {
                        Recuperadatiuser datiUtente = new Recuperadatiuser();
                        result = MailHelper.SendMail("", ReturnEmail(UserId), "", "", "", "", dataTemplate.Oggetto, servizioUtility.InsCom(UserId, dataTemplate.Corpo), allegato, datiUtente.ReturnObjectTenant());
                    }
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


                    Response.Redirect("RinnovaConf-" + SeoHelper.EncodeString(hdidutente.Value) + "?opt=okmail");
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Errore invio mail";
                }
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
        public string ReturnSocieta(string codsocieta)
        {
            string retVal = string.Empty;

            IUtilitysBL servizioUtility = new UtilitysBL();
            IUtilitys data = servizioUtility.DetailSocietaXCodS(codsocieta);
            if (data != null)
            {
                retVal = data.Societa;
            }

            return retVal;
        }
        public string ReturnGrade(string codgrade)
        {
            string retVal = string.Empty;

            IUtilitysBL servizioUtility = new UtilitysBL();
            IUtilitys data = servizioUtility.ReturnGradeXCod(codgrade);
            if (data != null)
            {
                retVal = data.Grade;
            }

            return retVal;
        }
    }
}
