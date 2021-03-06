﻿using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel.Entities;

namespace VendaBC.Domain.Entities
{
    public class Preco : Entity
    {
        public Produto Produto { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public decimal? PrecoVista { get; private set; }
        public decimal? PrecoPrazo { get; private set; }

        public Preco(decimal precoVenda, decimal? precoVista = null, decimal? precoPrazo = null, Guid? id = null) : base(id)
        {
            PrecoVenda = precoVenda;
            PrecoVista = precoVista;
            PrecoPrazo = precoPrazo;
        }

        public void DefinirProduto(Produto produto)
        {
            Produto = produto;
        }
    }
}
