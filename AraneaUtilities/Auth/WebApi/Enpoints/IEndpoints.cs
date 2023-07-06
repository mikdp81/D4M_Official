using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AraneaUtilities.Auth.WebApi.Enpoints
{
    /// <summary>
    /// Interfaccia per la gestione degli endpoint di autorizzazione delle API.
    /// </summary>
    public interface IEndpoints
    {
        /// <summary>
        /// Ruolo di default per tutti gli endpoints: se l'endpoint non è presente nella mappa, 
        /// di default si intende che abbia questo ruolo.
        /// </summary>
        string DefaultRole { get; set; }

        /// <summary>
        /// Estrae la lista dei ruoli abilitati ad accedere all'endpoint specificato.
        /// </summary>
        /// <param name="endpoint">L'endpoint da verificare.</param>
        /// <returns>La lista dei ruoli abilitati.</returns>
        List<string> GetRoles(string endpoint);

        /// <summary>
        /// Mappa contenente tutti gli endpoint e i ruoli abilitati ad accedervi.
        /// </summary>
        Dictionary<string, List<string>> EndpointsMap { get; set; }

        /// <summary>
        /// Ottiene tutti i ruoli distinti presenti nell'EndpointsMap, incluso il DefaultRole se non è già presente.
        /// </summary>
        /// <returns>Una lista di stringhe contenente tutti i ruoli distinti.</returns>
        List<string> GetAllRoles();
    }
}
