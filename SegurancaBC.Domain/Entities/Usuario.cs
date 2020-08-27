using SharedKernel.Entities;
using SharedKernel.ValueObjects;
using System;

namespace SegurancaBC.Domain.Entities
{
    public class Usuario : Entity
    {
        public Email NomeDeUsuario { get; private set; }
        public bool Ativo { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }

        public Usuario(Email nomeDeUsuario, Guid? id = null) : this(nomeDeUsuario, false, id) 
        { 
        }

        public Usuario(Email nomeDeUsuario, bool ativo, Guid? id = null) : base(id)
        {
            NomeDeUsuario = nomeDeUsuario;
            Ativo = ativo;

            AddNotifications(nomeDeUsuario);
        }

        public void DefinirSenha(string salt, string hash)
        {
            Salt = salt;
            Password = hash;
        }

        public void Ativar()
        {
            Ativo = true;
        }
    }
}
