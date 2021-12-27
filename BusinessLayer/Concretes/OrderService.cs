using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.Result;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Concretes;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concretes
{
    public class OrderService : IOrderService
    {
        IOrderDal _orderDal;
        IMovieDal _movieDal;
        public readonly IMapper _mapper;
        public OrderService(IOrderDal orderDal, IMovieDal movieDal, IMapper mapper)
        {
            _orderDal = orderDal;
            _movieDal = movieDal;
            _mapper = mapper;
        }
        /*  Filmi sistemden satın al. Alma işleminde filmin status değeri false yapılarak filmin satıldığı belirtilir.  */
        public Response Buy(OrderModel model)
        {
            var movie = _movieDal.IsThereId(model.MovieId);
            if (movie is null)
                return new Response(false, message: "Film sistemde bulunmamaktadır.",null);

            var order = _mapper.Map<Order>(model);
            order.Date = DateTime.Now;
            order.Price = movie.Price;
            _orderDal.Add(order);
            // Delete işlemiyle status durumunu false yaparak diğer satın alma durumlarını kapatıyoruz.
            movie.Status = false;
            _movieDal.Update(movie);
            return new Response(true, message: "Film Satın alınmıştır.",null);
        }

        public ResponseList<OrdersModel> CustomerPurchasedList(int customerId)
        {
            var orders = _orderDal.GetAllCustomer(customerId);
            if (orders is null)
                return new ResponseList<OrdersModel>(false, "Hata meydana geldi", null, null);

            List<OrdersModel> orderModels = _mapper.Map<List<OrdersModel>>(orders);
            return new ResponseList<OrdersModel>(true, "Oyuncular listelenmiştir.", null, orderModels);
        }
    }
}
