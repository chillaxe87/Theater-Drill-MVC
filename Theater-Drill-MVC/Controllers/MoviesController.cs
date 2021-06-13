using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Administrator")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        private string adminRole = Roles.role;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            var auditoriums = _context.Auditoriums.ToList();
            var viewModel = new MovieTheaterViewModel(movies, auditoriums);
            return View(viewModel);
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {           
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (movie == null)
                return View("", "Index");
            if (User.IsInRole(adminRole))
                return View("AdminDetails", movie);

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
                _context.Entry(movieInDb).CurrentValues.SetValues(movie);
            }
            _context.SaveChanges();
            return RedirectToAction("", "Movies");
        }
        public IActionResult Delete(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(s => s.ID == id);
            if (movieInDB == null)
                return NotFound();

            _context.Remove(movieInDB);
            _context.SaveChanges();

            return RedirectToAction("", "Movies");
        }
    }
}
