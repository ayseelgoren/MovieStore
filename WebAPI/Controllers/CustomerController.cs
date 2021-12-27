using BusinessLayer.Abstracts;
using BusinessLayer.Concretes;
using EntitiesLayer.ViewModel.CustomerModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpDelete]
        public IActionResult Delete(DeleteCustomerModel model)
        {
            _customerService.Delete(model);
            return Ok();
        }

        [HttpPost]
        public IActionResult Insert(CreateCustomerModel model)
        {
            _customerService.Add(model);
            return Ok();

        }

    }
}
