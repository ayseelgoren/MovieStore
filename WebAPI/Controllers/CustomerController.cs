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
            var result = _customerService.Delete(model);
            if (result.Status == false)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPost]
        public IActionResult Insert(CreateCustomerModel model)
        {
            var result = _customerService.Add(model);
            if(result.Status == false)
                return BadRequest(result.Message);
            
            return Ok(result.Message);

        }

    }
}
