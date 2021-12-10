using BusinessLayer.Abstracts;
using BusinessLayer.Result;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.OrderModel;

namespace BusinessLayer.Concretes
{
    public interface IOrderService
    {
        Response Buy(OrderModel model);
        ResponseList<OrdersModel> CustomerPurchasedList(int customerId);
    }
}