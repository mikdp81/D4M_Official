// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModAutoPool.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Pen
{
    public partial class ModAutoPool : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(54)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            ICarsBL servizioCar = new CarsBL();
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            pnlMessage.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Guid.TryParse(SeoHelper.EncodeString(Request.QueryString["uid"]), out Guid uid))
                {
                    hduid.Value = Convert.ToString(uid, CultureInfo.CurrentCulture);

                    IContratti data = servizioContratti.DetailContrattiId(uid);
                    if (data != null)
                    {
                        if (!string.IsNullOrEmpty(data.Codcarpolicy))
                        {
                            lblCodCarPolicy.Text = data.Codcarpolicy;
                        }
                        else
                        {
                            lblCodCarPolicy.Text = "-";
                        }
                        if (!string.IsNullOrEmpty(data.Targa))
                        {
                            lblTarga.Text = data.Targa;
                        }
                        else
                        {
                            lblTarga.Text = "-";
                        }
                        if (!string.IsNullOrEmpty(data.Kmcontratto.ToString()))
                        {
                            lblKmContratto.Text = data.Kmcontratto.ToString();
                        }
                        else
                        {
                            lblKmContratto.Text = "-";
                        }
                        if (!string.IsNullOrEmpty(data.Fringebenefit.ToString()))
                        {
                            lblFringe.Text = data.Fringebenefit.ToString();
                        }
                        else
                        {
                            lblFringe.Text = "-";
                        }
                        if (!string.IsNullOrEmpty(data.Canoneleasing.ToString()))
                        {
                            lblCanone.Text = data.Canoneleasing.ToString();
                        }
                        else
                        {
                            lblCanone.Text = "-";
                        }
                        if (!string.IsNullOrEmpty(data.Codfornitore))
                        {
                            lblFornitore.Text = data.Codfornitore;
                        }
                        else
                        {
                            lblFornitore.Text = "-";
                        }

                        if (data.Checkordinepool == 1)
                        {
                            checkordinepool.Checked = true;
                        }
                        else
                        {
                            checkordinepool.Checked = false;
                        }

                        if (data.Riparazione == 1)
                        {
                            lblRiparazione.Text = "SI";
                        }
                        else
                        {
                            lblRiparazione.Text = "NO";
                        }

                        ddlCodGrade.SelectedValue = data.Gradepool;

                        txtNotePool.Text = data.Notepool;
                        ddlStatusPool.SelectedValue = data.Idstatuspool.ToString();
                        ddlUserIdPool.SelectedValue = Convert.ToString(data.UserIdpool, CultureInfo.CurrentCulture);

                        if (data.Checkassegnatario == 1)
                        {
                            lblCkAssegnazione.Text = "Da riassegnare solo a driver gi&agrave; assegnatari di auto";
                        }


                        //luogo consegna
                        IContratti dataP = servizioContratti.ReturnUserIdAssPool(Uidtenant);
                        if (dataP != null)
                        {
                            IContratti dataA = servizioContratti.ReturnLuogoRestituzioneXTarga(data.Targa);
                            if (dataA != null)
                            {
                                lblCittaRestituzione.Text = dataA.Luogorestituzione + " " + dataA.Centrorestituzione;
                            }
                        }

                        if (string.IsNullOrEmpty(lblCittaRestituzione.Text))
                        {
                            lblCittaRestituzione.Text = "-";
                        }
                    }

                    //recupero modello auto
                    ICars dataCar = servizioCar.DetailCarListAutoXCodjato(data.Codjatoauto, data.Codcarlist);
                    if (dataCar != null)
                    {
                        if (!string.IsNullOrEmpty(dataCar.Marca))
                        {
                            lblMarca.Text = dataCar.Marca;
                        }
                        else
                        {
                            lblMarca.Text = "-";
                        }
                        if (!string.IsNullOrEmpty(dataCar.Modello))
                        {
                            lblModello.Text = dataCar.Modello;
                        }
                        else
                        {
                            lblModello.Text = "-";
                        }
                        if (!string.IsNullOrEmpty(dataCar.Alimentazione))
                        {
                            lblAlimentazione.Text = dataCar.Alimentazione;
                        }
                        else
                        {
                            lblAlimentazione.Text = "-";
                        }
                        if (!string.IsNullOrEmpty(dataCar.Emissioni.ToString()))
                        {
                            lblEmissione.Text = dataCar.Emissioni.ToString();
                        }
                        else
                        {
                            lblEmissione.Text = "-";
                        }
                        if (!string.IsNullOrEmpty(dataCar.Cambio))
                        {
                            lblCambio.Text = dataCar.Cambio;
                        }
                        else
                        {
                            lblCambio.Text = "-";
                        }

                    }

                    //recupero colore
                    ICars dataC = servizioCar.DetailOptionalXCod(data.Codcolore);
                    if (dataC != null)
                    {
                        lblColore.Text = dataC.Optional;
                    }
                    if (string.IsNullOrEmpty(lblColore.Text))
                    {
                        lblColore.Text = "-";
                    }


                    //storico assegnazioni
                    List<IContratti> dataStoricoAss = servizioContratti.SelectContrattiAssXIdContratto(data.Idcontratto);
                    if (dataStoricoAss != null && dataStoricoAss.Count > 0)
                    {
                        foreach (IContratti resultStoricoAss in dataStoricoAss)
                        {
                            lblAssegnazioni.Text += "<strong>" + resultStoricoAss.Cognome + "</strong> <br /> dal " + resultStoricoAss.Assegnatodal.ToString("dd/MM/yyyy") + " al " + resultStoricoAss.Assegnatoal.ToString("dd/MM/yyyy") + "<br />";
                        }
                    }
                    if (string.IsNullOrEmpty(lblAssegnazioni.Text))
                    {
                        lblAssegnazioni.Text = "-";
                    }

                    //recupero societa
                    IUtilitys dataS = servizioUtility.DetailSocietaXCodS(data.Codsocieta);
                    if (dataS != null)
                    {
                        lblSocieta.Text = dataS.Societa;
                    }
                    if (string.IsNullOrEmpty(lblSocieta.Text))
                    {
                        lblSocieta.Text = "-";
                    }


                    IContratti dataK = servizioContratti.SelectKmPercorsiAttuali(data.Targa);
                    if (dataK != null)
                    {
                        lblPercorrenza.Text = dataK.Kmpercorsi.ToString();
                    }
                    if (string.IsNullOrEmpty(lblPercorrenza.Text))
                    {
                        lblPercorrenza.Text = "-";
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
            Guid Uid = new Guid(hduid.Value);

            int _checkordinepool;
            string codgrade = SeoHelper.EncodeString(ddlCodGrade.SelectedValue);
            if (checkordinepool.Checked)
            {
                _checkordinepool = 1;
            }
            else
            {
                _checkordinepool = 0;
            }

            IContratti contrattoNew = new Contratti
            {
                Idstatuspool = SeoHelper.IntString(ddlStatusPool.SelectedValue),
                UserIdpool = new Guid(SeoHelper.EncodeString(ddlUserIdPool.SelectedValue)),
                Notepool = SeoHelper.EncodeString(txtNotePool.Text),
                Uid = new Guid(SeoHelper.EncodeString(hduid.Value)),
                Checkordinepool = _checkordinepool,
                Gradepool = codgrade,
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };


            if (servizioContratti.UpdatePoolContratto2(contrattoNew) == 1)
            {
                ILogBL log = new LogBL();
                log.InsLog(Page.TemplateSourceDirectory + "/" + Page.Title, "Modifica Contratto Auto Pool " + Uid);

                Response.Redirect("AutoPool");
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
