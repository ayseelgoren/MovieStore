using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.ViewModel.OrderModel
{
    public class OrderModel : BaseModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
    }
}
