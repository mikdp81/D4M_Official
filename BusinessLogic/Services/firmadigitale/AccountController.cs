using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocuSign.eSign.Client;
using static DocuSign.eSign.Client.Auth.OAuth;
using static DocuSign.eSign.Client.Auth.OAuth.UserInfo;

namespace FirmaDigitale
{
    internal class AccountController
    {
        private OAuthToken _authToken;
        internal UserConfig UserConfig { get; private set; }

        public AccountController(UserConfig userConfig)
        {
            UserConfig = userConfig;
        }

        protected static ApiClient ApiClient { get; private set; }
        private static Account Account { get; set; }
        internal User User { get; private set; }

        internal string Login(string returnUrl = "/")
        {

            try
            {
                this.UpdateUserFromJWT();
            }
            catch (ApiException apiExp)
            {
                    Console.WriteLine(apiExp.Message);
            }

                // no sense
            return returnUrl;
        }

        private void UpdateUserFromJWT()
        {
            ApiClient = new ApiClient("https://demo.docusign.net/restapi");

            var scopes = new List<string>
                {
                    "signature",
                    "impersonation",
                };

            // RICHIEDE IL TOKEN
            /*this._authToken = _apiClient.RequestJWTUserToken(
                 UserConfig.ClientId,
                 UserConfig.ImpersonatedUserId,
                 UserConfig.AuthServer,
                 DSHelper.ReadFileContent(DSHelper.PrepareFullPrivateKeyFilePath(UserConfig.PrivateKey)),
                 1,
                 scopes);*/


            this._authToken = ApiClient.RequestJWTUserToken(
                 UserConfig.ClientId,
                 UserConfig.ImpersonatedUserId,
                 UserConfig.AuthServer,
                 Encoding.ASCII.GetBytes(UserConfig.PrivateKey),
                 1,
                 scopes);

            Account = GetAccountInfo(_authToken);

             this.User = new User
             {
                 Name = Account.AccountName,
                 AccessToken = _authToken.access_token,
                 ExpireIn = DateTime.Now.AddSeconds(_authToken.expires_in.Value),
                 AccountId = Account.AccountId

             };

           
        }


        private Account GetAccountInfo(OAuthToken authToken)
        {
            ApiClient.SetOAuthBasePath(UserConfig.AuthServer);
            UserInfo userInfo = ApiClient.GetUserInfo(authToken.access_token);
            Account acct = userInfo.Accounts.FirstOrDefault();
            if (acct == null)
            {
                throw new Exception("The user does not have access to account");
            }

            return acct;
        }
    }
    
}
