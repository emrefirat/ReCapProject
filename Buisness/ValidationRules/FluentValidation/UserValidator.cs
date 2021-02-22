using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(us => us.FirstName).NotEmpty();
            RuleFor(us => us.LastName).NotEmpty();
            RuleFor(us => us.Password).NotEmpty();
            RuleFor(us => us.Email).EmailAddress();
            RuleFor(us => us.Password).MinimumLength(5);

        }
    }
}
