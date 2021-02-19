﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator :AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName.Length).GreaterThan(2);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.EMail).NotEmpty();
        }
    }
}
