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

        public Produto(string descricao, decimal preco, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Descricao = descricao;
            Preco = preco;
        }
    }
}
