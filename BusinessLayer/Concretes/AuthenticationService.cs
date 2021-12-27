using AutoMapper;
using BusinessLayer.Abstracts;
using BusinessLayer.Result;
using BusinessLayer.TokenOperation;
using BusinessLayer.TokenOperation.Models;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Abstracts;
using EntitiesLayer.ViewModel.CustomerModel;
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

        public AuthenticationService(ICustomerDal dal, IMapper mapper, IConfiguration configuration)
        {
            _dal = dal;
            _mapper = mapper;
            _configuration = configuration;
        }
        public ResponseEntity<Token> Login(LoginCustomerModel model)
        {
            // Validasyon kontrolü yapılır.
            var validator = new LoginCustomerValidator();
            var validationResult = validator.Validate(model);
            if (!validationResult.IsValid)
                return new ResponseEntity<Token>(false, message: "",validationResult.Errors,null);

            // Müşterinin sistemde var olup-olmadığının kontrol edilmesi
            var user = _dal.IsThereCustomer(model);
            if (user != null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dal.Update(user);
                return new ResponseEntity<Token>(true,"Token üretildi.", null, token);
            }
            else
            {
                return new ResponseEntity<Token>(false, "Kullanıcı adı-şifre hatalı.", null, null);
            }
        }
    }
}
