using SegurancaBC.Domain.Entities;
using SegurancaBC.Domain.Repositories;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void AtivarUsuario(Email nomeDeUsuario)
        {
            throw new NotImplementedException();
        }

        public Usuario CarregarUsuario(Email nomeDeUsuario)
        {
            throw new NotImplementedException();
        }

        public void InativarUsuario(Email nomeDeUsuario)
        {
            throw new NotImplementedException();
        }

        public void InserirUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
