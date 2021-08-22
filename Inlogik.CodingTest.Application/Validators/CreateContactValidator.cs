using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Inlogik.CodingTest.Application.Dtos;

namespace Inlogik.CodingTest.Application.Validators
{
    public class CreateContactValidator : ContactValidatorBase<CreateContactDto>
    {
        public CreateContactValidator()
        {
        }
    }
}
