using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.Commands.User;

namespace Users.Domain.Validations
{
    public class UserValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        protected void ValidateName()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("NAME_EMPTY")
                .Length(3, 50).WithMessage("NAME_LENGTH_INVALID");
        }

        protected void ValidateEmail()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("EMAIL_EMPTY")
                .Length(3, 50).WithMessage("EMAIL_LENGTH_INVALID");
        }

    }
}
