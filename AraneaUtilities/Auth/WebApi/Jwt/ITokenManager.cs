namespace AraneaUtilities.Auth.WebApi.Jwt
{
    /// <summary>
    /// Interfaccia per la gestione dei token di autenticazione.
    /// </summary>
    /// <typeparam name="TPayload">Il tipo di payload del token.</typeparam>
    public interface ITokenManager<TPayload> where TPayload : ITokenPayload
    {
        /// <summary>
        /// Genera un token di autenticazione per il payload specificato.
        /// </summary>
        /// <param name="payload">Il payload del token.</param>
        /// <returns>Il token di autenticazione generato.</returns>
        string GenerateToken(TPayload payload);

        /// <summary>
        /// Valida un token di autenticazione.
        /// </summary>
        /// <param name="token">Il token di autenticazione da validare.</param>
        /// <returns>Il payload del token validato.</returns>
        TPayload ValidateToken(string token);
    }
}
