using System;
using System.Collections.Generic;
using System.Text;
using VendaBC.Domain.Entities;
using VendaBC.Domain.Enums;
using Xunit;

namespace VendaBC.Tests.Entities
{
    public class PlanoPagamentoTests
    {
        [Fact]
        public void PlanoVista_EntradaMenor100_LancarExcecao()
        {
            Assert.Throws<ArgumentException>(() => new PlanoPagamento("VISTA", 1, FormaPagamento.Vista, 25.5m, null));
        }

        [Fact]
        public void PlanoVista_NumeroParcelas2_LancarExcecao()
        {
            Assert.Throws<ArgumentException>(() => new PlanoPagamento("VISTA", 2, FormaPagamento.Vista, 100m, null));
        }

        [Fact]
        public void PlanoVista_Entrada()
        {
            new PlanoPagamento("VISTA", 1, FormaPagamento.Vista, 100m, null);
        }

        [Fact]
        public void PlanoVista_Entrada_Valido()
        {
            new PlanoPagamento("VISTA", 1, FormaPagamento.Vista, null, null);
        }

        [Fact]
        public void PlanoPrazo_Entrada100_LancarExcecao()
        {
            Assert.Throws<ArgumentException>(() => new PlanoPagamento("2X CARNE", 2, FormaPagamento.Prazo, 100m, null));
        }
    }
}
