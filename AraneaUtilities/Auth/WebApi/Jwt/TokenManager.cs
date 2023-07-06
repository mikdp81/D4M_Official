using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace AraneaUtilities.Auth.WebApi.Jwt
{
    /// <summary>
    /// Classe che rappresenta il manager che valida il token.
    /// </summary>
    /// <typeparam name="TPayload">Il tipo di payload del token.</typeparam>
    public class TokenManager<TPayload> : ITokenManager<TPayload> where TPayload : ITokenPayload
    {
        private TokenSettings _tokenSettings; // Impostazioni del JWT
        private static TokenManager<TPayload> _tokenManager;

        /// <summary>
        /// Costruttore privato per la classe TokenManager.
        /// </summary>
        /// <param name="tokenSettings">Le impostazioni del token.</param>
        private TokenManager(TokenSettings tokenSettings)
        {
            if(tokenSettings != null)
                _tokenSettings = tokenSettings;
            else 
                throw new Exception("l'istanza di TokenSettings è null.");
        }


        /// <summary>
        /// Ottiene l'istanza condivisa del TokenManager.
        /// </summary>
        /// <param name="tokenSettings">Le impostazioni del token.</param>
        /// <returns>Un'istanza del TokenManager.</returns>
        public static TokenManager<TPayload> GetInstance(TokenSettings tokenSettings)
        {
            if (_tokenManager == null)
                _tokenManager = new TokenManager<TPayload>(tokenSettings);
            else
                _tokenManager._tokenSettings = tokenSettings;

            return _tokenManager;
        }

        /// <summary>
        /// Ottiene l'istanza condivisa del TokenManager.
        /// </summary>
        /// <param name="tokenSettingsJson">La stringa JSON delle impostazioni del token.</param>
        /// <returns>Un'istanza del TokenManager.</returns>
        public static TokenManager<TPayload> GetInstance(string tokenSettingsJson)
        {

            return GetInstance(TokenSettings.GetInstance(tokenSettingsJson));
        }

        /// <inheritdoc />
        public string GenerateToken(TPayload payload)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            ClaimsIdentity claimsIdentity = payload.GetClaimsIdentity();
            SecurityTokenDescriptor securityTokenDescriptor = _tokenSettings.TokenDescriptor(claimsIdentity);
            var token = tokenHandler.CreateToken(securityTokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <inheritdoc />
        public TPayload ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            TokenValidationParameters validationParameters = _tokenSettings.ValidationParameters();

            try
            {
                SecurityToken validatedToken;
                ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                ClaimsIdentity mainIdentity = claimsPrincipal.Identities.FirstOrDefault();

                if (!mainIdentity.IsAuthenticated)
                    throw new Exception("Identity non autenticata");

                TPayload payload = (TPayload)Activator.CreateInstance(typeof(TPayload), mainIdentity);
                return payload;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la validazione del token.", ex);
            }
        }
    }
}
