using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface ICustomerService 
    {
        void Add(CreateCustomerModel model);
        void Delete(DeleteCustomerModel model);
    }
}
