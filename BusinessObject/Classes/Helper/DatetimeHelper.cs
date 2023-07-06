// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="DatetimeHelper.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;

namespace BusinessObject
{
    public static class DatetimeHelper
    {
        public static string _stringEmpty = string.Empty;

        public static string DateTimeToString(string date, string format)
        {
            string retVal = _stringEmpty;
            CultureInfo provider = new CultureInfo("it-IT");
            if (DateTime.TryParse(date, provider, DateTimeStyles.None, out DateTime result))
                retVal = result.ToString(format, CultureInfo.CurrentCulture);
            return retVal;
        }

        public static string DateTimeFromDBToString(string date)
        {
            string retVal = " ---- ";
            if (!string.IsNullOrEmpty(date))
            {
                CultureInfo provider = new CultureInfo("it-IT");
                string[] formats = { "yyyyMMdd", "dd/MM/yyyy" };
                DateTime result = DateTime.ParseExact(date, formats, provider, DateTimeStyles.None);
                retVal = result.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture);
            }
            return retVal;
        }

        public static DateTime DateTimeFromDBToDate(string date)
        {
            DateTime retVal;
            CultureInfo provider = new CultureInfo("it-IT");
            string[] formats = { "yyyyMMdd", "dd/MM/yyyy" };
            retVal = DateTime.ParseExact(date, formats, provider, DateTimeStyles.None);
            return retVal;
        }

        public static string NowToString(string format)
        {
            CultureInfo provider = new CultureInfo("it-IT");
            return DateTime.Now.ToString(format, provider);
        }

        public static string NowFromDBToString(string date)
        {
            string retVal = " ---- ";
            if (!string.IsNullOrEmpty(date))
            {
                CultureInfo provider = new CultureInfo("it-IT");
                string[] formats = { "yyyyMMddHHmmss", "dd/MM/yyyy HH:mm:ss" };
                DateTime result = DateTime.ParseExact(date, formats, provider, DateTimeStyles.None);
                retVal = result.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture);
            }
            return retVal;
        }

        public static string DateTimeToISO8601(DateTime date)
        {
            return date.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
        }

        public static string DateTimeToISO86012(DateTime date)
        {
            return date.ToUniversalTime().ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public static string DateTimeToISO86012b(DateTime date)
        {
            return date.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture);
        }
    }
}
