using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
     {
        public CarValidator() {
            RuleFor(c => c.DailyPrice).NotEmpty();

            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c=> c.BrandId).NotEmpty();
            RuleFor(c => c.ModelYear).Must(Min).WithMessage("En az 2015 model olacaktır");

        }

        private bool Min(int arg)
        {
            return arg >= 2015;
        }
    }
}
