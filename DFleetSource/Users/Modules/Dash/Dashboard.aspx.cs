// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Dashboard.aspx.cs" company="">
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

namespace DFleet.Users.Modules.Dash
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ILogBL log = new LogBL();
            log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "View Dashboard");

            IUtilitysBL servizioUtility = new UtilitysBL();
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            IComunicazioniBL servizioComunicazioni = new ComunicazioniBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey; 
            int idutente = 0;
            int idapprovazione = 0;
            string codcarpolicy;
            string codcarbenefit;
            pnlTodoOrdina.Visible = false;
            pnlTodoOrdinaOpzione2.Visible = false;
            pnlTodoOrdinaBenefit.Visible = false;
            pnlScadenzaDataDecorrenza.Visible = false;
            lblannocorrente.Text = DateTime.Now.Year.ToString(); 
            
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            Guid Uidtenant = datiUtente.ReturnUidTenant();

            if (Session["UidTenant"] == null)
            {
                Session["UidTenant"] = Uidtenant;
            }
            else
            {
                Uidtenant = SeoHelper.ReturnSessionTenant();
            }


            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;

                //lista avvisi
                List<IUtilitys> dataAvvisi = servizioUtility.SelectAvvisiXUser(data.Codsocieta, data.Gradecode, ReturnCodCarPolicy(data.Codsocieta, data.Gradecode), Uidtenant);
                if (dataAvvisi != null && dataAvvisi.Count > 0)
                {
                    ltavvisi.Text += "<div class='row'><div class='col-md-2' style='padding-right:0;'><div style='background-color:#89BA17;height:35px;'>" +
                                     "<div style='padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700'>Avvisi</div></div></div>" +
                                     "<div class='col-md-10' style='padding-left:0;'><img src='../../../plugins/images/Fine_etichetta_verde.svg' alt='' height='35' /></div></div>" +
                                     "<div class='white-box-borderleftgreen font-16'>";
                    int x = 1;
                    foreach (IUtilitys resultAvvisi in dataAvvisi)
                    {
                        if (dataAvvisi.Count == x)
                        {
                            ltavvisi.Text += "<p class='ribbon-content colorblack'>" + ReturnTesto(resultAvvisi.Testoavviso) + "</p> ";
                        }
                        else
                        {
                            ltavvisi.Text += "<p class='ribbon-content colorblack' style='padding-bottom:10px;border-bottom:1px solid #FFB136;'>" + ReturnTesto(resultAvvisi.Testoavviso) + "</p> ";
                        }
                        x++;
                    }
                    ltavvisi.Text += "</div>";
                }

                //avviso plafond
                IAccount dataPlaf = servizioAccount.ReturnPlafond(UserId);
                if (dataPlaf != null)
                {
                    ltplafond.Text += "<div class='row'><div class='col-md-2' style='padding-right:0;'><div style='background-color:#89BA17;height:35px;'>" +
                                     "<div style='padding-left:20px;font-size:25px;color:#fff;font-style:italic;font-weight:700'>Attenzione</div></div></div>" +
                                     "<div class='col-md-10' style='padding-left:0;'><img src='../../../plugins/images/Fine_etichetta_verde.svg' alt='' height='35' /></div></div>" +
                                     "<div class='white-box-borderleftgreen font-16'>";
                    if (dataPlaf.Delta >= 0)
                    {
                        ltplafond.Text += "<p class='ribbon-content colorblack'>Ti restano a diposizione &euro; " + dataPlaf.Delta + " rispetto al tuo plafond ponderato al " + dataPlaf.Datarilevazione.ToString("dd/MM/yyy") +
                                         " pari a &euro; " + dataPlaf.Plafond + "</p>";
                    }
                    else
                    {
                        ltplafond.Text += "<p class='ribbon-content colorblack'>Hai sforato di &euro; " + dataPlaf.Delta + " il tuo plafond ponderato al " + dataPlaf.Datarilevazione.ToString("dd/MM/yyy") +
                                         " pari a &euro; " + dataPlaf.Plafond + "</p>";
                    }
                    ltplafond.Text += "</div>";
                }
            }

            hduiduser.Value = Membership.GetUser().ProviderUserKey.ToString();



            //dati auto
            IContratti data2 = servizioContratti.DetailVeicoloAttualeDriver(UserId);
            if (data2 != null)
            {
                pnlCar.Visible = true;
                lblRental.Text = data2.Fornitore;
                lblTarga.Text = data2.Targa;
                lblModello.Text = data2.Modello;

                if (data2.Datarevisione > DateTime.MinValue)
                {
                    lbldatarestituzione.Text = data2.Datarevisione.ToString("dd/MM/yyyy");
                }
                else
                {
                    lbldatarestituzione.Text = "-";
                }

                if (!string.IsNullOrEmpty(data2.Fotoauto))
                {
                    //lblimgauto.Text = "<img src='../../../DownloadFile?type=auto&nomefile=" + data2.Fotoauto + "' class='img-responsive' style='margin-left:auto;margin-right:auto;'>";
                    lblimgauto.Text = "<img src='../../../DownloadFile?type=auto&nomefile=" + data2.Fotoauto + "' class='img-responsive' style='margin-left:auto;margin-right:auto;'>";
                }
                else
                {
                    lblimgauto.Text = "<img src='../../../Repository/auto/nofoto.png' class='img-responsive' style='margin-left:auto;margin-right:auto;'>";
                }
                lblfuel.Text = servizioContratti.SelectToTFuelXUser(data2.Targa, UserId).ToString();

                IContratti dataA = servizioContratti.DetailContrattiAssId(data2.Idcontratto, UserId);
                if (dataA != null)
                {
                    lbldataritiro.Text = dataA.Assegnatodal.ToString("dd/MM/yyyy");                    
                }


                //lista km percorsi
                List<IContratti> dataKm = servizioContratti.SelectKmPercorsi(UserId, data2.Targa);
                if (dataKm != null && dataKm.Count > 0)
                {
                    foreach (IContratti resultKm in dataKm)
                    {
                        lblkmpercorsi.Text += resultKm.Kmpercorsi.ToString("N0");
                    }
                }

            }
            else
            {
                pnlCar.Visible = false;
                panelCar.Visible = false;
            }

            if (servizioContratti.ExistUserCarPolicy(idutente))
            {
                IContratti dataApp = servizioContratti.ReturnIdApprovazione(idutente);
                if (dataApp != null)
                {
                    idapprovazione = dataApp.Idapprovazione;
                }


                //PRIMA SCELTA BENEFIT
                IContratti dataPol = servizioContratti.ReturnTypeCarPolicy(idutente);
                if (dataPol != null)
                {
                    codcarpolicy = dataPol.Codcarpolicy;
                    codcarbenefit = dataPol.Codcarbenefit;

                    if (!string.IsNullOrEmpty(codcarpolicy) || !string.IsNullOrEmpty(codcarbenefit))
                    {
                        //se la carpolicy contiene codcarpolicy e codcarbenefit diversi da nocar e nobenefit
                        if (codcarpolicy.ToUpper() != "NOCAR" && codcarbenefit.ToUpper() != "NOBENEFIT")
                        {
                            pnlTodoOrdinaOpzione2.Visible = true;
                        }

                        //se la carpolicy contiene solo codcarpolicy 
                        if (codcarpolicy.ToUpper() != "NOCAR" && codcarbenefit.ToUpper() == "NOBENEFIT")
                        {
                            pnlTodoOrdina.Visible = true;
                        }

                        //se la carpolicy contiene solo codcarbenefit
                        if (codcarpolicy.ToUpper() == "NOCAR" && codcarbenefit.ToUpper() != "NOBENEFIT")
                        {
                            pnlTodoOrdinaBenefit.Visible = true;
                        }
                    }
                }


                //DOPO SCELTA BENEFIT
                IContratti dataB = servizioContratti.ReturnDatiBenefitCarPolicy(idapprovazione);
                if (dataB != null)
                {
                    hdsceltabenefit.Value = dataB.Sceltabenefit;

                    switch (dataB.Sceltabenefit.ToUpper())
                    {
                        case "AUTO":
                            pnlTodoOrdina.Visible = true;
                            break;
                        case "MOBILITA":
                            pnlTodoOrdinaBenefit.Visible = true;
                            break;
                    }

                    DateTime now = DateTime.Now;
                    DateTime datafinedecorrenza = dataB.Datafinedecorrenza.AddDays(1);

                    //data decorrenza
                    if (datafinedecorrenza < now)
                    {
                        pnlScadenzaDataDecorrenza.Visible = false;
                        pnlTodoOrdinaBenefit.Visible = false;
                        pnlTodoOrdinaOpzione2.Visible = false;
                        pnlTodoOrdina.Visible = false;
                    }
                    else
                    {
                        pnlScadenzaDataDecorrenza.Visible = true;
                        TimeSpan ts = datafinedecorrenza.Subtract(now);
                        lblScadenzaDataDecorrenza.Text = ts.Days.ToString() + " Giorno/i, " + ts.Hours.ToString() + " Ora/e";
                    }
                }



            }

            //conta comunicazioni
            if (servizioComunicazioni.SelectCountComunicazioni(UserId, DateTime.MinValue, DateTime.MinValue, 0, -1, 0, Uidtenant) == 0)
            {
                pnlMessage.Visible = true;
                lblMessage.Text = "<div class='colorblack font-bold font-16 m-b-23'>Nessun ticket in lavorazione</div>";
            }
            else
            {
                pnlMessage.Visible = false;
            }


            if (!Page.IsPostBack)
            {
                lblCountTask.Text = servizioUtility.SelectCountTaskAperti(UserId, Uidtenant).ToString();
            }

        }
        public string ReturnTesto(string testotask, string linktask)
        {
            string retVal = string.Empty;

            retVal += testotask;
            if (!string.IsNullOrEmpty(linktask))
            {
                retVal += " &nbsp; <a href='" + linktask + "' target='_blank'>Clicca qui</a>";
            }
            return retVal;
        }

        public string ReturnCheck(string idtask, string esitotask, string uid, string datatask)
        {
            string retVal;
            string dataoggi;
            string dataora = DateTime.Now.ToString("dd/MM/yyyy");

            if (SeoHelper.DataString(datatask) < SeoHelper.DataString(dataora))
            {
                dataoggi = "NO";
            }
            else
            {
                dataoggi = "SI";
            }

            if (esitotask == "1")
            {
                retVal = "<input id='c7_" + idtask + "' data-id='" + uid + "' data-day='" + dataoggi + "' class='checktask1' type='checkbox' checked='checked' onclick='return false;'>";
            }
            else
            {
                retVal = "<input id='c7_" + idtask + "' data-id='" + uid + "' data-day='" + dataoggi + "' class='checktask' type='checkbox'>";
            }

            return retVal;
        }
        public string ReturnFase1()
        {
            string retVal = string.Empty;

            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idutente = 0;

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;
            }

            //fase 1 
            if (servizioContratti.ExistUserCarPolicyActive(idutente))
            {
                if (string.IsNullOrEmpty(ReturnFase2()) && string.IsNullOrEmpty(ReturnFase3()) && string.IsNullOrEmpty(ReturnFase4()) 
                    && string.IsNullOrEmpty(ReturnFase5()) && string.IsNullOrEmpty(ReturnFase6()))
                {
                    retVal = "active";
                }
            }

            return retVal;
        }
        public string ReturnFase2()
        {
            string retVal = string.Empty;

            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey; 
            int idutente = 0;

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;
            }

            //fase 2
            if (servizioContratti.ExistUserCarPolicyActive(idutente))
            {
                if (string.IsNullOrEmpty(ReturnFase3()))
                {                        
                    retVal = "active";                        
                }
            }

            return retVal;
        }
        public string ReturnFase3()
        {
            string retVal = string.Empty;

            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idutente = 0;
            int idapprovazione = 0;

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;
            }

            IContratti data2 = servizioContratti.ReturnIdApprovazione(idutente);
            if (data2 != null)
            {
                idapprovazione = data2.Idapprovazione;
            }

            //fase 3
            if (servizioContratti.SelectCountConfigurazioniInviate(idapprovazione) >= 1)
            {
                if (string.IsNullOrEmpty(ReturnFase4()))
                {
                    retVal = "active";
                }
            }

            return retVal;
        }
        public string ReturnFase4()
        {
            string retVal = string.Empty;

            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idutente = 0;
            int idapprovazione = 0;

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;
            }

            IContratti data2 = servizioContratti.ReturnIdApprovazione(idutente);
            if (data2 != null)
            {
                idapprovazione = data2.Idapprovazione;
            }

            //fase 4
            if (servizioContratti.SelectCountConfigurazioniDaConfermareInviate(idapprovazione) >= 1)
            {
                if (string.IsNullOrEmpty(ReturnFase5()))
                {
                    retVal = "active";
                }
            }

            return retVal;
        }
        public string ReturnFase5()
        {
            string retVal = string.Empty;

            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idutente = 0;
            int idapprovazione = 0;

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;
            }

            IContratti data2 = servizioContratti.ReturnIdApprovazione(idutente);
            if (data2 != null)
            {
                idapprovazione = data2.Idapprovazione;
            }

            //fase 5
            if (servizioContratti.SelectCountConfigurazioniDaEvadereInviate(UserId) >= 1)
            {
                if (string.IsNullOrEmpty(ReturnFase6()))
                {
                    retVal = "active";
                }
            }

            return retVal;
        }
        public string ReturnFase6()
        {
            string retVal = string.Empty;

            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int idutente = 0;
            int idapprovazione = 0;

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                idutente = data.Iduser;
            }

            IContratti data2 = servizioContratti.ReturnIdApprovazione(idutente);
            if (data2 != null)
            {
                idapprovazione = data2.Idapprovazione;
            }

            //fase 6
            if (servizioContratti.SelectCountConfigurazioniEvaseInviate(idapprovazione) >= 1)
            {
                retVal = "active";
            }

            return retVal;
        }

        public string ReturnSituazioneAuto(string fase)
        {
            string retVal = string.Empty;
            int idcontratto = 0;

            IContrattiBL servizioContratti = new ContrattiBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;

            //fase 1
            IContratti dataP = servizioContratti.ReturnUidCarPolicy(UserId);
            if (dataP != null)
            {
                if (!string.IsNullOrEmpty(dataP.Documentocarpolicy))
                {
                    if (fase.ToUpper() == "FASE1")
                    {
                        retVal = "active";
                    }
                }
            }

            IContratti data2 = servizioContratti.DetailVeicoloAttualeDriver(UserId);
            if (data2 != null)
            {
                idcontratto = data2.Idcontratto;
            }

            IContratti data = servizioContratti.DetailContrattiAssId(idcontratto, UserId);
            if (data != null)
            {
                //fase 2
                if (data.Assegnatodal > DateTime.Now)
                {
                    if (fase.ToUpper() == "FASE2")
                    {
                        retVal = "active";
                    }
                }
                else //fase 3
                {
                    if (fase.ToUpper() == "FASE2")
                    {
                        retVal = "active";
                    }

                    if (fase.ToUpper() == "FASE3")
                    {
                        retVal = "active";
                    }
                }

                //fase 4
                if (data.Datarestituzione > DateTime.MinValue)
                {
                    if (fase.ToUpper() == "FASE4")
                    {
                        retVal = "active";
                    }
                }

            }
            return retVal;
        }
        public string ReturnFasePacchetto()
        {
            string retVal = string.Empty;

            if (string.IsNullOrEmpty(hdsceltabenefit.Value))
            {
                retVal = "active";
            }

            return retVal;
        }
        public string LinkFasePacchetto()
        {
            if (!string.IsNullOrEmpty(ReturnFasePacchetto()))
            {
                return "onclick=\"location.href='../Ordini/ScegliBenefit'\" style=\"cursor:pointer;\" ";
            }
            else
            {
                return "";
            }
        }
        public string ReturnFaseWallet()
        {
            string retVal = string.Empty;

            if (!string.IsNullOrEmpty(hdsceltabenefit.Value))
            {
                retVal = "active";
            }

            return retVal;
        }

        public string LinkFase1()
        {
            if (!string.IsNullOrEmpty(ReturnFase1()))
            {
                return "onclick=\"location.href='../Ordini/UploadCarPolicy'\" style=\"cursor:pointer;\" ";
            }
            else
            {
                return "";
            }
        }
        public string LinkFase2()
        {
            if (!string.IsNullOrEmpty(ReturnFase2()))
            {
                return "onclick=\"location.href='../Ordini/ConfiguraAuto'\" style=\"cursor:pointer;\" ";
            }
            else
            {
                return "";
            }
        }
        public string LinkFase3()
        {
            if (!string.IsNullOrEmpty(ReturnFase3()))
            {
                return "onclick=\"location.href='../Ordini/RichiesteOrdini'\" style=\"cursor:pointer;\" ";
            }
            else
            {
                return "";
            }
        }
        public string LinkFase4()
        {
            if (!string.IsNullOrEmpty(ReturnFase4()))
            {
                return "onclick=\"location.href='../Ordini/RichiesteOrdini'\" style=\"cursor:pointer;\" ";
            }
            else
            {
                return "";
            }
        }
        public string LinkFase5()
        {
            if (!string.IsNullOrEmpty(ReturnFase5()))
            {
                return "onclick=\"location.href='../Ordini/RichiesteOrdini'\" style=\"cursor:pointer;\" ";
            }
            else
            {
                return "";
            }
        }
        public string LinkFase6()
        {
            if (!string.IsNullOrEmpty(ReturnFase6()))
            {
                return "onclick=\"location.href='../Ordini/RitiroAuto'\" style=\"cursor:pointer;\" ";
            }
            else
            {
                return "";
            }
        }

        public string ReturnCodCarPolicy(string codsocieta, string gradecode)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string retVal = string.Empty;

            IContratti dataCodPol = servizioContratti.ReturnCodCarPolicy(codsocieta, gradecode);
            if (dataCodPol != null)
            {
                retVal = dataCodPol.Codcarpolicy;
            }

            return retVal;
        }

        public string ReturnTesto(string testo)
        {
            string retVal = "";

            if (!string.IsNullOrEmpty(testo))
            {
                retVal = testo.Replace("\r\n", "<br />");
            }

            return retVal;
        }
    }
}
