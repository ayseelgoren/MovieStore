using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Concretes;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.WriterModel;
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
            var writer = _mapper.Map<Director>(model);
            var validator = new DirectorValidator();
            validator.ValidateAndThrow(writer);
            var control = _dal.IsThere(writer);
            if (control is not null)
                throw new InvalidOperationException("Yazar sistemde bulunmaktadır.");

            _dal.Add(writer);
        }

        public void Delete(DeleteDirectorModel model)
        {
            var writer = _mapper.Map<Director>(model);
            var validator = new DirectorValidator();
            validator.ValidateAndThrow(writer);
            var control = _dal.IsThereId(writer);
            if (control is null)
                throw new InvalidOperationException("Yazar sistemde bulunmamaktadır.");

            _dal.Delete(writer);
        }

        public List<DirectorsModel> GetAll()
        {
            var listWriter= _dal.GetAll();
            if (listWriter is null)
                throw new InvalidOperationException("Yazarlar bulunmamaktadır.");

            List<DirectorsModel> writerModels = _mapper.Map<List<DirectorsModel>>(listWriter);
            return writerModels;
        }

        public void Update(UpdateDirectorModel model)
        {
            var writer = _mapper.Map<Director>(model);
            var validator = new DirectorValidator();
            validator.ValidateAndThrow(writer);
            var control = _dal.IsThereId(writer);
            if (control is null)
                throw new InvalidOperationException("Yazar sistemde bulunmamaktadır.");

            _dal.Update(writer);
        }
    }
}
