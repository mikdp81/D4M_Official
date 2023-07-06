// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DelCom.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using DFleet.Classes;
using System.Collections.Generic;

namespace DFleet.Partner.Modules.Dash
{
    public partial class DelCom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
            {
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();
                IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
                IAccountBL servizioAccount = new AccountBL();
                IUtilitysBL servizioUtility = new UtilitysBL();
                IContrattiBL servizioContratti = new ContrattiBL();

                //cancella comunicazione
                if (servizioComunicazioni.UpdateStatoComunicazione(1000, uid, Uidtenant) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Cancellazione " + uid);


                    //controllo se partner ha uno o piu delegati e se sono abilitati a ricevere mail in copia
                    string emaildelegato1 = "";
                    string emaildelegato2 = "";
                    string emaildelegato3 = "";

                    List<IContratti> dataOpt = servizioContratti.SelectDeleghePartner((Guid)Membership.GetUser().ProviderUserKey);
                    if (dataOpt != null && dataOpt.Count > 0)
                    {
                        int count = 1;

                        foreach (IContratti resultOpt in dataOpt)
                        {
                            if (count == 1)
                            {
                                if (resultOpt.Flgemailticket == 1)
                                {
                                    emaildelegato1 = resultOpt.Email;
                                }
                            }

                            if (count == 2)
                            {

                                if (resultOpt.Flgemailticket == 1)
                                {
                                    emaildelegato2 = resultOpt.Email;
                                }
                            }

                            if (count == 3)
                            {
                                if (resultOpt.Flgemailticket == 1)
                                {
                                    emaildelegato3 = resultOpt.Email;
                                }
                            }
                            count++;
                        }
                    }

                    //invio mail
                    IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(4);
                    if (dataTemplate != null)
                    {
                        Recuperadatiuser datiUtente = new Recuperadatiuser();
                        MailHelper.SendMail("", servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey).Email, emaildelegato1, emaildelegato2, emaildelegato3, "", "Chiusura Comunicazione", servizioUtility.InsComEmail((Guid)Membership.GetUser().ProviderUserKey, uid, "", dataTemplate.Corpo), "", datiUtente.ReturnObjectTenant());
                    }

                    //messaggio avvenuta cancellazione
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-success";
                    lblMessage.Text = "Cancellazione avvenuta correttamente <br /> <a href='" + ResolveUrl("~/Users/Modules/Dash/ViewComunicazioni") + "'>Ritorna alla Lista</a>";
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
                lblMessage.Text += "Operazione fallita";
            }


        }
    }
}
