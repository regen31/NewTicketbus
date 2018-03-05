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

        public News Get(int id)
        {
            return db.News.Find(id);
        }

        public IEnumerable<News> GetAll()
        {
            return db.News;
        }

        public void Create(News item)
        {
            db.News.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = db.News.Find(id);
            db.News.Remove(item);
            db.SaveChanges();
        }

        public IEnumerable<News> GetSome() {

            var items = db.News.Take(5).OrderByDescending(x=>x.Date);
            return items;
        }
    }
}
