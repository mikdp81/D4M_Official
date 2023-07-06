// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModMulte.aspx.cs" company="">
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
using System.IO;
using System.Linq;
using BusinessLogic.Services.blob;
using DFleet.Classes;

namespace DFleet.Users.Modules.Multa
{
    public partial class ModMulte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IMulteBL servizioMulte = new MulteBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IMulte data = servizioMulte.DetailMulteId(uid);
                    if (data != null)
                    {
                        BindData(data);
                    }
                    else
                    {
                        Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                    }
                }
            }
        }
        private void BindData(IMulte data)
        {
            lblDatiMulta.Text += "<div class='col-md-3'>Numero Verbale</div>";
            lblDatiMulta.Text += "<div class='col-md-9'>" + data.Numeroverbale + " del " + SeoHelper.CheckDataString(data.Datainfrazione) + "</div>";

            if (data.Datapagamento > DateTime.MinValue)
            {
                lblDatiMulta.Text += "<div class='col-md-3'>Pagata il</div><div class='col-md-9'>" + SeoHelper.CheckDataString(data.Datapagamento) + "</div>";
            }
            lblDatiMulta.Text += "<div class='col-md-3'>Ente</div><div class='col-md-9'>" + data.Ente + "</div>";
            lblDatiMulta.Text += "<div class='col-md-3'>Infrazione</div><div class='col-md-9'>" + data.Infrazione + "</div>";
            lblDatiMulta.Text += "<div class='col-md-3'>Data infrazione</div><div class='col-md-9'>" + SeoHelper.CheckDataString(data.Datainfrazione) + "</div>";
            lblDatiMulta.Text += "<div class='col-md-3'>Tipo multa</div><div class='col-md-9'>" + data.Tipomulta + "</div>";
            lblDatiMulta.Text += "<div class='col-md-3'>Targa</div><div class='col-md-9'>" + data.Targa + "</div>";
            if (data.Punti > 0)
            {
                lblDatiMulta.Text += "<div class='col-md-3'>Punti da decurtare</div><div class='col-md-9'>" + data.Punti + "</div>";
            }
            if (data.Importomulta > 0)
            {
                lblDatiMulta.Text += "<div class='col-md-3'>Importo intero (oltre 60 gg)</div><div class='col-md-9'>&euro; " + data.Importomulta.ToString() + "</div>";
            }
            if (data.Importomultaridotto > 0)
            {
                lblDatiMulta.Text += "<div class='col-md-3'>Importo ridotto (6-60 gg)</div><div class='col-md-9'>&euro; " + data.Importomultaridotto.ToString() + "</div>";
            }
            if (data.Importomultascontato > 0)
            {
                lblDatiMulta.Text += "<div class='col-md-3'>Importo scontato (1-5 gg)</div><div class='col-md-9'>&euro; " + data.Importomultascontato.ToString() + "</div>";
            }

            if (!string.IsNullOrEmpty(data.Fileverbale))
            {
                lblDatiMulta.Text += "<div class='col-md-3'>Verbale</div><div class='col-md-9'><a href=\"../../../DownloadFile?type=multe&nomefile=" + data.Fileverbale + "\" target='_blank' class='btn btn-primary font-18'>Apri documento</a></div>";
            }

            if (!string.IsNullOrEmpty(data.Filemanleva))
            {
                lblDatiMulta.Text += "<div class='col-md-3 m-t-20'>Manleva</div><div class='col-md-9 m-t-20'><a href=\"../../../DownloadFile?type=multe&nomefile=" + data.Filemanleva + "\" target='_blank' class='btn btn-primary font-18'>Apri documento </a></div>";
            }
            /*
            if (!string.IsNullOrEmpty(data.Filericevutapagamento))
            {
                lblDatiMulta.Text += "<div class='col-md-3'>Ricevuta Pagamento</div><div class='col-md-9'><a href='../../../DownloadFile?type=multe&nomefile=" + data.Filericevutapagamento + "' target='_blank'>Download</a></div>";
            }*/


            hduid.Value = Convert.ToString(data.Uid, CultureInfo.CurrentCulture);
            if (data.Idstatuslavorazione == 30 || data.Idstatuslavorazione == 40 || data.Idstatuspagamento == 100)
            {
                btnAccetto.Visible = false;
            }

            if (data.Idstatuslavorazione == 30 || data.Idstatuslavorazione == 40 || data.Idstatuspagamento == 100 || data.Datains < DateTime.Now.Date.AddDays(-2))
            {
                blockmanleva.Visible = false;
                btnContesto.Visible = false;
            }

        }

        protected void btnAccetto_Click(object sender, EventArgs e)
        {
            UpdateMulteAccettata(); //accettato
        }
        protected void btnContesto_Click(object sender, EventArgs e)
        {
            UpdateMulteContestata(); //contestato
        }


        public void UpdateMulteAccettata()
        {
            IMulteBL servizioMulte = new MulteBL();

            int idstatuslavorazione = 30; //accettato

            if (servizioMulte.ChangeStasusLavMulta(new Guid(hduid.Value), idstatuslavorazione, "", SeoHelper.ReturnSessionTenant()) == 1)
            {
                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Cambio Status Lavorazione Multa " + SeoHelper.EncodeString(hduid.Value) + " in " + idstatuslavorazione);

                Response.Redirect("ViewMulte");                
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text += "Operazione fallita";
            }
        }
        public void UpdateMulteContestata()
        {
            IMulteBL servizioMulte = new MulteBL();
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uid = SeoHelper.GuidString(hduid.Value);
            Guid UserId = Guid.Empty;

            int idstatuslavorazione = 40; //contestato

            string filemanleva;
            string error = string.Empty;
            var supportedTypes = new[] { "pdf" };
            string fileExt;
            string filePath = RequestExtensions.GetPathPhisicalApplication();
            filePath += "/Repository/multe/";


            if (fuFileManLeva.HasFile == false)
            {
                error += "Caricare il file ManLeva";
            }
            else
            {
                fileExt = Path.GetExtension(fuFileManLeva.FileName).Substring(1);

                // controllo la dimensione del file
                if (fuFileManLeva.PostedFile.ContentLength > SeoHelper.MaxDimensionFile())
                {
                    error += "Il file non può essere caricato perché supera " + SeoHelper.TextMaxDimensionFile();
                }
                else
                {
                    //controllo estensione del file
                    if (!supportedTypes.Contains(fileExt))
                    {
                        error += "Il file non può essere caricato perché non ha un'estensione .jpg o .png";
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
               
                string filename = SeoHelper.OraAttuale() + "-" + fuFileManLeva.FileName;
                // salviamo il file nel percorso calcolato
                filePath += filename;
                fuFileManLeva.SaveAs(filePath);
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
                    string containerName = "multe";
                    string blobName = filename;
                    string fileName = filename;
                    string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/multe/";
                    string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/multe/";
                    string sas = Global.sas;

                    AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                    string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);
                    Response.Write(resultBlob);

                    filemanleva = filename;

                    if (servizioMulte.ChangeStasusLavMulta(new Guid(hduid.Value), idstatuslavorazione, filemanleva, SeoHelper.ReturnSessionTenant()) == 1)
                    {
                        ILogBL log = new LogBL();
                        log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Cambio Status Lavorazione Multa " + SeoHelper.EncodeString(hduid.Value) + " in " + idstatuslavorazione);

                        //invio mail
                        IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(28);
                        if (dataTemplate != null)
                        {
                            //recupero userid
                            IMulte dataUs = servizioMulte.DetailMulteId(Uid);
                            if (dataUs != null)
                            {
                                UserId = dataUs.UserId;
                            }

                            Recuperadatiuser datiUtente = new Recuperadatiuser();
                            MailHelper.SendMail("", "itmulted4m@deloitte.it", "", "", "", "", dataTemplate.Oggetto, servizioUtility.InsMultaEmail(UserId, Uid, dataTemplate.Corpo), "", datiUtente.ReturnObjectTenant());
                        }

                        Response.Redirect("ViewMulte");
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
