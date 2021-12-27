using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.Result;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Concretes;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.MovieModel;
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
        public Response Add(CreateMovieModel model)
        {
            var movie = _mapper.Map<Movie>(model);

            //Validasyon kontrolü yapılır.
            var validator = new MovieValidator();
            var validationResult = validator.Validate(movie);
            if (!validationResult.IsValid)
                return new Response(false, message: "", errors: validationResult.Errors);

            _dal.Add(movie);
            return new Response(true,"Film eklenmiştir.",null);
        }

        public ResponseList<MoviesModel> GetAll()
        {
            var listMovies = _dal.GetAll();
            if (listMovies is null)
                return new ResponseList<MoviesModel>(false, "Hata meydana geldi", null, null);

            List<MoviesModel> moviesModels = _mapper.Map<List<MoviesModel>>(listMovies);
            return new ResponseList<MoviesModel>(true,"Filmlar listelenmiştir.", null, moviesModels);
        }

        public Response Update(UpdateMovieModel model)
        {
            var movie = _mapper.Map<Movie>(model);

            //Validasyon kontrolü yapılır.
            var validator = new MovieValidator();
            var validationResult = validator.Validate(movie);
            if (!validationResult.IsValid)
                return new Response(false, message: "", errors: validationResult.Errors);

            // Filmin sistemde olup olmadığı kontrol edilir
            movie = _dal.IsThere(movie);
            if (movie is null)
                return new Response(false, message: "Film sistemde bulunmamaktadır.",null);

            _dal.Update(movie);
            return new Response(true, message: "Film güncellenmiştir.",null);
        }

        public Response Delete(DeleteMovieModel model)
        {
            var movie = _mapper.Map<Movie>(model);

            //Validasyon kontrolü yapılır.
            var validator = new MovieValidator();
            var validationResult = validator.Validate(movie);
            if (!validationResult.IsValid)
                return new Response(false, message: "", errors: validationResult.Errors);

            // Filmin sistemde olup olmadığı kontrol edilir
            movie = _dal.IsThere(movie);
            if (movie is null)
                return new Response(false, message: "Film sistemde bulunmamaktadır.",null);
            movie.Status = false;
            _dal.Update(movie);
            return new Response(true, message: "Film silinmiştir.",null);
        }
    }
}
