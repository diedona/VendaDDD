using SharedKernel.Utils.Security;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SharedKernel.Tests.Utils.Security
{
    public class GerenciadorDeHashTests
    {
        [Fact]
        public void GerarHash()
        {
            string senha = "123456";
            var (salt, hash) = GerenciadorDeHash.GerarHash(senha);

            Assert.NotEmpty(salt);
            Assert.NotEmpty(hash);
        }

        [Fact]
        public void CompararHash_Valida()
        {
            string salt = "uTqebf7mtzq4zTjl/L3Ztg==";
            string hashOriginal = "jwG1JksNwI99mZ1HTrpeRKrUOkg4z/UHuTeV+WIx/7k=";
            string texto = "123456";

            Assert.True(GerenciadorDeHash.ValidarHash(hashOriginal, salt, texto));
        }
    }
}
