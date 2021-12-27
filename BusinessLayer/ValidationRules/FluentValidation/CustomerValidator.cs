using EntitiesLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("İsim boş geçilemez.")
                                .Length(1, 15).WithMessage("Karakter uzunluğu 1-15 aralığında olmalıdır.");

            RuleFor(c => c.Surname).NotEmpty().WithMessage("Soyisim boş geçilemez.")
                                   .Length(1, 15).WithMessage("Karakter uzunluğu 1-15 aralığında olmalıdır.");

            RuleFor(c => c.Email).EmailAddress().WithMessage("Mail adresi mail formatına uygun olmalıdır.")
                                 .NotEmpty().WithMessage("Mail adresi boş geçilemez.");

            RuleFor(c => c.Password).NotEmpty().WithMessage("Şifre boş geçilemez.")
                                    .Length(4, 15).WithMessage("Karakter uzunluğu 4-15 aralığında olmalıdır.");
        }
    }
}
