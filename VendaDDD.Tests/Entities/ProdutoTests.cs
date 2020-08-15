using System;
using System.Collections.Generic;
using System.Text;
using VendaDDD.Domain.Entities;
using Xunit;

namespace VendaDDD.Tests.Entities
{
    public class ProdutoTests
    {
        [Theory]
        [InlineData("Meia", 25.5, 1, 30)]
        [InlineData("Meia", 25.5, 2, 51.01)]
        [InlineData("Sapato Nike", 45.87, 4, 184.49)]
        public void DescontoNaoPodeSerMaiorQueValorBruto(string nomeProduto, decimal valorProduto, int quantidadeEmMaos, decimal valorDesconto)
        {
            Produto meia = new Produto(nomeProduto, valorProduto, quantidadeEmMaos);
            Assert.Throws<ArgumentException>(() => meia.DarDesconto(valorDesconto));
        }

        [Theory]
        [InlineData("Meia", 25.5, 1, 12)]
        [InlineData("Meia", 25.5, 1, 25.5)]
        [InlineData("Bota Nihili", 104.14, 2, 47.28)]
        public void DescontoMenorQueValorBruto(string nomeProduto, decimal valorProduto, int quantidadeEmMaos, decimal valorDesconto)
        {
            Produto meia = new Produto(nomeProduto, valorProduto, quantidadeEmMaos);
            meia.DarDesconto(valorDesconto);
        }
    }
}
