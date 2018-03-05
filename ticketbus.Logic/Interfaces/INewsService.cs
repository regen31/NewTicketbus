using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Logic.DTO;

namespace ticketbus.Logic.Interfaces
{
    public interface INewsService
    {
        NewsDTO GetNewsDTO(int id);
        IEnumerable<NewsDTO> GetAllDTO();
        void Create(NewsDTO item);
        void Delete(int id);
        IEnumerable<NewsDTO> GetSomeDTO();
    }
}
