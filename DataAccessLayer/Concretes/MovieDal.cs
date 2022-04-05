using EntitiesLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    public class MovieDal : RepositoryBase<Movie,MovieStoreDbContext>, IMovieDal
    {

        public override List<Movie> GetAll()
        {
            using (MovieStoreDbContext context=new MovieStoreDbContext())
            {
                return context.Set<Movie>().Include(g => g.Genre).Include(mp=>mp.Players).ThenInclude(p => p.Players).Include(d=>d.Director).Where(x=>x.Status == true).ToList();
            }
        }
        public Movie IsThere(Movie model)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Movies.SingleOrDefault(x => x.Id == model.Id && x.Status == true);
            }
        }

        public Movie IsThereId(int modelId)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Movies.SingleOrDefault(x => x.Id == modelId && x.Status == true);
            }
        }
    }
}
