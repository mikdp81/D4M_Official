// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="CreaPdfConf.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Ordini
{
    public partial class CreaPdfConf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
            IContrattiBL servizioContratti = new ContrattiBL();

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailOrdiniId(uid);
                    if (data != null)
                    {
                        GeneraPdf(uid, data.Idordine);

                        Response.Redirect("ViewConf-" + uid);
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

        public void GeneraPdf(Guid Uidordine, int idordine)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            ICarsBL servizioCar = new CarsBL();
            string filepdf = SeoHelper.OraAttuale() + "_" + idordine + "_order.pdf";
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/ordini/" + filepdf;

            FontProgram fontProgram = FontProgramFactory.CreateFont(Server.MapPath("/css/fonts/calibri.ttf"));
            PdfFont calibri = PdfFontFactory.CreateFont(fontProgram, PdfEncodings.WINANSI);
            PdfWriter writer = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            document.SetFont(calibri);
            Paragraph newline = new Paragraph(new Text("\n"));  // New line


            IContratti data = servizioContratti.DetailOrdiniId(Uidordine);
            if (data != null)
            {
                string imageURL = Server.MapPath("/plugins/images/") + "/logo_nero_d4m.jpg";
                ImageData dataIm = ImageDataFactory.Create(imageURL);

                iText.Layout.Element.Image image = new iText.Layout.Element.Image(dataIm);
      
                document.Add(image);

                document.Add(newline);

                /************ DATI ORDINE E RICHIEDENTE ************/
                Paragraph text1 = new Paragraph("Dati ordine e richiedente")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(14)
                   .SetBold();
                document.Add(text1);

                Paragraph text2 = new Paragraph("Nr. Quotazione: " + data.Numeroordine + " del " + data.Dataordine.ToString("dd/MM/yyyy"))
                   .SetTextAlignment(TextAlignment.JUSTIFIED)
                   .SetFontSize(11);
                document.Add(text2);

                IAccount dataA = servizioAccount.DetailId(data.UserId);
                if (dataA != null)
                {
                    Paragraph text2c = new Paragraph("Società: " + data.Committente)
                       .SetTextAlignment(TextAlignment.JUSTIFIED)
                       .SetFontSize(11);
                    document.Add(text2c);

                    Paragraph text2b = new Paragraph("Dipendente: " + dataA.Cognome + " " + dataA.Nome)
                       .SetTextAlignment(TextAlignment.JUSTIFIED)
                       .SetFontSize(11);
                    document.Add(text2b);

                    Paragraph text2d = new Paragraph("Email: " + dataA.Email)
                       .SetTextAlignment(TextAlignment.JUSTIFIED)
                       .SetFontSize(11);
                    document.Add(text2d);

                    Paragraph text2e = new Paragraph("Cellulare: " + dataA.Cellulare)
                       .SetTextAlignment(TextAlignment.JUSTIFIED)
                       .SetFontSize(11);
                    document.Add(text2e);

                    Paragraph text2f = new Paragraph("Sede: " + dataA.Cittasede + "(" + dataA.Provinciasede + ")")
                       .SetTextAlignment(TextAlignment.JUSTIFIED)
                       .SetFontSize(11);
                    document.Add(text2f);
                }

                document.Add(newline);
                /************ FINE ************/


                /************ VEICOLO ************/
                Paragraph text3 = new Paragraph("Dati veicolo")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(14)
                   .SetBold();
                document.Add(text3);

                ICars dataCar = servizioCar.DetailCarListAutoXCodjato(data.Codjatoauto, data.Codcarlist);
                if (dataCar != null)
                {
                    Paragraph text4m = new Paragraph("Cod. Jato: " + data.Codjatoauto)
                    .SetTextAlignment(TextAlignment.JUSTIFIED)
                    .SetFontSize(11);
                    document.Add(text4m);
                    Paragraph text4n = new Paragraph("Marca: " + dataCar.Marca)
                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                        .SetFontSize(11);
                    document.Add(text4n);
                    Paragraph text4 = new Paragraph("Modello: " + dataCar.Modello)
                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                        .SetFontSize(11);
                    document.Add(text4);
                    Paragraph text4b = new Paragraph("Alimentazione: " + dataCar.Alimentazione)
                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                        .SetFontSize(11);
                    document.Add(text4b);
                    Paragraph text4a = new Paragraph("Cilindrata: " + dataCar.Cilindrata)
                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                        .SetFontSize(11);
                    document.Add(text4a);
                    Paragraph text4h = new Paragraph("Fringe benefit base: " + dataCar.Fringebenefitbase)
                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                        .SetFontSize(11);
                    document.Add(text4h);
                    Paragraph text6 = new Paragraph("Canone Leasing: € " + data.Canoneleasing)
                       .SetTextAlignment(TextAlignment.JUSTIFIED)
                       .SetFontSize(11);
                    document.Add(text6);
                    Paragraph text4g = new Paragraph("Optional canone: € " + data.Deltacanone)
                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                        .SetFontSize(11);
                    document.Add(text4g);
                }

                //colore
                Paragraph text4r = new Paragraph("Colore:")
                   .SetTextAlignment(TextAlignment.JUSTIFIED)
                   .SetFontSize(14)
                   .SetBold();
                document.Add(text4r);

                int countcolore = 0;
                Guid Uidtenant = SeoHelper.ReturnSessionTenant();

                List<ICars> dataOpt = servizioCar.SelectAllColori(data.Codjatoauto, Uidtenant);
                if (dataOpt != null && dataOpt.Count > 0)
                {
                    foreach (ICars resultOpt in dataOpt)
                    {
                        if (servizioCar.ExistOrdineOptionalAuto(idordine, resultOpt.Codoptional))
                        {
                            Paragraph text4i = new Paragraph(resultOpt.Optional)
                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                .SetFontSize(11);
                            document.Add(text4i);
                            countcolore++;
                        }  
                    }
                }

                if (countcolore == 0)
                {
                    Paragraph text4q = new Paragraph("Nessun colore inserito")
                                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                                        .SetFontSize(11);
                    document.Add(text4q);
                }

                //optional
                Paragraph text4o = new Paragraph("Optional aggiuntivi:")
                    .SetTextAlignment(TextAlignment.JUSTIFIED)
                    .SetFontSize(14)
                    .SetBold();
                document.Add(text4o);

                int countoptional = 0;

                List<ICars> dataCatOpt = servizioCar.SelectAllCategoriePrimoLivello(Uidtenant);
                if (dataCatOpt != null && dataCatOpt.Count > 0)
                {
                    foreach (ICars resultCatOpt in dataCatOpt)
                    {
                        //elenco sottocategorie
                        List<ICars> dataSottoCatOpt = servizioCar.SelectAllCategorieSecondoLivelloXCod(resultCatOpt.Codcategoriaoptional);
                        if (dataSottoCatOpt != null && dataSottoCatOpt.Count > 0)
                        {
                            foreach (ICars resultSottoCatOpt in dataSottoCatOpt)
                            {
                                //elenco optional
                                List<ICars> dataOp2 = servizioCar.SelectOptionalAuto(data.Codjatoauto, resultCatOpt.Codcategoriaoptional, resultSottoCatOpt.Codcategoriaoptional);
                                if (dataOp2 != null && dataOp2.Count > 0)
                                {
                                    foreach (ICars resultOp2 in dataOp2)
                                    {
                                        if (servizioCar.ExistOrdineOptionalAuto(idordine, resultOp2.Codoptional))
                                        {
                                            if (resultOp2.Importooptional > 0)
                                            {
                                                Paragraph text4l = new Paragraph(resultOp2.Optional + " € " + resultOp2.Importooptional)
                                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                                .SetFontSize(11);
                                                document.Add(text4l);
                                                countoptional++;
                                            }                                            
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                if (countoptional == 0)
                {
                    Paragraph text4p = new Paragraph("Nessun optional aggiuntivo")
                                        .SetTextAlignment(TextAlignment.JUSTIFIED)
                                        .SetFontSize(11);
                    document.Add(text4p);
                }
            }


            document.Close();


            string containerName = "ordini";
            string blobName = filepdf;
            string fileName = filepdf;
            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
            string sas = Global.sas;

            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
            string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

            Response.Write(resultBlob);

            servizioContratti.UpdatePdfOrdine(idordine, filepdf, SeoHelper.ReturnSessionTenant());
        }

    }
}
