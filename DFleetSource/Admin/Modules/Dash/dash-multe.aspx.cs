// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 10-20-2020
// ***********************************************************************
// <copyright file="dash_multe.aspx.cs" company="">
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
    public partial class dash_multe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();
            IUtilitys data = servizioUtility.ViewDashMulte(Uidtenant);
            if (data != null)
            {
                lbltotmulte.Text = data.Tot.ToString();
            }
        }
        public string ReturnMulteMese()
        {
            string retVal = "";
            IUtilitysBL servizioUtility = new UtilitysBL();
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();

            List<IUtilitys> data = servizioUtility.SelectDashMulteMese(Uidtenant);

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
                    data = servizioUtility.SelectDashMulteStatus(Uidtenant);
                    break;

                case "SOCIETA":
                    data = servizioUtility.SelectDashMulteSocieta(Uidtenant);
                    break;

                case "GRADE":
                    data = servizioUtility.SelectDashMulteGrade(Uidtenant);
                    break;

                case "CITTA":
                    data = servizioUtility.SelectDashMulteCitta(Uidtenant);
                    break;

                case "TIPOMULTA":
                    data = servizioUtility.SelectDashMulteTipo(Uidtenant);
                    break;

            }

            if (data != null && data.Count > 0)
            {
                foreach (IUtilitys result in data)
                {
                    if (etichetta.ToUpper() == "SI")
                    {
                        retVal += "'" + result.Etichetta.Replace("'", " ") + "',"; //etichette                               
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
                case "STATUS":
                    viewtable = "view_multe_status";
                    break;

                case "SOCIETA":
                    viewtable = "view_multe_societa";
                    break;

                case "GRADE":
                    viewtable = "view_multe_grade";
                    break;

                case "CITTA":
                    viewtable = "view_multe_citta";
                    break;

                case "TIPOMULTA":
                    viewtable = "view_multe_tipo";
                    break;

            }

            int totale = servizioUtility.SelectCountViewFlotta(viewtable);
            retVal = totale.ToString("N0");
            

            return retVal;
        }
    }
}
