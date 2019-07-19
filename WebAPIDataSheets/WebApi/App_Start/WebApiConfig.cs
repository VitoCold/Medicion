using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Web.Http;

namespace WebApi
{
    public static class WebApiConfig
    {
        //public static void Register(HttpConfiguration config)
        //{
        //    // Configuración y servicios de API web

        //    // Rutas de API web
        //    config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );
        //}

        public static void Configure(HttpConfiguration config)
        {
            config.MessageHandlers.Insert(0,
                new ServerCompressionHandler(
                    new GZipCompressor(), new DeflateCompressor()));

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        }
    }
}
