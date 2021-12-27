using BusinessLayer.Abstracts;
using EntitiesLayer.ViewModel.CustomerModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult Login(LoginCustomerModel model)
        {
            var result = _authenticationService.Login(model);
            return Ok(result);

        }
    }
}
