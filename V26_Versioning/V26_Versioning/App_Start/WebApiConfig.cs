using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace V26_Versioning
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(IHttpControllerSelector), new ControllerSelector(config));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //config.Routes.MapHttpRoute(
            //    name: "version1",
            //    routeTemplate: "api/v1/employee/{id}",
            //    defaults: new { id = RouteParameter.Optional, controller="EmployeeV1" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "version2",
            //    routeTemplate: "api/v2/employee/{id}",
            //    defaults: new { id = RouteParameter.Optional, controller = "EmployeeV2" }
            //);
        }
    }
}
