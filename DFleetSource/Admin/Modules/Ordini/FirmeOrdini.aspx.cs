// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="FirmeOrdini.aspx.cs" company="">
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
using FirmaDigitale;

namespace DFleet.Admin.Modules.Ordini
{
    public partial class FirmeOrdini : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(50)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadPage();
            loadPage2();
        }
        protected void btnCerca_Click(object sender, EventArgs e)
        {
            loadPage();
        }
        protected void btnCerca2_Click(object sender, EventArgs e)
        {
            loadPage2();
        }

        public void loadPage()
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;
            string search = SeoHelper.EncodeString(txtSearch.Text);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue);
            string codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
            string codcarlist = SeoHelper.EncodeString(ddlCodCarList.SelectedValue);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountOrdiniDaFirmare(search, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;
            int pagina;

            if (string.IsNullOrEmpty(hdPagina.Value))
            {
                pagina = 1;
                hdPagina.Value = "1";
            }
            else
            {
                pagina = Convert.ToInt32(hdPagina.Value, CultureInfo.CurrentCulture);
            }


            if (gvRicOrdini.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicOrdini.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            if (totaleRighe == 0)
            {
                lblMessage.Text = "Nessun dato disponibile. Ricerca con altri parametri.";
                pnlMessage.Visible = true;
            }
            else
            {
                pnlMessage.Visible = false;
            }


            lblNumRecord.Text = "Ordini da firmare: " + HttpUtility.HtmlEncode(totaleRighe);
            if (totaleRighe == 0)
            {
                lblMessage.Text = "Nessun dato disponibile. Ricerca con altri parametri.";
                pnlMessage.Visible = true;
            }
            else
            {
                pnlMessage.Visible = false;
            }

            if ((pagina - 1) <= 1)
            {
                pagingprec.Enabled = false;
                pagingprec.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingprec.Enabled = true;
                pagingprec.CssClass = "paginate_button";
            }

            if (maxPage < (pagina + 1))
            {
                pagingnext.Enabled = false;
                pagingnext.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingnext.Enabled = true;
                pagingnext.CssClass = "paginate_button";
            }
        }
        public void loadPage2()
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage2.Visible = false;
            string search = SeoHelper.EncodeString(txtSearch2.Text);
            Guid UserId = SeoHelper.GuidString(hdusers2.Value);
            string codsocieta = SeoHelper.EncodeString(ddlCodSocieta2.SelectedValue);
            string codgrade = SeoHelper.EncodeString(ddlCodGrade2.SelectedValue);
            string codcarlist = SeoHelper.EncodeString(ddlCodCarList2.SelectedValue);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore2.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal2.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal2.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord2.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountOrdiniFirmati(search, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;
            int pagina;

            if (string.IsNullOrEmpty(hdPagina2.Value))
            {
                pagina = 1;
                hdPagina2.Value = "1";
            }
            else
            {
                pagina = Convert.ToInt32(hdPagina2.Value, CultureInfo.CurrentCulture);
            }


            if (gvOrdini2.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvOrdini2.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            if (totaleRighe == 0)
            {
                lblMessage2.Text = "Nessun dato disponibile. Ricerca con altri parametri.";
                pnlMessage2.Visible = true;
            }
            else
            {
                pnlMessage2.Visible = false;
            }


            lblNumRecord2.Text = "Ordini Firmati: " + HttpUtility.HtmlEncode(totaleRighe);
            if (totaleRighe == 0)
            {
                lblMessage2.Text = "Nessun dato disponibile. Ricerca con altri parametri.";
                pnlMessage2.Visible = true;
            }
            else
            {
                pnlMessage2.Visible = false;
            }

            if ((pagina - 1) <= 1)
            {
                pagingprec2.Enabled = false;
                pagingprec2.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingprec2.Enabled = true;
                pagingprec2.CssClass = "paginate_button";
            }

            if (maxPage < (pagina + 1))
            {
                pagingnext2.Enabled = false;
                pagingnext2.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingnext2.Enabled = true;
                pagingnext2.CssClass = "paginate_button";
            }
        }
        protected void btnSvuotaFiltri_Click(object sender, EventArgs e)
        {
            Response.Redirect("FirmeOrdini");
        }
        protected void btnSvuotaFiltri2_Click(object sender, EventArgs e)
        {
            Response.Redirect("FirmeOrdini#home2");
        }


        /********************** PAGINAZIONE **********************/
        protected void pagingprec_Click(object sender, EventArgs e)
        {
            int valore = Convert.ToInt32(hdPagina.Value, CultureInfo.CurrentCulture);
            Paginations("prec", valore);
        }

        protected void pagingnext_Click(object sender, EventArgs e)
        {
            int valore = Convert.ToInt32(hdPagina.Value, CultureInfo.CurrentCulture);
            Paginations("next", valore);
        }

        protected void txtnumpag_TextChanged(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string search = SeoHelper.EncodeString(txtSearch.Text);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue);
            string codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
            string codcarlist = SeoHelper.EncodeString(ddlCodCarList.SelectedValue);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountOrdiniDaFirmare(search, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;

            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string search = SeoHelper.EncodeString(txtSearch.Text);
            Guid UserId = SeoHelper.GuidString(hdusers.Value);
            string codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue);
            string codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
            string codcarlist = SeoHelper.EncodeString(ddlCodCarList.SelectedValue);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountOrdiniDaFirmare(search, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int pagina = 0;
            int tmppaginaprec = 0;
            int tmppaginanext = 0;

            switch (tipo.ToUpper())
            {
                case "PREC":
                    pagina = valore - 1;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;
                case "NEXT":
                    pagina = valore + 1;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;
                case "ELENCO":
                    pagina = valore;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;

            }


            if ((tmppaginaprec) < 1)
            {
                pagingprec.Enabled = false;
                pagingprec.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingprec.Enabled = true;
                pagingprec.CssClass = "paginate_button";
            }

            if (maxPage < (tmppaginanext))
            {
                pagingnext.Enabled = false;
                pagingnext.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingnext.Enabled = true;
                pagingnext.CssClass = "paginate_button";
            }

            hdPagina.Value = Convert.ToString(pagina, CultureInfo.CurrentCulture);
            txtnumpag.Text = Convert.ToString(pagina, CultureInfo.CurrentCulture);
        }



        protected void pagingprec2_Click(object sender, EventArgs e)
        {
            int valore = Convert.ToInt32(hdPagina2.Value, CultureInfo.CurrentCulture);
            Paginations2("prec", valore);
        }

        protected void pagingnext2_Click(object sender, EventArgs e)
        {
            int valore = Convert.ToInt32(hdPagina2.Value, CultureInfo.CurrentCulture);
            Paginations2("next", valore);
        }

        protected void txtnumpag2_TextChanged(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string search = SeoHelper.EncodeString(txtSearch2.Text);
            Guid UserId = SeoHelper.GuidString(hdusers2.Value);
            string codsocieta = SeoHelper.EncodeString(ddlCodSocieta2.SelectedValue);
            string codgrade = SeoHelper.EncodeString(ddlCodGrade2.SelectedValue);
            string codcarlist = SeoHelper.EncodeString(ddlCodCarList2.SelectedValue);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore2.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal2.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal2.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord2.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountOrdiniFirmati(search, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag2.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;

            Paginations2("elenco", valore);
        }

        public void Paginations2(string tipo, int valore)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string search = SeoHelper.EncodeString(txtSearch2.Text);
            Guid UserId = SeoHelper.GuidString(hdusers2.Value);
            string codsocieta = SeoHelper.EncodeString(ddlCodSocieta2.SelectedValue);
            string codgrade = SeoHelper.EncodeString(ddlCodGrade2.SelectedValue);
            string codcarlist = SeoHelper.EncodeString(ddlCodCarList2.SelectedValue);
            string codfornitore = SeoHelper.EncodeString(ddlFornitore2.SelectedValue);
            DateTime datadal = SeoHelper.DataString(txtDatadal2.Text);
            DateTime dataal = SeoHelper.DataString(txtDataal2.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord2.SelectedValue);
            int totaleRighe = servizioContratti.SelectCountOrdiniFirmati(search, codsocieta, codgrade, codcarlist, codfornitore, datadal, dataal, UserId, Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int pagina = 0;
            int tmppaginaprec = 0;
            int tmppaginanext = 0;

            switch (tipo.ToUpper())
            {
                case "PREC":
                    pagina = valore - 1;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;
                case "NEXT":
                    pagina = valore + 1;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;
                case "ELENCO":
                    pagina = valore;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;

            }


            if ((tmppaginaprec) < 1)
            {
                pagingprec2.Enabled = false;
                pagingprec2.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingprec2.Enabled = true;
                pagingprec2.CssClass = "paginate_button";
            }

            if (maxPage < (tmppaginanext))
            {
                pagingnext2.Enabled = false;
                pagingnext2.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingnext2.Enabled = true;
                pagingnext2.CssClass = "paginate_button";
            }

            hdPagina2.Value = Convert.ToString(pagina, CultureInfo.CurrentCulture);
            txtnumpag2.Text = Convert.ToString(pagina, CultureInfo.CurrentCulture);
        }

        /********************** FINE PAGINAZIONE **********************/



        protected void btnFirmaMultipla_Click(object sender, EventArgs e)
        {
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
        }
    }
}
