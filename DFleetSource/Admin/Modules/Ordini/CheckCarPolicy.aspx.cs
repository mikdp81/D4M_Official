// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CheckCarPolicy.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Ordini
{
    public partial class CheckCarPolicy : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(49)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailUserCarPolicyId(uid);
                    if (data != null)
                    {
                        hddocumentocarpolicy.Value = data.Documentocarpolicy;
                        hddocumentopatente.Value = data.Documentopatente;
                        hddocumentofuelcard.Value = data.Documentofuelcard;
                        hduid.Value = uid.ToString();
                        hduiduser.Value = data.UserId.ToString();
                        lblDati.Text = "Denominazione:<br><h3> " + data.Denominazione + "</h3> Societ&agrave;: <h4>" + data.Codsocieta + "</h4> Matricola: <h4>" + data.Matricola +
                                       "</h4>Cellulare: <h4>" + data.Cellulare + "</h4>Email: <h4>" + data.Email + "</h4> Data assunzione: <h4>" + SeoHelper.CheckDataString(data.Dataassunzione) + "</h4>";

                        if (data.Checkcarpolicy.ToUpper() == "SI")
                        {
                            btnApprova.Visible = false;
                            btnNonApprova.Visible = false;

                            lblApprovato.Text = "<strong>APPROVATO</strong> da " + data.Cognome + " il " + data.Dataapprovazione.ToString("dd/MM/yyyy");
                        }

                        if (data.Checkcarpolicy.ToUpper() == "NO")
                        {
                            lblApprovato.Text = "<strong>NON APPROVATO</strong>";
                        }

                    }
                }
            }
        }
        public string ReturnLinkPdf()
        {   
            return "../../../DownloadFile?type=ordini&nomefile=" + SeoHelper.EncodeString(hddocumentocarpolicy.Value);
        }
        public string ReturnLinkPdfPatente()
        {
            return "../../../DownloadFile?type=ordini&nomefile=" + SeoHelper.EncodeString(hddocumentopatente.Value);
        }
        public string ReturnLinkPdfFuelCard()
        {
            return "../../../DownloadFile?type=ordini&nomefile=" + SeoHelper.EncodeString(hddocumentofuelcard.Value);
        }
        protected void btnApprova_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = new Guid(hduid.Value);

            if (servizioContratti.UpdateCheckDocPolicy(Uid, SeoHelper.ReturnSessionTenant()) == 1)
            {
                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Check Approvato Documento CarPolicy " + Uid);

                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-success";
                lblMessage.Text = "Documento CarPolicy Approvato<br /> <a href='" + ResolveUrl("~/Admin/Modules/Ordini/ViewDocCarPolicy") + "'>Ritorna alla Lista</a>";
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text += "Operazione fallita";
            }
        }
        protected void btnNonApprova_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IUtilitysBL servizioUtility = new UtilitysBL();
            //IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
            Guid Uid = new Guid(hduid.Value);
            //Guid UserId = new Guid(hduiduser.Value);

            if (servizioContratti.UpdateNotCheckDocPolicy(Uid, SeoHelper.ReturnSessionTenant()) == 1)
            {
                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Check Non Approvato Documento CarPolicy " + Uid);


                //invio mail
                IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(1);
                if (dataTemplate != null)
                {
                    //MailHelper.SendMail("", ReturnEmail(UserId), "", "", "", "", dataTemplate.Oggetto, dataTemplate.Corpo, "");
                }


                //inserimento comunicazione
                /*IComunicazioni MailNew = new Comunicazioni
                {
                    UserIdMittente = (Guid)Membership.GetUser().ProviderUserKey,
                    UseridDestinatario = UserId,
                    Idoggetto = 4,
                    Testocomunicazione = "Il suo documento di car policy non è stato approvato. Si prega di caricare il file corretto.",
                    Priorita = 0
                };

                if (servizioComunicazioni.InsertComunicazione(MailNew) == 1)
                {
                    //recupero uidcomunicazione appena inserito
                    IComunicazioni data = servizioComunicazioni.ReturnUidCom();
                    if (data != null)
                    {
                        //aggiorna uidcomunicazione padre
                        IComunicazioni UpdMail = new Comunicazioni
                        {
                            UidcomunicazionePadre = data.UIDcomunicazione,
                            UIDcomunicazione = data.UIDcomunicazione,
                            Uidtenant = SeoHelper.ReturnSessionTenant()
                        };
                        servizioComunicazioni.UpdateUidComunicazionePadre(UpdMail);
                    }
                }*/

                Response.Redirect("ViewDocCarPolicy");
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
