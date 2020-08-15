using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDDD.Shared.ValueObjects.Documentos
{
    public abstract class Documento
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
