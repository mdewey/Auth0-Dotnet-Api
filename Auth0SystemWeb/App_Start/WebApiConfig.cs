﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Auth0SystemWeb.App_Start;
using System.Web.Configuration;

namespace Auth0SystemWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            // Web API configuration and services
            config.EnableCors();

            var clientID = WebConfigurationManager.AppSettings["auth0:ClientId"];
            var clientSecret = WebConfigurationManager.AppSettings["auth0:ClientSecret"];

            config.MessageHandlers.Add(new JsonWebTokenValidationHandler()
            {
                Audience = clientID,
                SymmetricKey = clientSecret,
                IsSecretBase64Encoded = false
            });
        }
    }
}
