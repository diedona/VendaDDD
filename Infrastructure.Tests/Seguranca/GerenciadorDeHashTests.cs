using Infrastructure.Seguranca;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Infrastructure.Tests.Seguranca
{
    public class GerenciadorDeHashTests
    {
        [Fact]
        public void DeveGerarHash()
        {
            GerenciadorDeHash sut = new GerenciadorDeHash();
            (string salt, string hash) dadosHash = sut.GerarHash("123123");
            
            Assert.NotEmpty(dadosHash.salt);
            Assert.NotEmpty(dadosHash.hash);
        }

        [Fact]
        public void DeveSerIgual()
        {
            GerenciadorDeHash sut = new GerenciadorDeHash();
            Assert.True(sut.ValidarHash("P4SKLzzRnwVPNpwUrY8ZVbByszeCuI4hVDaLJKn1S5s=", "lvtBXaaN5BnHK4BGy/lYCQ==", "123123"));
        }
    }
}
