﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator  : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.Description.Length).GreaterThan(2);

            RuleFor(c => c.FindexPoint).GreaterThanOrEqualTo(0);
            RuleFor(c => c.FindexPoint).LessThanOrEqualTo(1900);

        }
    }
}
