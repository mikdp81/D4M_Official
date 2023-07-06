// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModConfermaPool.aspx.cs" company="">
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
    public partial class ModConfermaPool : System.Web.UI.Page
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

            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    IContratti contrattoNew = new Contratti();
                    IContratti contrattoNew2 = new Contratti();
                    IContratti contrattoNew3 = new Contratti();

                    IContratti data2 = servizioContratti.DetailOrdiniPoolId(uid);
                    if (data2 != null)
                    {
                        IContratti data = servizioContratti.DetailContrattiId2(data2.Idcontratto);
                        if (data != null)
                        {
                            //nuovo contratto
                            contrattoNew.Codsocieta = data.Codsocieta;
                            contrattoNew.UserId = data2.UserId;
                            contrattoNew.Codjatoauto = data.Codjatoauto;
                            contrattoNew.Codcarpolicy = data.Codcarpolicy;
                            contrattoNew.Codcarlist = data.Codcarlist;
                            contrattoNew.Codfornitore = data.Codfornitore;
                            contrattoNew.Numordineordine = data.Numeroordine;
                            contrattoNew.Canoneleasing = data.Canoneleasing;
                            contrattoNew.Codtipocontratto = data.Codtipocontratto;
                            contrattoNew.Codtipousocontratto = data.Codtipousocontratto;
                            contrattoNew.Numerocontratto = data.Numerocontratto;
                            contrattoNew.Duratamesi = data.Duratamesi;
                            contrattoNew.Kmcontratto = data.Kmcontratto;
                            contrattoNew.Franchigia = data.Franchigia;
                            contrattoNew.Annotazionicontratto = data.Annotazionicontratto;
                            contrattoNew.Targa = data.Targa;
                            contrattoNew.Dataimmatricolazione = data.Dataimmatricolazione;
                            contrattoNew.Scadenzabollo = data.Scadenzabollo;
                            contrattoNew.Scadenzasuperbollo = data.Scadenzasuperbollo;
                            contrattoNew.Bollo = data.Bollo;
                            contrattoNew.Superbollo = data.Superbollo;
                            contrattoNew.Datacontratto = DateTime.Now;
                            contrattoNew.Datainiziocontratto = DateTime.Now;
                            contrattoNew.Datainiziouso = DateTime.Now;
                            contrattoNew.Datafinecontratto = data.Datafinecontratto;
                            contrattoNew.Idstatuscontratto = 0;

                            //assegnazione contratto nuovo
                            contrattoNew3.UserId = data2.UserId;
                            contrattoNew3.Targa = data.Targa;
                            contrattoNew3.Assegnatodal = DateTime.Now;
                            contrattoNew3.Assegnatoal = data.Datafinecontratto;
                            contrattoNew3.Idstatusassegnazione = 0;
                            contrattoNew3.Codsocieta = data.Codsocieta;


                            //aggiorna contratto precedente
                            contrattoNew2.Datafinecontratto = DateTime.Now.AddDays(-1);
                            contrattoNew2.Idstatuscontratto = 10;
                            contrattoNew2.Uid = data.Uid;
                            contrattoNew2.Uidtenant = SeoHelper.ReturnSessionTenant();

                            //aggiorna assegnazione contratto precedente
                            servizioContratti.UpdateTerminaAssegnazioneContratto(data2.Idcontratto, DateTime.Now.AddDays(-1), SeoHelper.ReturnSessionTenant());

                        }


                        //conferma dbs ordine
                        if (servizioContratti.UpdateChangeStatusOrdinePool(uid, 60, "", SeoHelper.ReturnSessionTenant()) == 1)
                        {
                            if (servizioContratti.UpdateContrattiPool(contrattoNew2) == 1)
                            {
                                if (servizioContratti.InsertContratti(contrattoNew) == 1)
                                {

                                    //recupero ultimo idcontratto
                                    IContratti dataContr = servizioContratti.ReturnUltimoIdContratto();
                                    if (dataContr != null)
                                    {
                                        //inserisci nuova assegnazione contratto
                                        contrattoNew3.Idcontratto = dataContr.Idcontratto;

                                        servizioContratti.InsertInizioAssegnazioneContratto(contrattoNew3);
                                    }

                                    ILogBL log = new LogBL();
                                    log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Conferma Ordine Pool - Contrattualizzato " + uid);

                                    //messaggio avvenuta cancellazione
                                    pnlMessage.Visible = true;
                                    pnlMessage.CssClass = "alert alert-success";
                                    lblMessage.Text = "Conferma Ordine avvenuta. Nuovo contratto creato<br /> <a href='" + ResolveUrl("~/Admin/Modules/Ordini/RichiesteOrdiniPool") + "'>Ritorna alla Lista</a>";
                                }
                            }
                            else
                            {
                                pnlMessage.Visible = true;
                                pnlMessage.CssClass = "alert alert-danger";
                                lblMessage.Text += "Operazione fallita";
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
                else
                {
                    Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
                }
            }
        
        }

    }
}
