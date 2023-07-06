using BusinessObject;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using D4M_Rest.AuthorizationAttributes.JWT;
using D4M_Rest.AuthorizationAttributes.UserStatus;
using D4M_Rest.AuthorizationAttributes.Endpoints;
using D4M_Rest.AuthorizationAttribute;
using AraneaUtilities.Auth.WebApi.Jwt;
using AraneaUtilities.Auth.WebApi.Blacklist;
using AraneaUtilities.Auth.WebApi.Enpoints;
using AraneaUtilities.Auth.WebApi;

namespace D4M_Rest.Authorization
{
    /// <summary>
    /// Classe che rappresenta l'handler che chi si occupa della autorizzazione della richiesta:
    ///     IF l'endpoint richiesto ha l'accesso Anonymous => richiesta già autorizzata
    ///     ELSE è necessario superare tutti questi passaggi:
    ///     1. verifica l'esistenza del JWT token nella richiesta
    ///     2. valida il JWT token
    ///     3. verifica che l'utente sia attivo
    ///     4. verifica che l'utente abbia il ruolo adeguato per invocare l'endpoint
    /// </summary>
    public class AuthorizationHandler : DelegatingHandler
    {
        private readonly ITokenManager _tokenManager;
        private readonly IBlacklistManager _blacklistManager;
        private readonly IEndpointsManager _endpointsManager;
       

        /// <summary>
        /// Crea una nuova istanza di JwtValidationHandler con il TokenManager e l'AuthorizationMap specificati.
        /// </summary>
        /// <param name="tokenManager">Il gestore dei token.</param>
        /// <param name="userStatusManager">memoria che contiene informazioni su account</param>
        /// <param name="endpointsAuthorization">La mappa di autorizzazione endpoints.</param>
        public AuthorizationHandler(ITokenManager tokenManager, IBlacklistManager userStatusManager,
                                                    IEndpointsManager endpointsAuthorization)
        {
            _tokenManager = tokenManager ?? throw new ArgumentNullException(nameof(tokenManager));
            _blacklistManager = userStatusManager ?? throw new ArgumentNullException(nameof(userStatusManager));
            _endpointsManager = endpointsAuthorization ?? throw new ArgumentNullException(nameof(endpointsAuthorization));
        }

        /// <inheritdoc />
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // recupero l'endpoint richiesto
            string endpoint = GetEndpointName(request);

            //
            // 0. se l'endpoint può avere accesso Anonymous salto tutta la parte di autorizzazione
            if (_endpointsManager.IsAuthorized(endpoint))
                // procedo con la gestione della richiesta
                return await base.SendAsync(request, cancellationToken);


            // 1. se è presente l'autorizzazione nell'header della richiesta => proseguo autorizzazione
            string token;
            if (request.Headers.Authorization == null || request.Headers.Authorization.Scheme != "Bearer")
            {
                // messaggio di errore
                return request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
                token = request.Headers.Authorization.Parameter;


            // 2. se validazione del JWT token ok => proseguo autorizzazione
            UserRoles userRoles;
            try
            {
                userRoles = _tokenManager.ValidateToken(token);
            }
            catch (Exception ex)
            {
                string errMsg = "l'utente non è riconosciuto";
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.Unauthorized, errMsg, new Exception(ex.Message));
            }


            // 3. se l'utente è abilitato => proseguo autorizzazione
            if (!_blacklistManager.IsEnabled(userRoles.Username))
            {
                string errMsg = "l'utente: " + userRoles.Username + "non è abilitato";
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.Forbidden, errMsg, new Exception(errMsg));
            }


            // 4. se l'utente ha il diritto ad accedere a quell'endpoint => proseguo autorizzazione
            if (!_endpointsManager.IsAuthorized(endpoint, userRoles.Roles))
            {
                string errMsg = "l'utente: " + userRoles.Username +
                                        " non ha i diritti per accedere all'endpoint:" + endpoint;
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.Forbidden, errMsg, new Exception(errMsg));
            }

            // se sono qui tutto è andato bene => procedo con la gestione della richiesta
            return await base.SendAsync(request, cancellationToken);
        }

        private static string GetEndpointName(HttpRequestMessage request)
        {
            string endpointPath = request.RequestUri.AbsolutePath;
            return endpointPath;
        }
    }
}

