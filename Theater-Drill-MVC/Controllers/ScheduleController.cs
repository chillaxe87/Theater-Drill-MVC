using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater_Drill_MVC.Data;
using Theater_Drill_MVC.Models;
using Theater_Drill_MVC.Models.ViewModels;

namespace Theater_Drill_MVC.Controllers
{
    public class ScheduleController : Controller
    {
        private ApplicationDbContext _context;
        private string adminRole = "Administrator";
        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? id)
        {
            ScheduleViewModel viewModel;       
            if (id == null)
                viewModel = new ScheduleViewModel(_context.Schedule.ToList());
            //viewModel = new ScheduleViewModel(_context.Schedule.Where(m => m.ScreeningTime > DateTime.Now).ToList());
            else
                viewModel = new ScheduleViewModel(_context.Schedule.Where(m => m.MovieID == id).ToList());
            //viewModel = new ScheduleViewModel(_context.Schedule.Where(m => m.MovieID == id && m.ScreeningTime > DateTime.Now).ToList());


            foreach (ScheduledMovie item in viewModel.schedules)
            {
                item.Movie = _context.Movies.SingleOrDefault(m => m.ID == item.MovieID);
                item.Auditorium = _context.Auditoriums.SingleOrDefault(a => a.ID == item.AuditoriumId);
            }
            if (User.IsInRole(adminRole))
                return View("AdminDetails", viewModel);
            return View(viewModel);
        }
        public IActionResult Edit(int id)
        {
            var schedule = _context.Schedule.SingleOrDefault(s => s.ID == id);
            if (schedule == null)
                return View("", "Auditorium");
            var movies = _context.Movies.ToList();
            var auditoriums = _context.Auditoriums.ToList();
            var viewModel = new ScheduleMovieViewModel(auditoriums, movies, schedule);
            return View("ScheduleMovieForm", viewModel);
        }
        public IActionResult New()
        {
            var movies = _context.Movies.ToList();
            var auditoriums = _context.Auditoriums.ToList();
            var viewModel = new ScheduleMovieViewModel(auditoriums, movies, null);
            return View("ScheduleMovieForm", viewModel);
        }
        public IActionResult Save(ScheduledMovie schedule)
        {
            if (schedule.ID == 0)
            {
                var newSchedule = new ScheduledMovie() {
                    Auditorium = _context.Auditoriums.SingleOrDefault(a => a.ID == schedule.AuditoriumId),
                    Movie = _context.Movies.SingleOrDefault(m => m.ID == schedule.MovieID),
                    ScreeningTime = schedule.ScreeningTime
                };
                _context.Schedule.Add(newSchedule);
            }
            else
            {
                var scheduleInDb = _context.Schedule.SingleOrDefault(s => s.ID == schedule.ID);
                _context.Entry(scheduleInDb).CurrentValues.SetValues(schedule);
            }
            _context.SaveChanges();
            return RedirectToAction("", "Movies");
        }
        public IActionResult Delete(int id)
        {
            var scheduleInDB = _context.Schedule.SingleOrDefault(s => s.ID == id);
            if (scheduleInDB == null)
                return NotFound();

            _context.Remove(scheduleInDB);
            _context.SaveChanges();

            return RedirectToAction("", "Schedule");
        }
        public IActionResult OrderTicket(int id)
        {
            var schedule = _context.Schedule.SingleOrDefault(s => s.ID == id);
            if(schedule == null)
                return NotFound();

            var seatsTaken = _context.Tickets.Where(t => t.AuditoriumId == schedule.AuditoriumId && t.Time == schedule.ScreeningTime).ToList();


            var movie = _context.Movies.SingleOrDefault(m => m.ID == schedule.MovieID);
            var auditorium = _context.Auditoriums.SingleOrDefault(a => a.ID == schedule.AuditoriumId);
            if (movie == null || auditorium == null)
                return NotFound();

            var ticket = new Ticket { Auditorium = auditorium, Movie = movie, AuditoriumId = auditorium.ID, MovieId = movie.ID };
    
            var screeningTimes = _context.Schedule.Where(s => s.MovieID == movie.ID).ToList();
            var screeningTime = _context.Schedule.SingleOrDefault(s => s.ScreeningTime == schedule.ScreeningTime);
            if (screeningTime == null)
                return NotFound();

            var viewModel = new TicketViewModel(screeningTimes, ticket, seatsTaken, screeningTime);
            return View(viewModel);
        }
        public IActionResult SaveTicket(Ticket ticket)
        {
            if (ticket.SeatsOrdered == null)
                return NotFound();

            var seats = ticket.SeatsOrdered.Split(' ');
            List<Ticket> tickets = new List<Ticket>();
            var movie = _context.Movies.SingleOrDefault(m => m.ID == ticket.MovieId);
            var auditorium = _context.Auditoriums.SingleOrDefault(m => m.ID == ticket.AuditoriumId);

            foreach (string seat in seats)
            {
                if (seat == "")
                    break;

                var rowAndColumn = seat.Split('/');
                int row = int.Parse(rowAndColumn[0]);
                int column = int.Parse(rowAndColumn[1]);
                Ticket item = new Ticket
                {
                    Auditorium = auditorium,
                    Movie = movie,
                    SeatRow = row,
                    SeatNumber = column,
                    AuditoriumId = auditorium.ID,
                    MovieId = movie.ID,
                    OwnerEmail = ticket.OwnerEmail,
                    OwnerName = ticket.OwnerName,
                    Time = ticket.Time
                };
                _context.Tickets.Add(item);
                tickets.Add(item);
            };
            var viewModel = new OrderdetailsViewModel(tickets, movie, auditorium);

            _context.SaveChanges();

            return View("OrderDetails", viewModel);
        }
        
        public IActionResult OrderDetails(OrderdetailsViewModel viewModel)
        {
            return View(viewModel);
        }
        
    }
}
