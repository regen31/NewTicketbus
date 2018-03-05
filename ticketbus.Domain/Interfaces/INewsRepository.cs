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
        NewsItem Get(int id);
        IEnumerable<NewsItem> GetAll();
        void Create(NewsItem item);
        void Delete(int id);
        IEnumerable<NewsItem> GetSome();
    }
}
