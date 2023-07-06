using AraneaUtilities.JsonUtilities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;

namespace AraneaUtilities.Auth.WebApi.Jwt
{
    /// <summary>
    /// Rappresenta le impostazioni per JSON Web Token (JWT).
    /// </summary>
    public class TokenSettings : JsonEntity<TokenSettings>
    {

        /// <summary>
        /// Crea un'istanza VUOTA della classe.
        /// </summary>
        public TokenSettings() : base() { }


        /// <summary>
        /// Crea un'istanza della classe iniziandola con json.
        /// </summary>
        public TokenSettings(string json): base(json)
        {
        }

        /* PARTE GENERAZIONE TOKEN */

        /// <summary>
        /// Ottiene o imposta la chiave utilizzata per la firma del token JWT.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Ottiene o imposta l'algoritmo di sicurezza per la chiave del token JWT.
        /// </summary>
        public string SecurityAlgorithm { get; set; }

        /// <summary>
        /// Ottiene o imposta l'emittente del token JWT.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Ottiene o imposta l'audience (destinatario) del token JWT.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Ottiene o imposta la durata di validità del token JWT.
        /// </summary>
        public long ExpirationSeconds { get; set; }

        /* FINE PARTE GENERAZIONE TOKEN */

        /* PARTE VALIDAZIONE TOKEN */

        /// <summary>
        /// Ottiene o imposta se validare la chiave del token JWT.
        /// </summary>
        public bool KeyValidation { get; set; }

        /// <summary>
        /// Ottiene o imposta se validare l'emittente del token JWT.
        /// </summary>
        public bool IssuerValidation { get; set; }

        /// <summary>
        /// Ottiene o imposta se validare l'audience del token JWT.
        /// </summary>
        public bool AudienceValidation { get; set; }

        /// <summary>
        /// Ottiene o imposta lo scarto massimo tra l'orario del token e quello attuale.
        /// </summary>
        public TimeSpan ClockSkew { get; set; }

        /* FINE PARTE VALIDAZIONE TOKEN */

        /// <summary>
        /// Valore chiave per riferirsi al claim dello user.
        /// </summary>
        public string UserKey { get; set; }

        /// <summary>
        /// Valore chiave per riferirsi ai claim dei role.
        /// </summary>
        public string RoleKey { get; set; }

        /// <summary>
        /// Genera i parametri per la validazione del token.
        /// </summary>
        /// <returns>I parametri per la validazione del token.</returns>
        internal TokenValidationParameters ValidationParameters()
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = AudienceValidation, // Imposta la validazione della chiave di firma
                IssuerSigningKey = SecurityKey(), // Imposta la chiave di firma da usare per la validazione
                ValidateIssuer = IssuerValidation, // Imposta la validazione dell'emittente
                ValidIssuer = Issuer, // Imposta l'emittente valido
                ValidateAudience = AudienceValidation, // Imposta la validazione dell'audience
                ValidAudience = Audience, // Imposta l'audience valido
                ClockSkew = ClockSkew // Imposta lo scarto massimo tra l'orario del token e quello attuale
            };

            return validationParameters;
        }

        /// <summary>
        /// Genera il descrittore del token.
        /// </summary>
        /// <param name="claimsIdentity">L'identità contenente i claims del token.</param>
        /// <returns>Il descrittore del token.</returns>
        internal SecurityTokenDescriptor TokenDescriptor(ClaimsIdentity claimsIdentity)
        {
            return new SecurityTokenDescriptor
            {
                Issuer = Issuer, // Imposta l'emittente del token
                Audience = Audience, // Imposta il destinatario del token
                Subject = claimsIdentity, // Imposta i claims del token
                Expires = DateTime.UtcNow.AddSeconds(ExpirationSeconds), // Imposta la scadenza del token
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithm) // Imposta la firma del token
            };
        }

        private SecurityKey SecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        }

        protected override void Initialize()
        {
            // Assegna l'algoritmo di sicurezza a TokenSettings
            this.SecurityAlgorithm = SecurityAlgorithms.HmacSha256Signature;

            // Imposta lo scarto massimo tra l'orario del token e quello attuale
            this.ClockSkew = TimeSpan.Zero;
        }
    }
}
