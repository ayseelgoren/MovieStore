using EntitiesLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    public class OrderDal : RepositoryBase<Order, MovieStoreDbContext>, IOrderDal
    {
        public List<Order> GetAllCustomer(int customerId)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Set<Order>().Include(g => g.Movie).Include(p => p.Customer).Where(x => x.CustomerId == customerId).ToList();
            }
        }
        public override List<Order> GetAll()
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                return context.Set<Order>().Include(g => g.Movie).ThenInclude(g=>g.Genre)
                                           .Include(g => g.Movie).ThenInclude(d=>d.Director)
                                           .Include(g => g.Movie).ThenInclude(d=>d.Players).ThenInclude(d => d.Players)
                                           .Include(p => p.Customer).ToList();
            }
        }
    }
}
