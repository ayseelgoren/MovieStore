using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.Result;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Concretes;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.DirectorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concretes
{
    public class DirectorService : IDirectorService
    {
        IDirectorDal _dal;
        public readonly IMapper _mapper;
        public DirectorService(IDirectorDal dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }
        public Response Add(DirectorModel model)
        {
            var director = _mapper.Map<Director>(model);
            var control = _dal.IsThere(director);
            if (control is not null)
                return new Response(false, message: "Yazar sistemde bulunmaktadır.");

            _dal.Add(director);
            return new Response(true, message: "Yazar eklenmiştir.");
        }

        public Response Delete(DeleteDirectorModel model)
        {
            var director = _mapper.Map<Director>(model);
            var control = _dal.IsThereId(director);
            if (control is null)
                return new Response(false, message: "Yazar sistemde bulunmamaktadır.");

            _dal.Delete(director);
            return new Response(true, message: "Yazar silinmiştir.");
        }

        public ResponseList<DirectorsModel> GetAll()
        {
            var listDirectors = _dal.GetAll();
            if (listDirectors is null)
                return new ResponseList<DirectorsModel>(false, "Hata meydana geldi", null);

            List<DirectorsModel> directorModels = _mapper.Map<List<DirectorsModel>>(listDirectors);
            return new ResponseList<DirectorsModel>(true, "Yazarlar listelenmiştir.", directorModels);
        }

        public Response Update(UpdateDirectorModel model)
        {
            var director = _mapper.Map<Director>(model);
            var control = _dal.IsThereId(director);
            if (control is null)
                return new Response(false, message: "Yazar sistemde bulunmamaktadır.");

            _dal.Update(director);
            return new Response(true, message: "Yazar güncellenmiştir.");
        }
    }
}
