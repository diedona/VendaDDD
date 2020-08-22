using SegurancaBC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario CarregarUsuario(string nomeDeUsuario);
    }
}
