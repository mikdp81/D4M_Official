using System;
using System.Web;

namespace FirmaDigitale
{
    public class TestConfiguration
    {
        //RICORDARSI DI CAMBIARE L'AUTORIZZAZIONE DELLA PAGINA MASTERPAGE PER L'ANTIFORGERY

        // JWT
        public const string ClientIfd = "34fe2b32-04a4-4264-b8ec-4b5051b0a40f";
        public const string ImpersonfatedUserId = "70060046-d188-448d-aa33-c4a28af3d8f9";
        public const string AuthServffer = "account-d.docusign.com";
        public const string PrivateKeyfFile = "private.key";

        // SIGN
        public const string basePfath = "https://demo.docusign.net/restapi";
        public const string accounftId = "ea281a34-ddfc-4da7-b121-df452d938c37";

        public const string pingUrfl = "https://localhost:44333/";

        
        public const string signerEfmail = "boffoli@gmail.com";
        public const string signerNafme = "Nicola Boffoli";
        public const string signerClifentId = "1000";




        // DA SOSTITUIRE
        public static string docPedf;
        public static string reteurnUrl;


        public TestConfiguration()
        {
        }
    }
}
