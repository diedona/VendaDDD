using FluentValidation.Results;
using SharedKernel.Entities;
using SharedKernel.Utils.Security;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Domain.Entities
{
    public class Usuario : Entity
    {
        public Email NomeDeUsuario { get; private set; }
        public bool Ativo { get; private set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public Usuario(Email nomeDeUsuario, Guid? id = null) : base(id)
        {
            NomeDeUsuario = nomeDeUsuario;
            Ativo = false;
        }

        public void DefinirSenha(string senha)
        {
            var (salt, hash) = GerenciadorDeHash.GerarHash(senha);
            Password = hash;
            Salt = salt;
        }

        public bool CompararSenha(string senha)
        {
            if (string.IsNullOrEmpty(Password))
                throw new Exception("Password não presente");

            if (string.IsNullOrEmpty(Salt))
                throw new Exception("Salt não presente");

            return GerenciadorDeHash.ValidarHash(Password, Salt, senha);
        }

        public override ValidationResult Validar()
        {
            throw new NotImplementedException();
        }
    }
}
