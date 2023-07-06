using System.Security.Claims;

namespace AraneaUtilities.Auth.WebApi.Jwt
{
    public interface ITokenPayload
    {
        /// <summary>
        /// Ottiene o imposta lo username dell'utente.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Ottiene o imposta se l'utente è autenticato.
        /// </summary>
        bool IsAuthenticated { get; set; }

        /// <summary>
        /// Ottiene o imposta un array contenente i ruoli a cui l'utente è abilitato.
        /// </summary>
        string[] Roles { get; set; }

        /// <summary>
        /// Ottiene l'identità degli Claims corrispondenti al payload.
        /// </summary>
        /// <returns>L'identità degli Claims corrispondenti al payload.</returns>
        ClaimsIdentity GetClaimsIdentity();

        /// <summary>
        /// Imposta l'identità degli Claims a partire da un oggetto ClaimsIdentity.
        /// </summary>
        /// <param name="claimsIdentity">L'oggetto ClaimsIdentity da cui ottenere gli Claims.</param>
        void SetClaimsIdentity(ClaimsIdentity claimsIdentity);
    }
}
