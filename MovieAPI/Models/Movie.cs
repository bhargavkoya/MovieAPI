using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        public string  Url { get; set; }
        
        [Required(ErrorMessage ="Please select date of release")]
        public DateTime ReleaseDate { get; set; }

        public Producer Producer { get; set; }
        public ICollection<MoviesActors> Actors { get; set; }
    }
}
