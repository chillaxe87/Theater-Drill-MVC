using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models.ViewModels
{
    public class ScheduleViewModel
    {
        public List<ScheduledMovie> schedules { get; set; }
        public SortedList<DateTime, ScheduledMovie> sortedSchedule { get; set; }
        public ScheduleViewModel( List<ScheduledMovie> items)
        {
            sortedSchedule = new SortedList<DateTime, ScheduledMovie>();
            schedules = items.OrderBy(m => m.ScreeningTime).ToList();
            /*
            foreach(var item in items)
            {
                sortedSchedule.Add(item.ScreeningTime, item);
            }
            schedules = new List<ScheduledMovie>();
            foreach(var item in sortedSchedule)
            {
                schedules.Add(item.Value);
            }
            */
        }
    }
}
