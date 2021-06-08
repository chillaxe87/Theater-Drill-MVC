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
    public class AuditoriumsController : Controller
    {
        private ApplicationDbContext _context;

        public AuditoriumsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var auditoriums = _context.Auditoriums.ToList();
            var viewModel = new AuditoriumScheduleViewModel(auditoriums, null);
            return View(viewModel);
        }
        public IActionResult Details(int id)
        {
            var auditorium = _context.Auditoriums.SingleOrDefault(a => a.ID == id);
            var schedule = _context.Schedule.Where(a => a.Auditorium.ID == id).ToList();

            foreach(var item in schedule)
            {
                item.Movie = _context.Movies.SingleOrDefault(m => m.ID == item.MovieID);
            }

            AuditoriumViewModel viewModel = new AuditoriumViewModel(auditorium, schedule);
            if (auditorium == null)
                return View("", "Index");


            return View(viewModel);
        }
        public IActionResult New()
        {
            var auditorium = new Auditorium();
            return View("AuditoriumForm", auditorium);
        }
        public IActionResult Edit(int id)
        {
            var auditorium = _context.Auditoriums.SingleOrDefault(m => m.ID == id);
            if (auditorium == null)
                return Content("Auditorium Not Found");
            return View("AuditoriumForm", auditorium);
        }
        public IActionResult Save(Auditorium auditorium)
        {
            if (auditorium.ID == 0)
                _context.Auditoriums.Add(auditorium);
            else
            {
                var auditoriumInDb = _context.Auditoriums.SingleOrDefault(a => a.ID == auditorium.ID);
                _context.Entry(auditoriumInDb).CurrentValues.SetValues(auditorium);
            }
            _context.SaveChanges();
            return RedirectToAction("", "Auditoriums");
        }
    }
}
