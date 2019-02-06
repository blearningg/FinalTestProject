﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TestWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            //// Web API configuration and services
            //var enableCorsAttribute = new EnableCorsAttribute("*",
            //                               "Origin, Content-Type, Accept",
            //                               "GET, PUT, POST, DELETE, OPTIONS"

            //                               );
            //config.EnableCors(enableCorsAttribute);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //To produce JSON format add this line of code  
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
