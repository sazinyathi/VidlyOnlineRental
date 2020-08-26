using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        public int GenreId { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movies { get; set; }
    }
}