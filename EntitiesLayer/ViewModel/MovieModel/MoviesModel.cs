using EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.ViewModel.MovieModel
{
    public class MoviesModel
    {
        public string Director { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public string GenreName { get; set; }
        public double Price { get; set; }
        public string IsItSold { get; set; }
        public ICollection<Player>? Players { get; set; }
    }
}
