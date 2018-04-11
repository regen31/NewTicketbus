using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using ticketbus.Logic.Services;
using ticketbus.Logic.Interfaces;

namespace ticketbus.WEB.Infrastructure
{
    public class DIModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IRouteService>().To<RouteService>();
            Bind<INewsService>().To<NewsService>();
            Bind<IUserService>().To<UserService>();
            Bind<IOrderService>().To<OrderService>();
        }
    }
}