using AraneaUtilities.JsonUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AraneaUtilities.Auth.WebApi.Enpoints
{
    public class Endpoints : JsonEntity<Endpoints>, IEndpoints
    {
        /// <inheritdoc/>
        public string DefaultRole { get; set; }

        /// <inheritdoc/>
        public Dictionary<string, List<string>> EndpointsMap { get; set; }


        /// <summary>
        /// Crea un'istanza VUOTA della classe iniziandola con json.
        /// </summary>
        public Endpoints() : base()
        {
        }

        /// <summary>
        /// Crea un'istanza della classe iniziandola con json.
        /// </summary>
        public Endpoints(string json) : base(json)
        {
        }

        /// <inheritdoc/>
        public List<string> GetRoles(string endpoint)
        {
            List<string> roles = new List<string>();

            // Controlla se l'endpoint esiste nel dizionario o se esiste una chiave che ne sia il prefisso
            // e restituisce tale chiave
            string matchingEndpoint = this.EndpointsMap.Keys.FirstOrDefault(k => endpoint.StartsWith(k));

            // Se c'è un endpoint nella mappa e ha specificato alcuni ruoli:
            if (matchingEndpoint != null && this.EndpointsMap.Count > 0)
                roles = this.EndpointsMap[matchingEndpoint];
            // Altrimenti assegna solo il suo ruolo di default
            else
                roles.Add(this.DefaultRole);

            return roles;
        }

        /// <inheritdoc/>
        public List<string> GetAllRoles()
        {
            // Ottenere tutti i valori distinti della lista di stringhe
            List<string> distinctValues = EndpointsMap.Values.SelectMany(list => list).Distinct().ToList();

            // Aggiungi DefaultRole solo se non è già presente nella lista distinta
            if (!distinctValues.Contains(DefaultRole))
            {
                distinctValues.Add(DefaultRole);
            }

            return distinctValues;
        }

        protected override void Initialize()
        {
            // Niente da aggiungere
        }
    }
}
