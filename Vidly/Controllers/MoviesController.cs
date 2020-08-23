using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;


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
        public ActionResult Details(int id)
        {
            var movie = applicationDbContext.Movies.Include(c => c.Genres).SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
    
        }

        protected override void Dispose(bool disposing)
        {
            applicationDbContext.Dispose();
        }
    }
}