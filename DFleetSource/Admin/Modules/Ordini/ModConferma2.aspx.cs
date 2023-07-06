// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModConferma2.aspx.cs" company="">
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
using FirmaDigitale;
using System.IO;
using BusinessLogic.Services.blob;

namespace DFleet.Admin.Modules.Ordini
{
    public partial class ModConferma2 : System.Web.UI.Page
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
            ICarsBL servizioCar = new CarsBL();
            IAccountBL servizioAccount = new AccountBL();
            string dettagliordine = "";

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailOrdiniId(uid);
                    if (data != null)
                    {
                        hdcodjatoauto.Value = data.Codjatoauto;
                        hdidordine.Value = data.Idordine.ToString();
                        lblcanoneleasing.Text = data.Deltacanone.ToString();
                        hduid.Value = uid.ToString();

                        //dati driver
                        IAccount dataUt = servizioAccount.DetailId(data.UserId);
                        if (dataUt != null)
                        {
                            lblDatiDriver.Text += "<div class='table-responsive'><table class='table'>" +
                                           "<tr><td class='width30p nopadding'>Societ&agrave;</td> <td class='width70p nopadding'> " + data.Committente + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Dipendente</td> <td class='width70p nopadding'>" + dataUt.Nome + " " + dataUt.Cognome + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Email</td> <td class='width70p nopadding'> " + dataUt.Email + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Cellulare</td> <td class='width70p nopadding'> " + dataUt.Cellulare + "</td></tr>" +
                                           "<tr><td class='width30p nopadding'>Sede</td> <td class='width70p nopadding'> " + data.Sedelavoro + "</td></tr>" +
                                           "</table></div>";
                        }




                        //dati ordine
                        dettagliordine += "<div class='table-responsive'><table class='table'><tr><td class='width30p nopadding'>Num. e data ordine</td> <td class='width70p nopadding'>" + data.Numeroordine + " del " + data.Dataordine.ToString("dd/MM/yyyy") + "</td></tr>";
                        if (!string.IsNullOrEmpty(data.Annotazioniordini))
                        {
                            dettagliordine += "<tr><td class='width30p nopadding'>Note</td> <td class='width70p nopadding'> " + data.Annotazioniordini + "</td></tr>";
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
                        lblfileofferta.Text = "<a href=\"../../../DownloadFile?type=ordini&nomefile=" + data.Fileconfermarental + "\" target='_blank'>Scarica e firma il documento di Offerta</a>";

                        ICars dataCar = servizioCar.DetailCarListAutoXCodjato(data.Codjatoauto, data.Codcarlist);
                        if (dataCar != null)
                        {
                            lblCodjatoauto.Text = dataCar.Codjatoauto;
                            lblMarca.Text = dataCar.Marca;
                            lblModello.Text = dataCar.Modello;
                            lblAlimentazione.Text = dataCar.Alimentazione;
                            lblAlimentazionesecondaria.Text = dataCar.Alimentazionesecondaria;
                            lblCilindrata.Text = dataCar.Cilindrata;
                            lblFringebenefitbase.Text = dataCar.Fringebenefitbase.ToString();
                            lblFoto.Text = ReturnFotoAuto(dataCar.Fotoauto);
                        }                       
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
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int count = 0;

            List<ICars> dataOpt = servizioCar.SelectAllColori("", Uidtenant);
            if (dataOpt != null && dataOpt.Count > 0)
            {
                hdcountcolor.Value = dataOpt.Count.ToString();
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
                    //elenco sottocategorie
                    List<ICars> dataSottoCatOpt = servizioCar.SelectAllCategorieSecondoLivelloXCod(resultCatOpt.Codcategoriaoptional);
                    if (dataSottoCatOpt != null && dataSottoCatOpt.Count > 0)
                    {
                        foreach (ICars resultSottoCatOpt in dataSottoCatOpt)
                        {
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
                                            elencooptional += "<div class='optional-table-center'>" + resultOpt.Optional + " (" + resultOpt.Codoptional + ")</div>";
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

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uid = new Guid(hduid.Value);

            string error = string.Empty;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/ordini/";


            string filename = SeoHelper.OraAttuale() + "-" + fuFileOffertaFirmata.FileName;
            if (fuFileOffertaFirmata.HasFile == false)
            {
                error += "Caricare il file firmato ";
            }
            else
            {
                fileExt = Path.GetExtension(filename).Substring(1);

                // controllo la dimensione del file
                if (fuFileOffertaFirmata.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
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


            if (!string.IsNullOrEmpty(error))
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione. Il modulo non è stato compilato correttamente. Si sono verificati i seguenti errori:";
                lblMessage.Text += "<br /><br /><b>" + error + "</b><br />";
            }
            else
            {
                // salviamo il file nel percorso calcolato
                filePath += filename;
                fuFileOffertaFirmata.SaveAs(filePath);
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
                    string containerName = "ordini";
                    string blobName = filename;
                    string fileName = filename;
                    string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                    string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                    string sas = Global.sas;

                    AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                    string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                    Response.Write(resultBlob);

                    //conferma dbs ordine
                    if (servizioContratti.UpdateChangeStatusOrdine(Uid, 50, "", SeoHelper.ReturnSessionTenant()) == 1)
                    {
                        if (servizioContratti.UpdatePdfOrdineFirmato(Uid, filename, (Guid)Membership.GetUser().ProviderUserKey, SeoHelper.ReturnSessionTenant()) == 1)
                        {
                            ILogBL log = new LogBL();
                            log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Conferma Ordine Firmato da DBS " + Uid);

                            Response.Redirect("FirmeOrdini");
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
        }
    }
}
