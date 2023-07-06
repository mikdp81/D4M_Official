using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;
using BusinessLogic;
using Google.Authenticator;
using DFleet.Classes;
using AraneaUtilities.Auth;
using BusinessLogic.Services.blob;
using System.Net;
using System.IO;

namespace DFleet
{
    public partial class DownloadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = SeoHelper.EncodeString(Request.QueryString["type"]);
            string nomefile = SeoHelper.EncodeString(Request.QueryString["nomefile"]);
            
            string containerName = type;
            string blobName = nomefile;
            string fileName = nomefile;
            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
            string sas = Global.sas;

            AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
            string result = azureBlobManager.DownloadBlob(fileName, blobName, true);
            string contentType = MimeMapping.GetMimeMapping(fileName);
            if (Path.GetExtension(fileName).Substring(1).ToUpper() == "CSV")
            {
                contentType = "text/csv";
            }

            if (result.ToUpper() == "PARTIAL CONTENT")
            {
                string path = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/" + fileName;

                WebClient client = new WebClient();
                Byte[] buffer = client.DownloadData(path);

                if (buffer != null)
                {
                    //Response.ContentType = "application/pdf";
                    Response.ContentType = contentType;
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.AddHeader("Content-Disposition", "inline; filename=\"" + fileName + "\"");
                    Response.BinaryWrite(buffer);
                }
            }
            else
            {
                Response.Write("File non disponibile");
            }

        }        
    }
}
