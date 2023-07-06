// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsConfMassiva.aspx.cs" company="">
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
    public partial class InsConfMassiva : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(86)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlStep1.Visible = true;
            pnlStep2.Visible = false;
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
                        lblMessage.Text = "Invio avvenuto correttamente";
                    }
                }
            }
        }

        protected void btnProsegui_Click(object sender, EventArgs e)
        {
            string error = "";

            if (string.IsNullOrEmpty(ddlCodSocieta.SelectedValue))
            {
                ddlCodSocieta.CssClass = "form-control is-invalid select2";
                error += "Selezionare una societ&agrave;<br />";
            }
            else
            {
                ddlCodSocieta.CssClass = "form-control select2";
            }

            if (!string.IsNullOrEmpty(error))
            {
                pnlStep1.Visible = true;
                pnlStep2.Visible = false;
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione. Il modulo non è stato compilato correttamente. Si sono verificati i seguenti errori:";
                lblMessage.Text += "<br /><br /><b>" + error + "</b><br />";
            }
            else
            {
                pnlMessage.Visible = false;
                hdcodsocieta.Value = ddlCodSocieta.SelectedValue;
                pnlStep1.Visible = false;
                pnlStep2.Visible = true;
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            IUtilitysBL servizioUtility = new UtilitysBL();
            string error = string.Empty;

            if (string.IsNullOrEmpty(txtMatricole.Text))
            {
                txtMatricole.CssClass = "form-control is-invalid";
                error += "Inserire almeno una matricola<br />";
            }

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
                pnlStep1.Visible = false;
                pnlStep2.Visible = true;
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione. Il modulo non è stato compilato correttamente. Si sono verificati i seguenti errori:";
                lblMessage.Text += "<br /><br /><b>" + error + "</b><br />";
            }
            else
            {
                DateTime dataapprovazione = DateTime.Now;
                int idapprovatore = 1;
                Guid UserIdApprovatore = (Guid)Membership.GetUser().ProviderUserKey;

                IAccount data = servizioAccount.DetailId(UserIdApprovatore);
                if (data != null)
                {
                    idapprovatore = data.Iduser;
                }


                if (rbCarPolicy.SelectedValue.ToUpper() != "NOCAR")
                {
                    //splitta textbox matricole e inserisce user carpolicy
                    string[] righeTesto = txtMatricole.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                    foreach (string matricola in righeTesto)
                    {
                        if (!string.IsNullOrEmpty(matricola))
                        {
                            IAccount dataM = servizioAccount.ExistAnagraficaMatricola(matricola);
                            if (dataM != null)
                            {
                                IContratti contrattiuserCarPolicyNew = new Contratti
                                {
                                    Idutente = dataM.Iduser,
                                    Codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value),
                                    Codcarpolicy = SeoHelper.EncodeString(rbCarPolicy.SelectedValue),
                                    Codcarbenefit = SeoHelper.EncodeString(rbCarBenefit.SelectedValue),
                                    Datadecorrenza = SeoHelper.DataString(txtDataDecorrenza.Text),
                                    Datafinedecorrenza = SeoHelper.DataString(txtDataFineDecorrenza.Text),
                                    Dataapprovazione = dataapprovazione,
                                    Datamail = dataapprovazione,
                                    Idapprovatore = idapprovatore,
                                    Flgmail = "1",
                                    Approvato = 1,
                                    Uidtenant = SeoHelper.ReturnSessionTenant()
                                };

                                //inserimento user carpolicy
                                if (servizioContratti.InsertUserCarPolicy(contrattiuserCarPolicyNew) == 1)
                                {
                                    //log
                                    ILogBL log = new LogBL();
                                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Approva Autorizzazione Car Policy " + contrattiuserCarPolicyNew.Idutente);


                                    //invio mail
                                    DateTime datadecorrenza = SeoHelper.DataString(txtDataDecorrenza.Text);

                                    int idtemplate = 2;
                                    string allegato = "";

                                    if (contrattiuserCarPolicyNew.Codcarpolicy.ToUpper() == "PARTNER")
                                    {
                                        idtemplate = 17;
                                        allegato = "guida_d4m_premium.pdf";
                                    }


                                    IContratti dataCP = servizioContratti.ExistCarPolicyMobilita(contrattiuserCarPolicyNew.Codcarpolicy);
                                    if (dataCP != null)
                                    {
                                        if (dataCP.Codcarbenefit.ToUpper() == "MOBILITA")
                                        {
                                            idtemplate = 18;
                                        }
                                    }



                                    bool result = false;
                                    IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(idtemplate);
                                    if (dataTemplate != null)
                                    {
                                        if (contrattiuserCarPolicyNew.Datadecorrenza <= DateTime.Now)  //se datadecorrenza e minore o uguale alla data di oggi spedisce mail
                                        {
                                            Recuperadatiuser datiUtente = new Recuperadatiuser();
                                            result = MailHelper.SendMail("", ReturnEmail(dataM.UserId), "", "", "", "", dataTemplate.Oggetto, servizioUtility.InsCom(dataM.UserId, dataTemplate.Corpo), allegato, datiUtente.ReturnObjectTenant());
                                        }
                                    }
                                    if (result) //se invio mail è andato a buon fine
                                    {
                                        //inserimento comunicazione
                                        IUtilitys comunicEmailNew = new Utilitys
                                        {
                                            Mittente = SeoHelper.EmailMittente(),
                                            UserId = dataM.UserId,
                                            Oggetto = dataTemplate.Oggetto,
                                            Testotask = servizioUtility.InsCom(dataM.UserId, dataTemplate.Corpo),
                                            Tipocomunicazione = "EMAIL",
                                            Idstatuscomunicazione = 0,
                                            Datainvio = datadecorrenza,
                                            Linktask = "UploadCarPolicy"    
                                        };
                                        servizioUtility.InsertComunicazioneEmail(comunicEmailNew);


                                        //inserimento task 
                                        servizioUtility.InsTask(dataM.UserId, "Firmare e caricare la Car Policy", "", datadecorrenza);

                                        //log
                                        ILogBL log2 = new LogBL();
                                        log2.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Invio Mail Autorizzazione Car Policy " + contrattiuserCarPolicyNew.Idutente);

                                    }
                                    else
                                    {
                                        pnlMessage.Visible = true;
                                        pnlMessage.CssClass = "alert alert-danger";
                                        lblMessage.Text += "Errore invio mail " + contrattiuserCarPolicyNew.Idutente + "<br />";
                                    }

                                }
                                else
                                {
                                    pnlMessage.Visible = true;
                                    pnlMessage.CssClass = "alert alert-danger";
                                    lblMessage.Text += "Operazione fallita " + contrattiuserCarPolicyNew.Idutente + "<br />";
                                }
                            }
                        }
                    }

                    Response.Redirect("InsConfMassiva?opt=ok");
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Car Policy non approvata perch&egrave; NOCAR";
                }
            }
        }

        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            pnlStep1.Visible = true;
            pnlStep2.Visible = false;
            pnlMessage.Visible = false;
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
