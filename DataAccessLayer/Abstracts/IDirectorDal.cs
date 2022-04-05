using DataAccessLayer.Abstracts;
using EntitiesLayer.Models;

namespace DataAccessLayer.Concretes
{
    public interface IDirectorDal : IRepositoryBase<Director>
    {
        Director IsThere(Director model);
        Director IsThereId(Director model);
    }
}