// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsMulte.aspx.cs" company="">
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
using System.IO;
using System.Linq;
using DFleet.Classes;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.IO.Font;
using iText.Kernel.Utils;
using BusinessLogic.Services.blob;

namespace DFleet.Admin.Modules.Multa
{
    public partial class InsMulte : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(20) && !datiUtente.ReturnExistPage(22)) //controllo se la pagina è autorizzata per l'utente 
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
            InsertMulta("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertMulta("salvachiudi");
        }

        public void InsertMulta(string opzione)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            IMulteBL servizioMulte = new MulteBL();

            IMulte multeNew = new Multe
            {
                Protocollo = SeoHelper.EncodeString(txtProtocollo.Text),
                Idtipotrasmissione = SeoHelper.IntString(ddlTipoTrasm.SelectedValue),
                Codtipomulta = SeoHelper.EncodeString(ddlCodTipoMulta.SelectedValue),
                Targa = SeoHelper.EncodeString(ddlTarga.SelectedValue),
                Numeroverbale = SeoHelper.EncodeString(txtNumeroVerbale.Text),
                Datainfrazione = SeoHelper.DataString(txtDataInfrazione.Text),
                Orainfrazione = SeoHelper.EncodeString(txtOraInfrazione.Text),
                Datanotifica = SeoHelper.DataString(txtDataNotifica.Text),
                Ente = SeoHelper.EncodeString(txtEnte.Text),
                Infrazione = SeoHelper.EncodeString(txtInfrazione.Text),
                Punti = SeoHelper.IntString(txtPunti.Text),
                Importomulta = SeoHelper.DecimalString(txtImportoMulta.Text),
                Importomultaridotto = SeoHelper.DecimalString(txtImportoMultaRidotto.Text),
                Importomultascontato = SeoHelper.DecimalString(txtImportoMultaScontato.Text),
                Spesepagamento = SeoHelper.DecimalString(txtSpesePagamento.Text),
                Idstatuspagamento = 0, // N/D
                Filemanleva = "",
                Filericevutapagamento = "",
                Importomultapagato = 0,
                Codsocieta = SeoHelper.EncodeString(ddlCodSocieta.SelectedValue),
                Cfemittente = SeoHelper.EncodeString(txtCfemittente.Text),
                Codpagopa = SeoHelper.EncodeString(txtCodPagoPa.Text),
                Codpagopa60 = SeoHelper.EncodeString(txtCodPagoPa60.Text),
                Iban = SeoHelper.EncodeString(txtIban.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };
            multeNew.UserId = AttributeMulta(multeNew.Datainfrazione, multeNew.Targa);

            if (multeNew.UserId != Guid.Empty)
            {
                multeNew.Idstatuslavorazione = 10; //Attribuita driver
            }
            else
            {
                multeNew.Idstatuslavorazione = 0; //non attribuita
            }

            string error = string.Empty;
            var supportedTypes = new[] { ".pdf", ".PDF" };
            string fileExt;


            if (string.IsNullOrEmpty(multeNew.Protocollo))
            {
                txtProtocollo.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Protocollo<br />";
            }
            else
            {
                txtProtocollo.CssClass = "form-control";
            }

            if (multeNew.Idtipotrasmissione == 0)
            {
                ddlTipoTrasm.CssClass = "form-control is-invalid select2";
                error += "inserire un valore valido per il campo Tipo Trasmissione<br />";
            }
            else
            {
                ddlTipoTrasm.CssClass = "form-control select2";
            }

            if (string.IsNullOrEmpty(multeNew.Codtipomulta))
            {
                ddlCodTipoMulta.CssClass = "form-control is-invalid select2";
                error += "inserire un valore valido per il campo Tipo Multa<br />";
            }
            else
            {
                ddlCodTipoMulta.CssClass = "form-control select2";
            }

            if (string.IsNullOrEmpty(multeNew.Targa))
            {
                ddlTarga.CssClass = "form-control is-invalid select2";
                error += "inserire un valore valido per il campo Targa<br />";
            }
            else
            {
                ddlTarga.CssClass = "form-control select2";
            }

            if (string.IsNullOrEmpty(multeNew.Numeroverbale))
            {
                txtNumeroVerbale.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Numero verbale<br />";
            }
            else
            {
                if (servizioMulte.ExistVerbaleMulta(multeNew.Numeroverbale, multeNew.Targa))
                {
                    txtNumeroVerbale.CssClass = "form-control is-invalid";
                    error += "Numero verbale gi&agrave; esistente per questa targa<br />";
                }
                else
                {
                    txtNumeroVerbale.CssClass = "form-control";
                }
            }

            if (multeNew.Datainfrazione == DateTime.MinValue)
            {
                txtDataInfrazione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Data Infrazione<br />";
            }
            else
            {
                txtDataInfrazione.CssClass = "form-control";
            }

            HttpFileCollection uploadedFiles = Request.Files;

            // controllo se fuFileVerbale contiene un file da caricare
            if (uploadedFiles.Count == 0) 
            {
                error += "inserire il file del verbale<br />";
            }
            else
            {
                for (int i = 0; i < uploadedFiles.Count; i++)
                {
                    HttpPostedFile userPostedFile = uploadedFiles[i];

                    try
                    {
                        if (userPostedFile.ContentLength > 0)
                        {
                            fileExt = Path.GetExtension(userPostedFile.FileName);


                            // controllo la dimensione del file
                            if (userPostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                            {
                                error += "Il file non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                            }
                            else
                            {
                                //controllo estensione del file
                                if (!supportedTypes.Contains(fileExt))
                                {
                                    error += "Il file non può essere caricato perché non ha un'estensione .pdf";
                                }
                            }
                        }
                    }
                    catch (IOException)
                    {
                        error += "Operazione non andata a buon fine<br />";
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
                string errorv = ""; 
                string[] fileArray = new string[uploadedFiles.Count]; //salviamo tutti i pdf in un array

                for (int i = 0; i < uploadedFiles.Count; i++)
                {
                    string filename;
                    string filePath;

                    HttpPostedFile userPostedFile2 = uploadedFiles[i];
                    filename = SeoHelper.OraAttuale() + "-" + SeoHelper.RenameFileUpload(userPostedFile2.FileName);
                    fileArray[i] = filename;

                    // salviamo il file nel percorso calcolato
                    filePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/multe/" + filename;
                    userPostedFile2.SaveAs(filePath);
                    System.Threading.Thread.Sleep(1000);

                    //controllo virus scanner
                    var scanner = new AntiVirus.Scanner();
                    var resultS = scanner.ScanAndClean(filePath);

                    if (resultS.ToString() != "VirusNotFound")
                    {
                        errorv += "1";
                    }
                }



                if (errorv.Contains("1"))
                {
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text = "Attenzione! Si sono verificati i seguenti errori:";
                    lblMessage.Text += "<br /><br /><b>E' stato trovato un virus in uno dei file</b><br />";
                }
                else
                {
                    //union pdf
                    string mergepdf = MargeMultiplePDF(fileArray);

                    string containerName = "multe";
                    string blobName = mergepdf;
                    string fileName = mergepdf;
                    string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/multe/";
                    string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/multe/";
                    string sas = Global.sas;

                    AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                    string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);
                    Response.Write(resultBlob);


                    multeNew.Fileverbale = mergepdf;

                    if (servizioMulte.InsertMulte(multeNew) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + multeNew.Numeroverbale);

                        //invio mail
                        if (multeNew.Idstatuslavorazione == 10)
                        {
                            bool result = true;
                            int idtemplate = 0;
                            Guid Uidmulta = Guid.Empty;
                            string oggetto = "";

                            switch (multeNew.Codtipomulta)
                            {
                                case "10": //multa senza decurtazione punti patente che prevede i pagamento ridotto
                                    idtemplate = 1;
                                    oggetto = "Notifica contravvenzione SENZA DECURTAZIONE PUNTI – D4M - notifica contravvenzione prot. " + multeNew.Protocollo + " verbale n. " + multeNew.Numeroverbale + " del " + multeNew.Datanotifica.ToString("dd/MM/yyyy") + " targa " + multeNew.Targa;
                                    break;

                                case "20": //multa senza decurtazione punti patente che prevede il solo pagamento al 100%
                                    idtemplate = 7;
                                    oggetto = "Notifica contravvenzione SENZA DECURTAZIONE PUNTI – D4M - notifica contravvenzione prot. " + multeNew.Protocollo + " verbale n. " + multeNew.Numeroverbale + " del " + multeNew.Datanotifica.ToString("dd/MM/yyyy") + " targa " + multeNew.Targa;
                                    break;

                                case "30": //multa con decurtazione punti patente che prevede i pagamento ridotto
                                    idtemplate = 8;
                                    oggetto = "Notifica contravvenzione CON DECURTAZIONE PUNTI - D4M – prot. " + multeNew.Protocollo + " verbale n. " + multeNew.Numeroverbale + " del " + multeNew.Datanotifica.ToString("dd/MM/yyyy") + " targa " + multeNew.Targa;
                                    break;

                                case "40": //multa con decurtazione punti patente che prevede il solo pagamento al 100%
                                    idtemplate = 9;
                                    oggetto = "Notifica contravvenzione CON DECURTAZIONE PUNTI - D4M – prot. " + multeNew.Protocollo + " verbale n. " + multeNew.Numeroverbale + " del " + multeNew.Datanotifica.ToString("dd/MM/yyyy") + " targa " + multeNew.Targa;
                                    break;

                                case "55": //multa per mancata comunicazione dati conducente (126bis) che prevede i pagamento ridotto
                                    idtemplate = 10;
                                    oggetto = "Notifica contravvenzione 126 bis. Mancanta comunicazione dati patente – D4M - notifica contravvenzione prot. " + multeNew.Protocollo + " verbale n. " + multeNew.Numeroverbale + " del " + multeNew.Datanotifica.ToString("dd/MM/yyyy") + " targa " + multeNew.Targa;
                                    break;

                                case "60": //multa per mancata comunicazione dati conducente (126biS) che prevede il solo pagamento al 100%
                                    idtemplate = 11;
                                    oggetto = "Notifica contravvenzione 126 bis. Mancanta comunicazione dati patente – D4M - notifica contravvenzione prot. " + multeNew.Protocollo + " verbale n. " + multeNew.Numeroverbale + " del " + multeNew.Datanotifica.ToString("dd/MM/yyyy") + " targa " + multeNew.Targa;
                                    break;

                                case "70": //multe estere
                                    idtemplate = 12;
                                    oggetto = "Notifica contravvenzione MULTA ESTERA – D4M – notifica contravvenzione prot. " + multeNew.Protocollo + " verbale n. " + multeNew.Numeroverbale + " del " + multeNew.Datanotifica.ToString("dd/MM/yyyy") + " targa " + multeNew.Targa;
                                    break;

                                case "80": //multa pagamento pedaggio
                                    idtemplate = 13; 
                                    oggetto = "Notifica amministrativa MANCATO PAGAMENTO PEDAGGIO – D4M – notifica contravvenzione prot. " + multeNew.Protocollo + " verbale n. " + multeNew.Numeroverbale + " del " + multeNew.Datanotifica.ToString("dd/MM/yyyy") + " targa " + multeNew.Targa;
                                    break;

                                case "90": //ingiunzioni di pagamento
                                    idtemplate = 15;
                                    oggetto = "Ingiunzioni di pagamento – D4M – notifica contravvenzione prot. " + multeNew.Protocollo + " verbale n. " + multeNew.Numeroverbale + " del " + multeNew.Datanotifica.ToString("dd/MM/yyyy") + " targa " + multeNew.Targa;
                                    break;
                            }


                            //recupero ultimo uid multa
                            IMulte dataLastUid = servizioMulte.UltimoIDMulta();
                            if (dataLastUid != null)
                            {
                                Uidmulta = dataLastUid.Uid;
                            }
                            
                            IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(idtemplate);
                            if (dataTemplate != null)
                            {
                                //result = MailHelper.SendMail("", ReturnEmail(multeNew.UserId), "", "", "", "", oggetto, servizioUtility.InsMultaEmail(multeNew.UserId, Uidmulta, dataTemplate.Corpo), "");
                            }

                            if (result) //se invio mail è andato a buon fine
                            {
                                if (Uidmulta != Guid.Empty)
                                {
                                    //aggiorna ckemaildriver
                                    //servizioMulte.UpdateCkEmail(dataLastUid.Uid, SeoHelper.ReturnSessionTenant());

                                    //inserimento comunicazione
                                    IUtilitys comunicEmailNew = new Utilitys
                                    {
                                        Mittente = "noreply@deloitte.it",
                                        UserId = multeNew.UserId,
                                        Oggetto = oggetto,
                                        Tipocomunicazione = "EMAIL",
                                        Idstatuscomunicazione = 0,
                                        Datainvio = DateTime.Now,
                                        Uidtenant = SeoHelper.ReturnSessionTenant()
                                    };
                                    servizioUtility.InsertComunicazioneEmail(comunicEmailNew);
                                }
                            }
                        }


                        if (opzione.ToUpper() == "SALVANUOVO")
                        {
                            //reset campi
                            txtProtocollo.Text = "";
                            ddlTipoTrasm.ClearSelection();
                            ddlCodTipoMulta.ClearSelection();
                            ddlTarga.ClearSelection();
                            ddlCodSocieta.ClearSelection();
                            txtNumeroVerbale.Text = "";
                            txtDataInfrazione.Text = "";
                            txtOraInfrazione.Text = "";
                            txtDataNotifica.Text = "";
                            txtEnte.Text = "";
                            txtInfrazione.Text = "";
                            txtPunti.Text = "";
                            txtImportoMulta.Text = "";
                            txtImportoMultaRidotto.Text = "";
                            txtImportoMultaScontato.Text = "";
                            txtCfemittente.Text = "";
                            txtCodPagoPa.Text = "";
                            txtIban.Text = "";

                            txtProtocollo.CssClass = "form-control";
                            ddlTipoTrasm.CssClass = "form-control";
                            ddlCodTipoMulta.CssClass = "form-control";
                            ddlTarga.CssClass = "form-control";
                            txtNumeroVerbale.CssClass = "form-control";
                            txtDataInfrazione.CssClass = "form-control";

                            //messaggio avvenuto inserimento
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuova Multa o <a href='" + ResolveUrl("~/Admin/Modules/Multa/ViewMulte") + "'>Ritorna alla Lista</a>";
                        }
                        else
                        {
                            Response.Redirect("ViewMulte");
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

        public string ReturnEmail(Guid userId)
        {
            string retVal = string.Empty;

            IAccountBL servizioAccount = new AccountBL();
            IAccount data = servizioAccount.DetailId(userId);
            if (data != null)
            {
                retVal = data.Email;
            }

            return retVal;
        }

        //attribuisce multa a driver in base alla data infrazione e alla targa
        public Guid AttributeMulta(DateTime datainfrazione, string targa)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid retVal = Guid.Empty;

            IContratti data = servizioContratti.ReturnContrattoUser(datainfrazione, targa);
            if (data != null)
            {
                retVal = data.UserId;
            }

            return retVal;
        }

        public static string MargeMultiplePDF(string[] PDFfileNames)
        {
            string filename = "";
            string percorso = RequestExtensions.GetPathPhisicalApplication() + "/Repository/multe/" + filename;

            if (PDFfileNames.Length > 1)
            {
                filename = SeoHelper.OraAttuale() + "-verbale.pdf";

                PdfDocument pdfOutput = new PdfDocument(new PdfWriter(percorso + filename));

                for (int i = 0; i < PDFfileNames.Length; i++)
                {
                    PdfDocument pdfToCombine = new PdfDocument(new PdfReader(RequestExtensions.GetPathPhisicalApplication() + "/Repository/multe/" + PDFfileNames[i].ToString()));
                    PdfMerger merger = new PdfMerger(pdfOutput);
                    merger.Merge(pdfToCombine, 1, pdfToCombine.GetNumberOfPages());
                    pdfToCombine.Close();
                }

                pdfOutput.Close();
            }
            else
            {
                filename = PDFfileNames[0];
            }


            return filename;
        }
    }
}
