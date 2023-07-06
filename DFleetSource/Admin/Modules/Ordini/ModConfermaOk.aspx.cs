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
    public partial class ModConfermaOk : System.Web.UI.Page
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


                            //messaggio avvenuta cancellazione
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Operazione avvenuta correttamente<br /> <a href='" + ResolveUrl("~/Admin/Modules/Ordini/FirmeOrdini") + "'>Ritorna alla Lista</a>";
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

    }
}
