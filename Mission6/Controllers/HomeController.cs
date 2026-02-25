using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;
using Microsoft.EntityFrameworkCore; // 1. ADD THIS for .Include()

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // GET: Add Movie
        [HttpGet]
        public IActionResult AddMovie()
        {
            // 2. Fetch categories to populate the dropdown in the View
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(new Movie { Title = "", Director = "", Rating = "" }); // Passing a new movie model prevents null errors
        }

        // POST: Add Movie
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Index");
            }

            // If invalid, we need to reload the categories for the dropdown before returning the view
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(response);
        }

        // GET: Movie List
        public IActionResult MovieList()
        {
            // 3. Add .Include() to join the Categories table
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        // GET: Edit Movie
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(x => x.MovieId == id);

            // 4. Load categories so the edit dropdown works
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View("AddMovie", movie);
        }

        // POST: Edit Movie
        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedMovie);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }

            // If invalid, reload categories for the dropdown
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View("AddMovie", updatedMovie);
        }

        // GET: Delete Confirmation
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Optional: Include category here too if you display it on the delete page
            var movie = _context.Movies
                .Include(x => x.Category)
                .Single(x => x.MovieId == id);

            return View(movie);
        }

        // POST: Delete Movie
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}