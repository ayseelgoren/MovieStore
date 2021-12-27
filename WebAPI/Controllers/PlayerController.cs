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
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Insert(PlayerModel model)
        {
             _playerService.Add(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UpdatePlayerModel model)
        {
             _playerService.Update(model);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(DeletePlayerModel model)
        {
            _playerService.Delete(model);
            return Ok();
        }

        // Oyuncuyu filme ekliyoruz
        [HttpPost("addMovie")]
        public IActionResult AddMovie(MoviePlayerModel model)
        {
            _playerService.AddMovie(model);
            return Ok();
        }

        // Oyuncuya ait filmleri getiriyoruz
        [HttpGet("getById")]
        public IActionResult GetById([FromQuery] int playerId)
        {
            var result = _playerService.GetById(playerId);
            return Ok(result);
        }
    }
}
