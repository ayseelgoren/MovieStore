using EntitiesLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    public class WriterDal : RepositoryBase<Writer, MovieStoreDbContext>, IWriterDal
    {

        public override List<Writer> GetAll()
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Set<Writer>().Include(m => m.Movies).ThenInclude(p=>p.MoviePlayers).Include(m => m.Movies).ThenInclude(x =>x.Genre).ToList();
            }
        }

        public Writer IsThere(Writer model)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Writers.SingleOrDefault(x => x.Name == model.Name && x.Surname == model.Surname);
            }
        }

        public Writer IsThereId(Writer model)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Writers.SingleOrDefault(x => x.Id == model.Id);
            }
        }
    }
}
