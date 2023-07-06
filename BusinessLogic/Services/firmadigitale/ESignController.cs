using System;
using System.Collections.Generic;
using System.Web;
using BusinessLogic.Services.blob;
using BusinessObject;
using DocuSign.eSign;
using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Model;

namespace FirmaDigitale
{
    internal class ESignController
    {
        private readonly string returnUrl;
        private readonly string docPdf;
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0052 // Remove unread private members
        private object docPdf1;
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning restore IDE0044 // Add readonly modifier

        internal ESignController(string returnUrl, string docPdf)
        {
            this.returnUrl = returnUrl;
            this.docPdf = docPdf;
        }

        public ESignController(string returnUrl, object docPdf1)
        {
            this.returnUrl = returnUrl;
            this.docPdf1 = docPdf1;
        }

        /// <summary>
        /// Creates a new envelope, adds a single document and a signle recipient (signer) and generates a url that is used for embedded signing.
        /// </summary>
        /// <param name="signerEmail">Email address for the signer</param>
        /// <param name="signerName">Full name of the signer</param>
        /// <param name="signerClientId">A unique ID for the embedded signing session for this signer</param>
        /// <param name="accessToken">Access Token for API call (OAuth)</param>
        /// <param name="basePath">BasePath for API calls (URI)</param>
        /// <param name="accountId">The DocuSign Account ID (GUID or short version) for which the APIs call would be made</param>
        /// <param name="docPdf">String of bytes representing the document (pdf)</param>
        /// <param name="returnUrl">URL user will be redirected to after they sign</param>
        /// <param name="pingUrl">URL that DocuSign will be able to ping to incdicate signing session is active</param>
        /// <returns>The envelopeId (GUID) of the resulting Envelope and the URL for the embedded signing</returns>
        internal (string, string) SendEnvelopeForEmbeddedSigning(User user, UserConfig userConfig)
        {
            // Step 1. Create the envelope definition
            EnvelopeDefinition envelope = MakeEnvelope(userConfig.SignerEmail, userConfig.SignerName, userConfig.SignerClientId, docPdf);

            // Step 2. Call DocuSign to create the envelope                   
            var apiClient = new ApiClient(userConfig.BasePath);
            apiClient.Configuration.DefaultHeader.Add("Authorization", "Bearer " + user.AccessToken);
            EnvelopesApi envelopesApi = new EnvelopesApi(apiClient);

            EnvelopeSummary results = envelopesApi.CreateEnvelope(userConfig.AccountId, envelope);
            string envelopeId = results.EnvelopeId;

            // Step 3. create the recipient view, the Signing Ceremony
            RecipientViewRequest viewRequest = MakeRecipientViewRequest(userConfig.SignerEmail, userConfig.SignerName, returnUrl, userConfig.SignerClientId, userConfig.PingUrl);
            // call the CreateRecipientView API
            ViewUrl results1 = envelopesApi.CreateRecipientView(userConfig.AccountId, envelopeId, viewRequest);

            // Step 4. Redirect the user to the Signing Ceremony
            // Don't use an iFrame!
            // State can be stored/recovered using the framework's session or a
            // query parameter on the returnUrl (see the makeRecipientViewRequest method)
            string redirectUrl = results1.Url;
            // returning both the envelopeId as well as the url to be used for embedded signing

            return (envelopeId, redirectUrl);
        }

        private RecipientViewRequest MakeRecipientViewRequest(string signerEmail, string signerName, string returnUrl, string signerClientId, string pingUrl = null)
        {
            // Data for this method
            // signerEmail 
            // signerName
            // dsPingUrl -- class global
            // signerClientId -- class global
            // dsReturnUrl -- class global


            RecipientViewRequest viewRequest = new RecipientViewRequest
            {
                // Set the url where you want the recipient to go once they are done signing
                // should typically be a callback route somewhere in your app.
                // The query parameter is included as an example of how
                // to save/recover state information during the redirect to
                // the DocuSign signing ceremony. It's usually better to use
                // the session mechanism of your web framework. Query parameters
                // can be changed/spoofed very easily.
                ReturnUrl = returnUrl + "?state=123",

                // How has your app authenticated the user? In addition to your app's
                // authentication, you can include authenticate steps from DocuSign.
                // Eg, SMS authentication
                AuthenticationMethod = "none",

                // Recipient information must match embedded recipient info
                // we used to create the envelope.
                Email = signerEmail,
                UserName = signerName,
                ClientUserId = signerClientId
            };

            // DocuSign recommends that you redirect to DocuSign for the
            // Signing Ceremony. There are multiple ways to save state.
            // To maintain your application's session, use the pingUrl
            // parameter. It causes the DocuSign Signing Ceremony web page
            // (not the DocuSign server) to send pings via AJAX to your
            // app,
            // NOTE: The pings will only be sent if the pingUrl is an https address
            if (pingUrl != null)
            {
                viewRequest.PingFrequency = "600"; // seconds
                viewRequest.PingUrl = pingUrl; // optional setting
            }

            return viewRequest;
        }

