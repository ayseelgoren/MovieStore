using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Models
{
    public class MoviePlayer
    {
        [Key]
        public int Id { get; set; }
        public Player Players { get; set; }
        public int PlayersId { get; set; }
        public Movie Movies { get; set; }
        public int MoviesId { get; set; }
    }
}
