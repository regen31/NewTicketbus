using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Domain.Entities;
using ticketbus.Domain.Interfaces;
using ticketbus.Logic.Interfaces;
using ticketbus.Logic.DTO;

namespace ticketbus.Logic.Services
{
    public class UserService:IUserService
    {

        IUserRepository UserRepository;

        public UserService(IUserRepository repo)
        {
            UserRepository = repo;
        }

        public UserDTO FindUser(string name)
        {
            var user = UserRepository.FindUser(name);
            if (user != null)
            {
                RoleDTO roledto = new RoleDTO()
                {
                    Name = user.UserRole.Name
                };

                return new UserDTO()
                {
                    Id = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    UserRole = roledto
                };
            }
            return null;
        }


       

        public IEnumerable<BoughtTicketDTO> GetUsersOrders(string username)
        {
            List<BoughtTicketDTO> OrdersDTO = new List<BoughtTicketDTO>();
            var orders = UserRepository.GetUsersOrders(username);

            foreach(var order in orders)
            {
                OrdersDTO.Add(new BoughtTicketDTO() {
                    RouteId = order.RouteId,
                    Buyer = order.Buyer,
                    StartPoint = order.StartPoint,
                    FinalPoint = order.FinalPoint,
                    BuyDay = order.BuyDay,

                });
            }
            return OrdersDTO;
        }
    }
}
