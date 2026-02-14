using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        // 1. Create a private variable to hold the database context
        private MovieContext _context;

        // 2. Add a Constructor so the controller can use the database
        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        // 3. Add the "Get to Know Joel" page action
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // 4. Add the GET action to show the movie form
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        // 5. Add the POST action to receive and save the movie data
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Add the new movie
                _context.SaveChanges(); // Save changes to the SQLite database
                return View("Index"); // Redirect to the home page after saving
            }

            return View(response); // If validation fails, stay on the form page
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}