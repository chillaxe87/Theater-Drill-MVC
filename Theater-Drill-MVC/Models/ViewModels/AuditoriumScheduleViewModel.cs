using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models.ViewModels
{
    public class AuditoriumScheduleViewModel 
    {
        public List<Auditorium> Auditorium;
        public List<ScheduledMovie> Schedule;

        public AuditoriumScheduleViewModel(List<Auditorium> auditorium, List<ScheduledMovie> schedule)
        {
            Auditorium = auditorium;
            Schedule = schedule;
        }
    }
}
