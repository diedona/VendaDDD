using SegurancaBC.Domain.DTO;
using SegurancaBC.Domain.DTO.Usuario;
using SegurancaBC.Domain.Entities;
using SharedKernel.Repositories;
using SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SegurancaBC.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository
    {
        Task<UsuarioAutenticacaoDTO> CarregarUsuario(Email nomeDeUsuario);
        Task InserirUsuario(Usuario usuario);
        Task AtivarUsuario(Email nomeDeUsuario);
        Task InativarUsuario(Email nomeDeUsuario);
    }
}
