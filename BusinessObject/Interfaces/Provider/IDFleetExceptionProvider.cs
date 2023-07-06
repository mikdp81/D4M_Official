namespace BusinessObject
{
    /// <summary>
    /// Interfaccia per il provider delle eccezioni DFleet.
    /// </summary>
    public interface IDFleetExceptionProvider
    {
        /// <summary>
        /// Inserisce un'eccezione DFleet nel provider.
        /// </summary>
        /// <param name="value">L'eccezione DFleet da inserire.</param>
        /// <returns>Il numero di righe interessate dall'operazione di inserimento.</returns>
        int Insert(DFleetException value);
    }
}
