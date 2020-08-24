using MediatR;
using SegurancaBC.Domain.DTO.Usuario;

namespace SegurancaBC.Application.UsuarioCases.FazerLogin
{
    public class FazerLoginQuery : IRequest<UsuarioDTO>
    {
        public string NomeDeUsuario { get; set; }
        public string Senha { get; set; }
    }
}
