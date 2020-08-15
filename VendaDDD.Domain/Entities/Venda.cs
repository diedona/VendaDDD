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

        public void SelecionarCliente(Cliente cliente)
        {
            Cliente = cliente;
        }

        public void SelecionarVendedor(Vendedor vendedor)
        {
            Vendedor = vendedor;
        }

        public void AdicionarProduto(Produto produto)
        {
            if (produto.Id == Guid.Empty)
                throw new ArgumentException("Produto inexistente");

            var produtoJaExistente = _Produtos.FirstOrDefault(x => x.Id == produto.Id);
            if (produtoJaExistente == null)
                _Produtos.Add(produtoJaExistente);
            else
                produtoJaExistente.AdicionarQuantidade(produto.QuantidadeEmMaos);
        }
    }
}
