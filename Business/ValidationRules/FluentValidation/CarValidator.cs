using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Aracın günlük fiyatı 0 dan büyük olmalıdır");
            RuleFor(c => c.ModelYear).MinimumLength(4).WithMessage("Aracın model yılı yıl cinsinden verilmeli");
            RuleFor(c => c.Descriptions).MinimumLength(2).WithMessage("Aracın açıklaması 2 karakterden büyük olmalı");
            
        }
    }
}
