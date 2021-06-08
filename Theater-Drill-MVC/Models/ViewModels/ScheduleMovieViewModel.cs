using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models.ViewModels
{
    public class ScheduleMovieViewModel
    {
        public List<Auditorium> Auditorium;
        public List<Movie> Movies;
        public ScheduledMovie Schedule;
        public ScheduleMovieViewModel() { }
        public ScheduleMovieViewModel(List<Auditorium> auditorium, List<Movie> movies, ScheduledMovie schedule)
        {
            Auditorium = auditorium;
            Movies = movies;
            Schedule = schedule;
        }
    }
}
