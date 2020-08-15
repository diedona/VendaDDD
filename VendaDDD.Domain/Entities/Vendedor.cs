using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDDD.Domain.Entities
{
    public class Vendedor
    {
        public Guid Id { get; private set; }
        public string NomeCompleto { get; private set; }
    }
}
