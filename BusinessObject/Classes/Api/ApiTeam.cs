using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    /// <summary>
    /// Rappresenta una classe che implementa l'interfaccia IApiTeam.
    /// </summary>
    public class ApiTeam : IApiTeam
    {
        /// <inheritdoc/>
        public Guid Uid { get; set; }

        /// <inheritdoc/>
        public int Iduser { get; set; }

        /// <inheritdoc/>
        public Guid UserId { get; set; }

        /// <inheritdoc/>
        public string Cognome { get; set; }

        /// <inheritdoc/>
        public string Nome { get; set; }

        /// <inheritdoc/>
        public string Matricola { get; set; }

        /// <inheritdoc/>
        public string Email { get; set; }

        /// <inheritdoc/>
        public string Gradecode { get; set; }

        /// <inheritdoc/>
        public string Siglasocieta { get; set; }

        /// <inheritdoc/>
        public string Societa { get; set; }

        /// <inheritdoc/>
        public string Grade { get; set; }

        /// <inheritdoc/>
        public int Idteam { get; set; }

        /// <inheritdoc/>
        public string Team { get; set; }

        /// <inheritdoc/>
        public string Stato { get; set; }

        /// <inheritdoc/>
        public int Idpagina { get; set; }

        /// <inheritdoc/>
        public string Gruppo { get; set; }

        /// <inheritdoc/>
        public string Codgruppopagina { get; set; }

        /// <inheritdoc/>
        public string Icona { get; set; }

        /// <inheritdoc/>
        public string Pagina { get; set; }

        /// <inheritdoc/>
        public string Linkpagina { get; set; }

        /// <inheritdoc/>
        public int Autorizzatore { get; set; }
    }
}
