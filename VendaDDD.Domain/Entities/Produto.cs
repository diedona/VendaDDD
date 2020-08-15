using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDDD.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public decimal? Desconto { get; private set; }
    }
}
