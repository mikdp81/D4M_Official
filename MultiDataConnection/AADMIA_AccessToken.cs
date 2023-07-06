using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MultiDataConnection
{
    // Active Directory Managed Identity authentication
    internal class AADMIA_AccessToken
    {
       
        public static string Create(string localManagedIdentityURL, string azureResourcesEndpoint)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(localManagedIdentityURL + azureResourcesEndpoint);
            request.Headers["Metadata"] = "true";
            request.Method = "GET";
            string accessToken = null;

            try
            {
                // Call managed identities for Azure resources endpoint.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Pipe response Stream to a StreamReader and extract access token.
                StreamReader streamResponse = new StreamReader(response.GetResponseStream());
                string stringResponse = streamResponse.ReadToEnd();
                JavaScriptSerializer j = new JavaScriptSerializer();
                Dictionary<string, string> list = (Dictionary<string, string>)j.Deserialize(stringResponse, typeof(Dictionary<string, string>));
                accessToken = list["access_token"];
            }
            catch (Exception e)
            {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                string errorText = String.Format("{0} \n\n{1}", e.Message, e.InnerException != null ? e.InnerException.Message : "Acquire token failed");
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            }

            return accessToken;
        }

    }
}
