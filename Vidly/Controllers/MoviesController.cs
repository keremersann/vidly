using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext applicationDbContext;

        public MoviesController()
        {
            this.applicationDbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            applicationDbContext.Dispose();
        }

        public ActionResult Index()
        {
            var movies = applicationDbContext.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = applicationDbContext.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
            return View(movie);
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Customer 1" },
                new Customer { Id = 2, Name = "Customer 2" }
            };

            RandomMovieViewModel viewModel = new RandomMovieViewModel();
            viewModel.Movie = movie;
            viewModel.Customers = customers;
            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        
    }
}