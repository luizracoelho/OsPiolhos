using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Piolhos.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Habilitar o CORS
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Remover XML => Retornar Json como padrão
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Desabilitar a referência circular
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            config.Formatters.JsonFormatter.SerializerSettings = jsonSerializerSettings;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {controller = "home", id = RouteParameter.Optional }
            );
        }
    }
}
