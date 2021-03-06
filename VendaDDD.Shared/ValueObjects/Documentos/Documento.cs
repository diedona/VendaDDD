﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.ValueObjects.Documentos
{
    public abstract class Documento : ValueObject
    {
        public string Numero { get; private set; }
        public DateTime? DataExpiracao { get; private set; }

        public Documento(string numero, DateTime? dataExpiracao = null)
        {
            Numero = numero;
            DataExpiracao = dataExpiracao;
        }
    }
}
