using BusinessLayer.Concretes;
using EntitiesLayer.ViewModel.CustomerModel;
using EntitiesLayer.ViewModel.PlayerModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _playerService.GetAll();
            if (result.Status == false)
                return BadRequest(result);

            return Ok(result.ResultList);
        }

        [HttpPost]
        public IActionResult Insert(PlayerModel model)
        {
            var result = _playerService.Add(model);
            if (result.Status == false)
                return BadRequest(result);

            return Ok(result.Message);
        }

        [HttpPut]
        public IActionResult Update(UpdatePlayerModel model)
        {
            var result = _playerService.Update(model);
            if (result.Status == false)
                return BadRequest(result);

            return Ok(result.Message);
        }

        [HttpDelete]
        public IActionResult Delete(DeletePlayerModel model)
        {
            var result = _playerService.Delete(model);
            if (result.Status == false)
                return BadRequest(result);

            return Ok(result.Message);
        }

        // Oyuncuyu filme ekliyoruz
        [HttpPost("addMovie")]
        public IActionResult AddMovie(MoviePlayerModel model)
        {
            var result = _playerService.AddMovie(model);
            if (result.Status == false)
                return BadRequest(result);

            return Ok(result.Message);
        }

        // Oyuncuya ait filmleri getiriyoruz
        [HttpGet("getById")]
        public IActionResult GetById([FromQuery] int playerId)
        {
            var result = _playerService.GetById(playerId);
            if (result.Status == false)
                return BadRequest(result);

            return Ok(result.Entity);
        }
    }
}
