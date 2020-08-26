using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name ="Genre Types")]
        public int GenreId { get; set; }
        public Genre Genres { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }
    }
}