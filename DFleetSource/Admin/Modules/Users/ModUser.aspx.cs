// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="modUser.aspx.cs" company="">
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
using AraneaUtilities.Auth.Roles;

namespace DFleet.Admin.Modules.Users
{
    public partial class ModUser : System.Web.UI.Page
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
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {

                    IAccount data = servizioAccount.DetailId(uid);
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
        private void BindData(IAccount data)
        {
            ddlGruppo.SelectedValue = Convert.ToString(data.Idgruppouser, CultureInfo.CurrentCulture);
            ddlStatus.SelectedValue = Convert.ToString(data.Idstatususer, CultureInfo.CurrentCulture);
            ddlCodSocieta.SelectedValue = data.Codsocieta;
            txtNome.Text = data.Nome;
            txtCognome.Text = data.Cognome;
            txtMatricola.Text = data.Matricola;
            txtNumber.Text = data.Idnumber;
            txtTipoDriver.Text = SeoHelper.CheckIntString(data.Idtipodriver);
            txtFunzione.Text = data.Funzione;
            txtMaternita.Text = data.Maternita;
            txtCellulare.Text = data.Cellulare;
            txtEmail.Text = data.Email;
            txtDataAssunzione.Text = SeoHelper.CheckDataString(data.Dataassunzione); 
            txtCodiceCDC.Text = data.Codicecdc;
            txtCodiceCDC2.Text = data.Codicecdc2;
            txtCodiceCDC3.Text = data.Codicecdc3;
            txtPercCDC.Text = SeoHelper.CheckIntString(data.Perccdc);
            txtPercCDC2.Text = SeoHelper.CheckIntString(data.Perccdc2);
            txtPercCDC3.Text = SeoHelper.CheckIntString(data.Perccdc3);
            txtDescrizioneCDC.Text = data.Descrizionecdc;
            txtFasciaCarPolicy.Text = data.Fasciacarpolicy;
            txtCodiceSede.Text = data.Codicesede;
            txtDescrizioneSede.Text = data.Descrizionesede;
            txtDataNascita.Text = SeoHelper.CheckDataString(data.Datanascita);
            txtLuogoNascita.Text = data.Luogonascita;
            txtProvinciaNascita.Text = data.Provincianascita;
            txtCodiceFiscale.Text = data.Codicefiscale;
            txtIndirizzoResidenza.Text = data.Indirizzoresidenza;
            txtLocalitaResidenza.Text = data.Localitaresidenza;
            txtProvinciaResidenza.Text = data.Provinciaresidenza;
            txtCapResidenza.Text = data.Capresidenza;
            txtNrPatente.Text = data.Nrpatente;
            txtDataEmissione.Text = SeoHelper.CheckDataString(data.Dataemissione);
            txtDataScadenza.Text = SeoHelper.CheckDataString(data.Datascadenza);
            txtUfficioEmittente.Text = data.Ufficioemittente;
            txtMatricolaApprovatore.Text = data.Matricolaapprovatore;
            txtCodiceSocietaApprovatore.Text = data.Codicesocietaapprovatore;
            txtDataInizioValidita.Text = SeoHelper.CheckDataString(data.Datainiziovalidita);
            txtCodiceSettore.Text = data.Codicesettore;
            txtDescrizioneSettore.Text = data.Descrizionesettore;
            txtDescrizioneApprovatore.Text = data.Descrizioneapprovatore;
            txtEmailApprovatore.Text = data.Emailapprovatore;
            txtDataPrevistaDimissione.Text = SeoHelper.CheckDataString(data.Dataprevistadimissione);
            txtDataDimissioni.Text = SeoHelper.CheckDataString(data.Datadimissioni);
            ddlCodGrade.SelectedValue = data.Gradecode;
            ddlPersonType.SelectedValue = data.Persontype;
            txtIndirizzoSede.Text = data.Indirizzosede;
            txtCittaSede.Text = data.Cittasede;
            txtProvinciaSede.Text = data.Provinciasede;
            txtCapSede.Text = data.Capsede;
            txtCodiceDivisione.Text = data.Codicedivisione;
            txtDescrizioneDivisione.Text = data.Descrizionedivisione;
            txtFasciaImportazione.Text = data.Fasciaimportazione;
            txtAnnotazioni.Text = data.Annotazioni;
            ddlCodFornitore.SelectedValue = data.Codfornitore;
            hdgradecode.Value = data.Gradecode;
            hdidutente.Value = data.Iduser.ToString();
            hdiduser.Value = SeoHelper.CheckGuidString(data.UserId);
            if (data.Flgdriver == 1)
            {
                flgdriver.Checked = true;
            }
            else
            {
                flgdriver.Checked = false;
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateAnagrafica("salva");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateAnagrafica("salvachiudi");
        }


        public void UpdateAnagrafica(string opzione)
        {
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();

            IAccount accountNew = new Account();
            IAccount accountNewCred = new Account();

            string _iduser = hdiduser.Value;
            Guid iduser = new Guid(_iduser);
            string error = string.Empty;
            int flgadmin = 0;
            accountNew.Email = SeoHelper.EncodeString(txtEmail.Text);


            //controllo email corretta
            Regex emailregexp = new Regex("(?<user>[^@]+)@(?<host>.+)");
            Match controlloEmail = emailregexp.Match(accountNew.Email);

            if (!controlloEmail.Success)
            {
                txtEmail.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Email<br />";
            }
            else
            {
                txtEmail.CssClass = "form-control";

                // rimuovo provvisoriamente tutti i ruoli da use
                // devo rimuovere a tutti gli altri ruoli
                if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin))
                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin);
                if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User))
                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User);
                if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Guest))
                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Guest);
                if (Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Partner))
                    Roles.RemoveUserFromRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Partner);

                //controllo check amministratore
                // assegno il ruolo indicato dal radio button
                switch (ddlGruppo.SelectedValue)
                {
                    case "2": //UTENTE
                        flgadmin = 0;
                        if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User))
                            Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User);
                        break;
                    case "1": //AMMINISTATORE
                    case "10": //MASTER
                        flgadmin = 1;
                        // devo passare a DFleetAdmin
                        if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin))
                            Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Admin);
                        break;
                    case "3": //GUEST
                        flgadmin = 3;
                        if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Guest))
                            Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Guest);
                        break;
                    case "4": //PARTNER
                        flgadmin = 4;
                        if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Partner))
                            Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.Partner);
                        break;
                    default: //UTENTE
                        flgadmin = 2;
                        if (!Roles.IsUserInRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User))
                            Roles.AddUserToRole(SeoHelper.EncodeString(txtEmail.Text), DFleetGlobals.UserRoles.User);
                        break;
                }
            }

            accountNew.Idgruppouser = SeoHelper.IntString(ddlGruppo.SelectedValue);
            accountNew.Idstatususer = SeoHelper.IntString(ddlStatus.SelectedValue);
            accountNew.Flgadmin = flgadmin;
            accountNew.UserId = iduser;
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
            accountNew.Fasciacarpolicy = SeoHelper.EncodeString(txtFasciaCarPolicy.Text);
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
            accountNew.Uidtenant = SeoHelper.ReturnSessionTenant();
            if (flgdriver.Checked)
            {
                accountNew.Flgdriver = 1;
            }
            else
            {
                accountNew.Flgdriver = 0;
            }

            //recupera dati credenziali firmadigitale
            string ClientId = "";
            string ImpersonatedUserId = "";
            string AuthServer = "";
            string PrivateKey = "";
            string BasePath = "";
            string AccountId = "";        
            string PingUrl = "";
            string SignerEmail = "";
            string SignerName = "";
            string SignerClientId = "";

            IAccount data = servizioAccount.DetailId(iduser);
            if (data != null)
            {
                ClientId = data.ClientId;
                ImpersonatedUserId = data.ImpersonatedUserId;
                AuthServer = data.AuthServer;
                PrivateKey = data.PrivateKey;
                BasePath = data.BasePath;
                AccountId = data.AccountId;
                PingUrl = data.PingUrl;
                SignerEmail = data.SignerEmail;
                SignerName = data.SignerName;
                SignerClientId = data.SignerClientId;
            }

            accountNewCred.UserId = iduser;
            accountNewCred.Uidtenant = SeoHelper.ReturnSessionTenant();

            if (!string.IsNullOrEmpty(txtClientId.Text))
            {
                accountNewCred.ClientId = SeoHelper.EncodeString(EncryptHelper.Encrypt(txtClientId.Text, SeoHelper.PassPhrase())); 
            }
            else
            {
                accountNewCred.ClientId = ClientId;
            }

            if (!string.IsNullOrEmpty(txtImpersonatedUserId.Text))
            {
                accountNewCred.ImpersonatedUserId = SeoHelper.EncodeString(EncryptHelper.Encrypt(txtImpersonatedUserId.Text, SeoHelper.PassPhrase()));
            }
            else
            {
                accountNewCred.ImpersonatedUserId = ImpersonatedUserId;
            }

            if (!string.IsNullOrEmpty(txtAuthServer.Text))
            {
                accountNewCred.AuthServer = SeoHelper.EncodeString(EncryptHelper.Encrypt(txtAuthServer.Text, SeoHelper.PassPhrase()));
            }
            else
            {
                accountNewCred.AuthServer = AuthServer;
            }

            if (!string.IsNullOrEmpty(txtPrivateKey.Text))
            {
                accountNewCred.PrivateKey = SeoHelper.EncodeString(EncryptHelper.Encrypt(txtPrivateKey.Text, SeoHelper.PassPhrase()));
            }
            else
            {
                accountNewCred.PrivateKey = PrivateKey;
            }

            if (!string.IsNullOrEmpty(txtBasePath.Text))
            {
                accountNewCred.BasePath = SeoHelper.EncodeString(EncryptHelper.Encrypt(txtBasePath.Text, SeoHelper.PassPhrase()));
            }
            else
            {
                accountNewCred.BasePath = BasePath;
            }

            if (!string.IsNullOrEmpty(txtAccountId.Text))
            {
                accountNewCred.AccountId = SeoHelper.EncodeString(EncryptHelper.Encrypt(txtAccountId.Text, SeoHelper.PassPhrase()));
            }
            else
            {
                accountNewCred.AccountId = AccountId;
            }

            if (!string.IsNullOrEmpty(txtPingUrl.Text))
            {
                accountNewCred.PingUrl = SeoHelper.EncodeString(EncryptHelper.Encrypt(txtPingUrl.Text, SeoHelper.PassPhrase()));
            }
            else
            {
                accountNewCred.PingUrl = PingUrl;
            }

            if (!string.IsNullOrEmpty(txtSignerEmail.Text))
            {
                accountNewCred.SignerEmail = SeoHelper.EncodeString(EncryptHelper.Encrypt(txtSignerEmail.Text, SeoHelper.PassPhrase()));
            }
            else
            {
                accountNewCred.SignerEmail = SignerEmail;
            }

            if (!string.IsNullOrEmpty(txtSignerName.Text))
            {
                accountNewCred.SignerName = SeoHelper.EncodeString(EncryptHelper.Encrypt(txtSignerName.Text, SeoHelper.PassPhrase()));
            }
            else
            {
                accountNewCred.SignerName = SignerName;
            }

            if (!string.IsNullOrEmpty(txtSignerClientId.Text))
            {
                accountNewCred.SignerClientId = SeoHelper.EncodeString(EncryptHelper.Encrypt(txtSignerClientId.Text, SeoHelper.PassPhrase()));
            }
            else
            {
                accountNewCred.SignerClientId = SignerClientId;
            }
            //fine


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

            if (!string.IsNullOrEmpty(error))
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione. Il modulo non è stato compilato correttamente. Si sono verificati i seguenti errori:";
                lblMessage.Text += "<br /><br /><b>" + error + "</b><br />";
            }
            else
            {
                if (servizioAccount.Update(accountNew) == 1)
                {
                    servizioAccount.UpdateCredential(accountNewCred);

                    //controllo cambio gradecode
                    if ((hdgradecode.Value != accountNew.Gradecode) && SeoHelper.IntString(accountNew.Gradecode) > 25)
                    {
                        //controllo esistenza user carpolicy
                        if (!servizioContratti.ExistUserCarPolicy(SeoHelper.IntString(hdidutente.Value)))
                        {
                            //se nocar non fa nuessuna operazione
                            if (accountNew.Fasciacarpolicy.ToUpper() != "NOCAR")
                            {
                                //inserimento user carpolicy

                                /*IContratti contrattiuserCarPolicyNew = new Contratti
                                {
                                    Idutente = SeoHelper.IntString(hdidutente.Value),
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


                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica " + accountNew.UserId);

                    if (opzione.ToUpper() == "SALVA")
                    {
                        //messaggio avvenuto inserimento
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-success";
                        lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Users/ViewUsers") + "'>Ritorna alla Lista</a>";
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
