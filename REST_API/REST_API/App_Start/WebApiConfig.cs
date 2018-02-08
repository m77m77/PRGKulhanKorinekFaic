using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace REST_API
{
    public static class WebApiConfig
    {
        public static MySqlConnection Connection()
        {
            string connection_string = "server=localhost;uid=kulhanmatous;pwd=123456;database=3b2_kulhanmatous_db2";
            MySqlConnection Connection = new MySqlConnection(connection_string);

            return Connection;
        }
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
