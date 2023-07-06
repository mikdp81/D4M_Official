namespace AraneaUtilities.InterceptingFilters
{
    /// <summary>
    /// Interfaccia per i filtri del proxy.
    /// </summary>
    public interface IProxyFilter
    {
        /// <summary>
        /// Esegue il filtro.
        /// </summary>
        /// <param name="parameters">Parametri opzionali passati al filtro.</param>
        /// <returns>True se il filtro è superato, False altrimenti.</returns>
        bool Execute(object parameters = null);
    }
}
