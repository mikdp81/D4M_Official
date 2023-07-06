// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="SEOHelper.cs" company="">
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
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BusinessObject
{
    public static class SeoHelper
    {
        public static string _stringEmpty = string.Empty;

        public static Regex _puntuationRegex = new Regex("[(\\p{P})+]|[(\\p{C})+]|[(\\p{Z})+]|[(\\p{S})+]|[ ]{2,}", RegexOptions.Compiled);
        public static Regex _underscoreRegex = new Regex("[_]{2,}", RegexOptions.Compiled);

        public static string FixTitleForDB(string value)
        {
            string result = value.Replace("-", " ").Trim();
            return result;
        }

        public static string FixTitleForUrlRewrite(string value)
        {
            string result = RemoveAccentMarks(RemovePuntuation(value, "-"));
            result = _underscoreRegex.Replace(result, "-").Trim();
            return HttpContext.Current.Server.UrlEncode(result);
        }

        public static string FixTitleForSeo(string value)
        {
            return RemoveAccentMarks(RemovePuntuation(value, " "));
        }

        public static string FixTagForSeo(string value)
        {
            return RemoveAccentMarks(value);
        }

        public static string RemoveAccentMarks(string value)
        {
            string normalizedString = value.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            char c = '\0';
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            for (int i = 0; i <= normalizedString.Length - 1; i++)
            {
                c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }

        public static string RemovePuntuation(string value, string replace)
        {
            return _puntuationRegex.Replace(value, replace);
        }

        public static LiteralControl FindDoctypeDeclaration(Control control)
        {
            if (control == null)
            {
                return null;
            }

            foreach (Control c in control.Controls)
            {
#pragma warning disable IDE0019 // Use pattern matching
                var head = c as LiteralControl;
#pragma warning restore IDE0019 // Use pattern matching
                if (head != null && head.Text.ToLowerInvariant().Contains("<!doctype html"))
                    return head;
                head = FindDoctypeDeclaration(c);
                if (head != null)
                    return head;
            }
            return null;
        }

        public static HtmlControl FindHtmlControl(Control control)
        {
            if (control == null)
            {
                return null;
            }

            foreach (Control c in control.Controls)
            {
#pragma warning disable IDE0019 // Use pattern matching
                var head = c as HtmlControl;
#pragma warning restore IDE0019 // Use pattern matching
                if (head != null && head.TagName == "html")
                    return head;
                head = FindHtmlControl(c);
                if (head != null)
                    return head;
            }
            return null;
        }

        public static void RenderBaseLocation(Page page, string baseLocation, bool overwriteExisting)
        {
            if (page == null || page.Header == null)
            {
                return;
            }

            HtmlControl control = page.Header.Controls.OfType<HtmlControl>().FirstOrDefault(item => string.Equals(item.TagName, "base", StringComparison.OrdinalIgnoreCase));
            if (control == null)
            {
                control = new HtmlGenericControl("base");
                control.Attributes.Add("href", baseLocation);
                page.Header.Controls.Add(control);
            }
            else
            {
                if (overwriteExisting)
                    control.Attributes["href"] = baseLocation;
                else
                {
                    if (string.IsNullOrEmpty(control.Attributes["href"]))
                        control.Attributes["href"] = baseLocation;
                }
            }
        }

        public static void RenderTitle(Page page, string siteName, string siteTile, bool overwriteExisting)
        {
            if (page == null || page.Header == null)
            {
                return;
            }

            siteName = (string.IsNullOrEmpty(siteName)) ?
                PathHelper.GetSiteLocation() :
                FixTitleForUrlRewrite(siteName);
            if (!string.IsNullOrEmpty(siteTile))
                siteName = FixTitleForUrlRewrite(siteTile) + ". " + siteName;
            if (overwriteExisting)
                page.Title = HttpUtility.HtmlEncode(siteName);
            else
            {
                if (string.IsNullOrEmpty(page.Title))
                    page.Title = HttpUtility.HtmlEncode(siteName);
            }
        }

        public static void RenderMetaTag(Page page, string name, string httpEquiv, string content, bool overwriteExisting)
        {
            if (page == null || page.Header == null)
            {
                return;
            }

            if (content == null)
            {
                content = _stringEmpty;
            }

            HtmlMeta control =
                (string.IsNullOrEmpty(httpEquiv)) ?
                control = page.Header.Controls.OfType<HtmlMeta>().FirstOrDefault(meta => string.Equals(meta.Name, name, StringComparison.OrdinalIgnoreCase)) :
                control = page.Header.Controls.OfType<HtmlMeta>().FirstOrDefault(meta => string.Equals(meta.HttpEquiv, httpEquiv, StringComparison.OrdinalIgnoreCase));
            if (control == null)
            {
                control = new HtmlMeta();
                if (!string.IsNullOrEmpty(name))
                {
                    control.Name = name;
                }

                if (!string.IsNullOrEmpty(httpEquiv))
                {
                    control.HttpEquiv = httpEquiv;
                }

                control.Content = content;
                page.Header.Controls.Add(control);
            }
            else
            {
                if (overwriteExisting)
                    control.Content = content;
                else
                {
                    if (string.IsNullOrEmpty(control.Content))
                        control.Content = content;
                }
            }
        }

        public static string EncodeStringAdv(string text)
        {
            string retVal = string.Empty;

            if (!string.IsNullOrEmpty(text))
            {
                if (!Regex.IsMatch(text, @"^[\p{L}\p{Zs}\p{Lu}\p{Ll}\p{N}\p{Nd}\p{P}\']{1,255}$"))
                {
                    //eccezione
                    retVal = "INPUT ERROR";
                }
                else
                {
                    retVal = HttpUtility.HtmlEncode(text);
                }
            }

            return retVal;
        }

        public static string EncodeString(string text)
        {
            /*string retVal = string.Empty;

            if (!string.IsNullOrEmpty(text))
            {
                if (!Regex.IsMatch(text, @"^[\p{L}\p{Zs}\p{Lu}\p{Ll}\p{N}\p{Nd}\p{P}\']{1,255}$"))
                {
                    //eccezione
                    retVal = "INPUT ERROR";
                }
                else
                {
                    retVal = HttpUtility.HtmlEncode(text);
                }
            }

            return retVal;*/

            string retVal = string.Empty;

            if (!string.IsNullOrEmpty(text))
            {
                //replace 
                text = text.Replace("＜", "");
                text = text.Replace("＞", "");
                text = text.Replace("‹", "");
                text = text.Replace("›", "");
                text = text.Replace("<", "");
                text = text.Replace(">", "");
                text = text.Replace("&lsaquo;", "");
                text = text.Replace("&rsaquo;", "");
                text = text.Replace("&lt;", "");
                text = text.Replace("&gt;", "");
                retVal = text.Trim();
            }

            return retVal;
        }

        public static string RemoveSymbol(string text)
        {
            string retVal = string.Empty;

            if (!string.IsNullOrEmpty(text))
            {
                retVal = Regex.Replace(text, @"[^\w\d]", "");
            }

            return retVal;
        }
        public static bool IsReadOnly()
        {
            bool retVal = true;

            if (HttpContext.Current.Session["write"] != null)
            {
                if (HttpContext.Current.Session["write"].ToString().ToUpper() == "SI")
                {
                    retVal = true;
                }
                else
                {
                    retVal = false;
                }
            }

            return retVal;
        }
        public static DateTime DataString(string text)
        {
            DateTime retVal;
            if (DateTime.TryParse(EncodeString(text), out DateTime retVal_))
            {
                retVal = retVal_;
            }
            else
            {
                retVal = DateTime.MinValue;
            }

            return retVal;
        }
        public static int IntString(string text)
        {
            int retVal;
            if (Int32.TryParse(EncodeString(text), out int retVal_))
            {
                retVal = retVal_;
            }
            else
            {
                retVal = 0;
            }

            return retVal;
        }
        public static decimal DecimalString(string text)
        {
            decimal retVal;
            if (Decimal.TryParse(EncodeString(text), out decimal retVal_))
            {
                retVal = retVal_;
            }
            else
            {
                retVal = 0;
            }

            return retVal;
        }
        public static Guid GuidString(string text)
        {
            Guid retVal;
            if (Guid.TryParse(EncodeString(text), out Guid retVal_))
            {
                retVal = retVal_;
            }
            else
            {
                retVal = Guid.Empty;
            }

            return retVal;
        }

        public static string CheckDataString(DateTime text)
        {
            string retVal;

            if (text == DateTime.MinValue)
            {
                retVal = "";
            }
            else
            {
                retVal = Convert.ToString(text.ToString("dd/MM/yyyy"), CultureInfo.CurrentCulture);
            }

            return retVal;

        }
        public static string CheckIntString(int text)
        {
            string retVal;

            if (text == 0)
            {
                retVal = "";
            }
            else
            {
                retVal = Convert.ToString(text, CultureInfo.CurrentCulture);
            }

            return retVal;
        }
        public static string CheckDecimalString(decimal text)
        {
            string retVal;

            if (text == 0)
            {
                retVal = "";
            }
            else
            {
                retVal = Convert.ToString(text, CultureInfo.CurrentCulture).Replace(".", ",");
            }

            return retVal;
        }
        public static string CheckGuidString(Guid text)
        {
            string retVal;

            if (text == Guid.Empty)
            {
                retVal = Convert.ToString(Guid.Empty, CultureInfo.CurrentCulture);
            }
            else
            {
                retVal = Convert.ToString(text, CultureInfo.CurrentCulture);
            }

            return retVal;
        }

        public static string OraAttuale()
        {
            return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
        }

        public static int MaxDimensionFile()
        {
            return 209715200; //dimensione massima caricamento di un file
        }
        public static string TextMaxDimensionFile()
        {
            return "200 MB"; //test dimensione massima caricamento di un file
        }
        public static int MaxNumConfigurazioni()
        {
            return 3; //numero massimo di configurazioni
        }
        public static decimal MaxDeltaCanoneSen()
        {
            return 100; //dimensione massima delta canone per passare l'ordine in autorizzato
        }
        public static decimal MaxDeltaCanoneMan()
        {
            return 150; //dimensione massima delta canone per passare l'ordine in autorizzato
        }
        public static decimal MaxDeltaCanoneSMan()
        {
            return 200; //dimensione massima delta canone per passare l'ordine in autorizzato
        }
        public static int MaxNumConfigurazioniPool()
        {
            return 1; //numero massimo di configurazioni pool
        }
        public static string CampoDataStatusOrdine(int idstatusordine)
        {
            string retVal = "";

            switch (idstatusordine)
            {
                case 1: //Configurato da autorizzare
                    retVal = "[dataordine]";
                    break;
                case 10: //Autorizzato in attesa di presa in carico
                    retVal = "[data10]";
                    break;
                case 20: //In attesa di offerta da Rental
                    retVal = "[data20]";
                    break;
                case 25: //Elaborazione offerta 
                    retVal = "[data25]";
                    break;
                case 30: //Offerta da valutare Driver
                    retVal = "[data30]";
                    break;
                case 40: //Offerta da valutare D4M
                    retVal = "[data40]";
                    break;
                case 50: //In attesa di evasione Rental
                    retVal = "[data50]";
                    break;
                case 55: //Evaso Rental
                    retVal = "[data55]";
                    break;
                case 60: //Offerta contrattualizzata
                    retVal = "[data60]";
                    break;
                case 100: //Scartato Driver
                    retVal = "[data100]";
                    break;
                case 110: //Non Autorizzato
                    retVal = "[data110]";
                    break;
            }

            return retVal;
        }
        public static string PassPhrase()
        {
            return "b123acd4"; //password per criptazione stringa
        }

        public static string EmailMittente()
        {
            return "automatic.d4m@deloitte.it";
        }

        public static string FiscalYear(string mese, string anno)
        {
            string retVal;

            int mese_ = IntString(mese);
            int anno_ = IntString(anno);

            if (mese_ < 6)
            {
                retVal = "FY" + anno_;
            }
            else
            {
                retVal = "FY" + (anno_ + 1);
            }

            return retVal;
        }
        public static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
        public static string RenameFileUpload(string text)
        {
            string retVal = string.Empty;

            if (!string.IsNullOrEmpty(text))
            {
                //replace 
                text = text.Replace("＜", "");
                text = text.Replace("＞", "");
                text = text.Replace("‹", "");
                text = text.Replace("›", "");
                text = text.Replace("<", "");
                text = text.Replace(">", "");
                text = text.Replace("&lsaquo;", "");
                text = text.Replace("&rsaquo;", "");
                text = text.Replace("&lt;", "");
                text = text.Replace("&gt;", "");
                text = text.Replace("'", "");
                text = text.Replace(" ", "-");
                retVal = text.Trim();
            }

            return retVal;
        }
        public static Guid ReturnSessionTenant()
        {
            Guid retVal = Guid.Empty;

            if (HttpContext.Current.Session["UidTenant"] != null)
            {
                retVal = GuidString(HttpContext.Current.Session["UidTenant"].ToString());
            }

            return retVal;
        }
    }
}
