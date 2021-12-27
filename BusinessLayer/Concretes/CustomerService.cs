using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.Result;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Abstracts;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.CustomerModel;
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
        public Response Add(CreateCustomerModel model)
        {
            // Müşteri sistemde olup olmadığı kontrol edilir
            var customer = _dal.IsThere(model);
            if (customer is not null)
                return new Response(false,message:"Müşteri sistemde bulunmaktadır.",null);
          
            customer = _mapper.Map<Customer>(model);
            //Validasyon kontrolü yapılır.
            var validator = new CustomerValidator();
            var validationResult = validator.Validate(customer);
            if (!validationResult.IsValid)
                return new Response(false, message: "", errors: validationResult.Errors);

            _dal.Add(customer);
            return new Response(true, message: "Müşteri eklenmiştir.",null);
        }

        public Response Delete(DeleteCustomerModel model)
        {
            // Yazarın sistemde olup olmadığı kontrol edilir
            var customer = _dal.IsThere(model);
            if (customer is null)
                return new Response(false, message: "Müşteri sistemde bulunmamaktadır.",null);

            customer = _mapper.Map<Customer>(model);
            //Validasyon kontrolü yapılır.
            var validator = new CustomerValidator();
            var validationResult = validator.Validate(customer);
            if (!validationResult.IsValid)
                return new Response(false, message: "", errors: validationResult.Errors);

            _dal.Delete(customer);
            return new Response(true, message: "Müşteri silinmiştir.",null);

        }
    }
}
