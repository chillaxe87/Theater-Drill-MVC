using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models.ViewModels
{
    public class ScheduleViewModel
    {
        public List<ScheduledMovie> schedules { get; set; }
        public ScheduleViewModel( List<ScheduledMovie> items)
        {
            schedules = items;
        }
    }
}
