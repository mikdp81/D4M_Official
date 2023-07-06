using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;
using System.Web.Http;
using BusinessObject;
using BusinessProvider;

namespace DFleetRest.Utility
{
    /// <summary>
    /// Classe di utilità per la creazione di risposte HTTP.
    /// </summary>
    public static class ResponseUtility
    {

        private readonly static IDFleetExceptionProvider _exceptionProvider = new ProviderFactory().ServizioDFleetException;

        /// <summary>
        /// Crea una risposta HTTP con lo stato specificato e un messaggio di errore personalizzato.
        /// inoltre, salva l'intera eccezione su DB
        /// </summary>
        /// <param name="statusCode">Lo stato HTTP della risposta.</param>
        /// <param name="errorResult">Il risultato di errore da includere nella risposta.</param>
        /// <param name="exception">L'eccezione associata all'errore (opzionale).</param>
        /// <returns>La risposta HTTP con lo stato e il messaggio di errore specificati.</returns>
        public static IHttpActionResult CreateErrorResponse(HttpStatusCode statusCode, IHttpActionResult errorResult, Exception exception = null)
        {
            // Logga l'eccezione o esegui altre operazioni necessarie
            if (exception != null)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
            }

            // Crea una risposta personalizzata includendo il messaggio di errore
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(errorResult.ToString())
            };

            // Aggiungi eventuali dettagli dell'errore all'intestazione della risposta
            // salvo su DB
            if (exception != null)
            {
                response.Headers.Add("X-Error-Message", exception.Message);

                DFleetException dfleetException = new DFleetException(exception);
                _exceptionProvider.Insert(dfleetException);
            }

            return new ResponseMessageResult(response);
        }










    }
}