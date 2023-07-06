// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewConcur.aspx.cs" company="">
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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using DFleet.Classes;
using System.IO;
using System.Drawing;
using System.Text;

namespace DFleet.Admin.Modules.Car
{
    public partial class ViewConcur : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(67)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadPage();
        }
        protected void btnCerca_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriFiltri()", true);
            loadPage();
        }
        protected void btnOrdina_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ApriOrdinamento()", true);
            loadPage();
        }
        public void loadPage()
        {
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            pnlMessage.Visible = false;
            pnlMessage2.Visible = false;
            string matricola = SeoHelper.EncodeString(txtMatricola.Text);
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int totaleRighe = servizioFileTracciati.SelectCountViewConcur(matricola, targa, Uidtenant);
            int maxPage = (totaleRighe / totaleRecord) + 1;
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


            if (gvConcur.HeaderRow != null)
            {
                //aggiunge il tag THEAD nell'intestazione della gridview
                gvConcur.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            lblNumRecord.Text = "Concur: " + HttpUtility.HtmlEncode(totaleRighe);
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

        protected void btnSvuotaFiltri_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewConcur");
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
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            string matricola = SeoHelper.EncodeString(txtMatricola.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            int totaleRighe = servizioFileTracciati.SelectCountViewConcur(matricola, targa, Uidtenant);
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int maxPage = (totaleRighe / totaleRecord) + 1;

            int valore = Convert.ToInt32(txtnumpag.Text);
            if (valore < 1) valore = 1;
            if (maxPage < valore) valore = maxPage;

            Paginations("elenco", valore);
        }

        public void Paginations(string tipo, int valore)
        {
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();
            string matricola = SeoHelper.EncodeString(txtMatricola.Text);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            int totaleRighe = servizioFileTracciati.SelectCountViewConcur(matricola, targa, Uidtenant);
            int totaleRecord = Convert.ToInt32(ddlNRecord.SelectedValue);
            int maxPage = (totaleRighe / totaleRecord) + 1;

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


        /********************** ESPORTA CSV **********************/

        protected void btnEsporta_Click(object sender, EventArgs e)
        {
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

            string nomefile = DateTime.Now.Day.ToString("d2") + DateTime.Now.Month.ToString("d2") + DateTime.Now.Year.ToString().Substring(2,2) + "_fuel";

            StringBuilder builder = new StringBuilder();
            builder.Append("MODELLO;IDEMPL;ANNUMBER;CODGEST;IDFUELCARD;DTSTARTVL;DTENDVL");
            builder.AppendLine();

            string matricola = SeoHelper.EncodeString(txtMatricola.Text);
            string targa = SeoHelper.EncodeString(ddlTarga.SelectedValue);
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            List<IFileTracciati> dataExport = servizioFileTracciati.SelectViewConcur(matricola, targa, Uidtenant, 100000, 1);

            if (dataExport != null && dataExport.Count > 0)
            {
                foreach (IFileTracciati resultExport in dataExport)
                {
                    builder.Append(resultExport.Modello + ";" + resultExport.Matricola + ";" + resultExport.Targa + ";" + resultExport.Codservice + ";" + resultExport.Numerofuelcard + ";" + resultExport.Datainizioperiodo.ToString("dd/MM/yyyy") + ";31/12/2999");
                    builder.AppendLine();
                }
            }


            // crea response
            Response.Clear();
            //CSV
            Response.ContentType = "text/csv";
            Response.ContentEncoding = Encoding.GetEncoding("Windows-1252");
            Response.AddHeader("Content-Disposition", "attachment;filename=" + nomefile + ".csv");
            Response.Write(builder.ToString());
            Response.End();
        }

        /********************** FINE ESPORTA CSV **********************/


        /********************** ESPORTA TXT **********************/

        protected void btnEsportaTxt_Click(object sender, EventArgs e)
        {
            IFileTracciatiBL servizioFileTracciati = new FileTracciatiBL();

            string nomefile = "employee_p0605152ufwo_ITC900_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("d2") + DateTime.Now.Day.ToString("d2") 
                + DateTime.Now.Hour.ToString("d2") + DateTime.Now.Minute.ToString("d2") + DateTime.Now.Second.ToString("d2");

            StringBuilder builder = new StringBuilder();
            builder.Append("100,0,SSO,UPDATE,EN,N,N");
            builder.AppendLine();

            //controllo sulla tabella EF_concur_900 se c'è una riga con la data di oggi
            if (!servizioFileTracciati.ExistDataConcur())  
            {
                //se la data è inesistente copio la vista concur nella tabella EF_concur_900 con la data di oggi

                List<IFileTracciati> dataExport = servizioFileTracciati.SelectViewConcurTxt();

                if (dataExport != null && dataExport.Count > 0)
                {
                    foreach (IFileTracciati resultExport in dataExport)
                    {
                        //controllo variazioni per ogni riga di EF_concur_900 di oggi e verifica
                        //se rispetto alla matricola della precedente esportazione, 
                        //la voce descrizione è differente crea nuovo record con la Y
                        string descrizioneold = "";
                        string targaold = "";
                        string tipoold = "";
                        int benefitold = 0;

                        IFileTracciati data = servizioFileTracciati.DetailConcur900(resultExport.Campo2);
                        if (data != null)
                        {
                            descrizioneold = data.Descrizione;
                            tipoold = data.Campo3;
                            targaold = data.Campo4;
                            benefitold = SeoHelper.IntString(data.Campo6);
                        }

                        if ((resultExport.Campo5.ToUpper() != descrizioneold.ToUpper()) && !string.IsNullOrEmpty(descrizioneold))
                        {
                            //creo nuova riga con aggiunta y
                            IFileTracciati RowConcurNew = new FileTracciati
                            {
                                Campo1 = resultExport.Campo1,
                                Campo2 = resultExport.Campo2,
                                Campo3 = tipoold,
                                Campo4 = targaold,
                                Campo5 = descrizioneold,
                                Benefit = benefitold,
                                Modifica = "Y"
                            };

                            servizioFileTracciati.InsertConcur900(RowConcurNew);
                        }

                        //inserimento riga in EF_concur_900
                        IFileTracciati RowConcur = new FileTracciati
                        {
                            Campo1 = resultExport.Campo1,
                            Campo2 = resultExport.Campo2,
                            Campo3 = resultExport.Campo3,
                            Campo4 = resultExport.Campo4,
                            Campo5 = resultExport.Campo5,
                            Benefit = SeoHelper.IntString(resultExport.Campo6),
                            Modifica = ""
                        };
                        servizioFileTracciati.InsertConcur900(RowConcur);

                    }
                }
            }


            //elenco concur 900 da scaricare
            List<IFileTracciati> dataExport2 = servizioFileTracciati.SelectViewConcur900Txt();

            if (dataExport2 != null && dataExport2.Count > 0)
            {
                foreach (IFileTracciati resultExport2 in dataExport2)
                {
                    builder.Append(resultExport2.Campo1 + "," + resultExport2.Campo2 + "," + resultExport2.Campo3 + "," + resultExport2.Campo4 + "," + resultExport2.Campo5 + "," + resultExport2.Benefit + "," + resultExport2.Modifica);
                    builder.AppendLine();
                }
            }

            // crea response
            Response.Clear();
            //CSV
            Response.ContentType = "text/plain";
            Response.ContentEncoding = Encoding.GetEncoding("Windows-1252");
            Response.AddHeader("Content-Disposition", "attachment;filename=" + nomefile + ".txt");
            Response.Write(builder.ToString());
            Response.End();

        }

        /********************** FINE ESPORTA TXT **********************/
    }
}
