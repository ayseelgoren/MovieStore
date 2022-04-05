using EntitiesLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    public class DirectorDal : RepositoryBase<Director, MovieStoreDbContext>, IDirectorDal
    {

        public override List<Director> GetAll()
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Set<Director>().Include(m => m.Movies).ThenInclude(x =>x.Genre).ToList();
            }
        }

        public Director IsThere(Director model)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Directors.SingleOrDefault(x => x.Name == model.Name && x.Surname == model.Surname);
            }
        }

        public Director IsThereId(Director model)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Directors.SingleOrDefault(x => x.Id == model.Id);
            }
        }
    }
}
