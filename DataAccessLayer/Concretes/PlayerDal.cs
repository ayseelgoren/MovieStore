using DataAccessLayer.Abstracts;
using EntitiesLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    public class PlayerDal : RepositoryBase<Player, MovieStoreDbContext>, IPlayerDal
    {
        public override List<Player> GetAll()
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Players.Include(pm => pm.PlayerMovies).ThenInclude(m=>m.Movies).ToList();
            }
        }
        public Player GetById(int playerId)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Players.Where(x => x.Id == playerId).Include(pm => pm.PlayerMovies).ThenInclude(m => m.Movies).FirstOrDefault();
            }
        }

        public Player IsThere(Player model)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Players.SingleOrDefault(x => x.Name == model.Name && x.Surname == model.Surname);
            }
        }

        public Player IsThereId(Player model)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Players.SingleOrDefault(x => x.Id == model.Id);
            }
        }
    }
}
