using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace DFleetRest.App_Start
{


    /// <summary>
    /// Filtro per ordinare in modo alfabetico le operazioni API nel documento Swagger.
    /// </summary>
    public class SortApiOperationsAlphabeticallyFilter : IDocumentFilter
    {
        /// <summary>
        /// Applica il filtro per ordinare le operazioni API in ordine alfabetico nel documento Swagger.
        /// </summary>
        /// <param name="swaggerDoc">Il documento Swagger da filtrare.</param>
        /// <param name="schemaRegistry">Il registro degli schemi Swagger.</param>
        /// <param name="apiExplorer">L'oggetto IApiExplorer per esplorare le API.</param>
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, System.Web.Http.Description.IApiExplorer apiExplorer)
        {
            // Ordina le chiavi dei percorsi in ordine alfabetico
            var paths = swaggerDoc.paths.OrderBy(e => e.Key).ToList();

            // Ricostruisce il dizionario dei percorsi con le chiavi ordinate
            swaggerDoc.paths = paths.ToDictionary(e => e.Key, e => e.Value);
        }
    }


}