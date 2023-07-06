using AraneaUtilities.Auth.Roles;
using AraneaUtilities.Auth.WebApi.Blacklist;
using AraneaUtilities.Auth.WebApi.Enpoints;
using AraneaUtilities.Auth.WebApi.Jwt;
using Autofac;
using Autofac.Integration.WebApi;
using BusinessObject;
using DFleetRest.AuthorizationAttributes;
using DFleetRest.Controllers;
using DFleetRest.Services;
using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace DFleetRest
{
    /// <summary>
    /// Configurazione Web API e servizi
    /// </summary>
    public static class WebApiConfig
    {
        private static ContainerBuilder _builder;
        private static IContainer _container;
        private static IDependencyResolver _resolver = GlobalConfiguration.Configuration.DependencyResolver;


        /// <summary>
        /// Registra la configurazione dell'applicazione Web API.
        /// </summary>
        /// <param name="config">Configurazione dell'applicazione Web API</param>
        public static void Register(HttpConfiguration config)
        {
            /* ROUTING */

            // Abilita la mappatura degli attributi
            config.MapHttpAttributeRoutes();

            // Configura la route predefinita dell'APIBlacklistUserAttribute
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            /* FINE ROUTING */

       
            /* REGISTRAZIONI AUTOFAC */

            // Creazione del container di Autofac
            _builder = new ContainerBuilder();

            // Registra le dipendenze
            _builder.RegisterType<Account>().As<IAccount>().SingleInstance(); // Registra l'interfaccia e l'implementazione

            // Registrazione di AUTHORIZATION JWT
            JwtRegister();

            // Registrazione di AUTHORIZATION Endpoints
            EnpointsRegister();

            // Registrazione di AUTHORIZATION Blacklist
            BlacklistRegister();

            // Registrazione degli AUTHORIZATION Attributes
            AuthAttributesRegister();

            // Registrazione SERVICES
            ServicesRegister();

            // Registrazione CONTROLLERS
            ControllersRegister();


            /* FINE REGISTRAZIONI AUTOFAC */


            // Creazione del container di Autofac
            _container = _builder.Build();

            // Configurazione di Autofac come DependencyResolver per Web API
            config.DependencyResolver = new AutofacWebApiDependencyResolver(_container);

        }

        private static void AuthAttributesRegister()
        {
            AuthorizeJwtAttribute jwtAttribute = _resolver.GetService(typeof(AuthorizeJwtAttribute)) as AuthorizeJwtAttribute;
            AuthorizeBlacklistAttribute blacklistAttribute = _resolver.GetService(typeof(AuthorizeBlacklistAttribute)) as AuthorizeBlacklistAttribute;
            AuthorizeEndpointsAttribute endpointsAttribute = _resolver.GetService(typeof(AuthorizeEndpointsAttribute)) as AuthorizeEndpointsAttribute;


            // Risoluzione di AuthorizeEndpointsAttribute utilizzando jwtAttribute, endpointsAttribute, blacklistAttribute
            var authorizeRestAttribute = new AuthorizeRestAttribute(jwtAttribute, endpointsAttribute, blacklistAttribute);
            // Registrazione di AuthorizeJwtAttribute
            _builder.RegisterInstance(authorizeRestAttribute).As<AuthorizeRestAttribute>().SingleInstance();

        }

        private static void BlacklistRegister()
        {
            // Risoluzione di BlacklistManager 
            var blacklistManager = BlacklistManager.GetInstance();

            // Registrazione di BlacklistManager come istanza singola
            _builder.RegisterInstance(blacklistManager).As<IBlacklistManager>().SingleInstance();

            // Registrazione di AuthorizeBlacklistAttribute
            _builder.RegisterType<AuthorizeBlacklistAttribute>().SingleInstance();
        }

        private static void EnpointsRegister()
        {
            // Risoluzione di Endpoints
            var endpoints = DFleetGlobals.Endpoints;
            // Registrazione di Endpoints
            _builder.RegisterType<DFleetUserRoles>().As<IUserRoles>().SingleInstance();


            // Risoluzione di UserRoles
            var userRoles = DFleetGlobals.UserRoles;
            // Registrazione di UserRoles
            _builder.RegisterType<DFleetUserRoles>().As<IUserRoles>().SingleInstance();


            // Risoluzione di EndpointsManager utilizzando endpoints, userRoles
            var endpointsManager = EndpointsManager.GetInstance(endpoints, userRoles);
            // Registrazione di EndpointsManager come istanza singola
            _builder.RegisterInstance(endpointsManager).As<IEndpointsManager>().SingleInstance();


            // Risoluzione di AuthorizeEndpointsAttribute utilizzando EndpointsManager
            var authorizeEndpointsAttribute = new AuthorizeEndpointsAttribute(endpointsManager);
            // Registrazione di AuthorizeEndpointAttribute
            _builder.RegisterInstance(authorizeEndpointsAttribute).As<AuthorizeEndpointsAttribute>().SingleInstance();
        }

        private static void JwtRegister()
        {
            // Risoluzione di TokenManager<DFleetTokenPayload> utilizzando TokenSettings
            var tokenManager = TokenManager<DFleetTokenPayload>.GetInstance(DFleetGlobals.JwtSettings);

            // Registrazione di TokenManager<DFleetTokenPayload> come istanza singola
            _builder.RegisterInstance(tokenManager).As<ITokenManager<DFleetTokenPayload>>();

            // Risoluzione di TokenManager utilizzando TokenManager
            var authorizeJwtAttribute = new AuthorizeJwtAttribute(tokenManager);
            // Registrazione di AuthorizeEndpointAttribute
            _builder.RegisterInstance(authorizeJwtAttribute).As<AuthorizeJwtAttribute>().SingleInstance();

        }

        private static void ServicesRegister()
        {
            // Registrazione di BLService con Autofac
            _builder.RegisterType<BLService>().As<IBLService>().InstancePerDependency();
        }


        private static void ControllersRegister()
        {
            // Registrazione di AccountController con Autofac
            _builder.RegisterType<AccountController>().InstancePerRequest();
            /*   .WithParameter((pi, ctx) => pi.ParameterType == typeof(IBLService),
                    (pi, ctx) => ctx.Resolve<IBLService>())
              .WithParameter((pi, ctx) => pi.ParameterType == typeof(IBlacklistManager),
                    (pi, ctx) => ctx.Resolve<IBlacklistManager>())
              .WithParameter((pi, ctx) => pi.ParameterType == typeof(ITokenManager),
                    (pi, ctx) => ctx.Resolve<ITokenManager>())
              .InstancePerRequest(); */
        }


    }
}
