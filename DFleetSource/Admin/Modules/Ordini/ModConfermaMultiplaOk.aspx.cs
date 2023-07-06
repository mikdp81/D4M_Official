// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModConfermaOk.aspx.cs" company="">
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
using BusinessLogic.Services.blob;

namespace DFleet.Admin.Modules.Ordini
{
    public partial class ModConfermaMultiplaOk : System.Web.UI.Page
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

            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                //mettiamo in sessione la firma digitale creata per poi riprenderla
                IFirmaDigitale firmaDigitale = (IFirmaDigitale)Session["FirmaDigitale"];
                //avvia download firma digitale
                firmaDigitale.DownloadFile();

                string filefirma = firmaDigitale.NomeFileFirmato();

                string containerName = "ordini";
                string blobName = filefirma;
                string fileName = filefirma;
                string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                string sas = Global.sas;

                AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                Response.Write(resultBlob);

                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {                    
                    //conferma dbs ordine
                    if (servizioContratti.UpdateChangeStatusOrdine(uid, 50, "", SeoHelper.ReturnSessionTenant()) == 1)
                    {
                        if (servizioContratti.UpdatePdfOrdineFirmato(uid, filefirma, (Guid)Membership.GetUser().ProviderUserKey, SeoHelper.ReturnSessionTenant()) == 1)
                        {
                            ILogBL log = new LogBL();
                            log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Conferma Ordine Firmato da DBS " + uid);


                            //se ci sono altri ordini continua il loop di apertura docusign altrimenti riceve messaggio di conclusione)
                            if (!LoopOrdiniFirma())
                            {
                                //messaggio conclusione
                                pnlMessage.Visible = true;
                                pnlMessage.CssClass = "alert alert-success";
                                lblMessage.Text = "Operazione avvenuta correttamente<br />";
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
                else
                {
                    Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                }
            }
        
        }

        public bool LoopOrdiniFirma()
        {
            bool retVal = false;

            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            //prima firma dell'elenco
            IContratti dataUid = servizioContratti.ReturnOrdineFirma(Uidtenant);
            if (dataUid != null)
            {
                string returnUrl = "";
                string docPdf = "";

                IContratti data = servizioContratti.DetailOrdiniId(dataUid.Uid);
                if (data != null)
                {
                    docPdf = data.Fileconfermarental;
                    returnUrl = "https://" + HttpContext.Current.Request.Url.Host + "/Admin/Modules/Ordini/ModConfermaMultiplaOk-" + dataUid.Uid.ToString();
                }

                retVal = true;

                // CREARE
                UserConfig userConfig = new UserConfig();

                IAccount dataUser = servizioAccount.DetailId(UserId);
                if (dataUser != null)
                {
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

            return retVal;
        }

    }
}
