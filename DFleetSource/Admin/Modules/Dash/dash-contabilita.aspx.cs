// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="dash_contabilita.aspx.cs" company="">
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
    public partial class dash_contabilita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            IUtilitys data = servizioUtility.ViewDashContabilita(Uidtenant);
            if (data != null)
            {
                lblfatture.Text = data.Tot.ToString();
            }
        }
        public string ReturnNumeroFatture()
        {
            string retVal = "";
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            List<IUtilitys> data = servizioUtility.SelectDashContabilitaFattureMese(Uidtenant);

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
                case "SOCIETA":
                    data = servizioUtility.SelectDashContabilitaSocieta(Uidtenant);
                    break;

                case "SOCIETAIMPORTO":
                    data = servizioUtility.SelectDashContabilitaSocietaImporto(Uidtenant);
                    break;

                case "FORNITORE":
                    data = servizioUtility.SelectDashContabilitaFornitore(Uidtenant);
                    break;

                case "FORNITOREIMPORTO":
                    data = servizioUtility.SelectDashContabilitaFornitoreImporto(Uidtenant);
                    break;

                case "TEMPLATE":
                    data = servizioUtility.SelectDashContabilitaTemplate(Uidtenant);
                    break;

                case "TEMPLATEIMPORTO":
                    data = servizioUtility.SelectDashContabilitaTemplateImporto(Uidtenant);
                    break;
            }

            if (data != null && data.Count > 0)
            {
                foreach (IUtilitys result in data)
                {
                    if (etichetta.ToUpper() == "SI")
                    {                        
                        retVal += "'" + result.Etichetta + "',"; //etichette
                    }
                    else
                    {
                        switch (chiave.ToUpper())
                        {
                            case "SOCIETAIMPORTO":
                            case "FORNITOREIMPORTO":
                            case "TEMPLATEIMPORTO":
                                retVal += result.Importototale.ToString("0.##", CultureInfo.InvariantCulture) + ","; //importo
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
                case "SOCIETA":
                    viewtable = "view_contabilita_societa";
                    break;

                case "SOCIETAIMPORTO":
                    viewtable = "view_contabilita_societa_importo";
                    break;

                case "FORNITORE":
                    viewtable = "view_contabilita_fornitori";
                    break;

                case "FORNITOREIMPORTO":
                    viewtable = "view_contabilita_fornitori_importo";
                    break;

                case "TEMPLATE":
                    viewtable = "view_contabilita_template";
                    break;

                case "TEMPLATEIMPORTO":
                    viewtable = "view_contabilita_template_importo";
                    break;
            }

            switch (chiave.ToUpper())
            {
                case "SOCIETAIMPORTO":
                case "FORNITOREIMPORTO":
                case "TEMPLATEIMPORTO":
                        decimal totale = servizioUtility.SelectCountViewFlotta2(viewtable);
                        retVal = totale.ToString("N2");
                    break;

                default:
                        int totale2 = servizioUtility.SelectCountViewFlotta(viewtable);
                        retVal = totale2.ToString("N0");
                    break;
            }

            return retVal;
        }
    }
}
