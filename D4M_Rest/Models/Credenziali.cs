namespace DFleetRest.Models
{
    /// <summary>
    /// Rappresenta le credenziali di un utente per l'autenticazione.
    /// </summary>
    public class Credenziali
    {
        /// <summary>
        /// Ottiene o imposta lo username dell'utente.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Ottiene o imposta la password dell'utente.
        /// </summary>
        public string Password { get; set; }
    }

}