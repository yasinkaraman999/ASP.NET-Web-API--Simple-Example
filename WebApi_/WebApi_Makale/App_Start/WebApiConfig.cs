using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi_Makale.Filters;
using WebApi_Makale.Security;

namespace WebApi_Makale
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API yapılandırması ve hizmetleri
            config.EnableCors();
            // Web API yolları
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new APIKeyHandler());
            //ExceptionFilterAttribute
            config.Filters.Add(new ApiExceptionAttribute());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
