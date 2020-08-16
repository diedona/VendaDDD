using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using VendaDDD.Domain.Entities;
using VendaDDD.Domain.Enums;
using Xunit;

namespace VendaDDD.Tests.Entities
{
    public class VendedorTests
    {
        [Fact]
        public void VendedorJunior_10PorcentoDeLimite()
        {
            Vendedor vendedor = new Vendedor("João", NivelVendedor.Junior);
            Assert.Equal(10m, vendedor.PegarLimiteDescontoPorcentagem());
        }

        [Fact]
        public void VendedorPleno_15PorcentoDeLimite()
        {
            Vendedor vendedor = new Vendedor("Almeida", NivelVendedor.Pleno);
            Assert.Equal(15m, vendedor.PegarLimiteDescontoPorcentagem());
        }

        [Fact]
        public void VendedorSenior_20PorcentoDeLimite()
        {
            Vendedor vendedor = new Vendedor("Carlos", NivelVendedor.Senior);
            Assert.Equal(20m, vendedor.PegarLimiteDescontoPorcentagem());
        }
    }
}
