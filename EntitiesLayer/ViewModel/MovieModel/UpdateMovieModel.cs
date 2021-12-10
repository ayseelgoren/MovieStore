using EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.ViewModel.MovieModel
{
    public class UpdateMovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public int GenreId { get; set; }
        public double Price { get; set; }
        public int DirectorId { get; set; }

    }
}
