using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models
{
    public class Auditorium
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Dictionary<DateTime, Movie> Schedule;
        public void AddMovieToSchedule(Movie movie, DateTime time)
        {
            Schedule[time] = movie;
        }
        public void RemoveMovieFromSchedule(DateTime time)
        {
            Schedule.Remove(time);
        }
    }
}
