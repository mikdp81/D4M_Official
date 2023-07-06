// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ViewCalendario.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BusinessObject;
using BusinessLogic;
using System.Web.Security;
using System.Globalization;
using System.Web;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Drawing;
using DFleet.Classes;

namespace DFleet.Admin.Modules.Utility
{
    public partial class ViewCalendario : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Recuperadatiuser datiUtente = new Recuperadatiuser();
            if (!datiUtente.ReturnExistPage(33)) //controllo se la pagina è autorizzata per l'utente 
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            hduiduser.Value = Membership.GetUser().ProviderUserKey.ToString();
        }
        public string ReturnEvent()
        {
            string retVal = "";
            DateTime dataoggi = DateTime.Now;
            string segno;
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            IUtilitysBL servizioUtility = new UtilitysBL();

            List<IUtilitys> data = servizioUtility.SelectAllTask(UserId);

            if (data != null && data.Count > 0)
            {
                foreach (IUtilitys result in data)
                {
                    int diffdate = (result.Datatask.Date - dataoggi.Date).Days;

                    if (diffdate >= 0)
                    {
                        segno = "+";
                    }
                    else
                    {
                        segno = "";
                    }

                    retVal += "{";
                    retVal += "title: '" + result.Testotask + "', ";
                    if (!string.IsNullOrEmpty(result.Linktask))
                    {
                        retVal += "start: new Date(year, month, day " + segno + diffdate + "), ";
                        retVal += "url: '" + result.Linktask + "'";
                    }
                    else
                    {
                        retVal += "start: new Date(year, month, day " + segno + diffdate + ") ";
                    }
                    retVal += "},";
                }

                retVal.Remove(retVal.Trim().Length - 1);
            }

            return retVal;
        }
    }
}
