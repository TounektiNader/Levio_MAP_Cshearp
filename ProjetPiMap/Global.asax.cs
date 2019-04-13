using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Gnostice.StarDocsSDK;

namespace ProjetPiMap
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static StarDocs starDocs;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Setup     connection  details 
            //starDocs = new StarDocs(new ConnectionInfo(new Uri(" https://api.gnostice.com/stardocs/v1"), "cc0392ce16a9401c8f61dfcb9cf2b203", "c11bf081f51b4f00945ac59d8bbb3b04"));
            //Authentificate
            //starDocs.Auth.loginApp();
        }
    }
}
