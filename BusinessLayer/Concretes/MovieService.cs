using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Concretes;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.MovieModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concretes
{
    public class MovieService : IMovieService
    {
        IMovieDal _dal;
        public readonly IMapper _mapper;
        public MovieService(IMovieDal dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }
        public void Add(CreateMovieModel model)
        {
            var movie = _mapper.Map<Movie>(model);
            var validator = new MovieValidator();
            validator.ValidateAndThrow(movie);

            _dal.Add(movie);
        }

        public List<MoviesModel> GetAll()
        {
            var listMovies = _dal.GetAll();
            if (listMovies is null)
                throw new InvalidOperationException("Filmler bulunmamaktadır.");

            List<MoviesModel> moviesModels = _mapper.Map<List<MoviesModel>>(listMovies);
            return moviesModels;
        }

        public void Update(UpdateMovieModel model)
        {
            var movie = _mapper.Map<Movie>(model);
            var validator = new MovieValidator();
            validator.ValidateAndThrow(movie);
            movie = _dal.IsThere(movie);
            if (movie is null)
                throw new InvalidOperationException("Film sistemde bulunmamaktadır.");

            _dal.Update(movie);
        }

        public void Delete(DeleteMovieModel model)
        {
            var movie = _mapper.Map<Movie>(model);
            var validator = new MovieValidator();
            validator.ValidateAndThrow(movie);
            movie = _dal.IsThere(movie);
            if (movie is null)
                throw new InvalidOperationException("Film sistemde bulunmamaktadır.");
            movie.Status = false;
            _dal.Update(movie);
        }
    }
}
