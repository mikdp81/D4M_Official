namespace AraneaUtilities.InterceptingFilters
{
    /// <summary>
    /// Interfaccia per il generatore di proxy di intercettazione.
    /// </summary>
    /// <typeparam name="ITP">Tipo dell'interfaccia del proxy che intercetta l'esecuzione di un oggetto target.</typeparam>
    public interface IInterceptingProxyGenerator<ITP>
    {
        /// <summary>
        /// Genera un proxy che implementa l'interfaccia specificata e aggiunge i filtri specificati all'oggetto target.
        /// </summary>
        /// <returns>Proxy che implementa l'interfaccia specificata.</returns>
        ITP GenerateProxy();
    }
}
