// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModConsegna.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Ordini
{
    public partial class ModConsegna : System.Web.UI.Page
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
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            ICarsBL servizioCar = new CarsBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Int32.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out int uid))
                {
                    IContratti dataA = servizioContratti.DetailAssegnazioniContrattiXId(uid);
                    if (dataA != null)
                    {
                        txtDataConsegna.Text = SeoHelper.CheckDataString(dataA.Dataconsegna);
                        txtOraConsegna.Text = dataA.Oraconsegna;
                        txtLuogoConsegna.Text = dataA.Luogoconsegna;
                        txtAnnotazioniConsegna.Text = dataA.Noteconsegna;
                        hdidass.Value = dataA.Idassegnazione.ToString();
                        lblTarga.Text = dataA.Targa;

                        if (!string.IsNullOrEmpty(dataA.Motivoscarto))
                        {
                            lblDati.Text += "Motivo Scarto <br /><h3>" + dataA.Motivoscarto + "</h3>";
                        }
                        if (!string.IsNullOrEmpty(dataA.Motivorifiutoauto))
                        {
                            lblDati.Text += "Motivo Rifiuto <br /><h3>" + dataA.Motivorifiutoauto + "</h3>";
                        }
                        if (!string.IsNullOrEmpty(dataA.Filerifiutoauto))
                        {
                            lblDati.Text = "Rifiuto Auto<br /><h3><a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataA.Filerifiutoauto + "\" target='_blank'>Apri File</a></h3>";
                        }
                        if (!string.IsNullOrEmpty(dataA.Fileverbaleauto))
                        {
                            lblDati.Text = "Verbale<br /><h3><a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataA.Fileverbaleauto + "\" target='_blank'>Apri File</a></h3>";
                        }
                        if (!string.IsNullOrEmpty(dataA.Filelibrettoauto))
                        {
                            lblDati.Text = "Libretto<br /><h3><a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataA.Filelibrettoauto + "\" target='_blank'>Apri File</a></h3>";
                        }
                        if (!string.IsNullOrEmpty(dataA.Tipogomme))
                        {
                            lblDati.Text += "Tipo gomme <br /><h3>" + dataA.Tipogomme + "</h3>";
                        }
                        if (!string.IsNullOrEmpty(dataA.Luogogomme))
                        {
                            lblDati.Text += "Luogo gomme <br /><h3>" + dataA.Luogogomme + "</h3>";
                        }
                        if (dataA.Datacambiogomme > DateTime.MinValue)
                        {
                            lblDati.Text += "Data cambio gomme <br /><h3>" + dataA.Datacambiogomme.ToString("dd/MM/yyyy") + "</h3>";
                        }
                        if (dataA.Kmrestituzione > 0)
                        {
                            lblDati.Text += "Km restituzione <br /><h3>" + dataA.Kmrestituzione + "</h3>";
                        }

                        if (!string.IsNullOrEmpty(dataA.Fileverbaleconsegna))
                        {
                            lblDati.Text = "Verbale Consegna<br /><h3><a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataA.Fileverbaleconsegna + "\" target='_blank'>Apri File</a></h3>";
                        }
                        if (!string.IsNullOrEmpty(dataA.Filerelazioneperito))
                        {
                            lblDati.Text = "Relazione perito<br /><h3><a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataA.Filerelazioneperito + "\" target='_blank'>Apri File</a></h3>";
                        }
                        if (!string.IsNullOrEmpty(dataA.Filedenunce))
                        {
                            lblDati.Text = "Denunce<br /><h3><a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataA.Filedenunce + "\" target='_blank'>Apri File</a></h3>";
                        }



                        //nome driver
                        IAccount dataU = servizioAccount.DetailId(dataA.UserId);
                        if (dataU != null)
                        {
                            lblDriver.Text = dataU.Cognome + " " + dataU.Nome;
                        }

                        IContratti dataC = servizioContratti.DetailContrattiId2(dataA.Idcontratto);
                        if (dataC != null)
                        {
                            //recupero modello auto
                            ICars dataCar = servizioCar.DetailCarListAutoXCodjato(dataC.Codjatoauto, dataC.Codcarlist);
                            if (dataCar != null)
                            {
                                lblModello.Text = dataCar.Modello;
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
        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            IContratti contrattoNew = new Contratti
            {
                Dataconsegna = SeoHelper.DataString(txtDataConsegna.Text),
                Oraconsegna = SeoHelper.EncodeString(txtOraConsegna.Text),
                Luogoconsegna = SeoHelper.EncodeString(txtLuogoConsegna.Text),
                Noteconsegna = SeoHelper.EncodeString(txtAnnotazioniConsegna.Text),
                Idassegnazione = SeoHelper.IntString(hdidass.Value),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;

            if (contrattoNew.Dataconsegna == DateTime.MinValue)
            {
                txtDataConsegna.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Data consegna<br />";
            }
            else
            {
                txtDataConsegna.CssClass = "form-control";
            }


            if (string.IsNullOrEmpty(contrattoNew.Oraconsegna))
            {
                txtOraConsegna.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Ora consegna<br />";
            }
            else
            {
                txtOraConsegna.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Luogoconsegna))
            {
                txtLuogoConsegna.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Luogo consegna<br />";
            }
            else
            {
                txtLuogoConsegna.CssClass = "form-control";
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
                if (servizioContratti.UpdateContrattoConsegna(contrattoNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Data Consegna Contratto: " + contrattoNew.Idassegnazione);

                    Response.Redirect("ViewRitiroAuto");
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Operazione fallita";
                }                    
                
            }
        }
        protected void btnMail_Click(object sender, EventArgs e)
        {
            //invio mail notifica consegna
            /*if (!string.IsNullOrEmpty(txtDataConsegna.Text))
            {
                IUtilitys dataTemplate = servizioUtility.ReturnTemplateEmail(1);
                if (dataTemplate != null)
                {
                    MailHelper.SendMail("", ReturnEmail(new Guid(hduserid.Value)), "", "", "", "", dataTemplate.Oggetto, dataTemplate.Corpo, "");
                }
            
                Response.Redirect("~/Admin/Modules/Contratto/Assegnazioni");
            }*/
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

    }
}
