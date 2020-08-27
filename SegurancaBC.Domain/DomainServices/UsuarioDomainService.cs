using SegurancaBC.Domain.Entities;
using SegurancaBC.Domain.InfrastructureServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Domain.DomainServices
{
    public class UsuarioDomainService
    {
        private readonly IHashService _HashService;
        private readonly ITokenService _TokenService;

        public UsuarioDomainService(IHashService hashService, ITokenService tokenService)
        {
            _HashService = hashService;
            _TokenService = tokenService;
        }

        public void DefinirSenha(Usuario usuario, string senha)
        {
            if (_HashService == null)
                throw new MemberAccessException("HashService não foi definido");

            var (salt, hash) = _HashService.GerarHash(senha);
            usuario.DefinirSenha(salt, hash);
        }

        public bool CompararSenha(Usuario usuario, string senha)
        {
            if (_HashService == null)
                throw new MemberAccessException("HashService não foi definido");

            if (string.IsNullOrEmpty(usuario.Password))
                throw new Exception("Password não presente");

            if (string.IsNullOrEmpty(usuario.Salt))
                throw new Exception("Salt não presente");

            return _HashService.ValidarHash(usuario.Password, usuario.Salt, senha);
        }

        public string GerarToken(Usuario usuario)
        {
            return _TokenService.GerarToken(usuario);
        }
    }
}
