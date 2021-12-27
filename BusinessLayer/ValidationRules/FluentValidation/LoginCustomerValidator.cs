using EntitiesLayer.ViewModel.CustomerModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class LoginCustomerValidator : AbstractValidator<LoginCustomerModel>
    {
        public LoginCustomerValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Mail formatına uygun değildir.")
                                 .NotEmpty().WithMessage("Mail adresi boş geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez")
                                    .Length(3,15).WithMessage("Şifre uzunluğunuz 3-15 aralığında olmalıdır.");
        }
    }
}
