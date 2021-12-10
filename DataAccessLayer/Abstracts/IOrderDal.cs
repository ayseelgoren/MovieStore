using DataAccessLayer.Abstracts;
using EntitiesLayer.Models;

namespace DataAccessLayer.Concretes
{
    public interface IOrderDal : IRepositoryBase<Order>
    {
        List<Order> GetAllCustomer(int customerId);
    }
}