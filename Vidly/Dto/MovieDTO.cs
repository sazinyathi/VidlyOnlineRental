using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dto
{
    public class MovieDTO
    {
       

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre Types")]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

    }
}