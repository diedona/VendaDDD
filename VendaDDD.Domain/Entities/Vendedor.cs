using System;
using System.Collections.Generic;
using System.Text;
using VendaBC.Domain.Enums;
using SharedKernel.Entities;
using FluentValidation.Results;

namespace VendaBC.Domain.Entities
{
    public class Vendedor : Entity
    {
        public string NomeCompleto { get; private set; }
        public NivelVendedor Nivel { get; private set; }

        public Vendedor(string nomeCompleto, NivelVendedor nivel, Guid? id = null) : base(id)
        {
            NomeCompleto = nomeCompleto;
            Nivel = nivel;
        }

        public decimal PegarLimiteDescontoPorcentagem()
        {
            switch (Nivel)
            {
                case NivelVendedor.Junior:
                    return 10m;
                case NivelVendedor.Pleno:
                    return 15m;
                case NivelVendedor.Senior:
                    return 20m;
                default:
                    throw new Exception("Nível desconhecido");
            }
        }

        public override ValidationResult Validar()
        {
            throw new NotImplementedException();
        }
    }
}
