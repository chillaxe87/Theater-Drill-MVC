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
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var auditoriums = _context.Auditoriums.ToList();
            var movies = _context.Movies.ToList();
            if (auditoriums == null)
                return Content("Error Loading this Page");
            var viewModel = new MovieTheaterViewModel(movies, auditoriums);

            int count = viewModel.Movies.Count;

            return View(viewModel);
        }
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (movie == null)
                return View("", "Index");

            return View(movie);
        }
        public IActionResult New()
        {
            var movie = new Movie();
            return View("MovieForm", movie);
        }
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (movie == null)
                return Content("Movie Not Found");
            return View("MovieForm", movie);
        }
        public IActionResult Save(Movie movie)
        {
            if (movie.ID == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.ID == movie.ID);
                movieInDb = movie;
            }
            _context.SaveChanges();
            return RedirectToAction("", "Movies");
        }
    }
}
