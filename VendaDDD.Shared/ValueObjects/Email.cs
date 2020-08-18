using FluentValidation;
using FluentValidation.Results;
using SharedKernel.Validations.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.ValueObjects
{
    public class Email : ValueObject
    {
        public string Endereco { get; private set; }

        public Email(string endereco)
        {
            Endereco = endereco;
            _Validator = new EmailValidator();
        }

        public override ValidationResult EstaValido() => _Validator.Validate(new ValidationContext<Email>(this));
    }
}
