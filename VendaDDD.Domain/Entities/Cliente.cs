using System;
using System.Collections.Generic;
using System.Text;
using VendaDDD.Shared.ValueObjects;
using VendaDDD.Shared.ValueObjects.Documentos;

namespace VendaDDD.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public CPF CPF { get; private set; }
        public RG RG { get; private set; }
        public Email Email { get; private set; }

        public Cliente(string nomeCompleto, CPF cpf, RG rg, Email email, Guid? id = null)
        {
            NomeCompleto = nomeCompleto;
            CPF = cpf;
            RG = rg;
            Email = email;

            Id = id ?? Guid.NewGuid();
        }
    }
}
