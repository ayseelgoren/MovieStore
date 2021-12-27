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
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Insert(CreateMovieModel model)
        {
            _movieService.Add(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UpdateMovieModel model)
        {
            _movieService.Update(model);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(DeleteMovieModel model)
        {
            _movieService.Delete(model);
            return Ok();
        }
    }
}
