using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstracts
{
    public interface ICustomerDal : IRepositoryBase<Customer>
    {
        Customer IsThere(CreateCustomerModel model);
        Customer IsThere(DeleteCustomerModel model);
        Customer IsThereCustomer(LoginCustomerModel model);
    }
}
