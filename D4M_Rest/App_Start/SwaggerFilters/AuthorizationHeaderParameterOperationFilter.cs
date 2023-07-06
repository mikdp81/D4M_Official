using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace DFleetRest.App_Start
{
    /// <summary>
    /// Classe per recuperare il token jwt da UI Swagger
    /// </summary>
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {

        /// <summary>
        /// Metodo che  recupera il token jwt da UI Swagger
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiDescription"></param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            // Aggiungi il parametro dell'header di autorizzazione solo per le operazioni che richiedono autenticazione
            if (apiDescription.ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>().Any())
            {
                // Aggiungi il parametro dell'header di autorizzazione
                if (operation.parameters == null)
                    operation.parameters = new List<Parameter>();

                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    description = "JWT token",
                    required = true,
                    type = "string"
                });
            }
        }
    }
}