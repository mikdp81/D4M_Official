// ***********************************************************************
// Assembly         : DFleet
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="Revisioni.aspx.cs" company="">
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
using System.Net;
using System.IO;
using AraneaUtilities.Auth;
using AraneaUtilities.CronAsyncTasks;
using Microsoft.VisualBasic.FileIO;
using DFleet.Classes;

namespace DFleet.Crons
{
    /// <summary>
    /// Summary description for Revisioni
    /// </summary>
    public class Revisioni : CronAsyncHandler
    {

        protected override void ServeContent(HttpContext context)
        {
            ICronBL servizioCron = new CronBL();

            //recupero auto con data immatricolazione di 4, 6, 8, 10 anni prima
            List<ICron> dataImm = servizioCron.SelectAutoImmatricolazione();

            if (dataImm != null && dataImm.Count > 0)
            {
                context.Response.Write("--------------- INSERIMENTO REVISIONI DA EFFETTUARE --------------- <br />");

                foreach (ICron resultImm in dataImm)
                {
                    //inserimento targhe in tabella revisione
                    ICron immNew = new Cron
                    {
                        UserId = resultImm.UserId,
                        Targa = resultImm.Targa,
                        Mese = DateTime.Now.Month,
                        Anno = DateTime.Now.Year,
                        Uidtenant = SeoHelper.GuidString("2ADFC3B4-B21D-4545-8FDC-723832AC0969")
                    };

                    if (!servizioCron.ExistRevisione(immNew.Targa, immNew.Mese, immNew.Anno)) //inserisce se non esiste 
                    {
                        servizioCron.InsertRevisione(immNew);
                        context.Response.Write("INSERT INTO EF_contratti_revisioni (targa,UserId,mese,anno,uidtenant) VALUES ('" + immNew.UserId + "', '" + immNew.Targa + "', '" + immNew.Mese + "', '" + immNew.Anno + "', '" + immNew.Uidtenant + "') <br />");
                    }
                }
            }
            else
            {
                context.Response.Write("Nessuna revisione inserita <br />");
            }


            //seleziona tutte le targhe con statuscheck = 0
            List<ICron> dataRev = servizioCron.SelectRevisioniDaEffettuare(); 
            
            if (dataRev != null && dataRev.Count > 0)
            {
                context.Response.Write("<br /><br /> --------------- INVIO MAIL DI REVISIONE DA EFFETTUARE --------------- <br />");

                foreach (ICron resultRev in dataRev)
                {
                    //invio mail
                    ICron dataTemplate = servizioCron.ReturnTemplateEmail(21);
                    if (dataTemplate != null)
                    {
                        if (!string.IsNullOrEmpty(resultRev.Email))
                        {
                            Recuperadatiuser datiUtente = new Recuperadatiuser();
                            MailHelper.SendMail("", resultRev.Email, "", "", "", "", dataTemplate.Oggetto, dataTemplate.Corpo, "", datiUtente.ReturnObjectTenant());
                            context.Response.Write(resultRev.Email + "<br />");
                        }
                    }
                }
            }
            else
            {
                context.Response.Write("Nessuna email di revisione inviata <br />");
            }
        }

    }
}
