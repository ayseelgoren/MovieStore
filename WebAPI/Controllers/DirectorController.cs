using BusinessLayer.Concretes;
using EntitiesLayer.ViewModel.DirectorModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {

        private readonly IDirectorService _directorService;
        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _directorService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Insert(DirectorModel model)
        {
            _directorService.Add(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UpdateDirectorModel model)
        {
            _directorService.Update(model);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(DeleteDirectorModel model)
        {
            _directorService.Delete(model);
            return Ok();
        }
    }
}
