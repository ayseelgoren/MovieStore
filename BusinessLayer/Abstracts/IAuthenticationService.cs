using BusinessLayer.TokenOperation.Models;
using EntitiesLayer.ViewModel.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface IAuthenticationService
    {
         Task<Token> Login(LoginCustomerModel model);
    }
}
