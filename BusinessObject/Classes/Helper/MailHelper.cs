// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 09-03-2020
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="MailHelper.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace BusinessObject
{
    public static class MailHelper
    {
#pragma warning disable IDE0060 // Remove unused parameter
        public static bool SendMail(string mailFrom, string mailTo, string mailTo2, string mailTo3, string mailTo4, string mailTo5, string subject, string htmlBody, string attachment, string preoggetto)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            bool retVal = false;

            try
            {
                string pathFile = RequestExtensions.GetPathPhisicalApplication();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("dcmmail.atrema.deloitte.com");
                mail.From = new MailAddress(SeoHelper.EmailMittente());
                mail.To.Add(mailTo);
                mail.Bcc.Add("automatic.d4m@deloitte.it");
                if (!string.IsNullOrEmpty(mailTo2))
                {
                    mail.To.Add(mailTo2);
                }
                if (!string.IsNullOrEmpty(mailTo3))
                {
                    mail.To.Add(mailTo3);
                }
                if (!string.IsNullOrEmpty(mailTo4))
                {
                    mail.To.Add(mailTo4);
                }
                if (!string.IsNullOrEmpty(mailTo5))
                {
                    mail.To.Add(mailTo5);
                }
                mail.Subject = preoggetto + subject;
                mail.IsBodyHtml = true;
                mail.Body = htmlBody;
                if (!string.IsNullOrEmpty(attachment))
                {
                    mail.Attachments.Add(new Attachment(pathFile + attachment));
                }

                SmtpServer.Port = 25;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("", "");
                //SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);

                retVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return retVal;
        }




        public static bool SendMailConfigurazione(string mailTo, string mailCC, string subject, string htmlBody, string attachment)
        {
            bool retVal = false;

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("dcmmail.atrema.deloitte.com");
                mail.From = new MailAddress(SeoHelper.EmailMittente());
                mail.To.Add(mailTo);
                if (!string.IsNullOrEmpty(mailCC))
                {
                    mail.CC.Add(mailCC);
                }
                mail.Bcc.Add("automatic.d4m@deloitte.it");               
                mail.Subject = "D4M - Premium - " + subject;
                mail.IsBodyHtml = true;
                mail.Body = htmlBody;
                if (!string.IsNullOrEmpty(attachment))
                {
                    string[] attachmentList = attachment.Split('*');
                    foreach (string attach in attachmentList)
                    {
                        if (!string.IsNullOrEmpty(attach))
                        {
                            mail.Attachments.Add(new Attachment(RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/" + attach));
                        }
                    }
                }
                SmtpServer.Port = 25;
                SmtpServer.Send(mail);

                retVal = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return retVal;
        }
    }
}
