using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:  AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(t=>t.CarName).MinimumLength(2);
            RuleFor(t => t.DailyPrice).GreaterThan(0);
            RuleFor(t => t.DailyPrice).GreaterThanOrEqualTo(600).When(t=>t.BrandId==2);
            RuleFor(t => t.CarName).Must(StartWithA).WithMessage("Araçlar A Harfi ile başlamalı");


        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
