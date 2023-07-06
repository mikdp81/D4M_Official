// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ConvertDaPagareDeloitte.aspx.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text;
using BusinessObject;
using BusinessLogic;
using System.Globalization;
using System.Web.Script.Serialization;

namespace DFleet.Crons
{
    /// <summary>
    /// Summary description for CreaUserPolicy
    /// </summary>
    public class CreaUserPolicy : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ICronBL servizioCron = new CronBL();
            HttpResponse response = context.Response;

            List<ICron> data = servizioCron.SelectContrattiUserInScadenza();

            if (data != null && data.Count > 0)
            {
                foreach (ICron result in data)
                {
                    ICron dataId = servizioCron.DetailId(result.UserId);
                    if (dataId != null)
                    {

                        //controllo esistenza user carpolicy
                        if (!servizioCron.ExistUserCarPolicy(dataId.Idutente))
                        {

                            //inserimento user carpolicy

                            ICron contrattiuserCarPolicyNew = new Cron
                            {
                                Idutente = dataId.Idutente,
                                Codsocieta = dataId.Codsocieta,
                                Codcarpolicy = ReturnCodCarPolicy(dataId.Codsocieta, dataId.Gradecode),
                                Idapprovatore = ReturnIdApprovatore(),
                                Flgmail = "",
                                Approvato = 0,
                                Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                            };

                            if (servizioCron.InsertUserCarPolicy(contrattiuserCarPolicyNew) == 1)
                            {
                                response.Write("INSERT INTO EF_users_carpolicy ([idutente],[codsocieta],[codcarpolicy],[idapprovatore],[flgmail],[approvato],[uidtenant]) ");
                                response.Write("VALUES ('" + contrattiuserCarPolicyNew.Idutente + "', '" + contrattiuserCarPolicyNew.Codsocieta + "','" + contrattiuserCarPolicyNew.Codcarpolicy + "','" + contrattiuserCarPolicyNew.Idapprovatore + "','','0','" + contrattiuserCarPolicyNew.Uidtenant + "') <br />");
                            }
                            else
                            {
                                response.Write("CarPolicy Users " + contrattiuserCarPolicyNew.Idutente + " - ERRORE! Non processata. <br />");
                            }
                        }
                    }
                }
            }
            else
            {
                response.Write("Nessuno contratto processato");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
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

        public int ReturnIdApprovatore()
        {
            IAccountBL servizioAccount = new AccountBL();
            int retVal = 0;

            IAccount dataId = servizioAccount.DetailId((Guid)Membership.GetUser().ProviderUserKey);
            if (dataId != null)
            {
                retVal = dataId.Iduser;
            }

            return retVal;
        }
    }
}
