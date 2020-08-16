using System;
using System.Collections.Generic;
using System.Text;
using VendaDDD.Domain.Entities;
using VendaDDD.Domain.Enums;
using Xunit;

namespace VendaDDD.Tests.Entities
{
    public class VendaTests
    {
        [Theory]
        [InlineData(NivelVendedor.Junior, "Meia", 15.5, 1, 1)]
        [InlineData(NivelVendedor.Junior, "Meia", 15.5, 1, 1.55)]
        [InlineData(NivelVendedor.Junior, "Tenis Nike", 150.5, 2, 30)]
        [InlineData(NivelVendedor.Junior, "Tenis Nike CR", 225.75, 1, 20)]
        public void DescontoProduto_DevePermitir(NivelVendedor nivel, string nomeProduto, decimal preco, int quantidade, decimal desconto)
        {
            Vendedor vendedor = new Vendedor("Vendedor Teste", nivel);
            Venda venda = new Venda();
            Produto produto = new Produto(nomeProduto, new Preco(preco), quantidade);
            venda.AdicionarProduto(produto);
            venda.DefinirVendedor(vendedor);

            venda.DefinirDescontoProduto(produto.Id, desconto);
        }

        [Theory]
        [InlineData(NivelVendedor.Junior, "Meia", 15.5, 1, 1.8)]
        [InlineData(NivelVendedor.Junior, "Meia", 15.5, 1, 1.551)]
        [InlineData(NivelVendedor.Junior, "Tenis Nike", 150.5, 2, 50)]
        [InlineData(NivelVendedor.Junior, "Tenis Nike CR", 225.75, 1, 225.75)]
        public void DescontoProduto_DeveLancarExcecao(NivelVendedor nivel, string nomeProduto, decimal preco, int quantidade, decimal desconto)
        {
            Vendedor vendedor = new Vendedor("Vendedor Teste", nivel);
            Venda venda = new Venda();
            Produto produto = new Produto(nomeProduto, new Preco(preco), quantidade);
            venda.AdicionarProduto(produto);
            venda.DefinirVendedor(vendedor);

            Assert.Throws<ArgumentException>(() => venda.DefinirDescontoProduto(produto.Id, desconto));
        }
    }
}
