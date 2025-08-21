using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplicationNewApi
{
    public static class WebApiConfig
    {
        //to convert in json we need to make some changes in WebApiConfig
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
