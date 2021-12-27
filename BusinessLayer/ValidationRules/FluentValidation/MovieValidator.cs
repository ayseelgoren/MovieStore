using EntitiesLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m=>m.Name).NotEmpty().WithMessage("Film ismi boş geçilemez.")
                                .Length(3, 25).WithMessage("Karakter uzunluğu 1-15 aralığında olmalıdır.");

            RuleFor(m => m.GenreId).NotEmpty().WithMessage("Film türü boş geçilemez.");

            RuleFor(m=>m.Price).NotEmpty().WithMessage("Film ismi boş geçilemez.")
                               .GreaterThan(0).WithMessage("Fiyat 0 dan büyük olmalıdır.");

            RuleFor(m=>m.DirectorId).NotEmpty().WithMessage("Filmin yazarı boş geçilemez.");

        }
    }
}
