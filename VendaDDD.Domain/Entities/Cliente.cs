using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using SharedKernel.Entities;
using SharedKernel.ValueObjects;
using SharedKernel.ValueObjects.Documentos;

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
        }

        public override ValidationResult Validar()
        {
            throw new NotImplementedException();
        }
    }
}
