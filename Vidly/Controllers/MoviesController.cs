using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
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

        private IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie>
            {
                new Movie() { Id = 1, Name = "Shrek" },
                new Movie() { Id = 2, Name = "Ice Age" }
            };
            return movies;
        }
    }
}