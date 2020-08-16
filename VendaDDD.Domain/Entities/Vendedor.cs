using System;
using System.Collections.Generic;
using System.Text;
using VendaDDD.Domain.Enums;

namespace VendaDDD.Domain.Entities
{
    public class Vendedor
    {
        public Guid Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public NivelVendedor Nivel { get; private set; }

        public Vendedor(string nomeCompleto, NivelVendedor nivel, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
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
    }
}
