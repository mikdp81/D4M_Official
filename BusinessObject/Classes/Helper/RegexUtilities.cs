// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="ValidateHelper.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessObject
{
    public static class RegexUtilities
    {
        private const string OmocodeChars = "LMNPQRSTUV";
        private static readonly int[] ControlCodeArray = new[] { 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23 };
        private static readonly Regex CheckRegex = new Regex(@"^[A-Z]{6}[\d]{2}[A-Z][\d]{2}[A-Z][\d]{3}[A-Z]$");

        private static readonly Regex CheckRegex2 = new Regex(@"^[0-9]{11}$");

        private static string SostituisciLettereOmocodia(string cf)
        {
            char[] cfChars = cf.ToCharArray();
            int[] pos = new[] { 6, 7, 9, 10, 12, 13, 14 };
            foreach (int i in pos)
                if (!Char.IsNumber(cfChars[i]))
                {
                    cfChars[i] = OmocodeChars.IndexOf(cfChars[i]).ToString(CultureInfo.CurrentCulture)[0];
                }

            return new string(cfChars);
        }

        private static string Normalize(string s, bool normalizeDiacritics)
        {
            if (String.IsNullOrEmpty(s))
            {
                return s;
            }

            s = s.Trim().ToUpper(CultureInfo.CurrentCulture);
            if (normalizeDiacritics)
            {
                string src = "ÀÈÉÌÒÙàèéìòù";
                string rep = "AEEIOUAEEIOU";
                for (int i = 0; i < src.Length; i++)
                    s = s.Replace(src[i], rep[i]);
                return s;
            }
            return s;
        }

        private static char CalcolaCarattereDIControllo(string f15)
        {
            int tot = 0;
            byte[] arrCode = Encoding.ASCII.GetBytes(f15.ToUpper(CultureInfo.CurrentCulture));
            for (int i = 0; i < f15.Length; i++)
            {
                if ((i + 1) % 2 == 0) tot += (char.IsLetter(f15, i))
                    ? arrCode[i] - (byte)'A'
                    : arrCode[i] - (byte)'0';
                else tot += (char.IsLetter(f15, i))
                    ? ControlCodeArray[(arrCode[i] - (byte)'A')]
                    : ControlCodeArray[(arrCode[i] - (byte)'0')];
            }
            tot %= 26;
            char l = (char)(tot + 'A');
            return l;
        }

        public static bool IsValidCF(string cf)
        {
            if (String.IsNullOrEmpty(cf) || cf.Length < 11)
            {
                return false;
            }

            cf = Normalize(cf, false);
            if (!CheckRegex.Match(cf).Success && !CheckRegex2.Match(cf).Success)
            {
                // Regex failed: it can be either an omocode or an invalid Fiscal Code
                string cf_NoOmocodia = SostituisciLettereOmocodia(cf);
                if (!CheckRegex.Match(cf_NoOmocodia).Success && !CheckRegex2.Match(cf_NoOmocodia).Success)
                {
                    return false;
                }
                // invalid Fiscal Code
            }

            if (CheckRegex.Match(cf).Success)
                return cf[15] == CalcolaCarattereDIControllo(cf.Substring(0, 15));
            else
                return true;


        }


        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
