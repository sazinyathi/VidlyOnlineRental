using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext applicationDbContext;
        public MoviesController()
        {
            applicationDbContext = new ApplicationDbContext();
        }
        public IEnumerable<MovieDTO> GeAllMovies()
        {
            return applicationDbContext.Movies.Include(x => x.Genres).ToList()
                .Select(Mapper.Map<Movie, MovieDTO>);
        }
        public MovieDTO GetMovieById(int id)
        {
            var movie = applicationDbContext.Movies.SingleOrDefault(x => x.Id == id);
            return Mapper.Map<Movie, MovieDTO>(movie);
        }

        

        
    }
}
