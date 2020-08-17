using System;
using System.Collections.Generic;
using System.Text;
using VendaBC.Domain.Enums;
using SharedKernel.Entities;

namespace VendaBC.Domain.Entities
{
    public class PlanoPagamento : Entity
    {
        public string Descricao { get; private set; }
        public int NumeroParcelas { get; private set; }
        public FormaPagamento FormaPagamento { get; private set; }
        public decimal? PorcentagemEntrada { get; private set; }
        public int? DiasPrimeiraParcela { get; private set; }
        public static int LimiteDiasPagamentoVista => 3;

        public PlanoPagamento(
            string descricao,
            int numeroParcelas,
            FormaPagamento formaPagamento,
            decimal? porcentagemEntrada,
            int? diasPrimeiraParcela,
            Guid? id = null) : base(id)
        {
            Descricao = descricao;
            NumeroParcelas = numeroParcelas;
            FormaPagamento = formaPagamento;
            PorcentagemEntrada = porcentagemEntrada;
            DiasPrimeiraParcela = diasPrimeiraParcela;

            if (PorcentagemEntrada.GetValueOrDefault() > 100 || PorcentagemEntrada.GetValueOrDefault() < 0)
                throw new ArgumentOutOfRangeException($"Porcentagem de entrada inválida ({PorcentagemEntrada}%)");

            if (FormaPagamento == FormaPagamento.Vista)
            {
                if (DiasPrimeiraParcela.HasValue && DiasPrimeiraParcela.Value > LimiteDiasPagamentoVista)
                    throw new ArgumentException($"Quantidade de dias para primeira parcela excedeu o limite de {LimiteDiasPagamentoVista}");

                if (PorcentagemEntrada.HasValue && PorcentagemEntrada.Value != 100m)
                    throw new ArgumentException("Plano a vista não pode conter uma porcentagem de entrada diferente de 100%");

                if (NumeroParcelas != 1)
                    throw new ArgumentException("Plano a vista não pode conter um número de parcelas diferente de 1");
            }

            if (FormaPagamento == FormaPagamento.Prazo)
            {
                if (NumeroParcelas == 1 && DiasPrimeiraParcela.HasValue && DiasPrimeiraParcela.Value <= LimiteDiasPagamentoVista)
                    throw new ArgumentException($"Quantidade de dias para primeira parcela está dentro do domínio de um plano a vista ({LimiteDiasPagamentoVista})");

                if (PorcentagemEntrada.HasValue && PorcentagemEntrada.Value == 100m)
                    throw new ArgumentException("Plano a prazo não pode conter uma porcentagem de entrada igual a 100%");
            }
        }
    }
}
