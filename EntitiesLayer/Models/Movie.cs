using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntitiesLayer.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public int? DirectorId { get; set; }
        public int? GenreId { get; set; }
        public string? Name { get; set; }
        public DateTime Year { get; set; }
        public bool Status { get; set; } = true;
        public double Price { get; set; }
        public Genre Genre { get; set; }
        public virtual Director Director { get; set; }
        public virtual ICollection<MoviePlayer> Players { get; set; }
    }

}