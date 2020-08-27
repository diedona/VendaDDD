using Infrastructure.Configurations;
using Microsoft.IdentityModel.Tokens;
using SegurancaBC.Domain.Entities;
using SegurancaBC.Domain.InfrastructureServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Seguranca
{
    public class GerenciadorDeToken : ITokenService
    {
        private readonly ITokenData _TokenData;

        public GerenciadorDeToken(ITokenData tokenData)
        {
            _TokenData = tokenData;
        }

        public string GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_TokenData.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.NomeDeUsuario.Endereco),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
