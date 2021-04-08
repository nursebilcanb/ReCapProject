using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(user => user.FirstName).MinimumLength(2);
            RuleFor(user => user.LastName).MinimumLength(2);
            RuleFor(user => user.Password).MinimumLength(5);

            RuleFor(user => user.Email).EmailAddress();
        }
    }
}
