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

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ScheduleViewModel viewModel = new ScheduleViewModel(_context.Schedule.ToList());
            foreach(ScheduledMovie item in viewModel.schedules)
            {
                item.Movie = _context.Movies.SingleOrDefault(m => m.ID == item.MovieID);
                item.Auditorium = _context.Auditoriums.SingleOrDefault(a => a.ID == item.AuditoriumId);
            }
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
                    Auditorium = _context.Auditoriums.SingleOrDefault(a=> a.ID == schedule.AuditoriumId),
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
    }
}
