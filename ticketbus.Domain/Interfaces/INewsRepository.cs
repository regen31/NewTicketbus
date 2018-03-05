using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Domain.Entities;

namespace ticketbus.Domain.Interfaces
{
    public interface INewsRepository
    {
        News Get(int id);
        IEnumerable<News> GetAll();
        void Create(News item);
        void Delete(int id);
        IEnumerable<News> GetSome();
    }
}
