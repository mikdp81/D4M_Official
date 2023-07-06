// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsVoltura.aspx.cs" company="">
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
using System.IO;
using System.Linq;
using BusinessLogic.Services.blob;

namespace DFleet.Admin.Modules.Contratto
{
    public partial class InsVoltura : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(42)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
            pnlStep1.Visible = true;
            pnlModo1.Visible = false;
            pnlModo2.Visible = false;
            pnlModo3.Visible = false;
        }

        protected void btnModo1_Click(object sender, EventArgs e)
        {
            pnlStep1.Visible = false;
            pnlModo1.Visible = true;
            pnlModo2.Visible = false;
            pnlModo3.Visible = false;

        }

        protected void btnModo2_Click(object sender, EventArgs e)
        {
            pnlStep1.Visible = false;
            pnlModo1.Visible = false;
            pnlModo2.Visible = true;
            pnlModo3.Visible = false;

        }

        protected void btnModo3_Click(object sender, EventArgs e)
        {
            pnlStep1.Visible = false;
            pnlModo1.Visible = false;
            pnlModo2.Visible = false;
            pnlModo3.Visible = true;

        }

        protected void btnInserisci1_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlStep1.Visible = false;
            pnlModo1.Visible = true;
            pnlModo2.Visible = false;
            pnlModo3.Visible = false;
            string error = string.Empty;

            if (SeoHelper.GuidString(ddlContratto.SelectedValue) == Guid.Empty)
            {
                ddlContratto.CssClass = "form-control is-invalid";
                error += "Selezionare un contratto<br />";
            }
            else
            {
                ddlContratto.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(ddlCodSocieta2.SelectedValue))
            {
                ddlCodSocieta2.CssClass = "form-control is-invalid";
                error += "Selezionare una societ&agrave;<br />";
            }
            else
            {
                ddlCodSocieta2.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(txtNumeroContratto2.Text))
            {
                txtNumeroContratto2.CssClass = "form-control is-invalid";
                error += "Inserire un valore valido per il campo Numero contratto<br />";
            }
            else
            {
                txtNumeroContratto2.CssClass = "form-control";
            }

            if (SeoHelper.DataString(txtDatainiziouso2.Text) == DateTime.MinValue)
            {
                txtDatainiziouso2.CssClass = "form-control is-invalid";
                error += "Inserire un valore valido per il campo Data inizio contratto<br />";
            }
            else
            {
                txtDatainiziouso2.CssClass = "form-control";
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
                //riprende dati contratto e inserisce nuova riga
                IContratti data = servizioContratti.DetailContrattiId(SeoHelper.GuidString(ddlContratto.SelectedValue));
                if (data != null)
                {
                    IContratti contrattoNew = new Contratti
                    {
                        Codsocieta = SeoHelper.EncodeString(ddlCodSocieta2.SelectedValue),
                        UserId = data.UserId,
                        Codjatoauto = data.Codjatoauto,
                        Codcarpolicy = data.Codcarpolicy,
                        Codcarlist = data.Codcarlist,
                        Codfornitore = data.Codfornitore,
                        Codtipocontratto = data.Codtipocontratto,
                        Codtipousocontratto = data.Codtipousocontratto,
                        Numordineordine = data.Numordineordine,
                        Numerocontratto = SeoHelper.EncodeString(txtNumeroContratto2.Text),
                        Datacontratto = SeoHelper.DataString(txtDatainiziouso2.Text),
                        Duratamesi = data.Duratamesi,
                        Kmcontratto = data.Kmcontratto,
                        Franchigia = data.Franchigia,
                        Datainiziocontratto = SeoHelper.DataString(txtDatainiziouso2.Text),
                        Datainiziouso = SeoHelper.DataString(txtDatainiziouso2.Text),
                        Datafinecontratto = data.Datafinecontratto,
                        Annotazionicontratto = data.Annotazionicontratto,
                        Canoneleasing = data.Canoneleasing,
                        Idstatuscontratto = 40,
                        Targa = data.Targa,
                        Dataimmatricolazione = data.Dataimmatricolazione,
                        Scadenzabollo = data.Scadenzabollo,
                        Scadenzasuperbollo = data.Scadenzasuperbollo,
                        Bollo = data.Bollo,
                        Superbollo = data.Superbollo,
                        Filecontratto = data.Filecontratto,
                        Uidordine = Guid.Empty,
                        Flgvoltura = 1,
                        Notevoltura = "",
                        Uidcontrattovolturato = data.Uid,
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };

                    if (servizioContratti.InsertContratti(contrattoNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento voltura " + contrattoNew.Numerocontratto);

                        Response.Redirect("InsVolturaOk");
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

        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlStep1.Visible = false;
            pnlModo1.Visible = false;
            pnlModo2.Visible = true;
            pnlModo3.Visible = false;

            IContratti contrattoNew = new Contratti
            {
                Codsocieta = SeoHelper.EncodeString(ddlCodsocieta.SelectedValue),
                UserId = SeoHelper.GuidString(ddlUsers.SelectedValue),
                Codjatoauto = SeoHelper.EncodeString(txtCodjatoAuto.Text),
                Codcarpolicy = SeoHelper.EncodeString(txtCodcarpolicy.Text),
                Codcarlist = SeoHelper.EncodeString(txtCodcarlist.Text),
                Codfornitore = SeoHelper.EncodeString(ddlFornitore.SelectedValue),
                Codtipocontratto = SeoHelper.EncodeString(txtCodtipocontratto.Text),
                Codtipousocontratto = SeoHelper.EncodeString(txtCodtipousocontratto.Text),
                Numordineordine = SeoHelper.EncodeString(txtNumeroOrdine.Text),
                Numerocontratto = SeoHelper.EncodeString(txtNumeroContratto.Text),
                Datacontratto = SeoHelper.DataString(txtDataContratto.Text),
                Duratamesi = SeoHelper.IntString(txtDurataMesi.Text),
                Kmcontratto = SeoHelper.IntString(txtKmContratto.Text),
                Franchigia = SeoHelper.DecimalString(txtFranchigia.Text),
                Datainiziocontratto = SeoHelper.DataString(txtDatainiziocontratto.Text),
                Datainiziouso = SeoHelper.DataString(txtDatainiziouso.Text),
                Datafinecontratto = SeoHelper.DataString(txtDatafinecontratto.Text),
                Annotazionicontratto = SeoHelper.EncodeString(txtAnnotazionicontratto.Text),
                Canoneleasing = SeoHelper.DecimalString(txtCanoneleasing.Text),
                Idstatuscontratto = 40,
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Dataimmatricolazione = SeoHelper.DataString(txtDataimmatricolazione.Text),
                Scadenzabollo = SeoHelper.DataString(txtScadenzaBollo.Text),
                Scadenzasuperbollo = SeoHelper.DataString(txtScadenzaSuperBollo.Text),
                Bollo = SeoHelper.DecimalString(txtBollo.Text),
                Superbollo = SeoHelper.DecimalString(txtSuperBollo.Text),
                Uidordine = Guid.Empty,
                Flgvoltura = 1,
                Notevoltura = "",
                Uidcontrattovolturato = Guid.Empty,
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;
            bool controlTipoFile;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/contratti/";


            if (string.IsNullOrEmpty(contrattoNew.Codsocieta))
            {
                ddlCodsocieta.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Societ&agrave;<br />";
            }
            else
            {
                ddlCodsocieta.CssClass = "form-control";
            }

            if (contrattoNew.UserId == Guid.Empty)
            {
                ddlUsers.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice fornitore<br />";
            }
            else
            {
                ddlUsers.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Codjatoauto))
            {
                txtCodjatoAuto.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codjato auto<br />";
            }
            else
            {
                txtCodjatoAuto.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Codfornitore))
            {
                ddlFornitore.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codice fornitore<br />";
            }
            else
            {
                ddlFornitore.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Numerocontratto))
            {
                txtNumeroContratto.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Numero contratto<br />";
            }
            else
            {
                txtNumeroContratto.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Targa))
            {
                txtTarga.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Targa<br />";
            }
            else
            {
                txtTarga.CssClass = "form-control";
            }



            // controllo la dimensione del file
            if (fuFileContratto.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
            {
                controlTipoFile = false;
                error += "Il file non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
            }
            else
            {
                if (fuFileContratto.HasFile == true)
                {
                    fileExt = Path.GetExtension(fuFileContratto.FileName).Substring(1);

                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        controlTipoFile = false;
                        error += "Il file non può essere caricato perché non ha un'estensione .pdf";
                    }
                    else
                    {
                        controlTipoFile = true;
                    }
                }
                else
                {
                    controlTipoFile = true;
                }
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
                if (controlTipoFile) //se i controlli sono corretti carica il file sul server
                {
                    string filename = SeoHelper.OraAttuale() + "-" + fuFileContratto.FileName;
                    // salviamo il file nel percorso calcolato
                    filePath += filename;
                    fuFileContratto.SaveAs(filePath);
                    System.Threading.Thread.Sleep(1000);

                    //controllo virus scanner
                    var scanner = new AntiVirus.Scanner();
                    var resultS = scanner.ScanAndClean(filePath);

                    if (resultS.ToString() != "VirusNotFound")
                    {
                        pnlMessage.CssClass = "alert alert-danger";
                        lblMessage.Text = "Attenzione! Si sono verificati i seguenti errori:";
                        lblMessage.Text += "<br /><br /><b>E' stato trovato un virus nel file " + filename + "</b><br />";
                    }
                    else
                    {
                        string containerName = "contratti";
                        string blobName = filename;
                        string fileName = filename;
                        string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/contratti/";
                        string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/contratti/";
                        string sas = Global.sas;

                        AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                        string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                        Response.Write(resultBlob);

                        contrattoNew.Filecontratto = filename;

                        if (servizioContratti.InsertContratti(contrattoNew) == 1)
                        {
                            ILogBL log = new LogBL();
                            log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento voltura " + contrattoNew.Numerocontratto);

                            Response.Redirect("InsVolturaOk");
                        }
                        else
                        {
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-danger";
                            lblMessage.Text += "Operazione fallita";
                        }
                    }
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Caricamento file non avvenuto. Ripetere l'operazione";
                }
            }
        }

        protected void btnInserisci3_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlStep1.Visible = false;
            pnlModo1.Visible = false;
            pnlModo2.Visible = false;
            pnlModo3.Visible = true;
            string error = string.Empty;

            if (SeoHelper.GuidString(ddlContratto2.SelectedValue) == Guid.Empty)
            {
                ddlContratto2.CssClass = "form-control is-invalid";
                error += "Selezionare un contratto<br />";
            }
            else
            {
                ddlContratto2.CssClass = "form-control";
            }

            if (SeoHelper.DataString(txtDatafinecontratto2.Text) == DateTime.MinValue)
            {
                txtDatafinecontratto2.CssClass = "form-control is-invalid";
                error += "Inserire un valore valido per il campo Data fine contratto<br />";
            }
            else
            {
                txtDatafinecontratto2.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(txtAnnotazioniVoltura.Text))
            {
                txtAnnotazioniVoltura.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Annotazioni voltura<br />";
            }
            else
            {
                txtAnnotazioniVoltura.CssClass = "form-control";
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

                IContratti contrattoNew = new Contratti
                {
                    Datafinecontratto = SeoHelper.DataString(txtDatafinecontratto2.Text),
                    Idstatuscontratto = 40,
                    Flgvoltura = 1,
                    Notevoltura = SeoHelper.EncodeString(txtAnnotazioniVoltura.Text),
                    Uid = SeoHelper.GuidString(ddlContratto2.SelectedValue),
                    Uidcontrattovolturato = SeoHelper.GuidString(ddlContratto2.SelectedValue)
                };

                if (servizioContratti.UpdateContrattiXVoltura(contrattoNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title,"Inserimento voltura " + ddlContratto2.SelectedValue);


                    Response.Redirect("InsVolturaOk");
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
}
