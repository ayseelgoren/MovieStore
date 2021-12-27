using BusinessLayer.Concretes;
using EntitiesLayer.ViewModel.MovieModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _movieService.GetAll();
            if (result.Status == false)
                return BadRequest(result);

            return Ok(result.ResultList);
        }

        [HttpPost]
        public IActionResult Insert(CreateMovieModel model)
        {
            var result = _movieService.Add(model);
            if (result.Status == false)
                return BadRequest(result);

            return Ok(result.Message);
        }

        [HttpPut]
        public IActionResult Update(UpdateMovieModel model)
        {
            var result = _movieService.Update(model);
            if (result.Status == false)
                return BadRequest(result);

            return Ok(result.Message);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteMovieModel model)
        {
            var result = _movieService.Delete(model);
            if (result.Status == false)
                return BadRequest(result);

            return Ok(result.Message);
        }
    }
}
