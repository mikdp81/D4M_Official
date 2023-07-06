// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DetailAuto.aspx.cs" company="">
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

namespace DFleet.Partner.Modules.Dash
{
    public partial class DetailAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            ICarsBL servizioCar = new CarsBL();
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            DateTime assegnatodal = DateTime.MinValue;
            DateTime assegnatoal = DateTime.MinValue;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti dataC = servizioContratti.DetailContrattiId(uid);
                    if (dataC != null)
                    {
                        lblkmtotali.Text = dataC.Kmcontratto.ToString();
                        lblscadenza.Text = dataC.Datafinecontratto.ToString("dd/MM/yyyy");
                        lblFringebenefitbase.Text = dataC.Fringebenefit.ToString();
                        hdcodjatoauto.Value = dataC.Codjatoauto;


                        IContratti dataA = servizioContratti.DetailContrattiAssId(dataC.Idcontratto, UserId);
                        if (dataA != null)
                        {
                            assegnatodal = dataA.Assegnatodal;
                            assegnatoal = dataA.Assegnatoal;
                            lblluogoritiro.Text = dataA.Luogoconsegna;
                        }


                        //certificati assicurativi
                        List<IContratti> dataDoc = servizioContratti.SelectDocumentiAuto(dataC.Targa);
                        if (dataDoc != null && dataDoc.Count > 0)
                        {
                            lbldocumenti.Text += "<strong>Certificato assicurativo:</strong> <br />";

                            foreach (IContratti resultDoc in dataDoc)
                            {
                                lbldocumenti.Text += "Anno: " + resultDoc.Anno + " - <a href=\"../../../DownloadFile?type=contratti&nomefile=" + resultDoc.Nomefile + "\" target='_blank'>Apri Certificato</a><br />";
                            }
                        }

                        //lista km percorsi
                        List<IContratti> dataKm = servizioContratti.SelectKmPercorsi(UserId, dataC.Targa);
                        if (dataKm != null && dataKm.Count > 0)
                        {
                            foreach (IContratti resultKm in dataKm)
                            {
                                lblkmattuali.Text += resultKm.Kmpercorsi;
                            }
                        }

                        //lista consumi
                        decimal improtototale = 0;
                        List<IContratti> dataCons = servizioContratti.SelectConsumiAutoXUser(dataC.Targa, assegnatodal, assegnatoal, UserId);
                        if (dataCons != null && dataCons.Count > 0)
                        {
                            lblConsumi.Text += "<strong>Consumi:</strong> <br />";

                            foreach (IContratti resultCons in dataCons)
                            {
                                improtototale += resultCons.Importototale;
                                lblConsumi.Text += "Importo: " + resultCons.Importototale + " del " + resultCons.Datains.ToString("dd/MM/yyyy") + "<br />";
                            }

                            lblConsumi.Text += "Totale: &euro; <strong>" + improtototale.ToString("F2") + "</strong>";
                        }


                        //recupero modello auto
                        ICars dataCar = servizioCar.DetailCarListAutoXCodjato(dataC.Codjatoauto, dataC.Codcarlist); 
                        if (dataCar != null)
                        {
                            lblMarca.Text = dataCar.Marca;
                            lblModello.Text = dataCar.Modello;
                            lblAlimentazione.Text = dataCar.Alimentazione;
                            lblAlimentazionesecondaria.Text = dataCar.Alimentazionesecondaria;
                            lblCilindrata.Text = dataCar.Cilindrata;
                            lblConsumo.Text = dataCar.Consumo.ToString();
                            lblConsumourbano.Text = dataCar.Consumourbano.ToString();
                            lblConsumoextraurbano.Text = dataCar.Consumoextraurbano.ToString();
                            lblEmissioni.Text = dataCar.Emissioni.ToString();
                            lblFoto.Text = ReturnFotoAuto(dataCar.Fotoauto);
                        }
                        
                    }
                }
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
    }
}
