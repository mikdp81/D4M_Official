namespace AraneaUtilities.Auth.WebApi.Enpoints
{
    /// <summary>
    /// Interfaccia che rappresenta la mappa di autorizzazione delle API.
    /// </summary>
    public interface IEndpointsManager
    {
        /// <summary>
        /// Verifica se un determinato ruolo utente è autorizzato ad accedere a uno specifico endpoint.
        /// AUTORIZZATO SE:
        ///     0. Il ruolo dell'utente è ADMIN.
        ///     1. L'endpoint contiene un ruolo ANONYMOUS
        ///     2. L'endpoint è trovato userRoles e ruoli endpoint non hanno un'intersezione vuota.
        /// </summary>
        /// <param name="endpoint">Il nome dell'endpoint da controllare.</param>
        /// <param name="userRoles">I ruoli dell'utente a cui è abilitato.</param>
        /// <returns>True se l'utente è autorizzato ad accedere all'endpoint, altrimenti False.</returns>
        bool IsAuthorized(string endpoint, string[] userRoles = null);
    }
}
