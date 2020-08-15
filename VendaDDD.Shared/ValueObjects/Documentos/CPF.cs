using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDDD.Shared.ValueObjects.Documentos
{
    public class CPF : Documento
    {
        public CPF(string numero) : base(numero, null)
        {
        }
    }
}
