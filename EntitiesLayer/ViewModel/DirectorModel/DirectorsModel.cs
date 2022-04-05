using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer.Models;


namespace EntitiesLayer.ViewModel.WriterModel
{
    public class DirectorsModel : BaseModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
