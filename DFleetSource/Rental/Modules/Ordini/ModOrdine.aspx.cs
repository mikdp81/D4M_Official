﻿// ***********************************************************************
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

namespace DFleet.Rental.Modules.Ordini
{
    public partial class ModOrdine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            ICarsBL servizioCar = new CarsBL();
            IAccountBL servizioAccount = new AccountBL();
            string dettagliordine = "";
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    hduid.Value = Convert.ToString(uid, CultureInfo.CurrentCulture);

                    IContratti data = servizioContratti.DetailOrdiniId(uid);
                    if (data != null)
                    {
                        txtDataConsegnaPrevista.Text = SeoHelper.CheckDataString(data.Dataconsegnaprevista);
                        hdFileConfermaRental.Value = data.Fileconfermarental;
                        hdidstatusordine.Value = data.Idstatusordine.ToString();
                        hduserid.Value = data.UserId.ToString();
                        hdidordine.Value = data.Idordine.ToString();
                        lblcanoneleasing.Text = data.Deltacanone.ToString();
                        hdcodjatoauto.Value = data.Codjatoauto;


                        //dati driver
                        IAccount dataUt = servizioAccount.DetailId(data.UserId);
                        if (dataUt != null)
                        {
                            lblDatiDriver.Text += "<div class='table-responsive'><table class='table'>" +
                                           "<tr><td class='width30p nopadding'>Societ&agrave;</td> <td class='width70p nopadding'> " + data.Codsocieta + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Dipendente</td> <td class='width70p nopadding'>" + dataUt.Nome + " " + dataUt.Cognome + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Email</td> <td class='width70p nopadding'> " + dataUt.Email + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Cellulare</td> <td class='width70p nopadding'> " + dataUt.Cellulare + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Sede</td> <td class='width70p nopadding'> " + data.Sedelavoro + "</td></tr>" +
                                           "</table></div>";
                        }



                        //dati ordine
                        dettagliordine += "<div class='table-responsive'><table class='table'><tr><td class='width30p nopadding'>Num. e data ordine</td> <td class='width70p nopadding'>" + data.Numeroordine + " del " + data.Dataordine.ToString("dd/MM/yyyy") + "</td></tr>";
                        if (!string.IsNullOrEmpty(data.Annotazioniordinirenter))
                        {
                            dettagliordine += "<tr><td class='width30p nopadding'>Note</td> <td class='width70p nopadding'> " + data.Annotazioniordinirenter + "</td></tr>";
                        }
                        if (!string.IsNullOrEmpty(data.Motivoscarto))
                        {
                            dettagliordine += "<tr><td class='width30p nopadding'>Scartato il </td> <td class='width70p nopadding'>" + data.Data100.ToString("dd/MM/yyyy") + " motivo scarto: " + data.Motivoscarto + "</td></tr>";
                        }
                        dettagliordine += "<tr><td class='width30p nopadding'>Canone Leasing</td> <td class='width70p nopadding'> " + data.Canoneleasing + "</td></tr>";
                        if (data.Dataconsegnaprevista > DateTime.MinValue)
                        {
                            dettagliordine += "<tr><td class='width30p nopadding'>Consegna prevista il</td> <td class='width70p nopadding'> " + data.Dataconsegnaprevista.ToString("dd/MM/yyyy") + "</td></tr>";
                        }

                        if (!string.IsNullOrEmpty(data.Fileordinepdf))
                        {
                            dettagliordine += "<tr class='no-print'><td class='width30p nopadding'>Configurazione</td> <td class='width70p nopadding'> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Fileordinepdf + "\" target='_blank'>Visualizza</a></td></tr>";
                        }
                        if (!string.IsNullOrEmpty(data.Fileconfermarental))
                        {
                            dettagliordine += "<tr class='no-print'><td class='width30p nopadding'>Offerta</td> <td class='width70p nopadding'> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Fileconfermarental + "\" target='_blank'>Visualizza</a></td></tr>";
                        }
                        if (!string.IsNullOrEmpty(data.Filefirma))
                        {
                            dettagliordine += "<tr class='no-print'><td class='width30p nopadding'>Ordine Firmato</td> <td class='width70p nopadding'> <a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Filefirma + "\" target='_blank'>Visualizza</a></td></tr>";
                        }

                        dettagliordine += "</table></div>";


                        lblDatiOrdine.Text = dettagliordine;


                        ICars dataCar = servizioCar.DetailCarListAutoXCodjato(data.Codjatoauto, data.Codcarlist);
                        if (dataCar != null)
                        {
                            lblCodjatoauto.Text = data.Codjatoauto;
                            lblMarca.Text = dataCar.Marca;
                            lblModello.Text = dataCar.Modello;
                            lblAlimentazione.Text = dataCar.Alimentazione;
                            lblAlimentazionesecondaria.Text = dataCar.Alimentazionesecondaria;
                            lblCilindrata.Text = dataCar.Cilindrata;
                            lblFringebenefitbase.Text = dataCar.Fringebenefitbase.ToString();
                            lblFoto.Text = ReturnFotoAuto(dataCar.Fotoauto);
                        }

                    }

