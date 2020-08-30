using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        public MoviesController()
        {
            applicationDbContext = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = applicationDbContext.Movies.Include(m =>m.Genres).ToList();
            return View(movies);
        }
        public ActionResult Edit(int id)
        {
            var movie = applicationDbContext.Movies.Include(c => c.Genres).SingleOrDefault(x => x.Id == id);
        
            if (movie == null)
                return HttpNotFound();

            var movieViewModel = new MovieViewModel
            {
                GenreId = movie.GenreId,
                Movies = movie,
                Genres = applicationDbContext.Gernes.ToList()
            };

            return View("MovieForm", movieViewModel);

        }

        [HttpPost]
        public ActionResult Save(MovieViewModel movieViewModel)
        {
            if (!ModelState.IsValid)
            {
                var genreTypes = applicationDbContext.Gernes.ToList();
                var _movieViewModel = new MovieViewModel
                {
                   
                    Movies = new Movie(),
                    Genres = genreTypes
                };
                return View("MovieForm", _movieViewModel);
            }
            var movie = new Movie
            {
              Name = movieViewModel.Movies.Name,
              DateAdded = movieViewModel.Movies.DateAdded,
              ReleaseDate = movieViewModel.Movies.ReleaseDate,
              NumberInStock = movieViewModel.Movies.NumberInStock,
              GenreId  = movieViewModel.Movies.GenreId
            };

            if(movieViewModel.Movies.Id == 0)
            {
                applicationDbContext.Movies.Add(movie);
            }
            else
            {
                var movieInDb = applicationDbContext.Movies.Single(x => x.Id == movieViewModel.Movies.Id);
                movieInDb.Name = movie.Name;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;

            }
          
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult New()
        {
            var genreTypes = applicationDbContext.Gernes.ToList();
            var movieViewModel = new MovieViewModel
            {
              Genres = genreTypes
            };
            return View("MovieForm", movieViewModel);
        }
        protected override void Dispose(bool disposing)
        {
            applicationDbContext.Dispose();
        }
    }
}