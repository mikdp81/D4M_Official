// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsOrdini.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Ordini
{
    public partial class InsOrdini : System.Web.UI.Page
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
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            InsertOrdine("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertOrdine("salvachiudi");
        }

        public void InsertOrdine(string opzione)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            ICarsBL servizioCar = new CarsBL();

            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
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
                Alimentazione = SeoHelper.EncodeString(txtAlimentazione.Text),
                Numeroordinefornitore = SeoHelper.EncodeString(txtNumOrdineFornitore.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            ICars dataAuto = servizioCar.DetailCarListAutoId(SeoHelper.GuidString(codjatoauto));
            if (dataAuto != null)
            {
                ordineNew.Codjatoauto = dataAuto.Codjatoauto;
                ordineNew.Codcarlist = dataAuto.Codcarlist;
            }

            //recupero codsocieta e grade per inserimento cod carpolicy
            IAccount dataUt = servizioAccount.DetailId(UserId);
            if (dataUt != null)
            {
                ordineNew.Codcarpolicy = ReturnCodCarPolicy(dataUt.Codsocieta, dataUt.Gradecode);
            }


            string error = string.Empty;
            bool controlTipoFile = false;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string fileExt2;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/ordini/";

            if (string.IsNullOrEmpty(codjatoauto))
            {
                if (string.IsNullOrEmpty(txtCodjatoAutoNew.Text))
                {
                    error += "inserire un valore valido per il campo CodjatoAuto<br />";
                }
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
                ddlUsers.CssClass = "form-control is-invalid select2 ddlUtente";
                error += "scegliere un Driver<br />";
            }
            else
            {
                ddlUsers.CssClass = "form-control select2 ddlUtente";
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


            if (fuFileOffertaFirmata.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
            {
                controlTipoFile = false;
                error += "Il file offerta firmata non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
            }
            else
            {
                if (fuFileOffertaFirmata.HasFile == true)
                {
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

            if (fuFileOffertaRenter.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
            {
                controlTipoFile = false;
                error += "Il file offerta renter non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
            }
            else
            {
                if (fuFileOffertaRenter.HasFile == true)
                {
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


            if (!string.IsNullOrEmpty(error))
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione. Il modulo non è stato compilato correttamente. Si sono verificati i seguenti errori:";
                lblMessage.Text += "<br /><br /><b>" + error + "</b><br />";
            }
            else
            {
                //se codjatoauto è vuoto inserisci nuovo modello auto in base ai dati nuovi 
                if (string.IsNullOrEmpty(ddlCodjatoAuto.SelectedValue))
                {
                    ICars carListNew = new Cars
                    {
                        Codcarlist = SeoHelper.EncodeString(ddlCodCarListNew.SelectedValue),
                        Codfornitore = SeoHelper.EncodeString(ddlFornitoreNew.SelectedValue),
                        Codjatoauto = SeoHelper.EncodeString(txtCodjatoAutoNew.Text),
                        Marca = SeoHelper.EncodeString(txtMarcaNew.Text),
                        Modello = SeoHelper.EncodeString(txtModelloNew.Text),
                        Canoneleasing = 0,
                        Fringebenefitbase = 0,
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };
                    servizioCar.InsertCarListAuto(carListNew);

                    ordineNew.Codjatoauto = carListNew.Codjatoauto;
                    ordineNew.Codfornitore = carListNew.Codfornitore;
                    ordineNew.Codcarlist = carListNew.Codcarlist;
                    ordineNew.Canoneleasing = 0;
                    ordineNew.Deltacanone = 0;
                }



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
                        pnlMessage.CssClass = "alert alert-danger";
                        lblMessage.Text = "Attenzione! Si sono verificati i seguenti errori:";
                        lblMessage.Text += "<br /><br /><b>E' stato trovato un virus nel file " + filename + "</b><br />";
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


                        ordineNew.Filefirma = SeoHelper.EncodeString(filename);
                        ordineNew.Fileconfermarental = SeoHelper.EncodeString(filename2);
                    }
                }

                if (servizioContratti.InsertOrdini(ordineNew) == 1)
                {
                    //recupero idordine inserito
                    IContratti data = servizioContratti.ReturnUltimoIdOrdine();
                    if (data != null)
                    {
                        //inserimento colore
                        IContratti ColNew = new Contratti
                        {
                            Idordine = data.Idordine,
                            Codoptional = SeoHelper.EncodeString(ddlColore.SelectedValue),
                            Importooptional = 0,
                            Uidtenant = SeoHelper.ReturnSessionTenant()
                        };

                        servizioContratti.InsertOrdineOptional(ColNew);

                    }


                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + ordineNew.Numeroordine);


                    if (opzione.ToUpper() == "SALVANUOVO")
                    {
                        //reset campi
                        ddlCodsocieta.ClearSelection();
                        ddlUsers.ClearSelection();
                        ddlCodjatoAuto.ClearSelection();
                        ddlCodFornitore.ClearSelection();
                        txtDataOrdine.Text = "";
                        txtAnnotazioniordine.Text = "";
                        ddlstatus.ClearSelection();

                        ddlCodsocieta.CssClass = "form-control";
                        ddlUsers.CssClass = "form-control";
                        ddlCodjatoAuto.CssClass = "form-control";
                        ddlstatus.CssClass = "form-control";

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
