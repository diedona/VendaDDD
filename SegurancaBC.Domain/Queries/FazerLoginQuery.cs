using MediatR;
using SegurancaBC.Domain.DTO.Usuario;

namespace SegurancaBC.Domain.Queries
{
    public class FazerLoginQuery : IRequest<UsuarioDTO>
    {
        public string NomeDeUsuario { get; set; }
        public string Senha { get; set; }
    }
}
