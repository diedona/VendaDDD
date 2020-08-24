using SegurancaBC.Domain.Entities;
using SegurancaBC.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Domain.DomainServices
{
    public class UsuarioService
    {
        private readonly IHashService _HashService;

        public UsuarioService(IHashService hashService)
        {
            _HashService = hashService;
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
    }
}
