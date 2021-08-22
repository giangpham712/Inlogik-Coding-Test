using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Inlogik.CodingTest.Application.Dtos;
using Inlogik.CodingTest.Core.Extensions;

namespace Inlogik.CodingTest.Application.Validators
{
    public abstract class ContactValidatorBase<T> : AbstractValidator<T> where T : ContactDtoBase
    {
        
        protected ContactValidatorBase()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(user => user.Email)
                .Must(email => email.IsValidEmail()).WithMessage("Provided email address has invalid format.");
        }
    }
}
