// ***********************************************************************
// Assembly         : BusinessObject
// Author           : Araneamarketing
// Created          : 21-10-2021
//
// Last Modified By : Araneamarketing
// Last Modified On : 21-10-2021
// ***********************************************************************
// <copyright file="PathHelper.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Globalization;

namespace BusinessObject
{
    public static class PathHelper
    {
        public static string _stringEmpty = string.Empty;

        public static string ServerVariables(string name)
        {
            string result = _stringEmpty;
            try
            {
                if (HttpContext.Current.Request.ServerVariables[name] != null)
                    result = HttpContext.Current.Request.ServerVariables[name].ToString(CultureInfo.CurrentCulture);
            }
            catch(CultureNotFoundException)
            {
                result = _stringEmpty;
            }
            return result;
        }

        public static string GetNameHost()
        {
            string result = ServerVariables("HTTP_HOST");
            if (result.EndsWith("/", StringComparison.CurrentCulture))
            {
                result.Substring(0, result.Length - 1);
            }

            return result.ToLowerInvariant();
        }

        public static string GetSiteHost()
        {
            string result = "http://" + GetNameHost();
            if (!result.EndsWith("/", StringComparison.CurrentCulture))
            {
                result += "/";
            }

            return result.ToLowerInvariant();
        }

        public static string GetSiteLocation()
        {
            string result = GetSiteHost();
            if (result.EndsWith("/", StringComparison.CurrentCulture))
            {
                result = result.Substring(0, result.Length - 1);
            }

            result += HttpContext.Current.Request.ApplicationPath;
            if (!result.EndsWith("/", StringComparison.CurrentCulture))
            {
                result += "/";
            }

            return result;
        }

        public static string GetCurrentLocation()
        {
            string result = GetSiteHost();
            string path = HttpContext.Current.Request.Path.Substring(0, HttpContext.Current.Request.Path.LastIndexOf("/", StringComparison.CurrentCulture));
            if (path.StartsWith("/", StringComparison.CurrentCulture))
            {
                path = path.Substring(1, path.Length - 1);
            }

            result += path;
            if (!result.EndsWith("/", StringComparison.CurrentCulture))
            {
                result += "/";
            }

            return result;
        }

        public static string GetCurrentUrl()
        {
            Uri uri = new Uri(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.RawUrl);
            if (uri.Query.Length > 0)
            {
                uri = new Uri(uri.AbsoluteUri.Replace(uri.Query, _stringEmpty));
            }

            return uri.AbsoluteUri;
        }

        public static string GetCurrentUrl(string[] sQueryParameters)
        {
            StringBuilder sQueryString = new StringBuilder();
            if (sQueryParameters.Length > 0)
            {
                sQueryString.Append("?");
                foreach (string sQueryParameter in sQueryParameters)
                {
                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[sQueryParameter]))
                        sQueryString.Append("&" + sQueryParameter + "=" + HttpContext.Current.Request.QueryString[sQueryParameter]);
                }
                sQueryString.Replace("?&", "?");
                if (sQueryString.Length == 1)
                    sQueryString.Remove(0, sQueryString.Length);
            }

