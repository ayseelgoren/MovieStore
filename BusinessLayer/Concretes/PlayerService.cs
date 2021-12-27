using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.Result;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Concretes;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.CustomerModel;
using EntitiesLayer.ViewModel.PlayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concretes
{
    public class PlayerService : IPlayerService
    {
        IPlayerDal _playerDal;
        IMoviePlayerDal _moviePlayerDal;
        public readonly IMapper _mapper;
        public PlayerService(IPlayerDal playerDal, IMoviePlayerDal moviePlayerDal, IMapper mapper)
        {
            _playerDal = playerDal;
            _moviePlayerDal = moviePlayerDal;
            _mapper = mapper;
        }
        public Response Add(PlayerModel model)
        {
            var player = _mapper.Map<Player>(model);
            var validator = new PlayerValidator();
            var validationResult = validator.Validate(player);

            if (!validationResult.IsValid)
                return new Response(false, message:"",errors:validationResult.Errors);

            var control = _playerDal.IsThere(player);
            if (control is not null)
                return new Response(false, message: "Oyuncu sistemde bulunmaktadır.",errors:null);

            _playerDal.Add(player);
            return new Response(true, message: "Oyuncu eklenmiştir.", errors: null);
        }

        public Response Delete(DeletePlayerModel model)
        {
            var player = _mapper.Map<Player>(model);
            var control = _playerDal.IsThereId(player);
            if (control is null)
                return new Response(false, message: "Oyuncu sistemde bulunmamaktadır.", errors: null);

            _playerDal.Delete(player);
            return new Response(true, message: "Oyuncu silinmiştir.", errors: null);
        }

        public ResponseList<PlayersModel> GetAll()
        {
            var listDirectors = _playerDal.GetAll();
            if (listDirectors is null)
                return new ResponseList<PlayersModel>(false, "Hata meydana geldi", null, null);

            List<PlayersModel> directorModels = _mapper.Map<List<PlayersModel>>(listDirectors);
            return new ResponseList<PlayersModel>(true, "Oyuncular listelenmiştir.", null, directorModels);
        }

        public Response Update(UpdatePlayerModel model)
        {
            var player = _mapper.Map<Player>(model);
            // Validasyon kontrolü yapılır
            var validator = new PlayerValidator();
            var validationResult = validator.Validate(player);
            if (!validationResult.IsValid)
                return new Response(false, message: "", errors: validationResult.Errors);
            // Oyuncunun sistemde varlığı kontrol edilir
            var control = _playerDal.IsThereId(player);
            if (control is null)
                return new Response(false, message: "Oyuncu sistemde bulunmamaktadır.", errors: null);

            _playerDal.Update(player);
            return new Response(true, message: "Oyuncu güncellenmiştir.", errors: null);
        }

        public Response AddMovie(MoviePlayerModel model)
        {
            // Oyuncunun filmde oynayıp oynamadığı kontrol edilir
            var control = _moviePlayerDal.IsThere(model);
            if(control is not null)
                return new Response(false, message: "Oyuncu zaten filmde oynamaktadır.", errors: null);

            var moviePlayer = _mapper.Map<MoviePlayer>(model);
            //Validasyon kontrolü yapılır.
            var validator = new MoviePlayerValidator();
            var validationResult = validator.Validate(moviePlayer);
            if (!validationResult.IsValid)
                return new Response(false, message: "", errors: validationResult.Errors);

            _moviePlayerDal.Add(moviePlayer);
            return new Response(true, message: "Oyuncu filme eklenmiştir.", errors: null);

        }

        public ResponseEntity<PlayersModel> GetById(int playerId)
        {
            var player = _playerDal.GetById(playerId);
            if (player is null)
                return new ResponseEntity<PlayersModel>(false, "Hata meydana geldi", null, null);

            PlayersModel playerModels = _mapper.Map<PlayersModel>(player);
            return new ResponseEntity<PlayersModel>(true, "Oyuncu bilgileri listelenmiştir.", null, playerModels);
        }
    }
}
