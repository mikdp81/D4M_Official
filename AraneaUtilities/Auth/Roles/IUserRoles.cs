using System.Collections.Generic;

/// <summary>
/// Interfaccia che definisce i ruoli validi.
/// </summary>
namespace AraneaUtilities.Auth.Roles
{
    /// <summary>
    /// Interfaccia per i ruoli validi.
    /// </summary>
    public interface IUserRoles
    {
        /// <summary>
        /// Ruolo di default per gli utenti: se ruolo non specificato => ruolo = DefaultRole
        /// </summary>
        string Default { get; set; }

        /// <summary>
        /// Ruolo di utente Admin
        /// </summary>
        string Admin { get; }

        /// <summary>
        /// Ruolo di utente anonimo
        /// </summary>
        string Anonymous { get; }


        /// <summary>
        /// Verifica se un ruolo è valido.
        /// </summary>
        /// <param name="role">Il ruolo da verificare.</param>
        /// <returns>True se il ruolo è valido, altrimenti False.</returns>
        bool IsValid(string role);

        /// <summary>
        /// Verifica se un ruolo è di amministratore.
        /// </summary>
        /// <param name="role">Il ruolo da verificare.</param>
        /// <returns>True se il ruolo è di amministratore, altrimenti False.</returns>
        bool IsAdmin(string role);

        /// <summary>
        /// Verifica se un ruolo anonimo
        /// </summary>
        /// <param name="role">Il ruolo da verificare.</param>
        /// <returns>True se il ruolo è anonimo, altrimenti False.</returns>
        bool IsAnonymous(string role);

        /// <summary>
        /// Verifica se un ruolo è di default.
        /// </summary>
        /// <param name="role">Il ruolo da verificare.</param>
        /// <returns>True se il ruolo è di default, altrimenti False.</returns>
        bool IsDefault(string role);

        /// <summary>
        /// restituisce il ruolo corrispondente alla chiave indicata
        /// </summary>
        /// <param name="roleKey"> valore chiave per recuperare il ruolo</param>
        /// <returns></returns>
        string GetRole(string roleKey);


        /// <summary>
        /// Restituisce un array contenente tutti i valori dei ruoli disponibili.
        /// </summary>
        /// <returns>Array di stringhe contenente i valori dei ruoli disponibili.</returns>
        string[] GetValues();
    }
}
