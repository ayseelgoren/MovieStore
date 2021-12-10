using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }   
        public int? CustomerId { get; set; }   
        public Customer Customer { get; set; }
        public int? MovieId { get; set; }
        public Movie Movie { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }


    }
}
