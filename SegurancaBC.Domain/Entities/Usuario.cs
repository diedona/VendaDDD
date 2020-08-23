using SegurancaBC.Domain.Services;
using SharedKernel.Entities;
using SharedKernel.ValueObjects;
using System;

namespace SegurancaBC.Domain.Entities
{
    public class Usuario : Entity
    {
        private IHashService _HashService;

        public Email NomeDeUsuario { get; private set; }
        public bool Ativo { get; private set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public Usuario(Email nomeDeUsuario, IHashService hashService = null, Guid? id = null) : base(id)
        {
            NomeDeUsuario = nomeDeUsuario;
            Ativo = false;
            _HashService = hashService;

            AddNotifications(nomeDeUsuario);
        }

        public void DefinirHashService(IHashService hashService)
        {
            _HashService = hashService;
        }

        public void DefinirSenha(string senha)
        {
            if (_HashService == null)
                throw new MemberAccessException("HashService não foi definido");

            var (salt, hash) = _HashService.GerarHash(senha);
            Password = hash;
            Salt = salt;
        }

        public bool CompararSenha(string senha)
        {
            if (_HashService == null)
                throw new MemberAccessException("HashService não foi definido");

            if (string.IsNullOrEmpty(Password))
                throw new Exception("Password não presente");

            if (string.IsNullOrEmpty(Salt))
                throw new Exception("Salt não presente");

            return _HashService.ValidarHash(Password, Salt, senha);
        }
    }
}
