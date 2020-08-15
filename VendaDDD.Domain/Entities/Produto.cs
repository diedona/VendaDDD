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
        public int QuantidadeEmMaos { get; private set; }
        public decimal ValorBruto => Preco * QuantidadeEmMaos;
        public decimal ValorLiquido => ValorBruto - Desconto.GetValueOrDefault();

        public Produto(string descricao, decimal preco, int quantidadeEmMaos, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Descricao = descricao;
            Preco = preco;
            QuantidadeEmMaos = quantidadeEmMaos;
        }

        public void DarDesconto(decimal desconto)
        {
            if (desconto > ValorBruto)
                throw new ArgumentException("Desconto maior que o valor bruto do produto!");

            Desconto = desconto;
        }
    }
}
