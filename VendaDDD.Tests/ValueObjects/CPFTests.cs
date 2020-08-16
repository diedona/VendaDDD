using System;
using System.Collections.Generic;
using System.Text;
using VendaDDD.Shared.ValueObjects.Documentos;
using Xunit;

namespace VendaDDD.Tests.ValueObjects
{
    public class CPFTests
    {
        [Theory]
        [InlineData("465.191.456-49")]
        [InlineData("315.171.786-49")]
        public void CPF_Invalido_LancarExcecao(string cpf)
        {
             Assert.Throws<ArgumentException>(() => new CPF(cpf));
        }

        [Theory]
        [InlineData("995.037.820-66")]
        [InlineData("312.651.070-17")]
        public void CPF_Valido(string cpf)
        {
            new CPF(cpf);
        }
    }
}
