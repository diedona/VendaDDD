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
        public void PlanoVista_EntradaMenor100_DeveSerInvalido()
        {
            var plano = new PlanoPagamento("VISTA", 1, FormaPagamento.Vista, 25.5m, null);
            Assert.False(plano.Valid);
        }

        [Fact]
        public void PlanoVista_NumeroParcelas2_DeveSerInvalido()
        {
            var plano = new PlanoPagamento("VISTA", 2, FormaPagamento.Vista, 100m, null);
            Assert.False(plano.Valid);
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
        public void PlanoPrazo_Entrada100_DeveSerInvalido()
        {
            PlanoPagamento planoPagamento = new PlanoPagamento("2X CARNE", 2, FormaPagamento.Prazo, 100m, null);
            Assert.False(planoPagamento.Valid);
        }
    }
}
