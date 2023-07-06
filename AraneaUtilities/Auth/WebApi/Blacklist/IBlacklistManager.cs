namespace AraneaUtilities.Auth.WebApi.Blacklist
{
    /// <summary>
    /// Interfaccia per il servizio di cache degli account.
    /// </summary>
    public interface IBlacklistManager
    {
        /// <summary>
        /// Verifica se l'account con lo username specificato è abilitato.
        /// </summary>
        /// <param name="username">Lo username dell'account da verificare.</param>
        /// <returns>True se l'account è abilitato, false altrimenti.</returns>
        bool IsEnabled(string username);

        /// <summary>
        /// Abilita l'account con lo username specificato.
        /// </summary>
        /// <param name="username">Lo username dell'account da abilitare.</param>
        void EnableAccount(string username);

        /// <summary>
        /// Disabilita l'account con lo username specificato.
        /// </summary>
        /// <param name="username">Lo username dell'account da disabilitare.</param>
        void DisableAccount(string username);

        /// <summary>
        /// Resetta il contenuto della cache.
        /// </summary>
        void Clear();
    }
}
