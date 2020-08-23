using MediatR;
using SegurancaBC.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegurancaBC.Domain.Queries
{
    public class PegarUsuarioPorNomeDeUsuarioQuery : IRequest<UsuarioDTO>
    {
        public string NomeDeUsuario { get; set; }
    }
}
