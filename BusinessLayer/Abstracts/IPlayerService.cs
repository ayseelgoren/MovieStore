using BusinessLayer.Abstracts;
using BusinessLayer.Result;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.CustomerModel;
using EntitiesLayer.ViewModel.PlayerModel;

namespace BusinessLayer.Concretes
{
    public interface IPlayerService
    {
        Response Add(PlayerModel model);
        ResponseList<PlayersModel> GetAll();
        Response Update(UpdatePlayerModel model);
        Response Delete(DeletePlayerModel model);
        Response AddMovie(MoviePlayerModel model);
        ResponseEntity<PlayersModel> GetById(int playerId);
    }
}