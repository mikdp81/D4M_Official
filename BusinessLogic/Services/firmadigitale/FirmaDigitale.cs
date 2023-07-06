using System;
using System.Web;

namespace FirmaDigitale
{
    internal class FirmaDigitale: IFirmaDigitale
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private AccountController accountController;
#pragma warning restore IDE0044 // Add readonly modifier
        private DowloadController downloadController;
        private ESignController eSignController;
        private string envelopeId;
#pragma warning disable IDE0044 // Add readonly modifier
        private string returnUrl;
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning disable IDE0044 // Add readonly modifier
        private string docPdf;
#pragma warning restore IDE0044 // Add readonly modifier

        internal FirmaDigitale(UserConfig userConfig, string returnUrl, string docPdf)
        {
            this.returnUrl = returnUrl;
            this.docPdf = docPdf;
            //1. autenticazione su DocuSign al fine di produrre user+token
            accountController = new AccountController(userConfig);
            accountController.Login();
        }

        // invocare come primo metodo per inizializzare tutti gli oggetti
        public void Avvio()
        {

            //2. invocazione su DocuSign per produrre documento + firma: return url da visualizzare
            eSignController = new ESignController(returnUrl, docPdf);
            var result =eSignController.SendEnvelopeForEmbeddedSigning(accountController.User, accountController.UserConfig);

            //2a. dispatch dell'url generato
            // Save for future use within the example launcher
            envelopeId = result.Item1;
            //2b. Redirect the user to the Signing Ceremony
            var uri = result.Item2;

            // PARTE WEB
            /*var psi = new System.Diagnostics.ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = uri
            };
            System.Diagnostics.Process.Start(psi);*/

            //HttpContext.Current.Response.Redirect(uri);

            HttpContext.Current.Response.Write("<script>");
            HttpContext.Current.Response.Write("window.open('" + uri + "','_firma')");
            HttpContext.Current.Response.Write("</script>");



        }

        // PRECONDIZIONE: invocare Avvio()
        public void DownloadFile()
        {
            //recupero lo stream del documento e salvataggio file
            downloadController = new DowloadController();
            downloadController.DownloadFile(accountController.User, envelopeId, accountController.UserConfig);

        }

        public string NomeFileFirmato()
        {
            return this.downloadController.filefirma;
        }
    }
}
