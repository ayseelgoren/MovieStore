using BusinessLayer.Abstracts;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.CustomerModel;
using EntitiesLayer.ViewModel.PlayerModel;

namespace BusinessLayer.Concretes
{
    public interface IPlayerService
    {
        void Add(PlayerModel model);
        List<PlayersModel> GetAll();
        void Update(UpdatePlayerModel model);
        void Delete(DeletePlayerModel model);
        void AddMovie(MoviePlayerModel model);
        PlayersModel GetById(int playerId);
    }
}