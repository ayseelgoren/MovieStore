using EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.ViewModel.PlayerModel
{
    public class PlayersModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
