using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Domain.Entities;
using ticketbus.Domain.Interfaces;
using ticketbus.Domain.EFContext;
using System.Data.Entity;

namespace ticketbus.Domain.Repositories
{
    public class UserRepository:IUserRepository
    {
        private BusContext db;

        public UserRepository(string connectionstring)
        {
            db = new BusContext(connectionstring);
        }


        public User FindUser(string name)
        {
           return db.Users.Include(x => x.UserRole).Where(x => x.Login == name).First();
        }
    }
}
