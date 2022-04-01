using DataAccessLayer.Abstracts;
using EntitiesLayer.Models;

namespace DataAccessLayer.Concretes
{
    public interface IWriterDal : IRepositoryBase<Writer>
    {
        Writer IsThere(Writer model);
        Writer IsThereId(Writer model);
    }
}