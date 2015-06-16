﻿using System.Web.Http;

namespace RoadMaintenance.MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            
            //var formatter =
            //    config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(f => f.MediaType == "application/xml");

            //if (formatter != null)
            //    config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(formatter);


            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}