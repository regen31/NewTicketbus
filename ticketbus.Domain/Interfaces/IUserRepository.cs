using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Domain.Entities;

namespace ticketbus.Domain.Interfaces
{
    public interface IUserRepository
    {
        User FindUser(string name);        
        IEnumerable<BoughtTicket> GetUsersOrders(string username);
        void AddUser(string username, string password);
    }
}
