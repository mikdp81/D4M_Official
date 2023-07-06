using AraneaUtilities.Auth.WebApi.Jwt;
using System;
using System.Security.Claims;

namespace BusinessObject
{
    /// <summary>
    /// Rappresenta una classe che rappresenta i dati del payload di un token DFleet.
    /// </summary>
    public class DFleetTokenPayload : TokenPayload, ITokenPayload
    {
        /// <summary>
        /// Ottiene o imposta l'id del tenant.
        /// </summary>
        public string UidTenant { get; set; }

        /// <summary>
        /// Crea una nuova istanza di DFleetTokenPayload.
        /// </summary>
        public DFleetTokenPayload() : base()
        { }

        /// <summary>
        /// Crea una nuova istanza di DFleetTokenPayload con le informazioni fornite da un oggetto ClaimsIdentity.
        /// </summary>
        /// <param name="claimsIdentity">L'oggetto ClaimsIdentity con le informazioni del token.</param>
        public DFleetTokenPayload(ClaimsIdentity claimsIdentity) : base(claimsIdentity)
        {
        }
    }
}
