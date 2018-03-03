using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketbus.Domain.Entities
{
    public class Route
    {
        public int Id { get; set; }
        public string StartPoint { get; set; }
        public string FinalPoint { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thusday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}
