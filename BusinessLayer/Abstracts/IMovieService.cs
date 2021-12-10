using BusinessLayer.Abstracts;
using BusinessLayer.Result;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.MovieModel;

namespace BusinessLayer.Concretes
{
    public interface IMovieService
    {
        Response Add(CreateMovieModel model);
        ResponseList<MoviesModel> GetAll();
        Response Update(UpdateMovieModel model);
        Response Delete(DeleteMovieModel model);
    }
}