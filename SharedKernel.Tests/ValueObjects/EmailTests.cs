using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SharedKernel.Tests.ValueObjects
{
    public class EmailTests
    {
        [Fact]
        public void RetornarFalse_EmailInvalido()
        {
            Email email = new Email("diedona.zt.zt");
        }

        [Fact]
        public void RetornarTrue_EmailValido()
        {
            Email email = new Email("juricir@storm.co.uk");
        }
    }
}
