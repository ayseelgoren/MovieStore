using EntitiesLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class DirectorValidator : AbstractValidator<Director>
    {
        public DirectorValidator()
        {
            RuleFor(d => d.Name).NotEmpty().WithMessage("İsim boş geçilemez.")
                                .Length(1,15).WithMessage("Karakter uzunluğu 1-15 aralığında olmalıdır.");
            RuleFor(d => d.Surname).NotEmpty().WithMessage("Soyisim boş geçilemez.")
                                   .Length(1, 15).WithMessage("Karakter uzunluğu 1-15 aralığında olmalıdır.");

        }
    }
}
