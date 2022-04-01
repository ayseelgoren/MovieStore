using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntitiesLayer.Models
{
    public class Movie
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? DirectorId { get; set; }
        public int? GenreId { get; set; }
        public string? Name { get; set; }
        public DateTime Year { get; set; }
        public bool Status { get; set; } = true;
        public double Price { get; set; }
        public Genre Genre { get; set; }
        public Writer Writer { get; set; }
        [JsonIgnore]
        public ICollection<MoviePlayer> MoviePlayers { get; set; }

    }

}