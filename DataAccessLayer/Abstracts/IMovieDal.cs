using DataAccessLayer.Abstracts;
using EntitiesLayer.Models;

namespace DataAccessLayer.Concretes
{
    public interface IMovieDal : IRepositoryBase<Movie>
    {
        Movie IsThere(Movie model);
        Movie IsThereId(int modelId);
    }
}