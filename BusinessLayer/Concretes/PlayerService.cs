using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Concretes;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.CustomerModel;
using EntitiesLayer.ViewModel.PlayerModel;
using FluentValidation;
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
        public void Add(PlayerModel model)
        {
            var player = _mapper.Map<Player>(model);
            var validator = new PlayerValidator();
            validator.ValidateAndThrow(player);

            var control = _playerDal.IsThere(player);
            if (control is not null)
                throw new InvalidOperationException("Oyuncu sistemde bulunmaktadır.");

            _playerDal.Add(player);
        }

        public void Delete(DeletePlayerModel model)
        {
            var player = _mapper.Map<Player>(model);
            var control = _playerDal.IsThereId(player);
            if (control is null)
                throw new InvalidOperationException("Oyuncu sistemde bulunmamaktadır.");

            _playerDal.Delete(player);
        }

        public List<PlayersModel> GetAll()
        {
            var listDirectors = _playerDal.GetAll();
            if (listDirectors is null)
               throw new InvalidOperationException("Hata meydana geldi");

            List<PlayersModel> directorModels = _mapper.Map<List<PlayersModel>>(listDirectors);
            return directorModels;
        }

        public void Update(UpdatePlayerModel model)
        {
            var player = _mapper.Map<Player>(model);
            var validator = new PlayerValidator();
            validator.ValidateAndThrow(player);

            var control = _playerDal.IsThereId(player);
            if (control is null)
                throw new InvalidOperationException("Oyuncu sistemde bulunmamaktadır.");

            _playerDal.Update(player);
        }

        public void AddMovie(MoviePlayerModel model)
        {

            var moviePlayer = _mapper.Map<MoviePlayer>(model);
            var validator = new MoviePlayerValidator();
            validator.ValidateAndThrow(moviePlayer);

            var control = _moviePlayerDal.IsThere(model);
            if (control is not null)
                throw new InvalidOperationException("Oyuncu zaten filmde oynamaktadır.");

            _moviePlayerDal.Add(moviePlayer);
        }

        public PlayersModel GetById(int playerId)
        {
            var player = _playerDal.GetById(playerId);
            if (player is null)
                throw new InvalidOperationException("Böyle bir oyuncu bulunmamaktadır.");

            PlayersModel playerModels = _mapper.Map<PlayersModel>(player);
            return playerModels;
        }
    }
}
