// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModConferma.aspx.cs" company="">
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
using FirmaDigitale;

namespace DFleet.Admin.Modules.Ordini
{
    public partial class ModConferma : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(10)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    //recupero file rental da firmare 
                    string returnUrl = "";
                    string docPdf = "";

                    IContratti data = servizioContratti.DetailOrdiniId(uid);
                    if (data != null)
                    {
                        docPdf = data.Fileconfermarental;
                        returnUrl = "https://" + HttpContext.Current.Request.Url.Host + "/Admin/Modules/Ordini/ModConfermaOk-" + uid.ToString();
                        //returnUrl = "https://dcredit-test.deloitte.it/Admin/Modules/Ordini/ModConfermaOk-" + uid.ToString();
                        //returnUrl = "https://localhost:44392/Admin/Modules/Ordini/ModConfermaOk-" + uid.ToString();
                        //returnUrl = "https://d4m-test.deloitte.it/Admin/Modules/Ordini/ModConfermaOk-" + uid.ToString();
                    }

                    // CREARE
                    UserConfig userConfig = new UserConfig();

                    IAccount dataUser = servizioAccount.DetailId(UserId);
                    if (dataUser != null)
                    {
                        /*userConfig.ClientId = "f7f99919-482a-4681-b079-4e239ae12607";
                        userConfig.ImpersonatedUserId = "90b68cdc-d23e-4f39-aa4f-ff02f6ee88b5";
                        userConfig.AuthServer = "account.docusign.com";*/

                        userConfig.ClientId = EncryptHelper.Decrypt(dataUser.ClientId, SeoHelper.PassPhrase());
                        userConfig.ImpersonatedUserId = EncryptHelper.Decrypt(dataUser.ImpersonatedUserId, SeoHelper.PassPhrase());
                        userConfig.AuthServer = EncryptHelper.Decrypt(dataUser.AuthServer, SeoHelper.PassPhrase());
                        userConfig.PrivateKey = EncryptHelper.Decrypt(dataUser.PrivateKey, SeoHelper.PassPhrase());
                        userConfig.BasePath = EncryptHelper.Decrypt(dataUser.BasePath, SeoHelper.PassPhrase());
                        userConfig.AccountId = EncryptHelper.Decrypt(dataUser.AccountId, SeoHelper.PassPhrase());
                        userConfig.PingUrl = EncryptHelper.Decrypt(dataUser.PingUrl, SeoHelper.PassPhrase());
                        userConfig.SignerEmail = EncryptHelper.Decrypt(dataUser.SignerEmail, SeoHelper.PassPhrase());
                        userConfig.SignerName = EncryptHelper.Decrypt(dataUser.SignerName, SeoHelper.PassPhrase());
                        userConfig.SignerClientId = EncryptHelper.Decrypt(dataUser.SignerClientId, SeoHelper.PassPhrase());
                    }

                    //avvia processo firma digitale
                    IFirmaDigitale firmaDigitale = FirmaDigitaleFactory.CreateInstance(userConfig, returnUrl, docPdf);
                    firmaDigitale.Avvio();

                    //mettiamo in sessione la firma digitale creata per poi riprenderla
                    Session["FirmaDigitale"] = firmaDigitale;
                }
                else
                {
                    Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                }
            }
        
        }

    }
}
