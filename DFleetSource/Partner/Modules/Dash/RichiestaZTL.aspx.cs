// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="RichiestaZTL.aspx.cs" company="">
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
using BusinessLogic.Services.blob;

namespace DFleet.Partner.Modules.Dash
{
    public partial class RichiestaZTL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IAccountBL servizioAccount = new AccountBL();
                IContrattiBL servizioContratti = new ContrattiBL();
                Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;

                IAccount data = servizioAccount.DetailId(UserId);
                if (data != null)
                {
                    txtDenominazione.Text = data.Nome + " " + data.Cognome;
                    txtLuogoNascita.Text = data.Luogonascita;
                    txtDataNascita.Text = SeoHelper.CheckDataString(data.Datanascita);
                    txtCitta.Text = data.Localitaresidenza;
                    txtIndirizzo.Text = data.Indirizzoresidenza;
                    hdcodsocieta.Value = data.Codsocieta;
                }

                IContratti dataC = servizioContratti.DetailVeicoloAttualeDriver(UserId);
                if (dataC != null)
                {
                    txtTarga.Text = dataC.Targa;
                    txtVeicolo.Text = dataC.Modello;
                    txtFornitore.Text = dataC.Fornitore;
                    txtDataInizioContratto.Text = SeoHelper.CheckDataString(dataC.Assegnatodal);
                    txtDataInizioContratto2.Text = SeoHelper.CheckDataString(dataC.Assegnatodal);
                    txtDataFineContratto.Text = SeoHelper.CheckDataString(dataC.Datafinecontratto);
                    txtNumContratto.Text = dataC.Numerocontratto;
                }

            }
        }

        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            Guid Uidtenant = datiUtente.ReturnUidTenant();

            string error = string.Empty;
            IContrattiBL servizioContratti = new ContrattiBL();

            IContratti delNew = new Contratti
            {
                Denominazione = SeoHelper.EncodeString(txtDenominazione.Text),
                Datanascita = SeoHelper.DataString(txtDataNascita.Text),
                Luogonascita = SeoHelper.EncodeString(txtLuogoNascita.Text),
                Indirizzoresidenza = SeoHelper.EncodeString(txtIndirizzo.Text),
                Civicoresidenza = SeoHelper.EncodeString(txtCivico.Text),
                Cittaresidenza = SeoHelper.EncodeString(txtCitta.Text),
                Numerocontratto = SeoHelper.EncodeString(txtNumContratto.Text),
                Datainiziocontratto = SeoHelper.DataString(txtDataInizioContratto.Text),
                Datafinecontratto = SeoHelper.DataString(txtDataFineContratto.Text),
                Veicolo = SeoHelper.EncodeString(txtVeicolo.Text),
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Fornitore = SeoHelper.EncodeString(txtFornitore.Text),
                Codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value),
                Datadocumento = SeoHelper.DataString(txtDataDocumento.Text),
                Luogodocumento = SeoHelper.EncodeString(txtLuogoDocumento.Text),
                UserId = (Guid)Membership.GetUser().ProviderUserKey,
                Filepdf = "",
                Uidtenant = Uidtenant
            };

            if (string.IsNullOrEmpty(delNew.Denominazione))
            {
                txtDenominazione.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Nome e Cognome<br />";
            }
            if (delNew.Datanascita == DateTime.MinValue)
            {
                txtDataNascita.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Data di nascita<br />";
            }
            if (string.IsNullOrEmpty(delNew.Luogonascita))
            {
                txtLuogoNascita.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Luogo di nascita<br />";
            }
            if (string.IsNullOrEmpty(delNew.Indirizzoresidenza))
            {
                txtIndirizzo.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Indirizzo<br />";
            }
            if (string.IsNullOrEmpty(delNew.Civicoresidenza))
            {
                txtCivico.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Civico<br />";
            }
            if (string.IsNullOrEmpty(delNew.Cittaresidenza))
            {
                txtCitta.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Citt&agrave;<br />";
            }
            if (string.IsNullOrEmpty(delNew.Numerocontratto))
            {
                txtNumContratto.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo N. Contratto<br />";
            }
            if (delNew.Datainiziocontratto == DateTime.MinValue)
            {
                txtDataInizioContratto.CssClass = "borderbottom is-invalid";
                txtDataInizioContratto2.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Data inizio contratto<br />";
            }
            if (delNew.Datafinecontratto == DateTime.MinValue)
            {
                txtDataFineContratto.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Data fine contratto<br />";
            }

            if (string.IsNullOrEmpty(delNew.Veicolo))
            {
                txtVeicolo.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Veicolo<br />";
            }
            if (string.IsNullOrEmpty(delNew.Targa))
            {
                txtTarga.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Targa<br />";
            }
            if (string.IsNullOrEmpty(delNew.Fornitore))
            {
                txtFornitore.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Fornitore<br />";
            }
            if (string.IsNullOrEmpty(delNew.Luogodocumento))
            {
                txtLuogoDocumento.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Luogo documento<br />";
            }
            if (delNew.Datadocumento == DateTime.MinValue)
            {
                txtDataDocumento.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Data documento<br />";
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
                if (servizioContratti.InsertDocZTL(delNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento Delega ZTL: " + delNew.UserId);

                    IContratti dataC = servizioContratti.ReturnUltimoIdZTL();
                    if (dataC != null)
                    {
                        GeneraPdf(dataC.Iddelega);
                    }

                    Response.Redirect("Procedure");                    
                }
            }
        }

        public void GeneraPdf(int iddelega)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            Guid Uidtenant = datiUtente.ReturnUidTenant();

            IContrattiBL servizioContratti = new ContrattiBL();
            string codsocieta = hdcodsocieta.Value;
            string filepdf = SeoHelper.OraAttuale() + "_ztl.pdf";
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/deleghe/" + filepdf;


            string testoiniziale = "";
            string testosocieta = "";
            string intestazioneimg = "";
            string footerimg = "";

            switch (codsocieta)
            {
                case "00570": //DBS
                    testoiniziale = "La Sig.ra Chiara Pavesi nella qualità di Procuratore della società Deloitte Business Solutions S.r.l. utilizzatrice in virtù di contratto di locazione a lungo termine di veicoli senza conducente con " + txtFornitore.Text + " del veicolo " + txtVeicolo.Text + " targato " + txtTarga.Text + ".";
                    testosocieta = "Deloitte Business Solutions S.r.l.";
                    intestazioneimg = "header_CI_DBS.jpg";
                    footerimg = "bottom_CI_DBS.jpg";
                    break;

                case "00500": //DC
                case "00545": //clasting
                    testoiniziale = "La Sig.ra Chiara Pavesi, in qualità di Procuratore della società Deloitte Consulting S.r.l. utilizzatrice in virtù di contratto di locazione a lungo termine di veicoli senza conducente con " + txtFornitore.Text + " del veicolo " + txtVeicolo.Text + " targato " + txtTarga.Text + ".";
                    testosocieta = "Deloitte Consulting S.r.l.";
                    intestazioneimg = "header_CI_Consulting.jpg";
                    footerimg = "bottom_CI_Consulting.jpg";
                    break;

                case "00690": //DFA
                    testoiniziale = "La Sig.ra Chiara Pavesi, in qualità di Procuratore della società Deloitte Financial Advisory S.r.l. utilizzatrice in virtù di contratto di locazione a lungo termine di veicoli senza conducente con " + txtFornitore.Text + " del veicolo " + txtVeicolo.Text + " targato " + txtTarga.Text + ".";
                    testosocieta = "Deloitte Financial Advisory S.r.l.";
                    intestazioneimg = "header_CI_DFA.jpg";
                    footerimg = "bottom_CI_DFA.jpg";
                    break;

                case "00650": //DI
                    testoiniziale = "La Sig.ra Chiara Pavesi nella qualità di Procuratore della società Deloitte Italy S.p.A. utilizzatrice in virtù di contratto di locazione a lungo termine di veicoli senza conducente con " + txtFornitore.Text + " del veicolo " + txtVeicolo.Text + " targato " + txtTarga.Text + ".";
                    testosocieta = "Deloitte Italy S.p.A.";
                    intestazioneimg = "header_CI_Deloitte.jpg";
                    footerimg = "bottom_CI_Deloitte.jpg";
                    break;

                case "00511": //DRA
                    testoiniziale = "La Sig.ra Chiara Pavesi in qualità di Procuratore della società Deloitte Risk Advisory S.r.l., utilizzatrice in virtù di contratto di locazione a lungo termine di veicoli senza conducente con " + txtFornitore.Text + " del veicolo " + txtVeicolo.Text + " targato " + txtTarga.Text + ".";
                    testosocieta = "Deloitte Risk Advisory S.r.l.";
                    intestazioneimg = "header_CI_RiskAdvisory.jpg";
                    footerimg = "bottom_CI_RiskAdvisory.jpg";
                    break;

                case "00100": //DT
                case "00671": //DTT
                    testoiniziale = "La Sig.ra Chiara Pavesi nella qualità di Procuratore della società Deloitte & Touche S.p.A utilizzatrice in virtù di contratto di locazione a lungo termine di veicoli senza conducente con " + txtFornitore.Text + " del veicolo " + txtVeicolo.Text + " targato " + txtTarga.Text + ".";
                    testosocieta = "Deloitte & Touche S.p.A.";
                    intestazioneimg = "header_CI_DT.jpg";
                    footerimg = "bottom_CI_DT.jpg";
                    break;

                case "00410": //OI
                    testoiniziale = "La Sig.ra Chiara Pavesi nella qualità di Procuratore della società Officine Innovazione S.r.l., utilizzatrice in virtù di contratto di locazione a lungo termine di veicoli senza conducente con " + txtFornitore.Text + " del veicolo " + txtVeicolo.Text + " targato " + txtTarga.Text + ".";
                    testosocieta = "Officine Innovazione S.r.l.";
                    intestazioneimg = "header_CI_OI.jpg";
                    footerimg = "bottom_CI_OI.jpg";
                    break;
            }



            FontProgram fontProgram = FontProgramFactory.CreateFont(Server.MapPath("/css/fonts/calibri.ttf"));
            PdfFont calibri = PdfFontFactory.CreateFont(fontProgram, PdfEncodings.WINANSI);
            PdfWriter writer = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            document.SetFont(calibri);

            iText.Layout.Element.Image imgheader = new iText.Layout.Element.Image(ImageDataFactory
            .Create(Server.MapPath("/plugins/images/" + intestazioneimg)));
            document.Add(imgheader);

            iText.Layout.Element.Image imgfooter = new iText.Layout.Element.Image(ImageDataFactory
            .Create(Server.MapPath("/plugins/images/" + footerimg)));
            imgfooter.SetFixedPosition(30, 10);
            imgfooter.SetWidth(500);
            //imgfooter.SetRelativePosition(0, 630, 0, 0);
            document.Add(imgfooter);

            Paragraph header = new Paragraph("DICHIARAZIONE")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(11)
               .SetBold();
            document.Add(header);

            Paragraph text1 = new Paragraph(testoiniziale)
               .SetTextAlignment(TextAlignment.JUSTIFIED)
               .SetFontSize(11);
            document.Add(text1);

            Paragraph text2 = new Paragraph("dichiara")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(11)
               .SetBold();
            document.Add(text2);

            Paragraph text3 = new Paragraph("che il dipendente Sig./la Sig.ra " + txtDenominazione.Text + ", nato/a a " + txtLuogoNascita.Text + " il giorno " + txtDataNascita.Text + ", " +
                                            "residente a " + txtCitta.Text + " in " + txtIndirizzo.Text + ", " + txtCivico.Text + ", è l’utilizzatore del suddetto veicolo " +
                                            " in uso esclusivo a partire dal " + txtDataInizioContratto.Text + " sino alla data in cui terminerà la locazione.")
               .SetTextAlignment(TextAlignment.JUSTIFIED)
               .SetFontSize(11);
            document.Add(text3);

            Paragraph text4 = new Paragraph("I dati del contratto in questione sono i seguenti:")
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11);
            document.Add(text4);

            Paragraph text5 = new Paragraph("    n. contratto: " + txtNumContratto.Text)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11);
            document.Add(text5);

            Paragraph text6 = new Paragraph("    data inizio: " + txtDataInizioContratto2.Text)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11);
            document.Add(text6);

            Paragraph text7 = new Paragraph("    data scadenza: " + txtDataFineContratto.Text)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11);
            document.Add(text7);

            Paragraph text8 = new Paragraph("Si attesta inoltre che, per l’utilizzo dell’autovettura sopra riportata, tramite cedolino paga, vengono regolarmente effettuati gli assoggettamenti " +
                                            "contributivi e fiscali nella misura corrispondente al valore del fringe benefit.")
               .SetTextAlignment(TextAlignment.JUSTIFIED)
               .SetFontSize(11);
            document.Add(text8);

            Paragraph text9 = new Paragraph("Si rilascia la presente dichiarazione per gli usi consentiti dalla legge.")
               .SetTextAlignment(TextAlignment.JUSTIFIED)
               .SetFontSize(11);
            document.Add(text9);

            Paragraph text10 = new Paragraph("Recapiti per comunicazioni: e-mail teamd4m@deloitte.it.")
               .SetTextAlignment(TextAlignment.JUSTIFIED)
               .SetFontSize(11);
            document.Add(text10);

            Paragraph text11 = new Paragraph("Luogo " + txtLuogoDocumento.Text + ", data " + txtDataDocumento.Text)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11);
            document.Add(text11);

            Paragraph text14 = new Paragraph(testosocieta)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11);
            document.Add(text14);

            iText.Layout.Element.Image img = new iText.Layout.Element.Image(ImageDataFactory
            .Create(Server.MapPath("/plugins/images/FIRMA_CHIARA.jpg")));
            document.Add(img);


            Paragraph text12 = new Paragraph("Chiara Pavesi")
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11);
            document.Add(text12);

            Paragraph text13 = new Paragraph("Procuratore")
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11);
            document.Add(text13);


            document.Close();

            string containerName = "deleghe";
            string blobName = filepdf;
            string fileName = filepdf;
            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/deleghe/";
            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/deleghe/";
            string sas = Global.sas;

            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
            string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

            Response.Write(resultBlob);


            servizioContratti.UpdatePdfDocZTL(iddelega, filepdf, SeoHelper.ReturnSessionTenant());


            IContratti delNew2 = new Contratti
            {
                Idtipomodulo = 2,
                Modulofirmato = filepdf,
                Uidtenant = Uidtenant
            };

            servizioContratti.InsertDelega(delNew2);

        }
            
    }
}
