using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VendaBC.Domain.Entities;

namespace VendaBC.Domain.Validations.Entities
{
    public class PlanoPagamentoValidator : AbstractValidator<PlanoPagamento>
    {
        public PlanoPagamentoValidator()
        {

        }
    }
}
