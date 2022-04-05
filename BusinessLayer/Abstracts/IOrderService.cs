using BusinessLayer.Abstracts;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.OrderModel;

namespace BusinessLayer.Concretes
{
    public interface IOrderService
    {
        void Buy(OrderModel model);
        List<OrdersModel> CustomerPurchasedList(int customerId);
        List<OrdersModel> GetAll();
    }
}