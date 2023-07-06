// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="EditConf.aspx.cs" company="">
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
using DFleet.Classes;

namespace DFleet.Users.Modules.Ordini
{
    public partial class EditConf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
            IContrattiBL servizioContratti = new ContrattiBL();
            ICarsBL servizioCar = new CarsBL();

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailOrdiniId(uid);
                    if (data != null)
                    {
                        hdcodjatoauto.Value = data.Codjatoauto;
                        hdidordine.Value = data.Idordine.ToString();
                        hduid.Value = uid.ToString();
                        lbloptionalcanone.Text = data.Deltacanone.ToString();

                        ICars dataCar = servizioCar.DetailCarListAutoXCodjato(data.Codjatoauto, data.Codcarlist);
                        if (dataCar != null)
                        {

                            lblMarca.Text = dataCar.Marca;
                            lblModello.Text = dataCar.Modello;
                            lblAlimentazione.Text = dataCar.Alimentazione;
                            lblAlimentazionesecondaria.Text = dataCar.Alimentazionesecondaria;
                            lblCilindrata.Text = dataCar.Cilindrata;
                            lblFringebenefitbase.Text = dataCar.Fringebenefitbase.ToString();
                            lblConsumo.Text = dataCar.Consumo.ToString();
                            lblConsumourbano.Text = dataCar.Consumourbano.ToString();
                            lblConsumoextraurbano.Text = dataCar.Consumoextraurbano.ToString();
                            lblEmissioni.Text = dataCar.Emissioni.ToString();
                            lblFoto.Text = ReturnFotoAuto(dataCar.Fotoauto);
                            lblgiorniconsegna.Text = dataCar.Giorniconsegna.ToString();

                        }
                    }
                }
                else
                {
                    Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                }
            }
            RecuperaColori();
            RecuperaOptional();
        }
        public void RecuperaColori()
        {
            ICarsBL servizioCar = new CarsBL();
            string elencocolori = "";
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int count = 0;

            List<ICars> dataOpt = servizioCar.SelectAllColori(SeoHelper.EncodeString(hdcodjatoauto.Value), Uidtenant);
            if (dataOpt != null && dataOpt.Count > 0)
            {
                hdcountcolor.Value = dataOpt.Count.ToString();
                foreach (ICars resultOpt in dataOpt)
                {
                    elencocolori += "<div class='col-sm-2 white-box' style='height:115px;'>";
                    if (servizioCar.ExistOrdineOptionalAuto(SeoHelper.IntString(hdidordine.Value), resultOpt.Codoptional))
                    {
                        elencocolori += "<input type='radio' class='codcolore' data-id='" + count + "' id='codcolore_" + count + "' name='codcolore' checked='checked' value=\"" + resultOpt.Codoptional + "\" />";
                    }
                    else
                    {
                        elencocolori += "<input type='radio' class='codcolore' data-id='" + count + "' id='codcolore_" + count + "' name='codcolore' value=\"" + resultOpt.Codoptional + "\" />";
                    }
                    elencocolori += " &nbsp; " + resultOpt.Optional;
                    elencocolori += "</div>";

                    count++;
                }
            }

            ltcolori.Text = elencocolori;

        }
        public void RecuperaOptional()
        {
            ICarsBL servizioCar = new CarsBL();
            IAccountBL servizioAccount = new AccountBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            string codjatoauto = hdcodjatoauto.Value;
            string elencooptional = "";
            string elencooptionaldiserie = "";
            Guid Uidcarpolicy = Guid.Empty;
            int checkoptionalpag = 0;
            int count = 0;
            int countDivCategory = 0;
            hdcount.Value = servizioCar.SelectCountOptionalAuto(SeoHelper.EncodeString(codjatoauto)).ToString();


            //recupero carpolicy                       
            IAccount dataUt = servizioAccount.DetailId(UserId);
            if (dataUt != null)
            {
                Uidcarpolicy = ReturnUidCarPolicy(dataUt.Codsocieta, dataUt.Gradecode);
            }

            ICars dataC = servizioCar.DetailCarPolicyId(Uidcarpolicy);
            if (dataC != null)
            {
                checkoptionalpag = dataC.Checkoptionalpag;
            }


            //elenco categorie
            List<ICars> dataCatOpt = servizioCar.SelectAllCategoriePrimoLivello(Uidtenant);
            if (dataCatOpt != null && dataCatOpt.Count > 0)
            {
                foreach (ICars resultCatOpt in dataCatOpt)
                {
                    if (servizioCar.SelectCountOptionalAutoCat(codjatoauto, resultCatOpt.Codcategoriaoptional) > 0)
                    {
                        elencooptional += "<div class='category'>" + resultCatOpt.Categoriaoptional + "</div>";
                    }
                    if (servizioCar.SelectCountOptionalAutoCatDiSerie(codjatoauto, resultCatOpt.Codcategoriaoptional) > 0)
                    {
                        elencooptionaldiserie += "<div class='category' data-toggle='#apertura" + countDivCategory + "' style='cursor:pointer;'>" + resultCatOpt.Categoriaoptional + "</div>";
                        elencooptionaldiserie += "<div id='apertura" + countDivCategory + "' style='display:none;'>";
                        countDivCategory++;
                    }

                    //elenco sottocategorie
                    List<ICars> dataSottoCatOpt = servizioCar.SelectAllCategorieSecondoLivelloXCod(resultCatOpt.Codcategoriaoptional);
                    if (dataSottoCatOpt != null && dataSottoCatOpt.Count > 0)
                    {
                        foreach (ICars resultSottoCatOpt in dataSottoCatOpt)
                        {
                            if (servizioCar.SelectCountOptionalAutoSottoCat(codjatoauto, resultCatOpt.Codcategoriaoptional, resultSottoCatOpt.Codcategoriaoptional) > 0)
                            {
                                elencooptional += "<div class='subcategory'>" + resultSottoCatOpt.Categoriaoptional + "</div>";
                            }
                            if (servizioCar.SelectCountOptionalAutoSottoCatDiSerie(codjatoauto, resultCatOpt.Codcategoriaoptional, resultSottoCatOpt.Codcategoriaoptional) > 0)
                            {
                                elencooptionaldiserie += "<div class='subcategory'>" + resultSottoCatOpt.Categoriaoptional + "</div>";
                            }

                            //elenco optional
                            List<ICars> dataOpt = servizioCar.SelectOptionalAuto(SeoHelper.EncodeString(codjatoauto), resultCatOpt.Codcategoriaoptional, resultSottoCatOpt.Codcategoriaoptional);
                            if (dataOpt != null && dataOpt.Count > 0)
                            {
                                foreach (ICars resultOpt in dataOpt)
                                {
                                    string infoicon;

                                    if (!string.IsNullOrEmpty(resultOpt.Note))
                                    {
                                        infoicon = "<i class='icon-info' data-toggle='tooltip' title='' data-original-title='" + resultOpt.Note + "'></i>";
                                    }
                                    else
                                    {
                                        infoicon = "";
                                    }

                                    if (resultOpt.Importooptional == 0)
                                    {
                                        elencooptionaldiserie += "<div class='optional-table'>";
                                        elencooptionaldiserie += "<div class='optional-table-left'><input type='checkbox' class='codoptional' data-id='" + count + "' id='codoptional_" + count + "' name='codoptional_" + count + "' onclick='return false;' checked='checked' value=\"" + resultOpt.Codoptional + "\" /></div>";
                                        elencooptionaldiserie += "<div class='optional-table-center'>" + resultOpt.Optional + " " + infoicon + "</div>";
                                        elencooptionaldiserie += "<div class='optional-table-right'>";
                                        elencooptionaldiserie += " di serie";
                                        elencooptionaldiserie += " <input type='hidden' name='importo_" + count + "' id='importo_" + count + "' size='10' maxlength='20' value='0' />";
                                        elencooptionaldiserie += " <input type='hidden' name='tipoimporto_" + count + "' size='10' maxlength='20' value='0' />";

                                        if (resultOpt.Giorniconsegnaagg == 0)
                                        {
                                            elencooptionaldiserie += " <input type='hidden' name='giorniconsegnaagg_" + count + "' id='giorniconsegnaagg_" + count + "' size='10' maxlength='20' value='0' />";
                                        }
                                        else
                                        {
                                            elencooptionaldiserie += " &nbsp; (giorni consegna aggiuntivi " + resultOpt.Giorniconsegnaagg + ")";
                                            elencooptionaldiserie += " <input type='hidden' name='giorniconsegnaagg_" + count + "' id='giorniconsegnaagg_" + count + "' size='10' maxlength='20' value='" + resultOpt.Giorniconsegnaagg + "' />";
                                        }

                                    }
                                    else
                                    {
                                        elencooptional += "<div class='optional-table'>";
                                        if (servizioCar.ExistOrdineOptionalAuto(SeoHelper.IntString(hdidordine.Value), resultOpt.Codoptional))
                                        {
                                            elencooptional += "<div class='optional-table-left'><input type='checkbox' class='codoptional' data-id='" + count + "' id='codoptional_" + count + "' name='codoptional_" + count + "' checked='checked' value=\"" + resultOpt.Codoptional + "\" /></div>";
                                        }
                                        else
                                        {
                                            elencooptional += "<div class='optional-table-left'><input type='checkbox' class='codoptional' data-id='" + count + "' id='codoptional_" + count + "' name='codoptional_" + count + "' value=\"" + resultOpt.Codoptional + "\" /></div>";
                                        }
                                        elencooptional += "<div class='optional-table-center'>" + resultOpt.Optional + " " + infoicon + "</div>";
                                        elencooptional += "<div class='optional-table-right'>";
                                        elencooptional += " &euro; " + resultOpt.Importooptional;
                                        elencooptional += " <input type='hidden' name='importo_" + count + "' id='importo_" + count + "' size='10' maxlength='20' value='" + resultOpt.Importooptional + "' />";
                                        elencooptional += " <input type='hidden' name='tipoimporto_" + count + "' size='10' maxlength='20' value='1' />";


                                        if (resultOpt.Giorniconsegnaagg == 0)
                                        {
                                            elencooptional += " <input type='hidden' name='giorniconsegnaagg_" + count + "' id='giorniconsegnaagg_" + count + "' size='10' maxlength='20' value='0' />";
                                        }
                                        else
                                        {
                                            elencooptional += " &nbsp; (giorni consegna aggiuntivi " + resultOpt.Giorniconsegnaagg + ")";
                                            elencooptional += " <input type='hidden' name='giorniconsegnaagg_" + count + "' id='giorniconsegnaagg_" + count + "' size='10' maxlength='20' value='" + resultOpt.Giorniconsegnaagg + "' />";
                                        }
                                    }

                                    if (resultOpt.Importooptional == 0)
                                    {
                                        elencooptionaldiserie += "</div></div>";
                                    }
                                    else
                                    {
                                        elencooptional += "</div></div>";
                                    }

                                    count++;
                                }
                            }

                        }
                    }

                    if (servizioCar.SelectCountOptionalAutoCatDiSerie(codjatoauto, resultCatOpt.Codcategoriaoptional) > 0)
                    {
                        elencooptionaldiserie += "</div>";
                    }
                }
            }

            if (!string.IsNullOrEmpty(elencooptional))
            {
                if (checkoptionalpag == 0)
                {
                    ltoptional.Text = elencooptional;
                }
                else
                {
                    ltoptional.Text = "Nessun optional aggiuntivo disponibile";
                }
            }
            else
            {
                ltoptional.Text = "Nessun optional aggiuntivo disponibile";
            }


            if (!string.IsNullOrEmpty(elencooptionaldiserie))
            {
                ltoptionalserie.Text = elencooptionaldiserie;
            }
            else
            {
                ltoptionalserie.Text = "Nessun optional di serie";
            }
        }

        public string ReturnFotoAuto(string fotoauto)
        {
            string retVal;

            if (!string.IsNullOrEmpty(fotoauto))
            {
                retVal = "<img src='../../../DownloadFile?type=auto&nomefile=" + fotoauto + "' class='img-responsive' style='height: 300px !important;'>";
            }
            else
            {
                retVal = "<img src='../../../Repository/auto/nofoto.png' class='img-responsive' style='height: 300px !important;'>";
            }

            return retVal;
        }
        public Guid ReturnUidCarPolicy(string codsocieta, string gradecode)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid retVal = Guid.Empty;

            IContratti dataCodPol = servizioContratti.ReturnCodCarPolicy(codsocieta, gradecode);
            if (dataCodPol != null)
            {
                retVal = dataCodPol.Uid;
            }

            return retVal;
        }

        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            string codcolore;
            string codoptional;
            string importooptional;
            string tipoimporto;
            string giorniconsegnaagg;
            decimal importodeltacanone = 0;
            int contaRecord = Convert.ToInt32(hdcount.Value);
            int contaRecordCol = Convert.ToInt32(hdcountcolor.Value);
            int idordine = SeoHelper.IntString(hdidordine.Value);
            Guid Uidordine = SeoHelper.GuidString(hduid.Value);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            //recupera totale deltacanone
            for (int i = 0; i < contaRecord; i++)
            {
                if (Request.Form["codoptional_" + i] != null)
                {
                    importodeltacanone += SeoHelper.DecimalString(Request.Form["importo_" + i]);
                }
            }


            //inserimento ordine
            IContratti ordineNew = new Contratti
            {
                Deltacanone = importodeltacanone,
                Uid = Uidordine,
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };


            if (servizioContratti.UpdateDeltaCanoneOrdini(ordineNew) == 1)
            {
                //reset optional e colori
                servizioContratti.DeleteConfOrdineOptional(idordine, Uidtenant);


                //inserimento colore
                if (contaRecordCol > 0)
                {
                    codcolore = Request.Form["codcolore"];

                    //inserimento colore solo se selezionato
                    if (codcolore != null)
                    {
                        IContratti ColNew = new Contratti
                        {
                            Idordine = idordine,
                            Codoptional = SeoHelper.EncodeString(codcolore),
                            Importooptional = 0,
                            Uidtenant = Uidtenant
                        };

                        servizioContratti.InsertOrdineOptional(ColNew);
                    }
                }

                //inserimento optional ordine
                if (contaRecord > 0)
                {
                    for (int i = 0; i < contaRecord; i++)
                    {
                        importooptional = Request.Form["importo_" + i];
                        codoptional = Request.Form["codoptional_" + i];
                        tipoimporto = Request.Form["tipoimporto_" + i];
                        giorniconsegnaagg = Request.Form["giorniconsegnaagg_" + i];

                        //inserimento optional solo se selezionato
                        if (codoptional != null)
                        {
                            IContratti OptNew = new Contratti
                            {
                                Idordine = idordine,
                                Codoptional = SeoHelper.EncodeString(codoptional),
                                Uidtenant = Uidtenant
                            };
                            if (tipoimporto == "0") // di serie
                            {
                                OptNew.Importooptional = 0;
                                OptNew.Giorniconsegnaagg = 0;
                            }
                            else //non di serie specifica importo
                            {
                                OptNew.Importooptional = SeoHelper.DecimalString(importooptional);
                                OptNew.Giorniconsegnaagg = SeoHelper.IntString(giorniconsegnaagg);
                            }

                            servizioContratti.InsertOrdineOptional(OptNew);
                        }
                    }
                }

                GeneraPdf(Uidordine, idordine);

                Response.Redirect("RichiesteOrdini");
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Operazione fallita";
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