        private EnvelopeDefinition MakeEnvelope(string signerEmail, string signerName, string signerClientId, string docPdf)
        {
            // Data for this method
            // signerEmail 
            // signerName
            // signerClientId -- class global
            // Config.docPdf

            string containerName = "ordini";
            string blobName = docPdf;
            string fileName = docPdf;
            string fileSourcePath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
            string fileTargetPath = RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/";
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
            string result = azureBlobManager.DownloadBlob(fileName, blobName, true);

            HttpContext.Current.Response.Write(result);

            byte[] buffer = System.IO.File.ReadAllBytes(RequestExtensions.GetPathPhisicalApplication() + "/Repository/temp/" + docPdf);

            EnvelopeDefinition envelopeDefinition = new EnvelopeDefinition
            {
                EmailSubject = "Please sign this document"
            };
            Document doc1 = new Document();

            String doc1b64 = Convert.ToBase64String(buffer);

            doc1.DocumentBase64 = doc1b64;
            doc1.Name = docPdf; // can be different from actual file name
            doc1.FileExtension = "pdf";
            doc1.DocumentId = "3";

            // The order in the docs array determines the order in the envelope
            envelopeDefinition.Documents = new List<Document> { doc1 };

            // Create a signer recipient to sign the document, identified by name and email
            // We set the clientUserId to enable embedded signing for the recipient
            // We're setting the parameters via the object creation

            //aggiunto - 20042023
            RecipientSignatureProvider recipientSignatureProvider = new RecipientSignatureProvider
            {
                SignatureProviderName = "ds_email"
            };
            //fine

            Signer signer1 = new Signer
            {
                Email = signerEmail,
                Name = signerName,
                ClientUserId = signerClientId,
                RecipientId = "1",
                DeliveryMethod = "email",  //aggiunto - 20042023
                RecipientSignatureProviders =  new List<RecipientSignatureProvider> { recipientSignatureProvider } //aggiunto - 20042023
            };

            // Create signHere fields (also known as tabs) on the documents,
            // We're using anchor (autoPlace) positioning
            //
            // The DocuSign platform seaches throughout your envelope's
            // documents for matching anchor strings.
            SignHere signHere1 = new SignHere
            {
                AnchorString = "/sn1/",
                AnchorUnits = "pixels",
                AnchorXOffset = "10",
                AnchorYOffset = "20"
            };
            // Tabs are set per recipient / signer
            Tabs signer1Tabs = new Tabs
            {
                SignHereTabs = new List<SignHere> { signHere1 }
            };
            signer1.Tabs = signer1Tabs;

            // Add the recipient to the envelope object
            Recipients recipients = new Recipients
            {
                Signers = new List<Signer> { signer1 }
                
            };
            envelopeDefinition.Recipients = recipients;

            // Request that the envelope be sent by setting |status| to "sent".
            // To request that the envelope be created as a draft, set to "created"
            envelopeDefinition.Status = "sent";

            //envelopeDefinition.SigningLocation = "InPerson";


            // Aggiungere l'opzione signature_provider all'envelope
            /*  envelopeDefinition.SigningLocation = "Online";
              envelopeDefinition.SigningProviderInfo = new SigningProviderInfo()
              {
                  SignatureProviderName = "ds_email",
                  SignatureProviderOptions = new SignatureProviderOptions()
                  {
                      apiVersion = "v2"
                  }
              };*/

            return envelopeDefinition;
        }
    }
}
