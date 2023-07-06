using System;
using System.IO;
using System.Web;
using BusinessLogic.Services.blob;
using BusinessObject;
using DocuSign.eSign.Api;
using DocuSign.eSign.Client;

namespace FirmaDigitale
{
    internal class DowloadController
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private string docSelect = "combined";
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning disable IDE0044 // Add readonly modifier
        private string docName = SeoHelper.OraAttuale() + "_firmato.pdf";
#pragma warning restore IDE0044 // Add readonly modifier
        internal string filefirma = SeoHelper.OraAttuale() + "_firmato.pdf";


        internal void DownloadFile(User user, string envelopeId, UserConfig userConfig)
        {
            // Call the Examples API method to download the specified document from the envelope
            var result = this.GetDocument(user.AccessToken, userConfig.BasePath, userConfig.AccountId,
                envelopeId, docSelect, docName);

            // salva Stream su server
            SaveStreamAsFile(result.Item1, result.Item2, result.Item3);

        }


        // recupero lo stream del documento via API
        private (Stream, string, string) GetDocument(string accessToken, string basePath, string accountId, string envelopeId, string documentId, string docName)
        {
            var apiClient = new ApiClient(basePath);
            apiClient.Configuration.DefaultHeader.Add("Authorization", "Bearer " + accessToken);
            EnvelopesApi envelopesApi = new EnvelopesApi(apiClient);

            // Step 1. EnvelopeDocuments::get.
            // Exceptions will be caught by the calling function
            Stream results = envelopesApi.GetDocument(accountId, envelopeId, documentId);

            bool hasPDFsuffix = docName.ToUpper().EndsWith(".PDF");
            bool pdfFile = hasPDFsuffix;
            // Add .pdf if it's a content or summary doc and doesn't already end in .pdf
            if (!hasPDFsuffix)
            {
                docName += ".pdf";
                pdfFile = true;
            }

            string mimetype;
            if (pdfFile)
            {
                mimetype = "application/pdf";
            }

            else
            {
                mimetype = "application/octet-stream";
            }

            return (results, mimetype, docName);
        }


        // salvo lo stream in un file sul server
#pragma warning disable IDE0060 // Remove unused parameter
        private void SaveStreamAsFile(Stream inputStream, string filePath, string sfileName)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            /*DirectoryInfo info = new DirectoryInfo(filePath);
            if (!info.Exists)
            {
                info.Create();
            }*/

            //string path = Path.Combine(filePath, fileName);
            string filepath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
            string path = Path.Combine(filepath, sfileName);
            FileStream outputFileStream;
            using (outputFileStream = new FileStream(path, FileMode.Create))
            {
                inputStream.CopyTo(outputFileStream);

                string containerName = "ordini";
                string blobName = sfileName;
                string fileName = sfileName;
                string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/ordini/";
                string sas;

                //if (HttpContext.Current.Request.Url.ToString().Contains("d4m"))
                //{
                    sas = "https://ititsazuprdeuw385sto02.blob.core.windows.net/?sv=2020-08-04&ss=bf&srt=sco&sp=rwdlacitfx&se=2025-05-19T22:01:16Z&st=2022-05-19T14:01:16Z&spr=https&sig=AHeB3LosYh8EOvRKAmKOq0%2FZpwTMIUL37j1MO0Jywg4%3D"; //recupero url azure blob                                
                /*}
                else
                {
                    sas = "https://itconazuprdeun558sto02.blob.core.windows.net/?sv=2022-11-02&ss=bfqt&srt=sco&sp=rwdlacupiytfx&se=2026-05-23T17:55:05Z&st=2023-05-23T09:55:05Z&spr=https&sig=DeGa5iHPc2YQZQuTMeI59JLliwxjv4kOqzwJGR5E5Mc%3D"; //recupero url azure blob
                }*/

                AzureBlobManager azureBlobManager = new AzureBlobManager(sas, fileSourcePath, fileTargetPath, containerName);
                string resultBlob = azureBlobManager.UploadBlob(fileName, blobName, true);

                HttpContext.Current.Response.Write(resultBlob);

            }
        }

    }

}
