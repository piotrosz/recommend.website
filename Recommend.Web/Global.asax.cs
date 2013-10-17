using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Recommend.Core.DAL;
using Recommend.Core.Ninject;
using Recommend.UI.App_Start;
using Ninject;
using Ninject.Web.Common;
using Recommend.UI.Infrastructure.ModelBinders;
using WebMatrix.WebData;
using System.Data.Entity;

namespace Recommend.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapBundleConfig.RegisterBundles();
            AuthConfig.RegisterAuth();

            //Database.SetInitializer(new RecommendationsInitializer());
            //// call a query on the database to make sure it gets created before any authorization/authentication code is called.
            //new RecommendationsContext().Users.Find(1);

            ModelBinderProviders.BinderProviders.Add(new RecommendModelBinderProvider());

            WebSecurity.InitializeDatabaseConnection(
               connectionStringName: "DefaultConnection",
               userTableName: "User",
               userIdColumn: "Id",
               userNameColumn: "UserName",
               autoCreateTables: true);
        }
    }
}