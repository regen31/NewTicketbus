using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ticketbus.Domain.Entities;

namespace ticketbus.Domain.EFContext
{
    class BusContext : DbContext
    {
        public BusContext(string connectionString) : base(connectionString) { }
        public DbSet <Route> Routes { get; set; }


        
    }
}
