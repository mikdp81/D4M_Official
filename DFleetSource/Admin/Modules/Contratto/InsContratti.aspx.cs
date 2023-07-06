// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsContratti.aspx.cs" company="">
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
    public partial class InsContratti : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(41)) //controllo se la pagina è autorizzata per l'utente 
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
            InsertContratto("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertContratto("salvachiudi");
        }

        public void InsertContratto(string opzione)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            IContratti contrattoNew = new Contratti
            {
                Codsocieta = SeoHelper.EncodeString(Request.Form[ddlCodsocieta.UniqueID].ToString()),
                UserId = SeoHelper.GuidString(Request.Form[ddlUsers.UniqueID].ToString()),
                Codjatoauto = SeoHelper.EncodeString(Request.Form[ddlCodjatoAuto.UniqueID].ToString()),
                Codcarpolicy = SeoHelper.EncodeString(Request.Form[ddlCodCarPolicy.UniqueID].ToString()),
                Codcarlist = SeoHelper.EncodeString(Request.Form[ddlCodCarList.UniqueID].ToString()),
                Codfornitore = SeoHelper.EncodeString(Request.Form[ddlFornitore.UniqueID].ToString()),
                Codtipocontratto = SeoHelper.EncodeString(ddlCodTipoContratto.SelectedValue),
                Codtipousocontratto = SeoHelper.EncodeString(ddlCodTipoUsoContratto.SelectedValue),
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
                Idstatuscontratto = SeoHelper.IntString(ddlstatus.SelectedValue),
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Dataimmatricolazione = SeoHelper.DataString(txtDataimmatricolazione.Text),
                Scadenzabollo = SeoHelper.DataString(txtScadenzaBollo.Text),
                Scadenzasuperbollo = SeoHelper.DataString(txtScadenzaSuperBollo.Text),
                Bollo = SeoHelper.DecimalString(txtBollo.Text),
                Superbollo = SeoHelper.DecimalString(txtSuperBollo.Text),
                Uidordine = Guid.Empty,
                Flgvoltura = 0,
                Notevoltura = "",
                Uidcontrattovolturato = Guid.Empty,
                Idtipoassegnazione = SeoHelper.IntString(ddlTipoAssegnazione.SelectedValue),
                Emissioni = SeoHelper.DecimalString(txtEmissioni.Text),
                Deltacanone = SeoHelper.DecimalString(txtDeltaCanone.Text),
                Canonefinanziario = SeoHelper.DecimalString(txtCanoneFinanziario.Text),
                Canoneservizi = SeoHelper.DecimalString(txtCanoneServizi.Text),
                Costokmeccedente = SeoHelper.DecimalString(txtCostokmeccedente.Text),
                Costokmrimborso = SeoHelper.DecimalString(txtCostokmrimborso.Text),
                Sogliakm = SeoHelper.DecimalString(txtSogliakm.Text),
                Datarevisione = SeoHelper.DataString(txtDatarevisione.Text),
                Codcolore = SeoHelper.EncodeString(ddlColore.SelectedValue),
                Canonefigurativo = SeoHelper.DecimalString(txtCanoneFigurativo.Text),
                Codutilizzo = SeoHelper.EncodeString(ddlTipoUtilizzo.SelectedValue),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;
            bool controlTipoFile = false;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/contratti/";


            if (string.IsNullOrEmpty(contrattoNew.Codsocieta))
            {
                ddlCodsocieta.CssClass = "form-control select2 ddlSocieta is-invalid";
                error += "inserire un valore valido per il campo Societ&agrave;<br />";
            }
            else
            {
                ddlCodsocieta.CssClass = "form-control select2 ddlSocieta";
            }

            if (contrattoNew.UserId == Guid.Empty)
            {
                ddlUsers.CssClass = "form-control select2 ddlUtente is-invalid";
                error += "inserire un valore valido per il campo Utente<br />";
            }
            else
            {
                ddlUsers.CssClass = "form-control select2 ddlUtente";
            }

            if (string.IsNullOrEmpty(contrattoNew.Codjatoauto))
            {
                ddlCodjatoAuto.CssClass = "form-control select2 ddlAuto is-invalid";
                error += "inserire un valore valido per il campo Codjato auto<br />";
            }
            else
            {
                ddlCodjatoAuto.CssClass = "form-control select2 ddlAuto";
            }

            if (string.IsNullOrEmpty(contrattoNew.Codfornitore))
            {
                ddlFornitore.CssClass = "form-control select2 ddlFornitore is-invalid";
                error += "inserire un valore valido per il campo Codice fornitore<br />";
            }
            else
            {
                ddlFornitore.CssClass = "form-control select2 ddlFornitore";
            }

            if (contrattoNew.Idstatuscontratto == -1)
            {
                ddlstatus.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Status contratto<br />";
            }
            else
            {
                ddlstatus.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Codcarlist))
            {
                ddlCodCarList.CssClass = "form-control select2 ddlCarList is-invalid";
                error += "inserire un valore valido per il campo Car List<br />";
            }
            else
            {
                ddlCodCarList.CssClass = "form-control select2 ddlCarList";
            }

            if (string.IsNullOrEmpty(contrattoNew.Codcarpolicy))
            {
                ddlCodCarPolicy.CssClass = "form-control select2 ddlCarPolicy is-invalid";
                error += "inserire un valore valido per il campo Car Policy<br />";
            }
            else
            {
                ddlCodCarPolicy.CssClass = "form-control select2 ddlCarPolicy";
            }

            if (string.IsNullOrEmpty(contrattoNew.Codfornitore))
            {
                ddlFornitore.CssClass = "form-control select2 ddlFornitore is-invalid";
                error += "inserire un valore valido per il campo Codice fornitore<br />";
            }
            else
            {
                ddlFornitore.CssClass = "form-control select2 ddlFornitore";
            }

            if (string.IsNullOrEmpty(contrattoNew.Targa))
            {
                txtTarga.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Targa<br />";
            }
            else
            {
                //controllo se targa è gia esistente
                if (servizioContratti.ExistTargaAss(contrattoNew.Targa))
                {
                    txtTarga.CssClass = "form-control is-invalid";
                    error += "Targa gi&agrave; esistente<br />";

                }
                else
                {
                    txtTarga.CssClass = "form-control";
                }

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
                            //assegnazione contratto nuovo
                            IContratti contrattoNew3 = new Contratti
                            {
                                UserId = contrattoNew.UserId,
                                Targa = contrattoNew.Targa,
                                Assegnatodal = contrattoNew.Datainiziocontratto,
                                Assegnatoal = contrattoNew.Datafinecontratto,
                                Idstatusassegnazione = 0,
                                Codsocieta = contrattoNew.Codsocieta,
                                Uidtenant = SeoHelper.ReturnSessionTenant()
                            };

                            //recupero ultimo idcontratto
                            IContratti dataContr = servizioContratti.ReturnUltimoIdContratto();
                            if (dataContr != null)
                            {
                                //inserisci nuova assegnazione contratto
                                contrattoNew3.Idcontratto = dataContr.Idcontratto;

                                servizioContratti.InsertInizioAssegnazioneContratto(contrattoNew3);
                            }

                            ILogBL log = new LogBL();
                            log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + contrattoNew.Numerocontratto);


                            if (opzione.ToUpper() == "SALVANUOVO")
                            {
                                //reset campi
                                ddlCodsocieta.ClearSelection();
                                ddlUsers.ClearSelection();
                                ddlCodjatoAuto.ClearSelection();
                                ddlCodCarPolicy.ClearSelection();
                                ddlCodCarList.ClearSelection();
                                ddlFornitore.ClearSelection();
                                ddlCodTipoContratto.ClearSelection();
                                ddlCodTipoUsoContratto.ClearSelection();
                                ddlTipoAssegnazione.ClearSelection();
                                ddlColore.ClearSelection();
                                txtNumeroOrdine.Text = "";
                                txtNumeroContratto.Text = "";
                                txtDataContratto.Text = "";
                                txtDurataMesi.Text = "";
                                txtKmContratto.Text = "";
                                txtFranchigia.Text = "";
                                txtDatainiziocontratto.Text = "";
                                txtDatainiziouso.Text = "";
                                txtDatafinecontratto.Text = "";
                                txtAnnotazionicontratto.Text = "";
                                txtCanoneleasing.Text = "";
                                ddlstatus.ClearSelection();
                                txtTarga.Text = "";
                                txtDataimmatricolazione.Text = "";
                                txtBollo.Text = "";
                                txtSuperBollo.Text = "";
                                txtScadenzaBollo.Text = "";
                                txtScadenzaSuperBollo.Text = "";
                                txtEmissioni.Text = "";
                                txtDeltaCanone.Text = "";
                                txtCanoneFinanziario.Text = "";
                                txtCanoneServizi.Text = "";
                                txtCostokmeccedente.Text = "";
                                txtCostokmrimborso.Text = "";
                                txtSogliakm.Text = "";
                                txtDatarevisione.Text = "";

                                ddlCodsocieta.CssClass = "form-control select2 ddlSocieta";
                                ddlUsers.CssClass = "form-control select2 ddlUtente";
                                ddlCodjatoAuto.CssClass = "form-control select2 ddlAuto";
                                ddlFornitore.CssClass = "form-control select2 ddlFornitore";
                                ddlCodCarPolicy.CssClass = "form-control select2 ddlCarPolicy";
                                ddlCodCarList.CssClass = "form-control select2 ddlCarList";
                                ddlstatus.CssClass = "form-control";
                                txtTarga.CssClass = "form-control";

                                //messaggio avvenuto inserimento
                                pnlMessage.Visible = true;
                                pnlMessage.CssClass = "alert alert-success";
                                lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuovo Contratto o <a href='" + ResolveUrl("~/Admin/Modules/Contratto/ViewContratti") + "'>Ritorna alla Lista</a>";
                            }
                            else
                            {
                                Response.Redirect("ViewContratti");
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
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Caricamento file non avvenuto. Ripetere l'operazione";
                }
            }
        }

    }
}
