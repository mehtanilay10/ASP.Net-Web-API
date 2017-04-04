using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace V26_Versioning
{
    public class ControllerSelector: DefaultHttpControllerSelector
    {
        HttpConfiguration config;
        public ControllerSelector(HttpConfiguration config) : base(config)
        {
            this.config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controller = GetControllerMapping();
            string controllerName = request.GetRouteData().Values["controller"].ToString();
            string versionNo = "1";

            //var queryString = HttpUtility.ParseQueryString(request.RequestUri.Query);
            //if (queryString["v"] != null)
            //    versionNo = queryString["v"];

            string headerName = "X-Employee-Version";
            if(request.Headers.Contains(headerName))
            {
                versionNo = request.Headers.GetValues(headerName).FirstOrDefault();
                if (versionNo.Contains(","))
                    versionNo = versionNo.Substring(0, versionNo.IndexOf(','));
            }

            if (versionNo == "1")
                controllerName += "V1";
            else if (versionNo == "2")
                controllerName += "V2";

            HttpControllerDescriptor descriptor;
            if (controller.TryGetValue(controllerName, out descriptor))
                return descriptor;
            return null;
        }
    }
}