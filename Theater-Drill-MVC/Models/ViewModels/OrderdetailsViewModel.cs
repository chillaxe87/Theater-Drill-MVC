using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models.ViewModels
{
    public class OrderdetailsViewModel
    {
        public List<Ticket> Tickets { get; set; }
        public Movie Movie { get; set; }
        public Auditorium Auditorium { get; set; }
        public OrderdetailsViewModel(List<Ticket> tickets, Movie movie, Auditorium auditorium)
        {
            Tickets = tickets;
            Movie = movie;
            Auditorium = auditorium;

        }
        
    }
}
