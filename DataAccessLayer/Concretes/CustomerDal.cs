using DataAccessLayer.Abstracts;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel;
using EntitiesLayer.ViewModel.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    public class CustomerDal : RepositoryBase<Customer, MovieStoreDbContext>, ICustomerDal
    {
        public Customer IsThere(CreateCustomerModel model)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Customers.SingleOrDefault(x => x.Email == model.Email);
            }
        }

        public Customer IsThere(DeleteCustomerModel model)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Customers.SingleOrDefault(x => x.Email == model.Email && x.Id == model.Id);
            }
        }
        public Customer IsThereCustomer(LoginCustomerModel model)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Customers.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            }
        }
    }
}
