using BusinessLayer.Concretes;
using EntitiesLayer.ViewModel.OrderModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // Müşteri filmi satın alıyor
        [HttpPost]
        public IActionResult Buy(OrderModel model)
        {
            var result = _orderService.Buy(model);
            if (result.Status == false)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        // Müşterinin satın aldığı filmler
        [HttpGet]
        public IActionResult GetAll([FromQuery]int customerId)
        {
            var result = _orderService.CustomerPurchasedList(customerId);
            if (result.Status == false)
                return BadRequest(result.Message);

            return Ok(result.ResultList);
        }
    }
}
