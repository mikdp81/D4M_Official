// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="dash-pool.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Dash
{
    public partial class dash_pool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            IUtilitys data = servizioUtility.ViewDashPool(Uidtenant);
            if (data != null)
            {
                lblautototali.Text = data.Autototali.ToString();
                lblready.Text = data.Ready.ToString();
                lbldariparare.Text = data.Dariparare.ToString();
                lblmeseconsegna.Text = data.Meseconsegna.ToString();
                lblannoconsegna.Text = data.Annoconsegna.ToString();
                lblkmmedi.Text = data.Kmmedi.ToString();

                lblnumerodeltacanone.Text = data.Numerodeltacanone.ToString();
                lblmediadeltacanone.Text = data.Mediadeltacanone.ToString("N2");
                lblmaxdeltacanone.Text = data.Maxdeltacanone.ToString("N2");
                lblmediafringebenefit.Text = data.Mediafringebenefit.ToString("N2");
                lblmaxfringebenefit.Text = data.Maxfringebenefit.ToString("N2");
                lblmediaemissioni.Text = data.Mediaemissioni.ToString("N2");
                lblmaxemissioni.Text = data.Maxemissioni.ToString("N2");
            }
        }
        public string ReturnAutoCircolazione()
        {
            string retVal = "";
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            List<IUtilitys> data = servizioUtility.ViewPoolAutoCircolazione(Uidtenant);

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
                case "STATUS":
                    data = servizioUtility.SelectDashPoolStatus(Uidtenant);
                    break;

                case "SOCIETA":
                    data = servizioUtility.SelectDashPoolSocieta(Uidtenant);
                    break;

                case "FORNITORE":
                    data = servizioUtility.SelectDashPoolFornitore(Uidtenant);
                    break;

                case "FORNITORECANONE":
                    data = servizioUtility.SelectDashPoolFornitoreCanone(Uidtenant);
                    break;

                case "MARCA":
                    data = servizioUtility.SelectDashPoolMarca(Uidtenant);
                    break;

                case "ANNUALITA":
                    data = servizioUtility.SelectDashPoolAnnualita(Uidtenant);
                    break;

                case "ALIMENTAZIONE":
                    data = servizioUtility.SelectDashPoolAlimentazione(Uidtenant);
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
                case "STATUS":
                    viewtable = "view_pool_status";
                    break;

                case "SOCIETA":
                    viewtable = "view_pool_societa";
                    break;

                case "FORNITORE":
                    viewtable = "view_pool_fornitori";
                    break;

                case "FORNITORECANONE":
                    viewtable = "view_pool_fornitori_canone";
                    break;

                case "MARCA":
                    viewtable = "view_pool_marche";
                    break;

                case "ANNUALITA":
                    viewtable = "view_pool_annualita";
                    break;

                case "ALIMENTAZIONE":
                    viewtable = "view_pool_alimentazione";
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
