using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.Result;
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
            var control = _playerDal.IsThere(player);
            if (control is not null)
                return new Response(false, message: "Oyuncu sistemde bulunmaktadır.");

            _playerDal.Add(player);
            return new Response(true, message: "Oyuncu eklenmiştir.");
        }

        public Response Delete(DeletePlayerModel model)
        {
            var player = _mapper.Map<Player>(model);
            var control = _playerDal.IsThereId(player);
            if (control is null)
                return new Response(false, message: "Oyuncu sistemde bulunmamaktadır.");

            _playerDal.Delete(player);
            return new Response(true, message: "Oyuncu silinmiştir.");
        }

        public ResponseList<PlayersModel> GetAll()
        {
            var listDirectors = _playerDal.GetAll();
            if (listDirectors is null)
                return new ResponseList<PlayersModel>(false, "Hata meydana geldi", null);

            List<PlayersModel> directorModels = _mapper.Map<List<PlayersModel>>(listDirectors);
            return new ResponseList<PlayersModel>(true, "Oyuncular listelenmiştir.", directorModels);
        }

        public Response Update(UpdatePlayerModel model)
        {
            var player = _mapper.Map<Player>(model);
            var control = _playerDal.IsThereId(player);
            if (control is null)
                return new Response(false, message: "Oyuncu sistemde bulunmamaktadır.");

            _playerDal.Update(player);
            return new Response(true, message: "Oyuncu güncellenmiştir.");
        }

        public Response AddMovie(MoviePlayerModel model)
        {
            var control = _moviePlayerDal.IsThere(model);
            if(control is not null)
                return new Response(false, message: "Oyuncu zaten filmde oynamaktadır.");
            var moviePlayer = _mapper.Map<MoviePlayer>(model);

            _moviePlayerDal.Add(moviePlayer);
            return new Response(true, message: "Oyuncu filme eklenmiştir.");

        }

        public ResponseEntity<PlayersModel> GetById(int playerId)
        {
            var player = _playerDal.GetById(playerId);
            if (player is null)
                return new ResponseEntity<PlayersModel>(false, "Hata meydana geldi", null);

            PlayersModel playerModels = _mapper.Map<PlayersModel>(player);
            return new ResponseEntity<PlayersModel>(true, "Oyuncu bilgileri listelenmiştir.", playerModels);
        }
    }
}
