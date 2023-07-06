using AraneaUtilities.JsonUtilities;
using Newtonsoft.Json;
using System;

// <summary>
// Rappresenta l'interfaccia per un team di API.
// </summary>
namespace BusinessObject
{
    [JsonConverter(typeof(JsonBinder<Account, IApiTeam>))]
    public interface IApiTeam
    {
        //********************************************  parametri EF_user

        /// <summary>
        /// Ottiene o imposta l'ID univoco dell'utente.
        /// </summary>
        Guid Uid { get; set; }

        /// <summary>
        /// Ottiene o imposta l'ID dell'utente.
        /// </summary>
        int Iduser { get; set; }

        /// <summary>
        /// Ottiene o imposta l'ID dell'utente come GUID.
        /// </summary>
        Guid UserId { get; set; }

        /// <summary>
        /// Ottiene o imposta il cognome dell'utente.
        /// </summary>
        string Cognome { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome dell'utente.
        /// </summary>
        string Nome { get; set; }

        /// <summary>
        /// Ottiene o imposta la matricola dell'utente.
        /// </summary>
        string Matricola { get; set; }

        /// <summary>
        /// Ottiene o imposta l'email dell'utente.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Ottiene o imposta il codice del grado dell'utente.
        /// </summary>
        string Gradecode { get; set; }

        /// <summary>
        /// Ottiene o imposta la sigla della società dell'utente.
        /// </summary>
        string Siglasocieta { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome della società dell'utente.
        /// </summary>
        string Societa { get; set; }

        /// <summary>
        /// Ottiene o imposta il grado dell'utente.
        /// </summary>
        string Grade { get; set; }


        //********************************************  parametri EF_team e menu relativo

        /// <summary>
        /// Ottiene o imposta l'ID del team.
        /// </summary>
        int Idteam { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome del team.
        /// </summary>
        string Team { get; set; }

        /// <summary>
        /// Ottiene o imposta lo stato del team.
        /// </summary>
        string Stato { get; set; }

        /// <summary>
        /// Ottiene o imposta l'ID della pagina.
        /// </summary>
        int Idpagina { get; set; }

        /// <summary>
        /// Ottiene o imposta il gruppo del team.
        /// </summary>
        string Gruppo { get; set; }

        /// <summary>
        /// Ottiene o imposta il codice del gruppo di pagina.
        /// </summary>
        string Codgruppopagina { get; set; }

        /// <summary>
        /// Ottiene o imposta l'icona del team.
        /// </summary>
        string Icona { get; set; }

        /// <summary>
        /// Ottiene o imposta il nome della pagina.
        /// </summary>
        string Pagina { get; set; }

        /// <summary>
        /// Ottiene o imposta il link della pagina.
        /// </summary>
        string Linkpagina { get; set; }

        /// <summary>
        /// Ottiene o imposta l'autorizzatore del team.
        /// </summary>
        int Autorizzatore { get; set; }
    }
}
