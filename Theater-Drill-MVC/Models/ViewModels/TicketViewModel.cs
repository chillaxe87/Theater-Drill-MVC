using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models.ViewModels
{
    public class TicketViewModel
    {
        public List<ScheduledMovie> ScreeningTimes { get; set; }
        public ScheduledMovie ScreeningTime { get; set; }
        public Ticket Ticket { get; set; }
        public List<Ticket> SeatsTaken { get; set; }
        public TicketViewModel(List<ScheduledMovie> screeningTimes, Ticket ticket, List<Ticket> seatsTaken, ScheduledMovie screeningTime)
        {
            Ticket = ticket;
            ScreeningTimes = screeningTimes;
            SeatsTaken = seatsTaken;
            ScreeningTime = screeningTime;
        }
    }
}
