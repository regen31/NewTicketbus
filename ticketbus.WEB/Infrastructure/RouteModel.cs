using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using ticketbus.Logic.Services;
using ticketbus.Logic.Interfaces;

namespace ticketbus.WEB.Infrastructure
{
    public class RouteModel:NinjectModule
    {
        public override void Load()
        {
            Bind<IRouteService>().To<RouteService>();
        }
    }
}