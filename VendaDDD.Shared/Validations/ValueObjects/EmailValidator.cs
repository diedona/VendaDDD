using FluentValidation;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Validations.ValueObjects
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(email => email.Endereco).EmailAddress();
        }
    }
}
