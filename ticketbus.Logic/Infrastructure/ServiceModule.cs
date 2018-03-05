using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using ticketbus.Domain.Interfaces;
using ticketbus.Domain.Repositories;

namespace ticketbus.Logic.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IRouteRepository>().To<RouteRepository>().WithConstructorArgument(connectionString);
            Bind<INewsRepository>().To<NewsRepository>().WithConstructorArgument(connectionString);
        }
    }
}
