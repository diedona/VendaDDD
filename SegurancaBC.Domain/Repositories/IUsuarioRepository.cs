using SegurancaBC.Domain.Entities;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario CarregarUsuario(Email nomeDeUsuario);
        void InserirUsuario(Usuario usuario);
        void AtivarUsuario(Email nomeDeUsuario);
        void InativarUsuario(Email nomeDeUsuario);
    }
}
