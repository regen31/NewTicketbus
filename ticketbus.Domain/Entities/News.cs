using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketbus.Domain.Entities
{
    public class News
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
