using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendaDDD.Shared.Entities;

namespace VendaDDD.Domain.Entities
{
    public class Venda : Entity
    {
        private readonly List<Produto> _Produtos;

        public Cliente Cliente { get; private set; }
        public Vendedor Vendedor { get; private set; }
        public IReadOnlyList<Produto> Produtos => _Produtos.AsReadOnly();
        public decimal? DescontoNaVenda { get; private set; }
        public decimal ValorTotalDescontos => DescontoNaVenda.GetValueOrDefault() + _Produtos.Sum(x => x.Desconto.GetValueOrDefault());
        public decimal ValorTotalBruto => _Produtos.Sum(x => x.ValorBruto);
        public decimal ValorTotalLiquido => ValorTotalBruto - ValorTotalDescontos;

        public Venda(Guid? id = null) : base(id)
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
                _Produtos.Add(produto);
            else
                produtoJaExistente.AdicionarQuantidade(produto.QuantidadeEmMaos);
        }

        public void DefinirDescontoProduto(Guid idProduto, decimal desconto)
        {
            if (Vendedor == null)
                throw new Exception("Necessário selecionar o vendedor");

            var produto = _Produtos.FirstOrDefault(x => x.Id.Equals(idProduto));
            if (produto == null)
                throw new ArgumentException($"{idProduto} não é um produto desta venda");

            decimal porcentagemDescontoProduto = ((desconto * 100.0m) / produto.ValorBruto);
            decimal limiteDescontoPorcentagemVendedor = Vendedor.PegarLimiteDescontoPorcentagem();

            if (porcentagemDescontoProduto > limiteDescontoPorcentagemVendedor)
                throw new ArgumentException($"Vendedor selecionado não pode dar desconto de {porcentagemDescontoProduto}%, limite de {limiteDescontoPorcentagemVendedor}%");

            produto.DarDesconto(desconto);
        }
    }
}
