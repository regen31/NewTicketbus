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
    public class NewsService : INewsService
    {
        INewsRepository NewsRepository;

        public NewsService(INewsRepository repo)
        {
            NewsRepository = repo;
        }
        
        public NewsDTO GetNewsDTO(int id)
        {
            var item = NewsRepository.Get(id);

            return new NewsDTO() {
                Id = item.Id,
                Date = item.Date,
                Text = item.Text,
            };
        }

        public IEnumerable<NewsDTO> GetAllDTO()
        {
            List<NewsDTO> NewsList = new List<NewsDTO>();
            var items = NewsRepository.GetAll();

            foreach (var item in items)
            {
                NewsList.Add(new NewsDTO() {
                    Id = item.Id,
                    Date = item.Date,
                    Text = item.Text,
                });
            }
            return NewsList;
        }

        public void Create(NewsDTO item)
        {
            NewsRepository.Create(new NewsItem() {
                Date = item.Date,
                Text = item.Text,
            });
        }

        public void Delete(int id)
        {
            NewsRepository.Delete(id);
        }

        public IEnumerable<NewsDTO> GetSomeDTO()
        {
            List <NewsDTO> NewsList = new List<NewsDTO>();
            var items = NewsRepository.GetSome();

            foreach(var item in items)
            {
                NewsList.Add(new NewsDTO() {
                    Id = item.Id,
                    Date = item.Date,
                    Text = item.Text,
                });
            }
            return NewsList;
        }
    }
}
