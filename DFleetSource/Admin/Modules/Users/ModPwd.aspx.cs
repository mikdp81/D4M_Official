// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ModPwd.aspx.cs" company="">
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

namespace DFleet.Admin.Modules.Users
{
    public partial class ModPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {             
            
        }
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            InsertAccount();
        }


        public void InsertAccount()
        {
            IAccountBL servizioAccount = new AccountBL();
            string email;
            List<IAccount> dataExport = servizioAccount.SelectUsersXDate(SeoHelper.DataString("2023-02-23 08:00:00"));

            if (dataExport != null && dataExport.Count > 0)
            {
                foreach (IAccount resultExport in dataExport)
                {
                    email = resultExport.Email;
                    MembershipUser user = Membership.GetUser(email);
                    user.ChangePassword(user.ResetPassword(), "C4sill023.");
                }
            }
        }
    }
}
