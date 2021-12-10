using EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.ViewModel.OrderModel
{
    public class OrdersModel
    {
        public string MovieName { get; set; }
        public DateTime OrderDate { get; set; }
        public string GenreName { get; set; }
        public double Price { get; set; }
        public string Director { get; set; }
        public string Customer { get; set; }
        public ICollection<Player>? Players { get; set; }

    }
}
