using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntitiesLayer.Models
{
    public class Player
    {

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public virtual ICollection<MoviePlayer> Movies { get; set; }
    }
}