            Uri uri = new Uri(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.RawUrl);
            if (uri.Query.Length > 0)
            {
                uri = new Uri(uri.AbsoluteUri.Replace(uri.Query, _stringEmpty));
            }
            return uri.AbsoluteUri + sQueryString.ToString();
        }

        public static string MapPath(string path)
        {
            return HostingEnvironment.MapPath(path);
        }

        public static string ApplicationVirtualPath()
        {
            string result = HostingEnvironment.ApplicationVirtualPath;
            if (!result.EndsWith("/", StringComparison.CurrentCulture))
            {
                result += "/";
            }

            return result;
        }

        public static string ApplicationPhysicalPath()
        {
            string result = HostingEnvironment.ApplicationPhysicalPath;
            if (!result.EndsWith(@"\", StringComparison.CurrentCulture))
            {
                result += @"\";
            }

            return result.Replace("\\", @"\");
        }

        public static string AdministrationVirtualPath()
        {
            return ApplicationVirtualPath() + "WebAdministration/";
        }

        public static string HomeUrl()
        {
            return GetSiteLocation();
        }

        public static string HomeUrl(string page)
        {
            return (GetSiteLocation() + page).Trim();
        }

        public static string HomeUrl(string language, string page)
        {
            string url = GetSiteLocation();
            string path = _stringEmpty;
            if (!string.IsNullOrEmpty(language))
            {
                path += (language + "/");
            }

            return ((!string.IsNullOrEmpty(path)) ? url + path + page : url + page).Trim();
        }                

        public static string PagesUrlDir(string dir, string key)
        {
            string url = GetSiteLocation();
            string path = _stringEmpty;
            if (!string.IsNullOrEmpty(dir))
            {
                path += (dir + "/");
            }

            return ((!string.IsNullOrEmpty(path)) ? url + path + key + ".aspx" : url + key + ".aspx").Trim();
        }

        public static string PagesUrlDir(string language, string dir, string key)
        {
            string url = GetSiteLocation();
            string path = _stringEmpty;
            if (!string.IsNullOrEmpty(language))
            {
                path += (language + "/");
            }

            if (!string.IsNullOrEmpty(dir))
            {
                path += (dir + "/");
            }

            return ((!string.IsNullOrEmpty(path)) ? url + path + key + ".aspx" : url + key + ".aspx").Trim();
        }

        public static string PagesUrl(string key, string page)
        {
            string url = GetSiteLocation();
            string path = _stringEmpty;
            if (!string.IsNullOrEmpty(key))
            {
                path += (key + "/");
            }

            return ((!string.IsNullOrEmpty(path)) ? url + path + page : url + page).Trim();
        }

        public static string PagesUrl(string language, string key, string page)
        {
            string url = GetSiteLocation();
            string path = _stringEmpty;
            if (!string.IsNullOrEmpty(language))
            {
                path += (language + "/");
            }

            if (!string.IsNullOrEmpty(key))
            {
                path += (key + "/");
            }

            return ((!string.IsNullOrEmpty(path)) ? url + path + page : url + page).Trim();
        }

        public static bool IsStaticResource(string virtualPathFile)
        {
            string extension = VirtualPathUtility.GetExtension(virtualPathFile);
            if (extension == null)
            {
                return false;
            }

            switch (extension.ToLower(CultureInfo.CurrentCulture))
            {
                case ".txt":
                case ".swf":
                case ".js":
                case ".css":
                case ".html":
                case ".htm":
                case ".bmp":
                case ".gif":
                case ".ico":
                case ".jpeg":
                case ".jpg":
                case ".png":
                case ".rar":
                case ".zip":
                    return true;
                default:
                    // do the default action
                    break;
            }
            return false;
        }

        public static bool IsImageResource(string virtualPathFile)
        {
            string extension = VirtualPathUtility.GetExtension(virtualPathFile);
            if (extension == null)
            {
                return false;
            }

            switch (extension.ToLower(CultureInfo.CurrentCulture))
            {
                case ".bmp":
                case ".gif":
                case ".ico":
                case ".jpeg":
                case ".jpg":
                case ".png":
                    return true;
                default:
                    // do the default action
                    break;
            }
            return false;
        }

        public static string MediaTypeImage(string virtualPathFile)
        {
            string extension = VirtualPathUtility.GetExtension(virtualPathFile);
            if (extension == null)
            {
                return _stringEmpty;
            }

            switch (extension.ToLower(CultureInfo.CurrentCulture))
            {
                case ".bmp":
                    return "image/bmp";
                case ".gif":
                    return "image/gif";
                case ".ico":
                    return "image/x-icon";
                case ".jpeg":
                case ".jpg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                default:
                    return _stringEmpty;
            }
        }

        public static long GetFileSize(string phisicalPathFile)
        {
            if (File.Exists(phisicalPathFile))
                return (new FileInfo(phisicalPathFile).Length);
            return 0;
        }


    }
}