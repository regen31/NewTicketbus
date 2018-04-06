using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Logic.DTO;

namespace ticketbus.Logic.Interfaces
{
    public interface IUserService
    {
        UserDTO FindUser(string name);
        void AddBoughtTicket(BoughtTicketDTO ticket);
    }
}
