using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDDD.Domain.Entities
{
    public class Vendedor
    {
        public Guid Id { get; private set; }
        public string NomeCompleto { get; private set; }

        public Vendedor(string nomeCompleto, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            NomeCompleto = nomeCompleto;
        }
    }
}
