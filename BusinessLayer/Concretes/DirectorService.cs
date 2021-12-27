using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Concretes;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.DirectorModel;
using FluentValidation;
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
        public void Add(DirectorModel model)
        {
            var director = _mapper.Map<Director>(model);
            var validator = new DirectorValidator();
            validator.ValidateAndThrow(director);
            var control = _dal.IsThere(director);
            if (control is not null)
                throw new InvalidOperationException("Yazar sistemde bulunmaktadır.");

            _dal.Add(director);
        }

        public void Delete(DeleteDirectorModel model)
        {
            var director = _mapper.Map<Director>(model);
            var validator = new DirectorValidator();
            validator.ValidateAndThrow(director);
            var control = _dal.IsThereId(director);
            if (control is null)
                throw new InvalidOperationException("Yazar sistemde bulunmamaktadır.");

            _dal.Delete(director);
        }

        public List<DirectorsModel> GetAll()
        {
            var listDirectors = _dal.GetAll();
            if (listDirectors is null)
                throw new InvalidOperationException("Yazarlar bulunmamaktadır.");

            List<DirectorsModel> directorModels = _mapper.Map<List<DirectorsModel>>(listDirectors);
            return directorModels;
        }

        public void Update(UpdateDirectorModel model)
        {
            var director = _mapper.Map<Director>(model);
            var validator = new DirectorValidator();
            validator.ValidateAndThrow(director);
            var control = _dal.IsThereId(director);
            if (control is null)
                throw new InvalidOperationException("Yazar sistemde bulunmamaktadır.");

            _dal.Update(director);
        }
    }
}
