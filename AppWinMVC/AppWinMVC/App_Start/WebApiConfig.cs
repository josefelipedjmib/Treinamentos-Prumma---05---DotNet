using System.Web.Http;
using System.Web.Mvc;

namespace AppWinMVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = UrlParameter.Optional }
            );

        }
    }
}
