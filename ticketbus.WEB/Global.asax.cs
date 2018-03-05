using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using ticketbus.Logic.Infrastructure;
using ticketbus.WEB.Infrastructure;

namespace ticketbus.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule DIModule = new DIModule();
            NinjectModule ServiceModule = new ServiceModule("DBConnection");
            var kernel = new StandardKernel(DIModule, ServiceModule);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
