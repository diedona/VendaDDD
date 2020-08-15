using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDDD.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public string Email { get; private set; }
    }
}
