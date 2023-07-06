// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InsAutoServizio.aspx.cs" company="">
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
using System.IO;
using System.Linq;
using BusinessLogic.Services.blob;
using System.Collections.Generic;

namespace DFleet.Users.Modules.Dash
{
    public partial class InsAutoServizio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {             
            pnlMessage.Visible = false;
            pnlStep1.Visible = true;
            pnlStep2.Visible = false;
            pnlStep2b.Visible = false;
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(ddlTarga.SelectedValue))
            {
                ddlTarga.CssClass = "form-control autotarga is-invalid";
                error += "inserire una targa valida<br />";
            }
            else
            {
                ddlTarga.CssClass = "form-control autotarga";
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
                lblTarga.Text = ddlTarga.SelectedItem.ToString();
                pnlStep1.Visible = false;
                pnlStep2.Visible = true;
                pnlStep2b.Visible = false;
            }
        }
        public string ReturnEvent()
        {
            string retVal = "";
            string targa = ddlTarga.SelectedValue;
            IContrattiBL servizioContratti = new ContrattiBL();

            List<IContratti> data = servizioContratti.SelectPrenotazioniAutoServizio(targa);

            if (data != null && data.Count > 0)
            {
                foreach (IContratti result in data)
                {
                    string datadal = result.Assegnatodal.Year + "-" + result.Assegnatodal.Month.ToString("d2") + "-" + result.Assegnatodal.Day.ToString("d2") + "T" + result.Assegnatodal.Hour.ToString("d2") + ":" + result.Assegnatodal.Minute.ToString("d2") + ":00";
                    string dataal = result.Assegnatoal.Year + "-" + result.Assegnatoal.Month.ToString("d2") + "-" + result.Assegnatoal.Day.ToString("d2") + "T" + result.Assegnatoal.Hour.ToString("d2") + ":" + result.Assegnatoal.Minute.ToString("d2") + ":00";

                    retVal += "{";
                    retVal += "title: '" + result.Noteamministrazione + "', ";
                    retVal += "start: '" + datadal + "', ";
                    retVal += "end: '" + dataal + "'";
                    retVal += "},";
                }

                retVal.Remove(retVal.Trim().Length - 1);
            }

            return retVal;
        }

        protected void btnIns_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            DateTime datadal = SeoHelper.DataString(txtDatadal.Text + " " + ddlOradal.SelectedValue);
            DateTime dataal = SeoHelper.DataString(txtDataal.Text + " " + ddlOraal.SelectedValue);
            string annotazioni = SeoHelper.EncodeString(txtNote.Text);
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);

            if (intera.Checked == true) //se selezionata intera giornata
            {
                datadal = SeoHelper.DataString(txtDatadal.Text + " 00:00");
                dataal = SeoHelper.DataString(txtDatadal.Text + " 00:00").AddDays(1);
            }
            if (metaam.Checked == true) //se selezionata mezza giornata (mattina)
            {
                datadal = SeoHelper.DataString(txtDatadal.Text + " 00:00");
                dataal = SeoHelper.DataString(txtDatadal.Text + " 12:00");
            }
            if (metapm.Checked == true) //se selezionata mezza giornata (pomeriggio)
            {
                datadal = SeoHelper.DataString(txtDatadal.Text + " 12:00");
                dataal = SeoHelper.DataString(txtDatadal.Text + " 00:00").AddDays(1);
            }

            //controllo se data e ora sono gia prenotate
            if (servizioContratti.ExistPrenotazioneAutoServizio(datadal, dataal, targa))
            {
                pnlStep1.Visible = false;
                pnlStep2.Visible = true;
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione. La data inserita &egrave; gi&agrave; stata prenotata.";
            }
            else
            {
                IContratti contrattoNew = new Contratti
                {
                    UserId = (Guid)Membership.GetUser().ProviderUserKey,
                    Targa = targa,
                    Assegnatodal = datadal,
                    Assegnatoal = dataal,
                    Noteamministrazione = annotazioni,
                    Idstatusassegnazione = 1,
                    Uidtenant = SeoHelper.ReturnSessionTenant(),
                    Autorizzatoadmin = 0
                };

                if (servizioContratti.InsertPrenotazioneAutoServizio(contrattoNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento Prenotazione Auto di servizio: " + contrattoNew.Targa);

                    Response.Redirect("ViewAutoServizio");
                }
                else
                {
                    pnlMessage.Visible = true;
                    pnlMessage.CssClass = "alert alert-danger";
                    lblMessage.Text += "Operazione fallita";
                }
            }

        }

        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string elencoauto = "";
            string error = "";
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            DateTime datadal = SeoHelper.DataString(txtDatadalsearch.Text);
            DateTime dataal = SeoHelper.DataString(txtDataalsearch.Text);

            if (datadal == DateTime.MinValue)
            {
                txtDatadalsearch.CssClass = "form-control datePicker is-invalid";
                error += "inserire un valore valido per il campo Data DAL<br />";
            }
            else
            {
                txtDatadalsearch.CssClass = "form-control datePicker";
            }

            if (dataal == DateTime.MinValue)
            {
                txtDataalsearch.CssClass = "form-control datePicker is-invalid";
                error += "inserire un valore valido per il campo Data AL<br />";
            }
            else
            {
                txtDataalsearch.CssClass = "form-control datePicker";
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

                pnlStep1.Visible = false;
                pnlStep2.Visible = false;
                pnlStep2b.Visible = true;

                //costruzione tabella elenco auto di servizio
                List<IContratti> dataAutoServ = servizioContratti.SelectAutoServizioDispo(Uidtenant);

                if (dataAutoServ != null && dataAutoServ.Count > 0)
                {
                    elencoauto += "<table width='100%' cellpadding='0' cellspacing='0' border='0' style='padding:3px;'>";

                    //intestazione 
                    elencoauto += "<tr>";
                    elencoauto += "<td></td>";
                    for (DateTime date = datadal; date <= dataal; date = date.AddDays(1))
                    {
                        elencoauto += "<td class='font-bold' style='padding:3px;'>" + date.ToString("dd/MM/yyyy") + "</td>";
                    }
                    elencoauto += "</tr>";


                    //elenco auto
                    foreach (IContratti resultAutoServ in dataAutoServ)
                    {
                        elencoauto += "<tr>";
                        elencoauto += "<td style='padding:3px;'>" + resultAutoServ.Targa + " - " + resultAutoServ.Modello + "</td>";
                        for (DateTime date = datadal; date <= dataal; date = date.AddDays(1))
                        {
                            elencoauto += "<td style='padding:3px;'>" + ReturnDispoAuto(date, resultAutoServ.Targa) + "</td>";
                        }
                        elencoauto += "</tr>";
                        elencoauto += "<tr><td colspan='30'><hr></td></tr>";
                    }

                    elencoauto += "</table>";
                }

                ltAutodispo.Text = elencoauto;
            }
        }

        public string ReturnDispoAuto(DateTime data, string targa)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string retVal = "";

            List<IContratti> dataAutoServ = servizioContratti.DispoAutoServizioXDay(targa, data);

            if (dataAutoServ != null && dataAutoServ.Count > 0) // c'è almeno un orario occupato
            {
                foreach (IContratti resultAutoServ in dataAutoServ)
                {
                    string dicituraassegnazione = "";

                    if (resultAutoServ.Autorizzatoadmin == 1)
                    {
                        dicituraassegnazione = "Assegnata";
                    }
                    else
                    {
                        dicituraassegnazione = "Prenotata";
                    }

                    if (resultAutoServ.Assegnatodal.Hour == 8 && resultAutoServ.Assegnatoal.Hour == 20) //se tutta la giornata occupata
                    {
                        retVal += "<span class='text-red'>" + dicituraassegnazione + " dalle h. " + resultAutoServ.Assegnatodal.Hour.ToString("00") + ":" + resultAutoServ.Assegnatodal.Minute.ToString("00") + " alle " +
                                  resultAutoServ.Assegnatoal.Hour.ToString("00") + ":" + resultAutoServ.Assegnatoal.Minute.ToString("00") + "</span><br />";
                    }
                    else
                    {
                        retVal += "<select name='oradal_" + targa + "' class='oradal' data-id='" + targa + "' id='oradal_" + targa + "'>" + ReturnOre(data, "Dal") + "</select>";

                        retVal += "<select name='oraal_" + targa + "' class='oraal' data-id='" + targa + "' id='oraal_" + targa + "'>" + ReturnOre(data, "Al") + "</select>";

                        retVal += "<br /><span class='text-red'>" + dicituraassegnazione + " dalle h. " + resultAutoServ.Assegnatodal.Hour.ToString("00") + ":" + resultAutoServ.Assegnatodal.Minute.ToString("00") + " alle " +
                                  resultAutoServ.Assegnatoal.Hour.ToString("00") + ":" + resultAutoServ.Assegnatoal.Minute.ToString("00") + "</span>";
                    }
                }
            }
            else //nessun orario occupato - tutta la giornata disponibile
            {
                retVal += "<select name='oradal_" + targa + "' class='oradal' data-id='" + targa + "' id='oradal_" + targa + "'>" + ReturnOre(data, "Dal") + "</select>";

                retVal += "<select name='oraal_" + targa + "' class='oraal' data-id='" + targa + "' id='oraal_" + targa + "'>" + ReturnOre(data, "Al") + "</select>";
            }
            
            return retVal;
        }

        public string ReturnOre(DateTime data, string etichetta)
        {
            string datashort = data.ToString("dd/MM/yyyy");
            return "<option value=''>" + etichetta + "</option><option value='" + datashort + " 00:00'>00:00</option><option value='" + datashort + " 01:00'>01:00</option><option value='" + datashort + " 02:00'>02:00</option>" +
                    "<option value='" + datashort + " 03:00'>03:00</option><option value='" + datashort + " 04:00'>04:00</option><option value='" + datashort + " 05:00'>05:00</option><option value='" + datashort + " 06:00'>06:00</option>" +
                    "<option value='" + datashort + " 07:00'>07:00</option><option value='" + datashort + " 08:00'>08:00</option><option value='" + datashort + " 09:00'>09:00</option><option value='" + datashort + " 10:00'>10:00</option>" +
                    "<option value='" + datashort + " 11:00'>11:00</option><option value='" + datashort + " 12:00'>12:00</option><option value='" + datashort + " 13:00'>13:00</option><option value='" + datashort + " 14:00'>14:00</option>" +
                    "<option value='" + datashort + " 15:00'>15:00</option><option value='" + datashort + " 16:00'>16:00</option><option value='" + datashort + " 17:00'>17:00</option><option value='" + datashort + " 18:00'>18:00</option>" +
                    "<option value='" + datashort + " 19:00'>19:00</option><option value='" + datashort + " 20:00'>20:00</option><option value='" + datashort + " 21:00'>21:00</option><option value='" + datashort + " 22:00'>22:00</option>" +
                    "<option value='" + datashort + " 23:00'>23:00</option>";
        }


        protected void btnIns2_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string annotazioni = SeoHelper.EncodeString(txtNoteIns.Text);
            string targa = SeoHelper.EncodeString(hdtarga.Value);
            DateTime datadal = SeoHelper.DataString(Request.Form["oradal_" + targa]);
            DateTime dataal = SeoHelper.DataString(Request.Form["oraal_" + targa]);

            //controllo se data e ora sono gia prenotate
            if (servizioContratti.ExistPrenotazioneAutoServizio(datadal, dataal, targa))
            {
                pnlStep1.Visible = false;
                pnlStep2.Visible = true;
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Attenzione. La data inserita &egrave; gi&agrave; stata assegnata.";
            }
            else
            {
                IContratti contrattoNew = new Contratti
                {
                    UserId = (Guid)Membership.GetUser().ProviderUserKey,
                    Targa = targa,
                    Assegnatodal = datadal,
                    Assegnatoal = dataal,
                    Noteamministrazione = annotazioni,
                    Idstatusassegnazione = 1,
                    Uidtenant = SeoHelper.ReturnSessionTenant(),
                    Autorizzatoadmin = 0
                };

                if (servizioContratti.InsertPrenotazioneAutoServizio(contrattoNew) == 1)
                {
                    ILogBL log = new LogBL();
                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Inserimento Prenotazione Auto di servizio: " + contrattoNew.Targa);

                    Response.Redirect("ViewAutoServizio");
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
