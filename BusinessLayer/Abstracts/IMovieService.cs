using BusinessLayer.Abstracts;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.MovieModel;

namespace BusinessLayer.Concretes
{
    public interface IMovieService
    {
        void Add(CreateMovieModel model);
        List<MoviesModel> GetAll();
        void Update(UpdateMovieModel model);
        void Delete(DeleteMovieModel model);
    }
}