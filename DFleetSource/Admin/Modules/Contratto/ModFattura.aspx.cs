// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModFattura.aspx.cs" company="">
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
using OfficeOpenXml;

namespace DFleet.Admin.Modules.Contratto
{
    public partial class ModFattura : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(21)) //controllo se la pagina è autorizzata per l'utente 
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
                    IContratti data = servizioContratti.DetailFattureId(uid);
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

            loadPage();
        }

        public void loadPage()
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            pnlMessage.Visible = false;
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioContratti.SelectCountDetailFatture(SeoHelper.GuidString(hduidfattura.Value), Uidtenant);
            int maxPage = (totaleRighe / 200) + 1;
            lblNumPagTot.Text = maxPage.ToString();
            int pagina;


            if (string.IsNullOrEmpty(hdPagina.Value))
            {
                pagina = 1;
                hdPagina.Value = "1";
            }
            else
            {
                pagina = Convert.ToInt32(hdPagina.Value, CultureInfo.CurrentCulture);
            }


            if (gvRicFatture.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvRicFatture.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            lblNumRecord.Text = "Righe fattura: " + HttpUtility.HtmlEncode(totaleRighe);
            if (totaleRighe == 0)
            {
                lblMessage.Text = "Nessun dato disponibile. Ricerca con altri parametri.";
                pnlMessage.Visible = true;
            }
            else
            {
                pnlMessage.Visible = false;
            }

            if ((pagina - 1) <= 1)
            {
                pagingprec.Enabled = false;
                pagingprec.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingprec.Enabled = true;
                pagingprec.CssClass = "paginate_button";
            }

            if (maxPage < (pagina + 1))
            {
                pagingnext.Enabled = false;
                pagingnext.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingnext.Enabled = true;
                pagingnext.CssClass = "paginate_button";
            }
        }
        private void BindData(IContratti data)
        {
            hduidfattura.Value = data.Uid.ToString();
            ltdatifattura.Text += "Tipo documento: " + data.Tipodocumento + "<br />" +
                                  "Numero documento: " + data.Numerodocumento + "<br />" +
                                  "Data documento: " + data.Datadocumento.ToString("dd/MM/yyyy") + "<br />" +
                                  "Cessionario: " + data.Fornitore + "<br />" +
                                  "Committente: " + data.Committente + "<br />" +
                                  "Importo totale: " + data.Importototale + "<br />" +
                                  "Numero contratto: " + data.Numerocontratto + "<br />" +
                                  "Data contratto: " + data.Datacontratto.ToString("dd/MM/yyyy") + "<br />" +
                                  "Importo pagamento: " + data.Importopagamento + "<br />";
            if (data.Datascadenzapagamento > DateTime.MinValue)
            {
                ltdatifattura.Text += "Data scadenza pagamento: " + data.Datascadenzapagamento.ToString("dd/MM/yyyy") + "<br />";
            }
            ltdatifattura.Text += "<a href=\"../../../DownloadFile?type=import&nomefile=" + data.Filexml + "\" target='_blank'>Visualizza File XML Fattura</a>";

            ddlTemplate.SelectedValue = data.Templateabb.ToString();
            hdtemplateabb.Value = data.Templateabb.ToString();
            txtData.Text = SeoHelper.CheckDataString(data.Datarifabb);

            IUtilitysBL servizioUtilitys = new UtilitysBL();
            IUtilitys dataS = servizioUtilitys.DetailSocietaXPIVA(data.Codcommittente);
            if (dataS != null)
            {
                hdcodsocieta.Value = dataS.Codsocieta;
            }
        }

        /********************** PAGINAZIONE **********************/
        protected void pagingprec_Click(object sender, EventArgs e)
        {
            int valore = Convert.ToInt32(hdPagina.Value, CultureInfo.CurrentCulture);
            Paginations("prec", valore);
        }

        protected void pagingnext_Click(object sender, EventArgs e)
        {
            int valore = Convert.ToInt32(hdPagina.Value, CultureInfo.CurrentCulture);
            Paginations("next", valore);
        }

        protected void txtnumpag_TextChanged(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioContratti.SelectCountDetailFatture(SeoHelper.GuidString(hduidfattura.Value), Uidtenant);
            int maxPage = (totaleRighe / 200) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;

            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRighe = servizioContratti.SelectCountDetailFatture(SeoHelper.GuidString(hduidfattura.Value), Uidtenant);
            int maxPage = (totaleRighe / 200) + 1;

            int pagina = 0;
            int tmppaginaprec = 0;
            int tmppaginanext = 0;

            switch (tipo.ToUpper())
            {
                case "PREC":
                    pagina = valore - 1;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;
                case "NEXT":
                    pagina = valore + 1;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;
                case "ELENCO":
                    pagina = valore;
                    tmppaginaprec = pagina - 1;
                    tmppaginanext = pagina + 1;
                    break;

            }


            if ((tmppaginaprec) < 1)
            {
                pagingprec.Enabled = false;
                pagingprec.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingprec.Enabled = true;
                pagingprec.CssClass = "paginate_button";
            }

            if (maxPage < (tmppaginanext))
            {
                pagingnext.Enabled = false;
                pagingnext.CssClass = "paginate_button cursor-not-allowed";
            }
            else
            {
                pagingnext.Enabled = true;
                pagingnext.CssClass = "paginate_button";
            }

            hdPagina.Value = Convert.ToString(pagina, CultureInfo.CurrentCulture);
            txtnumpag.Text = Convert.ToString(pagina, CultureInfo.CurrentCulture);
        }


        /********************** FINE PAGINAZIONE **********************/

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox ddlCdc = (e.Row.FindControl("txtAutoCdc") as TextBox);
                TextBox ddlCdc2 = (e.Row.FindControl("txtAutoCdc2") as TextBox);
                TextBox ddlCdc3 = (e.Row.FindControl("txtAutoCdc3") as TextBox);
                TextBox ddlCdc4 = (e.Row.FindControl("txtAutoCdc4") as TextBox);
                HiddenField tmpvaloreabbinamento = (e.Row.FindControl("hdvaloreabbinamento") as HiddenField);
                HiddenField tmpvaloreabbinamento2 = (e.Row.FindControl("hdvaloreabbinamento2") as HiddenField);
                HiddenField tmpvaloreabbinamento3 = (e.Row.FindControl("hdvaloreabbinamento3") as HiddenField);
                HiddenField tmpvaloreabbinamento4 = (e.Row.FindControl("hdvaloreabbinamento4") as HiddenField);

                string valoreabbinamento = tmpvaloreabbinamento.Value;
                string valoreabbinamento2 = tmpvaloreabbinamento2.Value;
                string valoreabbinamento3 = tmpvaloreabbinamento3.Value;
                string valoreabbinamento4 = tmpvaloreabbinamento4.Value;

                if (!string.IsNullOrEmpty(valoreabbinamento) && valoreabbinamento != ";;;00000000-0000-0000-0000-000000000000")
                {
                    ddlCdc.Text = valoreabbinamento;
                }

                if (!string.IsNullOrEmpty(valoreabbinamento2) && valoreabbinamento2 != ";;;00000000-0000-0000-0000-000000000000")
                {
                    ddlCdc2.Text = valoreabbinamento2;
                }

                if (!string.IsNullOrEmpty(valoreabbinamento3) && valoreabbinamento3 != ";;;00000000-0000-0000-0000-000000000000")
                {
                    ddlCdc3.Text = valoreabbinamento3;
                }

                if (!string.IsNullOrEmpty(valoreabbinamento4) && valoreabbinamento4 != ";;;00000000-0000-0000-0000-000000000000")
                {
                    ddlCdc4.Text = valoreabbinamento4;
                }
            }            
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uidfattura = SeoHelper.GuidString(hduidfattura.Value);

            foreach (GridViewRow row in gvRicFatture.Rows)
            {
                TextBox ddlCdc = (TextBox)row.FindControl("txtAutoCdc");
                TextBox txtCdc = (TextBox)row.FindControl("txtCdc");
                TextBox ddlCdc2 = (TextBox)row.FindControl("txtAutoCdc2");
                TextBox txtCdc2 = (TextBox)row.FindControl("txtCdc2");
                TextBox ddlCdc3 = (TextBox)row.FindControl("txtAutoCdc3");
                TextBox txtCdc3 = (TextBox)row.FindControl("txtCdc3");
                TextBox ddlCdc4 = (TextBox)row.FindControl("txtAutoCdc4");
                TextBox txtCdc4 = (TextBox)row.FindControl("txtCdc4");
                HiddenField hdUid = (HiddenField)row.FindControl("hdUid");
                TextBox txtDataInizio = (TextBox)row.FindControl("txtDataInizio");
                TextBox txtDataFine = (TextBox)row.FindControl("txtDataFine");
                TextBox txtDataInizio2 = (TextBox)row.FindControl("txtDataInizio2");
                TextBox txtDataFine2 = (TextBox)row.FindControl("txtDataFine2");
                TextBox txtDataInizio3 = (TextBox)row.FindControl("txtDataInizio3");
                TextBox txtDataFine3 = (TextBox)row.FindControl("txtDataFine3");
                TextBox txtDataInizio4 = (TextBox)row.FindControl("txtDataInizio4");
                TextBox txtDataFine4 = (TextBox)row.FindControl("txtDataFine4");

                string codicecdc = "";
                string codicecdc2 = "";
                string codicecdc3 = "";
                string codicecdc4 = "";
                string tipocentrocosto = "";
                string tipocentrocosto2 = "";
                string tipocentrocosto3 = "";
                string tipocentrocosto4 = "";
                string targa = "";
                Guid Uidcentrocosto = Guid.Empty;
                Guid Uidcentrocosto2 = Guid.Empty;
                Guid Uidcentrocosto3 = Guid.Empty;
                Guid Uidcentrocosto4 = Guid.Empty;


                if (!string.IsNullOrEmpty(ddlCdc.Text))
                {
                    string[] array = ddlCdc.Text.Split(';');
                    codicecdc = array[0].ToString();
                    Uidcentrocosto = SeoHelper.GuidString(array[3].ToString());
                    tipocentrocosto = array[2].ToString();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCdc.Text))
                    {
                        codicecdc = txtCdc.Text;
                        tipocentrocosto = "EF_users";
                    }
                }

                if (!string.IsNullOrEmpty(ddlCdc2.Text))
                {
                    string[] array2 = ddlCdc2.Text.Split(';');
                    codicecdc2 = array2[0].ToString();
                    Uidcentrocosto2 = SeoHelper.GuidString(array2[3].ToString());
                    tipocentrocosto2 = array2[2].ToString();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCdc2.Text))
                    {
                        codicecdc2 = txtCdc2.Text;
                        tipocentrocosto2 = "EF_users";
                    }
                }

                if (!string.IsNullOrEmpty(ddlCdc3.Text))
                {
                    string[] array3 = ddlCdc3.Text.Split(';');
                    codicecdc3 = array3[0].ToString();
                    Uidcentrocosto3 = SeoHelper.GuidString(array3[3].ToString());
                    tipocentrocosto3 = array3[2].ToString();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCdc3.Text))
                    {
                        codicecdc3 = txtCdc3.Text;
                        tipocentrocosto3 = "EF_users";
                    }
                }

                if (!string.IsNullOrEmpty(ddlCdc4.Text))
                {
                    string[] array4 = ddlCdc4.Text.Split(';');
                    codicecdc4 = array4[0].ToString();
                    Uidcentrocosto4 = SeoHelper.GuidString(array4[3].ToString());
                    tipocentrocosto4 = array4[2].ToString();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCdc4.Text))
                    {
                        codicecdc4 = txtCdc4.Text;
                        tipocentrocosto4 = "EF_users";
                    }
                }


                IContratti dataD = servizioContratti.DetailFattureDetId(SeoHelper.GuidString(hdUid.Value));
                if (dataD != null)
                {
                    targa = CalcolaTarga(dataD.Descrizione, dataD.Riftesto);
                }

                //abbinamento
                IContratti contrattoNew = new Contratti
                {
                    Centrocostoabb = SeoHelper.EncodeString(codicecdc),
                    Tipocentrocosto = SeoHelper.EncodeString(tipocentrocosto),
                    Uidcentrocosto = Uidcentrocosto,
                    Centrocostoabb2 = SeoHelper.EncodeString(codicecdc2),
                    Tipocentrocosto2 = SeoHelper.EncodeString(tipocentrocosto2),
                    Uidcentrocosto2 = Uidcentrocosto2,
                    Centrocostoabb3 = SeoHelper.EncodeString(codicecdc3),
                    Tipocentrocosto3 = SeoHelper.EncodeString(tipocentrocosto3),
                    Uidcentrocosto3 = Uidcentrocosto3,
                    Centrocostoabb4 = SeoHelper.EncodeString(codicecdc4),
                    Tipocentrocosto4 = SeoHelper.EncodeString(tipocentrocosto4),
                    Uidcentrocosto4 = Uidcentrocosto4,
                    Uid = SeoHelper.GuidString(hdUid.Value),
                    Datainizioperiodo = SeoHelper.DataString(txtDataInizio.Text),
                    Datafineperiodo = SeoHelper.DataString(txtDataFine.Text),
                    Datainizioperiodo2 = SeoHelper.DataString(txtDataInizio2.Text),
                    Datafineperiodo2 = SeoHelper.DataString(txtDataFine2.Text),
                    Datainizioperiodo3 = SeoHelper.DataString(txtDataInizio3.Text),
                    Datafineperiodo3 = SeoHelper.DataString(txtDataFine3.Text),
                    Datainizioperiodo4 = SeoHelper.DataString(txtDataInizio4.Text),
                    Datafineperiodo4 = SeoHelper.DataString(txtDataFine4.Text),
                    Targa = targa,
                    Uidtenant = SeoHelper.ReturnSessionTenant()
                };

                servizioContratti.UpdateAbbinaFattura(contrattoNew);
            }

            //controllo se tutti i record hanno il cdc (o cdc2)
            int countnonabbinati = servizioContratti.SelectCountFattureNonAbbinate(Uidfattura);

            if (countnonabbinati == 0) // se sono tutti abbinati mette status elaborato
            {
                servizioContratti.UpdateStatusFattura(Uidfattura, 1, SeoHelper.ReturnSessionTenant());
            }
            else
            {
                servizioContratti.UpdateStatusFattura(Uidfattura, 0, SeoHelper.ReturnSessionTenant());
            }

            servizioContratti.UpdateFatturaAbb(Uidfattura, SeoHelper.IntString(ddlTemplate.SelectedValue), SeoHelper.DataString(txtData.Text), SeoHelper.ReturnSessionTenant());


            Response.Redirect(ResolveUrl("~/Admin/Modules/Contratto/EditFattura-" + SeoHelper.EncodeString(hduidfattura.Value) + "#dettagli"));
        }

        protected void btnAbbina_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string error = string.Empty;
            DateTime datafattura = DateTime.MinValue;
            Guid Uidfattura = SeoHelper.GuidString(hduidfattura.Value);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            if (string.IsNullOrEmpty(ddlTemplate.SelectedValue))
            {
                ddlTemplate.CssClass = "form-control is-invalid";
                error += "Scegliere un template per poter proseguire<br />";
            }
            else
            {
                ddlTemplate.CssClass = "form-control";
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
                //recupero data fattura
                IContratti dataF = servizioContratti.DetailFattureId(Uidfattura);
                if (dataF != null)
                {
                    datafattura = dataF.Datadocumento;
                }

                //elenco dettagli fattura
                List<IContratti> data = servizioContratti.SelectDetailFatture(Uidfattura, Uidtenant, SeoHelper.IntString(hdPagina.Value));

                if (data != null && data.Count > 0)
                {
                    foreach (IContratti result in data)
                    {
                        InsertAbbinamento(result.Uid, result.Descrizione, result.Riftesto, result.Datainizioperiodo, result.Datafineperiodo, datafattura);
                    }

                    //controllo se tutti i record hanno il cdc (o cdc2)
                    int countnonabbinati = servizioContratti.SelectCountFattureNonAbbinate(Uidfattura);

                    if (countnonabbinati == 0) // se sono tutti abbinati mette status elaborato
                    {
                        servizioContratti.UpdateStatusFattura(Uidfattura, 1, SeoHelper.ReturnSessionTenant());
                    }
                    else
                    {
                        servizioContratti.UpdateStatusFattura(Uidfattura, 0, SeoHelper.ReturnSessionTenant());
                    }
                }

                servizioContratti.UpdateFatturaAbb(Uidfattura, SeoHelper.IntString(ddlTemplate.SelectedValue), SeoHelper.DataString(txtData.Text), SeoHelper.ReturnSessionTenant());

                Response.Redirect(ResolveUrl("~/Admin/Modules/Contratto/EditFattura-" + SeoHelper.EncodeString(hduidfattura.Value) + "#dettagli"));


            }
        }

        public void InsertAbbinamento(Guid Uid, string descrizione, string riftesto, DateTime datainizioperiodo, DateTime datafineperiodo, DateTime datafattura)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            DateTime datariferimento = SeoHelper.DataString(txtData.Text);
            DateTime datariferimentofinale;
            DateTime datariferimentofinale2;
            string codicecdc = string.Empty;
            string codicecdc2 = string.Empty;
            string codicecdc3 = string.Empty;
            string codicecdc4 = string.Empty;
            string tipocentrocosto = string.Empty;
            string tipocentrocosto2 = string.Empty;
            string tipocentrocosto3 = string.Empty;
            string tipocentrocosto4 = string.Empty;
            Guid Uidcentrocosto = Guid.Empty;
            Guid Uidcentrocosto2 = Guid.Empty;
            Guid Uidcentrocosto3 = Guid.Empty;
            Guid Uidcentrocosto4 = Guid.Empty;
            DateTime datainizio;
            DateTime datafine;
            DateTime datainizio2;
            DateTime datafine2;
            DateTime datainizio3;
            DateTime datafine3;
            DateTime datainizio4;
            DateTime datafine4;


            if (datainizioperiodo > DateTime.MinValue)
            {
                datariferimentofinale = datainizioperiodo;
                datariferimentofinale2 = datafineperiodo;
            }
            else
            {
                if (datariferimento > DateTime.MinValue)
                {
                    datariferimentofinale = datariferimento;
                    datariferimentofinale2 = datariferimento;
                }
                else
                {
                    datariferimentofinale = datafattura;
                    datariferimentofinale2 = datafattura;
                }
            }

            //recupera data inizio e data fine, se vuoti prende il valore inserito nel campo
            string datainiziofine_ = CalcolaDataInizioFine(descrizione, riftesto);
            string[] datainiziofine = CalcolaDataInizioFine(descrizione, riftesto).Split('|');
            if (!string.IsNullOrEmpty(datainiziofine_))
            {
                datainizio = SeoHelper.DataString(datainiziofine[0]);
                datafine = SeoHelper.DataString(datainiziofine[1]);
                datainizio2 = SeoHelper.DataString(datainiziofine[0]);
                datafine2 = SeoHelper.DataString(datainiziofine[1]);
                datainizio3 = SeoHelper.DataString(datainiziofine[0]);
                datafine3 = SeoHelper.DataString(datainiziofine[1]);
                datainizio4 = SeoHelper.DataString(datainiziofine[0]);
                datafine4 = SeoHelper.DataString(datainiziofine[1]);
            }
            else
            {
                datainizio = datariferimentofinale;
                datafine = datariferimentofinale2;
                datainizio2 = datariferimentofinale;
                datafine2 = datariferimentofinale2;
                datainizio3 = datariferimentofinale;
                datafine3 = datariferimentofinale2;
                datainizio4 = datariferimentofinale;
                datafine4 = datariferimentofinale2;
            }

            //recupero centro di costo (max 4 valori)
            List<IContratti> dataCDC = servizioContratti.ReturnCodiceCDC(datainizio, datafine, CalcolaTarga(descrizione, riftesto));

            if (dataCDC != null && dataCDC.Count > 0)
            {
                int countUs = 1;
                foreach (IContratti resultCDC in dataCDC)
                {
                    if (countUs == 1) //1° valore
                    {
                        codicecdc = resultCDC.Codicecdc;
                        Uidcentrocosto = resultCDC.UserId;
                        tipocentrocosto = "EF_users";
                    }
                    if (countUs == 2) //2° valore
                    {
                        codicecdc2 = resultCDC.Codicecdc;
                        Uidcentrocosto2 = resultCDC.UserId;
                        tipocentrocosto2 = "EF_users";
                        datafine = resultCDC.Assegnatodal.AddDays(-1);
                        datainizio2 = resultCDC.Assegnatodal;
                    }
                    if (countUs == 3) //3° valore
                    {
                        codicecdc3 = resultCDC.Codicecdc;
                        Uidcentrocosto3 = resultCDC.UserId;
                        tipocentrocosto3 = "EF_users";
                        datafine2 = resultCDC.Assegnatodal.AddDays(-1);
                        datainizio3 = resultCDC.Assegnatodal;
                    }
                    if (countUs == 4) //4° valore
                    {
                        codicecdc4 = resultCDC.Codicecdc;
                        Uidcentrocosto4 = resultCDC.UserId;
                        tipocentrocosto4 = "EF_users";
                        datafine3 = resultCDC.Assegnatodal.AddDays(-1);
                        datainizio4 = resultCDC.Assegnatodal;
                    }

                    countUs++;
                }
                if (dataCDC.Count == 1)
                {
                    datainizio2 = DateTime.MinValue;
                    datafine2 = DateTime.MinValue;
                    datainizio3 = DateTime.MinValue;
                    datafine3 = DateTime.MinValue;
                    datainizio4 = DateTime.MinValue;
                    datafine4 = DateTime.MinValue;
                }
                if (dataCDC.Count == 2)
                {
                    datainizio3 = DateTime.MinValue;
                    datafine3 = DateTime.MinValue;
                    datainizio4 = DateTime.MinValue;
                    datafine4 = DateTime.MinValue;
                }
                if (dataCDC.Count == 3)
                {
                    datainizio4 = DateTime.MinValue;
                    datafine4 = DateTime.MinValue;
                }
            }


            //abbinamento
            IContratti contrattoNew = new Contratti
            {
                Centrocostoabb = SeoHelper.EncodeString(codicecdc),
                Tipocentrocosto = SeoHelper.EncodeString(tipocentrocosto),
                Uidcentrocosto = Uidcentrocosto,
                Centrocostoabb2 = SeoHelper.EncodeString(codicecdc2),
                Tipocentrocosto2 = SeoHelper.EncodeString(tipocentrocosto2),
                Uidcentrocosto2 = Uidcentrocosto2,
                Centrocostoabb3 = SeoHelper.EncodeString(codicecdc3),
                Tipocentrocosto3 = SeoHelper.EncodeString(tipocentrocosto3),
                Uidcentrocosto3 = Uidcentrocosto3,
                Centrocostoabb4 = SeoHelper.EncodeString(codicecdc4),
                Tipocentrocosto4 = SeoHelper.EncodeString(tipocentrocosto4),
                Uidcentrocosto4 = Uidcentrocosto4,
                Datainizioperiodo = datainizio,
                Datafineperiodo = datafine,
                Datainizioperiodo2 = datainizio2,
                Datafineperiodo2 = datafine2,
                Datainizioperiodo3 = datainizio3,
                Datafineperiodo3 = datafine3,
                Datainizioperiodo4 = datainizio4,
                Datafineperiodo4 = datafine4,
                Uid = Uid,
                Targa = CalcolaTarga(descrizione, riftesto),
                Uidtenant = SeoHelper.ReturnSessionTenant()
            };

            servizioContratti.UpdateAbbinaFattura(contrattoNew);
        }

        protected void btnSvuota_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            Guid Uidfattura = SeoHelper.GuidString(hduidfattura.Value);

            if (servizioContratti.UpdateSvuotaAbbinamentoFattura(Uidfattura, SeoHelper.ReturnSessionTenant()) == 1)
            {
                //controllo se tutti i record hanno il cdc (o cdc2)
                int countnonabbinati = servizioContratti.SelectCountFattureNonAbbinate(Uidfattura);

                if (countnonabbinati == 0) // se sono tutti abbinati mette status elaborato
                {
                    servizioContratti.UpdateStatusFattura(Uidfattura, 1, SeoHelper.ReturnSessionTenant());
                }
                else
                {
                    servizioContratti.UpdateStatusFattura(Uidfattura, 0, SeoHelper.ReturnSessionTenant());
                }
                
                Response.Redirect(ResolveUrl("~/Admin/Modules/Contratto/EditFattura-" + SeoHelper.EncodeString(hduidfattura.Value) + "#dettagli"));
            }
            else
            {
                pnlMessage.Visible = true;
                pnlMessage.CssClass = "alert alert-danger";
                lblMessage.Text += "Operazione fallita";
            }
        }

        protected void btnEsporta_Click(object sender, EventArgs e)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            IUtilitysBL servizioUtilitys = new UtilitysBL();
            IAccountBL servizioAccount = new AccountBL();
            Guid Uidfattura = SeoHelper.GuidString(hduidfattura.Value);
            string nomefile = "";

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            FileInfo newFile = new FileInfo(RequestExtensions.GetPathPhisicalApplication() + "/Repository/report/tracciato_noleggio.xlsx");

            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets[1];

                IContratti data = servizioContratti.DetailFattureId(Uidfattura);
                if (data != null)
                {
                    string tipodocumento = "";
                    string codcommittente = "";
                    string codsocieta = "";
                    string positingkey = "";
                    string positingkeydett = "";
                    string cdcfornitore = "";
                    int template = data.Templateabb;


                    if (data.Tipodocumento.ToUpper() == "TD01") // fattura
                    {
                        tipodocumento = "KR";
                        positingkey = "31";
                        positingkeydett = "40";
                    }
                    if (data.Tipodocumento.ToUpper() == "TD04" || data.Tipodocumento.ToUpper() == "TD05") // nota credito
                    {
                        tipodocumento = "KG";
                        positingkey = "21";
                        positingkeydett = "50";
                    }

                    //recupero cod societa
                    IUtilitys dataS = servizioUtilitys.DetailSocietaXPIVA(data.Codcommittente);
                    if (dataS != null)
                    {
                        codsocieta = dataS.Codcompany;
                        nomefile += codsocieta + "_";
                        codcommittente = dataS.Codsocieta;
                    }

                    //recupero centro di costo fornitore
                    IUtilitys dataF = servizioUtilitys.DetailFornitoriPIva(data.Codfornitore);
                    if (dataF != null)
                    {
                        cdcfornitore = dataF.Codicecdc;
                    }

                    //recupero descrizione template
                    IContratti dataT = servizioContratti.DetailTemplateFattureId(template);
                    if (dataT != null)
                    {
                        nomefile += dataT.Nometemplate.ToUpper().Replace(" ", "_") + "_";
                    }
                    nomefile += data.Numerodocumento + "_" + data.Datadocumento.Day.ToString("d2") + data.Datadocumento.Month.ToString("d2") + data.Datadocumento.Year.ToString().Substring(2, 2);


                    worksheet.Cells["A8"].Value = "";
                    worksheet.Cells["B8"].Value = "";
                    worksheet.Cells["C8"].Value = tipodocumento;
                    worksheet.Cells["D8"].Value = codsocieta;
                    worksheet.Cells["E8"].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                    worksheet.Cells["E8"].Value = data.Datadocumento;
                    worksheet.Cells["F8"].Value = "";
                    worksheet.Cells["G8"].Value = "";
                    worksheet.Cells["H8"].Value = "";
                    worksheet.Cells["I8"].Value = "";
                    worksheet.Cells["J8"].Value = data.Divisa;
                    worksheet.Cells["K8"].Value = "";
                    worksheet.Cells["L8"].Value = "";
                    worksheet.Cells["M8"].Value = data.Numerodocumento;
                    worksheet.Cells["N8"].Value = "";
                    worksheet.Cells["O8"].Value = "";
                    worksheet.Cells["P8"].Value = "";
                    worksheet.Cells["Q8"].Value = "";
                    worksheet.Cells["R8"].Value = positingkey;
                    worksheet.Cells["S8"].Value = cdcfornitore;
                    worksheet.Cells["T8"].Value = "";
                    worksheet.Cells["U8"].Value = "";
                    worksheet.Cells["V8"].Value = "";
                    worksheet.Cells["W8"].Value = "";
                    worksheet.Cells["X8"].Value = Math.Abs(data.Importototale).ToString("F2");
                    worksheet.Cells["Y8"].Value = "";
                    worksheet.Cells["Z8"].Value = "";
                    worksheet.Cells["AA8"].Value = "";
                    worksheet.Cells["AB8"].Value = "";
                    worksheet.Cells["AC8"].Value = "";
                    worksheet.Cells["AD8"].Value = "";
                    worksheet.Cells["AE8"].Value = "";
                    worksheet.Cells["AF8"].Value = "";
                    worksheet.Cells["AG8"].Value = "";
                    worksheet.Cells["AH8"].Value = "";
                    worksheet.Cells["AI8"].Value = "";
                    worksheet.Cells["AJ8"].Value = "";
                    worksheet.Cells["AK8"].Value = "";
                    worksheet.Cells["AL8"].Value = "";
                    worksheet.Cells["AM8"].Value = "";
                    worksheet.Cells["AN8"].Value = "";
                    worksheet.Cells["AO8"].Value = "";
                    worksheet.Cells["AP8"].Value = "";
                    worksheet.Cells["AQ8"].Value = "";
                    worksheet.Cells["AR8"].Value = "";
                    worksheet.Cells["AS8"].Value = "";
                    worksheet.Cells["AT8"].Value = "";
                    worksheet.Cells["AU8"].Value = "";
                    worksheet.Cells["AV8"].Value = "";
                    worksheet.Cells["AW8"].Value = "";
                    worksheet.Cells["AX8"].Value = "";


                    //**************************** lista dettagli fattura
                    //**************************** template noleggi conguagli e bolli

                    if ((template >= 1 && template <= 14) || (template >= 18 && template <= 24) || template == 28 || template == 29)
                    {

                        List<IContratti> dataExport = servizioContratti.SelectDetailFattureGroup(Uidfattura);

                        if (dataExport != null && dataExport.Count > 0)
                        {
                            int countRow = 9;
                            foreach (IContratti resultExport in dataExport)
                            {
                                decimal importofinale1 = 0;
                                decimal importofinale2 = 0;
                                decimal importofinale3 = 0;
                                decimal importofinale4 = 0;
                                decimal totgiorni = 0;
                                decimal giornidiff1 = 0;
                                decimal giornidiff2 = 0;
                                decimal giornidiff3 = 0;
                                decimal giornidiff4 = 0;
                                DateTime datamax1 = DateTime.MinValue;
                                DateTime datamax2 = DateTime.MinValue;
                                DateTime datamax3 = DateTime.MinValue;
                                DateTime datamax4 = DateTime.MinValue;
                                string denominazione = "";
                                string matricola = "";
                                Guid UserId = Guid.Empty;
                                string targa = "";
                                //targa = CalcolaTarga(resultExport.Descrizione, resultExport.Riftesto);
                                targa = resultExport.Targa;
                                string natura = resultExport.Naturaiva;

                                //recupero denominazione utente o societa
                                IContratti dataD = servizioContratti.DetailDriverXCdc(resultExport.Tipocentrocosto, resultExport.Uidcentrocosto);
                                if (dataD != null)
                                {
                                    denominazione = dataD.Denominazione;
                                    matricola = dataD.Matricola;
                                }

                                if (resultExport.Tipocentrocosto.ToUpper() == "EF_USERS")
                                {
                                    UserId = resultExport.Uidcentrocosto;
                                }

                                //tronca denominazione a 20 caratteri 
                                if (denominazione.Length > 20)
                                {
                                    denominazione = denominazione.Substring(0, 20);
                                }


                                //se esiste solo 1 centro costo
                                if (string.IsNullOrEmpty(resultExport.Centrocostoabb2) && string.IsNullOrEmpty(resultExport.Centrocostoabb3) && string.IsNullOrEmpty(resultExport.Centrocostoabb4))
                                {
                                    importofinale1 = Math.Abs(resultExport.Prezzotot);
                                }

                                //se esiste centro di costo 2 splitta importo 
                                if (!string.IsNullOrEmpty(resultExport.Centrocostoabb2) && string.IsNullOrEmpty(resultExport.Centrocostoabb3) && string.IsNullOrEmpty(resultExport.Centrocostoabb4))
                                {
                                    if (resultExport.Datainizioperiodo > resultExport.Datainizioperiodo2)
                                    {
                                        datamax1 = resultExport.Datainizioperiodo2;
                                    }
                                    else
                                    {
                                        datamax1 = resultExport.Datainizioperiodo;
                                    }

                                    if (resultExport.Datafineperiodo > resultExport.Datafineperiodo2)
                                    {
                                        datamax2 = resultExport.Datafineperiodo;
                                    }
                                    else
                                    {
                                        datamax2 = resultExport.Datafineperiodo2;
                                    }

                                    totgiorni = Convert.ToDecimal(((datamax2 - datamax1).TotalDays) + 1);
                                    giornidiff1 = Convert.ToDecimal(((resultExport.Datafineperiodo - resultExport.Datainizioperiodo).TotalDays) + 1);
                                    giornidiff2 = Convert.ToDecimal(((resultExport.Datafineperiodo2 - resultExport.Datainizioperiodo2).TotalDays) + 1);

                                    importofinale1 = Math.Round((Math.Abs(resultExport.Prezzotot) * (giornidiff1 / totgiorni)), 2);
                                    importofinale2 = Math.Round((Math.Abs(resultExport.Prezzotot) * (giornidiff2 / totgiorni)), 2);
                                }

                                //se esiste centro di costo 3 splitta importo 
                                if (!string.IsNullOrEmpty(resultExport.Centrocostoabb2) && !string.IsNullOrEmpty(resultExport.Centrocostoabb3) && string.IsNullOrEmpty(resultExport.Centrocostoabb4))
                                {
                                    if (resultExport.Datainizioperiodo > resultExport.Datainizioperiodo3)
                                    {
                                        datamax1 = resultExport.Datainizioperiodo3;
                                    }
                                    else
                                    {
                                        datamax1 = resultExport.Datainizioperiodo;
                                    }

                                    if (resultExport.Datafineperiodo2 > resultExport.Datafineperiodo3)
                                    {
                                        datamax2 = resultExport.Datafineperiodo3;
                                    }
                                    else
                                    {
                                        datamax2 = resultExport.Datafineperiodo2;
                                    }

                                    if (resultExport.Datafineperiodo > resultExport.Datafineperiodo3)
                                    {
                                        datamax3 = resultExport.Datafineperiodo;
                                    }
                                    else
                                    {
                                        datamax3 = resultExport.Datafineperiodo3;
                                    }

                                    totgiorni = Convert.ToDecimal(((datamax3 - datamax1).TotalDays) + 1);
                                    giornidiff1 = Convert.ToDecimal(((resultExport.Datafineperiodo - resultExport.Datainizioperiodo).TotalDays) + 1);
                                    giornidiff2 = Convert.ToDecimal(((resultExport.Datafineperiodo2 - resultExport.Datainizioperiodo2).TotalDays) + 1);
                                    giornidiff3 = Convert.ToDecimal(((resultExport.Datafineperiodo3 - resultExport.Datainizioperiodo3).TotalDays) + 1);

                                    importofinale1 = Math.Round((Math.Abs(resultExport.Prezzotot) * (giornidiff1 / totgiorni)), 2);
                                    importofinale2 = Math.Round((Math.Abs(resultExport.Prezzotot) * (giornidiff2 / totgiorni)), 2);
                                    importofinale3 = Math.Round((Math.Abs(resultExport.Prezzotot) * (giornidiff3 / totgiorni)), 2);
                                }

                                //se esiste centro di costo 4 splitta importo 
                                if (!string.IsNullOrEmpty(resultExport.Centrocostoabb2) && !string.IsNullOrEmpty(resultExport.Centrocostoabb3) && !string.IsNullOrEmpty(resultExport.Centrocostoabb4))
                                {
                                    if (resultExport.Datainizioperiodo > resultExport.Datainizioperiodo4)
                                    {
                                        datamax1 = resultExport.Datainizioperiodo4;
                                    }
                                    else
                                    {
                                        datamax1 = resultExport.Datainizioperiodo;
                                    }

                                    if (resultExport.Datafineperiodo2 > resultExport.Datafineperiodo4)
                                    {
                                        datamax2 = resultExport.Datafineperiodo4;
                                    }
                                    else
                                    {
                                        datamax2 = resultExport.Datafineperiodo2;
                                    }

                                    if (resultExport.Datafineperiodo > resultExport.Datafineperiodo4)
                                    {
                                        datamax3 = resultExport.Datafineperiodo;
                                    }
                                    else
                                    {
                                        datamax3 = resultExport.Datafineperiodo4;
                                    }

                                    if (resultExport.Datafineperiodo > resultExport.Datafineperiodo4)
                                    {
                                        datamax4 = resultExport.Datafineperiodo;
                                    }
                                    else
                                    {
                                        datamax4 = resultExport.Datafineperiodo4;
                                    }

                                    totgiorni = Convert.ToDecimal(((datamax4 - datamax1).TotalDays) + 1);
                                    giornidiff1 = Convert.ToDecimal(((resultExport.Datafineperiodo - resultExport.Datainizioperiodo).TotalDays) + 1);
                                    giornidiff2 = Convert.ToDecimal(((resultExport.Datafineperiodo2 - resultExport.Datainizioperiodo2).TotalDays) + 1);
                                    giornidiff3 = Convert.ToDecimal(((resultExport.Datafineperiodo3 - resultExport.Datainizioperiodo3).TotalDays) + 1);
                                    giornidiff4 = Convert.ToDecimal(((resultExport.Datafineperiodo4 - resultExport.Datainizioperiodo4).TotalDays) + 1);

                                    importofinale1 = Math.Round((Math.Abs(resultExport.Prezzotot) * (giornidiff1 / totgiorni)), 2);
                                    importofinale2 = Math.Round((Math.Abs(resultExport.Prezzotot) * (giornidiff2 / totgiorni)), 2);
                                    importofinale3 = Math.Round((Math.Abs(resultExport.Prezzotot) * (giornidiff3 / totgiorni)), 2);
                                    importofinale4 = Math.Round((Math.Abs(resultExport.Prezzotot) * (giornidiff4 / totgiorni)), 2);
                                }





                                //******************


                                worksheet.Cells["A" + countRow].Value = "";
                                worksheet.Cells["B" + countRow].Value = "";
                                worksheet.Cells["C" + countRow].Value = "";
                                worksheet.Cells["D" + countRow].Value = "";
                                worksheet.Cells["E" + countRow].Value = "";
                                worksheet.Cells["F" + countRow].Value = "";
                                worksheet.Cells["G" + countRow].Value = "";
                                worksheet.Cells["H" + countRow].Value = "";
                                worksheet.Cells["I" + countRow].Value = "";
                                worksheet.Cells["J" + countRow].Value = "";
                                worksheet.Cells["K" + countRow].Value = "";
                                worksheet.Cells["L" + countRow].Value = "";
                                worksheet.Cells["M" + countRow].Value = "";
                                worksheet.Cells["N" + countRow].Value = "";
                                worksheet.Cells["O" + countRow].Value = "";
                                worksheet.Cells["P" + countRow].Value = "";
                                worksheet.Cells["Q" + countRow].Value = "";
                                worksheet.Cells["R" + countRow].Value = positingkeydett;
                                worksheet.Cells["S" + countRow].Value = CalcolaAccount(codcommittente, UserId, template);
                                worksheet.Cells["T" + countRow].Value = "";
                                worksheet.Cells["U" + countRow].Value = "";
                                worksheet.Cells["V" + countRow].Value = "";
                                worksheet.Cells["W" + countRow].Value = "";
                                worksheet.Cells["X" + countRow].Value = importofinale1;
                                worksheet.Cells["Y" + countRow].Value = "";
                                worksheet.Cells["Z" + countRow].Value = "";
                                worksheet.Cells["AA" + countRow].Value = CalcolaTaxCode(codcommittente, UserId, template, natura);
                                worksheet.Cells["AB" + countRow].Value = "";
                                worksheet.Cells["AC" + countRow].Value = "";
                                worksheet.Cells["AD" + countRow].Value = resultExport.Centrocostoabb;
                                worksheet.Cells["AE" + countRow].Value = "";
                                worksheet.Cells["AF" + countRow].Value = "";
                                worksheet.Cells["AG" + countRow].Value = "";
                                worksheet.Cells["AH" + countRow].Value = "";
                                worksheet.Cells["AI" + countRow].Value = CalcolaDescrizione(targa, resultExport.Datainizioperiodo, resultExport.Datafineperiodo, matricola, template);
                                worksheet.Cells["AJ" + countRow].Value = "";
                                worksheet.Cells["AK" + countRow].Value = "";
                                worksheet.Cells["AL" + countRow].Value = "";
                                worksheet.Cells["AM" + countRow].Value = "";
                                worksheet.Cells["AN" + countRow].Value = "";
                                worksheet.Cells["AO" + countRow].Value = "";
                                worksheet.Cells["AP" + countRow].Value = "";
                                worksheet.Cells["AQ" + countRow].Value = "";
                                worksheet.Cells["AR" + countRow].Value = "";
                                worksheet.Cells["AS" + countRow].Value = "";
                                worksheet.Cells["AT" + countRow].Value = "";
                                worksheet.Cells["AU" + countRow].Value = "";
                                worksheet.Cells["AV" + countRow].Value = "";
                                worksheet.Cells["AW" + countRow].Value = "";
                                worksheet.Cells["AX" + countRow].Value = denominazione;

                                countRow++;


                                if (!string.IsNullOrEmpty(resultExport.Centrocostoabb2)) //se esiste centro di costo 2 crea nuova riga
                                {
                                    string denominazione2 = "";
                                    string matricola2 = "";
                                    Guid UserId2 = Guid.Empty;

                                    //recupero denominazione utente o societa
                                    IContratti dataD2 = servizioContratti.DetailDriverXCdc(resultExport.Tipocentrocosto2, resultExport.Uidcentrocosto2);
                                    if (dataD2 != null)
                                    {
                                        denominazione2 = dataD2.Denominazione;
                                        matricola2 = dataD2.Matricola;
                                    }

                                    if (resultExport.Tipocentrocosto2.ToUpper() == "EF_USERS")
                                    {
                                        UserId2 = resultExport.Uidcentrocosto2;
                                    }

                                    //tronca denominazione a 20 caratteri 
                                    if (denominazione2.Length > 20)
                                    {
                                        denominazione2 = denominazione2.Substring(0, 20);
                                    }

                                    worksheet.Cells["A" + countRow].Value = "";
                                    worksheet.Cells["B" + countRow].Value = "";
                                    worksheet.Cells["C" + countRow].Value = "";
                                    worksheet.Cells["D" + countRow].Value = "";
                                    worksheet.Cells["E" + countRow].Value = "";
                                    worksheet.Cells["F" + countRow].Value = "";
                                    worksheet.Cells["G" + countRow].Value = "";
                                    worksheet.Cells["H" + countRow].Value = "";
                                    worksheet.Cells["I" + countRow].Value = "";
                                    worksheet.Cells["J" + countRow].Value = "";
                                    worksheet.Cells["K" + countRow].Value = "";
                                    worksheet.Cells["L" + countRow].Value = "";
                                    worksheet.Cells["M" + countRow].Value = "";
                                    worksheet.Cells["N" + countRow].Value = "";
                                    worksheet.Cells["O" + countRow].Value = "";
                                    worksheet.Cells["P" + countRow].Value = "";
                                    worksheet.Cells["Q" + countRow].Value = "";
                                    worksheet.Cells["R" + countRow].Value = positingkeydett;
                                    worksheet.Cells["S" + countRow].Value = CalcolaAccount(codcommittente, UserId2, template);
                                    worksheet.Cells["T" + countRow].Value = "";
                                    worksheet.Cells["U" + countRow].Value = "";
                                    worksheet.Cells["V" + countRow].Value = "";
                                    worksheet.Cells["W" + countRow].Value = "";
                                    worksheet.Cells["X" + countRow].Value = importofinale2;
                                    worksheet.Cells["Y" + countRow].Value = "";
                                    worksheet.Cells["Z" + countRow].Value = "";
                                    worksheet.Cells["AA" + countRow].Value = CalcolaTaxCode(codcommittente, UserId2, template, natura);
                                    worksheet.Cells["AB" + countRow].Value = "";
                                    worksheet.Cells["AC" + countRow].Value = "";
                                    worksheet.Cells["AD" + countRow].Value = resultExport.Centrocostoabb2;
                                    worksheet.Cells["AE" + countRow].Value = "";
                                    worksheet.Cells["AF" + countRow].Value = "";
                                    worksheet.Cells["AG" + countRow].Value = "";
                                    worksheet.Cells["AH" + countRow].Value = "";
                                    worksheet.Cells["AI" + countRow].Value = CalcolaDescrizione(targa, resultExport.Datainizioperiodo2, resultExport.Datafineperiodo2, matricola2, template);
                                    worksheet.Cells["AJ" + countRow].Value = "";
                                    worksheet.Cells["AK" + countRow].Value = "";
                                    worksheet.Cells["AL" + countRow].Value = "";
                                    worksheet.Cells["AM" + countRow].Value = "";
                                    worksheet.Cells["AN" + countRow].Value = "";
                                    worksheet.Cells["AO" + countRow].Value = "";
                                    worksheet.Cells["AP" + countRow].Value = "";
                                    worksheet.Cells["AQ" + countRow].Value = "";
                                    worksheet.Cells["AR" + countRow].Value = "";
                                    worksheet.Cells["AS" + countRow].Value = "";
                                    worksheet.Cells["AT" + countRow].Value = "";
                                    worksheet.Cells["AU" + countRow].Value = "";
                                    worksheet.Cells["AV" + countRow].Value = "";
                                    worksheet.Cells["AW" + countRow].Value = "";
                                    worksheet.Cells["AX" + countRow].Value = denominazione2;

                                    countRow++;

                                }



                                if (!string.IsNullOrEmpty(resultExport.Centrocostoabb3)) //se esiste centro di costo 3 crea nuova riga
                                {
                                    string denominazione3 = "";
                                    string matricola3 = "";
                                    Guid UserId3 = Guid.Empty;

                                    //recupero denominazione utente o societa
                                    IContratti dataD3 = servizioContratti.DetailDriverXCdc(resultExport.Tipocentrocosto3, resultExport.Uidcentrocosto3);
                                    if (dataD3 != null)
                                    {
                                        denominazione3 = dataD3.Denominazione;
                                        matricola3 = dataD3.Matricola;
                                    }

                                    if (resultExport.Tipocentrocosto3.ToUpper() == "EF_USERS")
                                    {
                                        UserId3 = resultExport.Uidcentrocosto3;
                                    }

                                    //tronca denominazione a 20 caratteri 
                                    if (denominazione3.Length > 20)
                                    {
                                        denominazione3 = denominazione3.Substring(0, 20);
                                    }

                                    worksheet.Cells["A" + countRow].Value = "";
                                    worksheet.Cells["B" + countRow].Value = "";
                                    worksheet.Cells["C" + countRow].Value = "";
                                    worksheet.Cells["D" + countRow].Value = "";
                                    worksheet.Cells["E" + countRow].Value = "";
                                    worksheet.Cells["F" + countRow].Value = "";
                                    worksheet.Cells["G" + countRow].Value = "";
                                    worksheet.Cells["H" + countRow].Value = "";
                                    worksheet.Cells["I" + countRow].Value = "";
                                    worksheet.Cells["J" + countRow].Value = "";
                                    worksheet.Cells["K" + countRow].Value = "";
                                    worksheet.Cells["L" + countRow].Value = "";
                                    worksheet.Cells["M" + countRow].Value = "";
                                    worksheet.Cells["N" + countRow].Value = "";
                                    worksheet.Cells["O" + countRow].Value = "";
                                    worksheet.Cells["P" + countRow].Value = "";
                                    worksheet.Cells["Q" + countRow].Value = "";
                                    worksheet.Cells["R" + countRow].Value = positingkeydett;
                                    worksheet.Cells["S" + countRow].Value = CalcolaAccount(codcommittente, UserId3, template);
                                    worksheet.Cells["T" + countRow].Value = "";
                                    worksheet.Cells["U" + countRow].Value = "";
                                    worksheet.Cells["V" + countRow].Value = "";
                                    worksheet.Cells["W" + countRow].Value = "";
                                    worksheet.Cells["X" + countRow].Value = importofinale3;
                                    worksheet.Cells["Y" + countRow].Value = "";
                                    worksheet.Cells["Z" + countRow].Value = "";
                                    worksheet.Cells["AA" + countRow].Value = CalcolaTaxCode(codcommittente, UserId3, template, natura);
                                    worksheet.Cells["AB" + countRow].Value = "";
                                    worksheet.Cells["AC" + countRow].Value = "";
                                    worksheet.Cells["AD" + countRow].Value = resultExport.Centrocostoabb3;
                                    worksheet.Cells["AE" + countRow].Value = "";
                                    worksheet.Cells["AF" + countRow].Value = "";
                                    worksheet.Cells["AG" + countRow].Value = "";
                                    worksheet.Cells["AH" + countRow].Value = "";
                                    worksheet.Cells["AI" + countRow].Value = CalcolaDescrizione(targa, resultExport.Datainizioperiodo3, resultExport.Datafineperiodo3, matricola3, template);
                                    worksheet.Cells["AJ" + countRow].Value = "";
                                    worksheet.Cells["AK" + countRow].Value = "";
                                    worksheet.Cells["AL" + countRow].Value = "";
                                    worksheet.Cells["AM" + countRow].Value = "";
                                    worksheet.Cells["AN" + countRow].Value = "";
                                    worksheet.Cells["AO" + countRow].Value = "";
                                    worksheet.Cells["AP" + countRow].Value = "";
                                    worksheet.Cells["AQ" + countRow].Value = "";
                                    worksheet.Cells["AR" + countRow].Value = "";
                                    worksheet.Cells["AS" + countRow].Value = "";
                                    worksheet.Cells["AT" + countRow].Value = "";
                                    worksheet.Cells["AU" + countRow].Value = "";
                                    worksheet.Cells["AV" + countRow].Value = "";
                                    worksheet.Cells["AW" + countRow].Value = "";
                                    worksheet.Cells["AX" + countRow].Value = denominazione3;

                                    countRow++;

                                }



                                if (!string.IsNullOrEmpty(resultExport.Centrocostoabb4)) //se esiste centro di costo 4 crea nuova riga
                                {
                                    string denominazione4 = "";
                                    string matricola4 = "";
                                    Guid UserId4 = Guid.Empty;

                                    //recupero denominazione utente o societa
                                    IContratti dataD4 = servizioContratti.DetailDriverXCdc(resultExport.Tipocentrocosto4, resultExport.Uidcentrocosto4);
                                    if (dataD4 != null)
                                    {
                                        denominazione4 = dataD4.Denominazione;
                                        matricola4 = dataD4.Matricola;
                                    }

                                    if (resultExport.Tipocentrocosto4.ToUpper() == "EF_USERS")
                                    {
                                        UserId4 = resultExport.Uidcentrocosto4;
                                    }

                                    //tronca denominazione a 20 caratteri 
                                    if (denominazione4.Length > 20)
                                    {
                                        denominazione4 = denominazione4.Substring(0, 20);
                                    }

                                    worksheet.Cells["A" + countRow].Value = "";
                                    worksheet.Cells["B" + countRow].Value = "";
                                    worksheet.Cells["C" + countRow].Value = "";
                                    worksheet.Cells["D" + countRow].Value = "";
                                    worksheet.Cells["E" + countRow].Value = "";
                                    worksheet.Cells["F" + countRow].Value = "";
                                    worksheet.Cells["G" + countRow].Value = "";
                                    worksheet.Cells["H" + countRow].Value = "";
                                    worksheet.Cells["I" + countRow].Value = "";
                                    worksheet.Cells["J" + countRow].Value = "";
                                    worksheet.Cells["K" + countRow].Value = "";
                                    worksheet.Cells["L" + countRow].Value = "";
                                    worksheet.Cells["M" + countRow].Value = "";
                                    worksheet.Cells["N" + countRow].Value = "";
                                    worksheet.Cells["O" + countRow].Value = "";
                                    worksheet.Cells["P" + countRow].Value = "";
                                    worksheet.Cells["Q" + countRow].Value = "";
                                    worksheet.Cells["R" + countRow].Value = positingkeydett;
                                    worksheet.Cells["S" + countRow].Value = CalcolaAccount(codcommittente, UserId4, template);
                                    worksheet.Cells["T" + countRow].Value = "";
                                    worksheet.Cells["U" + countRow].Value = "";
                                    worksheet.Cells["V" + countRow].Value = "";
                                    worksheet.Cells["W" + countRow].Value = "";
                                    worksheet.Cells["X" + countRow].Value = importofinale4;
                                    worksheet.Cells["Y" + countRow].Value = "";
                                    worksheet.Cells["Z" + countRow].Value = "";
                                    worksheet.Cells["AA" + countRow].Value = CalcolaTaxCode(codcommittente, UserId4, template, natura);
                                    worksheet.Cells["AB" + countRow].Value = "";
                                    worksheet.Cells["AC" + countRow].Value = "";
                                    worksheet.Cells["AD" + countRow].Value = resultExport.Centrocostoabb4;
                                    worksheet.Cells["AE" + countRow].Value = "";
                                    worksheet.Cells["AF" + countRow].Value = "";
                                    worksheet.Cells["AG" + countRow].Value = "";
                                    worksheet.Cells["AH" + countRow].Value = "";
                                    worksheet.Cells["AI" + countRow].Value = CalcolaDescrizione(targa, resultExport.Datainizioperiodo4, resultExport.Datafineperiodo4, matricola4, template);
                                    worksheet.Cells["AJ" + countRow].Value = "";
                                    worksheet.Cells["AK" + countRow].Value = "";
                                    worksheet.Cells["AL" + countRow].Value = "";
                                    worksheet.Cells["AM" + countRow].Value = "";
                                    worksheet.Cells["AN" + countRow].Value = "";
                                    worksheet.Cells["AO" + countRow].Value = "";
                                    worksheet.Cells["AP" + countRow].Value = "";
                                    worksheet.Cells["AQ" + countRow].Value = "";
                                    worksheet.Cells["AR" + countRow].Value = "";
                                    worksheet.Cells["AS" + countRow].Value = "";
                                    worksheet.Cells["AT" + countRow].Value = "";
                                    worksheet.Cells["AU" + countRow].Value = "";
                                    worksheet.Cells["AV" + countRow].Value = "";
                                    worksheet.Cells["AW" + countRow].Value = "";
                                    worksheet.Cells["AX" + countRow].Value = denominazione4;

                                    countRow++;

                                }


                            }
                        }
                    }


                    //**************************** lista dettagli fattura
                    //**************************** template carburanti

                    if (template >= 15 && template <= 17)
                    {
                        int idcompagnia;

                        if (template == 15)
                        {
                            idcompagnia = 1;
                        }
                        else
                        {
                            idcompagnia = 2;
                        }

                        List<IContratti> dataExport = servizioContratti.SelectDetailConsumiGroup(data.Numerodocumento, idcompagnia, data.Datadocumento);

                        if (dataExport != null && dataExport.Count > 0)
                        {
                            int countRow2 = 9;
                            string denominazione3 = "";
                            string codicecdc = "";
                            foreach (IContratti resultExport in dataExport)
                            {
                                //recupero nominativo driver
                                IAccount dataU = servizioAccount.DetailId(resultExport.UserId);
                                if (dataU != null)
                                {
                                    denominazione3 = dataU.Cognome + " " + dataU.Nome;
                                    codicecdc = dataU.Codicecdc;
                                }

                                //tronca denominazione a 20 caratteri 
                                if (denominazione3.Length > 20)
                                {
                                    denominazione3 = denominazione3.Substring(0, 20);
                                }

                                worksheet.Cells["A" + countRow2].Value = "";
                                worksheet.Cells["B" + countRow2].Value = "";
                                worksheet.Cells["C" + countRow2].Value = "";
                                worksheet.Cells["D" + countRow2].Value = "";
                                worksheet.Cells["E" + countRow2].Value = "";
                                worksheet.Cells["F" + countRow2].Value = "";
                                worksheet.Cells["G" + countRow2].Value = "";
                                worksheet.Cells["H" + countRow2].Value = "";
                                worksheet.Cells["I" + countRow2].Value = "";
                                worksheet.Cells["J" + countRow2].Value = "";
                                worksheet.Cells["K" + countRow2].Value = "";
                                worksheet.Cells["L" + countRow2].Value = "";
                                worksheet.Cells["M" + countRow2].Value = "";
                                worksheet.Cells["N" + countRow2].Value = "";
                                worksheet.Cells["O" + countRow2].Value = "";
                                worksheet.Cells["P" + countRow2].Value = "";
                                worksheet.Cells["Q" + countRow2].Value = "";
                                worksheet.Cells["R" + countRow2].Value = positingkeydett;
                                worksheet.Cells["S" + countRow2].Value = CalcolaAccountCarburante(codcommittente, codsocieta, resultExport.UserId);
                                worksheet.Cells["T" + countRow2].Value = "";
                                worksheet.Cells["U" + countRow2].Value = "";
                                worksheet.Cells["V" + countRow2].Value = "";
                                worksheet.Cells["W" + countRow2].Value = "";
                                worksheet.Cells["X" + countRow2].Value = resultExport.Importototale.ToString("F2");
                                worksheet.Cells["Y" + countRow2].Value = "";
                                worksheet.Cells["Z" + countRow2].Value = "";
                                worksheet.Cells["AA" + countRow2].Value = CalcolaTaxCode(codcommittente, resultExport.UserId, template, "");
                                worksheet.Cells["AB" + countRow2].Value = "";
                                worksheet.Cells["AC" + countRow2].Value = "";
                                worksheet.Cells["AD" + countRow2].Value = codicecdc;
                                worksheet.Cells["AE" + countRow2].Value = "";
                                worksheet.Cells["AF" + countRow2].Value = "";
                                worksheet.Cells["AG" + countRow2].Value = "";
                                worksheet.Cells["AH" + countRow2].Value = "";
                                worksheet.Cells["AI" + countRow2].Value = resultExport.Targa + " CARBURANTE " + resultExport.Riftesto;
                                worksheet.Cells["AJ" + countRow2].Value = "";
                                worksheet.Cells["AK" + countRow2].Value = "";
                                worksheet.Cells["AL" + countRow2].Value = "";
                                worksheet.Cells["AM" + countRow2].Value = "";
                                worksheet.Cells["AN" + countRow2].Value = "";
                                worksheet.Cells["AO" + countRow2].Value = "";
                                worksheet.Cells["AP" + countRow2].Value = "";
                                worksheet.Cells["AQ" + countRow2].Value = "";
                                worksheet.Cells["AR" + countRow2].Value = "";
                                worksheet.Cells["AS" + countRow2].Value = "";
                                worksheet.Cells["AT" + countRow2].Value = "";
                                worksheet.Cells["AU" + countRow2].Value = "";
                                worksheet.Cells["AV" + countRow2].Value = "";
                                worksheet.Cells["AW" + countRow2].Value = "";
                                worksheet.Cells["AX" + countRow2].Value = denominazione3;

                                countRow2++;
                            }
                        }
                    }







                    //**************************** lista dettagli fattura
                    //**************************** template autostrade telepass

                    if (template == 25)
                    {
                        int idcompagnia = 4;
                        int mesedatadocumento = data.Datadocumento.Month;
                        int annodocumento = data.Datadocumento.Year;
                        int mesedatadocumentoprev = data.Datadocumento.AddMonths(-1).Month;
                        int annodocumentoprev = data.Datadocumento.AddMonths(-1).Year;
                        DateTime datafatturada = SeoHelper.DataString("15/" + mesedatadocumentoprev + "/" + annodocumentoprev);
                        DateTime datafatturaa = SeoHelper.DataString("14/" + mesedatadocumento + "/" + annodocumento);

                        List <IContratti> dataExport = servizioContratti.SelectDetailConsumiTelePassGroup(idcompagnia, datafatturada, datafatturaa);

                        if (dataExport != null && dataExport.Count > 0)
                        {
                            int countRow3 = 9;
                            string denominazione4 = "";
                            string cognome4 = "";
                            string codicecdc = "";
                            foreach (IContratti resultExport in dataExport)
                            {
                                //recupero nominativo driver
                                IAccount dataU = servizioAccount.DetailId(resultExport.UserId);
                                if (dataU != null)
                                {
                                    denominazione4 = dataU.Cognome + " " + dataU.Nome;
                                    cognome4 = dataU.Cognome.ToUpper();
                                    codicecdc = dataU.Codicecdc;
                                }

                                //tronca denominazione a 20 caratteri 
                                if (denominazione4.Length > 20)
                                {
                                    denominazione4 = denominazione4.Substring(0, 20);
                                }

                                worksheet.Cells["A" + countRow3].Value = "";
                                worksheet.Cells["B" + countRow3].Value = "";
                                worksheet.Cells["C" + countRow3].Value = "";
                                worksheet.Cells["D" + countRow3].Value = "";
                                worksheet.Cells["E" + countRow3].Value = "";
                                worksheet.Cells["F" + countRow3].Value = "";
                                worksheet.Cells["G" + countRow3].Value = "";
                                worksheet.Cells["H" + countRow3].Value = "";
                                worksheet.Cells["I" + countRow3].Value = "";
                                worksheet.Cells["J" + countRow3].Value = "";
                                worksheet.Cells["K" + countRow3].Value = "";
                                worksheet.Cells["L" + countRow3].Value = "";
                                worksheet.Cells["M" + countRow3].Value = "";
                                worksheet.Cells["N" + countRow3].Value = "";
                                worksheet.Cells["O" + countRow3].Value = "";
                                worksheet.Cells["P" + countRow3].Value = "";
                                worksheet.Cells["Q" + countRow3].Value = "";
                                worksheet.Cells["R" + countRow3].Value = positingkeydett;
                                worksheet.Cells["S" + countRow3].Value = "64800480";
                                worksheet.Cells["T" + countRow3].Value = "";
                                worksheet.Cells["U" + countRow3].Value = "";
                                worksheet.Cells["V" + countRow3].Value = "";
                                worksheet.Cells["W" + countRow3].Value = "";
                                worksheet.Cells["X" + countRow3].Value = resultExport.Importototale;
                                worksheet.Cells["Y" + countRow3].Value = "";
                                worksheet.Cells["Z" + countRow3].Value = "";
                                worksheet.Cells["AA" + countRow3].Value = CalcolaTaxCodeTelePass(template);
                                worksheet.Cells["AB" + countRow3].Value = "";
                                worksheet.Cells["AC" + countRow3].Value = "";
                                worksheet.Cells["AD" + countRow3].Value = codicecdc;
                                worksheet.Cells["AE" + countRow3].Value = "";
                                worksheet.Cells["AF" + countRow3].Value = "";
                                worksheet.Cells["AG" + countRow3].Value = "";
                                worksheet.Cells["AH" + countRow3].Value = "";
                                worksheet.Cells["AI" + countRow3].Value = cognome4 + " 15" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mesedatadocumentoprev).Substring(0,3).ToUpper() + " - 14" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mesedatadocumento).Substring(0, 3).ToUpper() + annodocumento.ToString().Substring(0, 2) + "Pedaggi";
                                worksheet.Cells["AJ" + countRow3].Value = "";
                                worksheet.Cells["AK" + countRow3].Value = "";
                                worksheet.Cells["AL" + countRow3].Value = "";
                                worksheet.Cells["AM" + countRow3].Value = "";
                                worksheet.Cells["AN" + countRow3].Value = "";
                                worksheet.Cells["AO" + countRow3].Value = "";
                                worksheet.Cells["AP" + countRow3].Value = "";
                                worksheet.Cells["AQ" + countRow3].Value = "";
                                worksheet.Cells["AR" + countRow3].Value = "";
                                worksheet.Cells["AS" + countRow3].Value = "";
                                worksheet.Cells["AT" + countRow3].Value = "";
                                worksheet.Cells["AU" + countRow3].Value = "";
                                worksheet.Cells["AV" + countRow3].Value = "";
                                worksheet.Cells["AW" + countRow3].Value = "";
                                worksheet.Cells["AX" + countRow3].Value = denominazione4;

                                countRow3++;
                            }
                        }
                    }







                    //**************************** lista dettagli fattura
                    //**************************** template multe

                    if (template == 26)
                    {
                        string mesedatadocumento = data.Datadocumento.Month.ToString();
                        int annodocumento = data.Datadocumento.Year;

                        List<IContratti> dataExport = servizioContratti.SelectFattureMulte(codcommittente, Guid.Empty, mesedatadocumento, annodocumento);

                        if (dataExport != null && dataExport.Count > 0)
                        {
                            int countRow4 = 9;
                            string denominazione5 = "";
                            string cognome5 = "";
                            string codicecdc = "";
                            string codicecdcsocieta = "";
                            foreach (IContratti resultExport in dataExport)
                            {
                                nomefile = "";
                                //recupero nominativo driver
                                IAccount dataU = servizioAccount.DetailId(resultExport.UserId);
                                if (dataU != null)
                                {
                                    denominazione5 = dataU.Cognome + " " + dataU.Nome;
                                    cognome5 = dataU.Cognome.ToUpper();
                                    codicecdc = dataU.Codicecdc;
                                }

                                //tronca denominazione a 20 caratteri 
                                if (denominazione5.Length > 20)
                                {
                                    denominazione5 = denominazione5.Substring(0, 20);
                                }


                                //recupero codcompany
                                IUtilitys dataCs = servizioUtilitys.DetailSocietaXCodS(codcommittente);
                                if (dataCs != null)
                                {
                                    nomefile += dataCs.Codcompany + "_" + dataCs.Siglasocieta;
                                    codicecdcsocieta = dataCs.Codicecdc;
                                }
                                nomefile += "_Multe_" + mesedatadocumento + annodocumento.ToString().Substring(2, 2);


                                if (resultExport.Idtipoassegnazione == 10 || resultExport.Idtipoassegnazione == 100)
                                {
                                    worksheet.Cells["A" + countRow4].Value = "";
                                    worksheet.Cells["B" + countRow4].Value = "";
                                    worksheet.Cells["C" + countRow4].Value = "";
                                    worksheet.Cells["D" + countRow4].Value = "";
                                    worksheet.Cells["E" + countRow4].Value = "";
                                    worksheet.Cells["F" + countRow4].Value = "";
                                    worksheet.Cells["G" + countRow4].Value = "";
                                    worksheet.Cells["H" + countRow4].Value = "";
                                    worksheet.Cells["I" + countRow4].Value = "";
                                    worksheet.Cells["J" + countRow4].Value = "";
                                    worksheet.Cells["K" + countRow4].Value = "";
                                    worksheet.Cells["L" + countRow4].Value = "";
                                    worksheet.Cells["M" + countRow4].Value = "";
                                    worksheet.Cells["N" + countRow4].Value = "";
                                    worksheet.Cells["O" + countRow4].Value = "";
                                    worksheet.Cells["P" + countRow4].Value = "";
                                    worksheet.Cells["Q" + countRow4].Value = "";
                                    worksheet.Cells["R" + countRow4].Value = positingkeydett;
                                    worksheet.Cells["S" + countRow4].Value = CalcolaAccountMulta(resultExport.UserId, resultExport.Idtipoassegnazione);
                                    worksheet.Cells["T" + countRow4].Value = "";
                                    worksheet.Cells["U" + countRow4].Value = "";
                                    worksheet.Cells["V" + countRow4].Value = "";
                                    worksheet.Cells["W" + countRow4].Value = "";
                                    worksheet.Cells["X" + countRow4].Value = (resultExport.Importototale).ToString("F2");
                                    worksheet.Cells["Y" + countRow4].Value = "";
                                    worksheet.Cells["Z" + countRow4].Value = "";
                                    worksheet.Cells["AA" + countRow4].Value = CalcolaTaxCodeMulta(resultExport.UserId, resultExport.Idtipoassegnazione);
                                    worksheet.Cells["AB" + countRow4].Value = "";
                                    worksheet.Cells["AC" + countRow4].Value = "";
                                    worksheet.Cells["AD" + countRow4].Value = CalcolaCDCMulta(codicecdc, codicecdcsocieta, resultExport.Idtipoassegnazione);
                                    worksheet.Cells["AE" + countRow4].Value = "";
                                    worksheet.Cells["AF" + countRow4].Value = "";
                                    worksheet.Cells["AG" + countRow4].Value = "";
                                    worksheet.Cells["AH" + countRow4].Value = "";
                                    worksheet.Cells["AI" + countRow4].Value = resultExport.Targa + " - " + resultExport.Numerocontratto + " - " + resultExport.Datarichiesta.ToString("dd/MM/yyyy");
                                    worksheet.Cells["AJ" + countRow4].Value = "";
                                    worksheet.Cells["AK" + countRow4].Value = "";
                                    worksheet.Cells["AL" + countRow4].Value = "";
                                    worksheet.Cells["AM" + countRow4].Value = "";
                                    worksheet.Cells["AN" + countRow4].Value = "";
                                    worksheet.Cells["AO" + countRow4].Value = "";
                                    worksheet.Cells["AP" + countRow4].Value = "";
                                    worksheet.Cells["AQ" + countRow4].Value = "";
                                    worksheet.Cells["AR" + countRow4].Value = "";
                                    worksheet.Cells["AS" + countRow4].Value = "";
                                    worksheet.Cells["AT" + countRow4].Value = "";
                                    worksheet.Cells["AU" + countRow4].Value = "";
                                    worksheet.Cells["AV" + countRow4].Value = "";
                                    worksheet.Cells["AW" + countRow4].Value = "";
                                    worksheet.Cells["AX" + countRow4].Value = denominazione5;
                                }

                                //caso driver + societa
                                
                                if (resultExport.Idtipoassegnazione == 200)
                                {
                                    //caso driver
                                    worksheet.Cells["A" + countRow4].Value = "";
                                    worksheet.Cells["B" + countRow4].Value = "";
                                    worksheet.Cells["C" + countRow4].Value = "";
                                    worksheet.Cells["D" + countRow4].Value = "";
                                    worksheet.Cells["E" + countRow4].Value = "";
                                    worksheet.Cells["F" + countRow4].Value = "";
                                    worksheet.Cells["G" + countRow4].Value = "";
                                    worksheet.Cells["H" + countRow4].Value = "";
                                    worksheet.Cells["I" + countRow4].Value = "";
                                    worksheet.Cells["J" + countRow4].Value = "";
                                    worksheet.Cells["K" + countRow4].Value = "";
                                    worksheet.Cells["L" + countRow4].Value = "";
                                    worksheet.Cells["M" + countRow4].Value = "";
                                    worksheet.Cells["N" + countRow4].Value = "";
                                    worksheet.Cells["O" + countRow4].Value = "";
                                    worksheet.Cells["P" + countRow4].Value = "";
                                    worksheet.Cells["Q" + countRow4].Value = "";
                                    worksheet.Cells["R" + countRow4].Value = positingkeydett;
                                    worksheet.Cells["S" + countRow4].Value = CalcolaAccountMulta(resultExport.UserId, 10);
                                    worksheet.Cells["T" + countRow4].Value = "";
                                    worksheet.Cells["U" + countRow4].Value = "";
                                    worksheet.Cells["V" + countRow4].Value = "";
                                    worksheet.Cells["W" + countRow4].Value = "";
                                    worksheet.Cells["X" + countRow4].Value = (resultExport.Quotadriver).ToString("F2");
                                    worksheet.Cells["Y" + countRow4].Value = "";
                                    worksheet.Cells["Z" + countRow4].Value = "";
                                    worksheet.Cells["AA" + countRow4].Value = CalcolaTaxCodeMulta(resultExport.UserId, 10);
                                    worksheet.Cells["AB" + countRow4].Value = "";
                                    worksheet.Cells["AC" + countRow4].Value = "";
                                    worksheet.Cells["AD" + countRow4].Value = CalcolaCDCMulta(codicecdc, codicecdcsocieta, 10);
                                    worksheet.Cells["AE" + countRow4].Value = "";
                                    worksheet.Cells["AF" + countRow4].Value = "";
                                    worksheet.Cells["AG" + countRow4].Value = "";
                                    worksheet.Cells["AH" + countRow4].Value = "";
                                    worksheet.Cells["AI" + countRow4].Value = resultExport.Targa + " - " + resultExport.Numerocontratto + " - " + resultExport.Datarichiesta.ToString("dd/MM/yyyy");
                                    worksheet.Cells["AJ" + countRow4].Value = "";
                                    worksheet.Cells["AK" + countRow4].Value = "";
                                    worksheet.Cells["AL" + countRow4].Value = "";
                                    worksheet.Cells["AM" + countRow4].Value = "";
                                    worksheet.Cells["AN" + countRow4].Value = "";
                                    worksheet.Cells["AO" + countRow4].Value = "";
                                    worksheet.Cells["AP" + countRow4].Value = "";
                                    worksheet.Cells["AQ" + countRow4].Value = "";
                                    worksheet.Cells["AR" + countRow4].Value = "";
                                    worksheet.Cells["AS" + countRow4].Value = "";
                                    worksheet.Cells["AT" + countRow4].Value = "";
                                    worksheet.Cells["AU" + countRow4].Value = "";
                                    worksheet.Cells["AV" + countRow4].Value = "";
                                    worksheet.Cells["AW" + countRow4].Value = "";
                                    worksheet.Cells["AX" + countRow4].Value = denominazione5;

                                    countRow4++;

                                    //caso societa
                                    worksheet.Cells["A" + countRow4].Value = "";
                                    worksheet.Cells["B" + countRow4].Value = "";
                                    worksheet.Cells["C" + countRow4].Value = "";
                                    worksheet.Cells["D" + countRow4].Value = "";
                                    worksheet.Cells["E" + countRow4].Value = "";
                                    worksheet.Cells["F" + countRow4].Value = "";
                                    worksheet.Cells["G" + countRow4].Value = "";
                                    worksheet.Cells["H" + countRow4].Value = "";
                                    worksheet.Cells["I" + countRow4].Value = "";
                                    worksheet.Cells["J" + countRow4].Value = "";
                                    worksheet.Cells["K" + countRow4].Value = "";
                                    worksheet.Cells["L" + countRow4].Value = "";
                                    worksheet.Cells["M" + countRow4].Value = "";
                                    worksheet.Cells["N" + countRow4].Value = "";
                                    worksheet.Cells["O" + countRow4].Value = "";
                                    worksheet.Cells["P" + countRow4].Value = "";
                                    worksheet.Cells["Q" + countRow4].Value = "";
                                    worksheet.Cells["R" + countRow4].Value = positingkeydett;
                                    worksheet.Cells["S" + countRow4].Value = CalcolaAccountMulta(resultExport.UserId, 100);
                                    worksheet.Cells["T" + countRow4].Value = "";
                                    worksheet.Cells["U" + countRow4].Value = "";
                                    worksheet.Cells["V" + countRow4].Value = "";
                                    worksheet.Cells["W" + countRow4].Value = "";
                                    worksheet.Cells["X" + countRow4].Value = (resultExport.Quotasocieta).ToString("F2");
                                    worksheet.Cells["Y" + countRow4].Value = "";
                                    worksheet.Cells["Z" + countRow4].Value = "";
                                    worksheet.Cells["AA" + countRow4].Value = CalcolaTaxCodeMulta(resultExport.UserId, 100);
                                    worksheet.Cells["AB" + countRow4].Value = "";
                                    worksheet.Cells["AC" + countRow4].Value = "";
                                    worksheet.Cells["AD" + countRow4].Value = CalcolaCDCMulta(codicecdc, codicecdcsocieta, 100);
                                    worksheet.Cells["AE" + countRow4].Value = "";
                                    worksheet.Cells["AF" + countRow4].Value = "";
                                    worksheet.Cells["AG" + countRow4].Value = "";
                                    worksheet.Cells["AH" + countRow4].Value = "";
                                    worksheet.Cells["AI" + countRow4].Value = resultExport.Targa + " - " + resultExport.Numerocontratto + " - " + resultExport.Datarichiesta.ToString("dd/MM/yyyy");
                                    worksheet.Cells["AJ" + countRow4].Value = "";
                                    worksheet.Cells["AK" + countRow4].Value = "";
                                    worksheet.Cells["AL" + countRow4].Value = "";
                                    worksheet.Cells["AM" + countRow4].Value = "";
                                    worksheet.Cells["AN" + countRow4].Value = "";
                                    worksheet.Cells["AO" + countRow4].Value = "";
                                    worksheet.Cells["AP" + countRow4].Value = "";
                                    worksheet.Cells["AQ" + countRow4].Value = "";
                                    worksheet.Cells["AR" + countRow4].Value = "";
                                    worksheet.Cells["AS" + countRow4].Value = "";
                                    worksheet.Cells["AT" + countRow4].Value = "";
                                    worksheet.Cells["AU" + countRow4].Value = "";
                                    worksheet.Cells["AV" + countRow4].Value = "";
                                    worksheet.Cells["AW" + countRow4].Value = "";
                                    worksheet.Cells["AX" + countRow4].Value = denominazione5;
                                }
                                
                                countRow4++;
                            }
                        }
                    }








                    //**************************** lista dettagli fattura
                    //**************************** template multe fee

                    if (template == 27)
                    {
                        string mesedatadocumento = data.Datadocumento.Month.ToString();
                        int annodocumento = data.Datadocumento.Year;

                        List<IContratti> dataExport = servizioContratti.SelectFattureMulteFee(codcommittente, Guid.Empty, mesedatadocumento, annodocumento);

                        if (dataExport != null && dataExport.Count > 0)
                        {
                            int countRow5 = 9;
                            string denominazione6 = "";
                            string cognome6 = "";
                            string codicecdc = "";
                            decimal importo = 0;
                            foreach (IContratti resultExport in dataExport)
                            {
                                nomefile = "";
                                //recupero nominativo driver
                                IAccount dataU = servizioAccount.DetailId(resultExport.UserId);
                                if (dataU != null)
                                {
                                    denominazione6 = dataU.Cognome + " " + dataU.Nome;
                                    cognome6 = dataU.Cognome.ToUpper();
                                }

                                //tronca denominazione a 20 caratteri 
                                if (denominazione6.Length > 20)
                                {
                                    denominazione6 = denominazione6.Substring(0, 20);
                                }


                                //recupero codcompany e codicecdc della società
                                IUtilitys dataCs = servizioUtilitys.DetailSocietaXCodS(codcommittente);
                                if (dataCs != null)
                                {
                                    nomefile += dataCs.Codcompany + "_" + dataCs.Siglasocieta;
                                    codicecdc = dataCs.Codicecdc;
                                }
                                nomefile += "_Multe_fee_" + mesedatadocumento + annodocumento.ToString().Substring(2, 2);


                                //calcolo importo

                                if (resultExport.Dataconsegna == DateTime.MinValue) //se data pagamento è nullo
                                {
                                    importo = 8;
                                }

                                //se mese e anno pagamento && mese e anno datauserins = mese corrente
                                if ((resultExport.Dataconsegna.Month == DateTime.Now.Month && resultExport.Dataconsegna.Year == DateTime.Now.Year) && 
                                    (resultExport.Datauserins.Month == DateTime.Now.Month && resultExport.Datauserins.Year == DateTime.Now.Year))
                                {
                                    importo = 16;
                                }

                                //se mese e anno pagamento > mese e anno di inserimento
                                if ((resultExport.Dataconsegna.Month > resultExport.Datauserins.Month) && (resultExport.Dataconsegna.Year == resultExport.Datauserins.Month))
                                {
                                    importo = 8;
                                }

                                worksheet.Cells["A" + countRow5].Value = "";
                                worksheet.Cells["B" + countRow5].Value = "";
                                worksheet.Cells["C" + countRow5].Value = "";
                                worksheet.Cells["D" + countRow5].Value = "";
                                worksheet.Cells["E" + countRow5].Value = "";
                                worksheet.Cells["F" + countRow5].Value = "";
                                worksheet.Cells["G" + countRow5].Value = "";
                                worksheet.Cells["H" + countRow5].Value = "";
                                worksheet.Cells["I" + countRow5].Value = "";
                                worksheet.Cells["J" + countRow5].Value = "";
                                worksheet.Cells["K" + countRow5].Value = "";
                                worksheet.Cells["L" + countRow5].Value = "";
                                worksheet.Cells["M" + countRow5].Value = "";
                                worksheet.Cells["N" + countRow5].Value = "";
                                worksheet.Cells["O" + countRow5].Value = "";
                                worksheet.Cells["P" + countRow5].Value = "";
                                worksheet.Cells["Q" + countRow5].Value = "";
                                worksheet.Cells["R" + countRow5].Value = positingkeydett;
                                worksheet.Cells["S" + countRow5].Value = "63400300";
                                worksheet.Cells["T" + countRow5].Value = "";
                                worksheet.Cells["U" + countRow5].Value = "";
                                worksheet.Cells["V" + countRow5].Value = "";
                                worksheet.Cells["W" + countRow5].Value = "";
                                worksheet.Cells["X" + countRow5].Value = importo.ToString("F2");
                                worksheet.Cells["Y" + countRow5].Value = "";
                                worksheet.Cells["Z" + countRow5].Value = "";
                                worksheet.Cells["AA" + countRow5].Value = "PB";
                                worksheet.Cells["AB" + countRow5].Value = "";
                                worksheet.Cells["AC" + countRow5].Value = "";
                                worksheet.Cells["AD" + countRow5].Value = codicecdc;
                                worksheet.Cells["AE" + countRow5].Value = "";
                                worksheet.Cells["AF" + countRow5].Value = "";
                                worksheet.Cells["AG" + countRow5].Value = "";
                                worksheet.Cells["AH" + countRow5].Value = "";
                                worksheet.Cells["AI" + countRow5].Value = "COMPENSI PROFESSIONALI - MAGGIO - " + resultExport.Numerocontratto;
                                worksheet.Cells["AJ" + countRow5].Value = "";
                                worksheet.Cells["AK" + countRow5].Value = "";
                                worksheet.Cells["AL" + countRow5].Value = "";
                                worksheet.Cells["AM" + countRow5].Value = "";
                                worksheet.Cells["AN" + countRow5].Value = "";
                                worksheet.Cells["AO" + countRow5].Value = "";
                                worksheet.Cells["AP" + countRow5].Value = "";
                                worksheet.Cells["AQ" + countRow5].Value = "";
                                worksheet.Cells["AR" + countRow5].Value = "";
                                worksheet.Cells["AS" + countRow5].Value = "";
                                worksheet.Cells["AT" + countRow5].Value = "";
                                worksheet.Cells["AU" + countRow5].Value = "";
                                worksheet.Cells["AV" + countRow5].Value = "";
                                worksheet.Cells["AW" + countRow5].Value = "";
                                worksheet.Cells["AX" + countRow5].Value = denominazione6;

                                countRow5++;
                            }
                        }
                    }


                }


                //rinomina file
                string filenameexcel = nomefile + ".xlsx";

                Response.Clear();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filenameexcel);
                Response.BinaryWrite(excel.GetAsByteArray());
                Response.End();
            }
        }

        public string CalcolaAccount(string codsocieta, Guid UserId, int idtemplate)
        {
            IAccountBL servizioAccount = new AccountBL();

            string retVal = "";
            string persontype = "";
            string codsocietadriver = "";
            string denominazione = "";

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                persontype = data.Persontype;
                codsocietadriver = data.Codsocieta;
                denominazione = data.Cognome + data.Nome;
            }

            if (idtemplate >= 1 && idtemplate <= 14) //template noleggi e conguagli
            {
                if (codsocieta == "3819")
                {
                    retVal = "60205088";
                }

                switch (persontype.ToUpper())
                {
                    case "CLS":
                        retVal = "60003298";
                        break;

                    case "SUP":
                        retVal = "60205088";
                        break;

                    case "PAR":
                        retVal = "60003324";
                        break;

                    case "PEQ":
                        retVal = "60210108";
                        break;
                }

                if (codsocieta != codsocietadriver)
                {
                    retVal = "13200250";
                }

                if (denominazione.ToUpper() == "POOLPOOL")
                {
                    if (codsocieta == "3819")
                    {
                        retVal = "60205088";
                    }
                    else
                    {
                        retVal = "60003298";
                    }
                }

                if (UserId == Guid.Empty)
                {
                    if (codsocieta == "3819")
                    {
                        retVal = "60205088";
                    }
                    else
                    {
                        retVal = "60003298";
                    }
                }
            }

            if (idtemplate >= 18 && idtemplate <= 24) //template bolli
            {
                if (codsocieta == "3819")
                {
                    retVal = "60205092";
                }

                switch (persontype.ToUpper())
                {
                    case "CLS":
                        retVal = "60003315";
                        break;

                    case "SUP":
                        retVal = "60205092";
                        break;

                    case "PAR":
                        retVal = "60003317";
                        break;

                    case "PEQ":
                        retVal = "60210104";
                        break;
                }

                if (idtemplate == 25) //template autostrade telepass
                {
                    retVal = "41600134";
                }
            }
            return retVal;
        }
        public string CalcolaTaxCode(string codsocieta, Guid UserId, int idtemplate, string natura)
        {
            IAccountBL servizioAccount = new AccountBL();
            IContrattiBL servizioContratti = new ContrattiBL();

            string retVal = "";
            string codsocietadriver = "";

            IContratti data = servizioContratti.DetailTemplateFattureId(idtemplate);
            if (data != null)
            {
                retVal = data.Ivatemplate;
            }

            IAccount data2 = servizioAccount.DetailId(UserId);
            if (data2 != null)
            {
                codsocietadriver = data2.Codsocieta;
            }

            if (codsocieta != codsocietadriver)
            {
                retVal = "PB";
            }

            if (natura.Contains("N1"))
            {
                retVal = "PI";
            }
            if (natura.Contains("N2"))
            {
                retVal = "PD";
            }

            return retVal;
        }
        public string CalcolaTaxCodeTelePass(int idtemplate)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            string retVal = "";

            IContratti data = servizioContratti.DetailTemplateFattureId(idtemplate);
            if (data != null)
            {
                retVal = data.Ivatemplate;
            }

            return retVal;
        }
        public string CalcolaDescrizione(string targa, DateTime datainizio, DateTime datafine, string matricola, int idtemplate)
        {
            IContrattiBL servizioContratti = new ContrattiBL();

            string retVal;
            string descrizione = "";

            IContratti data = servizioContratti.DetailTemplateFattureId(idtemplate);
            if (data != null)
            {
                descrizione = data.Descrizionetemplate;
            }

            retVal = targa + " " + datainizio.ToString("dd/MM/yyyy") + " " + datafine.ToString("dd/MM/yyyy") + " " + matricola;

            if (descrizione == "1")
            {
                retVal = targa + " " + datainizio.ToString("dd/MM/yyyy") + " " + datafine.ToString("dd/MM/yyyy") + " " + matricola;
            }

            if (descrizione == "2")
            {
                retVal = targa + " CONGUAGLIO KM";
            }

            return retVal;
        }
        public string CalcolaTarga(string descrizione, string riftesto)
        {
            string targa = "";

            switch (hdtemplateabb.Value)
            {
                case "1": //ALD noleggio [Applicabile ad ALD noleggio - Targa parte dal 8 carattere rif. testo + confronto data documento]
                case "8": //ALD conguaglio
                case "18": //ALD bolli
                    if (!string.IsNullOrEmpty(riftesto))
                    {
                        targa = riftesto.Substring(7, 7);
                    }
                    break;

                case "2": //Alphabet noleggio [Applicabile ad Alphabet noleggio - Targa parte dal 8 carattere rif. testo + confronto data documento]
                case "9": //Alphabet conguaglio
                case "19": //Alphabet bolli
                    string riftestonew = "";

                    //elimina testo prima della parola targa                     
                    if (riftesto.IndexOf("Targa") != -1)
                    {
                        riftestonew = riftesto.Substring(riftesto.IndexOf("Targa"));
                        riftestonew = riftestonew.Replace(":", "");
                        riftestonew = riftestonew.Replace(" ", "");
                    }
                        
                    if (!string.IsNullOrEmpty(riftestonew))
                    {
                        targa = riftestonew.Substring(5, 7);
                    }
                    break;

                case "29": //Alphabet nota credito bolli
                    string descrizionenew = "";

                    //elimina testo prima della parola targa                     
                    if (descrizione.IndexOf("Targa") != -1)
                    {
                        descrizionenew = descrizione.Substring(descrizione.IndexOf("Targa"));
                        descrizionenew = descrizionenew.Replace(":", "");
                        descrizionenew = descrizionenew.Replace(" ", "");
                    }

                    if (!string.IsNullOrEmpty(descrizionenew))
                    {
                        targa = descrizionenew.Substring(5, 7);
                    }
                    break;

                case "3": //Arval noleggio [Applicabile ad Arval Noleggio - Targa primi 7 caratteri descrizione + confronto data inizio periodo]
                case "10": //Arval conguaglio
                case "20": //Arval bolli
                    if (!string.IsNullOrEmpty(descrizione))
                    {
                        targa = descrizione.Substring(0, 7);
                    }
                    break;

                case "4": //Leasys noleggio [Applicabile a Leasys noleggio - Targa parte dal 15 carattere descrizione + confronto data documento]
                case "11": //Leasys conguaglio 
                case "21": //Leasys bolli 
                    if (!string.IsNullOrEmpty(descrizione))
                    {
                        targa = descrizione.Substring(14, 7);
                    }
                    break;

                case "5": //Leasys Rent noleggio [Applicabile a Leasys Rent noleggio]
                case "12": //Leasys Rent conguaglio
                case "22": //Leasys Rent bolli

                    break;

                case "6": //Porsche noleggio [Applicabile a Porsche noleggio]
                case "13": //Porsche conguaglio
                case "23": //Porsche bolli

                    break;

                case "7": //Volks noleggio [Applicabile a Volks noleggio - Targa primi 7 caratteri rif. testo + confronto data documento]
                case "14": //Volks conguaglio
                case "24": //Volks bolli
                    if (!string.IsNullOrEmpty(riftesto))
                    {
                        targa = riftesto.Substring(0, 7);
                    }
                    break;

                case "28": //Leasys canone [Applicabile a Leasys canone - Eliminare dalla descrizione le parole canone servizio o canone locazione e partire da carattere 0 descrizione + confronto data documento]
                    if (!string.IsNullOrEmpty(descrizione))
                    {
                        descrizione = descrizione.ToUpper().Replace("RETTIFICA CANONE LOCAZIONE ", "");
                        descrizione = descrizione.ToUpper().Replace("RETTIFICA CANONE LOCAZIONE", "");
                        descrizione = descrizione.ToUpper().Replace("RETTIFICA CANONE SERVIZIO ", "");
                        descrizione = descrizione.ToUpper().Replace("RETTIFICA CANONE SERVIZIO", "");
                        descrizione = descrizione.ToUpper().Replace("CANONE LOCAZIONE ", "");
                        descrizione = descrizione.ToUpper().Replace("CANONE LOCAZIONE", "");
                        descrizione = descrizione.ToUpper().Replace("CANONE SERVIZIO ", "");
                        descrizione = descrizione.ToUpper().Replace("CANONE SERVIZIO", "");
                        targa = descrizione.Substring(0, 7);
                    }
                    break;
            }

            return targa;
        }

        public string ReturnUrlAss(string descrizione, string riftesto)
        {
            string targa = CalcolaTarga(descrizione, riftesto);
            return "Assegnazioni?targa=" + SeoHelper.EncodeString(targa);
        }



        public string CalcolaAccountCarburante(string codsocieta, string codcompany, Guid UserId)
        {
            IAccountBL servizioAccount = new AccountBL();

            string retVal = "";
            string persontype = "";
            string codsocietadriver = "";

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                persontype = data.Persontype;
                codsocietadriver = data.Codsocieta;
            }

            /*Deloitte Consulting		3804
            CLUSTIN				        3805
            Deloitte Business Solutions	3807	
            Deloitte Risk Advisory		3801
            QUANTUM LEAP			    3802
            Deloitte & Touche		    3800
            Deloitte Financial Advisory	3803
            Officine Innovazioni		3808
            Deloitte Italy			    3819
            */

            switch (persontype.ToUpper())
            {
                case "CLS":

                    switch (codcompany)
                    {
                        case "3804":
                        case "3805":
                        case "3807":
                        case "3801":
                        case "3802":
                        case "3800":
                        case "3803":
                        case "3808":
                            retVal = "60009402";
                            break;
                        case "3809":
                            retVal = "60205101";
                            break;
                    }

                    break;

                case "SUP":
                    switch (codcompany)
                    {
                        case "3804":
                        case "3805":
                        case "3807":
                        case "3801":
                        case "3802":
                        case "3800":
                        case "3803":
                        case "3808":
                        case "3809":
                            retVal = "60205101";
                            break;
                    }
                    break;

                case "PEQ":
                    switch (codcompany)
                    {
                        case "3804":
                        case "3805":
                        case "3807":
                        case "3801":
                        case "3802":
                        case "3800":
                        case "3803":
                        case "3808":
                            retVal = "60210106";
                            break;
                        case "3809":
                            retVal = "60205101";
                            break;
                    }
                    break;

                case "PAR":
                    switch (codcompany)
                    {
                        case "3804":
                        case "3805":
                        case "3807":
                        case "3801":
                        case "3802":
                        case "3800":
                        case "3803":
                        case "3808":
                            retVal = "60009403";
                            break;
                        case "3809":
                            retVal = "60205101";
                            break;
                    }
                    break;
            }


            if (codsocieta != codsocietadriver)
            {
                retVal = "63206001";
            }


            return retVal;
        }


        public string CalcolaAccountMulta(Guid UserId, int idtitolarepagamento)
        {
            IAccountBL servizioAccount = new AccountBL();

            string retVal = "";

            if (idtitolarepagamento == 10)
            {
                retVal = "23200013"; //Se multa da addebitare a cedolino al dipendente
            }

            if (idtitolarepagamento == 100)
            {
                retVal = "64200500"; //Se multa da imputare a costo alla società (nel caso di DIPENDENTI DIMESSI con ultimo cedolino già liquidato)
            }

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {

            }


            return retVal;
        }

        public string CalcolaTaxCodeMulta(Guid UserId, int idtitolarepagamento)
        {
            IAccountBL servizioAccount = new AccountBL();

            string retVal = "";

            if (idtitolarepagamento == 10)
            {
                retVal = "PI"; //Se multa da addebitare a cedolino al dipendente
            }

            if (idtitolarepagamento == 100)
            {
                retVal = "PI"; //Se multa da imputare a costo alla società (nel caso di DIPENDENTI DIMESSI con ultimo cedolino già liquidato)
            }

            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {

            }


            return retVal;
        }

        public string CalcolaCDCMulta(string codicecdc, string codicecdcsocieta, int idtipoassegnazione)
        {
            string retVal = "";

            if (idtipoassegnazione == 10)
            {
                retVal = codicecdc; 
            }

            if (idtipoassegnazione == 100)
            {
                retVal = codicecdcsocieta; 
            }

            return retVal;

        }


        public string CalcolaDataInizioFine(string descrizione, string riftesto)
        {
            string datainiziofine = "";

            switch (hdtemplateabb.Value)
            {
                case "1": //ALD noleggio [Applicabile ad ALD noleggio - Targa parte dal 8 carattere rif. testo + confronto data documento]
                case "8": //ALD conguaglio
                case "18": //ALD bolli


                    break;

                case "2": //Alphabet noleggio [Applicabile ad Alphabet noleggio - Targa parte dal 8 carattere rif. testo + confronto data documento]
                case "9": //Alphabet conguaglio
                case "19": //Alphabet bolli
                    string riftestonew = "";

                    riftestonew = riftesto.Replace("***", "$");
                    string[] arrayTesto = riftestonew.Split('$');

                    if (!string.IsNullOrEmpty(riftestonew))
                    {
                        if (arrayTesto[0].IndexOf("Periodo") != -1)
                        {
                            riftestonew = arrayTesto[0].Substring(arrayTesto[0].IndexOf("Periodo"));
                            riftestonew = riftestonew.Replace("Periodo", "");
                            riftestonew = riftestonew.Replace(":", "");
                            riftestonew = riftestonew.Replace(" ", "");
                            riftestonew = riftestonew.Replace("dal", "");
                            riftestonew = riftestonew.Replace("al", "a");
                        }

                        if (!string.IsNullOrEmpty(riftestonew))
                        {
                            string[] arrayDate = riftestonew.Split('a');
                            datainiziofine = SeoHelper.DataString(arrayDate[0]) + "|" + SeoHelper.DataString(arrayDate[1]);
                        }
                    }
                    break;

                case "29": //Alphabet nota credito bolli
                    string descrizionenew = "";

                    //elimina testo prima della parola periodo da                     
                    if (descrizione.IndexOf("Periodo da") != -1)
                    {
                        descrizionenew = descrizione.Substring(descrizione.IndexOf("Periodo da"));
                        descrizionenew = descrizionenew.Replace("Periodo da", "");
                        descrizionenew = descrizionenew.Replace(":", "");
                        descrizionenew = descrizionenew.Replace(" ", "");
                    }

                    if (!string.IsNullOrEmpty(descrizionenew))
                    {
                        string[] arrayDate = descrizionenew.Split('a');
                        datainiziofine = SeoHelper.DataString(arrayDate[0]) + "|" + SeoHelper.DataString(arrayDate[1]);
                    }
                    break;

                case "3": //Arval noleggio [Applicabile ad Arval Noleggio - Targa primi 7 caratteri descrizione + confronto data inizio periodo]
                case "10": //Arval conguaglio
                case "20": //Arval bolli


                    break;

                case "4": //Leasys noleggio [Applicabile a Leasys noleggio - Targa parte dal 15 carattere descrizione + confronto data documento]
                case "11": //Leasys conguaglio 
                case "21": //Leasys bolli 


                    break;

                case "5": //Leasys Rent noleggio [Applicabile a Leasys Rent noleggio]
                case "12": //Leasys Rent conguaglio
                case "22": //Leasys Rent bolli

                    break;

                case "6": //Porsche noleggio [Applicabile a Porsche noleggio]
                case "13": //Porsche conguaglio
                case "23": //Porsche bolli

                    break;

                case "7": //Volks noleggio [Applicabile a Volks noleggio - Targa primi 7 caratteri rif. testo + confronto data documento]
                case "14": //Volks conguaglio
                case "24": //Volks bolli


                    break;

                case "28": //Leasys canone [Applicabile a Leasys canone - Eliminare dalla descrizione le parole canone servizio o canone locazione e partire da carattere 0 descrizione + confronto data documento]


                    break;
            }

            return datainiziofine;
        }
    }
}
