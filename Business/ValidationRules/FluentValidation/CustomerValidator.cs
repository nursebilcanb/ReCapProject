using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator :AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.UserId).NotEmpty();

            RuleFor(customer => customer.FindexPoint).GreaterThan(0);
            RuleFor(customer => customer.FindexPoint).LessThanOrEqualTo(1900);
        }
    }
}
