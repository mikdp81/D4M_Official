// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Autorizzazioni.aspx.cs" company="">
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
using System.Web.UI.HtmlControls;

namespace DFleet.Admin.Modules.Ordini
{
    public partial class Autorizzazioni : System.Web.UI.Page
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
            hdcodsocietaapprovatore.Value = ReturnCodSocieta();
            loadPage();
            loadPage2();
        }
        protected void btnCerca_Click(object sender, EventArgs e)
        {
            loadPage();
        }
        protected void btnCerca2_Click(object sender, EventArgs e)
        {
            loadPage2();
        }
        public void loadPage()
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;
            string carpolicy = SeoHelper.EncodeString(ddlCodCarPolicy.SelectedValue);
            Guid UserId = SeoHelper.GuidString(ddlUsers.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountUserCarPolicyDaApprovare(carpolicy, UserId, SeoHelper.EncodeString(hdcodsocietaapprovatore.Value), Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;
            int pagina;

            if (string.IsNullOrEmpty(hdPagina.Value))
            {
                pagina = 1;
                hdPagina.Value = "1";
            }
            else
            {
                pagina = Convert.ToInt32(hdPagina.Value, CultureInfo.CurrentCulture);
            }


            if (gvRicDaAppr.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicDaAppr.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            if (totaleRighe == 0)
            {
                lblMessage.Text = "Non ci sono driver da approvare";
                pnlMessage.Visible = true;
            }
            else
            {
                pnlMessage.Visible = false;
            }


            lblNumRecord.Text = "Da Approvare: " + HttpUtility.HtmlEncode(totaleRighe);
            if (totaleRighe == 0)
            {
                lblMessage.Text = "Non ci sono driver da approvare";
                pnlMessage.Visible = true;
            }
            else
            {
                pnlMessage.Visible = false;
            }

            if ((pagina - 1) <= 1)
            {
                pagingprec.Enabled = false;
                pagingprec.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingprec.Enabled = true;
                pagingprec.CssClass = "paginate_button";
            }

            if (maxPage < (pagina + 1))
            {
                pagingnext.Enabled = false;
                pagingnext.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingnext.Enabled = true;
                pagingnext.CssClass = "paginate_button";
            }
        }
        public void loadPage2()
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage2.Visible = false;
            string search = SeoHelper.EncodeString(ddlCarPolicy2.SelectedValue);
            string flgmail = SeoHelper.EncodeString(ddlFlgMail.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord2.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountUserCarPolicyApprovati(search, SeoHelper.EncodeString(hdcodsocietaapprovatore.Value), SeoHelper.IntString(flgmail), Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;
            int pagina;

            if (string.IsNullOrEmpty(hdPagina2.Value))
            {
                pagina = 1;
                hdPagina2.Value = "1";
            }
            else
            {
                pagina = Convert.ToInt32(hdPagina2.Value, CultureInfo.CurrentCulture);
            }


            if (gvRicAppr.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicAppr.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            if (totaleRighe == 0)
            {
                lblMessage2.Text = "Nessun dato disponibile. Ricerca con altri parametri.";
                pnlMessage2.Visible = true;
            }
            else
            {
                pnlMessage2.Visible = false;
            }


            lblNumRecord2.Text = "Approvati: " + HttpUtility.HtmlEncode(totaleRighe);
            if (totaleRighe == 0)
            {
                lblMessage2.Text = "Nessun dato disponibile. Ricerca con altri parametri.";
                pnlMessage2.Visible = true;
            }
            else
            {
                pnlMessage2.Visible = false;
            }

            if ((pagina - 1) <= 1)
            {
                pagingprec2.Enabled = false;
                pagingprec2.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingprec2.Enabled = true;
                pagingprec2.CssClass = "paginate_button";
            }

            if (maxPage < (pagina + 1))
            {
                pagingnext2.Enabled = false;
                pagingnext2.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingnext2.Enabled = true;
                pagingnext2.CssClass = "paginate_button";
            }
        }

        protected void btnSvuotaFiltri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Autorizzazioni");
        }
        protected void btnSvuotaFiltri2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Autorizzazioni#home2");
        }


        /********************** PAGINAZIONE **********************/
        protected void pagingprec_Click(object sender, EventArgs e)
        {
            int valore = Convert.ToInt32(hdPagina.Value, CultureInfo.CurrentCulture);
            Paginations("prec", valore);
        }

        protected void pagingnext_Click(object sender, EventArgs e)
        {
            int valore = Convert.ToInt32(hdPagina.Value, CultureInfo.CurrentCulture);
            Paginations("next", valore);
        }

        protected void txtnumpag_TextChanged(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string carpolicy = SeoHelper.EncodeString(ddlCodCarPolicy.SelectedValue);
            Guid UserId = SeoHelper.GuidString(ddlUsers.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountUserCarPolicyDaApprovare(carpolicy, UserId, SeoHelper.EncodeString(hdcodsocietaapprovatore.Value), Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;

            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string carpolicy = SeoHelper.EncodeString(ddlCodCarPolicy.SelectedValue);
            Guid UserId = SeoHelper.GuidString(ddlUsers.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountUserCarPolicyDaApprovare(carpolicy, UserId, SeoHelper.EncodeString(hdcodsocietaapprovatore.Value), Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int pagina = 0;
            int tmppaginaprec = 0;
            int tmppaginanext = 0;

            switch (tipo.ToUpper())
            {
                case "PREC":
                    pagina = valore - 1;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;
                case "NEXT":
                    pagina = valore + 1;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;
                case "ELENCO":
                    pagina = valore;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;

            }


            if ((tmppaginaprec) < 1)
            {
                pagingprec.Enabled = false;
                pagingprec.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingprec.Enabled = true;
                pagingprec.CssClass = "paginate_button";
            }

            if (maxPage < (tmppaginanext))
            {
                pagingnext.Enabled = false;
                pagingnext.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingnext.Enabled = true;
                pagingnext.CssClass = "paginate_button";
            }

            hdPagina.Value = Convert.ToString(pagina, CultureInfo.CurrentCulture);
            txtnumpag.Text = Convert.ToString(pagina, CultureInfo.CurrentCulture);
        }




        protected void pagingprec2_Click(object sender, EventArgs e)
        {
            int valore = Convert.ToInt32(hdPagina2.Value, CultureInfo.CurrentCulture);
            Paginations2("prec", valore);
        }

        protected void pagingnext2_Click(object sender, EventArgs e)
        {
            int valore = Convert.ToInt32(hdPagina2.Value, CultureInfo.CurrentCulture);
            Paginations2("next", valore);
        }

        protected void txtnumpag2_TextChanged(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string search = SeoHelper.EncodeString(ddlCarPolicy2.SelectedValue);
            string flgmail = SeoHelper.EncodeString(ddlFlgMail.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord2.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountUserCarPolicyApprovati(search, SeoHelper.EncodeString(hdcodsocietaapprovatore.Value), SeoHelper.IntString(flgmail), Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag2.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;

            Paginations2("elenco", valore);
        }

        public void Paginations2(string tipo, int valore)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string search = SeoHelper.EncodeString(ddlCarPolicy2.SelectedValue);
            string flgmail = SeoHelper.EncodeString(ddlFlgMail.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord2.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountUserCarPolicyApprovati(search, SeoHelper.EncodeString(hdcodsocietaapprovatore.Value), SeoHelper.IntString(flgmail), Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int pagina = 0;
            int tmppaginaprec = 0;
            int tmppaginanext = 0;

            switch (tipo.ToUpper())
            {
                case "PREC":
                    pagina = valore - 1;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;
                case "NEXT":
                    pagina = valore + 1;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;
                case "ELENCO":
                    pagina = valore;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;

            }


            if ((tmppaginaprec) < 1)
            {
                pagingprec2.Enabled = false;
                pagingprec2.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingprec2.Enabled = true;
                pagingprec2.CssClass = "paginate_button";
            }

            if (maxPage < (tmppaginanext))
            {
                pagingnext2.Enabled = false;
                pagingnext2.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingnext2.Enabled = true;
                pagingnext2.CssClass = "paginate_button";
            }

            hdPagina2.Value = Convert.ToString(pagina, CultureInfo.CurrentCulture);
            txtnumpag2.Text = Convert.ToString(pagina, CultureInfo.CurrentCulture);
        }
        /********************** FINE PAGINAZIONE **********************/


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
        public string ReturnData(string data)
        {
            string retVal;

            if (string.IsNullOrEmpty(data) || data == "01/01/0001 00:00:00")
            {
                retVal = "";
            }
            else
            {
                retVal = data.Substring(0, 10);
            }

            return retVal;
        }

        protected void btnConcludi_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IUtilitysBL servizioUtility = new UtilitysBL();

            foreach (GridViewRow row in gvRicDaAppr.Rows)
            {
                HiddenField hduidaut = (HiddenField)row.FindControl("hduidaut");
                HtmlInputCheckBox cb = (HtmlInputCheckBox)row.FindControl("chkiddelega");

                bool check = cb.Checked;
                Guid uid = SeoHelper.GuidString(hduidaut.Value);

                if (check)
                {
                    IContratti data = servizioContratti.DetailUserCarPolicyId(uid);
                    if (data != null)
                    {
                        //se nocar non fa nuessuna operazione
                        if (data.Codcarpolicy.ToUpper() != "NOCAR")
                        {

                            //approva car policy
                            if (servizioContratti.UpdateApprovaCarPolicy(uid, data.Codcarpolicy, "NO", DateTime.Now, SeoHelper.ReturnSessionTenant()) == 1)
                            {
                                //log
                                ILogBL log = new LogBL();
                                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Approva Autorizzazione Car Policy " + uid);

                                //contrassegna data di invio mail
                                servizioContratti.UpdateInvioMailCarPolicy(uid, SeoHelper.ReturnSessionTenant());

                                bool result = false;
                                IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(2);
                                if (dataTemplate != null)
                                {
                                    //result = MailHelper.SendMail("", ReturnEmail(UserId), "", "", "", "", dataTemplate.Oggetto, dataTemplate.Corpo, ""); DA RIATTIVARE
                                    result = true;
                                }
                                if (result) //se invio mail è andato a buon fine
                                {
                                    //inserimento comunicazione
                                    IUtilitys comunicEmailNew = new Utilitys
                                    {
                                        Mittente = SeoHelper.EmailMittente(),
                                        UserId = data.UserId,
                                        Oggetto = dataTemplate.Oggetto,
                                        Testotask = servizioUtility.InsCom(data.UserId, dataTemplate.Corpo),
                                        Tipocomunicazione = "EMAIL",
                                        Idstatuscomunicazione = 0,
                                        Datainvio = DateTime.Now,
                                        Linktask = "UploadCarPolicy"
                                    };
                                    servizioUtility.InsertComunicazioneEmail(comunicEmailNew);


                                    //inserimento task 
                                    servizioUtility.InsTask(data.UserId, "Firmare e caricare la Car Policy", "", DateTime.Now);

                                    //log
                                    ILogBL log2 = new LogBL();
                                    log2.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Invio Mail Autorizzazione Car Policy " + uid);

                                }
                            }
                        }
                    }
                }
            }

            Response.Redirect("Autorizzazioni");
        }
    }
}
