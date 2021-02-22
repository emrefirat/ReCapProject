using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.Name).MinimumLength(3);
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(50).WithMessage("Gunluk Bedel 50'den Az olamaz");
            RuleFor(p => p.Name).Must(StartWithA).WithMessage("Arac Ismi A harfi ile baslamali");


        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }

}
