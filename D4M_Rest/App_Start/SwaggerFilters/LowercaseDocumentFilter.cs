using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace DFleetRest.App_Start

{
    /// <summary>
    /// Filtro Swagger per la conversione dei nomi dei path in minuscolo.
    /// </summary>
    public class LowercaseDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// Applica il filtro al documento Swagger.
        /// </summary>
        /// <param name="swaggerDoc">Documento Swagger.</param>
        /// <param name="schemaRegistry">Schema Registry.</param>
        /// <param name="apiExplorer">API Explorer.</param>
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            // Converte i nomi dei path in minuscolo
            var newPaths = new Dictionary<string, PathItem>();
            foreach (var path in swaggerDoc.paths)
            {
                var newKey = path.Key.ToLower();
                newPaths.Add(newKey, path.Value);
            }
            swaggerDoc.paths = newPaths;
        }
    }

}