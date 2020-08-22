using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SegurancaBC.Domain.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Seguranca
{
    public class GerenciadorDeHash : IHashService
    {
        private const int ITERATION_COUNT = 10000;

        // https://docs.microsoft.com/pt-br/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-3.1
        public (string salt, string hash) GerarHash(string texto)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: texto,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: ITERATION_COUNT,
                numBytesRequested: 256 / 8));

            return (Convert.ToBase64String(salt), hashed);
        }

        public bool ValidarHash(string hashOriginal, string salt, string texto)
        {
            string textoEmHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: texto,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: ITERATION_COUNT,
                numBytesRequested: 256 / 8));

            return hashOriginal.Equals(textoEmHash);
        }
    }
}
