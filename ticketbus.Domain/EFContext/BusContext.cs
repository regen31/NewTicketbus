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
        static BusContext()
        {
            Database.SetInitializer<BusContext>(new DBInitializer());
        }
        public BusContext(string connectionString) : base(connectionString) { }
        public DbSet <Route> Routes { get; set; }
        public DbSet <NewsItem> NewsItems { get; set; }
        public DbSet <User> Users { get; set; }
        public DbSet <Role> Roles { get; set; }
        public DbSet <BoughtTicket> BoughtTickets { get; set; }
        
    }
}
