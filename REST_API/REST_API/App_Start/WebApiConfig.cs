using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace REST_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Služby a konfigurace rozhraní Web API
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            // Trasy rozhraní Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
