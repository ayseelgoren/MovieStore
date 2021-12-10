using DataAccessLayer.Abstracts;
using EntitiesLayer.Models;

namespace DataAccessLayer.Concretes
{
    public interface IPlayerDal : IRepositoryBase<Player>
    {
        Player IsThere(Player model);
        Player IsThereId(Player model);
        Player GetById(int playerId);
    }
}