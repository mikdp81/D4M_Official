using AraneaUtilities.Auth.WebApi.Blacklist;
using AraneaUtilities.Auth.WebApi.Jwt;
using AraneaUtilities.JsonUtilities;
using BusinessObject;
using DFleetRest.AuthorizationAttributes;
using DFleetRest.Models;
using DFleetRest.Services;
using DFleetRest.Utility;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace DFleetRest.Controllers
{
    /// <summary>
    /// Controller per la gestione dell'autenticazione.
    /// </summary>
    /// 
    public class AccountController : ApiController
    {

        private const string API_VER = "v1";

        private readonly IBLService _accountService; // Servizio per la gestione degli account
        private readonly IBlacklistManager _blacklistManager; // Memoria condivisa per gli account abilitati/disabilitati
        private readonly ITokenManager<DFleetTokenPayload> _tokenManager; // Servizio per la gestione dei token JWT

        /// <summary>
        /// accede al payload del token validato dal jwt validator
        /// </summary>
        private DFleetTokenPayload ValidatedTokenPayload
        {
            get { return (DFleetTokenPayload)Request.Properties[DFleetGlobals.TokenPayloadKey]; }
        }


        /// <summary>
        /// Costruttore della classe AccountController.
        /// </summary>
        /// <param name="accountService">Servizio per la gestione degli account.</param>
        /// <param name="blacklistManager">Memoria condivisa per gli account abilitati/disabilitati.</param>
        /// <param name="tokenManager">Servizio per la gestione dei token JWT.</param>
        public AccountController(IBLService accountService,
            IBlacklistManager blacklistManager, ITokenManager<DFleetTokenPayload> tokenManager)
        {
            _accountService = accountService; // Assegna il servizio per la gestione degli account alla variabile privata corrispondente
            _blacklistManager = blacklistManager; // Assegna la memoria condivisa alla variabile privata corrispondente
            _tokenManager = tokenManager; // Assegna il servizio per la gestione dei token JWT alla variabile privata corrispondente
        }


        /// <summary>
        /// Estrae la logica comune di controllo nome utente in un metodo privato.
        /// </summary>
        /// <param name="nomeUtente">Il nome utente dell'utente.</param>
        /// <param name="action">L'azione da eseguire sull'account.</param>
        /// <returns>Una risposta HTTP OK se l'operazione è stata completata con successo, altrimenti una risposta HTTP BadRequest.</returns>
        private IHttpActionResult UpdateUserCache(string nomeUtente, Action<string> action)
        {
            if (string.IsNullOrEmpty(nomeUtente))
            {
                return BadRequest("Il nome utente non può essere vuoto.");
            }

            try
            {
                // Recupera l'utente in base al nome utente.
                var user = Membership.GetUser(nomeUtente);
                if (user == null)
                {
                    // Restituisce una risposta HTTP BadRequest se l'utente non esiste.
                    return NotFound();
                }

                // Esegue l'azione specificata sull'account.
                action(nomeUtente);

                // Restituisce una risposta HTTP OK per indicare che la cache è stata aggiornata con successo.
                return Ok();
            }
            catch (Exception ex)
            {
                // Gestione dell'eccezione.
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerError(), ex);
            }
        }


        /// <summary>
        /// Disabilita l'account dell'utente con il nome utente specificato.
        /// </summary>
        /// <param name="nomeUtente">Il nome utente dell'utente da disabilitare.</param>
        /// <returns>Una risposta HTTP OK se l'utente è stato disabilitato con successo, altrimenti una risposta HTTP BadRequest.</returns>
        [AuthorizeRest]
        [HttpPost]
        [Route("api/" + API_VER + "/admin/disabilitautente")]
        [SwaggerResponse(HttpStatusCode.OK, "Utente disabilitato con successo")]
        [SwaggerResponse(HttpStatusCode.NotFound, "L'utente specificato non esiste")]
        public IHttpActionResult DisabilitaUtente(string nomeUtente)
        {
            return UpdateUserCache(nomeUtente, _blacklistManager.DisableAccount);
        }


        /// <summary>
        /// Abilita un utente in base al nome utente.
        /// </summary>
        /// <param name="nomeUtente">Il nome utente dell'utente da abilitare.</param>
        /// <returns>Una risposta HTTP che indica se l'operazione è stata completata con successo o meno.</returns>
        [AuthorizeRest]
        [HttpPost]
        [Route("api/" + API_VER + "/admin/abilitautente")]
        [SwaggerResponse(HttpStatusCode.OK, "Utente abilitato con successo")]
        [SwaggerResponse(HttpStatusCode.NotFound, "L'utente specificato non esiste")]
        public IHttpActionResult AbilitaUtente(string nomeUtente)
        {
            return UpdateUserCache(nomeUtente, _blacklistManager.EnableAccount);
        }


        /// <summary>
        /// Svuota la cache che contiene gli utenti abilitati/disabilitati.
        /// </summary>
        /// <returns>Una risposta HTTP che indica se l'operazione è stata completata con successo o meno.</returns>
        //[AuthorizeRest]
        [HttpPost]
        [Route("api/" + API_VER + "/admin/svuotacacheutenti")]
        [SwaggerResponse(HttpStatusCode.OK, "Memoria cache degli account svuotata con successo")]
        public IHttpActionResult SvuotaCacheUtenti()
        {
            try
            {
                // Esegue l'azione specificata sull'account.
                _blacklistManager.Clear();

                // Restituisce una risposta HTTP OK per indicare che la cache è stata aggiornata con successo.
                return Ok();
            }
            catch (Exception ex)
            {
                // Gestione dell'eccezione.
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerError(), ex);
            }
        }


        /// <summary>
        /// Metodo REST per l'autenticazione di un utente.
        /// </summary>
        /// <param name="credenziali">Oggetto contenente le credenziali dell'utente.</param>
        /// <returns>Token JWT se l'autenticazione è andata a buon fine, altrimenti un messaggio di errore.</returns>
        [HttpPost]
        [Route("api/" + API_VER + "/login")]
        [SwaggerResponse(HttpStatusCode.OK, "Utente autenticato con successo", Type = typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Utente non trovato")]
        public IHttpActionResult Login([FromBody] Credenziali credenziali)
        {
            string[] roles = _accountService.Authenticate(credenziali.Username, credenziali.Password);
            if (roles != null)
            {
                DFleetTokenPayload payload = new DFleetTokenPayload();
                payload.Username = credenziali.Username;
                payload.Roles = roles;
                payload.UidTenant =  "";

                // generazione token momentaneo per acquisire l'accesso a UidTenant
                var token = _tokenManager.GenerateToken(payload);
                HttpContext.Current.Items[DFleetGlobals.TokenKey] = token;
                payload.UidTenant = _accountService.UserDetail(credenziali.Username).Uidtenant.ToString();

                // token definitivo
                token = _tokenManager.GenerateToken(payload);
                return Ok(new { token });
            }
            else
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Azione API per cancellare un user.
        /// Richiede autorizzazione REST.
        /// </summary>
        /// <param name="account">Oggetto IAccount contenente i dati dell'account.</param>
        /// <returns>Risposta HTTP con esito della cancellazione o errore.</returns>
        [AuthorizeRest]
        [HttpPost]
        [Route("api/" + API_VER + "/user/delete")]
        [SwaggerResponse(HttpStatusCode.OK, "Utente cancellato con successo")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Utente non trovato, impossibile cancellare l'utente")]
        public IHttpActionResult DeleteUser([FromBody] IApiAccount account)
        {
            try
            {
                if (_accountService.DeleteUser(account) == 1)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerError(), ex);
            }

        }


        /// <summary>
        /// Azione API per cancellare un team.
        /// Richiede autorizzazione REST.
        /// </summary>
        /// <param name="team">Oggetto IApiTeam contenente i dati dell'account.</param>
        /// <returns>Risposta HTTP con esito della cancellazione o errore.</returns>
        //[AuthorizeRest]
        [HttpPost]
        [Route("api/" + API_VER + "/team/delete")]
        [SwaggerResponse(HttpStatusCode.OK, "Team cancellato con successo")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Team non trovato, impossibile cancellare il team")]
        public IHttpActionResult DeleteTeam([FromBody] IApiTeam team)
        {
            try
            {
                if (_accountService.DeleteTeam((IApiAccount)team) == 1)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerError(), ex);
            }

        }


        /// <summary>
        /// Azione API per inserire un user.
        /// Richiede autorizzazione REST.
        /// </summary>
        /// <param name="account">Oggetto IAccount contenente i dati dell'account.</param>
        /// <returns>Risposta HTTP con esito della cancellazione o errore.</returns>
        //[AuthorizeRest]
        [HttpPost]
        [Route("api/" + API_VER + "/user/insert")]
        [SwaggerResponse(HttpStatusCode.OK, "Utente inserito con successo")]
        [SwaggerResponse(HttpStatusCode.Conflict, "Impossibile inserire l'utente")]
        public IHttpActionResult InsertUser([FromBody] IApiAccount account)
        {
            try
            {
                if (_accountService.InsertUser(account) == 1)
                    return Ok();
                else
                    return Conflict();
            }
            catch (Exception ex)
            {
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerError(), ex);
            }

        }



        /// <summary>
        /// Azione API per l'inserimento di un team.
        /// Richiede autorizzazione REST.
        /// </summary>
        /// <param name="team">Oggetto IApiTeam contenente i dati del team.</param>
        /// <returns>Risposta HTTP con esito dell'inserimento o errore.</returns>
        //[AuthorizeRest]
        [HttpPost]
        [Route("api/" + API_VER + "/team/insert")]
        [SwaggerResponse(HttpStatusCode.OK, "Team inserito con successo")]
        [SwaggerResponse(HttpStatusCode.Conflict, "Impossibile inserire il team")]
        public IHttpActionResult InsertTeam([FromBody] IApiTeam team)
        {
            try
            {
                if (_accountService.InsertTeam((IApiAccount)team) == 1)
                    return Ok();
                else
                    return Conflict();
            }
            catch (Exception ex)
            {
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerError(), ex);
            }

        }



        /// <summary>
        /// UpdateUser - Azione API per modificare un user.
        /// Richiede autorizzazione REST.
        /// </summary>
        /// <param name="account">Oggetto IAccount contenente i dati dell'account.</param>
        /// <returns>Risposta HTTP con esito della cancellazione o errore.</returns>
        //[AuthorizeRest]
        [HttpPost]
        [Route("api/" + API_VER + "/user/update")]
        [SwaggerResponse(HttpStatusCode.OK, "Utente aggiornato con successo")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Utente non trovato")]
        public IHttpActionResult UpdateUser([FromBody] IApiAccount account)
        {
            try
            {
                if (_accountService.UpdateUser(account) == 1)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerError(), ex);
            }

        }


        /// <summary>
        /// UpdateTeam - Azione API per modificare un team.
        /// Richiede autorizzazione REST.
        /// </summary>
        /// <param name="team">Oggetto IApiTeam contenente i dati dell'account.</param>
        /// <returns>Risposta HTTP con esito della cancellazione o errore.</returns>
        //[AuthorizeRest]
        [HttpPost]
        [Route("api/" + API_VER + "/team/update")]
        [SwaggerResponse(HttpStatusCode.OK, "Team aggiornato con successo")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Team non trovato")]

        public IHttpActionResult UpdateTeam([FromBody] IApiTeam team)
        {
            try
            {

                if (_accountService.UpdateTeam((IApiAccount)team) == 1)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerError(), ex);
            }

        }


        /// <summary>
        /// UserDetail - Metodo per selezionare un user.
        /// Richiesta GET.
        /// </summary>
        /// <param name="emailuser">L'email dell'user</param>
        /// <returns>Risposta HTTP con esito della lettura o errore.</returns>
        //[AuthorizeRest]
        [HttpGet]
        [Route("api/" + API_VER + "/user")]
        [SwaggerResponse(HttpStatusCode.OK, "Dati dell'utente trovati", typeof(IApiAccount))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Dati dell'utente non trovati")]
        public IHttpActionResult UserDetail(string emailuser)
        {
            try
            {
                IApiAccount result = _accountService.UserDetail(emailuser);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerError(), ex);
            }
        }


        /// <summary>
        /// TeamDetail - Metodo per selezionare un team.
        /// Richiesta GET.
        /// </summary>
        /// <param name="idteam">L'ID del team</param>
        /// <returns>Risposta HTTP con esito della lettura o errore.</returns>
        //[AuthorizeRest]
        [HttpGet]
        [Route("api/" + API_VER + "/team")]
        [SwaggerResponse(HttpStatusCode.OK, "Dati dell'utente trovati", typeof(IApiAccount))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Dati del team non trovati")]
        public IHttpActionResult TeamDetail(int idteam, Guid Uidtenant)
        {
            try
            {
                IApiTeam result = _accountService.TeamDetail(idteam, Uidtenant);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerError(), ex);
            }
        }



        /// <summary>
        /// SelectTeams - Metodo per selezionare i team.
        /// Richiesta GET.
        /// </summary>
        /// <param name="keysearch">La chiave di ricerca</param>
        /// <param name="pagina">Il numero di pagina</param>
        /// <returns>Risposta HTTP con esito della lettura o errore.</returns>
        [AuthorizeRest]
        [HttpGet]
        [Route("api/" + API_VER + "/team/list")]
        [SwaggerResponse(HttpStatusCode.OK, "Team trovati", typeof(List<IApiTeam>))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Team non trovati")]
        public IHttpActionResult SelectTeams(string keysearch = null, int pagina = 0)
        {

            try
            {
                List<IApiAccount> listaAccount = _accountService.SelectTeam(Guid.Parse(ValidatedTokenPayload.UidTenant), keysearch, pagina);
                
                if(listaAccount.Count > 0)
                {
                    List<IApiTeam> listaTeam = new List<IApiTeam>();
                    listaTeam.AddRange(listaAccount);
               
                    var jsonBinder = new JsonBinder<Account, IApiTeam>();

                    return Ok(jsonBinder.GetJObjectList(listaTeam));
                }

                else
                    return NotFound();
            }
            catch(Exception ex)
            {
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerError(), ex);
            }
        }



        /// <summary>
        /// SelectUsers - Metodo per selezionare gli users.
        /// Richiesta GET.
        /// </summary>
        /// <param name="codsocieta">Il codice della società</param>
        /// <param name="keysearch">La chiave di ricerca</param>
        /// <param name="idstatususer">L'ID dello stato dell'utente</param>
        /// <param name="idgruppouser">L'ID del gruppo dell'utente</param>
        /// <param name="pagina">Il numero di pagina</param>
        /// <returns>L'oggetto IHttpActionResult risultante</returns>
        //[AuthorizeRest]
        [HttpGet]
        [Route("api/" + API_VER + "/user/list")]
        [SwaggerResponse(HttpStatusCode.OK, "Utenti trovati", typeof(List<IApiAccount>))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Utenti non trovati")]
        public IHttpActionResult SelectUsers(string codsocieta = null, string keysearch = null, int idstatususer = -1, int idgruppouser = 0, int pagina = 0)
        {
            try
            {
                List<IApiAccount> result = _accountService.SelectUser(Guid.Parse(ValidatedTokenPayload.UidTenant), codsocieta, keysearch, idstatususer, idgruppouser, pagina);
                if (result.Count > 0)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return ResponseUtility.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalServerError(), ex);
            }

        }

    }
}
