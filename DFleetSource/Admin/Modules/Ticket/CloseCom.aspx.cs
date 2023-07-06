// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CloseCom.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Ticket
{
    public partial class CloseCom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
            {
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();
                IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
                IUtilitysBL servizioUtility = new UtilitysBL();
                IContrattiBL servizioContratti = new ContrattiBL();

                //cancella comunicazione
                if (servizioComunicazioni.UpdateChiusuraComunicazione(uid, Uidtenant) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Chiusura " + uid);


                    //controllo se partner ha uno o piu delegati e se sono abilitati a ricevere mail in copia

                    string emailmittente = "";
                    Guid UserIdMittente = Guid.Empty;

                    IComunicazioni dataMitt = servizioComunicazioni.SelectEmailMittente(uid);
                    if (dataMitt != null)
                    {
                        emailmittente = dataMitt.Emailmittente;
                        UserIdMittente = dataMitt.UserIdMittente;
                    }


                    string emaildelegato1 = "";
                    string emaildelegato2 = "";
                    string emaildelegato3 = "";

                    List<IContratti> dataOpt = servizioContratti.SelectDeleghePartner(UserIdMittente);
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
                        MailHelper.SendMail("", emailmittente, emaildelegato1, emaildelegato2, emaildelegato3, "", "Help Desk - Chiusura Ticket", servizioUtility.InsComEmail((Guid)Membership.GetUser().ProviderUserKey, uid, "", dataTemplate.Corpo), "", datiUtente.ReturnObjectTenant());
                    }

                    //messaggio avvenuta cancellazione
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-success";
                    lblMessage.Text = "Chiusura avvenuta correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Ticket/ViewComunicazioni") + "'>Ritorna alla Lista</a>";
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