                    RecuperaColori();
                    RecuperaOptional();
                }
                else
                {
                    Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                }
            }
        }
        public void RecuperaColori()
        {
            ICarsBL servizioCar = new CarsBL();
            string elencocolori = "";
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int count = 0;

            List<ICars> dataOpt = servizioCar.SelectAllColori("", Uidtenant);
            if (dataOpt != null && dataOpt.Count > 0)
            {
                foreach (ICars resultOpt in dataOpt)
                {
                    if (servizioCar.ExistOrdineOptionalAuto(SeoHelper.IntString(hdidordine.Value), resultOpt.Codoptional))
                    {
                        elencocolori += "<div class='optional-table'>";
                        elencocolori += "<div class='optional-table-left'><input type='radio' class='codcolore' onclick='return false;' checked='checked' name='codcolore' value=\"" + resultOpt.Codoptional + "\" /></div>";
                        elencocolori += "<div class='optional-table-center'>" + resultOpt.Optional + "</div>";
                        elencocolori += "<div class='optional-table-right'></div>";
                        elencocolori += "</div>";

                        count++;
                    }
                }
            }

            if (count > 0)
            {
                ltcolori.Text = elencocolori;
            }
            else
            {
                ltcolori.Text = "Nessun colore inserito";
            }
        }

        public void RecuperaOptional()
        {
            ICarsBL servizioCar = new CarsBL();
            string codjatoauto = hdcodjatoauto.Value;
            string elencooptional = "";
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int countoptional = 0;

            //elenco categorie
            List<ICars> dataCatOpt = servizioCar.SelectAllCategoriePrimoLivello(Uidtenant);
            if (dataCatOpt != null && dataCatOpt.Count > 0)
            {
                foreach (ICars resultCatOpt in dataCatOpt)
                {
                    //elencooptional += "<div class='category'>" + resultCatOpt.Categoriaoptional + "</div>";

                    //elenco sottocategorie
                    List<ICars> dataSottoCatOpt = servizioCar.SelectAllCategorieSecondoLivelloXCod(resultCatOpt.Codcategoriaoptional);
                    if (dataSottoCatOpt != null && dataSottoCatOpt.Count > 0)
                    {
                        foreach (ICars resultSottoCatOpt in dataSottoCatOpt)
                        {
                            //elencooptional += "<div class='subcategory'>" + resultSottoCatOpt.Categoriaoptional + "</div>";

                            //elenco optional
                            List<ICars> dataOpt = servizioCar.SelectOptionalAuto(SeoHelper.EncodeString(codjatoauto), resultCatOpt.Codcategoriaoptional, resultSottoCatOpt.Codcategoriaoptional);
                            if (dataOpt != null && dataOpt.Count > 0)
                            {
                                foreach (ICars resultOpt in dataOpt)
                                {
                                    if (servizioCar.ExistOrdineOptionalAuto(SeoHelper.IntString(hdidordine.Value), resultOpt.Codoptional))
                                    {
                                        if (resultOpt.Importooptional > 0)
                                        {
                                            elencooptional += "<div class='optional-table'>";
                                            elencooptional += "<div class='optional-table-left'><input type='checkbox' class='codoptional' onclick='return false;' checked='checked' value=\"" + resultOpt.Codoptional + "\" /></div>";
                                            elencooptional += "<div class='optional-table-center'>" + resultOpt.Optional + "</div>";
                                            elencooptional += "<div class='optional-table-right'>";
                                            elencooptional += " &euro; " + servizioCar.DetailImportoOrdineOptionalAuto(SeoHelper.IntString(hdidordine.Value), resultOpt.Codoptional).Importooptional;
                                            elencooptional += "</div>";
                                            elencooptional += "</div>";
                                            countoptional++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (countoptional > 0)
            {
                ltoptional.Text = elencooptional;
            }
            else
            {
                ltoptional.Text = "Nessun optional aggiuntivo";
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = new Guid(hduid.Value);

            string error = string.Empty;
            bool controlTipoFile = false;
            bool controlFileLoad;
            bool controlTrueFileLoad = true;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/ordini/";


            string filename = SeoHelper.OraAttuale() + "-" + fuFileConferma.FileName;
            if (fuFileConferma.HasFile == false)
            {
                filename = hdFileConfermaRental.Value;
                controlFileLoad = false;
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileConferma.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    controlFileLoad = true;
                    error += "Il file non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    controlFileLoad = true;
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
                if (controlFileLoad) //c'è un file da caricare
                {
                    if (controlTipoFile) //se i controlli sono corretti carica il file sul server
                    {
                        // salviamo il file nel percorso calcolato
                        filePath += filename;
                        fuFileConferma.SaveAs(filePath);
                        System.Threading.Thread.Sleep(1000);

                        //controllo virus scanner
                        var scanner = new AntiVirus.Scanner();
                        var resultS = scanner.ScanAndClean(filePath);

                        if (resultS.ToString() != "VirusNotFound")
                        {
                            controlTrueFileLoad = false;
                        }
                    }
                }


                if (!controlTrueFileLoad)
                {
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text = "Attenzione! Si sono verificati i seguenti errori:";
                    lblMessage.Text += "<br /><br /><b>E' stato trovato un virus nel file " + filename + "</b><br />";
                }
                else
                {
                    string containerName = "ordini";
                    string blobName = filename;
                    string fileName = filename;
                    string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                    string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                    string sas = Global.sas;

                    AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                    string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                    Response.Write(resultBlob);


                    int idstatusordine;

                    if (SeoHelper.IntString(hdidstatusordine.Value) == 50 || SeoHelper.IntString(hdidstatusordine.Value) == 55)
                    {
                        idstatusordine = 55;
                    }
                    else
                    {
                        idstatusordine = 25;
                    }


                    if (servizioContratti.UpdateOrdineConfermaRental(Uid, idstatusordine, filename, SeoHelper.DataString(txtDataConsegnaPrevista.Text), SeoHelper.EncodeString(txtNote.Text), SeoHelper.ReturnSessionTenant()) == 1)
                    {
                        //invio mail notifica consegna
                        /*if (!string.IsNullOrEmpty(txtDataConsegna.Text))
                        {
                            IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(1);
                            if (dataTemplate != null)
                            {
                                MailHelper.SendMail("", ReturnEmail(new Guid(hduserid.Value)), "", "", "", "", dataTemplate.Oggetto, dataTemplate.Corpo, "");
                            }
                        }*/
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Elaborazione offerta " + Uid);

                        Response.Redirect("ViewOrdini");
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
