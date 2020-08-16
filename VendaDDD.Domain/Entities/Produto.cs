﻿using System;
using System.Collections.Generic;
using System.Text;
using VendaDDD.Shared.Entities;

namespace VendaDDD.Domain.Entities
{
    public class Produto : Entity
    {
        public string Descricao { get; private set; }
        public Preco Preco { get; private set; }
        public decimal? Desconto { get; private set; }
        public int QuantidadeEmMaos { get; private set; }
        public Venda Venda { get; private set; }
        public decimal ValorBruto => Preco.PrecoVenda * QuantidadeEmMaos;
        public decimal ValorLiquido => ValorBruto - Desconto.GetValueOrDefault();

        public Produto(string descricao, Preco preco, int quantidadeEmMaos, Guid? id = null) : base(id)
        {
            Descricao = descricao;
            Preco = preco;
            QuantidadeEmMaos = quantidadeEmMaos;

            Preco.DefinirProduto(this);
        }

        public void DarDesconto(decimal desconto)
        {
            if (desconto > ValorBruto)
                throw new ArgumentException("Desconto maior que o valor bruto do produto!");

            Desconto = desconto;
        }

        public void AdicionarQuantidade(int quantidade)
        {
            if (quantidade == 0)
                throw new ArgumentException("Quantidade não pode ser Zero");

            QuantidadeEmMaos += quantidade;
        }

        public void DefinirVenda(Venda venda)
        {
            Venda = venda;
        }
    }
}
