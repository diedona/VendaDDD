using FluentValidation;
using SharedKernel.Validations.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using VendaBC.Domain.Entities;

namespace VendaBC.Domain.Validations.Entities
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Email).SetValidator(new EmailValidator());
        }
    }
}
