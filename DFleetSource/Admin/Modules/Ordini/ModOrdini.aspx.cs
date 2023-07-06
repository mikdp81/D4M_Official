// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModOrdini.aspx.cs" company="">
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
using System.Collections.Generic;

namespace DFleet.Admin.Modules.Ordini
{
    public partial class ModOrdini : System.Web.UI.Page
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
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailOrdiniId(uid);
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
        private void BindData(IContratti data)
        {
            ICarsBL servizioCar = new CarsBL();
            string codjatoauto = "";
            string codcolore = "";

            //recupero uid codjatoauto
            ICars dataAuto = servizioCar.DetailCarListAutoId2(data.Codjatoauto, data.Codcarlist, data.Codfornitore);
            if (dataAuto != null)
            {
                codjatoauto = dataAuto.Uid.ToString();
            }

            //recupero codcolore
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            List<ICars> dataOpt = servizioCar.SelectAllColori("", Uidtenant);
            if (dataOpt != null && dataOpt.Count > 0)
            {
                foreach (ICars resultOpt in dataOpt)
                {
                    if (servizioCar.ExistOrdineOptionalAuto(data.Idordine, resultOpt.Codoptional))
                    {
                        codcolore = resultOpt.Codoptional;
                    }
                }
            }

            lblnumordine.Text = "N. " + data.Numeroordine;
            txtNumOrdineFornitore.Text = data.Numeroordinefornitore;
            ddlColore.SelectedValue = codcolore;
            ddlCodsocieta.SelectedValue = data.Codsocieta;
            ddlUsers.SelectedValue = Convert.ToString(data.UserId, CultureInfo.CurrentCulture);
            ddlCodjatoAuto.SelectedValue = codjatoauto;
            ddlCodFornitore.SelectedValue = data.Codfornitore;
            txtDataOrdine.Text = SeoHelper.CheckDataString(data.Dataordine);
            txtAnnotazioniordine.Text = data.Annotazioniordini;
            txtCanoneLeasing.Text = SeoHelper.CheckDecimalString(data.Canoneleasing);
            txtCanoneLeasingOfferta.Text = SeoHelper.CheckDecimalString(data.Canoneleasingofferta);
            txtOptionalCanone.Text = SeoHelper.CheckDecimalString(data.Deltacanone);
            txtSedeConsegna.Text = data.Sedelavoro;
            ddlstatus.SelectedValue = data.Idstatusordine.ToString();
            ddlCodCarPolicy.SelectedValue = data.Codcarpolicy;
            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
            txtDataConsegnaPrevista.Text = SeoHelper.CheckDataString(data.Dataconsegnaprevista);
            if (!string.IsNullOrEmpty(data.Fileconfermarental))
            {
                lblViewFileOffertaRenter.Text = "<a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Fileconfermarental + "\" target='_blank'>Apri File</a>";
            }
            if (!string.IsNullOrEmpty(data.Filefirma))
            {
                lblViewFileOffertaFirmata.Text = "<a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Filefirma + "\" target='_blank'>Apri File</a>";
            }
            hdFileOffertaFirmata.Value = data.Filefirma;
            hdFileOffertaRenter.Value = data.Fileconfermarental;
            txtAlimentazione.Text = data.Alimentazione;
        }
        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateOrdini("salvanuovo");
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateOrdini("salvachiudi");
        }

        public void UpdateOrdini(string opzione)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            ICarsBL servizioCar = new CarsBL();

            string codjatoauto = SeoHelper.EncodeString(Request.Form[ddlCodjatoAuto.UniqueID].ToString());

            IContratti ordineNew = new Contratti
            {
                Codsocieta = SeoHelper.EncodeString(Request.Form[ddlCodsocieta.UniqueID].ToString()),
                UserId = SeoHelper.GuidString(Request.Form[ddlUsers.UniqueID].ToString()),
                Codfornitore = SeoHelper.EncodeString(Request.Form[ddlCodFornitore.UniqueID].ToString()),
                Numeroordine = ReturnNumeroOrdine(),
                Dataordine = SeoHelper.DataString(txtDataOrdine.Text),
                Annotazioniordini = SeoHelper.EncodeString(txtAnnotazioniordine.Text),
                Idstatusordine = SeoHelper.IntString(ddlstatus.SelectedValue),
                Idapprovazione = 0,
                Canoneleasing = SeoHelper.DecimalString(txtCanoneLeasing.Text),
                Canoneleasingofferta = SeoHelper.DecimalString(txtCanoneLeasingOfferta.Text),
                Deltacanone = SeoHelper.DecimalString(txtOptionalCanone.Text),
                Sedelavoro = SeoHelper.EncodeString(txtSedeConsegna.Text),
                Uid = SeoHelper.GuidString(hduid.Value),
                Codcarpolicy = SeoHelper.EncodeString(ddlCodCarPolicy.SelectedValue),
                Dataconsegnaprevista = SeoHelper.DataString(txtDataConsegnaPrevista.Text),
                Alimentazione = SeoHelper.EncodeString(txtAlimentazione.Text),
                Numeroordinefornitore = SeoHelper.EncodeString(txtNumOrdineFornitore.Text)
            };

            ICars dataAuto = servizioCar.DetailCarListAutoId(SeoHelper.GuidString(codjatoauto));
            if (dataAuto != null)
            {
                ordineNew.Codjatoauto = dataAuto.Codjatoauto;
                ordineNew.Codcarlist = dataAuto.Codcarlist;
            }

            string error = string.Empty;
            bool controlTipoFile = false;
            bool controlFileLoad = false;
            bool controlFileLoad2 = false;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string fileExt2;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/ordini/";

            if (string.IsNullOrEmpty(codjatoauto))
            {
                error += "inserire un valore valido per il campo CodjatoAuto<br />";                
            }

            if (string.IsNullOrEmpty(ordineNew.Codfornitore))
            {
                ddlCodFornitore.CssClass = "form-control is-invalid select2 ddlFornitore";
                error += "inserire un valore valido per il campo Fornitore<br />";
            }
            else
            {
                ddlCodFornitore.CssClass = "form-control select2 ddlFornitore";
            }

            if (string.IsNullOrEmpty(ordineNew.Codsocieta))
            {
                ddlCodsocieta.CssClass = "form-control is-invalid select2";
                error += "inserire un valore valido per il campo Societ&agrave;<br />";
            }
            else
            {
                ddlCodsocieta.CssClass = "form-control select2";
            }

            if (ordineNew.UserId == Guid.Empty)
            {
                ddlUsers.CssClass = "form-control is-invalid select2";
                error += "scegliere un Driver<br />";
            }
            else
            {
                ddlUsers.CssClass = "form-control select2";
            }

            if (ordineNew.Idstatusordine == -1)
            {
                ddlstatus.CssClass = "form-control is-invalid select2";
                error += "inserire un valore valido per il campo Status ordine<br />";
            }
            else
            {
                ddlstatus.CssClass = "form-control select2";
            }



            if (fuFileOffertaFirmata.HasFile == false)
            {
                ordineNew.Filefirma = hdFileOffertaFirmata.Value;
                controlFileLoad = false;
            }
            else
            {
                if (fuFileOffertaFirmata.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad = true;
                    error += "Il file offerta firmata non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    if (fuFileOffertaFirmata.HasFile == true)
                    {
                        controlFileLoad = true;
                        fileExt = Path.GetExtension(fuFileOffertaFirmata.FileName).Substring(1);
                        //controllo estensione del file
                        if (!supportedTypes.Contains(fileExt))
                        {
                            controlTipoFile = false;
                            error += "Il file offerta firmata non può essere caricato perché non ha un'estensione .pdf";
                        }
                        else
                        {
                            controlTipoFile = true;
                        }
                    }
                }
            }

            if (fuFileOffertaRenter.HasFile == false)
            {
                ordineNew.Fileconfermarental = hdFileOffertaRenter.Value;
                controlFileLoad2 = false;
            }
            else
            {
                if (fuFileOffertaRenter.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlFileLoad = true;
                    controlFileLoad2 = false;
                    error += "Il file offerta renter non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    if (fuFileOffertaRenter.HasFile == true)
                    {
                        controlFileLoad2 = true;
                        fileExt2 = Path.GetExtension(fuFileOffertaRenter.FileName).Substring(1);
                        //controllo estensione del file
                        if (!supportedTypes.Contains(fileExt2))
                        {
                            controlTipoFile = false;
                            error += "Il file offerta renter non può essere caricato perché non ha un'estensione .pdf";
                        }
                        else
                        {
                            controlTipoFile = true;
                        }
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

                if (controlFileLoad || controlFileLoad2) //c'è un file da caricare
                {
                    if (controlTipoFile) //se i controlli sono corretti carica il file sul server
                    {
                        string filename = SeoHelper.OraAttuale() + "-" + fuFileOffertaFirmata.FileName;
                        string filename2 = SeoHelper.OraAttuale() + "-" + fuFileOffertaRenter.FileName;
                        // salviamo il file nel percorso calcolato

                        fuFileOffertaFirmata.SaveAs(filePath + filename);
                        fuFileOffertaRenter.SaveAs(filePath + filename2);
                        System.Threading.Thread.Sleep(1000);

                        //controllo virus scanner
                        var scanner = new AntiVirus.Scanner();
                        var resultS = scanner.ScanAndClean(filePath + filename);
                        var resultS2 = scanner.ScanAndClean(filePath + filename2);

                        if (resultS.ToString() != "VirusNotFound" && resultS2.ToString() != "VirusNotFound")
                        {
                            controlTrueFileLoad = false;
                        }
                        else
                        {
                            string containerName = "ordini";
                            string blobName = filename;
                            string blobName2 = filename2;
                            string fileName = filename;
                            string fileName2 = filename2;
                            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                            string sas = Global.sas;

                            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                            string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);
                            string resultBlob2 = azureBlobManager.UploadBlob(fileName2, blobName2, true);

                            Response.Write(resultBlob);
                            Response.Write(resultBlob2);

                            if (fuFileOffertaFirmata.HasFile == false)
                            {
                                ordineNew.Filefirma = hdFileOffertaFirmata.Value;
                            }
                            else
                            {
                                ordineNew.Filefirma = SeoHelper.EncodeString(filename);
                            }

                            if (fuFileOffertaRenter.HasFile == false)
                            {
                                ordineNew.Fileconfermarental = hdFileOffertaRenter.Value;
                            }
                            else
                            {
                                ordineNew.Fileconfermarental = SeoHelper.EncodeString(filename2);
                            }
                        }
                    }
                }



                if (!controlTrueFileLoad)
                {
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text = "Attenzione! Si sono verificati i seguenti errori:";
                    lblMessage.Text += "<br /><br /><b>E' stato trovato un virus nel file </b><br />";
                }
                else
                {

                    if (servizioContratti.UpdateOrdini2(ordineNew) == 1)
                    {
                        //recupero idordine inserito
                        IContratti data = servizioContratti.DetailOrdiniId(ordineNew.Uid);
                        if (data != null)
                        {
                            //inserimento colore
                            IContratti ColNew = new Contratti
                            {
                                Idordine = data.Idordine,
                                Codoptional = SeoHelper.EncodeString(ddlColore.SelectedValue),
                                Importooptional = 0
                            };

                            servizioContratti.InsertOrdineOptional(ColNew);

                        }



                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Aggiornamento " + ordineNew.Uid);


                        if (opzione.ToUpper() == "SALVANUOVO")
                        {
                            //messaggio avvenuto inserimento
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuovo Ordine o <a href='" + ResolveUrl("~/Admin/Modules/Ordini/RichiesteOrdini") + "'>Ritorna alla Lista</a>";
                        }
                        else
                        {
                            Response.Redirect("RichiesteOrdini");
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
        }

        public string ReturnNumeroOrdine()
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string retVal;

            IContratti data = servizioContratti.ReturnUltimoNumeroOrdine();
            if (data != null)
            {
                retVal = (data.Nconfigurazioni + 1).ToString();
            }
            else
            {
                retVal = "1";
            }

            return retVal;
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
    }
}
