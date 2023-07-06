using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;

namespace AraneaUtilities.Auth.WebApi.Jwt
{
    /// <summary>
    /// Elenco base dei claims del token: un utente con i relativi ruoli.
    /// </summary>
    public class TokenPayload : ITokenPayload
    {
        /// <summary>
        /// Ottiene o imposta lo username dell'utente.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Ottiene o imposta un array contenente i ruoli a cui l'utente è abilitato.
        /// </summary>
        public string[] Roles { get; set; }

        /// <summary>
        /// Ottiene o imposta se l'utente è autenticato.
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// Costruttore predefinito della classe TokenPayload.
        /// </summary>
        public TokenPayload()
        {
        }

        /// <summary>
        /// Costruttore della classe TokenPayload che imposta i claims dell'identità.
        /// </summary>
        /// <param name="claimsIdentity">L'identità contenente i claims.</param>
        public TokenPayload(ClaimsIdentity claimsIdentity)
        {
            SetClaimsIdentity(claimsIdentity);
        }

        /// <inheritdoc />
        public ClaimsIdentity GetClaimsIdentity()
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, Username));

            if (Roles != null)
            {
                foreach (var role in Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            PropertyInfo[] properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                string propertyName = property.Name;

                if (propertyName == "Username" || propertyName == "Roles" || propertyName == "IsAuthenticated")
                {
                    continue;
                }

                var propertyValue = property.GetValue(this);

                if (propertyValue != null)
                {
                    claims.Add(new Claim(propertyName, propertyValue.ToString()));
                }
            }

            return new ClaimsIdentity(claims);
        }

        /// <inheritdoc />
        public void SetClaimsIdentity(ClaimsIdentity claimsIdentity)
        {
            PropertyInfo[] properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                string propertyName = property.Name;

                if (propertyName == "Username")
                {
                    var usernameClaim = claimsIdentity.FindFirst(ClaimTypes.Name);
                    if (usernameClaim != null)
                    {
                        Username = usernameClaim.Value;
                    }
                }
                else if (propertyName == "IsAuthenticated")
                {
                    IsAuthenticated = claimsIdentity.IsAuthenticated;
                }
                else if (propertyName == "Roles")
                {
                    Roles = claimsIdentity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value)
                        .ToArray();
                }
                else
                {
                    Claim matchingClaim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == propertyName);

                    if (matchingClaim != null)
                    {
                        string claimValue = matchingClaim.Value;
                        property.SetValue(this, Convert.ChangeType(claimValue, property.PropertyType));
                    }
                }
            }
        }
    }
}
