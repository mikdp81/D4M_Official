// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ScegliAuto.aspx.cs" company="">
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
    public partial class ScegliAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMessage.Visible = false; 
            string grade = "";
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            ICarsBL servizioCar = new CarsBL();            

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    ICars data = servizioCar.DetailCarListAutoId(uid);
                    if (data != null)
                    {
                        hdcodjatoauto.Value = data.Codjatoauto;
                        hdcodfornitore.Value = data.Codfornitore;
                        hdcodcarlist.Value = data.Codcarlist;
                        hdcanoneleasing.Value = data.Canoneleasing.ToString();

                        lblMarca.Text = data.Marca;
                        lblModello.Text = data.Modello;
                        lblAlimentazione.Text = data.Alimentazione;
                        lblAlimentazionesecondaria.Text = data.Alimentazionesecondaria;
                        lblCilindrata.Text = data.Cilindrata;
                        lblFringebenefitbase.Text = data.Fringebenefitbase.ToString();
                        lblConsumo.Text = data.Consumo.ToString();
                        lblConsumourbano.Text = data.Consumourbano.ToString();
                        lblConsumoextraurbano.Text = data.Consumoextraurbano.ToString();
                        lblEmissioni.Text = data.Emissioni.ToString();
                        lblFoto.Text = ReturnFotoAuto(data.Fotoauto);
                        lblgiorniconsegna.Text = data.Giorniconsegna.ToString();


                    }



                    IAccount dataGrade = servizioAccount.DetailId(UserId);
                    if (dataGrade != null)
                    {
                        grade = dataGrade.Gradecode;
                    }

                    switch (grade)
                    {
                        case "35": //SENIOR + MANAGER
                        case "40":
                        case "27":
                        case "30":
                            hdimportolimiteoptional.Value = SeoHelper.MaxDeltaCanoneSen().ToString();
                            break;

                        case "25": //SMANAGER
                            hdimportolimiteoptional.Value = SeoHelper.MaxDeltaCanoneMan().ToString();
                            break;

                        case "17": //DIRECTOR
                            hdimportolimiteoptional.Value = SeoHelper.MaxDeltaCanoneSMan().ToString();
                            break;
                    }

                    hdidapprovazione.Value = ReturnIdApprovazione();


                    //se staff senior (cod grade 40) - non può configurare 2 volte la stessa auto (se non è stata eliminata)
                    if (grade == "40" && servizioContratti.SelectCountRichiesteOrdiniDriverXCodjato(UserId, SeoHelper.EncodeString(hdcodjatoauto.Value)) > 0)
                    {
                        btnInserisci.Visible = false;
                        pnlMessage.Visible = true;
                        pnlMessage.CssClass = "alert alert-danger";
                        lblMessage.Text = "Non puoi configurare nuovamente la stessa auto";
                    }
                        

                }
            }
            RecuperaColori();
            RecuperaOptional();
        }

        public void RecuperaColori()
        {
            ICarsBL servizioCar = new CarsBL();
            string elencocolori = "";
            string codjatoauto = SeoHelper.EncodeString(hdcodjatoauto.Value);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int count = 0;

            List<ICars> dataOpt = servizioCar.SelectAllColori(codjatoauto, Uidtenant);
            if (dataOpt != null && dataOpt.Count > 0)
            {
                hdcountcolor.Value = dataOpt.Count.ToString();
                foreach (ICars resultOpt in dataOpt)
                {
                    elencocolori += "<div class='col-sm-2 white-box' style='height:115px;'>";
                    elencocolori += "<input type='radio' class='codcolore' data-id='" + count + "' id='codcolore_" + count + "' name='codcolore' value=\"" + resultOpt.Codoptional + "\" />";
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
                                        elencooptional += "<div class='optional-table-left'><input type='checkbox' class='codoptional' data-id='" + count + "' id='codoptional_" + count + "' name='codoptional_" + count + "' value=\"" + resultOpt.Codoptional + "\" /></div>";
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
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            Guid Uidtenant = datiUtente.ReturnUidTenant();

            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            ICarsBL servizioCar = new CarsBL();

            string codcolore;
            string codoptional;
            string importooptional;
            string tipoimporto;
            string giorniconsegnaagg;
            string codsocieta = string.Empty;
            string grade = string.Empty;
            string sedelavoro = "";
            decimal importodeltacanone = 0;
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            int contaRecord = Convert.ToInt32(hdcount.Value);
            int contaRecordCol = Convert.ToInt32(hdcountcolor.Value);
            int idordine = 0;
            Guid Uidordine = Guid.Empty;

            //recupero codsocieta e grade
            IAccount dataUt = servizioAccount.DetailId(UserId);
            if (dataUt != null)
            {
                codsocieta = dataUt.Codsocieta;
                grade = dataUt.Gradecode;
                sedelavoro = dataUt.Cittasede + " (" + dataUt.Provinciasede + ")";
            }

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
                Codsocieta = codsocieta,
                UserId = UserId,
                Codjatoauto = SeoHelper.EncodeString(hdcodjatoauto.Value),
                Codcarpolicy = ReturnCodCarPolicy(codsocieta, grade),
                Codcarlist = SeoHelper.EncodeString(hdcodcarlist.Value),
                Codfornitore = SeoHelper.EncodeString(hdcodfornitore.Value),
                Numeroordine = ReturnNumeroOrdine(),
                Dataordine = DateTime.Now,
                Canoneleasing = SeoHelper.DecimalString(hdcanoneleasing.Value),
                Deltacanone = importodeltacanone,
                Idstatusordine = 0,
                Idapprovazione = SeoHelper.IntString(hdidapprovazione.Value),
                Motivoscarto = "",
                Sedelavoro = sedelavoro,
                Uidtenant = Uidtenant
            };

            //recupera alimentazione tramite il codjato e la carlist
            ICars dataAuto = servizioCar.DetailCarListAutoXCodjato(ordineNew.Codjatoauto, ordineNew.Codcarlist);
            if (dataAuto != null)
            {
                ordineNew.Alimentazione = dataAuto.Alimentazione;
            }
            


            /*if (SeoHelper.MaxDeltaCanone() > importodeltacanone)
            {
                ordineNew.Idstatusordine = 10; //già autorizzato
            }
            else
            {
                ordineNew.Idstatusordine = 1; //configurato
            }
            if (importodeltacanone == 0) 
            {
                ordineNew.Idstatusordine = 40; //se optonal canone = 0 va in status Conferma ordine in firma
            }*/

            if (servizioContratti.InsertOrdini(ordineNew) == 1)
            {

                //recupero idordine inserito
                IContratti data = servizioContratti.ReturnUltimoIdOrdine();
                if (data != null)
                {
                    idordine = data.Idordine;
                    Uidordine = data.Uid;
                }

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
        public string ReturnIdApprovazione()
        {
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            int idutente = 0;
            string retVal = string.Empty;

            IAccount data = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
            if (data != null)
            {
                idutente = data.Iduser;
            }

            IContratti data2 = servizioContratti.ReturnIdApprovazione(idutente);
            if (data2 != null)
            {
                retVal = data2.Idapprovazione.ToString();
            }

            return retVal;
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
    }
}
