// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Documenti.aspx.cs" company="">
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

namespace DFleet.Partner.Modules.Dash
{
    public partial class Documenti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAccountBL servizioAccount = new AccountBL();
            IUtilitysBL servizioUtility = new UtilitysBL();
            string ltdoc = "";
            Guid UserId = (Guid)Membership.GetUser().ProviderUserKey;
            Guid Uidtenant = SeoHelper.ReturnSessionTenant();


            IAccount data = servizioAccount.DetailId(UserId);
            if (data != null)
            {
                //lista categorie documenti
                List<IUtilitys> dataCatDoc = servizioUtility.SelectAllCatDoc(Uidtenant);

                if (dataCatDoc != null && dataCatDoc.Count > 0)
                {
                    foreach (IUtilitys resultCatDoc in dataCatDoc)
                    {
                        ltdoc += "<div class='col-sm-3'><h4>" + resultCatDoc.Categoriadocumento + "</h4><br />";

                        //lista doc
                        List<IUtilitys> dataDoc = servizioUtility.SelectDocumentiXUser(resultCatDoc.Idcatdoc, data.Codsocieta, data.Gradecode, ReturnCodCarPolicy(data.Codsocieta, data.Gradecode));
                        if (dataDoc != null && dataDoc.Count > 0)
                        {
                            foreach (IUtilitys resultDoc in dataDoc)
                            {
                                ltdoc += "<li><a href=\"../../../DownloadFile?type=documenti&nomefile=" + resultDoc.Filedocumento + "\" target='_blank'>" + resultDoc.Nomedocumento + "</a></li>";
                            }
                        }

                        ltdoc += "<br /><br /></div>";
                    }
                }

                ltdati.Text = ltdoc;
            }
            else
            {
                Response.Redirect(ResolveUrl("../../../UnauthorizedAccess.html"));
            }
        }
        public string ReturnCodCarPolicy(string codsocieta, string gradecode)
        {
            IContrattiBL servizioContratti = new ContrattiBL();
            string retVal = string.Empty;

            IContratti dataCodPol = servizioContratti.ReturnCodCarPolicy(codsocieta, gradecode);
            if (dataCodPol != null)
            {
                retVal = dataCodPol.Codcarpolicy;
            }

            return retVal;
        }
    }
}
