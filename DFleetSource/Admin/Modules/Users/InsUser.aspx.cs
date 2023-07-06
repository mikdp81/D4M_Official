// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="insUser.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text.RegularExpressions;
using System.Web;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using DFleet.Classes;
using AraneaUtilities.Auth.Roles;

namespace DFleet.Admin.Modules.Users
{
    public partial class InsUser : System.Web.UI.Page
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
            pnlMessage.Visible = false;
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            InsertAccount("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertAccount("salvachiudi");
        }


        public void InsertAccount(string opzione)
        {
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();

            IAccount accountNew = new Account();

            string error = string.Empty;
            int flgadmin = 0;
            Guid userId = Guid.Empty;
            accountNew.Email = SeoHelper.EncodeString(txtEmail.Text);
            accountNew.Idgruppouser = SeoHelper.IntString(ddlGruppo.SelectedValue);
            accountNew.Idstatususer = SeoHelper.IntString(ddlStatus.SelectedValue);
            accountNew.Codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue);
            accountNew.Nome = SeoHelper.EncodeString(txtNome.Text);
            accountNew.Cognome = SeoHelper.EncodeString(txtCognome.Text);
            accountNew.Matricola = SeoHelper.EncodeString(txtMatricola.Text);
            accountNew.Idnumber = SeoHelper.EncodeString(txtNumber.Text);
            accountNew.Idtipodriver = SeoHelper.IntString(txtTipoDriver.Text);
            accountNew.Funzione = SeoHelper.EncodeString(txtFunzione.Text);
            accountNew.Maternita = SeoHelper.EncodeString(txtMaternita.Text);
            accountNew.Cellulare = SeoHelper.EncodeString(txtCellulare.Text);
            accountNew.Dataassunzione = SeoHelper.DataString(txtDataAssunzione.Text);
            accountNew.Codicecdc = SeoHelper.EncodeString(txtCodiceCDC.Text);
            accountNew.Codicecdc2 = SeoHelper.EncodeString(txtCodiceCDC2.Text);
            accountNew.Codicecdc3 = SeoHelper.EncodeString(txtCodiceCDC3.Text);
            accountNew.Perccdc = SeoHelper.IntString(txtPercCDC.Text);
            accountNew.Perccdc2 = SeoHelper.IntString(txtPercCDC2.Text);
            accountNew.Perccdc3 = SeoHelper.IntString(txtPercCDC3.Text);
            accountNew.Descrizionecdc = SeoHelper.EncodeString(txtDescrizioneCDC.Text);
            accountNew.Codicesede = SeoHelper.EncodeString(txtCodiceSede.Text);
            accountNew.Descrizionesede = SeoHelper.EncodeString(txtDescrizioneSede.Text);
            accountNew.Datanascita = SeoHelper.DataString(txtDataNascita.Text);
            accountNew.Luogonascita = SeoHelper.EncodeString(txtLuogoNascita.Text);
            accountNew.Provincianascita = SeoHelper.EncodeString(txtProvinciaNascita.Text);
            accountNew.Codicefiscale = SeoHelper.EncodeString(txtCodiceFiscale.Text);
            accountNew.Indirizzoresidenza = SeoHelper.EncodeString(txtIndirizzoResidenza.Text);
            accountNew.Localitaresidenza = SeoHelper.EncodeString(txtLocalitaResidenza.Text);
            accountNew.Provinciaresidenza = SeoHelper.EncodeString(txtProvinciaResidenza.Text);
            accountNew.Capresidenza = SeoHelper.EncodeString(txtCapResidenza.Text);
            accountNew.Nrpatente = SeoHelper.EncodeString(txtNrPatente.Text);
            accountNew.Dataemissione = SeoHelper.DataString(txtDataEmissione.Text);
            accountNew.Datascadenza = SeoHelper.DataString(txtDataScadenza.Text);
            accountNew.Ufficioemittente = SeoHelper.EncodeString(txtUfficioEmittente.Text);
            accountNew.Matricolaapprovatore = SeoHelper.EncodeString(txtMatricolaApprovatore.Text);
            accountNew.Codicesocietaapprovatore = SeoHelper.EncodeString(txtCodiceSocietaApprovatore.Text);
            accountNew.Datainiziovalidita = SeoHelper.DataString(txtDataInizioValidita.Text);
            accountNew.Codicesettore = SeoHelper.EncodeString(txtCodiceSettore.Text);
            accountNew.Descrizionesettore = SeoHelper.EncodeString(txtDescrizioneSettore.Text);
            accountNew.Descrizioneapprovatore = SeoHelper.EncodeString(txtDescrizioneApprovatore.Text);
            accountNew.Emailapprovatore = SeoHelper.EncodeString(txtEmailApprovatore.Text);
            accountNew.Dataprevistadimissione = SeoHelper.DataString(txtDataPrevistaDimissione.Text);
            accountNew.Datadimissioni = SeoHelper.DataString(txtDataDimissioni.Text);
            accountNew.Gradecode = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
            accountNew.Persontype = SeoHelper.EncodeString(ddlPersonType.SelectedValue);
            accountNew.Indirizzosede = SeoHelper.EncodeString(txtIndirizzoSede.Text);
            accountNew.Cittasede = SeoHelper.EncodeString(txtCittaSede.Text);
            accountNew.Provinciasede = SeoHelper.EncodeString(txtProvinciaSede.Text);
            accountNew.Capsede = SeoHelper.EncodeString(txtCapSede.Text);
            accountNew.Codicedivisione = SeoHelper.EncodeString(txtCodiceDivisione.Text);
            accountNew.Descrizionedivisione = SeoHelper.EncodeString(txtDescrizioneDivisione.Text);
            accountNew.Fasciaimportazione = SeoHelper.EncodeString(txtFasciaImportazione.Text);
            accountNew.Annotazioni = SeoHelper.EncodeString(txtAnnotazioni.Text);
            accountNew.Codfornitore = SeoHelper.EncodeString(ddlCodFornitore.SelectedValue);
            accountNew.Fasciacarpolicy = ReturnCodCarPolicy(accountNew.Codsocieta, accountNew.Gradecode);
            accountNew.Uidtenant = SeoHelper.ReturnSessionTenant();
            if (flgdriver.Checked)
            {
                accountNew.Flgdriver = 1;
            }
            else
            {
                accountNew.Flgdriver = 0;
            }

