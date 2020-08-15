using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendaDDD.Domain.Entities
{
    public class Venda
    {
        private readonly List<Produto> _Produtos;

        public Guid Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public Vendedor Vendedor { get; private set; }
        public IReadOnlyList<Produto> Produtos => _Produtos.AsReadOnly();
        public decimal? DescontoNaVenda { get; private set; }
        public decimal ValorTotalDescontos => DescontoNaVenda.GetValueOrDefault() + _Produtos.Sum(x => x.Desconto.GetValueOrDefault());
        public decimal ValorTotalBruto => _Produtos.Sum(x => x.ValorBruto);
        public decimal ValorTotalLiquido => ValorTotalBruto - ValorTotalDescontos;

        public Venda()
        {
            _Produtos = new List<Produto>();
        }
    }
}
