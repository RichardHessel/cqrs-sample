using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.Commands.User;

namespace Users.Domain.Validations.User
{
    public class CreateUserValidation : UserValidation<CreateUserCommand>
    {
        public CreateUserValidation()
        {
            ValidateName();
            ValidateEmail();
            ValidatePassword();
        }

        protected void ValidatePassword()
        {
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("PASS_EMPTY")
                .Length(8, 350).WithMessage("PASS_LENGTH_INVALID");
        }
    }
}