            //controllo email corretta
            Regex emailregexp = new Regex("(?<user>[^@]+)@(?<host>.+)");
            Match controlloEmail = emailregexp.Match(accountNew.Email);

            if (!controlloEmail.Success)
            {
                txtEmail.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Email<br />";
            }

            if (string.IsNullOrEmpty(accountNew.Codsocieta))
            {
                ddlCodSocieta.CssClass = "form-control is-invalid";
                error += "Selezionare un Codice Societ&agrave;<br />";
            }
            else
            {
                ddlCodSocieta.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(accountNew.Nome))
            {
                txtNome.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Nome<br />";
            }
            else
            {
                txtNome.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(accountNew.Cognome))
            {
                txtCognome.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Cognome<br />";
            }
            else
            {
                txtCognome.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(accountNew.Matricola))
            {
                txtMatricola.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Matricola<br />";
            }
            else
            {
                txtMatricola.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(accountNew.Cellulare))
            {
                txtCellulare.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Cellulare<br />";
            }
            else
            {
                txtCellulare.CssClass = "form-control";
            }

            if (accountNew.Idgruppouser == 0)
            {
                ddlGruppo.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Ruolo<br />";
            }
            else
            {
                ddlGruppo.CssClass = "form-control";
            }


            // se l'utente non è già esistente: creo utente
            MembershipUserCollection utenti = Membership.FindUsersByEmail(SeoHelper.EncodeString(txtEmail.Text));
            if (utenti.Count > 0)
            {
                txtEmail.CssClass = "form-control is-invalid";
                error += "Email gi&agrave; esistente<br />";
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
                if (utenti.Count == 0)
                {
                    //ERR: crea l'utente anche se username = ""
                    Membership.CreateUser(SeoHelper.EncodeString(txtEmail.Text), "Dfleet2021.", SeoHelper.EncodeString(txtEmail.Text)); //crea utente
                    //Membership.CreateUser(SeoHelper.EncodeString(txtEmail.Text), "PenTest2022!", SeoHelper.EncodeString(txtEmail.Text)); //crea utente

                    //controllo check amministratore
                    switch (ddlGruppo.SelectedValue)
                    {
                        case "2": //UTENTE
                            flgadmin = 2;

                            // devo passare a DCreditUser
                            if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User))
                                Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User);
                            // devo rimuovere a DCreditAdmin
                            if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin))
                                Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin);

                            break;
                        case "1": //AMMINISTATORE
                        case "10": //MASTER
                            flgadmin = 1;

                            // devo passare a DCreditAdmin
                            if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin))
                                Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin);
                            // devo rimuovere a DCreditUser
                            if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User))
                                Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User);

                            break;

                        case "3": //GUEST
                            flgadmin = 3;

                            // devo passare a DCreditGuest
                            if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Guest))
                                Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Guest);
                            // devo rimuovere a DCreditAdmin
                            if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin))
                                Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin);

                            break;

                        case "4": //PARTNER
                            flgadmin = 4;

                            // devo passare a DCreditPartner
                            if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Partner))
                                Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Partner);
                            // devo rimuovere a DCreditAdmin
                            if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin))
                                Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin);

                            break;

                        default: //UTENTE
                            flgadmin = 2;

                            // devo passare a DCreditUser
                            if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User))
                                Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User);
                            // devo rimuovere a DCreditAdmin
                            if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin))
                                Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin);

                            break;
                    }

                    userId = (Guid)Membership.GetUser(SeoHelper.EncodeString(txtEmail.Text)).ProviderUserKey; //recupera guid utente
                    accountNew.Flgadmin = flgadmin;
                    accountNew.UserId = userId;
                }



                if (servizioAccount.Insert(accountNew) == 1)
                {
                    //controllo esistenza mail
                    if (servizioAccount.ExistUser(accountNew.Email))
                    {
                        //recupero iduser
                        IAccount dataLastId = servizioAccount.UltimoIDUser();
                        if (dataLastId != null)
                        {
                            //controllo esistenza user carpolicy
                            if (!servizioContratti.ExistUserCarPolicy(dataLastId.Iduser))
                            {
                                //se nocar non fa nuessuna operazione
                                if (accountNew.Fasciacarpolicy.ToUpper() != "NOCAR")
                                {

                                    //inserimento user carpolicy
                                    /*IContratti contrattiuserCarPolicyNew = new Contratti
                                    {
                                        Idutente = dataLastId.Iduser,
                                        Codsocieta = accountNew.Codsocieta,
                                        Codcarpolicy = ReturnCodCarPolicy(accountNew.Codsocieta, accountNew.Gradecode),
                                        Idapprovatore = ReturnIdApprovatore(),
                                        Flgmail = "",
                                        Approvato = 0
                                    };

                                    servizioContratti.InsertUserCarPolicy(contrattiuserCarPolicyNew);*/
                                }
                            }
                        }

                    }

                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + accountNew.Cognome + " " + accountNew.Nome + " " + accountNew.Matricola);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset di tutti campi
                        ddlGruppo.ClearSelection();
                        ddlStatus.ClearSelection();
                        ddlCodSocieta.ClearSelection();
                        ddlCodGrade.ClearSelection();
                        ddlPersonType.ClearSelection();
                        ddlCodFornitore.ClearSelection();
                        txtNome.Text = "";
                        txtCognome.Text = "";
                        txtMatricola.Text = "";
                        txtNumber.Text = "";
                        txtTipoDriver.Text = "";
                        txtFunzione.Text = "";
                        txtMaternita.Text = "";
                        txtCellulare.Text = "";
                        txtEmail.Text = "";
                        txtDataAssunzione.Text = "";
                        txtCodiceCDC.Text = "";
                        txtCodiceCDC2.Text = "";
                        txtCodiceCDC3.Text = "";
                        txtPercCDC.Text = "";
                        txtPercCDC2.Text = "";
                        txtPercCDC3.Text = "";
                        txtDescrizioneCDC.Text = "";
                        txtCodiceSede.Text = "";
                        txtDescrizioneSede.Text = "";
                        txtDataNascita.Text = "";
                        txtLuogoNascita.Text = "";
                        txtProvinciaNascita.Text = "";
                        txtCodiceFiscale.Text = "";
                        txtIndirizzoResidenza.Text = "";
                        txtLocalitaResidenza.Text = "";
                        txtProvinciaResidenza.Text = "";
                        txtCapResidenza.Text = "";
                        txtNrPatente.Text = "";
                        txtDataEmissione.Text = "";
                        txtDataScadenza.Text = "";
                        txtUfficioEmittente.Text = "";
                        txtMatricolaApprovatore.Text = "";
                        txtCodiceSocietaApprovatore.Text = "";
                        txtDataInizioValidita.Text = "";
                        txtCodiceSettore.Text = "";
                        txtDescrizioneSettore.Text = "";
                        txtDescrizioneApprovatore.Text = "";
                        txtEmailApprovatore.Text = "";
                        txtDataPrevistaDimissione.Text = "";
                        txtDataDimissioni.Text = "";
                        txtIndirizzoSede.Text = "";
                        txtCittaSede.Text = "";
                        txtProvinciaSede.Text = "";
                        txtCapSede.Text = "";
                        txtCodiceDivisione.Text = "";
                        txtDescrizioneDivisione.Text = "";
                        txtFasciaImportazione.Text = "";
                        txtAnnotazioni.Text = "";


                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Inserimento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Users/ViewUsers") + "'>Ritorna alla Lista</a>";
                    }
                    else
                    {
                        Response.Redirect("ViewUsers");
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

        public string ReturnCodCarPolicy(string codsocieta, string gradecode)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string retVal;

            IContratti dataCodPol = servizioContratti.ReturnCodCarPolicy(codsocieta, gradecode);
            if (dataCodPol != null)
            {
                retVal = dataCodPol.Codcarpolicy;
            }
            else
            {
                retVal = "Nocar";
            }

            return retVal;
        }

        public int ReturnIdApprovatore()
        {
            IAccountBL servizioAccount = new AccountBL();
            int retVal = 0;

            IAccount dataId = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
            if (dataId != null)
            {
                retVal = dataId.Iduser;
            }

            return retVal;
        }
    }
}
