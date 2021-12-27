using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Abstracts;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.CustomerModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concretes
{
    public class CustomerService : ICustomerService
    {
        ICustomerDal _dal;
        public readonly IMapper _mapper;
        public CustomerService(ICustomerDal dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }
        public void Add(CreateCustomerModel model)
        {
            var customer = _dal.IsThere(model);
            if (customer is not null)
                throw new InvalidOperationException("Müşteri sistemde bulunmaktadır.");
          
            customer = _mapper.Map<Customer>(model);
            var validator = new CustomerValidator();
            validator.ValidateAndThrow(customer);
            _dal.Add(customer);
        }

        public void Delete(DeleteCustomerModel model)
        {
            var customer = _dal.IsThere(model);
            if (customer is null)
                throw new InvalidOperationException("Müşteri sistemde bulunmamaktadır.");

            customer = _mapper.Map<Customer>(model);
            var validator = new CustomerValidator();
            validator.ValidateAndThrow(customer);
            _dal.Delete(customer);

        }
    }
}
