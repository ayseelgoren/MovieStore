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
            if (result.Status == false)
                return BadRequest(result.Message);

            return Ok(result.ResultList);
        }

        [HttpPost]
        public IActionResult Insert(DirectorModel model)
        {
            var result = _directorService.Add(model);
            if (result.Status == false)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPut]
        public IActionResult Update(UpdateDirectorModel model)
        {
            var result = _directorService.Update(model);
            if (result.Status == false)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteDirectorModel model)
        {
            var result = _directorService.Delete(model);
            if (result.Status == false)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
