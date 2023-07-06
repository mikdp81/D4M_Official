// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModScarta.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Ordini
{
    public partial class DetailRitiroAuto : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(47)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            ICarsBL servizioCar = new CarsBL();

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailOrdiniId(uid);
                    if (data != null)
                    {
                        ICars dataCar = servizioCar.DetailCarListAutoXCodjato(data.Codjatoauto, data.Codcarlist);
                        if (dataCar != null)
                        {
                            lblAuto.Text = dataCar.Modello;
                            lblDatiAuto.Text = "<div style='float:right;'>" + ReturnFotoAuto(dataCar.Fotoauto) + "</div>" +
                                               "Cilindrata: " + dataCar.Cilindrata + "<br />" +
                                               "Alimentazione: " + dataCar.Alimentazione + "<br />" +
                                               "Alimentazione secondaria: " + dataCar.Alimentazionesecondaria + "<br />" +
                                               "Consumo: " + dataCar.Consumo + "<br />" +
                                               "Consumourbano: " + dataCar.Consumourbano + "<br />" +
                                               "Consumoextraurbano: " + dataCar.Consumoextraurbano + "<br />" +
                                               "Emissioni: " + dataCar.Emissioni + "<br />" +
                                               "Fringe benefit base: " + dataCar.Fringebenefitbase + "<br />";
                        }


                        IContratti dataO = servizioContratti.DetailContrattiXUidordine(uid);
                        if (dataO != null)
                        {
                            IContratti dataA = servizioContratti.DetailContrattiAssId(dataO.Idcontratto, dataO.UserId);
                            if (dataA != null)
                            {
                                if (dataA.Dataconsegna > DateTime.MinValue)
                                {
                                    lblDatiOrdine.Text = "Data Consegna: " + dataA.Dataconsegna.ToString("dd/MM/yyyy") + " ore: " + dataA.Oraconsegna + " a " + dataA.Luogoconsegna;
                                }

                                if (!string.IsNullOrEmpty(dataA.Fileverbaleauto))
                                {
                                    lblViewFileVerbale.Text = "Verbale: <a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataA.Fileverbaleauto + "\" target='_blank'>Apri File</a>";
                                }

                                if (!string.IsNullOrEmpty(dataA.Filelibrettoauto))
                                {
                                    lblViewFileLibretto.Text = "Libretto: <a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataA.Filelibrettoauto + "\" target='_blank'>Apri File</a>";
                                }

                                if (!string.IsNullOrEmpty(dataA.Filerifiutoauto))
                                {
                                    lblViewFileRifiuto.Text = "Rifiuto: <a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataA.Filerifiutoauto + "\" target='_blank'>Apri File</a> <br />" +
                                                              "Motivo: " + dataA.Motivorifiutoauto;
                                }
                            }
                        }

                    }


                }
                else
                {
                    Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
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
