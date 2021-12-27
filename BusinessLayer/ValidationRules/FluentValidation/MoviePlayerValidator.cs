using EntitiesLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class MoviePlayerValidator : AbstractValidator<MoviePlayer>
    {
        public MoviePlayerValidator()
        {
            RuleFor(x => x.PlayersId).NotEmpty().WithMessage("Oyuncu bilgisi(id) boş geçilemez.");
            RuleFor(x => x.MoviesId).NotEmpty().WithMessage("Film bilgisi(id) boş geçilemez.");
        }
    }
}
