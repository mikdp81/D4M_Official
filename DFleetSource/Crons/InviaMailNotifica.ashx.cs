// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="InviaMailNotifica.aspx.cs" company="">
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
using DFleet.Classes;

namespace DFleet.Crons
{
    /// <summary>
    /// Summary description for InviaMailNotifica
    /// </summary>
    public class InviaMailNotifica : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            ICronBL servizioCron = new CronBL();
            HttpResponse response = context.Response;

            List<ICron> data = servizioCron.SelectComunicazioniInserite();

            if (data != null && data.Count > 0)
            {
                foreach (ICron result in data)
                {
                    //invio mail
                    ICron dataTemplate = servizioCron.ReturnTemplateEmail(6);
                    if (dataTemplate != null)
                    {
                        Recuperadatiuser datiUtente = new Recuperadatiuser();
                        MailHelper.SendMail("", servizioCron.DetailId(result.UserIdMittente).Email, "", "", "", "", "Comunicazione n. " + result.Idcomunicazione + " del " + result.Datainvio.ToString("dd/MM/yyyy HH:d") + " presa in carico", dataTemplate.Corpo, "", datiUtente.ReturnObjectTenant());
                    }
                }
            }
            else
            {
                response.Write("Nessuna mail di notifica inviata");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
