using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;
using Microsoft.EntityFrameworkCore;

namespace Mission6.Controllers
{
    /// <summary>
    /// Handles all HTTP requests related to movies and navigation.
    /// Manages CRUD operations for movies and category display.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly MovieContext _context;

        public HomeController(MovieContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Displays the home page with welcome information.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Displays information about Joel.
        /// </summary>
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        /// <summary>
        /// GET: Displays the form to add a new movie.
        /// Populates the category dropdown list sorted alphabetically.
        /// </summary>
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(new Movie { Title = "", Director = "", Rating = "" });
        }

        /// <summary>
        /// POST: Saves a new movie to the database.
        /// Reloads categories if validation fails to preserve dropdown state.
        /// </summary>
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Index");
            }

            // Reload categories if validation fails
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(response);
        }

        /// <summary>
        /// Displays all movies in the collection, sorted by title.
        /// Uses Include() to load category information for each movie.
        /// </summary>
        public IActionResult MovieList()
        {
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        /// <summary>
        /// GET: Displays the form to edit an existing movie.
        /// Loads the movie details and available categories for the dropdown.
        /// </summary>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(movie);
        }

        /// <summary>
        /// POST: Updates an existing movie in the database.
        /// Reloads categories if validation fails to preserve dropdown state.
        /// </summary>
        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedMovie);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }

            // Reload categories if validation fails
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(updatedMovie);
        }

        /// <summary>
        /// GET: Displays confirmation page before deleting a movie.
        /// Includes category information for context.
        /// </summary>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies
                .Include(x => x.Category)
                .Single(x => x.MovieId == id);

            return View(movie);
        }

        /// <summary>
        /// POST: Permanently removes a movie from the database.
        /// </summary>
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        /// <summary>
        /// Displays the error page when an exception occurs during request processing.
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}