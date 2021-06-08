using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models.ViewModels
{
    public class AuditoriumViewModel
    {
        public Auditorium Auditorium;
        public List<ScheduledMovie> Schedule;

        public AuditoriumViewModel(Auditorium auditorium, List<ScheduledMovie> schedule)
        {
            Auditorium = auditorium;
            Schedule = schedule;
        }
    }
}
