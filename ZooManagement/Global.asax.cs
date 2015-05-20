using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ZooManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            HttpConfiguration config = GlobalConfiguration.Configuration;

            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add
                     (new Newtonsoft.Json.Converters.StringEnumConverter());
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.EnsureInitialized();

            
        }
    }
}
