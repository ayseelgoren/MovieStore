using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.TokenOperation;
using BusinessLayer.TokenOperation.Models;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer;
using DataAccessLayer.Abstracts;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.CustomerModel;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concretes
{
    public class AuthenticationService : IAuthenticationService
    {
        ICustomerDal _dal;
        public readonly IMapper _mapper;
        public IConfiguration _configuration;
       private MovieStoreDbContext _context = new();
        public AuthenticationService(ICustomerDal dal, IMapper mapper, IConfiguration configuration)
        {
            _dal = dal;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<Token> Login(LoginCustomerModel model)
        {
            var validator = new LoginCustomerValidator();
            validator.ValidateAndThrow(model);
            var currentModel = _dal.IsThereCustomer(model);
            if (currentModel != null)
            {
                var updatedModel = new Customer();
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(currentModel);
                updatedModel.RefreshToken = token.RefreshToken;
                updatedModel.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                await _context.SaveChangesAsync();
                return token;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı adı-şifre hatalı.");
            }
        }
    }
}
