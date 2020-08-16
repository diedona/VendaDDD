using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using VendaDDD.Domain.Entities;
using VendaDDD.Domain.Enums;
using Xunit;

namespace VendaDDD.Tests.Entities
{
    public class ProdutoTests
    {
        [Theory]
        [InlineData("Meia", 25.5, 1, 30)]
        [InlineData("Meia", 25.5, 2, 51.01)]
        [InlineData("Sapato Nike", 45.87, 4, 184.49)]
        public void LancarExcecao_DescontoMaiorQueValorBruto(string nomeProduto, decimal valorProduto, int quantidadeEmMaos, decimal valorDesconto)
        {
            Produto meia = new Produto(nomeProduto, new Preco(valorProduto), quantidadeEmMaos);
            Assert.Throws<ArgumentException>(() => meia.DarDesconto(valorDesconto));
        }

        [Theory]
        [InlineData("Meia", 25.5, 1, 12)]
        [InlineData("Meia", 25.5, 1, 25.5)]
        [InlineData("Bota Nihili", 104.14, 2, 47.28)]
        public void NaoLancarExcecao_DescontoMenorQueValorBruto(string nomeProduto, decimal valorProduto, int quantidadeEmMaos, decimal valorDesconto)
        {
            Produto meia = new Produto(nomeProduto, new Preco(valorProduto), quantidadeEmMaos);
            meia.DarDesconto(valorDesconto);
        }

        [Theory]
        [ClassData(typeof(DadosPreco_DeveUsarPrecoVenda))]
        public void Preco_DeveUsarPrecoVenda(decimal precoVenda, decimal? precoVista, decimal? precoPrazo)
        {
            Preco preco = new Preco(precoVenda, precoVista, precoPrazo);
            Produto produto = new Produto("Meia Branca", preco, 1);

            Assert.Equal(preco.PrecoVenda, produto.PegarPrecoPeloPlano());
        }

        [Theory]
        [ClassData(typeof(DadosPreco_DeveUsarPrecoVista))]
        public void Preco_DeveUsarPrecoVista(decimal precoVenda, decimal? precoVista, decimal? precoPrazo)
        {
            Venda venda = new Venda();
            Preco preco = new Preco(precoVenda, precoVista, precoPrazo);
            Produto produto = new Produto("Meia Branca", preco, 1);
            PlanoPagamento pagamento = new PlanoPagamento("vista", 1, FormaPagamento.Vista, null, null);

            venda.AdicionarProduto(produto);
            venda.DefinirPlanoPagamento(pagamento);

            Assert.Equal(preco.PrecoVista.Value, produto.PegarPrecoPeloPlano());
        }
    }

    public class DadosPreco_DeveUsarPrecoVenda : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {15.5m, 12.0m, null},
            new object[] {150m, null, 180m}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class DadosPreco_DeveUsarPrecoVista : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {15.5m, 12.0m, null},
            new object[] {150m, 150m, 180m}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
