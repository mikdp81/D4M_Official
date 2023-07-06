// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModContratto.aspx.cs" company="">
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
using System.IO;
using BusinessLogic.Services.blob;

namespace DFleet.Admin.Modules.Ordini
{
    public partial class ModContratto : System.Web.UI.Page
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
            pnlMessage.Visible = false;
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    hduid.Value = Convert.ToString(uid, CultureInfo.CurrentCulture);

                    IContratti data = servizioContratti.DetailOrdiniId(uid);
                    if (data != null)
                    {
                        lblDatiRiepilogo.Text += "<div class='table-responsive'><table class='table'>";

                        IAccount data2 = servizioAccount.DetailId(data.UserId);
                        if (data2 != null)
                        {
                            lblDatiRiepilogo.Text += "<tr><td class='width30p nopadding'>Driver</td> <td class='width70p nopadding'> " + data2.Cognome + " " + data2.Nome + "</td></tr>";
                        }

                        lblDatiRiepilogo.Text += "<tr><td class='width30p nopadding'>Societ&agrave;</td> <td class='width70p nopadding'> " + data.Societa + "</td></tr>";
                        lblDatiRiepilogo.Text += "<tr><td class='width30p nopadding'>Codjatoauto</td> <td class='width70p nopadding'> " + data.Codjatoauto + "</td></tr>";
                        lblDatiRiepilogo.Text += "<tr><td class='width30p nopadding'>Cod Carpolicy</td> <td class='width70p nopadding'> " + data.Codcarpolicy + "</td></tr>";
                        lblDatiRiepilogo.Text += "<tr><td class='width30p nopadding'>Cod Carlist</td> <td class='width70p nopadding'> " + data.Codcarlist + "</td></tr>";
                        lblDatiRiepilogo.Text += "<tr><td class='width30p nopadding'>Fornitore</td> <td class='width70p nopadding'> " + data.Codfornitore + "</td></tr>";
                        lblDatiRiepilogo.Text += "<tr><td class='width30p nopadding'>Numero ordine</td> <td class='width70p nopadding'> " + data.Numeroordine + "</td></tr>";
                        lblDatiRiepilogo.Text += "<tr><td class='width30p nopadding'>Canone Leasing Offerta</td> <td class='width70p nopadding'> " + data.Canoneleasingofferta + "</td></tr>";
                        lblDatiRiepilogo.Text += "<tr><td class='width30p nopadding'>Deltacanone</td> <td class='width70p nopadding'> " + data.Deltacanone + "</td></tr>";
                        lblDatiRiepilogo.Text += "</table></div>";

                    }
                }
                else
                {
                    Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                }
            }
        }


        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = new Guid(hduid.Value);

            IContratti contrattoNew = new Contratti();

            IContratti data = servizioContratti.DetailOrdiniId(Uid);
            if (data != null)
            {
                contrattoNew.Codsocieta = data.Codsocieta;
                contrattoNew.UserId = data.UserId;
                contrattoNew.Codjatoauto = data.Codjatoauto;
                contrattoNew.Codcarpolicy = data.Codcarpolicy;
                contrattoNew.Codcarlist = data.Codcarlist;
                contrattoNew.Codfornitore = data.Codfornitore;
                contrattoNew.Numordineordine = data.Numeroordine;
                contrattoNew.Canoneleasing = data.Canoneleasingofferta;
                contrattoNew.Deltacanone = data.Deltacanone;
            }
                        
            contrattoNew.Codtipocontratto = SeoHelper.EncodeString(ddlCodTipoContratto.SelectedValue);
            contrattoNew.Codtipousocontratto = SeoHelper.EncodeString(ddlCodTipoUsoContratto.SelectedValue);
            contrattoNew.Numerocontratto = SeoHelper.EncodeString(txtNumeroContratto.Text);
            contrattoNew.Datacontratto = SeoHelper.DataString(txtDataContratto.Text);
            contrattoNew.Datainiziocontratto = SeoHelper.DataString(txtDatainiziocontratto.Text);
            contrattoNew.Datainiziouso = SeoHelper.DataString(txtDatainiziouso.Text);
            contrattoNew.Datafinecontratto = SeoHelper.DataString(txtDatafinecontratto.Text);
            contrattoNew.Duratamesi = SeoHelper.IntString(txtDurataMesi.Text);
            contrattoNew.Kmcontratto = SeoHelper.IntString(txtKmContratto.Text);
            contrattoNew.Franchigia = SeoHelper.DecimalString(txtFranchigia.Text);
            contrattoNew.Annotazionicontratto = SeoHelper.EncodeString(txtAnnotazionicontratto.Text);
            contrattoNew.Targa = SeoHelper.EncodeString(txtTarga.Text);
            contrattoNew.Dataimmatricolazione = SeoHelper.DataString(txtDataimmatricolazione.Text);
            contrattoNew.Scadenzabollo = SeoHelper.DataString(txtScadenzaBollo.Text);
            contrattoNew.Scadenzasuperbollo = SeoHelper.DataString(txtScadenzaSuperBollo.Text);
            contrattoNew.Bollo = SeoHelper.DecimalString(txtBollo.Text);
            contrattoNew.Superbollo = SeoHelper.DecimalString(txtSuperBollo.Text);
            contrattoNew.Emissioni = SeoHelper.DecimalString(txtEmissioni.Text);
            contrattoNew.Datacontratto = DateTime.Now;
            contrattoNew.Idstatuscontratto = 0;
            contrattoNew.Uidordine = Uid;
            contrattoNew.Idtipoassegnazione = SeoHelper.IntString(ddlTipoAssegnazione.SelectedValue);
            contrattoNew.Canonefinanziario = SeoHelper.DecimalString(txtCanoneFinanziario.Text);
            contrattoNew.Canoneservizi = SeoHelper.DecimalString(txtCanoneServizi.Text);
            contrattoNew.Costokmeccedente = SeoHelper.DecimalString(txtCostokmeccedente.Text);
            contrattoNew.Costokmrimborso = SeoHelper.DecimalString(txtCostokmrimborso.Text);
            contrattoNew.Sogliakm = SeoHelper.DecimalString(txtSogliakm.Text);
            contrattoNew.Uidtenant = SeoHelper.ReturnSessionTenant();

            string error = string.Empty;
            bool controlTipoFile;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/contratti/";


            // controllo la dimensione del file
            if (fuFileContratto.HasFile == false)
            {
                controlTipoFile = false;
                error += "File contratto non caricato";
            }
            else
            {
                if (fuFileContratto.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    error += "Il file non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
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
                        Guid UidContratto = Guid.Empty;
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

                        //da ordine a contratto
                        if (servizioContratti.UpdateChangeStatusOrdine(Uid, 60, "", SeoHelper.ReturnSessionTenant()) == 1)
                        {
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
                                    Codsocieta = contrattoNew.Codsocieta
                                };

                                //recupero ultimo idcontratto
                                IContratti dataContr = servizioContratti.ReturnUltimoIdContratto();
                                if (dataContr != null)
                                {
                                    //inserisci nuova assegnazione contratto
                                    contrattoNew3.Idcontratto = dataContr.Idcontratto;
                                    UidContratto = dataContr.Uid;

                                    servizioContratti.InsertInizioAssegnazioneContratto(contrattoNew3);
                                }

                                ILogBL log = new LogBL();
                                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Trasforma Ordine in Contratto " + Uid);

                                //messaggio avvenuta cancellazione
                                //pnlMessage.Visible = true;
                                //pnlMessage.CssClass = "alert alert-success";
                                //lblMessage.Text = "L'Ordine &egrave; stato trasformato in Contratto<br /> <a href='" + ResolveUrl("~/Admin/Modules/Ordini/RichiesteOrdini") + "'>Ritorna alla Lista</a>";


                                Response.Redirect(ResolveUrl("~/Admin/Modules/Contratto/EditContratti-" + UidContratto));

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
