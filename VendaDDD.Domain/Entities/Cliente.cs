using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using SharedKernel.Entities;
using SharedKernel.ValueObjects;
using SharedKernel.ValueObjects.Documentos;
using VendaBC.Domain.Validations.Entities;

namespace VendaBC.Domain.Entities
{
    public class Cliente : Entity
    {
        public string NomeCompleto { get; private set; }
        public CPF CPF { get; private set; }
        public RG RG { get; private set; }
        public Email Email { get; private set; }

        public Cliente(string nomeCompleto, CPF cpf, RG rg, Email email, Guid? id = null) : base(id)
        {
            NomeCompleto = nomeCompleto;
            CPF = cpf;
            RG = rg;
            Email = email;

            _Validator = new ClienteValidator();
        }

        public override ValidationResult Validar() => _Validator.Validate(new ValidationContext<Cliente>(this));
    }
}
