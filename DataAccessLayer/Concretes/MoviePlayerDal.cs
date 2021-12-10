using DataAccessLayer.Abstracts;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.CustomerModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    public class MoviePlayerDal : RepositoryBase<MoviePlayer, MovieStoreDbContext>, IMoviePlayerDal
    {
        public MoviePlayer IsThere(MoviePlayerModel model)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.MoviePlayer.SingleOrDefault(mp => mp.MoviesId == model.MoviesId && mp.PlayersId == model.PlayersId);
            }
        }
    }
}
