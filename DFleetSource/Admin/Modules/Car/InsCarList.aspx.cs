// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsCarList.aspx.cs" company="">
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
using System.Web.UI.WebControls;
using System.IO;
using System.Linq;
using BusinessLogic.Services.blob;

namespace DFleet.Admin.Modules.Car
{
    public partial class InsCarList : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(5)) //controllo se la pagina è autorizzata per l'utente 
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
            InsertCarList("salvanuovo");
        }
        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            InsertCarList("salvachiudi");
        }

        public void InsertCarList(string opzione)
        {
            string tmpcodice = string.Empty;

            foreach (ListItem item in ddlCarList.Items)
            {
                if (item.Selected)
                {
                    tmpcodice += SeoHelper.EncodeString(item.Value) + ",";
                }
            }

            ICarsBL servizioCar = new CarsBL();

            ICars carListNew = new Cars
            {
                Codfornitore = SeoHelper.EncodeString(ddlCodFornitore.SelectedValue),
                Codjatoauto = SeoHelper.EncodeString(txtCodjatoAuto.Text),
                Marca = SeoHelper.EncodeString(txtMarca.Text),
                Modello = SeoHelper.EncodeString(txtModello.Text),
                Cilindrata = SeoHelper.EncodeString(txtCilindrata.Text),
                Alimentazione = SeoHelper.EncodeString(txtAlimentazione.Text),
                Alimentazionesecondaria = SeoHelper.EncodeString(txtAlimentazioneSecondaria.Text),
                Consumo = SeoHelper.DecimalString(txtConsumo.Text),
                Consumourbano = SeoHelper.DecimalString(txtConsumoUrbano.Text),
                Consumoextraurbano = SeoHelper.DecimalString(txtConsumoExtraUrbano.Text),
                Emissioni = SeoHelper.DecimalString(txtEmissioni.Text),
                Costoautobase = SeoHelper.DecimalString(txtCostoAutoBase.Text),
                Costoaci = SeoHelper.DecimalString(txtCostoAci.Text),
                Canoneleasing = SeoHelper.DecimalString(txtCanoneLeasing.Text),
                Fringebenefitbase = SeoHelper.DecimalString(txtFringeBenefit.Text),
                Cambio = SeoHelper.EncodeString(ddlCambio.SelectedValue),
                Giorniconsegna = SeoHelper.IntString(txtGiorni.Text),
                Mesicontratto = SeoHelper.IntString(txtMesiContratto.Text),
                Serbatoio = SeoHelper.DecimalString(txtSerbatoio.Text),
                Visibile = SeoHelper.EncodeString(ddlVisibile.SelectedValue),
                Kwcv = SeoHelper.EncodeString(txtKwcv.Text),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;
            bool controlTipoFile;
            var supportedTypes = new[] { "jpg", "png" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/auto/";


            if (string.IsNullOrEmpty(tmpcodice))
            {
                ddlCarList.CssClass = "select2 select2-multiple is-invalid ";
                error += "inserire un valore valido per il campo Codice<br />";
            }
            else
            {
                ddlCarList.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(carListNew.Codfornitore))
            {
                ddlCodFornitore.CssClass = "form-control is-invalid select2";
                error += "inserire un valore valido per il campo Codice fornitore<br />";
            }
            else
            {
                ddlCodFornitore.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(carListNew.Codjatoauto))
            {
                txtCodjatoAuto.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Codjato auto<br />";
            }
            else
            {
                txtCodjatoAuto.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(carListNew.Marca))
            {
                txtMarca.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Marca<br />";
            }
            else
            {
                txtMarca.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(carListNew.Modello))
            {
                txtModello.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Modello<br />";
            }
            else
            {
                txtModello.CssClass = "form-control";
            }

            // controllo se fuFileFotoAuto contiene un file da caricare
            if (fuFileFotoAuto.HasFile == false)
            {
                controlTipoFile = false;
            }
            else
            {
                fileExt = Path.GetExtension(fuFileFotoAuto.FileName).Substring(1);

                // controllo la dimensione del file
                if (fuFileFotoAuto.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    controlTipoFile = false;
                    error += "Il file non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        controlTipoFile = false;
                        error += "Il file non può essere caricato perché non ha un'estensione .jpg o .png";
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
                if (controlTipoFile) //se i controlli sono corretti carica il file sul server
                {
                    string filename = SeoHelper.OraAttuale() + "-" + fuFileFotoAuto.FileName;
                    // salviamo il file nel percorso calcolato
                    filePath += filename;
                    fuFileFotoAuto.SaveAs(filePath);
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
                        string containerName = "auto";
                        string blobName = filename;
                        string fileName = filename;
                        string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/auto/";
                        string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/auto/";
                        string sas = Global.sas;

                        AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                        string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                        Response.Write(resultBlob);

                        carListNew.Fotoauto = filename;
                    }
                }
                else
                {
                    carListNew.Fotoauto = "";
                }


                foreach (ListItem item in ddlCarList.Items)
                {
                    if (item.Selected)
                    {
                        carListNew.Codcarlist = SeoHelper.EncodeString(item.Value);
                        servizioCar.InsertCarListAuto(carListNew);

                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento " + carListNew.Codcarlist);


                        if (opzione.ToUpper() == "SALVANUOVO")
                        {
                            //reset campi
                            ddlCarList.ClearSelection();
                            ddlCodFornitore.ClearSelection();
                            ddlVisibile.ClearSelection();
                            txtCodjatoAuto.Text = "";
                            txtMarca.Text = "";
                            txtModello.Text = "";
                            txtCilindrata.Text = "";
                            txtAlimentazione.Text = "";
                            txtAlimentazioneSecondaria.Text = "";
                            txtConsumo.Text = "";
                            txtConsumoUrbano.Text = "";
                            txtConsumoExtraUrbano.Text = "";
                            txtEmissioni.Text = "";
                            txtCostoAutoBase.Text = "";
                            txtCostoAci.Text = "";
                            txtGiorni.Text = "";
                            txtMesiContratto.Text = "";
                            txtSerbatoio.Text = "";
                            txtKwcv.Text = "";

                            ddlCarList.CssClass = "form-control";
                            ddlCodFornitore.CssClass = "form-control";
                            txtCodjatoAuto.CssClass = "form-control";
                            txtMarca.CssClass = "form-control";
                            txtModello.CssClass = "form-control";

                            //messaggio avvenuto inserimento
                            pnlMessage.Visible = true;
                            pnlMessage.CssClass = "alert alert-success";
                            lblMessage.Text = "Inserimento avvenuto correttamente <br /> Inserisci Nuova Car List o <a href='" + ResolveUrl("~/Admin/Modules/Car/ViewCarList") + "'>Ritorna alla Lista</a>";
                        }
                        else
                        {
                            Response.Redirect("ViewCarList");
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

    }
}
