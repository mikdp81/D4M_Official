using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessObject
{
    using AraneaUtilities.Auth.Roles;
    using AraneaUtilities.Auth.WebApi.Enpoints;
    using AraneaUtilities.Auth.WebApi.Jwt;
    using System.Configuration;

    /// <summary>
    /// Classe contenente le chiavi del'applicazione DFleet.
    /// </summary>
    public static class DFleetGlobals
    {
        /// <summary>
        /// Chiave di acceso al token per un array associativo.
        /// </summary>
        public static string TokenKey { get; } = ConfigurationManager.AppSettings["TokenKey"];

        /// <summary>
        /// Chiave di acceso al payload del token per un array associativo.
        /// </summary>
        public static string TokenPayloadKey { get; } = ConfigurationManager.AppSettings["TokenPayloadKey"];

 
        /// <summary>
        /// Impostazioni del jwt in un file json
        /// </summary>
        public static TokenSettings JwtSettings { get; } = TokenSettings.GetInstance(ConfigurationManager.AppSettings["JwtSettingsKey"]);


        /// <summary>
        /// Elenco ruoli validi in un file json
        /// </summary>
        public static DFleetUserRoles UserRoles { get; } = DFleetUserRoles.GetInstance(ConfigurationManager.AppSettings["UserRolesKey"]);

        /// <summary>
        ///  Endpoints disponibili e dei ruoli associati in un file json
        /// </summary>
        public static Endpoints Endpoints { get; } = Endpoints.GetInstance(ConfigurationManager.AppSettings["EndpointsKey"]);

        /// <summary>
        /// ProviderProxy_ON = true/false
        /// </summary>
        public static bool ProviderProxy_ON { get; } = bool.Parse(ConfigurationManager.AppSettings["ProviderProxy_ON_Key"]);


        /*
        /// <summary>
        /// Chiave di acceso allo username nel token per un array associativo.
        /// </summary>
        public static string TokenUsernameKey { get; } = ConfigurationManager.AppSettings["TokenUsernameKey"];

        /// <summary>
        /// Chiave di acceso ai ruoli del token per un array associativo.
        /// </summary>
        public static string TokenRolesKey { get; } = ConfigurationManager.AppSettings["TokenRolesKey"];

        /// <summary>
        /// Chiave di acceso all'UID del tenant nel token per un array associativo.
        /// </summary>
        public static string TokenUidTenantKey { get; } = ConfigurationManager.AppSettings["TokenUidTenantKey"];
        */
    }
}
