using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.ValueObjects.Documentos
{
    public class RG : Documento
    {
        public RG(string numero) : base(numero, null)
        {
        }
    }
}
