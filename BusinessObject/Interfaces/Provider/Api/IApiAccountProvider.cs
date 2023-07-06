using System;
using System.Collections.Generic;

namespace BusinessObject
{
    /// <summary>
    /// Interfaccia per la fornitura dei dati relativi agli account API.
    /// </summary>
    public interface IApiAccountProvider
    {
        /// <summary>
        /// Seleziona gli utenti corrispondenti ai criteri di ricerca specificati.
        /// </summary>
        /// <param name="Uidtenant">UID del tenant.</param>
        /// <param name="codsocieta">Codice della società.</param>
        /// <param name="keysearch">Parola chiave di ricerca.</param>
        /// <param name="idstatususer">ID dello stato dell'utente.</param>
        /// <param name="idgruppouser">ID del gruppo dell'utente.</param>
        /// <param name="pagina">Numero della pagina.</param>
        /// <returns>Lista di account API corrispondenti ai criteri di ricerca.</returns>
        List<IApiAccount> SelectUser(Guid Uidtenant, string codsocieta, string keysearch, int idstatususer, int idgruppouser, int pagina);

        /// <summary>
        /// Ottiene i dettagli dell'utente corrispondente all'indirizzo email specificato.
        /// </summary>
        /// <param name="emailuser">Indirizzo email dell'utente.</param>
        /// <param name="emailuser">la password dell'utente.</param>
        /// <returns>Account API corrispondente all'utente specificato.</returns>
        IApiAccount UserDetail(string emailuser);

        /// <summary>
        /// Aggiorna l'utente specificato.
        /// </summary>
        /// <param name="value">Account API da aggiornare.</param>
        /// <returns>Numero di righe interessate.</returns>
        int UpdateUser(IApiAccount value);

        /// <summary>
        /// Inserisce il nuovo utente specificato.
        /// </summary>
        /// <param name="value">Account API da inserire.</param>
        /// <returns>Numero di righe interessate.</returns>
        int InsertUser(IApiAccount value);

        /// <summary>
        /// Elimina l'utente specificato.
        /// </summary>
        /// <param name="value">Account API da eliminare.</param>
        /// <returns>Numero di righe interessate.</returns>
        int DeleteUser(IApiAccount value);

        /// <summary>
        /// Seleziona i team corrispondenti ai criteri di ricerca specificati.
        /// </summary>
        /// <param name="Uidtenant">UID del tenant.</param>
        /// <param name="keysearch">Parola chiave di ricerca.</param>
        /// <param name="pagina">Numero della pagina.</param>
        /// <returns>Lista di account API corrispondenti ai criteri di ricerca.</returns>
        List<IApiAccount> SelectTeam(Guid Uidtenant, string keysearch, int pagina);

        /// <summary>
        /// Ottiene i dettagli del team corrispondente all'ID specificato.
        /// </summary>
        /// <param name="idteam">ID del team.</param>
        /// <param name="idteam">Uidtenant del team.</param>
        /// <returns>Account API corrispondente al team specificato.</returns>
        IApiAccount TeamDetail(int idteam, Guid Uidtenant);

        /// <summary>
        /// Aggiorna il team specificato.
        /// </summary>
        /// <param name="value">Account API da aggiornare.</param>
        /// <returns>Numero di righe interessate.</returns>
        int UpdateTeam(IApiAccount value);

        /// <summary>
        /// Inserisce il nuovo team specificato.
        /// </summary>
        /// <param name="value">Account API da inserire.</param>
        /// <returns>Numero di righe interessate.</returns>
        int InsertTeam(IApiAccount value);

        /// <summary>
        /// Elimina il team specificato.
        /// </summary>
        /// <param name="value">Account API da eliminare.</param>
        /// <returns>Numero di righe interessate.</returns>
        int DeleteTeam(IApiAccount value);
    }
}
