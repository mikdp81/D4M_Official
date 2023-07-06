using System;
using System.Linq;
using System.Runtime.Caching;

namespace AraneaUtilities.Auth.WebApi.Blacklist
{
    /// <summary>
    /// Gestisce la cache degli account utente.
    /// </summary>
    public class BlacklistManager : IBlacklistManager
    {
        private ObjectCache _cache;

        private static IBlacklistManager _blacklistManager;

        /// <summary>
        /// Crea una nuova istanza di BlacklistManager.
        /// </summary>
        private BlacklistManager()
        {
            _cache = MemoryCache.Default;
        }

        /// <summary>
        /// Ottiene l'istanza condivisa del BlacklistManager.
        /// </summary>
        /// <returns>Un'istanza del BlacklistManager</returns>
        public static IBlacklistManager GetInstance()
        {
            if (_blacklistManager == null)
                _blacklistManager = new BlacklistManager();

            return _blacklistManager;
        }

        /// <summary>
        /// Verifica se l'account specificato è abilitato.
        /// </summary>
        /// <param name="username">Nome utente</param>
        /// <returns>True se l'account è abilitato, False altrimenti</returns>
        public bool IsEnabled(string username)
        {
            if (!_cache.Contains(username))
                EnableAccount(username);

            return (bool)_cache[username];
        }

        /// <summary>
        /// Abilita l'account specificato.
        /// </summary>
        /// <param name="username">Nome utente</param>
        public void EnableAccount(string username)
        {
            _cache.AddOrGetExisting(username, true, DateTimeOffset.MaxValue);
        }

        /// <summary>
        /// Disabilita l'account specificato.
        /// </summary>
        /// <param name="username">Nome utente</param>
        public void DisableAccount(string username)
        {
            _cache.AddOrGetExisting(username, false, DateTimeOffset.MaxValue);
        }

        /// <summary>
        /// Cancella tutti gli elementi presenti nella cache.
        /// </summary>
        public void Clear()
        {
            var cacheKeys = _cache.Select(kvp => kvp.Key).ToList();
            foreach (var key in cacheKeys)
            {
                _cache.Remove(key);
            }
        }
    }
}
