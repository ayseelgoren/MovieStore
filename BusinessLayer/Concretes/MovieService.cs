using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.Result;
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
            //var movie = _dal.IsThere(model);
            //if (movie is null)
            //    throw new InvalidOperationException("Film sistemde mevcuttur.");

            var movie = _mapper.Map<Movie>(model);
            _dal.Add(movie);
            return new Response(true,"Film eklenmiştir.");
        }

        public ResponseList<MoviesModel> GetAll()
        {
            var listMovies = _dal.GetAll();
            if (listMovies is null)
                return new ResponseList<MoviesModel>(false, "Hata meydana geldi", null);

            List<MoviesModel> moviesModels = _mapper.Map<List<MoviesModel>>(listMovies);
            return new ResponseList<MoviesModel>(true,"Filmlar listelenmiştir.", moviesModels);
        }

        public Response Update(UpdateMovieModel model)
        {
            var movie = _mapper.Map<Movie>(model);
            movie = _dal.IsThere(movie);
            if (movie is null)
                return new Response(false, message: "Film sistemde bulunmamaktadır.");

            _dal.Update(movie);
            return new Response(true, message: "Film güncellenmiştir.");
        }

        public Response Delete(DeleteMovieModel model)
        {
            var movie = _mapper.Map<Movie>(model);
            movie = _dal.IsThere(movie);
            if (movie is null)
                return new Response(false, message: "Film sistemde bulunmamaktadır.");
            movie.Status = false;
            _dal.Update(movie);
            return new Response(true, message: "Film silinmiştir.");
        }
    }
}
