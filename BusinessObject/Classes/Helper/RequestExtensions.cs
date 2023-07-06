using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessObject
{
    // valuta se l'URL è locale
    public class RequestExtensions
    {
        public static bool IsLocalUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return false;
            }

            if (Uri.TryCreate(url, UriKind.Absolute, out Uri absoluteUri))
            {
                return String.Equals(HttpContext.Current.Request.Url.Host, absoluteUri.Host,
                            StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                bool isLocal = !url.StartsWith("http:", StringComparison.OrdinalIgnoreCase)
                    && !url.StartsWith("https:", StringComparison.OrdinalIgnoreCase)
                    && Uri.IsWellFormedUriString(url, UriKind.Relative);
                return isLocal;
            }

        }

        public static string GetLocalUrl(string url)
        {
            string localUrl = "";
            if (IsLocalUrl(url))
                localUrl = url;
            return localUrl;
        }
        public static string GetPathPhisicalApplication()
        {
            string Url = "F:\\";

            return Url;
        }
    }
}
