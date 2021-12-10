using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.Result;
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
            var customer = _dal.IsThere(model);
            if (customer is not null)
                return new Response(false,message:"Müşteri sistemde bulunmaktadır.");
          
            customer = _mapper.Map<Customer>(model);
            _dal.Add(customer);
            return new Response(true, message: "Müşteri eklenmiştir.");
        }

        public Response Delete(DeleteCustomerModel model)
        {
            var customer = _dal.IsThere(model);
            if (customer is null)
                return new Response(false, message: "Müşteri sistemde bulunmamaktadır.");

            customer = _mapper.Map<Customer>(model);
            _dal.Delete(customer);
            return new Response(true, message: "Müşteri silinmiştir.");

        }
    }
}
