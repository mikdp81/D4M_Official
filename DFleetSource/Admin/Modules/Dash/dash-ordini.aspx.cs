using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessObject;

namespace DFleet.Admin.Modules.Dash
{
    public partial class dash_ordini : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            IUtilitys data = servizioUtility.ViewDashOrdini(Uidtenant);
            if (data != null)
            {
                lblconfigurazione.Text = data.Configurazione.ToString();
                lblofferte.Text = data.Offerte.ToString();
                lblinapprovazione.Text = data.Approvazione.ToString();
                lblinconferma.Text = data.Conferma.ToString();
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

            List<IUtilitys> data = servizioUtility.SelectDashFlottaAnnualita(Uidtenant);

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
                case "STATUSORDINE":
                    data = servizioUtility.SelectDashOrdiniStatusOrdine(Uidtenant);
                    break;

                case "SOCIETA":
                    data = servizioUtility.SelectDashOrdiniSocieta(Uidtenant);
                    break;

                case "GRADE":
                    data = servizioUtility.SelectDashOrdiniGrade(Uidtenant);
                    break;

                case "SEDEDRIVER":
                    data = servizioUtility.SelectDashOrdiniSedeDriver(Uidtenant);
                    break;

                case "FORNITORE":
                    data = servizioUtility.SelectDashOrdiniFornitore(Uidtenant);
                    break;

                case "FORNITORECANONE":
                    data = servizioUtility.SelectDashOrdiniFornitoreCanone(Uidtenant);
                    break;

                case "MARCA":
                    data = servizioUtility.SelectDashOrdiniMarca(Uidtenant);
                    break;

                case "ANNUALITA":
                    data = servizioUtility.SelectDashOrdiniAnnualita(Uidtenant);
                    break;

                case "ALIMENTAZIONE":
                    data = servizioUtility.SelectDashOrdiniAlimentazione(Uidtenant);
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
                case "STATUSORDINE":
                    viewtable = "view_ordini_status";
                    break;

                case "SOCIETA":
                    viewtable = "view_ordini_societa";
                    break;

                case "GRADE":
                    viewtable = "view_ordini_grade";
                    break;

                case "SEDEDRIVER":
                    viewtable = "view_ordini_sededriver";
                    break;

                case "FORNITORE":
                    viewtable = "view_ordini_fornitori";
                    break;

                case "FORNITORECANONE":
                    viewtable = "view_ordini_fornitori_canone";
                    break;

                case "MARCA":
                    viewtable = "view_ordini_marche";
                    break;

                case "ANNUALITA":
                    viewtable = "view_ordini_annualita";
                    break;

                case "ALIMENTAZIONE":
                    viewtable = "view_ordini_alimentazione";
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
