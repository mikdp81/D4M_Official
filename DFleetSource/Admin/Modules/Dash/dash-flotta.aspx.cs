// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="dash-flotta.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Security.Permissions;
using System.Threading;
using System.Web.Security;
using BusinessLogic;
using BusinessObject;
using System.Globalization;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace DFleet.Admin.Modules.Dash
{
    public partial class dash_flotta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            IUtilitys data = servizioUtility.ViewDashFlotta(Uidtenant);
            if (data != null)
            {
                lblautoincircolazione.Text = data.Autoincircolazione.ToString();
                lblautoinpool.Text = data.Autoinpool.ToString();
                lblsaldoauto.Text = data.Saldoauto.ToString();

                lblnumerodeltacanone.Text = data.Numerodeltacanone.ToString();
                lblmediadeltacanone.Text = data.Mediadeltacanone.ToString("N2");
                lblmaxdeltacanone.Text = data.Maxdeltacanone.ToString("N2");
                lblmediafringebenefit.Text = data.Mediafringebenefit.ToString("N2");
                lblmaxfringebenefit.Text = data.Maxfringebenefit.ToString("N2");
                lblmediaemissioni.Text = data.Mediaemissioni.ToString("N2");
                lblmaxemissioni.Text = data.Maxemissioni.ToString("N2");

                lblmeseconsegna.Text = data.Meseconsegna.ToString();
                lblannoconsegna.Text = data.Annoconsegna.ToString();
                lblkmmedi.Text = data.Kmmedi.ToString("N0");
                lbletamedia.Text = data.Etamedia.ToString();

                //lbletamediadriver.Text = data.Etamediadriver.ToString();
                //lblpercultimoannoetadriver.Text = data.Percultimoannoetadriver.ToString();
                //lblfornitore1.Text = data.Fornitore1;
                //lblfornitore2.Text = data.Fornitore2;
                //lblpercultimoannokm.Text = data.Percultimoannokm.ToString();
                //lblpercultimoannoeta.Text = data.Percultimoannoeta.ToString();
            }
        }

        public string ReturnAutoCircolazione()
        {
            string retVal = "";
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            List<IUtilitys> data = servizioUtility.SelectDashFlottaTempo(Uidtenant);

            if (data != null && data.Count > 0)
            {
                foreach (IUtilitys result in data)
                {
                    retVal += result.Tot + ",";
                }
            }

            if (!string.IsNullOrEmpty(retVal))
            {
                retVal = retVal.Remove(retVal.Trim().Length - 1);
            }

            return retVal;
        }

        public string ReturnValoriAuto(string chiave, string etichetta)
        {
            string retVal = "";

            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            List<IUtilitys> data = null;

            switch (chiave.ToUpper())
            {
                case "STATUSCONTRATTO":
                    data = servizioUtility.SelectDashFlottaStatusContratto(Uidtenant);
                    break;
                case "CONTRATTO":
                    data = servizioUtility.SelectDashFlottaContratto(Uidtenant);
                    break;

                case "NONASSEGNATO":
                    data = servizioUtility.SelectDashFlottaNonAssegnato(Uidtenant);
                    break;

                case "SOCIETA":
                    data = servizioUtility.SelectDashFlottaSocieta(Uidtenant);
                    break;

                case "GRADE":
                    data = servizioUtility.SelectDashFlottaGrade(Uidtenant);
                    break;

                case "SEDEDRIVER":
                    data = servizioUtility.SelectDashFlottaSedeDriver(Uidtenant);
                    break;

                case "FORNITORE":
                    data = servizioUtility.SelectDashFlottaFornitore(Uidtenant);
                    break;

                case "FORNITORECANONE":
                    data = servizioUtility.SelectDashFlottaFornitoreCanone(Uidtenant);
                    break;

                case "MARCA":
                    data = servizioUtility.SelectDashFlottaMarca(Uidtenant);
                    break;

                case "ANNUALITA":
                    data = servizioUtility.SelectDashFlottaAnnualita(Uidtenant);
                    break;

                case "ALIMENTAZIONE":
                    data = servizioUtility.SelectDashFlottaAlimentazione(Uidtenant);
                    break;
            }

            if (data != null && data.Count > 0)
            {
                foreach (IUtilitys result in data)
                {
                    if (etichetta.ToUpper() == "SI")
                    {
                        switch (chiave.ToUpper())
                        {
                            case "ANNUALITA":
                                retVal += "'" + result.Annoconsegna.ToString() + "',"; //anno
                                break;

                            default:
                                retVal += "'" + result.Etichetta + "',"; //etichette
                                break;
                        }
                    }
                    else
                    {
                        switch (chiave.ToUpper())
                        {
                            case "FORNITORECANONE":
                                retVal += result.Canone.ToString("0.##", CultureInfo.InvariantCulture) + ","; //canone
                                break;

                            default:
                                retVal += result.Tot + ","; //valori
                                break;
                        }
                        
                    }
                }
            }
            if (!string.IsNullOrEmpty(retVal))
            {
                retVal = retVal.Remove(retVal.Trim().Length - 1);
            }

            return retVal;
        }

        public string ReturnTotale(string chiave)
        {
            string retVal;
            string viewtable = "";

            IUtilitysBL servizioUtility = new UtilitysBL();

            switch (chiave.ToUpper())
            {
                case "STATUSCONTRATTO":
                    viewtable = "view_flotta_statuscontratto";
                    break;
                case "CONTRATTO":
                    viewtable = "view_flotta_statuscontratto";
                    break;

                case "NONASSEGNATO":
                    viewtable = "view_flotta_statuscontratto";
                    break;

                case "SOCIETA":
                    viewtable = "view_flotta_societa";
                    break;

                case "GRADE":
                    viewtable = "view_flotta_grade";
                    break;

                case "SEDEDRIVER":
                    viewtable = "view_flotta_sededriver";
                    break;

                case "FORNITORE":
                    viewtable = "view_flotta_fornitori";
                    break;

                case "FORNITORECANONE":
                    viewtable = "view_flotta_fornitori_canone";
                    break;

                case "MARCA":
                    viewtable = "view_flotta_marche";
                    break;

                case "ANNUALITA":
                    viewtable = "view_flotta_annualita";
                    break;

                case "ALIMENTAZIONE":
                    viewtable = "view_flotta_alimentazione";
                    break;
            }

            if (chiave.ToUpper() == "FORNITORECANONE")
            {
                decimal totale = servizioUtility.SelectCountViewFlotta2(viewtable);
                retVal = totale.ToString("N2");
            }
            else
            {
                int totale = servizioUtility.SelectCountViewFlotta(viewtable);
                retVal = totale.ToString("N0");
            }

            return retVal;
        }
    }
}
