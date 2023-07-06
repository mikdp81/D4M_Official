// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="RichiestaDelega.aspx.cs" company="">
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
using iText.Kernel.Pdf.Xobject;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Events;

namespace DFleet.Users.Modules.Dash
{
    public partial class RichiestaDelega : System.Web.UI.Page
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
                    txtNrPatente.Text = data.Nrpatente;
                    txtDataRilascioPatente.Text = SeoHelper.CheckDataString(data.Dataemissione);
                    txtEntePatente.Text = data.Ufficioemittente;
                    txtScadenzaPatente.Text = SeoHelper.CheckDataString(data.Datascadenza);
                    hdcodsocieta.Value = data.Codsocieta;
                }

                IContratti dataC = servizioContratti.DetailVeicoloAttualeDriver(UserId);
                if (dataC != null)
                {
                    txtTarga.Text = dataC.Targa;
                    txtVeicolo.Text = dataC.Modello;
                    txtFornitore.Text = dataC.Fornitore;
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
                Nrpatente = SeoHelper.EncodeString(txtNrPatente.Text),
                Datarilasciopatente = SeoHelper.DataString(txtDataRilascioPatente.Text),
                Entepatente = SeoHelper.EncodeString(txtEntePatente.Text),
                Scadenzapatente = SeoHelper.DataString(txtScadenzaPatente.Text),
                Denominazionedelegato = SeoHelper.EncodeString(txtDenominazioneDelegato.Text),
                Datanascitadelegato = SeoHelper.DataString(txtDataNascitaDelegato.Text),
                Luogonascitadelegato = SeoHelper.EncodeString(txtLuogoNascitaDelegato.Text),
                Indirizzoresidenzadelegato = SeoHelper.EncodeString(txtIndirizzoDelegato.Text),
                Civicoresidenzadelegato = SeoHelper.EncodeString(txtCivicoDelegato.Text),
                Cittaresidenzadelegato = SeoHelper.EncodeString(txtCittaDelegato.Text),
                Nrpatentedelegato = SeoHelper.EncodeString(txtNrPatenteDelegato.Text),
                Datarilasciopatentedelegato = SeoHelper.DataString(txtDataRilascioPatenteDelegato.Text),
                Entepatentedelegato = SeoHelper.EncodeString(txtEntePatenteDelegato.Text),
                Scadenzapatentedelegato = SeoHelper.DataString(txtScadenzaPatenteDelegato.Text),
                Tipoutente = SeoHelper.EncodeString(ddlTipoUtente.SelectedValue),
                Veicolo = SeoHelper.EncodeString(txtVeicolo.Text),
                Targa = SeoHelper.EncodeString(txtTarga.Text),
                Fornitore = SeoHelper.EncodeString(txtFornitore.Text),
                Codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value),
                Datadocumento = SeoHelper.DataString(txtDataDocumento.Text),
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
            if (string.IsNullOrEmpty(delNew.Nrpatente))
            {
                txtNrPatente.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Nr. Patente<br />";
            }
            if (delNew.Datarilasciopatente == DateTime.MinValue)
            {
                txtDataRilascioPatente.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Data rilascio patente<br />";
            }
            if (string.IsNullOrEmpty(delNew.Entepatente))
            {
                txtEntePatente.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Ente patente<br />";
            }
            if (delNew.Scadenzapatente == DateTime.MinValue)
            {
                txtScadenzaPatente.CssClass = "borderbottom is-invalid";
                error += "inserire un valore valido per il campo Scadenza patente<br />";
            }
            if (string.IsNullOrEmpty(delNew.Denominazionedelegato))
            {
                txtDenominazioneDelegato.CssClass = "borderbottomred is-invalid";
                error += "inserire un valore valido per il campo Nome e Cognome delegato<br />";
            }
            if (delNew.Datanascitadelegato == DateTime.MinValue)
            {
                txtDataNascitaDelegato.CssClass = "borderbottomred is-invalid";
                error += "inserire un valore valido per il campo Data di nascita delegato<br />";
            }
            if (string.IsNullOrEmpty(delNew.Luogonascitadelegato))
            {
                txtLuogoNascitaDelegato.CssClass = "borderbottomred is-invalid";
                error += "inserire un valore valido per il campo Luogo di nascita delegato<br />";
            }
            if (string.IsNullOrEmpty(delNew.Indirizzoresidenzadelegato))
            {
                txtIndirizzoDelegato.CssClass = "borderbottomred is-invalid";
                error += "inserire un valore valido per il campo Indirizzo delegato<br />";
            }
            if (string.IsNullOrEmpty(delNew.Civicoresidenzadelegato))
            {
                txtCivicoDelegato.CssClass = "borderbottomred is-invalid";
                error += "inserire un valore valido per il Civico delegato<br />";
            }
            if (string.IsNullOrEmpty(delNew.Cittaresidenzadelegato))
            {
                txtCittaDelegato.CssClass = "borderbottomred is-invalid";
                error += "inserire un valore valido per il campo Citt&agrave; delegato<br />";
            }
            if (string.IsNullOrEmpty(delNew.Nrpatentedelegato))
            {
                txtNrPatenteDelegato.CssClass = "borderbottomred is-invalid";
                error += "inserire un valore valido per il campo Nr. Patente delegato<br />";
            }
            if (delNew.Datarilasciopatentedelegato == DateTime.MinValue)
            {
                txtDataRilascioPatenteDelegato.CssClass = "borderbottomred is-invalid";
                error += "inserire un valore valido per il campo Data rilascio patente delegato<br />";
            }
            if (string.IsNullOrEmpty(delNew.Entepatentedelegato))
            {
                txtEntePatenteDelegato.CssClass = "borderbottomred is-invalid";
                error += "inserire un valore valido per il campo Ente patente delegato<br />";
            }
            if (delNew.Scadenzapatentedelegato == DateTime.MinValue)
            {
                txtScadenzaPatenteDelegato.CssClass = "borderbottomred is-invalid";
                error += "inserire un valore valido per il campo Scadenza patente delegato<br />";
            }
            if (string.IsNullOrEmpty(delNew.Tipoutente))
            {
                ddlTipoUtente.CssClass = "borderbottomred is-invalid";
                error += "inserire un valore valido per il campo Tipo utente<br />";
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
                if (servizioContratti.InsertDocDelega(delNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento Delega decorrenza del driver: " + delNew.UserId);


                    IContratti dataC = servizioContratti.ReturnUltimoIdDelega();
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
            string filepdf = SeoHelper.OraAttuale() + "_decorrenza.pdf";
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/deleghe/" + filepdf;

            string testoiniziale = "";
            string testosocieta = "";
            string intestazioneimg = "";
            string footerimg = "";

            switch (codsocieta)
            {
                case "00570": //DBS
                    testoiniziale = "La Sig.ra Chiara Pavesi nella qualità di Procuratore della società Deloitte Business Solutions S.r.l. con sede in Milano, Via Tortona, 25, munito degli occorrenti poteri in forza di Procura del 03/05/2021 rilasciata in autentica dal Notaio Domenico Guaccero, Repertorio n. 17208, Raccolta n. 10498";
                    testosocieta = "Deloitte Business Solutions S.r.l.";
                    intestazioneimg = "header_CI_DBS.jpg";
                    footerimg = "bottom_CI_DBS.jpg";
                    break;

                case "00500": //DC
                case "00545": //clasting
                    testoiniziale = "La Sig.ra Chiara Pavesi nella qualità di procuratore della società Deloitte Consulting S.r.l. con sede in Milano, Via Tortona, 25, munito degli occorrenti poteri in forza di Procura del 19/05/2020 rilasciata in autentica dal Notaio Laura Cavallotti, Repertorio n. 35719, Raccolta n. 12320";
                    testosocieta = "Deloitte Consulting S.r.l.";
                    intestazioneimg = "header_CI_Consulting.jpg";
                    footerimg = "bottom_CI_Consulting.jpg";
                    break;

                case "00690": //DFA
                    testoiniziale = "La Sig.ra Chiara Pavesi nella qualità di Procuratore della società Deloitte Financial Advisory S.r.l. con sede in Milano, Via Tortona, 25, munito degli occorrenti poteri in forza di Procura del 17/03/2021 rilasciata in autentica dal Notaio Gavino Posadinu, Repertorio n. 12.902, Raccolta n. 4.322";
                    testosocieta = "Deloitte Financial Advisory S.r.l.";
                    intestazioneimg = "header_CI_DFA.jpg";
                    footerimg = "bottom_CI_DFA.jpg";
                    break;

                case "00650": //DI
                    testoiniziale = "La Sig.ra Chiara Pavesi in qualità di Procuratore della società Deloitte Italy S.p.A. con sede in Milano, Via Tortona, 25 munito degli occorrenti poteri in forza di Procura del 20/05/2020 rilasciata in autentica dal Notaio Paola Cardelli, Repertorio n. 26624, Raccolta n. 7841";
                    testosocieta = "Deloitte Italy S.p.A.";
                    intestazioneimg = "header_CI_Deloitte.jpg";
                    footerimg = "bottom_CI_Deloitte.jpg";
                    break;

                case "00511": //DRA
                    testoiniziale = "La Sig.ra Chiara Pavesi nella qualità di Procuratore della società Deloitte Risk Advisory S.r.l. con sede in Milano, Via Tortona 25 munito degli occorrenti poteri in forza di Procura del 20/05/2020 rilasciata in autentica dal Notaio Rossella Ruffini, Repertorio n. 3551, Raccolta n. 2974";
                    testosocieta = "Deloitte Risk Advisory S.r.l.";
                    intestazioneimg = "header_CI_RiskAdvisory.jpg";
                    footerimg = "bottom_CI_RiskAdvisory.jpg";
                    break;

                case "00100": //DT
                case "00671": //DTT
                    testoiniziale = "La Sig.ra Chiara Pavesi nella qualità di Procuratore della società Deloitte & Touche S.p.A. con sede in Milano, Via Tortona 25 munito degli occorrenti poteri in forza di Procura del 20/05/2021 rilasciata in autentica dal Notaio Federico De Stefano, Repertorio n. 8997, Raccolta n. 3131";
                    testosocieta = "Deloitte & Touche S.p.A.";
                    intestazioneimg = "header_CI_DT.jpg";
                    footerimg = "bottom_CI_DT.jpg";
                    break;

                case "00410": //OI
                    testoiniziale = "La Sig.ra Chiara Pavesi nella qualità di Procuratore della società Officine Innovazione S.r.l. con sede in Milano, Via Tortona, 25, munito degli occorrenti poteri in forza di Procura del 20/05/2020 rilasciata in autentica dal Notaio Paola Cardelli, Repertorio n. 26626, Raccolta n. 7843";
                    testosocieta = "Officine Innovazione S.r.l.";
                    intestazioneimg = "header_CI_OI.jpg";
                    footerimg = "bottom_CI_OI.jpg";
                    break;

                case "00800": //DNH
                    testoiniziale = "La Sig.ra Chiara Pavesi nella qualità di Procuratore della società Deloitte Nexthub S.r.l., utilizzatrice in virtù di contratto di locazione a lungo termine di veicoli senza conducente con " + txtFornitore.Text + " del veicolo " + txtVeicolo.Text + " targato " + txtTarga.Text + ".";
                    testosocieta = "Deloitte Nexthub S.r.l.";
                    intestazioneimg = "header_CI_DNH.jpg";
                    footerimg = "bottom_CI_DNH.jpg";
                    break;

                case "00900": //DCS
                    testoiniziale = "La Sig.ra Chiara Pavesi nella qualità di Procuratore della società Deloitte Climate & Sustainability S.r.l. Società Benefit, utilizzatrice in virtù di contratto di locazione a lungo termine di veicoli senza conducente con " + txtFornitore.Text + " del veicolo " + txtVeicolo.Text + " targato " + txtTarga.Text + ".";
                    testosocieta = "Deloitte Nexthub S.r.l.";
                    intestazioneimg = "header_CI_DCS.jpg";
                    footerimg = "bottom_CI_DCS.jpg";
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


            Paragraph newline = new Paragraph(new Text("\n"));  // New line

            Paragraph header = new Paragraph("Delega a condurre da cliente a terzi")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(11)
               .SetBold();
            document.Add(header);

            Paragraph header2 = new Paragraph("Autorizzazione alla conduzione di veicolo")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(11)
               .SetBold();
            document.Add(header2);
            document.Add(newline);

            Paragraph text1 = new Paragraph(testoiniziale)
               .SetTextAlignment(TextAlignment.JUSTIFIED)
               .SetFontSize(11);
            document.Add(text1);

            Paragraph text2 = new Paragraph("autorizza")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(11)
               .SetBold();
            document.Add(text2);

            Paragraph text3 = new Paragraph("il/la Sig./ra " + txtDenominazione.Text + ", nato/a " + txtLuogoNascita.Text + " il giorno " + txtDataNascita.Text + "," +
                " residente a " + txtCitta.Text + " in Via " + txtIndirizzo.Text + ", n. " + txtCivico.Text + ", nr.Patente " + txtNrPatente.Text + "," +
                " rilasciata il giorno " + txtDataRilascioPatente.Text + ", da " + txtEntePatente.Text + " e con scadenza " + txtScadenzaPatente.Text + " in qualità di dipendente")
               .SetTextAlignment(TextAlignment.JUSTIFIED)
               .SetFontSize(11);
            document.Add(text3);

            Paragraph text4 = new Paragraph("e")
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11);
            document.Add(text4);

            Paragraph text5 = new Paragraph("il/la Sig./ra " + txtDenominazioneDelegato.Text + ", nato/a " + txtLuogoNascitaDelegato.Text + " il giorno " + txtDataNascitaDelegato.Text + "," +
                " residente a " + txtCittaDelegato.Text + " in Via " + txtIndirizzoDelegato.Text + ", n. " + txtCivicoDelegato.Text + ", nr.Patente " + txtNrPatenteDelegato.Text + "," +
                " rilasciata il giorno " + txtDataRilascioPatenteDelegato.Text + ", da " + txtEntePatenteDelegato.Text + " e con scadenza " + txtScadenzaPatenteDelegato.Text + " in qualità " +
                " di " + ddlTipoUtente.SelectedValue)
               .SetTextAlignment(TextAlignment.JUSTIFIED)
               .SetFontSize(11);
            document.Add(text5);

            Paragraph text6 = new Paragraph("a condurre il veicolo " + txtVeicolo.Text + " targato " + txtTarga.Text)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11)
               .SetBold();
            document.Add(text6);

            Paragraph text7 = new Paragraph("in virtù dell’accordo avente per oggetto la locazione di autoveicoli a lungo termine stipulato con " + txtFornitore.Text + ".")
               .SetTextAlignment(TextAlignment.JUSTIFIED)
               .SetFontSize(11);
            document.Add(text7);

            Paragraph text8 = new Paragraph("La presente autorizzazione è valida sino alla data in cui terminerà la locazione.")
               .SetTextAlignment(TextAlignment.JUSTIFIED)
               .SetFontSize(11);
            document.Add(text8);

            Paragraph text9 = new Paragraph("Milano, " + txtDataDocumento.Text)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11);
            document.Add(text9);

            Paragraph text13 = new Paragraph(testosocieta)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11);
            document.Add(text13);

            iText.Layout.Element.Image img = new iText.Layout.Element.Image(ImageDataFactory
            .Create(Server.MapPath("/plugins/images/FIRMA_CHIARA.jpg")));
            document.Add(img);


            Paragraph text11 = new Paragraph("Chiara Pavesi")
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11);
            document.Add(text11);

            Paragraph text12 = new Paragraph("Procuratore")
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(11);
            document.Add(text12);

            document.Close();


            //backgroundDocument.Close();


            string containerName = "deleghe";
            string blobName = filepdf;
            string fileName = filepdf;
            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/deleghe/";
            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/deleghe/";
            string sas = Global.sas;

            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
            string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

            Response.Write(resultBlob);


            servizioContratti.UpdatePdfDocDelega(iddelega, filepdf, SeoHelper.ReturnSessionTenant());

            IContratti delNew2 = new Contratti
            {
                Idtipomodulo = 1,
                Modulofirmato = filepdf,
                Uidtenant = Uidtenant
            };

            servizioContratti.InsertDelega(delNew2);
        }
    }
}
