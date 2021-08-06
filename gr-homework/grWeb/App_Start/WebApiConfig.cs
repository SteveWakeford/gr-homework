using System.Web.Http;

namespace grWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}"
            );

            // force JSON
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
