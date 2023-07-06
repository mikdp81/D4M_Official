// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="EditRiconsegnaAuto.aspx.cs" company="">
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
using DFleet.Classes;
using System.IO;
using System.Linq;

namespace DFleet.Admin.Modules.Contratto
{
    public partial class EditRiconsegnaAuto : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(14)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti data = servizioContratti.DetailContrattiId(uid);
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
        private void BindData(IContratti data)
        {
            ICarsBL servizioCar = new CarsBL();
            IContrattiBL servizioContratti = new ContrattiBL();
            IAccountBL servizioAccount = new AccountBL();
            string dettagliordine = string.Empty;

            //dettagli documentazione driver e data riconsegna
            IContratti dataA = servizioContratti.DetailContrattiAssId(data.Idcontratto, data.UserId);
            if (dataA != null)
            {
                hdassegnatoal.Value = SeoHelper.CheckDataString(dataA.Assegnatoal);
                txtDataRestituzione.Text = SeoHelper.CheckDataString(dataA.Datarestituzione);
                txtOraRestituzione.Text = dataA.Orarestituzione;
                ddlCittaRestituzione.Text = dataA.Luogorestituzione;
                ddlCentroRestituzione.Text = dataA.Centrorestituzione;
                txtAnnotazionicontratto.Text = dataA.Noteamministrazione;
                ddlstatus.SelectedValue = dataA.Idstatusassegnazione.ToString();
                ddlstatusauto.SelectedValue = dataA.Idstatoauto.ToString();
                hdidass.Value = dataA.Idassegnazione.ToString();
                hdtarga.Value = dataA.Targa;
                hdidcontratto.Value = dataA.Idcontratto.ToString();
                lbltipogomme.Text = dataA.Tipogomme;
                lblluogogomme.Text = dataA.Luogogomme;
                lbldatacambiogomme.Text = SeoHelper.CheckDataString(dataA.Datacambiogomme);
                lblkmrestituzione.Text = dataA.Kmrestituzione.ToString();


                if (!string.IsNullOrEmpty(dataA.Fileverbaleconsegna))
                {
                    lblviewfileverbale.Text = "<a href=\"../../../DownloadFile?type=contratti&nomefile= " + dataA.Fileverbaleconsegna + "\" target='_blank'>Apri File</a>";
                }
                else
                {
                    lblviewfileverbale.Text = "NON CARICATO";
                }
                if (!string.IsNullOrEmpty(dataA.Filerelazioneperito))
                {
                    lblviewfilerelazione.Text = "<a href=\"../../../DownloadFile?type=contratti&nomefile= " + dataA.Filerelazioneperito + "\" target='_blank'>Apri File</a>";
                }
                else
                {
                    lblviewfilerelazione.Text = "NON CARICATO";
                }
                if (!string.IsNullOrEmpty(dataA.Filedenunce))
                {
                    lblviewfiledenunce.Text = "<a href=\"../../../DownloadFile?type=contratti&nomefile= " + dataA.Filedenunce + "\" target='_blank'>Apri File</a>";
                }
                else
                {
                    lblviewfiledenunce.Text = "NON CARICATO";
                }
                if (!string.IsNullOrEmpty(dataA.Notedriver))
                {
                    lblnotedriver.Text = dataA.Notedriver;
                }
                else
                {
                    lblnotedriver.Text = "-";
                }

                if (dataA.Checkdoc.ToUpper() == "SI")
                {
                    btnModifica2.Visible = false;
                    lblcontrollata.Text = "DOCUMENTAZIONE CONTROLLATA";
                }
                else
                {
                    btnModifica2.Visible = true;
                }


            }


            //dettagli driver
            IAccount dataD = servizioAccount.DetailId(data.UserId);
            if (dataD != null)
            {
                hdcodsocieta.Value = dataD.Codsocieta;
                lblDatiDriver.Text += dataD.Cognome + " " + dataD.Nome + " (" + dataD.Matricola + ")";
            }

            //dettagli ordini
            IContratti dataO = servizioContratti.DetailOrdiniId(data.Uidordine);
            if (dataO != null)
            {
                //dati ordine
                dettagliordine += "Num. Ordine <b>" + dataO.Numeroordine + "</b> del <b>" + dataO.Dataordine.ToString("dd/MM/yyyy") + "</b><br />";
                if (!string.IsNullOrEmpty(dataO.Annotazioniordini))
                {
                    dettagliordine += "Note: " + dataO.Annotazioniordini + "<br />";
                }
                if (!string.IsNullOrEmpty(dataO.Motivoscarto))
                {
                    dettagliordine += "Scartato il " + dataO.Data100.ToString("dd/MM/yyyy") + " motivo scarto: " + dataO.Motivoscarto + "<br />";
                }
                dettagliordine += "Canone Leasing: " + dataO.Canoneleasing + "<br />";
                if (dataO.Dataconsegnaprevista > DateTime.MinValue)
                {
                    dettagliordine += "Consegna prevista il: " + dataO.Dataconsegnaprevista.ToString("dd/MM/yyyy") + "<br />";
                }

                if (!string.IsNullOrEmpty(dataO.Filefirma))
                {
                    dettagliordine += "File Firmato: <a href=\"../../../DownloadFile?type=ordini&nomefile= " + dataO.Filefirma + "\" target='_blank'>Apri File</a><br />";
                }
                if (!string.IsNullOrEmpty(dataO.Fileconfermarental))
                {
                    dettagliordine += "File Conferma Fornitore: <a href=\"../../../DownloadFile?type=ordini&nomefile=" + dataO.Fileconfermarental + "\" target='_blank'>Apri File</a><br />";
                }

                if (dataO.Data10 > DateTime.MinValue)
                {
                    dettagliordine += "Pending presa in carico Rental: " + dataO.Data10.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data20 > DateTime.MinValue)
                {
                    dettagliordine += "In attesa di offerta da Rental: " + dataO.Data20.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data25 > DateTime.MinValue)
                {
                    dettagliordine += "Elaborazione offerta: " + dataO.Data25.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data30 > DateTime.MinValue)
                {
                    dettagliordine += "Offerta da valutare Driver: " + dataO.Data30.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data40 > DateTime.MinValue)
                {
                    dettagliordine += "Offerta da valutare D4M: " + dataO.Data40.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data50 > DateTime.MinValue)
                {
                    dettagliordine += "In attesa di evasione Rental: " + dataO.Data50.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data55 > DateTime.MinValue)
                {
                    dettagliordine += "Evaso Rental: " + dataO.Data55.ToString("dd/MM/yyyy") + "<br />";
                }
                if (dataO.Data60 > DateTime.MinValue)
                {
                    dettagliordine += "Offerta contrattualizzata: " + dataO.Data60.ToString("dd/MM/yyyy") + "<br />";
                }

                if (dataO.Data110 > DateTime.MinValue)
                {
                    dettagliordine += "Non Autorizzato: " + dataO.Data110.ToString("dd/MM/yyyy") + "<br />";
                }


                lblDatiOrdine.Text = dettagliordine;


                //recupero modello auto
                ICars dataCar = servizioCar.DetailCarListAutoXCodjato(dataO.Codjatoauto, data.Codcarlist);
                if (dataCar != null)
                {
                    lblAuto.Text = dataCar.Modello;
                }

            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            UpdateContratti();
        }
        protected void btnModifica2_Click(object sender, EventArgs e)
        {
            UpdateContratti2();
        }


        public void UpdateContratti()
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            IContratti contrattoNew = new Contratti
            {
                Idstatusassegnazione = SeoHelper.IntString(ddlstatus.SelectedValue),
                Idstatoauto = SeoHelper.IntString(ddlstatusauto.SelectedValue),
                Datarestituzione = SeoHelper.DataString(txtDataRestituzione.Text),
                Orarestituzione = SeoHelper.EncodeString(txtOraRestituzione.Text),
                Luogorestituzione = SeoHelper.EncodeString(Request.Form[ddlCittaRestituzione.UniqueID].ToString()),
                Centrorestituzione = SeoHelper.EncodeString(Request.Form[ddlCentroRestituzione.UniqueID].ToString()),
                Noteamministrazione = SeoHelper.EncodeString(txtAnnotazionicontratto.Text),
                Idassegnazione = SeoHelper.IntString(hdidass.Value),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            string error = string.Empty;

            if (contrattoNew.Idstatusassegnazione == -1)
            {
                ddlstatus.CssClass = "form-control is-invalid";
                error += "selezionare uno status<br />";
            }
            else
            {
                ddlstatus.CssClass = "form-control";
            }

            if (contrattoNew.Idstatoauto == -1)
            {
                ddlstatusauto.CssClass = "form-control is-invalid";
                error += "selezionare uno status auto<br />";
            }
            else
            {
                ddlstatusauto.CssClass = "form-control";
            }

            if (contrattoNew.Datarestituzione == DateTime.MinValue)
            {
                txtDataRestituzione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Data Restituzione<br />";
            }
            else
            {
                txtDataRestituzione.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Orarestituzione))
            {
                txtOraRestituzione.CssClass = "form-control is-invalid";
                error += "inserire un valore valido per il campo Ora Restituzione<br />";
            }
            else
            {
                txtOraRestituzione.CssClass = "form-control";
            }

            if (string.IsNullOrEmpty(contrattoNew.Luogorestituzione))
            {
                ddlCittaRestituzione.CssClass = "form-control select2 ddlCittaRest is-invalid";
                error += "inserire un valore valido per il campo Citta Restituzione<br />";
            }
            else
            {
                ddlCittaRestituzione.CssClass = "form-control select2 ddlCittaRest";
            }

            if (string.IsNullOrEmpty(contrattoNew.Centrorestituzione))
            {
                ddlCentroRestituzione.CssClass = "form-control select2 ddlCentroRest is-invalid";
                error += "inserire un valore valido per il campo Centro Restituzione<br />";
            }
            else
            {
                ddlCentroRestituzione.CssClass = "form-control select2 ddlCentroRest";
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

                if (servizioContratti.UpdateContrattiAss(contrattoNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Resituzione auto assegnazione: " + contrattoNew.Idassegnazione);


                    //messaggio avvenuto inserimento
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-success";
                    lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Contratto/ViewRiconsegnaAuto") + "'>Ritorna alla Lista</a>";

                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Operazione fallita";
                }
            }
        }

        public void UpdateContratti2()
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid UserId = Guid.Empty;
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            int idstatus = SeoHelper.IntString(ddlstatus.SelectedValue);

            if (servizioContratti.UpdateCheckContrattiAss(SeoHelper.IntString(hdidass.Value), SeoHelper.DataString(txtDataRestituzione.Text), SeoHelper.ReturnSessionTenant()) == 1)
            {
                if (idstatus == 130) // restituita per cambio auto (la macchina va in pool)
                {
                    //recupero UserId utente pool
                    IContratti dataU = servizioContratti.ReturnUserIdAssPool(Uidtenant);
                    if (dataU != null)
                    {
                        UserId = dataU.UserId;
                    }

                    //assegnazione contratto nuovo
                    IContratti contrattoNew3 = new Contratti
                    {
                        UserId = UserId,
                        Targa = SeoHelper.EncodeString(hdtarga.Value),
                        Assegnatodal = SeoHelper.DataString(txtDataRestituzione.Text).AddDays(1),
                        Assegnatoal = SeoHelper.DataString(hdassegnatoal.Value),
                        Idstatusassegnazione = 5,
                        Idcontratto = SeoHelper.IntString(hdidcontratto.Value),
                        Codsocieta = SeoHelper.EncodeString(hdcodsocieta.Value)
                    };
                    servizioContratti.InsertInizioAssegnazioneContratto(contrattoNew3);

                    //sovrascrive l'utente pool nel contratto 
                    IContratti contrattoNew4 = new Contratti
                    {
                        UserId = contrattoNew3.UserId,
                        Idcontratto = contrattoNew3.Idcontratto,
                        Uidtenant = SeoHelper.ReturnSessionTenant()
                    };
                    servizioContratti.UpdateContrattoUserPool(contrattoNew4);

                }


                //messaggio avvenuto inserimento
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-success";
                lblMessage.Text = "Aggiornamento avvenuto correttamente <br /> <a href='" + ResolveUrl("~/Admin/Modules/Contratto/ViewRiconsegnaAuto") + "'>Ritorna alla Lista</a>";

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
