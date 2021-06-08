using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models.ViewModels
{
    public class MovieTheaterViewModel
    {
        public List<Movie> Movies;
        public List<Auditorium> Auditoriums;

        public MovieTheaterViewModel(List<Movie> movies, List<Auditorium> auditoriums)
        {
            Movies = movies;
            Auditoriums = auditoriums;
        }
    }
}
