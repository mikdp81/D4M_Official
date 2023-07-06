// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="dash-driver.aspx.cs" company="">
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
    public partial class dash_driver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            IUtilitys data = servizioUtility.ViewDashDriver(Uidtenant);
            if (data != null)
            {
                lbletamediadriver.Text = data.Etamediadriver.ToString();
            }
        }

        public string ReturnValoriAuto(string chiave, string etichetta)
        {
            string retVal = "";

            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            List<IUtilitys> data = null;

            switch (chiave.ToUpper())
            {
                case "GRADE":
                    data = servizioUtility.SelectDashDriverGrade(Uidtenant);
                    break;

                case "SEDE":
                    data = servizioUtility.SelectDashDriverSede(Uidtenant);
                    break;

                case "ETA":
                    data = servizioUtility.SelectDashDriverEta(Uidtenant);
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
                            case "ETA":
                                retVal += "'" + result.Annoconsegna.ToString() + "',"; //anno
                                break;

                            default:
                                retVal += "'" + result.Etichetta + "',"; //etichette
                                break;
                        }
                    }
                    else
                    {                        
                        retVal += result.Tot + ","; //valori
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
                case "GRADE":
                    viewtable = "view_driver_grade";
                    break;

                case "SEDE":
                    viewtable = "view_driver_sede";
                    break;

                case "ETA":
                    viewtable = "view_driver_eta";
                    break;
            }

            int totale = servizioUtility.SelectCountViewFlotta(viewtable);
            retVal = totale.ToString("N0");

            return retVal;
        }
    }
}
