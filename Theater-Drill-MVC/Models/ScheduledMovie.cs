using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models
{
    public class ScheduledMovie
    {
        public int ID { get; set; }
        public Movie Movie { get; set; }
        public int MovieID { get; set; }
        public Auditorium Auditorium { get; set; }
        public int AuditoriumId { get; set; }
        public DateTime ScreeningTime { get; set; }
    }
}
