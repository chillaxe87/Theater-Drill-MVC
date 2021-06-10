using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public string OwnerName { get; set; }
        public Auditorium Auditorium { get; set; }
        public int AuditoriumId { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public DateTime Time { get; set; }
        public int SeatRow { get; set; }
        public int SeatNumber { get; set; }
    }
}
