using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticketbus.Domain.EFContext;
using ticketbus.Domain.Entities;
using ticketbus.Domain.Interfaces;
using System.Data.Entity;

namespace ticketbus.Domain.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private BusContext db;

        public NewsRepository(string connectionString)
        {
            db = new BusContext(connectionString);
        }

        public NewsItem Get(int id)
        {
            return db.NewsItems.Find(id);
        }

        public IEnumerable<NewsItem> GetAll()
        {
            return db.NewsItems;
        }

        public void Create(NewsItem item)
        {
            db.NewsItems.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = db.NewsItems.Find(id);
            db.NewsItems.Remove(item);
            db.SaveChanges();
        }

        public IEnumerable<NewsItem> GetSome() {

            var items = db.NewsItems.Take(5).OrderByDescending(x=>x.Date);
            return items;
        }
    }
}
