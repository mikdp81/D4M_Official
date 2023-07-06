// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ReinviaMail.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Multa
{
    public partial class ReinviaMail : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(20) && !datiUtente.ReturnExistPage(22)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
            {
                IUtilitysBL servizioUtility = new UtilitysBL();
                IMulteBL servizioMulte = new MulteBL();
                IContrattiBL servizioContratti = new ContrattiBL();

                //recupero utente multa
                IMulte data = servizioMulte.DetailMulteId(uid);
                if (data != null)
                {

                    //reinvia mail
                    if (data.Idstatuslavorazione > 0)
                    {
                        bool result = true;
                        int idtemplate = 0;
                        string oggetto = "";

                        switch (data.Codtipomulta)
                        {
                            case "10": //multa senza decurtazione punti patente che prevede i pagamento ridotto
                                idtemplate = 1;
                                oggetto = "Notifica contravvenzione SENZA DECURTAZIONE PUNTI – D4M - notifica contravvenzione prot. " + data.Protocollo + " verbale n. " + data.Numeroverbale + " del " + data.Datanotifica.ToString("dd/MM/yyyy") + " targa " + data.Targa;
                                break;

                            case "20": //multa senza decurtazione punti patente che prevede il solo pagamento al 100%
                                idtemplate = 7;
                                oggetto = "Notifica contravvenzione SENZA DECURTAZIONE PUNTI – D4M - notifica contravvenzione prot. " + data.Protocollo + " verbale n. " + data.Numeroverbale + " del " + data.Datanotifica.ToString("dd/MM/yyyy") + " targa " + data.Targa;
                                break;

                            case "30": //multa con decurtazione punti patente che prevede i pagamento ridotto
                                idtemplate = 8;
                                oggetto = "Notifica contravvenzione CON DECURTAZIONE PUNTI - D4M – prot. " + data.Protocollo + " verbale n. " + data.Numeroverbale + " del " + data.Datanotifica.ToString("dd/MM/yyyy") + " targa " + data.Targa;
                                break;

                            case "40": //multa con decurtazione punti patente che prevede il solo pagamento al 100%
                                idtemplate = 9;
                                oggetto = "Notifica contravvenzione CON DECURTAZIONE PUNTI - D4M – prot. " + data.Protocollo + " verbale n. " + data.Numeroverbale + " del " + data.Datanotifica.ToString("dd/MM/yyyy") + " targa " + data.Targa;
                                break;

                            case "55": //multa per mancata comunicazione dati conducente (126bis) che prevede i pagamento ridotto
                                idtemplate = 10;
                                oggetto = "Notifica contravvenzione 126 bis. Mancanta comunicazione dati patente – D4M - notifica contravvenzione prot. " + data.Protocollo + " verbale n. " + data.Numeroverbale + " del " + data.Datanotifica.ToString("dd/MM/yyyy") + " targa " + data.Targa;
                                break;

                            case "60": //multa per mancata comunicazione dati conducente (126biS) che prevede il solo pagamento al 100%
                                idtemplate = 11;
                                oggetto = "Notifica contravvenzione 126 bis. Mancanta comunicazione dati patente – D4M - notifica contravvenzione prot. " + data.Protocollo + " verbale n. " + data.Numeroverbale + " del " + data.Datanotifica.ToString("dd/MM/yyyy") + " targa " + data.Targa;
                                break;

                            case "70": //multe estere
                                idtemplate = 12;
                                oggetto = "Notifica contravvenzione MULTA ESTERA – D4M – notifica contravvenzione prot. " + data.Protocollo + " verbale n. " + data.Numeroverbale + " del " + data.Datanotifica.ToString("dd/MM/yyyy") + " targa " + data.Targa;
                                break;

                            case "80": //multa pagamento pedaggio
                                idtemplate = 13;
                                oggetto = "Notifica amministrativa MANCATO PAGAMENTO PEDAGGIO – D4M – notifica contravvenzione prot. " + data.Protocollo + " verbale n. " + data.Numeroverbale + " del " + data.Datanotifica.ToString("dd/MM/yyyy") + " targa " + data.Targa;
                                break;

                            case "90": //ingiunzioni di pagamento
                                idtemplate = 15;
                                oggetto = "Ingiunzioni di pagamento – D4M – notifica contravvenzione prot. " + data.Protocollo + " verbale n. " + data.Numeroverbale + " del " + data.Datanotifica.ToString("dd/MM/yyyy") + " targa " + data.Targa;
                                break;
                        }



                        //controllo se partner ha uno o piu delegati e se sono abilitati a ricevere mail in copia
                        string emaildelegato1 = "";
                        string emaildelegato2 = "";
                        string emaildelegato3 = "";

                        List<IContratti> dataOpt = servizioContratti.SelectDeleghePartner(data.UserId);
                        if (dataOpt != null && dataOpt.Count > 0)
                        {
                            int count = 1;

                            foreach (IContratti resultOpt in dataOpt)
                            {
                                if (count == 1)
                                {
                                    if (resultOpt.Flgemailmulte == 1)
                                    {
                                        emaildelegato1 = resultOpt.Email;
                                    }
                                }

                                if (count == 2)
                                {

                                    if (resultOpt.Flgemailmulte == 1)
                                    {
                                        emaildelegato2 = resultOpt.Email;
                                    }
                                }

                                if (count == 3)
                                {
                                    if (resultOpt.Flgemailmulte == 1)
                                    {
                                        emaildelegato3 = resultOpt.Email;
                                    }
                                }
                                count++;
                            }
                        }


                        IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(idtemplate);
                        if (dataTemplate != null)
                        {
                            Recuperadatiuser datiUtente = new Recuperadatiuser();
                            result = MailHelper.SendMail("", ReturnEmail(data.UserId), "itmulted4m@deloitte.it", emaildelegato1, emaildelegato2, emaildelegato3, oggetto, servizioUtility.InsMultaEmail(data.UserId, uid, dataTemplate.Corpo), "", datiUtente.ReturnObjectTenant());
                            //result = MailHelper.SendMail("", "mimezzina@deloitte.it", "itmulted4m@deloitte.it", "", "", "", oggetto, servizioUtility.InsMultaEmail(data.UserId, uid, dataTemplate.Corpo), "", datiUtente.ReturnObjectTenant());
                        }

                        if (result) //se invio mail è andato a buon fine
                        {
                            if (uid != Guid.Empty)
                            {
                                //aggiorna ckemaildriver
                                servizioMulte.UpdateCkEmail(uid, SeoHelper.ReturnSessionTenant());

                                //inserimento comunicazione
                                IUtilitys comunicEmailNew = new Utilitys
                                {
                                    Mittente = "noreply@deloitte.it",
                                    UserId = data.UserId,
                                    Oggetto = oggetto,
                                    Tipocomunicazione = "EMAIL",
                                    Idstatuscomunicazione = 0,
                                    Datainvio = DateTime.Now,
                                    Uidtenant = SeoHelper.ReturnSessionTenant(),
                                    Testotask = servizioUtility.InsMultaEmail(data.UserId, uid, dataTemplate.Corpo)
                                };
                                servizioUtility.InsertComunicazioneEmail(comunicEmailNew);

                                //inserimento task
                                IUtilitys taskNew = new Utilitys
                                {
                                    UserId = data.UserId,
                                    Uidteam = Guid.Empty,
                                    Testotask = "Accetta/Contesta multa",
                                    Datatask = DateTime.Now,
                                    Esitotask = 0,
                                    Linktask = "ViewMulte",
                                    Uidtenant = SeoHelper.ReturnSessionTenant()
                                };
                                servizioUtility.InsertTask(taskNew);
                            }


                            ILogBL log = new LogBL();
                            log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Reinvio Mail Notifica Multa " + uid);


                            //messaggio avvenuto reinvio
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Reinvio email notifica multa avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Multa/ViewMulte") + "'>Ritorna alla Lista</a>";
                        }
                    }   
                    else
                    {
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-danger";
                        lblMessage.Text += "Multa non inviata. Non &egrave; stata attribuita a nessun driver.";
                    }
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
